using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class CantSelectedProductsToSaleOrReceive
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Qty { get; set; }
        public string Unit { get; set; }
        public double Rate { get; set; }
        public double Total { get; set; }

        public int DebitAccId { get; set; }
        public int CreditAccId { get; set; }
    }
}
