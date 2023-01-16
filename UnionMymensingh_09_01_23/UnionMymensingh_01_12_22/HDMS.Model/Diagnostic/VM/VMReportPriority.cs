using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMReportPriority
    {
        public string ReportId { get; set; }
        public int ReportTypeId { get; set; }
        public int Priority { get; set; }
    }
}
