using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class DischargeCertificateTemplateBased
    {
        [Key]
        public long DId { get; set; }
        public long BillNo { get; set; }
        public string CabinNo { get; set; }
        public int RCId { get; set; }  // Consultant RCId from ReportConsultants , Medical Officer for Discharge
        public DateTime DCPrintDate { get; set; } // Discharge Certificate Print Date
        public string DCPrintTime { get; set; } // Discharge Certificate Print Date
        public byte[] DCContent { get; set; } // Discharge Certificate Content

    }
}
