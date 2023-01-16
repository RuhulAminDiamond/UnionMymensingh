using HDMS.Model.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM
{
    public class SCMPRAppovalRecord
    {
       [Key]
        public long ApprvId { get; set; }
        [ForeignKey("SCMPR")]
        public long PRId { get; set; }
        public int ApprovebyUserId { get; set; }
        public DateTime ApprovalDate { get; set; }
     
        public SCMPR SCMPR { get; set; }
    }
}
