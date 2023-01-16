using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;
using System.Data.SqlClient;
using HDMS.Common.Utils;
using System.Data;
using System.Data.Entity;
using HDMS.Model.Enums;
using HDMS.Model;
using HDMS.Model.Diagnostic.VM;

namespace HDMS.Repository.OPD
{
    public class OPDPatientRepository
    {
        string sql = string.Empty;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;

        public VMOPDPatientRecord GetOPDInfoById(long _patientId)
        {
            try
            {
                sql = string.Format(@"SELECT dbo.OPDPatientRecords.RegNo, dbo.OPDPatientRecords.PatientId, dbo.OPDPatientRecords.BillNo, dbo.OPDPatientRecords.EntryDate, dbo.OPDPatientRecords.EntryTime, dbo.OPDPatientRecords.Status, 
                                      dbo.RegRecords.FullName AS Name, 
                                    CASE WHEN dbo.OPDPatientRecords.AgeYear <> '' THEN dbo.OPDPatientRecords.AgeYear + 'Y ' ELSE dbo.OPDPatientRecords.AgeYear END + CASE WHEN dbo.OPDPatientRecords.AgeMonth <> '' THEN dbo.OPDPatientRecords.AgeMonth
                                   + 'M ' ELSE dbo.OPDPatientRecords.AgeMonth END + CASE WHEN dbo.OPDPatientRecords.AgeDay <> '' THEN dbo.OPDPatientRecords.AgeDay + 'D' ELSE dbo.OPDPatientRecords.AgeDay END AS Age, 
                                   dbo.RegRecords.MobileNo FROM dbo.OPDPatientRecords INNER JOIN
                                   dbo.RegRecords ON dbo.OPDPatientRecords.RegNo = dbo.RegRecords.RegNo
                                    WHERE  (dbo.OPDPatientRecords.PatientId={0} and dbo.OPDPatientRecords.Status = 'UnderService')", _patientId);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

            

                return GetOPDPatientDataTableRow(dt.Rows[0]);
                
            }
            catch (Exception ex)
            {
                return new VMOPDPatientRecord();
            }
        }

        public DisplaySetting GetDisplaySetting()
        {
            using (DBEntities entites = new DBEntities())
            {
                return entites.DisplaySettings.ToList().FirstOrDefault();

            }
        }

        public OPDPatientRecord GetLastReceivedPatientByUser(int _userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDPatientRecords.SqlQuery("Select * from OPDPatientRecords Where PatientId=(Select Max(PatientId) as mpId from OPDPatientRecords Where UserId={0})", _userId).FirstOrDefault();
            }
        }

        public OPDPatientRecord GetFirstReceivedPatientByUser(int _userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDPatientRecords.SqlQuery("Select * from OPDPatientRecords Where PatientId=(Select Min(PatientId) as mpId from OPDPatientRecords Where UserId={0})", _userId).FirstOrDefault();
            }
        }

        public OPDPatientRecord GetOPDPatientByBillNo(long billNo)
        {
            using (DBEntities entites = new DBEntities())
            {
                return entites.OPDPatientRecords.Where(x => x.BillNo == billNo).FirstOrDefault();

            }
        }

        public List<OPDPatientLedgerRough> GetOPDPatientLedgerRough(long patientId)
        {
            using (DBEntities entites = new DBEntities())
            {
                return entites.OPDPatientLedgerRoughs.Where(x=>x.PatientId== patientId).ToList();

            }
        }

