using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpPatientAccomodationInfo
    {
        [Key]
        public long AccomId { get; set; }
        [ForeignKey("HospitalPatientInfo")]
        public long AdmissionId { get; set; }
        public DateTime AccomodateDate { get; set; }

        public string AccomodateTime { get; set; }
        public int CabinId { get; set; }

        public string Status { get; set; }

        public DateTime? ReleaseDate { get; set; } //Cabin Leave date

        public string ReleaseTime { get; set; }

        public string OperatorRemarks { get; set; }

        public string SoftwareRemarks { get; set; }

        public string OperateBy { get; set; }

        public string Modifiedby { get; set; }

        public DateTime? Modifiydate { get; set; }

        public string ModifyTime { get; set; }

        public string AllotType { get; set; }  //ExtrBed or Regular Bed

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
    }
}
