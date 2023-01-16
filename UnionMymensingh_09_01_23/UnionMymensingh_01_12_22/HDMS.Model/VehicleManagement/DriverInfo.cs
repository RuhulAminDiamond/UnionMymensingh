using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Vehicle
{
   
    public class DriverInfo
    {
        [Key]
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string License { get; set; }
        public string Qualification { get; set; }
        public string Remarks { get; set; }
        public string DStatus { get; set; }
        public DateTime Djoin { get; set; }

    }
}
