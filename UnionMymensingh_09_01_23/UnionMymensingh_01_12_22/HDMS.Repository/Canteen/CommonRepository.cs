using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;

namespace Repositories.POS
{
    public class CommonRepository
    {
        public List<BusinessUnit> GetbusinessUnit()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BusinessUnits.ToList();

            }
        }
    }
}
