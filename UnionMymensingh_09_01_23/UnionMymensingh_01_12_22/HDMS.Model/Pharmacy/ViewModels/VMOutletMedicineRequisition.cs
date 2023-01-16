using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMOutletMedicineRequisition
    {
        public long RequisitionId { get; set; }
      
        public DateTime ReqDate { get; set; }
        public int FromOutletId { get; set; }
        public int ToOutletId { get; set; }
        public string FromOutlet { get; set; }
        public string ToOutlet { get; set; }
      
        public string RequisitionBy { get; set; }
        public string RequisitionStatus { get; set; }
        public string ItemStatus { get; set; }
    }
}
