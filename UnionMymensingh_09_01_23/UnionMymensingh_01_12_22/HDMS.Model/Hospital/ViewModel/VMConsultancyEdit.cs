using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMConsultancyEdit
    {
        public long DSBDId { get; set; } // Doctor or Consultant Service Bill Detail Id
        public DateTime ServiceDate { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string ServiceName { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Total { get; set; }
    }

    public class VMFloorServiceEdit
    {
        public long SBDId { get; set; } // Floor Service Bill Detail Id
        public DateTime ServiceDate { get; set; }
        public int ServiceHeadId { get; set; }
      
        public string ServiceName { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Total { get; set; }
    }
}
