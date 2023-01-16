using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhProductGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
       
    }
}
