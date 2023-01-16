using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM
{
    public class SCMPRAppovalRecordDetail
    {
        public long Id { get; set; }
        [ForeignKey("SCMPRAppovalRecord")]
        public long ApprvId { get; set; }
        public int ProductId { get; set; }
        public double ApprovedQty { get; set; }
        public SCMPRAppovalRecord SCMPRAppovalRecord { get; set; }
    }
}
