using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhStockInfoesDateWiseHistory
    {
        [Key]
        public int AutoId { get; set; }
        public DateTime FilterDate { get; set; }
        public string ProductStock { get; set; }
    }
}
