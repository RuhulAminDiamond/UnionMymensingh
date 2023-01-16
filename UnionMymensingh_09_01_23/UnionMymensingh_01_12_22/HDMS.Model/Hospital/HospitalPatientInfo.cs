using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class HospitalPatientInfo
    {
        [Key]

        
        public long AdmissionId { get; set; }

        public long RegNo { get; set; }
        public long BillNo { get; set; }
        public long OPDBillNo { get; set; }
        public string AgeYear { get; set; }
        public string AgeMonth { get; set; }
        public string AgeDay { get; set; }
        public int WardOrCabinId { get; set; }
        public string CabinOrWardBedDisplayString { get; set; }
        public int AssignDoctorId { get; set; }
        public int RefdDoctorId { get; set; }
        public int MediaId { get; set; }
        
        public string Status { get; set; }
        public DateTime AddmissionDate { get; set; }
        public string Time { get; set; }    
        public DateTime? DischargeDate { get; set; }
        public string DischargeTime { get; set; }

        public DateTime? RecommededDateForDischarge { get; set; }
        public string RecommededTimeForDischarge { get; set; }
        public string DischargeRecommendationConfirmedby { get; set; }

        public string StatusChangeBy { get; set; }

        public string Admittedby { get; set; }

        public int DeptId { get; set; }

        public int PackageId { get; set; }

        public string Dischargedby { get; set; }

        public string CreatedWorkStationId { get; set; }

        public string UpdatedWorkStationId { get; set; }

        public string BillPrintState { get; set; }

        public string PharmacyClearance { get; set; }

        public string Cancelledby { get; set; }

        public bool IsMediaPaid { get; set; }
        public double MediaCommission { get; set; }

    }
}
