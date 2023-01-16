using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
  public  class OpdProcedureBillDistribution
    {
        [Key]
        public int DisId { get; set; }
        public long BillNo { get; set; }
        public int ProcedureBillId { get; set; }
        public DateTime DistributeDate { get; set; }
        public string DistributeTime { get; set; }
        public string PreparedBy { get; set; }


    }
}
