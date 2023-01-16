using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class LabInfo
    {
        [Key]
        public int LabId { get; set; }
        public string Name { get; set; }
        public string InChargeName { get; set; }
        public string Location { get; set; }
    }
}
