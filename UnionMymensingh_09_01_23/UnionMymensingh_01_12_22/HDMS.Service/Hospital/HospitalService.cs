using HDMS.Model;
using HDMS.Model.Common.VW;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Repository.Hospital;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Models.Pharmacy;
using HDMS.Model.OPD.VM;

namespace HDMS.Service.Hospital
{
    public class HospitalService
    {

        public VMIPDInfo GetIPDInfoById(long _admissionId)
        {
            return new HospitalRepository().GetIPDInfoById(_admissionId);
        }

        public IList<ServiceGroup> GetAllProvidedService()
        {
            return new HospitalRepository().GetAllProvidedService();
        }

        public long SaveHospitalPatientInfo(HospitalPatientInfo _HospitalPatientInfo)
        {
            return new HospitalRepository().SavePatientInfo(_HospitalPatientInfo);
        }

        public bool UpdateHpPackage(HpPackage _pkg)
        {
            return new HospitalRepository().UpdateHpPackage(_pkg);
        }

        public List<VMHpPatientAccomodationInfo> GetHpAccomDetails(long _admissionId)
        {
            return new HospitalRepository().GetHpAccomDetails(_admissionId);
        }

        public List<VMHpFinalBill> GetHpDayWisePreviousBillDetails(long _hbillNo)
        {
            return new HospitalReportRepository().GetHpDayWisePreviousBillDetails(_hbillNo);
        }

        public bool SaveHpPackage(HpPackage _pkg)
        {
            return new HospitalRepository().SaveHpPackage(_pkg);
        }

        public IList<VMIPDInfo> GetDischargedIPDInfo(DateTime _dtfrm, DateTime _dateto)
        {
            return new HospitalRepository().GetDischargedIPDInfo(_dtfrm, _dateto);
        }

        public List<HpPackage> GetAllHpPackages()
        {
            return new HospitalRepository().GetAllHpPackages();
        }

        public List<OPDServiceSubGroup> getOpdServiceSubGroups()
        {
            return new HospitalRepository().getOpdServiceSubGroups();
        }

        public bool SaveHpPackageSubItem(HpPkgSubItem _sItem)
        {
            return new HospitalRepository().SaveHpPackageSubItem(_sItem);
        }

        public bool UpdateOPDServiceHead(OPDServiceHead _sh)
        {
            return new HospitalRepository().UpdateOPDServiceHead(_sh);
        }

        public List<VMDischargedCertifiedPatientList> GetDischargeCertificateList(DateTime dtpStart, DateTime dtpEnd)
        {
            return new HospitalRepository().GetDischargeCertificateList(dtpStart, dtpEnd);
        }

        public IList<VMIPDInfo> GetCurrentOPDInfo()
        {
            return new HospitalRepository().GetCurrentOPDInfo();
        }

        public List<HpPkgSubItem> GetHpPackageSubItems(int pkgId)
        {
            return new HospitalRepository().GetHpPackageSubItems(pkgId);
        }

        public bool SaveHpDepartment(HpDepartment _hpd)
        {
            return new HospitalRepository().SaveHpDepartment(_hpd);
        }

        public List<OPDServiceGroup> getOpdServiceGroups()
        {
            return new HospitalRepository().getOpdServiceGroups();
        }

        public bool UpdateHpOPDConsultantCategory(HpOPDConsultantCategory _hpopdconsultantcat)
        {
            return new HospitalRepository().UpdateHpOPDConsultantCategory(_hpopdconsultantcat);
        }

        public Task<List<VMIPDInfo>> GetCurrentIPDInfoForDischarge()
        {
            return new HospitalRepository().GetCurrentIPDInfoForDischarge();
        }

        public List<VMHpFinalBill> GetHpPreviousBillDetails(long _hbillNo)
        {
            return new HospitalRepository().GetHpPreviousBillDetails( _hbillNo );
        }

        public IList<VMIPDInfo> GetCurrentIPDAndOPDInfo()
        {
            return new HospitalRepository().GetCurrentIPDAndOPDInfo();
        }

        public long SaveDischargeMaster(DischargeCertificateMaster _dcm)
        {
            return new HospitalRepository().SaveDischargeMaster(_dcm);
        }

