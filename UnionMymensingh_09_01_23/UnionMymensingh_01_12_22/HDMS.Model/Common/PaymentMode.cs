using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class PaymentMode
    {
        [Key]
        public int PMId { get; set; }
        public string Name { get; set; }
    }
}
