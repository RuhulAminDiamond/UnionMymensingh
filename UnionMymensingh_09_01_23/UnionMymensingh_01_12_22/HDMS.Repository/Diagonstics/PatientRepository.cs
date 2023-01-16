using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Diagnostic;
using HDMS.Model.OPD;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Hospital.ViewModel;

namespace HDMS.Repository.Diagonstics
{
    public class PatientRepository
    {

        SqlConnection con;
        SqlDataAdapter da;
        string sql = string.Empty;
        SqlCommand cmd;

        public Task<List<VMDiagPatientBasicInfo>> GetDiagnosticPatienInfo(DateTime dtpfrm, DateTime dtpto)
        {
            {

                return Task.Run(() =>
                {
                    try
                    {
                        sql = string.Format("Exec spGetDiagPaientBasicInfo '{0}', '{1}'", dtpfrm, dtpto);  // Current Active Patient List
                        con = new SqlConnection();
                        con.ConnectionString = Utility.GetLegacyDbConnectionString();
                        con.Open();
                        da = new SqlDataAdapter(sql, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        con.Close();

                        List<VMDiagPatientBasicInfo> listhp = new List<VMDiagPatientBasicInfo>();

                        listhp = dt.AsEnumerable().Select(dr => new VMDiagPatientBasicInfo()
                        {

                            BillNo = Convert.ToInt64(dr["BillNo"]),
                            PatientId = Convert.ToInt64(dr["Patientid"]),
                            PatientName = dr["FullName"].ToString(),
                            Ageyear = dr["Ageyear"].ToString(),
                            Sex = dr["Sex"].ToString(),
                            MobileNo = dr["MobileNo"].ToString(),
                            Name = dr["Name"].ToString(),
                            MediaName = dr["MediaName"].ToString(),
                            DiscountCareOf = dr["DiscountCareOf"].ToString(),
                            UserName = dr["UserName"].ToString(),
                            ArearOrThana = dr["ArearOrThana"].ToString(),
                            EntryTime = dr["EntryTime"].ToString(),
                            EntryDate =Convert.ToDateTime(dr["EntryDate"]), 

                        }).ToList();



                        return listhp;
                    }
                    catch (Exception ex)
                    {
                        return new List<VMDiagPatientBasicInfo>();
                    }
                });
            }
        }

        public Patient GetPatientById(long billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.Where(x => x.PatientId == billNo).FirstOrDefault();
            }
        }

        public long SavePatient(Patient patient){
            using (DBEntities entity = new DBEntities())
            {
                entity.Patients.Add(patient);
                entity.SaveChanges();
                return patient.PatientId;
            }
        }
        public int GetNumberofPatientOfUserByDate(int Receivedby, DateTime date)
        {
            using(DBEntities entity = new DBEntities())
            {
                return entity.Patients.Where(x => (x.UserId == Receivedby && date.Year == x.EntryDate.Year
                && date.Month == x.EntryDate.Month
                && date.Day == x.EntryDate.Day && x.Status != "Cancelled")).ToList().Count;
            }
        }

        public List<VMDiagPatientAndTestDetail> GetDaigPatientAndTestDetailsByPatientId(long patientId)
        {
            var _patientId = new SqlParameter("@PatientId", patientId);

            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMDiagPatientAndTestDetail>(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId, 
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where dbo.Patients.PatientId=@PatientId and dbo.TestItems.ReportTypeId<>63 and  dbo.TestsCost.Status<>'Cancelled' and dbo.TestsCost.ReportStatus in ('NE','OP','SC','SR','SRun','RG','RV')", _patientId).ToList();
            }
        }

        public List<VMDiagPatientAndTestDetail> GetDaigPatientOrDeleveredReportsByPatientId(long patientId)
        {

            var _patientId = new SqlParameter("@PatientId", patientId);

            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMDiagPatientAndTestDetail>(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId, 
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where BillNo=@PatientId and dbo.TestItems.ReportTypeId<>63 and  dbo.TestsCost.Status<>'Cancelled' and dbo.TestsCost.ReportStatus in ('RP','RD')", _patientId).ToList();
            }
        }

