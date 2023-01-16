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
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using HDMS.Windows.Forms.UI;
using CrystalDecisions.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Model.Enums;
using HDMS.Service.Common;

namespace POS.Forms
{
    public partial class frmPhPayToSupplier : Form
    {
        public frmPhPayToSupplier()
        {
            InitializeComponent();
        }

        private void txtSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlManufacturerSearchControl.Visible = true;
                ctrlManufacturerSearchControl.LoadData();
            }

            if (e.KeyChar == (char) Keys.Enter)
            {
                double _balance = 0;
                if (txtSupplier.Tag != null)
                {
                    _balance =  new PhFinancialService().GetSupplierBanalce(((Manufacturer)txtSupplier.Tag).ManufacturerId);
                    txtBalanceTk.Text = _balance.ToString();
                }
               
                txtPaymentTk.Focus();

            }

        }

        private void HideAllDefaultHidden()
        {
            ctrlManufacturerSearchControl.Visible = false;
        }

        private void frmPayToSupplier_Load(object sender, EventArgs e)
        {
            ctrlManufacturerSearchControl.Location = new Point(txtSupplier.Location.X, txtSupplier.Location.Y+txtSupplier.Height);

      
            ctrlManufacturerSearchControl.ItemSelected += ctrlManufacturerSearchControl_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            dtp.Value = DateTime.Now;
        }

        private void ctrlManufacturerSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSupplier.Text = item.Name;
            txtSupplier.Tag = item;
          
            sender.Visible = false;

            txtSupplier.Focus();
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
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
            //Shohag 
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

                if (txtBillNo.Tag != null)
                {
                    PhReceive _receive = (PhReceive)txtBillNo.Tag;

                    List<PhPurchaseLedger> transactionList = new List<PhPurchaseLedger>();

                    PhPurchaseLedger pLedger = new PhPurchaseLedger();
                    pLedger.ReceiveId = _receive.ReceiveId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Paid Tk.";
                    pLedger.Debit = _paymentTk;
                    pLedger.Credit = 0;
                    pLedger.Balance = _currentBalance;
                    pLedger.TransactionType = TransactionTypeEnum.PhDuePayment.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);

                    if (transactionList.Count > 0)
                    {

                        new PhFinancialService().SavePhPurchaseSaleLedger(transactionList);
                    }


                    List<PhSupplierLedger> _sLedgerList = new List<PhSupplierLedger>();

                    double _sbalance = new PhFinancialService().GetSupplierBanalce(((Manufacturer)txtSupplier.Tag).ManufacturerId);

                    PhSupplierLedger _Ledger = new PhSupplierLedger();
                    _Ledger.ManufacturerId = ((Manufacturer)txtSupplier.Tag).ManufacturerId;
                    _Ledger.TranDate = Utils.GetServerDateAndTime();
                    _Ledger.Particulars = txtRemarks.Text;
                    _Ledger.Debit = _paymentTk;
                    _Ledger.Credit = 0;
                    _Ledger.TransactionType = TransactionTypeEnum.PhDuePayment.ToString();
                    _Ledger.Balance = (_sbalance- _paymentTk);
                    _Ledger.OperateBy = MainForm.LoggedinUser.Name;
                    _sLedgerList.Add(_Ledger);

                    new PhFinancialService().SaveSupplierLedgerTransactions(_sLedgerList);

                }
                else
                {

                    MessageBox.Show("Invoice No. Required.");

                    txtBillNo.Focus();

                    return;


                    //List<PhSupplierLedger> _sLedgerList = new List<PhSupplierLedger>();


                    //PhSupplierLedger _Ledger = new PhSupplierLedger();
                    //_Ledger.ManufacturerId = ((Manufacturer)txtSupplier.Tag).ManufacturerId;
                    //_Ledger.TranDate = Utils.GetServerDateAndTime();
                    //_Ledger.Particulars = txtRemarks.Text;
                    //_Ledger.Debit = _paymentTk;
                    //_Ledger.Credit = 0;
                    //_Ledger.TransactionType = TransactionTypeEnum.PhDuePayment.ToString();
                    //_Ledger.Balance = _currentBalance;
                    //_Ledger.OperateBy = MainForm.LoggedinUser.Name;
                    //_sLedgerList.Add(_Ledger);

                    //new PhFinancialService().SaveSupplierLedgerTransactions(_sLedgerList);
                }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLedger_Click(object sender, EventArgs e)
        {

           
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _receivedId = 0;
                long.TryParse(txtBillNo.Text, out _receivedId);

                if (_receivedId > 0)
                {
                    PhReceive _receive = new PhFinancialService().GetPhReceiveById(_receivedId);

                    if (_receive != null)
                    {

                        txtBillNo.Tag = _receive;

                        Manufacturer _manufacturer = new PhProductService().GetManufacturerById(_receive.SupplerId);

                        txtSupplier.Text = _manufacturer.Name;
                        txtSupplier.Tag = _manufacturer;

                        List<PhPurchaseLedger> _pList = new PhFinancialService().GetPhPurchaseLedgerByReceiveId(_receivedId);

                        double _balance = _pList.Sum(x => x.Credit - x.Debit);

                        txtBalanceTk.Text = _balance.ToString();

                        FillGridItem(_pList);
                    }

                }

            }
        }

        private void FillGridItem(List<PhPurchaseLedger> _ldList)
        {
            gvLedger.SuspendLayout();
            gvLedger.Rows.Clear();

            foreach (var item in _ldList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(gvLedger, item.TranDate.ToString("dd/MM/yyyy"), item.Debit, item.Credit, item.Balance, item.Particulars, item.OperateBy);

                gvLedger.Rows.Add(row);
            }
        }
    }
}