        public IList<VWDoctor> GetDoctorListByName(string _name)
        {
            return new HospitalRepository().GetDoctorListByName(_name);
        }

        public async Task<List<VMIPDInfo>> GetOPdBillingDistributedPatient()
        {
            return await new HospitalRepository().GetOPdBillingDistributedPatient();
        }

        public bool UpdateHpPackageSubItem(HpPkgSubItem _subItem)
        {
            return new HospitalRepository().UpdateHpPackageSubItem(_subItem);
        }

        public IList<VMOPDServiceHead> GetAllOPDServiceHeadsByGroup(string _type)
        {
            return new HospitalRepository().GetAllOPDServiceHeadsByGroup(_type);
        }

        public List<VMedicineRequisition> GetOPDRequisitionListByUserByDate(string username, DateTime dtp)
        {
            return new HospitalRepository().GetOPDRequisitionListByUserByDate(username, dtp);
        }

        public bool UpdateHpDept(HpDepartment _hpd)
        {
            return new HospitalRepository().UpdateHpDept(_hpd);
        }

        public bool SaveHpOPDConsultantCategory(HpOPDConsultantCategory _hpdcat)
        {
            return new HospitalRepository().SaveHpOPDConsultantCategory(_hpdcat);
        }

        public DataSet GetHpAllPatientListByAdmissionDate(DateTime dtpfrm, DateTime dtpto, int deptId, int floorId, bool isAllIPD)
        {
            return new HospitalRepository().GetHpAllPatientListByAdmissionDate(dtpfrm, dtpto, deptId, floorId, isAllIPD);
        }

        public bool SaveOPDServiceHead(OPDServiceHead _sh)
        {
            return new HospitalRepository().SaveOPDServiceHead(_sh);
        }

        public bool CreateOPDServiceGroup(OPDServiceGroup _sGroup)
        {
            return new HospitalRepository().CreateOPDServiceGroup(_sGroup);
        }

        public OTSchedule GetOTScheduleByAdmissionId(long admissionId)
        {
            return new HospitalRepository().GetOTScheduleByAdmissionId(admissionId);
        }

        public List<VMOPDServiceHead> GetAllOPDServiceHeads()
        {
            return new HospitalRepository().GetAllOPDServiceHeads();
        }

        public ServiceGroup GetServiceByName(string serviceName)
        {
           return new HospitalRepository().GetServiceByName(serviceName);
        }

        public List<HpOPDConsultantCategory> GetHpOPDConsultantCategories()
        {
            return new HospitalRepository().GetHpOPDConsultantCategories();
        }

        public List<VMIPDInfo> GetCurrentEmergencyPatients()
        {
            return new HospitalRepository().GetCurrentEmergencyPatients();
        }

        public HpPatientAccomodationInfo GetPatientLastAccomodatedCabin(long admissionId)
        {
            return new HospitalRepository().GetPatientLastAccomodatedCabin(admissionId);
        }

        public List<HpDepartment> GetHpDepartments()
        {
            return new HospitalRepository().GetHpDepartments();
        }

        public async Task<List<VMIPDInfo>> GetCurrentOPDAdmittedInfo()
        {
            return await  new HospitalRepository().GetCurrentOPDAdmittedInfo();
        }

        public List<ServiceHead> GetAllServiceHeads()
        {
            return new HospitalRepository().GetAllServiceHeads();
        }

        public bool UpdateHpOPDServiceSubGroup(OPDServiceSubGroup _ssgroup)
        {
            return new HospitalRepository().UpdateHpOPDServiceSubGroup(_ssgroup);
        }

        public List<OPDServiceSubGroup> GetAllOPDServiceSubGroups()
        {
            return new HospitalRepository().GetAllOPDServiceSubGroups();
        }

        public List<OTExecutionDetail> GetOTSurgeon(long oTId)
        {
            return new HospitalRepository().GetOTSurgeon(oTId);
        }

        public List<ServiceSubGroup> GetAllServiceSubGroups()
        {
            return new HospitalRepository().GetAllServiceSubGroups();
        }

