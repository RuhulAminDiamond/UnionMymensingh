using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPPastHistory   // Additional Info
    {
        [Key]
        public long RxPHId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string HistoryEn { get; set; }
        public string HistoryBn { get; set; }

        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
