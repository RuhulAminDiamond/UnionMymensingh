using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class OPDPatientLedger
    {
        public long Id { get; set; }
        [ForeignKey("HpOPDBill")]
        public long OPDBillId { get; set; }
        public DateTime TranDate { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }
        public string OperateBy { get; set; }

        public HpOPDBill HpOPDBill { get; set; }
    }

    public class OPDPatientLedgerRough
    {
        public long Id { get; set; }
        [ForeignKey("OPDPatientRecord")]
        public long PatientId { get; set; }
        public DateTime TranDate { get; set; }
        public string TransactionTime { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }
        public string OperateBy { get; set; }

        public OPDPatientRecord OPDPatientRecord { get; set; }
    }
}
