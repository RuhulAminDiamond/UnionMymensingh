using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class OPDPatientVisitType
    {
        [Key]
        public int VisitTypeId { get; set; }
        public string VisitType { get; set; }
        public string VisitTypeCode { get; set; }
    }
}
