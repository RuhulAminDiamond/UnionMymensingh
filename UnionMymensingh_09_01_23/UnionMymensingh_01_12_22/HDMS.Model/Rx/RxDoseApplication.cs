using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxDoseApplication   // Before or After Meal
    {
        [Key]
        public int DAppId { get; set; }
        public string DoseApplyRole { get; set; }
        public bool IsBanglaFont { get; set; }
    }
}