        public HpOPDConsultantCategory GetHpOPDConsultantCategoryById(int _cateId)
        {
            return new HospitalRepository().GetHpOPDConsultantCategoryById(_cateId);
        }

        public List<VMIPDInfo> GetCurrentIPDs()
        {
            return new HospitalRepository().GetCurrentIPDs();
        }

        public List<OTExecutionDetail> GetOTAnaesthetists(long oTId)
        {
            return new HospitalRepository().GetOTAnaesthetists(oTId);
        }

        public DataTable HospitalPatientInfo(int patientId, object barcodeimg)
        {
            return new HospitalRepository().PatientInfo(patientId, barcodeimg);
        }

        public List<OPDServiceHead> GetAllOPDServiceHeadBySubGroupId(int subGroupId)
        {
            return new HospitalRepository().GetAllOPDServiceHeadBySubGroupId(subGroupId);
        }

        public bool SaveHpOPDServiceSubGroup(OPDServiceSubGroup _ssgroup)
        {
            return new HospitalRepository().SaveHpOPDServiceSubGroup(_ssgroup);
        }

        public List<OTExecutionDetail> GetOTAssistantSurgeonDetail(long oTId)
        {
            return new HospitalRepository().GetOTAssistantSurgeonDetail(oTId);
        }

        public OPDServiceHead GetOPDServiceHeadById(int _shId)
        {
            return new HospitalRepository().GetOPDServiceHeadById(_shId);
        }

        public void SaveDischargeDetails(List<DischargeCertificateDetail> _dcdList)
        {
            new HospitalRepository().SaveDischargeDetails(_dcdList);
        }

        public HpDepartment GetHpDeptById(int _deptId)
        {
            return new HospitalRepository().GetHpDeptById(_deptId);
        }

        public ServiceHead GetServiceHeadById(int shId)
        {
            return new HospitalRepository().GetServiceHeadById(shId);
        }

        public bool CreateServiceGroup(ServiceGroup _sGroup)
        {
            return new HospitalRepository().CreateServiceGroup(_sGroup);
        }

        public List<VMIPDInfo> GetCurrentOTOrPostOperativePatients(int _floorId, string _otOrPo)
        {
            return new HospitalRepository().GetCurrentOTOrPostOperativePatients(_floorId, _otOrPo);
        }

        public void PopulateSelectedOPDServices(IList<VMSelectedService> _SelectedServices, VMOPDServiceHead _Servicehead, double _Rate, int _Qty, OPDServiceGroup sg, string _userName)
        {
            int ServiceId;
            ServiceId = _Servicehead.ServiceHeadId;
            if (_Servicehead == null) return;

            _SelectedServices.Add(GetPreparedOPDSelectedServiceObject(_Servicehead,  _Rate, _Qty, sg, _userName));
        }

        private VMSelectedService GetPreparedOPDSelectedServiceObject(VMOPDServiceHead _Servicehead, double _Rate, int _Qty, OPDServiceGroup sg, string _userName)
        {
            VMSelectedService ss = new VMSelectedService();
            ss.ServiceHeadId = _Servicehead.ServiceHeadId;
            ss.ServiceHeadName = _Servicehead.ServiceHeadName;
            ss.Rate = _Rate;
            ss.Qty = _Qty;
            ss.ServiceCharge = GetServiceChargeByHeadId(_Servicehead.ServiceHeadId, _Rate * _Qty);
            ss.Amount = _Rate * _Qty;
            ss.ServiceGroupId = sg.GroupId;
            ss.EnteredBy = _userName;
            return ss;
        }

        public void UpdateOPDProcedurePatientInfo(OpdProcedureBill _pInfo)
        {
            new HospitalRepository().UpdateOPDProcedurePatientInfo(_pInfo);
        }

        public HospitalPatientInfo GetOPProcedurePatientByOPDBillNo(long billNo)
        {
            return new HospitalRepository().GetOPProcedurePatientByOPDBillNo(billNo);
        }

        public OpdProcedureBill GetOPDProcedurePatientInfoById(int procedureBillId)
        {
            return new HospitalRepository().GetOPDProcedurePatientInfoById(procedureBillId);
        }

