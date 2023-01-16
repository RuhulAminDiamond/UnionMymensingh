using HDMS.Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
   public class OPDProcedureServiceBillDetail
    {
        [Key]
        public long SBDId { get; set; }
        public long SBId { get; set; }
        [ForeignKey("HospitalPatientInfo")]
        public long AdmissionId { get; set; }
        [ForeignKey("ServiceHead")]
        public int ServiceHeadId { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double ServiceCharge { get; set; }
        public double Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceTime { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
        public ServiceHead ServiceHead { get; set; }

    }
}
