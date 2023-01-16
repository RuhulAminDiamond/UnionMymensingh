using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class BusinessUnit
    {
        [Key]
        public int BusinessUnitId { get; set; }
        public string Name { get; set; }

      
    }
}
