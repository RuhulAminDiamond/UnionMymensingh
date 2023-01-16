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
    public class PhStockTransferRecordDetail
    {

        [Key]
        public long STDId { get; set; }
        [ForeignKey("PhStockTransferRecord")]
        public long StTId { get; set; }
        [ForeignKey("PhLotInfo")]
        public long LotNo { get; set; }
        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public PhStockTransferRecord PhStockTransferRecord { get; set; }
        public PhLotInfo PhLotInfo { get; set; }
        public PhProductInfo PhProductInfo { get; set; }
    }
}
