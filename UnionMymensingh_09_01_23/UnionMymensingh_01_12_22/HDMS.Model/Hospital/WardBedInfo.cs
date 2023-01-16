using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class WardBedInfo
    {
        [Key]
        public int WardBedId { get; set; }
        [ForeignKey("WardInfo")]
        public int WardId { get; set; }
        public string Description { get; set; }

        public double Rent { get; set; }
        public bool IsBooked { get; set; }
        public WardInfo WardInfo { get; set; }

    }
}
