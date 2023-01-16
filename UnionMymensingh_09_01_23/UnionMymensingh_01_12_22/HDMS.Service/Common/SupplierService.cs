using System;
using System.Collections.Generic;
using System.Linq;
using HDMS.Model.Common;
using HDMS.Models.Pharmacy;
using HDMS.Repositories.Common;

namespace HDMS.Service.Common
{
    public class SupplierService
    {
       

        public bool AddNewSupplier(SupplierInfo _sInfo)
        {
            return new SupplierRepository().AddNewSupplier(_sInfo);
        }
        public IList<SupplierInfo> GetAllSupplier()
        {
            return new SupplierRepository().GetAllSuppliers();
        }
        public SupplierInfo GetSupplier(int _supplierID)
        {
            return new SupplierRepository().GetSupplierById(_supplierID);
        }

        public double GetSupplierBanalce(int _SupplierId)
        {
            return new SupplierRepository().GetSupplierBanalce(_SupplierId);
        }

        public void SaveSupplierLedgerTransactions(List<SupplierLedger> _sLedgerList)
        {
            new SupplierRepository().SaveSupplierLedgerTransactions(_sLedgerList);
        }

        public IList<SupplierInfo> GetCanteenSuppliers()
        {
            return new SupplierRepository().GetCanteenSuppliers();
        }

        public IList<Manufacturer> GetAllManufacturers()
        {
            return new SupplierRepository().GetAllManufacturers();
        }
        public IList<Manufacturer> GetManufacturers()
        {
            return new SupplierRepository().GetManufacturers();
        }

        public Manufacturer GetManufacturerById(int orderTo)
        {
            return new SupplierRepository().GetManufacturerById(orderTo);
        }

        public IList<SupplierInfo> GetSupplierByCategory(string _type)
        {
            return new SupplierRepository().GetSupplierByCategory(_type);
        }
    }
}
