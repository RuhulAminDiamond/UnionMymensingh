using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmpDesignation
    {
        [Key]
        public int DesignationId { get; set; }
        public string Name { get; set; }
    }
}
