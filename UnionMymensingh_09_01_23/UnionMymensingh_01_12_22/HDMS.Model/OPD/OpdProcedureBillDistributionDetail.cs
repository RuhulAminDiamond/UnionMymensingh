using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
  public  class OpdProcedureBillDistributionDetail
    {
        [Key]
        public long OPDDistributionDetailId { get; set; }
        [ForeignKey("OpdProcedureBillDistribution")]
        public int DisId { get; set; }
        public int ServiceHeadId { get; set; }
        public int DoctorId { get; set; }
        public double qnt { get; set; }
        public double Amount { get; set; }
        public OpdProcedureBillDistribution OpdProcedureBillDistribution { get; set; }
    }
}
