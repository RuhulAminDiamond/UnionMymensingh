using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VWPhProductInfo
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string Unit { get; set; }
        public string BrandName { get; set; }
        public string FormationShortName { get; set; }
        public string OutLetName { get; set; }

        public int ManufacturerId { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public long LotNo { get; set; }


        public string Generic { get; set; }
        public string Manufacturer { get; set; }
        public int Stock { get; set; }
        public int ROLIndoor { get; set; }


    }
}
