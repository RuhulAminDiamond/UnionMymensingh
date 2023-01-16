using System;


namespace HDMS.Model {
public class Stock{
public Decimal Groupno { get; set; }
public Decimal Productcode { get; set; }
public string Productname { get; set; }
public Double Runningstock { get; set; }
public string Productunit { get; set; }
public Double Purchaseperunit { get; set; }
public Double Retailsalerate { get; set; }
public Double Wholesalerate { get; set; }
public Double Stockvalue { get; set; }
public Double Comm { get; set; }
public Double? Minimumstock { get; set; }
public string Psymbol { get; set; }
public string Dvfrm { get; set; }
public string Dvto { get; set; }
public string Spstatus { get; set; }
public string Wildstatus { get; set; }
}
}