using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpConsultantLedger
    {
        [Key]
        public long TranId { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public DateTime TranDate { get; set; }
        public string TransactionTime { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }
        public string OperateBy { get; set; }
        public long PaymentTransactionNo { get; set; }
        public string PaymentEntryTime { get; set; }

        public Doctor Doctor { get; set; }
    }
}
