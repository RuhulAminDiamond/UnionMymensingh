using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMRequestOnDischargedResult
    {
        public DateTime EntryDate { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; }
        
    }
}
