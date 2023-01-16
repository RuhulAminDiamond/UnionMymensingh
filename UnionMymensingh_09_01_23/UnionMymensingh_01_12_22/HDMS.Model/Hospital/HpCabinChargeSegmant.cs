using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpCabinChargeSegmantMaster
    {
        [Key]
        public long SMId { get; set; }
        public long AdmissionId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string AdmissionTime { get; set; }
        public bool IsAdmissionDayBillApplicable { get; set; }
        public bool IsAdmissionDayAndReleaseDaySame { get; set; }
        public bool IsOccupationMorethanTwoCalendarDate { get; set; }
  
    }


    public class HpCabinChargeSegmantDetail
    {
        [Key]
        public long SDId { get; set; }
        [ForeignKey("HpCabinChargeSegmantMaster")]
        public long SMId { get; set; }
        public long BookOrder { get; set; }
        public long AdmissionId { get; set; }
        public int ServiceHeadId { get; set; }
        public int CabinId { get; set; }
        public string CabinNo { get; set; }
        public int Rent { get; set; }
        public int AccomodationTypeId { get; set; }
        public DateTime StayingDate { get; set; }
        public bool IsAdmissionDay { get; set; }
        public string OccupationStatus { get; set; }

        public HpCabinChargeSegmantMaster HpCabinChargeSegmantMaster { get; set; }
    }
}
