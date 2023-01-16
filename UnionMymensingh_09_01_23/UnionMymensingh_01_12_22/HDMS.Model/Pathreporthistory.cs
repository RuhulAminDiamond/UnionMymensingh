using System;


namespace HDMS.Model {
public class Pathreporthistory{
public Decimal Patientid { get; set; }
public string Testspeciman { get; set; }
public string Reportfilename { get; set; }
public string Preparedby { get; set; }
public DateTime? Reportdate { get; set; }
public string Reporttime { get; set; }
public string Updatedby { get; set; }
public DateTime? UpdatEntryDate { get; set; }
public string Updatetime { get; set; }
public Int32? Doctorid { get; set; }
}
}