
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using HDMS.Models.Pharmacy;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Common.Utils;
using HDMS.Model.Pharmacy;
using System.Data.Entity;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Hospital;
using System.Threading.Tasks;
using HDMS.Model.Accounting.VModel;

namespace HDMS.Repositories.Pharmacy
{
    public class PhProductRepository
    {

        string sql = string.Empty;
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        public bool SaveProduct(PhProductInfo PhP_Info)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhProductInfos.Add(PhP_Info);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public DataSet GetPhCompanyWiseDailySaleSummary(DateTime dtp)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Exec spDailySummary '{0}'", dtp);
                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);
                con.Close();

                return dsReports;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public List<VWPhStockWithLotAndExpireInfo> GetPhStockList(int productId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter pordId = new SqlParameter("@ProductId", productId);

                return entities.Database.SqlQuery<VWPhStockWithLotAndExpireInfo>(@"Select st.*,lot.BatchNo,lot.ExpireDate from PhStockInfoes st join PhLotInfoes lot on st.LotNo=lot.LotNo
                 Where ProductId = @ProductId and st.CurrentStock>0", pordId).ToList();
            }
        }

        public DataSet GetPhCompanyWiseDailySalePurchase(DateTime dtpfrm, DateTime dtpto)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Exec spCompanyWiseSalePurchase '{0}','{1}'", dtpfrm, dtpto);
                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);
                con.Close();

                return dsReports;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public IList<VWPhProductInfo> GetProductListBySpace()
        {
            using (DBEntities entities = new DBEntities())
            {
                return (IList<VWPhProductInfo>)entities.Manufacturers.ToList();


            }
        }

        public List<VMOutletMedicineRequisition> GetAllPhOutletRequisition(DateTime dt)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var _date = new SqlParameter("ReqDate", dt.Date);
                    return entities.Database.SqlQuery<VMOutletMedicineRequisition>(@"Select r.RequisitionId,r.[FromOutletId],m.Name as FromOutlet, r.[ToOutletId],m2.Name as ToOutlet, r.ReqDate,r.RequisitionBy, r.Status as RequisitionStatus,'' as ItemStatus from [dbo].[PhOutletMedicinieRequisitions] r 
                    join MedicineOutlets m on r.FromOutletId = m.OutLetId join MedicineOutlets m2 on r.ToOutletId = m2.OutLetId  where r.ReqDate=@ReqDate and Status='Pending'", _date).ToList();

                }
                catch (Exception ex)
                {
                    return new List<VMOutletMedicineRequisition>();
                }

            }
        }

        public List<VMOutletMedicineRequisition> GetPhOutletRequisitionList(int outletId, DateTime dt)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var outlet = new SqlParameter("FromOutletId", outletId.ToString());
                    var _date = new SqlParameter("ReqDate", dt.Date);
                    return entities.Database.SqlQuery<VMOutletMedicineRequisition>(@"Select r.RequisitionId,r.[FromOutletId],m.Name as FromOutlet, r.[ToOutletId],m2.Name as ToOutlet, r.ReqDate,r.RequisitionBy, r.Status as RequisitionStatus,'' as ItemStatus from [dbo].[PhOutletMedicinieRequisitions] r 
                    join MedicineOutlets m on r.FromOutletId = m.OutLetId join MedicineOutlets m2 on r.ToOutletId = m2.OutLetId  where  r.FromOutletId=@FromOutletId and r.ReqDate=@ReqDate", outlet, _date).ToList();

                }
                catch (Exception ex)
                {
                    return new List<VMOutletMedicineRequisition>();
                }

            }
        }

        public DataSet GetPhOpeningClosingStock(DateTime dtpfrm, DateTime dtpto)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Exec SP_Get_Current_Product_Stock_Date_Wise_History '{0}','{1}'", dtpfrm.Date, dtpto.Date);
                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);
                con.Close();

                return dsReports;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public DataSet GetPhProductLedger(DateTime dtfrm, DateTime dtto, VWPhProductList phProductInfo, int outletId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Select * from  VWPhProductLedger Where TDate between '{0}' and '{1}' and ProductId={2} and OutletId={3} order by TranId", dtfrm, dtto, phProductInfo.ProductId, outletId);
                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);
                con.Close();

                return dsReports;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public bool SaveMapProductWithRackAndBlock(List<PhProductLocation> prodLocList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhProductLocations.AddRange(prodLocList);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<VMPhProductMapWithRackAndBlock> GetPhMappedProductWithManufacturer(int manufacturerId, int genId, int outletId)
        {
            using (DBEntities entities = new DBEntities())
            {

                if (manufacturerId > 0)
                    return entities.Database.SqlQuery<VMPhProductMapWithRackAndBlock>(@"Select p.ProductId,p.BrandName,p.ManufacturerId,p.GenericId,m.Name as Manufacturer, g.Name as Generic,isNull(ploc.OutLetId,0) OutLetId,IsNull(ploc.RackNo,'') RackNo,ISNULL(ploc.BlockNo,'') BlockNo from PhProductInfoes p join Manufacturers m on p.ManufacturerId=m.ManufacturerId
                     join Generics g on p.GenericId=g.GenericId left join PhProductLocations ploc on 
                     p.ProductId=ploc.ProductId left join MedicineOutlets outlet on ploc.OutLetId=outlet.OutLetId
                     where p.ManufacturerId=@manufacturerId and ploc.OutLetId=@outletId", new SqlParameter("@manufacturerId", manufacturerId), new SqlParameter("@outletId", outletId)).ToList();

                return entities.Database.SqlQuery<VMPhProductMapWithRackAndBlock>(@"Select p.ProductId,p.BrandName,p.ManufacturerId,p.GenericId,m.Name as Manufacturer, g.Name as Generic,isNull(ploc.OutLetId,0) OutLetId,IsNull(ploc.RackNo,'') RackNo,ISNULL(ploc.BlockNo,'') BlockNo from PhProductInfoes p join Manufacturers m on p.ManufacturerId=m.ManufacturerId
                     join Generics g on p.GenericId=g.GenericId left join PhProductLocations ploc on 
                     p.ProductId=ploc.ProductId left join MedicineOutlets outlet on ploc.OutLetId=outlet.OutLetId
                     where p.GenericId=@genericId and ploc.OutLetId=@outletId", new SqlParameter("@genericId", genId), new SqlParameter("@outletId", outletId)).ToList();

            }
        }

        public Manufacturer GetManufacturerById(int supplerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Manufacturers.Where(x => x.ManufacturerId == supplerId).FirstOrDefault();
            }
        }

        public List<PhProductInfo> GetProductListByGeneric(int genericId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductInfos.Where(x => x.GenericId == genericId).ToList();

            }
        }

        public void UpdatePhLotInfo(PhLotInfo lotInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(lotInfo).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public PhLotInfo GetPhLotInfo(long lotNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhLotInfoes.Where(x => x.LotNo == lotNo).FirstOrDefault();
            }
        }

        public PhStockInfo GetPhStockInfo(long stckId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhStockInfoes.Where(x => x.StckId == stckId).FirstOrDefault();
            }
        }

        public List<VMPhSoldItem> GetPhSoldItems(long invoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter InvoiceId = new SqlParameter("InvoiceId", invoiceId);

                return entities.Database.SqlQuery<VMPhSoldItem>(@"Select invd.InvoiceId,invd.LotNo,inv.OutLetId, p.ProductId,f.ShortFormation +' '+ p.BrandName as BrandName, invd.Qty, invd.RetQty,p.Unit,invd.SaleRate,invd.TotalPrice from PhInvoiceDetails invd join PhProductInfoes p on invd.ProductId = p.ProductId join Formations f on p.FormationId=f.FormationId join
                 PhInvoices inv on inv.InvoiceId=invd.InvoiceId Where inv.InvoiceId=@InvoiceId", InvoiceId).ToList();
            }
        }

        public List<PhProductInfo> GetPhProductListByManufacturer(int manufacturerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductInfos.Where(x => x.ManufacturerId == manufacturerId).ToList();
            }
        }

        public DataSet GetAuditedStockData(long _asmId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Select * from  VWAuditedStock Where AMId={0}", _asmId);
                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);
                con.Close();

                return dsReports;

            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public List<PhStockInfo> GetPhStockListByProdId(int prodId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhStockInfoes.Where(x => x.ProductId == prodId).ToList();
            }
        }

        private VWAuditedStock GetPhAuditedStockDataTableRow(DataRow dr)
        {
            VWAuditedStock _os = new VWAuditedStock();
            _os.ProductId = Convert.ToInt32(dr["ProductId"]);
            _os.BrandName = dr["BrandName"].ToString();
            _os.Manufacturer = dr["Manufacturer"].ToString();
            _os.SoftWareStock = Convert.ToDouble(dr["SoftWareStock"]);
            _os.PhysicalStock = Convert.ToDouble(dr["PhysicalStock"]);
            _os.SoftValue = Convert.ToDouble(dr["SoftValue"]);
            _os.PhysicalVal = Convert.ToDouble(dr["PhysicalVal"]);

            return _os;
        }

        public bool IsOpeningStockSet(DateTime _date)
        {
            using (DBEntities entities = new DBEntities())
            {
                var Obj = entities.PhStockInfoesDateWiseHistories.Where(x => x.FilterDate == _date.Date).FirstOrDefault();
                if (Obj != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IList<VMPhStock> GetPhStock(int outLetId, string searchString, int manufacturerId)
        {
            try
            {



                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                if (String.IsNullOrEmpty(searchString))
                {
                    sql = string.Format(@"Exec spGetPhStockByOutlet {0},0,'',{1}", outLetId, manufacturerId);

                }
                else
                {
                    sql = string.Format(@"Exec spGetPhStockByOutlet {0},0,'{1}',{2}", outLetId, searchString, manufacturerId);
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMPhStock> listStockList = new List<VMPhStock>();


                listStockList = new List<VMPhStock>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPhStockDataTableRow(dRow)))
                    );

                return listStockList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public IList<VMPhProductListForRxPerspective> GetBasicProductInfoListForRxPerspective(string brand, string generic)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    var _brand = new SqlParameter("@BrandName", brand);
                    var _generic = new SqlParameter("@Generic", generic);

                    return entities.Database.SqlQuery<VMPhProductListForRxPerspective>(@"Exec [dbo].[spGetPhProductBasicInfoListRxPerspective] @BrandName,@Generic", _brand, _generic).ToList();


                }
                catch (Exception ex)
                {
                    return new List<VMPhProductListForRxPerspective>();
                }
            }

        }

        public PhStockTransferRecord GetPhStockTransferRecord(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhStockTransferRecords.Where(x => x.RequisitionNo == requisitionId).FirstOrDefault();

            }
        }

        public void UpdatePhProductInfo(PhProductInfo _pInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_pInfo).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public List<VMIssuedProductAgainstRequisition> GetOutletIssuedProductAgainstRequisition(PhStockTransferRecord phTransferRecord)
        {
            using (DBEntities entities = new DBEntities())
            {
                var _StTId = new SqlParameter("StTId", phTransferRecord.StTId);
                return entities.Database.SqlQuery<VMIssuedProductAgainstRequisition>(@"SELECT   p.ProductId, f.ShortFormation+' '+p.BrandName as BrandName,Sum(Convert(int,std.Qty)) as Qty
                 FROM PhStockTransferRecords strec join PhStockTransferRecordDetails std on strec.StTId=std.StTId 
                 join PhProductInfoes p on p.ProductId=std.ProductId join Formations f on p.FormationId=f.FormationId
                 Where strec.StTId=@StTId
                 group by  p.ProductId, f.ShortFormation,p.BrandName  
                 ", _StTId).ToList();
            }
        }

        public void UpdateOutletRequisition(PhOutletMedicinieRequisition mreq)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(mreq).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
        public async Task<PhOutletMedicinieRequisition> CreateNewPhOutletRequistion(PhOutletMedicinieRequisition hpMReq, List<PhOutletMedicineRequisitionDetail> reqDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        entities.PhOutletMedicinieRequisitions.Add(hpMReq);
                        entities.SaveChanges();

                        List<PhOutletMedicineRequisitionDetail> _reqList = new List<PhOutletMedicineRequisitionDetail>();
                        foreach (var item in reqDetailsList)
                        {
                            item.RequisitionId = hpMReq.RequisitionId;
                            _reqList.Add(item);
                        }

                        if (_reqList.Count > 0)
                        {
                            entities.PhOutletMedicineRequisitionDetails.AddRange(_reqList);
                            entities.SaveChanges();
                        }
                        else
                        {
                            transaction.Rollback();
                            return await Task.FromResult(new PhOutletMedicinieRequisition() { RequisitionId = 0 });
                        }

                        transaction.Commit();
                        return await Task.FromResult(hpMReq);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return await Task.FromResult(new PhOutletMedicinieRequisition() { RequisitionId = 0 });
                    }
                }
            }
        }

        public List<VMOutletRequisitionList> GetOutletMedicineRequisitionDetailByReqId(long requisitionId, int fromOutletId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var reqId = new SqlParameter("RequisitionId", requisitionId);
                    var outlet = new SqlParameter("FromOutletId", fromOutletId);
                    return entities.Database.SqlQuery<VMOutletRequisitionList>(@"Exec [dbo].[spGetOutletRequisitionData] @RequisitionId,@FromOutletId", reqId, outlet).ToList();

                }
                catch (Exception ex)
                {
                    return new List<VMOutletRequisitionList>();
                }
            }
        }

        public void CancelOutletMedicineRequisition(long requisitionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                conn.Open();
                sql = string.Format("Update PhOutletMedicinieRequisitions Set Status='Cancelled' Where RequisitionId={0}", requisitionId);
                cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public PhOutletMedicinieRequisition GetOutletMedicineRequisitionByReqId(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhOutletMedicinieRequisitions.Where(x => x.RequisitionId == requisitionId).FirstOrDefault();
            }
        }

        public IList<VWPhProductList> GetBasicProductInfoListByGeneric(int genId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();



                sql = string.Format(@"SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.GenericId,dbo.PhProductInfoes.FormationId,dbo.PhProductInfoes.ROLIndoor,dbo.PhProductInfoes.ROLOutdoor,  dbo.PhProductInfoes.BrandName, g.Name as GroupName, dbo.Generics.Name AS GenericName, 
                                  dbo.Manufacturers.Name AS Manufacturer, dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit,IsNull(dbo.PhProductInfoes.PkgUnit,'N/A') as PkgUnit,dbo.PhProductInfoes.QtyPerBox,
								  dbo.PhProductInfoes.SideEffact,dbo.PhProductInfoes.DoseLongBn,dbo.PhProductInfoes.DoseLongEn,dbo.PhProductInfoes.DoseShortBn,dbo.PhProductInfoes.DoseShortEn 
                                  FROM   dbo.PhProductInfoes Left JOIN dbo.Generics ON dbo.PhProductInfoes.GenericId = dbo.Generics.GenericId Left JOIN
								  PhProductGroups g on g.GroupId = dbo.Generics.GroupId Left JOIN
                                  dbo.Manufacturers ON dbo.PhProductInfoes.ManufacturerId = dbo.Manufacturers.ManufacturerId
                                       where dbo.PhProductInfoes.GenericId = {0} ", genId);


                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductList> pInfoList = new List<VWPhProductList>();


                pInfoList = new List<VWPhProductList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBasicProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VWPhProductList>();

            }

        }

        public PhOutletMedicineRequisitionDetail GetPhMedicineRequisitionDetail(long requisitionId, int productId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.PhOutletMedicineRequisitionDetails.Where(x => x.RequisitionId == requisitionId && x.ProductId == productId).FirstOrDefault();
            }
        }

        public async Task<List<VMPhProductListForRxPerspective>> GetBasicProductInfoListAsync(string brand, string generic)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    var _brand = new SqlParameter("@BrandName", brand);
                    var _generic = new SqlParameter("@Generic", generic);

                    return await entities.Database.SqlQuery<VMPhProductListForRxPerspective>(@"Exec [dbo].[spGetPhProductBasicInfoListRxPerspective] @BrandName,@Generic", _brand, _generic).ToListAsync();


                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new List<VMPhProductListForRxPerspective>());
                }
            }
        }

        public IList<VWRxPhProductList> GetFilteredRxCpPreferredProductListWithStock(string brand, string generic, string formation, int cpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    var _brand = new SqlParameter("@BrandName", brand);
                    var _generic = new SqlParameter("@Generic", generic);
                    var _formation = new SqlParameter("@Formation", formation);
                    var _cpId = new SqlParameter("@CpId", cpId);
                    return entities.Database.SqlQuery<VWRxPhProductList>(@"Exec [dbo].[spGetPhRxCpPreferredProductWithStock] @BrandName,@Generic,@Formation,@CpId", _brand, _generic, _formation, _cpId).ToList();


                }
                catch (Exception ex)
                {
                    return new List<VWRxPhProductList>();
                }
            }
        }

        public IList<VWRxPhProductList> GetFilteredRxProductListWithStock(string brand, string generic, string formation)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    var _brand = new SqlParameter("@BrandName", brand);
                    var _generic = new SqlParameter("@Generic", generic);
                    var _formation = new SqlParameter("@Formation", formation);

                    return entities.Database.SqlQuery<VWRxPhProductList>(@"Exec [dbo].[spGetPhRxProductWithStock] @BrandName,@Generic,@Formation", _brand, _generic, _formation).ToList();


                }
                catch (Exception ex)
                {
                    return new List<VWRxPhProductList>();
                }
            }
        }

        public IList<VWRxPhProductList> GetRxProductListWithStock(string branName)
        {

            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    var _brand = new SqlParameter("@BrandName", branName);
                    var _generic = new SqlParameter("@Generic", "");
                    var _formation = new SqlParameter("@Formation", "");

                    return entities.Database.SqlQuery<VWRxPhProductList>(@"Exec [dbo].[spGetPhRxProductWithStock] @BrandName,@Generic,@Formation", _brand, _generic, _formation).ToList();


                }
                catch (Exception ex)
                {
                    return new List<VWRxPhProductList>();
                }
            }

        }
        public DataSet GetPhStockTransferStatement(DateTime dtpfrm, DateTime dtpto, int fromoutLetId, int tooutletd)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.PhStockTransferRecords.StTId, dbo.PhStockTransferRecords.TDate, dbo.PhStockTransferRecords.TTime, dbo.PhStockTransferRecords.OperateBy, dbo.HpMedicineRequisitions.RequisitionId, 
                         dbo.HpMedicineRequisitions.RequisitionBy, dbo.MedicineOutlets.Name AS FromOutlet, MedicineOutlets_1.Name AS ToOutlet, dbo.PhStockTransferRecordDetails.ProductId, dbo.PhProductInfoes.BrandName, 
                         dbo.PhStockTransferRecordDetails.Qty,dbo.HpMedicineRequisitions.ReqDate
                         FROM dbo.MedicineOutlets INNER JOIN
                         dbo.PhStockTransferRecords INNER JOIN
                         dbo.PhStockTransferRecordDetails ON dbo.PhStockTransferRecords.StTId = dbo.PhStockTransferRecordDetails.StTId ON dbo.MedicineOutlets.OutLetId = dbo.PhStockTransferRecords.FromOutLet INNER JOIN
                         dbo.MedicineOutlets AS MedicineOutlets_1 ON dbo.PhStockTransferRecords.ToOutLet = MedicineOutlets_1.OutLetId LEFT JOIN
                         dbo.HpMedicineRequisitions ON dbo.PhStockTransferRecords.RequisitionNo = dbo.HpMedicineRequisitions.RequisitionId INNER JOIN
                         dbo.PhProductInfoes ON dbo.PhStockTransferRecordDetails.ProductId = dbo.PhProductInfoes.ProductId
						 Where TDate between '{0}' and '{1}'  and dbo.PhStockTransferRecords.FromOutLet={2} and dbo.PhStockTransferRecords.ToOutLet={3} ", dtpfrm, dtpto, fromoutLetId, tooutletd);

                da = new SqlDataAdapter(sql, con);
                DataSet dsStock = new DataSet();
                da.Fill(dsStock);

                con.Close();

                return dsStock;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<VMedicineRequisition> GetoutletsPendingRequisitionList()
        {

            try
            {

                sql = string.Format(@"SELECT dbo.HpMedicineRequisitions.*,
                                             IsNull(dbo.HospitalPatientInfoes.BillNo,0) BillNo,  
                                             CASE WHEN dbo.HpMedicineRequisitions.AdmissionId=0  THEN dbo.GetRequestedOutlet(HpMedicineRequisitions.RequisitionBy) ELSE IsNull(dbo.CabinInfoes.CabinNo,'') END as CabinNo, 
                                             CASE WHEN dbo.HpMedicineRequisitions.AdmissionId=0  THEN '' ELSE IsNull(dbo.FloorInfoes.Name,'') END as Name
                                             FROM  dbo.HpMedicineRequisitions Left JOIN
                                             dbo.HospitalPatientInfoes ON dbo.HpMedicineRequisitions.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId Left JOIN
                                             dbo.CabinInfoes ON dbo.HospitalPatientInfoes.WardOrCabinId = dbo.CabinInfoes.CabinId Left JOIN
                                             dbo.FloorInfoes ON dbo.CabinInfoes.FloorId = dbo.FloorInfoes.FloorId Where HpMedicineRequisitions.Status in ('Pending','PartiallyServed')
                                             and  HpMedicineRequisitions.RequisitionType in ('ForOutlet')");

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMedicineRequisition> _reqList = new List<VMedicineRequisition>();

                _reqList = new List<VMedicineRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetMedicineRequisitionDataRow(dRow)))
                  );

                return _reqList;
            }
            catch (Exception ex)
            {
                return new List<VMedicineRequisition>();
            }

        }

        private VMedicineRequisition GetMedicineRequisitionDataRow(DataRow dr)
        {

            VMedicineRequisition req = new VMedicineRequisition();
            req.RequisitionId = Convert.ToInt64(dr["RequisitionId"]);
            req.RequisitionBy = dr["RequisitionBy"].ToString();
            if (Convert.ToInt64(dr["AdmissionId"]) == 0)
            {
                req.CabinNo = dr["CabinNo"].ToString();
            }
            else
            {
                req.CabinNo = "";
            }

            req.AdmissionId = Convert.ToInt64(dr["AdmissionId"]);
            req.OutletId = Convert.ToInt32(dr["OutletId"]);
            req.Floor = dr["Name"].ToString();
            req.RequisitionStatus = dr["Status"].ToString();


            return req;
        }

        public List<PhStockAuditMaster> GetPhStockAuditMasters()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhStockAuditMasters.ToList();
            }
        }

        public Generic GetGeneric(int genericId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Generics.Where(x => x.GenericId == genericId).FirstOrDefault();
            }
        }

        public DataSet GetPhSupplierReturnStatement(DateTime dtpfrm, DateTime dtpto, int _manufacturerId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"SELECT dbo.PhReturnToSuppliers.RetId, dbo.PhReturnToSuppliers.ManufacturerId, dbo.PhReturnToSuppliers.RetDate, dbo.PhReturnToSuppliers.UserName,dbo.PhReturnToSuppliers.ReturnClaim, dbo.PhReturnToSuppliers.Remarks, 
                                          dbo.Manufacturers.Name AS SupplierName, dbo.PhSupplierReturnDetails.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhSupplierReturnDetails.Qty AS ReturnQty, dbo.PhSupplierReturnDetails.Rate, 
                                          dbo.PhSupplierReturnDetails.Qty * dbo.PhSupplierReturnDetails.Rate AS Total
                                          FROM dbo.PhReturnToSuppliers INNER JOIN
                                          dbo.PhSupplierReturnDetails ON dbo.PhReturnToSuppliers.RetId = dbo.PhSupplierReturnDetails.RetId INNER JOIN
                                          dbo.Manufacturers ON dbo.PhReturnToSuppliers.ManufacturerId = dbo.Manufacturers.ManufacturerId INNER JOIN
                                          dbo.PhProductInfoes ON dbo.PhSupplierReturnDetails.ProductId = dbo.PhProductInfoes.ProductId
                                          WHERE (dbo.PhReturnToSuppliers.RetDate BETWEEN '{0}' AND '{1}') AND (dbo.PhReturnToSuppliers.ManufacturerId = {2} or 0 ={2})", dtpfrm, dtpto, _manufacturerId);


                da = new SqlDataAdapter(sql, con);
                DataSet dsStock = new DataSet();
                da.Fill(dsStock);

                con.Close();

                return dsStock;

            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                con.Close();
            }

        }

        public PhReceive GetPhReceiveBySupInvoice(string supInvoiceNo, int supplierid)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhReceives.Where(x => x.SupInvNo == supInvoiceNo && x.SupplerId == supplierid).FirstOrDefault();
            }
        }

        public void UpdateOrAddToReturnedStockInfo(List<PhReceiveDetail> rDeatailsList, int outLetId, DateTime _rettrandate, string userName, long RetInvoiceNo)
        {


            using (DBEntities entities = new DBEntities())
            {
                List<PhProductLedger> _prodLedger = new List<PhProductLedger>();


                foreach (var item in rDeatailsList)
                {


                    var stckList = entities.PhStockInfoes.Where(x => x.ProductId == item.ProductId && x.OutLetId == outLetId && x.CurrentStock > 0).ToList();

                    double opStock = 0;
                    if (stckList != null)
                    {
                        opStock = stckList.Sum(x => x.CurrentStock);
                    }

                    stckList = null;

                    PhStockInfo _phst = entities.PhStockInfoes.Where(x => x.LotNo == item.LotNo && x.OutLetId == outLetId && x.ProductId == item.ProductId).FirstOrDefault(); ;//new PhProductRepository().GetPhStockInfoObj(item.LotNo, item.ProductId, outLetId);
                    if (_phst != null)
                    {
                        double _newStock = _phst.CurrentStock + item.Qty;
                        _phst.CurrentStock = _newStock;

                        entities.Entry(_phst).State = EntityState.Modified;
                        entities.SaveChanges();
                    }
                    else
                    {
                        PhStockInfo _st = new PhStockInfo();
                        _st.LotNo = item.LotNo;
                        _st.OutLetId = outLetId;
                        _st.ProductId = item.ProductId;
                        _st.CurrentStock = item.Qty;
                        _st.PurchaseRate = item.PurchaseRate;
                        _st.SaleRate = _phst.SaleRate;
                        _st.PRIncludingVat = 0;
                        entities.PhStockInfoes.Add(_st);
                        entities.SaveChanges();
                    }



                    //Product Ledger Update
                    PhProductLedger prodlObj = new PhProductLedger();
                    prodlObj.TDate = _rettrandate;
                    prodlObj.TTime = _rettrandate.ToString("hh:mm tt");
                    prodlObj.OutletId = outLetId;
                    prodlObj.ProductId = item.ProductId;
                    prodlObj.OpStock = opStock;
                    prodlObj.Particulars = Constants.SaleReturn + RetInvoiceNo.ToString();
                    prodlObj.StockQty = 0;
                    prodlObj.SoldQty = 0;
                    prodlObj.TransferQty = 0;
                    prodlObj.RetQty = item.Qty;
                    prodlObj.ClosingStock = opStock + item.Qty;
                    prodlObj.UserName = userName;
                    _prodLedger.Add(prodlObj);

                }

                if (_prodLedger != null && _prodLedger.Count > 0)
                {
                    entities.PhProductLedgers.AddRange(_prodLedger);
                    entities.SaveChanges();
                }

            }
        }

        public PhStockInfo GetPhStockByStckId(long stckId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhStockInfoes.Where(x => x.StckId == stckId).FirstOrDefault();
            }
        }

        public DataSet GetPhOpeningClosingStockDataset(DateTime dtfrm, DateTime dtto)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Exec [dbo].[sp_Get_PH_Stock_By_Date] '{0}','{1}','0'", dtfrm, dtto);
                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);
                con.Close();

                return dsReports;

            }
            catch (Exception ex)
            {

            }

            return null;
        }


        public IList<VWPhProductList> GetProductListWithStockFilterByGeneric(string _filterString)
        {
            try
            {

                string filterString = string.Empty;
                int _outLetId = 0;

                string[] arr = null;
                arr = _filterString.Split('>');

                if (arr.Length > 1)
                {
                    filterString = arr[0];
                    _outLetId = Convert.ToInt32(arr[1]);
                }


                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("Exec [dbo].[spGetPhAllProductWithStockFilterByGeneric] {0},'{1}'", _outLetId, filterString);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductList> listStockList = new List<VWPhProductList>();


                listStockList = new List<VWPhProductList>(
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

        public List<VWPhProductInfo> GetPhStockByBrandName(string _brandName, int _outletId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();



                if (!String.IsNullOrEmpty(_brandName))
                {
                    sql = string.Format(@"SELECT S.LotNo, P.ProductId,P.BrandName,P.GenericId, P.ManufacturerId, S.CurrentStock,MedicineOutlets.Name as OutletName
                                          FROM  dbo.PhProductInfoes P INNER JOIN
                                         dbo.PhStockInfoes S on P.ProductId =S.ProductId 
										 inner join MedicineOutlets on S.OutLetId=MedicineOutlets.OutLetId
                                         Where S.OutLetId={0} and P.BrandName like '%{1}%' ORDER BY P.ProductId,S.LotNo", _outletId, _brandName);

                }
                else
                {
                    sql = string.Format(@"SELECT S.LotNo, P.ProductId,P.BrandName,P.GenericId, P.ManufacturerId, S.CurrentStock,MedicineOutlets.Name as OutletName
                                          FROM  dbo.PhProductInfoes P INNER JOIN
                                         dbo.PhStockInfoes S on P.ProductId =S.ProductId 
										 inner join MedicineOutlets on S.OutLetId=MedicineOutlets.OutLetId
                                         where S.OutLetId={0}  ORDER BY   P.ProductId,S.LotNo", _outletId);
                }




                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductInfo> pInfoList = new List<VWPhProductInfo>();


                pInfoList = new List<VWPhProductInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPhStockInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VWPhProductInfo>();

            }
        }

        public DataSet GetPhStockTransferInvoice(long stTId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.PhStockTransferRecords.StTId, dbo.PhStockTransferRecords.TDate, dbo.PhStockTransferRecords.OperateBy, dbo.PhOutletMedicinieRequisitions.RequisitionBy,dbo.PhOutletMedicinieRequisitions.RequisitionId, dbo.PhOutletMedicinieRequisitions.ReqDate, 
                         dbo.MedicineOutlets.Name AS FromOutlet, MedicineOutlets_1.Name AS ToOutlet, dbo.PhStockTransferRecordDetails.ProductId, dbo.Formations.ShortFormation + ' ' + dbo.PhProductInfoes.BrandName AS BrandName, 
                         dbo.PhStockTransferRecordDetails.Qty, dbo.PhStockTransferRecordDetails.LotNo, dbo.Formations.Name, dbo.Formations.ShortFormation
                         FROM dbo.MedicineOutlets INNER JOIN
                         dbo.PhStockTransferRecords INNER JOIN
                         dbo.PhOutletMedicinieRequisitions ON dbo.PhStockTransferRecords.RequisitionNo = dbo.PhOutletMedicinieRequisitions.RequisitionId INNER JOIN
                         dbo.PhStockTransferRecordDetails ON dbo.PhStockTransferRecords.StTId = dbo.PhStockTransferRecordDetails.StTId ON dbo.MedicineOutlets.OutLetId = dbo.PhStockTransferRecords.FromOutLet INNER JOIN
                         dbo.MedicineOutlets AS MedicineOutlets_1 ON dbo.PhStockTransferRecords.ToOutLet = MedicineOutlets_1.OutLetId INNER JOIN
                         dbo.PhProductInfoes ON dbo.PhStockTransferRecordDetails.ProductId = dbo.PhProductInfoes.ProductId INNER JOIN
                         dbo.Formations ON dbo.PhProductInfoes.FormationId = dbo.Formations.FormationId Where dbo.PhStockTransferRecords.StTId={0}", stTId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsStock = new DataSet();
                da.Fill(dsStock);

                con.Close();

                return dsStock;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveStockTransferRecord(PhStockTransferRecord _sttr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhStockTransferRecords.Add(_sttr);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public string CheckStockAvailability(List<PhInvoiceDetail> invDetails, VMPhEndpointDataCarrier voucherObj)
        {

            string _msg = string.Empty;
            PhProductInfo _productInfo = new PhProductInfo();

            using (DBEntities entities = new DBEntities())
            {
                foreach (PhInvoiceDetail invd in invDetails)
                {
                    PhStockInfo _phst = entities.PhStockInfoes.Where(x => x.LotNo == invd.LotNo && x.OutLetId == voucherObj.OutletId && x.ProductId == invd.ProductId).FirstOrDefault();
                    double soldQty = invd.Qty;
                    if (_phst != null)
                    {
                        if (_phst.CurrentStock < invd.Qty)
                        {
                            _productInfo = entities.PhProductInfos.Where(x => x.ProductId == _phst.ProductId).FirstOrDefault();
                            if (string.IsNullOrEmpty(_msg))
                            {
                                _msg = _msg + "Brand Name: " + _productInfo.BrandName + ", Lot No: " + _phst.LotNo.ToString();
                            }
                            else
                            {
                                _msg = _msg + ", " + "Brand Name: " + _productInfo.BrandName + ", Lot No: " + _phst.LotNo.ToString();
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(_msg))
                        {
                            _msg = _msg + "Brand Name: " + _productInfo.BrandName + ", Lot No: " + _phst.LotNo.ToString();
                        }
                        else
                        {
                            _msg = _msg + ", " + "Brand Name: " + _productInfo.BrandName + ", Lot No: " + _phst.LotNo.ToString();
                        }
                    }
                }


                if (!string.IsNullOrEmpty(_msg)) return _msg + ". Check stock for this product and try again.";


                return _msg;
            }
        }
        public PhReceive PhReceiveInvoice(long _ReceiveId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhReceives.Where(x => x.ReceiveId == _ReceiveId).FirstOrDefault();
            }
        }

        public void AddUpdateStockOnTransfer(List<PhStockTransferRecordDetail> _rdDetailsList, int fromoutLetId, int toOutletId, DateTime _transferDate, string userName)
        {

            List<PhProductLedger> _prodLedgerfrm = new List<PhProductLedger>();
            List<PhProductLedger> _prodLedgerto = new List<PhProductLedger>();

            using (DBEntities entities = new DBEntities())
            {
                foreach (var item in _rdDetailsList)
                {
                    var stckList = entities.PhStockInfoes.Where(x => x.ProductId == item.ProductId && x.OutLetId == fromoutLetId && x.CurrentStock > 0).ToList();

                    double opStock = 0;
                    if (stckList != null)
                    {
                        opStock = stckList.Sum(x => x.CurrentStock);
                    }

                    stckList = null;



                    PhStockInfo _phstfrom = entities.PhStockInfoes.Where(x => x.LotNo == item.LotNo && x.OutLetId == fromoutLetId && x.ProductId == item.ProductId).FirstOrDefault();
                    double _newStock = _phstfrom.CurrentStock - item.Qty;
                    _phstfrom.CurrentStock = _newStock;

                    entities.Entry(_phstfrom).State = EntityState.Modified;
                    entities.SaveChanges();

                    PhProductLedger prodlObj = new PhProductLedger();
                    prodlObj.TDate = _transferDate;
                    prodlObj.TTime = _transferDate.ToString("hh:mm tt");
                    prodlObj.OutletId = fromoutLetId;
                    prodlObj.ProductId = item.ProductId;
                    prodlObj.OpStock = opStock;
                    prodlObj.Particulars = "Transfer to outlet :" + toOutletId.ToString() + " (-)";
                    prodlObj.StockQty = 0;
                    prodlObj.SoldQty = 0;
                    prodlObj.TransferQty = item.Qty;
                    prodlObj.RetQty = 0;
                    prodlObj.ClosingStock = opStock + item.Qty;
                    prodlObj.UserName = userName;
                    _prodLedgerfrm.Add(prodlObj);


                    var stckList2 = entities.PhStockInfoes.Where(x => x.ProductId == item.ProductId && x.OutLetId == toOutletId && x.CurrentStock > 0).ToList();

                    double opStock2 = 0;
                    if (stckList2 != null)
                    {
                        opStock2 = stckList2.Sum(x => x.CurrentStock);
                    }

                    stckList2 = null;


                    PhStockInfo _phstto = entities.PhStockInfoes.Where(x => x.LotNo == item.LotNo && x.OutLetId == toOutletId && x.ProductId == item.ProductId).FirstOrDefault();
                    if (_phstto != null)
                    {
                        double _tonewStock = _phstto.CurrentStock + item.Qty;
                        _phstto.CurrentStock = _tonewStock;

                        entities.Entry(_phstto).State = EntityState.Modified;
                        entities.SaveChanges();
                    }
                    else
                    {
                        PhStockInfo _st = new PhStockInfo();
                        _st.LotNo = item.LotNo;
                        _st.OutLetId = toOutletId;
                        _st.ProductId = item.ProductId;
                        _st.CurrentStock = item.Qty;
                        _st.BookedQty = 0;
                        _st.BookedBy = "";
                        entities.PhStockInfoes.Add(_st);
                        entities.SaveChanges();
                    }


                    prodlObj = new PhProductLedger();
                    prodlObj.TDate = _transferDate;
                    prodlObj.TTime = _transferDate.ToString("hh:mm tt");
                    prodlObj.OutletId = toOutletId;
                    prodlObj.ProductId = item.ProductId;
                    prodlObj.OpStock = opStock2;
                    prodlObj.Particulars = "Transfer from outlet :" + fromoutLetId.ToString() + " (+)";
                    prodlObj.StockQty = item.Qty;
                    prodlObj.SoldQty = 0;
                    prodlObj.TransferQty = 0;
                    prodlObj.RetQty = 0;
                    prodlObj.ClosingStock = opStock2 + item.Qty;
                    prodlObj.UserName = userName;
                    _prodLedgerto.Add(prodlObj);

                }

                entities.PhProductLedgers.AddRange(_prodLedgerfrm);
                entities.SaveChanges();

                entities.PhProductLedgers.AddRange(_prodLedgerto);
                entities.SaveChanges();

            }
        }

        public PhInvoice GetPhOPDLastestInvoice()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.SqlQuery("Select * from PhInvoices Where InvoiceId=(Select Max(InvoiceId) from PhInvoices Where InvoiceType='GC')").FirstOrDefault();
            }
        }

        public bool AddStockTransferDetails(List<PhStockTransferRecordDetail> _rdDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhStockTransferRecordDetails.AddRange(_rdDetailsList);
                entities.SaveChanges();

                return true;
            }
        }

        public Generic GetPhProducGenId(int genericId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Generics.Where(x => x.GenericId == genericId).FirstOrDefault();
            }
        }

        public List<VWPhProductInfo> GetPhStockByManufacturer(int manufacturerId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();



                if (manufacturerId == 0)
                {
                    sql = string.Format(@"SELECT  dbo.VR.ProductId, dbo.VR.BrandName, dbo.VR.Generic, dbo.VR.tR, dbo.VS.tS, dbo.VR.ManufacturerId, dbo.PhStockInfoes.CurrentStock
                                          FROM  dbo.VR INNER JOIN
                                          dbo.VS ON dbo.VR.ProductId = dbo.VS.ProductId INNER JOIN
                                          dbo.PhStockInfoes ON dbo.VR.ProductId = dbo.PhStockInfoes.ProductId
                                          ORDER BY  dbo.VR.GenericId");



                }
                else
                {
                    sql = string.Format(@"SELECT  dbo.VR.ProductId, dbo.VR.BrandName, dbo.VR.Generic, dbo.VR.tR, dbo.VS.tS, dbo.VR.ManufacturerId, dbo.PhStockInfoes.CurrentStock
                                          FROM  dbo.VR INNER JOIN
                                          dbo.VS ON dbo.VR.ProductId = dbo.VS.ProductId INNER JOIN
                                          dbo.PhStockInfoes ON dbo.VR.ProductId = dbo.PhStockInfoes.ProductId
                                          Where dbo.VR.ManufacturerId={0} 
                                          ORDER BY dbo.VR.GenericId", manufacturerId);

                }


                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductInfo> pInfoList = new List<VWPhProductInfo>();


                pInfoList = new List<VWPhProductInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPhStockInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VWPhProductInfo>();

            }
        }

        public double GetTotalStock(int productId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var stckList = entities.PhStockInfoes.Where(x => x.ProductId == productId && x.CurrentStock > 0).ToList();
                if (stckList != null)
                {
                    return stckList.Sum(x => x.CurrentStock);
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<VMPhSoldItem> GetPhIPDSoldItems(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter InvoiceId = new SqlParameter("AdmissionNo", admissionId);

                return entities.Database.SqlQuery<VMPhSoldItem>(@"
                   Select T.LotNo,T.OutLetId, T.ProductId,T.BrandName,Sum(T.Qty) Qty, Sum(T.RetQty) RetQty,T.Unit,T.SaleRate,Sum(T.Qty)* T.SaleRate as TotalPrice
                  from (

                  Select invd.LotNo,inv.OutLetId, p.ProductId,f.ShortFormation +' '+ p.BrandName as BrandName, Sum(invd.Qty) as Qty, 0 as RetQty,p.Unit,invd.SaleRate,invd.TotalPrice from PhInvoiceDetails invd join PhProductInfoes p on invd.ProductId = p.ProductId join Formations f on p.FormationId=f.FormationId join
                       PhInvoices inv on inv.InvoiceId=invd.InvoiceId Where inv.AdmissionNo=@AdmissionNo and inv.InvoiceType<>'RRN' Group by invd.LotNo,inv.OutLetId, p.ProductId,f.ShortFormation,p.BrandName,p.Unit,invd.SaleRate,invd.TotalPrice

                  Union ALL

                 Select invd.LotNo,inv.OutLetId, p.ProductId, f.ShortFormation +' '+ p.BrandName as BrandName,0 as Qty, Sum(-1*Qty) as RetQty,p.Unit,invd.SaleRate,invd.TotalPrice from PhInvoiceDetails invd join PhProductInfoes p on invd.ProductId = p.ProductId join Formations f on p.FormationId=f.FormationId join
                 PhInvoices inv on inv.InvoiceId=invd.InvoiceId Where inv.AdmissionNo=@AdmissionNo and inv.InvoiceType='RRN' Group by invd.LotNo,inv.OutLetId, p.ProductId,f.ShortFormation,p.BrandName,p.Unit,invd.SaleRate,invd.TotalPrice
                 ) T  Group by T.LotNo,T.OutLetId, T.ProductId,T.BrandName,T.Unit,T.SaleRate  order by T.ProductId", InvoiceId).ToList();
            }
        }

        public VWPhProductListForSale GetStockForSaleByProductId(int productId, int outLetId, long lotNo)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("select * from  VWPhStockReport Where ProductId={0} and OutLetId={1} and LotNo={2}", productId, outLetId, lotNo);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                return GetStockDataForSaleEditTableRow(dt.Rows[0]);


            }
            catch (Exception ex)
            {

            }

            return null;
        }


        public async Task<bool> SetOpeningStock(DateTime _date)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Exec SP_SET_Ph_Opening_Stock '{0}'", _date);
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        private VWPhProductListForSale GetStockDataForSaleEditTableRow(DataRow dr)
        {
            VWPhProductListForSale pL = new VWPhProductListForSale();
            pL.ProductId = Convert.ToInt32(dr["ProductId"]);

            pL.BrandName = dr["BrandName"].ToString();
            //  pL.BarCode = dr["BarCode"].ToString(); 
            pL.LotNo = Convert.ToInt64(dr["LotNo"]);
            pL.OutLetId = Convert.ToInt32(dr["OutLetId"]);
            pL.StockAvailable = Convert.ToDouble(dr["Stock"]);
            pL.PurchasePrice = Convert.ToDouble(dr["PurchasePrice"]);
            pL.SalePrice = Convert.ToDouble(dr["SalePrice"]);
            // pL.Unit = dr["Unit"].ToString();
            return pL;
        }

        public bool AddSupplierReturnDetails(List<PhSupplierReturnDetail> _retDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhSupplierReturnDetails.AddRange(_retDetailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public bool SaveReturnToSupplier(PhReturnToSupplier _retToSupplier)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhReturnToSuppliers.Add(_retToSupplier);
                entities.SaveChanges();
                return true;
            }
        }

        private VWPhProductInfo GetPhStockInfoDataTableRow(DataRow dr)
        {
            VWPhProductInfo _phStock = new VWPhProductInfo();
            _phStock.ProductId = Convert.ToInt32(dr["ProductId"]);
            _phStock.LotNo = Convert.ToInt64(dr["LotNo"]);
            _phStock.BrandName = dr["BrandName"].ToString();
            _phStock.OutLetName = dr["OutletName"].ToString();
            _phStock.Stock = Convert.ToInt32(dr["CurrentStock"]);

            return _phStock;
        }

        public void UpdateStockInfoOnReturn(List<PhSupplierReturnDetail> _retDetailsList, int outLetId)
        {
            foreach (var item in _retDetailsList)
            {
                using (DBEntities entities = new DBEntities())
                {
                    PhStockInfo _phst = new PhProductRepository().GetPhStockInfoObj(item.LotNo, item.ProductId, outLetId);
                    double _newStock = _phst.CurrentStock - item.Qty;
                    _phst.CurrentStock = _newStock;

                    entities.Entry(_phst).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        private VMPhStock GetPhStockDataTableRow(DataRow dr)
        {
            VMPhStock _phStock = new VMPhStock();
            _phStock.ProductId = Convert.ToInt32(dr["ProductId"]);

            _phStock.BrandName = dr["BrandName"].ToString();
            _phStock.PPrice = Convert.ToDouble(dr["PurchasePrice"]);
            _phStock.SPrice = Convert.ToDouble(dr["SalePrice"]);


            _phStock.StockAvail = Convert.ToInt64(dr["Stock"]);
            _phStock.TPValue = Convert.ToInt32(dr["totalPV"]);
            _phStock.TSValue = Convert.ToInt32(dr["totalSV"]);
            return _phStock;
        }

        public void DeleteExistingAuditRecord(int productId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Delete from PhStockAuditMasterDetails Where ProductId={0}", productId);
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch
            {

            }
        }

        public void SavePhAuditDetail(PhStockAuditMasterDetail _auditdetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhStockAuditMasterDetails.Add(_auditdetail);
                entities.SaveChanges();
            }
        }

        public bool UpdatePhStockInfo(PhStockInfo _stockInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_stockInfo).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public PhStockInfo GetCurrentStockByProdId(int productId, long _lotNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhStockInfoes.Where(x => x.ProductId == productId & x.LotNo == _lotNo).FirstOrDefault();
            }
        }

        public DataSet GetPhStockByDate(DateTime dtpfrm, DateTime dtpto, int outLetId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Exec  [dbo].[spGetPhStockByDate] '{0}','{1}',{2},'{3}'", dtpfrm, dtpto, outLetId, "");

                da = new SqlDataAdapter(sql, con);
                DataSet dsStock = new DataSet();
                da.Fill(dsStock);

                con.Close();

                return dsStock;
            }
            catch
            {
                return null;
            }
        }

        public IList<VWPhProductInfo> GetProductListBySearchStr(string _filterString)
        {
            //try
            //{

            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();

            if (_filterString.Contains(">"))
            {

                string[] filterOptions = _filterString.Split('>');

                if (string.IsNullOrEmpty(_filterString))
                {
                    sql = string.Format(@"With Cte_CurrentStock
                                           as (Select ProductId,Sum(CurrentStock) as Stock from [dbo].[PhStockInfoes] group by ProductId)
                                           SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.ROLIndoor, dbo.PhProductInfoes.ROLOutdoor, f.ShortFormation, dbo.PhProductInfoes.BrandName,IsNull(Cte_CurrentStock.Stock,0) Stock,
                                           dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit
                                           FROM   dbo.PhProductInfoes left join Formations f on dbo.PhProductInfoes.FormationId=f.FormationId left join Cte_CurrentStock on dbo.PhProductInfoes.ProductId=Cte_CurrentStock.ProductId");
                }
                else if (filterOptions.Length > 1)
                {
                    sql = string.Format(@"With Cte_CurrentStock
                                           as (Select ProductId,Sum(CurrentStock) as Stock from [dbo].[PhStockInfoes] group by ProductId)
                                           SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.ROLIndoor, dbo.PhProductInfoes.ROLOutdoor, f.ShortFormation, dbo.PhProductInfoes.BrandName,IsNull(Cte_CurrentStock.Stock,0) Stock,
                                           dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit
                                           FROM   dbo.PhProductInfoes left join Formations f on dbo.PhProductInfoes.FormationId=f.FormationId left join Cte_CurrentStock on dbo.PhProductInfoes.ProductId=Cte_CurrentStock.ProductId where ManufacturerId={0} and BrandName like '{1}%'", Convert.ToInt32(filterOptions[1]), filterOptions[0]);



                }
                else
                {
                    sql = string.Format(@"With Cte_CurrentStock
                                           as (Select ProductId,Sum(CurrentStock) as Stock from [dbo].[PhStockInfoes] group by ProductId)
                                           SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.ROLIndoor, dbo.PhProductInfoes.ROLOutdoor, f.ShortFormation, dbo.PhProductInfoes.BrandName,IsNull(Cte_CurrentStock.Stock,0) Stock,
                                           dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit
                                           FROM   dbo.PhProductInfoes left join Formations f on dbo.PhProductInfoes.FormationId=f.FormationId left join Cte_CurrentStock on dbo.PhProductInfoes.ProductId=Cte_CurrentStock.ProductId where BrandName like '{0}%'", filterOptions[0]);

                }


                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductInfo> pInfoList = new List<VWPhProductInfo>();


                pInfoList = new List<VWPhProductInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPhProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;
            }
            else
            {
                sql = string.Format(@"
                    WITH Cte_CurrentStock
                    AS (
	                    SELECT ProductId
		                    ,Sum(CurrentStock) AS Stock
	                    FROM [dbo].[PhStockInfoes]
	                    GROUP BY ProductId
	                    )
                    SELECT dbo.PhProductInfoes.ProductId
	                    ,dbo.PhProductInfoes.ROLIndoor
	                    ,dbo.PhProductInfoes.ROLOutdoor
	                    ,f.ShortFormation
	                    ,dbo.PhProductInfoes.BrandName
	                    ,IsNull(Cte_CurrentStock.Stock, 0) Stock
	                    ,dbo.PhProductInfoes.PurchasePrice
	                    ,dbo.PhProductInfoes.SalePrice
	                    ,IsNull(dbo.PhProductInfoes.Unit, 'N/A') AS Unit
                    FROM dbo.PhProductInfoes
                    LEFT JOIN Formations f ON dbo.PhProductInfoes.FormationId = f.FormationId
                    LEFT JOIN Cte_CurrentStock ON dbo.PhProductInfoes.ProductId = Cte_CurrentStock.ProductId
                    WHERE dbo.PhProductInfoes.BrandName like '{0}%'
                ", _filterString);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductInfo> pInfoList = new List<VWPhProductInfo>();


                pInfoList = new List<VWPhProductInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPhProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;
            }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return new List<VWPhProductInfo>();

            //}
        }


        public IList<VWPhProductInfo> GetUnderStockList(int _manufacturerId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();


                sql = string.Format(@"With Cte_CurrentStock
                                           as (Select ProductId,Sum(CurrentStock) as Stock from [dbo].[PhStockInfoes] group by ProductId)
                                           SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.ROLIndoor, dbo.PhProductInfoes.ROLOutdoor, dbo.PhProductInfoes.BrandName,IsNull(Cte_CurrentStock.Stock,0) Stock,
                                           dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit
                                           FROM   dbo.PhProductInfoes left join Cte_CurrentStock on dbo.PhProductInfoes.ProductId=Cte_CurrentStock.ProductId where ManufacturerId={0} and IsNull(Cte_CurrentStock.Stock,0)<=dbo.PhProductInfoes.ROLIndoor", _manufacturerId);



                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductInfo> pInfoList = new List<VWPhProductInfo>();


                pInfoList = new List<VWPhProductInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPhProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VWPhProductInfo>();

            }
        }



        public List<PhProductInfo> GetProductsByGeneric(int genericId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductInfos.Where(x => x.GenericId == genericId).ToList();
            }
        }

        public List<PhProductInfo> GetProductListByManufacturer(int manufacturerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductInfos.Where(x => x.ManufacturerId == manufacturerId).ToList();
            }
        }

        private VWPhProductInfo GetPhProductInfoDataTableRow(DataRow dr)
        {
            VWPhProductInfo _pInfo = new VWPhProductInfo();
            _pInfo.ProductId = Convert.ToInt32(dr["ProductId"]);
            _pInfo.FormationShortName = dr["ShortFormation"].ToString();
            _pInfo.BrandName = dr["BrandName"].ToString();
            _pInfo.Stock = Convert.ToInt32(dr["Stock"]);
            _pInfo.Unit = dr["Unit"].ToString();
            _pInfo.ROLIndoor = Convert.ToInt32(dr["ROLIndoor"]);
            _pInfo.SalePrice = Convert.ToDouble(dr["SalePrice"]);
            _pInfo.PurchasePrice = Convert.ToDouble(dr["PurchasePrice"]);

            return _pInfo;
        }

        public DataSet GetPhStockDataset(int outLetId, string searchStr, int _stockParam, int _manaufacturerId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"Exec spGetPhStockByOutLet {0},{1},'',{2}", outLetId, _stockParam, _manaufacturerId);


                da = new SqlDataAdapter(sql, con);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                return dsReports;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public IList<VWPhProductList> GetBasicProductInfoList(string name, string _type)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                if (!String.IsNullOrEmpty(name))
                {

                    sql = string.Format(@"SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.GenericId,dbo.PhProductInfoes.FormationId,dbo.PhProductInfoes.ROLIndoor,dbo.PhProductInfoes.ROLOutdoor,  dbo.PhProductInfoes.BrandName, g.Name as GroupName, dbo.Generics.Name AS GenericName, 
                                  dbo.Manufacturers.Name AS Manufacturer, dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit,IsNull(dbo.PhProductInfoes.PkgUnit,'N/A') as PkgUnit,dbo.PhProductInfoes.QtyPerBox,
								  dbo.PhProductInfoes.SideEffact,dbo.PhProductInfoes.DoseLongBn,dbo.PhProductInfoes.DoseLongEn,dbo.PhProductInfoes.DoseShortBn,dbo.PhProductInfoes.DoseShortEn 
                                  FROM   dbo.PhProductInfoes Left JOIN dbo.Generics ON dbo.PhProductInfoes.GenericId = dbo.Generics.GenericId Left JOIN
								  PhProductGroups g on g.GroupId = dbo.Generics.GroupId Left JOIN
                                  dbo.Manufacturers ON dbo.PhProductInfoes.ManufacturerId = dbo.Manufacturers.ManufacturerId
                                       where BrandName like '{0}%'", name);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.GenericId,dbo.PhProductInfoes.FormationId,dbo.PhProductInfoes.ProductId,dbo.PhProductInfoes.ROLIndoor,dbo.PhProductInfoes.ROLOutdoor,  dbo.PhProductInfoes.BrandName, g.Name as GroupName, dbo.Generics.Name AS GenericName, 
                                  dbo.Manufacturers.Name AS Manufacturer, dbo.PhProductInfoes.PurchasePrice, dbo.PhProductInfoes.SalePrice, IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit,IsNull(dbo.PhProductInfoes.PkgUnit,'N/A') as PkgUnit,dbo.PhProductInfoes.QtyPerBox,
								  dbo.PhProductInfoes.SideEffact,dbo.PhProductInfoes.DoseLongBn,dbo.PhProductInfoes.DoseLongEn,dbo.PhProductInfoes.DoseShortBn,dbo.PhProductInfoes.DoseShortEn 
                                  FROM   dbo.PhProductInfoes Left JOIN dbo.Generics ON dbo.PhProductInfoes.GenericId = dbo.Generics.GenericId Left JOIN
								  PhProductGroups g on g.GroupId = dbo.Generics.GroupId Left JOIN
                                  dbo.Manufacturers ON dbo.PhProductInfoes.ManufacturerId = dbo.Manufacturers.ManufacturerId
                             ");
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductList> pInfoList = new List<VWPhProductList>();


                pInfoList = new List<VWPhProductList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBasicProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<VWPhProductList>();

            }
        }

        public void UpdateStockInfoOnReturn(List<PhInvoiceDetail> _invDetailsList, int _outLetId)
        {
            foreach (var item in _invDetailsList)
            {
                PhStockInfo _phst = new PhStockInfo();

                _phst = new PhProductRepository().GetPhStockInfoObj(item.LotNo, item.ProductId, _outLetId);

                double _newStock = _phst.CurrentStock + (-1) * item.Qty;
                _phst.CurrentStock = _newStock;


                using (DBEntities entities = new DBEntities())
                {

                    entities.Entry(_phst).State = EntityState.Modified;
                    entities.SaveChanges();


                }
            }
        }

        private VWPhProductList GetBasicProductInfoDataTableRow(DataRow dr)
        {
            VWPhProductList _pInfo = new VWPhProductList();
            _pInfo.ProductId = Convert.ToInt32(dr["ProductId"]);
            _pInfo.ProductCode = "";
            _pInfo.BrandName = dr["BrandName"].ToString();
            _pInfo.GenericName = dr["GenericName"].ToString();
            _pInfo.GroupName = dr["GroupName"].ToString();
            _pInfo.GenericId = Convert.ToInt32(dr["GenericId"]);
            _pInfo.FormationId = Convert.ToInt32(dr["FormationId"]);
            _pInfo.Manufacturer = dr["Manufacturer"].ToString();
            _pInfo.Unit = dr["Unit"].ToString();
            _pInfo.ROLIndoor = Convert.ToInt32(dr["ROLIndoor"]);
            _pInfo.ROLOutdoor = Convert.ToInt32(dr["ROLOutdoor"]);
            _pInfo.SaleRate = Convert.ToDouble(dr["SalePrice"]);
            _pInfo.PurchaseRate = Convert.ToDouble(dr["PurchasePrice"]);
            if (!dr.IsNull("PkgUnit"))
            {
                _pInfo.PkgUnit = dr["PkgUnit"].ToString();
            }
            else
            {
                _pInfo.PkgUnit = "N/A";
            }

            if (!dr.IsNull("SideEffact"))
            {
                _pInfo.SideEffact = dr["SideEffact"].ToString();
            }
            else
            {
                _pInfo.SideEffact = "N/A";
            }

            if (!dr.IsNull("DoseLongBn"))
            {
                _pInfo.DoseLongBn = dr["DoseLongBn"].ToString();
            }
            else
            {
                _pInfo.DoseLongBn = "N/A";
            }

            if (!dr.IsNull("DoseLongEn"))
            {
                _pInfo.DoseLongEn = dr["DoseLongEn"].ToString();
            }
            else
            {
                _pInfo.DoseLongEn = "N/A";
            }

            if (!dr.IsNull("DoseShortBn"))
            {
                _pInfo.DoseShortBn = dr["DoseShortBn"].ToString();
            }
            else
            {
                _pInfo.DoseShortBn = "N/A";
            }

            if (!dr.IsNull("DoseShortEn"))
            {
                _pInfo.DoseShortEn = dr["DoseShortEn"].ToString();
            }
            else
            {
                _pInfo.DoseShortEn = "N/A";
            }

            _pInfo.QtyPerBox = Convert.ToInt32(dr["QtyPerBox"]);

            return _pInfo;
        }

        public void UpdatePurchaseAndSalerate(VWPhProductList vWPhProductList, double _prate, double _sRate)
        {
            using (DBEntities entities = new DBEntities())
            {
                PhProductInfo _pInfo = this.GetProductById(vWPhProductList.ProductId);
                _pInfo.PurchasePrice = _prate;
                _pInfo.SalePrice = _sRate;

                entities.Entry(_pInfo).State = EntityState.Modified;
                entities.SaveChanges();

            }
        }

        public long SaveBatchAndExpireInfo(PhLotInfo _PL)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhLotInfoes.Add(_PL);
                entities.SaveChanges();
                return _PL.LotNo;
            }
        }

        public PhLotInfo GetPhLotInfo(string _batchNo, DateTime _ExpDate)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhLotInfoes.Where(x => x.BatchNo == _batchNo.Trim() && x.ExpireDate == _ExpDate).FirstOrDefault();
            }
        }

        public IList<PhProductInfo> GetAllProduct()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductInfos.ToList();
            }
        }

        public List<PhSaleLedger> GetPhLedgerByInvoice(long invoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhSaleLedgers.Where(x => x.InvoiceId == invoiceId).ToList();
            }
        }

        public void UpdatePhRefundedInvoiceDetail(PhInvoiceDetail _pInvd)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_pInvd).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public PhInvoiceDetail GetPhInvoiceDetail(long invoiceId, long _lotNo, int _productId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoiceDetails.Where(x => x.InvoiceId == invoiceId && x.LotNo == _lotNo && x.ProductId == _productId).FirstOrDefault();
            }
        }

        public bool UpdateOutletInfo(MedicineOutlet _outlet)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_outlet).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<MedicineOutlet> GetAllMedicineOutlets()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MedicineOutlets.ToList();
            }
        }

        public IList<VWPhProductInfo> GetProductListByGenAndManufacturer(string _filterString)
        {
            try
            {

                //string filterString = string.Empty;
                //int _outLetId = 0;

                //string[] arr = null;
                //arr = _filterString.Split('>');

                //if (arr.Length > 1)
                //{
                //    filterString = arr[0];
                //    _outLetId = Convert.ToInt32(arr[1]);
                //}


                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("select * from  VWPhProductInfo Where BrandName like '{0}%'  order by BrandName", _filterString);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductInfo> pInfoList = new List<VWPhProductInfo>();


                pInfoList = new List<VWPhProductInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;
            }
            catch
            {
                return null;
            }
        }

        public HpMedicineRequisitionDetail GetHpMedicineRequisitionDetail(long requisitionId, int productId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.HpMedicineRequisitionDetails.Where(x => x.RequisitionId == requisitionId && x.ProductId == productId).FirstOrDefault();
            }
        }


        public void UpdateHpMedicineRequisitionDetail(HpMedicineRequisitionDetail _reqDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_reqDetail).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
        public void UpdatePhMedicineRequisitionDetail(PhOutletMedicineRequisitionDetail _reqDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_reqDetail).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public List<VMPhRequisitionAutomation> GetAvailablePhStockByBatchAndExpireDate(int productId, int outLetId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT StckId, PhStockInfoes.LotNo, BatchNo,ExpireDate,ProductId, CurrentStock, OutLetId
                                      FROM PhStockInfoes join PhLotInfoes on  PhStockInfoes.LotNo = PhLotInfoes.LotNo
                                      WHERE CurrentStock > 0 and ProductId = {0} and OutLetId={1} order by ExpireDate", productId, outLetId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMPhRequisitionAutomation> pInfoList = new List<VMPhRequisitionAutomation>();


                pInfoList = new List<VMPhRequisitionAutomation>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPhStckDataTableRow(dRow)))
                    );

                return pInfoList;
            }
            catch
            {
                return null;
            }
        }

        public List<PhInvoiceDetail> GetServedProductListAgainstRequisition(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoiceDetails.SqlQuery("Select * from PhInvoiceDetails Where InvoiceId=(Select Max(InvoiceId) from PhInvoices Where RequisitionNo={0})", requisitionId).ToList();
            }
        }

        private VMPhRequisitionAutomation GetPhStckDataTableRow(DataRow dr)
        {
            VMPhRequisitionAutomation _req = new VMPhRequisitionAutomation();
            _req.LotNo = Convert.ToInt64(dr["LotNo"]);
            _req.ProductId = Convert.ToInt32(dr["ProductId"]);
            _req.BatchNo = dr["BatchNo"].ToString();
            _req.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);
            _req.Qty = Convert.ToInt32(dr["CurrentStock"]);
            _req.OutletId = Convert.ToInt32(dr["OutletId"]);
            return _req;
        }

        public void UpdateOrAddToStockInfo(List<PhSelectedProductsToSaleOrReceiveOrOrder> _rDeatailsList, int outLetId)
        {
            foreach (var item in _rDeatailsList)
            {
                using (DBEntities entities = new DBEntities())
                {
                    PhStockInfo _phst = new PhProductRepository().GetPhStockInfoObj(item.LotNo, item.Id, outLetId);
                    if (_phst != null)
                    {
                        double _newStock = _phst.CurrentStock + item.Qty;
                        _phst.CurrentStock = _newStock;

                        entities.Entry(_phst).State = EntityState.Modified;
                        entities.SaveChanges();
                    }
                    else
                    {
                        PhStockInfo _st = new PhStockInfo();
                        _st.LotNo = item.LotNo;
                        _st.OutLetId = outLetId;
                        _st.ProductId = item.Id;
                        _st.CurrentStock = item.Qty;
                        _st.PurchaseRate = item.PRate;
                        _st.SaleRate = item.SRate;
                        _st.PRIncludingVat = item.PRIncludingVat;
                        entities.PhStockInfoes.Add(_st);
                        entities.SaveChanges();
                    }
                }
            }
        }

        private VWPhProductInfo GetProductInfoDataTableRow(DataRow dr)
        {
            VWPhProductInfo pL = new VWPhProductInfo();
            pL.ProductId = Convert.ToInt32(dr["ProductId"]);
            pL.Unit = dr["Unit"].ToString();
            pL.BrandName = dr["BrandName"].ToString();
            pL.FormationShortName = dr["FormationShortName"].ToString();
            pL.Generic = dr["Generic"].ToString();
            pL.Manufacturer = dr["Manufacturer"].ToString();
            return pL;
        }

        public List<HpMedicineReturnInednt> GetPhRetutnIndentList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpMedicineReturnInednts.Where(x => x.Status.ToLower() == "pending").ToList();
            }
        }

        public bool CreateOutlet(MedicineOutlet _outlet)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.MedicineOutlets.Add(_outlet);
                entities.SaveChanges();
                return true;
            }
        }

        public PhInvoice GetPhInvoiceByInvoiceNo(long _InvoiceNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.InvoiceId == _InvoiceNo).FirstOrDefault();
            }
        }

        public bool AddGroup(PhProductGroup _group)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhProductGroups.Add(_group);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }

        public PhLotInfo GetPhLotInfoByLotNo(long lotNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhLotInfoes.Where(x => x.LotNo == lotNo).FirstOrDefault();
            }
        }

        public long SaveReceivedInvoice(PhReceive rcv)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhReceives.Add(rcv);
                    entities.SaveChanges();
                    return rcv.ReceiveId;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public bool IsPhBillNoAlloted(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                int count = entities.PhInvoices.Where(x => x.BillNo == _billNo).ToList().Count();

                if (count > 0) return true;

                return false;
            }
        }
        public IList<VWPhProductList> GetProductListWithStock(string _filterString)
        {
            try
            {

                string filterString = string.Empty;
                int _outLetId = 0;

                string[] arr = null;
                arr = _filterString.Split('>');

                if (arr.Length > 1)
                {
                    filterString = arr[0];
                    _outLetId = Convert.ToInt32(arr[1]);
                }


                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("Exec [dbo].[spGetPhAllProductWithStock] {0},'{1}'", _outLetId, filterString);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductList> listStockList = new List<VWPhProductList>();


                listStockList = new List<VWPhProductList>(
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

        private VWPhProductList GetStockEntryDataTableRow(DataRow dr)
        {

            VWPhProductList pL = new VWPhProductList();
            pL.ProductId = Convert.ToInt32(dr["ProductId"]);
            pL.OutLetId = Convert.ToInt32(dr["OutLetId"]);
            pL.BrandName = dr["BrandName"].ToString();
            pL.FormationShortName = dr["FormationShortName"].ToString();
            pL.GenericName = dr["Generic"].ToString();
            pL.Manufacturer = dr["Manufacturer"].ToString();
            //  pL.BarCode = dr["BarCode"].ToString(); 

            //pL.BatchNo = dr["BatchNo"].ToString();
            //  pL.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);

            pL.StockAvailable = Convert.ToInt32(dr["CurrentStock"]);
            // pL.LotNo = Convert.ToInt64(dr["LotNo"]);

            pL.PurchaseRate = Convert.ToDouble(dr["PurchasePrice"]);
            pL.SaleRate = Convert.ToDouble(dr["SalePrice"]);
            if (!dr.IsNull("PkgUnit"))
            {
                pL.PkgUnit = dr["PkgUnit"].ToString();
            }
            else
            {
                pL.PkgUnit = "N/A";
            }

            pL.QtyPerBox = Convert.ToInt32(dr["QtyPerBox"]);


            // pL.Unit = dr["Unit"].ToString();
            return pL;
        }


        public void UpdateStockOnSale(List<PhInvoiceDetail> _invDetailsList, int outLetId)
        {
            foreach (var item in _invDetailsList)
            {
                using (DBEntities entities = new DBEntities())
                {
                    PhStockInfo _phst = new PhProductRepository().GetPhStockInfoObj(item.LotNo, item.ProductId, outLetId);
                    double _newStock = _phst.CurrentStock - item.Qty;
                    _phst.CurrentStock = _newStock;

                    entities.Entry(_phst).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        public PhStockInfo GetPhStockInfoObj(long lotNo, int productId, int outLetId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhStockInfoes.Where(x => x.LotNo == lotNo && x.OutLetId == outLetId && x.ProductId == productId).FirstOrDefault();
            }
        }

        public PhOrder GetPhOrderByOrderNo(string _orderNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhOrders.Where(x => x.OrderNo == _orderNo).FirstOrDefault();
            }
        }
        public bool IsRequisitionNoAlloted(long _requisitionNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                int count = entities.HpMedicineRequisitions.Where(x => x.RequisitionId == _requisitionNo).ToList().Count();

                if (count > 0) return true;

                return false;
            }
        }

        public MedicineOutlet getOutletById(int _outletId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MedicineOutlets.Where(x => x.OutLetId == _outletId).FirstOrDefault();
            }
        }

        public PhProductInfo GetProductById(int productId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductInfos.Where(x => x.ProductId == productId).FirstOrDefault();
            }
        }

        public IList<PhInvoiceDetail> GetPhInvoiceDetails(long _InvoiceNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoiceDetails.Where(x => x.InvoiceId == _InvoiceNo).ToList();
            }
        }

        public bool IsBillNoAlloted(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                //  int count= entities.PhInvoices.Where(x=>x.Bi)

                return false;
            }
        }
        public bool SaveReceiveDetails(List<PhReceiveDetail> _rDeatailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhReceiveDetails.AddRange(_rDeatailsList);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public HpMedicineRequisition GetRequisitionByReqId(long _requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpMedicineRequisitions.Where(x => x.RequisitionId == _requisitionId).FirstOrDefault();
            }
        }

        public IList<VWPhProductListForSale> GetPhItemForSale(string _filterString)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    string filterString = string.Empty;
                    int _outLetId = 0;

                    string[] arr = null;
                    arr = _filterString.Split('>');

                    if (arr.Length > 1)
                    {
                        filterString = arr[0];
                        _outLetId = Convert.ToInt32(arr[1]);
                    }

                    SqlParameter outletId = new SqlParameter("outletId", _outLetId);
                    SqlParameter filterStr = new SqlParameter("filterStr", filterString);

                    return entities.Database.SqlQuery<VWPhProductListForSale>(@"Exec spGetPhStockItemForSale @outletId,@filterStr", outletId, filterStr).ToList();

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public IList<VWPhProductList> GetStockListForSale(string _filterString)
        {
            try
            {
                string filterString = string.Empty;
                int _outLetId = 0;

                string[] arr = null;
                arr = _filterString.Split('>');

                if (arr.Length > 1)
                {
                    filterString = arr[0];
                    _outLetId = Convert.ToInt32(arr[1]);
                }

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("Exec spGetPhStockItemForSale {0},'{1}'", _outLetId, filterString.Trim());
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWPhProductList> listStockList = new List<VWPhProductList>();


                listStockList = new List<VWPhProductList>(
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

        private VWPhProductList GetStockDataTableRow(DataRow dr)
        {

            VWPhProductList pL = new VWPhProductList();
            pL.ProductId = Convert.ToInt32(dr["ProductId"]);
            pL.GenericId = Convert.ToInt32(dr["GenericId"]);
            pL.OutLetId = Convert.ToInt32(dr["OutLetId"]);
            pL.BrandName = dr["BrandName"].ToString();
            pL.GenericName = dr["Generic"].ToString();
            pL.Manufacturer = dr["Manufacturer"].ToString();
            //  pL.BarCode = dr["BarCode"].ToString(); 

            pL.BatchNo = dr["BatchNo"].ToString();
            pL.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);

            pL.StockAvailable = Convert.ToInt32(dr["CurrentStock"]);
            pL.LotNo = Convert.ToInt64(dr["LotNo"]);

            pL.PurchaseRate = Convert.ToDouble(dr["PurchasePrice"]);
            pL.SaleRate = Convert.ToDouble(dr["SalePrice"]);
            if (!dr.IsNull("PkgUnit"))
            {
                pL.PkgUnit = dr["PkgUnit"].ToString();
            }
            else
            {
                pL.PkgUnit = "N/A";
            }

            pL.QtyPerBox = Convert.ToInt32(dr["QtyPerBox"]);


            // pL.Unit = dr["Unit"].ToString();
            return pL;
        }

        public int GetTotalOrderOfthisMonth(int year, int month)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhOrders.Where(x => x.OrderYear == year && x.OrderMonth == month).ToList().Count();
            }
        }

        public long AddNewInvoice(PhInvoice pi)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhInvoices.Add(pi);
                    entities.SaveChanges();
                    return pi.InvoiceId;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public bool AddNewInvDetails(List<PhInvoiceDetail> _invDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhInvoiceDetails.AddRange(_invDetailsList);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<VMIssuedProductAgainstRequisition> GetIssuedProductAgainstRequisition(long InvoiceId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {

                    conn.Open();
                    sql = string.Format(@"SELECT dbo.PhInvoices.InvoiceId, dbo.PhInvoiceDetails.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhInvoiceDetails.Qty
                                      FROM dbo.PhProductInfoes INNER JOIN
                                      dbo.PhInvoiceDetails ON dbo.PhProductInfoes.ProductId = dbo.PhInvoiceDetails.ProductId INNER JOIN
                                      dbo.PhInvoices ON dbo.PhInvoiceDetails.InvoiceId = dbo.PhInvoices.InvoiceId Where dbo.PhInvoices.InvoiceId={0}", InvoiceId);

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VMIssuedProductAgainstRequisition> listIssuedItem = new List<VMIssuedProductAgainstRequisition>();


                    listIssuedItem = new List<VMIssuedProductAgainstRequisition>(
                        (from dRow in dt.AsEnumerable()
                         select (GetPhIssuedProductInIndoor(dRow)))
                        );

                    return listIssuedItem;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private VMIssuedProductAgainstRequisition GetPhIssuedProductInIndoor(DataRow dr)
        {
            VMIssuedProductAgainstRequisition _issuedPrd = new VMIssuedProductAgainstRequisition();
            _issuedPrd.ProductId = Convert.ToInt32(dr["ProductId"]);
            _issuedPrd.BrandName = dr["BrandName"].ToString();
            _issuedPrd.Qty = Convert.ToInt32(dr["Qty"]);

            return _issuedPrd;
        }

        public PhInvoice GetPhInvoiceByRequistionNo(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.RequisitionNo == requisitionId).FirstOrDefault();
            }
        }

        public long SaveHpReturnIndent(HpMedicineReturnInednt _ReturnIndent)
        {
            using (DBEntities entities = new DBEntities())
            {

                entities.HpMedicineReturnInednts.Add(_ReturnIndent);
                entities.SaveChanges();
                return _ReturnIndent.ReturnIndentId;

            }

        }



        public PhOrder GetOrderByOrderNo(string orderNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                var phorders = from O in entities.PhOrders where O.OrderNo.Contains(orderNo) select O;

                return phorders.FirstOrDefault();
            }
        }

        public bool SaveBulkProductDataFromExcel(List<PhProductInfo> _pList)
        {
            using (DBEntities entities = new DBEntities())
            {

                entities.PhProductInfos.AddRange(_pList);
                entities.SaveChanges();
                return true;

            }
        }

        public void SaveReturnIndentDetail(List<HpMedicineReturnIndentDetail> _rDeatailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpMedicineReturnIndentDetails.AddRange(_rDeatailsList);
                entities.SaveChanges();

            }
        }

        public void UpdateReturnIndent(HpMedicineReturnInednt _RetIndent)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_RetIndent).State = EntityState.Modified;
                entities.SaveChanges();

            }
        }

        public void SaveBulkProductReceiveData(List<PhReceiveDetail> _pReceiveDetails)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhReceiveDetails.AddRange(_pReceiveDetails);
                entities.SaveChanges();

            }
        }

        public List<PhProductGroup> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public double getPhDiscountByInvoiceId(long invoiceId)
        {
            double _DiscountTk = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as tDiscount from PhSaleLedgers Where InvoiceId={0} and TransactionType in('PhDiscount')", invoiceId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _DiscountTk = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _DiscountTk;
            }
        }

        public double GetPhInvoiceBalance(long invoiceId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as Balance from PhSaleLedgers Where InvoiceId={0}", invoiceId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _balance = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _balance;
            }
        }

        public VWPhProductListForSale GetStockByProductId(int ProductId, int OutLetId, long lotNo)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("select * from  VWPhStockReport Where ProductId={0} and OutLetId={1} and LotNo={2}", ProductId, OutLetId, lotNo);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                return GetStockDataSaleEditTableRow(dt.Rows[0]);


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private VWPhProductListForSale GetStockDataSaleEditTableRow(DataRow dr)
        {
            VWPhProductListForSale pL = new VWPhProductListForSale();
            pL.ProductId = Convert.ToInt32(dr["ProductId"]);

            pL.BrandName = dr["BrandName"].ToString();
            //  pL.BarCode = dr["BarCode"].ToString(); 
            pL.LotNo = Convert.ToInt64(dr["LotNo"]);
            pL.OutLetId = Convert.ToInt32(dr["OutLetId"]);
            pL.StockAvailable = Convert.ToDouble(dr["Stock"]);
            pL.PurchasePrice = Convert.ToDouble(dr["PurchasePrice"]);
            pL.SalePrice = Convert.ToDouble(dr["SalePrice"]);
            // pL.Unit = dr["Unit"].ToString();
            return pL;
        }

        public List<VMReturnRequestList> GetHpMedicineReturnDetail(long _retIndentId)
        {
            try
            {
                sql = string.Format(@"SELECT  dbo.HpMedicineReturnInednts.ReturnIndentId, dbo.HpMedicineReturnIndentDetails.ReturnIndentDetailId, dbo.HpMedicineReturnIndentDetails.LotNo,HpMedicineReturnIndentDetails.OutLetId, dbo.HpMedicineReturnIndentDetails.ProductId, f.ShortFormation +' '+ dbo.PhProductInfoes.BrandName as BrandName, IsNull(dbo.PhProductInfoes.Unit,'N/A') Unit,
                                         dbo.HpMedicineReturnIndentDetails.Qty, dbo.HpMedicineReturnIndentDetails.SRate, dbo.HpMedicineReturnIndentDetails.PRate,  dbo.HpMedicineReturnIndentDetails.SRate*dbo.HpMedicineReturnIndentDetails.Qty as TotalPrice  
                                         FROM  dbo.HpMedicineReturnInednts INNER JOIN
                                         dbo.HpMedicineReturnIndentDetails ON dbo.HpMedicineReturnInednts.ReturnIndentId = dbo.HpMedicineReturnIndentDetails.ReturnIndentId INNER JOIN
                                         dbo.PhProductInfoes ON dbo.HpMedicineReturnIndentDetails.ProductId = dbo.PhProductInfoes.ProductId join Formations f on 
										 dbo.PhProductInfoes.FormationId=f.FormationId
										 Where  dbo.HpMedicineReturnInednts.ReturnIndentId = {0}", _retIndentId);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                List<VMReturnRequestList> listhp = new List<VMReturnRequestList>();

                listhp = new List<VMReturnRequestList>(
                  (from dRow in dt.AsEnumerable()
                   select (GetPhReturnDataRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void CancelMedicineReturnId(long _retId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                conn.Open();
                sql = string.Format("Update HpMedicineReturnInednts Set Status='Cancelled' Where ReturnIndentId={0}", _retId);
                cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private VMReturnRequestList GetPhReturnDataRow(DataRow dr)
        {
            VMReturnRequestList _retL = new VMReturnRequestList();
            _retL.ReturnId = Convert.ToInt64(dr["ReturnIndentId"]);
            _retL.ProductId = Convert.ToInt32(dr["ProductId"]);
            _retL.BrandName = dr["BrandName"].ToString();
            _retL.SalePrice = Convert.ToDouble(dr["SRate"]);
            _retL.PurchasePrice = Convert.ToDouble(dr["PRate"]);
            _retL.RetQty = Convert.ToDouble(dr["Qty"]);
            _retL.LotNo = Convert.ToInt64(dr["LotNo"]);
            _retL.OutLetId = Convert.ToInt32(dr["OutLetId"]);
            _retL.TotalPrice = Convert.ToDouble(dr["TotalPrice"]);
            return _retL;
        }

        public HpMedicineReturnInednt GetReturnIndentById(long __retIndentNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpMedicineReturnInednts.Where(x => x.ReturnIndentId == __retIndentNo).FirstOrDefault();
            }
        }

        public void CancelMedicineRequisition(long _requisition)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                conn.Open();
                sql = string.Format("Update HpMedicineRequisitions Set Status='Cancelled' Where RequisitionId={0}", _requisition);
                cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        public void UpdaMedicineRequisition(HpMedicineRequisition _requisition)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_requisition).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public List<PhSelectedProductsToSaleOrReceiveOrOrder> GetOrderedProductListByOrderId(long orderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format(@"SELECT        dbo.PhOrders.OrderId, dbo.PhOrders.OrderTo, dbo.PhOrders.OrderNo, dbo.PhOrders.OrderDate, dbo.PhOrders.OrderYear, dbo.PhOrders.OrderMonth, dbo.PhOrderDetails.ProductId, dbo.PhProductInfoes.BarCode, 
                         dbo.PhProductInfoes.BrandName,dbo.PhProductInfoes.PurchasePrice, dbo.PhOrderDetails.Qty, dbo.PhOrderDetails.TotalPrice
                         FROM            dbo.PhOrders INNER JOIN
                         dbo.PhOrderDetails ON dbo.PhOrders.OrderId = dbo.PhOrderDetails.OrderId INNER JOIN
                         dbo.PhProductInfoes ON dbo.PhOrderDetails.ProductId = dbo.PhProductInfoes.ProductId
                         WHERE(dbo.PhOrders.OrderId = {0})", orderId);

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<PhSelectedProductsToSaleOrReceiveOrOrder> listProductSaleReceiveOrderItemList = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();


                    listProductSaleReceiveOrderItemList = new List<PhSelectedProductsToSaleOrReceiveOrOrder>(
                        (from dRow in dt.AsEnumerable()
                         select (GetPhProductSaleReceiveOrderItem(dRow)))
                        );

                    return listProductSaleReceiveOrderItemList;


                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PhInvoice> GetInvoiceListByAdmissionNo(long _admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.AdmissionNo == _admissionId).ToList();
            }
        }

        public PhInvoice GetPhFirstInvoice()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.SqlQuery("Select * from PhInvoices Where InvoiceId=(Select MIn(InvoiceId) from PhInvoices)").FirstOrDefault();
            }
        }

        public PhInvoice GetPhInvoiceByInvoiceId(long _InvoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.InvoiceId == _InvoiceId).FirstOrDefault();
            }
        }

        public PhInvoice GetPhInvoiceByBillNo(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.BillNo == _billNo).FirstOrDefault();
            }
        }

        public PhInvoice GetPhIPDLastestInvoice()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.SqlQuery("Select * from PhInvoices Where InvoiceId=(Select Max(InvoiceId) from PhInvoices Where InvoiceType='IS')").FirstOrDefault();
            }
        }
        public void SavePhSaleLedger(List<PhSaleLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhSaleLedgers.AddRange(transactionList);
                entities.SaveChanges();
            }
        }

        public IList<PhInvoiceType> GetInvoiceType()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoiceTypes.ToList();
            }
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPhProductSaleReceiveOrderItem(DataRow dr)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _psro = new PhSelectedProductsToSaleOrReceiveOrOrder();

            _psro.Id = Convert.ToInt32(dr["ProductId"]);
            _psro.BarCode = dr["BarCode"].ToString();

            _psro.Name = dr["BrandName"].ToString();
            _psro.Qty = Convert.ToInt32(dr["Qty"]);
            _psro.PRate = Convert.ToDouble(dr["PurchasePrice"]);
            _psro.Total = Convert.ToDouble(dr["PurchasePrice"]) * Convert.ToInt32(dr["Qty"]);

            return _psro;

        }

        public long SaveOrder(PhOrder Phord)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhOrders.Add(Phord);
                    entities.SaveChanges();
                    return Phord.OrderId;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public bool SaveOrderDetail(List<PhOrderDetail> _ODeatailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PhOrderDetails.AddRange(_ODeatailsList);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }





        public PhCompany GetCompany()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhCompanies.Where(x => x.Id == 1).FirstOrDefault();
            }
        }
    }
}
