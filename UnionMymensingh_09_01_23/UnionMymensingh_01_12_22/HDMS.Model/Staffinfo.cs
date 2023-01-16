using System;


namespace HDMS.Model {
public class Staffinfo{
public Decimal? Staffid { get; set; }
public string Sname { get; set; }
public string Fathersname { get; set; }
public string Mothersname { get; set; }
public Int32? Staffcategory { get; set; }
public Int32? Section { get; set; }
public Double? Asicsalary { get; set; }
public DateTime? Dateofbirth { get; set; }
public string Presentaddress { get; set; }
public string Parmenentaddress { get; set; }
public string Oodgroup { get; set; }
public DateTime? Joiningdate { get; set; }
public string Phonenumber { get; set; }
public string Photopath { get; set; }
public Double? Atttime { get; set; }
public Double? Eavetime { get; set; }
}
}