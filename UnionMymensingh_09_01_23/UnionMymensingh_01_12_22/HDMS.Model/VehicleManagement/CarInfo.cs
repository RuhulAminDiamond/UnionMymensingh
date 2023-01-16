using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Vehicle
{
   
    public class CarInfo
    {
        [Key]
        public int CarId { get; set; }
        public string ChasisNo { get; set; }
        public string EngineNo { get; set; }
        public string CarNo { get; set; }
        public string License { get; set; }
        public DateTime CommissionDate { get; set; }
        public string Condiotion { get; set; }
        public string Amenities { get; set; }
        public string CarType { get; set; }
        public string CStatus { get; set; }

    }
}
