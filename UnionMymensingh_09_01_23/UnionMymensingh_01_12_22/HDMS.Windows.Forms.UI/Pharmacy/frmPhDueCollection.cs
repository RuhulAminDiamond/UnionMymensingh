using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Controls;
using Models;
using Models.Canteen;
using Services.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.HR;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using CrystalDecisions.Windows.Forms;

namespace POS.Forms
{
    public partial class frmPhDueCollection : Form
    {
        public frmPhDueCollection()
        {
            InitializeComponent();
        }

        private void ctlCustomerSearch_ItemSelected(SearchResultListControl<CantMemberInfo> sender, CantMemberInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item;
            txtCustomer.Focus();
            sender.Visible = false;
        }

        private void frmDueCollection_Load(object sender, EventArgs e)
        {
            ctlCustomerSearch.Location = new Point(txtCustomer.Location.X, txtCustomer.Location.Y + txtCustomer.Height);
            ctlCustomerSearch.ItemSelected += CtlCustomerSearch_ItemSelected;

            ctlEmployeeSearchControl.Location = new Point(txtEmployee.Location.X, txtEmployee.Location.Y);
            ctlEmployeeSearchControl.ItemSelected += ctlEmployeeSearchControl_ItemSelected;
        }

        private void ctlEmployeeSearchControl_ItemSelected(SearchResultListControl<VMEmployeeInfo> sender, VMEmployeeInfo item)
        {
            txtEmployee.Text = item.EmployeeName;
            txtEmployee.Tag = item;
            double _balance = 0;
            PhMemberInfo _memberInfo = new PhFinancialService().GetPhMemberByEmployeeId(item.EmployeeId);
            if (_memberInfo != null)
            {
                txtCustomer.Text = _memberInfo.Name;
                txtCustomer.Tag = _memberInfo;
                txtPaymentTk.Focus();


                _balance = new PhFinancialService().GetPhMemberLedgerBalance(((PhMemberInfo)txtCustomer.Tag).MemberId);
                txtBalanceTk.Text = Math.Abs(_balance).ToString();
                

                sender.Visible = false;
            }
            else
            {
                MessageBox.Show("Member entry not found against this employee.");
                txtCustomer.Text = "";
                txtCustomer.Tag = null;
                txtEmployee.Focus();
                sender.Visible = false;
                return;
            }

        }

        private void CtlCustomerSearch_ItemSelected(SearchResultListControl<PhMemberInfo> sender, PhMemberInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item;

            double _balance = 0;
            if (txtCustomer.Tag != null)
            {
                _balance = new PhFinancialService().GetPhMemberLedgerBalance(((PhMemberInfo)txtCustomer.Tag).MemberId);
                txtBalanceTk.Text = Math.Abs(_balance).ToString();
            }
            ////txtCustomer.Focus();
            sender.Visible = false;

        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlCustomerSearch.Visible = true;
                ctlCustomerSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                double _balance = 0;
                if (txtCustomer.Tag != null)
                {
                    _balance = new PhFinancialService().GetPhMemberLedgerBalance(((PhMemberInfo)txtCustomer.Tag).MemberId);
                    txtBalanceTk.Text = Math.Abs(_balance).ToString();
                }
                
                
                txtPaymentTk.Focus();

            }
        }

        private void HideAllDefaultHidden()
        {
            ctlCustomerSearch.Visible = false;
            ctlEmployeeSearchControl.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double _prevBalance = 0;
            double _currentBalance = 0;
            double _paymentTk = 0;

            double.TryParse(txtBalanceTk.Text, out _prevBalance);
            double.TryParse(txtPaymentTk.Text, out _paymentTk);
            _currentBalance = -(_prevBalance) + _paymentTk;

            if (txtCustomer.Tag != null && _prevBalance > 0 && _paymentTk > 0)
            {
                List<PhMemberLedger> _cLedgerList = new List<PhMemberLedger>();


                PhMemberLedger _Ledger = new PhMemberLedger();
                _Ledger.MemberId = ((PhMemberInfo)txtCustomer.Tag).MemberId;
                _Ledger.TranDate = Utils.GetServerDateAndTime();
                _Ledger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _Ledger.Particulars = txtRemarks.Text;
                _Ledger.Debit = 0;
                _Ledger.Credit = _paymentTk;
                _Ledger.Balance = _currentBalance;
                _Ledger.TransactionType = TransactionTypeEnum.PhDueCollection.ToString();
                _Ledger.OperateBy = MainForm.LoggedinUser.Name;

                _cLedgerList.Add(_Ledger);

                new PhFinancialService().SaveCustomerLedgerTransactions(_cLedgerList);

                CustomerCashMemo(((PhMemberInfo)txtCustomer.Tag).MemberId, dtp.Value);



                MessageBox.Show("Payment successfull.");
                txtCustomer.Tag = null;
                txtCustomer.Text = "";
                txtBalanceTk.Text = "";
                txtPaymentTk.Text = "";
                txtRemarks.Text = "";

            }
            else
            {
                MessageBox.Show("No transaction happend.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerCashMemo(long customerId , DateTime dateTime)
        {

            DataSet ds = new ReportingService().GetDueCollectionByCustomerId(customerId, dateTime);



       


            ReportViewer rv = new ReportViewer();
            rptOPDDueCollectionInvoice _rpt = new rptOPDDueCollectionInvoice();

            _rpt.SetDataSource(ds.Tables[0]);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();



        }


        private void ctlCustomerSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCustomer.Focus();
            }
        }

        private void txtEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlEmployeeSearchControl.Visible = true;
                ctlEmployeeSearchControl.LoadData();
            }
        }

        private void btnPrintCashmemo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomer.Text))
            {
                if (((PhMemberInfo)txtCustomer.Tag).MemberId > 0)
                {
                    CustomerCashMemo(((PhMemberInfo)txtCustomer.Tag).MemberId, dtp.Value);

                    return;
                }
            }
            MessageBox.Show("Place Select Customer Name");
        }
    }
}
