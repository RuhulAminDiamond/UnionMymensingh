using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy.ViewModels
{
    public class PhSelectedProductsToSaleOrReceiveOrOrder
    {
        public int Id { get; set; }
        public long BillNo { get; set; }
        public string Code { get; set; }
        public long LotNo { get; set; }
        public int OutLetId { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpireDate { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public DateTime? Ndate { get; set; }
        public double Qty { get; set; }
        public string Qty2 { get; set; }  // Needed for blank entry 
        public double RetQty { get; set; }
        public string Unit { get; set; }
        public int ROLOutdoor { get; set; }

        public double SRate { get; set; }

        public double PRate { get; set; }  //Purchase Rate

        public double PRIncludingVat { get; set; }

        public double Total { get; set; }
        public double PTotal { get; set; }   // Purchase Total

        public double DiscInPercentPerProduct { get; set; }

        public double Gtotal { get; set; }

        public double Discount { get; set; }

        public double VatInPercentPerProduct { get; set; }

        public double Vat { get; set; }

        public long InvoiceId { get; set; }

       public double CurrentStock { get; set; }
    }
}
