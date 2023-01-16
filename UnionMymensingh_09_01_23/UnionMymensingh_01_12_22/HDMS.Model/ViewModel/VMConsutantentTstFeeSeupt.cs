using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class VMConsutantentTstFeeSeupt
    {
        public int RCId { get; set; }
        public string Name { get; set; }
        public int RFId { get; set; }

        public int TestId { get; set; }
        public double Fee { get; set; }
        public int ReportTypeId { get; set; }
        public double? Rate { get; set; }
    }
}
