using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class ServiceGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public string Createdby { get; set; }
        public string modifiedby { get; set; }
        public DateTime Modifieddate { get; set; }
    }
}
