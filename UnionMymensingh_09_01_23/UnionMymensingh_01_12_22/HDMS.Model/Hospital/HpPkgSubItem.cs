using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpPkgSubItem
    {
        [Key]
        public int PkgSubItemId { get; set; }
        [ForeignKey("HpPackage")]
        public int PkgId { get; set; }
        [ForeignKey("ServiceHead")]
        public int ServiceId { get; set; }  // Id from Table ServiceHead
        public string Name { get; set; }
        public double Amount { get; set; }
        public HpPackage HpPackage { get; set; }
        public ServiceHead ServiceHead { get; set; }
    }
}
