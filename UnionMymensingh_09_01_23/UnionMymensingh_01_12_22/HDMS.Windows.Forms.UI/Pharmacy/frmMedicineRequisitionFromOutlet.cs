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
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Service.Pharmacy;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Service.Hospital;
using HDMS.Model.Hospital;
using HDMS.Model.Enums;
using HDMS.Service;
using HDMS.Model.Users;
using HDMS.Model.Pharmacy;
using HDMS.Models.Pharmacy;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmMedicineRequisitionFromOutlet : Form
    {

        bool unlocked = true;
        bool isPanelMinimized = true;

        public frmMedicineRequisitionFromOutlet()
        {
            InitializeComponent();
        }


        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private void frmMedicineRequisitionFromOutlet_Load(object sender, EventArgs e)
        {

            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
         
            ctlProductInfoSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);

            ctlProductInfoSearchControl.ItemSelected += ctlProductInfoSearchControl_ItemSelected;
          

            dtp1.Value = DateTime.Now;

            txtRequisitionby.Text = MainForm.LoggedinUser.Name;

            lblEntryDateValue.Text = DateTime.Now.ToString(Configuration.DATE_TIME_FORMAT);

            LoadFromOutLets();
            LoadToOutlets();

            MedicineOutlet _m = (MedicineOutlet)cmbFromOutlet.SelectedItem;

            LoadPrevileges();

           
            LoadRequisitionByDate(MainForm.LoggedinUser.Name, _m.OutLetId);

        }

        private void LoadRequisitionByDate(string name, int outletId)
        {
            List<VMOutletMedicineRequisition> _reqList = new PhProductService().GetPhOutletRequisitionList(outletId,dtp1.Value);
            FillIndentGrid(_reqList);
        }

        private void FillIndentGrid(List<VMOutletMedicineRequisition> _hpReqList)
        {
            dgRequistions.SuspendLayout();
            dgRequistions.Rows.Clear();
            foreach (VMOutletMedicineRequisition item in _hpReqList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 32;
                row.Tag = item;


                row.CreateCells(dgRequistions, item.RequisitionId, item.ToOutlet, item.RequisitionStatus, item.RequisitionBy);
                dgRequistions.Rows.Add(row);


            }

        }

        private void LoadToOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbToOutlet.DataSource = _outletLists;
            cmbToOutlet.DisplayMember = "Name";
            cmbToOutlet.ValueMember = "OutletId";

            cmbToOutlet.SelectedItem = _outletLists.Find(x=>x.OutLetId==2);
        }

        private void LoadPrevileges()
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if (_user.FloorId >= 0)
            {
               
                    lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name;
              

            }


        }

        private void LoadFromOutLets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbFromOutlet.DataSource = _outletLists;
            cmbFromOutlet.DisplayMember = "Name";
            cmbFromOutlet.ValueMember = "OutletId";

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            cmbFromOutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == _user.MedicineRequisitionForwardToOutLet);
          
            cmbFromOutlet.Enabled = false;
         
            //if (_user.AssignedOutLet == 3)
            // {
            //     cmboutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == _user.AssignedOutLet);
            //     txtRequisitionfor.Enabled = false;
            //     cmboutlet.Enabled = false;
            //     lvPatients.Enabled = false;
            // }
            // else
            // {
            //     txtRequisitionfor.Enabled = true;
            //     lvPatients.Enabled = true;
            //     cmboutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == 0);
            //     cmboutlet.Enabled = false;
            // }


        }

        private void ctlProductInfoSearchControl_ItemSelected(SearchResultListControl<VWPhProductInfo> sender, VWPhProductInfo item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.BrandName;

            txtQuantity.Focus();

            sender.Visible = false;
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmbFromOutlet.SelectedItem;

                    ctlProductInfoSearchControl.Visible = true;
                    ctlProductInfoSearchControl.txtSearch.Text = _txt;
                    ctlProductInfoSearchControl.txtSearch.SelectionStart = ctlProductInfoSearchControl.txtSearch.Text.Length;

                    ctlProductInfoSearchControl.LoadDataByType(_txt); // Out let Id appended for outlet specific product loading
                    //ctlProductInfoSearchControl.LoadDataByType(_txt + ">" + _outLet.OutLetId.ToString());
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductInfoSearchControl.Visible = false;
          
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtProductCode.Tag == null) return;

                VWPhProductInfo _PL = (VWPhProductInfo)txtProductCode.Tag;

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

                new PhProductService().PopulateSelectedItemDataForRequisition(_SelectedItems, txtProductCode.Tag as VWPhProductInfo, _qty);
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (dgRequisition.Rows.Count > 0)
            {
               
                int _outletId = 0;

            
                MedicineOutlet _FromOutLet = (MedicineOutlet)cmbFromOutlet.SelectedItem;
                MedicineOutlet _ToOutLet = (MedicineOutlet)cmbToOutlet.SelectedItem;

                _outletId = _FromOutLet.OutLetId;

                if (_ToOutLet.OutLetId == 0)
                {
                    return;
                }

                DateTime _ReqDateTime= Utils.GetServerDateAndTime();

                PhOutletMedicinieRequisition _hpMReq = new PhOutletMedicinieRequisition();
                _hpMReq.FromOutletId = _outletId;
                _hpMReq.ToOutletId = _ToOutLet.OutLetId;
                _hpMReq.ReqDate = _ReqDateTime;
                _hpMReq.ReqTime = _ReqDateTime.ToString("dd/MM/yyyy");
                _hpMReq.RequisitionBy = MainForm.LoggedinUser.Name;
                _hpMReq.Status = RequisitionStatusEnum.Pending.ToString();


                List<PhOutletMedicineRequisitionDetail> _reqDetailsList = new List<PhOutletMedicineRequisitionDetail>();
                foreach (DataGridViewRow row in dgRequisition.Rows)
                {
                    PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                    PhOutletMedicineRequisitionDetail _reqDetail = new PhOutletMedicineRequisitionDetail();
                    _reqDetail.RequisitionId = 0;
                    _reqDetail.ProductId = selectedTests.Id;
                    _reqDetail.Qty = selectedTests.Qty;
                    _reqDetail.TransferQty = selectedTests.Qty;
                    _reqDetail.Status = RequisitionStatusEnum.Pending.ToString();
                    _reqDetailsList.Add(_reqDetail);
                }

                PhOutletMedicinieRequisition _newRequisition = await new PhProductService().CreateNewPhOutletRequistion(_hpMReq, _reqDetailsList);
                if (_newRequisition!=null)
                {
                    MessageBox.Show("Requisition generated successfully.");

                    _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                    dgRequisition.Rows.Clear();

                  
                }
                else
                {
                    MessageBox.Show("Requisition generation failed.");
                }



            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgRequistions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMOutletMedicineRequisition _mreq = dgRequistions.SelectedRows[0].Tag as VMOutletMedicineRequisition;

            // dgRequistions.Visible = false;
            LoadRequitedProducts(_mreq.RequisitionId);
        }

        private void LoadRequitedProducts(long requisitionId)
        {
            PhOutletMedicinieRequisition _MedReq = new PhProductService().GetOutletMedicineRequisitionByReqId(requisitionId);

            if (_MedReq != null)
            {
                List<VMOutletRequisitionList> _mReqDetail = new PhProductService().GetOutletMedicineRequisitionDetailByReqId(_MedReq.RequisitionId, _MedReq.FromOutletId);
                dgRequisitionList.Visible = true;
                FillReqProductGrid(_mReqDetail);

            }

            if (_MedReq.Status.ToLower() == "served")
            {
                PhStockTransferRecord _phTransferRecord = new PhProductService().GetPhStockTransferRecord(_MedReq.RequisitionId);
                if (_phTransferRecord != null)
                {
                    List<VMIssuedProductAgainstRequisition> _pList = new PhProductService().GetOutletIssuedProductAgainstRequisition(_phTransferRecord);
                    FillServedPrdGrid(_pList);
                }
            }
            else
            {
                dgServed.SuspendLayout();
                dgServed.Rows.Clear();
            }
        }

        private void FillServedPrdGrid(List<VMIssuedProductAgainstRequisition> _pList)
        {
            dgServed.SuspendLayout();
            dgServed.Rows.Clear();

            if (_pList == null) return;


            foreach (VMIssuedProductAgainstRequisition item in _pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgServed, item.ProductId, item.BrandName, item.Qty);
                dgServed.Rows.Add(row);
            }
        }

        private void FillReqProductGrid(List<VMOutletRequisitionList> mReqDetail)
        {
            dgRequisitionList.SuspendLayout();
            dgRequisitionList.Rows.Clear();
            foreach (VMOutletRequisitionList item in mReqDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgRequisitionList, item.ProductId, item.BrandName, item.ReqQty);
                dgRequisitionList.Rows.Add(row);
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
                lblRequisitionPanel.Location = new Point(1100, 15);

                button1.Location = new Point(20, 14);
                button1.Text = "<-----<< << <<";

                isPanelMinimized = false;

            }
            else
            {
                lblRequisitionPanel.Location = new Point(150, 15);

                button1.Location = new Point(20, 14);
                button1.Text = ">> >> >> ----->";

                isPanelMinimized = true;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MedicineOutlet _m = (MedicineOutlet)cmbFromOutlet.SelectedItem;
            LoadRequisitionByDate(MainForm.LoggedinUser.Name, _m.OutLetId);

        }

        private void ctlProductInfoSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }
    }
}
