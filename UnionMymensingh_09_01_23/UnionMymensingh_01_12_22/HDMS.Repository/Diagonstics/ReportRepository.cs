using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.ViewModel;
using HDMS.Repository.ServiceObjects;
using Models.Accounting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using HDMS.Model.LIS;
using HDMS.Model.MiniAccount;

namespace HDMS.Repository.Diagonstics
{
    public class ReportRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlConnection con;

        public async Task<DataSet> GetCashMemo(long _pId)
        {

            return await Task.Run(() =>
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {


                    sql = string.Format(@"EXEC [spGetDiagCashMemo] {0}", _pId);

                    da = new SqlDataAdapter(sql, conn);

                    DataSet dsReports = new DataSet();
                    da.Fill(dsReports);

                    dsReports.DataSetName = "myDataset";
                    dsReports.Tables[0].TableName = "dtCashMemo"; //based on datatable name in .xsd
                    dsReports.Tables[1].TableName = "dtTransactionsBy";

                    return dsReports;
                }
            });



        }

        public DataSet GetAllDiagDeailySaleSummary(DateTime dtpFrom, DateTime dtpTo)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                
                    try
                {
                    sql =  string.Format($@"

SELECT count(TotalInvoice) AS TotalInvoice
	,UserName
	,sum(TotalBill) AS TotalBill
	,sum(Discount) AS Discount
	,sum(Dues) AS Dues
	,sum(Advance) AS Advance
	,sum(DueCollection) AS DueCollection
	,sum(TotalCollection) AS TotalCollection
FROM (
	SELECT count(p.PatientId) AS TotalInvoice
		,plg.OperateBy AS UserName
		,0 AS TotalBill
		,0 AS Discount
		,0 AS Dues
		,0 AS Advance
		,0 AS DueCollection
		,0 AS TotalCollection
	FROM Patients AS p
	INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
	WHERE plg.TransactionType = 'TestCost'
	GROUP BY plg.OperateBy
	
	UNION ALL
	
	SELECT 0 AS TotalInvoice
		,plg.OperateBy AS UserName
		,sum(plg.Debit) AS TotalBill
		,0 AS Discount
		,0 AS Dues
		,0 AS Advance
		,0 AS DueCollection
		,0 AS TotalCollection
	FROM Patients AS p
	INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
	WHERE plg.TransactionType = 'TestCost'
	GROUP BY plg.OperateBy
	
	UNION ALL
	
	SELECT 0 AS TotalInvoice
		,plg.OperateBy AS UserName
		,0 AS TotalBill
		,sum(plg.Credit) AS Discount
		,0 AS Dues
		,0 AS Advance
		,0 AS DueCollection
		,0 AS TotalCollection
	FROM Patients AS p
	INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
	WHERE plg.TransactionType = 'DiscountOnRegularCollection'
	GROUP BY plg.OperateBy
	
	UNION ALL
	
	SELECT 0 AS TotalInvoice
		,plg.OperateBy AS UserName
		,0 AS TotalBill
		,0 AS Discount
		,0 AS Dues
		,sum(plg.Credit) AS Advance
		,0 AS DueCollection
		,0 AS TotalCollection
	FROM Patients AS p
	INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
	WHERE plg.TransactionType = 'OnEntryPayment'
	GROUP BY plg.OperateBy
	
	UNION ALL
	
	SELECT 0 AS TotalInvoice
		,plg.OperateBy AS UserName
		,0 AS TotalBill
		,0 AS Discount
		,0 AS Dues
		,0 AS Advance
		,sum(plg.Credit) AS DueCollection
		,0 AS TotalCollection
	FROM Patients AS p
	INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
	WHERE plg.TransactionType = 'DueCollection'
	GROUP BY plg.OperateBy
	

	
	UNION ALL
	
	SELECT 0 AS TotalInvoice
		,plg.OperateBy AS UserName
		,0 AS TotalBill
		,0 AS Discount
		,(sum(plg.Debit) - (sum(plg.Credit))) AS Dues
		,0 AS Advance
		,0 AS DueCollection
		,0 AS TotalCollection
	FROM Patients AS p
	INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
	WHERE plg.TransactionType IN (
			'TestCost'
			,'OnEntryPayment'
			,'DueCollection'
			,'DiscountOnRegularCollection'
			)
	GROUP BY plg.OperateBy
		UNION ALL
	
	SELECT 0 AS TotalInvoice
		,plg.OperateBy AS UserName
		,0 AS TotalBill
		,0 AS Discount
		,0 AS Dues
		,0 AS Advance
		,0 AS DueCollection
		,sum(plg.Credit) AS TotalCollection
	FROM Patients AS p
	INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
	WHERE plg.TransactionType IN (
			'OnEntryPayment'
			,'DueCollection'
			)
	GROUP BY plg.OperateBy
	) AS t
INNER JOIN PatientLedger AS plg ON plg.OperateBy = t.UserName
WHERE plg.TranDate BETWEEN '{dtpFrom}'
		AND '{dtpTo}'
GROUP BY UserName
");
                    da = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    da.Fill(ds, "dtDaigDeailySummary");
                    return ds;

                   

                }catch(Exception ex)
                {
                    return new DataSet();
                }
            }
        }

        public List<PathologyReport> IsNotPaidConsultanPayment(DateTime dptFrom, DateTime dptTo, int doctorId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    sql = string.Format(@"
                    DECLARE @doctorId INT = {2};
                    SELECT *
                    FROM PathologyReports
                    WHERE (IsPaid = 0)
	                    AND (
		                    ReportDoctor = @doctorId
		                    OR @doctorId = 0
		                    )
	                    AND CONVERT(DATE, ModifiedDate) BETWEEN '{0}'
		                    AND '{1}'
                    ", dptFrom, dptTo, doctorId);

                    List<PathologyReport> pathologyReports = entities.PathologyReports.SqlQuery(sql).ToList();

                    return pathologyReports;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public DataSet GetUnpaidMediaStatement(DateTime fromdate, DateTime todate, int meidaId)
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                try
                {
    sql = string.Format($@"SELECT t.PatientName
	,t.PatientId
	,t.BusinessName
	,Sum(t.TotalSales) AS TotalSales
	,sum(t.MediaCommission) AS Commission
	,sum(t.discount) discount
	,sum(t.Paid) Paid
	,-- sum(t.Unpaid) Unpaid 
	CASE 
		WHEN (sum(t.MediaCommission) - sum(t.discount)) > 0
			THEN (sum(t.MediaCommission) - sum(t.discount))
		ELSE 0
		END AS Unpaid
FROM (
	SELECT rr.FullName AS PatientName
		,p.PatientId
		,bm.Name AS BusinessName
		,0 AS TotalSales
		,(((tis.Rate * mcrtc.CommissionPercent) / 100) + ISNULL(mcrtc.Commission, 0)) AS MediaCommission
		,0 AS 'discount'
		,0 AS 'Paid'
		,p.EntryDate
		,bm.MediaId
	--,0 as 'Unpaid'
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
	WHERE --p.EntryDate BETWEEN '{0}'
		--AND '{1}'
		p.IsMediaPaid = 0
		--  AND bm.MediaId = {2}
		AND isNull(p.STATUS, '') <> 'Cancelled'
		AND tc.STATUS <> 'Cancelled'
	GROUP BY rr.FullName
		,p.PatientId
		,bm.Name
		,mcrtc.CommissionPercent
		,mcrtc.Commission
		,tis.Rate
		,p.EntryDate
		,bm.MediaId
	-- ORDER BY p.PatientId ASC
	-- 


    UNION ALL


    SELECT rr.FullName AS PatientName
        , p.PatientId
        , bm.Name AS BusinessName
        , 0 AS TotalSales
        , 0 AS MediaCommission
        , sum(plg.Credit) AS 'discount'
        , 0 AS 'Paid'
        , p.EntryDate
        , bm.MediaId
    --, 0 as 'Unpaid'

    FROM RegRecords AS rr

    INNER JOIN Patients AS p ON p.RegNo = rr.RegNo

    INNER JOIN BusinessMedias AS bm ON p.MediaId = bm.MediaId

    INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
    --INNER JOIN TestItems as tis2 ON tis2.TestId = tc.TestId

    WHERE--p.EntryDate BETWEEN '{0}'
        --AND '{1}'

        p.IsMediaPaid = 0
        --  AND bm.MediaId = { 2}
                    AND isNull(p.STATUS, '') <> 'Cancelled'

        AND plg.TransactionType IN(

            'DiscountOnRegularCollection'
			,'DiscountOnDueCollection'
			)
	GROUP BY rr.FullName
		,p.PatientId
		,bm.Name
		,p.EntryDate
		,bm.MediaId

    UNION ALL

    SELECT rr.FullName AS PatientName
		,p.PatientId
		,bm.Name AS BusinessName
		,plg.Debit AS TotalSales
		,0 AS MediaCommission
        ,0 AS 'discount'
		,0 AS 'Paid'
		,p.EntryDate
		,bm.MediaId
    --,0 as 'Unpaid'

    FROM RegRecords AS rr

    INNER JOIN Patients AS p ON p.RegNo = rr.RegNo

    INNER JOIN BusinessMedias AS bm ON p.MediaId = bm.MediaId

    INNER JOIN PatientLedger AS plg ON p.PatientId = plg.PatientId
    --INNER JOIN TestItems as tis2 ON tis2.TestId = tc.TestId

    WHERE--p.EntryDate BETWEEN '{0}'
       --AND '{1}'

        p.IsMediaPaid = 0
        --  AND bm.MediaId = { 2}
                    AND isNull(p.STATUS, '') <> 'Cancelled'

        AND plg.TransactionType IN('TestCost')
	GROUP BY rr.FullName
		,p.PatientId
		,bm.Name
		,plg.Debit
		,p.EntryDate
		,bm.MediaId
	) AS t    WHERE t.MediaId = {meidaId}  AND t.EntryDate BETWEEN '{fromdate}' AND '{todate}'
GROUP BY t.BusinessName
	,t.PatientId
	,t.PatientName");
                    da = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    da.Fill(ds, "dtMediaUnpaidStatement");
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public DataSet GetMediaPaidAndUnpaidStatementwithMedia(DateTime fromdate, DateTime todate, int referralId)
        {
            
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {


                    sql = string.Format($@"EXEC [spMediaPaidAndUpaidLedgerStatementWithMedia] {referralId}, '{fromdate}', '{todate}'");

                    da = new SqlDataAdapter(sql, conn);

                    DataSet dsReports = new DataSet();
                    da.Fill(dsReports);

                    dsReports.DataSetName = "myDataset";
                    dsReports.Tables[0].TableName = "dtMediaUnpaidStatement"; //based on datatable name in .xsd
                    

                    return dsReports;
                }
            
        }

        public List<VMPathologistServiceFee> GetAllPathlogisServiceFeeWithPatientId(DateTime dptFrom, DateTime dptTo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var pathologist = entities.Database.SqlQuery<VMPathologistServiceFee>(@"EXEC  [dbo].[spGetPathologistServiceFeeByPatientId]  {0},{1}", dptFrom, dptTo).ToList();

                    return pathologist;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<SelectedTestItemsForPatient> GetTestListByPatientBillNo(long patientId)
        {
            try
            {

                using (DBEntities entities = new DBEntities())
                {



                    sql = string.Format(@"SELECT dbo.TestsCost.Id, dbo.TestsCost.PatientId, dbo.TestsCost.TestId, CASE WHEN dbo.TestItems.ReportTypeId=63 and dbo.TestsCost.Qty>1 THEN  dbo.TestItems.Name + '-' + CONVERT(nvarchar(50),dbo.TestsCost.Qty) + 'Pcs'  ELSE dbo.TestItems.Name  END AS TestName, dbo.TestItems.TestCode, TestItems.ReportTypeId, dbo.TestsCost.IsCancelApprove,dbo.TestsCost.Cost,dbo.TestsCost.DiscountInPercent,dbo.TestsCost.Discount, dbo.TestsCost.UserId, dbo.[User].LoginName as UserName, dbo.TestsCost.Status AS TestStatus
                                  FROM     dbo.TestItems INNER JOIN
                                   dbo.TestsCost ON dbo.TestItems.TestId = dbo.TestsCost.TestId INNER JOIN
                                 dbo.[User] ON dbo.TestsCost.UserId = dbo.[User].UserId
                                 WHERE  (dbo.TestsCost.PatientId = {0}  and dbo.TestsCost.Status<>'Cancelled')", patientId);

                    var result = entities.Database.SqlQuery<SelectedTestItemsForPatient>(sql).ToList();
                    return result;


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetRefundPatientWiseData(DateTime dtpFrom, DateTime dtpTo)
        {
            try
            {
                string constring = Configuration.ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {

                    sql = string.Format($@"
                        WITH cte1
AS (
	SELECT re.FullName AS PatientName
		,p.PatientId
		,p.CancelRemarks AS Remarks
		--,pl.Debit as Refund
		,tc.Cost AS Refund
		,tc.TestId
		,tis.Name AS TestName
		,pl.TranDate AS TranDate
	FROM Patients AS p
	INNER JOIN TestsCost AS tc ON tc.PatientId = p.PatientId
	INNER JOIN PatientLedger AS pl ON pl.PatientId = p.PatientId
	INNER JOIN RegRecords AS re ON re.RegNo = p.RegNo
	INNER JOIN TestItems AS tis ON tis.TestId = tc.TestId
	WHERE tc.STATUS = 'Cancelled'
		AND CONVERT(DATE, pl.TranDate) BETWEEN '{dtpFrom.Date}'
			AND '{dtpTo.Date}'
		AND pl.TransactionType = 'Refund'
	)
	,cteTotalCost
AS (
	SELECT re.FullName AS PatientName
		,p.PatientId
		,tc.TestId
		,pl.Debit AS TotalCost
	FROM Patients AS p
	INNER JOIN TestsCost AS tc ON tc.PatientId = p.PatientId
	INNER JOIN PatientLedger AS pl ON pl.PatientId = p.PatientId
	INNER JOIN RegRecords AS re ON re.RegNo = p.RegNo
	INNER JOIN TestItems AS tis ON tis.TestId = tc.TestId
	WHERE tc.STATUS = 'Cancelled'
		AND CONVERT(DATE, pl.TranDate) BETWEEN '{dtpFrom.Date}'
			AND '{dtpTo.Date}'
		AND pl.TransactionType = 'TestCost'
	)
	,cteDiscountOnReguler
AS (
	SELECT re.FullName AS PatientName
		,p.PatientId
		,tc.TestId
		,pl.Credit AS DiscountTk
	FROM Patients AS p
	INNER JOIN TestsCost AS tc ON tc.PatientId = p.PatientId
	INNER JOIN PatientLedger AS pl ON pl.PatientId = p.PatientId
	INNER JOIN RegRecords AS re ON re.RegNo = p.RegNo
	INNER JOIN TestItems AS tis ON tis.TestId = tc.TestId
	WHERE tc.STATUS = 'Cancelled'
		AND CONVERT(DATE, pl.TranDate) BETWEEN '{dtpFrom.Date}'
			AND '{dtpTo.Date}'
		AND pl.TransactionType = 'DiscountOnRegularCollection'
	)
	,cteDiscountOnDueCollection
AS (
	SELECT re.FullName AS PatientName
		,p.PatientId
		,tc.TestId
		,isnull(pl.Credit, 0) AS DiscountDue
	FROM Patients AS p
	INNER JOIN TestsCost AS tc ON tc.PatientId = p.PatientId
	INNER JOIN PatientLedger AS pl ON pl.PatientId = p.PatientId
	INNER JOIN RegRecords AS re ON re.RegNo = p.RegNo
	INNER JOIN TestItems AS tis ON tis.TestId = tc.TestId
	WHERE tc.STATUS = 'Cancelled'
		AND CONVERT(DATE, pl.TranDate) BETWEEN '{dtpFrom.Date}'
			AND '{dtpTo.Date}'
		AND pl.TransactionType = 'DiscountOnDueCollection'
	)
SELECT c1.PatientId
	,c1.PatientName
	,c1.Remarks
	,c1.Refund AS TestPercost
	,c1.TestId
	,c1.TestName
	,c1.TranDate
	,ctCost.TotalCost
	,(c1.Refund - CONVERT(NUMERIC(10, 3), ((isnull(ctDisOnRe.DiscountTk, 0) + ISNULL(ctDisDue.DiscountDue, 0)) / ctCost.TotalCost) * c1.Refund)) AS Refund
	,ctDisOnRe.DiscountTk
	,ISNULL(ctDisDue.DiscountDue, 0) AS DiscountDue
	,(CONVERT(NUMERIC(10, 3), ((isnull(ctDisOnRe.DiscountTk, 0) + ISNULL(ctDisDue.DiscountDue, 0)) / ctCost.TotalCost) * c1.Refund)) AS withoutDiscount
FROM cte1 c1
INNER JOIN cteTotalCost AS ctCost ON c1.PatientId = ctCost.PatientId
	AND c1.TestId = ctCost.TestId
LEFT JOIN cteDiscountOnReguler AS ctDisOnRe ON c1.PatientId = ctDisOnRe.PatientId
	AND c1.TestId = ctDisOnRe.TestId
LEFT JOIN cteDiscountOnDueCollection AS ctDisDue ON c1.PatientId = ctDisDue.PatientId
	AND c1.TestId = ctDisDue.TestId
                    ");


                    da = new SqlDataAdapter(sql, con);
                    ds = new DataSet();
                    da.Fill(ds, "dtMediaPaymentLadgerSummary");
                    return ds;


                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetMediaLeadgerSummery(int mediaId, DateTime dateFrom, DateTime dateTo)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {

                sql = string.Format(@"EXEC  [dbo].[SpMediaCommissionSummaryLedger]  {0},'{1}', '{2}'", mediaId, dateFrom, dateTo);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtMediaPaymentLadgerSummary");
                return ds;
            }
        }

        public DataSet GetHpDueList(DateTime dpt1, DateTime dpt2)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {

                sql = string.Format(@"EXEC  [dbo].[spGetHpDueList]  '{0}','{1}'", dpt1, dpt2);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDischargedBillStatement");
                return ds;
            }
        }

        public DataSet GetReferrelByMediaPatientWise(DateTime fromdate, DateTime todate, int _referralId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_Get_Referral_Payment] {0}, '{1}','{2}'", _referralId, fromdate, todate);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtReagentManagment");
                return dsReports;
            }
        }

        public DataSet GetDiagReagentUse(DateTime dafrm, DateTime dtto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SPGetReagentManagment_Summery] '{0}','{1}'", dafrm.Date, dtto.Date);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtReagentManagment");
                return dsReports;
            }
        }

        public List<VMPathologistServiceFee> GetSinglePalthlogistServiceFeeByPaitent(int consultantId, DateTime dtpFrom, DateTime dtpTo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var pathologist = entities.Database.SqlQuery<VMPathologistServiceFee>(@"EXEC  [dbo].[spGetPathologistServiceFeeByPatientId]  {0},{1}", dtpFrom, dtpTo).Where(x => x.RCId == consultantId).ToList();

                    return pathologist;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public CashBookDto GetCashBookSummary()
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                sql = string.Format(@"Select Sum(Convert(float,IsNUll(Credit,0))) CreditTotal,Sum(Convert(float,IsNUll(Debit,0))) DebitTotal,
                                     Sum(Convert(float, IsNUll(Credit, 0))) - Sum(Convert(float, IsNUll(Debit, 0))) CashBookTotal from CashBookReceiverWise");
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return GetCashBookDataTableRow(dt.Rows[0]);

            }
        }

        public DataSet GetPathologistServiceReportFeeWithConsultentId(int consultantUserId, DateTime dtpFrom, DateTime dtpTo)
        {


            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                try
                {
                    sql = string.Format(@"SELECT p.PatientId
	,r.FullName AS PatientName
	,rptCon.Name AS Consultant
	,con.ConsultentId
	,
	--  rptFee.Fee,
	-- pathRpt.ReportType,
	--  sum(con.Cost)Cost,
	con.Credit AS TotalFee
FROM ReportConsultants AS rptCon
INNER JOIN ReportFees AS rptFee ON rptCon.RCId = rptFee.RCId --inner join PathologyReports as pathRpt On rptFee.ReportTypeId =pathRpt.ReportType
INNER JOIN ConsultentLedgers AS con ON rptCon.RCId = con.ConsultentId
INNER JOIN Patients AS p ON p.PatientId = con.PatientId
INNER JOIN RegRecords AS r ON p.RegNo = r.RegNo
WHERE CONVERT(DATE, con.TranDate) BETWEEN '{0}'
		AND '{1}'
	AND con.ConsultentId = {2}
GROUP BY p.PatientId
	,r.FullName
	,con.ConsultentId
	,
	-- rptFee.Fee,
	-- pathRpt.ReportType,
	rptCon.Name
	,con.Credit", dtpFrom.Date, dtpTo.Date, consultantUserId);
                    da = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    da.Fill(ds, "dtPathologistServiceFee");
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public DataSet GetReferrelByDoctorPatientWise(DateTime fromdate, DateTime todate, int _referralId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"EXEC [dbo].[SP_Get_Doctor_Payment]  {0}, '{1}','{2}'", _referralId, fromdate, todate);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtReferralByDoctorPatientWise");
                return ds;
            }
        }

        public DataSet GetCashBookPhar(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBookPhar] '{0}','{1}','{2}','{3}',{4}", dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }
        }

        public void UpdatePathologyReportIsPaid(List<PathologyReport> pathologyReports)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach (PathologyReport _pnwrd in pathologyReports)
                {
                    entities.Entry(_pnwrd).State = EntityState.Modified;
                    entities.SaveChanges();
                }

            }
        }

        /* =================== Consulten Payment with Zerro Or Normal ========================= */
        public DataSet GetConsultentPaymentWithZerroOrNormal(DateTime dtpFrom, DateTime dtpTo, int rCId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                try
                {
                    sql = string.Format(@"
                        SELECT
                            PatientId
	                        ,PatientName
	                        ,Credit AS TotalFee
                        FROM ConsultentLedgers
                            WHERE ConsultentId = {2}
	                         AND CONVERT(DATE, TranDate) BETWEEN '{0}' AND '{1}'
	                         AND TransectionType != 'TransectionWithZerro'
                        ", dtpFrom.Date, dtpTo.Date, rCId);
                    da = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    da.Fill(ds, "dtPathologistServiceFee");
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }


        /* =================== Save Pathlogys Payment Details ========================= */
        public bool SavePathologistPaymentDetails(List<ConsultentLedger> consultent)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    IEnumerable<ConsultentLedger> consult = entities.ConsultentLedgers.AddRange(consultent);
                    entities.SaveChanges();

                    if (consult.ToList().Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public DataSet GetCashBookHos(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBookHos] '{0}','{1}','{2}','{3}',{4}", dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }
        }

        public bool SaveReportFees(List<ReportFee> reportFees)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    foreach (ReportFee item in reportFees)
                    {
                        if (item.RFId == 0)
                        {
                            entities.ReportFees.Add(item);
                            entities.SaveChanges();
                        }
                    }


                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public DataSet GetCashBookDiag(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBookDiag] '{0}','{1}','{2}','{3}',{4}", dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }
        }

        public DataSet GetReferrelContribution(DateTime fromdate, DateTime todate, int _referralId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [dbo].[sp_getReferralContribution]  '{0}', '{1}',{2}", fromdate, todate, _referralId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);


                return dsReports;
            }
        }

        // Load Single Report fee Test Id and Consultant Id 
        public ReportFee GetReportTestIdAndCoultantId(int reporttypeId, int consultanteId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    ReportFee sql = entities.ReportFees.Where(x => x.ReportTypeId == reporttypeId && x.RCId == consultanteId).FirstOrDefault();
                    return sql;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public DataSet GetSupplierPaymentList(int manufacturerId, DateTime from, DateTime to)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"EXEC spGetSupplierPaymentDetails  {0},'{1}','{2}'", manufacturerId, from.Date, to.Date);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);
                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtSupplierPayment";
                return dsReports;
            }
        }

        public DataSet GetMediaStatement(int mediaId, DateTime _dtpfrm, DateTime _dtpto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"EXEC [dbo].[SPGetMediaCommision] '{0}','{1}', {2}", _dtpfrm, _dtpto, mediaId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);


                return dsReports;
            }
        }

        private CashBookDto GetCashBookDataTableRow(DataRow dr)
        {
            CashBookDto _cashsum = new CashBookDto();
            if (dr["CreditTotal"] != DBNull.Value)
            {
                _cashsum.CreditTotal = Convert.ToDouble(dr["CreditTotal"]);
            }
            else
            {
                _cashsum.CreditTotal = 0;
            }
            if (dr["DebitTotal"] != DBNull.Value)
            {
                _cashsum.DebitTotal = Convert.ToDouble(dr["DebitTotal"]);
            }
            else
            {
                _cashsum.DebitTotal = 0;
            }

            if (dr["CashBookTotal"] != DBNull.Value)
            {
                _cashsum.CashBookTotal = Convert.ToDouble(dr["CashBookTotal"]);
            }
            else
            {
                _cashsum.CashBookTotal = 0;
            }



            return _cashsum;

        }

        public DataSet GetCashBookGroupByUser(DateTime dtfrm, DateTime dtto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [dbo].[spCashBookReceiverWise]  '{0}', '{1}','All'", dtfrm, dtto);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);


                return dsReports;
            }
        }


        public DataSet GetOpdConsultancy(DateTime _startDateTime, DateTime _endDateTime, int _consultantId, string _userName)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@" Exec dbo.sp_getOPDConsultancy '{0}','{1}',{2},'{3}'", _startDateTime, _endDateTime, _consultantId, _userName);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtOPDConsultancyStatement"; //based on datatable name in .xsd

                return dsReports;
            }
        }

        public DataSet GetCashBook(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBook] '{0}' , '{1}','{2}','{3}'", dateTime1, dateTime2, _CheckPaymentState, _userName);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }

        }

        public DataSet GetDiagMasterStatement(DateTime dtpfrm, DateTime dtpto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                da = new SqlDataAdapter();
                sql = string.Format(@"EXEC [dbo].[SP_Diag_Master_Income_Statement_ByEntrydate]  '{0}', '{1}','All','OPD'", dtpfrm, dtpto);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtDiagDetailsStatement");
                conn.Close();

                return ds;


            }
        }

        public DataSet GetMediaPaidListData(DateTime dtpFrom, DateTime dtpTo, int mediaId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                //                sql = string.Format(@" 
                //    select rr.FullName as PatientName,
                //  bs.Name as MediaName, 
                // p.PatientId,
                // ISNULL(sum(tis.MediaComm), 0) as MediaCommission,
                // ISNULL(sum(pledger.Debit),0) as TotalCost,
                //(select ISNULL(pl.Credit, 0) from PatientLedger as pl where pl.PatientId = pledger.PatientId and pl.TransactionType in ('DiscountOnRegularCollection','DiscountOnDueCollection') ) as Discount	

                //,(ISNULL(tis.MediaComm, 0) - (select ISNULL(sum(pl.Credit), 0) from PatientLedger as pl where pl.PatientId = pledger.PatientId and pl.TransactionType in ('DiscountOnRegularCollection','DiscountOnDueCollection') ) ) as Paid

                //	from 
                //	RegRecords as rr   
                //			 inner Join Patients as p ON rr.RegNo = p.RegNo
                //				inner join BusinessMedias as bs 
                //					ON bs.MediaId = p.MediaId
                //				inner Join PatientLedger as pledger ON p.PatientId = pledger.PatientId
                //				inner Join TestsCost as tcs  ON tcs.PatientId = p.PatientId
                //				inner Join TestItems as tis ON tcs.TestId = tis.TestId

                //					where p.IsMediaPaid = 1 and  p.MediaPaymentDate between '{0}' and '{1}'

                //					--and pledger.TransactionType in ('DiscountOnRegularCollection','DiscountOnDueCollection')

                //					group by rr.FullName, --pledger.PatientId,
                //					bs.Name, p.PatientId,--pledger.TransactionType,
                //					p.MediaPaymentDate, pledger.PatientId,tis.MediaComm

                //                 ", dtpFrom, dtpTo);


                sql = string.Format(@" exec [dbo].[spGetMediaPaidList] '{0}','{1}', {2}", dtpFrom, dtpTo, mediaId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtMediaPaymentPalidList");
                return ds;
            }

        }

        public List<PathReportValueComboType> GetReportValueComboTypes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathReportValueComboTypes.ToList();
            }
        }

        public DataSet GetOPDCashMemo(long _PId, string _serviceType)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [dbo].[spGetOPDCashMemo]  {0}, '{1}'", _PId, _serviceType);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtOPDCashMemo"; //based on datatable name in .xsd
                //dsReports.Tables[1].TableName = "dtTransactionsBy";

                return dsReports;
            }
        }

        public DataSet GetDiagDeptWisePatientStatement(DateTime dtpfrm, DateTime dtpto, string _userName, string _reportOPtion, int deptId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                da = new SqlDataAdapter();
                sql = string.Format(@"Exec [dbo].[SP_Diag_Sale_Statement_ByEntrydate_ByDept] '{0}','{1}','{2}','{3}',{4}", dtpfrm, dtpto, _userName, _reportOPtion, deptId);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtDiagPatientStatement");
                conn.Close();

                return ds;
            }
        }

        public async Task<DataSet> GetDetailConsultancyStatement(int consultantId, DateTime dtfrm, DateTime dtto)
        {
            return await Task.Run(() =>
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    da = new SqlDataAdapter();
                    sql = string.Format(@"Exec [dbo].[spGetConsultancyDetail] '{0}','{1}',{2}", dtfrm, dtto, consultantId);
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 900;
                    da.SelectCommand = cmd;
                    ds = new DataSet();

                    conn.Open();
                    da.Fill(ds, "dtConsultancyDetail");
                    conn.Close();

                    return ds;
                }
            });
        }

        public async Task<DataSet> GetDiagCollectionStatementDataSetAsync(DateTime dtpfrm, DateTime dtpto, string userName, string reportOPtion)
        {
            return await Task.Run(() =>
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    da = new SqlDataAdapter();
                    sql = string.Format(@"Exec [dbo].[SP_Diag_Income_statement] '{0}','{1}','{2}','{3}'", dtpfrm, dtpto, userName, reportOPtion);
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 900;
                    da.SelectCommand = cmd;
                    ds = new DataSet();

                    conn.Open();
                    da.Fill(ds, "dtDiagPatientStatement");
                    conn.Close();

                    return ds;
                }
            });
        }

        public DataSet GetLabTokenData(long _PatientId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"EXEC [spGetDiagLabToken] {0}", _PatientId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtCashMemo";


                return dsReports;
            }
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPrintedOrDeliveredReportsByBillNo(long billNo)
        {
            var _billNo = new SqlParameter("@BillNo", billNo);

            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMDiagPatientAndTestDetail>(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId, 
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where BillNo=@BillNo and dbo.TestItems.ReportTypeId<>63 and  dbo.TestsCost.Status<>'Cancelled' and dbo.TestsCost.ReportStatus in ('RP','RD')", _billNo).ToList();
            }
        }

        public DataTable GetTestGroupNameByMasterGroup(int groupId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"select * from [dbo].[TestGroups] t where t.MasterTestGroupId ={0} order by t.TestGroupId ", groupId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsDueList = new DataSet();
                da.Fill(dsDueList, "DTMasterTestGroupDailyStatement");
                return dsDueList.Tables[0];
            }
        }



        public DataSet GetOPDCollectionStatement(DateTime dtpfrm, DateTime dtpto, int _sgroupid, string _user, string _reportOPtion, int _doctorId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec [dbo].[SP_OPD_Income_statement] '{0}','{1}','{2}','{3}','{4}','{5}'", dtpfrm, dtpto, _sgroupid, _user, _reportOPtion, _doctorId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtDiagPatientStatement");
                return ds;
            }
        }
        public DataSet GetOPDProcedureCollectionStatement(DateTime dtpfrm, DateTime dtpto, string _procedure, string _reportOPtion)
        {
            if (_procedure == "")
                _procedure = "All";
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec [dbo].[spProcedureIncomeStatement] '{0}','{1}','{2}'", dtpfrm, dtpto, _procedure);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds);
                ds.Tables[0].TableName = "dtOPDPatientStatement";

                return ds;
            }
        }

        public double GetRefundByUser(DateTime dateTime1, LoginUser loggedinUser)
        {
            double _currentReceived = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                //string _sql = string.Format("Select Sum(Debit-Credit) as totalRefund from PatientLedger join Patients on PatientLedger.PatientId= Patients.PatientId  Where TranDate='{0}' and OperateBy='{1}' and TransactionType in ('Refund') and Patients.Status is Null", dateTime1.Date, loggedinUser.Name);
                string _sql = string.Format("Select Sum(Debit-Credit) as totalRefund from PatientLedger join Patients on PatientLedger.PatientId= Patients.PatientId  Where TranDate='{0}' and OperateBy='{1}' and TransactionType in ('Refund')", dateTime1.Date, loggedinUser.Name);
                using (SqlCommand cmd = new SqlCommand(_sql, con))
                {
                    con.Open();
                    var _amount = cmd.ExecuteScalar();
                    if (_amount != DBNull.Value)
                    {
                        _currentReceived = Convert.ToDouble(_amount);
                    }
                    con.Close();

                }
            }
            return _currentReceived;
        }

        public Task<DataSet> GetDiagPatientStatementDataSetAsync(DateTime dtpfrm, DateTime dtpto, string userName, string _reportOPtion)
        {
            return Task.Run(() =>
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    da = new SqlDataAdapter();
                    sql = string.Format(@"Exec [dbo].[SP_Diag_Income_Statement_ByEntrydate] '{0}','{1}','{2}','{3}'", dtpfrm, dtpto, userName, _reportOPtion);
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 900;
                    da.SelectCommand = cmd;
                    ds = new DataSet();

                    conn.Open();
                    da.Fill(ds, "dtDiagPatientStatement");
                    conn.Close();

                    return ds;
                }
            });
        }

        public DataSet GetReferredCaseByReferralDetail(DateTime fromdate, DateTime todate, int _referralId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec [dbo].[spReferredCaseDetail] '{0}','{1}',{2}", fromdate, todate, _referralId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtByReferralDetail");
                return ds;
            }
        }

        public IList<VMReportDefination> GetLISReportDetails(string _Id)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    var _patientId = new SqlParameter("@PatientId", _Id);
                    //sql = string.Format(@"SELECT * FROM dbo.VWInterfacingResultSysmax800  WHERE PatientIdNumeric = @PatientIdNumeric order by DetailReportOrder", _patientId);
                    if (Configuration.ORG_CODE == "2")
                    {
                        return entities.Database.SqlQuery<VMReportDefination>("SELECT * FROM dbo.VWInterfacingResultPentaDxNexus  WHERE PatientIdNumeric = @PatientId order by DetailReportOrder", _patientId).ToList();
                    }
                    else
                    {
                        return entities.Database.SqlQuery<VMReportDefination>("SELECT * FROM dbo.VWInterfacingResultSysmax800  WHERE PatientIdNumeric = @PatientId order by DetailReportOrder", _patientId).ToList();
                    }

                }
                catch (Exception ex)
                {
                    return new List<VMReportDefination>();
                }
            }
        }

        public string GetTotalTransactedPatient(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOPtion)
        {
            throw new NotImplementedException();
        }

        public DataSet GetTokenByPatientId(long _PatientId)
        {
            return null;
        }

        public List<PathologyReport> GetReportDoneListByPatientId(long patientId)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("select * from dbo.PathologyReports Where PatientId={0}", patientId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<PathologyReport> listReportDoneList = new List<PathologyReport>();

                listReportDoneList = new List<PathologyReport>(
                    (from dRow in dt.AsEnumerable()
                     select (GetPathologyReportDataRow(dRow)))
                    );

                return listReportDoneList;
            }
            catch
            {
                return null;
            }
        }

        public DataSet GetDiagToken(long _pId, string GroupName)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetToken {0},'{1}'", _pId, GroupName);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtToken");
                return dsReports;
            }
        }

        private PathologyReport GetPathologyReportDataRow(DataRow dr)
        {
            PathologyReport _pr = new PathologyReport();
            _pr.Id = Convert.ToInt64(dr["Id"]);
            _pr.PatientId = Convert.ToInt64(dr["PatientId"]);
            _pr.ReportDate = Convert.ToDateTime(dr["ReportDate"]);
            _pr.ReportDoctor = Convert.ToInt32(dr["ReportDoctor"]);
            _pr.ReportTechnologist = Convert.ToInt32(dr["ReportTechnologist"]);

            return _pr;
        }

        public DataSet GetDiscountList(DateTime dtpfrm, DateTime dtpto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[spGetDiagDiscountList] '{0}','{1}','All','All'", dtpfrm, dtpto);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtDiscountList");
                return dsReports;
            }
        }

        public DataSet GetReferredCaseByIPDOPD(int _doctorId, DateTime fromdate, DateTime todate, string entryType)
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"EXEC [dbo].[spGetReferralStatement] '{0}' , '{1}','{2}','{3}'", fromdate, todate, _doctorId, entryType);

                SqlCommand com = new SqlCommand(sql, conn);
                com.CommandTimeout = 0;
                da = new SqlDataAdapter(com);

                DataSet dsReferredcase = new DataSet();
                da.Fill(dsReferredcase, "dtRefdCaseByIPDOPD");
                return dsReferredcase;
            }


        }

        public DataSet GetPatientStatement(DateTime dtpfrm, DateTime dtpto, string userName, string _reportOPtion)
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                da = new SqlDataAdapter();
                sql = string.Format(@"Exec [dbo].[SP_Diag_Income_Statement_ByEntrydate] '{0}','{1}','{2}','{3}'", dtpfrm, dtpto, userName, _reportOPtion);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtDiagPatientStatement");
                conn.Close();

                return ds;
            }
        }

        public async Task<DataTable> GetPathologicalTestsByReportType(long _billNo, int reportTypeId)
        {

            return await Task.Run(() => ReturnPathologicalTestsByReportType(_billNo, reportTypeId));

        }

        private DataTable ReturnPathologicalTestsByReportType(long _billNo, int reportTypeId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.VWPathologicalTests.TestId, dbo.VWPathologicalTests.TestName,dbo.VWPathologicalTests.ReportStatus   
                                  FROM  VWPathologicalTests WHERE (dbo.VWPathologicalTests.TestStatus<>'Cancelled' and dbo.VWPathologicalTests.PatientId = {0} and ReportTypeId={1})", _billNo, reportTypeId);


                da = new SqlDataAdapter(sql, conn);

                DataTable dtchildc = new DataTable();
                da.Fill(dtchildc);

                return dtchildc;
            }
        }

        public List<VMLISOutput> GetLISReportByDate(DateTime _rdate)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    if (Configuration.ORG_CODE == "2")
                    {
                        return entities.Database.SqlQuery<VMLISOutput>
                     ("SELECT * FROM dbo.VWPentaDxNexusInterfacedResultInfo  WHERE InsertDate = @InsertDate order by PatientRecordId Desc",
                                           new SqlParameter("InsertDate", _rdate)).ToList();
                    }
                    else
                    {
                        return entities.Database.SqlQuery<VMLISOutput>
                       ("SELECT * FROM dbo.VWInterfacedResultInfo  WHERE InsertDate = @InsertDate order by PatientRecordId Desc",
                                             new SqlParameter("InsertDate", _rdate)).ToList();
                    }
                }
                catch (Exception ex)
                {
                    return new List<VMLISOutput>();
                }
            }
        }

        public DataSet GetIDPatientList(DateTime frm, DateTime to)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select RegNo,FullName,NationalId,MobileNo,DOB,MotherName,BloodGroup from RegRecords Where  RegDate>='{0}' and RegDate<='{1}' and IsRegisterd=1", frm.Date, to.Date);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtRegList");

                return ds;
            }
        }

        public async Task<DataTable> GetDisticntReportTypeForPathologyReport(long _billNo)
        {
            return await Task.Run(() => ReturnDistinctReportType(_billNo));
        }

        private DataTable ReturnDistinctReportType(long _billNo)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT Distinct ReportTypeId,Report_Type from VWPathologicalTests Where dbo.VWPathologicalTests.TestStatus<>'Cancelled' and dbo.VWPathologicalTests.PatientId = {0}", _billNo);


                da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public List<ReportConsultant> GetReportConsultants()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultants.ToList();
            }
        }

        public void UpdatePathologyNonWordReportDetails(List<PathologyNonWordReportReportDetail> _reportDetails)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach (PathologyNonWordReportReportDetail _pnwrd in _reportDetails)
                {
                    entities.Entry(_pnwrd).State = EntityState.Modified;
                    entities.SaveChanges();
                }


            }
        }

        public List<VMReportPriority> GetReportPriorityObj(int reportTypeId, string _reportId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var reportId = new SqlParameter("PatientId", _reportId);
                var retportType = new SqlParameter("ReportTypeId", reportTypeId);
                return entities.Database.SqlQuery<VMReportPriority>(@"Select ld.PatientId,ld.InstrumentName,ld.ReportTypeId,pm.Priority from InterfacingData.dbo.PatientRecords ld join dbo.PathologicalMachines pm on pm.MachineShortName=ld.InstrumentName Where ld.PatientId=@PatientId and ld.ReportTypeId=@ReportTypeId", reportId, retportType).ToList();
            }
        }

        public TEMPLISPatientRecord GetTempLISPatientRecord(string reportId, string machineShortName)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TEMPLISPatientRecords.Where(x => x.ReportId == reportId && x.InstrumentName == machineShortName).FirstOrDefault();
            }
        }

        public List<PathologyNonWordReportReportDetail> GetPathologyNonWordReportDetailById(long _reportId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathologyNonWordReportReportDetails.Where(x => x.ReportId == _reportId).ToList();
            }
        }

        public async Task<DataSet> GetTestListForSampleCollection(long patientId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.TestsCost.Id, dbo.TestsCost.TestId, dbo.TestsCost.PatientId, dbo.TestsCost.TestId,VacuWithTestSettings.VTId, dbo.TestItems.Name as TestName, dbo.TestItems.ShortName, BarCodeLabelSettingForTests.BarcodeLabel,BarCodeLabelSettingForTests.CategoryId, TestItems.ReportTypeId, TestItems.CollectionTypeId, dbo.TestsCost.Cost, dbo.TestsCost.ReportStatus,dbo.TestsCost.UserId, dbo.[User].LoginName as UserName, dbo.TestsCost.Status AS TestStatus
                                      FROM  dbo.TestItems INNER JOIN
                                      dbo.TestsCost ON dbo.TestItems.TestId = dbo.TestsCost.TestId 
								      inner join VacuWithTestSettings on dbo.TestsCost.TestId =  VacuWithTestSettings.TestId
								      INNER JOIN BarCodeLabelSettingForTests on dbo.TestItems.TestId=BarCodeLabelSettingForTests.TestId inner join
                                      dbo.[User] ON dbo.TestsCost.UserId = dbo.[User].UserId 
                                      WHERE  ( TestItems.ReportTypeId in (2,5,6,7,8,9,10,11,12,14,16,17,19,24,27,48,51,55,67) and dbo.TestsCost.Status<>'Cancelled' and  dbo.TestsCost.PatientId = {0})", patientId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtCashMemo");
                return await Task.FromResult(dsReports);
            }
        }

        public DataSet GetHpAdmittedPatientList(int deptId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@" Select * from VWHospitalPatientDetails_2 Where (DeptId={0} or {0}=0)", deptId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtHpAdmittedPatientList");
                return dsReports;
            }
        }

        public byte[] GetReportContentByRegNoAnd(long _billNo, int _testId)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ReportData FROM dbo.ImageOrPdfReport WHERE BillNo=@BillNo and TestId=@TestId", con);
                cmd.Parameters.Add(new SqlParameter("@BillNo", SqlDbType.BigInt));
                cmd.Parameters.Add(new SqlParameter("@TestId", SqlDbType.Int));
                cmd.Parameters["@BillNo"].Value = _billNo;
                cmd.Parameters["@TestId"].Value = _testId;
                byte[] img = (byte[])cmd.ExecuteScalar();
                con.Close();

                return img;
            }
            catch
            {
                return null;
            }
        }
        public DataSet GetTestList(long patientId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {

                    sql = string.Format(@"SELECT dbo.TestsCost.Id, dbo.TestsCost.PatientId, dbo.TestsCost.TestId, CASE WHEN dbo.TestItems.ReportTypeId=63 and dbo.TestsCost.Qty>1 THEN  dbo.TestItems.Name + '-' + CONVERT(nvarchar(50),dbo.TestsCost.Qty) + 'Pcs'  ELSE dbo.TestItems.Name  END AS TestName, dbo.TestItems.TestCode, TestItems.ReportTypeId,dbo.TestsCost.IsCancelApprove, dbo.TestsCost.Cost,dbo.TestsCost.DiscountInPercent,dbo.TestsCost.Discount, dbo.TestsCost.UserId, dbo.[User].LoginName as UserName, dbo.TestsCost.Status AS TestStatus
                                  FROM     dbo.TestItems INNER JOIN
                                   dbo.TestsCost ON dbo.TestItems.TestId = dbo.TestsCost.TestId INNER JOIN
                                 dbo.[User] ON dbo.TestsCost.UserId = dbo.[User].UserId
                                 WHERE  (dbo.TestsCost.PatientId = {0}  and dbo.TestsCost.Status<>'Cancelled')", patientId);



                    da = new SqlDataAdapter(sql, conn);

                    DataSet dsReports = new DataSet();
                    da.Fill(dsReports, "dtCashMemo");
                    return dsReports;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool AddOrUpdateReportItems(IList<VMReportDefination> _SelectedTestItemsForPathologyReport)
        {

            try
            {
                foreach (var item in _SelectedTestItemsForPathologyReport)
                {
                    using (DBEntities entities = new DBEntities())
                    {
                        PathologyNonWordReportReportDetail _rd = this.GetPathologyNonWordReportReportDetailObj(item.ReportId, item.TestId, item.TestDetailId);
                        if (_rd != null)
                        {

                            _rd.TestResult = item.TestResult;

                            entities.Entry(_rd).State = EntityState.Modified;
                            entities.SaveChanges();
                        }
                        else
                        {
                            PathologyNonWordReportReportDetail _reportdetail = new PathologyNonWordReportReportDetail();
                            _reportdetail.ReportId = item.ReportId;
                            _reportdetail.TestId = item.TestId;
                            _reportdetail.TestDetailId = item.TestDetailId;
                            _reportdetail.TestTitle = item.TestTitle;
                            _reportdetail.TestResult = item.TestResult;
                            _reportdetail.ResultUnit = item.ResultUnit;
                            _reportdetail.NormalResult = item.NormalValue;
                            entities.PathologyNonWordReportReportDetails.Add(_reportdetail);
                            entities.SaveChanges();
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private PathologyNonWordReportReportDetail GetPathologyNonWordReportReportDetailObj(long reportId, int testId, int testDetailId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathologyNonWordReportReportDetails.Where(x => x.ReportId == reportId && x.TestId == testId && x.TestDetailId == testDetailId).FirstOrDefault();
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

        public DataTable GetDisticntTestGroupForPathologyReport(int RegNo)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT Distinct TestGroupId,GroupName from VWPathologicalTests Where dbo.VWPathologicalTests.TestStatus<>'Cancelled' and dbo.VWPathologicalTests.PatientId = {0}", RegNo);


                da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public string GetTestByReportId(long _reportId)
        {
            return new ReportRepository().GetTestByReportId(_reportId);
        }

        public DataTable GetPathologicalTestsByGroup(int RegNo, int groupId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.VWPathologicalTests.TestId, dbo.VWPathologicalTests.TestName  
                                  FROM  VWPathologicalTests WHERE (dbo.VWPathologicalTests.TestStatus<>'Cancelled' and dbo.VWPathologicalTests.PatientId = {0} and TestGroupId={1})", RegNo, groupId);


                da = new SqlDataAdapter(sql, conn);

                DataTable dtchildc = new DataTable();
                da.Fill(dtchildc);

                return dtchildc;
            }
        }



        public DataSet GetCollectionStatement(DateTime dateTimefrom, DateTime dateTimeto, string _userName, string _reportOPtion)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                da = new SqlDataAdapter();
                sql = string.Format(@"Exec [dbo].[SP_Diag_Income_statement] '{0}','{1}','{2}','{3}'", dateTimefrom, dateTimeto, _userName, _reportOPtion);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtDiagPatientStatement");
                conn.Close();

                return ds;
            }
        }



        public async Task<DataTable> GetTestDetailsForReport(long _patientId, int testId, int ReportTypeId, int PriorityId)
        {

            return await Task.Run(() => GetTestDetailsForPatientReport(_patientId, testId, ReportTypeId, PriorityId));


        }

        private DataTable GetTestDetailsForPatientReport(long patientId, int testId, int ReportTypeId, int PriorityId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetPathNewReportTestDetails {0},{1},{2},{3}", patientId, testId, ReportTypeId, PriorityId);

                da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public SqlDataAdapter GetAmbulanceRentInfo(DateTime dateTime1, DateTime dateTime2)
        {
            sql = string.Format(@"SELECT RentDate,RegNo,Id,RenterName,MobileNo,TripFrom,TripTo,TotalRent from Ambulances WHERE (dbo.Ambulances.RentDate between '{0}' and '{1}')", dateTime1, dateTime2);

            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            return da;
        }

        public double GetDueTk(long patientId)
        {
            using (SqlConnection con = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select Sum(Debit-Credit) as DueTk from PatientLedger Where PatientId={0} and TransactionType<>'CardOrMobileServiceCharge'", patientId);
                    cmd = new SqlCommand(sql, con);
                    con.Open();

                    return Convert.ToDouble(cmd.ExecuteScalar());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public DataSet GetTokenData(long _PatientId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.VWUsgOrXrayOrEchoTestList.PatientId,dbo.VWUsgOrXrayOrEchoTestList.BillNo, dbo.VWUsgOrXrayOrEchoTestList.TestId, dbo.VWUsgOrXrayOrEchoTestList.Name as TestName, dbo.VWUsgOrXrayOrEchoTestList.EntryDate, VWUsgOrXrayOrEchoTestList.FullName as Name, dbo.VWUsgOrXrayOrEchoTestList.AgeYear as Age, dbo.VWUsgOrXrayOrEchoTestList.Sex, dbo.VWUsgOrXrayOrEchoTestList.Refdby
                                  FROM     VWUsgOrXrayOrEchoTestList
                                  WHERE  (dbo.VWUsgOrXrayOrEchoTestList.PatientId = {0})", _PatientId);



                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtTokentTestList");
                return dsReports;
            }
        }

        public SqlDataAdapter GetIndoorPatientBillStatement(DateTime dateTime1, DateTime dateTime2)
        {
            sql = string.Format(@"SELECT Invdate,RegNo,Name,HospitalBill,DiscountOnHospital,HospitalPaymentByCash,HospitalBillPaymentByPF,HospitalPaymentByHCV from VWHospitalBillStatement WHERE (dbo.VWHospitalBillStatement.Invdate between '{0}' and '{1}')", dateTime1, dateTime2);

            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            return da;
        }

        public PathologyReport SavePathologyNonWordReport(Model.PathologyReport _report)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    PathologyReport _pReport = this.GetPathologyReport(_report.PatientId, _report.ReportType);

                    if (_pReport != null)
                    {

                        _pReport.ModifiedDate = DateTime.Now;
                        _pReport.ModifiedTime = DateTime.Now.ToString("hh:mm tt");
                        _pReport.ModifiedBy = _report.PreparedBy;
                        entities.Entry(_pReport).State = EntityState.Modified;
                        entities.SaveChanges();

                        return _pReport;
                    }
                    else
                    {
                        entities.PathologyReports.Add(_report);
                        entities.SaveChanges();
                        return _report;

                    }

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }



        public void UpdateReportStatus(List<VMReportDefination> _DistinctTestObj)
        {
            foreach (var item in _DistinctTestObj)
            {
                TestsCost _cost = new TestsCostRepository().GetTestCostByPatientAndTestId(item.PatientId, item.TestId);
                _cost.ReportStatus = ReportStatusEnum.RP.ToString();
                new TestsCostRepository().UpdateReportStatusByTest(_cost);
            }

        }

        private PathologyReport GetPathologyReport(long patientId, int reportType)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathologyReports.Where(x => x.PatientId == patientId && x.ReportType == reportType).FirstOrDefault();
            }
        }

        public void SavePathologicalReportDetail(List<Model.PathologyNonWordReportReportDetail> _reportdetailList, PathologyReport _report)
        {
            using (DBEntities entity = new DBEntities())
            {
                try
                {

                    _reportdetailList.ForEach(n => entity.PathologyNonWordReportReportDetails.Add(n));
                    entity.SaveChanges();

                    // Set Report Status of a sample

                    List<PathologyNonWordReportReportDetail> _rdList = new List<PathologyNonWordReportReportDetail>();
                    foreach (var item in _reportdetailList)
                    {
                        if (_rdList.Count > 0 && !_rdList.Any(x => x.TestId == item.TestId))
                        {
                            TestsCost _cost = new TestsCostRepository().GetTestCostByPatientAndTestId(_report.PatientId, item.TestId);
                            _cost.ReportStatus = ReportStatusEnum.RP.ToString();
                            new TestsCostRepository().UpdateReportStatusByTest(_cost);
                            _rdList.Add(item);
                        }

                        if (_rdList.Count == 0)
                        {
                            TestsCost _cost = new TestsCostRepository().GetTestCostByPatientAndTestId(_report.PatientId, item.TestId);
                            _cost.ReportStatus = ReportStatusEnum.RP.ToString();
                            new TestsCostRepository().UpdateReportStatusByTest(_cost);
                            _rdList.Add(item);
                        }
                    }


                }
                catch (Exception ex)
                {

                }
            }
        }

        public ReportDeliveryTimingMaster GetRegularReportDeliveryTimeMaster()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportDeliveryTimingMasters.Where(x => x.IsActiveNow == true).FirstOrDefault();

            }
        }

        public List<ReportDeliveryTimingDetail> GetReportDeliveryTimingDetail(int rDTMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportDeliveryTimingDetails.Where(x => x.RDTMId == rDTMId).ToList();
            }
        }

        public ReportDeliveryTimingMaster GetWeekEndReportDeliveryTimingMaster()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportDeliveryTimingMasters.Where(x => x.IsWeekendDeliverySchedule == true).FirstOrDefault();
            }
        }

        public SqlDataAdapter GetPathologicalTestDataByReportId(long reportId)
        {
            sql = string.Format(@"SELECT PatientId,GroupId,GroupTitle,TestId,TestTitle,TestDetailId,TestResult + ' ' + ResultUnit AS TestResult ,NormalResult,DetailReportOrder,TestReportOrder,GroupReportOrder,TestTitle_FontBold,TestTitle_FontItalic,TestTitle_FontUnderline from VWPathologicalReportDetails WHERE (dbo.VWPathologicalReportDetails.Id={0}) order by GroupReportOrder,TestReportOrder,DetailReportOrder", reportId);

            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            return da;
        }

        public SqlDataAdapter GetHospitalBillDetails(int InvoiceId)
        {
            sql = string.Format(@"SELECT ReportOrder,Name,DeliveredUnit,Rate,Total from VWHospitalBillDetails WHERE (dbo.VWHospitalBillDetails.BillId={0}) Order by ReportOrder", InvoiceId);

            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            return da;
        }





        public double GetCashBookTotal()
        {
            double cashbooktotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("spCashBookTotal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@cashbooktotal", SqlDbType.Float));
                    cmd.Parameters["@cashbooktotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@cashbooktotal"].Value != DBNull.Value)
                    {
                        cashbooktotal = Convert.ToDouble(cmd.Parameters["@cashbooktotal"].Value);
                    }
                }
            }
            return cashbooktotal;
        }
        public double GetCashBookDebitTotal()
        {
            double cashbooktotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("spCashBookDebitTotal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@cashbookdebittotal", SqlDbType.Float));
                    cmd.Parameters["@cashbookdebittotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@cashbookdebittotal"].Value != DBNull.Value)
                        cashbooktotal = Convert.ToDouble(cmd.Parameters["@cashbookdebittotal"].Value);
                }
            }
            return cashbooktotal;
        }

        public double GetCashBookCreditTotal()
        {
            double cashbooktotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("spCashBookCreditTotal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@cashbookcredittotal", SqlDbType.Float));
                    cmd.Parameters["@cashbookcredittotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@cashbookcredittotal"].Value != DBNull.Value)
                        cashbooktotal = Convert.ToDouble(cmd.Parameters["@cashbookcredittotal"].Value);
                }
            }
            return cashbooktotal;
        }


        public void GenerateStaticReport(DataTable dt_fields, DataTable dt_values)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_staticreports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tvparam1 = cmd.Parameters.AddWithValue("@dtFields", dt_fields);
                SqlParameter tvparam2 = cmd.Parameters.AddWithValue("@dtValues", dt_values);
                tvparam1.SqlDbType = SqlDbType.Structured;
                tvparam2.SqlDbType = SqlDbType.Structured;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet GetPathologicalStaticTestData()
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select * from tmpStaticReportData");

                da = new SqlDataAdapter(sql, conn);
                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtUrine");
                return dsReports;


            }


        }

        public List<VWMReportDoneList> GetTodaysReportList(DateTime dateTime)
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [ReportedTestListByDate] '{0}'", dateTime);

                da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<VWMReportDoneList> _listOfReportTests = new List<VWMReportDoneList>();

                _listOfReportTests = new List<VWMReportDoneList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetReportTestDataTableRow(dRow)))
                    );

                return _listOfReportTests;
            }

        }

        private VWMReportDoneList GetReportTestDataTableRow(DataRow dr)
        {
            VWMReportDoneList _reportTest = new VWMReportDoneList();
            _reportTest.BillNo = dr["BillNo"].ToString();
            _reportTest.ReportTests = dr["Tests"].ToString();
            _reportTest.ReportId = dr["ReportId"].ToString();

            return _reportTest;

        }

        public async Task<DataTable> GetPreviousReportTestDetailsByPatientByTestId(long PatientId, int TestId, int reportTypeId, int PriorityId)
        {

            return await Task.Run(() => GetPreviousReportTestDetailsOfPatient(PatientId, TestId, reportTypeId, PriorityId));

        }

        private DataTable GetPreviousReportTestDetailsOfPatient(long PatientId, int TestId, int reportTypeId, int PriorityId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetPathPrevReportTestDetails {0},{1},{2},{3}", PatientId, TestId, reportTypeId, PriorityId);

                da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

        }

        public DataTable GetPreviousReportTestDetails(long _reportId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT GroupId,GroupTitle,TestId,ReportTypeId,TestName,TestTitle,TestDetailId,TestResult,ResultUnit,NormalResult,DetailReportOrder,TestReportOrder,GroupReportOrder,TestTitle_FontBold,TestTitle_FontItalic,TestTitle_FontUnderline from VWPathologicalReportDetails WHERE (dbo.VWPathologicalReportDetails.Id={0}) order by GroupReportOrder,TestReportOrder,DetailReportOrder", _reportId);

                da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public bool UpdatePathologyNonWordReport(PathologyReport _updateReport)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_updateReport).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }


            }
        }

        public PathologyReport GetPathologyNonWordReportById(long _reportID)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathologyReports.Where(x => x.Id == _reportID).FirstOrDefault();
            }
        }

        public bool DeleteExistingReportDetails(long _reportId)
        {

            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Delete from PathologyNonWordReportReportDetails Where ReportId={0}", _reportId);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch
                {
                    con.Close();
                    return false;
                }

            }

        }

        public DataSet GetSummarySheetData(DateTime dateTime1, DateTime dateTime2)
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spSummarySheet] '{0}' , '{1}'", dateTime1, dateTime2);
                SqlCommand com = new SqlCommand(sql, conn);
                com.CommandTimeout = 0;
                da = new SqlDataAdapter(com);
                DataSet dsSummarySheet = new DataSet();
                da.Fill(dsSummarySheet, "dtSummarySheet");
                return dsSummarySheet;


            }

        }

        public VWSummarySheetSumAndBalance GetSummarySheetSumAndBalance()
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select Sum(Cast(Debit AS Float)) as Debit,Sum(Cast(Credit as Float)) as Credit, Sum(Cast(Credit as Float)-Cast(Debit as Float)) as Balance from SummarySheet");

                da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);


                return this.GetSumAndBalance(dt.Rows[0]);
            }

        }

        private VWSummarySheetSumAndBalance GetSumAndBalance(DataRow dr)
        {
            VWSummarySheetSumAndBalance _sumandbalance = new VWSummarySheetSumAndBalance();
            if (dr["Credit"] != DBNull.Value)
            {
                _sumandbalance.Credit = Convert.ToDouble(dr["Credit"]);
            }
            else
            {
                _sumandbalance.Credit = 0;
            }
            if (dr["Debit"] != DBNull.Value)
            {
                _sumandbalance.Debit = Convert.ToDouble(dr["Debit"]);
            }
            else
            {
                _sumandbalance.Debit = 0;
            }
            if (dr["Balance"] != DBNull.Value)
            {
                _sumandbalance.Balance = Convert.ToDouble(dr["Balance"]);
            }
            else
            {
                _sumandbalance.Balance = 0;
            }


            return _sumandbalance;
        }

        public string GetReportType(string[] Ids)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("SELECT ReportType FROM dbo.Reports WHERE PatientId='{0}' and TestId='{1}'", Ids[0], Ids[1]);
                SqlCommand cmd = new SqlCommand(sql, con);
                string _type = cmd.ExecuteScalar().ToString();
                con.Close();

                return _type;
            }
            catch
            {
                con.Close();
                return "";
            }
        }

        public DataSet GetUserWisePatientReceiptStatement(DateTime dateTime1, DateTime dateTime2, string _userName, string _reportOPtion)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                if (String.IsNullOrEmpty(_userName) || _userName == "All" || _userName == "Admin")
                {
                    if (_reportOPtion == "IPD")
                    {
                        sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryPaymentReceiptStatement   Where AdmissionNo>0 and [Date] between '{0}' and '{1}' order by RegNo", dateTime1, dateTime2);
                    }
                    else if (_reportOPtion == "OPD")
                    {
                        sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryPaymentReceiptStatement Where AdmissionNo=0  and [Date] between '{0}' and '{1}' order by RegNo", dateTime1, dateTime2);
                    }
                    else if (_userName == "Admin")
                    {
                        sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryPaymentReceiptStatement Where AdmissionNo=0  and [Date] between '{0}' and '{1}' and OperateBy='{2}' order by RegNo", dateTime1, dateTime2, _userName);
                    }
                    else
                    {
                        //sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryDuePaymentReceiptStatement Where [Date] between '{0}' and '{1}' order by RegNo", dateTime1, dateTime2);

                        sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryPaymentReceiptStatement Where [Date] between '{0}' and '{1}' order by RegNo", dateTime1, dateTime2);
                        
                    }

                }
                else
                {
                    if (_reportOPtion == "IPD")
                    {
                        sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryPaymentReceiptStatement Where AdmissionNo>0 and [Date] between '{0}' and '{1}' and OperateBy='{2}' order by RegNo", dateTime1, dateTime2, _userName);
                    }
                    else if (_reportOPtion == "OPD")
                    {
                        sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryPaymentReceiptStatement Where AdmissionNo=0 and [Date] between '{0}' and '{1}' and OperateBy='{2}' order by RegNo", dateTime1, dateTime2, _userName);
                    }
                    else
                    {
                        sql = string.Format(@"Select * from VWUserWisePatientWithOnEntryPaymentReceiptStatement Where [Date] between '{0}' and '{1}' and OperateBy='{2}' order by RegNo", dateTime1, dateTime2, _userName);
                    }

                }


                da = new SqlDataAdapter(sql, conn);
                DataSet dsUserwisePatientWithOnEntryDatePaymentReceiptReport = new DataSet();
                da.Fill(dsUserwisePatientWithOnEntryDatePaymentReceiptReport, "dtUserwisePatientWithOnEntryDatePaymentReceiptReport");

                return dsUserwisePatientWithOnEntryDatePaymentReceiptReport;
            }



        }

        public DataSet GetDueList(DateTime dateTime1, DateTime dateTime2, string _reportOption)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                if (_reportOption.ToLower() == "ipd")
                {
                    sql = string.Format(@"Select * from VWPatientWiseDueList Where [Date] between '{0}' and '{1}'  and AdmissionNo>0 and DueAmount<>'0'", dateTime1, dateTime2);
                }
                else if (_reportOption.ToLower() == "opd")
                {
                    sql = string.Format(@"Select * from VWPatientWiseDueList Where [Date] between '{0}' and '{1}' and AdmissionNo=0 and DueAmount<>'0'", dateTime1, dateTime2);
                }
                else
                {
                    sql = string.Format(@"Select * from VWPatientWiseDueList Where [Date] between '{0}' and '{1}' and DueAmount<>'0'", dateTime1, dateTime2);
                }
                da = new SqlDataAdapter(sql, conn);
                DataSet dsDueList = new DataSet();
                da.Fill(dsDueList, "dtDueList");
                return dsDueList;
            }

        }

        public DataSet GetGroupwiseTestAmount(Int32 groupID, Int32 patientID, DateTime dateTime1, DateTime dateTime2)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"exec spGroupWiseTestAmount  {0} , {1},'{2}' , '{3}' ", groupID, patientID, dateTime1, dateTime2);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsDueList = new DataSet();
                da.Fill(dsDueList, "DTMasterTestGroupDailyStatement");
                return dsDueList;
            }

        }



        public DataSet GetReferredStatement(DateTime dateTime1, DateTime dateTime2, int _referralId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                //sql = string.Format(@"Select AdvisorName,COUNT(PatientId) as TotalPatient,Sum(TotalTestAmount) as TestAmount,SUM(Discount) as Discount from dbo.VWReferredCasesStep2 Where [Date] between '{0}' and '{1}' group by AdvisorName", dateTime1, dateTime2);

                //da = new SqlDataAdapter(sql, conn);

                //sql = string.Format(@"EXEC [spReferredCases] '{0}' , '{1}',{2}", dateTime1, dateTime2, _referralId);
                sql = string.Format(@"EXEC [dbo].[spGetReferralStatement] '{0}' , '{1}','{2}','All'", dateTime1, dateTime2, _referralId);

                SqlCommand com = new SqlCommand(sql, conn);
                com.CommandTimeout = 0;
                da = new SqlDataAdapter(com);

                DataSet dsReferredcase = new DataSet();
                da.Fill(dsReferredcase, "dtReferredcase");
                return dsReferredcase;
            }

        }

        public DataSet GetDueCollectionList(DateTime dateTime1, DateTime dateTime2, string _userName)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                if (String.IsNullOrEmpty(_userName) || _userName == "All")
                {
                    sql = string.Format(@"Select * from VWPatientWiseDueCollectionList Where [Date] between '{0}' and '{1}'", dateTime1, dateTime2);
                }
                else
                {
                    sql = string.Format(@"Select * from VWPatientWiseDueCollectionList Where [Date] between '{0}' and '{1}' and OperateBy='{2}'", dateTime1, dateTime2, _userName);
                }



                da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
                DataSet dsDueCollectionList = new DataSet();
                da.Fill(dsDueCollectionList, "dtDueCollectionList");
                return dsDueCollectionList;
            }


        }

        public async Task<DataSet> GetConsultancyStatement(int _ConsultantId, DateTime dateTime1, DateTime dateTime2)
        {

            return await Task.Run(() =>
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {

                    da = new SqlDataAdapter();
                    sql = string.Format(@"Exec sp_VWConsultancy_summery '{0}','{1}',{2}", dateTime1, dateTime2, _ConsultantId);
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 900;
                    da.SelectCommand = cmd;
                    DataSet dsConsultancy = new DataSet();

                    conn.Open();


                    da.Fill(dsConsultancy, "dtConsultancy");
                    conn.Close();
                    return dsConsultancy;



                }
            });



        }

        public SqlDataAdapter GetIrregularPaymentList()
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

            }
            sql = string.Format(@"Select * from VWDepriciation Where Depriciation<>0");

            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            return da;
        }

        public DataSet GetRefundDateWise(DateTime dateTime1, DateTime dateTime2)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select TranDate as [Date], Sum(RefundTk) as Amount from VWRefundTk Where [TranDate] between '{0}' and '{1}' group by TranDate", dateTime1, dateTime2);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsRefund = new DataSet();
                da.Fill(dsRefund, "dtRefund");
                return dsRefund;
            }

        }

        public DataSet GetRefundPatientWise(DateTime dateTime1, DateTime dateTime2)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select PatientId AS BillNo, RefundTk as Amount from VWRefundTk Where [TranDate] between '{0}' and '{1}'", dateTime1, dateTime2);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsRefundPatientWise = new DataSet();
                da.Fill(dsRefundPatientWise, "dtRefundPatientWise");
                return dsRefundPatientWise;
            }

        }

        public DataSet GetExpenseDetailsByHead(DateTime dateTime1, DateTime dateTime2, AccountHead _accHead)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select trandate as [Date], Description,Amount from VWExpenseDetails Where [TranDate] between '{0}' and '{1}' and AccountId={2}", dateTime1, dateTime2, _accHead.AccId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsHeadwiseExpense = new DataSet();
                da.Fill(dsHeadwiseExpense, "dtHeadwiseExpense");
                return dsHeadwiseExpense;
            }

        }

        public DataSet GetExpenseByChecqueList(DateTime dateTime1, DateTime dateTime2)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select trandate as [Date], Name,Description,Amount from VWExpenseByCheck Where [TranDate] between '{0}' and '{1}'", dateTime1, dateTime2);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsExpenseByCheck = new DataSet();
                da.Fill(dsExpenseByCheck, "dtExpenseByCheck");
                return dsExpenseByCheck;
            }

        }

        public DataSet GetTestSummary(DateTime dateTime1, DateTime dateTime2, int _doctorId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [SpTestSummary] '{0}' , '{1}', {2}", dateTime1, dateTime2, _doctorId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtTestSummary");

                return ds;
            }

        }

        public DataSet GetPatientSerialByDoctor(int _doctorId, DateTime _date)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select SerialNo,PatientName,MobileNo from PractitionerWisePatientSerials Where ChamberPractitionerId= {0} and  SerialDate='{1}'", _doctorId, _date.Date);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtPatientSerial");

                return ds;
            }
        }

        public DataSet GetCancelledPatientStatement(DateTime dateTime1, DateTime dateTime2, int _refdBy)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                if (_refdBy > 0)
                {
                    sql = string.Format(@"SELECT * from VWCancelledPatientStatement WHERE (dbo.VWCancelledPatientStatement.Date between '{0}' and '{1}' and RefdId={2}) order by PatientId ASC", dateTime1, dateTime2, _refdBy);
                }
                else
                {
                    sql = string.Format(@"SELECT * from VWCancelledPatientStatement WHERE (dbo.VWCancelledPatientStatement.Date between '{0}' and '{1}') order by PatientId ASC", dateTime1, dateTime2);
                }

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtDiagPatientStatement");
                return ds;
            }
        }

        public bool IsReportDoneByOtherConsultant(ViewModelReportTests viewModelReportTests, string regNo, int _LoggedInConsultantId)
        {
            try
            {
                int _consultant = 0;
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("SELECT * FROM dbo.Reports WHERE RegNo='{0}' and TestId='{1}'", regNo, viewModelReportTests.Id);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        _consultant = reader.GetInt32(9);
                    }

                }

                if (_consultant > 0 && _consultant != _LoggedInConsultantId) return true;

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ChangeConsultant(string _regNo, ViewModelReportTests viewModelReportTests, ReportConsultant _newconsultant)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("Update dbo.Reports Set ConsultantId={0} WHERE RegNo='{1}' and TestId={2}", _newconsultant.RCId, _regNo, viewModelReportTests.Id);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("Update dbo.TestsCost Set ConsultantId={0} WHERE PatientId={1} and ItemId={2}", _newconsultant.RCId, _regNo, viewModelReportTests.Id);
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                return true;
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

        public List<PathologyReport> GetPathologyReportByPatientId(long _pId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathologyReports.Where(x => x.PatientId == _pId).ToList();
            }
        }

        public double GetRegularReceivedByUser(DateTime _dtp, LoginUser loggedinUser)
        {
            double _currentReceived = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                string _sql = string.Format("Select Sum(Amount) as totalRecieved from VWUserWisePatientWithOnEntryPaymentReceiptStatement Where Date='{0}' and OperateBy='{1}'", _dtp.Date, loggedinUser.Name);

                using (SqlCommand cmd = new SqlCommand(_sql, con))
                {
                    con.Open();
                    var _amount = cmd.ExecuteScalar();
                    if (_amount != DBNull.Value)
                    {
                        _currentReceived = Convert.ToDouble(_amount);
                    }
                    con.Close();

                }
            }
            return _currentReceived;
        }

        public double GetDueCollectionByUser(DateTime _dtp, LoginUser loggedinUser)
        {
            double _currentReceived = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                string _sql = string.Format("Select Sum(Credit-Debit) as totalRecieved from PatientLedger Where TranDate='{0}' and OperateBy='{1}' and TransactionType in ('DueCollection')", _dtp.Date, loggedinUser.Name);

                using (SqlCommand cmd = new SqlCommand(_sql, con))
                {
                    con.Open();
                    var _amount = cmd.ExecuteScalar();
                    if (_amount != DBNull.Value)
                    {
                        _currentReceived = Convert.ToDouble(_amount);
                    }
                    con.Close();

                }
            }
            return _currentReceived;
        }

        public VMDepositSlip GetDepositSlip(DateTime _dtpfrom, DateTime _dtpto, string _userName, string _reportOPtion)
        {
            var _strdtpfrom = new SqlParameter("@DateFrom", _dtpfrom.ToShortDateString());
            var _strdtpto = new SqlParameter("@DateTo", _dtpto.ToShortDateString());
            var _strname = new SqlParameter("@OperatorBy", _userName);
            var _invoiceType = new SqlParameter("@InvoiceType", _reportOPtion);

            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMDepositSlip>(@"exec SP_DIAG_INCOME  @DateFrom,@DateTo,@OperatorBy,@InvoiceType ", _strdtpfrom, _strdtpto, _strname, _invoiceType).FirstOrDefault();
            }


        }
    }
}