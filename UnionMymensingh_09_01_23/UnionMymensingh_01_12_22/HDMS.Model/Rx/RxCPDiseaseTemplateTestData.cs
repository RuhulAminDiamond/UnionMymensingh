using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPDiseaseTemplateTestData
    {
        public long Id { get; set; }
        [ForeignKey("RxCPDiseaseTemplate")]
        public long DTId { get; set; }
        public int TestId { get; set; } // Central Test Db TestId
        public long CPPTId { get; set; } // Cp Personal Test Db Test Id

        public RxCPDiseaseTemplate RxCPDiseaseTemplate { get; set; }
       
    }
}
