using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Canteen
{
    public class CantMemberLedger
    {
        public Int64 Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Trandate { get; set; }
        public string Particulars { get; set; }
        public Double Debit { get; set; }
        public Double Credit { get; set; }
        public Double Balance { get; set; }
        public string TransactionType { get; set; }
        public string OperateBy { get; set; }
    }
}
