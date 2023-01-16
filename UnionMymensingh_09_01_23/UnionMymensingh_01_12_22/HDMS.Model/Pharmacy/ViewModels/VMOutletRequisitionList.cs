using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMOutletRequisitionList
    {
        public long RequisitionId { get; set; }
        public int ProductId { get; set; }
        public int GenericId { get; set; }
      
        public string BrandName { get; set; }
        public double TransferQty { get; set; }
        public double ReqQty { get; set; }
        public double AvailQty { get; set; }
       
        public double PurchasePrice { get; set; }

        public double SalePrice { get; set; }


        public bool IsStockShort { get; set; }

        public string Status { get; set; }

        public string ReplaceRemarks { get; set; }
    }
}
