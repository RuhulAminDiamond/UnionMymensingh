using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class JobCirculation
    {
        [Key]
        public int JCId { get; set; }
        public string CirculationNo { get; set; }
        public string CirculationTitle { get; set; }
    }
}
