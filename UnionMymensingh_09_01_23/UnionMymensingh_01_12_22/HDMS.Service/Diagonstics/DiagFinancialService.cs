using HDMS.Model.Diagnostic.VM;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HDMS.Model;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic;

namespace HDMS.Service.Diagonstics
{
    public class DiagFinancialService
    {
        public List<VWIndoorInvestigationBill> GetIndoorInvestigationBillOfUndertreatedPatient()
        {
            return new DiagFinancialRepository().GetIndoorInvestigationBillOfUndertreatedPatient();
        }

        public DataSet GetInvestigationDetailsByPatientId(long admissionId)
        {
            return new DiagFinancialRepository().GetInvestigationDetailsByPatientId(admissionId);
        }

        public List<MediaCategory> GetAllMediaCategory()
        {
            return new DiagFinancialRepository().GetAllMediaCategory();
        }

        public List<ReportType> LoadAllReportType()
        {
            return new DiagFinancialRepository().LoadAllReportType();
        }

        public List<BusinessMedia> GetAllMedias()
        {
            return new DiagFinancialRepository().GetAllMedias();
        }

        public MediaCategory SaveMediaCategory(string name)
        {
            return new DiagFinancialRepository().SaveMediaCategory(name);
        }

        public List<VWIndoorInvestigationBill> GetIndoorInvestigationBillOfUndertreatedPatientBySearchPrefix(string strSearch, string _type)
        {
            return new DiagFinancialRepository().GetIndoorInvestigationBillOfUndertreatedPatientBySearchPrefix(strSearch, _type);
        }

        public List<BusinessMedia> GetMediaNameByPatientEntry(DateTime dtpFrom, DateTime dtpTo)
        {
            return new DiagFinancialRepository().GetMediaNameByPatientEntry(dtpFrom, dtpTo);
        }

        public async Task<Patient> SaveAndCommitNewSale(Patient patient, List<TestsCost> testsCost, VMDiagEndPointDataCapture voucherObj, bool isIntegratedAccountInAction)
        {
            return await new DiagFinancialRepository().SaveAndCommitNewSale(patient, testsCost,voucherObj, isIntegratedAccountInAction);
        }

        public bool GetMediaDueByPatient(DateTime dateFrom, DateTime dateTo, int mediaId)
        {
            return new DiagFinancialRepository().GetMediaDueByPatient(dateFrom, dateTo, mediaId);
        }

        public List<VMTestWiseMediaPayment> GetTestWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {
            return new DiagFinancialRepository().GetTestWiseMediaPayments(dtFrom, dtTo, mediaId);
        }

        public List<VMPatientWiseMediaPayment> GetPatientWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {
            return new DiagFinancialRepository().GetPatientWiseMediaPayments(dtFrom, dtTo, mediaId);
        }

        public bool SaveCategroyAndReprotTypeId(MediaCategoryReportTypeCommission mtc)
        {
            return new DiagFinancialRepository().SaveCategroyAndReprotTypeId(mtc);
        }

        public MediaLedger SaveMediaLedgersForPaidList(List<MediaLedger> mld)
        {
            return new DiagFinancialRepository().SaveMediaLedgersForPaidList(mld);
        }

        public List<VMTestWiseMediaPayment> GetCustomTestWiseMediaPayment(DateTime dtpFrom, DateTime dtpTo, long patientId)
        {
            return new DiagFinancialRepository().GetCustomTestWiseMediaPayment(dtpFrom, dtpTo, patientId);
        }

        public List<VMPatientWiseMediaPayment> GetCustometPatientWiseMediaPayments(DateTime dtpFrom, DateTime dtpTo, long patientId)
        {
            return new DiagFinancialRepository().GetCustometPatientWiseMediaPayments(dtpFrom, dtpTo, patientId);
        }

        public List<VMMediaCategoryReportTypeCommission> GetAllMediaCommissionTypeWithReportId()
        {
            return new DiagFinancialRepository().GetAllMediaCommissionTypeWithReportId();
        }

        public bool UpdateMediaCommissionType(MediaCategoryReportTypeCommission mtc)
        {
            return new DiagFinancialRepository().UpdateMediaCommissionType(mtc);
        }
    }
}
