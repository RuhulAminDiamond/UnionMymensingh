using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.ServiceObjects
{
    public class ModuleCollection:List<Module>
    {
        public bool IsModuleExists(string moduleName)
        {
            return Exists(x => string.Compare(moduleName, x.Name, true) == 0);
        }
    }
}
