using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;
using HDMS.Model.Common.VW;
using HDMS.Model.Rx;

namespace HDMS.Repository.Doctors
{
    public class DoctorRepository
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        string sql = string.Empty;
        public IList<Doctor> GetAllDoctors()
        {
            using(DBEntities entities = new DBEntities())
            {
               
                return entities.Doctors.ToList();
            }
        }

        public ReportConsultant GetReportConsultantById(int id)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultants.Where(x => x.RCId == id).FirstOrDefault();
            }
        }

        public CPOffDayCalender GetCPOffDays(ChamberPractitioner prac, DateTime dt)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CPOffDayCalenders.Where(x => x.CpId == prac.CPId && x.MonthlyOffDate == dt.Date).FirstOrDefault();

            }
        }

        public ChamberPractitioner GetChamberPractitionerById(int chamberPractitionerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ChamberPractitioners.Where(x => x.CPId == chamberPractitionerId).FirstOrDefault();
            }
        }

        public bool SaveMedia(BusinessMedia _media)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.BusinessMedias.Add(_media);
                entities.SaveChanges();

                return true;
            }
        }

        public bool UpdateDoctorSerialPatient(PractitionerWisePatientSerial pr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(pr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<BusinessMedia> GetAllMediasByType(string type)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BusinessMedias.Where(x => x.MediaType.Equals(type)).ToList();
            }
        }

        public BusinessMedia getMediaById(int mediaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BusinessMedias.Where(x => x.MediaId == mediaId).FirstOrDefault();
            }
        }

        public ChamberPractitionerSpeciality GetChamberPractionerSpecialityById(int _CPSId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ChamberPractitionerSpecialities.Where(x => x.CPSId == _CPSId).FirstOrDefault();
            }
        }

        public bool UpdateChamberPractionerSpeciality(ChamberPractitionerSpeciality _cp)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_cp).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<BusinessMedia> GetAllMedias()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BusinessMedias.ToList();

            }
        }

        public IList<VWDoctor> GetDoctorDetailList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VWDoctor>("Select * from VWDoctorDetail").ToList();                
            }
        }

        public IList<ReportConsultant> GetlAlReportDoctorOtherThanPathology()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultants.ToList();
            }
        }

        private Doctor GetDoctorByIdConvertedFromDataTable(DataRow dr)
        {
            Doctor _doctor = new Doctor();
            _doctor.DoctorId = Convert.ToInt32(dr["DoctorId"]);
            _doctor.Name = dr["Name"].ToString();
            return _doctor;
        }

        public IList<ChamberPractitionerSpeciality> GetChamberPractitionerSpecialityList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ChamberPractitionerSpecialities.ToList();
            }
        }

        public Doctor GetDoctorByIdFromLegacy(int id)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter("select * from dbo.Doctor where DoctorId=" + id.ToString(), con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                return GetDoctorByIdConvertedFromDataTable(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool AddChamberPractitionerSpeciality(ChamberPractitionerSpeciality _cprac)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ChamberPractitionerSpecialities.Add(_cprac);
                entities.SaveChanges();
                return true;
            }
        }

        public void SaveChamberPractitionerOffDays(List<CPOffDayCalender> offdays)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.CPOffDayCalenders.AddRange(offdays);
                entities.SaveChanges();
            }
        }

        public List<ReferralCategory> GetRefCategories()
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.ReferralCategories.ToList();
            }
        }

        public IList<ReportConsultant> GetlAlReportDoctorOtherThanPathologyLegacy()
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter("select * from dbo.ReportConsultants Where RCId in (Select Distinct RCId from ReportConsultantWorkLists)", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                List<ReportConsultant> listReportDoctors = new List<ReportConsultant>();

                listReportDoctors = new List<ReportConsultant>(
                    (from dRow in dt.AsEnumerable()
                     select (GetDoctorDataTableRow(dRow)))
                    );

                return listReportDoctors;
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

        public void DeleteExistingAllowedGroups(int rCId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format("Delete from ReportConsultantWorkLists where RCId={0}", rCId);
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }catch(Exception ex)
                {

                }
            }
        }

        public List<CPOffDayCalender> GetCPOffDays(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CPOffDayCalenders.Where(x=>x.CpId== cPId).ToList();
              
            }
        }

        public bool UpdateChamberPractitioner(ChamberPractitioner _consultant)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_consultant).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public IList<ChamberPractitioner> GetAllChamberPractitioners()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ChamberPractitioners.ToList();
            }
        }

        public List<ChamberPractitioner> GetChamberPractitionerList()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.ChamberPractitioners.ToList();
            }
        }

        public int SaveChamberPractitioner(ChamberPractitioner _consultant)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ChamberPractitioners.Add(_consultant);
                entities.SaveChanges();
                return _consultant.CPId;
            }
        }

        public bool UpdateDoctorRecord(Doctor _doc)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(_doc).State=EntityState.Modified;
               entities.SaveChanges();
               return true;
            }
        }

        public List<Doctor> GetDoctorBySearchString(string _searcgString)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("select * from Doctor Where Name like '%{0}%'", _searcgString.Trim());
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                List<Doctor> listReportDoctors = new List<Doctor>();

                listReportDoctors = new List<Doctor>(
                    (from dRow in dt.AsEnumerable()
                     select (GetDDataTableRow(dRow)))
                    );

                return listReportDoctors;
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

        public List<ReportConsultantWorkList> GetConsultantWorkList(int rCId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultantWorkLists.Where(x => x.RCId == rCId).ToList();
            }
        }

        private Doctor GetDDataTableRow(DataRow dr)
        {
            Doctor _doc = new Doctor();
            _doc.DoctorId= Convert.ToInt32(dr["DoctorId"]);
            _doc.Name = dr["Name"].ToString();

            return _doc;
        }

        private ReportConsultant GetDoctorDataTableRow(DataRow dr)
        {
            ReportConsultant _doctor = new ReportConsultant();
            _doctor.RCId = Convert.ToInt32(dr["RCId"]);
            _doctor.Name = dr["Name"].ToString();
            _doctor.Fsize1 = Convert.ToInt32(dr["Fsize1"]);
            _doctor.DIdentityLine1 = dr["DIdentityLine1"].ToString();
            _doctor.Fsize2 = Convert.ToInt32(dr["Fsize2"]);
            _doctor.DIdentityLine2 = dr["DIdentityLine2"].ToString();
            _doctor.Fsize3 = Convert.ToInt32(dr["Fsize3"]);
            _doctor.DIdentityLine3 = dr["DIdentityLine3"].ToString();
            _doctor.Fsize4 = Convert.ToInt32(dr["Fsize4"]);
            _doctor.DIdentityLine4 = dr["DIdentityLine4"].ToString();
            _doctor.Fsize5 = Convert.ToInt32(dr["Fsize5"]);
            _doctor.DIdentityLine5 = dr["DIdentityLine5"].ToString();
            _doctor.Fsize5 = Convert.ToInt32(dr["Fsize6"]);
            return _doctor;
        }

        public IList<ReportConsultant> GetAllConsultants()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultants.ToList();
            }
        }

        public void SaveAllowedGroups(List<ReportConsultantWorkList> _rcWList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ReportConsultantWorkLists.AddRange(_rcWList);
                entities.SaveChanges();
              
            }
        }

        public bool UpdateReportConsultant(ReportConsultant _rConsultant)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_rConsultant).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public string SaveNewReferral(Doctor _doctor)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Doctors.Add(_doctor);
                    entities.SaveChanges();
                    return "Doctor name saved successfully.";
                }
                catch
                {
                    return "Doctor name saving fail.";
                }
               
            }
        }

        public int IsExists(string p)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Doctors.Where(x => x.Name == p).ToList().Count;
            }
        }

        public IList<ReportConsultant> GetPathologyConsultants()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultants.SqlQuery("Select * from ReportConsultants Where RCId not in (Select Distinct RCId from ReportConsultantWorkLists)").ToList();
            }
        }

        public IList<ReportTechnologist> GetReportTechnologists()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTechnologist.ToList();
            }
        }

        public ReportConsultant GetReportConsultantByName(string _dname)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultants.Where(x=>x.Name==_dname).FirstOrDefault();
            }
        }

        public object GetTechnologistByName(string name)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTechnologist.Where(x => x.Name == name).FirstOrDefault();
            }
        }

        public ReportTechnologist GetTechnologistById(int _technologistId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTechnologist.Where(x => x.Id == _technologistId).FirstOrDefault();
            }
        }

        public Doctor GetDoctorById(int _refdBy)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Doctors.Where(x => x.DoctorId == _refdBy).FirstOrDefault();
            }
        }

        public ReportConsultant GetConsultantByUserId(int _consultandUserId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportConsultants.Where(x => x.ConsultantUserId == _consultandUserId).FirstOrDefault();
            }
        }

        public int SaveReportConsultant(ReportConsultant _consultant)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ReportConsultants.Add(_consultant);
                    entities.SaveChanges();
                    return _consultant.RCId;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public ReportConsultant GetCurrentConsultant(string _regNo, Model.ViewModel.ViewModelReportTests viewModelReportTests)
        {
            try
            {
                int _currentConsultant=0;
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("select * from dbo.Reports Where RegNo='{0}' and TestId={1}", _regNo, viewModelReportTests.Id);
                cmd=new SqlCommand(sql,con);
              
                
                using(var reader=cmd.ExecuteReader()){
                   while(reader.Read()){
                       _currentConsultant=reader.GetInt32(9);
                   }
                }


                if(_currentConsultant>0){
                    using (DBEntities entities = new DBEntities())
                    {
                        return entities.ReportConsultants.Where(x => x.RCId == _currentConsultant).FirstOrDefault();
                    }
                }

                return null;
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

        public Doctor GetDoctorByUserId(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Doctors.Where(x => x.UserId == userId).FirstOrDefault();
            }
        }
    }
}
