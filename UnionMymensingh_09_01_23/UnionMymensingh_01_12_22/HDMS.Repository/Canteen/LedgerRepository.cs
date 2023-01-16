using Models;
using Models.Canteen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;

namespace Repositories.POS
{
    public class LedgerRepository
    {
        public double GetBanalce(int _CustomerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var result = entities.CantMemberLedgers
                   .Where(s => s.CustomerId == _CustomerId)
                   .AsEnumerable()
                   .Sum(s => s.Credit-s.Debit);

                return Convert.ToDouble(result);
            }
        }

        public void SaveCustomerLedgerTransactions(List<CantMemberLedger> _cLedgerList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.CantMemberLedgers.AddRange(_cLedgerList);
                entities.SaveChanges();
            }
        }

        public void SaveSupplierLedgerTransactions(List<SupplierLedger> _sLedgerList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.SupplierLedgers.AddRange(_sLedgerList);
                entities.SaveChanges();
            }
        }

        public void SaveCustomerLedger(List<CantMemberLedger> _custTransaction)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.CantMemberLedgers.AddRange(_custTransaction);
                entities.SaveChanges();
            }
        }

        public double GetSupplierBanalce(int _SupplierId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var result = entities.SupplierLedgers
                   .Where(s => s.SupplierId == _SupplierId)
                   .AsEnumerable()
                   .Sum(s => s.Credit - s.Debit);

                return Convert.ToDouble(result);
            }
        }

        public void SaveSaleLedger(List<CantSaleLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.CantSaleLedgers.AddRange(transactionList);
                entities.SaveChanges();
            }
        }

       
    }
}
