using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Canteen
{
    public class VMCanteenCashMemoTranactionList
    {
        public string Label { get; set; }
        public double Value { get; set; }

        public bool IsDue { get; set; }
        public bool IsDicounted { get; set; }
    }
}
