using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Store
{
    public class SCMPRDetail
    {
        [Key]
        public long PRDId { get; set; }
        [ForeignKey("SCMPR")]
        public long PRId { get; set; }
        public int ProductId { get; set; }
        public double PRQty { get; set; }
        public double FinalApprovedQty { get; set; }
        public double Rate { get; set; }
        public SCMPR SCMPR { get; set; }
    }
}
