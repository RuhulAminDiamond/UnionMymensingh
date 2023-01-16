using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Repository.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Pharmacy;
using System.Data;
using HDMS.Model.Common;
using HDMS.Model.HR;
using HDMS.Models.Pharmacy;
using HDMS.Model.Accounting.VModel;
using HDMS.Models.Pharmacy.ViewModels;

namespace HDMS.Service.Pharmacy
{
    public class PhFinancialService
    {
        public async Task<List<VMIndoorMedicineBill>> GetIndoorMedicineBillOfUndertreatedPatient(int _deptId)
        {
            return await new PhFinancialRepository().GetIndoorMedicineBillOfUndertreatedPatient(_deptId);
        }

        public void SavePhSaleLedger(PhSaleLedger pLedger)
        {
            new PhFinancialRepository().SavePhSaleLedger(pLedger);
        }

        public List<VMIndoorMedicineBill> GetIndoorMedicineBillOfUndertreatedPatientBySearchPrefix(string strCabin, string _type)
        {
            return new PhFinancialRepository().GetIndoorMedicineBillOfUndertreatedPatientBySearchPrefix(strCabin, _type);
        }

        public DataSet GetPurchaseStatement(DateTime dtpfrm, DateTime dtpto, int outLetId, int manufacId)
        {
            return new PhFinancialRepository().GetPurchaseStatement(dtpfrm, dtpto, outLetId, manufacId);
        }

        public double GetSupplierBanalce(int _SupplierId)
        {
            return new PhFinancialRepository().GetSupplierBalance(_SupplierId);
        }

        public bool SavePhMemberInfo(PhMemberInfo _memInfo)
        {
           return new PhFinancialRepository().SavePhMemberInfo(_memInfo);
        }

        public PhReceive GetPhReceiveByManufacturerId(int manufacturerId)
        {
            return new PhFinancialRepository().GetPhReceiveByManufacturerId(manufacturerId);
        }

        public double GetManuFactureLedger(int manufacturerId)
        {
            return new PhFinancialRepository().GetManuFactureLedger(manufacturerId);
        }

        public List<PhInvoice> GetReturnInvoices(long AdmissionBillNo)
        {
            return new PhFinancialRepository().GetReturnInvoices(AdmissionBillNo);
        }

        public IList<PhMemberInfo> GetAllMember()
        {
            return new PhFinancialRepository().GetAllMember();
        }

        public PhMemberInfo GetPhMemberByEmployeeId(long employeeId)
        {
            return new PhFinancialRepository().GetPhMemberByEmployeeId(employeeId);
        }

        public DataSet GetOrderStatement(DateTime dtpfrm, DateTime dtpto, Manufacturer manufacturer)
        {
            return new PhFinancialRepository().GetOrderStatement(dtpfrm, dtpto, manufacturer.ManufacturerId);
        }

        public double GetPhMemberLedgerBalance(int _memberId)
        {
            return new PhFinancialRepository().GetPhMemberLedgerBalance(_memberId);
        }

        public DataSet GetSupplierLedger(DateTime dtpfrm, DateTime dtpto, int manufacturerId)
        {
            return new PhFinancialRepository().GetSupplierLedger(dtpfrm, dtpto, manufacturerId);
        }

        public void SaveCustomerLedgerTransactions(List<PhMemberLedger> _cLedgerList)
        {
            new PhFinancialRepository().SaveCustomerLedgerTransactions(_cLedgerList);
        }

        public DataSet GetPhDueCollection(DateTime _dtpfrm, DateTime _dtpto, string _user)
        {
           return new PhFinancialRepository().GetPhDueCollection(_dtpfrm, _dtpto, _user);
        }

        public PhReceive GetPhReceiveById(long _ReceiveId)
        {
            return new PhFinancialRepository().GetPhReceiveById(_ReceiveId);
        }

        public DataSet GetPurchaseInvoice(long _ReceiveId)
        {
            return new PhFinancialRepository().GetPurchaseInvoice(_ReceiveId);
        }

        public DataSet GetPurchaseInvoicesBySupplier(DateTime dtpfrm, DateTime dtpto, int manufacturerId)
        {
            return new PhFinancialRepository().GetPurchaseInvoicesBySupplier(dtpfrm, dtpto, manufacturerId);
        }

        public void SavePhIPDSaleTransactionLedger(List<PhIPDSaleLedger> _ipdtransactionList)
        {
            new PhFinancialRepository().SavePhIPDSaleTransactionLedger(_ipdtransactionList);
        }

        public double GetPhIPDLedgerBalance(long admissionId)
        {
            return new PhFinancialRepository().GetPhIPDLedgerBalance(admissionId);
        }

