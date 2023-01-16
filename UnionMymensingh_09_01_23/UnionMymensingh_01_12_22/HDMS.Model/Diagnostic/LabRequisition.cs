using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class LabRequisition
    {
        [Key]
        public long RequisitionId { get; set; }
        [ForeignKey("LabInfo")]
        public int LabId { get; set; }
        public DateTime RDate { get; set; }
        public string RTime { get; set; }
        public string OperateBy { get; set; }
        public string Status { get; set; }

        public LabInfo LabInfo { get; set; }
    }


    public class LabRequisitionDetail
    {
        [Key]
        public long RDId { get; set; }
        [ForeignKey("LabRequisition")]
        public long RequisitionId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }
       
        public LabRequisition LabRequisition { get; set; }
    }

}
