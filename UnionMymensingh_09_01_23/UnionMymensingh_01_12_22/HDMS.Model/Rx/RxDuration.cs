using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxDuration
    {
        [Key]
        public int DurationId { get; set; }
        public string Name { get; set; }
        public bool IsBanglaFont { get; set; }
    }
}
