using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.ViewModel;
using HDMS.Repository.Diagonstics;
using HDMS.Repository.ServiceObjects;
using Models.Accounting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.LIS;
using HDMS.Model.MiniAccount;

namespace HDMS.Service.Diagonstics
{
    public class ReportService
    {
        SqlDataAdapter da;

        public async Task<DataSet> GetCashMemo(long _PatientId)
        {
            return await new ReportRepository().GetCashMemo(_PatientId);
        }

        public DataSet GetAllDiagDeailySaleSummary(DateTime dtpFrom, DateTime dtpTo)
        {
            return new ReportRepository().GetAllDiagDeailySaleSummary(dtpFrom, dtpTo);
        }

        public DataSet GetOpdConsultancy(DateTime _startDateTime, DateTime _endDateTime, int _consultantId, string _userName)
        {
            return new ReportRepository().GetOpdConsultancy(_startDateTime, _endDateTime, _consultantId, _userName);
        }

        public List<VMPathologistServiceFee> GetAllPathlogisServiceFeeWithPatientId(DateTime dptFrom, DateTime dptTo)
        {
            return new ReportRepository().GetAllPathlogisServiceFeeWithPatientId(dptFrom, dptTo);
        }

        public List<PathologyReport> IsNotPaidConsultanPayment(DateTime dptFrom, DateTime dptTo, int doctorId)
        {
            return new ReportRepository().IsNotPaidConsultanPayment(dptFrom, dptTo, doctorId);
        }

        public DataSet GetHpDueList(DateTime dtp1, DateTime dtp2)
        {
            return new ReportRepository().GetHpDueList(dtp1, dtp2);
        }

        public DataSet GetDiagReagentUse(DateTime dafrm, DateTime dtto)
        {
            return new ReportRepository().GetDiagReagentUse(dafrm, dtto);
        }

        public DataTable GetDisticntTestGroupForPathologyReport(int RegNo)
        {
             return new ReportRepository().GetDisticntTestGroupForPathologyReport(RegNo);
        }

        public CashBookDto GetCashBookSummary()
        {
            return new ReportRepository().GetCashBookSummary();
        }

        public DataSet GetMediaLeadgerSummery(int mediaId, DateTime dateFrom, DateTime dateTo)
        {
            return new ReportRepository().GetMediaLeadgerSummery(mediaId, dateFrom, dateTo);
        }

        public DataSet GetUnpaidMediaStatement(DateTime fromdate, DateTime todate, int meidaId)
        {
            return new ReportRepository().GetUnpaidMediaStatement(fromdate, todate, meidaId);
        }

        public DataSet GetCashBookGroupByUser(DateTime dtfrm, DateTime dtto)
        {
            return new ReportRepository().GetCashBookGroupByUser(dtfrm, dtto);
        }

        public DataSet GetReferrelByMediaPatientWise(DateTime fromdate, DateTime todate, int referralId)
        {
            return new ReportRepository().GetReferrelByMediaPatientWise(fromdate, todate, referralId);
        }

        public DataSet GetCollectionStatement(DateTime dateTimefrom, DateTime dateTimeto,string _userName, string _reportOPtion)
        {
            return new ReportRepository().GetCollectionStatement(dateTimefrom, dateTimeto, _userName, _reportOPtion);
        }

        public List<SelectedTestItemsForPatient> GetTestListByPatientBillNo(long patientId)
        {
            return new ReportRepository().GetTestListByPatientBillNo(patientId);
        }

        public DataSet GetMediaPaidAndUnpaidStatementwithMedia(DateTime fromdate, DateTime todate, int referralId)
        {
            return new ReportRepository().GetMediaPaidAndUnpaidStatementwithMedia(fromdate, todate, referralId);
        }

        public DataSet GetRefundPatientWiseData(DateTime dtpFrom, DateTime dtpTo)
        {
            return new ReportRepository().GetRefundPatientWiseData(dtpFrom, dtpTo);
        }

