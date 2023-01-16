using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.ViewModel;
using HDMS.Repository.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Hospital
{
    public class HospitalBillingItemService
    {
       
        public List<ServiceHead> GetAllBillingItems()
        {
            return new HospitalBillingItemRepository().GetAllBillingItems();
        }


        private double getValue(string rate)
        {
            double _rate = 0;
            double.TryParse(rate, out _rate);
            return _rate;
        }


        public void SaveBillRecord(List<LedgerOfHospitalBillPayment> _ledgerlist)
        {
            new HospitalBillingItemRepository().SaveBillRecord(_ledgerlist);
        }

        public void SaveBillInfo(LedgerOfHospitalBillPayment ledger)
        {
            new HospitalBillingItemRepository().SaveBillInfo(ledger);
        }

        public VWHospitalBillCollectionDetails GetBillCollectionInfoByInvoice(int InvoiceId)
        {
          return  new HospitalBillingItemRepository().GetBillCollectionInfoByInvoice(InvoiceId);
        }

      
    }
}
