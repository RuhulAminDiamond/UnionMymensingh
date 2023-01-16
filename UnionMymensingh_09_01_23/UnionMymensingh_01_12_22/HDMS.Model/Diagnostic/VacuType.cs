using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class VacuType
    {
        [Key]
        public int VTId { get; set; }
        public string VType { get; set; }

        public int TestId { get; set; } // ForeginKey- From TestItem
    }
}
