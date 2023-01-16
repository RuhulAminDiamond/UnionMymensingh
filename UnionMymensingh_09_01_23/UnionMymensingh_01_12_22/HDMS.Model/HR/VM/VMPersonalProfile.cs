using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR.VM
{
    public class VMPersonalProfile
    {
        public long EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public int Nationality { get; set; }
        public string NationIDorPPNo { get; set; }

        public int DeptId { get; set; }
        public int DesignationId { get; set; }
    }
}
