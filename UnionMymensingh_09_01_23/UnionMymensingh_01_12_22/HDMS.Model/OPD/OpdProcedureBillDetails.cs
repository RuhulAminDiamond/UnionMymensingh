using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class OpdProcedureBillDetails
    {


        [Key]
        public long OpdProcedureBillDetailId { get; set; }
        [ForeignKey("OpdProcedureBill")]
        public long ProcedureBillId { get; set; }
        public int ServiceHeadId { get; set; }
        public string ServiceName { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public double Total { get; set; }
        //public int DisplayOrder { get; set; }
        //public int DoctorId { get; set; }

        public OpdProcedureBill OpdProcedureBill { get; set; }
    }
}
