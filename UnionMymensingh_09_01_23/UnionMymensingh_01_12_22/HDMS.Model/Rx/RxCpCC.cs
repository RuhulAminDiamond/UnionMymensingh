using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpCC
    {
        [Key]
        public long RxCCId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string CCEn { get; set; }
        public string CCBn { get; set; }

        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
