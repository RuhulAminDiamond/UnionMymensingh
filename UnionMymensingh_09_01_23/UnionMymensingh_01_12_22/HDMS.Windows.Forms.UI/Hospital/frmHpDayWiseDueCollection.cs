using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmHpDayWiseDueCollection : Form
    {
        public frmHpDayWiseDueCollection()
        {
            InitializeComponent();
        }

        private void txtHBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _hbillNo = 0;
                long.TryParse(txtHBillNo.Text, out _hbillNo);

                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_hbillNo);

                HpDayWiseBill _hDaybill = new HpFinancialService().GetHospitalDayWiseBillByBillNo(_hbillNo);
           
                cmdPrintReceipt.Tag = _hDaybill;

                List<VMHpFinalBill> finalBillItems = new HospitalService().GetHpDayWisePreviousBillDetails(_hbillNo);

               // List<VMHpFinalBill> finalBillItems = new HospitalService().GetHpPreviousBillDetails(_hbillNo);
                FillBillGrid(finalBillItems);

                LoadTransactionHistory(_hbillNo);
            }
        }

        private void LoadTransactionHistory(long _hbillNo)
        {
            HpDayWiseBill _hbill = new HpFinancialService().GetHpDayWisebillbyDaybillNo(_hbillNo);
            if (_hbill != null)
            {

                txtHBillNo.Tag = _hbill;

                List<HPDayWiseBillingLedger> _hplFinal = new HpFinancialService().GetPatientDayWiseLedgerFinalById(_hbill.DayWiseBillId);
                gvLedger.AutoGenerateColumns = false;
                gvLedger.DataSource = _hplFinal;

                double _totalBill = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpTotalBiLL.ToString()).Sum(y => y.Debit);
                double _serviceCharge = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpServiceCharge.ToString()).Sum(y => y.Debit);

                double _cashPaidTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpPaidAmount.ToString()).Sum(y => y.Credit);
                double _cardPaidTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.PaymentbyCard.ToString()).Sum(y => y.Credit);
                double _mobPaidTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.PaymentbyMobileBanking.ToString()).Sum(y => y.Credit);


                double _discountTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpDiscount.ToString()).Sum(y => y.Credit);
                double _advanceTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpAdvance.ToString() || x.TransactionType == TransactionTypeEnum.AdvanceByCard.ToString() || x.TransactionType == TransactionTypeEnum.AdvanceByMob.ToString()).Sum(y => y.Credit) - _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpAdvanceReturn.ToString()).Sum(y => y.Debit);

                double _prevduecollection = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpDueCollection.ToString() || x.TransactionType == TransactionTypeEnum.DueCollectionByMobileBanking.ToString() || x.TransactionType == TransactionTypeEnum.DueCollectionByCard.ToString()).Sum(y => y.Credit);
                

                txtTotalBill.Text = _totalBill.ToString();
                txtServiceCharge.Text = _serviceCharge.ToString();

                double _PaidTk = _cashPaidTk + _cardPaidTk + _mobPaidTk + _advanceTk + _prevduecollection;

                txtPrevPaid.Text = _PaidTk.ToString();
                txtPrevDiscount.Text = _discountTk.ToString();

                double _total = 0;
                double.TryParse(txtTotalBill.Text, out _total);

                double _service = 0;
                double.TryParse(txtServiceCharge.Text, out _service);

                double _paid = 0;
                double.TryParse(txtPrevPaid.Text, out _paid);

                double _disc = 0;
                double.TryParse(txtPrevDiscount.Text, out _disc);

                // _service = _service - _disc;
                // txtServiceCharge.Text = _service.ToString();

                double _gtotal = _total + _service;

                _gtotal = _gtotal - (_paid + _disc);

                txtDue.Text = _gtotal.ToString();

            }
        }

        private void FillBillGrid(List<VMHpFinalBill> finalBillItems)
        {
            dgLedger.SuspendLayout();
            dgLedger.Rows.Clear();
            foreach (VMHpFinalBill item in finalBillItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgLedger, item.SrlNo, item.ServiceName, item.Qty, item.Rate, item.Total);
                dgLedger.Rows.Add(row);
            }
        }

        private void frmHpDayWiseDueCollection_Load(object sender, EventArgs e)
        {
            LoadPaymentModes();
        }

        private async void LoadPaymentModes()
        {
            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfo();
            dgLedger.Tag = _lisPatientInfo;


            List<PaymentMode> _paymodes = new CommonService().GetPaymentModes();
            _paymodes.Insert(0, new PaymentMode() { PMId = 0, Name = "Select Mode" });
            cmbPaymentMode.DataSource = _paymodes;
            cmbPaymentMode.DisplayMember = "Name";
            cmbPaymentMode.ValueMember = "PMId";



            cmbPaymentMode.SelectedItem = _paymodes.Find(q => q.PMId == 1);
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentMode _pmode = cmbPaymentMode.SelectedItem as PaymentMode;
            if (_pmode != null)
            {
                List<PaymentChannel> _pChannelList = new CommonService().GetPaymentChannels(_pmode.PMId);
                _pChannelList.Insert(0, new PaymentChannel() { PCId = 0, Name = "Select Channel" });
                cmbPaymentChannel.DataSource = _pChannelList;
                cmbPaymentChannel.DisplayMember = "Name";
                cmbPaymentChannel.ValueMember = "PCId";

                if (_pmode.PMId == 1 || _pmode.PMId == 4 || _pmode.PMId == 5)
                {

                    cmbPaymentChannel.SelectedItem = _pChannelList.Find(q => q.PMId == _pmode.PMId);
                    txtTransactionNo.Enabled = false;
                    txtCardOrMobileReceiveTk.Enabled = false;
                }
                else
                {
                    txtTransactionNo.Enabled = true;
                    txtCardOrMobileReceiveTk.Enabled = true;
                }
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            double _tDebit = Convert.ToDouble(gvLedger.Rows.Cast<DataGridViewRow>()
                             .Sum(t => Convert.ToInt32(t.Cells[2].Value)));

            double _tCredit = Convert.ToDouble(gvLedger.Rows.Cast<DataGridViewRow>()
                              .Sum(t => Convert.ToInt32(t.Cells[3].Value)));

            double _prevDue = _tDebit - _tCredit;

            double _paid = 0;
            double.TryParse(txtPaid.Text, out _paid);

            double _disc = 0;
            double.TryParse(txtDiscount.Text, out _disc);

            txtDue.Text = (_prevDue - (_disc + _paid)).ToString();
        }

        private void txtCardOrMobileReceiveTk_TextChanged(object sender, EventArgs e)
        {
            double _tDebit = Convert.ToDouble(gvLedger.Rows.Cast<DataGridViewRow>()
                           .Sum(t => Convert.ToInt32(t.Cells[2].Value)));

            double _tCredit = Convert.ToDouble(gvLedger.Rows.Cast<DataGridViewRow>()
                              .Sum(t => Convert.ToInt32(t.Cells[3].Value)));

            double _prevDue = _tDebit - _tCredit;

            double _paid = 0;
            double.TryParse(txtCardOrMobileReceiveTk.Text, out _paid);

            double _disc = 0;
            double.TryParse(txtDiscount.Text, out _disc);

            txtDue.Text = (_prevDue - (_disc + _paid)).ToString();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            double _tDebit = Convert.ToDouble(gvLedger.Rows.Cast<DataGridViewRow>()
                             .Sum(t => Convert.ToInt32(t.Cells[2].Value)));

            double _tCredit = Convert.ToDouble(gvLedger.Rows.Cast<DataGridViewRow>()
                              .Sum(t => Convert.ToInt32(t.Cells[3].Value)));

            double _prevDue = _tDebit - _tCredit;

            double _paid = 0;
            double.TryParse(txtPaid.Text, out _paid);

            double _dueTk = 0;
            double.TryParse(txtDue.Text, out _dueTk);

            double _disc = 0;
            double.TryParse(txtDiscount.Text, out _disc);

            txtDue.Text = (_prevDue - (_disc + _paid)).ToString();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            cmdSave.Enabled = false;
            cmdSave.Text = "Plz. Wait..";

            if (txtHBillNo.Tag != null)
            {


                HpDayWiseBill _hbill = (HpDayWiseBill)txtHBillNo.Tag;

                double discount = 0;
                double.TryParse(txtDiscount.Text, out discount);

                double _paid = 0;
                double.TryParse(txtPaid.Text, out _paid);

                double _cardormobilepay = 0;
                double.TryParse(txtCardOrMobileReceiveTk.Text, out _cardormobilepay);
               
                int _pmodId = 0;
                PaymentMode _pMode = cmbPaymentMode.SelectedItem as PaymentMode;
                if (_pMode != null)
                {
                    _pmodId = _pMode.PMId;
                }


                int _PCId = 0;
                PaymentChannel _pChannel = cmbPaymentChannel.SelectedItem as PaymentChannel;
                if (_pChannel != null)
                {
                    _PCId = _pChannel.PCId;
                }
                double paidBymobile = 0;
                double paidByCard = 0;

                if (_pmodId == 3)
                {
                    double.TryParse(txtCardOrMobileReceiveTk.Text, out paidByCard);
                }
                else if (_pmodId == 2)
                {
                    double.TryParse(txtCardOrMobileReceiveTk.Text, out paidBymobile);
                }

                double balance = new HpFinancialService().GetHpDayWisePatientBalance(_hbill.DayWiseBillId);

                List<HPDayWiseBillingLedger> transactionList = new List<HPDayWiseBillingLedger>();

                HPDayWiseBillingLedger pLedger = new HPDayWiseBillingLedger();


                VMIPDInfo _lisPatientInfo = (VMIPDInfo)cmdSave.Tag;

                DateTime _tranDate = Utils.GetServerDateAndTime();
                string _tranTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");

                //if (discount > 0)
                //{

                //    balance = balance + discount;
                //    pLedger = new HpPatientLedgerFinal();
                //    pLedger.HospitalBillId = _hbill.HospitalBillId;
                //    pLedger.TranDate = Utils.GetServerDateAndTime();
                //    pLedger.Particulars = "Discount";
                //    pLedger.Debit = 0;
                //    pLedger.Credit = discount;
                //    pLedger.Balance = balance;
                //    pLedger.TransactionType = TransactionTypeEnum.HpDiscount.ToString();
                //    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                //    pLedger.Remarks = txtRemarks.Text;
                //    pLedger.PCId = 0;
                //    pLedger.TransactionNo = "";
                //    transactionList.Add(pLedger);
                //}

                double paidTk = 0;
                double.TryParse(txtPaid.Text, out paidTk);

                if (paidTk > 0)
                {

                    balance = balance - paidTk;
                    pLedger = new HPDayWiseBillingLedger();
                    pLedger.DayWiseBillId = _hbill.DayWiseBillId;
                    pLedger.TDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Payment";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.HpDueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);

                    HpAdvancePayment _advancePayment = new HpAdvancePayment();
                    _advancePayment.AdmissionId = _hbill.AdmissionId;
                    _advancePayment.PayDate = _tranDate;
                    _advancePayment.PayTime = _tranTime;
                    _advancePayment.Amount = paidTk;
                    _advancePayment.ReceievedBy = MainForm.LoggedinUser.Name;
                    _advancePayment.Remarks = "Advance Payment";
                    _advancePayment.TransactionTerminal = MainForm.WorkStationId;
                    _advancePayment.PCId = 0;
                    _advancePayment.TransactionNo = "";
                    _advancePayment.TransactionType = TransactionTypeEnum.HpAdvance.ToString();
                    new HpFinancialService().SaveAdvancePayment(_advancePayment);

                }
                if (paidBymobile > 0)
                {

                    balance = balance - paidBymobile;
                    pLedger = new HPDayWiseBillingLedger();
                    pLedger.DayWiseBillId = _hbill.DayWiseBillId;
                    pLedger.TDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Payment(By Mobile Banking)";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidBymobile;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollectionByMobileBanking.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }
                if (paidByCard > 0)
                {

                    balance = balance - paidByCard;
                    pLedger = new HPDayWiseBillingLedger();
                    pLedger.DayWiseBillId = _hbill.DayWiseBillId;
                    pLedger.TDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Payment(By Card)";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidByCard;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollectionByCard.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }

                if (transactionList.Count > 0)
                {
                    HpFinancialService fpService = new HpFinancialService();
                    fpService.SaveHpDayWiseFinalLedger(transactionList);

                    MessageBox.Show("Transaction successful.");

                    txtHBillNo.Tag = null;
                    txtDiscount.Text = "";
                    txtPaid.Text = "";

                    long _hbillNo = 0;
                    long.TryParse(txtHBillNo.Text, out _hbillNo);

                    LoadTransactionHistory(_hbillNo);

                }

            }
            else
            {
                MessageBox.Show("No transaction data found to commit.");
            }

            cmdSave.Enabled = true;
            cmdSave.Text = "Save";
        }
    }
}
