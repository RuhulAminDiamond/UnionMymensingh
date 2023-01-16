using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.ViewModel;
using Models.Accounting;
using HDMS.Model.ViewModel;
using HDMS.Repository.Accounting;
using System.Data;
using Models.Accounting.VModel;
using System.Data.Entity.Core.Metadata.Edm;
using HDMS.Model.Accounting;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.Users;

namespace HDMS.Service.Accounting
{
    public class AccountService
    {


        public bool AddNewAccountHead(AccountHead _sInfo)
        {
            return new AccountRepository().AddNewAccountHead(_sInfo);
        }

        public bool UpdateAccountHead(AccountHead _sInfo)
        {
            return new AccountRepository().UpdateAccountHead(_sInfo);
        }


        public IList<AccountHead> GetAllAccountHead()
        {
            return new AccountRepository().GetAllAccountHead();
        }

        public void AccumulateBalance(DateTime dtpfrm, DateTime dtpto)
        {
            new AccountRepository().AccumulateBalance(dtpfrm, dtpto);
        }

        public List<User> GetAccountsUsers()
        {
            return new AccountRepository().GetAccountsUsers();
        }

        public FiscalYear GetCurrentFiscalYear()
        {
            return new AccountRepository().GetCurrentFiscalYear();
        }

        public DataSet GetProfitAndLossSummary(DateTime dtpfrm, DateTime dtpto, DateTime dtpprevfrm, DateTime dtpprevto, int statementType)
        {
            return new AccountRepository().GetProfitAndLossSummary(dtpfrm, dtpto, dtpprevfrm, dtpprevto, statementType);
        }

        public DataSet GetReceivePaymentStatement(DateTime fromdate, DateTime todate, DateTime prevfromdate, DateTime prevtodate)
        {
            return new AccountRepository().GetReceivePaymentStatement(fromdate, todate, prevfromdate, prevtodate);
        }

        public DataSet GetGFLedger(DateTime fromdate, DateTime todate, int accId)
        {
            return new AccountRepository().GetGFLedger(fromdate, todate, accId);
        }

        public DataSet GetBKDLedger(DateTime fromdate, DateTime todate, int accId)
        {
            return new AccountRepository().GetBKDLedger(fromdate, todate, accId);
        }

        public DataSet GetAccCashBook(DateTime dtpfrm, DateTime dtpto)
        {
            return new AccountRepository().GetAccCashBook(dtpfrm, dtpto);
        }

        public IList<VMAccountHeads> GetAllAccountGroups()
        {
            return new AccountRepository().GetAllAccountGroups();
        }

        public DataSet GetVoucherStatement(DateTime datefrm, DateTime dateto, string voucherType, string drcr, string user)
        {
            return new AccountRepository().GetVoucherStatement(datefrm, dateto, voucherType, drcr, user);
        }

        public DataSet GetBalanceSheet(DateTime dtpfrm, DateTime dtpto, DateTime dtpprevfrm, DateTime dtpprevto, int statementType)
        {
            return new AccountRepository().GetBalanceSheet(dtpfrm, dtpto, dtpprevfrm, dtpprevto, statementType);
        }

        public List<AccOpeningBalance> GetOpeningBalances(int fYId)
        {
            return new AccountRepository().GetOpeningBalances(fYId);
        }

        public IList<AccountHead> GetAllNonPostingAccountHead()
        {
            return new AccountRepository().GetAllAccountHead().Where(x => x.IsPostingHead == false).ToList();
        }

        public void PopulateSelectedItemData(IList<SelectedAccountHeadToVoucher> _SelectedItems, VMAccountHeads accountHeadInfo, double amount, string remarks)
        {
            int accountHeadId;
            accountHeadId = accountHeadInfo.AccId;
            if (accountHeadInfo == null) return;
            // if (_SelectedItems.Any(x => x.AccountHeadID == accountHeadId)) return;

            _SelectedItems.Add(GetPreparedSelectedItemObject(accountHeadInfo, amount, remarks));
        }

        public DataSet GetTrialBalanceBasedOnSummaryHead(DateTime dtfrm, DateTime dtto, int IswithOpening)
        {
            return new AccountRepository().GetTrialBalanceBasedOnSummaryHead(dtfrm, dtto, IswithOpening);
        }

        public IList<VMAccountHeads> GetAllPostingAccountHeads()
        {
            return new AccountRepository().GetAllPostingAccountHeads();
        }

        public DataSet GetProfitAndLoss(DateTime dtpfrm, DateTime dtpto, DateTime _prevStartDate, DateTime _prevEndDate, int _statementType)
        {
            return new AccountRepository().GetProfitAndLoss(dtpfrm, dtpto, _prevStartDate, _prevEndDate, _statementType);
        }

        public VMPLBalance GetPLNetInc()
        {
            double _currentNetInc = new AccountRepository().GetCurrentNetIncome("Incomes");
            double _currentNetExp = new AccountRepository().GetCurrentNetIncome("Expenses");
            double _cNetInc = _currentNetInc - _currentNetExp;

            double _prevNetInc = new AccountRepository().GetPrevNetIncome("Incomes");
            double _prevNetExp = new AccountRepository().GetPrevNetIncome("Expenses");
            double _pNetInc = _prevNetInc - _prevNetExp;

            VMPLBalance _plB = new VMPLBalance();
            _plB.NetIncCurrent = _cNetInc;
            _plB.NetIncPrev = _pNetInc;

            return _plB;
        }

        private SelectedAccountHeadToVoucher GetPreparedSelectedItemObject(VMAccountHeads accountHeadInfo, double amount, string remarks)
        {
            SelectedAccountHeadToVoucher _sItem = new SelectedAccountHeadToVoucher();
            _sItem.AccountHeadID = accountHeadInfo.AccId;
            _sItem.AccountHeadName = accountHeadInfo.AccountHeadName;
            _sItem.Amount = amount;
            _sItem.Remarks = remarks;

            return _sItem;

        }

