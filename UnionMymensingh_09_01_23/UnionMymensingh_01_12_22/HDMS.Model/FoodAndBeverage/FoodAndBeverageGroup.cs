using HDMS.Model.FoodAndBeverage;
using HDMS.Model.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodAndBeverage
{
    public class FoodAndBeverageGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        [ForeignKey("FoodAndBeverageMasterGroup")]
        public int MasterGroupId { get; set; }

        public FoodAndBeverageMasterGroup FoodAndBeverageMasterGroup { get; set; }
    }
}
