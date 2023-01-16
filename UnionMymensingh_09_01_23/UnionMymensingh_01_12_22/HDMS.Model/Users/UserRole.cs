using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Users
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

       
        public int UserId { get; set; }

       
        public int RoleId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

    }
}
