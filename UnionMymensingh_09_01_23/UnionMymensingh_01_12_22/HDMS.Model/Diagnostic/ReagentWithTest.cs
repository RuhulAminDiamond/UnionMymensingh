using Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
   public class ReagentWithTest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TestItem")]
        public int TestId { get; set; }
        [ForeignKey("StoreProductInfo")]
        public int ProductId { get; set; }
        public double Qty { get; set; }

        public TestItem TestItem { get; set; }
        public StoreProductInfo StoreProductInfo { get; set; }
    }
}
