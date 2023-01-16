using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMPhStock
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string BrandName { get; set; }
        public string BatchNo { get; set; }
        public string ExpireDate { get; set; }
        public double PPrice { get; set; }
        public double SPrice { get; set; }
        public long TPQty { get; set; }
        public long TSQty { get; set; }
        public long StockAvail { get; set; }
        public double TPValue { get; set; }
        public double TSValue { get; set; }
    }
}
