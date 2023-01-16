using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpHistoryTemplate
    {
        [Key]
        public long RxHTId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string Name { get; set; }
        public string History { get; set; }
        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
