using HDMS.Repository.Hospital;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HDMS.Service.Hospital
{
     public  class HospitalReportService
    {
        public SqlDataAdapter GetOutDoorPatients(DateTime dateTime1, DateTime dateTime2, string servicefor)
        {
            return new HospitalReportRepository().GetOutDoorPatients(dateTime1, dateTime2, servicefor);
        }

        public SqlDataAdapter GetOutDoorPatientsIncome(DateTime dateTime1, DateTime dateTime2)
        {
            return new HospitalReportRepository().GetOutDoorPatientsIncome(dateTime1, dateTime2);
        }

        public Model.Hospital.ViewModel.VWMHospitalBillPaymentAmounts GetIndoorPatentBillPaymentsInfo(int billId)
        {
            return new HospitalReportRepository().GetIndoorPatentBillPaymentsInfo(billId);
        }

        public DataSet GetAdmissionRecordByAdmissionId(long _admissionId)
        {
            return new HospitalReportRepository().GetAdmissionRecordByAdmissionId(_admissionId);
        }

        public DataSet GetPatientBasicInfoByAdmissionId(long admissionId)
        {
            return new HospitalReportRepository().GetPatientBasicInfoByAdmissionId(admissionId);
        }

        public DataSet GetDischargeData(long admissionId)
        {
            return new HospitalReportRepository().GetDischargeData(admissionId);
        }
    }
}
