using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMInvestigationList
    {
        public long PatientId { get; set; }
        public long AdmissionNo { get; set; }
        public string TestName { get; set; }

    }
}
