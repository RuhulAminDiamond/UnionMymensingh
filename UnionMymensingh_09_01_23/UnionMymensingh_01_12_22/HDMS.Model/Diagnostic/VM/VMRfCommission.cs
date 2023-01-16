using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
   public class VMRfCommission
    {
        public string MediaName { get; set; }
        public int MediaId { get; set; }
        public string CategoryName { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public DateTime TranDate { get; set; }
        public long PatientId { get; set; }
        public string TransactionType { get; set; }
        public double Cost { get; set; }
        public double Commission { get; set; }
        public double TotalCommission { get; set; }
        public bool IsPercent { get; set; }
        public int TestId { get; set; }
    }
}
