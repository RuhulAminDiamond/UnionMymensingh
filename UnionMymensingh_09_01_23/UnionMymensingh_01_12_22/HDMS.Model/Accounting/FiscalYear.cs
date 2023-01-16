using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting
{
    public class FiscalYear 
    {
        [Key]
        public int FYId { get; set; }
        public DateTime FYStrat { get; set; }
        public DateTime FYEnd { get; set; }
        public bool IsClosed { get; set; }
    }
}
