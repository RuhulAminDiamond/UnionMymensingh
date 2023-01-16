using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Store
{
    public class StoreDept
    {
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }
        public int ApprovalUserId { get; set; }
        public int IndentUserId { get; set; }
  
     }
    public class StoreDeptUser
    {
        public int Id { get; set; }
        [ForeignKey("StoreDept")]
        public int DeptId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public StoreDept StoreDept { get; set; }
        public Users.User User { get; set; }
    }
}
