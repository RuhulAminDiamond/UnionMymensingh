using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HDMS.Model.ViewModel;
using HDMS.Repository.Account;
using HDMS.Model.MiniAccount;
using System.Data;

namespace HDMS.Service.MiniAccounts
{
    public class MiniAccountService
    {
        public bool SaveAccountHead(MiniAccountHead _accHead)
        {
            return new MiniAccountRepository().SaveAccountHead(_accHead);
        }

        public List<MiniAccountHead> GetAccountHeadsByType(string _type)
        {
            return new MiniAccountRepository().GetAccountHeadsByType(_type);
        }

        public bool SaveExpense(Expense _exp)
        {
            return new MiniAccountRepository().SaveExpense(_exp);
        }

        public object GetAccountHeadObj(string _headName)
        {
            return new MiniAccountRepository().GetAccountHeadObj(_headName);
        }

        public List<VMExpense> GetAllExpensesByDate(DateTime _date, int _businessUnitId)
        {
            return new MiniAccountRepository().GetAllExpensesByDate(_date, _businessUnitId);
        }

        public Expense GetExpenseById(int _Id)
        {
            return new MiniAccountRepository().GetExpenseById(_Id);
        }

        public bool UpdateExpense(Expense _exp)
        {
            return new MiniAccountRepository().UpdateExpense(_exp);
        }

        public IList<MiniAccountHead> GetAllAccountHeads()
        {
            return new MiniAccountRepository().GetAllAccountHeads();
        }

        public void PopulateSelectedHead(IList<Model.ViewModel.SelectedAccountHead> _SelectedHeads, MiniAccountHead _selectedHead,double _amount, string drcr)
        {
            MiniAccountHead _accountHead = _selectedHead;
            //TestRepository repo = new TestRepository();
            //if (item == null || item.Id != testItemId)
            //{
            //    item = repo.GetTestItemsById(testItemId);
            //}

            //if (item == null) return;
            //TestGroup group = repo.GetGroupByType(TestGroupTypeEnum.Tube.ToString());
            //if (group != null && item.GroupId == group.Id)
            //{
            //    tubeTests.Add(GetPreparedSelectedTestObject(item, dtpDeliveryDate, deliveryTime, true));
            //    return;
            //}



            //_SelectedHeads.Add(GetPreparedSelectedTestObject(item, dtpDeliveryDate, deliveryTime, false));

        }

        private SelectedAccountHead GetPreparedSelectedTestObject(MiniAccountHead item, DateTime dtpDeliveryDate, string deliveryTime, bool isTube)
        {
            SelectedAccountHead _selectedHeads = new SelectedAccountHead();
            //_selectedHeads.AccountCode = item.Id;
            //_selectedHeads.HeadName = item.GroupId;
            //_selectedHeads.Amount = item.Name;
            //_selectedHeads.DrCr = item.Cost;
            

            return _selectedHeads;
        }


        public MiniAccountHead GetAccountHeadByAccountId(int _accId)
        {
            return new MiniAccountRepository().GetAccountHeadByAccountId(_accId);
        }


        public DataSet GetCashBookDiagDateWise(DateTime dtpfrm, DateTime dtpto, string checkPaymentState, string _userName, int businessUnitId)
        {
            return new MiniAccountRepository().GetCashBookDiagDateWise(dtpfrm, dtpto, checkPaymentState, _userName, businessUnitId);
        }

        public DataSet GetCashBookHosDateWise(DateTime dtpfrm, DateTime dtpto, string checkPaymentState, string _userName, int businessUnitId)
        {
            return new MiniAccountRepository().GetCashBookHosDateWise(dtpfrm, dtpto, checkPaymentState, _userName, businessUnitId);
        }

        public DataSet GetCashBookPharDateWise(DateTime dtpfrm, DateTime dtpto, string checkPaymentState, string _userName, int businessUnitId)
        {
            return new MiniAccountRepository().GetCashBookPharDateWise(dtpfrm, dtpto, checkPaymentState, _userName, businessUnitId);
        }

        public DataSet GetCashBook(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new MiniAccountRepository().GetCashBook(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetCashBookDiag(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new MiniAccountRepository().GetCashBookDiag(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetCashBookPhar(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new MiniAccountRepository().GetCashBookPhar(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetCashBookHos(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new MiniAccountRepository().GetCashBookHos(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public DataSet GetTotalExpense(DateTime dtpfrm, DateTime dtpto, int _mode)
        {
            return new MiniAccountRepository().GetTotalExpense(dtpfrm, dtpto, _mode);
        }

        public DataSet GetExpenseDetailsByHead(DateTime dateTime1, DateTime dateTime2, MiniAccountHead _accHead)
        {
            return new MiniAccountRepository().GetExpenseDetailsByHead(dateTime1, dateTime2, _accHead);
        }

        public int GetAccountHeadIdByMediaId(int mediaId)
        {
            return new MiniAccountRepository().GetAccountHeadIdByMediaId(mediaId);
        }
    }
}
