using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Store;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
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

namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    public partial class frmFBItemUses : Form
    {
        public frmFBItemUses()
        {
            InitializeComponent();
        }

        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private void frmStoreItemUses_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            ctrlProductSearch.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y + txtProductCode.Height);
            ctrlProductSearch.ItemSelected += CtrlProductSearch_ItemSelected;

            LoadDepartments(MainForm.LoggedinUser.UserId);
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

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                long _billNo = 0;
                long.TryParse(txtBillNo.Text, out _billNo);

                if (_billNo > 0)
                {
                    Patient _p = new PatientService().GetPatientByBillNo(_billNo);
                    if (_p == null)
                    {
                        _p = new PatientService().GetPatientByIdNo(_billNo);
                    }

                    if (_p != null)
                    {
                        RegRecord _rr = new RegRecordService().GetRegRecordByRegNo(_p.RegNo);
                        lblPName.Text = _rr.FullName;
                        txtBillNo.Tag = _p;
                        txtProductCode.Focus();

                    }else
                    {
                        MessageBox.Show("Invalid Bill No. Plz. check and try again.");
                        
                    }
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblName.Tag != null && txtBillNo.Tag!=null) //Dept Name
            {
                int _deptId = 0;
                int.TryParse(lblName.Tag.ToString(), out _deptId);

                Patient _p = (Patient)txtBillNo.Tag;

                StoreItemUsesMaster _stMaster = new StoreItemUsesMaster();
                _stMaster.BillNo = _p.PatientId;
                _stMaster.DeptId = _deptId;
                _stMaster.UDate = Utils.GetServerDateAndTime();
                _stMaster.UTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _stMaster.UserId = MainForm.LoggedinUser.UserId;

                if(new StoreItemService().SaveStoreMaster(_stMaster))
                {
                    List<StoreItemUsesMasterDetail> _reqDetailsList = new List<StoreItemUsesMasterDetail>();
                    foreach (DataGridViewRow row in dgItems.Rows)
                    {
                        PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                         StoreItemUsesMasterDetail _reqDetail = new StoreItemUsesMasterDetail();
                        _reqDetail.StMId = _stMaster.StMId;
                        _reqDetail.ProductId = selectedTests.Id;
                        _reqDetail.Qty = selectedTests.Qty;

                        _reqDetailsList.Add(_reqDetail);
                    }
                    if (new StoreItemService().SaveStoreItemUSesDetails(_reqDetailsList))
                    {
                        MessageBox.Show("Information saved successfully.");
                       _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
                        dgItems.Rows.Clear();

                    }
                }


            }
            else
            {
                MessageBox.Show("Patient or Department not selected. Plz. check and try again."); return;
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
                lblName.Text = _deptInfo.Name;
                lblName.Tag = _deptId;
                lblInchargeName.Text = MainForm.LoggedinUser.Name;
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

                double _qty = 0;
                double.TryParse(txtQuantity.Text, out _qty);

                if (_qty == 0)
                {
                    MessageBox.Show("Quantity required."); return;
                }

                if (txtBillNo.Tag == null)
                {
                    MessageBox.Show("Patient bill no required."); return;
                }

                new StoreItemService().PopulateSelectedItemDataForConsumeRecord(_SelectedItems, txtProductCode.Tag as StoreProductInfo, txtBillNo.Tag as Patient, _qty);
                FillItemGrid();
                
                txtDrescription.Text = "";
                txtQuantity.Text = "";
                txtProductCode.Text = "";
                txtBillNo.Focus();
            }

        }

        private void FillItemGrid()
        {
            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.BillNo, item.Id, item.Name, item.Qty, item.Unit);
                dgItems.Rows.Add(row);
            }

             CalculateAmount();

            //dgTests.ResumeLayout();
        }

        private void CalculateAmount()
        {
          
            txtTotalQty.Text = dgItems.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToDouble(t.Cells[3].Value)).ToString();

        }
    }
}
