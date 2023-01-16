using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class WardInfo
    {
        [Key]
        public int WardId { get; set; }
        public string Description { get; set; }
       

    }
}
