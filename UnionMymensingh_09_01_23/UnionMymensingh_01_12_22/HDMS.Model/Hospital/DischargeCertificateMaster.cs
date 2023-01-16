using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class DischargeCertificateMaster
    {
        [Key]
        public long DischargeId { get; set; }
        public long AdmissionId { get; set; }
        [ForeignKey("ReportConsultant")]
        public int RCId { get; set; }  // Medical Officer Id
        public DateTime DischareDate { get; set; }
        public string DischargeTime { get; set; }
        public string Remarks { get; set; }
        public string CertificateBy { get; set; }

        public  ReportConsultant ReportConsultant { get; set; }
    }
}
