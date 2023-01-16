using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
     public class Generic
    {
        public int GenericId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
