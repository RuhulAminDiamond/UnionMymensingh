using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital.ViewModel;
using System.Data.SqlClient;
using System.Data;
using HDMS.Common.Utils;
using HDMS.Model.OPD;
using HDMS.Model.Hospital;

namespace HDMS.Repository.Hospital
{
    public class HospitalEmergencyRepository
    {

        SqlConnection con;
        string sql = string.Empty;
        SqlDataAdapter da;

        public List<VMIPDInfo> GetOPDPatientByDate(DateTime _date)
        {
            try
            {
                sql = string.Format("select * from VWEmergencyPatientDetails Where EntryDate='{0}' and Status<>'DisCharged'", _date);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        public bool SaveDoctorServiceDetails(List<OPDDoctorServiceBillDetail> _dsblist)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDDoctorServiceBillDetails.AddRange(_dsblist);
                entities.SaveChanges();

                return true;
            }
        }

        public bool SaveServiceBillDetails(List<OPDServiceBillDetail> _sbillList)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.OPDServiceBillDetails.AddRange(_sbillList);
                 entities.SaveChanges();

                 return true;
            }
        }

        public OPDPatientRecord GetPatientInfoByBillNo(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDPatientRecords.Where(x => x.BillNo == _billNo).FirstOrDefault();
            }
        }

        public VMIPDInfo GetPatientInfoById(long _admissionId)
        {
            try
            {
                sql = string.Format("select * from VWEmergencyPatientDetails Where PatientID={0}", _admissionId);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

               

                return GetTemplateDataTableRow(dt.Rows[0]);

               
            }
            catch (Exception ex)
            {
                return new VMIPDInfo();
            }
        }

        private VMIPDInfo GetTemplateDataTableRow(DataRow dr)
        {
            VMIPDInfo pdInfo = new VMIPDInfo();
            pdInfo.RegNo = Convert.ToInt64(dr["RegNo"]);
            pdInfo.AdmissionId = Convert.ToInt32(dr["PatientId"]);
            pdInfo.BillNo = Convert.ToInt64(dr["BillNo"]);
            pdInfo.AddmissionDate = Convert.ToDateTime(dr["EntryDate"]);
            pdInfo.AdmTime = dr["EntryTime"].ToString();
            pdInfo.Name = dr["FullName"].ToString();
         

            return pdInfo;
        }
    }
}
