using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMLabRequisitionList
    {

        public long RequisitionId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }

        public double ReqQty { get; set; }

        public double StockAvailable { get; set; }

        public bool IsStockShort { get; set; }
    }
}
