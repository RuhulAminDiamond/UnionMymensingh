using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder.VM
{
    public class VMShareTransferDetail
    {
        public int transferId { get; set; }
        public DateTime TDate { get; set; }
        public int MyProperty { get; set; }
        public long TransferrerShareNo { get; set; }
        public string TransferrerName { get; set; }
        public long ReceiverShareNo { get; set; }
        public string ReceiverName { get; set; }
        public long SellShareAmount { get; set; }
        public long ReceiptNo { get; set; }
        public int? ShareCountStart { get; set; }
        public int? ShareCountEnd { get; set; }
    }
}
