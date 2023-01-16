using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HDMS.Model.Marketing
{
    public class MediaCommissionGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public double DefaultValue { get; set; }
    }
}
