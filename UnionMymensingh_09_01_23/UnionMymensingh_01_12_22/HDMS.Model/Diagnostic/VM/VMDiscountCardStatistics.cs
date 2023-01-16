using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMDiscountCardStatistics
    {
        public int IssuedCard { get; set; }
        public int UsedCard { get; set; }
        public int UnusedCard { get; set; }
    }
}
