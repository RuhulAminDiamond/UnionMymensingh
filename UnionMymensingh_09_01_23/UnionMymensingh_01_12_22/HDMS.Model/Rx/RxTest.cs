using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxTest
    {
        public int Id { get; set; }
        [ForeignKey("RxVisitHistory")]
        public long RxVisitId { get; set; } // To check either they are Initial Test
        public int TestId { get; set; } // Central Db Test Id
        public long CPPTId { get; set; } // Personal Db Test Id
        public int discountInPercent { get; set; }
        public int discountGross { get; set; }
        public bool IsPickedFromPDb { get; set; } // IsPickedFrom Personal Medicine Db , RxCpPrefferedMedicine
        public RxVisitHistory RxVisitHistory { get; set; }
    }
}
