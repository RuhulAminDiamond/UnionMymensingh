using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Enums
{
    public enum TransactionTypeEnum
    {
        TestCost,
        AdmissionFee,
        DiscountOnRegularCollection,
        DrDiscountOnRegularCollection,
        OPDPorcedurebill,
        OnEntryPayment,
        DueCollection,
        DueCollectionByCard,
        DueCollectionByMobileBanking,
        DiscountOnDueCollection,
        TestCancelled,
        Refund,
        TestCancelledDiscountAdjustment,
        DiscountRefunded,
        AddendumTestCost,
        HospitalBill,
        CashPaid,
        DiscountOnHospitalBill,
        PhProductCost,
        PhDiscount,
        PhPaidAmount,
        PhDuePayment,
        PaymentbyCard,
        PaymentbyMobileBanking,
        CardOrMobileServiceCharge,
        PhProductReturn,
        PhDueCollection,
        PhPreviousDueCollection,
        PhRefund,
        PhProductRefund,
        PhDiscountDiscountRefunded,
        HpAdmissionFee,
        MedicineBill,
        HpServiceBill,
        ConsultantFee,
        CabinCharge,
        HpPathologyBill,
        OTBiLL,
        RPC,  //Return Product Cost
        HpTotalBiLL,
        HpServiceCharge,
        HpDiscount,
        HpPaidAmount,   //
        HpAdvance,
        AdvanceByCard,
        AdvanceByMob,
        HpAdvanceReturn,
        HpDueCollection,
        OPDServiceCost,
        OPDServiceCharge,
        PhOrderCancel,
        HpOPDServiceBill,
        RoundingPlus,
        RoundingMinus,
        AdvancePaymentByCard,
        AdvancePaymentByMobileBanking,
        ServiceCancelled,
        ServiceCancelledDiscountAdjustment,
        DiscountOnMediaPaymentPluse,
        DiscountOnMediaPaymentMinus,
    }
}
