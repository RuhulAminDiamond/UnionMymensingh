using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodAndBeverage
{
    public class FoodAndBeverageReceive
    {
        [Key]
        public long ReceiveId { get; set; }
        public DateTime RDate { get; set; }
        public string Particulars { get; set; }
        public double TotalTk { get; set; }
        public double DiscountTk { get; set; }
        public double PaidTk { get; set; }
        public int SupplerId { get; set; }
        public string SChallanNo { get; set; }
        public string SInvoiceNo { get; set; }
        public DateTime SInvoiceDate { get; set; }
    }
}
