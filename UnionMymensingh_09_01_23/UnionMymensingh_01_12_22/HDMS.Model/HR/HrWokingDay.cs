using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class HrWokingDay
    {
        [Key]
        public long WDId { get; set; }
        public DateTime WDate { get; set; }
        public int WDay { get; set; }
        public int WMonth { get; set; }
        public int WYear { get; set; }
        public bool IsPublicHoliday { get; set; }
        public string Remarks { get; set; }
    }
}
