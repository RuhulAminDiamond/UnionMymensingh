

using HDMS.Model.Common;
using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HDMS.Repositories.Common
{
    public class SupplierRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        string sql = string.Empty;


        public bool AddNewSupplier(SupplierInfo _sInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.SupplierInfoes.Add(_sInfo);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


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

        public IList<Manufacturer> GetAllManufacturers()
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.Manufacturers.ToList();
                

            }
        }
        public IList<Manufacturer> GetManufacturers()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Manufacturers.ToList();


            }
        }

        public Manufacturer GetManufacturerById(int orderTo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Manufacturers.Where(x=>x.ManufacturerId== orderTo).FirstOrDefault();

            }
        }

        public IList<SupplierInfo> GetSupplierByCategory(string _type)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SupplierInfoes.Where(x => x.Category == _type).ToList();

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

        public SupplierInfo GetSupplierById(int _supplierID)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SupplierInfoes.Where(x => x.SupplierId == _supplierID).FirstOrDefault();
            }
        }

        public IList<SupplierInfo> GetCanteenSuppliers()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SupplierInfoes.Where(x => x.Category.ToLower() == "canteen").ToList();
            }
        }

        public IList<SupplierInfo> GetAllSuppliers()
        {
            using (DBEntities entities = new DBEntities())
            {

                try
                {
                    return entities.SupplierInfoes.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
