using HDMS.Model.OPD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class OPDServiceSubGroup
    {
        [Key]
        public int SubGroupId { get; set; }
        [ForeignKey("OPDServiceGroup")]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string SubGroupType { get; set; }

        public DateTime? CreateDate { get; set; }
        public string Createdby { get; set; }
        public string modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }

        public OPDServiceGroup OPDServiceGroup { get; set; }
    }
}
