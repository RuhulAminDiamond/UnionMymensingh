using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Pharmacy;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmStockAdjust : Form
    {
        public frmStockAdjust()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {

            foreach (DataGridViewColumn c in dgProducts.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgProducts.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

        }

        private void frmStockAdjust_Load(object sender, EventArgs e)
        {
            ctrlManufacturerSearchControl.Location = new Point(txtManufacturer.Location.X, txtManufacturer.Location.Y);
            ctrlManufacturerSearchControl.ItemSelected += ctrlManufacturerSearchControl_ItemSelected;


            LoadOutlets();

            List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByBrandName("",2);
            FillListGrid(_prdList);
        }

        private void LoadOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";

        }
        private void ctrlManufacturerSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtManufacturer.Text = item.Name;
            txtManufacturer.Tag = item;
            txtManufacturer.Focus();
            sender.Visible = false;
        }

        private void txtManufacturer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlManufacturerSearchControl.Visible = true;
                ctrlManufacturerSearchControl.LoadData();

            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if(txtManufacturer.Tag != null)
                {
                    Manufacturer manuf = (Manufacturer)txtManufacturer.Tag;
                    List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByManufacturer(manuf.ManufacturerId);
                    FillListGrid(_prdList);
                }else
                {
                  
                    List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByManufacturer(0);
                    FillListGrid(_prdList);
                }
               
            }
        }

        private void FillListGrid(List<VWPhProductInfo> pList)
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (VWPhProductInfo item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgProducts, item.ProductId, item.LotNo, item.BrandName, item.Stock,item.OutLetName);
                dgProducts.Rows.Add(row);
            }
        }


        private void HideAllDefaultHidden()
        {
            ctrlManufacturerSearchControl.Visible = false;
           
        }

        private void txtPhysicalStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Are you sure to update the current?", "Confirmation", MessageBoxButtons.YesNoCancel);


                if (result == DialogResult.Yes)
                {
                    if (txtBrandName.Tag != null)
                    {

                        VWPhProductInfo _pInfo = (VWPhProductInfo)txtBrandName.Tag;

                        PhStockInfo _stockInfo = new PhProductService().GetCurrentStockByProdId(_pInfo.ProductId, _pInfo.LotNo);

                        if (_stockInfo != null)
                        {
                            if (!String.IsNullOrEmpty(txtPhysicalStock.Text))
                            {

                                int _physicalStock = 0;
                                int _softStock = 0;
                                int.TryParse(txtPhysicalStock.Text, out _physicalStock);
                                int.TryParse(txtSoftwareStock.Text, out _softStock);

                                _stockInfo.CurrentStock = _physicalStock;
                                if (new PhProductService().UpdatePhStockInfo(_stockInfo))
                                {
                                    MessageBox.Show("Stock update successful.");
                                    //List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByManufacturer(0);
                                    //FillListGrid(_prdList);

                                    new PhProductService().DeleteExistingAuditRecord(_pInfo.ProductId);

                                    PhStockAuditMasterDetail _auditdetail = new PhStockAuditMasterDetail();
                                    _auditdetail.AMId = 4;
                                    _auditdetail.ProductId = _pInfo.ProductId;
                                    _auditdetail.SoftWareStock = _softStock;
                                    _auditdetail.PhysicalStock = _physicalStock;

                                    new PhProductService().SavePhAuditDetail(_auditdetail);
                                }
                            }
                        }
                    }else
                    {
                        MessageBox.Show("Product not selected.");
                    }
                }
            }
        }

        private void dgProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgProducts.SelectedRows.Count>0)
            {
                VWPhProductInfo _pInfo = dgProducts.SelectedRows[0].Tag as VWPhProductInfo;

                if (_pInfo != null)
                {
                    txtBrandName.Text = _pInfo.BrandName;
                    txtBrandName.Tag = _pInfo;
                    txtSoftwareStock.Text = _pInfo.Stock.ToString();
                    txtPhysicalStock.Focus();

                }

            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {

            MedicineOutlet _outlet = (MedicineOutlet)cmbOutlet.SelectedItem;

            if (!String.IsNullOrEmpty(txtBrandName.Text) && txtBrandName.Text.Length > 1)
            {

                List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByBrandName(txtBrandName.Text, _outlet.OutLetId);
                FillListGrid(_prdList);

            }
            else
            {
                List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByBrandName("", _outlet.OutLetId);
                FillListGrid(_prdList);
            }
        }

        private void txtBrandName_TextChanged(object sender, EventArgs e)
        {
            MedicineOutlet _outlet = (MedicineOutlet)cmbOutlet.SelectedItem;

            if (!String.IsNullOrEmpty(txtBrandName.Text) && txtBrandName.Text.Length>1)
            {

                List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByBrandName(txtBrandName.Text, _outlet.OutLetId);
                FillListGrid(_prdList);

            }else
            {
                List<VWPhProductInfo> _prdList = new PhProductService().GetPhStockByBrandName("",_outlet.OutLetId);
                FillListGrid(_prdList);
            }
        }

        private void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
