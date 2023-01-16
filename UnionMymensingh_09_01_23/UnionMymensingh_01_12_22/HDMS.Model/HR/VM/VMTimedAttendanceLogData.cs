using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR.VM
{
    public class VMTimedAttendanceLogData
    {
        public DateTime BDate { get; set; }  // Business or Working Day
        public long EmployeeId { get; set; }
        public int IndRegID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Remarks { get; set; }

        public DateTime InSortableDateTime { get; set; }
        public DateTime OutSortableDateTime { get; set; }


    }
}
