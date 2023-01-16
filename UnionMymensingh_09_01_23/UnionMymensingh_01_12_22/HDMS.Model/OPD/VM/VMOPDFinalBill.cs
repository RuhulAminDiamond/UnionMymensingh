using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD.VM
{
    public class VMOPDFinalBill
    {
        public int SrlNo { get; set; }
        public string ServiceName { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public double Total { get; set; }
        public string ServiceGroup { get; set; }
        public double ServiceChargeInPercent { get; set; }
    }
}
