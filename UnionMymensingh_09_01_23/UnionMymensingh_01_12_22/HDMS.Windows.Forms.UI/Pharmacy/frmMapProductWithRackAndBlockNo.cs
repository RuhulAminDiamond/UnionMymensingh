using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmMapProductWithRackAndBlockNo : Form
    {
        public frmMapProductWithRackAndBlockNo()
        {
            InitializeComponent();
        }

        private void frmMapProductWithRackAndBlockNo_Load(object sender, EventArgs e)
        {

            ctrlManufacturerSearchControl.Location = new Point(txtSuplier.Location.X, txtSuplier.Location.Y);
            ctrlManufacturerSearchControl.ItemSelected += ctlSupllierSearchControl_ItemSelected;

            ctrlProductSearch.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y + txtProductCode.Height);
            ctrlProductSearch.ItemSelected += CtrlProductSearch_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            LoadOutlets();

            LoadGeneric();

        }


        private void LoadGeneric()
        {

            List<Generic> gList = new PhProductClassificationService().GetGenList().ToList();
            gList.Insert(0, new Generic() { GenericId = 0, Name = "Select Generic" });
            cmbGeneric.DataSource = gList;
            cmbGeneric.DisplayMember = "Name";
            cmbGeneric.ValueMember = "GenericId";


        }

        private void CtrlProductSearch_ItemSelected(Controls.SearchResultListControl<VWPhProductInfo> sender, VWPhProductInfo item)
        {
            txtProductCode.Text = item.BrandName;
            txtProductCode.Tag = item;
            cmbOutlet.Focus();
            sender.Visible = false;
        }

        private void LoadOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";


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

        private void ctlSupllierSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSuplier.Text = item.Name;
            txtSuplier.Tag = item;
            cmbOutlet.Focus();



            sender.Visible = false;
        }

        private void txtSuplier_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlProductSearch.Visible = true;
                ctrlProductSearch.LoadDataByType("");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Generic _gen = cmbGeneric.SelectedItem as Generic;

            MedicineOutlet outlet = cmbOutlet.SelectedItem as MedicineOutlet;

            if (outlet.OutLetId == 0)
            {
                MessageBox.Show("Plz. select outlet and try again."); return;
            }

            if (string.IsNullOrEmpty(txtRackNo.Text) || string.IsNullOrEmpty(txtBlockNo.Text))
            {
                MessageBox.Show("Rack and Block No Required."); return;
            }


            if (txtSuplier.Tag != null)
            {
                MapRackAndBlockWithProduct(txtSuplier.Tag as Manufacturer, _gen);

            }
            else if (_gen.GenericId > 0)
            {
                Manufacturer man = new Manufacturer() { ManufacturerId = 0, Name = "" };
                MapRackAndBlockWithProduct(man, _gen);

            }
            else if (txtProductCode.Tag != null)
            {

            }
            else
            {
                MessageBox.Show("Supplier/Generic/Product Required.");
                return;
            }
        }

        private void MapRackAndBlockWithProduct(Manufacturer manufacturer, Generic gen)
        {

            MedicineOutlet outlet = cmbOutlet.SelectedItem as MedicineOutlet;
            List<PhProductInfo> prodList = new List<PhProductInfo>();
            if (manufacturer.ManufacturerId > 0)
            {
                prodList = new PhProductService().GetProductListByManufacturer(manufacturer.ManufacturerId);

            }
            else if (gen.GenericId > 0)
            {
                prodList = new PhProductService().GetProductListByGeneric(gen.GenericId);
            }

            List<PhProductLocation> _prodLocList = new List<PhProductLocation>();
            foreach (var item in prodList)
            {
                PhProductLocation locObj = new PhProductLocation();
                locObj.ProductId = item.ProductId;
                locObj.OutLetId = outlet.OutLetId;
                locObj.RackNo = txtRackNo.Text;
                locObj.BlockNo = txtBlockNo.Text;
                _prodLocList.Add(locObj);
            }



            if (new PhProductService().SaveMapProductWithRackAndBlock(_prodLocList))
            {
                MessageBox.Show("Map successful.");
                LoadMappedProductByManGen(manufacturer, gen, outlet);
            }

        }

        private void LoadMappedProductByManGen(Manufacturer manufacturer, Generic gen, MedicineOutlet outlet)
        {
            List<VMPhProductMapWithRackAndBlock> _prodList = new List<VMPhProductMapWithRackAndBlock>();

            _prodList = new PhProductService().GetPhMappedProductWithManufacturer(manufacturer.ManufacturerId, gen.GenericId, outlet.OutLetId);

            FillMappedGrid(_prodList);

        }

        private void FillMappedGrid(List<VMPhProductMapWithRackAndBlock> prodList)
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (var item in prodList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgProducts, item.ProductId, item.BrandName, item.Generic, item.Manufacturer, item.RackNo, item.BlockNo);

                dgProducts.Rows.Add(row);


            }
        }

        private void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicineOutlet outlet = cmbOutlet.SelectedItem as MedicineOutlet;
            if (outlet.OutLetId > 0)
            {
                Manufacturer man = txtSuplier.Tag as Manufacturer;
                if (man == null)
                {
                    man = new Manufacturer() { ManufacturerId = 0, Name = "" };
                }

                Generic gen = cmbGeneric.SelectedItem as Generic;

                if (man.ManufacturerId > 0 || gen.GenericId > 0)
                {
                    LoadMappedProductByManGen(man, gen, outlet);
                }
            }
        }
    }
}
