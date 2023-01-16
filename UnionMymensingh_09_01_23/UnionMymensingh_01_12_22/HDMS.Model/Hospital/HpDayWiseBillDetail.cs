using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
   public class HpDayWiseBillDetail
    {
        [Key]
        public long DayWiseBillDetailId { get; set; }
        [ForeignKey("HpDayWiseBill")]
        public int DayWiseBillId { get; set; }
        public int ServiceHeadId { get; set; }
        public double qnt { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string ServiceName { get; set; }
        public HpDayWiseBill HpDayWiseBill { get; set; }

    }
}
