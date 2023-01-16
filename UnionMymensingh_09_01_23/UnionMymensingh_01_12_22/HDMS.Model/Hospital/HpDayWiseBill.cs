using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
  public  class HpDayWiseBill
    {
        [Key]
        public int DayWiseBillId { get; set; }
        public long BillNo { get; set; }
        public long DayBillNo { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime Billdatefrom { get; set; }
        public string BillTimefrom { get; set; }
        public DateTime Billdateto { get; set; }
        public string BillTimeTo { get; set; }
        public string BillTime { get; set; }
        public string PreparedBy { get; set; }
        public long AdmissionId { get; set; }
    }
}
