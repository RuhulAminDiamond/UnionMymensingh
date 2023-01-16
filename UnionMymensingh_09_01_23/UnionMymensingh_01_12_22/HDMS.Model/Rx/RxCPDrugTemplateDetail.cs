using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPDrugTemplateDetail
    {
        public long Id { get; set; }
        [ForeignKey("RxCPDrugTemplateMaster")]
        public long TemplateId { get; set; }
        public int ProductId { get; set; } // From central medicine db
        public long CPPMId { get; set; } // From Personal Medicine db
        public string Dosage { get; set; }
        public string Duration { get; set; }
        public int Qty { get; set; }
       

        public RxCPDrugTemplateMaster RxCPDrugTemplateMaster { get; set; }
       

    }
}
