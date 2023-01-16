using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhProductLocation
    {
        [Key]
        public int LocId { get; set; }
        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }
        [ForeignKey("MedicineOutlet")]
        public int OutLetId { get; set; }
        public string RackNo { get; set; }
        public string BlockNo { get; set; }

        public PhProductInfo PhProductInfo { get; set; }
        public MedicineOutlet MedicineOutlet { get; set; }
    }
}