        public void PopulateSelectedEmergencyConsultancyServices(IList<VMSelectedService> _SelectedServices, Doctor _doc, double _Rate, int _Qty, string _userName)
        {
            int docId;
            docId = _doc.DoctorId;
            if (_doc == null) return;

            _SelectedServices.Add(GetPreparedEmergencyConsultantSelectedServiceObject(_doc, _Rate, _Qty,  _userName));
        }

        public List<DischargeCertificateTemplateBased> GetDischargeCertificates(DateTime _datetime)
        {
            return new HospitalRepository().GetDischargeCertificates(_datetime);
        }

        public HpPatientAccomodationInfo GetHpPatientExtraAccomodationByAdmAndCabinId(long admissionId, int cabinId)
        {
            return new HospitalRepository().GetHpPatientExtraAccomodationByAdmAndCabinId(admissionId, cabinId);
        }

        private VMSelectedService GetPreparedEmergencyConsultantSelectedServiceObject(Doctor _doc, double _Rate, int _Qty, string _userName)
        {
            VMSelectedService ss = new VMSelectedService();
            ss.ServiceHeadId = _doc.DoctorId;
            ss.ServiceHeadName = _doc.Name;
            ss.Rate = _Rate;
            ss.Qty = _Qty;
            ss.ServiceCharge = 0;
            ss.Amount = _Rate * _Qty;
          
            ss.EnteredBy = _userName;
            return ss;
        }

        public bool SaveOPDServiceBillDetails(List<OPDProcedureServiceBillDetail> sbillList)
        {
           return new HpFinancialRepository().SaveOPDServiceBillDetails(sbillList);
        }

        public void SaveTreatmentOnDischarge(List<TreatmentOnDischarge> _treatmentList)
        {
            new HospitalRepository().SaveTreatmentOnDischarge(_treatmentList);
        }

        public void PopulateSelectedOPDConsultancyServices(IList<VMSelectedService> _SelectedServices, Doctor _doc, double _Rate, int _Qty, OPDServiceGroup sg, string _userName)
        {
            int docId;
            docId = _doc.DoctorId;
            if (_doc == null) return;

            _SelectedServices.Add(GetPreparedOPDConsultantSelectedServiceObject(_doc, _Rate, _Qty, sg, _userName));
        }

        private VMSelectedService GetPreparedOPDConsultantSelectedServiceObject(Doctor _doc, double _Rate, int _Qty, OPDServiceGroup sg, string _userName)
        {
            VMSelectedService ss = new VMSelectedService();
            ss.ServiceHeadId = _doc.DoctorId;
            ss.ServiceHeadName = _doc.Name;
            ss.Rate = _Rate;
            ss.Qty = _Qty;
            ss.ServiceCharge =0;
            ss.Amount = _Rate * _Qty;
            ss.ServiceGroupId = sg.GroupId;
            ss.EnteredBy = _userName;
            return ss;
        }

        public OperationConsent GetConsentNote()
        {
            return new HospitalRepository().GetConsentNote();
        }

        public List<ServiceSubGroup> getServiceSubGroups()
        {
            return new HospitalRepository().getServiceSubGroups();
        }

        public OPDServiceGroup GetOPDServiceGroupById(int _groupId)
        {
            return new HospitalRepository().GetOPDServiceGroupById(_groupId);
        }

        public bool UpdateServiceHead(ServiceHead _sh)
        {
            return new HospitalRepository().UpdateServiceHead(_sh);
        }

        public List<ServiceGroup> getServiceGroups()
        {
            return new HospitalRepository().getServiceGroups();
        }

        public HpPackage GetHpPackageById(int packageId)
        {
            return new HospitalRepository().GetHpPackageById(packageId);
        }

        public OPDServiceSubGroup GetOPDServiceSubGroupById(int subgroupId)
        {
            return new HospitalRepository().GetOPDServiceSubGroupById(subgroupId);
        }

        public bool SaveService(ServiceGroup _pService)
        {
            return new HospitalRepository().SaveService(_pService);
        }

        public IList<ServiceGroup> GetAllServices()
        {
            return new HospitalRepository().GetAllProvidedService();
        }

