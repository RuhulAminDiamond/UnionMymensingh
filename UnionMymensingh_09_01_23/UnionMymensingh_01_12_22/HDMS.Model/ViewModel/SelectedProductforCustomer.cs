using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class SelectedProductforCustomer
    {
        public Int32 Id { get; set; }
        public Int32 GroupId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
    }
}
