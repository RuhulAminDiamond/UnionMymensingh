using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Services.POS;
using Models.ViewModel;
using Models.Canteen;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Service.Common;

namespace POS.Forms
{
    public partial class ProductReceiveControl : UserControl
    {

        bool unlocked = true;
        public ProductReceiveControl()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgItems.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgItems.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlProductSearch.Visible = true;
                ctlProductSearch.LoadData();
            
            }


            else if (e.KeyChar == (char)Keys.Enter)
            {
                CantProductInfo _PInfo = new CantItemService().GetProductByCode(txtProduct.Text);
                if (_PInfo != null)
                {
                    txtProduct.Text = _PInfo.ProductCode;
                    txtProduct.Tag = _PInfo;
                    txtRate.Text = _PInfo.SaleRate.ToString();
                    txtQty.Focus();
                    txtProductName.Text = _PInfo.Name.ToString();

                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }
            else 
            {
                DisplayProductInformation();
            }
        }

        private void DisplayProductInformation()
        {
            CantProductInfo _PInfo = new CantItemService().GetProductByCode(txtProduct.Text);
            if (_PInfo != null)
            {
                txtProduct.Text = _PInfo.ProductCode;
                txtProduct.Tag = _PInfo;
                ////txtRate.Text = _PInfo.PurchaseRate.ToString();
                ////txtRate.Focus();
                txtProductName.Text = _PInfo.Name.ToString();

            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearch.Visible = false;
            ctlSupplierSearch.Visible = false;

        }

        private IList<CantSelectedProductsToSaleOrReceive> _SelectedItems;

        private void ProductReceiveControl_Load(object sender, EventArgs e)
        {
            ClearForm();

            _SelectedItems = new List<CantSelectedProductsToSaleOrReceive>();

            ctlProductSearch.Location = new Point(txtProduct.Location.X, txtProduct.Location.Y);
            ctlProductSearch.ItemSelected += CtlProductSearch_ItemSelected;
            ctlSupplierSearch.Location = new Point(txtSupplier.Location.X, txtSupplier.Location.Y + txtSupplier.Height);
            ctlSupplierSearch.ItemSelected += CtlSupplierSearch_ItemSelected;

            // txtProduct.GotFocus += new System.EventHandler(this.txtGotFocus);

            dtpRDate.Value = DateTime.Now;
            dtpSInvDate.Value = DateTime.Now;

           
        }

        private void CtlSupplierSearch_ItemSelected(SearchResultListControl<SupplierInfo> sender, SupplierInfo item)
        {
            txtSupplier.Text = item.Name;
            txtSupplier.Tag = item.SupplierId;
            txtSupInvoice.Focus();
            sender.Visible = false;
        }

        private void CtlProductSearch_ItemSelected(SearchResultListControl<CantProductInfo> sender, CantProductInfo item)
        {
            txtProduct.Text = item.ProductCode;
            txtProduct.Tag = item;
            txtProductName.Text = item.Name;
            txtRate.Text = item.SaleRate.ToString();
            txtQty.Focus();
            sender.Visible = false;
        }

        private void txtGotFocus(object sender, EventArgs e)
        {
            HideAllDefaultHidden();
            //ctlProductSearch.Visible = true;
           // ctlProductSearch.LoadData();
        }

       

     

        private void txtSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlSupplierSearch.Visible = true;
                ctlSupplierSearch.LoadData();


            }

        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                int _qty = 0;
                int.TryParse(txtQty.Text, out _qty);

                if (_qty == 0)
                {
                    MessageBox.Show("Quantity required."); return;
                }

