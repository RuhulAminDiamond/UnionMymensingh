using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Store
{
    public class SCMPR
    {
       [Key]
        public long PRId { get; set; }
        public DateTime PRDate { get; set; }
        public long PRNo { get; set; }
        public string PRFor { get; set; }  //Dept
        public int PRCreator { get; set; }  // User Id
        public bool PRApprovalStatus { get; set; }
        
        public string Note { get; set; }
        public string TearmCondition { get; set; }

        public string PRStatus { get; set; }
    }
}
