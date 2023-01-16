using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class DeptGroupWithAccountMapping
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public int AccountHeadId { get; set; }
    }
}
