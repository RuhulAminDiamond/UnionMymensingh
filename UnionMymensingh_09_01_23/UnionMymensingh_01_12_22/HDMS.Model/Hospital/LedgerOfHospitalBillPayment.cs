using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class LedgerOfHospitalBillPayment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public DateTime TranDate { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string HCVSerialNo { get; set; }
    }
}
