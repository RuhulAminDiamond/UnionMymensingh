using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxAdviceToPatient
    {
        [Key]
        public int AdvId { get; set; }
        [ForeignKey("RxVisitHistory")]
        public long RxVisitId { get; set; }
        public string Advice { get; set; }
        [ForeignKey("RxCPAdvice")]
        public int RxCpAdvId { get; set; }
        public RxVisitHistory RxVisitHistory { get; set; }
        public RxCPAdvice RxCPAdvice { get; set; }
    }
}
