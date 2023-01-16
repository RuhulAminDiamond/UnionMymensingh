using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using HDMS.Repository.Hospital;

namespace HDMS.Service.Hospital
{
    public class OTService
    {
        public OTSchedule GetOTSchedule(long admissionId)
        {
            return new OTRepository().GetOTSchedule(admissionId);
        }
    }
}
