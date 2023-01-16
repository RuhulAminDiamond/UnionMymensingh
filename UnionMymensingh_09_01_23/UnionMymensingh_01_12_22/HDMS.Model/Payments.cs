using System;


namespace HDMS.Model {
public class Payments{
public Int64 Paymentid { get; set; }
public Decimal? Patientid { get; set; }
public Double? Amount { get; set; }
public DateTime? pDate { get; set; }
public string Paymentreceivedby { get; set; }
public string Refundnote { get; set; }
public Int32? pMonth { get; set; }
}
}