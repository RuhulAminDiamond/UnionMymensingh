using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting.VModel
{
    public class VMDiagEndPointDataCapture
    {
        public int SaleAccId { get; set; }
        public int ReceivableAccId { get; set; }
        
        public int IPDCashAccId { get; set; }
        public int OPDCashAccId { get; set; }

        public int IPDDiscountAccId { get; set; }
        public int OPDDiscountAccId { get; set; }

        public int IPDSaleAccountId { get; set; }
        public int OPDSaleAccountId { get; set; }

        public double SaleAmount { get; set; }
        public double ReceiveCashAmount { get; set; }
        public double ChangeCashAmount { get; set; }
        public double CashPaidAmount { get; set; }
        public double DueAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double DrDiscountAmount { get; set; }
        public double GrandTotal { get; set; }
        public string SaleOrIssueRemarks { get; set; }
        public string IPDRemarks { get; set; }
        public string  OPDRemarks { get; set; }
        public bool IsIpdSale { get; set; }
        public bool IsStaffSale { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionBy { get; set; }
        public int MediaId { get; set; }

        public string testsConducted { get; set; }
        public string discountCardNo { get; set; }
        public string WorkStationId { get; set; }
        public string CareOf { get; set; }

        public int CashPayChannelId { get; set; }
        public int OthersPayChannelId { get; set; }
        public double CardPayment { get; set; }
        public double MobilePayment { get; set; }
        public double CardOrMobileServiceCharge { get; set; }
        public int PCId { get; set; }
        public string TransactionNo { get; set; }

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
        
    }
}
