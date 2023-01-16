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

namespace POS.Forms
{
    public partial class frmCantDueCollection : Form
    {
        public frmCantDueCollection()
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
        }

        private void CtlCustomerSearch_ItemSelected(SearchResultListControl<CantMemberInfo> sender, CantMemberInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item;
            txtCustomer.Focus();
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
                    _balance = new LedgerService().GetBanalce(((CantMemberInfo)txtCustomer.Tag).MemberId);
                    txtBalanceTk.Text = Math.Abs(_balance).ToString();
                }
                
                
                txtPaymentTk.Focus();

            }
        }

        private void HideAllDefaultHidden()
        {
            ctlCustomerSearch.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double _prevBalance = 0;
            double _currentBalance = 0;
            double _paymentTk = 0;

            double.TryParse(txtBalanceTk.Text, out _prevBalance);
            double.TryParse(txtPaymentTk.Text, out _paymentTk);
            _currentBalance = _prevBalance - _paymentTk;

            if (txtCustomer.Tag != null && _prevBalance > 0 && _paymentTk > 0)
            {
                List<CantMemberLedger> _cLedgerList = new List<CantMemberLedger>();


                CantMemberLedger _Ledger = new CantMemberLedger();
                _Ledger.CustomerId = ((CantMemberInfo)txtCustomer.Tag).MemberId;
                _Ledger.Trandate = DateTime.Now;
                _Ledger.Particulars = txtRemarks.Text;
                _Ledger.Debit = 0;
                _Ledger.Credit = _paymentTk;
                _Ledger.Balance = _currentBalance;
                _Ledger.TransactionType = TransactionTypeEnum.PhDueCollection.ToString();
                _Ledger.OperateBy = MainForm.LoggedinUser.Name;

                _cLedgerList.Add(_Ledger);

                new LedgerService().SaveCustomerLedgerTransactions(_cLedgerList);

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

        private void ctlCustomerSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCustomer.Focus();
            }
        }
    }
}
