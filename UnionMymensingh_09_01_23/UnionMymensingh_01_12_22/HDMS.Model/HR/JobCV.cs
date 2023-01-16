using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class JobCV
    {
        [Key]
        public int JCVId { get; set; }
        [ForeignKey("JobCirculation")]
        public int JCId { get; set; }
        public string Applyfor { get; set; }
        public string ApplicatName { get; set; }
        public string ApplicatMobileNo { get; set; }
        public string FileName { get; set; }
        public byte[] CVInPdf { get; set; }
       
        public byte[] CVInWord { get; set; }

        public string Status { get; set; }

        public JobCirculation JobCirculation { get; set; }
    }
}
