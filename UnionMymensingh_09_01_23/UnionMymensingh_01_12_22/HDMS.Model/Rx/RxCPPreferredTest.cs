using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPPreferredTest  // Tests Personal Database
    {
        [Key]
        public long CPPTId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public int TestGroupId { get; set; }
        public int TestId { get; set; }  // Central Database Test Id
        public string TestName { get; set; }

        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
