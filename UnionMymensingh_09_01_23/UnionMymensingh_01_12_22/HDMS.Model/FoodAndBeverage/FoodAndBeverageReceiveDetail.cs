using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodAndBeverage
{
    public class FoodAndBeverageReceiveDetail
    {
        public long Id { get; set; }
        [ForeignKey("FoodAndBeverageReceive")]
        public long ReceiveId { get; set; }
        [ForeignKey("FoodAndBeverageProductInfo")]
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public double PurchaseRate { get; set; }
        public double Total { get; set; }

        public FoodAndBeverageReceive FoodAndBeverageReceive { get; set; }
        public FoodAndBeverageProductInfo FoodAndBeverageProductInfo { get; set; }
    }
}
