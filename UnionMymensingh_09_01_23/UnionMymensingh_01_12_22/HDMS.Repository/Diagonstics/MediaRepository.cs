using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Diagonstics
{
    public class MediaRepository
    {
        string sql = string.Empty;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;




        public List<VMPatientWiseMediaPayment> GetPatientWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"
    SELECT t.PatientId
	,t.MediaId
	,t.MediaName
	,t.FullName AS PatientName
	,SUM(t.RegularDiscount) + SUM(t.DiscountMinus) - SUM(t.DiscountPluse) AS TotalDiscount
	,SUM(t.DiscountMinus) AS DueDiscount
	,SUM(t.DiscountPluse) AS RegularDiscount
	,SUM(t.RegularDiscount) AS TotalDisicountWithDiscountMinus
FROM (
	SELECT bs.Name AS MediaName
		,bs.MediaId
		,r.FullName
		,p.PatientId
		,ml.Credit
		,SUM(ml.Debit) AS RegularDiscount
		,0 AS DiscountPluse
		,0 AS DiscountMinus
		,ml.TransactionType
	FROM Patients AS p
	INNER JOIN RegRecords AS r ON r.RegNo = p.RegNo
	INNER JOIN BusinessMedias AS bs ON bs.MediaId = p.MediaId
	INNER JOIN MediaLedgers AS ml ON ml.PatientId = p.PatientId
	WHERE Convert(DATE, ml.TranDate) BETWEEN '{0}' AND '{1}'
		AND ml.TransactionType IN ('DiscountOnRegularCollection')
		AND p.MediaId = {2}
	GROUP BY r.FullName
		,p.PatientId
		,ml.Credit
		,ml.TransactionType
		,ml.Debit
		,bs.Name
		,bs.MediaId
	
	UNION ALL
	
	SELECT bs.Name AS MediaName
		,bs.MediaId
		,r.FullName
		,p.PatientId
		,ml.Credit
		,0 AS RegularDiscount
		,0 AS DiscountPluse
		,SUM(ml.Debit) AS DiscountMinus
		,ml.TransactionType
	FROM Patients AS p
	INNER JOIN RegRecords AS r ON r.RegNo = p.RegNo
	INNER JOIN BusinessMedias AS bs ON bs.MediaId = p.MediaId
	INNER JOIN MediaLedgers AS ml ON ml.PatientId = p.PatientId
	WHERE Convert(DATE, ml.TranDate) BETWEEN '{0}' AND '{1}'
		AND ml.TransactionType IN ('DiscountOnMediaPaymentMinus')
		AND p.MediaId = {2}
	GROUP BY r.FullName
		,p.PatientId
		,ml.Credit
		,ml.TransactionType
		,ml.Debit
		,bs.Name
		,bs.MediaId
	
	UNION ALL
	
	SELECT bs.Name AS MediaName
		,bs.MediaId
		,r.FullName
		,p.PatientId
		,ml.Credit
		,0 AS RegularDiscount
		,SUM(ml.Credit) AS DiscountPluse
		,0 AS DiscountMinus
		,ml.TransactionType
	FROM Patients AS p
	INNER JOIN RegRecords AS r ON r.RegNo = p.RegNo
	INNER JOIN BusinessMedias AS bs ON bs.MediaId = p.MediaId
	INNER JOIN MediaLedgers AS ml ON ml.PatientId = p.PatientId
	WHERE Convert(DATE, ml.TranDate) BETWEEN '{0}' AND '{1}'
		AND ml.TransactionType IN ('DiscountOnMediaPaymentPluse')
		AND p.MediaId = {2}
	GROUP BY r.FullName
		,p.PatientId
		,ml.Credit
		,ml.TransactionType
		,ml.Debit
		,bs.Name
		,bs.MediaId
	) AS t
GROUP BY t.PatientId
	,t.MediaId
	,t.MediaName
	,t.FullName	                

", dtFrom.Date, dtTo.Date, mediaId);

                return entities.Database.SqlQuery<VMPatientWiseMediaPayment>(sql).ToList();
            }
        }

		public static DataSet GetHospitalMeidaWaisePaymentStatement(DateTime from, DateTime to, int mediaId)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{

					string sql = string.Format($@"SELECT r.FullName as PatientName
												, hpinfo.BillNo
												, hpinfo.AdmissionId
												, hpinfo.DischargeDate
												, hpinfo.MediaCommission
												, m.MediaId
												, m.Name as MediaName
											FROM HospitalPatientInfoes AS hpinfo
											INNER JOIN BusinessMedias AS m ON hpinfo.MediaId = m.MediaId
											INNER JOIN RegRecords AS r ON r.RegNo = hpinfo.RegNo
											WHERE hpinfo.DischargeDate BETWEEN '{from}'
													AND '{to}' AND m.MediaId = {mediaId}");
					SqlDataAdapter da = new SqlDataAdapter(sql, conn);
					DataSet ds = new DataSet();
					da.Fill(ds);
					return ds;
				}
				catch (Exception ex)
				{
					return new DataSet();
				}
			}
		}

        public static DataSet GetHospitalMeidaPaymentStatement(DateTime from, DateTime to, int mediaId)
        {
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					
					string sql = string.Format($@"SELECT r.FullName as PatientName
												, hpinfo.BillNo
												, hpinfo.AdmissionId
												, hpinfo.DischargeDate
												, hpinfo.MediaCommission
												, m.MediaId
												, m.Name
											FROM HospitalPatientInfoes AS hpinfo
											INNER JOIN BusinessMedias AS m ON hpinfo.MediaId = m.MediaId
											INNER JOIN RegRecords AS r ON r.RegNo = hpinfo.RegNo
											WHERE hpinfo.DischargeDate BETWEEN '{from}'
													AND '{to}'");
					SqlDataAdapter da = new SqlDataAdapter(sql, conn);
					DataSet ds = new DataSet();
					da.Fill(ds);
					return ds;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

        public static DataSet getMediaStatementDataset(DateTime fromDate, DateTime toDate, int mediaId, bool paid)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					string sp = paid ? "spMediaCommissionStatement" : "spGetMediaUnpaidStatement";
					string sql = string.Format($"exec {sp} '{fromDate}', '{toDate}', {mediaId}");
					SqlDataAdapter da = new SqlDataAdapter(sql, conn);
					DataSet ds = new DataSet();
					da.Fill(ds);
					return ds;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public static DataSet getMediaPaymentReceiptByPatientId(Patient patient)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					string sql = string.Format($"exec spGetMediaPaymentReceipt {patient.PatientId}");

					if (patient.MediaId == 0)
					{
						sql = string.Format($"exec spGetRefPaymentReceipt {patient.PatientId}");
					}

					SqlDataAdapter da = new SqlDataAdapter(sql, conn);
					DataSet ds = new DataSet();
					da.Fill(ds, "dtMediaPaymentReceipt");
					return ds;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public MediaLedger GetPatientIdByMedia(long patientId)
        {
            using(DBEntities entities = new DBEntities())
            {
                try {
					MediaLedger mediaLedger = entities.MediaLedgers.Where(x => x.PatientId == patientId).FirstOrDefault();

					return mediaLedger;
				
				}catch(Exception ex)
                {
					return null;
                }
            }
        }

        public DataSet GetUserWiseMediayPayment(int MediaId, DateTime dtfrom, DateTime dtTo)
        {
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				sql = string.Format(@"
					SELECT bs.Name AS MediaName
						,r.FullName AS PatientName
						,ml.TranDate
						,ISNULL(sum(ml.Credit) -  sum(ml.Debit), 0) AS Total
						, u.LoginName AS UserName
						,p.PatientId
					FROM Patients AS p
					INNER JOIN RegRecords AS r ON r.RegNo = p.RegNo
					INNER JOIN MediaLedgers AS ml ON p.PatientId = ml.PatientId
					INNER JOIN BusinessMedias AS bs ON bs.MediaId = ml.MediaId
					INNER JOIN [User] AS u ON ml.UserId = u.UserId
					WHERE ml.UserId = {2}
						AND ml.TransactionType in('MediaPayment','DiscountOnRegularCollection','DiscountOnMediaPaymentPluse','DiscountOnMediaPaymentMinus')
						AND CONVERT(DATE, ml.TranDate) BETWEEN '{0}'
							AND '{1}'
					GROUP BY bs.Name
						,r.FullName
						,ml.TranDate
						,u.LoginName
						,p.PatientId;
", dtfrom.Date, dtTo.Date, MediaId);
				da = new SqlDataAdapter(sql, conn);
				ds = new DataSet();
				da.Fill(ds, "dtUserWiseMeidaPaymentList");
				return ds;
			}

		}

        public List<VMTestWiseMediaPayment> GetTestWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"
						SELECT tc.TestId
	,p.MediaId
	,p.PatientId
	,r.FullName AS PatientName
	,ti.Name AS TestName
	,ti.Rate
	,ml.Credit AS MediaCommission
FROM MediaLedgers AS ml
INNER JOIN BusinessMedias AS bs ON bs.MediaId = ml.MediaId
INNER JOIN Patients AS p ON p.MediaId = bs.MediaId
	AND p.PatientId = ml.PatientId
INNER JOIN RegRecords AS r ON r.RegNo = p.RegNo
INNER JOIN TestsCost AS tc ON tc.PatientId = p.PatientId
	AND ml.TestId = tc.TestId
INNER JOIN TestItems AS ti ON ti.TestId = tc.TestId
WHERE ml.MediaId = {2}
	AND Convert(DATE, ml.TranDate) BETWEEN '{0}'
		AND '{1}'
	AND ml.TransactionType = 'MediaPayment'
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
                    where p.IsMediaPaid = 1 and p.EntryDate between '{0}' and '{1}'
                    ", dtpFrom, dtpTo);



                    List<BusinessMedia> medias = entities.Database.SqlQuery<BusinessMedia>(sql).ToList();
                    return medias;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
