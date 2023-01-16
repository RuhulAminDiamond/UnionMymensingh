using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpPreferredTestParameterMaster
    {
        [Key]
        public int TpId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CpId { get; set; }
        [ForeignKey("RxCPPreferredTest")]
        public long CPPTId { get; set; }

        public ChamberPractitioner ChamberPractitioner { get; set; }
        public RxCPPreferredTest RxCPPreferredTest { get; set; }
    }
}
