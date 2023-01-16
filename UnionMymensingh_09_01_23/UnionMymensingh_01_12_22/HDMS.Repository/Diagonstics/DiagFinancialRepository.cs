using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Diagnostic.VM;
using System.Data.SqlClient;
using System.Data;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.Common;
using System.Data.Entity;
using HDMS.Model.Enums;
using Models.Accounting;
using HDMS.Model.Diagnostic;

namespace HDMS.Repository.Diagonstics
{
    public class DiagFinancialRepository
    {
        string sql = string.Empty;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public List<VWIndoorInvestigationBill> GetIndoorInvestigationBillOfUndertreatedPatient()
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, dbo.RegRecords.FullName, dbo.VWInvestigationBill.InvestigationBill
                                      FROM  dbo.CabinInfoes INNER JOIN
                                      dbo.HpPatientAccomodationInfoes ON dbo.CabinInfoes.CabinId = dbo.HpPatientAccomodationInfoes.CabinId INNER JOIN
                                      dbo.HospitalPatientInfoes ON dbo.HpPatientAccomodationInfoes.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                     dbo.VWInvestigationBill ON dbo.HospitalPatientInfoes.AdmissionId = dbo.VWInvestigationBill.AdmissionId
                                      WHERE  (dbo.HospitalPatientInfoes.Status <> 'DisCharged') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed')");

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWIndoorInvestigationBill> billList = new List<VWIndoorInvestigationBill>();


