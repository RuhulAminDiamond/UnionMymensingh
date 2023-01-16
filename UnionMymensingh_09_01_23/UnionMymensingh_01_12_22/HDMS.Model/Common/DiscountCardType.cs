using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class DiscountCardType
    {
        [Key]
        public int CardTypeId { get; set; }
        public string Name { get; set; }
        public double DiscountInPercent { get; set; }
    }
}
