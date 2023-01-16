using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Users
{
    [Table("ModulePermission")]
    public class ModulePermission
    {
        [Key]
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public int ModuleId { get; set; }
        public PermissionEnum Permission { get; set; }

        public enum PermissionTypeEnum
        {
            Role=0,
            User
        }

        public enum PermissionEnum
        {
            None,
            Permitted
        }
        [ForeignKey("ModuleId")]
        public Module Module { get; set; }
    }
}
