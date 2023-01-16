using HDMS.Repository.OPD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.OPD;

namespace HDMS.Service.OPD
{
    public class OPDPatientLedgerService
    {
        public double GetPaidTk(long _PatientId)
        {
            return new OPDPatientLedgerRepository().GetPaidTk(_PatientId);
        }

        public double GetDicountTk(long _PatientId)
        {
            return new OPDPatientLedgerRepository().GetDiscountTk(_PatientId);
        }

        public double GetCancelledAmount(long patientId)
        {
            return new OPDPatientLedgerRepository().GetCancelledAmount(patientId);
        }

        public double GetPatientLedgerBalance(long patientId)
        {
            return new OPDPatientLedgerRepository().GetPatientLedgerBalance(patientId);
        }

        public double GetCurrentBalance(long patientId)
        {
            return new OPDPatientLedgerRepository().GetPatientLedgerBalance(patientId);
        }

        public List<OPDPatientLedgerRough> GetLedgerByPatientId(long patientId)
        {
            return new OPDPatientLedgerRepository().GetLedgerByPatientId(patientId);
        }

        public void SavePatientLedger(List<OPDPatientLedger> transactionList)
        {
             new OPDPatientLedgerRepository().SavePatientLedger(transactionList);
        }

        public void SavePatientLedgerRough(List<OPDPatientLedgerRough> transactionList)
        {
            new OPDPatientLedgerRepository().SavePatientLedgerRough(transactionList);
        }

        public double GetRefundable(long patientId)
        {
            return new OPDPatientLedgerRepository().GetRefundable(patientId);
        }

        public double GetDiscountedAmount(long patientId)
        {
            return new OPDPatientLedgerRepository().GetDiscountTk(patientId);
        }
    }
}
