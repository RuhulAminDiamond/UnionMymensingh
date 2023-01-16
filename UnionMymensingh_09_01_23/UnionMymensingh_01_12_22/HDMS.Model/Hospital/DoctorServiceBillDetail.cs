using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{

    public class HpDoctorServiceBill
    {
        [Key]
        public long DSbId { get; set; }
       public DateTime DSDate { get; set; }
       public double ServiceAmount { get; set; }

    }

    public class DoctorServiceBillDetail
    {
        [Key]
        public long DSBDId { get; set; }
        
        public long DSBId { get; set; }
        [ForeignKey("HospitalPatientInfo")]
        public long AdmissionId { get; set; }
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

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
        public ServiceHead ServiceHead { get; set; }
        public Doctor Doctor { get; set; }
    }

    public class DoctorServiceDeleteLog
    {
        [Key]
        public long DeleteId { get; set; }
        [ForeignKey("HospitalPatientInfo")]
        public long AdmissionId { get; set; }
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
        public string DeletedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
        public ServiceHead ServiceHead { get; set; }
        public Doctor Doctor { get; set; }
    }

    public class FloorServiceDeleteLog
    {
        [Key]
        public long DeleteId { get; set; }
        [ForeignKey("HospitalPatientInfo")]
        public long AdmissionId { get; set; }
        [ForeignKey("ServiceHead")]
        public int ServiceHeadId { get; set; }

        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Vat { get; set; }
        public double ServiceCharge { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceTime { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
        public ServiceHead ServiceHead { get; set; }
       
    }
}
