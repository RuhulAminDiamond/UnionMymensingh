using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Canteen
{
    public class CantReceive
    {
        public long Id { get; set; }
        public DateTime RDate { get; set; }
        public string Particulars { get; set; }
        public double TotalTk { get; set; }
        public double DiscountTk { get; set; }
        public int SupplerId { get; set; }
        public string SChallanNo { get; set; }
        public string SInvoiceNo { get; set; }
        public DateTime SInvoiceDate { get; set; }
    }
}
