using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpPatientAccomodationType
    {
        [Key]
        public int AccomodationTypeId { get; set; }
        public string AccomodationType { get; set; }
        public int ServiceHeadId { get; set; }
    }
}
