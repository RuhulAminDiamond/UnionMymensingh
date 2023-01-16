using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Reports.Hospital;
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
    public partial class frmHpDueCollection : Form
    {
        public frmHpDueCollection()
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

                HospitalBill _hbill = new HpFinancialService().GetHospitalBillByBillNo(_pInfo.BillNo);

                cmdPrintReceipt.Tag = _hbill;


                List<VMHpFinalBill> finalBillItems = new HospitalService().GetHpPreviousBillDetails(_pInfo.BillNo);

                FillBillGrid(finalBillItems);

                LoadTransactionHistory(_pInfo.BillNo);
            }
        }

        private void LoadTransactionHistory(long _hbillNo)
        {
            HospitalBill _hbill = new HpFinancialService().GetHospitalBillByBillNo(_hbillNo);
            if (_hbill != null)
            {
                txtHBillNo.Tag = _hbill;
                List<HpPatientLedgerFinal> _hplFinal = new HpFinancialService().GetPatientLedgerFinalById(_hbill.HospitalBillId);
                gvLedger.AutoGenerateColumns = false;
                gvLedger.DataSource = _hplFinal;

                double _totalBill = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpTotalBiLL.ToString()).Sum(y => y.Debit);
                double _serviceCharge = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpServiceCharge.ToString()).Sum(y => y.Debit);

                double _cashPaidTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpPaidAmount.ToString()).Sum(y => y.Credit);
                double _cardPaidTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.PaymentbyCard.ToString()).Sum(y => y.Credit);
                double _mobPaidTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.PaymentbyMobileBanking.ToString()).Sum(y => y.Credit);


                double _discountTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpDiscount.ToString()).Sum(y => y.Credit);
                double _advanceTk = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpAdvance.ToString() || x.TransactionType == TransactionTypeEnum.AdvanceByCard.ToString()|| x.TransactionType == TransactionTypeEnum.AdvanceByMob.ToString()).Sum(y => y.Credit)- _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpAdvanceReturn.ToString()).Sum(y => y.Debit);
               
                double _prevduecollection = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.HpDueCollection.ToString()|| x.TransactionType == TransactionTypeEnum.DueCollectionByMobileBanking.ToString()|| x.TransactionType == TransactionTypeEnum.DueCollectionByCard.ToString()).Sum(y => y.Credit);
                //double _prevduecollectionbymobile = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.DueCollectionByMobileBanking.ToString()).Sum(y => y.Credit);
                //double _prevduecollectionbyCard = _hplFinal.Where(x => x.TransactionType == TransactionTypeEnum.DueCollectionByCard.ToString()).Sum(y => y.Credit);

                txtTotalBill.Text = _totalBill.ToString();
                txtServiceCharge.Text = _serviceCharge.ToString();

                double _PaidTk = _cashPaidTk + _cardPaidTk + _mobPaidTk+ _advanceTk+_prevduecollection;

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

            //CalculateBill(finalBillItems);
        }

        private void CalculateBill(List<VMHpFinalBill> _finalBillItems)
        {
            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            txtTotalBill.Text = _tDebit.ToString();

            double _total = 0;
            double.TryParse(_tDebit, out _total);

            //double _serviceCharge = (_total * 25) / 100;
            double _MedicineBill = _finalBillItems.Where(q => q.ServiceName.ToLower() == "medicine bill").Sum(x => x.Total);
            txtTotalBill.Tag = _MedicineBill;

            double _serviceCharge = 0;

            if (Configuration.ORG_CODE == "2")
            {
                _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100;
            }
            else
            {
                _serviceCharge = (_total * 25) / 100;
            }


            double _gtotal = _total + _serviceCharge;

            txtServiceCharge.Text = _serviceCharge.ToString();
          //  txtGtotal.Text = _gtotal.ToString();
            txtDue.Text = _gtotal.ToString();
        }

        private void txtPrevPaid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrevDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
           double _tDebit= Convert.ToDouble( gvLedger.Rows.Cast<DataGridViewRow>()
                             .Sum(t => Convert.ToInt32(t.Cells[2].Value)));

           double _tCredit = Convert.ToDouble( gvLedger.Rows.Cast<DataGridViewRow>()
                             .Sum(t => Convert.ToInt32(t.Cells[3].Value)));

            double _prevDue = _tDebit - _tCredit;

            double _paid = 0;
            double.TryParse(txtPaid.Text, out _paid);

            double _disc = 0;
            double.TryParse(txtDiscount.Text, out _disc);

            txtDue.Text = (_prevDue - (_disc+_paid)).ToString();
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
               

                HospitalBill _hbill = (HospitalBill)txtHBillNo.Tag;

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

                double balance = new HpFinancialService().GetHpPatientBalance(_hbill.HospitalBillId);

                List<HpPatientLedgerFinal> transactionList = new List<HpPatientLedgerFinal>();

                HpPatientLedgerFinal pLedger = new HpPatientLedgerFinal();

                if (discount > 0)
                {

                    balance = balance + discount;
                    pLedger = new HpPatientLedgerFinal();
                    pLedger.HospitalBillId = _hbill.HospitalBillId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = discount;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.HpDiscount.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.Remarks = txtRemarks.Text;
                    pLedger.PCId = 0;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }



                double paidTk = 0;
                double.TryParse(txtPaid.Text, out paidTk);

                if (paidTk > 0)
                {

                    balance = balance + paidTk;
                    pLedger = new HpPatientLedgerFinal();
                    pLedger.HospitalBillId = _hbill.HospitalBillId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Payment";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.HpDueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = 1;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }
                if (paidBymobile > 0)
                {

                    balance = balance + paidBymobile;
                    pLedger = new HpPatientLedgerFinal();
                    pLedger.HospitalBillId = _hbill.HospitalBillId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Payment(By Mobile Banking)";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidBymobile;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollectionByMobileBanking.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = _PCId;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }
                if ( paidByCard> 0)
                {

                    balance = balance + paidByCard;
                    pLedger = new HpPatientLedgerFinal();
                    pLedger.HospitalBillId = _hbill.HospitalBillId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Payment(By Card)";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidByCard;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollectionByCard.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = _PCId;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }



                if (transactionList.Count > 0)
                {
                    HpFinancialService fpService = new HpFinancialService();
                    fpService.SaveHpFinalLedger(transactionList);

                    MessageBox.Show("Transaction successful.");

                    txtHBillNo.Tag = null;
                    txtDiscount.Text = "";
                    txtPaid.Text = "";

                    long _hbillNo = 0;
                    long.TryParse(txtHBillNo.Text, out _hbillNo);

                    LoadTransactionHistory(_hbillNo);

                   
                }

              

            }else
            {
                MessageBox.Show("No transaction data found to commit.");
            }


            cmdSave.Enabled = true;
            cmdSave.Text = "Save";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrintReceipt_Click(object sender, EventArgs e)
        {
            if (cmdPrintReceipt.Tag != null)
            {
                HospitalBill _hbill = (HospitalBill)cmdPrintReceipt.Tag;
                ViewPrintView(_hbill, "", "");
            }
        }

        private void ViewPrintView(HospitalBill _hbill, string _billType, string _Cabin)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_hbill.BillNo);

            DataSet ds = new HpFinancialService().GetHpCashMemo(_hbill.HospitalBillId);


            rptHpBill _rptBill = new rptHpBill();
            _rptBill.SetDataSource(ds);

            List<HpPatientLedgerFinal> _pLedger = new HpFinancialService().GetPatientLedgerFinalById(_hbill.HospitalBillId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetHospitalCashMemotransaction(_pLedger);



            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _rptBill.SetParameterValue(p1, litem.Label);
                _rptBill.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rptBill.SetParameterValue(p3, "");
                }
                else
                {
                    if (litem.Value.ToString().ToLower().Contains('.'))
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString());
                    }
                    else
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString() + ".00");
                    }
                  
                }

                if (litem.IsDue)
                {
                    isDue = true;
                }

                if (litem.IsDicounted)
                {
                    isDiscounted = true;
                }



            }


            for (int _count = _index + 1; _count <= 8; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rptBill.SetParameterValue(p1, "");
                _rptBill.SetParameterValue(p2, "");
                _rptBill.SetParameterValue(p3, "");
            }


            _rptBill.SetParameterValue("CabinNo", _Cabin);
            _rptBill.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
            _rptBill.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());
            _rptBill.SetParameterValue("WaterMark", "Print mode: final_due_collection");

            if (isDue)
            {
                _rptBill.SetParameterValue("PayStatus", "DUE");
            }
            else
            {
                _rptBill.SetParameterValue("PayStatus", "PAID");
            }



            //Header & Footer Added

            _rptBill.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);

            if (Configuration.ORG_CODE == "1")
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote1);
                _rptBill.SetParameterValue("OrgLicenseNo", "License No:" + ComapnyDetail.MAH_NAY_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", "Reg. Code:" + ComapnyDetail.MAH_NAY_Hospital_RegCode);
            }
            else
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote2);
                _rptBill.SetParameterValue("OrgLicenseNo", ComapnyDetail.MAH_AKH_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", ComapnyDetail.MAH_AKH_Hospital_RegCode);
            }



            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptBill;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void frmHpDueCollection_Load(object sender, EventArgs e)
        {
            LoadPaymentModes();
        }

        private void LoadPaymentModes()
        {
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

        private void cmbPaymentChannel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCardOrMobileReceiveTk.Enabled)
                {
                    txtCardOrMobileReceiveTk.Focus();
                }
                else
                {
                    txtPaid.Focus();
                }
            }
        }

        private void txtCardorMobilePaymentChanged(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
