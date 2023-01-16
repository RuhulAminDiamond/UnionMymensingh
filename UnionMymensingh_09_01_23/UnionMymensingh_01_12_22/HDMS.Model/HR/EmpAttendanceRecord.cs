using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmpAttendanceRecord
    {
        [Key]
        public long AttRId { get; set; }
        [ForeignKey("HrWokingDay")]
        public long WDId { get; set; }
        [ForeignKey("EmployeeInfo")]
        public long EmployeeId { get; set; }
        public string AttendaceStatus { get; set; }

        public HrWokingDay HrWokingDay { get; set; }
        public EmployeeInfo EmployeeInfo { get; set; }
    }
}