        public List<VMDiagPatientAndTestDetail> GetDiagUndeliveredTestDetailByDateAndTime(DateTime dtpfrm, DateTime _time, int _ReportTypeId, string _ipdOpd)
        {


            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {

                    string _sql = string.Empty;

                    if (_ipdOpd == "IPD")
                    {
                        _sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.ReportIdPrefix,dbo.Patients.ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, Convert(date, dbo.Patients.DeliveryDate) DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId,
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where dbo.Patients.AdmissionNo>0 and  dbo.TestItems.ReportTypeId <> 63 and  dbo.TestsCost.Status <> 'Cancelled' and dbo.TestsCost.ReportStatus in ('NE', 'OP', 'SC', 'SR', 'SRun', 'RG', 'RV')
                                                                         and Convert(date, dbo.Patients.DeliveryDate)= '{0}' and Convert(Time, dbo.Patients.DeliveryTime) = '{1}' and dbo.TestItems.ReportTypeId = {2}", dtpfrm, _time.TimeOfDay.ToString(), _ReportTypeId);

                    }
                    else if (_ipdOpd == "OPD")
                    {
                        _sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.ReportIdPrefix,dbo.Patients.ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, Convert(date, dbo.Patients.DeliveryDate) DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId,
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where  dbo.Patients.AdmissionNo=0 and  dbo.TestItems.ReportTypeId <> 63 and  dbo.TestsCost.Status <> 'Cancelled' and dbo.TestsCost.ReportStatus in ('NE', 'OP', 'SC', 'SR', 'SRun', 'RG', 'RV')
                                                                         and Convert(date, dbo.Patients.DeliveryDate)= '{0}' and Convert(Time, dbo.Patients.DeliveryTime) = '{1}' and dbo.TestItems.ReportTypeId = {2}", dtpfrm, _time.TimeOfDay.ToString(), _ReportTypeId);

                    }
                    else
                    {
                         _sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.ReportIdPrefix,dbo.Patients.ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, Convert(date, dbo.Patients.DeliveryDate) DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId,
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where  dbo.TestItems.ReportTypeId <> 63 and  dbo.TestsCost.Status <> 'Cancelled' and dbo.TestsCost.ReportStatus in ('NE', 'OP', 'SC', 'SR', 'SRun', 'RG', 'RV')
                                                                         and Convert(date, dbo.Patients.DeliveryDate)= '{0}' and Convert(Time, dbo.Patients.DeliveryTime) = '{1}' and dbo.TestItems.ReportTypeId = {2}", dtpfrm, _time.TimeOfDay.ToString(), _ReportTypeId);

                    }

                    da = new SqlDataAdapter(_sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VMDiagPatientAndTestDetail> listPBills = new List<VMDiagPatientAndTestDetail>();


                    listPBills = new List<VMDiagPatientAndTestDetail>(
                        (from dRow in dt.AsEnumerable()
                         select (GetTestDeliveryScheduleDataTableRow(dRow)))
                        );

                    return listPBills;

                }
                catch (Exception ex)
                {
                    return new List<VMDiagPatientAndTestDetail>();
                }

            }

        }

        public void IsApproveCancelTest(long patientId, int itemId, int userId, string remarks, bool isApprove)
        {
             using(DBEntities entities = new DBEntities())
            {

                try
                {
                    //sql = string.Format($@"update TestsCost set TestsCost.IsCancelApprove = 1  where PatientId = {patientId} and dbo.TestsCost.TestId = {itemId}");
                    //var result =    entities.TestsCosts.SqlQuery(sql);




                    sql = string.Format($@"update TestsCost set IsCancelApprove = 1  where PatientId = {patientId} and TestId = {itemId}; Update Patients Set CancelRemarks='{remarks}' Where PatientId={patientId}"
                                       );
                    var result = entities.Database.SqlQuery<TestsCost>(sql).ToList();


                }
                catch(Exception ex) { 
                }
            }
        }

        public OPDPatientRecord OPDPatientRecord(long billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDPatientRecords.Where(x => x.BillNo == billNo).FirstOrDefault();
            }
        }

