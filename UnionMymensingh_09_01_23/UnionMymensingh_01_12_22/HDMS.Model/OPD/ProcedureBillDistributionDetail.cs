using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class ProcedureBillDistributionDetail
    {
        public long Id { get; set; }
        [ForeignKey("OpdProcedureBillDistribution")]
        public long DisId { get; set; }
        public int ServiceHeadId { get; set; }
        public int DoctorId { get; set; }
        public double Amount { get; set; }
        public OpdProcedureBillDistribution OpdProcedureBillDistribution { get; set; }
    }
}
