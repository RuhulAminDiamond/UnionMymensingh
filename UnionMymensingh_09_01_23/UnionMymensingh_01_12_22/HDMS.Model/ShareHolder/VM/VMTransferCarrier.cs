using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class VMTransferCarrier
    {
        public VMshareTransfer TransferFrom { get; set; }
        public VMshareTransfer TransferTo { get; set; }
        public int transferedShare { get; set; }
        public DateTime TDate { get; set; }
        public string TransferBy { get; set; }
        public long ReceiptNo { get; set; }
        public int? ShareCountStart { get; set; }
        public int? ShareCountEnd { get; set; }
    }
}