                new CantItemService().PopulateSelectedItemData(_SelectedItems, txtProduct.Tag as CantProductInfo, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtQty.Text));
                FillItemGrid();

                txtRate.Text = "";
                txtQty.Text = "";
                txtProductName.Text = "";
                //txtProduct.Text = "";
                txtProduct.Focus();
            }
        }


        private void FillItemGrid()
        {

            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (CantSelectedProductsToSaleOrReceive item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.Code, item.Name,item.Qty,item.Unit,item.Rate,item.Total);
                dgItems.Rows.Add(row);
            }

           
            CalculateAmount();
            //dgTests.ResumeLayout();
        }

        private void CalculateAmount()
        {
            txtTotalTk.Text = dgItems.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToInt32(t.Cells[5].Value)).ToString();

            txtDiscount.Text = "0";
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (dgItems.Rows.Count > 0)
            {
                if (txtSupplier.Tag != null)
                {
                    double _totalTK = 0;
                    double _discountTk = 0;

                    double.TryParse(txtTotalTk.Text, out _totalTK);
                    double.TryParse(txtDiscount.Text, out _discountTk);

                    CantReceive _receive = new CantReceive();
                    _receive.RDate = dtpRDate.Value;
                    _receive.Particulars = "NR"; //NR-> New Receive
                    _receive.TotalTk = _totalTK;
                    _receive.DiscountTk = _discountTk;
                    _receive.SInvoiceDate = dtpSInvDate.Value;
                    _receive.SInvoiceNo = txtSupInvoice.Text;
                   
                    _receive.SupplerId = Convert.ToInt32(txtSupplier.Tag);

                    Int64 _ReceiveId = new CantItemService().SaveReceivedInvoice(_receive);

                    if (_ReceiveId > 0)
                    {
                        List<CantReceiveDetail> _rDeatailsList = new List<CantReceiveDetail>();
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            CantSelectedProductsToSaleOrReceive selectedTests = row.Tag as CantSelectedProductsToSaleOrReceive;
                            CantReceiveDetail _rDetails = new CantReceiveDetail();
                            _rDetails.ReceivedId = _ReceiveId;
                            _rDetails.ProductId = Convert.ToInt16(selectedTests.Id);
                            _rDetails.Qty = Convert.ToDouble(selectedTests.Qty);
                            _rDetails.PurchaseRate = Convert.ToDouble(selectedTests.Rate);
                            _rDetails.Total = Convert.ToDouble(selectedTests.Qty) *
                                              Convert.ToDouble(selectedTests.Rate);

                            _rDeatailsList.Add(_rDetails);

                        }

                        if (new CantItemService().SaveReceiveDetails(_rDeatailsList))
                        {
                            MessageBox.Show("Receive Successfull");

                            this.AdJustSupplierLedger(Convert.ToInt32(txtSupplier.Tag), _totalTK, _discountTk);
                            ClearForm();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Supplier not selected.");
                }

            }
            else
            {
                MessageBox.Show("Product not selected.");
            }

        }


        private void AdJustSupplierLedger(int _SupplierId, double _totalTK, double _discountTk)
        {
            double _balance = new SupplierService().GetSupplierBanalce(_SupplierId);

            List<SupplierLedger> _sLedgerList = new List<SupplierLedger>();

            _balance = _balance + _totalTK;
            SupplierLedger _Ledger = new SupplierLedger();
            _Ledger.SupplierId = _SupplierId;
            _Ledger.Trandate = DateTime.Now;
            _Ledger.Particulars = "Receive Invoice ";
            _Ledger.Debit = 0;
            _Ledger.Credit = _totalTK;
            _Ledger.Balance = _balance;

            _sLedgerList.Add(_Ledger);

            if (_discountTk > 0)
            {
                _balance = _balance - _discountTk;
                _Ledger = new SupplierLedger();
                _Ledger.SupplierId = _SupplierId;
                _Ledger.Trandate = DateTime.Now;
                _Ledger.Particulars = "Discount on Invoice ";
                _Ledger.Debit = _discountTk; 
                _Ledger.Credit = 0;
                _Ledger.Balance = _balance;
                _sLedgerList.Add(_Ledger);
            }




            new SupplierService().SaveSupplierLedgerTransactions(_sLedgerList);
        }


        private void ClearForm()
        {
            dgItems.Rows.Clear();
            txtTotalTk.Text = "";
            txtDiscount.Text = "";

            HideAllDefaultHidden();
         
        }


        private void txtSupChallan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpRDate.Focus();
            }
        }

       

        private void dgItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
           _SelectedItems.Remove(e.Row.Tag as CantSelectedProductsToSaleOrReceive);
            CalculateAmount();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtProduct.Text, out itemId))
            {

            }
            else
            {
                unlocked = false;

                if (unlocked)
                {
                    string _txt = txtProduct.Text;
                    HideAllDefaultHidden();
                    ctlProductSearch.Visible = true;
                    ctlProductSearch.txtSearch.Text = _txt;
                    ctlProductSearch.txtSearch.SelectionStart = ctlProductSearch.txtSearch.Text.Length;

                    ctlProductSearch.LoadData();
                }
            }
        }

        private void dtpRDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpSInvDate.Focus();
            }

        }

        private void dtpSInvDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtProduct.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void ctlProductSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProduct.Focus();
            }
        }

        private void ctlSupplierSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtSupplier.Focus();
            }
        }
    }
}