        public HospitalPatientInfo GetHospitalPatientByBillNoAny(long admissionNo)
        {
            return new HospitalRepository().GetHospitalPatientByBillNoAny(admissionNo);
        }

        public ServiceGroup GetServiceById(int sId)
        {
            return new HospitalRepository().GetServiceById(sId);
        }

        public List<VMIPDInfo> GetAdmittedPatientListByFloor(int floorId)
        {
            return new HospitalRepository().GetCurrentIPDInfoByFloor(floorId);
        }

        public List<VMedicineRequisition> GetRequisitionListByUserByDate(string username, DateTime _date)
        {
            return new HospitalRepository().GetRequisitionListByUserByDate(username, _date);
        }

        public bool UpdateHpSubGroup(ServiceSubGroup _ssgroup)
        {
            return new HospitalRepository().UpdateHpSubGroup(_ssgroup);
        }

        public List<VMSelectedOTServices> GetPastServices(long admissionId)
        {
            return new HospitalRepository().GetPastServices(admissionId);
        }

        public List<HpPatientAccomodationInfo> GetHpPatientExtraAccomodation(long admissionId)
        {
            return new HospitalRepository().GetHpPatientExtraAccomodation(admissionId);
        }

        public bool SaveHpSubGroup(ServiceSubGroup _ssgroup)
        {
            return new HospitalRepository().SaveHpSubGroup(_ssgroup);
        }

        public HospitalPatientInfo GetLastPatientById()
        {
            return new HospitalRepository().GetLastPatientById();
        }

        public ServiceSubGroup GetServiceSubGroupById(int _subGroupId)
        {
            return new HospitalRepository().GetServiceSubGroupById(_subGroupId);
        }

        public DischargeCertificateTemplateBased GetDischargeCertificate(long _billNo)
        {
            return new HospitalRepository().GetDischargeCertificate(_billNo);
        }

        public bool IsBillNoAlloted(long _billNo)
        {
            return new HospitalRepository().IsBillNoAlloted(_billNo);
        }

        public List<HpRequisitionType> GetRequisitionTypes()
        {
            return new HospitalRepository().GetRequisitionTypes();
        }

        public void  UpdateHospitalPatientInfo(HospitalPatientInfo _pInfo)
        {
             new HospitalRepository().UpdateHospitalPatientInfo(_pInfo);
        }

        public List<ServiceHead> GetAllServiceHeadBySubGroupId(int subGroupId)
        {
            return new HospitalRepository().GetAllServiceHeadBySubGroupId(subGroupId);
        }

        public List<VMHpReturnRequest> GetHpPendingReturnRequestList(int _floorId,int _outletId)
        {
            return new HospitalRepository().GetHpPendingReturnRequestList(_floorId, _outletId);
        }

        public HospitalPatientInfo GetHospitalPatientInfoById(long pId)
        {
            return new HospitalRepository().GetPatientInfoById(pId);
        }

        public HospitalPatientInfo GetFirstPatientById()
        {
            return new HospitalRepository().GetFirstPatientById();
        }

        public HospitalPatientInfo GetHospitalPatientInfoByRegNo(long regNo)
        {
            return new HospitalRepository().GetFirstPatientById(regNo);
        }

        public bool SaveServiceHead(ServiceHead _sh)
        {
            return new HospitalRepository().SaveServiceHead(_sh);
        }

        public string GetNewInvoiceNo()
        {
            int count = new HospitalRepository().GetNewInvoiceNo()+1;
            return count.ToString();
        }

        public HpPatientAccomodationInfo GetHpPatientCurrentAccomodation(long _admissionId)
        {
            return new HospitalRepository().GetHpPatientCurrentAccomodation(_admissionId);
        }

        public List<VMSelectedService> GetDeliveredFloorServices(long _admissionId)
        {
            return new HospitalRepository().GetDeliveredFloorServices(_admissionId);
        }

        public string UpdateDischargeCertificate(DischargeCertificateTemplateBased reportTest)
        {
            return new HospitalRepository().UpdateDischargeCertificate(reportTest);
        }

