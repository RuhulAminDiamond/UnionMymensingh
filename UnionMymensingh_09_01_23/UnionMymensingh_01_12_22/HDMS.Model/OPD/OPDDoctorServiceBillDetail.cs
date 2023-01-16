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
    public class OPDDoctorServiceBillDetail
    {
        [Key]
        public long DSBDId { get; set; }

        public long DSBId { get; set; }
        //[ForeignKey("OPDPatientRecord")]
        public long PatientId { get; set; }
        [ForeignKey("ServiceHead")]
        public int ServiceHeadId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Vat { get; set; }
        public double ServiceCharge { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceTime { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

       // public OPDPatientRecord OPDPatientRecord { get; set; }
        public ServiceHead ServiceHead { get; set; }
        public Doctor Doctor { get; set; }
    }
}
