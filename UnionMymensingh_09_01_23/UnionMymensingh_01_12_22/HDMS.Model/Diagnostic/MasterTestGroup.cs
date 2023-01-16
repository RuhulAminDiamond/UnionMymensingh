using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class MasterTestGroup
    {
        public int MasterTestGroupId { get; set; }
        public string Name { get; set; }
        public int ReportOrder { get; set; }
        public int TokenOrder { get; set; }
    }
}
