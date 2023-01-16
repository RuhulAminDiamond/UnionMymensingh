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
    public class SCMPO
    {
        [Key]
        public long POId { get; set; }
        public DateTime PODate { get; set; }
        public long PONo { get; set; }
        [ForeignKey("SCMPR")]
        public long PRId { get; set; }
       
        public string POFor { get; set; }  //Dept
        public int POCreator { get; set; }  // User Id
        public int SupplierId { get; set; }
        public string POStatus { get; set; }

        public SCMPR SCMPR { get; set; }
    }
}
