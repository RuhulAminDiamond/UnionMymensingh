using HDMS.Model.Diagnostic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model {
   
public class ReportType{
        [Key]
public Int32 ReportTypeId { get; set; }
[ForeignKey("TestGroup")]
public int TestGroupId { get; set; }
public string Report_Type { get; set; }
public bool IsPathReport { get; set; }
public bool IsImageReport { get; set; }
public string TestCarriedOutBy { get; set; }
public Int32 ReportOrder { get; set; }
public Int32? SCTokenOrder { get; set; } //Sample Collection Token Order
public TestGroup TestGroup { get; set; }
    }
}