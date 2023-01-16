using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class VMEmployeeRoster
    {
        public long RosterId { get; set; }
        public DateTime RosterDate { get; set; }
        public string RosterDay { get; set; }
        public int RosterOrder { get; set; }
        public string MorningEmpid { get; set; }
        public string MorningEmpName { get; set; }
        public string EveningEmpid { get; set; }
        public string EveningEmpName { get; set; }
        public string NightEmpid { get; set; }
        public string NightEmpName { get; set; }

        public string OverTimeEmpid { get; set; }
        public string OverTimeEmpName { get; set; }
        public string DayOffEmpid { get; set; }
        public string DayOffEmpName { get; set; }
        public int DeptId { get; set; }
        public int DesignationId { get; set; }

    }
}
