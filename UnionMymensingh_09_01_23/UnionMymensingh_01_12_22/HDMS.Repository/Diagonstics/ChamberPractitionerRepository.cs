using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.OPD;
using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Diagonstics
{
    public class ChamberPractitionerRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;

        SqlConnection con;

        SqlCommand cmd;


        public bool AddPractitioner(ChamberPractitioner _practitioner)
        {
            using(DBEntities entities=new DBEntities())
            {
                try{
                      entities.ChamberPractitioners.Add(_practitioner);
                      entities.SaveChanges();
                      return true;
                }catch{
                      return false;
                }
            }
            
        }

        public void InitializeSerialSlot(List<PractitionerWisePatientSerial> pSerialObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PractitionerWisePatientSerials.AddRange(pSerialObj);
                entities.SaveChanges();
            }
        }

        public List<PractitionerWisePatientSerial> GetAllPatients(int cPId, DateTime date)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PractitionerWisePatientSerials.Where(x => x.ChamberPractitionerId == cPId && x.SerialDate == date.Date).ToList();
            }
        }

        public PractitionerWisePatientSerial GetPatientBySerialNo(int id)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PractitionerWisePatientSerials.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<ChamberPractitioner> GetAllActivePractitioner()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ChamberPractitioners.Where(x => x.Status == "Active").ToList();
            }
        }

        public int GetSerialNo(ChamberPractitioner chamberPractitioner, DateTime dateTime)
        {
            using (DBEntities entity = new DBEntities())
            {
                IList<PractitionerWisePatientSerial> list = entity.PractitionerWisePatientSerials.Where(x => (x.SerialDate == dateTime.Date
                && x.ChamberPractitionerId == chamberPractitioner.CPId)).ToList();
                if (list.Count == 0) return 1;
                return (int)list[list.Count - 1].SerialNo + 1;
            }
        }

        public bool DeletePatientSerial(PractitionerWisePatientSerial patientSerial)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    entities.Database.ExecuteSqlCommand("delete from PractitionerWisePatientSerials where Id={0}", patientSerial.Id);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public OPDPatientVisitType GetVisitType(int visitTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.OPDPatientVisitTypes.Where(x => x.VisitTypeId == visitTypeId).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<List<VMPractitionerWisePatientSerial>> GetTodaysPatient(DateTime date)
        {
            try
            {
                sql = string.Format("exec spgetDatewisePatientSerail '{0}'", date.Date);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMPractitionerWisePatientSerial> listhp = new List<VMPractitionerWisePatientSerial>();

                listhp = new List<VMPractitionerWisePatientSerial>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return await Task.FromResult(listhp);
            }
            catch (Exception ex)
            {
                return new List<VMPractitionerWisePatientSerial>();
            }
        }

        private VMPractitionerWisePatientSerial GetTemplateDataTableRow(DataRow dr)
        {
            VMPractitionerWisePatientSerial pdInfo = new VMPractitionerWisePatientSerial();
            pdInfo.PractionerName = dr["PractionerName"].ToString();
            pdInfo.PatientName = dr["PatientName"].ToString();
            pdInfo.Id = Convert.ToInt32(dr["Id"]);
            pdInfo.Status = dr["Status"].ToString();
            pdInfo.SerilaTime = dr["SerilaTime"].ToString();
            pdInfo.DailyId = Convert.ToInt32(dr["DailyId"]);
            return pdInfo;
        }

        public bool CreateNewSerial(PractitionerWisePatientSerial _pSerial)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.PractitionerWisePatientSerials.Add(_pSerial);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<VMPractitionerWisePatientSerial> LoadPatientSerialByDoctor(int _pId,DateTime _date)
        {
            using (SqlConnection con = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {

                try
                {

                    con.Open();

                    sql = string.Format(@"Select * from PractitionerWisePatientSerials join OPDPatientVisitTypes on PractitionerWisePatientSerials.VisitTypeId=OPDPatientVisitTypes.VisitTypeId
                           Where ChamberPractitionerId={0} and SerialDate='{1}' order by SerialNo Asc", _pId, _date.Date);

                    da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();

                    List<VMPractitionerWisePatientSerial> pInfoList = new List<VMPractitionerWisePatientSerial>();


                    pInfoList = new List<VMPractitionerWisePatientSerial>(
                      (from dRow in dt.AsEnumerable()
                       select (GetPatientSrlDataTableRow(dRow)))
                      );

                    return pInfoList;

                }
                catch (Exception ex)
                {
                    return new List<VMPractitionerWisePatientSerial>();

                }

            }
        }

        private VMPractitionerWisePatientSerial GetPatientSrlDataTableRow(DataRow dr)
        {
            VMPractitionerWisePatientSerial Obj = new VMPractitionerWisePatientSerial();
            Obj.ChamberPractitionerId = Convert.ToInt32(dr["ChamberPractitionerId"]);
            Obj.SerialNo = Convert.ToInt32(dr["SerialNo"]);
            Obj.SerialDate = Convert.ToDateTime(dr["SerialDate"]);
            Obj.Titel = dr["Titel"].ToString();
            Obj.PatientName = dr["PatientName"].ToString();
            Obj.MobileNo = dr["MobileNo"].ToString();
            Obj.EmailId = dr["EmailId"].ToString();
            Obj.Address = dr["Address"].ToString();
            Obj.Occupation = dr["Occupation"].ToString();
            Obj.Age = dr["Age"].ToString();
            Obj.AgeYear = dr["AgeYear"].ToString();
            Obj.AgeMonth = dr["AgeMonth"].ToString();
            Obj.AgeDay = dr["AgeDay"].ToString();
            Obj.DOB = Convert.ToDateTime(dr["DOB"]);
            Obj.Sex = dr["Sex"].ToString();
            Obj.VisitTypeId = Convert.ToInt32(dr["VisitTypeId"]);
            Obj.VisitType = dr["VisitType"].ToString();
            Obj.VisitTypeCode = dr["VisitTypeCode"].ToString();
            Obj.Remarks = dr["Remarks"].ToString();
            
            return Obj;
        }
    }
}
