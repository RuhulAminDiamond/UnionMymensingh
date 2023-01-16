using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class HpOPDBill
    {
        [Key]
        public long OPDBillId { get; set; }
        public DateTime BillDate { get; set; }
        public string BillTime { get; set; }
        public long PatientId { get; set; }
        public long BillNo { get; set; }
        public string PreparedBy { get; set; }
        public string BillType { get; set; }
        public string Remarks { get; set; }
    }
}
