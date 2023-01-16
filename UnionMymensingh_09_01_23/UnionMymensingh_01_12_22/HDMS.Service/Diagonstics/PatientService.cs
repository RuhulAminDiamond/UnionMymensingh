using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Repository.Diagonstics;
using HDMS.Repository.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.ViewModel;
using HDMS.Model.Diagnostic;
using HDMS.Model.OPD;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Hospital.ViewModel;

namespace HDMS.Service.Diagonstics
{
     public class PatientService
     {

        public Task<List<VMDiagPatientBasicInfo>> GetDiagnosticPatienInfo(DateTime dtpfrm, DateTime dtpto)
        {
            return new PatientRepository().GetDiagnosticPatienInfo(dtpfrm, dtpto);
        }

        public long SavePatient(Patient patient)
        {
           return new PatientRepository().SavePatient(patient);
         
        }
        public int GetNumberofPatient(LoginUser loginUser)
        {
            return new PatientRepository().GetNumberofPatientOfUserByDate(loginUser.UserId, DateTime.Now);
        }

        public int GetLastRegistrtionNo()
        {
            return new PatientRepository().GetLastRegistrtionNo();
        }

        public List<VMDiagPatientAndTestDetail> GetDiagUndeliveredTestDetailByDateAndTime(DateTime dtpfrm, DateTime _time, int _ReportTypeId,string _ipdOpd)
        {
            return new PatientRepository().GetDiagUndeliveredTestDetailByDateAndTime(dtpfrm, _time, _ReportTypeId, _ipdOpd);
        }

        public OPDPatientRecord GetOPDPatientByBillNo(long _billNo)
        {
            return new PatientRepository().OPDPatientRecord(_billNo);
        }

        public OPDPatientRecord GetOPDPatientByIdNo(long pId)
        {
            return new PatientRepository().OPDPatientRecordByIdNo(pId);
        }

