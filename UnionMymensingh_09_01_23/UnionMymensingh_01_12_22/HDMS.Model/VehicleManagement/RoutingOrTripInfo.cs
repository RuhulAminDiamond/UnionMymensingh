using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Vehicle
{
    public class RoutingOrTripInfo
    {
        [Key]
        public int RouteId { get; set; }
        public string Destination { get; set; }
        public int Rent { get; set; }
    }
}
