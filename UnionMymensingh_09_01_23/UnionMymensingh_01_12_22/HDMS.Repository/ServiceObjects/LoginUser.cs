using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.ServiceObjects
{
    public class LoginUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public RoleColeection Roles { get; set; }
       
        public ModuleCollection Modules { get; set; }

        public LoginUser()
        {
            Roles = new RoleColeection();
            Modules = new ModuleCollection();
        }
    }
}
