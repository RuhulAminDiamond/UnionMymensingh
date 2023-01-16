using HDMS.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhInvoiceDetail
    {
        [Key]
        public long InvoiceDetailId { get; set; }
      
        [ForeignKey("PhInvoice")]
        public long InvoiceId { get; set; }
        [ForeignKey("PhLotInfo")]
        public long LotNo { get; set; }
        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }

     
        public double Qty { get; set; }
        public double RetQty { get; set; }

        public double PurchaseRate { get; set; }

        public double SaleRate { get; set; }

        public double TotalPrice { get; set; }

        public double Discount { get; set; }

      

        public virtual PhLotInfo PhLotInfo { get; set; }
        public virtual PhInvoice PhInvoice { get; set; }
        public virtual PhProductInfo PhProductInfo { get; set; }

    }
}
