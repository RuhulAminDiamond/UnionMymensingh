using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR.VM
{
    public class VMLeaveApplication
    {
        public long EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DOB { get; set; }
        public int DeptId { get; set; }
        public int DesignationId { get; set; }
        public int CL { get; set; }

        public int CLExp { get; set; }

        public long ApplicationId { get; set; }
        public DateTime AppDate { get; set; }
        public string ApplicationTo { get; set; }
        public string AppSubject { get; set; }
        public string Application { get; set; }
        public string ApprovalLevel1 { get; set; }
        public string ApprovalLevel2 { get; set; }
        public string ApprovalLevel3 { get; set; }
        public DateTime Leavefrom { get; set; }
        public DateTime Leaveto { get; set; }


    }
}
