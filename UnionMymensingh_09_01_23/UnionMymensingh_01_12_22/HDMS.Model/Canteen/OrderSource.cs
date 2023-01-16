using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Canteen
{
    public class OrderSource
    {
        [Key]
        public int SourceId { get; set; }
        public string TableInfo { get; set; }
    }
}
