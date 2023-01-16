using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPDiseaseTemplateAdviceData
    {
        
        public long  Id { get; set; }
        [ForeignKey("RxCPDiseaseTemplate")]
        public long DTId { get; set; }
        [ForeignKey("RxCPAdvice")]
        public int RxCpAdvId { get; set; }
        public string Advice { get; set; }
        public RxCPAdvice RxCPAdvice { get; set; }
        public RxCPDiseaseTemplate RxCPDiseaseTemplate { get; set; }
    }
}
