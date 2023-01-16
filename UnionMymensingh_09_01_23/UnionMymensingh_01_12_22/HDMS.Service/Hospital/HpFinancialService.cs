using HDMS.Repository.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using System.Data;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model;
using HDMS.Common.Utils;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;

namespace HDMS.Service.Hospital
{
    public class HpFinancialService
    {
        public double GetHospitalBill(long _admissionId)
        {
            return new HpFinancialRepository().GetHospitalBill(_admissionId);
        }

        public double GetPathologyBill(long _admissionId)
        {
            return new HpFinancialRepository().GetPathologyBill(_admissionId);
        }

        public DataSet GetConsultentAndSergeonTeamCharge(DateTime dtpfrm, DateTime dtpto)
        {
            return new HpFinancialRepository().GetConsultentAndSergeonTeamCharge(dtpfrm, dtpto);
        }

        public DataSet GetHpSummaryStatement(DateTime dtpfrm, DateTime dtpto)
        {
            return new HpFinancialRepository().GetHpSummaryStatement(dtpfrm, dtpto);
        }

        public DataSet GetHpAdmittedAllPatientList(DateTime dtfrm, DateTime dtto)
        {
            return new HpFinancialRepository().GetHpAdmittedAllPatientList(dtfrm, dtto);
        }

        public HpDayWiseBill GetHospitalDayWiseBillByBillNo(long _hbillNo)
        {
            return new HpFinancialRepository().GetHospitalDayWiseBillByBillNo(_hbillNo);
        }

        public DataSet GetHpDailyCollection(DateTime dtpfrm, DateTime dtpto,int _deptId)
        {
            return new HpFinancialRepository().GetHpDailyCollection(dtpfrm, dtpto, _deptId);
        }

        public double GetMedicineBill(long _admissionId)
        {
            return new HpFinancialRepository().GetMedicineBill(_admissionId);
        }

        public HpDayWiseBill GetHpDayWisebillbyDaybillNo(long hbillNo)
        {
            return new HpFinancialRepository().GetHpDayWisebillbyDaybillNo(hbillNo);
        }

        public double GetDoctorBill(long _admissionId)
        {
            return new HpFinancialRepository().GetDoctorBill(_admissionId);
        }

        public List<HPDayWiseBillingLedger> GetPatientDayWiseLedgerFinalById(long hospitalBillId)
        {
            return new HpFinancialRepository().GetDayWiseBillingLedgerById(hospitalBillId);
        }

        public DataSet GetHpAdmittedOPDPatientList(DateTime dtfrm, DateTime dtto)
        {
            return new HpFinancialRepository().GetHpAdmittedOPDPatientList(dtfrm, dtto);
        }

        public DataSet GetDischargedPatient(DateTime dtpfrm, DateTime dtpto,int _deptId)
        {
            return new HpFinancialRepository().GetDischargedPatient(dtpfrm, dtpto, _deptId);
        }

        public HpParameterSetup GetAdmissionFee()
        {
            return new HpFinancialRepository().GetAdmissionFee();
        }

        public HospitalBill GetHospitalBillByBillNo(long _hbillNo)
        {
            return new HpFinancialRepository().GetHospitalBillByBillNo(_hbillNo);
        }

        public List<HpConsultantLedger> GetConsultantLedger(DateTime _datefrm, DateTime _dateto, int doctorId)
        {
            return new HpFinancialRepository().GetConsultantLedger(_datefrm, _dateto,doctorId);
        }

        public bool SaveHpLedgerTransaction(HpPatientLedger _hpLedger)
        {
            return new HpFinancialRepository().SaveHpLedgerTransaction(_hpLedger);
        }

        public List<VMFloorServiceEdit> GetFloorServiceList(long admissionId)
        {
            return new HpFinancialRepository().GetFloorServiceList(admissionId);
        }

        public double GetConsultantLedgerBalance(int doctorId)
        {
            return new HpFinancialRepository().GetConsultantLedgerBalance(doctorId);
        }

        public List<VMConsultancyEdit> GetOTServiceList(long admissionId)
        {
            return new HpFinancialRepository().GetOTServiceList(admissionId);
        }

