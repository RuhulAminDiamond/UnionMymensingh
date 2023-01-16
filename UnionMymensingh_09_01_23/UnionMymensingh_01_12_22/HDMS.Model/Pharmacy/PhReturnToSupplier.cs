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
    public class PhReturnToSupplier
    {
        [Key]
        public long RetId { get; set; }
        public DateTime RetDate { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public string Remarks { get; set; }
        public string UserName { get; set; }
        public string ReturnClaim { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }



    public class PhSupplierReturnDetail
    {
        [Key]
        public long RetDId { get; set; }
        [ForeignKey("PhReturnToSupplier")]
        public long RetId { get; set; }
        public long LotNo  { get; set; }
        public int ProductId { get; set; }
        public double Rate { get; set; }
        public double  Qty { get; set; }

        public PhReturnToSupplier PhReturnToSupplier { get; set; }
    }


}
