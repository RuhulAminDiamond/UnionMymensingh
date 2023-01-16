using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Pharmacy.ViewModels;
using System.Data.SqlClient;
using HDMS.Common.Utils;
using System.Data;
using HDMS.Model.Pharmacy;
using HDMS.Model.Common;
using HDMS.Model.HR;
using HDMS.Models.Pharmacy;
using System.Data.Entity;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.Enums;
using HDMS.Model;
using HDMS.Model.Hospital;
using Models.Accounting;
using HDMS.Models.Pharmacy.ViewModels;

namespace HDMS.Repository.Pharmacy
{
    public class PhFinancialRepository
    {

        string sql = string.Empty;
        SqlConnection con;
        SqlDataAdapter da;
        public async Task<List<VMIndoorMedicineBill>> GetIndoorMedicineBillOfUndertreatedPatient(int _deptId)
        {
            return await Task.Run(() =>
            {
                try
                {

                    con = new SqlConnection();
                    con.ConnectionString = Utility.GetLegacyDbConnectionString();
                    con.Open();
                    sql = string.Format(@"SELECT dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, dbo.RegRecords.FullName, dbo.VWMedicineBillList.MedicineBill
                                      FROM  dbo.CabinInfoes INNER JOIN
                                      dbo.HpPatientAccomodationInfoes ON dbo.CabinInfoes.CabinId = dbo.HpPatientAccomodationInfoes.CabinId INNER JOIN
									  HpDepartments on CabinInfoes.DeptId=HpDepartments.DeptId inner join
                                      dbo.HospitalPatientInfoes ON dbo.HpPatientAccomodationInfoes.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                      dbo.VWMedicineBillList ON dbo.HospitalPatientInfoes.AdmissionId = dbo.VWMedicineBillList.AdmissionId
                                      WHERE  (dbo.HospitalPatientInfoes.Status <> 'DisCharged') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed') And (HpDepartments.DeptId={0} or {0}=0)", _deptId);

                    da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();

                    List<VMIndoorMedicineBill> billList = new List<VMIndoorMedicineBill>();

                    billList = dt.AsEnumerable().Select(dr => new VMIndoorMedicineBill()
                    {
                        BillNo = Convert.ToInt64(dr["BillNo"]),
                        FullName = dr["FullName"].ToString(),
                        CabinNo = dr["CabinNo"].ToString(),
                        MedicineBill = Convert.ToDouble(dr["MedicineBill"])

                    }).ToList();

                    return billList;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            });

        }

        public double GetManuFactureLedger(int manufacturerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ManufacturerLedgers.Where(x => x.ManufacturerId == manufacturerId).ToList().Sum(q => q.Credit - q.Debit);

                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public PhReceive GetPhReceiveByManufacturerId(int manufacturerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.PhReceives.Where(x => x.SupplerId == manufacturerId).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public double GetSupplierBalance(int _SupplierId)
        {

            using (DBEntities entities = new DBEntities())
            {
                var result = entities.PhSupplierLedgers
                   .Where(s => s.ManufacturerId == _SupplierId)
                   .AsEnumerable()
                   .Sum(s => s.Credit - s.Debit);

                return Convert.ToDouble(result);
            }

        }

        public bool SaveManufacturerLedger(ManufacturerLedger ledger)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ManufacturerLedgers.Add(ledger);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public DataSet GetSupplierLedger(DateTime dtpfrm, DateTime dtpto, int manufacturerId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Exec spGetPhSupplierLedger '{0}','{1}',{2}", dtpfrm, dtpto, manufacturerId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsPurchase = new DataSet();
                da.Fill(dsPurchase);

                con.Close();

                return dsPurchase;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PhInvoice> GetReturnInvoices(long admissionBillNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.AdmissionNo == admissionBillNo && x.InvoiceType.ToLower().Equals("RRN")).ToList();
            }
        }

        public DataSet GetPurchaseStatement(DateTime dtpfrm, DateTime dtpto, int outLetId, int manufacId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                if (manufacId > 0)
                {
                    sql = string.Format(@"Select * from VWPhPurchaseDetails Where  SupInvDate between '{0}' and '{1}' and  OutLetId={2} and SupplerId={3}", dtpfrm, dtpto, outLetId, manufacId);
                }
                else
                {
                    sql = string.Format(@"Select * from VWPhPurchaseDetails Where  SupInvDate between '{0}' and '{1}' and  OutLetId={2} and SupplerId<>'110'", dtpfrm, dtpto, outLetId);
                }
                da = new SqlDataAdapter(sql, con);
                DataSet dsPurchase = new DataSet();
                da.Fill(dsPurchase);

                con.Close();

                return dsPurchase;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SavePhPurchaseSaleLedger(List<PhPurchaseLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhPurchaseLedgers.AddRange(transactionList);
                entities.SaveChanges();
            }
        }

        public void SaveSupplierLedgerTransactions(List<PhSupplierLedger> _sLedgerList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhSupplierLedgers.AddRange(_sLedgerList);
                entities.SaveChanges();
            }
        }

        public DataSet GetPurchaseInvoice(long _ReceiveId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Select * from VWPhPurchaseDetails Where  ReceiveId= {0}", _ReceiveId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsPurchase = new DataSet();
                da.Fill(dsPurchase);

                con.Close();

                return dsPurchase;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SavePhIPDSaleTransactionLedger(List<PhIPDSaleLedger> _ipdtransactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhIPDSaleLedgers.AddRange(_ipdtransactionList);
                entities.SaveChanges();
            }
        }

        public List<PhSelectedProductsToSaleOrReceiveOrOrder> GetSockEntryInvoiceNo(long invoice)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    var result = entities.Database.SqlQuery<PhSelectedProductsToSaleOrReceiveOrOrder>(@"
                                                SELECT BrandName AS Name
	                                                ,Convert( nvarchar, phrd.LotNo) AS BatchNo
	                                                ,phrd.Qty
	                                                ,phrd.Total
	                                                ,phrd.Total - (phrd.Total * phrd.disCountInpercent / 100) AS Gtotal
	                                                --,phrdI.Unit
	                                                ,phrdI.PurchasePrice AS RRate
	                                                ,phrd.vatInpercent
	                                                ,phrd.vatInTk
	                                                ,phrd.grossDiscount AS Discount
	                                                ,phrd.disCountInpercent AS DiscInPercentPerProduct
	                                                ,phr.RDate AS ExpireDate
	                                                ,phrd.PurchaseRate as PRate
                                                    ,phrdI.ProductId as Id
                                                FROM PhReceives AS phr
                                                INNER JOIN PhReceiveDetails AS phrd ON phr.ReceiveId = phrd.ReceivedId
                                                INNER JOIN PhProductInfoes AS phrdI ON phrdI.ProductId = phrd.ProductId
                                                WHERE phr.ReceiveId = {0}", invoice

                                                   ).ToList();


                    return result;




                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public void SavePhSaleLedgerList(List<PhSaleLedger> _saleLedgerList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhSaleLedgers.AddRange(_saleLedgerList);
                entities.SaveChanges();
            }
        }

        public DataSet GetOPDCustomerLedger(int memberId, DateTime _dtpfrm, DateTime _dtpto)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Exec [dbo].[SpGetPhOPDCustomerLedger] {0},'{1}','{2}',''", memberId, _dtpfrm, _dtpto);

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

        public List<PhPurchaseLedger> GetPhPurchaseLedgerByReceiveId(long _receivedId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.PhPurchaseLedgers.Where(x => x.ReceiveId == _receivedId).ToList();

            }
        }

        public void SavePhIPDSaleLedger(List<PhIPDSaleLedger> ipdtransactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhIPDSaleLedgers.AddRange(ipdtransactionList);
                entities.SaveChanges();
            }
        }

