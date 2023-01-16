using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR.VM
{
    public class VMLoanInfo
    {
        public long LoanId { get; set; }
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public double IssueAmount { get; set; }
        public int NoOfInstallemnt { get; set; }
        public double AmountPerInstallment { get; set; }
        public string InstamentStartMonth { get; set; }
        public int installmentStartYear { get; set; }
    }
}
