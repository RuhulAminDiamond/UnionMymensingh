using HDMS.Repository.OPD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;
using System.Data;

namespace HDMS.Service.OPD
{
    public class OPDFinancialService
    {
        public double GetBalanceByPatient(long _pId)
        {
            return new OPDFinancialRepository().GetBalanceByPatient(_pId);
        }

        public long SaveOPDServiceBill(HpOPDServiceBill _bService)
        {
            return new OPDFinancialRepository().SaveOPDServiceBill(_bService);
        }

        public void SaveOPDLedgerTransaction(OPDPatientLedger _hpLedger)
        {
            new OPDFinancialRepository().SaveOPDLedgerTransaction(_hpLedger);
        }

        public List<VMOPDFinalBill> GetOPDFinalBillItems(long patientId)
        {
            return new OPDFinancialRepository().GetOPDFinalBillItems(patientId);
        }

        public long SaveOPDFinalBill(HpOPDBill _hbill)
        {
            return new OPDFinancialRepository().SaveOPDFinalBill(_hbill);
        }

        public bool SaveOPDFinalBillDetail(List<HpOPDBillDetail> _hbilldetailList)
        {
            return new OPDFinancialRepository().SaveOPDFinalBillDetail(_hbilldetailList);
        }

        public void SaveOPDFinalLedger(List<OPDPatientLedger> transactionList)
        {
            new OPDFinancialRepository().SaveOPDFinalLedger(transactionList);
        }

        public DataSet GetOPDCashMemo(long _hbillId)
        {
            return new OPDFinancialRepository().GetOPDCashMemo(_hbillId);
        }

        public List<OPDPatientLedger> GetOPDPatientLedgerFinalById(long _billId)
        {
            return new OPDFinancialRepository().GetOPDPatientLedgerFinalById(_billId);
        }

        public void SaveOPDRoughLedger(List<OPDPatientLedgerRough> transactionList)
        {
            new OPDFinancialRepository().SaveOPDRoughLedger(transactionList);
        }

        public List<OPDPatientLedgerRough> GetOPDPatienLedgerRough(long patientId)
        {
            return new OPDFinancialRepository().GetOPDPatienLedgerRough(patientId);
        }

        public async Task<List<VMOPDProcudureBill>> GetOPdPatientProcedurBill()
        {
            return await new OPDFinancialRepository().GetOPdPatientProcedurBill();
        }
    }
}
