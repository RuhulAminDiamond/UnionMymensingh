using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPTestTemplateMaster
    {
        [Key]
        public long TemplateId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDefault { get; set; }
        public ChamberPractitioner ChamberPractitioner { get; set; }
        
    }

   
}
