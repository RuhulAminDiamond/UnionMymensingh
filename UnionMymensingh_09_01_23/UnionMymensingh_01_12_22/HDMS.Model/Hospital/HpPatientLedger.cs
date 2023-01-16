using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpPatientLedger
    {
        [Key]
        public long TranId { get; set; }
        [ForeignKey("HospitalPatientInfo")]
        public long AdmissionId { get; set; }
        public DateTime TranDate { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }
        public string OperateBy { get; set; }

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
    }
}
