using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Models.Pharmacy;
using HDMS.Model.Hospital;
using HDMS.Model.OPD;

namespace HDMS.Windows.Forms.UI.Classes
{
   public static class Helper
    {
       public static List<VMCashMemoTranactionList> GetCashMemotransaction(List<PatientLedger> _ledgerItem)
       {
           double _testCost = 0,_discount=0, _netPayable=0, tPaid=0,tRefund=0,tCancelled=0,_duetk=0,tDiscountAdjusted=0;
           
           List<VMCashMemoTranactionList> _lItem = new List<VMCashMemoTranactionList>();

           foreach (var ledger in _ledgerItem)
           {
               
                
               if (ledger.TransactionType == TransactionTypeEnum.TestCost.ToString())
               {
                   _testCost = _testCost + Math.Round(ledger.Debit,2);
                  
               }

               if (ledger.TransactionType == TransactionTypeEnum.DiscountOnRegularCollection.ToString())
               {
                   _discount = _discount+ Math.Round(ledger.Credit,2);
                  
               }

               if (ledger.TransactionType == TransactionTypeEnum.DiscountOnDueCollection.ToString())
               {
                   _discount = _discount + Math.Round(ledger.Credit,2);

               }

               if (ledger.TransactionType == TransactionTypeEnum.TestCancelledDiscountAdjustment.ToString())
               {
                   _discount = _discount - Math.Round(ledger.Debit,2);
                    tDiscountAdjusted = Math.Round(ledger.Debit,2);

               }

               if (ledger.TransactionType == TransactionTypeEnum.OnEntryPayment.ToString())
               {
                   tPaid = tPaid + Math.Round(ledger.Credit,2);
               }

               if (ledger.TransactionType == TransactionTypeEnum.DueCollection.ToString())
               {
                   tPaid = tPaid + Math.Round(ledger.Credit,2);
               }

               if (ledger.TransactionType == TransactionTypeEnum.TestCancelled.ToString())
               {
                   tCancelled = tCancelled + Math.Round(ledger.Credit,2);
               }

               if (ledger.TransactionType == TransactionTypeEnum.Refund.ToString())
               {
                   tRefund = tRefund + Math.Round(ledger.Debit,2);
               }


           }


           _duetk = _ledgerItem.Sum(item => item.Debit) - _ledgerItem.Sum(item => item.Credit);
           if (tRefund > 0) _duetk = 0;
           //if ((tCancelled > 0) && (tRefund == 0)) _duetk = _duetk - tCancelled;

           if (_testCost > 0)
           {
               VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
               _item.Label = "Total Tk.";
               _item.Value = _testCost;
               _item.IsDue = false;
               _item.IsDicounted = false;
               _lItem.Add(_item);
           }

           if (_discount > 0)
           {
               VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
               _item.Label = "Discount Tk.";
               _item.Value = _discount;
               _item.IsDue = false;
                _item.IsDicounted = true;
                _lItem.Add(_item);

                _item = new VMCashMemoTranactionList();
                _item.Label = "Net Payable";
                _item.Value = _testCost  - _discount;
                _item.IsDicounted = true;
                _item.IsDue = false;
                _lItem.Add(_item);
            }

           if (tCancelled > 0)
           {
               VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
               _item.Label = "Cancelled Tk.";
               _item.Value = tCancelled;
               _item.IsDue = false;
               _item.IsDicounted = false;
               _lItem.Add(_item);
           }

            //if (tRefund > 0)
            //{
            //    VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
            //    _item.Label = "Refund Tk.";
            //    _item.Value = tRefund;
            //    _item.IsDue = false;
            //    _lItem.Add(_item);
            //}


            if (tPaid > 0)
           {
               tPaid = tPaid - (tRefund+tDiscountAdjusted);
               VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
               _item.Label = "Paid Tk.";
               _item.Value = tPaid;
               _item.IsDue = false;
               _item.IsDicounted = false;
               _lItem.Add(_item);
           }

           if (_duetk > 0)
           {
               VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
               _item.Label = "Due Tk.";
               _item.Value = _duetk;
               _item.IsDue = true;
               _item.IsDicounted = false;
               _lItem.Add(_item);
           }
          

           return _lItem;
       }

