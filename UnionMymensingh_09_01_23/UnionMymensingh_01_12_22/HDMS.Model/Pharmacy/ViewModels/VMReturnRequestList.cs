using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMReturnRequestList
    {

        public long ReturnId { get; set; }

        public int ProductId { get; set; }

        public string ProductCode { get; set; }
        public string BrandName { get; set; }

        public double RetQty { get; set; }

        public double SalePrice { get; set; }

        public double PurchasePrice { get; set; }

        public double TotalPrice { get; set; }

        public string Unit { get; set; }

        public long LotNo { get; set; }
        public int OutLetId { get; set; }

       
    }
}
