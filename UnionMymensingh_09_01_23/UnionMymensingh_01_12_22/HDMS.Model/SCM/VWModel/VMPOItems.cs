using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM.VWModel
{
    public class VMPOItems
    {
        public long PONo { get; set; }
        public int ProductId { get; set; }
        public int POQty { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}
