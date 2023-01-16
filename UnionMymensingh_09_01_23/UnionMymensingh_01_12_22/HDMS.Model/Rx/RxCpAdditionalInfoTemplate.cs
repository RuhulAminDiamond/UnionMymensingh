using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpAdditionalInfoTemplate
    {
        [Key]
        public long RxAITId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string Name { get; set; }
        public string AdditionalInfo { get; set; }
        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
