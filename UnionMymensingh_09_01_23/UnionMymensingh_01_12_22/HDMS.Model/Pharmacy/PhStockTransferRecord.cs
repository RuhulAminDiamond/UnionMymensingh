using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhStockTransferRecord
    {
        [Key]
        public long StTId { get; set; }
        public DateTime TDate { get; set; }
        public string TTime { get; set; }
        public int FromOutLet { get; set; }
        public int ToOutLet { get; set; }
        public long RequisitionNo { get; set; }
        public string OperateBy { get; set; }
    }
}
