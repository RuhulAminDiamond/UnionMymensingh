using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{

    public class TimedAttendanceLogPullHistory
    {
        [Key]
        public long PullId { get; set; }
        public DateTime PullFromDate { get; set; }
        public string PullFromTime { get; set; }
        public DateTime PullToDate { get; set; }
        public string PullToTime { get; set; }
        public string PullFromSortableDateTime { get; set; }
        public string PullToSortableDateTime { get; set; }
    }


    public class TimedAttendanceLog
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("TimedAttendanceLogPullHistory")]
        public long PullId { get; set; }
        public int MachineNumber { get; set; }
        public int IndRegID { get; set; }
        public long EmployeeId { get; set; }
        public DateTime BDate { get; set; }   // Business/Working Date
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Remarks { get; set; }

        public DateTime InSortableDateTime { get; set; }
        public DateTime OutSortableDateTime { get; set; }
        public TimedAttendanceLogPullHistory TimedAttendanceLogPullHistory { get; set; }
    }


    public class TempGAttendanceLogData
    {
        public long Id { get; set; }
        
        public int MachineNumber { get; set; }
        public int IndRegID { get; set; }
        public string DateTimeRecord { get; set; }
        public DateTime DateOnlyRecord { get; set; }
        public DateTime TimeOnlyRecord { get; set; }

    }
}
