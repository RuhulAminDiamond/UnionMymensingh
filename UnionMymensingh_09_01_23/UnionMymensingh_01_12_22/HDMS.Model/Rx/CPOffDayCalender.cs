using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class CPOffDayCalender
    {
        public int Id { get; set; }
        public int CpId { get; set; }
        public string WeeklyOffDay { get; set; }
        public DateTime? MonthlyOffDate { get; set; }
    }
}
