using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.ServiceObjects
{
    public class Module
    {
        public string Name { get; set; }
        public ModulePermission.PermissionEnum Permission { get; set; }
    }
}
