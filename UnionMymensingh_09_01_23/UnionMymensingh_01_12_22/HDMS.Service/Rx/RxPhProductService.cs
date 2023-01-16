using HDMS.Model.Rx;
using HDMS.Repository.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Rx
{
    public class RxPhProductService
    {
        public RxCPPreferredMedicine GetRxCPPProductById(long cPPMId)
        {
            return new RxPhProductRepository().GetRxCPPProductById(cPPMId);
        }
    }
}
