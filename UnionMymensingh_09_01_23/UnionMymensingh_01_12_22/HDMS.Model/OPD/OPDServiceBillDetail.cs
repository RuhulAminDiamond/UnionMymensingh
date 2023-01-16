using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class OPDServiceBillDetail
    {
        [Key]
        public long SBDId { get; set; }
        public long SBId { get; set; }
        public long PatientId { get; set; }
        public int ServiceHeadId { get; set; }
        public double Rate { get; set; }
        public int Qty { get; set; }
        public double ServiceCharge { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceTime { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
