using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhSupplierLedger
    {
        [Key]
        public long TranId { get; set; }
        public DateTime TranDate { get; set; }
        public int ManufacturerId { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string OperateBy { get; set; }
    }
}
