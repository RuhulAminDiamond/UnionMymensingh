using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.FoodAndBeverage
{
    public class VMFoodAndBeverageDept
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public int IndentUserId { get; set; }
        public string LoginName { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
    }
}
