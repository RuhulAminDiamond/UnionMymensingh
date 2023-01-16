using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Vehicle
{
    public class CarAllotmentInfo
    {
        [Key]
        public int AllotmentId { get; set; }
        [ForeignKey("CarInfo")]
        public int CarId { get; set; }
        [ForeignKey("DriverInfo")]
        public int DriverId { get; set; }
        [ForeignKey("RoutingOrTripInfo")]
        public int RouteId { get; set; }
        public string Allotmentby { get; set; }
        public DateTime ADate { get; set; }
        public int Rent { get; set; }
        public CarInfo CarInfo { get; set; }
        public DriverInfo DriverInfo { get; set; }
        public RoutingOrTripInfo RoutingOrTripInfo { get; set; }
    }
}
