using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.ViewModel;
using System.Data;
using System.Data.SqlClient;

using System.Data.Entity;
using Models.Store;
using HDMS.Common.Utils;
using HDMS.Model.Store;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Enums;
using HDMS.Model.Users;
using HDMS.Model.SCM.VWModel;
using HDMS.Model.SCM;
using HDMS.Model.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.Diagnostic;

namespace Repositories.Store
{
    public class StoreItemRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        public void SaveGroup(StoreGroup _stgroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreGroups.Add(_stgroup);
                entities.SaveChanges();
            }
        }

        public List<StoreGroup> GetAllGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.StoreGroups.ToList ();
               
            }
        }

        public List<StoreDept> GetStoreDepts()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDepts.SqlQuery(@"Select * from StoreDepts Where Name in (Select Distinct Name from StoreDepts)").ToList();
            }
        }

        public DataSet GetROL(DateTime fromdate, DateTime todate, int ProdiuctId, int GroupId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetStoreROLStockByDate '{0}','{1}',{2},{3}", fromdate, todate, ProdiuctId, GroupId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dsStoreROL");
                return ds;
            }
        }

        public List<StoreDept> GetStoreDepartment()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDepts.ToList();
            }
        }

        public StoreDeptUser GetIndentUser(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDeptUsers.Where(x => x.UserId == userId).FirstOrDefault();
            }
        }

        public DataSet GetSupplierLedger(int memberId, DateTime dtfrm, DateTime dtto)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Exec [dbo].[SpGetSupplierLedger] {0},'{1}','{2}',''", memberId, dtfrm, dtto);

                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                con.Close();

                return dsReports;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<VMStoreRequisition> GetRequisitionListByUserByDate2(int deptId, DateTime _date)
        {
            try
            {
                sql = string.Format(@"SELECT  dbo.StoreRequisitions.RequisitionId, dbo.StoreRequisitions.DeptId, dbo.StoreRequisitions.RDate, dbo.StoreRequisitions.RTime, dbo.StoreRequisitions.OperateBy, dbo.StoreRequisitions.Status, dbo.StoreDepts.Name,dbo.StoreDepts.IndentUserId 
                                      FROM   dbo.StoreRequisitions INNER JOIN
                                      dbo.StoreDeptUsers ON dbo.StoreRequisitions.DeptId = dbo.StoreDeptUsers.DeptId join StoreDepts on dbo.StoreDeptUsers.DeptId=StoreDepts.DeptId
                                      Where dbo.StoreRequisitions.DeptId={0} and    CAST(dbo.StoreRequisitions.RDate as date)='{1}'", deptId, _date);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMStoreRequisition> _reqList = new List<VMStoreRequisition>();

                _reqList = new List<VMStoreRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetStoreRequisitionData(dRow)))
                  );

                return _reqList;

            }catch(Exception ex)
            {
                return null;

            }
        }

        public List<StoreDeptUser> GetStoreDeptIndentUserList(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDeptUsers.Where(x => x.UserId == userId).ToList();
            }
        }

        public List<VMStoreDept> GetStoreDeptUserList()
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Select d.DeptId,d.UserId, sd.Name,u.LoginName as Username from StoreDeptUsers d join [User] u on d.UserId= u.UserId
                             join [Role] r on u.RoleId=r.RoleId 
							 join StoreDepts sd on sd.DeptId=d.DeptId");


                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMStoreDept> pInfoList = new List<VMStoreDept>();


                pInfoList = new List<VMStoreDept>(
                    (from dRow in dt.AsEnumerable()
                     select (GetStoreDeptDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VMStoreDept>();

            }
        }

        public List<StoreDeptUser> GetStoreDeptListByUser2(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDeptUsers.Where(x => x.UserId == userId).ToList();
            }
        }

        public IList<VWStoreProductList> GetStoreBasicProductInfoList(string name, string type)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                if (!String.IsNullOrEmpty(name))
                {

                    sql = string.Format(@"SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.ROLIndoor,dbo.PhProductInfoes.ROLOutdoor,  dbo.PhProductInfoes.BrandName, dbo.Generics.Name AS GenericName, dbo.PhProductGroups.Name AS GroupName, dbo.PhSubGroups.Name AS SubGroup, 
                                  dbo.Manufacturers.Name AS Manufacturer, dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit,IsNull(dbo.PhProductInfoes.PkgUnit,'N/A') as PkgUnit,dbo.PhProductInfoes.QtyPerBox 
                                  FROM   dbo.PhProductInfoes INNER JOIN dbo.PhSubGroups ON dbo.PhProductInfoes.SubGroupId = dbo.PhSubGroups.SubGroupId INNER JOIN
                                  dbo.PhProductGroups ON dbo.PhSubGroups.GroupId = dbo.PhProductGroups.GroupId INNER JOIN
                                  dbo.Manufacturers ON dbo.PhProductInfoes.ManufacturerId = dbo.Manufacturers.ManufacturerId INNER JOIN
                                  dbo.Generics ON dbo.PhProductInfoes.GenericId = dbo.Generics.GenericId where BrandName like '{0}%'", name);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.ROLIndoor,dbo.PhProductInfoes.ROLOutdoor,  dbo.PhProductInfoes.BrandName, dbo.Generics.Name AS GenericName, dbo.PhProductGroups.Name AS GroupName, dbo.PhSubGroups.Name AS SubGroup, 
                                  dbo.Manufacturers.Name AS Manufacturer, dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit,IsNull(dbo.PhProductInfoes.PkgUnit,'N/A') as PkgUnit,dbo.PhProductInfoes.QtyPerBox  
                                  FROM   dbo.PhProductInfoes INNER JOIN dbo.PhSubGroups ON dbo.PhProductInfoes.SubGroupId = dbo.PhSubGroups.SubGroupId INNER JOIN
                                  dbo.PhProductGroups ON dbo.PhSubGroups.GroupId = dbo.PhProductGroups.GroupId INNER JOIN
                                  dbo.Manufacturers ON dbo.PhProductInfoes.ManufacturerId = dbo.Manufacturers.ManufacturerId INNER JOIN
                                  dbo.Generics ON dbo.PhProductInfoes.GenericId = dbo.Generics.GenericId");
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWStoreProductList> pInfoList = new List<VWStoreProductList>();


                pInfoList = new List<VWStoreProductList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetStoreBasicProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VWStoreProductList>();

            }
        }

        public bool SaveTestForReagent(List<ReagentWithTest> _rDeatailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ReagentWithTests.AddRange(_rDeatailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public long SaveBatchAndExpireInfo(StoreLotInfo pL)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.StoreLotInfoes.Add(pL);
                entities.SaveChanges();
                return pL.LotNo;
            }
        }

        public StoreLotInfo GetStoreLotInfo(string batchNo, DateTime expdate)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreLotInfoes.Where(x => x.BatchNo == batchNo.Trim() && x.ExpireDate == expdate).FirstOrDefault();
            }
        }

        public IList<VWStoreProductList> GetStockListForSale(string _filterString)
        {
            try
            {
                
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("Exec spGetStoreStock '{0}'", _filterString.Trim());
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWStoreProductList> listStockList = new List<VWStoreProductList>();


                listStockList = new List<VWStoreProductList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetStockDataTableRow(dRow)))
                    );

                return listStockList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public List<ReagentWithTest> GetReAgentsWithTest(int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReagentWithTests.Where(x => x.TestId == testId).ToList();

            }
        }

        private VWStoreProductList GetStockDataTableRow(DataRow dr)
        {
            VWStoreProductList pL = new VWStoreProductList();
            pL.ProductId = Convert.ToInt32(dr["ProductId"]);
           // pL.OutLetId = Convert.ToInt32(dr["OutLetId"]);
            pL.Name = dr["Name"].ToString();
           // pL.SupplierName = dr["SupplierName"].ToString();

            pL.BatchNo = dr["BatchNo"].ToString();
            pL.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);

            pL.StockAvailable = Convert.ToInt32(dr["CurrentStock"]);
            pL.LotNo = Convert.ToInt64(dr["LotNo"]);

            pL.PurchaseRate = Convert.ToDouble(dr["PurchaseRate"]);
            pL.SaleRate = Convert.ToDouble(dr["SaleRate"]);
            pL.Unit = dr["Unit"].ToString();


            // pL.Unit = dr["Unit"].ToString();
            return pL;
        }

        public bool SaveStoreReturnToSupplier(StoreReturnToSupplier _retToSupplier)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreReturnToSuppliers.Add(_retToSupplier);
                entities.SaveChanges();
                return true;
            }
        }

        public void UpdateStoreStockOnReturnToSupplier(List<StoreReturnProductDetil> _retDetailsList)
        {
            foreach (var item in _retDetailsList)
            {
                using (DBEntities entities = new DBEntities())
                {
                    StoreStcokInfo _phst = new StoreItemRepository().GetStoreStockInfoObj(item.LotNo, item.ProductId);
                    double _newStock = _phst.CurrentStock - item.Qty;
                    _phst.CurrentStock = _newStock;

                    entities.Entry(_phst).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        public DataSet GetStoreReturnInvoice(long returnId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Select * from VWStoreReturnInvoice Where  RetId= {0}", returnId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsStoreReturnInvoice = new DataSet();
                da.Fill(dsStoreReturnInvoice);

                con.Close();

                return dsStoreReturnInvoice;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddStoreSupplierReturnDetails(List<StoreReturnProductDetil> _retDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreReturnProductDetils.AddRange(_retDetailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public IList<VWStoreProductList> GetProductListWithStock(string _filterString)
        {
            try
            {

              

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("Exec [dbo].[spGetStoreAllProductWithStock] '{0}'", _filterString);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWStoreProductList> listStockList = new List<VWStoreProductList>();


                listStockList = new List<VWStoreProductList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetStockEntryDataTableRow(dRow)))
                    );

                return listStockList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private VWStoreProductList GetStockEntryDataTableRow(DataRow dr)
        {
            VWStoreProductList sL = new VWStoreProductList();
            sL.ProductId = Convert.ToInt32(dr["ProductId"]);
         
            sL.Name = dr["Name"].ToString();
            sL.StockAvailable = Convert.ToInt32(dr["CurrentStock"]);

            sL.PurchaseRate = Convert.ToDouble(dr["PurchaseRate"]);
            sL.SaleRate = Convert.ToDouble(dr["SaleRate"]);
            sL.Unit = dr["Unit"].ToString();

            return sL;
        }

        private VWStoreProductList GetStoreBasicProductInfoDataTableRow(DataRow dr)
        {
            VWStoreProductList _pInfo = new VWStoreProductList();
            _pInfo.ProductId = Convert.ToInt32(dr["ProductId"]);
            _pInfo.ProductCode = "";
            _pInfo.Name = dr["Name"].ToString();
           // _pInfo.GenericName = dr["GenericName"].ToString();
           // _pInfo.GroupName = dr["GroupName"].ToString();
           // _pInfo.SubGroup = dr["SubGroup"].ToString();
            //_pInfo.Manufacturer = dr["Manufacturer"].ToString();
            _pInfo.Unit = dr["Unit"].ToString();
           // _pInfo.ROLIndoor = Convert.ToInt32(dr["ROLIndoor"]);
           // _pInfo.ROLOutdoor = Convert.ToInt32(dr["ROLOutdoor"]);
            _pInfo.SaleRate = Convert.ToDouble(dr["SalePrice"]);
            _pInfo.PurchaseRate = Convert.ToDouble(dr["PurchasePrice"]);
            //if (!dr.IsNull("PkgUnit"))
            //{
            //    _pInfo.PkgUnit = dr["PkgUnit"].ToString();
            //}
            //else
            //{
            //    _pInfo.PkgUnit = "N/A";
            //}

            //_pInfo.QtyPerBox = Convert.ToInt32(dr["QtyPerBox"]);

            return _pInfo;
        }

        public DataSet GetStoreIssueStatement(DateTime fromdate, DateTime todate, int deptId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetStoreIssueStatement '{0}','{1}',{2}", fromdate, todate, deptId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dsStoreIssue");
                return ds;
            }
        }

        public DataSet GetStoreItemUsesStatement(DateTime fromdate, DateTime todate, int _deptId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetStoreItemUsesStatement '{0}','{1}',{2}", fromdate, todate, _deptId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dsStoreItemUsesStatement");
                return ds;
            }
        }

        public bool SaveStoreMasterGroup(StoreMasterGroup _stgroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreMasterGroups.Add(_stgroup);
                entities.SaveChanges();
                return true;
            }
        }

        public DataSet GetStoreExpireProductStatement(DateTime dtpfrm, DateTime dtpto, int groupId, int productId, string groupName, string productName)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec Sp_GET_Store_ExpireProduct_Stock '{0}','{1}',{2},{3},'' ,''", dtpfrm.Date, dtpto.Date, groupId, productId, groupName, productName);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtExpireStatement");
                return ds;
            }
        }

        public List<StoreDept> GetStoreDeptList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDepts.ToList();

            }
        }

        public List<VMStoreRequisition> GetRequisitionListByUserDate(int deptId, DateTime _date)
        {
            try
            {
                sql = string.Format(@"SELECT  dbo.StoreRequisitions.RequisitionId, dbo.StoreRequisitions.DeptId, dbo.StoreRequisitions.RDate, dbo.StoreRequisitions.RTime, dbo.StoreRequisitions.OperateBy, dbo.StoreRequisitions.Status, dbo.StoreDepts.Name,dbo.StoreDepts.IndentUserId 
                                      FROM   dbo.StoreRequisitions INNER JOIN
                                      dbo.StoreDepts ON dbo.StoreRequisitions.DeptId = dbo.StoreDepts.DeptId
	                                   Where dbo.StoreRequisitions.DeptId={0} and    CAST(dbo.StoreRequisitions.RDate as date)='{1}'", deptId, _date);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMStoreRequisition> _reqList = new List<VMStoreRequisition>();

                _reqList = new List<VMStoreRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetStoreRequisitionData(dRow)))
                  );

                return _reqList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpOpdOrEmgSale(List<StoreInvoiceDetail> invDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    foreach (var item in invDetailsList)
                    {
                        int Uptototal = 0;
                        OpdOrEmgStock opd = entities.OpdOrEmgStocks.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                        if (opd != null)
                        {
                            Uptototal = entities.OpdOrEmgStocks.Where(x => x.ProductId == item.ProductId).Sum(x => x.CurrentStock);
                            opd.CurrentStock = Uptototal + Convert.ToInt32(item.Qty);
                            entities.Entry(opd).State = EntityState.Modified;
                            entities.SaveChanges();
                        }
                        else
                        {
                            OpdOrEmgStock opdOrEmgStock = new OpdOrEmgStock();
                            opdOrEmgStock.ProductId = item.ProductId;
                            opdOrEmgStock.CurrentStock = Uptototal + Convert.ToInt32(item.Qty);
                            entities.OpdOrEmgStocks.Add(opdOrEmgStock);
                            entities.SaveChanges();
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public List<VWStoreAutomateRequisition> GetAvailableStockByBatchAndExpireDate(int productId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT StckId, st.LotNo, lot.BatchNo,lot.ExpireDate,st.ProductId, st.CurrentStock
                                      FROM StoreStcokInfoes st join StoreLotInfoes lot on  st.LotNo = lot.LotNo
                                      WHERE st.CurrentStock > 0 and st.ProductId = {0}  order by ExpireDate", productId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWStoreAutomateRequisition> pInfoList = new List<VWStoreAutomateRequisition>();


                pInfoList = new List<VWStoreAutomateRequisition>(
                    (from dRow in dt.AsEnumerable()
                     select (GetStoreStckDataTableRow(dRow)))
                    );

                return pInfoList;
            }
            catch
            {
                return null;
            }
        }

        private VWStoreAutomateRequisition GetStoreStckDataTableRow(DataRow dr)
        {
            VWStoreAutomateRequisition _req = new VWStoreAutomateRequisition();
            _req.LotNo = Convert.ToInt64(dr["LotNo"]);
            _req.ProductId = Convert.ToInt32(dr["ProductId"]);
            _req.BatchNo = dr["BatchNo"].ToString();
            _req.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);
            _req.Qty = Convert.ToInt32(dr["CurrentStock"]);
            return _req;
        }

        public void UpdateOrAddToStockInfo(List<StoreReceiveDetail> rDeatailsList)
        {
            foreach (var item in rDeatailsList)
            {
                using (DBEntities entities = new DBEntities())
                {
                    StoreStcokInfo _phst = this.GetStoreStockInfoObj(item.LotNo, item.ProductId);
                    if (_phst != null)
                    {
                        double _newStock = _phst.CurrentStock + item.Qty;
                        _phst.CurrentStock = _newStock;

                        entities.Entry(_phst).State = EntityState.Modified;
                        entities.SaveChanges();
                    }
                    else
                    {
                        StoreStcokInfo _st = new StoreStcokInfo();
                        _st.LotNo = item.LotNo;
                     
                        _st.ProductId = item.ProductId;
                        _st.CurrentStock = item.Qty;

                        entities.StoreStcokInfoes.Add(_st);
                        entities.SaveChanges();
                    }
                }
            }
        }

        private StoreStcokInfo GetStoreStockInfoObj(long lotNo, int productId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.StoreStcokInfoes.Where(x=>x.LotNo== lotNo && x.ProductId== productId).FirstOrDefault();
               
            }
        }

        public void StoreProductInfo(StoreProductInfo sTPInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreProductInfoes.Add(sTPInfo);
                entities.SaveChanges();
            }
        }

        public bool SaveStoreMaster(StoreItemUsesMaster _stMaster)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreItemUsesMasters.Add(_stMaster);
                entities.SaveChanges();
                return true;
            }
        }

        public bool UpdateStoreDept(StoreDept _dept)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_dept).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

       

        public List<VMPOItems> GetPOItems(long poNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                var poNum = new  SqlParameter("PONo", poNo);
                
                return entities.Database.SqlQuery<VMPOItems>(@"SELECT dbo.SCMPOes.PONo, dbo.SCMPODetails.ProductId, dbo.SCMPODetails.POQty, dbo.StoreProductInfoes.Name,IsNull(dbo.StoreProductInfoes.Unit,'') Unit, dbo.SCMPODetails.Rate 
                         FROM  dbo.StoreProductInfoes INNER JOIN
                         dbo.SCMPODetails ON dbo.StoreProductInfoes.ProductId = dbo.SCMPODetails.ProductId INNER JOIN
                         dbo.SCMPOes ON dbo.SCMPODetails.POId = dbo.SCMPOes.POId Where PONo=@PONo", poNum).ToList();
            }
        }

        public void StoreDeptUser(StoreDeptUser _stdept)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreDeptUsers.Add(_stdept);
                entities.SaveChanges();
            }
        }

        public StoreDept GetStoreDeptById(int deptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDepts.Where(x => x.DeptId == deptId).FirstOrDefault();

            }
        }

        private VMStoreDept GetStoreDeptDataTableRow(DataRow dr)
        {
            VMStoreDept Obj = new VMStoreDept();
            Obj.DeptId = Convert.ToInt32(dr["DeptId"]);
            Obj.Name = dr["Name"].ToString();
            Obj.IndentUserId = Convert.ToInt32(dr["UserId"]);
            Obj.LoginName = dr["Username"].ToString();


            return Obj;
        }

        public bool SaveStoreItemUSesDetails(List<StoreItemUsesMasterDetail> _reqDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreItemUsesMasterDetails.AddRange(_reqDetailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public List<StoreDept> GetStoreDeptListByUser(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreDepts.Where(x => x.IndentUserId == userId).ToList();

            }
        }

        public List<StoreMasterGroup> GetStoreMasterGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.StoreMasterGroups.ToList();
            }
        }

        public bool UpdateProductInfo(StoreProductInfo _P)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_P).State =EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public double GetCurrentStockByProductId(int _pId)
        {
            try
            {
                sql = string.Format("select CurrentStock from VWStoreProductInfoWithCurrentStock Where ProductId={0}", _pId);
                con = new SqlConnection(Configuration.ConnectionString);
                cmd = new SqlCommand(sql, con);
                con.Open();
                double _currentStock = Convert.ToDouble(cmd.ExecuteScalar());

                return _currentStock;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public List<VMStoreRequisition> GetRequisitionListByDate(DateTime date)
        {
            try
            {
                sql = string.Format(@"SELECT  dbo.StoreRequisitions.RequisitionId, dbo.StoreRequisitions.DeptId, dbo.StoreRequisitions.RDate, dbo.StoreRequisitions.RTime, dbo.StoreRequisitions.OperateBy, dbo.StoreRequisitions.Status,dbo.StoreRequisitions.ApprovalStatuesbyDeptHead,dbo.StoreRequisitions.IsApprovedbyDeptHead, dbo.StoreDepts.Name,dbo.StoreDepts.IndentUserId 
                                      FROM   dbo.StoreRequisitions INNER JOIN
                                      dbo.StoreDepts ON dbo.StoreRequisitions.DeptId = dbo.StoreDepts.DeptId
	                                   Where CAST(dbo.StoreRequisitions.RDate as date)='{0}' and ApprovalStatuesbyDeptHead='Approved' and IsApprovedbyDeptHead='True' and Status='Pending'", date);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMStoreRequisition> _reqList = new List<VMStoreRequisition>();

                _reqList = new List<VMStoreRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetStoreRequisitionData(dRow)))
                  );

                return _reqList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private VMStoreRequisition GetStoreRequisitionData(DataRow dr)
        {
            VMStoreRequisition _req = new VMStoreRequisition();
            _req.RequisitionId = Convert.ToInt64(dr["RequisitionId"]);
            _req.LabId = Convert.ToInt32(dr["DeptId"]);
            _req.RDate = Convert.ToDateTime(dr["RDate"]);
            _req.LabName = dr["Name"].ToString();
            _req.RequisitionbyId = Convert.ToInt32(dr["IndentUserId"]);
            _req.Status = dr["Status"].ToString();
            return _req;
        }

        public double GetCurrentPurchaseRateByProductId(int _pId)
        {
            try
            {
                sql = string.Format("select PurchaseRate from VWStoreProductInfoWithCurrentStock Where Id={0}", _pId);
                con = new SqlConnection(Configuration.ConnectionString);
                cmd = new SqlCommand(sql, con);
                con.Open();
                double _currentPurchase = Convert.ToDouble(cmd.ExecuteScalar());

                return _currentPurchase;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public long SaveRequisition(StoreRequisition _hpMReq)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreRequisitions.Add(_hpMReq);
                entities.SaveChanges();
                return _hpMReq.RequisitionId;
            }
        }

        public bool SaveRequisitionDetails(List<StoreRequisitionDetail> _reqDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreRequisitionDetails.AddRange(_reqDetailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public bool CreateDepartment(StoreDept _dept)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreDepts.Add(_dept);
                entities.SaveChanges();
                return true;
            }
        }

        public StoreReceive GetStoreLastestReceiveInvoice()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreReceives.SqlQuery("Select * from StoreReceives Where ReceiveId=(Select Max(ReceiveId) from StoreReceives)").FirstOrDefault();
            }
        }

        public IList<StoreReceiveDetail> GetStoreReceiveDetails(long receiveId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreReceiveDetails.Where(x => x.ReceiveId == receiveId).ToList();

            }
        }

        public StoreReceive GetStoreFirstReceiveInvoice()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreReceives.SqlQuery("Select * from StoreReceives Where ReceiveId=(Select MIn(ReceiveId) from StoreReceives)").FirstOrDefault();
            }
        }

        public StoreReceive GetStoreReceiveInvoiceById(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreReceives.Where(x => x.ReceiveId == _billNo).FirstOrDefault();

            }
        }

        public List<VMRequisitionList> GetStoreRequisitionDetailByReqId(long requisitionId)
        {
            try
            {
                sql = string.Format(@"Exec [dbo].[spGetStoreRequisitionData] {0}", requisitionId);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                List<VMRequisitionList> listhp = new List<VMRequisitionList>();

                listhp = new List<VMRequisitionList>(
                  (from dRow in dt.AsEnumerable()
                   select (GetRequisitionDataRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private VMRequisitionList GetRequisitionDataRow(DataRow dr)
        {
            double _stockAvail = 0;

            VMRequisitionList obj = new VMRequisitionList();

            obj.RequisitionId = Convert.ToInt64(dr["RequisitionId"]);

            obj.ProductId = Convert.ToInt32(dr["ProductId"]);

            obj.BrandName = dr["Name"].ToString();
            obj.ReqQty = Convert.ToDouble(dr["ReqQty"]);
            if (!dr.IsNull("AvailQty"))
            {
                _stockAvail = Convert.ToDouble(dr["AvailQty"]);
                obj.StockAvailable = Convert.ToDouble(dr["AvailQty"]);
            }
            else
            {
                obj.StockAvailable = 0;
            }

            obj.PurchasePrice = Convert.ToDouble(dr["PurchaseRate"]);
            obj.SalePrice = Convert.ToDouble(dr["SaleRate"]);

            if (Convert.ToDouble(dr["ReqQty"]) <= _stockAvail)
            {
                obj.IsStockShort = false;
            }
            else
            {
                obj.IsStockShort = true;
            }

            obj.ItemDeliveryStatus = dr["Status"].ToString();

            return obj;

        }

        public void UpdateRequisition(long _requisitionNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                StoreRequisition _req = this.GetStoreRequisitionByReqId(_requisitionNo);
                _req.Status = RequisitionStatusEnum.Served.ToString();

                entities.Entry(_req).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public IList<StoreInvoiceDetail> GetStoreInvoiceDetails(long invoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreInvoiceDetails.Where(x => x.InvoiceId == invoiceId).ToList();

            }
        }

        public StoreInvoice GetStoreFirstIssueInvoice()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreInvoices.SqlQuery("Select * from StoreInvoices Where InvoiceId=(Select MIn(InvoiceId) from StoreInvoices)").FirstOrDefault();
            }
        }

        public StoreInvoice GetStoreLastestIssueInvoice()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreInvoices.SqlQuery("Select * from StoreInvoices Where InvoiceId=(Select Max(InvoiceId) from StoreInvoices)").FirstOrDefault();
            }
        }

        public StoreInvoice GetStoreIssueInvoiceById(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreInvoices.Where(x => x.InvoiceId == _billNo).FirstOrDefault();

            }
        }

        public StoreRequisition GetStoreRequisitionByReqId(long _requisitionNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreRequisitions.Where(x => x.RequisitionId == _requisitionNo).FirstOrDefault();

            }
        }

        public IList<StoreProductInfo> GetAllProduct()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreProductInfoes.ToList();

            }
        }

        public StoreProductInfo GetProductById(int productId)
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.StoreProductInfoes.Where(x=>x.ProductId== productId).FirstOrDefault();
                
            }
        }

        public StoreProductInfo GetProductByCode(string _PCode)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreProductInfoes.Where(x => x.ProductCode == _PCode).FirstOrDefault();

            }
        }

        public bool SaveReceiveDetails(List<StoreReceiveDetail> _rDeatailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreReceiveDetails.AddRange(_rDeatailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public StoreInvoice GetInvoiceByInvoiceNo(long _InvoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.StoreInvoices.Where(x=>x.InvoiceId== _InvoiceId).FirstOrDefault();
               
            }
        }

        public void AddNewInvDetails(List<StoreInvoiceDetail> _invDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreInvoiceDetails.AddRange(_invDetailsList);
                entities.SaveChanges();
              
            }
        }

        public long AddNewInvoice(StoreInvoice _invoice)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreInvoices.Add(_invoice);
                entities.SaveChanges();
                return _invoice.InvoiceId;
            }
        }

        public long SaveReceivedInvoice(StoreReceive _receive)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.StoreReceives.Add(_receive);
                  entities.SaveChanges();
                return _receive.ReceiveId;
            }
        }

        public IList<VMStoreItemInfo> GetBasicItemInfoList(string name, string _type)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                if (!String.IsNullOrEmpty(name))
                {

                    sql = string.Format(@"SELECT dbo.StoreProductInfoes.ProductId, dbo.StoreProductInfoes.ProductCode, dbo.StoreProductInfoes.Name, dbo.StoreProductInfoes.PurchaseRate, dbo.StoreProductInfoes.SaleRate, dbo.StoreProductInfoes.Unit,dbo.StoreProductInfoes.ROL, dbo.StoreProductInfoes.DebitAccId, dbo.StoreProductInfoes.CreditAccId ,dbo.StoreGroups.Name AS GroupName
                                           FROM dbo.StoreProductInfoes INNER JOIN
                                          dbo.StoreGroups ON dbo.StoreProductInfoes.GroupId = dbo.StoreGroups.GroupId  Where dbo.StoreProductInfoes.Name like '{0}%'", name);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.StoreProductInfoes.ProductId, dbo.StoreProductInfoes.ProductCode, dbo.StoreProductInfoes.Name, dbo.StoreProductInfoes.PurchaseRate, dbo.StoreProductInfoes.SaleRate, dbo.StoreProductInfoes.Unit,dbo.StoreProductInfoes.ROL, dbo.StoreProductInfoes.DebitAccId, dbo.StoreProductInfoes.CreditAccId ,dbo.StoreGroups.Name AS GroupName
                                           FROM dbo.StoreProductInfoes INNER JOIN
                                          dbo.StoreGroups ON dbo.StoreProductInfoes.GroupId = dbo.StoreGroups.GroupId");
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMStoreItemInfo> pInfoList = new List<VMStoreItemInfo>();


                pInfoList = new List<VMStoreItemInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBasicProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VMStoreItemInfo>();

            }
        }

        private VMStoreItemInfo GetBasicProductInfoDataTableRow(DataRow dr)
        {
            VMStoreItemInfo _itemInfo = new VMStoreItemInfo();
            _itemInfo.ProductId = Convert.ToInt32(dr["ProductId"]);
            _itemInfo.ProductCode = dr["ProductCode"].ToString();
            _itemInfo.ProductName = dr["Name"].ToString();
            _itemInfo.PurchaseRate = Convert.ToDouble(dr["PurchaseRate"]);
            _itemInfo.SaleRate = Convert.ToDouble(dr["SaleRate"]);
            _itemInfo.ROL = Convert.ToInt32(dr["ROL"]);
            if (!dr.IsNull("DebitAccId"))
            {
                
                _itemInfo.DebitAccId = (int)dr["DebitAccId"];
            }
            else
            {
                _itemInfo.DebitAccId = 0;
            }

            if (!dr.IsNull("CreditAccId"))
            {

                _itemInfo.CreditAccId = (int)dr["CreditAccId"];
            }
            else
            {
                _itemInfo.CreditAccId = 0;
            }

         
            _itemInfo.GroupName = dr["GroupName"].ToString();
            _itemInfo.Unit = dr["Unit"].ToString();

            return _itemInfo;
        }

        public DataSet GetStoreStockStatement(DateTime dtpfrm, DateTime dtpto, int groupId, int productId, string groupName, string productName)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec sp_Get_Store_Stock_By_Date '{0}','{1}',{2},{3},'' ,'All'", dtpfrm.Date, dtpto.Date, groupId, productId, groupName, productName);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtStockReport");
                return ds;
            }
        }
    }
}
