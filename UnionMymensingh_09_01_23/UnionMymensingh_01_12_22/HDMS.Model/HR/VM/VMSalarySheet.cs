using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR.VM
{
    public class VMSalarySheet
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public double BasicAmount { get; set; }
        public double HouseRent { get; set; }
        public double MedicalAllownce { get; set; }
        public double MobileAllownceTk { get; set; }
        public double TransportAllownceTk { get; set; }
        public double FestivalBonus { get; set; }
        public double Others { get; set; }
        public double Overtime { get; set; }
        public double LateDeduction { get; set; }
        public double LoanDeduction { get; set; }
        public double AdvanceDeduct { get; set; }
        public double InvestigationDue { get; set; }
        public double MedicineDue { get; set; }
        public double IPDDue { get; set; }
        public double CanteenDue { get; set; }
        public double TaxDeduction { get; set; }
        public double PFDeduction { get; set; }
        public double InsuranceDeduction { get; set; }

        public double Total { get; set; }

    }
}
