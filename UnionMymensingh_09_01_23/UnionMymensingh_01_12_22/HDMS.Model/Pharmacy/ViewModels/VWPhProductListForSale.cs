using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VWPhProductListForSale
    {
        public long StckId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public int GenericId { get; set; }
        public int FormationId { get; set; }
        public string BrandName { get; set; }
        public string FormationShortName { get; set; }  // Tab. or Cap. Inj. etc
        public long LotNo { get; set; }
        public int OutLetId { get; set; }
        public double StockAvailable { get; set; }
        public double BookedQty { get; set; }
        public string BookedBy { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Generic { get; set; }
        public string Manufacturer { get; set; }
        public string PkgUnit { get; set; }  // Packaging Style
        public int QtyPerBox { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
       
        public string RackNo { get; set; }
        public string BlockNo { get; set; }
    }
}
