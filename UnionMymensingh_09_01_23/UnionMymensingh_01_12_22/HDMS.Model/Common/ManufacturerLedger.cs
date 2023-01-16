using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{

    public class ManufacturerLedger
    {
        public long Id { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public DateTime Trandate { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
    
}
