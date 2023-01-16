using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhOrder
    {
        [Key]
        public long OrderId { get; set; }
        public int OrderTo { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderYear { get; set; }
        public int OrderMonth { get; set; }

        public int OrderGenerateBy { get; set; }
        public int OrderVerifiedBy { get; set; }

        public int OrderApprovedBy { get; set; }

    }
}
