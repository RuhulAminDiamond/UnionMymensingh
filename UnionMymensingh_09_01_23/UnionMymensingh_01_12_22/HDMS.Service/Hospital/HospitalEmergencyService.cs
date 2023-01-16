using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Repository.Hospital;

namespace HDMS.Service.Hospital
{
    public class HospitalEmergencyService
    {
        public List<VMIPDInfo> GetOPDPatientByDate(DateTime _date)
        {
            return new HospitalEmergencyRepository().GetOPDPatientByDate(_date);
        }

        public VMIPDInfo GetPatientInfoById(long _admissionId)
        {
            return new HospitalEmergencyRepository().GetPatientInfoById(_admissionId);
        }

        public OPDPatientRecord GetPatientInfoByBillNo(long _billNo)
        {
            return new HospitalEmergencyRepository().GetPatientInfoByBillNo(_billNo);
        }

        public bool SaveServiceBillDetails(List<OPDServiceBillDetail> _sbillList)
        {
            return new HospitalEmergencyRepository().SaveServiceBillDetails(_sbillList);
        }

        public bool SaveDoctorServiceDetails(List<OPDDoctorServiceBillDetail> _dsblist)
        {
            return new HospitalEmergencyRepository().SaveDoctorServiceDetails(_dsblist);
        }
    }
}
