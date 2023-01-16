using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMPhSoldItem
    {
        public long InvoiceId { get; set; }
        public long LotNo { get; set; }
        public int OutLetId { get; set; }
        public int ProductId { get; set; }
       
        public string BrandName { get; set; }
        public double Qty { get; set; }
        public double RetQty { get; set; }
        public string Unit { get; set; }
        public double SaleRate { get; set; }
        public double PurchaseRate { get; set; }
        public double TotalPrice { get; set; }
    }
}
