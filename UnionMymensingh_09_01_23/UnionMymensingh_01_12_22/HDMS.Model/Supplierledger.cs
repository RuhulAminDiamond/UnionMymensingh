using System;


namespace HDMS.Model {
public class Supplierledger{
public Decimal Ranid { get; set; }
public Int32? Supid { get; set; }
public string Particulars { get; set; }
public Double? Debit { get; set; }
public Double? Credit { get; set; }
public Double? Alance { get; set; }
public DateTime? Randate { get; set; }
}
}