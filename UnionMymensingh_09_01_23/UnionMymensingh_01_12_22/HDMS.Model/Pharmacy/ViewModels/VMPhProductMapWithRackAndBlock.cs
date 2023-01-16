using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMPhProductMapWithRackAndBlock
    {
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public int outletId { get; set; }
        public int ManufacturerId { get; set; }
        public string Generic { get; set; }
        public string Manufacturer { get; set; }
        public string RackNo { get; set; }
        public string BlockNo { get; set; }
    }
}
