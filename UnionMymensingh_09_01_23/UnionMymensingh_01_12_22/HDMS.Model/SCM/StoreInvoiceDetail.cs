using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Store
{
    public class StoreInvoiceDetail
    {
        public long Id { get; set; }
        [ForeignKey("StoreInvoice")]
        public long InvoiceId { get; set; }
        [ForeignKey("StoreProductInfo")]
        public int ProductId { get; set; }
        public Double Qty { get; set; }

        public Double PurchaseRate { get; set; }

        public Double SaleRate { get; set; }

        public Double TotalPrice { get; set; }

        public Double Discount { get; set; }

        public StoreInvoice StoreInvoice { get; set; }
        public StoreProductInfo StoreProductInfo { get; set; }
    }
}
