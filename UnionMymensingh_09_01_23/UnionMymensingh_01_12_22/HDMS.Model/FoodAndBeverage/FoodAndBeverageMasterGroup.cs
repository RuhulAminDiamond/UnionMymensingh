using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.FoodAndBeverage
{
    public class FoodAndBeverageMasterGroup
    {
        [Key]
        public int MasterGroupId { get; set; }
        public string Name { get; set; }
    }
}
