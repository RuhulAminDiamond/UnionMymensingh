using HDMS.Model.Diagnostic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class VacuWithTestSetting
    {
        [Key]
        public int VSId { get; set; }
        [ForeignKey("VacuType")]
        public int VTId { get; set; }
        [ForeignKey("TestItem")]
        public int TestId { get; set; }

        public VacuType VacuType { get; set; }
        public TestItem TestItem { get; set; }
    }
}
