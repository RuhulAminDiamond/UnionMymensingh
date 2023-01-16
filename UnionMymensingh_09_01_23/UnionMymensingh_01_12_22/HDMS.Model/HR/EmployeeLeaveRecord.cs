using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmployeeLeaveRecord
    {
        [Key]
        public long LRId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Leavefrom { get; set; }
        public DateTime Leaveto { get; set; }
        public int TotalDays { get; set; }
        public string LeaveType { get; set; }
    }
}
