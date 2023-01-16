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
using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
using Models.Store;
using HDMS.Model.Diagnostic.VM;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmLabItemRequisition : Form
    {

        bool unlocked = true;
        bool isPanelMinimized = true;

        public frmLabItemRequisition()
        {
            InitializeComponent();
        }

      

        private void HideAllDefaultHidden()
        {
            ctrlProductSearch.Visible = false;
        }

        private void ctlProductInfoSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                unlocked = false;
                txtProductCode.Text = "";
                unlocked = true;
                txtProductCode.Focus();
            }
        }


        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private void frmIndoorMedicineRequisition_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            ctrlProductSearch.Location = new Point(txtProductCode.Location.X,txtProductCode.Location.Y+txtProductCode.Height);
            ctrlProductSearch.ItemSelected += CtrlProductSearch_ItemSelected;
            dtp1.Value = DateTime.Now;

            txtRequisitionby.Text = MainForm.LoggedinUser.Name;

            lblEntryDateValue.Text = DateTime.Now.ToString(Configuration.DATE_TIME_FORMAT);

            lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name;

            LoadLabs();

            LoadRequisitionByDateByUser(MainForm.LoggedinUser.Name);
        }

        private void CtrlProductSearch_ItemSelected(SearchResultListControl<StoreProductInfo> sender, StoreProductInfo item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.Name;
            txtQuantity.Focus();
            sender.Visible = false;
        }

        private void LoadLabs()
        {
            List<LabInfo> _labList = new LabService().GetLabList();
          
            lvLabs.Items.Clear();
            lvLabs.SmallImageList = imgListLab;
            foreach (var item in _labList)
            {

                string displayText = item.Name;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = item.LabId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvLabs.Items.Add(listitem);
            }

        }

        private void LoadRequisitionByDateByUser(string username)
        {
            List<VMLabRequisition> _reqList = new LabService().GetRequisitionListByUserByDate(username, dtp1.Value);
            FillIndentGrid(_reqList);
        }

        private void FillIndentGrid(List<VMLabRequisition> _hpReqList)
        {
            dgRequistions.SuspendLayout();
            dgRequistions.Rows.Clear();
            foreach (VMLabRequisition item in _hpReqList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 32;
                row.Tag = item;
                row.CreateCells(dgRequistions, item.RequisitionId, item.RDate.ToString("dd/MM/yyyy"), item.Status);
                dgRequistions.Rows.Add(row);

            }

        }

      

        private void LoadAdmittedPatients()
        {
          
        }


        private void LoadOTOrPostOperativePatient(string _otOrPo, int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentOTOrPostOperativePatients(floorId, _otOrPo);
            lvLabs.Items.Clear();
            lvLabs.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvLabs.Items.Add(listitem);
            }
        }

        private void LoadAdmittedPatientListByFloor(int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentIPDInfoByFloor(floorId);
            lvLabs.Items.Clear();
            lvLabs.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvLabs.Items.Add(listitem);
            }

        }


        private void LoadOutLets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

           

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

           
          
            lvLabs.Enabled = true;

         

        }

        private void LoadRequisitionTypes()
        {
            List<HpRequisitionType> _hpReqTypeList = new HospitalService().GetRequisitionTypes();
            _hpReqTypeList.Insert(0, new HpRequisitionType() { RequisitionTypeId = 0, RequisitionType = "--Select--" });
          
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
           

        }

        private void ctlhpPatientSearchControl_ItemSelected(SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
          
            lblName.Text = item.Name;
            lblInchargeName.Text = item.BedCabinNo;
            txtProductCode.Focus();
            sender.Visible = false;
        }

        private void ctlProductInfoSearchControl_ItemSelected(SearchResultListControl<VWPhProductInfo> sender, VWPhProductInfo item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.BrandName;

            txtQuantity.Focus();

            sender.Visible = false;
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

                new LabService().PopulateSelectedItemDataForLabRequisition(_SelectedItems, txtProductCode.Tag as StoreProductInfo, _qty);
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

        private void dgRequisition_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)e.Row.Tag;

            _SelectedItems.Remove(e.Row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder);
            CalculateItem();
        }


        private string GetNewBillNo()
        {
            string _billPart1 = Utils.GetBillNo();
            long _billNo = new Random().Next(10000, 99999);
            string _billPart2 = _billNo.ToString() + "1";

            string _BillNo = _billPart1 + _billPart2;

            if (!new PhProductService().IsRequisitionNoAlloted(Convert.ToInt64(_BillNo)))
            {
                return _BillNo.ToString();
            }

            GetNewBillNo();

            return "";
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgRequisition.Rows.Count > 0)
            {
                int _labId = 0;

                if (lblName.Tag != null)
                {
                    int.TryParse(lblName.Tag.ToString(), out _labId);
                }

                



                 LabRequisition _hpMReq = new LabRequisition();
                _hpMReq.LabId = _labId;
                _hpMReq.RDate = Utils.GetServerDateAndTime();
                _hpMReq.RTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _hpMReq.OperateBy = MainForm.LoggedinUser.Name;
              
                _hpMReq.Status = RequisitionStatusEnum.Pending.ToString();
                long RequisitionId = new LabService().SaveRequisition(_hpMReq);
            
                if (RequisitionId > 0)
                {
                    List<LabRequisitionDetail> _reqDetailsList = new List<LabRequisitionDetail>();
                    foreach (DataGridViewRow row in dgRequisition.Rows)
                    {
                        PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                        LabRequisitionDetail _reqDetail = new LabRequisitionDetail();
                        _reqDetail.RequisitionId = RequisitionId;
                        _reqDetail.ProductId = selectedTests.Id;
                        _reqDetail.Qty = selectedTests.Qty;

                        _reqDetailsList.Add(_reqDetail);
                    }
                    if (new LabService().SaveRequisitionDetails(_reqDetailsList))
                    {
                

                        MessageBox.Show("Requisition generated successfully.");

                        _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                        dgRequisition.Rows.Clear();

                    }
                }

             

            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

      
        private void lvPatients_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void LoadLabInfo(int _LabId)
        {
            LabInfo _LabInfo = new LabService().GetlabInfoById(_LabId);

            if (_LabInfo != null)
            {

                unlocked = false;
             
                lblName.Text = _LabInfo.Name;
                lblName.Tag = _LabId;
                lblInchargeName.Text = _LabInfo.InChargeName;

              

                unlocked = true;
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

        private void dgRequistions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            VMLabRequisition _mreq = dgRequistions.SelectedRows[0].Tag as VMLabRequisition;
           
            // dgRequistions.Visible = false;
            LoadRequitedProducts(_mreq.RequisitionId);
        }

        private void LoadRequitedProducts(long requisitionId)
        {
            LabRequisition _MedReq = new LabService().GetLabRequisitionByReqId(requisitionId);
            
            if (_MedReq != null)
            {
                List<VMLabRequisitionList> _mReqDetail = new LabService().GetLabRequisitionDetailByReqId(_MedReq.RequisitionId);
                dgRequisitionList.Visible = true;
                FillReqProductGrid(_mReqDetail);

            }

            if (_MedReq.Status.ToLower() == "served")
            {
                PhInvoice _phInvoice = new PhProductService().GetPhInvoiceByRequistionNo(_MedReq.RequisitionId);
                if (_phInvoice != null)
                {
                    List<VMIssuedProductAgainstRequisition> _pList = new PhProductService().GetIssuedProductAgainstRequisition(_phInvoice.InvoiceId);
                    FillServedPrdGrid(_pList);
                }
            }else
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

        private void FillReqProductGrid(List<VMLabRequisitionList> _mReqDetail)
        {
            dgRequisitionList.SuspendLayout();
            dgRequisitionList.Rows.Clear();

            if (_mReqDetail == null) return;


            foreach (VMLabRequisitionList item in _mReqDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgRequisitionList, item.ProductId, item.Name, item.ReqQty);
                dgRequisitionList.Rows.Add(row);
            }
            // CalculateAmount();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequisitionByDateByUser(MainForm.LoggedinUser.Name);
        }

        private void lvLabs_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvLabs.SelectedItems.Count == 1)
            {


                ListView.SelectedListViewItemCollection items = lvLabs.SelectedItems;

                ListViewItem lvItem = items[0];

                if (lvItem.Tag != null)
                {
                    int _LabId = 0;
                    int.TryParse(lvItem.Tag.ToString(), out _LabId);
                    LoadLabInfo(_LabId);
                }
                else
                {
                    MessageBox.Show("Lab Info not found.");
                }

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

        private void lblRequisitionPanel_Paint(object sender, PaintEventArgs e)
        {




        }
    }
}
