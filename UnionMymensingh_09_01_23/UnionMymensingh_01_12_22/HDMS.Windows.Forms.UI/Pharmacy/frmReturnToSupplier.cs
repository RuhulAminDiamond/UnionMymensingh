using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Service.Pharmacy;
using HDMS.Model.Pharmacy;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmReturnToSupplier : Form
    {
        bool unlocked = true;

        public frmReturnToSupplier()
        {
            InitializeComponent();
        }


        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private void frmReturnToSupplier_Load(object sender, EventArgs e)
        {
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            ctrlManufacturerSearchControl.Location = new Point(txtOrderTo.Location.X, txtOrderTo.Location.Y);
            ctrlManufacturerSearchControl.ItemSelected += ctrlManufacturerSearchControl_ItemSelected;

            ctlProductSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;

            dtpReturn.Value = DateTime.Now;

            LoadOutLets();

        }

        private void LoadOutLets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";
        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControlForPharmacy<VWPhProductListForSale> sender, VWPhProductListForSale item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.BrandName;
            txtUnitPrice.Text = item.PurchasePrice.ToString();
            txtQuantity.Focus();

            sender.Visible = false;
        }

        private void ctrlManufacturerSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtOrderTo.Text = item.Name;
            txtOrderTo.Tag = item;
            txtProductCode.Focus();
            sender.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtReturnTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void txtOrderTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlManufacturerSearchControl.Visible = true;
                ctrlManufacturerSearchControl.LoadData();

            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlManufacturerSearchControl.Visible = false;
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadDataByType(_txt + ">" + _outLet.OutLetId.ToString()); // Out let Id appended for outlet specific product loading
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _qty = 0, _rate = 0, _total = 0;
                double.TryParse(txtQuantity.Text, out _qty);
                double.TryParse(txtUnitPrice.Text, out _rate);


                new PhProductService().PopulateSelectedItemData(_SelectedItems, txtProductCode.Tag as VWPhProductListForSale, _rate, _qty);
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
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgProducts, item.Id, item.Name, item.Qty, item.PRate,item.Total);
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
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void btnReturnNow_Click(object sender, EventArgs e)
        {
            MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;
            if (_outLet.OutLetId != 2)
            {
                MessageBox.Show("Plz. select appropriate outlet."); return;
            }

            if (dgProducts.Rows.Count>0 && txtOrderTo.Tag != null)
            {

                PhReturnToSupplier _retToSupplier = new PhReturnToSupplier();
                _retToSupplier.RetDate = Utils.GetServerDateAndTime();
                _retToSupplier.ManufacturerId = ((Manufacturer)txtOrderTo.Tag).ManufacturerId;
                _retToSupplier.Remarks = txtRemarks.Text;
                _retToSupplier.UserName = MainForm.LoggedinUser.Name;
                _retToSupplier.ReturnClaim = "NotSettled";
                if (new PhProductService().SaveReturnToSupplier(_retToSupplier))
                {

                    List<PhSupplierReturnDetail> _retDetailsList = new List<PhSupplierReturnDetail>();
                    foreach (DataGridViewRow row in dgProducts.Rows)
                    {
                        PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                        PhSupplierReturnDetail pid = new PhSupplierReturnDetail();
                        pid.RetId = _retToSupplier.RetId;
                        pid.ProductId = selectedTests.Id;
                        pid.LotNo = selectedTests.LotNo;
                        pid.Qty = selectedTests.Qty;
                        pid.Rate = selectedTests.PRate;

                        _retDetailsList.Add(pid);
                    }
                    if (new PhProductService().AddSupplierReturnDetails(_retDetailsList))
                    {

                        new PhProductService().UpdateStockOnReturn(_retDetailsList, _outLet.OutLetId);

                        MessageBox.Show("Return successful.");

                        ClearFields();

                    }

                      
                }
            }
        }

        private void ClearFields()
        {
            dgProducts.Rows.Clear();
            txtRemarks.Text = "";
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            txtTotalAmount.Text = "";
        }

        private void ctlProductSearchControl_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }
    }
}
