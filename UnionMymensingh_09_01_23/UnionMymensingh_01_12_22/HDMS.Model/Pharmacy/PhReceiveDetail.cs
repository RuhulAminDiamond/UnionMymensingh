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
    public class PhReceiveDetail
    {
        [Key]
        public long ReceiveDetailId { get; set; }
        [ForeignKey("PhReceive")]
        public long ReceivedId { get; set; }
        [ForeignKey("PhLotInfo")]
        public long LotNo { get; set; }

        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }
      
        public double Qty { get; set; }
        public double PurchaseRate { get; set; }
        public double Total { get; set; }
        public double disCountInpercent { get; set; }
        public double  grossDiscount{ get; set; }

        public double vatInpercent { get; set; }
        public double vatInTk { get; set; }

        public virtual PhLotInfo PhLotInfo { get; set; }
        public virtual PhReceive PhReceive { get; set; }
        public virtual PhProductInfo PhProductInfo { get; set; }
    }


   
}
