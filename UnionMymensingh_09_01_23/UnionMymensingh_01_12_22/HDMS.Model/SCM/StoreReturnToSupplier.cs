using HDMS.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM
{
   public class StoreReturnToSupplier
    {
        [Key]
        public long RetId { get; set; }
        public DateTime RetDate { get; set; }
        [ForeignKey("SupplierInfo")]
        public int SupplierId { get; set; }
        public string Remarks { get; set; }
        public string UserName { get; set; }
        public string ReturnClaim { get; set; }
        public SupplierInfo SupplierInfo { get; set; }
    }
}
