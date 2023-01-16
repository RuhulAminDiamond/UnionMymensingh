using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx.VModel
{
    public class RxVMPatientBasicInfo
    {
        public long RegNo { get; set; }
        public long RxVisitId { get; set; }
        public int PSrlNo { get; set; }
        public DateTime VisitDate { get; set; }
        public string  Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        
    }
}
