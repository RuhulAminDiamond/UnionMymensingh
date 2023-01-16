using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class VMEmployeeInfo
    {
        public long EmployeeId { get; set; }
        public string EmployeeNo { get; set; }

        public int JCId { get; set; }
        public int JCVId { get; set; }
        public string CirculationNo { get; set; }

        public int BiometricEnrollmentNo { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public int Nationality { get; set; }
        public int NationalId { get; set; }
        public string NationalIdOrPPNo { get; set; }
        public bool IsHoD { get; set; }
        public string Address { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DOB { get; set; }
        public int DeptId { get; set; }
        public int DesignationId { get; set; }
        public int CL { get; set; }

        public int CLExp { get; set; }

       

    }
}
