using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class LeaveApplication
    {
        [Key]
        public long ApplicationId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime AppDate { get; set; }
        public string ApplicationTo { get; set; }
        public string ApplicationThrough { get; set; }
        public string AppSubject { get; set; }
        public string Application { get; set; }
        public string ApprovalStatusLevel1 { get; set; }
        public string ApprovalStatusLevel2 { get; set; }
        public string ApprovalStatusLevel3 { get; set; }
        public DateTime Leavefrom { get; set; }
        public DateTime Leaveto { get; set; }

    }
}
