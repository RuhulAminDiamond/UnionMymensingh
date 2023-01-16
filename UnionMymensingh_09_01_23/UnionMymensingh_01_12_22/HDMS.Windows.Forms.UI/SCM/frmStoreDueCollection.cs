using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Enums;
using Services.POS;

namespace HDMS.Windows.Forms.UI.Store
{
    public partial class frmStoreDueCollection : Form
    {
        public frmStoreDueCollection()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStoreDueCollection_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();
            ctlSupplierSearch.Location = new Point(txtCustomer.Location.X, txtCustomer.Location.Y + txtCustomer.Height);
            ctlSupplierSearch.ItemSelected += ctlSupplierSearch_ItemSelected;
        }

        private void ctlSupplierSearch_ItemSelected(SearchResultListControl<SupplierInfo> sender, SupplierInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item;
            txtCustomer.Focus();
            sender.Visible = false;
        }

        private void HideAllDefaultHidden()
        {
            ctlSupplierSearch.Visible = false;
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
                List<SupplierLedger> _cLedgerList = new List<SupplierLedger>();


                SupplierLedger _Ledger = new SupplierLedger();
                _Ledger.SupplierId = ((SupplierInfo)txtCustomer.Tag).SupplierId;
                _Ledger.Trandate =Utils.GetServerDateAndTime();
                _Ledger.Particulars = txtRemarks.Text;
                _Ledger.Debit = _paymentTk;
                _Ledger.Credit = 0;
                _Ledger.Balance = _currentBalance;
               // _Ledger.TransactionType = TransactionTypeEnum.PhDueCollection.ToString();
               // _Ledger.IsImported = "N";
               // _Ledger.OperateBy = MainForm.LoggedinUser.Name;

                _cLedgerList.Add(_Ledger);

                new LedgerService().SaveSupplierLedgerTransactions(_cLedgerList);

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

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlSupplierSearch.Visible = true;
                ctlSupplierSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                double _balance = 0;
                if (txtCustomer.Tag != null)
                {
                    _balance = new LedgerService().GetSupplierBanalce(((SupplierInfo)txtCustomer.Tag).SupplierId);
                    txtBalanceTk.Text = _balance.ToString();
                }


                txtPaymentTk.Focus();

            }
        }
    }
}
