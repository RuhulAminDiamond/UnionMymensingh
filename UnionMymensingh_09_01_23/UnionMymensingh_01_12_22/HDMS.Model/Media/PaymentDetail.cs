using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Media
{
    public class PaymentDetail
    {
        public double TotalSale { get; set; }
        public double MediaCommission { get; set; }
        public double Discount { get; set; }
        public double Payable { get; set; }
    }
}
