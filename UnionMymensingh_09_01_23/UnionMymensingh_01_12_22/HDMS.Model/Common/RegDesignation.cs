using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class RegDesignation
    {
        [Key]
        public int DesignationId { get; set; }
        public string Designation { get; set; }
    }
}
