using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Store
{
    public class StoreReceiveDetail
    {
        public long Id { get; set; }
        [ForeignKey("StoreReceive")]
        public long ReceiveId { get; set; }
        [ForeignKey("StoreProductInfo")]
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public double PurchaseRate { get; set; }
        public double Total { get; set; }
        public long LotNo { get; set; }

        public StoreReceive StoreReceive { get; set; }
        public StoreProductInfo StoreProductInfo { get; set; }
    }
}
