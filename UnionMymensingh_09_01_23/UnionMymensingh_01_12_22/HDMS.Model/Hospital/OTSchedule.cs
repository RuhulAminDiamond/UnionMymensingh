using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class OTSchedule
    {
        [Key]
        public long OTId { get; set; }
         [ForeignKey("HospitalPatientInfo")]
        public long AdmissionId { get; set; }

        public DateTime OSDate { get; set; }
        public string OSTime { get; set; }
        public DateTime OEDate { get; set; }
        public string OETime { get; set; }
        public string OTName { get; set; }
        public long ChiefSurgeonId { get; set; }
        public string IndicationOfSurgery { get; set; }
        public string IncisionType { get; set; }
        public string AnaesthesiaType { get; set; }
        public string OTType { get; set; }
        public string OEStatus { get; set; }
        public string UserName { get; set; }

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
        public ICollection<OTExecutionDetail> OTExecutionDetails { get; set; }
    }
}
