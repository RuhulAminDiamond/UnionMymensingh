using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
   public class PhSaleLedger  // Need for IPD Sale related by InvoiceId
    {
        [Key]
        public long TranId { get; set; }
        [ForeignKey("PhInvoice")]
        public long InvoiceId { get; set; }
        public DateTime TranDate { get; set; }
        public string TransactionTime { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }
        public string OperateBy { get; set; }
        public int PCId { get; set; }   // Payment Channel Id
        public string TransactionNo { get; set; }
        public PhInvoice PhInvoice { get; set; }
    }
}
