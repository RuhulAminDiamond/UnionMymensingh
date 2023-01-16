using System;


namespace HDMS.Model {
public class Dailypatientstatementcompact{
public Decimal Patientid { get; set; }
public Int32 DailyId { get; set; }
public string Receivedby { get; set; }
public string Pname { get; set; }
public string Investigation { get; set; }
public Double? Pathology { get; set; }
public Double? Xray { get; set; }
public Double? Echo { get; set; }
public Double? Ecg { get; set; }
public Double? Ultra { get; set; }
public string Ultardr { get; set; }
public Double? Endoscopy { get; set; }
public Double? Histo { get; set; }
public Double? Vacuamount { get; set; }
public Double? Dues { get; set; }
public string Duestatus { get; set; }
public Double? Vat { get; set; }
public Double? Less { get; set; }
public Decimal? Refby { get; set; }
public string Cabin { get; set; }
public DateTime? Ddate { get; set; }
public Int32? Dday { get; set; }
public Int32? Dmonth { get; set; }
public Int32? Dyear { get; set; }
public string Status { get; set; }
public string Co { get; set; }
}
}