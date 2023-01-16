using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class RegUniqueKeyTracker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long RegNo { get; set; }
        public string GenerateBy { get; set; }
        public string GenerateFrom { get; set; }
        public string GenerateTime { get; set; }
        public int RegYear { get; set; }
        public int RegMonth { get; set; }
        public bool IsUsed { get; set; }
    }
}