        public DataSet GetConsultancyServiceList(long patientId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.OPDPatientRecords.PatientId, dbo.OPDPatientRecords.BillNo, dbo.OPDServiceCosts.ServiceOrConsultantId, dbo.OPDServiceCosts.Qty, dbo.OPDServiceCosts.Rate, dbo.OPDServiceCosts.TAmount, 
                         dbo.OPDServiceGroups.Name AS ServiceGroup, dbo.OPDPatientVisitTypes.VisitType, dbo.Doctor.Name AS Consultant, 
                         dbo.OPDServiceGroups.Name + '-' + dbo.OPDPatientVisitTypes.VisitType + ' (' + dbo.Doctor.Name + ')' AS ServiceName, dbo.OPDPatientRecords.GroupId, dbo.OPDPatientRecords.VisitTypeId, dbo.OPDPatientRecords.Status, 
                         dbo.[User].LoginName
                         FROM  dbo.OPDPatientRecords INNER JOIN
                         dbo.OPDServiceCosts ON dbo.OPDPatientRecords.PatientId = dbo.OPDServiceCosts.PatientId INNER JOIN
                         dbo.OPDServiceGroups ON dbo.OPDPatientRecords.GroupId = dbo.OPDServiceGroups.GroupId INNER JOIN
                         dbo.OPDPatientVisitTypes ON dbo.OPDPatientRecords.VisitTypeId = dbo.OPDPatientVisitTypes.VisitTypeId INNER JOIN
                         dbo.Doctor ON dbo.OPDServiceCosts.ServiceOrConsultantId = dbo.Doctor.DoctorId INNER JOIN
                         dbo.[User] ON dbo.OPDPatientRecords.UserId = dbo.[User].UserId  Where dbo.OPDPatientRecords.PatientId={0}", patientId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsConsultancyServices = new DataSet();
                da.Fill(dsConsultancyServices);

                dsConsultancyServices.DataSetName = "dsConsultancyService";
                dsConsultancyServices.Tables[0].TableName = "dtConsultancyService";


                return dsConsultancyServices;

            }
        }

        public Task<List<VMDiagPatientBasicInfo>> GetOPDPatienInfo(DateTime dtfrm, DateTime dtto)
        {
            return Task.Run(() =>
            {
                using (DBEntities entites = new DBEntities())
                {

                    try
                    {

                        return entites.Database.SqlQuery<VMDiagPatientBasicInfo>("exec spGetOPDPaientBasicInfo @dtfrm,@dtto", new SqlParameter("@dtfrm", dtfrm.Date), new SqlParameter("@dtto", dtto.Date)).ToList();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            });
        }

        public OPDPatientRecord GetPatientByPatientId(long billNo)
        {
            using (DBEntities entites = new DBEntities())
            {
                return entites.OPDPatientRecords.Where(x => x.PatientId == billNo).FirstOrDefault();

            }
        }

        public bool UpdatePatientSerialStatus(PractitionerWisePatientSerial pat)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(pat).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool CancelService(long patientId, int itemId, int groupId, int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Database.ExecuteSqlCommand(@"Update OPDServiceCosts Set Status='Cancelled' Where PatientId={0} and ServiceOrConsultantId={1}", new object[] { patientId, itemId });
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool CancelPatient(long patientId, string cancelledby)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Update OPDServiceCosts Set Status='Cancelled' Where PatientId={0}", patientId);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    sql = string.Format(@"Update OPDPatientRecords Set Status='{0}',Cancelledby='{1}' Where PatientId={2}", PatientStatusEnum.Cancelled.ToString(), cancelledby, patientId);
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

        public DataSet GetOPDServiceListExceptConsultancy(long patientId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.OPDPatientRecords.PatientId, dbo.OPDPatientRecords.BillNo, dbo.OPDServiceCosts.ServiceOrConsultantId, dbo.OPDServiceCosts.Qty, dbo.OPDServiceCosts.Rate, dbo.OPDServiceCosts.TAmount, 
                         dbo.OPDServiceGroups.Name AS ServiceGroup, sh.ServiceHeadName as ServiceName, 
                         dbo.OPDPatientRecords.GroupId, dbo.OPDPatientRecords.VisitTypeId, dbo.OPDPatientRecords.Status, 
                         dbo.[User].LoginName
                         FROM  dbo.OPDPatientRecords INNER JOIN
                         dbo.OPDServiceCosts ON dbo.OPDPatientRecords.PatientId = dbo.OPDServiceCosts.PatientId INNER JOIN
                         dbo.OPDServiceGroups ON dbo.OPDPatientRecords.GroupId = dbo.OPDServiceGroups.GroupId INNER JOIN
                         OPDServiceHeads sh on sh.ServiceHeadId= dbo.OPDServiceCosts.ServiceOrConsultantId Join
                         dbo.[User] ON dbo.OPDPatientRecords.UserId = dbo.[User].UserId  Where dbo.OPDPatientRecords.PatientId={0} and dbo.OPDServiceCosts.Status<>'Cancelled'", patientId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsConsultancyServices = new DataSet();
                da.Fill(dsConsultancyServices);

                dsConsultancyServices.DataSetName = "dsOPDService";
                dsConsultancyServices.Tables[0].TableName = "dtOPDService";


                return dsConsultancyServices;

            }
        }

        public List<OPDPatientVisitType> GetVisitTypes()
        {
            using (DBEntities entites = new DBEntities())
            {
                return entites.OPDPatientVisitTypes.ToList();

            }
        }

        public void UpdateOPDPatientInfo(OPDPatientRecord _PInfo)
        {
            using (DBEntities entites = new DBEntities())
            {
                entites.Entry(_PInfo).State=EntityState.Modified;
                entites.SaveChanges();
            }
        }

        public void SaveTestsCost(List<OPDServiceCost> serviceCosts)
        {
            using (DBEntities entites= new DBEntities())
            {
                entites.OPDServiceCosts.AddRange(serviceCosts);
                entites.SaveChanges();
            }
        }

        public long SavePatient(OPDPatientRecord patient)
        {
            using (DBEntities entites = new DBEntities())
            {

                try
                {

                    entites.OPDPatientRecords.Add(patient);
                    entites.SaveChanges();

                    return patient.PatientId;

                }catch(Exception ex)
                {
                    return 0;
                }
            }
        }

        public List<VMOPDPatientRecord> GetOPDPatientsUnderService()
        {

            try
            {
                sql = string.Format(@"SELECT dbo.OPDPatientRecords.RegNo, dbo.OPDPatientRecords.PatientId, dbo.OPDPatientRecords.BillNo, dbo.OPDPatientRecords.EntryDate, dbo.OPDPatientRecords.EntryTime, dbo.OPDPatientRecords.Status, 
                                      dbo.RegRecords.FullName AS Name, 
                                    CASE WHEN dbo.OPDPatientRecords.AgeYear <> '' THEN dbo.OPDPatientRecords.AgeYear + 'Y ' ELSE dbo.OPDPatientRecords.AgeYear END + CASE WHEN dbo.OPDPatientRecords.AgeMonth <> '' THEN dbo.OPDPatientRecords.AgeMonth
                                   + 'M ' ELSE dbo.OPDPatientRecords.AgeMonth END + CASE WHEN dbo.OPDPatientRecords.AgeDay <> '' THEN dbo.OPDPatientRecords.AgeDay + 'D' ELSE dbo.OPDPatientRecords.AgeDay END AS Age, 
                                   dbo.RegRecords.MobileNo FROM dbo.OPDPatientRecords INNER JOIN
                                   dbo.RegRecords ON dbo.OPDPatientRecords.RegNo = dbo.RegRecords.RegNo
                                    WHERE  (dbo.OPDPatientRecords.Status = 'UnderService')");  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMOPDPatientRecord> listhp = new List<VMOPDPatientRecord>();

                listhp = new List<VMOPDPatientRecord>(
                  (from dRow in dt.AsEnumerable()
                   select (GetOPDPatientDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMOPDPatientRecord>();
            }
        }

        private VMOPDPatientRecord GetOPDPatientDataTableRow(DataRow dr)
        {
            VMOPDPatientRecord _opdpr = new VMOPDPatientRecord();
            _opdpr.RegNo = Convert.ToInt64(dr["RegNo"]);
            _opdpr.PatientId = Convert.ToInt64(dr["PatientId"]);
            _opdpr.BillNo = Convert.ToInt64(dr["BillNo"]);
            _opdpr.EntryDate = Convert.ToDateTime(dr["EntryDate"]);
            _opdpr.EntryTime = dr["EntryTime"].ToString();
            _opdpr.Name = dr["Name"].ToString();
            _opdpr.Age = dr["Age"].ToString();
            _opdpr.MobileNo= dr["MobileNo"].ToString();
            return _opdpr;
        }

        public OPDPatientRecord GetPatientByBillNo(long _billNo)
        {
            using (DBEntities entites = new DBEntities())
            {
              return  entites.OPDPatientRecords.Where(x=>x.BillNo== _billNo).FirstOrDefault();
            }
        }

        public OPDServiceCost GetOPDServiceCost(long patientId)
        {
            using (DBEntities entites = new DBEntities())
            {
                return entites.OPDServiceCosts.Where(x => x.PatientId == patientId).FirstOrDefault();
            }
        }

        public OPDPatientRecord GetOPDPatientById(long _pId)
        {
            using (DBEntities entites = new DBEntities())
            {

                return entites.OPDPatientRecords.Where(x=>x.PatientId == _pId).FirstOrDefault();
               
            }
        }

        public void SavePatientLedger(List<OPDPatientLedger> transactionList)
        {
            using (DBEntities entites = new DBEntities())
            {
                entites.OPDPatientLedgers.AddRange(transactionList);
                entites.SaveChanges();
            }
        }
    }
}
