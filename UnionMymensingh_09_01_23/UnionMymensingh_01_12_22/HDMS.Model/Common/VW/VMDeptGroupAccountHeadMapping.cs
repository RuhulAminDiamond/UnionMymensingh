using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common.VW
{
    public class VMDeptGroupAccountHeadMapping
    {
        public int Id { get; set; }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public int AccountHeadId { get; set; }
        public int ParentAccountHeadID { get; set; }
        public string AccountHeadName { get; set; }
        public string GroupName { get; set; }
        public double Amount { get; set; }
    }
}
