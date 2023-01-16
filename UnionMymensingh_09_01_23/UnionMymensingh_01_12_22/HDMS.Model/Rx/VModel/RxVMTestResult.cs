using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx.VModel
{
    public class RxVMTestResult
    {
        public int VisitNo { get; set; }
        public DateTime VisitDate { get; set; }
        public string TestName { get; set; }
        public string TestParameter { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
    }
}