        public void UpdateCurrentAccomodation(HpPatientAccomodationInfo _hpAccomodation)
        {
             new HospitalRepository().UpdateCurrentAccomodation(_hpAccomodation);
        }

        public async Task<HpMedicineRequisition> CreateNewIPdPhRequistion(HpMedicineRequisition hpMReq, List<HpMedicineRequisitionDetail> reqDetailsList)
        {
            return await new HospitalRepository().CreateNewIPdPhRequistion(hpMReq, reqDetailsList);
        }

        public List<HpMedicineRequisition> GetUnservedRequisitionList()
        {
            return new HospitalRepository().GetUnservedRequisitionList();
        }

        public DataSet GetAdmissinDetails(long _admissionNo)
        {
            return new HospitalRepository().GetPatientAdmissionDetails(_admissionNo);
        }

        public IList<VMIPDInfo> GetCurrentIPDInfoBySearchParameter(string _prefix, string type)
        {
            return new HospitalRepository().GetCurrentIPDInfoBySearchParameter(_prefix, type);
        }

        public async Task<List<VMIPDInfo>> GetCurrentIPDInfo()
        {
            return await new HospitalRepository().GetCurrentIPDInfo();
        }

        public void PopulateSelectedServiceData(IList<Model.Hospital.ViewModel.VMSelectedOTServices> _SelectedOTServices, Model.Hospital.ServiceHead _Servicehead, Doctor _doctor, double _Rate, double _Qty, string _userName)
        {
            int ServiceId;
            ServiceId = _Servicehead.ServiceHeadId;
            if (_Servicehead == null) return;
            if (_doctor == null) return;

           // if (_SelectedOTServices.Any(x => x.ServiceHeadId == ServiceId)) return;

            _SelectedOTServices.Add(GetPreparedSelectedItemObject(_Servicehead, _doctor, _Rate, _Qty, _userName));
        }

        public HospitalPatientInfo GetIPDInfoByBillNo(long _billNo)
        {
            return new HospitalRepository().GetIPDInfoByBillNo(_billNo);
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
            sos.ServiceCharge = GetServiceChargeByHeadId(_Servicehead.ServiceHeadId, _Rate * _Qty);
            sos.Amount = _Rate * _Qty;
            sos.EnteredBy = _userName;
            return sos;
        }

        public List<VMSelectedDoctorService> GetDeliveredDoctorConsultancies(long _admissionId)
        {
            return new HospitalRepository().GetDeliveredDoctorConsultancies(_admissionId);
        }

        private double GetServiceChargeByHeadId(int headId, double amount)
        {
            ServiceHead _shead = GetServiceHeadById(headId);
            if (_shead != null)
            {
                if (_shead.ServiceCharge)
                {
                    return (amount * 25) / 100;   //Service charge hard-coded here will be taken later from DB
                }
            }

            return 0;
        }

        //private ServiceHead GetServiceHeadById(int headId)
        //{
        //    return new HospitalRepository().GetServiceHeadById(headId);
        //}

        public long SaveOTSchedule(OTSchedule _schedule)
        {
            return new HospitalRepository().SaveOTSchedule(_schedule);
        }

        public List<VMIPDInfo> GetDischargeCertificateList(string _prefix, string type, DateTime _date)
        {
            return new HospitalRepository().GetDischargeCertificateList(_prefix, type, _date);
        }

        public bool SaveOTExecutioDetails(List<OTExecutionDetail> _otelist)
        {
            return new HospitalRepository().SaveOTExecutioDetails(_otelist);
        }

        public void PopulateSelectedServices(IList<VMSelectedService> _SelectedServices, ServiceHead _Servicehead, DateTime _serviceDate, double _Rate, int _Qty, string _userName)
        {
            int ServiceId;
            ServiceId = _Servicehead.ServiceHeadId;
            if (_Servicehead == null) return;
           
           // if (_SelectedServices.Any(x => x.ServiceHeadId == ServiceId)) return;

            _SelectedServices.Add(GetPreparedSelectedServiceObject(_Servicehead, _serviceDate, _Rate, _Qty, _userName));
        }

