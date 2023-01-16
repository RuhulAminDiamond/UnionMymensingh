using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMedicineRequisition
    {
        public long RequisitionId { get; set; }
        public long RequisitionNo { get; set; }
        public DateTime ReqDate { get; set; }
        public long AdmissionId { get; set; }

        public string CabinNo { get; set; }

        public string Floor { get; set; }
        public int OutletId { get; set; }
        public string RequisitionType { get; set; }
        public string RequisitionBy { get; set; }
        public string RequisitionStatus { get; set; }
        public string ItemStatus { get; set; }
    }
}
