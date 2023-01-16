using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxDrug
    {
        public int Id { get; set; }
        [ForeignKey("RxVisitHistory")]
        public long RxVisitId { get; set; }
        public int ProductId { get; set; } // Central Db Product Id
        public long CPPMId { get; set; } // CP Preferred Medicine Id
        public string BrandName { get; set; }
        public string dosage { get; set; }
        public string duration { get; set; }
        public int Qty { get; set; }
        public bool IsPickedFromPDb { get; set; }  // IsPickedFrom Personal Medicine Db , RxCpPrefferedMedicine
        public RxVisitHistory RxVisitHistory { get; set; }
        
    }
}