        public async Task<PhReceive> SaveNewPurchase(PhReceive rcv, List<PhSelectedProductsToSaleOrReceiveOrOrder> selectedItems, VMPhEndPointDataCarrierForStockEntry voucherObj, bool isIntegratedAccountInAction, double _discountInPercent, double _vatInPercents)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {

                    try
                    {
                        entities.PhReceives.Add(rcv);
                        entities.SaveChanges();

                        List<PhReceiveDetail> _rDeatailsList = new List<PhReceiveDetail>();

                        foreach (var item in selectedItems)
                        {
                            PhReceiveDetail _rDetails = new PhReceiveDetail();
                            _rDetails.ReceivedId = rcv.ReceiveId;
                            _rDetails.LotNo = item.LotNo;
                            _rDetails.ProductId = item.Id;
                            _rDetails.Qty = item.Qty;
                            _rDetails.PurchaseRate = item.PRate;
                            _rDetails.Total = item.Total;
                            _rDetails.disCountInpercent = item.DiscInPercentPerProduct;
                            _rDetails.grossDiscount = item.Discount + (item.Total * _discountInPercent)/100;
                            _rDetails.vatInpercent = item.VatInPercentPerProduct;
                            _rDetails.vatInTk = item.Vat +( item.Total * _vatInPercents /100);
                            _rDeatailsList.Add(_rDetails);

                        }

                        if (_rDeatailsList.Count > 0)
                        {
                            entities.PhReceiveDetails.AddRange(_rDeatailsList);
                            entities.SaveChanges();

                        }


                        List<PhProductLedger> _prodLedger = new List<PhProductLedger>();
                        foreach (var item in selectedItems)
                        {
                            var stckList = entities.PhStockInfoes.Where(x => x.ProductId == item.Id && x.OutLetId == voucherObj.OutletId && x.CurrentStock > 0).ToList();

                            double opStock = 0;
                            double closingStock = 0;

                            if (stckList != null)
                            {
                                opStock = stckList.Sum(x => x.CurrentStock);
                            }


                            PhStockInfo _phst = entities.PhStockInfoes.Where(x => x.LotNo == item.LotNo && x.OutLetId == voucherObj.OutletId && x.ProductId == item.Id).FirstOrDefault();

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
                                _st.OutLetId = rcv.OutLetId;
                                _st.ProductId = item.Id;
                                _st.CurrentStock = item.Qty;
                                _st.BookedQty = 0;
                                _st.PurchaseRate = item.PRate;
                                _st.SaleRate = item.SRate;
                                _st.PRIncludingVat = item.PRIncludingVat;
                                _st.BookedBy = "";
                                entities.PhStockInfoes.Add(_st);
                                entities.SaveChanges();

                            }

                            closingStock = opStock + item.Qty;

                            PhProductLedger prodlObj = new PhProductLedger();
                            prodlObj.TDate = voucherObj.TransactionDateTime;
                            prodlObj.TTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            prodlObj.OutletId = voucherObj.OutletId;
                            prodlObj.ProductId = item.Id;
                            prodlObj.OpStock = opStock;
                            prodlObj.Particulars = Constants.NewStockEntry + rcv.ReceiveId.ToString();
                            prodlObj.StockQty = item.Qty;
                            prodlObj.SoldQty = 0;
                            prodlObj.TransferQty = 0;
                            prodlObj.RetQty = 0;
                            prodlObj.ClosingStock = closingStock;
                            prodlObj.UserName = voucherObj.TransactionBy;
                            _prodLedger.Add(prodlObj);

                        }

                        if (_prodLedger.Count > 0)
                        {
                            entities.PhProductLedgers.AddRange(_prodLedger);
                            entities.SaveChanges();
                        }


                        List<ManufacturerLedger> tranList = new List<ManufacturerLedger>();
                        ManufacturerLedger _ledger = new ManufacturerLedger();

                        var _balace = entities.ManufacturerLedgers.Where(x => x.ManufacturerId == rcv.SupplerId).ToList().Sum(q => q.Credit - q.Debit);
                        _balace = _balace + rcv.TotalTk + rcv.DiscountTk;
                        _ledger.ManufacturerId = rcv.SupplerId;
                        _ledger.Trandate = rcv.RDate;
                        _ledger.Particulars = "Purchase Invoice: " + rcv.ReceiveId.ToString();
                        _ledger.Credit = rcv.TotalTk + rcv.DiscountTk;
                        _ledger.Debit = 0;
                        _ledger.Balance = _balace;

                        tranList.Add(_ledger);

                        if (rcv.DiscountTk > 0)
                        {
                            _balace = _balace - rcv.DiscountTk;
                            _ledger = new ManufacturerLedger();
                            _ledger.ManufacturerId = rcv.SupplerId;
                            _ledger.Trandate = rcv.RDate;
                            _ledger.Particulars = "Discount On Invoice: " + rcv.ReceiveId.ToString();
                            _ledger.Credit = 0;
                            _ledger.Debit = rcv.DiscountTk;
                            _ledger.Balance = _balace;

                            tranList.Add(_ledger);
                        }

                        entities.ManufacturerLedgers.AddRange(tranList);
                        entities.SaveChanges();


                        transaction.Commit();

                        return await Task.FromResult(rcv);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return await Task.FromResult(new PhReceive() { ReceiveId = 0 });
                    }
                }
            }
        }



        public async Task<PhInvoice> SaveAndCommitOPDNewSale(PhInvoice pi, List<PhInvoiceDetail> invDetailsList, VMPhEndpointDataCarrier voucherObj, bool IsIntegratedAccountInAction)
        {
            using (DBEntities entities = new DBEntities())
            {

                using (var scope = entities.Database.BeginTransaction())
                {

                    try
                    {

                        // Save Invoice 
                        entities.PhInvoices.Add(pi);
                        entities.SaveChanges();

                        // Save Invoice Details
                        List<PhInvoiceDetail> _invDetailsList = new List<PhInvoiceDetail>();
                        List<PhProductLedger> _prodLedger = new List<PhProductLedger>();
                        List<PhStockInfo> _phStockLst = new List<PhStockInfo>();
                        foreach (PhInvoiceDetail invd in invDetailsList)
                        {

                            var stckList = entities.PhStockInfoes.Where(x => x.ProductId == invd.ProductId && x.OutLetId == voucherObj.OutletId && x.CurrentStock > 0).ToList();

                            double opStock = 0;
                            if (stckList != null)
                            {

                                opStock = stckList.Sum(x => x.CurrentStock);

                                PhStockInfo _phst = entities.PhStockInfoes.Where(x => x.LotNo == invd.LotNo && x.OutLetId == voucherObj.OutletId && x.ProductId == invd.ProductId).FirstOrDefault();
                                double soldQty = invd.Qty;
                                if (_phst != null)
                                {
                                    if (_phst.CurrentStock < invd.Qty)
                                    {
                                        soldQty = _phst.CurrentStock;
                                    }

                                    PhInvoiceDetail pid = new PhInvoiceDetail();
                                    pid.InvoiceId = pi.InvoiceId;
                                    pid.ProductId = invd.ProductId;

                                    pid.LotNo = invd.LotNo;
                                    pid.Qty = soldQty;
                                    pid.SaleRate = invd.SaleRate;
                                    pid.TotalPrice = soldQty * invd.SaleRate;
                                    pid.Discount = invd.Discount;
                                    pid.PurchaseRate = invd.PurchaseRate;

                                    _invDetailsList.Add(pid);

                                    PhProductLedger prodlObj = new PhProductLedger();
                                    prodlObj.TDate = voucherObj.TransactionDateTime;
                                    prodlObj.TTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                                    prodlObj.OutletId = voucherObj.OutletId;
                                    prodlObj.ProductId = invd.ProductId;
                                    prodlObj.OpStock = opStock;
                                    prodlObj.Particulars = Constants.StockMinusBySale + pi.InvoiceId.ToString();
                                    prodlObj.StockQty = 0;
                                    prodlObj.SoldQty = soldQty;
                                    prodlObj.TransferQty = 0;
                                    prodlObj.RetQty = 0;
                                    prodlObj.ClosingStock = opStock - soldQty;
                                    prodlObj.UserName = voucherObj.TransactionBy;
                                    _prodLedger.Add(prodlObj);


                                    double _newStock = _phst.CurrentStock - soldQty;
                                    _phst.CurrentStock = _newStock;

                                    _phStockLst.Add(_phst);


                                }

                            }
                        }

                        entities.PhInvoiceDetails.AddRange(_invDetailsList);
                        entities.SaveChanges();

                        entities.PhProductLedgers.AddRange(_prodLedger);
                        entities.SaveChanges();

                        // Stock Update
                        foreach (var item in _phStockLst)
                        {

                            entities.Database.ExecuteSqlCommand(@"Update PhStockInfoes Set CurrentStock = @p0 Where StckId=@p1", new SqlParameter("@p0", item.CurrentStock), new SqlParameter("@p1", item.StckId));

                        }

                        //End of Stock Update





                        if (voucherObj.IsStaffSale)
                        {
                            PhMemberInfo _member = voucherObj.PhMemberInfo;

                            List<PhMemberLedger> ipdLedgers = entities.PhMemberLedgers.Where(x => x.MemberId == voucherObj.PhMemberInfo.MemberId).ToList();
                            double ebalance = ipdLedgers.Sum(x => x.Credit - x.Debit);


                            ebalance = ebalance - voucherObj.SaleAmount;
                            //Save On Entry Payment Information
                            List<PhMemberLedger> _employeetransactionList = new List<PhMemberLedger>();
                            PhMemberLedger eLedger = new PhMemberLedger();
                            eLedger.MemberId = _member.MemberId;
                            eLedger.TranDate = voucherObj.TransactionDateTime;
                            eLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            eLedger.Particulars = "Product Cost. Invoice No: " + pi.InvoiceId.ToString();
                            eLedger.Debit = voucherObj.SaleAmount;
                            eLedger.Credit = 0;
                            eLedger.Balance = ebalance;
                            eLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                            eLedger.OperateBy = voucherObj.TransactionBy;
                            eLedger.PCId = 0;
                            eLedger.TransactionNo = "";
                            _employeetransactionList.Add(eLedger);


                            if (voucherObj.DiscountAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.DiscountAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = voucherObj.TransactionDateTime;
                                eLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                                eLedger.Particulars = "Discount";
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.DiscountAmount;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = 0;
                                eLedger.TransactionNo = "";
                                _employeetransactionList.Add(eLedger);
                            }

                            if (voucherObj.CashPaidAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.CashPaidAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = DateTime.Now;
                                eLedger.Particulars = "Paid as Recive Tk. " + voucherObj.CashPaidAmount.ToString();
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.CashPaidAmount;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = voucherObj.CashPayChannelId;
                                eLedger.TransactionNo = "";
                                _employeetransactionList.Add(eLedger);
                            }

                            if (voucherObj.CardOrMobilePaidAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.CardOrMobilePaidAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = DateTime.Now;
                                eLedger.Particulars = "Paid as Recive Tk. " + voucherObj.CardOrMobilePaidAmount.ToString();
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.CardOrMobilePaidAmount;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = voucherObj.PCId;
                                eLedger.TransactionNo = voucherObj.TransactionNo;
                                _employeetransactionList.Add(eLedger);
                            }

                            if (voucherObj.CardOrMobileServiceCharge > 0)
                            {

                                //ebalance = ebalance + voucherObj.CardOrMobilePaidAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = DateTime.Now;
                                eLedger.Particulars = "Service Charege Tk. " + voucherObj.CardOrMobileServiceCharge.ToString();
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.CardOrMobileServiceCharge;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.CardOrMobileServiceCharge.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = voucherObj.PCId;
                                eLedger.TransactionNo = voucherObj.TransactionNo;
                                _employeetransactionList.Add(eLedger);
                            }

                            if (_employeetransactionList.Count > 0)
                            {
                                entities.PhMemberLedgers.AddRange(_employeetransactionList);
                                entities.SaveChanges();
                            }

                        }


                        double balance = 0;
                        balance = 0 - voucherObj.SaleAmount;
                        //Save On Entry Payment Information
                        List<PhSaleLedger> transactionList = new List<PhSaleLedger>();
                        PhSaleLedger pLedger = new PhSaleLedger();
                        pLedger.InvoiceId = pi.InvoiceId;
                        pLedger.TranDate = voucherObj.TransactionDateTime;
                        pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                        pLedger.Particulars = "Product/s Price";
                        pLedger.Debit = voucherObj.SaleAmount;
                        pLedger.Credit = 0;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                        pLedger.OperateBy = voucherObj.TransactionBy;
                        pLedger.PCId = 0;
                        pLedger.TransactionNo = "";
                        transactionList.Add(pLedger);


                        if (voucherObj.DiscountAmount > 0)
                        {

                            balance = balance + voucherObj.DiscountAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = DateTime.Now;
                            pLedger.Particulars = "Discount";
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.DiscountAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = 0;
                            pLedger.TransactionNo = "";
                            transactionList.Add(pLedger);
                        }


                        if (voucherObj.CashPaidAmount > 0)
                        {

                            balance = balance + voucherObj.CashPaidAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.Particulars = "Paid as Recive Tk. " + voucherObj.CashPaidAmount.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CashPaidAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.CashPayChannelId;
                            pLedger.TransactionNo = "";
                            transactionList.Add(pLedger);

                        }

                        if (voucherObj.CardOrMobilePaidAmount > 0)
                        {

                            balance = balance + voucherObj.CardOrMobilePaidAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.Particulars = "Card/Mobile Tk. " + voucherObj.CardOrMobilePaidAmount.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CardOrMobilePaidAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.PCId;
                            pLedger.TransactionNo = voucherObj.TransactionNo;
                            transactionList.Add(pLedger);

                        }

                        if (voucherObj.CardOrMobileServiceCharge > 0)
                        {

                            //balance = balance + voucherObj.CardOrMobilePaidAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.Particulars = "Service Charge Tk. " + voucherObj.CardOrMobileServiceCharge.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CardOrMobileServiceCharge;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.CardOrMobileServiceCharge.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.PCId;
                            pLedger.TransactionNo = voucherObj.TransactionNo;
                            transactionList.Add(pLedger);

                        }

                        if (transactionList.Count > 0)
                        {

                            entities.PhSaleLedgers.AddRange(transactionList);
                            entities.SaveChanges();
                        }

                        if (voucherObj.IsIpdSale)
                        {
                            if (voucherObj.hpMedicineRequisition != null)
                            {
                                if (voucherObj.IPDRequisitionDeliveryStatus == RequisitionStatusEnum.Served.ToString())
                                {
                                    List<HpMedicineRequisitionDetail> _reqList = entities.HpMedicineRequisitionDetails.Where(x => x.RequisitionId == voucherObj.hpMedicineRequisition.RequisitionId).ToList();
                                    List<PhInvoiceDetail> _invItemList = entities.PhInvoiceDetails.SqlQuery("Select * from PhInvoiceDetails Where InvoiceId=(Select Max(InvoiceId) from PhInvoices Where RequisitionNo={0})", voucherObj.hpMedicineRequisition.RequisitionId).ToList();

                                    foreach (HpMedicineRequisitionDetail _reqItem in _reqList)
                                    {

                                        PhInvoiceDetail _invdetail = _invItemList.Where(x => x.ProductId == _reqItem.ProductId).FirstOrDefault();
                                        if (_invdetail != null)
                                        {
                                            _reqItem.DeliveredQty = _invdetail.Qty;
                                            if (_reqItem.DeliveredQty == _invdetail.Qty)
                                            {
                                                _reqItem.Status = RequisitionStatusEnum.Served.ToString();
                                            }
                                            else
                                            {
                                                RequisitionStatusEnum.PartiallyServed.ToString();
                                            }



                                            entities.Entry(_reqItem).State = EntityState.Modified;
                                            entities.SaveChanges();
                                        }
                                    }

                                }
                                else if (voucherObj.IPDRequisitionDeliveryStatus == RequisitionStatusEnum.PartiallyServed.ToString())
                                {
                                    List<PhInvoiceDetail> _inVDetail = entities.PhInvoiceDetails.SqlQuery("Select * from PhInvoiceDetails Where InvoiceId=(Select Max(InvoiceId) from PhInvoices Where RequisitionNo={0})", voucherObj.hpMedicineRequisition.RequisitionId).ToList();

                                    List<PhInvoiceDetail> _invdL = _inVDetail.GroupBy(x => x.ProductId).Select(q => q.First()).ToList();

                                    foreach (PhInvoiceDetail _deliverItem in _invdL)
                                    {
                                        HpMedicineRequisitionDetail _mreqd = entities.HpMedicineRequisitionDetails.Where(x => x.RequisitionId == voucherObj.hpMedicineRequisition.RequisitionId && x.ProductId == _deliverItem.ProductId).FirstOrDefault();
                                        _mreqd.DeliveredQty = _mreqd.Qty;
                                        //if (_mreqd.Qty == _deliverItem.Qty)
                                        //{
                                        _mreqd.Status = RequisitionStatusEnum.Served.ToString();
                                        //}else
                                        //{
                                        //    _mreqd.Status = RequisitionStatusEnum.PartiallyServed.ToString();
                                        //}
                                        entities.Entry(_mreqd).State = EntityState.Modified;
                                        entities.SaveChanges();
                                    }
                                }

                                voucherObj.hpMedicineRequisition.Status = voucherObj.IPDRequisitionDeliveryStatus;

                                entities.Entry(voucherObj.hpMedicineRequisition).State = EntityState.Modified;
                                entities.SaveChanges();

                            }
                        }

                        if (voucherObj.InvoiceTypeTagVal == 3 || voucherObj.InvoiceTypeTagVal == 9)
                        {

                            HpMedicineRequisition _Mreq = voucherObj.hpMedicineRequisition;
                            if (_Mreq != null)
                            {
                                _Mreq.Status = RequisitionStatusEnum.Served.ToString();
                                entities.Entry(_Mreq).State = EntityState.Modified;
                                entities.SaveChanges();
                            }


                        }

                        // Sale Voucher

                        //Pick Sale Account

                        if (IsIntegratedAccountInAction)
                        {

                            int _saleAccountId = 0;

                            if (voucherObj.IsIpdSale)
                            {
                                _saleAccountId = 100;
                            }
                            else
                            {
                                _saleAccountId = 101;
                            }

                            string _voucherType = "Credit";
                            if (voucherObj.CashPaidAmount == 0)  // if Full Credit then Journal Else Credit Voucher
                            {
                                _voucherType = "Journal";
                            }

                            Voucher _saleVoucher = new Voucher();
                            _saleVoucher.CompanyId = 1;
                            _saleVoucher.VoucherDate = voucherObj.TransactionDateTime;
                            _saleVoucher.VTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            _saleVoucher.VoucherId = "";
                            _saleVoucher.VoucherType = _voucherType;
                            _saleVoucher.Description = "Sale Invoice " + pi.InvoiceId.ToString();
                            _saleVoucher.CreateUser = voucherObj.TransactionBy;

                            entities.Vouchers.Add(_saleVoucher);
                            entities.SaveChanges();


                            List<VoucherDetail> vdList = new List<VoucherDetail>();

                            VoucherDetail detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = _saleVoucher.VMId;
                            detailsVoucher.DRCR = "C";
                            detailsVoucher.Amount = voucherObj.SaleAmount;
                            detailsVoucher.AccId = _saleAccountId;
                            detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                            vdList.Add(detailsVoucher);
                            if (voucherObj.DueAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.DueAmount;
                                detailsVoucher.AccId = voucherObj.ReceivableAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            if (voucherObj.CashPaidAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.CashPaidAmount;
                                detailsVoucher.AccId = voucherObj.CashAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            if (voucherObj.DiscountAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.DiscountAmount;
                                detailsVoucher.AccId = voucherObj.DiscountAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            entities.VoucherDetails.AddRange(vdList);
                            entities.SaveChanges();

                            // Inventory journal

                            Voucher _InventoryVoucher = new Voucher();
                            _InventoryVoucher.CompanyId = 1;
                            _InventoryVoucher.VoucherDate = voucherObj.TransactionDateTime;
                            _InventoryVoucher.VTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            _InventoryVoucher.VoucherId = "";
                            _InventoryVoucher.VoucherType = "Journal";
                            _InventoryVoucher.Description = "Sale Invoice " + pi.InvoiceId.ToString();
                            _InventoryVoucher.CreateUser = voucherObj.TransactionBy;

                            entities.Vouchers.Add(_InventoryVoucher);
                            entities.SaveChanges();

                            vdList = new List<VoucherDetail>();

                            VoucherDetail vdetail = new VoucherDetail();
                            vdetail.VMId = _InventoryVoucher.VMId;
                            vdetail.DRCR = "C";
                            vdetail.Amount = voucherObj.CostAmount;
                            vdetail.AccId = voucherObj.StockAccId;
                            vdetail.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                            vdList.Add(vdetail);

                            vdetail = new VoucherDetail();
                            vdetail.VMId = _InventoryVoucher.VMId;
                            vdetail.DRCR = "D";
                            vdetail.Amount = voucherObj.CostAmount;
                            vdetail.AccId = voucherObj.StockExpAccId;
                            vdetail.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                            vdList.Add(vdetail);

                            entities.VoucherDetails.AddRange(vdList);
                            entities.SaveChanges();

                        }

                        scope.Commit();

                        return await Task.FromResult(pi);

                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                        return await Task.FromResult(new PhInvoice() { InvoiceId = 0 });
                    }
                }

            }
        }


        public async Task<PhInvoice> SaveAndCommitNewSale(PhInvoice pi, List<PhInvoiceDetail> invDetailsList, VMPhEndpointDataCarrier voucherObj, bool IsIntegratedAccountInAction)
        {
            using (DBEntities entities = new DBEntities())
            {

                using (var scope = entities.Database.BeginTransaction())
                {

                    try
                    {

                        // Save Invoice 
                        entities.PhInvoices.Add(pi);
                        entities.SaveChanges();

                        // Save Invoice Details
                        List<PhInvoiceDetail> _invDetailsList = new List<PhInvoiceDetail>();
                        List<PhProductLedger> _prodLedger = new List<PhProductLedger>();
                        List<PhStockInfo> _phStockLst = new List<PhStockInfo>();
                        foreach (PhInvoiceDetail invd in invDetailsList)
                        {

                            var stckList = entities.PhStockInfoes.Where(x => x.ProductId == invd.ProductId && x.OutLetId == voucherObj.OutletId && x.CurrentStock > 0).ToList();

                            double opStock = 0;
                            if (stckList != null)
                            {

                                opStock = stckList.Sum(x => x.CurrentStock);

                                PhStockInfo _phst = entities.PhStockInfoes.Where(x => x.LotNo == invd.LotNo && x.OutLetId == voucherObj.OutletId && x.ProductId == invd.ProductId).FirstOrDefault();
                                double soldQty = invd.Qty;
                                if (_phst != null)
                                {
                                    if (_phst.CurrentStock < invd.Qty)
                                    {
                                        soldQty = _phst.CurrentStock;
                                    }

                                    PhInvoiceDetail pid = new PhInvoiceDetail();
                                    pid.InvoiceId = pi.InvoiceId;
                                    pid.ProductId = invd.ProductId;

                                    pid.LotNo = invd.LotNo;
                                    pid.Qty = soldQty;
                                    pid.SaleRate = invd.SaleRate;
                                    pid.TotalPrice = soldQty * invd.SaleRate;
                                    pid.Discount = invd.Discount;
                                    pid.PurchaseRate = invd.PurchaseRate;

                                    _invDetailsList.Add(pid);

                                    PhProductLedger prodlObj = new PhProductLedger();
                                    prodlObj.TDate = voucherObj.TransactionDateTime;
                                    prodlObj.TTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                                    prodlObj.OutletId = voucherObj.OutletId;
                                    prodlObj.ProductId = invd.ProductId;
                                    prodlObj.OpStock = opStock;
                                    prodlObj.Particulars = Constants.StockMinusBySale + pi.InvoiceId.ToString();
                                    prodlObj.StockQty = 0;
                                    prodlObj.SoldQty = soldQty;
                                    prodlObj.TransferQty = 0;
                                    prodlObj.RetQty = 0;
                                    prodlObj.ClosingStock = opStock - soldQty;
                                    prodlObj.UserName = voucherObj.TransactionBy;
                                    _prodLedger.Add(prodlObj);


                                    double _newStock = _phst.CurrentStock - soldQty;
                                    _phst.CurrentStock = _newStock;

                                    _phStockLst.Add(_phst);


                                }

                            }
                        }

                        entities.PhInvoiceDetails.AddRange(_invDetailsList);
                        entities.SaveChanges();

                        entities.PhProductLedgers.AddRange(_prodLedger);
                        entities.SaveChanges();

                        // Stock Update
                        foreach (var item in _phStockLst)
                        {

                            entities.Database.ExecuteSqlCommand(@"Update PhStockInfoes Set CurrentStock = @p0 Where StckId=@p1", new SqlParameter("@p0", item.CurrentStock), new SqlParameter("@p1", item.StckId));

                        }

                        //End of Stock Update


                        if (voucherObj.IsIpdSale)
                        {

                            HospitalPatientInfo _pInfo = voucherObj.HospitalPatientInfo;

                            List<PhIPDSaleLedger> ipdLedgers = entities.PhIPDSaleLedgers.Where(x => x.AdmissionId == _pInfo.AdmissionId).ToList();

                            double ebalance = ipdLedgers.Sum(x => x.Credit - x.Debit);

                            ebalance = ebalance - voucherObj.SaleAmount;
                            //Save On Entry Payment Information
                            List<PhIPDSaleLedger> _ipdtransactionList = new List<PhIPDSaleLedger>();
                            PhIPDSaleLedger ipdLedger = new PhIPDSaleLedger();
                            ipdLedger.AdmissionId = _pInfo.AdmissionId;
                            ipdLedger.TranDate = voucherObj.TransactionDateTime;
                            ipdLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            ipdLedger.Particulars = "Product Cost. Invoice No: " + pi.InvoiceId.ToString();
                            ipdLedger.Debit = voucherObj.SaleAmount;
                            ipdLedger.Credit = 0;
                            ipdLedger.Balance = ebalance;
                            ipdLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                            ipdLedger.OperateBy = voucherObj.TransactionBy;
                            ipdLedger.PCId = 0;
                            ipdLedger.TransactionNo = "";
                            _ipdtransactionList.Add(ipdLedger);


                            if (voucherObj.DiscountAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.DiscountAmount;
                                ipdLedger = new PhIPDSaleLedger();
                                ipdLedger.AdmissionId = _pInfo.AdmissionId;
                                ipdLedger.TranDate = voucherObj.TransactionDateTime;
                                ipdLedger.Particulars = "Discount";
                                ipdLedger.Debit = 0;
                                ipdLedger.Credit = voucherObj.DiscountAmount;
                                ipdLedger.Balance = ebalance;
                                ipdLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                                ipdLedger.OperateBy = voucherObj.TransactionBy;
                                ipdLedger.PCId = 0;
                                ipdLedger.TransactionNo = "";
                                _ipdtransactionList.Add(ipdLedger);
                            }

                            if (voucherObj.CashPaidAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.CashPaidAmount;
                                ipdLedger = new PhIPDSaleLedger();
                                ipdLedger.AdmissionId = _pInfo.AdmissionId;
                                ipdLedger.TranDate = voucherObj.TransactionDateTime;
                                ipdLedger.Particulars = "Paid as Recive Tk. " + voucherObj.CashReceiveAmount.ToString() + "Change Tk. " + voucherObj.ChangeCashAmount.ToString();
                                ipdLedger.Debit = 0;
                                ipdLedger.Credit = voucherObj.CashPaidAmount;
                                ipdLedger.Balance = ebalance;
                                ipdLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                                ipdLedger.OperateBy = voucherObj.TransactionBy;
                                ipdLedger.PCId = voucherObj.CashPayChannelId;
                                ipdLedger.TransactionNo = "";
                                _ipdtransactionList.Add(ipdLedger);
                            }

                            if (voucherObj.CardOrMobilePaidAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.CardOrMobilePaidAmount;
                                ipdLedger = new PhIPDSaleLedger();
                                ipdLedger.AdmissionId = _pInfo.AdmissionId;
                                ipdLedger.TranDate = voucherObj.TransactionDateTime;
                                ipdLedger.Particulars = "Card/Mobile Payment " + voucherObj.CardOrMobilePaidAmount.ToString();
                                ipdLedger.Debit = 0;
                                ipdLedger.Credit = voucherObj.CardOrMobilePaidAmount;
                                ipdLedger.Balance = ebalance;
                                ipdLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                                ipdLedger.OperateBy = voucherObj.TransactionBy;
                                ipdLedger.PCId = voucherObj.PCId;
                                ipdLedger.TransactionNo = voucherObj.TransactionNo;
                                _ipdtransactionList.Add(ipdLedger);
                            }

                            if (voucherObj.CardOrMobileServiceCharge > 0) // CardOrMobileServiceCharge does not affect balance
                            {

                                //ebalance = ebalance + voucherObj.CardOrMobilePaidAmount;
                                ipdLedger = new PhIPDSaleLedger();
                                ipdLedger.AdmissionId = _pInfo.AdmissionId;
                                ipdLedger.TranDate = voucherObj.TransactionDateTime;
                                ipdLedger.Particulars = "Service Charge Tk. " + voucherObj.CardOrMobileServiceCharge.ToString();
                                ipdLedger.Debit = 0;
                                ipdLedger.Credit = voucherObj.CardOrMobileServiceCharge;
                                ipdLedger.Balance = ebalance;  // CardOrMobileServiceCharge does not affect balance
                                ipdLedger.TransactionType = TransactionTypeEnum.CardOrMobileServiceCharge.ToString();
                                ipdLedger.OperateBy = voucherObj.TransactionBy;
                                ipdLedger.PCId = voucherObj.PCId;
                                ipdLedger.TransactionNo = voucherObj.TransactionNo;
                                _ipdtransactionList.Add(ipdLedger);
                            }

                            if (_ipdtransactionList.Count > 0)
                            {
                                entities.PhIPDSaleLedgers.AddRange(_ipdtransactionList);
                                entities.SaveChanges();
                            }
                        }


                        if (voucherObj.IsStaffSale)
                        {
                            PhMemberInfo _member = voucherObj.PhMemberInfo;

                            List<PhMemberLedger> ipdLedgers = entities.PhMemberLedgers.Where(x => x.MemberId == voucherObj.PhMemberInfo.MemberId).ToList();
                            double ebalance = ipdLedgers.Sum(x => x.Credit - x.Debit);


                            ebalance = ebalance - voucherObj.SaleAmount;
                            //Save On Entry Payment Information
                            List<PhMemberLedger> _employeetransactionList = new List<PhMemberLedger>();
                            PhMemberLedger eLedger = new PhMemberLedger();
                            eLedger.MemberId = _member.MemberId;
                            eLedger.TranDate = voucherObj.TransactionDateTime;
                            eLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            eLedger.Particulars = "Product Cost. Invoice No: " + pi.InvoiceId.ToString();
                            eLedger.Debit = voucherObj.SaleAmount;
                            eLedger.Credit = 0;
                            eLedger.Balance = ebalance;
                            eLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                            eLedger.OperateBy = voucherObj.TransactionBy;
                            eLedger.PCId = 0;
                            eLedger.TransactionNo = "";
                            _employeetransactionList.Add(eLedger);


                            if (voucherObj.DiscountAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.DiscountAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = voucherObj.TransactionDateTime;
                                eLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                                eLedger.Particulars = "Discount";
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.DiscountAmount;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = 0;
                                eLedger.TransactionNo = "";
                                _employeetransactionList.Add(eLedger);
                            }

                            if (voucherObj.CashPaidAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.CashPaidAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = DateTime.Now;
                                eLedger.Particulars = "Paid as Recive Tk. " + voucherObj.CashPaidAmount.ToString();
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.CashPaidAmount;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = voucherObj.CashPayChannelId;
                                eLedger.TransactionNo = "";
                                _employeetransactionList.Add(eLedger);
                            }

                            if (voucherObj.CardOrMobilePaidAmount > 0)
                            {

                                ebalance = ebalance + voucherObj.CardOrMobilePaidAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = DateTime.Now;
                                eLedger.Particulars = "Paid as Recive Tk. " + voucherObj.CardOrMobilePaidAmount.ToString();
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.CardOrMobilePaidAmount;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = voucherObj.PCId;
                                eLedger.TransactionNo = voucherObj.TransactionNo;
                                _employeetransactionList.Add(eLedger);
                            }

                            if (voucherObj.CardOrMobileServiceCharge > 0)
                            {

                                //ebalance = ebalance + voucherObj.CardOrMobilePaidAmount;
                                eLedger = new PhMemberLedger();
                                eLedger.MemberId = _member.MemberId;
                                eLedger.TranDate = DateTime.Now;
                                eLedger.Particulars = "Service Charege Tk. " + voucherObj.CardOrMobileServiceCharge.ToString();
                                eLedger.Debit = 0;
                                eLedger.Credit = voucherObj.CardOrMobileServiceCharge;
                                eLedger.Balance = ebalance;
                                eLedger.TransactionType = TransactionTypeEnum.CardOrMobileServiceCharge.ToString();
                                eLedger.OperateBy = voucherObj.TransactionBy;
                                eLedger.PCId = voucherObj.PCId;
                                eLedger.TransactionNo = voucherObj.TransactionNo;
                                _employeetransactionList.Add(eLedger);
                            }

                            if (_employeetransactionList.Count > 0)
                            {
                                entities.PhMemberLedgers.AddRange(_employeetransactionList);
                                entities.SaveChanges();
                            }

                        }


                        double balance = 0;
                        balance = 0 - voucherObj.SaleAmount;
                        //Save On Entry Payment Information
                        List<PhSaleLedger> transactionList = new List<PhSaleLedger>();
                        PhSaleLedger pLedger = new PhSaleLedger();
                        pLedger.InvoiceId = pi.InvoiceId;
                        pLedger.TranDate = voucherObj.TransactionDateTime;
                        pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                        pLedger.Particulars = "Product/s Price";
                        pLedger.Debit = voucherObj.SaleAmount;
                        pLedger.Credit = 0;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                        pLedger.OperateBy = voucherObj.TransactionBy;
                        pLedger.PCId = 0;
                        pLedger.TransactionNo = "";
                        transactionList.Add(pLedger);


                        if (voucherObj.DiscountAmount > 0)
                        {

                            balance = balance + voucherObj.DiscountAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = DateTime.Now;
                            pLedger.Particulars = "Discount";
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.DiscountAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = 0;
                            pLedger.TransactionNo = "";
                            transactionList.Add(pLedger);
                        }


                        if (voucherObj.CashPaidAmount > 0)
                        {

                            balance = balance + voucherObj.CashPaidAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.Particulars = "Paid as Recive Tk. " + voucherObj.CashPaidAmount.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CashPaidAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.CashPayChannelId;
                            pLedger.TransactionNo = "";
                            transactionList.Add(pLedger);

                        }

                        if (voucherObj.CardOrMobilePaidAmount > 0)
                        {

                            balance = balance + voucherObj.CardOrMobilePaidAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.Particulars = "Card/Mobile Tk. " + voucherObj.CardOrMobilePaidAmount.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CardOrMobilePaidAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.PCId;
                            pLedger.TransactionNo = voucherObj.TransactionNo;
                            transactionList.Add(pLedger);

                        }

                        if (voucherObj.CardOrMobileServiceCharge > 0)
                        {

                            //balance = balance + voucherObj.CardOrMobilePaidAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = pi.InvoiceId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.Particulars = "Service Charge Tk. " + voucherObj.CardOrMobileServiceCharge.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CardOrMobileServiceCharge;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.CardOrMobileServiceCharge.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.PCId;
                            pLedger.TransactionNo = voucherObj.TransactionNo;
                            transactionList.Add(pLedger);

                        }

                        if (transactionList.Count > 0)
                        {

                            entities.PhSaleLedgers.AddRange(transactionList);
                            entities.SaveChanges();
                        }

                        if (voucherObj.IsIpdSale)
                        {
                            if (voucherObj.hpMedicineRequisition != null)
                            {
                                if (voucherObj.IPDRequisitionDeliveryStatus == RequisitionStatusEnum.Served.ToString())
                                {
                                    List<HpMedicineRequisitionDetail> _reqList = entities.HpMedicineRequisitionDetails.Where(x => x.RequisitionId == voucherObj.hpMedicineRequisition.RequisitionId).ToList();
                                    List<PhInvoiceDetail> _invItemList = entities.PhInvoiceDetails.SqlQuery("Select * from PhInvoiceDetails Where InvoiceId=(Select Max(InvoiceId) from PhInvoices Where RequisitionNo={0})", voucherObj.hpMedicineRequisition.RequisitionId).ToList();

                                    foreach (HpMedicineRequisitionDetail _reqItem in _reqList)
                                    {

                                        PhInvoiceDetail _invdetail = _invItemList.Where(x => x.ProductId == _reqItem.ProductId).FirstOrDefault();
                                        if (_invdetail != null)
                                        {
                                            _reqItem.DeliveredQty = _invdetail.Qty;
                                            if (_reqItem.DeliveredQty == _invdetail.Qty)
                                            {
                                                _reqItem.Status = RequisitionStatusEnum.Served.ToString();
                                            }
                                            else
                                            {
                                                RequisitionStatusEnum.PartiallyServed.ToString();
                                            }



                                            entities.Entry(_reqItem).State = EntityState.Modified;
                                            entities.SaveChanges();
                                        }
                                    }

                                }
                                else if (voucherObj.IPDRequisitionDeliveryStatus == RequisitionStatusEnum.PartiallyServed.ToString())
                                {
                                    List<PhInvoiceDetail> _inVDetail = entities.PhInvoiceDetails.SqlQuery("Select * from PhInvoiceDetails Where InvoiceId=(Select Max(InvoiceId) from PhInvoices Where RequisitionNo={0})", voucherObj.hpMedicineRequisition.RequisitionId).ToList();

                                    List<PhInvoiceDetail> _invdL = _inVDetail.GroupBy(x => x.ProductId).Select(q => q.First()).ToList();

                                    foreach (PhInvoiceDetail _deliverItem in _invdL)
                                    {
                                        HpMedicineRequisitionDetail _mreqd = entities.HpMedicineRequisitionDetails.Where(x => x.RequisitionId == voucherObj.hpMedicineRequisition.RequisitionId && x.ProductId == _deliverItem.ProductId).FirstOrDefault();
                                        _mreqd.DeliveredQty = _mreqd.Qty;
                                        //if (_mreqd.Qty == _deliverItem.Qty)
                                        //{
                                        _mreqd.Status = RequisitionStatusEnum.Served.ToString();
                                        //}else
                                        //{
                                        //    _mreqd.Status = RequisitionStatusEnum.PartiallyServed.ToString();
                                        //}
                                        entities.Entry(_mreqd).State = EntityState.Modified;
                                        entities.SaveChanges();
                                    }
                                }

                                voucherObj.hpMedicineRequisition.Status = voucherObj.IPDRequisitionDeliveryStatus;

                                entities.Entry(voucherObj.hpMedicineRequisition).State = EntityState.Modified;
                                entities.SaveChanges();

                            }
                        }

                        if (voucherObj.InvoiceTypeTagVal == 3 || voucherObj.InvoiceTypeTagVal == 9)
                        {

                            HpMedicineRequisition _Mreq = voucherObj.hpMedicineRequisition;
                            if (_Mreq != null)
                            {
                                _Mreq.Status = RequisitionStatusEnum.Served.ToString();
                                entities.Entry(_Mreq).State = EntityState.Modified;
                                entities.SaveChanges();
                            }


                        }

                        // Sale Voucher

                        //Pick Sale Account

                        if (IsIntegratedAccountInAction)
                        {

                            int _saleAccountId = 0;

                            if (voucherObj.IsIpdSale)
                            {
                                _saleAccountId = 100;
                            }
                            else
                            {
                                _saleAccountId = 101;
                            }

                            string _voucherType = "Credit";
                            if (voucherObj.CashPaidAmount == 0)  // if Full Credit then Journal Else Credit Voucher
                            {
                                _voucherType = "Journal";
                            }

                            Voucher _saleVoucher = new Voucher();
                            _saleVoucher.CompanyId = 1;
                            _saleVoucher.VoucherDate = voucherObj.TransactionDateTime;
                            _saleVoucher.VTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            _saleVoucher.VoucherId = "";
                            _saleVoucher.VoucherType = _voucherType;
                            _saleVoucher.Description = "Sale Invoice " + pi.InvoiceId.ToString();
                            _saleVoucher.CreateUser = voucherObj.TransactionBy;

                            entities.Vouchers.Add(_saleVoucher);
                            entities.SaveChanges();


                            List<VoucherDetail> vdList = new List<VoucherDetail>();

                            VoucherDetail detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = _saleVoucher.VMId;
                            detailsVoucher.DRCR = "C";
                            detailsVoucher.Amount = voucherObj.SaleAmount;
                            detailsVoucher.AccId = _saleAccountId;
                            detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                            vdList.Add(detailsVoucher);
                            if (voucherObj.DueAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.DueAmount;
                                detailsVoucher.AccId = voucherObj.ReceivableAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            if (voucherObj.CashPaidAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.CashPaidAmount;
                                detailsVoucher.AccId = voucherObj.CashAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            if (voucherObj.DiscountAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.DiscountAmount;
                                detailsVoucher.AccId = voucherObj.DiscountAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            entities.VoucherDetails.AddRange(vdList);
                            entities.SaveChanges();

                            // Inventory journal

                            Voucher _InventoryVoucher = new Voucher();
                            _InventoryVoucher.CompanyId = 1;
                            _InventoryVoucher.VoucherDate = voucherObj.TransactionDateTime;
                            _InventoryVoucher.VTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            _InventoryVoucher.VoucherId = "";
                            _InventoryVoucher.VoucherType = "Journal";
                            _InventoryVoucher.Description = "Sale Invoice " + pi.InvoiceId.ToString();
                            _InventoryVoucher.CreateUser = voucherObj.TransactionBy;

                            entities.Vouchers.Add(_InventoryVoucher);
                            entities.SaveChanges();

                            vdList = new List<VoucherDetail>();

                            VoucherDetail vdetail = new VoucherDetail();
                            vdetail.VMId = _InventoryVoucher.VMId;
                            vdetail.DRCR = "C";
                            vdetail.Amount = voucherObj.CostAmount;
                            vdetail.AccId = voucherObj.StockAccId;
                            vdetail.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                            vdList.Add(vdetail);

                            vdetail = new VoucherDetail();
                            vdetail.VMId = _InventoryVoucher.VMId;
                            vdetail.DRCR = "D";
                            vdetail.Amount = voucherObj.CostAmount;
                            vdetail.AccId = voucherObj.StockExpAccId;
                            vdetail.reamrks = "Sale Invoice " + pi.InvoiceId.ToString();
                            vdList.Add(vdetail);

                            entities.VoucherDetails.AddRange(vdList);
                            entities.SaveChanges();

                        }

                        scope.Commit();

                        return await Task.FromResult(pi);

                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                        return await Task.FromResult(new PhInvoice() { InvoiceId = 0 });
                    }
                }

            }
        }

        public DataSet GetOPDCustomerProductDetails(DateTime dtfrm, DateTime dtto, int memberId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT  dbo.PhInvoices.InvoiceId, dbo.PhInvoices.BillNo, dbo.PhInvoices.CustomerID,m.Name, dbo.PhInvoiceDetails.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhInvoiceDetails.Qty, dbo.PhInvoiceDetails.SaleRate, 
                                    dbo.PhInvoiceDetails.TotalPrice, dbo.PhInvoices.Invdate, dbo.PhInvoices.OPDCustomerName
                                    FROM  dbo.PhInvoices  INNER JOIN
                                    dbo.PhInvoiceDetails ON dbo.PhInvoices.InvoiceId = dbo.PhInvoiceDetails.InvoiceId INNER JOIN
                                    dbo.PhProductInfoes ON dbo.PhInvoiceDetails.ProductId = dbo.PhProductInfoes.ProductId INNER JOIN
						            PhMemberInfoes m on dbo.PhInvoices.CustomerID = m.MemberId
						            Where dbo.PhInvoices.Invdate between '{0}' and '{1}' and dbo.PhInvoices.CustomerID={2}", dtfrm, dtto, memberId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtOPDMedicineDetailByCustomer");
                return dsReports;
            }
        }

        public void UpdatePhtemIPDReturnLadger(PhTemIPDReturnLadger _tempLedger)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_tempLedger).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public PhTemIPDReturnLadger GetTempIPDLedger(long returnIndentId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhTemIPDReturnLadgers.Where(x => x.RetIndentId == returnIndentId).FirstOrDefault();

            }
        }

        public void SavetempIpdReturnLedger(PhTemIPDReturnLadger obj)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhTemIPDReturnLadgers.Add(obj);
                entities.SaveChanges();
            }
        }

        public DataSet GetStorePurchaseInvoice(long _ReceiveId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Select * from VWStoreReciveInvoice Where  ReceiveId= {0}", _ReceiveId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsPurchase = new DataSet();
                da.Fill(dsPurchase);

                con.Close();

                return dsPurchase;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PhIPDSaleLedger> GetIPDTransactions(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhIPDSaleLedgers.Where(x => x.AdmissionId == admissionId).ToList();

            }
        }

        public DataSet GetIndoorSaleLedger(long admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"select * from PhIpdSaleLedgers where AdmissionId={0} order by TranId", admissionId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtIndoorMedicineBillPatientLadger");
                return dsReports;
            }
        }

        public List<PhSaleLedger> GetCurrenPhInvoiceLedger(long invoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhSaleLedgers.Where(x => x.InvoiceId == invoiceId).ToList();

            }
        }

        public List<PhInvoice> GetPhInvoicesByAdmissionNo(long billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.AdmissionNo == billNo).ToList();

            }
        }

        public double GetPhIPDLedgerBalance(long admissionId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as Balance from PhIPDSaleLedgers Where AdmissionId={0}", admissionId);
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

        public DataSet GetPurchaseInvoicesBySupplier(DateTime dtpfrm, DateTime dtpto, int manufacturerId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Select * from VWPhPurchaseDetails Where RDate between '{0}' and '{1}'  and SupplerId= {2}", dtpfrm, dtpto, manufacturerId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsPurchase = new DataSet();
                da.Fill(dsPurchase);

                con.Close();

                return dsPurchase;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PhReceive GetPhReceiveById(long _ReceiveId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhReceives.Where(x => x.ReceiveId == _ReceiveId).FirstOrDefault();
            }
        }

        public DataSet GetPhDueCollection(DateTime _dtpfrm, DateTime _dtpto, string _user)
        {

            try
            {
                if (!String.IsNullOrEmpty(_user))
                {
                    sql = string.Format(@"SELECT dbo.PhMemberLedgers.TranId, dbo.PhMemberLedgers.Particulars, dbo.PhMemberLedgers.Debit, dbo.PhMemberLedgers.Credit, dbo.PhMemberLedgers.Balance, dbo.PhMemberLedgers.TranDate, 
                                      dbo.PhMemberLedgers.TransactionType, dbo.PhMemberLedgers.OperateBy, dbo.PhMemberLedgers.TransactionTime, dbo.PhMemberLedgers.MemberId, dbo.PhMemberInfoes.Name, dbo.PhMemberInfoes.MobileNo, 
                                      dbo.PhMemberInfoes.Address, dbo.PhMemberInfoes.MembershipCategory AS Category
                                      FROM dbo.PhMemberLedgers INNER JOIN
                                      dbo.PhMemberInfoes ON dbo.PhMemberLedgers.MemberId = dbo.PhMemberInfoes.MemberId
                                      WHERE (dbo.PhMemberLedgers.TransactionType = 'PhDueCollection') AND (dbo.PhMemberLedgers.OperateBy = '{0}') AND (dbo.PhMemberLedgers.TranDate BETWEEN '{1}' AND '{2}')", _user, _dtpfrm, _dtpto);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.PhMemberLedgers.TranId, dbo.PhMemberLedgers.Particulars, dbo.PhMemberLedgers.Debit, dbo.PhMemberLedgers.Credit, dbo.PhMemberLedgers.Balance, dbo.PhMemberLedgers.TranDate, 
                                      dbo.PhMemberLedgers.TransactionType, dbo.PhMemberLedgers.OperateBy, dbo.PhMemberLedgers.TransactionTime, dbo.PhMemberLedgers.MemberId, dbo.PhMemberInfoes.Name, dbo.PhMemberInfoes.MobileNo, 
                                      dbo.PhMemberInfoes.Address, dbo.PhMemberInfoes.MembershipCategory AS Category
                                      FROM dbo.PhMemberLedgers INNER JOIN
                                      dbo.PhMemberInfoes ON dbo.PhMemberLedgers.MemberId = dbo.PhMemberInfoes.MemberId
                                      WHERE (dbo.PhMemberLedgers.TransactionType = 'PhDueCollection') AND (dbo.PhMemberLedgers.TranDate BETWEEN '{0}' AND '{1}')", _dtpfrm, _dtpto);
                }

                con = new SqlConnection(Configuration.ConnectionString);
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataSet dsDCS = new DataSet();
                da.Fill(dsDCS);

                return dsDCS;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveCustomerLedgerTransactions(List<PhMemberLedger> _cLedgerList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhMemberLedgers.AddRange(_cLedgerList);
                entities.SaveChanges();
            }
        }

        public double GetPhMemberLedgerBalance(int _memberId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as Balance from PhMemberLedgers Where MemberId={0}", _memberId);
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

        public PhMemberInfo GetPhMemberByEmployeeId(long employeeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhMemberInfoes.Where(x => x.EmployeeId == employeeId).FirstOrDefault();

            }
        }

        public IList<PhMemberInfo> GetAllMember()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhMemberInfoes.ToList();

            }
        }

        public bool SavePhMemberInfo(PhMemberInfo _memInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhMemberInfoes.Add(_memInfo);
                entities.SaveChanges();
                return true;
            }
        }

        public DataSet GetPurchaseStatement(DateTime dtpfrm, DateTime dtpto, int outLetId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Select * from VWPhPurchaseDetails Where  RDate between '{0}' and '{1}' and  OutLetId={2}", dtpfrm, dtpto, outLetId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsPurchase = new DataSet();
                da.Fill(dsPurchase);

                con.Close();

                return dsPurchase;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetOrderStatement(DateTime dtpfrm, DateTime dtpto, int ManufacturerId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Select * from VWOrderDetails Where  RDate between '{0}' and '{1}' and  SupplerId={2}", dtpfrm, dtpto, ManufacturerId);

                da = new SqlDataAdapter(sql, con);
                DataSet dsPurchase = new DataSet();
                da.Fill(dsPurchase);

                con.Close();

                return dsPurchase;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<VMIndoorMedicineBill> GetIndoorMedicineBillOfUndertreatedPatientBySearchPrefix(string SearchString, string _type)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                if (_type.ToLower() == "cabin")
                {
                    sql = string.Format(@"SELECT dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, dbo.RegRecords.FullName, dbo.VWMedicineBillList.MedicineBill
                                      FROM  dbo.CabinInfoes INNER JOIN
                                      dbo.HpPatientAccomodationInfoes ON dbo.CabinInfoes.CabinId = dbo.HpPatientAccomodationInfoes.CabinId INNER JOIN
                                      dbo.HospitalPatientInfoes ON dbo.HpPatientAccomodationInfoes.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                      dbo.VWMedicineBillList ON dbo.HospitalPatientInfoes.AdmissionId = dbo.VWMedicineBillList.AdmissionId
                                      WHERE  (dbo.HospitalPatientInfoes.Status <> 'DisCharged') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed') AND (dbo.CabinInfoes.CabinNo like '%{0}%')", SearchString);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, dbo.RegRecords.FullName, dbo.VWMedicineBillList.MedicineBill
                                      FROM  dbo.CabinInfoes INNER JOIN
                                      dbo.HpPatientAccomodationInfoes ON dbo.CabinInfoes.CabinId = dbo.HpPatientAccomodationInfoes.CabinId INNER JOIN
                                      dbo.HospitalPatientInfoes ON dbo.HpPatientAccomodationInfoes.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                      dbo.VWMedicineBillList ON dbo.HospitalPatientInfoes.AdmissionId = dbo.VWMedicineBillList.AdmissionId
                                      WHERE  (dbo.HospitalPatientInfoes.Status <> 'DisCharged') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed') AND (dbo.RegRecords.FullName like '%{0}%')", SearchString);
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIndoorMedicineBill> billList = new List<VMIndoorMedicineBill>();


                billList = new List<VMIndoorMedicineBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetMedicineBillDataTableRow(dRow)))
                    );

                return billList;
            }
            catch (Exception ex)
            {
                return new List<VMIndoorMedicineBill>();
            }
            finally
            {
                con.Close();
            }
        }

        public void SavePhSaleLedger(PhSaleLedger pLedger)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhSaleLedgers.Add(pLedger);
                entities.SaveChanges();
            }
        }

        private VMIndoorMedicineBill GetMedicineBillDataTableRow(DataRow dr)
        {
            VMIndoorMedicineBill _imb = new VMIndoorMedicineBill();
            _imb.BillNo = Convert.ToInt64(dr["BillNo"]);
            _imb.FullName = dr["FullName"].ToString();
            _imb.CabinNo = dr["CabinNo"].ToString();
            _imb.MedicineBill = Convert.ToDouble(dr["MedicineBill"]);

            return _imb;
        }


        public DataSet GetIndoorMedicineBillDetailByPatient(long _AdmisssionId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, SUM(dbo.PhInvoices.TotalTK) AS MedicineBill, dbo.RegRecords.FullName, dbo.PhInvoices.InvoiceId, dbo.PhInvoiceDetails.ProductId, 
                                      dbo.PhProductInfoes.BrandName, dbo.PhInvoiceDetails.Qty, dbo.PhInvoiceDetails.SaleRate, dbo.PhInvoiceDetails.TotalPrice, dbo.PhProductInfoes.Unit
                                      FROM            dbo.HpMedicineRequisitions INNER JOIN
                                      dbo.PhInvoices ON dbo.HpMedicineRequisitions.RequisitionNo = dbo.PhInvoices.RequisitionNo INNER JOIN
                                      dbo.HospitalPatientInfoes ON dbo.HpMedicineRequisitions.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                      dbo.CabinInfoes ON dbo.HospitalPatientInfoes.WardOrCabinId = dbo.CabinInfoes.CabinId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                      dbo.PhInvoiceDetails ON dbo.PhInvoices.InvoiceId = dbo.PhInvoiceDetails.InvoiceId INNER JOIN
                                      dbo.PhProductInfoes ON dbo.PhInvoiceDetails.ProductId = dbo.PhProductInfoes.ProductId
                                      WHERE  (dbo.HospitalPatientInfoes.Status <> 'DisCharge')
                                      GROUP BY dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, dbo.RegRecords.FullName, dbo.PhInvoices.InvoiceId, dbo.PhInvoiceDetails.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhInvoiceDetails.Qty, 
                                       dbo.PhInvoiceDetails.SaleRate, dbo.PhInvoiceDetails.TotalPrice, dbo.PhProductInfoes.Unit");

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIndoorMedicineBill> billList = new List<VMIndoorMedicineBill>();




                billList = new List<VMIndoorMedicineBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetMedicineBillDataTableRow(dRow)))
                    );

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
