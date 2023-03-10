using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpMedicineRequisitionDetail
    {
        [Key]
        public long ReqDetailId { get; set; }

        [ForeignKey("HpMedicineRequisition")]
        public long RequisitionId { get; set; }

        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }

        public double Qty { get; set; }

        public double DeliveredQty { get; set; }

        public string Status { get; set; }

        public string ReplaceRemarks { get; set; }

        public HpMedicineRequisition HpMedicineRequisition { get; set; }

        public PhProductInfo PhProductInfo { get; set; }
    }
}
