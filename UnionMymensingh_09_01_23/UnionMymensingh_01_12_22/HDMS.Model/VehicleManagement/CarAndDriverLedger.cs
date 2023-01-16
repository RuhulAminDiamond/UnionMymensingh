using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Vehicle
{
    public class CarAndDriverLedger
    {
        [Key]
        public int TranId { get; set; }
        public DateTime TDate { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        public double balance { get; set; }
        [ForeignKey("CarInfo")]
        public int CarId { get; set; }
        [ForeignKey("DriverInfo")]
        public int DriverId { get; set; }
        public CarInfo CarInfo { get; set; }
        public DriverInfo DriverInfo { get; set; }

    }
}
