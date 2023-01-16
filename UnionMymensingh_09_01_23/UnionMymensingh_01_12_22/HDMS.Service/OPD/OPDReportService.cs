using HDMS.Repository.OPD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.OPD
{
    public class OPDReportService
    {
        public DataSet GetServiceList(long patientId, string _serviceType)
        {
            return new OPDReportRepository().GetServiceList(patientId, _serviceType);
        }
    }
}
