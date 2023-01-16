using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhStockAuditMasterDetail
    {
        [Key]
        public long AMDId { get; set; }
        public long AMId { get; set; }
        public int ProductId { get; set; }
        public int SoftWareStock { get; set; }
        public int PhysicalStock { get; set; }
    }
}
