using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VWRxPhProductList
    {
        public long CPPMId { get; set; }
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string Formation { get; set; }
        public string Manufacturer { get; set; }
        public string Generic { get; set; }
        public double CurrentStock { get; set; }
    }
}
