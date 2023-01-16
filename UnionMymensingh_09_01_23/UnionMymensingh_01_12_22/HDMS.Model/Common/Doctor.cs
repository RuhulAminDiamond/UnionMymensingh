using HDMS.Model.Common;
using HDMS.Model.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model {
 [Table("Doctor")]
public class Doctor{
 [Key]
public int DoctorId { get; set; }
public string Name { get; set; }
 public int RCId { get; set; }
 public double VisitFee { get; set; }

[ForeignKey("ReferralCategory")]
public int RefCategoryId { get; set; }
public double SelfDiscountAllowed { get; set; }
public bool IsSelfFullFree { get; set; }
public double RequestedPatientDiscountAdjustFromRefDoctor { get; set; }

public bool IsOPDConsultant { get; set; }
public int DeptId { get; set; }
public int OPDConsultantCategoryId { get; set; }
public double ConsultancyFee1 { get; set; }  // Brand New or First time patient
public double ConsultancyFee2 { get; set; }  //After some visit but certain period of time later it will consider as new patient.
public double ConsultancyFee3 { get; set; }  //After some visit but within certain period of time it will consider as old patient.
public double ConsultancyFee4 { get; set; }  //Guset or staff fee.
public double IPDConsultancyFee { get; set; }
public double ConsultancyFeeReportOpinion { get; set; }
public double HpPercent { get; set; }
public double CpPercent { get; set; }

[ForeignKey("User")]
public int UserId { get; set; }

public ReferralCategory ReferralCategory { get; set; }
public User User { get; set; }
    }
}