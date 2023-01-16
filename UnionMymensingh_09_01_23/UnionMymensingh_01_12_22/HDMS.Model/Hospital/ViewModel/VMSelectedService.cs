using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMSelectedService
    {
        public int ServiceHeadId { get; set; }
        public int ServiceGroupId { get; set; }
        public string ServiceHeadName { get; set; }
        
        public double Rate { get; set; }
        public int Qty { get; set; }
        public double ServiceCharge { get; set; }
        public double Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public string EnteredBy { get; set; }
    }
}
