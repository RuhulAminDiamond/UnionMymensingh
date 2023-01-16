using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Windows.Forms.UI.Controls;
using Models;
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
    public partial class frmPayToSupplier : Form
    {
        public frmPayToSupplier()
        {
            InitializeComponent();
        }

        private void txtSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Space)
            {
                HideAllDefaultHidden();
                //ctlSupplierSearch.Visible = true;
                //ctlSupplierSearch.LoadData("");
            }

            if (e.KeyChar == (char) Keys.Enter)
            {
                double _balance = 0;
                if (txtSupplier.Tag != null)
                {
                    _balance = 0; // new LedgerService().GetSupplierBanalce(((Supplier)txtSupplier.Tag).Supplierid);
                    txtBalanceTk.Text = _balance.ToString();
                }
               
                txtPaymentTk.Focus();

            }

        }

        private void HideAllDefaultHidden()
        {
            //ctlSupplierSearch.Visible = false;
        }

        private void frmPayToSupplier_Load(object sender, EventArgs e)
        {
           // ctlSupplierSearch.Location = new Point(txtSupplier.Location.X, txtSupplier.Location.Y + txtSupplier.Height);
            dtp.Value = DateTime.Now;
        }

        private void ctlSupplierSearch_ItemSelected(SearchResultListControl<SupplierInfo> sender, SupplierInfo item)
        {
            txtSupplier.Text = item.Name;
            txtSupplier.Tag = item;
            txtSupplier.Focus();
            sender.Visible = false;
        }

        private void txtPaymentTk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRemarks.Focus();

            }
        }

        private void ctlSupplierSearch_ItemSelected()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            double _prevBalance = 0;
            double _currentBalance = 0;
            double _paymentTk = 0;

            double.TryParse(txtBalanceTk.Text, out _prevBalance);
            double.TryParse(txtPaymentTk.Text, out _paymentTk);
            _currentBalance = _prevBalance - _paymentTk;

            if (txtSupplier.Tag!=null && _prevBalance > 0 && _paymentTk > 0)
            {
                List<SupplierLedger> _sLedgerList = new List<SupplierLedger>();


                SupplierLedger _Ledger = new SupplierLedger();
                _Ledger.SupplierId = ((SupplierInfo)txtSupplier.Tag).SupplierId;
                _Ledger.Trandate = DateTime.Now;
                _Ledger.Particulars = txtRemarks.Text;
                _Ledger.Debit = _paymentTk;
                _Ledger.Credit = 0;
                _Ledger.Balance = _currentBalance;

                _sLedgerList.Add(_Ledger);

               // new LedgerService().SaveSupplierLedgerTransactions(_sLedgerList);

                MessageBox.Show("Payment successfull.");
                txtSupplier.Tag = null;
                txtSupplier.Text = "";
                txtBalanceTk.Text = "";
                txtPaymentTk.Text = "";
                txtRemarks.Text = "";

            }
            else
            {
                MessageBox.Show("No transaction happend.");
            }
        }
    }
}