        public List<VMConsultancyEdit> GetConsultancyProvidedList(long admissionId)
        {
            return new HpFinancialRepository().GetConsultancyProvidedList(admissionId);
        }

        public double GetPatientCurrentBalance(long _admissionId)
        {
            return new HpFinancialRepository().GetPatientCurrentBalance(_admissionId);
        }

        public void DeleteExistingCabinChargeCalculation(long admissionId)
        {
            new HpFinancialRepository().DeleteExistingCabinChargeCalculation(admissionId);
        }

        public DataSet GetHpDailyCollection_2(DateTime dtpfrm, DateTime dtpto, string _userName, int deptId)
        {
            return new HpFinancialRepository().GetHpDailyCollection_2(dtpfrm, dtpto, _userName, deptId);
        }

        public DataSet GetHpFinalBill(long _admissionId)
        {
            return new HpFinancialRepository().GetHpFinalBill(_admissionId);
        }

        public long SaveHpServiceBill(HpServiceBill _bService)
        {
            return new HpFinancialRepository().SaveHpServiceBill(_bService);
        }

        public void DeleteExistingFinalBill(long hospitalBillId)
        {
            new HpFinancialRepository().DeleteExistingFinalBill(hospitalBillId);
        }

        public List<HpPatientLedger> GetTransactionsByAdmissionId(long admissionId)
        {
            return new HpFinancialRepository().GetTransactionsByAdmissionId(admissionId);
        }

        public double GetConsultantCurrentBalance(int doctorId)
        {
            return new HpFinancialRepository().GetConsultantCurrentBalance(doctorId);
        }

        public HospitalBill GetHospitalBillByAdmissionId(long admissionId)
        {
            return new HpFinancialRepository().GetHospitalBillByAdmissionId(admissionId);
        }

        public DataSet GetHpDailyCollection_IPD(DateTime dtpfrm, DateTime dtpto, string _userName, int _deptId)
        {
            return new HpFinancialRepository().GetHpDailyCollection_IPD(dtpfrm, dtpto, _userName, _deptId);
        }

        public double GetAlreadySavedCabinCharge(long admissionId)
        {
            return new HpFinancialRepository().GetAlreadySavedCabinCharge(admissionId);
        }

        public List<VMHpFinalBill> GetHpFinalBillItems(long admissionId,bool IsAdmissionFeeApplicable)
        {
            return new HpFinancialRepository().GetHpFinalBillItems(admissionId, IsAdmissionFeeApplicable);
        }

        public void SaveCabinChargeRange(List<HpCabinCharge> _cabinChargeList)
        {
            new HpFinancialRepository().SaveCabinChargeRange(_cabinChargeList);
        }

        public DataSet GetConsultancyLedger(DateTime dtpfrm, DateTime dtpto, int doctorId)
        {
            return new HpFinancialRepository().GetConsultancyLedger(dtpfrm, dtpto, doctorId);
        }

        public double GetCabinCharge(long admissionId, DateTime _releasedate, string _releaseTime)
        {
            double _cabinCharge = 0;
            HpPatientAccomodationInfo _pAccomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(admissionId);

            if (_pAccomInfo != null)
            {
                CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_pAccomInfo.CabinId);
                int _daysInCabin = new CalculateCabinCharge().DaysInHospital(_pAccomInfo.AccomodateDate, _pAccomInfo.AccomodateTime, _releasedate, _releaseTime,0,false,false);
                _cabinCharge = _daysInCabin * _Cabin.Rent;
            }

            double _extrabedCharge = 0;

            List<HpPatientAccomodationInfo> _pAccomList = new HospitalCabinBedService().GetExtraCabinListByPatient(admissionId);

            foreach(HpPatientAccomodationInfo _item in _pAccomList)
            {
                CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_item.CabinId);
                int _daysInCabin = new CalculateCabinCharge().DaysInHospital(_item.AccomodateDate, _item.AccomodateTime, _releasedate, _releaseTime,0,false,false);
                _extrabedCharge = _extrabedCharge + _daysInCabin * _Cabin.Rent;
            }

