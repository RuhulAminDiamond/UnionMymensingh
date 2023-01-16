using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VWPhStockWithLotAndExpireInfo
    {
        public long StckId { get; set; }
        public long LotNo { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ProductId { get; set; }
        public int OutLetId { get; set; }
        public double CurrentStock { get; set; }
        public double PurchaseRate { get; set; }
        public double SaleRate { get; set; }
    }
}
