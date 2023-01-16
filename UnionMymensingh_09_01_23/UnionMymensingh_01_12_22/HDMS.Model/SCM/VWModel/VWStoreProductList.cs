using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM.VWModel
{
   public class VWStoreProductList
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Unit { get; set; }
        public double PurchaseRate { get; set; }
        public double SaleRate { get; set; }
        public double WholeSaleRate { get; set; }
        public int ROL { get; set; }
        public int QtyPerCartoonOrBox { get; set; }
        public int DebitAccId { get; set; }
        public int CreditAccId { get; set; }

        public string BatchNo { get; set; }
        public double StockAvailable { get; set; }
        public DateTime ExpireDate { get; set; }
        public long LotNo { get; set; }

        public bool IsExpireDateRequired { get; set; }
    }
}
