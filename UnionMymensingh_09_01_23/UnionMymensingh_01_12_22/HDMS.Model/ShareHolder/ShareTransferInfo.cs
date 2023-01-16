using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class ShareTransferInfo
    {
        [Key]
        public int transferId { get; set; }
        public long TrfFromId { get; set; }
        public long TrfToId { get; set; }
        public DateTime TDate { get; set; }
        public long SellShareAmount { get; set; }
        public long ReceiptNo { get; set; }
        public int? ShareCountStart { get; set; }
        public int? ShareCountEnd { get; set; }
    }
}
