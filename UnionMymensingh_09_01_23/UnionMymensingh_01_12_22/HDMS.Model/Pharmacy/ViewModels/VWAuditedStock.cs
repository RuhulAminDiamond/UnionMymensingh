using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VWAuditedStock
    {
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string Manufacturer { get; set; }
        public double SoftWareStock { get; set; }
        public double PhysicalStock { get; set; }
        public double SoftValue { get; set; }
        public double PhysicalVal { get; set; }
    }
}
