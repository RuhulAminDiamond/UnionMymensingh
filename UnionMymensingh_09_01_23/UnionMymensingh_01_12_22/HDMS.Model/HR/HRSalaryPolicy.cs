using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    [Table("HRSalaryPolicy")]
    public class HRSalaryPolicy
    {
        [Key]
        public int PolicyId { get; set; }
        public long EmployeeId { get; set; }
        public double BasicAmount { get; set; }
        public double HouseRentInPercentOfBasic { get; set; }
        public double MedicalAllownceInPercentOfBasic { get; set; }
        public double MobileAllownceTk { get; set; }
        public double TransportAllownceTk { get; set; }
        public double FestivalBonusInPercentOfBasic { get; set; }
        public double Others { get; set; }
        public double OvertimePerHour { get; set; }
        public double LateDeductionPerHour { get; set; }
        public double TaxDeduction { get; set; }
        public double PfDeduction { get; set; }
        public double InsuranceDeduction { get; set; }
        public double IncrementAmount { get; set; }
        public double TotalSalary { get; set; }
        public DateTime IncrementEffectDate { get; set; }
    }
}
