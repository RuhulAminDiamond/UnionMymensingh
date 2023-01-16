using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Location
{
    public  class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public string BN_Name { get; set; }
        [ForeignKey("Division")]
        public int DivisionId { get; set; }

        public Division Division { get; set; }
    }
}