        private VMSelectedService GetPreparedSelectedServiceObject(ServiceHead _Servicehead, DateTime _serviceDate, double _Rate, int _Qty, string _userName)
        {
            VMSelectedService ss = new VMSelectedService();
            ss.ServiceHeadId = _Servicehead.ServiceHeadId;
            ss.ServiceHeadName = _Servicehead.ServiceHeadName;
            ss.Rate = _Rate;
            ss.Qty = _Qty;
            ss.ServiceCharge = GetServiceChargeByHeadId(_Servicehead.ServiceHeadId, _Rate * _Qty);
            ss.Amount = _Rate * _Qty;
            ss.ServiceDate = _serviceDate;
            ss.EnteredBy = _userName;
            return ss;
        }

        public long SaveDoctorServiceBill(HpDoctorServiceBill _hpsb)
        {
            return new HospitalRepository().SaveDoctorServiceBill(_hpsb);
        }

        public bool SaveServiceBillDetails(List<ServiceBillDetail> _sbillList)
        {
            return new HospitalRepository().SaveServiceBillDetails(_sbillList);
        }

        public HpPatientAccomodationInfo GetHpAccomInfo(long accomId)
        {
            return new HospitalRepository().GetHpAccomInfo(accomId);
        }

        public void PopulateSelectedDoctorServiceData(IList<VMSelectedDoctorService> _SelectedDoctorServices, ServiceHead _Servicehead, Doctor _doctor, double _Rate, double _Qty, DateTime _ServiceDate, string _userName)
        {
            int ServiceId;
            ServiceId = _Servicehead.ServiceHeadId;
            if (_Servicehead == null) return;
            if (_doctor == null) return;
           // if (_SelectedDoctorServices.Any(x => x.ServiceHeadId == ServiceId)) return;

            _SelectedDoctorServices.Add(GetPreparedSelectedDoctorObject(_Servicehead, _doctor, _Rate, _Qty, _ServiceDate, _userName));
        }

        public void SaveHpPatientAccomadationInfo(HpPatientAccomodationInfo _currentAccomodation)
        {
              new HospitalRepository().SaveHpPatientAccomadationInfo(_currentAccomodation);
        }

        public List<FloorInfo> GetFloors()
        {
            return new HospitalRepository().GetFloors();
        }

        public long SaveRequisition(HpMedicineRequisition _hpMReq)
        {
            return new HospitalRepository().SaveRequisition(_hpMReq);
        }

        private VMSelectedDoctorService GetPreparedSelectedDoctorObject(ServiceHead _Servicehead, Doctor _doctor, double _Rate, double _Qty,DateTime _ServiceDate, string _userName)
        {
            VMSelectedDoctorService _sds = new VMSelectedDoctorService();
            _sds.ServiceHeadId = _Servicehead.ServiceHeadId;
            _sds.ServiceHeadName = _Servicehead.ServiceHeadName;
            _sds.DoctorId = _doctor.DoctorId;
            _sds.DoctorName = _doctor.Name;
            _sds.Rate = _Rate;
            _sds.Qty = _Qty;
            _sds.ServiceCharge = GetServiceChargeByHeadId(_Servicehead.ServiceHeadId, _Rate * _Qty);
            _sds.Amount = _Rate * _Qty;
            _sds.ServiceDate = _ServiceDate;
            _sds.ServiceTime = _ServiceDate.ToShortTimeString();
            _sds.CreatedBy = _userName;
            _sds.ModifiedBy = _userName;

            return _sds;
        }

        public bool SaveRequisitionDetails(List<HpMedicineRequisitionDetail> _reqDetailsList)
        {
            return new HospitalRepository().SaveRequisitionDetails(_reqDetailsList);
        }

        public bool SaveDoctorServiceDetails(List<DoctorServiceBillDetail> _dsblist)
        {
            return new HospitalRepository().SaveDoctorServiceDetails(_dsblist);
        }

        public HospitalPatientInfo GetHospitalPatientByBillNo(long _billNo)
        {
            return new HospitalRepository().GetHospitalPatientByBillNo(_billNo);
        }

        public HospitalPatientInfo GetLatestAdmittedPatient()
        {
            return new HospitalRepository().GetLatestAdmittedPatient();
        }

