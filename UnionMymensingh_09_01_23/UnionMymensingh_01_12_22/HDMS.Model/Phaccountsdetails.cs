using System;


namespace HDMS.Model {
public class Phaccountsdetails{
public Decimal Postingid { get; set; }
public Int32 Accountid { get; set; }
public DateTime Ddate { get; set; }
public string Description { get; set; }
public Double Amount { get; set; }
public string Secname { get; set; }
public Int32? Dmonth { get; set; }
public Int32? Dyear { get; set; }
}
}