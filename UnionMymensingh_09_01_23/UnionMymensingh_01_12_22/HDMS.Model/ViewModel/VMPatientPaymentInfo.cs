using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class VMPatientPaymentInfo
    {
        public int PatientId { get; set; }
        public double TestsCost { get; set; }
        public double PaidTk { get; set; }
        public double discountTk { get; set; }
        public double DueTk { get; set; }
    }
}
