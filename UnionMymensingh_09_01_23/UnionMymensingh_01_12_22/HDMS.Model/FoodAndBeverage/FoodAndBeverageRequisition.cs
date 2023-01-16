using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.FoodAndBeverage
{
    public class FoodAndBeverageRequisition
    {
        [Key]
        public long RequisitionId { get; set; }
        [ForeignKey("FoodAndBeverageDept")]
        public int DeptId { get; set; }
        public DateTime RDate { get; set; }
        public string RTime { get; set; }
        public string OperateBy { get; set; }
        public string Status { get; set; }

        public FoodAndBeverageDept FoodAndBeverageDept { get; set; }
    }


    public class FoodAndBeverageRequisitionDetail
    {
        [Key]
        public long RDId { get; set; }
        [ForeignKey("FoodAndBeverageRequisition")]
        public long RequisitionId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }

        public FoodAndBeverageRequisition FoodAndBeverageRequisition { get; set; }
    }
}

