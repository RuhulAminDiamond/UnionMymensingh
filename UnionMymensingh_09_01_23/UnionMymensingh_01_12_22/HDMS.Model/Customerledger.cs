using System;


namespace HDMS.Model {
public class Customerledger{
public Decimal Ranid { get; set; }
public Decimal Clientid { get; set; }
public string Particulars { get; set; }
public Double? Debit { get; set; }
public Double? Credit { get; set; }
public Double? Discount { get; set; }
public Double? Alance { get; set; }
public DateTime Randate { get; set; }
public Double? Ess { get; set; }
public string Remarks { get; set; }
public Decimal? Invoiceno { get; set; }
}
}