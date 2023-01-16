using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPOtherFinding
    {
       
        public long Id { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string OtherFindingEn { get; set; }
        public string OtherFindingBn { get; set; }

        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
