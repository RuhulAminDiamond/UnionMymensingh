using HDMS.Model.Common;
using Models;
using Models.Canteen;
using Repositories.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.POS
{
    public class LedgerService
    {

        public double GetBanalce(int CustomerId)
        {
            return new LedgerRepository().GetBanalce(CustomerId);
        }

        public void SaveCustomerLedgerTransactions(List<CantMemberLedger> _cLedgerList)
        {
             new LedgerRepository().SaveCustomerLedgerTransactions(_cLedgerList);
        }

        public void SaveSupplierLedgerTransactions(List<SupplierLedger> _sLedgerList)
        {
            new LedgerRepository().SaveSupplierLedgerTransactions(_sLedgerList);
        }

        public void SaveSaleLedger(List<CantSaleLedger> transactionList)
        {
            new LedgerRepository().SaveSaleLedger(transactionList);
        }

        public void SaveCustomerLedger(List<CantMemberLedger> _custTransaction)
        {
            new LedgerRepository().SaveCustomerLedger(_custTransaction);
        }

        public double GetSupplierBanalce(int _SupplierId)
        {
            return new LedgerRepository().GetSupplierBanalce(_SupplierId);
        }
    }
}
