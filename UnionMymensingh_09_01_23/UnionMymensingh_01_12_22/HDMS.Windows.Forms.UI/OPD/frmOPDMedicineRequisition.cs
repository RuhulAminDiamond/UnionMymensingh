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
    public partial class frmOPDMedicineRequisition : Form
    {

        bool unlocked = true;
        bool isPanelMinimized = true;

        public frmOPDMedicineRequisition()
        {
            InitializeComponent();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

            if (unlocked)
            {
                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmboutlet.SelectedItem;

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
            ctlhpPatientSearchControl.Visible = false;
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

            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            ctlhpPatientSearchControl.Location = new Point(txtRequisitionfor.Location.X, txtRequisitionfor.Location.Y);
            ctlProductInfoSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);

            ctlProductInfoSearchControl.ItemSelected += ctlProductInfoSearchControl_ItemSelected;
            ctlhpPatientSearchControl.ItemSelected += ctlhpPatientSearchControl_ItemSelected;

            dtp1.Value = DateTime.Now;

            txtRequisitionby.Text = MainForm.LoggedinUser.Name;

            lblEntryDateValue.Text = DateTime.Now.ToString(Configuration.DATE_TIME_FORMAT);


            LoadRequisitionTypes();
            LoadOutLets();

            LoadPrevileges();

            LoadRequisitionByDateByUser(MainForm.LoggedinUser.Name);
        }

        private void LoadRequisitionByDateByUser(string username)
        {
            List<VMedicineRequisition> _reqList = new HospitalService().GetOPDRequisitionListByUserByDate(username, dtp1.Value);
            FillIndentGrid(_reqList);
        }

        private void FillIndentGrid(List<VMedicineRequisition> _hpReqList)
        {
            dgRequistions.SuspendLayout();
            dgRequistions.Rows.Clear();
            foreach (VMedicineRequisition item in _hpReqList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 32;
                row.Tag = item;


                row.CreateCells(dgRequistions, item.RequisitionId, item.CabinNo, item.RequisitionStatus);
                dgRequistions.Rows.Add(row);


            }

        }

        private void LoadPrevileges()
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if (_user.FloorId >= 0)
            {
                
                LoadEmergencyPatient("OPD", _user.FloorId);
              
               
                txtRequisitionfor.Enabled = false;
                
             

                FloorInfo _floor = new HospitalCabinBedService().GetFloorById(_user.FloorId);

                if (_floor != null)
                {
                    lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name + ", " + _floor.Name.ToString();
                }
                else
                {
                    lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name;
                }

            }


        }

        private void LoadEmergencyPatient(string v, int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentEmergencyPatients();
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }
        }

        private void LoadAdmittedPatients()
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentIPDs();
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }
        }


        private void LoadOTOrPostOperativePatient(string _otOrPo, int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentOTOrPostOperativePatients(floorId, _otOrPo);
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }
        }

        private void LoadAdmittedPatientListByFloor(int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentIPDInfoByFloor(floorId);
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }

        }


        private void LoadOutLets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmboutlet.DataSource = _outletLists;
            cmboutlet.DisplayMember = "Name";
            cmboutlet.ValueMember = "OutletId";

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            cmboutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == _user.MedicineRequisitionForwardToOutLet);
            txtRequisitionfor.Enabled = false;
            cmboutlet.Enabled = false;
            lvPatients.Enabled = true;

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

        private void LoadRequisitionTypes()
        {
            List<HpRequisitionType> _hpReqTypeList = new HospitalService().GetRequisitionTypes();
            _hpReqTypeList.Insert(0, new HpRequisitionType() { RequisitionTypeId = 0, RequisitionType = "--Select--" });
            cmbReqType.DataSource = _hpReqTypeList;
            cmbReqType.DisplayMember = "RequisitionType";
            cmbReqType.ValueMember = "RequisitionTypeId";

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            if (_user.RoleId == 34 || _user.RoleId==20 || _user.RoleId==21)
            {
                cmbReqType.SelectedItem = _hpReqTypeList.Find(q => q.RequisitionTypeId == 2);
                cmbReqType.Enabled = false;


            }
            else
            {
                cmbReqType.SelectedItem = _hpReqTypeList.Find(q => q.RequisitionTypeId == 1);
                cmbReqType.Enabled = false;
            }


        }

        private void ctlhpPatientSearchControl_ItemSelected(SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
            txtRequisitionfor.Text = item.BillNo.ToString();
            txtRequisitionfor.Tag = item;
            lblName.Text = item.Name;
            lblCabin.Text = item.BedCabinNo;
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

        private void txtRequisitionfor_TextChanged(object sender, EventArgs e)
        {
          

            if (unlocked)
            {
                string _txt = txtRequisitionfor.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    ctlhpPatientSearchControl.Visible = true;
                    ctlhpPatientSearchControl.txtSearch.Text = _txt;
                    ctlhpPatientSearchControl.txtSearch.SelectionStart = ctlProductInfoSearchControl.txtSearch.Text.Length;

                    ctlhpPatientSearchControl.LoadData();
                }
            }
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
                long _admissionId = 0;
                int _outletId = 0;
             
                long _requisitionfor = 0;
                VMIPDInfo _IpdInfo = (VMIPDInfo)txtRequisitionfor.Tag;

                //if (_IpdInfo == null)
                //{
                //    MessageBox.Show("Patient not selected. Plz. select patient and try again.");
                //    return;
                //}

                HpRequisitionType reqType = (HpRequisitionType)cmbReqType.SelectedItem;

                MedicineOutlet _OutLet = (MedicineOutlet)cmboutlet.SelectedItem;

                if (reqType.RequisitionTypeId== 1) {

                    if (_IpdInfo != null)
                    {
                        HospitalPatientInfo _Patient = new HospitalService().GetHospitalPatientByBillNo(_IpdInfo.BillNo);

                        if (_Patient == null || txtRequisitionfor.Tag == null)
                        {
                            MessageBox.Show("Patient not found. Please re-check requisition for and try again.");
                            return;
                        }


                        _admissionId = _IpdInfo.AdmissionId;
                    }else
                    {
                        MessageBox.Show("Patient not selected. Plz. select patient and try again.");
                        return;
                    }
                }


                _outletId = _OutLet.OutLetId;


                //if (reqType.RequisitionTypeId == 2)
                //{
                //    _outletId = 2;
                //}


                HpMedicineRequisition _hpMReq = new HpMedicineRequisition();
                _hpMReq.AdmissionId = _admissionId;
                _hpMReq.ReqDate = Utils.GetServerDateAndTime();
                _hpMReq.RequisitionBy = MainForm.LoggedinUser.Name;
                _hpMReq.RequisitionType = ((HpRequisitionType)cmbReqType.SelectedItem).RequisitionType;
                _hpMReq.OutletId = _outletId;
                _hpMReq.Status = RequisitionStatusEnum.Pending.ToString();
                long RequisitionId = new HospitalService().SaveRequisition(_hpMReq);
            
                if (RequisitionId > 0)
                {
                    List<HpMedicineRequisitionDetail> _reqDetailsList = new List<HpMedicineRequisitionDetail>();
                    foreach (DataGridViewRow row in dgRequisition.Rows)
                    {
                        PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                        HpMedicineRequisitionDetail _reqDetail = new HpMedicineRequisitionDetail();
                        _reqDetail.RequisitionId = RequisitionId;
                        _reqDetail.ProductId = selectedTests.Id;
                        _reqDetail.Qty = selectedTests.Qty;
                        _reqDetail.Status = RequisitionStatusEnum.Pending.ToString();
                        _reqDetailsList.Add(_reqDetail);
                    }
                    if (new HospitalService().SaveRequisitionDetails(_reqDetailsList))
                    {
                

                        MessageBox.Show("Requisition generated successfully.");

                        _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                        dgRequisition.Rows.Clear();

                  

                        txtRequisitionfor.Text = "";
                      
                        txtRequisitionfor.Tag = null;
                       


                    }
                }

             

            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ctlhpPatientSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) { txtRequisitionfor.Focus(); }
        }

        private void lvPatients_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvPatients.SelectedItems.Count == 1)
            {
              

                ListView.SelectedListViewItemCollection items = lvPatients.SelectedItems;

                ListViewItem lvItem = items[0];

                if (lvItem.Tag != null)
                {
                    long _admissionId = 0;
                    long.TryParse(lvItem.Tag.ToString(), out _admissionId);
                    LoadPatientInfo(_admissionId);
                }
                else
                {
                    MessageBox.Show("Patient not found.");
                }

            }
        }

        private void LoadPatientInfo(long _admissionId)
        {
            VMIPDInfo _IPdInfo = new HospitalService().GetIPDInfoById(_admissionId);

            if (_IPdInfo != null)
            {

                unlocked = false;
                txtRequisitionfor.Text = _IPdInfo.BillNo.ToString();
                lblName.Text = _IPdInfo.Name;
                lblCabin.Text = _IPdInfo.BedCabinNo;

                txtRequisitionfor.Tag = _IPdInfo;

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

            VMedicineRequisition _mreq = dgRequistions.SelectedRows[0].Tag as VMedicineRequisition;
           
            // dgRequistions.Visible = false;
            LoadRequitedProducts(_mreq.RequisitionId);
        }

        private void LoadRequitedProducts(long requisitionId)
        {
            HpMedicineRequisition _MedReq = new HospitalService().GetHpMedicineRequisitionByReqId(requisitionId);
            
            if (_MedReq != null)
            {
                List<VMRequisitionList> _mReqDetail = new HospitalService().GetHpMedicineRequisitionDetailByReqId(_MedReq.RequisitionId, 2);
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

        private void FillReqProductGrid(List<VMRequisitionList> _mReqDetail)
        {
            dgRequisitionList.SuspendLayout();
            dgRequisitionList.Rows.Clear();

            if (_mReqDetail == null) return;


            foreach (VMRequisitionList item in _mReqDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgRequisitionList, item.ProductId, item.BrandName, item.ReqQty);
                dgRequisitionList.Rows.Add(row);
            }
            // CalculateAmount();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequisitionByDateByUser(MainForm.LoggedinUser.Name);
        }
    }
}
