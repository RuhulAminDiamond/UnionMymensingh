using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Media
{
    public class VMIPDPaymentInfo
    {
        public string PhoneNo { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int MediaId { get; set; }
        public string MediaName { get; set; }
        public bool IsPaid { get; set; }
        public double MediaCommission { get; set; }
    }
}
