using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCompletedTestDetail
    {
        [Key]
        public long CTDId { get; set; }
        [ForeignKey("RxCompletedTestMaster")] 
        public int CTMId { get; set; }
        public int TpdId { get; set; } // Id from RxCpPreferredTestParameterDetail
        public string Parameter { get; set; }
        public string ParameterValue { get; set; }
        public RxCompletedTestMaster RxCompletedTestMaster { get; set; }

    }
}
