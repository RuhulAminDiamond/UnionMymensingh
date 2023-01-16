using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmpDepartment
    {
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }
        public int DivId { get; set; }
    }
}