        public static List<VMCashMemoTranactionList> GetPhCashMemoTransactionList(PhInvoice _pInvoice)
        {
            double _totalAmount = 0, _discount = 0, _netPayable = 0, tPaid = 0, tReceived = 0, tChanged = 0, _duetk = 0;

            List<VMCashMemoTranactionList> _lItem = new List<VMCashMemoTranactionList>();
             _totalAmount = _pInvoice.TotalTK;
             _discount = _pInvoice.DiscountTK;
              tReceived = _pInvoice.ReceivedTK;
             tChanged = _pInvoice.ChangeTK;
             _duetk= _pInvoice.DueTK;

            if (_totalAmount > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Total Amount";
                _item.Value = _totalAmount;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_discount > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Discount";
                _item.Value = _discount;
                _item.IsDue = false;
                _item.IsDicounted = true;
                _lItem.Add(_item);

                _item = new VMCashMemoTranactionList();
                _item.Label = "Net Payable";
                _item.Value = _totalAmount - _discount;
                _item.IsDicounted = true;
                _item.IsDue = false;
                _lItem.Add(_item);
            }

            if (tReceived > 0)
            {
                
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Receive Amount";
                _item.Value = tReceived;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (tChanged > 0)
            {

                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Change Amount";
                _item.Value = tChanged;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_duetk > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Due Amount";
                _item.Value = _duetk;
                _item.IsDue = true;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }


            return _lItem;

        }

        //Hospital Invoice Transaction List

        public static List<VMCashMemoTranactionList> GetHospitalCashMemotransaction(List<HpPatientLedgerFinal> _ledgerItem)
        {
            double _totalBill = 0, _ServiceCharge = 0, GrandTital=0,  _discount = 0, _netPayable = 0, _tAdvance=0, tPaid = 0, _duetk = 0;

            List<VMCashMemoTranactionList> _lItem = new List<VMCashMemoTranactionList>();

            foreach (var ledger in _ledgerItem)
            {


                if (ledger.TransactionType == TransactionTypeEnum.HpTotalBiLL.ToString())
                {
                    _totalBill = _totalBill + ledger.Debit;

                }

                if (ledger.TransactionType == TransactionTypeEnum.HpServiceCharge.ToString())
                {
                    _ServiceCharge = _ServiceCharge + ledger.Debit;

                }

                if (ledger.TransactionType == TransactionTypeEnum.HpDiscount.ToString())
                {
                    _discount = _discount + ledger.Credit;

                }

                if (ledger.TransactionType == TransactionTypeEnum.HpAdvance.ToString())
                {
                    _tAdvance = _tAdvance + ledger.Credit;
                }

                if (ledger.TransactionType == TransactionTypeEnum.HpPaidAmount.ToString())
                {
                    tPaid = tPaid + ledger.Credit;
                }

                if (ledger.TransactionType == TransactionTypeEnum.HpDueCollection.ToString())
                {
                    tPaid = tPaid + ledger.Credit;
                }

            }


            _duetk = _ledgerItem.Sum(item => item.Debit) - _ledgerItem.Sum(item => item.Credit);
         

            if (_totalBill > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Total Amnt.";
                _item.Value = _totalBill;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_ServiceCharge > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Service Charge";
                _item.Value = _ServiceCharge;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);

                _item = new VMCashMemoTranactionList();
                _item.Label = "Grand Total";
                _item.Value = _totalBill + _ServiceCharge;
                _item.IsDicounted = true;
                _item.IsDue = false;
                _lItem.Add(_item);
            }

            GrandTital = _totalBill + _ServiceCharge;

            if (_discount > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Discount Tk.";
                _item.Value = _discount;
                _item.IsDue = false;
                _item.IsDicounted = true;
                _lItem.Add(_item);

                _item = new VMCashMemoTranactionList();
                _item.Label = "Net Payable";
                _item.Value = GrandTital - _discount;
                _item.IsDicounted = true;
                _item.IsDue = false;
                _lItem.Add(_item);
            }


            if (_tAdvance > 0)
            {

                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Advance Tk.";
                _item.Value = _tAdvance;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (tPaid > 0)
            {
              
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Paid Amnt.";
                _item.Value = tPaid;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_duetk > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Due Amnt.";
                _item.Value = _duetk;
                _item.IsDue = true;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }


            return _lItem;
        }

        public static List<VMCashMemoTranactionList> GetHospitalRoughCashMemotransaction(List<HpPatientLedgerRough> _ledgerItem)
        {
            double _totalBill = 0, _ServiceCharge = 0, GrandTital = 0, _discount = 0, _netPayable = 0, _tAdvance = 0, tPaid = 0, _duetk = 0;

            List<VMCashMemoTranactionList> _lItem = new List<VMCashMemoTranactionList>();

            foreach (var ledger in _ledgerItem)
            {


                if (ledger.TransactionType == TransactionTypeEnum.HpTotalBiLL.ToString())
                {
                    _totalBill = _totalBill + ledger.Debit;

                }

                if (ledger.TransactionType == TransactionTypeEnum.HpServiceCharge.ToString())
                {
                    _ServiceCharge = _ServiceCharge + ledger.Debit;

                }

                if (ledger.TransactionType == TransactionTypeEnum.HpDiscount.ToString())
                {
                    _discount = _discount + ledger.Credit;

                }

                if (ledger.TransactionType == TransactionTypeEnum.HpAdvance.ToString())
                {
                    _tAdvance = _tAdvance + ledger.Credit;
                }

                if (ledger.TransactionType == TransactionTypeEnum.HpPaidAmount.ToString())
                {
                    tPaid = tPaid + ledger.Credit;
                }

                if (ledger.TransactionType == TransactionTypeEnum.HpDueCollection.ToString())
                {
                    tPaid = tPaid + ledger.Credit;
                }

            }


            _duetk = _ledgerItem.Sum(item => item.Debit) - _ledgerItem.Sum(item => item.Credit);


            if (_totalBill > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Total Amnt.";
                _item.Value = _totalBill;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_ServiceCharge > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Service Charge";
                _item.Value = _ServiceCharge;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);

                _item = new VMCashMemoTranactionList();
                _item.Label = "Grand Total";
                _item.Value = _totalBill + _ServiceCharge;
                _item.IsDicounted = true;
                _item.IsDue = false;
                _lItem.Add(_item);
            }

            GrandTital = _totalBill + _ServiceCharge;

            if (_discount > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Discount Tk.";
                _item.Value = _discount;
                _item.IsDue = false;
                _item.IsDicounted = true;
                _lItem.Add(_item);

                _item = new VMCashMemoTranactionList();
                _item.Label = "Net Payable";
                _item.Value = GrandTital - _discount;
                _item.IsDicounted = true;
                _item.IsDue = false;
                _lItem.Add(_item);
            }


            if (_tAdvance > 0)
            {

                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Advance Tk.";
                _item.Value = _tAdvance;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (tPaid > 0)
            {

                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Paid Amnt.";
                _item.Value = tPaid;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_duetk > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Due Amnt.";
                _item.Value = _duetk;
                _item.IsDue = true;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }


            return _lItem;
        }


        public static List<VMCashMemoTranactionList> GetOPDCashMemotransaction(List<OPDPatientLedger> _ledgerItem)
        {
            double _serviceCost = 0, _discount = 0, _netPayable = 0, tPaid = 0, tRefund = 0, tCancelled = 0, _duetk = 0, tDiscountAdjusted = 0;

            List<VMCashMemoTranactionList> _lItem = new List<VMCashMemoTranactionList>();

            foreach (var ledger in _ledgerItem)
            {


                if (ledger.TransactionType == TransactionTypeEnum.OPDServiceCost.ToString())
                {
                    _serviceCost = _serviceCost + Math.Round(ledger.Debit, 2);

                }

                if (ledger.TransactionType == TransactionTypeEnum.DiscountOnRegularCollection.ToString())
                {
                    _discount = _discount + Math.Round(ledger.Credit, 2);

                }

                if (ledger.TransactionType == TransactionTypeEnum.DiscountOnDueCollection.ToString())
                {
                    _discount = _discount + Math.Round(ledger.Credit, 2);

                }

                if (ledger.TransactionType == TransactionTypeEnum.TestCancelledDiscountAdjustment.ToString())
                {
                    _discount = _discount - Math.Round(ledger.Debit, 2);
                    tDiscountAdjusted = Math.Round(ledger.Debit, 2);

                }

                if (ledger.TransactionType == TransactionTypeEnum.OnEntryPayment.ToString())
                {
                    tPaid = tPaid + Math.Round(ledger.Credit, 2);
                }

                if (ledger.TransactionType == TransactionTypeEnum.DueCollection.ToString())
                {
                    tPaid = tPaid + Math.Round(ledger.Credit, 2);
                }

                if (ledger.TransactionType == TransactionTypeEnum.TestCancelled.ToString())
                {
                    tCancelled = tCancelled + Math.Round(ledger.Credit, 2);
                }

                if (ledger.TransactionType == TransactionTypeEnum.Refund.ToString())
                {
                    tRefund = tRefund + Math.Round(ledger.Debit, 2);
                }


            }


            _duetk = _ledgerItem.Sum(item => item.Debit) - _ledgerItem.Sum(item => item.Credit);
            if (tRefund > 0) _duetk = 0;
            //if ((tCancelled > 0) && (tRefund == 0)) _duetk = _duetk - tCancelled;

            if (_serviceCost > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Total Tk.";
                _item.Value = _serviceCost;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_discount > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Discount Tk.";
                _item.Value = _discount;
                _item.IsDue = false;
                _item.IsDicounted = true;
                _lItem.Add(_item);

                _item = new VMCashMemoTranactionList();
                _item.Label = "Net Payable";
                _item.Value = _serviceCost - _discount;
                _item.IsDicounted = true;
                _item.IsDue = false;
                _lItem.Add(_item);
            }

            if (tCancelled > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Cancelled Tk.";
                _item.Value = tCancelled;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            //if (tRefund > 0)
            //{
            //    VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
            //    _item.Label = "Refund Tk.";
            //    _item.Value = tRefund;
            //    _item.IsDue = false;
            //    _lItem.Add(_item);
            //}


            if (tPaid > 0)
            {
                tPaid = tPaid - (tRefund + tDiscountAdjusted);
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Paid Tk.";
                _item.Value = tPaid;
                _item.IsDue = false;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }

            if (_duetk > 0)
            {
                VMCashMemoTranactionList _item = new VMCashMemoTranactionList();
                _item.Label = "Due Tk.";
                _item.Value = _duetk;
                _item.IsDue = true;
                _item.IsDicounted = false;
                _lItem.Add(_item);
            }


            return _lItem;
        }

        public static string GetDiscountRemarks(List<PatientLedger> _pLedger)
        {
            string _remarks = string.Empty;
            double _regularDisc = _pLedger.Where(x => x.TransactionType.ToLower() == "discountonregularcollection").Sum(q => q.Credit);

            if (_regularDisc > 0)
            {
                List<PatientLedger> _pl = _pLedger.Where(x => x.TransactionType.ToLower() == "discountonregularcollection").ToList();
                foreach(var item in _pl)
                {
                    if (String.IsNullOrEmpty(_remarks))
                    {
                        _remarks = item.Remarks;
                    }
                    else
                    {
                        _remarks = _remarks+ ", "+ item.Remarks;
                    }
                  
                }
               
            }

            double _dueDisc = _pLedger.Where(x => x.TransactionType.ToLower() == "discountonduecollection").Sum(q => q.Credit);

            if (_dueDisc > 0)
            {
                PatientLedger _pl2 = _pLedger.Where(x => x.TransactionType.ToLower() == "discountonduecollection").FirstOrDefault();
                if (String.IsNullOrEmpty(_remarks))
                {
                    _remarks = _pl2.Remarks;

                }
                else
                {
                    _remarks =  _remarks + ", "+ _pl2.Remarks;
                }
            }

            return _remarks;
        }
    }
}
