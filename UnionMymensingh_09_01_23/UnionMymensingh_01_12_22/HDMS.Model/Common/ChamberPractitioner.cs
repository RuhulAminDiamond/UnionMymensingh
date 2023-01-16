using HDMS.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class ChamberPractitioner
    {
        [Key]
        public int CPId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        [ForeignKey("ChamberPractitionerSpeciality")]
        public int CPSId { get; set; }
        public int? Fsize1 { get; set; }
        public string DIdentityLine1 { get; set; }
        public int? Fsize2 { get; set; }
        public string DIdentityLine2 { get; set; }
        public int? Fsize3 { get; set; }
        public string DIdentityLine3 { get; set; }
        public int? Fsize4 { get; set; }
        public string DIdentityLine4 { get; set; }
        public int? Fsize5 { get; set; }
        public string DIdentityLine5 { get; set; }
        public int? Fsize6 { get; set; }
        public string DIdentityLine6 { get; set; }
        public int? Fsize7 { get; set; }
        public int CPUserId { get; set; }
       
        public string IsESignatureAllow { get; set; }
        public int PatientQuota { get; set; }  //Perday Patient
        public string Status { get; set; }
        public string PrcticeTimeFrom { get; set; }
        public string PrcticeTimeTo { get; set; }
        public byte[] ESignature { get; set; }
        public Doctor Doctor { get; set; }
        public ChamberPractitionerSpeciality ChamberPractitionerSpeciality { get; set; }
    }
}
