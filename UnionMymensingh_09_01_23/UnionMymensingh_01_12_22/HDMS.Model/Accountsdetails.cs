using System;


namespace HDMS.Model {
public class Accountsdetails{
public Int64 Postingid { get; set; }
public Int32 Accountid { get; set; }
public DateTime Ddate { get; set; }
public string Description { get; set; }
public Double Amount { get; set; }
public Int32? Dmonth { get; set; }
public Int32? Dyear { get; set; }
public string Paymentmode { get; set; }
}
}