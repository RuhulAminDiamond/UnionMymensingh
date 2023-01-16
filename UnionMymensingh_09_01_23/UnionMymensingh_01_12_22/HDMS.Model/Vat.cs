using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace HDMS.Model.Pharmacy {
    [Table("PhVat")]
public class PhVat{
public long Id{ get; set; }
public Double VatInPercent { get; set; }
}
}