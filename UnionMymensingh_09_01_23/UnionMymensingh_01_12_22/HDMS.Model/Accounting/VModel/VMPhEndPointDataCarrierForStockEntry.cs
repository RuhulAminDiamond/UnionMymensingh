using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting.VModel
{
    public class VMPhEndPointDataCarrierForStockEntry
    {
        public int SupplierId { get; set; }
        public int StockAccId { get; set; }
        public int PurchaseAccId { get; set; }
        public int OutletId { get; set; }
        public double CostAmount { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double GrandTotal { get; set; }
        public string BillingDept { get; set; }
        public bool IsIpdReturn { get; set; }
        public bool IsNewpurchase { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionBy { get; set; }
       
    }
}