        public HpMedicineRequisition GetHpMedicineRequisitionByReqId(long _reqId)
        {
            return new HospitalRepository().GetHpMedicineRequisitionByReqId(_reqId);
        }

        public List<VMedicineRequisition> GetHpPendingRequisitionList(int _floorId,int _outletId)
        {
            return new HospitalRepository().GetHpPendingRequisitionList(_floorId, _outletId);
        }

        public List<VMRequisitionList> GetHpMedicineRequisitionDetailByReqId(long requisitionId, int _outLetId)
        {
            return new HospitalRepository().GetHpMedicineRequisitionDetailByReqId(requisitionId, _outLetId);
        }
        //public List<VMOutletRequisitionList> GetPhMedicineRequisitionDetailByReqId(long requisitionId, int _outLetId)
        //{
        //    return new HospitalRepository().GetPhMedicineRequisitionDetailByReqId(requisitionId, _outLetId);
        //}

        public void UpdateRequisition(HpMedicineRequisition _Mreq)
        {
            new HospitalRepository().UpdateRequisition(_Mreq);
        }

        public List<VMIPDInfo> GetCurrentIPDInfoByFloor(int _floorId)
        {
            return  new HospitalRepository().GetCurrentIPDInfoByFloor(_floorId);
        }

        public bool UpdateAllotedCabin(HpPatientAccomodationInfo _pAccomInfo)
        {
            return new HospitalRepository().UpdateAllotedCabin(_pAccomInfo);
        }

        public List<HpMedicineRequisitionDetail> GetHpMedicineRequisitionDetailById(long requisitionId)
        {
            return new HospitalRepository().GetHpMedicineRequisitionDetailById(requisitionId);
        }

        public void UpdateRequisitionProductDeliveryStatus(List<PhInvoiceDetail> _invList,List<HpMedicineRequisitionDetail> _reqList)
        {
            new HospitalRepository().UpdateRequisitionProductDeliveryStatus(_invList, _reqList);
        }

        public void UpdateRequisitionProductPartialDeliveryStatus(long _requisitionId, List<PhInvoiceDetail> _inVDetail)
        {
            new HospitalRepository().UpdateRequisitionProductPartialDeliveryStatus(_requisitionId,_inVDetail);
        }

        public IList<VMIPDInfo> GetCurrentIPDInfoByDept(int _deptId)
        {
            return new HospitalRepository().GetCurrentIPDInfoByDept(_deptId);
        }

        public IList<VMIPDInfo> GetCurrentOPDInfoBySearchParameter(string _prefix, string type)
        {
            return new HospitalRepository().GetCurrentOPDInfoBySearchParameter(_prefix, type);
        }

        public void PopulateSelectedOPDServices(IList<VMSelectedService> selectedServices, VMOPDServiceHead servicehead, double rate, int qty, string name)
        {
            int ServiceId;
            ServiceId = servicehead.ServiceHeadId;
            if (servicehead == null) return;

            selectedServices.Add(GetPreparedOPDSelectedServiceObject(servicehead, rate, qty, name));
        }

        private VMSelectedService GetPreparedOPDSelectedServiceObject(VMOPDServiceHead servicehead, double rate, int qty, string name)
        {
            VMSelectedService ss = new VMSelectedService();
            ss.ServiceHeadId = servicehead.ServiceHeadId;
            ss.ServiceHeadName = servicehead.ServiceHeadName;
            ss.Rate = rate;
            ss.Qty = qty;
            ss.ServiceCharge = GetServiceChargeByHeadId(servicehead.ServiceHeadId, rate * qty);
            ss.Amount = rate * qty;
   
            ss.EnteredBy = name;
            return ss;
        }

        public bool IsCabinChargeApplied(VMIPDInfo patient, DateTime currentDateTime)
        {
            return new HospitalRepository().IsCabinChargeApplied(patient, currentDateTime);
        }

        public bool IsAnyIpdServiceProvided(VMIPDInfo patient)
        {
            return new HospitalRepository().IsAnyIpdServiceProvided(patient);
        }
    }
}
