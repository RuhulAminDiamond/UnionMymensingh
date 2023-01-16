using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
   public class OPDPatientRecord
    {
        [Key]
        public long PatientId { get; set; }
        public long BillNo { get; set; }  // 10 digit (yymm + 5 dgit random + 1 digit OrgCode)
        public long RegNo { get; set; }
     
        public string AgeYear { get; set; }
        public string AgeMonth { get; set; }
        public string AgeDay { get; set; }
        public string DiscountCareOf { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryTime { get; set; }
      
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public int GroupId { get; set; }

        public int VisitTypeId { get; set; }

        public int DiscountRequestById { get; set; }

        public double DiscountGivenByRequestInPercent { get; set; }
        public string Cabin { get; set; }
        public double DiscountInPercent { get; set; }
        public string Status { get; set; }
        public string Cancelledby { get; set; }
        public string CancelledhostIp { get; set; }
        public string Cancelledhostname { get; set; }
     
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int Updateby { get; set; }

        public string CreatedWorkStationId { get; set; }

        public string UpdatedWorkStationId { get; set; }

        public User User { get; set; }
        public Doctor Doctor { get; set; }
     
    }
}
