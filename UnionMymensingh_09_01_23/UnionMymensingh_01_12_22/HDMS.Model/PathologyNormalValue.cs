using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDMS.Model
{
   public class PathologyNormalValue
    {
       public int Id { get; set; }
       public int TestDetailId { get; set; }
       public float Age { get; set; }
       public string lowerValue { get; set; }
       public string upperValue { get; set; }
       public string alarmingValue { get; set; }
       public string ResultUnit { get; set; }
    }
}
