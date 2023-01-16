using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class DiagPatientLedgerViewModel
    {
        public DateTime Date { get; set; }
        public double TestAmount { get; set; }
        public double PaidAmount { get; set; }
        public double Balance { get; set; }
        public string Particulars { get; set; }

        public string OperateBy { get; set; }
    }
}
