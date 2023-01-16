using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class VWPhProductList
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string BrandName { get; set; }
        public string FormationShortName { get; set; }
        public string GenericName { get; set; }
        public int GenericId { get; set; }
        public int FormationId { get; set; }
        public string GroupName { get; set; }
        public string SubGroup { get; set; }
        public string Manufacturer { get; set; }
        public string BoxNo { get; set; }


        public string BatchNo { get; set; }
        public double StockAvailable { get; set; }
        public DateTime ExpireDate { get; set; }
        public long LotNo { get; set; }
        public int OutLetId { get; set; }
        public double SaleRate { get; set; }
        public double PurchaseRate { get; set; }

        public string SideEffact { get; set; }

        public string DoseShortEn { get; set; }
        public string DoseShortBn { get; set; }
        public string DoseLongEn { get; set; }
        public string DoseLongBn { get; set; }

        public string Unit { get; set; }
        public string PkgUnit { get; set; }  // Packaging Style
        public int QtyPerBox { get; set; }
        public int ROLIndoor { get; set; }
        public int ROLOutdoor { get; set; }

    }
}
