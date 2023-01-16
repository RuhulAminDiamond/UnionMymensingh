using System;


namespace HDMS.Model {
public class PathologyNonWordReportReportDetail
{
public long Id { get; set; }
public long ReportId { get; set; }
//public long PatientId { get; set; }
public int TestId { get; set; }
public int TestDetailId { get; set; }
public string TestTitle { get; set; }
public string TestResult { get; set; }
public string ResultUnit { get; set; }
public string NormalResult { get; set; }
public string MachineResult { get; set; }
 }
}