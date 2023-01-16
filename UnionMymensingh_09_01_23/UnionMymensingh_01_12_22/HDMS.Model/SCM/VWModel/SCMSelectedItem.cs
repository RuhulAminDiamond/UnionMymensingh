using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM.VWModel
{
    public class SCMSelectedItem
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public long LotNo { get; set; }
        public int OutLetId { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpireDate { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public double Qty { get; set; }
        public double RetQty { get; set; }
        public string Unit { get; set; }

        public double Rate { get; set; }

        public double PRate { get; set; }  //Purchase Rate

        public double Total { get; set; }

        public double DiscInPercentPerProduct { get; set; }

        public double Gtotal { get; set; }

        public double Discount { get; set; }

        public long InvoiceId { get; set; }

        public long BillNo { get; set; }  // Bill No

        public int DebitAccId { get; set; }
        public int CreditAccId { get; set; }
    }
}