        public DataSet GetCashBookDiag(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new ReportRepository().GetCashBookDiag(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetCashBookHos(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new ReportRepository().GetCashBookHos(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetReferrelByDoctorPatientWise(DateTime fromdate, DateTime todate, int _referralId)
        {
            return new ReportRepository().GetReferrelByDoctorPatientWise(fromdate, todate, _referralId);
        }

        public List<VMPathologistServiceFee> GetSinglePalthlogistServiceFeeByPaitent(int consultantId, DateTime dtpFrom, DateTime dtpTo)
        {
            return new ReportRepository().GetSinglePalthlogistServiceFeeByPaitent(consultantId, dtpFrom, dtpTo);
        }

        public DataSet GetCashBook(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new ReportRepository().GetCashBook(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetCashBookPhar(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new ReportRepository().GetCashBookPhar(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetReferrelContribution(DateTime fromdate, DateTime todate, int _referralId)
        {
            return new ReportRepository().GetReferrelContribution(fromdate, todate, _referralId);
        }

        public DataSet GetPathologistServiceReportFeeWithConsultentId(int consultantUserId, DateTime dtpFrom, DateTime dtpTo)
        {
            return new ReportRepository().GetPathologistServiceReportFeeWithConsultentId(consultantUserId, dtpFrom, dtpTo);
        }

        public DataSet GetDiagMasterStatement(DateTime dtpfrm, DateTime dtpto)
        {
            return new ReportRepository().GetDiagMasterStatement(dtpfrm, dtpto);
        }

        public DataSet GetMediaStatement(int mediaId, DateTime _dtpfrm, DateTime _dtpto)
        {
            return new ReportRepository().GetMediaStatement(mediaId, _dtpfrm, _dtpto);
        }

        public DataTable GetPathologicalTestsByGroup(int regNo, int groupId)
        {
            return new ReportRepository().GetPathologicalTestsByGroup(regNo, groupId);
        }

        public async Task<DataTable> GetTestDetailsForReport(long _patientId , int testId, int ReportTypeId, int PriorityId)
        {
            return await new ReportRepository().GetTestDetailsForReport(_patientId,testId, ReportTypeId, PriorityId);
        }

        public DataSet GetSupplierPaymentList(int manufacturerId, DateTime from, DateTime to)
        {
            return new ReportRepository().GetSupplierPaymentList(manufacturerId, from, to);
        }

        public DataSet GetDiscountList(DateTime dtpfrm, DateTime dtpto)
        {
            return new ReportRepository().GetDiscountList(dtpfrm, dtpto);
        }

        public List<PathReportValueComboType> GetReportValueComboTypes()
        {
            return new ReportRepository().GetReportValueComboTypes();
        }

        public SqlDataAdapter GetAmbulanceRentInfo(DateTime dateTime1, DateTime dateTime2)
        {
            return new ReportRepository().GetAmbulanceRentInfo(dateTime1, dateTime2);
        }

        public SqlDataAdapter GetIndoorPatientBillStatement(DateTime dateTime1, DateTime dateTime2)
        {
            return new ReportRepository().GetIndoorPatientBillStatement(dateTime1, dateTime2);
        }

        public bool SaveReportFees(List<ReportFee> reportFees)
        {
            return new ReportRepository().SaveReportFees(reportFees);
        }

        public double GetRefundByUser(DateTime dateTime1, LoginUser loggedinUser)
        {
            return new ReportRepository().GetRefundByUser(dateTime1, loggedinUser);
        }

        public DataTable GetTestGroupNameByMasterGroup(int groupID)
        {
            return new ReportRepository().GetTestGroupNameByMasterGroup(groupID);
        }

        public async Task<DataSet> GetDetailConsultancyStatement(int consultantId, DateTime dtfrm, DateTime dtto)
        {
            return await new ReportRepository().GetDetailConsultancyStatement(consultantId, dtfrm, dtto);
        }

        public DataSet GetDiagDeptWisePatientStatement(DateTime dtpfrm, DateTime dtpto, string _userName, string _reportOPtion, int deptId)
        {
            return new ReportRepository().GetDiagDeptWisePatientStatement(dtpfrm, dtpto, _userName, _reportOPtion, deptId);
        }

        public PathologyReport SavePathologyNonWordReport(Model.PathologyReport _report)
        {
            return new ReportRepository().SavePathologyNonWordReport(_report);
        }

        /* =================== Save Pathlogys Payment Details ========================= */
        public bool SavePathologistPaymentDetails(List<ConsultentLedger> consultent)
        {
            return new ReportRepository().SavePathologistPaymentDetails(consultent);
        }

        /* =================== Consulten Payment with Zerro Or Normal ========================= */
        public DataSet GetConsultentPaymentWithZerroOrNormal(DateTime dtpFrom,DateTime dtpTo, int rCId)
        {
            return new ReportRepository().GetConsultentPaymentWithZerroOrNormal(dtpFrom, dtpTo, rCId);
        }

        public DataSet GetOPDCollectionStatement(DateTime dtpfrm, DateTime dtpto, int sGroupId, string _user, string _reportOPtion, int _doctorId)
        {
            return new ReportRepository().GetOPDCollectionStatement(dtpfrm,dtpto, sGroupId, _user, _reportOPtion, _doctorId);
        }

        public ReportFee GetReportTestIdAndCoultantId(int reporttypeId, int consultanteId)
        {
            return new ReportRepository().GetReportTestIdAndCoultantId(reporttypeId, consultanteId);
        }

        public void UpdatePathologyReportIsPaid(List<PathologyReport> pathologyReports)
        {
             new ReportRepository().UpdatePathologyReportIsPaid(pathologyReports);
        }

        public DataSet GetOPDProcedureCollectionStatement(DateTime dtpfrm, DateTime dtpto, string _procedure, string _reportOPtion)
        {
            return new ReportRepository().GetOPDProcedureCollectionStatement(dtpfrm, dtpto, _procedure, _reportOPtion);
        }

        public async Task<DataSet> GetDiagCollectionStatementDataSetAsync(DateTime dtpfrm, DateTime dtpto, string userName, string reportOPtion)
        {
            return await new ReportRepository().GetDiagCollectionStatementDataSetAsync(dtpfrm, dtpto, userName, reportOPtion);
        }

        public void SavePathologicalReportDetail(List<Model.PathologyNonWordReportReportDetail> _reportdetailList, PathologyReport _report)
        {
            new ReportRepository().SavePathologicalReportDetail(_reportdetailList, _report);
        }

        public DataSet GetTestList(long patientId)
        {
            return new ReportRepository().GetTestList(patientId);
        }

        public async Task<DataSet> GetTestListForSampleCollection(long patientId)
        {
            return await new ReportRepository().GetTestListForSampleCollection(patientId);
        }

        private string GetTotalTransactedPatient(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOPtion)
        {
            return new ReportRepository().GetTotalTransactedPatient(dtpfrm, dtpto, _user, _reportOPtion);
        }

        public string GetTestByReportId(long _reportId)
        {
            return new ReportRepository().GetTestByReportId(_reportId);
        }

        public SqlDataAdapter GetPathologicalTestDataByReportId(long reportId)
        {
           return new ReportRepository().GetPathologicalTestDataByReportId(reportId);
        }

        public List<ReportConsultant> GetReportConsultants()
        {
            return new ReportRepository().GetReportConsultants();
        }

        public SqlDataAdapter GetHospitalBillDetails(int InvoiceId)
        {
            return new ReportRepository().GetHospitalBillDetails(InvoiceId);
        }



       

        public DataSet GetReferredCaseByReferralDetail(DateTime fromdate, DateTime todate, int _referralId)
        {
            return new ReportRepository().GetReferredCaseByReferralDetail(fromdate, todate, _referralId);
        }

        public double GetCashBookTotal()
        {
            return new ReportRepository().GetCashBookTotal();
        }

        public IList<VMReportDefination> GetLISReportDetails( string _patientId)
        {
            return new ReportRepository().GetLISReportDetails(_patientId);
        }

      

        public async Task<DataTable> GetDisticntReportTypeForPathologyReport(long _billNo)
        {
            return await new ReportRepository().GetDisticntReportTypeForPathologyReport(_billNo);
        }

        public void GenerateStaticReport(System.Data.DataTable dt_fields, System.Data.DataTable dt_values)
        {
            new ReportRepository().GenerateStaticReport(dt_fields, dt_values);
        }

        public List<PathologyReport> GetReportDoneListByPatientId(long patientId)
        {
            return new ReportRepository().GetReportDoneListByPatientId(patientId);
        }

        public DataSet GetPathologicalStaticTestData()
        {
          return  new ReportRepository().GetPathologicalStaticTestData();
        }

        public List<VWMReportDoneList> GetTodaysReportList(DateTime dateTime)
        {
            return new ReportRepository().GetTodaysReportList(dateTime);
        }

        public async Task<DataTable> GetPathologicalTestsByReportType(long _billNo, int ReportTypeId)
        {
            return await new ReportRepository().GetPathologicalTestsByReportType(_billNo, ReportTypeId);
        }

        public DataTable GetPreviousReportTestDetails(long _reportId)
        {
            return new ReportRepository().GetPreviousReportTestDetails(_reportId);
        }

        public bool UpdatePathologyNonWordReport(PathologyReport _updateReport)
        {
            return new ReportRepository().UpdatePathologyNonWordReport(_updateReport);
        }

        public DataSet GetMediaPaidListData(DateTime dtpFrom, DateTime dtpTo, int mediaId)
        {
            return new ReportRepository().GetMediaPaidListData(dtpFrom, dtpTo, mediaId);
        }

        public PathologyReport GetPathologyNonWordReportById(long _reportId)
        {
            return new ReportRepository().GetPathologyNonWordReportById(_reportId);
        }

        public  Task<DataSet> GetDiagPatientStatementDataSetAsync(DateTime dtpfrm, DateTime dtpto, string _user, string reportOPtion)
        {
            return  new ReportRepository().GetDiagPatientStatementDataSetAsync(dtpfrm, dtpto, _user, reportOPtion);
        }

        public DataSet GetReferredCaseByIPDOPD(int _doctorId, DateTime fromdate, DateTime todate, string entryType)
        {
            return new ReportRepository().GetReferredCaseByIPDOPD(_doctorId, fromdate, todate, entryType);
        }

        public DataSet GetPatientStatement(DateTime dtpfrm, DateTime dtpto, string userName, string _reportOPtion)
        {
           return new ReportRepository().GetPatientStatement(dtpfrm, dtpto, userName, _reportOPtion);
        }
        
        public bool DeleteExistingReportDetails(long _reportId)
        {
            return new ReportRepository().DeleteExistingReportDetails(_reportId);
        }

        public double GetCashBookCreditTotal()
        {
            return new ReportRepository().GetCashBookCreditTotal();
        }

        public double GetCashBookDebitTotal()
        {
            return new ReportRepository().GetCashBookDebitTotal();
        }

        public DataSet GetSummarySheetData(DateTime dt1, DateTime dt2)
        {
            return new ReportRepository().GetSummarySheetData(dt1, dt2);
        }

        public VWSummarySheetSumAndBalance GetSummarySheetSumAndBalance()
        {
            return new ReportRepository().GetSummarySheetSumAndBalance();
        }

        public string GetReportType(string[] Ids)
        {
            return new ReportRepository().GetReportType(Ids);
        }

        public DataSet GetUserWisePatientReceiptStatement(DateTime dateTime1, DateTime dateTime2, string _userName, string _reportOPtion)
        {
            return new ReportRepository().GetUserWisePatientReceiptStatement(dateTime1, dateTime2, _userName, _reportOPtion);
        }

        public DataSet GetDueList(DateTime dateTime1, DateTime dateTime2, string _reportOption)
        {
            return new ReportRepository().GetDueList(dateTime1, dateTime2, _reportOption);
        }


        public DataSet GetGroupwiseTestAmount(Int32 groupID, Int32 patientID,  DateTime dateTime1, DateTime dateTime2)
        {
            return new ReportRepository().GetGroupwiseTestAmount(groupID, patientID,dateTime1, dateTime2);
        }


        public DataSet GetReferredStatement(DateTime dateTime1, DateTime dateTime2, int _referralId)
        {
            return new ReportRepository().GetReferredStatement(dateTime1, dateTime2, _referralId);
        }

        public DataSet GetDueCollectionList(DateTime dateTime1, DateTime dateTime2, string _userName)
        {
            return new ReportRepository().GetDueCollectionList(dateTime1, dateTime2, _userName);
        }

        public async Task<DataSet> GetConsultancyStatement(int _consultantId, DateTime dateTime1, DateTime dateTime2)
        {
            return await new ReportRepository().GetConsultancyStatement(_consultantId, dateTime1, dateTime2);
        }

        public SqlDataAdapter GetIrregularPaymentList()
        {
            return new ReportRepository().GetIrregularPaymentList();
        }

        public DataSet GetRefundDateWise(DateTime dateTime1, DateTime dateTime2)
        {
            return new ReportRepository().GetRefundDateWise(dateTime1, dateTime2);
        }

        public DataSet GetRefundPatientWise(DateTime dateTime1, DateTime dateTime2)
        {
            return new ReportRepository().GetRefundPatientWise(dateTime1, dateTime2);
        }

        public List<VMLISOutput> GetLISReportByDate(DateTime _rdate)
        {
            return new ReportRepository().GetLISReportByDate(_rdate);
        }

        public DataSet GetExpenseDetailsByHead(DateTime dateTime1, DateTime dateTime2,AccountHead _accHead)
        {
            return new ReportRepository().GetExpenseDetailsByHead(dateTime1, dateTime2, _accHead);
        }

        public DataSet GetExpenseByChecqueList(DateTime dateTime1, DateTime dateTime2)
        {
            return new ReportRepository().GetExpenseByChecqueList(dateTime1, dateTime2);
        }

        public DataSet GetTestSummary(DateTime dateTime1, DateTime dateTime2, int _doctorId)
        {
            return new ReportRepository().GetTestSummary(dateTime1, dateTime2, _doctorId);
        }

        public DataSet GetCancelledPatientStatement(DateTime dateTime1, DateTime dateTime2, int _refdBy)
        {
            return new ReportRepository().GetCancelledPatientStatement(dateTime1, dateTime2, _refdBy);
        }

        public bool IsReportDoneByOtherConsultant(ViewModelReportTests viewModelReportTests, string regNo,int _ConsultantId)
        {
            return new ReportRepository().IsReportDoneByOtherConsultant(viewModelReportTests, regNo, _ConsultantId);
        }

        public bool ChangeConsultant(string _regNo, ViewModelReportTests viewModelReportTests, ReportConsultant _newconsultant)
        {
            return new ReportRepository().ChangeConsultant(_regNo, viewModelReportTests, _newconsultant);
        }

        public DataSet GetPatientSerialByDoctor(int _docId, DateTime dateTime)
        {
            return new ReportRepository().GetPatientSerialByDoctor(_docId, dateTime);
        }

        public List<PathologyReport> GetPathologyReportByPatientId(long _pId)
        {
            return new ReportRepository().GetPathologyReportByPatientId(_pId);
        }

        public DataSet GetTokenData(long _PatientId)
        {
            return new ReportRepository().GetTokenData(_PatientId);
        }

        public double GetDueTk(long patientId)
        {
            return new ReportRepository().GetDueTk(patientId);
        }

        public double GetRegularReceivedByUser(DateTime _dtp, LoginUser loggedinUser)
        {
            return new ReportRepository().GetRegularReceivedByUser(_dtp, loggedinUser);
        }

        public double GetDueCollectionByUser(DateTime _dtp, LoginUser loggedinUser)
        {
            return new ReportRepository().GetDueCollectionByUser(_dtp, loggedinUser);
        }

        public DataSet GetLabTokenData(long _PatientId)
        {
            return new ReportRepository().GetLabTokenData(_PatientId);
        }

        public async Task<DataTable> GetPreviousReportTestDetailsByPatientByTestId(long patientId, int testId, int reportTypeId, int PriorityId)
        {
            return await new ReportRepository().GetPreviousReportTestDetailsByPatientByTestId(patientId, testId, reportTypeId, PriorityId);
        }

        public VMDepositSlip GetDepositSlip(DateTime _dtpfrom, DateTime _dtpto, string _username, string _reportOPtion)
        {
            return new ReportRepository().GetDepositSlip(_dtpfrom, _dtpto, _username, _reportOPtion);
        }

        public DataSet GetOPDCashMemo(long _PId, string _serviceType)
        {
            return new ReportRepository().GetOPDCashMemo(_PId, _serviceType);
        }

        public List<PathologyNonWordReportReportDetail> GetPathologyNonWordReportDetailById(long _reportId)
        {
            return new ReportRepository().GetPathologyNonWordReportDetailById(_reportId);
        }

        public void UpdatePathologyNonWordReportDetails(List<PathologyNonWordReportReportDetail> _reportDetails)
        {
            new ReportRepository().UpdatePathologyNonWordReportDetails(_reportDetails);
        }

        public DataSet GetPathologyReportData(IList<VMReportDefination> _SelectedTestItemsForPathologyReport)
        {
            DataTable _dt = GetTableFormat();

            foreach (VMReportDefination item in _SelectedTestItemsForPathologyReport)
            {

                var values = new object[15];

                 for (int i = 0; i < 15; i++)
                 {
                    if(i==0)
                     values[i] = item.PatientId;

                    if (i == 1)
                        values[i] = item.GroupId;

                    if (i == 2)
                        values[i] = item.GroupTitle;

                    if (i == 3)
                        values[i] = item.TestId;

                    if (i == 4)
                        values[i] = item.TestTitle;

                    if (i == 5)
                        values[i] = item.TestDetailId;

                    if (i == 6)
                        values[i] = item.TestResult + " " + item.ResultUnit;

                    if (i == 7)
                        values[i] = item.NormalValue;

                    if (i == 8)
                        values[i] = item.DetailReportOrder;

                    if (i == 9)
                        values[i] = item.TestReportOrder;

                    if (i == 10)
                        values[i] = item.GroupReportOrder;

                    if (i == 11)
                        values[i] = item.TestTitle_FontBold;

                    if (i == 12)
                        values[i] = item.TestTitle_FontItalic;

                    if (i == 13)
                        values[i] = item.MachineResult;


                    if (i == 14)
                    {
                        values[i] = item.TestTitle_FontUnderline;
                        _dt.Rows.Add(values);
                    }


                }

                

            }

            DataSet ds = new DataSet();
            ds.Tables.Add(_dt);
            return ds;


        }

        public byte[] GetReportContentByRegNoAnd(long _billNo, int _testId)
        {
            return new ReportRepository().GetReportContentByRegNoAnd(_billNo, _testId);
        }

        private DataTable GetTableFormat()
        {
            DataTable dt = new DataTable("ReportData");
            dt.Columns.Add("PatientId", typeof(long));
            dt.Columns.Add("GroupId", typeof(Int32));
            dt.Columns.Add("GroupTitle", typeof(string));
            dt.Columns.Add("TestId", typeof(Int32));

            dt.Columns.Add("TestTitle", typeof(string));
            dt.Columns.Add("TestDetailId", typeof(Int32));
            dt.Columns.Add("TestResult", typeof(string));
            dt.Columns.Add("NormalResult", typeof(string));
            dt.Columns.Add("DetailReportOrder", typeof(Int32));

            dt.Columns.Add("TestReportOrder", typeof(Int32));
            dt.Columns.Add("GroupReportOrder", typeof(Int32));
            dt.Columns.Add("TestTitle_FontBold", typeof(Int32));
            dt.Columns.Add("TestTitle_FontItalic", typeof(Int32));
            dt.Columns.Add("MachineResult", typeof(string));
            dt.Columns.Add("TestTitle_FontUnderline", typeof(Int32));

            return dt;
        }

        public DataSet GetIndoorSaleLedger(long admissionId)
        {
            return new ReportRepository().GetIndoorSaleLedger(admissionId);
        }

        public bool AddOrUpdateReportItems(IList<VMReportDefination> _SelectedTestItemsForPathologyReport)
        {
           return  new ReportRepository().AddOrUpdateReportItems(_SelectedTestItemsForPathologyReport);
        }

        public DataSet GetHpAdmittedPatientList(int deptId)
        {
            return new ReportRepository().GetHpAdmittedPatientList(deptId);
        }

        public List<VMReportPriority> GetReportPriorityObj(int reportTypeId, string _reportId)
        {
            return new ReportRepository().GetReportPriorityObj(reportTypeId, _reportId);
        }

        public TEMPLISPatientRecord GetTempLISPatientRecord(string reportId, string machineShortName)
        {
            return new ReportRepository().GetTempLISPatientRecord(reportId, machineShortName);
        }

        public DataSet GetIDPatientList(DateTime _frm, DateTime to)
        {
            return new ReportRepository().GetIDPatientList(_frm, to);
        }

        public DataSet GetDiagToken(long _pId, string GroupName)
        {
            return new ReportRepository().GetDiagToken(_pId, GroupName);
        }
    }
}
