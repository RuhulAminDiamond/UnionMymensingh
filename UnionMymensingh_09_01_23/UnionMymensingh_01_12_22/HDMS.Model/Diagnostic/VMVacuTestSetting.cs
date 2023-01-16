using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class VMVacuTestSetting
    {
        public int VSId { get; set; }
     
        public int VTId { get; set; }
      
        public int TestId { get; set; }

        public string TestName { get; set; }

        public string ShortName { get; set; }
    }
}