        public bool SaveManufacturerLedger(ManufacturerLedger ledger)
        {
            return new PhFinancialRepository().SaveManufacturerLedger(ledger);
        }

        public void SavePhSaleLedgerList(List<PhSaleLedger> _saleLedgerList)
        {
            new PhFinancialRepository().SavePhSaleLedgerList(_saleLedgerList);
        }

        public DataSet GetOPDCustomerLedger(int memberId, DateTime _dtpfrm, DateTime _dtpto)
        {
            return new PhFinancialRepository().GetOPDCustomerLedger(memberId, _dtpfrm, _dtpto);
        }

        public void SavePhIPDSaleLedger(List<PhIPDSaleLedger> ipdtransactionList)
        {
            new PhFinancialRepository().SavePhIPDSaleLedger(ipdtransactionList);
        }

        public List<PhInvoice> GetPhInvoicesByAdmissionNo(long billNo)
        {
            return new PhFinancialRepository().GetPhInvoicesByAdmissionNo(billNo);
        }

        public List<PhIPDSaleLedger> GetIPDTransactions(long admissionId)
        {
            return new PhFinancialRepository().GetIPDTransactions(admissionId);
        }

        public void SavePhPurchaseSaleLedger(List<PhPurchaseLedger> transactionList)
        {
            new PhFinancialRepository().SavePhPurchaseSaleLedger(transactionList);
        }

        public List<PhSaleLedger> GetCurrenPhInvoiceLedger(long invoiceId)
        {
            return new PhFinancialRepository().GetCurrenPhInvoiceLedger(invoiceId);
        }

        public DataSet GetIndoorSaleLedger(long admissionId)
        {
            return new PhFinancialRepository().GetIndoorSaleLedger(admissionId);
        }

        public DataSet GetOPDCustomerProductDetails(DateTime dtfrm, DateTime dtto, int memberId)
        {
            return new PhFinancialRepository().GetOPDCustomerProductDetails(dtfrm, dtto, memberId);
        }

        public DataSet GetStorePurchaseInvoice(long _ReceiveId)
        {
            return new PhFinancialRepository().GetStorePurchaseInvoice(_ReceiveId);
        }

        public void SaveSupplierLedgerTransactions(List<PhSupplierLedger> _sLedgerList)
        {
            new PhFinancialRepository().SaveSupplierLedgerTransactions(_sLedgerList);
        }

        public void SavetempIpdReturnLedger(PhTemIPDReturnLadger obj)
        {
            new PhFinancialRepository().SavetempIpdReturnLedger(obj);
        }

        public PhTemIPDReturnLadger GetTempIPDLedger(long returnIndentId)
        {
            return new PhFinancialRepository().GetTempIPDLedger(returnIndentId);
        }

        public void UpdatePhtemIPDReturnLadger(PhTemIPDReturnLadger _tempLedger)
        {
            new PhFinancialRepository().UpdatePhtemIPDReturnLadger(_tempLedger);
        }

        public async Task<PhInvoice> SaveAndCommitNewSale(PhInvoice pi, List<PhInvoiceDetail> invDetailsList, VMPhEndpointDataCarrier voucherObj, bool IsIntegratedAccountInAction)
        {
           return await new PhFinancialRepository().SaveAndCommitNewSale(pi, invDetailsList, voucherObj, IsIntegratedAccountInAction);
        }

        public async Task<PhInvoice> SaveAndCommitOPDNewSale(PhInvoice pi, List<PhInvoiceDetail> invDetailsList, VMPhEndpointDataCarrier voucherObj, bool IsIntegratedAccountInAction)
        {
            return await new PhFinancialRepository().SaveAndCommitOPDNewSale(pi, invDetailsList, voucherObj, IsIntegratedAccountInAction);
        }

        public async Task<PhReceive> SaveNewPurchase(PhReceive rcv, List<PhSelectedProductsToSaleOrReceiveOrOrder> rDeatailsList, VMPhEndPointDataCarrierForStockEntry voucherObj, bool isIntegratedAccountInAction, double _discountInPercent, double _vatInPercents)
        {
            return await new PhFinancialRepository().SaveNewPurchase(rcv, rDeatailsList, voucherObj, isIntegratedAccountInAction, _discountInPercent, _vatInPercents);
        }

        public List<PhPurchaseLedger> GetPhPurchaseLedgerByReceiveId(long _receivedId)
        {
            return new PhFinancialRepository().GetPhPurchaseLedgerByReceiveId(_receivedId);
        }

        public List<PhSelectedProductsToSaleOrReceiveOrOrder> GetSockEntryInvoiceNo(long invoice)
        {
            return new PhFinancialRepository().GetSockEntryInvoiceNo(invoice);
        }
    }
}
