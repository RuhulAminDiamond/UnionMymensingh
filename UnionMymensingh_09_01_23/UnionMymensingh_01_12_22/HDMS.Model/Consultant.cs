using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDMS.Model {
 [Table("Consultants")]
public class Consultant{
[Key]
public int Id { get; set; }
public string Name { get; set; }
public string GroupId { get; set; }
public string Status { get; set; }

}
}