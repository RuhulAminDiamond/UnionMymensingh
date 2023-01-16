using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpAdviceTemplateDetail
    {
        public long Id { get; set; }
        [ForeignKey("RxCpAdviceTemplateMaster")]
        public long TemplateId { get; set; }
        [ForeignKey("RxCPAdvice")]
        public int RxCpAdvId { get; set; }
        public string Advice { get; set; }
       
        public RxCpAdviceTemplateMaster RxCpAdviceTemplateMaster { get; set; }
        public RxCPAdvice RxCPAdvice { get; set; }
    }
}
