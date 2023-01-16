using Models.FoodAndBeverage;
using Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.FoodAndBeverage
{
    public class FoodAndBeverageItemUsesMaster
    {
        [Key]
        public long FBMId { get; set; }
        public int DeptId { get; set; }
        public long BillNo { get; set; }  // Patient Id
        public DateTime UDate { get; set; }
        public string UTime { get; set; }
        public int UserId { get; set; }
    }

    public class FoodAndBeverageItemUsesMasterDetail
    {
        [Key]
        public long FBMDId { get; set; }
        [ForeignKey("FoodAndBeverageItemUsesMaster")]
        public long FBMId { get; set; }
        [ForeignKey("FoodAndBeverageProductInfo")]
        public int ProductId { get; set; }
        public double Qty { get; set; }

        public FoodAndBeverageItemUsesMaster FoodAndBeverageItemUsesMaster { get; set; }
        public FoodAndBeverageProductInfo FoodAndBeverageProductInfo { get; set; }

    }
}
