using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPAdvice
    {
        [Key]
        public int RxCpAdvId { get; set; }
        public int CPId { get; set; }
        public string AdviceEn { get; set; }
        public string AdviceBn {get; set; }

        public string ShortKey { get; set; }
    }
}
