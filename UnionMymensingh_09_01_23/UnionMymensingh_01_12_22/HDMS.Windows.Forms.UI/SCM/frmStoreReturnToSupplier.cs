using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Model.SCM;
using HDMS.Model.SCM.VWModel;
using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.SCM;
using Models.Store;
using Services.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.SCM
{
    public partial class frmStoreReturnToSupplier : Form
    {
        bool unlocked = true;


        public frmStoreReturnToSupplier()
        {
            InitializeComponent();
        }
        private IList<SelectedProductsToSaleOrReceive> _SelectedItems;
        private void frmStoreReturnToSupplier_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();

            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();


            ctlProductSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;

            ctlSupplierSearch.Location = new Point(txtOrderTo.Location.X, txtOrderTo.Location.Y + txtOrderTo.Height);
            ctlSupplierSearch.ItemSelected += CtlSupplierSearch_ItemSelected;
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearchControl.Visible = false;
            ctlSupplierSearch.Visible = false;
        }

        private void CtlSupplierSearch_ItemSelected(SearchResultListControl<SupplierInfo> sender, SupplierInfo item)
        {
            txtOrderTo.Text = item.Name;
            txtOrderTo.Tag = item;
            txtProductCode.Focus();
            sender.Visible = false;
        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControl<VWStoreProductList> sender, VWStoreProductList item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.Name;
            txtUnitPrice.Text = item.PurchaseRate.ToString();
            //txtSRate.Text = item.SaleRate.ToString();


            //if (item.IsExpireDateRequired)
            //{
           // txtBatchNo.Enabled = true;
           /// txtExpDate.Enabled = true;

            txtUnitPrice.Focus();

            //}
            //else
            //{
            //    txtBatchNo.Enabled = false;
            //    txtExpDate.Enabled = false;
            //    txtBatchNo.Text = "N/A";
            //    txtExpDate.Text = "24/04/2050";
            //    txtQty.Focus();

            //}

            sender.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOrderTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctlSupplierSearch.Visible = true;
                ctlSupplierSearch.LoadDataByType("Store");
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlProductSearchControl.Visible = true;
                ctlProductSearchControl.LoadData();

            }


            else if (e.KeyChar == (char)Keys.Enter)
            {
                StoreProductInfo _PInfo = new StoreItemService().GetProductByCode(txtProductCode.Text);
                if (_PInfo != null)
                {
                    txtProductCode.Text = _PInfo.ProductCode;
                    txtProductCode.Tag = _PInfo;
                    txtUnitPrice.Text = _PInfo.PurchaseRate.ToString();
                    txtUnitPrice.Focus();
                    txtDrescription.Text = _PInfo.Name.ToString();

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
            StoreProductInfo _PInfo = new StoreItemService().GetProductByCode(txtProductCode.Text);
            if (_PInfo != null)
            {
                txtProductCode.Text = _PInfo.ProductCode;
                txtProductCode.Tag = _PInfo;
                ////txtRate.Text = _PInfo.PurchaseRate.ToString();
                ////txtRate.Focus();
                txtDrescription.Text = _PInfo.Name.ToString();

            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtProductCode.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtProductCode.Text;
                    HideAllDefaultHidden();
                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadDataByType(_txt);
                }
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _qty = 0, _rate = 0, _total = 0;
                double.TryParse(txtQuantity.Text, out _qty);
                double.TryParse(txtUnitPrice.Text, out _rate);


                new StoreItemService().PopulateStoreSelectedItemData(_SelectedItems, txtProductCode.Tag as VWStoreProductList, _rate, _qty);
                FillItemGrid();

                txtUnitPrice.Text = "";
                txtQuantity.Text = "";
                txtDrescription.Text = "";
                txtProductCode.Text = "";
                txtProductCode.Focus();
            }
        }

        private void FillItemGrid()
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (SelectedProductsToSaleOrReceive item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgProducts, item.ProductId, item.Name, item.Qty, item.Rate, item.Total);
                dgProducts.Rows.Add(row);
            }
            CalculateItem();
        }

        private void CalculateItem()
        {
            txtTotalAmount.Text = dgProducts.Rows.Cast<DataGridViewRow>()
                 .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();
        }

        private void ctlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if(IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void btnReturnNow_Click(object sender, EventArgs e)
        {
            if (dgProducts.Rows.Count > 0 && txtOrderTo.Tag != null)
            {

                StoreReturnToSupplier _retToSupplier = new StoreReturnToSupplier();
                _retToSupplier.RetDate = Utils.GetServerDateAndTime();
                _retToSupplier.SupplierId = ((SupplierInfo)txtOrderTo.Tag).SupplierId;
                _retToSupplier.Remarks = txtRemarks.Text;
                _retToSupplier.UserName = MainForm.LoggedinUser.Name;
                _retToSupplier.ReturnClaim = "NotSettled";
                if (new StoreItemService().SaveStoreReturnToSupplier(_retToSupplier))
                {

                    List<StoreReturnProductDetil> _retDetailsList = new List<StoreReturnProductDetil>();
                    foreach (DataGridViewRow row in dgProducts.Rows)
                    {
                        SelectedProductsToSaleOrReceive selectedTests = row.Tag as SelectedProductsToSaleOrReceive;

                        StoreReturnProductDetil pid = new StoreReturnProductDetil();
                        pid.RetId = _retToSupplier.RetId;
                        pid.ProductId = selectedTests.ProductId;
                        pid.LotNo = selectedTests.LotNo;
                        pid.Qty = selectedTests.Qty;
                        pid.Rate = selectedTests.Rate;
                        pid.Total = Convert.ToDouble(selectedTests.Qty) *
                                             Convert.ToDouble(selectedTests.Rate);

                        _retDetailsList.Add(pid);

                        
                    }
                    if (new StoreItemService().AddStoreSupplierReturnDetails(_retDetailsList))
                    {

                        new StoreItemService().UpdateStoreStockOnReturnToSupplier(_retDetailsList);

                        MessageBox.Show("Return successful.");


                        PrintInvoice(_retToSupplier.RetId);
                        ClearFields();

                    }


                }
            }
        }

        private void PrintInvoice(long _ReturnId)
        {
            double _total = 0;
            double _discount = 0;
            double _gtotal = 0;

            double.TryParse(txtTotalAmount.Text, out _total);
            //double.TryParse(txtDiscount.Text, out _discount);

            _gtotal = _total - _discount;


            rptStoreReturnMemo _rpt = new rptStoreReturnMemo();


            DataSet ds = new StoreItemService().GetStoreReturnInvoice(_ReturnId);

            _rpt.SetDataSource(ds.Tables[0]);




            //_rpt.SetParameterValue("discount", txtDiscount.Text);
           // _rpt.SetParameterValue("vat", "0");
            _rpt.SetParameterValue("gtotal", _gtotal.ToString());

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ClearFields()
        {
            dgProducts.Rows.Clear();
            txtRemarks.Text = "";
            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();
            txtTotalAmount.Text = "";
        }

        private void ctlSupplierSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtOrderTo.Focus();
            }
        }
    }
}
