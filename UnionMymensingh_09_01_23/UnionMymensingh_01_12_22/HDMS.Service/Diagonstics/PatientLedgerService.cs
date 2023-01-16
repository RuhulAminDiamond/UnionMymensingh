using HDMS.Model;
using HDMS.Model.Diagnostic.VM;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Diagonstics
{
    public class PatientLedgerService
    {
        public bool SavePatientLedger(List<PatientLedger> pLedger)
        {
            return new PatientLedgerRepository().SavePatientLedger(pLedger);
        }

        public List<PatientLedger> GetLedgerByPatientId(long pId)
        {
            return new PatientLedgerRepository().GetLedgerByPatientId(pId);
        }



        public void CreateDailyStatement(int RegNo)
        {
            new PatientLedgerRepository().CreateDailyStatement(RegNo);
        }

        public double GetPatientLedgerBalance(long _PatientId)
        {
           return new PatientLedgerRepository().GetPatientLedgerBalance(_PatientId);
        }

        public PatientLedger GetInitialTestCost(long _PatientId)
        {
            return new PatientLedgerRepository().GetInitialTestCost(_PatientId);
        }

        public double GetCancelledAmount(long _PatientId)
        {
            return new PatientLedgerRepository().GetCancelledAmount(_PatientId);
        }

        public double GetPaidTk(long _PatientId)
        {
            return new PatientLedgerRepository().GetPaidTk(_PatientId);
        }

        public double GetDicountTk(long _PatientId)
        {
            return new PatientLedgerRepository().GetDiscountTk(_PatientId);
        }

        public double GetRefundable(long _PatientId)
        {
            return new PatientLedgerRepository().GetRefundable(_PatientId);
        }

        public double GetInvoiceTotal(long _PatientId)
        {
            return new PatientLedgerRepository().GetInvoiceTotal(_PatientId);
        }

        public double GetMediaCommissionOnTest(long patientId)
        {
            return new PatientLedgerRepository().GetMediaCommissionOnTest(patientId);
        }

        public double GetMediaCommissionOnDiscount(long patientId)
        {
            return new PatientLedgerRepository().GetMediaCommissionOnDiscount(patientId);
        }

        public VMMediaAndPatientName GetMeidaAndPatientName(long patientId)
        {
            return new PatientLedgerRepository().GetMeidaAndPatientName(patientId);
        }

        public string GetPatientNameByPatientId(long patientId)
        {
            return new PatientLedgerRepository().GetPatientNameByPatientId(patientId);
        }
    }
}
