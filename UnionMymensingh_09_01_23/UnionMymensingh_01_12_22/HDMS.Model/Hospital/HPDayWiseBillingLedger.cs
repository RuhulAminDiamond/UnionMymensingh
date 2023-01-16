using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
  public  class HPDayWiseBillingLedger
    {
       [Key]
        public long TranId { get; set; }
        public long BillNo { get; set; }
        public long DayWiseBillId { get; set; }
        public string Particulars { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public DateTime TDate { get; set; }
        public string TransactionTime { get; set; }
        public string OperateBy { get; set; }


    }
}
