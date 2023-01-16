using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMSelectedOTServices
    {
        public int ServiceHeadId { get; set; }
        public string ServiceHeadName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double ServiceCharge { get; set; }
        public double Amount { get; set; }
        public string EnteredBy { get; set; }
    }
}
