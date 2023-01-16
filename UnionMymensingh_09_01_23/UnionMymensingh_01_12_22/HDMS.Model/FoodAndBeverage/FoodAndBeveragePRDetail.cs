using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.FoodAndBeverage
{
    public class FoodAndBeveragePRDetail
    {
        public long PRDId { get; set; }
        public long PRId { get; set; }
        public int ProductId { get; set; }
        public int PRQty { get; set; }
        public int ApprovedQty { get; set; }
    }
}
