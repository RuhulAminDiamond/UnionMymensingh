using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class VWMSelectedTestForPathologyReport
    {
       public string TestName{get;set;}
       public string TestCriteria{get;set;}
       public string TestResult{get;set;}
       public string ResultUnit{get;set;}
       public int DetailId { get; set; }
       public int TestId { get; set; }
       public int GroupId { get; set; }
       public string NormalResult { get; set; }
       public int ReportMachine { get; set; }
       public int HeaderId { get; set; }
    }
}
