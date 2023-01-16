using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmployeeEducationalQualification
    {
        [Key]
        public int EmEduQualificationId { get; set; }
        public long EmployeeId { get; set; }
        public string NameOfExam { get; set; }
        public int Passingyear { get; set; }
        public string Department { get; set; }
        public string GPA { get; set; }
        public string Board { get; set; }

    }
}
