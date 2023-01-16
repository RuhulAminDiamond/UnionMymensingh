using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMHpCabinCharge
    {
        public long BookingOrder { get; set; }
        public long AdmissionId { get; set; }
        public DateTime TranDate { get; set; }
        public string TranTime { get; set; }
        public string Particulars { get; set; }
        public int CabinId { get; set; }
        public int AccomodationTypeId { get; set; }
        public int TotalDays { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
    }
}
