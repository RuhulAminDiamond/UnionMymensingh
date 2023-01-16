using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPTreatmentPlan
    {
        [Key]
        public long RxTPId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string TreatmentPlanEn { get; set; }
        public string TreatmentPlanBn { get; set; }

        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
