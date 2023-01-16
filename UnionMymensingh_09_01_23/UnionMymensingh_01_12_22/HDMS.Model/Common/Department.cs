using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [ForeignKey("BusinessUnit")]
        public int BusinessUnitId { get; set; }
        public string Name { get; set; }
        public string ActivityNote { get; set; }
        public string Status { get; set; }

        public BusinessUnit BusinessUnit { get; set; }
    }
}
