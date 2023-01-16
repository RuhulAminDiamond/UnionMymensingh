using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class PaymentChannel
    {
       [Key]
        public int PCId { get; set; }
        [ForeignKey("PaymentMode")]
        public int PMId { get; set; }
        public string Name { get; set; }
        public double ServiceCharge { get; set; }
        public PaymentMode PaymentMode { get; set; }
    }
}
