using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMIssuedProductAgainstRequisition
    {
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public int Qty { get; set; }
    }
}
