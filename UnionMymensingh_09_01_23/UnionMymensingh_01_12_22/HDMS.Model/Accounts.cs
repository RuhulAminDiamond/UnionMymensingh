using System;
using System.ComponentModel.DataAnnotations;


namespace HDMS.Model {
public class Accounts{
    [Key]
public Int32 Accountid { get; set; }
public string Type { get; set; }
public string Accountname { get; set; }
public string Category { get; set; }
}
}