using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class OPDServiceHead
    {

        [Key]
        public int ServiceHeadId { get; set; }

        [ForeignKey("OPDServiceSubGroup")]
        public int SubGroupId { get; set; }
        public int ServiceCode { get; set; }
        public string ServiceHeadName { get; set; }
        public double Rate { get; set; }
        public string Unit { get; set; }
        public bool Vat { get; set; }
        public bool ServiceCharge { get; set; }
        public bool DocVisit { get; set; }
        public bool Show { get; set; }
        public bool OpdShow { get; set; }

        public DateTime? CreateDate { get; set; }
        public string Createdby { get; set; }
        public string modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }

        public OPDServiceSubGroup OPDServiceSubGroup { get; set; }
    }
}
