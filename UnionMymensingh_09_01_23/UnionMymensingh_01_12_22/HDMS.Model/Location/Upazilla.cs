using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Location
{
    public class UpazilaOrArea
    {
       [Key]
        public int UpazilaId { get; set; }
        public string Name { get; set; }

        public string BN_Name { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }

        public District District { get; set; }
    }
}
