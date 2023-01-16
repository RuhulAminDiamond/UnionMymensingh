using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhOutletMedicinieRequisition
    {
        [Key]
        public long RequisitionId { get; set; }
        public DateTime ReqDate { get; set; }
        public string ReqTime { get; set; }
        public int FromOutletId { get; set; }
        public int ToOutletId { get; set; }
        public string RequisitionBy { get; set; }
        public string Status { get; set; }
    }
}
