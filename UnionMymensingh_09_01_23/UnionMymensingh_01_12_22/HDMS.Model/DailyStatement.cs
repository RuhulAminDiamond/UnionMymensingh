using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model {
    [Table("DailyStatement")]
public class DailyStatement
{
public int Id { get; set; }
public DateTime EntryDate { get; set; }
public int PatientId { get; set; }
public string Name { get; set; }
public string Investigations { get; set; }
public double Pathology { get; set; }
public double XRay { get; set; }
public double USG { get; set; }
public double ECG { get; set; }
public double ENDO { get; set; }
public double CC { get; set; }
public double ECHO { get; set; }
public double Histo { get; set; }
public double Medicine { get; set; }
public double Due { get; set; }
public double Less { get; set; }
public string DoctorName { get; set; }
public string DueCollectedOn { get; set; }
public string USGDoctor { get; set; }
}
}