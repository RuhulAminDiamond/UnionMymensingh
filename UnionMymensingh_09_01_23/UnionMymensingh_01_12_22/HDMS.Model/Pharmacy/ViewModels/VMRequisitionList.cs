using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMRequisitionList
    {

        public long RequisitionId { get; set; }

        public long RequisitionNo { get; set; }
        public int ProductId { get; set; }
        public int GenericId { get; set; }
        public string ProductCode { get; set; }
        public string BrandName { get; set; }

        public int OutLetId { get; set; }

        public double ReqQty { get; set; }

        public double StockAvailable { get; set; }

        public double PurchasePrice { get; set; }

        public double SalePrice { get; set; }

        public string BatchNo { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsStockShort { get; set; }

        public string ItemDeliveryStatus { get; set; }

        public string ReplaceRemarks { get; set; }
    }
}
