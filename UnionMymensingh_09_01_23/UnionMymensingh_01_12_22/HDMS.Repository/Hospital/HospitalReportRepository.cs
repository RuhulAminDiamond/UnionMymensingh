using HDMS.Common.Utils;
using HDMS.Model.Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Hospital
{
    public class HospitalReportRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlConnection con;

        
        public SqlDataAdapter GetOutDoorPatients(DateTime dateTime1, DateTime dateTime2, string servicefor)
        {
            if (servicefor == "All")
            {
                sql = string.Format(@" SELECT * from OutDoorPatients WHERE (dbo.OutDoorPatients.EntryDate between '{0}' and '{1}')", dateTime1, dateTime2);
            }
            else
            {
                sql = string.Format(@"SELECT * from OutDoorPatients WHERE (dbo.OutDoorPatients.EntryDate between '{0}' and '{1}' and ServiceFor='{2}')", dateTime1, dateTime2, servicefor);
            }



            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            return da;
        }

        public DataSet GetAdmissionRecordByAdmissionId(long _admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select * from VWHospitalPatientDetails_2 Where AdmissionId={0}", _admissionId);



                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtAdmissionInfo");
                return dsReports;
            }
        }

        public List<VMHpFinalBill> GetHpDayWisePreviousBillDetails(long _hbillNo)
        {
            sql = string.Format(@"SELECT dbo.HpDayWiseBills.DayWiseBillId, dbo.HpDayWiseBills.Billdate, dbo.HpDayWiseBills.BillNo,
                                  dbo.HpDayWiseBills.PreparedBy, dbo.HpDayWiseBills.BillTime,  dbo.HpDayWiseBillDetails.DayWiseBillDetailId,
                                  dbo.HpDayWiseBillDetails.qnt as Qty, dbo.HpDayWiseBillDetails.Rate, dbo.HpDayWiseBillDetails.Amount as Total,
                                  dbo.HpDayWiseBillDetails.ServiceHeadId, dbo.HpDayWiseBillDetails.ServiceName
                                   FROM  dbo.HpDayWiseBills INNER JOIN dbo.HpDayWiseBillDetails ON 
	                                  dbo.HpDayWiseBills.DayWiseBillId = dbo.HpDayWiseBillDetails.DayWiseBillId Where  dbo.HpDayWiseBills.DayBillNo='{0}'", _hbillNo);

            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<VMHpFinalBill> _hpprevbillItems = new List<VMHpFinalBill>();

            _hpprevbillItems = new List<VMHpFinalBill>(
              (from dRow in dt.AsEnumerable()
               select (GetHpDayWiseFinalBillDataRow(dRow)))
              );

            return _hpprevbillItems;
        }

        private VMHpFinalBill GetHpDayWiseFinalBillDataRow(DataRow dr)
        {
            VMHpFinalBill _pr = new VMHpFinalBill();
            
            _pr.ServiceName = dr["ServiceName"].ToString();
            _pr.Qty = Convert.ToInt32(dr["Qty"]);
            _pr.Rate = Convert.ToDouble(dr["Rate"]);
            _pr.Total = Convert.ToDouble(dr["Total"]);
            // _pr.ServiceGroup = dr["ServiceGroup"].ToString();

            return _pr;
        }

        public DataSet GetDischargeData(long admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.DischargeCertificateMasters.DischargeId, dbo.DischargeCertificateMasters.AdmissionId, dbo.DischargeCertificateMasters.DischareDate, dbo.DischargeCertificateMasters.Remarks, 
                         dbo.DischargeCertificateMasters.DischargeTime, dbo.DischargeCertificateMasters.CertificateBy, dbo.DischargeCertificateDetails.DescriptionTitle, dbo.DischargeCertificateDetails.Description, 
                         dbo.DischargeCertificateDetails.DescriptionLabel, dbo.DischargeCertificateDetails.IsLabelBold,dbo.DischargeCertificateDetails.DisplayOrder
                         FROM dbo.DischargeCertificateMasters INNER JOIN
                         dbo.DischargeCertificateDetails ON dbo.DischargeCertificateMasters.DischargeId = dbo.DischargeCertificateDetails.DischargeId  Where AdmissionId={0}", admissionId);



                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtDischargeCertificate");
                return dsReports;
            }
        }

        public DataSet GetPatientBasicInfoByAdmissionId(long admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetHpPatientBasicInfo {0}", admissionId);



                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtHBill");
                return dsReports;
            }
        }

        public SqlDataAdapter GetOutDoorPatientsIncome(DateTime dateTime1, DateTime dateTime2)
        {
            sql = string.Format(@"SELECT RegNo,Name,Amount,HCVAdjust,PoorFund,Date from VWOutDoorIncomeStatement WHERE (dbo.VWOutDoorIncomeStatement.Date between '{0}' and '{1}')", dateTime1, dateTime2);


            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            return da;
        }

        public VWMHospitalBillPaymentAmounts GetIndoorPatentBillPaymentsInfo(int billId)
        {
            sql = string.Format(@"SELECT BillId,Invdate,RegNo,Name,HospitalBill,DiscountOnHospital,HospitalPaymentByCash,HospitalBillPaymentByPF,HospitalPaymentByHCV from VWHospitalBillStatement WHERE (dbo.VWHospitalBillStatement.BillId='{0}')", billId);

            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                return GetHospitalBillPaymentDataTableRow(dt.Rows[0]);
            }
            else
            {
                return new VWMHospitalBillPaymentAmounts();
            }
        }

        private VWMHospitalBillPaymentAmounts GetHospitalBillPaymentDataTableRow(DataRow dr)
        {
            VWMHospitalBillPaymentAmounts ttype = new VWMHospitalBillPaymentAmounts();
            ttype.BillId = Convert.ToInt32(dr["BillId"]);
            ttype.HospitalBill = Convert.ToDouble(dr["HospitalBill"]);
            ttype.HospitalPaymentByCash = Convert.ToDouble(dr["HospitalPaymentByCash"]);
            ttype.HospitalBillPaymentByPF = Convert.ToDouble(dr["HospitalBillPaymentByPF"]);
            ttype.HospitalPaymentByHCV = Convert.ToDouble(dr["HospitalPaymentByHCV"]);
            ttype.DiscountOnHospital = Convert.ToDouble(dr["DiscountOnHospital"]);

            return ttype;
        }


    }
}
