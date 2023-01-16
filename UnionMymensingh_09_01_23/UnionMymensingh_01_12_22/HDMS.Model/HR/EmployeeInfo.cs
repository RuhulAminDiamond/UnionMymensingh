using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmployeeInfo
    {
        [Key]
        public long EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
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

        public int EmpDivisionId { get; set; }
        public int DeptId { get; set; }
        public int DesignationId { get; set; }
        public bool IsHoD { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime Confirmationdate { get; set; }

        public int EmployeeCategory { get; set; }
        public string EmployeeJobLocation { get; set; }
        public string CareOf { get; set; }
        public string PostOffice { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        public string experience { get; set; }
        public double JoiningSalry { get; set; }
        public double WorkingHouse { get; set; }

    }
}
