using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class OpdProcedureBill
    {
        [Key]
       public long ProcedureBillId { get; set; }

        public DateTime BillDate { get; set; }
        public string Time { get; set; }
        public long AdmissionId { get; set; }
        public long BillNo { get; set; }
        public string PreparedBy { get; set; }
        public string BillTime { get; set; }
        public string Remarks { get; set; }
        public string BillType { get; set; }
        public bool isBillDistributed { get; set; } // Bill divided among stake holders like surgeons, nurses etc.

    }
}
