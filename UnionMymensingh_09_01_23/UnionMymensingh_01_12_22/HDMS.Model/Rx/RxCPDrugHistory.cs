using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPDrugHistory
    {
        public long Id { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public string DrugHistory { get; set; }
        
        public ChamberPractitioner ChamberPractitioner { get; set; }
    }
}
