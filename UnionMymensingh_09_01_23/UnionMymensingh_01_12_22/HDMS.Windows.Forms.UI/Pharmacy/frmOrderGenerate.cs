using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using POS;
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

namespace Store.Forms
{
    public partial class frmOrderGenerate : Form
    {
        public event System.Windows.Forms.DataGridViewCellEventHandler CellEnter;

        public frmOrderGenerate()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {

            foreach (DataGridViewColumn c in dgOrders.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgOrders.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                //ctlProductSearchControl.Visible = true;
                //ctlProductSearchControl.LoadData();


            }
        }



        private void HideAllDefaultHidden()
        {
            ctrlManufacturerSearchControl.Visible = false;
            ctlProductSearchControl.Visible = false;
        }
        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private void frmOrderGenerate_Load(object sender, EventArgs e)
        {
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

           ctrlManufacturerSearchControl.Location = new Point(txtOrderTo.Location.X, txtOrderTo.Location.Y);
           ctrlManufacturerSearchControl.ItemSelected += ctrlManufacturerSearchControl_ItemSelected;

            ctlProductSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;



            txtOrderNo.Text = GetOrderNo();

            Random rnd = new Random();
            int invNo = rnd.Next(10000, 11000);
            
            lblOrddate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

            txtStaffName.Text = MainForm.LoggedinUser.Name;

            txtOrderTo.Focus();
        }

        private string GetOrderNo()
        {

           PhCompany phc = new PhProductService().GetCompany();

            int _totalOrderOfthisMonth = new PhProductService().GetTotalOrderOfthisMonth(DateTime.Now.Year, DateTime.Now.Month)+1;

            string _ordercount = GetPrefixedOrder(_totalOrderOfthisMonth.ToString());

           string on=phc.ShortName + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month+"/"+ _ordercount;
           return on;
        }

        private string GetPrefixedOrder(string _totalOrderOfthisMonth)
        {
            if (_totalOrderOfthisMonth.Length == 1) return "00" + _totalOrderOfthisMonth;
            if (_totalOrderOfthisMonth.Length == 2) return "0" + _totalOrderOfthisMonth;

            return "001";
        }

