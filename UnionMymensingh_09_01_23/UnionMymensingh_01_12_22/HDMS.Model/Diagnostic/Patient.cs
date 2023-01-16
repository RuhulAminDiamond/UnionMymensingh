using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        public long PatientId { get; set; }
        public long BillNo { get; set; }  // 10 digit (yymm + 5 dgit random + 1 digit OrgCode)
        public long RegNo { get; set; }
        public long AdmissionNo { get; set; }
        public int DailyId { get; set; }
        public string ReportIdPrefix { get; set; }
        public long ReportId { get; set; }
        public long RxId { get; set; }
        public int PkgId { get; set; }   // Test Package Id
        public string AgeYear { get; set; }
        public string AgeMonth { get; set; }
        public string AgeDay { get; set; }
        public string DiscountCareOf { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryTime { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public int MediaId { get; set; }
        public bool IsMediaPaid { get; set; }
        public int MarketingId { get; set; }
        public string DiscountCardNo { get; set; }
        public double DiscountHonouredInPercentAgainstCardNo { get; set; }

        public int DiscountRequestById { get; set; }

        public double DiscountGivenByRequestInPercent { get; set; }
        public string Cabin { get; set; }
        public double DiscountInPercent { get; set; }
        public string SampleCollectionStatus { get; set; }  // FC (Fully Collected), PC (Partially Collected), NC (Not Collected)
        public string Status { get; set; }
        public string Cancelledby { get; set; }
        public string CancelledhostIp { get; set; }
        public string Cancelledhostname { get; set; }
        public bool Isfree { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int Updateby { get; set; }

        public string CreatedWorkStationId { get; set; }
        public string CancelRemarks { get; set; }

        public string UpdatedWorkStationId { get; set; }

        public User User { get; set; } 
        public Doctor Doctor { get; set; }
        public ICollection<TestsCost> TestCosts { get; set; }

        public DateTime? MediaPaymentDate { get; set; }
    }
}