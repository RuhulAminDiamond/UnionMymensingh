using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.ServiceObjects
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public ModuleCollection Modules { get; set; }

        public Role()
        {
            Modules = new ModuleCollection();
        }
    }
}
