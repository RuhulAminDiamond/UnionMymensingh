using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
   public class HpMedicineRequisition
    {
        [Key]
        public long RequisitionId { get; set; }
        public DateTime ReqDate { get; set; }
        public long AdmissionId { get; set; }
        public int OutletId { get; set; }
        public string RequisitionType { get; set; }
        public string RequisitionBy { get; set; }
        public string Status { get; set; }
    }
}
