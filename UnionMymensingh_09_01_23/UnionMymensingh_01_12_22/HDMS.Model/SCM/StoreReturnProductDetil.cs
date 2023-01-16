using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM
{
   public class StoreReturnProductDetil
    {
        [Key]
        public long RetDId { get; set; }
        [ForeignKey("StoreReturnToSupplier")]
        public long RetId { get; set; }
        public long LotNo { get; set; }
        public int ProductId { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Total { get; set; }

        public StoreReturnToSupplier StoreReturnToSupplier { get; set; }
    }
}
