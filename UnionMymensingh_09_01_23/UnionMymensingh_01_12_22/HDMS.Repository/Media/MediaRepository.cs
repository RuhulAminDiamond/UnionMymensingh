using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Media;
using HDMS.Model.Marketing;
using HDMS.Model.Media;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Media
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

		public static DataSet GetMarketingSummaryStatement(DateTime fromDate, DateTime toDate)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					string sql = string.Format($"exec spGetMarketingAgentSummaryStatement '{fromDate}', '{toDate}'");
					SqlDataAdapter da = new SqlDataAdapter(sql, conn);
					DataSet ds = new DataSet();
					da.Fill(ds, "dtMarketingSummaryStatement");
					return ds;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public static void SetMediaCommissionPaid(long patientId)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					string sql = string.Format($"update PatientWiseMediaCommissions set IsPaid = 1 where PatientId = {patientId}");

					SqlCommand command = new SqlCommand(sql, conn);
					conn.Open();
					int result = command.ExecuteNonQuery();
					conn.Close();
				}
				catch (Exception ex)
				{

				}
			}
		}

		public static DataSet getMediaStatementDataset(DateTime fromDate, DateTime toDate, int mediaId)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					string sql = string.Format($"exec spMediaCommissionStatement '{fromDate}', '{toDate}', {mediaId}");
					SqlDataAdapter da = new SqlDataAdapter(sql, conn);
					DataSet ds = new DataSet();
					da.Fill(ds, "dtMediaCommissionStatement");
					return ds;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public static List<PatientWiseMediaCommission> fetchPatientWiseMediaCommission(long patientId)
		{
			using (DBEntities entities = new DBEntities())
			{
				try
				{
					var result = entities.PatientWiseMediaCommissions.Where(x => x.PatientId == patientId).ToList();
					return result;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public static void SaveCommisionForPatient(Patient patient)
		{
			using (DBEntities entities = new DBEntities())
			{
				try
				{
					string sql = string.Format($"select * from VMMedialCommissionCalculation where PatientId={patient.PatientId}");

					List<VMMedialCommissionCalculation> commisions = entities.Database.SqlQuery<VMMedialCommissionCalculation>(sql).ToList();

					foreach (VMMedialCommissionCalculation cm in commisions)
					{
						PatientWiseMediaCommission commission = new PatientWiseMediaCommission();
						commission.MediaId = patient.MediaId;
						commission.PatientId = patient.PatientId;
						commission.TestName = cm.TestName;
						commission.TestRate = cm.TestRate;
						commission.CommissionInPercent = cm.CommissionInPercent;
						commission.CommissionInAmount = cm.CommissionInAmount;
						entities.PatientWiseMediaCommissions.Add(commission);
						entities.SaveChanges();
					}
				}
				catch (Exception ex)
				{

				}
			}


		}

		public static DataSet getMediaPaymentReceiptByPatientId(int patientId)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					string sql = string.Format($"exec spGetMediaPaymentReceipt {patientId}");
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
		public static DataSet GetMediaStatementMOWise(object dtFrom, object dtTo, int mAId)
		{
			using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
			{
				try
				{
					string sql = string.Format(@"exec spGetMediaCommissionStatementByMarketingAgent '{0}', '{1}', {2}", dtFrom, dtTo, mAId);
					SqlDataAdapter da = new SqlDataAdapter(sql, conn);
					DataSet ds = new DataSet();
					da.Fill(ds, "dtMediaCommissionStatement");
					return ds;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}
		public static List<VMMedialCommissionCalculation> getMediaCommissionTestWise(long patientId)
		{
			using (DBEntities entities = new DBEntities())
			{
				try
				{
					string sql = string.Format($"Select * from VMMedialCommissionCalculation where patientId = {patientId}");
					var result = entities.Database.SqlQuery<VMMedialCommissionCalculation>(sql).ToList();
					return result;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public static List<VMCategoryWisePatient> GetCategoryWisePatients(int CategoryId)
		{
			using (DBEntities entities = new DBEntities())
			{
				try
				{
					string sql = string.Format($"exec spGetPatientsCategoryWise {CategoryId}");
					var result = entities.Database.SqlQuery<VMCategoryWisePatient>(sql).ToList();
					return result;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public static bool FreezMedia(BusinessMedia media)
		{
			using (DBEntities entities = new DBEntities())
			{
				try
				{
					entities.Entry(media).State = EntityState.Modified;
					entities.SaveChanges();
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public static List<VmMediaCommission> getCommissionsByMediaId(int mediaId)
		{
			using (DBEntities entities = new DBEntities())
			{
				try
				{
					string sql = string.Format($"exec Spgetmediacommission {mediaId}");
					var result = entities.Database.SqlQuery<VmMediaCommission>(sql).ToList();
					return result;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}

		public MediaLedger GetMediaLedgerById(int mediaId)
		{
			using (DBEntities entities = new DBEntities())
			{
				return entities.MediaLedgers.Where(x => x.MediaId == mediaId).FirstOrDefault();
			}
		}

		public BusinessMedia GetMediaById(int mediaId)
		{
			using (DBEntities entities = new DBEntities())
			{
				return entities.BusinessMedias.Where(x => x.MediaId == mediaId).FirstOrDefault();
			}
		}

		public static List<MediaCommissionGroup> getAllMediaCommissionGroups()
		{
			using (DBEntities entities = new DBEntities())
			{
				return entities.MediaCommissionGroups.ToList<MediaCommissionGroup>();
			}
		}

		public MediaLedger GetPatientIdByMedia(long patientId)
		{
			using (DBEntities entities = new DBEntities())
			{
				try
				{
					MediaLedger mediaLedger = entities.MediaLedgers.Where(x => x.PatientId == patientId).FirstOrDefault();

					return mediaLedger;

				}
				catch (Exception ex)
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
