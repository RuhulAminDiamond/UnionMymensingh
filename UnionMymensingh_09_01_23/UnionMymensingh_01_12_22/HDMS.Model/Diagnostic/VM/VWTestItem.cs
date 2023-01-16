using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VWTestItem
    {
        public long BillNo { get; set; }
        public long PatientId { get; set; }
        public long RefdId { get; set; }
        public int TestId { get; set; }
        public int ReportTypeId { get; set; }
        public string TestName { get; set; }
    }
}
