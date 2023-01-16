using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodAndBeverage
{
    public class FoodAndBeverageInvoiceDetail
    {
        public long Id { get; set; }
        [ForeignKey("FoodAndBeverageInvoice")]
        public long InvoiceId { get; set; }
        [ForeignKey("FoodAndBeverageProductInfo")]
        public int ProductId { get; set; }
        public Double Qty { get; set; }

        public Double PurchaseRate { get; set; }

        public Double SaleRate { get; set; }

        public Double TotalPrice { get; set; }

        public Double Discount { get; set; }

        public FoodAndBeverageInvoice FoodAndBeverageInvoice { get; set; }
        public FoodAndBeverageProductInfo FoodAndBeverageProductInfo { get; set; }
    }
}
