using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class OpdOrEmgStock
    {
        [Key]
        public int EmgStockId { get; set; }
        public int CurrentStock { get; set; }
        public int ProductId { get; set; }
    }
}
