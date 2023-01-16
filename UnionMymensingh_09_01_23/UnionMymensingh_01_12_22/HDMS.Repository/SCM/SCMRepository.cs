using HDMS.Common.Utils;
using HDMS.Model.SCM;
using HDMS.Model.SCM.VWModel;
using HDMS.Model.Store;
using HDMS.Model.Users;
using Models.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.SCM
{
    public class SCMRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;

        public void SavePRApprovalSetting(SCMPRApproval apprvLevel)
        {
            using (DBEntities entities=new DBEntities())
            {
                entities.SCMPRApprovals.Add(apprvLevel);
                entities.SaveChanges();
            }
        }

        public List<VMApprovalLevel> GetCurrentApprovalSetting()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMApprovalLevel>(@"SELECT dbo.SCMPRApprovals.Id, dbo.SCMPRApprovals.ApprovLevel,dbo.SCMPRApprovals.ApprovebyUserId, dbo.SCMPRApprovals.LevelTagKey, dbo.[User].LoginName as UserName, dbo.[User].FullName, dbo.Role.Name AS Role
                                                                     FROM dbo.SCMPRApprovals INNER JOIN dbo.[User] ON dbo.SCMPRApprovals.ApprovebyUserId = dbo.[User].UserId INNER JOIN
                                                                     dbo.Role ON dbo.[User].RoleId = dbo.Role.RoleId").ToList();
            }
        }

        public List<SCMPR> GetSCMPRList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SCMPRs.ToList();

            }
        }

        public List<StoreRequisition> GetDateWiseIndenList(int deptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreRequisitions.ToList();

            }
        }

        public List<StoreRequisition> GetndentListView(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreRequisitions.Where(x => x.RequisitionId == requisitionId).ToList();

            }
        }

        public List<StoreRequisition> GetndentWaitingList(int DeptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreRequisitions.Where(x => x.DeptId == DeptId && x.IsApprovedbyDeptHead == false && x.ApprovalStatuesbyDeptHead.ToLower().Equals("pending")).ToList();

            }
        }

        public StoreDept GetUserIndentApproval(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDepts.Where(x => x.ApprovalUserId == userId).FirstOrDefault();

            }
        }

        public List<SCMPR> GetSCMApprovedPRList()
        {
            using (DBEntities entiteis = new DBEntities())
            {
                return entiteis.SCMPRs.Where(x => x.PRApprovalStatus == true && x.PRStatus == "Approved").ToList();
            }
        }

        public DataSet GetPOData(SCMPO poObj)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                sql = string.Format(@"SELECT  pr.POId,pr.PODate,pr.PONo,pr.POFor,pr.POCreator,u.LoginName as Preparedby, pr.POStatus, prd.ProductId, prd.POQty as Qty, 
                                       prd.Rate, prd.POQty*prd.Rate as Total,p.Name,p.Unit,s.Name as SupplierName,s.SupplierId FROM dbo.SCMPOes pr INNER JOIN
                                       dbo.SCMPODetails prd ON pr.POId = prd.POId INNER JOIN
									   SupplierInfoes s on pr.SupplierId=s.SupplierId INNER JOIN
                                       dbo.StoreProductInfoes p ON prd.ProductId = p.ProductId join [User] u on u.UserId=pr.POCreator  Where  pr.POId = {0}", poObj.POId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtPO");

                return ds;

            }
        }

        public List<SCMPR> GetSCMPRList(DateTime dtfrm, DateTime dtto)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SCMPRs.Where(x => x.PRDate >= dtfrm.Date && x.PRDate<= dtto.Date).ToList();

            }
        }

        public List<StoreRequisitionDetail> GetIndentDetails(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreRequisitionDetails.Where(x => x.RequisitionId == requisitionId).ToList();

            }
        }

        public List<SCMPR> GetSCMPRWaitingListFor2ndLevelApproval(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                
                return entities.Database.SqlQuery<SCMPR>(@"Select * from SCMPRs Where PRApprovalStatus=0 and PRStatus='level2' and PRId in (Select PRId from SCMPRAppovalRecords Where ApprovebyUserId in (Select ApprovebyUserId from SCMPRApprovals Where LevelTagKey='level1'))").ToList();
            }
        }

        

        public void UpdateRequisitionOnApproval(List<StoreRequisitionDetail> reqList)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach(var item in reqList)
                {
                    entities.Entry(item).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        public bool UpdateIndentStatus(StoreRequisition indentObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(indentObj).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public void UpdateApprovedQty(SCMPRDetail selectedItem, double qty)
        {
            using (DBEntities entities = new DBEntities())
            {
                selectedItem.FinalApprovedQty = qty;
                entities.Entry(selectedItem).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void SavePRApprovalRecordDetail(List<SCMPRAppovalRecordDetail> apprvRecordList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.SCMPRAppovalRecordDetails.AddRange(apprvRecordList);
                entities.SaveChanges();
              
            }
        }

        public void UpdatePRApprovalStatus(SCMPR pr)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(pr).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void SavePODetails(List<SCMPODetail> podlist)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.SCMPODetails.AddRange(podlist);
                entities.SaveChanges();

              
            }
        }

        public bool SavePO(SCMPO poObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.SCMPOes.Add(poObj);
                entities.SaveChanges();

                return true;
            }
        }

        public DataSet GetPRPrintView(long pRId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                sql = string.Format(@"SELECT  pr.PRId,pr.PRDate,pr.PRNo,pr.PRFor,pr.PRCreator,u.LoginName as Preparedby,   pr.PRApprovalStatus,pr.PRStatus, prd.ProductId, prd.PRQty, 
                                       prd.FinalApprovedQty, prd.Rate, p.Name,p.Unit FROM dbo.SCMPRs pr INNER JOIN
                                       dbo.SCMPRDetails prd ON pr.PRId = prd.PRId INNER JOIN
                                       dbo.StoreProductInfoes p ON prd.ProductId = p.ProductId join [User] u on u.UserId=pr.PRCreator  Where  pr.PRId = {0}", pRId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtPR");

                return ds;

            }
        }

        public SCMPR GetSCMPR(long pRId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.SCMPRs.Where(x=>x.PRId== pRId).FirstOrDefault();

            }
        }

        public void UpdateHighestApprovalLevel()
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand(@"Update SCMPRApprovals Set IsThisTheHighestLevelApproval=0");
               
            }
        }

        public bool SavePRApprovalRecord(SCMPRAppovalRecord rObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.SCMPRAppovalRecords.Add(rObj);
                 entities.SaveChanges();
                 return true;
            }
        }

        public List<SCMPRDetail> GetSCMPRDetails(long pRId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SCMPRDetails.Where(x => x.PRId == pRId).ToList();

            }
        }

        public List<SCMPR> GetSCMPRWaitingList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SCMPRs.Where(x => x.PRApprovalStatus == false && x.PRStatus.ToLower().Equals("level1")).ToList();

            }
        }

        public SCMPRApproval GetUserApprovalLevel(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.SCMPRApprovals.Where(x=>x.ApprovebyUserId== userId).FirstOrDefault();
            
            }
        }

        public void SaveSCMPRDetail(List<SCMPRDetail> itmList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.SCMPRDetails.AddRange(itmList);
                entities.SaveChanges();
                
            }
        }

        public bool SaveSCMPR(SCMPR obj)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.SCMPRs.Add(obj);
                entities.SaveChanges();
                return true;
            }
        }
    }
}
