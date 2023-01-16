using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMPatientWiseMediaPayment
    {
        public long PatientId { get; set; }
        public string PatientName { get; set; }
        public double RegularDiscount { get; set; }
        public double DueDiscount { get; set; }
        public double TotalDiscount { get; set; }
        public bool Check { get; set; }
    }
}
