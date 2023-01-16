using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class DischargeTemplate
    {
        [Key]
        public int TId { get; set; }
        public string TGroup { get; set; } // Template Group
        public string FileName { get; set; }
        public string TemplateName { get; set; }
        public byte[] TemplateContent { get; set; }
    }
}
