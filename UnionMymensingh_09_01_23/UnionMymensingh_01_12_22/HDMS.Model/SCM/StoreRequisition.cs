using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Store
{
    public class StoreRequisition
    {
        [Key]
        public long RequisitionId { get; set; }
        [ForeignKey("StoreDept")]
        public int DeptId { get; set; }
        public DateTime RDate { get; set; }
        public string RTime { get; set; }
        public string OperateBy { get; set; }
        public string Status { get; set; }
        public bool IsApprovedbyDeptHead { get; set; }
        public string ApprovalStatuesbyDeptHead { get; set; }
        public string Comments { get; set; }
        public DateTime ApprovalDate { get; set; }

        public StoreDept StoreDept { get; set; }
    }


    public class StoreRequisitionDetail
    {
        [Key]
        public long RDId { get; set; }
        [ForeignKey("StoreRequisition")]
        public long RequisitionId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }

        public StoreRequisition StoreRequisition { get; set; }
    }
}

