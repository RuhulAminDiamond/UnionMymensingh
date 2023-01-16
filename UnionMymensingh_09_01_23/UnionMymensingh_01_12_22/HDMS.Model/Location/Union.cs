using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Location
{
    public class Union
    {
        [Key]
        public int UnionId { get; set; }
        public string Name { get; set; }
        public string BN_Name { get; set; }
        [ForeignKey("Upazila")]
        public int UpazilaId { get; set; }
        public UpazilaOrArea Upazila { get; set; }
    } 
}
