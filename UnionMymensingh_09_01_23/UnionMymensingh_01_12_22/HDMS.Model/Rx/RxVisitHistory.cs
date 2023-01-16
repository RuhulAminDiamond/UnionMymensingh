using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxVisitHistory
    {
        [Key]
        public long RxVisitId { get; set; }
        public long RxPMId { get; set; } // Rx Patient Master Id
        public long RxIN { get; set; }
        public int CpId { get; set; }    // Chamber Practitioner Id
        public int PSrlNo { get; set; }  // Patient Serial No
        public int VisitNo { get; set; } 
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; }
        public string AgeYear { get; set; }
        public string AgeMonth { get; set; }
        public string AgeDay { get; set; }
        public bool IsServiceCompleted { get; set; }

    }
}
