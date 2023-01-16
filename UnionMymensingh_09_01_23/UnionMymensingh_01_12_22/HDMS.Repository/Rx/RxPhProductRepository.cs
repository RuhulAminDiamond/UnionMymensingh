using HDMS.Model.Rx;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Rx
{
    public class RxPhProductRepository
    {
        public RxCPPreferredMedicine GetRxCPPProductById(long cPPMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPPreferredMedicines.Where(x=>x.CPPMId== cPPMId).FirstOrDefault();
            }
        }

        public bool UpCPPreferredDrugs(RxCPPreferredMedicine preferredMedicine)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(preferredMedicine).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public void DeleteDoseFromCpPersonalDb(RxCpDosage dose)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxCpDosages Where DoseId={0}",new object[] { dose.DoseId });
            }
        }
    }
}