        public OPDPatientRecord OPDPatientRecordByIdNo(long pId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDPatientRecords.Where(x => x.PatientId == pId).FirstOrDefault();
            }
        }

        public List<VMDiagPatientAndTestDetail> GetDiagDeliveredTestDetailByDateAndTime(DateTime dtpfrm, DateTime _time, int _ReportTypeId, string _IpdOpd)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {

                    string _sql = string.Empty;

                    if (_IpdOpd == "IPD")
                    {
                        _sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.ReportIdPrefix,dbo.Patients.ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, Convert(date, dbo.Patients.DeliveryDate) DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId,
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where dbo.Patients.AdmissionNo>0 and  dbo.TestItems.ReportTypeId <> 63 and  dbo.TestsCost.Status <> 'Cancelled' and dbo.TestsCost.ReportStatus in ('RP','RD')
                                                                         and Convert(date, dbo.Patients.DeliveryDate)= '{0}' and Convert(Time, dbo.Patients.DeliveryTime) = '{1}' and dbo.TestItems.ReportTypeId = {2}", dtpfrm, _time.TimeOfDay.ToString(), _ReportTypeId);
                    }
                    else if (_IpdOpd == "OPD")
                    {

                        _sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.ReportIdPrefix,dbo.Patients.ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, Convert(date, dbo.Patients.DeliveryDate) DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId,
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where dbo.Patients.AdmissionNo=0 and dbo.TestItems.ReportTypeId <> 63 and  dbo.TestsCost.Status <> 'Cancelled' and dbo.TestsCost.ReportStatus in ('RP','RD')
                                                                         and Convert(date, dbo.Patients.DeliveryDate)= '{0}' and Convert(Time, dbo.Patients.DeliveryTime) = '{1}' and dbo.TestItems.ReportTypeId = {2}", dtpfrm, _time.TimeOfDay.ToString(), _ReportTypeId);
                    }
                    else
                    {

                         _sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.ReportIdPrefix,dbo.Patients.ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, Convert(date, dbo.Patients.DeliveryDate) DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId,
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where  dbo.TestItems.ReportTypeId <> 63 and  dbo.TestsCost.Status <> 'Cancelled' and dbo.TestsCost.ReportStatus in ('RP','RD')
                                                                         and Convert(date, dbo.Patients.DeliveryDate)= '{0}' and Convert(Time, dbo.Patients.DeliveryTime) = '{1}' and dbo.TestItems.ReportTypeId = {2}", dtpfrm, _time.TimeOfDay.ToString(), _ReportTypeId);
                    }

                    da = new SqlDataAdapter(_sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VMDiagPatientAndTestDetail> listPBills = new List<VMDiagPatientAndTestDetail>();


                    listPBills = new List<VMDiagPatientAndTestDetail>(
                        (from dRow in dt.AsEnumerable()
                         select (GetTestDeliveryScheduleDataTableRow(dRow)))
                        );

                    return listPBills;

                }
                catch (Exception ex)
                {
                    return new List<VMDiagPatientAndTestDetail>();
                }

            }



        }

        public bool IsAnyDueInInvestigationDone(VMIPDInfo ipdPatient)
        {
            using (DBEntities entities = new DBEntities())
            {
                var transactions = entities.PatientLedgers.SqlQuery("Select * from PatientLedger Where PatientId in (Select PatientId from Patients Where AdmissionNo={0})", ipdPatient.BillNo).ToList();
                if (transactions.Count() == 0) return false;

                double bal = transactions.Sum(item => item.Debit) - transactions.Sum(item => item.Credit);
                if (bal > 0) return true;

                return false;
            }
        }

        public bool GetApproveByAdminCheck(long patientId)
        {
            using(DBEntities entities = new DBEntities())
            {

                sql = string.Format($@"select * from TestsCost where TestsCost.IsCancelApprove = 0 and TestsCost.PatientId = {patientId}");
                var result = entities.Database.SqlQuery<TestsCost>(sql).ToList() ;

                if(result.Count > 0)
                {
                    return false;
                }
                return true;
            }
        }

        public void IsApproveCancelPatient(long patientId, int userId, string remarks, bool isApprove)
        {
            using(DBEntities entities = new DBEntities())
            {

                try
                {
                    sql = string.Format($@"update TestsCost set IsCancelApprove = 1  where PatientId = {patientId}; Update Patients Set CancelRemarks='{remarks}' Where PatientId={patientId}"
                                        );
                    var result = entities.Database.SqlQuery<TestsCost>(sql).ToList();

                }
                catch(Exception ex)
                {

                }
            }
        }

        public List<VMRfCommission> GetMediaDiscountByPatientId(long patientId, int mediaId)
        {
            using(DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"select 
  bs.Name as MediaName, 
  bs.MediaId, 
 -- mc.CategoryName, 
  p.BillNo, 

  sum(pl.Credit) as Credit, 
  pl.Debit, 
  pl.TranDate, 
  p.PatientId, 
  pl.Particulars, 
  pl.OperateBy, 
  pl.TransactionType 
from 
  BusinessMedias as bs 
 -- inner join MediaCategories as mc ON bs.CategoryId = mc.CategoryId 
  --inner join MediaCategoryReportTypeCommissions as mrc On mc.CategoryId = mrc.CategoryId 
  inner join Patients as p On p.MediaId = bs.MediaId 
  inner join PatientLedger as pl On pl.PatientId = p.PatientId 
  --inner join TestsCost as tsc On p.PatientId = tsc.PatientId  and pl.PatientId = p.PatientId
where 
  pl.TransactionType In(
    'DiscountOnRegularCollection', 'DiscountOnDueCollection'
  ) 
  and bs.MediaId = {1} 
  and p.PatientId = {0}

  group by   bs.Name , 
  bs.MediaId, 
 -- mc.CategoryName, 
  p.BillNo, 


  pl.Debit, 
  pl.TranDate, 
  p.PatientId, 
  pl.Particulars, 
  pl.OperateBy, 
  pl.TransactionType ", patientId, mediaId);

                try
                {
                    List<VMRfCommission> vMRfCommissions = entities.Database.SqlQuery<VMRfCommission>(sql).ToList();

                    return vMRfCommissions;

                }catch(Exception ex)
                {
                    return null;
                }

            }
        }

        public List<VMRfCommission> GetRfCommissionWithMeidaId(long patientId, int mediaId)
        {
            using(DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"SELECT 
        distinct tis.TestId
,ts.Cost
	
	,mec.CategoryName
	,mec.CategoryId
	,bs.MediaId
	,bs.Name AS MediaName
	,mcrc.Commission
	,mcrc.CommissionPercent
	,mcrc.IsPercent
	,CASE 
		WHEN mcrc.Commission > 0
			AND mcrc.IsPercent = 0
			THEN Commission
		WHEN mcrc.CommissionPercent > 0
			AND mcrc.IsPercent = 1
			THEN ts.Cost * mcrc.CommissionPercent / 100
		END TotalCommission
FROM Patients AS p
INNER JOIN TestsCost AS ts ON ts.PatientId = p.PatientId
INNER JOIN BusinessMedias AS bs ON bs.MediaId = p.MediaId
INNER JOIN MediaCategories AS mec ON mec.CategoryId = bs.CategoryId
INNER JOIN MediaCategoryReportTypeCommissions AS mcrc ON mcrc.CategoryId = mec.CategoryId
INNER JOIN ReportTypes AS rpt ON rpt.ReportTypeId = mcrc.ReportTypeId
INNER JOIN TestItems AS tis ON rpt.ReportTypeId = tis.ReportTypeId
	AND tis.TestId = ts.TestId
WHERE p.PatientId = {0}
	AND bs.MediaId = {1}", patientId, mediaId);

                try
                {
                    List<VMRfCommission> vMRfCommissions = entities.Database.SqlQuery<VMRfCommission>(sql).ToList();
                    return vMRfCommissions;
                }
                catch(Exception ex)
                {
                    return null;
                }

                

            }
        }

        public Patient GetRfommission(long patientId)
        {
            using(DBEntities entities = new DBEntities())
            {
                try
                {
                    Patient patient = entities.Patients.Where(x => x.PatientId == patientId).FirstOrDefault();
                    return patient;
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool UpdatePatinetMediaId(long patientId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"update Patients set MediaId  =  0  Where PatientId={0}", patientId);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    return true;
                }
                catch
                {
                    //con.Close();
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private VMDiagPatientAndTestDetail GetTestDeliveryScheduleDataTableRow(DataRow dr)
        {
            VMDiagPatientAndTestDetail _data = new VMDiagPatientAndTestDetail();
            _data.BillNo = Convert.ToInt64(dr["BillNo"]);
            _data.ReportId = dr["ReportIdPrefix"].ToString() + dr["ReportId"].ToString();
            _data.Name = dr["Name"].ToString();
            _data.TestName = dr["TestName"].ToString();
            _data.EntryDate = Convert.ToDateTime(dr["EntryDate"]);
            _data.EntryTime = dr["EntryTime"].ToString();
            _data.DeliveryDate = Convert.ToDateTime(dr["DeliveryDate"]);
            _data.DeliveryTime = dr["DeliveryTime"].ToString();
            _data.ReportStatus = dr["ReportStatus"].ToString();

            return _data;
        }

        public bool UpdateOPdPatientInfo(OPDPatientRecord oPDPatient)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(oPDPatient).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public async Task<List<Patient>> GetSampleCollecTablePatientList(DateTime _EntryDate)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var _entryDate = new SqlParameter("@EntryDate", _EntryDate.Date);
                    var _collectionStatus = new SqlParameter("@CS", SampleCollectionStatusEnum.NC.ToString());

                    return await entities.Database.SqlQuery<Patient>(@" exec spGetSampleCollection @EntryDate,@CS", _entryDate, _collectionStatus).ToListAsync();
                                        
                }
                catch (Exception ex)
                {
                    return  await Task.FromResult(new List<Patient>());
                }


            }
        }

        public double GetDrDiscountAmount(long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var transactions = entities.PatientLedgers.SqlQuery("Select * from PatientLedger Where PatientId={0} and TransactionType in('DrDiscountOnRegularCollection','DrDiscountOnDueCollection')", patientId).ToList();
                if (transactions.Count() == 0) return 0;

                return transactions.Sum(item => item.Credit);
            }
        }

        public List<Patient> GetDiagPatientsByHpBillNo(long hpbill)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.Where(x=>x.AdmissionNo== hpbill).ToList();
            }
        }

        public List<VMRequestOnDischargedResult> GetInvestigationsOnDischarge(long billNo)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format(@"Exec SP_InvestigationResultOnDischarge {0}", billNo);
                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VMRequestOnDischargedResult> invList = new List<VMRequestOnDischargedResult>();


                    invList = new List<VMRequestOnDischargedResult>(
                        (from dRow in dt.AsEnumerable()
                         select (GetInvestigationDataTableRowOnDischarge(dRow)))
                        );

                    return invList;

                }
                catch (Exception ex)
                {
                    return new List<VMRequestOnDischargedResult>();
                }

            }
        }

        private VMRequestOnDischargedResult GetInvestigationDataTableRowOnDischarge(DataRow dr)
        {
            VMRequestOnDischargedResult Obj = new VMRequestOnDischargedResult();
            Obj.EntryDate = Convert.ToDateTime(dr["EntryDate"]);
            Obj.TestName = dr["Name"].ToString();
            Obj.TestResult = dr["TestResult"].ToString();

            return Obj;
        }

        public List<VMDiagPatient> GetDiagPatientByDate(DateTime dtp1,string _type)
        {
            var _entryDate = new SqlParameter("@EntryDate", dtp1.ToShortDateString());

            using (DBEntities entities = new DBEntities())
            {

                if (_type == "All")
                {
                    return entities.Database.SqlQuery<VMDiagPatient>(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo,  dbo.Patients.ReportIdPrefix+Convert(NVARCHAR(50),ReportId) as ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, 
                                                                   dbo.Doctor.Name AS RefdBy FROM dbo.Patients INNER JOIN
                                                                   dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                   dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId
                                                                   Where EntryDate=@EntryDate order by ReportId Desc", _entryDate).ToList();
                }else if (_type == "IPD")
                {
                    return entities.Database.SqlQuery<VMDiagPatient>(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo,  dbo.Patients.ReportIdPrefix+Convert(NVARCHAR(50),ReportId) as ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, 
                                                                   dbo.Doctor.Name AS RefdBy FROM dbo.Patients INNER JOIN
                                                                   dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                   dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId
                                                                   Where dbo.Patients.AdmissionNo>0 and EntryDate=@EntryDate order by ReportId Desc", _entryDate).ToList();
                }else
                {

                    return entities.Database.SqlQuery<VMDiagPatient>(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo,  dbo.Patients.ReportIdPrefix+Convert(NVARCHAR(50),ReportId) as ReportId, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, 
                                                                   dbo.Doctor.Name AS RefdBy FROM dbo.Patients INNER JOIN
                                                                   dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                   dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId
                                                                   Where dbo.Patients.AdmissionNo=0 and EntryDate=@EntryDate order by ReportId Desc", _entryDate).ToList();
                }
            }
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPatientAndTestDetailByDate(DateTime dtp1)
        {
            var _entryDate = new SqlParameter("@EntryDate", dtp1.ToShortDateString());
            
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMDiagPatientAndTestDetail>(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId, 
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where EntryDate=@EntryDate", _entryDate).ToList();
            }
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPatientAndTestDetailByBillNo(long billNo)
        {
            var _billNo = new SqlParameter("@BillNo", billNo);

            using (DBEntities entities = new DBEntities())
            {

                try
                {
                    var sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.RegNo, dbo.Patients.BillNo, dbo.Patients.EntryDate, dbo.Patients.EntryTime, dbo.Patients.DeliveryDate, dbo.Patients.DeliveryTime, dbo.RegRecords.FullName as Name, dbo.TestsCost.TestId,  dbo.TestsCost.ReportDeliveredBy,
                                                                         dbo.TestItems.Name AS TestName, dbo.TestsCost.ReportStatus, dbo.Doctor.Name AS RefdBy
                                                                         FROM dbo.Patients INNER JOIN dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                                                                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                                                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                                                                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId Where dbo.Patients.PatientId={0} and dbo.TestItems.ReportTypeId<>63 and  dbo.TestsCost.Status<>'Cancelled' and dbo.TestsCost.ReportStatus in ('NE','OP','SC','SR','SRun','RG','RV','RP','RD')", billNo);



                    return entities.Database.SqlQuery<VMDiagPatientAndTestDetail>(sql).ToList();


                }
                catch(Exception ex)
                {
                    return null;
                }

            }
        }

        public Patient GetPatientByIdNo(long PatientId)
        {
            using (DBEntities entity = new DBEntities())
            {
                //int _PatientId = Convert.ToInt32(PatientId);
                return entity.Patients.Where(x => x.PatientId == PatientId).FirstOrDefault();
            }
        }

        public List<PatientLedger> GetPatientLedgerById(long RegNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PatientLedgers.Where(x => x.PatientId == RegNo).OrderBy(y => y.Id).ToList();
            }
        }

      

        public List<TestsCost> GetSampleCollectedTests(long _pId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestsCosts.Where(x => x.PatientId == _pId && x.ReportStatus==ReportStatusEnum.SC.ToString()).ToList();
               
            }
        }

        public bool UpdatePatientInfo(Patient _PatinetInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_PatinetInfo).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public List<Patient> GetIndoorPatientList()
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.Patients.Where(x=>x.AdmissionNo>0).ToList();
            }
        }

        public int GetLastRegistrtionNo()
        {
            using (DBEntities entity = new DBEntities())
            {
                IList<Patient> list = entity.Patients.ToList();
                if (list.Count == 0) return 0;
                return (int)list[list.Count - 1].PatientId;
            }
        }

        public Patient GetPatientByReportPrefixAndId(string _prefix, long _reportId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.Where(x => x.ReportIdPrefix== _prefix && x.ReportId== _reportId).FirstOrDefault();
            }
        }

        public int GetLastDailyId(DateTime date)
        {
            using (DBEntities entity = new DBEntities())
            {
                IList<Patient> list = entity.Patients.Where(x => (date.Year == x.EntryDate.Year
                && date.Month == x.EntryDate.Month
                && date.Day == x.EntryDate.Day)).ToList();
                if (list.Count == 0) return 1;
                return (int)list[list.Count - 1].DailyId + 1;
                

            }
        }

        public Patient GetDiagPatientById(long _pId)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Patients.Where(x => x.PatientId == _pId).FirstOrDefault();
            }
        }

        public void SetUSGDoctorOnDailyStatement(string _regNo, ReportConsultant _doctor)
        {
            Int32 regNo = 0;
            int.TryParse(_regNo, out regNo);
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {

                    sql = string.Format(@"Update DailyStatement Set USGDoctor='{0}' Where PatientId={1}", _doctor.Name, regNo);
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //return true;
                }
                catch
                {
                    con.Close();
                    //return false;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private Patient GetPatientByRegNoConvertedFromDataTable(DataRow dr)
        {
             Patient _patient = new Patient();
            _patient.PatientId = Convert.ToInt32(dr["PatientId"]);
            _patient.DailyId = Convert.ToInt32(dr["DailyId"]);
           
            _patient.DoctorId = Convert.ToInt32(dr["RefbyId"]);
            _patient.EntryDate = Convert.ToDateTime(dr["EntryDate"]);


            return _patient;
        }

        public List<Patient> GetPatientIdsByRegNo(long regNo)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format(@"Select * from Patients Where RegNo={0}", regNo);
                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<Patient> listPBills = new List<Patient>();


                    listPBills = new List<Patient>(
                        (from dRow in dt.AsEnumerable()
                         select (GetPatintDataTableRow(dRow)))
                        );

                    return listPBills;

                }
                catch (Exception ex)
                {
                    return new List<Patient>();
                }

            }
        }

        private Patient GetPatintDataTableRow(DataRow dr)
        {
            Patient _p = new Patient();
            _p.BillNo = Convert.ToInt64(dr["BillNo"]);
            _p.PatientId = Convert.ToInt64(dr["PatientId"]);
            _p.DoctorId = Convert.ToInt32(dr["DoctorId"]);
            _p.EntryDate = Convert.ToDateTime(dr["EntryDate"]);
            _p.EntryTime = dr["EntryTime"].ToString();

            return _p;
        }

        public Patient GetPatientByRegNoFromLegacy(string id)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter("select * from Patients where PatientId=" + id.ToString(), con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                return GetPatientByRegNoConvertedFromDataTable(dt.Rows[0]);
            }
            catch(Exception ex) {
                return null;
            }
            
        }

        public double GetPaidTk(long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var transactions = entities.PatientLedgers.SqlQuery("Select * from PatientLedger Where PatientId={0} and TransactionType in('OnEntryPayment','DueCollection')", patientId).ToList();
                if (transactions.Count() == 0) return 0;

                return transactions.Sum(item => item.Credit);
            }
        }

        public List<TestGroup> GetTestGroupsByPatientId(long _PId)
        {
            using (DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"Select * from TestGroups Where  TestGroupId IN (SELECT        dbo.ReportTypes.TestGroupId FROM dbo.TestsCost INNER JOIN
                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId INNER JOIN
                         dbo.ReportTypes ON dbo.TestItems.ReportTypeId = dbo.ReportTypes.ReportTypeId INNER JOIN
                         dbo.TestGroups ON dbo.ReportTypes.TestGroupId = dbo.TestGroups.TestGroupId
                         WHERE (dbo.TestsCost.PatientId = {0}))", _PId);
                return entities.TestGroups.SqlQuery(sql).ToList();
            }
        }

        public Patient GetPatientByBillNo(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.Where(x => x.PatientId == _billNo).FirstOrDefault();
            }
        }

        public List<TestsCost> GetTestList(long _PatientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestsCosts.Where(x => x.PatientId == _PatientId).ToList();
            }
        }

        public List<OPDPatientLedgerRough> GetOPDPatientLedgerRoughById(long _PId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDPatientLedgerRoughs.Where(x => x.PatientId == _PId).ToList();
            }
        }

        public double GetDiscountAmount(long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var transactions = entities.PatientLedgers.SqlQuery("Select * from PatientLedger Where PatientId={0} and TransactionType in('DiscountOnRegularCollection','DiscountOnDueCollection')", patientId).ToList();
                if (transactions.Count() == 0) return 0;

                return transactions.Sum(item => item.Credit);
            }
        }

        public Patient GetLastReceivedPatientByUser(int _userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.SqlQuery("Select * from Patients Where PatientId=(Select Max(PatientId) as mpId from Patients Where UserId={0})", _userId).FirstOrDefault();
            }
        }

        public Patient GetFirstReceivedPatientByUser(int _userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.SqlQuery("Select * from Patients Where PatientId=(Select Min(PatientId) as mpId from Patients Where UserId={0})", _userId).FirstOrDefault();
            }
        }

        public string GetNextRegNo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.ToList().Count().ToString();
            }
        }

        public int GetNextServiceId(long regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.Where(x => x.RegNo == regNo).ToList().Count();
            }
        }

        public int GetDailyId(DateTime dateTime)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.ToList().Where(x => x.EntryDate.ToString("MM/dd/yyyy") == dateTime.ToString("MM/dd/yyyy")).ToList().Count();
            }
        }

        public bool IsBillNoAlloted(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                int count = entities.Patients.Where(x => x.BillNo == _billNo).ToList().Count();

                if (count > 0) return true;

                return false;
            }
        }

        public int GetReportIdForThisPatient()
        {
            using (DBEntities entity = new DBEntities())
            {
                IList<Patient> list = entity.Patients.Where(x =>x.ReportIdPrefix=="A").ToList();
                if (list.Count == 0) return 1;
                return (int)list[list.Count - 1].ReportId + 1;


            }
        }

        public Patient GetPatientBySerial(long serial)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.Where(x => x.PatientId == serial).FirstOrDefault();
            }
        }

        public bool CancelTest(long _regNo, int _itemId, int _UserId, string remarks)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Update  TestsCost Set Status='Cancelled',UserId={0} Where PatientId={1} and TestId={2}", _UserId, _regNo, _itemId);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    sql = string.Format(@"Update Patients Set CancelRemarks='{0}' Where PatientId={1}", remarks, _regNo);
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();


                    return true;
                }
                catch
                {
                    con.Close();
                    return false;
                }

            }
        }

        public List<VWTestItem> GetTestItemsByPatientId(long patientId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format(@"SELECT dbo.TestsCost.TestId, dbo.TestsCost.PatientId, dbo.TestItems.Name,dbo.TestItems.ReportTypeId,dbo.Patients.BillNo, dbo.Patients.DoctorId
                                          FROM  dbo.TestItems INNER JOIN
                                          dbo.TestsCost ON dbo.TestItems.TestId = dbo.TestsCost.TestId INNER JOIN
                                          dbo.Patients ON dbo.TestsCost.PatientId = dbo.Patients.PatientId Where dbo.Patients.PatientId={0} and TestItems.ReportTypeId<>63", patientId);
                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VWTestItem> listTItems = new List<VWTestItem>();


                    listTItems = new List<VWTestItem>(
                        (from dRow in dt.AsEnumerable()
                         select (GetPatintTestDataTableRow(dRow)))
                        );

                    return listTItems;

                }
                catch (Exception ex)
                {
                    return new List<VWTestItem>();
                }

            }
        }

        private VWTestItem GetPatintTestDataTableRow(DataRow dr)
        {
            VWTestItem _ti = new VWTestItem();
            _ti.BillNo = Convert.ToInt64(dr["BillNo"]);
            _ti.PatientId = Convert.ToInt64(dr["PatientId"]);
            _ti.TestId = Convert.ToInt32(dr["TestId"]);
            _ti.ReportTypeId = Convert.ToInt32(dr["ReportTypeId"]);
            _ti.TestName = dr["Name"].ToString();
            _ti.RefdId = Convert.ToInt32(dr["DoctorId"]);
            return _ti;
        }

        public double GetCurrentBalance(long _pId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Select Sum(Credit-Debit) as cBalance from  PatientLedger Where PatientId={0}", _pId);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());

                }
                catch
                {
                    con.Close();
                    return 0;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        

        public bool UpdateHospitalPatientInfo(Patient _PatinetInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_PatinetInfo).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool CancelPatient(long _regNo, string __operatorName, string remarks)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Update TestsCost Set Status='Cancelled' Where PatientId={0}", _regNo);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    sql = string.Format(@"Update Patients Set Status='{0}',Cancelledby='{1}', CancelRemarks='{3}' Where PatientId={2}", PatientStatusEnum.Cancelled.ToString(), __operatorName, _regNo, remarks);
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    //con.Close();
                    return false;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public PatientLedger GetPatientLedger(long _pId, string _transactionType)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PatientLedgers.Where(x => x.PatientId == _pId && x.TransactionType == _transactionType).FirstOrDefault();
            }
        }

        public VMPatientPaymentInfo GetPatientPaymentInfo(int RegNo)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter("select * from VWDiagPatientStatement where PatientId=" + RegNo.ToString(), con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                return GetPatientPaymentInfoConvertedFromDataTable(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private Model.ViewModel.VMPatientPaymentInfo GetPatientPaymentInfoConvertedFromDataTable(DataRow dr)
        {
            VMPatientPaymentInfo _patientpayment = new VMPatientPaymentInfo();
            _patientpayment.PatientId = Convert.ToInt32(dr["PatientId"]);
            _patientpayment.TestsCost = Convert.ToDouble(dr["TestAmount"]);
            _patientpayment.PaidTk = Convert.ToDouble(dr["PaidAmount"]);
            _patientpayment.discountTk = Convert.ToDouble(dr["Discount"]);
            _patientpayment.DueTk = Convert.ToDouble(dr["DueAmount"]);
           
            return _patientpayment;
        }

        public Patient GetPatientByRxId(long _RxId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.Where(x => x.RxId == _RxId).FirstOrDefault();
            }
        }

        public double GetGroupAmountFromDailyStatementByPatientId(long _regNo, string _headerName)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Select " + _headerName + " as groupAmount from  DailyStatement Where PatientId={0}", _regNo);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());

                }
                catch
                {
                    con.Close();
                    return 0;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public void SetDuecollectionDateOnDailyStatement(long regNo)
        {
            string customFmts = "dd/MM/yyyy";
            string _date = "Collected On " + DateTime.Now.ToString(customFmts);
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {

                    sql = string.Format(@"Update DailyStatement Set DueCollectedOn='{0}' Where PatientId={1}", _date, regNo);
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //return true;
                }
                catch
                {
                    con.Close();
                    //return false;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public double GetDueAmountFromDailyStatementByPatientId(long _regNo)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Select Due as tDue from  DailyStatement Where PatientId={0}", _regNo);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());

                }
                catch
                {
                    con.Close();
                    return 0;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public void AdjustDailyStatement(long _regNo, string testGroup, double _groupAmount, double _dueAmount)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {

                    sql = string.Format(@"Update DailyStatement Set " + testGroup + "='{0}', Due='{1}' Where PatientId={2}", _groupAmount, _dueAmount, _regNo);
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //return true;
                }
                catch
                {
                    con.Close();
                    //return false;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public void SetDueOnDailyStatement(int regNo, double _due, double _less)
        {
            DailyStatement _ds = GetDailyStatementByPatientId(regNo);

            _less = _less + _ds.Less;

            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {

                    sql = string.Format(@"Update DailyStatement Set Due={0},Less={1} Where PatientId={2}", _due, _less, regNo);
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //return true;
                }
                catch
                {
                    con.Close();
                    //return false;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public DailyStatement GetDailyStatementByPatientId(int PId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.DailyStatement.Where(x => x.PatientId == PId).FirstOrDefault();
            }
        }

       
    }
}
