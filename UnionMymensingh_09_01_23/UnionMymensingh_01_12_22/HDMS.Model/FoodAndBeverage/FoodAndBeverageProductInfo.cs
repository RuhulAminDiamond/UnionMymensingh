using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodAndBeverage
{
    public class FoodAndBeverageProductInfo
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        [ForeignKey("FoodAndBeverageGroup")]
        public int GroupId { get; set; }
        public string Unit { get; set; }
        public double PurchaseRate { get; set; }
        public double SaleRate { get; set; }
        public double WholeSaleRate { get; set; }
        public int ROL { get; set; }
        public int QtyPerCartoonOrBox { get; set; }
        public int DebitAccId { get; set; }
        public int CreditAccId { get; set; }

        public FoodAndBeverageGroup FoodAndBeverageGroup { get; set; }
    }
}