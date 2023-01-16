using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhSubGroup
    {
        [Key]
        public int SubGroupId { get; set; }
        [ForeignKey("PhProductGroup")]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public virtual PhProductGroup PhProductGroup { get; set; }
       
    }
}
