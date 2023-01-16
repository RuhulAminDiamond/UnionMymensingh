using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class ReportConsultantWorkList
    {
        [Key]
        public int RCWId { get; set; }
        public int RCId { get; set; }
        public int TestGroupId { get; set; }
    }
}
