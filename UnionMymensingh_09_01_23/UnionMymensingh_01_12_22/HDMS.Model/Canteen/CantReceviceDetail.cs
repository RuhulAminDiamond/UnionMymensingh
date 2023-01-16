using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Canteen
{
    public class CantReceiveDetail
    {
        public long Id { get; set; }
        public long ReceivedId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public double PurchaseRate { get; set; }
        public double Total { get; set; }
    }
}
