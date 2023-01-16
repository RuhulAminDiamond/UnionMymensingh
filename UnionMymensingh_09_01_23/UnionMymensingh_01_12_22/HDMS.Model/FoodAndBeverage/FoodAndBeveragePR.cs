using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.FoodAndBeverage
{
    public class FoodAndBeveragePR
    {
        [Key]
        public long PRId { get; set; }
        public DateTime PRDate { get; set; }
        public int PRCreator { get; set; }
        public string PRApprovalStatus { get; set; }
        public int PRApprovedBy { get; set; }
        public DateTime PRApprovalDate { get; set; }
    }
}
