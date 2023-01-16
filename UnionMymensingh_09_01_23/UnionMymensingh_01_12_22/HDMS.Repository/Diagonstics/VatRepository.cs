using HDMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Diagonstics
{
    public class VatRepository
    {
        public PhVat GetVateRates()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.Vats.ToList().FirstOrDefault();
            }
        }
    }
}
