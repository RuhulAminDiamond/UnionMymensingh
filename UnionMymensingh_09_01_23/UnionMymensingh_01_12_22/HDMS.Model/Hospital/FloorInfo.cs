using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class FloorInfo
    {
        [Key]
        public int FloorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
