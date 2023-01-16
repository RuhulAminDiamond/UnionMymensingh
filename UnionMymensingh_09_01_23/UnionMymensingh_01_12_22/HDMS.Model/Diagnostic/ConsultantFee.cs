using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class ConsultantFee
    {
        [Key]
        public int CFId { get; set; }
        public int RCId { get; set; }
        public int TestId { get; set; }
        public int FeeInPercent { get; set; }
        public int FeeInGross { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
