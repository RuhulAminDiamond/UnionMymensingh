using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPTestTemplateDetail
    {
        public long Id { get; set; }
        [ForeignKey("RxCPTestTemplateMaster")]
        public long TemplateId { get; set; }
        public int TestId { get; set; } // From central test db
        public long CPPTId { get; set; } // From Cp Personal Test db

        public RxCPTestTemplateMaster RxCPTestTemplateMaster { get; set; }
       
    }
}
