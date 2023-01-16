using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class HRPolicy
    {
        public int Id { get; set; }
        public int CL { get; set; }  // Casual Leave
        public int ML { get; set; }  // Maternity Leave
        public int MedicalLeave { get; set; }
        public bool AbsentDeduction { get; set; }
        public int lateConsiderAfterMins { get; set; }
        public int OnedaySalaryDeductionForLateInDays { get; set; }
    }
}
