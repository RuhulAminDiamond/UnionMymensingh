using HDMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxDoseEMRInterpretation
    {
        [Key]
        public int EmrIId { get; set; }
        public string Description { get; set; }
        public RxDoseApplyModeEnum InPCode { get; set; }  // Inter Pretation Code
        

    }
}
