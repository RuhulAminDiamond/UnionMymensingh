using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Store
{
    public class StoreMasterGroup
    {
        [Key]
        public int StoreMasterGroupId { get; set; }
        public string Name { get; set; }
    }
}
