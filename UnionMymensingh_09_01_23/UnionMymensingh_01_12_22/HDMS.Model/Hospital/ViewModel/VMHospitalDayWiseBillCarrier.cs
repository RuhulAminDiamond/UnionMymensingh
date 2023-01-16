using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
   public class VMHospitalDayWiseBillCarrier
    {
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

        public int ServiceHeadId { get; set; }
        public double qnt { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string ServiceName { get; set; }

        public double SaleAmount { get; set; }
        public double ServiceCharge { get; set; }
        public double AdvancePaidAmount { get; set; }
        public double CashPaidAmount { get; set; }
        public double MobilePayment { get; set; }
        public double CardPayment { get; set; }
        public double VirtualPaymentCharge { get; set; }
        public double DueAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double GrandTotal { get; set; }
        public string SaleOrIssueRemarks { get; set; }


        public string Particulars { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public DateTime TDate { get; set; }
        public string TransactionTime { get; set; }
        public string OperateBy { get; set; }

        public HpDayWiseBill hdaybill { get; set; }
        public List<HpDayWiseBillDetail> hdaybilldetails { get; set; }

        public List<HpDayWiseBillDetail> hdayledger { get; set; }
        public List<HpPatientLedgerRough> pledgerRough { get; set; }

        public VMIPDInfo pInfo { get; set; }

    }
}
