using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmpLoanInfo
    {
        [Key]
        public long LoanId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime IssueDate { get; set; }
        public double IssueAmount { get; set; }
        public int NoOfInstallment { get; set; }
        public double AmountPerInstallment { get; set; }
        public string InstallmentStartMonth { get; set; }
        public int InstallmentStartYear { get; set; }
    }

    public class LoanInstallmentCollection
    {
        [Key]
        public long LCId { get; set; }
        public long EmployeeId { get; set; }
        public long LoanId { get; set; }
        public int InstallmentNo { get; set; }
        public DateTime CDate { get; set; }
        public double CAmount { get; set; }
       
    }
}
