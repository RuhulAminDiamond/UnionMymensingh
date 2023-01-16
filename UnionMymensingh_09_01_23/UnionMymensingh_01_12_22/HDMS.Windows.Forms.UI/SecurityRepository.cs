using HDMS.Model;
using System;
using System.Linq;

namespace HDMS.Windows.Forms.UI
{
    internal class SecurityRepository
    {
        public SecurityRepository()
        {
        }

        public Patient GetLastEntryDiagnostic()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Patients.ToList().OrderByDescending(x => x.PatientId).FirstOrDefault();
            }
        }
    }
}