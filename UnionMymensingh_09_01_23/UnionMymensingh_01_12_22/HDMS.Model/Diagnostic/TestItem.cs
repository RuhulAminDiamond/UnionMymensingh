using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model
{

    public class TestItem
    {
        [Key]
        public int TestId { get; set; }
        public int TestCode { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double Rate { get; set; }
        public string Specimen { get; set; }
        public string Process_Time { get; set; }
        public int DayNeededForReportDelivery { get; set; }                   // Need for Test Where Delivery Date needed more than one day
        public int EscapeDayNeededForReportDeliveryDayCount { get; set; }     // Need for Test Where Delivery Date needed more than one day
        public DateTime DeliveryTimeOnReportDay { get; set; }  // Need for Test Where Delivery Date needed more than one day
        public bool Vatable { get; set; }
        public int ReportTypeId { get; set; }
        public int? CollectionTypeId { get; set; }
        public bool Label { get; set; }
        public string Comments { get; set; }
        public int ReportOrder { get; set; }
        public bool IsGLUTest { get; set; }   // For Vitros 350
        public string GLUIdentityExt { get; set; } // For Vitros 350
        public bool IsPackage { get; set; }
        public double PackageDiscount { get; set; }
        public double MediaComm { get; set; }
        public double ReferralCommission { get; set; }

        //public double Mediacommission { get; set; }
    }
}