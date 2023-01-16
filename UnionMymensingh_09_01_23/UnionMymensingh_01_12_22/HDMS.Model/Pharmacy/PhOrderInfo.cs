using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhOrderInfo
    {
        [Key]
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderTo { get; set; }
        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public int GenerateBy { get; set; }
        public int VerifiedBy { get; set; }
        public int ApprovedBy{get;set;}
        public string Status{get;set;}
        public virtual PhProductInfo PhProductInfo { get; set; }

    }
}