                billList = new List<VWIndoorInvestigationBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetInvestigationBillDataTableRow(dRow)))
                    );

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

        }

        public bool GetMediaDueByPatient(DateTime dateFrom, DateTime dateTo, int mediaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"
	                DECLARE @dtFrom date = '{0}';
	                DECLARE @dtTo date = '{1}';
	                DECLARE @mediaId int = {2};

	                 WITH cte1
	                AS (
		                SELECT p.PatientId
			                ,p.IsMediaPaid
			                ,rr.FullName
			                ,p.MediaId
		                FROM Patients p
		                INNER JOIN RegRecords rr ON rr.RegNo = p.RegNo
		                WHERE (p.EntryDate BETWEEN @dtFrom AND @dtTo)
			                AND (p.MediaId = @mediaId)
			                AND (p.IsMediaPaid = 'false')
		                )
	                , cte2
	                AS (
		                SELECT l.PatientId
			                ,sum(l.Credit) AS Discount
		                FROM PatientLedger l
		                WHERE l.TransactionType = 'DiscountOnRegularCollection'
		                GROUP BY l.PatientId
		                )
	                , cte3
	                AS (
		                SELECT l.PatientId
			                ,sum(l.Credit) AS Discount
		                FROM PatientLedger l
		                WHERE l.TransactionType = 'DiscountOnDueCollection'
		                GROUP BY l.PatientId
		                )

	                SELECT cte1.PatientId
		                ,cte1.FullName AS PatientName
		                ,isNull(cte2.Discount, 0) AS RegularDiscount
		                ,isNull(cte3.Discount, 0) AS DueDiscount
		                ,isNull(cte2.Discount, 0) + isNull(cte3.Discount, 0) AS TotalDiscount
	                FROM cte1
	                LEFT JOIN cte2 ON cte2.PatientId = cte1.PatientId
	                LEFT JOIN cte3 ON cte3.PatientId = cte1.PatientId
					LEFT JOIN PatientLedger as pl ON pl.PatientId = cte1.PatientId
					group by cte1.PatientId, cte1.FullName, cte2.Discount, cte3.Discount
					 Having (ISNULL(sum(pl.Debit - pl.Credit), 0)) != 0", dateFrom, dateTo, mediaId);

                var restul = entities.Database.SqlQuery<VMPatientWiseMediaPayment>(sql).ToList();

                if (restul.Count> 0) {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateMediaCommissionType(MediaCategoryReportTypeCommission mtc)
        {
           using(DBEntities entities = new DBEntities())
            {
                try
                {

                    entities.Entry(mtc).State = EntityState.Modified;
                    entities.SaveChanges();

                    return true;
                }
                catch(Exception ex)
                {
                    return false;

                }
            }
        }

        public List<VMMediaCategoryReportTypeCommission> GetAllMediaCommissionTypeWithReportId()
        {
            using(DBEntities entities = new DBEntities())
            {

                try {
                    List<VMMediaCategoryReportTypeCommission> rpt = entities.Database.SqlQuery<VMMediaCategoryReportTypeCommission>(@"SELECT mc.CategoryId
	,mc.CategoryName
	,mcrtc.Commission
	,mcrtc.CommissionPercent
	,IsPercent
	,mcrtc.ReportTypeId
	,rpt.Report_Type
    ,mcrtc.CategoryRepotTypeId
FROM MediaCategories AS mc
INNER JOIN MediaCategoryReportTypeCommissions AS mcrtc ON mcrtc.CategoryId = mc.CategoryId
INNER JOIN ReportTypes AS rpt ON rpt.ReportTypeId = mcrtc.ReportTypeId").ToList();

                    return rpt;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public List<VMPatientWiseMediaPayment> GetCustometPatientWiseMediaPayments(DateTime dtpFrom, DateTime dtpTo, long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"
	                DECLARE @dtFrom date = '{0}';
	                DECLARE @dtTo date = '{1}';
	                DECLARE @mediaId int = {2};

	                 WITH cte1
	                AS (
		                SELECT p.PatientId
			                ,p.IsMediaPaid
			                ,rr.FullName
			                ,p.MediaId
		                FROM Patients p
		                INNER JOIN RegRecords rr ON rr.RegNo = p.RegNo
		                WHERE (p.EntryDate BETWEEN @dtFrom AND @dtTo)
			                AND (p.PatientId = @mediaId)
			                AND (p.IsMediaPaid = 'false')
		                )
	                , cte2
	                AS (
		                SELECT l.PatientId
			                ,sum(l.Credit) AS Discount
		                FROM PatientLedger l
		                WHERE l.TransactionType = 'DiscountOnRegularCollection'
		                GROUP BY l.PatientId
		                )
	                , cte3
	                AS (
		                SELECT l.PatientId
			                ,sum(l.Credit) AS Discount
		                FROM PatientLedger l
		                WHERE l.TransactionType = 'DiscountOnDueCollection'
		                GROUP BY l.PatientId
		                )

	                SELECT cte1.PatientId
		                ,cte1.FullName AS PatientName
		                ,isNull(cte2.Discount, 0) AS RegularDiscount
		                ,isNull(cte3.Discount, 0) AS DueDiscount
		                ,isNull(cte2.Discount, 0) + isNull(cte3.Discount, 0) AS TotalDiscount
	                FROM cte1
	                LEFT JOIN cte2 ON cte2.PatientId = cte1.PatientId
	                LEFT JOIN cte3 ON cte3.PatientId = cte1.PatientId
					LEFT JOIN PatientLedger as pl ON pl.PatientId = cte1.PatientId
					group by cte1.PatientId, cte1.FullName, cte2.Discount, cte3.Discount
					-- Having (ISNULL(sum(pl.Debit - pl.Credit), 0)) = 0", dtpFrom, dtpTo, patientId);

                return entities.Database.SqlQuery<VMPatientWiseMediaPayment>(sql).ToList();
            }
        }

        public List<VMTestWiseMediaPayment> GetCustomTestWiseMediaPayment(DateTime dtpFrom, DateTime dtpTo, long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"
                    SELECT DISTINCT tc.TestId
	                    ,rr.FullName AS PatientName
	                    ,p.PatientId
	                    ,bm.Name
	                    ,mc.CategoryName
	                    ,mcrtc.Commission
	                    ,mcrtc.CommissionPercent
	                    ,tis.Rate
	                    ,(((tis.Rate * mcrtc.CommissionPercent) / 100) + ISNULL(mcrtc.Commission, 0)) AS MediaCommission
	                    ,mcrtc.IsPercent
	                    ,tis.Name AS TestName
                    FROM RegRecords AS rr
                    INNER JOIN Patients AS p ON p.RegNo = rr.RegNo
                    INNER JOIN BusinessMedias AS bm ON p.MediaId = bm.MediaId
                    INNER JOIN MediaCategories AS mc ON bm.CategoryId = mc.CategoryId
                    INNER JOIN MediaCategoryReportTypeCommissions AS mcrtc ON mcrtc.CategoryId = mc.CategoryId
                    INNER JOIN TestItems AS tis ON tis.ReportTypeId = mcrtc.ReportTypeId
                    INNER JOIN TestsCost AS tc ON tc.PatientId = p.PatientId
	                    AND tc.TestId = tis.TestId
                    INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
                    --INNER JOIN TestItems as tis2 ON tis2.TestId = tc.TestId
                    WHERE p.EntryDate BETWEEN '{0}'
		                    AND '{1}'
	                    AND p.IsMediaPaid = 0
	                    AND p.PatientId = {2}
	                    AND tc.Status <> 'Cancelled'
                    GROUP BY tc.TestId
	                    ,rr.FullName
	                    ,p.PatientId
	                    ,bm.Name
	                    ,mc.CategoryName
	                    ,mcrtc.Commission
	                    ,mcrtc.CommissionPercent
	                    ,tis.Rate
	                    ,mcrtc.IsPercent
	                    ,tis.Name
                ", dtpFrom, dtpTo, patientId);

                return entities.Database.SqlQuery<VMTestWiseMediaPayment>(sql).ToList();
            }
        }

        public List<ReportType> LoadAllReportType()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    List<ReportType> reports = entities.ReportTypes.ToList();
                    return reports;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public MediaLedger SaveMediaLedgersForPaidList(List<MediaLedger> mld)
        {
            using (DBEntities entities = new DBEntities())
            {

                try
                {

                    MediaLedger ml = entities.MediaLedgers.AddRange(mld).FirstOrDefault();
                    entities.SaveChanges();

                    return ml;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public bool SaveCategroyAndReprotTypeId(MediaCategoryReportTypeCommission mtc)
        {
           using(DBEntities entities = new DBEntities())
            {

                try
                {

                    MediaCategoryReportTypeCommission mediaCategoryReportTypeCommission =  entities.MediaCategoryReportTypeCommissions.Add(mtc);
                    entities.SaveChanges();

                    if (mediaCategoryReportTypeCommission != null) return true;

                    return false;


                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public List<MediaCategory> GetAllMediaCategory()
        {
            using(DBEntities entities = new DBEntities())
            {
                try
                {
                    List<MediaCategory> mediaCts = entities.MediaCategories.ToList();
                    return mediaCts;

                }catch(Exception ex)
                {
                    return null;
                }

            }
        }

        public MediaCategory SaveMediaCategory(string name)
        {
           using(DBEntities entities = new DBEntities())
            {
                try
                {
                    var result = new MediaCategory();
                    result.CategoryName = name;
                    MediaCategory mediaCategory = entities.MediaCategories.Add(result);
                    entities.SaveChanges();
                    return mediaCategory;
                } catch(Exception ex)
                {
                    return null;

                }

            }
        }

        public List<BusinessMedia> GetMediaNameByPatientEntry(DateTime dtpFrom, DateTime dtpTo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    sql = string.Format(@" 
                select distinct 
	                    bs.MediaId, 
	                    bs.Name, 
	                    bs.Address, 
	                    bs.ContactNo,  
	                    bs.MediaType,
                        bs.CategoryId
                    from 
	                    Patients as p 
                    inner join  
	                    BusinessMedias as bs  On p.MediaId = bs.MediaId 
                    --inner join PatientLedger as pl on p.PatientId = pl.PatientId
                    where p.IsMediaPaid = 0 and p.EntryDate between '{0}' and '{1}'
                    ", dtpFrom, dtpTo);

                    
                    
                    List<BusinessMedia> medias =  entities.Database.SqlQuery<BusinessMedia>(sql).ToList();
                    return medias;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<VMPatientWiseMediaPayment> GetPatientWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"
	                DECLARE @dtFrom date = '{0}';
	                DECLARE @dtTo date = '{1}';
	                DECLARE @mediaId int = {2};

	                 WITH cte1
	                AS (
		                SELECT p.PatientId
			                ,p.IsMediaPaid
			                ,rr.FullName
			                ,p.MediaId
		                FROM Patients p
		                INNER JOIN RegRecords rr ON rr.RegNo = p.RegNo
		                WHERE (p.EntryDate BETWEEN @dtFrom AND @dtTo)
			                AND (p.MediaId = @mediaId)
			                AND (p.IsMediaPaid = 'false')
		                )
	                , cte2
	                AS (
		                SELECT l.PatientId
			                ,sum(l.Credit) AS Discount
		                FROM PatientLedger l
		                WHERE l.TransactionType = 'DiscountOnRegularCollection'
		                GROUP BY l.PatientId
		                )
	                , cte3
	                AS (
		                SELECT l.PatientId
			                ,sum(l.Credit) AS Discount
		                FROM PatientLedger l
		                WHERE l.TransactionType = 'DiscountOnDueCollection'
		                GROUP BY l.PatientId
		                )
                    	 , cte4
	                AS (
		                SELECT l.PatientId
			                ,sum(l.Debit) AS DiscountAdjustment
		                FROM PatientLedger l
		                WHERE l.TransactionType = 'TestCancelledDiscountAdjustment'
		                GROUP BY l.PatientId
		                )

	                SELECT cte1.PatientId
		                ,cte1.FullName AS PatientName
		                ,isNull(cte2.Discount, 0) AS RegularDiscount
		                ,isNull(cte3.Discount, 0) AS DueDiscount
		                ,isNull(cte2.Discount, 0) + isNull(cte3.Discount, 0) - ISNULL(cte4.DiscountAdjustment, 0) AS TotalDiscount
	                FROM cte1
	                LEFT JOIN cte2 ON cte2.PatientId = cte1.PatientId
	                LEFT JOIN cte3 ON cte3.PatientId = cte1.PatientId
					LEFT JOIN PatientLedger as pl ON pl.PatientId = cte1.PatientId
                    left join Patients as ps On ps.PatientId = pl.PatientId
                    left join cte4  ON pl.PatientId = cte4.PatientId
					where isnull(ps.status, '') <> 'Cancelled' 
					group by cte1.PatientId, cte1.FullName, cte2.Discount, cte3.Discount , cte4.DiscountAdjustment
					-- Having (ISNULL(sum(pl.Debit - pl.Credit), 0)) = 0", dtFrom.Date, dtTo.Date, mediaId);

                return entities.Database.SqlQuery<VMPatientWiseMediaPayment>(sql).ToList();
            }
        }

        public List<VMTestWiseMediaPayment> GetTestWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"
                    SELECT DISTINCT tc.TestId
	                    ,rr.FullName AS PatientName
	                    ,p.PatientId
	                    ,bm.Name
	                    ,mc.CategoryName
	                    ,mcrtc.Commission
	                    ,mcrtc.CommissionPercent
	                    ,tis.Rate
	                    ,(((tis.Rate * mcrtc.CommissionPercent) / 100) + ISNULL(mcrtc.Commission, 0)) AS MediaCommission
	                    ,mcrtc.IsPercent
	                    ,tis.Name AS TestName
                    FROM RegRecords AS rr
                    INNER JOIN Patients AS p ON p.RegNo = rr.RegNo
                    INNER JOIN BusinessMedias AS bm ON p.MediaId = bm.MediaId
                    INNER JOIN MediaCategories AS mc ON bm.CategoryId = mc.CategoryId
                    INNER JOIN MediaCategoryReportTypeCommissions AS mcrtc ON mcrtc.CategoryId = mc.CategoryId
                    INNER JOIN TestItems AS tis ON tis.ReportTypeId = mcrtc.ReportTypeId
                    INNER JOIN TestsCost AS tc ON tc.PatientId = p.PatientId
	                    AND tc.TestId = tis.TestId
                    INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
                    --INNER JOIN TestItems as tis2 ON tis2.TestId = tc.TestId
                    WHERE p.EntryDate BETWEEN '{0}'
		                    AND '{1}'
	                    AND p.IsMediaPaid = 0
	                    AND bm.MediaId = {2}
	                    AND isNull(p.STATUS, '') <> 'Cancelled'
	                    AND tc.Status <> 'Cancelled'
                    GROUP BY tc.TestId
	                    ,rr.FullName
	                    ,p.PatientId
	                    ,bm.Name
	                    ,mc.CategoryName
	                    ,mcrtc.Commission
	                    ,mcrtc.CommissionPercent
	                    ,tis.Rate
	                    ,mcrtc.IsPercent
	                    ,tis.Name
                    ORDER BY p.PatientId ASC
                ", dtFrom.Date, dtTo.Date, mediaId);

                return entities.Database.SqlQuery<VMTestWiseMediaPayment>(sql).ToList();
            }
        }

        public List<BusinessMedia> GetAllMedias()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BusinessMedias.ToList();
            }
        }

        public async Task<Patient> SaveAndCommitNewSale(Patient patient, List<TestsCost> testsCost, VMDiagEndPointDataCapture voucherObj, bool isIntegratedAccountInAction)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {

                        entities.Patients.Add(patient);
                        entities.SaveChanges();

                        List<TestsCost> testLists = new List<TestsCost>();
                        foreach (var item in testsCost)
                        {
                            item.PatientId = patient.PatientId;

                            testLists.Add(item);
                        }


                        entities.TestsCosts.AddRange(testLists);
                        entities.SaveChanges();


                        if (!string.IsNullOrEmpty(voucherObj.discountCardNo))
                        {

                            DiscountCard _card = entities.DiscountCards.Where(x => x.CardNo == voucherObj.discountCardNo).FirstOrDefault();
                            _card.status = "Used";
                            _card.UsedDate = voucherObj.TransactionDateTime;

                            entities.Entry(_card).State = EntityState.Modified;
                            entities.SaveChanges();
                        }


                        double balance = 0;
                        double _testAmount = voucherObj.SaleAmount;

                        balance = 0 - _testAmount;
                        //Save On Entry Payment Information
                        List<PatientLedger> transactionList = new List<PatientLedger>();

                        PatientLedger pLedger = new PatientLedger();
                        pLedger.PatientId = patient.PatientId;
                        pLedger.TranDate = voucherObj.TransactionDateTime;
                        pLedger.Particulars = voucherObj.testsConducted;
                        pLedger.Debit = _testAmount;
                        pLedger.Credit = 0;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.TestCost.ToString();
                        pLedger.OperateBy = voucherObj.TransactionBy;
                        pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                        pLedger.TransactionTerminal = voucherObj.WorkStationId;
                        pLedger.PCId = 0;
                        pLedger.TransactionNo = "";

                        transactionList.Add(pLedger);

                        double discount = voucherObj.DiscountAmount;

                        if (discount > 0)
                        {
                            discount = voucherObj.DiscountAmount;
                            balance = balance + discount;
                            pLedger = new PatientLedger();
                            pLedger.PatientId = patient.PatientId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            pLedger.Particulars = "Discount";
                            pLedger.Debit = 0;
                            pLedger.Credit = discount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.DiscountOnRegularCollection.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.TransactionTerminal = voucherObj.WorkStationId;
                            pLedger.PCId = 0;
                            pLedger.TransactionNo = "";
                            pLedger.Remarks = voucherObj.CareOf;
                            transactionList.Add(pLedger);
                        }


                        double drDiscount = voucherObj.DrDiscountAmount;


                        if (drDiscount > 0)
                        {
                            discount = voucherObj.DrDiscountAmount;
                            balance = balance + drDiscount;
                            pLedger = new PatientLedger();
                            pLedger.PatientId = patient.PatientId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            pLedger.Particulars = "Doctor Discount";
                            pLedger.Debit = 0;
                            pLedger.Credit = drDiscount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.DrDiscountOnRegularCollection.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.TransactionTerminal = voucherObj.WorkStationId;
                            pLedger.PCId = 0;
                            pLedger.TransactionNo = "";
                            pLedger.Remarks = voucherObj.CareOf;
                            transactionList.Add(pLedger);
                        }



                        double cpaidTk = voucherObj.CashPaidAmount;

                        if (cpaidTk > 0)
                        {

                            balance = balance + cpaidTk;
                            pLedger = new PatientLedger();
                            pLedger.PatientId = patient.PatientId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            pLedger.Particulars = "Payment (Cash)";
                            pLedger.Debit = 0;
                            pLedger.Credit = cpaidTk;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.OnEntryPayment.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.TransactionTerminal = voucherObj.WorkStationId;
                            pLedger.PCId = voucherObj.CashPayChannelId;
                            pLedger.TransactionNo = "";
                            transactionList.Add(pLedger);
                        }

                        if (voucherObj.CardPayment > 0)
                        {

                            balance = balance + voucherObj.CardPayment;
                            pLedger = new PatientLedger();
                            pLedger.PatientId = patient.PatientId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            pLedger.Particulars = "Payment by card " + voucherObj.CardPayment.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CardPayment;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.PCId;
                            pLedger.TransactionNo = voucherObj.TransactionNo;
                            pLedger.TransactionTerminal = voucherObj.WorkStationId;
                            transactionList.Add(pLedger);
                        }

                        if (voucherObj.MobilePayment > 0)
                        {

                            balance = balance + voucherObj.MobilePayment;
                            pLedger = new PatientLedger();
                            pLedger.PatientId = patient.PatientId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            pLedger.Particulars = "Payment by mobile banking " + voucherObj.MobilePayment.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.MobilePayment;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyMobileBanking.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.PCId;
                            pLedger.TransactionNo = voucherObj.TransactionNo;
                            pLedger.TransactionTerminal = voucherObj.WorkStationId;
                            transactionList.Add(pLedger);
                        }

                        if (voucherObj.CardOrMobileServiceCharge > 0) // CardOrMobileServiceCharge does not affect balance
                        {

                            //ebalance = ebalance + voucherObj.CardOrMobilePaidAmount;
                            pLedger = new PatientLedger();
                            pLedger.PatientId = patient.PatientId;
                            pLedger.TranDate = voucherObj.TransactionDateTime;
                            pLedger.TransactionTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            pLedger.Particulars = "Service Charge Tk. " + voucherObj.CardOrMobileServiceCharge.ToString();
                            pLedger.Debit = 0;
                            pLedger.Credit = voucherObj.CardOrMobileServiceCharge;
                            pLedger.Balance = balance;  // CardOrMobileServiceCharge does not affect balance
                            pLedger.TransactionType = TransactionTypeEnum.CardOrMobileServiceCharge.ToString();
                            pLedger.OperateBy = voucherObj.TransactionBy;
                            pLedger.PCId = voucherObj.PCId;
                            pLedger.TransactionNo = voucherObj.TransactionNo;
                            pLedger.TransactionTerminal = voucherObj.WorkStationId;
                            transactionList.Add(pLedger);
                        }


                        if (transactionList.Count > 0)
                        {
                            entities.PatientLedgers.AddRange(transactionList);
                            entities.SaveChanges();
                        }


                        /*
                            int _saleAccountId = 0;
                            int _cashAccId = 0;
                            int _discountAccId = 0;
                            if (voucherObj.IsIpdSale)
                            {
                                _saleAccountId = voucherObj.IPDSaleAccountId;
                                _cashAccId = voucherObj.IPDCashAccId;
                                _discountAccId = voucherObj.IPDDiscountAccId;
                            }
                            else
                            {
                                _saleAccountId = voucherObj.OPDSaleAccountId;
                                _cashAccId = voucherObj.OPDCashAccId;
                                _discountAccId = voucherObj.OPDDiscountAccId;
                            }



                            Voucher _saleVoucher = new Voucher();
                            _saleVoucher.CompanyId = 1;
                            _saleVoucher.VoucherDate = voucherObj.TransactionDateTime;
                            _saleVoucher.VTime = voucherObj.TransactionDateTime.ToString("hh:mm tt");
                            _saleVoucher.VoucherId = "";
                            _saleVoucher.VoucherType = "Credit";
                            _saleVoucher.Description = "Sale Invoice " + patient.PatientId.ToString();
                            _saleVoucher.CreateUser = voucherObj.TransactionBy;

                            entities.Vouchers.Add(_saleVoucher);
                            entities.SaveChanges();


                            List<VoucherDetail> vdList = new List<VoucherDetail>();

                            VoucherDetail detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = _saleVoucher.VMId;
                            detailsVoucher.DRCR = "C";
                            detailsVoucher.Amount = voucherObj.SaleAmount;
                            detailsVoucher.AccId = _saleAccountId;
                            detailsVoucher.reamrks = "Sale Invoice " + patient.PatientId.ToString();
                            vdList.Add(detailsVoucher);
                            if (voucherObj.DueAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.DueAmount;
                                detailsVoucher.AccId = voucherObj.ReceivableAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + patient.BillNo.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            if (voucherObj.PaidAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.PaidAmount;
                                detailsVoucher.AccId = _cashAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + patient.BillNo.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            if (voucherObj.DiscountAmount > 0)
                            {
                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = _saleVoucher.VMId;
                                detailsVoucher.DRCR = "D";
                                detailsVoucher.Amount = voucherObj.DiscountAmount;
                                detailsVoucher.AccId = _discountAccId;
                                detailsVoucher.reamrks = "Sale Invoice " + patient.BillNo.ToString();
                                vdList.Add(detailsVoucher);
                            }

                            entities.VoucherDetails.AddRange(vdList);
                            entities.SaveChanges(); */

                        transaction.Commit();

                        return await Task.FromResult(patient);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return await Task.FromResult(new Patient() { PatientId = 0 });
                    }
                }
            }
        }

        public List<VWIndoorInvestigationBill> GetIndoorInvestigationBillOfUndertreatedPatientBySearchPrefix(string strSearch, string _type)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                if (_type.ToLower() == "cabin")
                {
                    sql = string.Format(@"SELECT dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, dbo.RegRecords.FullName, dbo.VWInvestigationBill.InvestigationBill
                                      FROM  dbo.CabinInfoes INNER JOIN
                                      dbo.HpPatientAccomodationInfoes ON dbo.CabinInfoes.CabinId = dbo.HpPatientAccomodationInfoes.CabinId INNER JOIN
                                      dbo.HospitalPatientInfoes ON dbo.HpPatientAccomodationInfoes.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                     dbo.VWInvestigationBill ON dbo.HospitalPatientInfoes.AdmissionId = dbo.VWInvestigationBill.AdmissionId
                                      WHERE  (dbo.HospitalPatientInfoes.Status <> 'DisCharged') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed') AND (dbo.CabinInfoes.CabinNo like '%{0}%')", strSearch);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo, dbo.CabinInfoes.CabinNo, dbo.RegRecords.FullName, dbo.VWInvestigationBill.InvestigationBill
                                      FROM  dbo.CabinInfoes INNER JOIN
                                      dbo.HpPatientAccomodationInfoes ON dbo.CabinInfoes.CabinId = dbo.HpPatientAccomodationInfoes.CabinId INNER JOIN
                                      dbo.HospitalPatientInfoes ON dbo.HpPatientAccomodationInfoes.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                     dbo.VWInvestigationBill ON dbo.HospitalPatientInfoes.AdmissionId = dbo.VWInvestigationBill.AdmissionId
                                      WHERE  (dbo.HospitalPatientInfoes.Status <> 'DisCharged') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed') AND (dbo.RegRecords.FullName like '%{0}%')", strSearch);
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VWIndoorInvestigationBill> billList = new List<VWIndoorInvestigationBill>();


                billList = new List<VWIndoorInvestigationBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetInvestigationBillDataTableRow(dRow)))
                    );

                return billList;
            }
            catch (Exception ex)
            {
                return new List<VWIndoorInvestigationBill>();
            }
            finally
            {
                con.Close();
            }
        }

        private VWIndoorInvestigationBill GetInvestigationBillDataTableRow(DataRow dr)
        {
            VWIndoorInvestigationBill _imb = new VWIndoorInvestigationBill();
            _imb.BillNo = Convert.ToInt64(dr["BillNo"]);
            _imb.FullName = dr["FullName"].ToString();
            _imb.CabinNo = dr["CabinNo"].ToString();
            _imb.InvestigationBill = Convert.ToDouble(dr["InvestigationBill"]);

            return _imb;
        }

        public DataSet GetInvestigationDetailsByPatientId(long _admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT  dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo AS HospitalBillNo, dbo.Patients.PatientId, dbo.Patients.BillNo AS DiagBillNo, dbo.Patients.ReportIdPrefix+Convert(varchar(50),dbo.Patients.ReportId) as ReportId, dbo.TestsCost.TestId, dbo.TestItems.Name, 
                         dbo.TestsCost.Qty, dbo.TestsCost.Cost, 
                        dbo.HospitalPatientInfoes.RegNo, dbo.RegRecords.FullName, dbo.RegRecords.Sex, 
                         CASE WHEN dbo.HospitalPatientInfoes.AgeYear <> '' THEN dbo.HospitalPatientInfoes.AgeYear + 'Y ' ELSE dbo.HospitalPatientInfoes.AgeYear END + CASE WHEN dbo.HospitalPatientInfoes.AgeMonth <> '' THEN dbo.HospitalPatientInfoes.AgeMonth
                          + 'M ' ELSE dbo.HospitalPatientInfoes.AgeMonth END + CASE WHEN dbo.HospitalPatientInfoes.AgeDay <> '' THEN dbo.HospitalPatientInfoes.AgeDay + 'D' ELSE dbo.HospitalPatientInfoes.AgeDay END AS Age, 
                         dbo.HospitalPatientInfoes.AddmissionDate, dbo.Doctor.Name AS AssignDoc, Doctor_1.Name AS RefdDoc, dbo.TestItems.TestCode, dbo.Patients.EntryDate, dbo.Patients.EntryTime
                         
                         FROM  dbo.Doctor INNER JOIN
                         dbo.HospitalPatientInfoes INNER JOIN
                         dbo.Patients ON dbo.HospitalPatientInfoes.AdmissionId = dbo.Patients.AdmissionNo INNER JOIN
                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                         dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo ON dbo.Doctor.DoctorId = dbo.HospitalPatientInfoes.AssignDoctorId INNER JOIN
                         dbo.Doctor AS Doctor_1 ON dbo.HospitalPatientInfoes.RefdDoctorId = Doctor_1.DoctorId
                                      Where dbo.HospitalPatientInfoes.AdmissionId={0} and (TestsCost.Status<>'Cancelled' OR TestsCost.Status is Null)", _admissionId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtIndoorInvestigationBillByPatient");
                return ds;
            }
        }
    }
}
