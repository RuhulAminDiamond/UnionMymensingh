using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhStockInfo
    {
        [Key]
        public long StckId { get; set; }
        [ForeignKey("PhLotInfo")]
        public long LotNo { get; set; }
        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }
        [ForeignKey("MedicineOutlet")]
        public int OutLetId { get; set; }
        public double CurrentStock { get; set; }
        public double BookedQty { get; set; }
        public double PurchaseRate { get; set; }
        public double SaleRate { get; set; }
        public double PRIncludingVat { get; set; }
        public string BookedBy { get; set; }
        public PhLotInfo PhLotInfo { get; set; }
        public PhProductInfo PhProductInfo { get; set; }
        public MedicineOutlet MedicineOutlet { get; set; }
    }
}
