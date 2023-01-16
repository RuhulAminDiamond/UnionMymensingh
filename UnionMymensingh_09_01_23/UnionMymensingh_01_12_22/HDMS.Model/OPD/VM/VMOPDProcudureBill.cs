using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD.VM
{
   public class VMOPDProcudureBill
    {
        public long BillNo { get; set; }
        public int ProcedureBillId { get; set; }
        public string FullName { get; set; }
        public double TotalBill { get; set; }
        public double TotalPaid { get; set; }
        public double TotalDue { get; set; }
        public double TotalDiscount { get; set; }
        public DateTime DischargeDate { get; set; }



    }
}
