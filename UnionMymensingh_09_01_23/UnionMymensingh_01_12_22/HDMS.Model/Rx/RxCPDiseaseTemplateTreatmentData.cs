using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPDiseaseTemplateTreatmentData
    {
        public long Id { get; set; }
        [ForeignKey("RxCPDiseaseTemplate")]
        public long DTId { get; set; }
        public int ProductId { get; set; } // Central store product Id
        public long CPPMId { get; set; } // CP Preferred Medicine Id
        public string BrandName { get; set; }
        public string dosage { get; set; }
        public string duration { get; set; }
        public int Qty { get; set; }

        public RxCPDiseaseTemplate RxCPDiseaseTemplate { get; set; }
       
    }
}
