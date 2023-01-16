using HDMS.Model.Common;
using HDMS.Model.Hospital;
using HDMS.Model.HR;
using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting.VModel
{
    public class VMPhEndpointDataCarrier
    {
        public int SaleAccId { get; set; }
        public int ReceivableAccId { get; set; }
        public int StockAccId { get; set; }
        public int StockExpAccId { get; set; }
        public int CashAccId { get; set; }
        public int DiscountAccId { get; set; }
        public int IPDSaleAccountId { get; set; }
        public int OPDSaleAccountId { get; set; }
        public int OutletId { get; set; }
        public double SaleAmount { get; set; }
        public double CostAmount { get; set; }
        public double CashReceiveAmount { get; set; }
        public double CardOrMobileReceiveAmount { get; set; }
        public double ChangeCashAmount { get; set; }
        public double CashPaidAmount { get; set; }
        public int CashPayChannelId { get; set; }
        public int OthersPayChannelId { get; set; }
        public double CardOrMobilePaidAmount { get; set; }
        public double CardOrMobileServiceCharge { get; set; }
        public double DueAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double GrandTotal { get; set; }
        public string SaleOrIssueRemarks { get; set; }
        public string SaleOrReceiveNo { get; set; }
        public string PhIPDRemarks { get; set; }
        public string PhOPDRemarks { get; set; }
        public string BillingDept { get; set; }
        public bool IsIpdSale { get; set; }
        public bool IsStaffSale { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionBy { get; set; }
        public string IPDRequisitionDeliveryStatus { get; set; }
        public int InvoiceTypeTagVal { get; set; }
        public int PCId { get; set; }
        public string TransactionNo { get; set; }

        public HospitalPatientInfo HospitalPatientInfo { get; set; }
        public PhMemberInfo PhMemberInfo { get; set; }
        public HpMedicineRequisition hpMedicineRequisition { get; set; }
        public PhInvoiceType InvoiceType { get; set; }

    }
}
