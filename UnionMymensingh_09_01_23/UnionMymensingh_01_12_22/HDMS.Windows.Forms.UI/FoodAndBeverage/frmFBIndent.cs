using HDMS.Model.Store;
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
using HDMS.Windows.Forms.UI.Controls;
using Models.Store;
using HDMS.Service.Diagonstics;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Model.Diagnostic;
using HDMS.Model.Enums;
using HDMS.Model.Diagnostic.VM;
using HDMS.Service.FoodAndBeverage;

namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    public partial class frmFBIndent : Form
    {
        bool unlocked = true;
        bool isPanelMinimized = true;

        public frmFBIndent()
        {
            InitializeComponent();
        }

        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private void frmStoreIndent_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            ctrlProductSearch.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y + txtProductCode.Height);
            ctrlProductSearch.ItemSelected += CtrlProductSearch_ItemSelected;

            LoadDepartments(MainForm.LoggedinUser.UserId);

            LoadRequisitionByDateByUser(MainForm.LoggedinUser.UserId);

        }

        private void LoadRequisitionByDateByUser(int userId)
        {
            StoreDept _dept = null; // new StoreItemService().GetStoreDeptListByUser(userId).FirstOrDefault();
            if (_dept != null)
            {
                List<VMStoreRequisition> _reqList = new StoreItemService().GetRequisitionListByUserByDate(_dept.DeptId, dtp1.Value);
                FillIndentGrid(_reqList);
            }
        }

        private void FillIndentGrid(List<VMStoreRequisition> _reqList)
        {
            dgRequistions.SuspendLayout();
            dgRequistions.Rows.Clear();
            foreach (VMStoreRequisition item in _reqList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 32;
                row.Tag = item;
                row.CreateCells(dgRequistions, item.RequisitionId, item.RDate.ToString("dd/MM/yyyy"), item.Status);
                dgRequistions.Rows.Add(row);

            }
        }

        private void CtrlProductSearch_ItemSelected(SearchResultListControl<StoreProductInfo> sender, StoreProductInfo item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.Name;
            txtQuantity.Focus();
            sender.Visible = false;
        }

        private void LoadDepartments(int userId)
        {
            List<StoreDept> _stDeptList = null; // new StoreItemService().GetStoreDeptListByUser(userId);
            lvDepts.Items.Clear();
            lvDepts.SmallImageList = imgListLarge;
            foreach (var item in _stDeptList)
            {

                string displayText = item.Name;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = item.DeptId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvDepts.Items.Add(listitem);
            }
        }

        private void lvDepts_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvDepts.SelectedItems.Count == 1)
            {


                ListView.SelectedListViewItemCollection items = lvDepts.SelectedItems;

                ListViewItem lvItem = items[0];

                if (lvItem.Tag != null)
                {
                    int _deptId = 0;
                    int.TryParse(lvItem.Tag.ToString(), out _deptId);
                    LoadDeptInfo(_deptId);
                }
                else
                {
                    MessageBox.Show("Lab Info not found.");
                }

            }
        }

        private void LoadDeptInfo(int _deptId)
        {
            StoreDept _deptInfo = new StoreItemService().GetStoreDeptById(_deptId);

            if (_deptInfo != null)
            {

                unlocked = false;

                lblName.Text = _deptInfo.Name;
                lblName.Tag = _deptId;
                lblInchargeName.Text = MainForm.LoggedinUser.Name;

                unlocked = true;
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlProductSearch.Visible = true;
                ctrlProductSearch.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlProductSearch.Visible = false;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtProductCode.Tag == null) return;

                StoreProductInfo _PL = (StoreProductInfo)txtProductCode.Tag;

                double _qty = 0;
                double.TryParse(txtQuantity.Text, out _qty);


                if (_qty == 0)
                {
                    MessageBox.Show("Quantity blank.");

                    txtQuantity.Text = "";
                    txtDrescription.Text = "";
                    unlocked = false;
                    txtProductCode.Text = "";
                    unlocked = true;
                    txtProductCode.Focus();
                    return;
                }

                new FoodAndBeverageItemService().PopulateSelectedItemDataForLabRequisition(_SelectedItems, txtProductCode.Tag as StoreProductInfo, _qty);
                FillItemGrid();

                unlocked = false;


                txtQuantity.Text = "";
                txtDrescription.Text = "";
                txtProductCode.Text = "";
                txtProductCode.Focus();

                txtProductCode.Tag = null;

                unlocked = true;
            }
        }

        private void FillItemGrid()
        {
            dgRequisition.SuspendLayout();
            dgRequisition.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgRequisition, item.Id, item.Name, item.Qty, item.Unit);
                dgRequisition.Rows.Add(row);
            }
            CalculateItem();
        }

        private void CalculateItem()
        {
            txtTotalItem.Text = dgRequisition.Rows.Count.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgRequisition.Rows.Count > 0)
            {
                int _deptId = 0;

                if (lblName.Tag != null)
                {
                    int.TryParse(lblName.Tag.ToString(), out _deptId);
                }

                StoreRequisition _stMReq = new StoreRequisition();
                _stMReq.DeptId = _deptId;
                _stMReq.RDate = Utils.GetServerDateAndTime();
                _stMReq.RTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _stMReq.OperateBy = MainForm.LoggedinUser.Name;

                _stMReq.Status = RequisitionStatusEnum.Pending.ToString();
                 long RequisitionId = new StoreItemService().SaveRequisition(_stMReq);

                if (RequisitionId > 0)
                {
                    List<StoreRequisitionDetail> _reqDetailsList = new List<StoreRequisitionDetail>();
                    foreach (DataGridViewRow row in dgRequisition.Rows)
                    {
                        PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                        StoreRequisitionDetail _reqDetail = new StoreRequisitionDetail();
                        _reqDetail.RequisitionId = RequisitionId;
                        _reqDetail.ProductId = selectedTests.Id;
                        _reqDetail.Qty = selectedTests.Qty;

                        _reqDetailsList.Add(_reqDetail);
                    }
                    if (new StoreItemService().SaveRequisitionDetails(_reqDetailsList))
                    {


                        MessageBox.Show("Requisition generated successfully.");

                        _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                        dgRequisition.Rows.Clear();

                        LoadRequisitionByDateByUser(MainForm.LoggedinUser.UserId);

                    }
                }



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTogglePositionForPanel(isPanelMinimized);
        }

        private void SetTogglePositionForPanel(bool _IspanleMinimized)
        {
            if (_IspanleMinimized)
            {
                lblRequisitionPanel.Location = new Point(1100, 54);

                button1.Location = new Point(20, 14);
                button1.Text = "<-----<< << <<";

                isPanelMinimized = false;

            }
            else
            {
                lblRequisitionPanel.Location = new Point(150, 54);

                button1.Location = new Point(20, 14);
                button1.Text = ">> >> >> ----->";

                isPanelMinimized = true;

            }
        }

        private void ctrlProductSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void dgRequisition_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)e.Row.Tag;


            _SelectedItems.Remove(e.Row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder);

            CalculateItem();
        }
    }
}
