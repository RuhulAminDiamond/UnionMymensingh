using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR.VM
{
    public class JobCVDetail
    {
        public bool IsShorListed { get; set; }
        public int JCVId { get; set; }
        public int JCId { get; set; }
        public string JobCircularNo { get; set; }
        public string Applyfor { get; set; }
        public string ApplicatName { get; set; }
        public string ApplicatMobileNo { get; set; }
        public string FileName { get; set; }
        public byte[] CVInPdf { get; set; }

        public byte[] CVInWord { get; set; }

        public string Status { get; set; }
    }
}
