using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMPathologicalMachine
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string ApplicableFor { get; set; }
        public int ReportTypeId { get; set; }  // This will be ReportTypeId
        public string MachineShortName { get; set; }
        public int Priority { get; set; }
        public string ReportType { get; set; }
    }
}
