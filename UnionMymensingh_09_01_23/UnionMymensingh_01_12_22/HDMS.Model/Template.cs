using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class Template
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string GroupName { get; set; }
        public string FileName { get; set; }
        public string TemplateName { get; set; }
        public byte[] TemplateContent { get; set; }
    }
}
