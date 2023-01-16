using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.FoodAndBeverage
{
    public class VMFoodAndBeverageRequisition
    {
        public long RequisitionId { get; set; }
        public DateTime RDate { get; set; }
        public int LabId { get; set; }

        public string LabName { get; set; }
        public string RequisitionBy { get; set; }
        public int RequisitionbyId { get; set; }
        public string Status { get; set; }
    }
}

