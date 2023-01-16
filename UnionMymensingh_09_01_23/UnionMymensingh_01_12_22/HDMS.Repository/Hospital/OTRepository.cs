using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;

namespace HDMS.Repository.Hospital
{
    public class OTRepository
    {
        public OTSchedule GetOTSchedule(long admissionId)
        {
            using(DBEntities entities = new DBEntities())
            {
                return entities.OTSchedules.Where(x => x.AdmissionId == admissionId).FirstOrDefault();
            }
        }
    }
}
