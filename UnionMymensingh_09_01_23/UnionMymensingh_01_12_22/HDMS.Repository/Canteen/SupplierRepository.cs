using HDMS.Model;
using HDMS.Model.Common;
using Models;
using Models.Canteen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.POS
{
    public class SupplierRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        string sql = string.Empty;
        public List<CantGroup> GetAllGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantGroups.ToList();
            }

        }

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

        public IList<SupplierInfo> GetAllSuppliers()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SupplierInfoes.ToList();
            }
        }

        

       

        public IList<SupplierInfo> GetAllSupplier()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SupplierInfoes.ToList();
            }
        }

       


        
    }
}
