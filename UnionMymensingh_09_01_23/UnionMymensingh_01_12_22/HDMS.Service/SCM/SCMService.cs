using HDMS.Model.SCM;
using HDMS.Model.SCM.VWModel;
using HDMS.Model.Store;
using HDMS.Model.Users;
using HDMS.Repository.SCM;
using Models.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.SCM
{
    public class SCMService
    {
      

        public void SavePRApprovalSetting(SCMPRApproval apprvLevel)
        {
            new SCMRepository().SavePRApprovalSetting(apprvLevel);
        }

        public List<VMApprovalLevel> GetCurrentApprovalSetting()
        {
            return new SCMRepository().GetCurrentApprovalSetting();
        }

        public List<SCMPR> GetSCMPRWaitingList()
        {
            return new SCMRepository().GetSCMPRWaitingList();
        }

        public List<SCMPR> GetSCMApprovedPRList()
        {
            return new SCMRepository().GetSCMApprovedPRList();
        }

        public List<SCMPR> GetSCMPRList()
        {
            return new SCMRepository().GetSCMPRList();
        }

        public StoreDept GetUserIndentApproval(int userId)
        {
            return new SCMRepository().GetUserIndentApproval(userId);
        }

        public List<StoreRequisition> GetDateWiseIndenList(int deptId)
        {
            return new SCMRepository().GetDateWiseIndenList(deptId);
        }

        public List< StoreRequisition> GetndentListView(long requisitionId)
        {
            return new SCMRepository().GetndentListView(requisitionId);
        }

        public List<StoreRequisition> GetndentWaitingList(int DeptId)
        {
            return new SCMRepository().GetndentWaitingList(DeptId);
        }

        public SCMPRApproval GetUserApprovalLevel(int userId)
        {
            return new SCMRepository().GetUserApprovalLevel(userId);
        }

        public bool SaveSCMPR(SCMPR obj)
        {
            return new SCMRepository().SaveSCMPR(obj);
        }

        public void SaveSCMPRDetail(List<SCMPRDetail> itmList)
        {
            new SCMRepository().SaveSCMPRDetail(itmList);
        }

        public List<SCMPR> GetSCMPRWaitingListFor2ndLevelApproval(int userId)
        {
            return  new SCMRepository().GetSCMPRWaitingListFor2ndLevelApproval(userId);
        }

        public List<SCMPR> GetSCMPRWaitingListFor3rdLevelApproval(int userId)
        {
            throw new NotImplementedException();
        }

        public DataSet GetPOData(SCMPO poObj)
        {
            return new SCMRepository().GetPOData(poObj);
        }

        public List<SCMPRDetail> GetSCMPRDetails(long pRId)
        {
            return new SCMRepository().GetSCMPRDetails(pRId);
        }

        public void UpdateApprovedQty(SCMPRDetail selectedItem, double qty)
        {
            new SCMRepository().UpdateApprovedQty(selectedItem, qty);
        }

        public bool SavePRApprovalRecord(SCMPRAppovalRecord rObj)
        {
            return new SCMRepository().SavePRApprovalRecord(rObj);
        }

        public void SavePRApprovalRecordDetail(List<SCMPRAppovalRecordDetail> apprvRecordList)
        {
            new SCMRepository().SavePRApprovalRecordDetail(apprvRecordList);
        }

        public List<SCMPR> GetSCMPRList(DateTime dtfrm, DateTime dtto)
        {
           return  new SCMRepository().GetSCMPRList(dtfrm, dtto);
        }

        public List<StoreRequisitionDetail> GetIndentDetails(long requisitionId)
        {
            return new SCMRepository().GetIndentDetails(requisitionId);
        }

        public void UpdateHighestApprovalLevel()
        {
            new SCMRepository().UpdateHighestApprovalLevel();
        }

        public SCMPR GetSCMPR(long pRId)
        {
           return  new SCMRepository().GetSCMPR(pRId);
        }

        public void UpdatePRApprovalStatus(SCMPR pr)
        {
            new SCMRepository().UpdatePRApprovalStatus(pr);
        }

        public DataSet GetPRPrintView(long pRId)
        {
            return new SCMRepository().GetPRPrintView(pRId);
        }

        public bool SavePO(SCMPO poObj)
        {
            return new SCMRepository().SavePO(poObj);
        }

        public void SavePODetails(List<SCMPODetail> podlist)
        {
            new SCMRepository().SavePODetails(podlist);
        }

        public bool UpdateIndentStatus(StoreRequisition indentObj)
        {
            return new SCMRepository().UpdateIndentStatus(indentObj);
        }

        public void UpdateRequisitionOnApproval(List<StoreRequisitionDetail> reqList)
        {
            new SCMRepository().UpdateRequisitionOnApproval(reqList);
        }

        public void DeleteSelectedSettings(VMApprovalLevel appset)
        {
            throw new NotImplementedException();
        }

        
    }
}
