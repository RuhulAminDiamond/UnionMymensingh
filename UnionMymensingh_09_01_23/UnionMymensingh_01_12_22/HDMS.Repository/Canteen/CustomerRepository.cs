using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Canteen;

namespace Repositories.POS
{
    public class CustomerRepository
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
        public bool AddNewCustomer(CantMemberInfo _cInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CantMemberInfoes.Add(_cInfo);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }

        public IList<CantMemberInfo> GetAllCustomers()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantMemberInfoes.ToList();
            }
        }

        public CantMemberInfo GetProductById(int cId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantMemberInfoes.Where(x => x.MemberId == cId).FirstOrDefault();
            }
        }

        public bool UpdateCustomer(CantMemberInfo _C)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_C).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
