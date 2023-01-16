using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhTempIPDLedger
    {
        [Key]
        public long TranId { get; set; }
        public long RetIndentId { get; set; }
        public DateTime TranDate { get; set; }
        public string TransactionTime { get; set; }
        public long AdmissionId { get; set; }
        public double ReturnAmount { get; set; }
        public double DiscountAdjusted { get; set; }
        public double Returnable { get; set; }
        public string Status { get; set; }
    }
}