        private void ctrlManufacturerSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtOrderTo.Text = item.Name;
            txtOrderTo.Tag = item;
            txtOrderTo.Focus();
            sender.Visible = false;
        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControl<VWPhProductInfo> sender, VWPhProductInfo item)
        {

            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.BrandName;
            txtUnitPrice.Text = item.PurchasePrice.ToString();
            txtQuantity.Focus();

            sender.Visible = false;
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
              

                new PhProductService().PopulateSelectedItemDataForOrder(_SelectedItems, txtProductCode.Tag as VWPhProductInfo, _rate, _qty);
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
            dgOrders.SuspendLayout();
            dgOrders.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgOrders, item.Id, item.Name, item.Qty2, item.CurrentStock, item.ROLOutdoor, item.Unit);
                dgOrders.Rows.Add(row);
            }
            CalculateItem();
        }

        private void CalculateItem()
        {
            txtTotalItem.Text = dgOrders.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[2].Value)).ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgOrders.Rows.Count > 0)
            {
                if (txtOrderTo.Tag != null)
                {
                    DateTime _dt = DateTime.Now;// Convert.ToDateTime(lblOrddate.Text);

                    PhOrder Phord = new PhOrder();
                    Phord.OrderTo = ((Manufacturer)txtOrderTo.Tag).ManufacturerId;
                    Phord.OrderDate = DateTime.Now;
                    Phord.OrderNo = txtOrderNo.Text;
                    Phord.OrderYear = _dt.Year;
                    Phord.OrderMonth = _dt.Month;
                    Phord.OrderGenerateBy = MainForm.LoggedinUser.UserId;
                    Phord.OrderVerifiedBy = 0;
                    Phord.OrderApprovedBy = 0;

                    long _OrderId = new PhProductService().SaveOrder(Phord);
                    if (_OrderId > 0)
                    {
                        List<PhOrderDetail> _ODeatailsList = new List<PhOrderDetail>();
                        foreach (DataGridViewRow row in dgOrders.Rows)
                        {
                            PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                            if (!String.IsNullOrEmpty(selectedTests.Qty2))
                            {
                                double _qty = 0;
                                double.TryParse(selectedTests.Qty2, out _qty);

                                PhOrderDetail phod = new PhOrderDetail();
                                phod.OrderId = _OrderId;
                                phod.ProductId = Convert.ToInt32(selectedTests.Id);
                                phod.Qty = _qty;
                                //phod.PurchaseRate = Convert.ToDouble(selectedTests.Rate);
                                _ODeatailsList.Add(phod);
                            }
                        }
                        if (new PhProductService().SaveOrderDetail(_ODeatailsList))
                        {
                            MessageBox.Show("Save Successful.");
                            PrintOrderSheet(_OrderId);
                            ClearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Saved Failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Plz select order to and try again.");
                }
            }
        }

        private void ClearFields()
        {
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            dgOrders.Rows.Clear();
        }

        private void PrintOrderSheet(long _OrderId)
        {
            DataSet ds = new PhReportingService().GetOrderedItemDataSetByOrderId(_OrderId);

            RptOrderSheet _rpt = new RptOrderSheet();
            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.Show();
        }

        private void txtOrderTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlManufacturerSearchControl.Visible = true;
                ctrlManufacturerSearchControl.LoadData();

            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtOrderTo.Tag != null)
                {
                    Manufacturer _m = (Manufacturer)txtOrderTo.Tag;
                    LoadManufacturerItem(_m.ManufacturerId);
                }
            }

        }

        private void LoadManufacturerItem(int manufacturerId)
        {
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            //PhProductInfo _pInfo = new PhProductService().GetProductById(_selectedItem.Id);
          
            new PhProductService().PopulateSelectedItemDataByManufacturer(_SelectedItems, manufacturerId);
            FillItemGridByManufacturer();
        }

        private void FillItemGridByManufacturer()
        {
            dgOrders.SuspendLayout();
            dgOrders.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgOrders, item.Id, item.Name, item.Qty2, item.Qty,item.ROLOutdoor, item.Unit);
                dgOrders.Rows.Add(row);
            }
            //CalculateItem();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtOrderNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrWhiteSpace(txtSearchOrder.Text))
                {
                    PhOrder _PrevOrder = new PhProductService().GetOrderByOrderNo(txtSearchOrder.Text);
                    if(_PrevOrder != null)
                    {
                        txtSearchOrder.Tag = _PrevOrder;
                        List<PhSelectedProductsToSaleOrReceiveOrOrder> _pList = new PhProductService().GetOrderedProductListByOrderId(_PrevOrder.OrderId);
                        FillItemGridByPreviousOrder(_pList);
                        CalculateItem();
                    }
                }
            }
        }

        private void FillItemGridByPreviousOrder(List<PhSelectedProductsToSaleOrReceiveOrOrder> _pList)
        {
            dgOrders.SuspendLayout();
            dgOrders.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;

                row.CreateCells(dgOrders, item.Code,item.Name,item.Qty);
                dgOrders.Rows.Add(row);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearchOrder.Text))
            {
                if (dgOrders.Rows.Count > 0)
                {
                    if (txtSearchOrder.Tag != null)
                    {
                        PhOrder _order = (PhOrder)txtSearchOrder.Tag;
                        PrintOrderSheet(_order.OrderId);

                    }
                    else
                    {
                        MessageBox.Show("Order no required.");
                    }
                }
            }
        }

        private void ctlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void ctrlManufacturerSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtOrderTo.Focus();
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            string _txt = txtProductCode.Text.Trim();
            if (_txt.Length >= 2)
            {
                HideAllDefaultHidden();

                //MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;
                int _manufacturerId = 0;
                if (txtOrderTo.Tag != null)
                {
                    Manufacturer _manufacturer = (Manufacturer)txtOrderTo.Tag;
                    _manufacturerId = _manufacturer.ManufacturerId;
                }

                ctlProductSearchControl.Visible = true;
                ctlProductSearchControl.txtSearch.Text = _txt;
                ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                ctlProductSearchControl.LoadDataByType(_txt+">"+ _manufacturerId.ToString()); // Out let Id appended for outlet specific product loading
            }
        }

        private void ctlProductSearchControl_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void dgOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOrders.Rows.Count > 0)
            {

                if (e.ColumnIndex == 2)  //example-'Column index=4'
                {

                    double qty = 0;

                    double.TryParse(dgOrders.CurrentRow.Cells[2].Value.ToString(), out qty);

                    if (qty == 0) return;

                    PhSelectedProductsToSaleOrReceiveOrOrder _selectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)dgOrders.CurrentRow.Tag;
                    _SelectedItems.Where(w => w.Id == _selectedItem.Id).ToList().ForEach(s => s.Qty2 = qty.ToString());

                    
                }

                if (e.ColumnIndex == 4)  //example-'Column index=4'
                {

                    int rol = 0;

                    int.TryParse(dgOrders.CurrentRow.Cells[4].Value.ToString(), out rol);

                    if (rol == 0) return;

                    PhSelectedProductsToSaleOrReceiveOrOrder _selectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)dgOrders.CurrentRow.Tag;
                    _SelectedItems.Where(w => w.Id == _selectedItem.Id).ToList().ForEach(s => s.ROLOutdoor = rol);

                    PhProductInfo _pInfo = new PhProductService().GetProductById(_selectedItem.Id);
                    _pInfo.ROLOutdoor = rol;
                    new PhProductService().UpdatePhProductInfo(_pInfo);

                    if(_selectedItem.ROLOutdoor> _selectedItem.Qty)
                    {
                        _SelectedItems.Where(w => w.Id == _selectedItem.Id).ToList().ForEach(s => s.Qty2 = (_selectedItem.ROLOutdoor- _selectedItem.Qty).ToString());

                        FillItemGridByManufacturer();
                    }
                }
            }
        }
    }
}
