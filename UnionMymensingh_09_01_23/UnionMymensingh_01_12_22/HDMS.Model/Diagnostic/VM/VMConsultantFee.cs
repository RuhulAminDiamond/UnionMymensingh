using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMConsultantFee
    {
        public int RCId { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int FeeInPercent { get; set; }
        public int FeeInGross { get; set; }
    }
}
