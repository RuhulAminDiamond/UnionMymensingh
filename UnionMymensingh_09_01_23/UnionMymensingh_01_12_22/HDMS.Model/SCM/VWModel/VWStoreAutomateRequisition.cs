using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM.VWModel
{
    public class VWStoreAutomateRequisition
    {
        public long LotNo { get; set; }
        public int ProductId { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpireDate { get; set; }
        public int OutletId { get; set; }
        public double Qty { get; set; }
    }
}
