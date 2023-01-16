using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Canteen
{
    public class CantProductInfo
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Unit { get; set; }
        public double PurchaseRate { get; set; }
        public double SaleRate { get; set; }
        public double WholeSaleRate { get; set; }
        public int ROL { get; set; }
        public int QtyPerCartoonOrBox { get; set; }
    }
}
