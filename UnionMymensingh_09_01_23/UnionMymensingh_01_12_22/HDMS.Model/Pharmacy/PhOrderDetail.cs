using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
     public class PhOrderDetail
    {
        [Key]
        public long OrderDetailId { get; set; }
        //public Int64 Id { get; set; }
        //public int InvoiceId { get; set; }
        [ForeignKey("PhOrder")]
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public Double Qty { get; set; }
        public Double TotalPrice { get; set; }
        public virtual PhOrder PhOrder { get; set; }
    }
}
