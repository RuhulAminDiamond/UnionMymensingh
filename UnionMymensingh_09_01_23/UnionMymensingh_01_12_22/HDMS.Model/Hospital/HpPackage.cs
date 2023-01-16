using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpPackage
    {
        [Key]
        public int PkgId { get; set; }
        public string Name { get; set; }
        public double PkgTotal { get; set; }
    }
}
