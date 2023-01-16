using System;


namespace HDMS.Model {
public class Reportdetailsbackup{
public Decimal Reportid { get; set; }
public Int32 Itemid { get; set; }
public Int32? Detailid { get; set; }
public string Testcriteria { get; set; }
public string Tresult { get; set; }
public string Resultunit { get; set; }
public string Normalresult { get; set; }
public Decimal? Itemorder { get; set; }
public Decimal? Reportorder { get; set; }
public Int32? Grouptestid { get; set; }
public string Headername { get; set; }
}
}