        public List<VMDiagPatient> GetDiagPatientByDate(DateTime dtp1, string _type)
        {
            return new PatientRepository().GetDiagPatientByDate(dtp1, _type);
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPatientAndTestDetailByDate(DateTime dtp1)
        {
            return new PatientRepository().GetDiagPatientAndTestDetailByDate(dtp1);
        }

        public Patient GetPatientById(long billNo)
        {
            return new PatientRepository().GetPatientById(billNo);
        }

        public List<VMDiagPatientAndTestDetail> GetDiagDeliveredTestDetailByDateAndTime(DateTime dtpfrm, DateTime _time, int _ReportTypeId, string _IpdOpd)
        {
            return new PatientRepository().GetDiagDeliveredTestDetailByDateAndTime(dtpfrm, _time, _ReportTypeId, _IpdOpd);
        }

        public object GetLastIdOfToday()
        {
            return new PatientRepository().GetLastDailyId(DateTime.Now);
        }

        public Patient GetPatientByIdNo(long _PatientId)
        {
            return new PatientRepository().GetPatientByIdNo(_PatientId);
        }

        public Patient GetPatientByRegNoFromLegacy(string regNo)
        {
            return new PatientRepository().GetPatientByRegNoFromLegacy(regNo);
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPatientAndTestDetailByPatientId(long patientId)
        {
            return new PatientRepository().GetDaigPatientAndTestDetailsByPatientId(patientId);
        }

        public int GetNextServiceId(long regNo)
        {
            return Convert.ToInt32(new PatientRepository().GetNextServiceId(regNo)) + 1;
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPrintedOrDeliveredReportsByPatientId(long patientId)
        {
            return new PatientRepository().GetDaigPatientOrDeleveredReportsByPatientId(patientId);
        }

        public List<TestsCost> GetSampleCollectedTests(long _pId)
        {
            return new PatientRepository().GetSampleCollectedTests(_pId);
        }

        public int GetDailyId(DateTime dateTime)
        {
            return Convert.ToInt32(new PatientRepository().GetDailyId(dateTime)) + 1;
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPatientAndTestDetailByBillNo(long billNo)
        {
            return new PatientRepository().GetDiagPatientAndTestDetailByBillNo(billNo);
        }

        public Patient GetPatientBySerial(long serial)
        {
            return new PatientRepository().GetPatientBySerial(serial);
        }

        public bool CancelTest(long _regNo, int _itemId, int UserId, string Remarks)
        {
            return new PatientRepository().CancelTest(_regNo, _itemId, UserId, Remarks);
        }

        public List<Patient> GetIndoorPatientList()
        {
            return new PatientRepository().GetIndoorPatientList();
        }

        public List<VMDiagPatientAndTestDetail> GetDiagPrintedOrDeliveredReportsByBillNo(long billNo)
        {
            return new ReportRepository().GetDiagPrintedOrDeliveredReportsByBillNo(billNo);
        }

        public double GetCurrentBalance(long RegNo)
        {
            return new PatientRepository().GetCurrentBalance(RegNo);
        }

        public bool UpdatePatientInfo(Patient _PatinetInfo)
        {
            return new PatientRepository().UpdatePatientInfo(_PatinetInfo);
        }

        public Patient GetDiagPatientById(long _pId)
        {
            return new PatientRepository().GetDiagPatientById(_pId);
        }

        public bool CancelPatient(long _regNo, string cancelledby, string Remarks)
        {
            return new PatientRepository().CancelPatient(_regNo, cancelledby, Remarks);
        }

        public Patient GetPatientByReportPrefixAndId(string _prefix, long _reportId)
        {
            return new PatientRepository().GetPatientByReportPrefixAndId(_prefix, _reportId);
        }

        public string GetInitialTestCost(long _regNo)
        {
            PatientLedger _ledger = new PatientRepository().GetPatientLedger(_regNo,TransactionTypeEnum.TestCost.ToString());

            if (_ledger == null)
            {
                return "0";
            }
            else
            {
                return _ledger.Debit.ToString();
            }
        }

        public Model.ViewModel.VMPatientPaymentInfo GetPatientPaymentInfo(int RegNo)
        {
            return new PatientRepository().GetPatientPaymentInfo(RegNo);
        }

        public List<PatientLedger> GetPatientLedgerById(long _PId)
        {
            return new PatientRepository().GetPatientLedgerById(_PId);
        }

        public void SetDuecollectionDateOnDailyStatement(long regNo)
        {
             new PatientRepository().SetDuecollectionDateOnDailyStatement(regNo);
        }

        public void SetUSGDoctorOnDailyStatement(string _regNo, ReportConsultant _doctor)
        {
            new PatientRepository().SetUSGDoctorOnDailyStatement(_regNo, _doctor);
        }

        public void AdjustDailyStatement(long _regNo, string testGroup, double _Cost)
        {
            double _groupAmount = new PatientRepository().GetGroupAmountFromDailyStatementByPatientId(_regNo,testGroup);
            double _dueAmount= new PatientRepository().GetDueAmountFromDailyStatementByPatientId(_regNo);

            if(_Cost>=_dueAmount) {
                _dueAmount = 0;
            }
            else
            {
                _dueAmount = _dueAmount - _Cost;
            }

            _groupAmount = _groupAmount - _Cost;



            new PatientRepository().AdjustDailyStatement(_regNo, testGroup, _groupAmount, _dueAmount);
        }



        public void SetDueOnDailyStatement(int regNo, double _due, double _less)
        {
            new PatientRepository().SetDueOnDailyStatement(regNo, _due, _less);
        }

        public Patient GetPatientByRxId(long _RxId)
        {
            return new PatientRepository().GetPatientByRxId(_RxId);
        }

        public Patient GetLastReceivedPatientByUser(int _UserId)
        {
            return new PatientRepository().GetLastReceivedPatientByUser(_UserId);
        }

        public Patient GetFirstReceivedPatientByUser(int _UserId)
        {
            return new PatientRepository().GetFirstReceivedPatientByUser(_UserId);
        }

        public List<Patient> GetPatientIdsByRegNo(long _regNo)
        {
            return new PatientRepository().GetPatientIdsByRegNo(_regNo);
        }

        public void IsApproveCancelTest(long patientId, int itemId, int userId, string remarks, bool isApprove)
        {
             new PatientRepository().IsApproveCancelTest(patientId, itemId, userId, remarks, isApprove);
        }

        public double GetDiscountAmount(long patientId)
        {
            return new PatientRepository().GetDiscountAmount(patientId);
        }

        public double GetPaidTk(long patientId)
        {
            return new PatientRepository().GetPaidTk(patientId);
        }

        public List<TestsCost> GetTestList(long _PatientId)
        {
            return new PatientRepository().GetTestList(_PatientId);
        }

        public int GetNumberofPatientOfUserByDate(DateTime _dt, LoginUser loginUser)
        {
            return new PatientRepository().GetNumberofPatientOfUserByDate(loginUser.UserId, _dt);
        }

        public Patient GetPatientByBillNo(long _billNo)
        {
            return new PatientRepository().GetPatientByBillNo(_billNo);
        }

        public List<TestGroup> GetTestGroupsByPatientId(long _PId)
        {
            return new PatientRepository().GetTestGroupsByPatientId(_PId);
        }

        public string GetMovementString(List<TestGroup> _tGroups)
        {

            //return "";
            int _order = 1;
            string _messasge = string.Empty;
            string _sampleCollectionRoom = string.Empty;
            bool IsLaboratory = false;
            bool IsUSG = false;
            bool IsXray = false;
            bool IsCTScan = false;
            bool IsMRI = false;
            bool IsECG = false;
            bool IsEcho = false;
            bool IsUroflowmetry = false;
            bool IsNCV = false;
            bool IsEEG = false;
            bool IsHolter = false;
            bool IsETT = false;
            bool IsEndo = false;
            bool IsColon = false;
            bool IsERCP = false;
            bool IsBMD = false;

            if (_tGroups.Any(x => x.TestGroupId == 29))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 29).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "USG (Room-"+ _tGroup.MovementRoomNo + ") ";
                _order++;
            }



            foreach (var group in _tGroups)
            {
                
                if (group.TestGroupId == 1 || group.TestGroupId == 15 || group.TestGroupId == 18 || group.TestGroupId == 21 || group.TestGroupId == 26 || group.TestGroupId == 34)
                {
                    if (!IsLaboratory)
                    {
                        //if (!String.IsNullOrEmpty(_messasge))
                        //{
                        //    _messasge = _messasge + "  " + _order.ToString() + "." + group.DeptName+" ";
                        //    _order++;
                        //}
                        //else
                        //{
                        //    _messasge = _order.ToString() + "." + group.DeptName+" ";
                        //    _order++;
                        //}

        
                    }

                    IsLaboratory = true;
                    _sampleCollectionRoom = group.MovementRoomNo;
                }

            }

            if (IsLaboratory)
            {
                _messasge = _messasge + " " + _order.ToString() + "." + "Sample Collection (Room-" + _sampleCollectionRoom + ") ";
                _order++;
            }


            if (_tGroups.Any(x => x.TestGroupId == 31))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 31).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "X-Ray (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }



            if (_tGroups.Any(x => x.TestGroupId == 5))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 5).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "CT-Scan (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }


            if (_tGroups.Any(x => x.TestGroupId == 22))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 22).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "MRI (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }


