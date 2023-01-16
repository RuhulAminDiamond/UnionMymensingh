using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpPreferredTestParameterDetail
    {
        [Key]
        public int TpdId { get; set; }
        [ForeignKey("RxCpPreferredTestParameterMaster")]
        public int TpId { get; set; }
        public int TestId { get; set; }  //From Central DB TestItem Table
        public int TestDetailId { get; set; } //From Central DB ReportDefination Table
        public string Parameter { get; set; }
        public RxCpPreferredTestParameterMaster RxCpPreferredTestParameterMaster { get; set; }

    }
}
