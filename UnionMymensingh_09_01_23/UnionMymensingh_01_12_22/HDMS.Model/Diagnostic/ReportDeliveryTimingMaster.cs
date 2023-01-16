using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class ReportDeliveryTimingMaster
    {
        [Key]
        public int RDTMId { get; set; }
        public int TotalDeliverySlot { get; set; } // How many times in a day report will be delivered
        public int OrgCode { get; set; }
        public bool IsActiveNow { get; set; }
        public bool IsWeekendDeliverySchedule { get; set; }
        public string WeekEndStartTime { get; set; }
        public bool IsWeekEndStartTimeOnPrevDay { get; set; }
    }

    public class ReportDeliveryTimingDetail
    {
        public int Id { get; set; }
        [ForeignKey("ReportDeliveryTimingMaster")]
        public int RDTMId { get; set; }
        public string EntryTime { get; set; }
        public string DeliveryTime { get; set; }
       
        
        public ReportDeliveryTimingMaster ReportDeliveryTimingMaster { get; set; }
    }
}