            if (_tGroups.Any(x => x.TestGroupId == 8))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 8).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "ECG (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 9 || x.TestGroupId==4))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 9 || x.TestGroupId==4).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "ECHO (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 10))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 10).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "EEG (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 33))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 33).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "Duplex Study (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 23))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 23).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "NCV & EMG (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 28))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 28).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "Uroflometry (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 13))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 13).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "ETT (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 3))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 3).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "Colonoscopy (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            if (_tGroups.Any(x => x.TestGroupId == 11))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 11).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "Endoscopy (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }


            if (_tGroups.Any(x => x.TestGroupId == 11))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 11).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "Endoscopy (Room-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }


            if (_tGroups.Any(x => x.TestGroupId == 16))
            {
                TestGroup _tGroup = _tGroups.Where(x => x.TestGroupId == 16).FirstOrDefault();
                _messasge = _messasge + " " + _order.ToString() + "." + "FNAC (Lab-" + _tGroup.MovementRoomNo + ") ";
                _order++;
            }

            return _messasge;
        }

        public bool UpdateOPdPatientInfo(OPDPatientRecord _oPDPatient)
        {
            return new PatientRepository().UpdateOPdPatientInfo(_oPDPatient);
        }

        public async Task<List<Patient>> GetSampleCollecTablePatientList(DateTime _EntryDate)
        {
            return await new PatientRepository().GetSampleCollecTablePatientList(_EntryDate);
        }

        public List<VMRequestOnDischargedResult> GetInvestigationsOnDischarge(long billNo)
        {
            return new PatientRepository().GetInvestigationsOnDischarge(billNo);
        }

        public List<VWTestItem> GetTestItemsByPatientId(long patientId)
        {
            return new PatientRepository().GetTestItemsByPatientId(patientId);
        }

        public bool IsBillNoAlloted(long _billNo)
        {
            return new PatientRepository().IsBillNoAlloted(_billNo);
        }

        public int GetReportIdForThisPatient()
        {
            return new PatientRepository().GetReportIdForThisPatient();
        }

        public Patient GetRfCommission(long patientId)
        {
            return new PatientRepository().GetRfommission(patientId);
        }

        public List<VMRfCommission> GetRfCommissionWithMeidaId(long patientId, int mediaId)
        {
            return new PatientRepository().GetRfCommissionWithMeidaId(patientId, mediaId);
        }

        public List<VMRfCommission> GetMediaDiscountByPatientId(long patientId, int mediaId)
        {
            return new PatientRepository().GetMediaDiscountByPatientId(patientId, mediaId);
        }

        public List<OPDPatientLedgerRough> GetOPDPatientLedgerRoughById(long _PId)
        {
            return new PatientRepository().GetOPDPatientLedgerRoughById(_PId);
        }

        public List<Patient> GetDiagPatientsByHpBillNo(long hpbill)
        {
            return new PatientRepository().GetDiagPatientsByHpBillNo(hpbill);
        }

        public double GetDrDiscountAmount(long patientId)
        {
            return new PatientRepository().GetDrDiscountAmount(patientId);
        }

        public bool UpdatePatinetMediaId(long patientId)
        {
            return new PatientRepository().UpdatePatinetMediaId(patientId);
        }

        public void IsApproveCancelPatient(long patientId, int userId, string text, bool isApprove)
        {
            new PatientRepository().IsApproveCancelPatient(patientId, userId, text, isApprove);
        }

        public bool GetApproveByAdminCheck(long patientId)
        {
            return new PatientRepository().GetApproveByAdminCheck(patientId);
        }

        public bool IsAnyDueInInvestigationDone(VMIPDInfo ipdPatient)
        {
            return new PatientRepository().IsAnyDueInInvestigationDone(ipdPatient);
        }
    }
}
