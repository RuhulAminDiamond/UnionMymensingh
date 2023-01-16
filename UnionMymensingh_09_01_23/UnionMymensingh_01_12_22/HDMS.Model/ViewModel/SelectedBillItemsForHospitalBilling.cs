using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class SelectedBillItemsForHospitalBilling
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public double Rate { get; set; }
        public double Qnt { get; set; }
        public double TotalAmount { get; set; }
    }
}
