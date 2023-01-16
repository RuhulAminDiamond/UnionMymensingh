using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class VMCashMemoTranactionList
    {
        public string Label { get; set; }
        public double Value { get; set; }

        public bool IsDue { get; set; }
        public bool IsDicounted { get; set; }
        public string TransactionType { get; set; }

        public bool IsDrDiscounted { get; set; }
    }
}
