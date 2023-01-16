using HDMS.Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Store
{
    public class StoreProductRepository
    {

        public IList<StoreProductSubGroup> GetAllGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreProductSubGroups.ToList();
            }
        }

        public bool AddNewProduct(StoreProduct _pInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.StoreProducts.Add(_pInfo);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public StoreProduct GetProductById(int _PId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreProducts.Where(x=>x.ProductId==_PId).FirstOrDefault();
            }
        }

        public bool CreateParentGroup(StoreProductMasterGroup _spm)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreProductMasterGroups.Add(_spm);
                entities.SaveChanges();
                return true;
            }
        }

        public bool CreateSubGroup(StoreProductSubGroup _spsg)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.StoreProductSubGroups.Add(_spsg);
                entities.SaveChanges();
                return true;
            }
        }

        public IList<StoreProductSubGroup> GetAllSubGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreProductSubGroups.ToList();
            }
        }

        public IList<StoreProductMasterGroup> GetAllMasterGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreProductMasterGroups.ToList();
            }
        }

        public bool UpdateProductInfo(StoreProduct _P)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_P).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<StoreProduct> GetAllProduct()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreProducts.ToList();
            }
        }
    }
}