        public IList<AccountHead> GetAllAccountHeads()
        {
            return new AccountRepository().GetAllAccountHead();
        }

        public AccountHead GetAllHeadById(int accId)
        {
            return new AccountRepository().GetAllHeadById(accId);
        }

        public IList<AccountHead> GetAllBaseHead()
        {
            return new AccountRepository().GetAllBaseHead();
        }

        public AccountHead GetPostingAccountHeadById(int accountHeadID)
        {
            return new AccountRepository().GetPostingAccountHeadById(accountHeadID);
        }

        public DataSet GetLedger(DateTime fromdate, DateTime todate, int accountHeadID)
        {
            return new AccountRepository().GetLedger(fromdate, todate, accountHeadID);
        }

        public DataSet GetGFLedgerSummary(DateTime fromdate, DateTime todate, int accId)
        {
            return new AccountRepository().GetGFLedgerSummary(fromdate, todate, accId);
        }

        public DataSet GetTrialBalance(DateTime dtpfrm, DateTime dtpto, int IswithOpening)
        {
            return new AccountRepository().GetTrialBalance(dtpfrm, dtpto, IswithOpening);
        }

        public DataSet GetBKDLedgerSummary(DateTime fromdate, DateTime todate, int accId)
        {
            return new AccountRepository().GetBKDLedgerSummary(fromdate, todate, accId);
        }

        public DataSet GetBalanceSheet(DateTime dtpfrm, DateTime dtpto, DateTime _prevstartDate, DateTime _prevEndDate)
        {
            return new AccountRepository().GetBalanceSheet(dtpfrm, dtpto, _prevstartDate, _prevEndDate);

        }

        public bool SaveOpeningBalance(AccOpeningBalance opBalance)
        {
            return new AccountRepository().SaveOpeningBalance(opBalance);
        }

        public bool UpdateOpeningBalance(AccOpeningBalance opBalance)
        {
            return new AccountRepository().UpdateOpeningBalance(opBalance);
        }

        public DataSet GetJournalVoucher(long voucherID)
        {
            return new AccountRepository().GetJournalVoucher(voucherID);
        }

        public DataSet GetLedgerSummary(DateTime fromdate, DateTime todate, int accId)
        {
            return new AccountRepository().GetLedgerSummary(fromdate, todate, accId);
        }

        public Voucher GetVocherById(int _voucherId)
        {
            return new AccountRepository().GetVocherById(_voucherId);
        }

        public IList<VoucherDetail> GetVoucherDetails(long vMId)
        {
            return new AccountRepository().GetVoucherDetails(vMId);
        }

        public AccountHead GetAccountHeadByAccCode(long debitAccCode)
        {
            return new AccountRepository().GetAccountHeadByAccCode(debitAccCode);
        }

        public void SaveVoucherDetails(List<VoucherDetail> _rVoucherDetailList)
        {
            new AccountRepository().SaveVoucherDetails(_rVoucherDetailList);
        }

        public List<SelectedAccountHeadToVoucher> GetAccountListByVoucher(long vMId)
        {
            return new AccountRepository().GetAccountListByVoucher(vMId);
        }

        public List<SelectedAccountHeadToVoucher> GetCreditAccountListByVoucher(long vMId)
        {
            return new AccountRepository().GetCreditAccountListByVoucher(vMId);
        }

        public Voucher GetLatestPaymentVoucher()
        {
            return new AccountRepository().GetLatestPaymentVoucher();
        }

        public Voucher GetVoucherById(long _VMId)
        {
            return new AccountRepository().GetVoucherById(_VMId);
        }

        public VoucherDetail GetCreditHeadAgainstDebits(long vMId)
        {
            return new AccountRepository().GetCreditHeadAgainstDebits(vMId);
        }

        public List<SelectedAccountHeadToVoucher> GetDebitHeadList(long vMId)
        {
            return new AccountRepository().GetDebitHeadList(vMId);

        }

        public bool DeleteExistingVoucherDetails(long vMId)
        {
            return new AccountRepository().DeleteExistingVoucherDetails(vMId);
        }

        public List<VMAccountAutoImportLogs> GetAutoImportLogs(DateTime dtpfrm, DateTime dtpto)
        {
            return new AccountRepository().GetAutoImportLogs(dtpfrm, dtpto);
        }

        public Voucher GetLatestReceiptVoucher()
        {
            return new AccountRepository().GetLatestReceiptVoucher();
        }

        public VoucherDetail GetDebitHeadAgainstCredits(long vMId)
        {
            return new AccountRepository().GetDebitHeadAgainstCredits(vMId);
        }

        public IList<SelectedAccountHeadToVoucher> GetCreditHeadList(long vMId)
        {
            return new AccountRepository().GetCreditHeadList(vMId);
        }

        public void GenerateReceivableVoucher(int accHeadId, double dueTk, string accparticulars)
        {
            //throw new NotImplementedException();
        }

        public long GetLastSHAccCodeShareDivident()
        {
            return new AccountRepository().GetLastSHAccCodeShareDivident();
        }

        public long GetLastSHAccCodePaidUpCapital()
        {
            return new AccountRepository().GetLastSHAccCodePaidUpCapital();
        }

        public List<VMAutoImportedPostedVoucherDetail> GetImportedDataDetails(int aILogId)
        {
            return new AccountRepository().GetImportedDataDetails(aILogId);
        }

        public bool DeleteImportedResults(int aILogId)
        {
            return new AccountRepository().DeleteImportedResults(aILogId);
        }
    }
}
