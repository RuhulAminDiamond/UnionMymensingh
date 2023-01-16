using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPDiseaseTemplateHistoricalData
    {
        public long Id { get; set; }
        [ForeignKey("RxCPDiseaseTemplate")]
        public long DTId { get; set; }
        public string CC { get; set; }
        public string PresentHistory { get; set; }
        public string PastHistory { get; set; }
        public string TreatmentPaln { get; set; }
        public string OtherFindings { get; set; }
       
        public string DrugHistory { get; set; }
        public string CommentsOrReferral { get; set; }
        public string Notes { get; set; }
        public string Diagnosis { get; set; }
        public RxCPDiseaseTemplate RxCPDiseaseTemplate { get; set; }
    }
}
