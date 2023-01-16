using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpAdvancePayment
    {
        [Key]
        public long AdvanceId { get; set; }
        public long AdmissionId { get; set; }
        public DateTime PayDate { get; set; }
        public string PayTime { get; set; }
        public double Amount { get; set; }
        public string ReceievedBy { get; set; }
        public string Remarks { get; set; }
        public int PaymentModeId { get; set; }
        public string TransactionTerminal { get; set; }
        public int PCId { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionType { get; set; }
    }
}
