using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhStockAuditMaster
    {
        [Key]
        public long AMId { get; set; }
        public string AMonth { get; set; }
        public int AYear { get; set; }
      
    }
}
