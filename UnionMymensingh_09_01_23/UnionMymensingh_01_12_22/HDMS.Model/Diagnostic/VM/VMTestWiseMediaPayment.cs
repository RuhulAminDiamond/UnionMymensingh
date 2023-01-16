using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMTestWiseMediaPayment
    {
        public long PatientId { get; set; }
        public string PatientName { get; set; }
        public string TestName { get; set; }
        public double MediaCommission { get; set; }
        public int TestId { get; set; }
        public double Rate { get; set; }
    }
}
