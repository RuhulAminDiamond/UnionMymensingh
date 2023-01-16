using HDMS.Model.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model {
 [Table("TestsCost")]
public class TestsCost{
[Key]
public long Id { get; set; }

[ForeignKey("Patient")]
public long PatientId { get; set; }
[ForeignKey("TestItem")]
public int TestId { get; set; }
public int Qty { get; set; }
public double Cost { get; set; }
public double DiscountInPercent { get; set; }
public double Discount { get; set; }
public int ConsultantId { get; set; }
public string ReportStatus { get; set; }
public string DeliveryDate { get; set; }
public string DeliveryTime { get; set; }
public string SampleCollectedBy { get; set; }
public string SampleReceivedBy { get; set; }  //In Lab sample received by
public string ReportDeliveredBy { get; set; }
public DateTime? SampleReceivedDate { get; set; }
public string SampleReceivedTime { get; set; }
public string Status { get; set; }
public string LisReportStatus { get; set; }
[ForeignKey("User")]
 public int UserId { get; set; }
 public bool IsCancelApprove { get; set; } = false;
 public Patient Patient { get; set; }
 public TestItem TestItem { get; set; }
 public User User { get; set; }
}
}