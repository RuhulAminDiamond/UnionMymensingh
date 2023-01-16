using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories.POS;
using Models.Canteen;

namespace Services.POS
{
    public class CustomerServices
    {
        public List<CantGroup> GetAllGroups()
        {
            return new CustomerRepository().GetAllGroups();
        }
        public bool AddNewCustomer(CantMemberInfo _cInfo)
        {
            return new CustomerRepository().AddNewCustomer(_cInfo);
        }

        public IList<CantMemberInfo> GetAllCustomer()
        {
            return new CustomerRepository().GetAllCustomers();
        }

        public CantMemberInfo GetCustomerById(int cId)
        {
            return new CustomerRepository().GetProductById(cId);
        }

        public bool UpdateCustomer(CantMemberInfo _C)
        {
            return new CustomerRepository().UpdateCustomer(_C);
        }
    }
}
