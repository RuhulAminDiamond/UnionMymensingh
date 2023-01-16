using HDMS.Model.Pharmacy;
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
    public class HpMedicineReturnIndentDetail
    {
        [Key]
        public long ReturnIndentDetailId { get; set; }

        [ForeignKey("PhInvoice")]
        public long InvoiceId { get; set; }

        [ForeignKey("HpMedicineReturnInednt")]
        public long ReturnIndentId { get; set; }

        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }

        [ForeignKey("PhLotInfo")]
        public long LotNo { get; set; }

        [ForeignKey("MedicineOutlet")]
        public int OutLetId { get; set; }

        public double SRate { get; set; }  // Sale Rate

        public double PRate { get; set; }  // Purchase Rate

        public double Qty { get; set; }

        public double TSaleAmount { get; set; }

        public PhInvoice PhInvoice { get; set; }

        public HpMedicineReturnInednt HpMedicineReturnInednt { get; set; }

        public PhProductInfo PhProductInfo { get; set; }

        public PhLotInfo PhLotInfo { get; set; }

        public MedicineOutlet MedicineOutlet { get; set; }
    }
}
