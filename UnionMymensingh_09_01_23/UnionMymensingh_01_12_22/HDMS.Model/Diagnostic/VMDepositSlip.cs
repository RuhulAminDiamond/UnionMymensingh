using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class VMDepositSlip
    {

        public double totalPatient { get; set; }
        public double TotalSales { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalDue { get; set; }
        public double TotalWithoutDisc { get; set; }
        public double RefundTk { get; set; }
        public double PaidAmount { get; set; }
        public double DueCollection { get; set; }
        public double totalAmountReceived { get; set; }


    }
}
