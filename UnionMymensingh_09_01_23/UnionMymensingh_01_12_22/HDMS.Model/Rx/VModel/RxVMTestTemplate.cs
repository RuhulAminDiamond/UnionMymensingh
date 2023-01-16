using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx.VModel
{
    public class RxVMTestTemplate
    {
        public long RxVisitId { get; set; }
        public long DTId { get; set; }
        public long CPPTId { get; set; }
        public int TestId { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}
