using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Store
{
    public class VMStoreItemInfo
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string GroupName { get; set; }

        public double SaleRate { get; set; }
        public double PurchaseRate { get; set; }
        public int ROL { get; set; }

        public int DebitAccId { get; set; }
        public int CreditAccId { get; set; }

        public string Unit { get; set; }

    }
}
