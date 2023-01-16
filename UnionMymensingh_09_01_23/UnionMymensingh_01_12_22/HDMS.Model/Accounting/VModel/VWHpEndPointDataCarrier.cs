using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting.VModel
{
    public class VWHpEndPointDataCarrier
    {

        public int HpIPDSaleAccountId { get; set; }
        public int HpOPDOrEmergencySaleAccountId { get; set; }

        public int HpIPDDiscountAccId { get; set; }
        public int HpOPDOrEmergencyDiscountAccId { get; set; }

        public int HpIPDReceivableAccId { get; set; }
        public int HpOPDOrEmergencyReceivableAccId { get; set; }
        public int HpIPDCashAccId { get; set; }
        public int HpOPDOrEmergencyCashAccId { get; set; }

        public int HpIPDAdvanceAccountId { get; set; }
        public int HpOPDOrEmergencyAdvanceAccountId { get; set; }

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
       
        
        public bool IsStaffSale { get; set; }
        
        public string TransactionBy { get; set; }
        public int MediaId { get; set; }
        public string discountCardNo { get; set; }
        public string WorkStationId { get; set; }
        public int CashPayChannelId { get; set; }
        public int OthersPayChannelId { get; set; }
      
        public int PCId { get; set; }
        public string TransactionNo { get; set; }

        public string UserName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionTime { get; set; }
         public double AdmissionFee { get; set; }

        public HospitalBill hbill { get; set; }
        public List<HospitalBillDetail> hbilldetails { get; set; }

        public List<HpPatientLedgerFinal> pledgerfinal { get; set; }
        public List<HpPatientLedgerRough> pledgerRough { get; set; }

        public VMIPDInfo pInfo { get; set; }
       
    }
}
