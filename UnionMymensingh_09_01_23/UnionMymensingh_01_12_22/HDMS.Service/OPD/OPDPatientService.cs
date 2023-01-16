using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;
using HDMS.Repository.OPD;

namespace HDMS.Service.OPD
{
    public class OPDPatientService
    {

        public VMOPDPatientRecord GetOPDInfoById(long _patientId)
        {
            return new OPDPatientRepository().GetOPDInfoById(_patientId);
        }

        public OPDPatientRecord GetLastReceivedPatientByUser(int userId)
        {
            return new OPDPatientRepository().GetLastReceivedPatientByUser(userId);
        }

        public OPDPatientRecord GetFirstReceivedPatientByUser(int userId)
        {
            return new OPDPatientRepository().GetFirstReceivedPatientByUser(userId);
        }

        public double GetDiscountAmount()
        {
            return 0;
        }

        public static long SavePatient(OPDPatientRecord patient)
        {
            return new OPDPatientRepository().SavePatient(patient);
        }

        public DisplaySetting GetDisplaySetting()
        {
            return new OPDPatientRepository().GetDisplaySetting();
        }

        public void SaveTestsCost(List<OPDServiceCost> serviceCosts)
        {
            new OPDPatientRepository().SaveTestsCost(serviceCosts);
        }

        public List<VMOPDPatientRecord> GetOPDPatientsUnderService()
        {
            return new OPDPatientRepository().GetOPDPatientsUnderService();
        }

        public void SavePatientLedger(List<OPDPatientLedger> transactionList)
        {
            new OPDPatientRepository().SavePatientLedger(transactionList);
        }

        public OPDPatientRecord GetPatientByBillNo(long _billNo)
        {
           return  new OPDPatientRepository().GetPatientByBillNo(_billNo);
        }

        public OPDServiceCost GetOPDServiceCost(long patientId)
        {
            return new OPDPatientRepository().GetOPDServiceCost(patientId);
        }

       

        public OPDPatientRecord GetOPDPatientById(long _pId)
        {
            return new OPDPatientRepository().GetOPDPatientById(_pId);
        }

        public void UpdateOPDPatientInfo(OPDPatientRecord _PInfo)
        {
            new OPDPatientRepository().UpdateOPDPatientInfo(_PInfo);
        }

        public List<OPDPatientVisitType> GetVisitTypes()
        {
            return new OPDPatientRepository().GetVisitTypes();
        }

        public void PopulateSelectedServiceData(IList<VMSelectedOTServices> _SelectedOTServices, ServiceHead _Servicehead, Doctor _doctor, double _Rate, double _Qty, string _userName)
        {
            int ServiceId;
            ServiceId = _Servicehead.ServiceHeadId;
            if (_Servicehead == null) return;
            if (_doctor == null) return;

            // if (_SelectedOTServices.Any(x => x.ServiceHeadId == ServiceId)) return;

            _SelectedOTServices.Add(GetPreparedSelectedItemObject(_Servicehead, _doctor, _Rate, _Qty, _userName));

        }

        private Model.Hospital.ViewModel.VMSelectedOTServices GetPreparedSelectedItemObject(Model.Hospital.ServiceHead _Servicehead, Doctor _doctor, double _Rate, double _Qty, string _userName)
        {
            VMSelectedOTServices sos = new VMSelectedOTServices();
            sos.ServiceHeadId = _Servicehead.ServiceHeadId;
            sos.ServiceHeadName = _Servicehead.ServiceHeadName;
            sos.DoctorId = _doctor.DoctorId;
            sos.DoctorName = _doctor.Name;
            sos.Rate = _Rate;
            sos.Qty = _Qty;
           // sos.ServiceCharge = GetServiceChargeByHeadId(_Servicehead.ServiceHeadId, _Rate * _Qty);
            sos.Amount = _Rate * _Qty;
            sos.EnteredBy = _userName;
            return sos;
        }

        public Task<List<VMDiagPatientBasicInfo>> GetOPDPatienInfo(DateTime dtfrm, DateTime dtto)
        {
            return new OPDPatientRepository().GetOPDPatienInfo(dtfrm, dtto);
        }

        public OPDPatientRecord GetPatientByPatientId(long billNo)
        {
            return new OPDPatientRepository().GetPatientByPatientId(billNo);
        }

        public DataSet GetOPDServiceListExceptConsultancy(long patientId)
        {
            return new OPDPatientRepository().GetOPDServiceListExceptConsultancy(patientId);
        }

        public List<OPDPatientLedgerRough> GetOPDPatientLedgerRough(long patientId)
        {
            return new OPDPatientRepository().GetOPDPatientLedgerRough(patientId);
        }

        public DataSet GetConsultancyServiceList(long patientId)
        {
            return new OPDPatientRepository().GetConsultancyServiceList(patientId);
        }

        public OPDPatientRecord GetOPDPatientByBillNo(long billNo)
        {
            return new OPDPatientRepository().GetOPDPatientByBillNo(billNo);
        }

        public bool UpdatePatientSerialStatus(PractitionerWisePatientSerial pat)
        {
            return new OPDPatientRepository().UpdatePatientSerialStatus(pat);
        }

        public bool CancelPatient(long patientId, string cancelledby)
        {
            return new OPDPatientRepository().CancelPatient(patientId, cancelledby);
        }

        public bool CancelService(long patientId, int itemId, int groupId, int userId)
        {
            return new OPDPatientRepository().CancelService(patientId, itemId, groupId, userId);
        }
    }
}
