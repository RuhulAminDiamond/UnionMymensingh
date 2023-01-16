using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class ReportFee
    {
        [Key]
        public int RFId { get; set; }
        public int RCId { get; set; }
        public int TestId { get; set; }
        public double Fee { get; set; }
        public int ReportTypeId { get; set; }
    }
}
