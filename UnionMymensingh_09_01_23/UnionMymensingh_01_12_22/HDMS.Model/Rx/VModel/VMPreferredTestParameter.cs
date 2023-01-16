using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx.VModel
{
    public class VMPreferredTestParameter
    {
        public int TpId { get; set; }
        public long CPPTId { get; set; }
        public int TestId { get; set; }  //From Central DB TestItem Table
        public int TestDetailId { get; set; } //From Central DB ReportDefination Table
        public string Parameter { get; set; }
    }
}
