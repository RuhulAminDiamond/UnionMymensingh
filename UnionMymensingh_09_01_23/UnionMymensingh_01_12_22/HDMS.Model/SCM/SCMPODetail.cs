using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM
{
    public class SCMPODetail
    {
        [Key]
        public long PODId { get; set; }
        [ForeignKey("SCMPO")]
        public long POId { get; set; }
        public int ProductId { get; set; }
        public double POQty { get; set; }
        public double Rate { get; set; }

        public SCMPO SCMPO { get; set; }
    }
}
