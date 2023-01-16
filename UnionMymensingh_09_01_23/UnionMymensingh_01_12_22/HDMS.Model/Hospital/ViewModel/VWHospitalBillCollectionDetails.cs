using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VWHospitalBillCollectionDetails
    {
        public double HospitalPaymentByCash { get; set; }
        public double HospitalBillPaymentByPF { get; set; }
        public double DiscountOnHospital { get; set; }
        public double HospitalPaymentByHCV { get; set; }

    }
}
