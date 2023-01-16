using HDMS.Model.Hospital;
using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class OPDServiceCost
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("OPDPatientRecord")]
        public long PatientId { get; set; }
       
        public int ServiceOrConsultantId { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public double TAmount { get; set; }
        [ForeignKey("OPDServiceGroup")]
        public int GroupId { get; set; }
        public string Status { get; set; }
       
       

        public OPDPatientRecord OPDPatientRecord { get; set; }
        public OPDServiceGroup OPDServiceGroup { get; set; }
       
    }
}
