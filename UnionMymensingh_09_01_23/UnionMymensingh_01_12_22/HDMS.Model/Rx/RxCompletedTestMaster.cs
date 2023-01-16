using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCompletedTestMaster
    {
        [Key]
        public int CTMId { get; set; }
        [ForeignKey("RxVisitHistory")]
        public long RxVisitId { get; set; }
        [ForeignKey("RxCpPreferredTestParameterMaster")]
        public int TpId { get; set; } // CP Preferred Test Parameter Id
       
        public RxVisitHistory RxVisitHistory { get; set; }
        public RxCpPreferredTestParameterMaster RxCpPreferredTestParameterMaster { get; set; }
    }
}
