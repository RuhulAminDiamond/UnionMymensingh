using Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class LabStockInfo
    {
        public int Id { get; set; }
        [ForeignKey("LabInfo")]
        public int LabId { get; set; }
        [ForeignKey("StoreProductInfo")]
        public int ProductId { get; set; }
        public double Stock { get; set; }

        public LabInfo LabInfo { get; set; }
        public StoreProductInfo StoreProductInfo { get; set; }
    }
}
