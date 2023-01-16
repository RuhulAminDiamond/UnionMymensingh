using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
   public  class GroupReportItem
    {
       public int Id { get; set; }
       public int GroupTestId { get; set; }
       public int TestId { get; set; }
       public int DisplayOrder { get; set; }
    }
}
