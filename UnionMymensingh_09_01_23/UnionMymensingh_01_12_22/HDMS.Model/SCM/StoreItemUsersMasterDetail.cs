using Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Store
{
    public class StoreItemUsesMaster
    {
        [Key]
        public long StMId { get; set; }
        public int DeptId { get; set; }
        public long BillNo { get; set; }  // Patient Id
        public DateTime UDate { get; set; }
        public string UTime { get; set; }
        public int UserId { get; set; }
    }

    public class StoreItemUsesMasterDetail
    {
        [Key]
        public long StMDId { get; set; }
        [ForeignKey("StoreItemUsesMaster")]
        public long StMId { get; set; }
        [ForeignKey("StoreProductInfo")]
        public int ProductId { get; set; }
        public double Qty { get; set; }

        public StoreItemUsesMaster StoreItemUsesMaster { get; set; }
        public StoreProductInfo StoreProductInfo { get; set; }

    }
}
