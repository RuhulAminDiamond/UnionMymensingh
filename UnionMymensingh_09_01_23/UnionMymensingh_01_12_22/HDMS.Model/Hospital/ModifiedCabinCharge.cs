using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class ModifiedCabinCharge
    {
        public long Id { get; set; }
        public long AdmissionId { get; set; }
        public int ServiceHeadId { get; set; }
        public int CabinId { get; set; }
        public int ActualQty { get; set; }
        public int ModifiedQty { get; set; } // Day In Cabin
        public int Rate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedTime { get; set; }
    }
}
