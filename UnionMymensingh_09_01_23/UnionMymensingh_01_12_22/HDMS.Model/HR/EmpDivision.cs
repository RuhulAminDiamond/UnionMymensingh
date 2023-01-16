using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Models
{
    public class EmpDivision
    {
        [Key]
        public int DivId { get; set; }
        public string Name { get; set; }

    }
}