            return _cabinCharge+ _extrabedCharge;
        }

        public DataSet GetHpDailyCollection_OPD(DateTime dtpfrm, DateTime dtpto, string _userName, int _deptId)
        {
            return new HpFinancialRepository().GetHpDailyCollection_OPD(dtpfrm, dtpto, _userName, _deptId);
        }

        public ServiceBillDetail GetFloorServiceById(long sBDId)
        {
            return new HpFinancialRepository().GetFloorServiceById(sBDId);
        }

        public int SaveOPDDistributedBill(OpdProcedureBillDistribution distributebill)
        {
            return new HpFinancialRepository().SaveOPDDistributedBill(distributebill);
        }

        public DataSet GetHpDailyCollection_3(DateTime dtpfrm, DateTime dtpto, string _userName, int deptId)
        {
            return new HpFinancialRepository().GetHpDailyCollection_3(dtpfrm, dtpto, _userName, deptId);
        }

        public OTExecutionDetail GetOTConsultancyServiceById(long dSBDId)
        {
            return new HpFinancialRepository().GetOTConsultancyServiceById(dSBDId);
        }

        public void DeleteFloorService(ServiceBillDetail _billDetail)
        {
            new HpFinancialRepository().DeleteFloorService(_billDetail);
        }

        public bool SaveFloorServiceDeleteLog(FloorServiceDeleteLog _dLog)
        {
            return new HpFinancialRepository().SaveFloorServiceDeleteLog(_dLog);
        }

        public DoctorServiceBillDetail GetConsultancyBillById(long dSBDId)
        {
            return new HpFinancialRepository().GetConsultancyBillById(dSBDId);
        }

        public bool SaveOpdProceduredistributionBillDetail(List<OpdProcedureBillDistributionDetail> obilldetaildistributionList)
        {
            return new HpFinancialRepository().SaveOpdProceduredistributionBillDetail(obilldetaildistributionList);
        }

        public void DeleteConsultancyService(DoctorServiceBillDetail _billDetail)
        {
             new HpFinancialRepository().DeleteConsultancyService(_billDetail);
        }

        public bool SaveConsultancyServiceDeleteLog(DoctorServiceDeleteLog _dLog)
        {
            return new HpFinancialRepository().SaveConsultancyServiceDeleteLog(_dLog);
        }

        public void DeleteOTConsultancyService(OTExecutionDetail _billDetail)
        {
            new HpFinancialRepository().DeleteOTConsultancyService(_billDetail);
        }

        public HpConsultantLedger GetConsultantLedgerByTransactionNo(long tranNo)
        {
            return new HpFinancialRepository().GetConsultantLedgerByTransactionNo(tranNo);
        }

        public void SaveHpConsultantTransactionUnit(HpConsultantLedger _hpcLedger)
        {
            new HpFinancialRepository().SaveHpConsultantTransactionUnit(_hpcLedger);
        }

        public double GetHpDayWisePatientBalance(int dayWiseBillId)
        {
            return new HpFinancialRepository().GetHpDayWisePatientBalance(dayWiseBillId);
        }

        public void SaveHpConsultantTransaction(List<HpConsultantLedger> _hpcLedger)
        {
             new HpFinancialRepository().SaveHpConsultantTransaction(_hpcLedger);
        }

        public long SaveOpdProcedureBill(OpdProcedureBill pbill)
        {
          return  new HpFinancialRepository().SaveOpdProcedureBill(pbill);
        }

        public long SaveOPDProcedureServiceBill(OPDProcedureServiceBill oPDSbill)
        {
            return new HpFinancialRepository().SaveOPDProcedureServiceBill(oPDSbill);
        }

        public long SaveHpOpdProcedureBill(OpdProcedureBill pbill)
        {
            throw new NotImplementedException();
        }

        public void AccumulateHpFinalBill(long admissionId)
        {
            new HpFinancialRepository().AccumulateHpFinalBill(admissionId);
        }

        public void SaveHpLedgerTransactionList(List<HpPatientLedger> _hpLedegerList)
        {
            new HpFinancialRepository().SaveHpLedgerTransactionList(_hpLedegerList);
        }

        public double GetRoughAdvancePaymentByPatient(long admissionId)
        {
           return new HpFinancialRepository().GetRoughAdvancePaymentByPatient(admissionId);
        }

        public bool UpdateFloorServiceBill(ServiceBillDetail _billDetail)
        {
            return new HpFinancialRepository().UpdateFloorServiceBill(_billDetail);
        }

        public double GetOTDoctorBill(long admissionId)
        {
           return new HpFinancialRepository().GetOTDoctorBill(admissionId);
        }

        public long SaveHpFinalBill(HospitalBill _hbill)
        {
            return new HpFinancialRepository().SaveHpFinalBill(_hbill);
        }

        public bool SaveHpFinalBillDetail(List<HospitalBillDetail> _hbilldetailList)
        {
            return new HpFinancialRepository().SaveHpFinalBillDetail(_hbilldetailList);
        }
        public bool SaveOpdProcedureBillDetail(List<OpdProcedureBillDetails> _hbilldetailList)
        {
            return new HpFinancialRepository().SaveOpdProcedureBillDetail(_hbilldetailList);
        }

        public void SaveHpFinalLedger(List<HpPatientLedgerFinal> transactionList)
        {
            new HpFinancialRepository().SaveHpFinalLedger(transactionList);
        }
        public void SaveOpdProcedureLedger(List<OpdProcedurepatientLedger> transactionList)
        {
            new HpFinancialRepository().SaveOpdProcedureLedger(transactionList);
        }

        public List<HpPatientLedgerFinal> GetPatientLedgerFinalById(long _billId)
        {
           return new HpFinancialRepository().GetPatientLedgerFinalById(_billId);
        }
        public List<OpdProcedurepatientLedger> GetProcedurePatientLedgerFinalById(long _billId)
        {
            return new HpFinancialRepository().GetProcedurePatientLedgerFinalById(_billId);
        }

        public DataSet GetHpCashMemo(long _billId)
        {
          return  new HpFinancialRepository().GetHpCashMemo(_billId);
        }
        public DataSet GetOpdCashMemo(long _billId)
        {
            return new HpFinancialRepository().GetOpdCashMemo(_billId);
        }

        public HospitalBill GetHospitalBillById(long _billId)
        {
            return new HpFinancialRepository().GetHospitalBillById(_billId);
        }
        public OpdProcedureBill GetOpdProcedureBillById(long _billId)
        {
            return new HpFinancialRepository().GetOpdProcedureBillById(_billId);
        }

        public void SaveHpDayWiseFinalLedger(List<HPDayWiseBillingLedger> transactionList)
        {
             new HpFinancialRepository().SaveHpDayWiseFinalLedger(transactionList);
        }

        public List<VMHpFinalBill> GetHpCabinBillItems(long admissionId, bool isAdmissionFeeApplicable)
        {
            return new HpFinancialRepository().GetHpCabinBillItems(admissionId, isAdmissionFeeApplicable);
        }

        public void SaveCabinCharge(HpCabinCharge _HpcabinCharge)
        {
            new HpFinancialRepository().SaveCabinCharge(_HpcabinCharge);
        }

        public bool DeleteExistingBill(long admissionId)
        {
           return new HpFinancialRepository().DeleteExistingBill(admissionId);
        }

        public double GetHpPatientBalance(long hospitalBillId)
        {
            return new HpFinancialRepository().GetHpPatientBalance(hospitalBillId);
        }

        public void SaveAdvancePayment(HpAdvancePayment _advPayment)
        {
            new HpFinancialRepository().SaveAdvancePayment(_advPayment);
        }

        public double GetAdvancePaymentByPatient(long admissionId)
        {
           return new HpFinancialRepository().GetAdvancePaymentByPatient(admissionId);
        }

        public void UpdateHospitalBill(HospitalBill hbill)
        {
            new HpFinancialRepository().UpdateHospitalBill(hbill);
        }

        public List<HpPatientLedgerRough> GetRoughAdvancePaymentList(long admissionId)
        {
            return new HpFinancialRepository().GetRoughAdvancePaymentList(admissionId);
        }

        public long SaveHpRoughBill(HospitalRoughBill _hbill)
        {
            return new HpFinancialRepository().SaveHpRoughBill(_hbill);
        }

        public bool SaveHpRoughBillDetail(List<HospitalRoughBillDetail> _hbilldetailList)
        {
            return new HpFinancialRepository().SaveHpRoughBillDetail(_hbilldetailList);
        }

        public bool UpdateOTServiceBill(OTExecutionDetail _billDetail)
        {
            return new HpFinancialRepository().UpdateOTServiceBill(_billDetail);
        }

        public void SaveHpRoughLedger(List<HpPatientLedgerRough> transactionList)
        {
             new HpFinancialRepository().SaveHpRoughLedger(transactionList);
        }

        public bool UpdateDoctorServiceBill(DoctorServiceBillDetail _billDetail)
        {
           return new HpFinancialRepository().UpdateDoctorServiceBill(_billDetail);
        }

        public List<HpPatientLedgerFinal> GetAdvancePaymentList(long admissionId)
        {
            return  new HpFinancialRepository().GetAdvancePaymentList(admissionId);
        }

        public DataSet GetHpRoughCashMemo(long _billId)
        {
            return new HpFinancialRepository().GetHpRoughCashMemo(_billId);
        }

        public List<HpPatientLedgerRough> GetPatientLedgerRoughById(long _billId)
        {
            return new HpFinancialRepository().GetPatientLedgerRoughById(_billId);
        }

        public HospitalRoughBill GetHospitalRoughBillById(long _billId)
        {
            return new HpFinancialRepository().GetHospitalRoughBillById(_billId);
        }

        public HospitalRoughBill GetHospitalRoughBillByAdmissionId(long admissionId)
        {
            return new HpFinancialRepository().GetHospitalRoughBillByAdmissionId(admissionId);
        }

        public DataSet GetConsultancyDetailsByPatientId(long admissionId)
        {
            return new HpFinancialRepository().GetConsultancyDetailsByPatientId(admissionId);
        }

        public DataSet GetCabinChargeDetails(long admissionId)
        {
            return new HpFinancialRepository().GetCabinChargeDetails(admissionId);
        }

        public DataSet GetInPatientCareServiceByPatientId(long admissionId)
        {
            return new HpFinancialRepository().GetInPatientCareServiceByPatientId(admissionId);
        }

        public async Task<VMHospitalBillCarrierObj2> SaveAndGetHpFinalBill(VWHpEndPointDataCarrier carrierDataObj)
        {
            return await new HpFinancialRepository().SaveAndGetHpFinalBill(carrierDataObj);
        }

        public List<HpAdvancePayment> GetAdvancePayments(long admissionId)
        {
            return  new HpFinancialRepository().GetAdvancePayments(admissionId);
        }

        public void SaveOPDAdvancePayment(OPDAdvancePayment advancePayment)
        {
            new HpFinancialRepository().SaveOPDAdvancePayment(advancePayment);
        }

        public int SaveDayWiseBillBill(HpDayWiseBill dayWisebill)
        {
            return new HpFinancialRepository().SaveDayWiseBillBill(dayWisebill);
        }

        public bool SaveHPDayWiseBillDetails(List<HpDayWiseBillDetail> dayWiseBillDetailsList)
        {
            return new HpFinancialRepository().SaveHPDayWiseBillDetails(dayWiseBillDetailsList);
        }

        public void SaveDayWiseBillingLedger(List<HPDayWiseBillingLedger> transactionList)
        {
            new HpFinancialRepository().SaveDayWiseBillingLedger(transactionList);
        }

        public List<VMHpFinalBill> GetHpDayWiseBillItems(long admissionId, string _startDateTime, string _endDateTime, bool IsAdmissionFeeApplicable)
        {
            return new HpFinancialRepository().GetHpDayWiseBillItems(admissionId, _startDateTime, _endDateTime, IsAdmissionFeeApplicable);
        }

        public List<HPDayWiseBillingLedger> GetDayWiseBillingLedgerById(long billId)
        {
            return new HpFinancialRepository().GetDayWiseBillingLedgerById(billId);
        }

        public DataSet GetDayWiseBillCashMemo(long _billId)
        {
            return new HpFinancialRepository().GetDayWiseBillCashMemo(_billId);
        }

        public async Task<VMHospitalDayWiseBillCarrier2> SaveAndGetDayWiseBill(VMHospitalDayWiseBillCarrier carrierDataObj)
        {
            return await new HpFinancialRepository().SaveAndGetDayWiseBill(carrierDataObj);
        }

       
    }
}
