using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model {
[Table("Reportdoctors")]
 public class Reportdoctor{
public int Id { get; set; }
public string Name { get; set; }
public int? Fsize1 { get; set; }
public string DIdentityLine1 { get; set; }
public int? Fsize2 { get; set; }
public string DIdentityLine2 { get; set; }
public int? Fsize3 { get; set; }
public string DIdentityLine3 { get; set; }
public int? Fsize4 { get; set; }
public string DIdentityLine4 { get; set; }
public int? Fsize5 { get; set; }
public string DIdentityLine5 { get; set; }
public int? Fsize6 { get; set; }
public string ReportGroup { get; set; }
public string Status { get; set; }
}
}