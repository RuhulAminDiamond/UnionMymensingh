using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.Users;
using HDMS.Service;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class ctrlOPDServices : UserControl
    {
        public ctrlOPDServices()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgService.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgService.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }
        private void txtPatient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlPatientList.Visible = true;
                ctlPatientList.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlPatientList.Visible = false;
            ctrlServicetem.Visible = false;
        }

        private IList<VMSelectedService> _SelectedServices;
        private void ctrlServices_Load(object sender, EventArgs e)
        {

            _SelectedServices = new List<VMSelectedService>();
            ctlPatientList.Location = new Point(txtPatient.Location.X, txtPatient.Location.Y + txtPatient.Height);
            ctrlServicetem.Location = new Point(txtServiceItem.Location.X, txtServiceItem.Location.Y + txtServiceItem.Height);
            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;
            ctrlServicetem.ItemSelected += ctrlServicetem_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadPrevileges();

        }

        private void LoadPrevileges()
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if (_user.FloorId >= 0)
            {


              
                LoadEmergencyPatient("OPD", _user.FloorId);



                //txtPatient.Enabled = false;

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
        private void ctrlServicetem_ItemSelected(Controls.SearchResultListControl<Model.Hospital.ServiceHead> sender, Model.Hospital.ServiceHead item)
        {
            txtServiceItem.Text = item.ServiceHeadName.ToString();
            txtServiceItem.Tag = item;
            txtRate.Text = item.Rate.ToString();
            txtRate.Focus();
            sender.Visible = false;
            ctrlServicetem.Visible = false;
        }

        private void ctlPatientList_ItemSelected(Controls.SearchResultListControl<Model.Hospital.ViewModel.VMIPDInfo> sender, Model.Hospital.ViewModel.VMIPDInfo item)
        {
            txtPatient.Text = item.BillNo.ToString();
            txtName.Text = item.Name;
            txtCabinNo.Text = item.BedCabinNo;
            txtAssignedDoctor.Text = item.AssignedDoctor;
            txtPatient.Tag = item;
            txtServiceItem.Focus();
            sender.Visible = false;
            ctlPatientList.Visible = false;
        }

        private void txtServiceItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlServicetem.Visible = true;
                ctrlServicetem.LoadData();
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtQty.Text) && txtServiceItem.Tag != null)
                {
                    int _Qty = 0;
                    double _Rate = 0;
                    int.TryParse(txtQty.Text, out _Qty);
                    double.TryParse(txtRate.Text, out _Rate);

                    ServiceHead _Servicehead = (ServiceHead)txtServiceItem.Tag;
                   


                    new HospitalService().PopulateSelectedServices(_SelectedServices, _Servicehead, dtpServiceDate.Value, _Rate, _Qty, MainForm.LoggedinUser.Name);
                    FillServiceGrid();
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtServiceItem.Text = "";
                    txtServiceItem.Tag = null;

                    txtServiceItem.Focus();

                }
                else
                {
                    MessageBox.Show("Service not selected.");
                }

            }
        }

        private void FillServiceGrid()
        {
            dgService.SuspendLayout();
            dgService.Rows.Clear();
            foreach (VMSelectedService item in _SelectedServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgService, item.ServiceHeadName, item.Rate, item.Qty, item.ServiceCharge, item.Amount,item.ServiceDate, item.EnteredBy, false);
                dgService.Rows.Add(row);
            }

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
          txtTotalAmount.Text = dgService.Rows.Cast<DataGridViewRow>()
              .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

          txtServiceCharge.Text = dgService.Rows.Cast<DataGridViewRow>()
              .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtPatient.Tag == null) return;

            if (dgService.Rows.Count == 0)
            {
                MessageBox.Show("No service added."); return;
            }

            List<ServiceBillDetail> _sbillList = new List<ServiceBillDetail>();

            double _totalAmount = 0, serviceCharge = 0, Gtotal = 0;
            double.TryParse(txtTotalAmount.Text, out _totalAmount);
            double.TryParse(txtServiceCharge.Text, out serviceCharge);
            Gtotal = _totalAmount + serviceCharge;

        
            HpServiceBill _bService = new HpServiceBill();
            _bService.SDate = Utils.GetServerDateAndTime();
            _bService.ServiceAmount = Gtotal;

            long _SbId = new HpFinancialService().SaveHpServiceBill(_bService);


                long  _billNo=0;
                long.TryParse(txtPatient.Text, out _billNo);

                 HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_billNo);
           
                foreach (DataGridViewRow row in dgService.Rows)
                {
                    VMSelectedService selectedOTServices = row.Tag as VMSelectedService;
                    
                    ServiceBillDetail sbd = new ServiceBillDetail();
                    sbd.SBId = _SbId;
                    sbd.AdmissionId = _pInfo.AdmissionId;
                    sbd.ServiceHeadId = selectedOTServices.ServiceHeadId;
                   
                    sbd.Rate = selectedOTServices.Rate;
                    sbd.Qty = selectedOTServices.Qty;
                    sbd.ServiceCharge = selectedOTServices.ServiceCharge;
                    sbd.ServiceDate = selectedOTServices.ServiceDate;
                    sbd.ServiceTime = selectedOTServices.ServiceDate.ToShortTimeString();
                    sbd.CreatedBy = MainForm.LoggedinUser.Name;
                    sbd.ModifiedBy = MainForm.LoggedinUser.Name;
                    sbd.ModifiedDate = Utils.GetServerDateAndTime();
                    _sbillList.Add(sbd);
                }

                if (new HospitalService().SaveServiceBillDetails(_sbillList))
                {
                    MessageBox.Show("Record saved successfully.");

                 

                    double _currentBalance = new HpFinancialService().GetPatientCurrentBalance(_pInfo.AdmissionId);

                     double _balance = _currentBalance - Gtotal;


                    HpPatientLedger _hpLedger = new HpPatientLedger();
                   _hpLedger.AdmissionId = _pInfo.AdmissionId;
                   _hpLedger.TranDate = Utils.GetServerDateAndTime();
                   _hpLedger.Particulars = "Hp Service: " + _billNo.ToString();
                   _hpLedger.Debit = Gtotal;
                   _hpLedger.Credit = 0;
                   _hpLedger.Balance = _balance; // Negative balance means patient is payable this amount
                   _hpLedger.TransactionType = TransactionTypeEnum.HpServiceBill.ToString();
                   _hpLedger.OperateBy = MainForm.LoggedinUser.Name;

                    new HpFinancialService().SaveHpLedgerTransaction(_hpLedger);

                   _SelectedServices = new List<VMSelectedService>();

                    dgService.SuspendLayout();
                    dgService.Rows.Clear();

                   txtPatient.Tag = null;
            }
                else
                {
                    MessageBox.Show("Fail to save record. Please verify the patient infomation and try again.");
                }
            
        }

        private void dgService_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _SelectedServices.Remove(e.Row.Tag as VMSelectedService);
        }

        private void ctrlServicetem_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtServiceItem.Focus();
        }

        private void ctlPatientList_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtPatient.Focus();
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
                    LoadDelivedServices(_admissionId);
                    
                }else
                {
                    MessageBox.Show("Patient not found.");
                }

            }
        }

        private void LoadDelivedServices(long _admissionId)
        {
            List<VMSelectedService> _deliveredServices = new HospitalService().GetDeliveredFloorServices(_admissionId);
            FillDeliveredServiceGrid(_deliveredServices);
        }

        private void FillDeliveredServiceGrid(List<VMSelectedService> _dsList)
        {
            dgDeliveredServices.SuspendLayout();
            dgDeliveredServices.Rows.Clear();
            foreach (VMSelectedService item in _dsList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgDeliveredServices, item.ServiceHeadName, item.Rate, item.Qty,  item.Amount, item.EnteredBy, false);
                dgDeliveredServices.Rows.Add(row);
            }

            CalculateTotalAmount();
        }

        private void LoadPatientInfo(long _admissionId)
        {
            VMIPDInfo _IPdInfo = new HospitalService().GetIPDInfoById(_admissionId);

            if (_IPdInfo != null)
            {
                txtPatient.Text = _IPdInfo.BillNo.ToString();
                txtName.Text = _IPdInfo.Name;
                txtCabinNo.Text = _IPdInfo.BedCabinNo;
                txtAssignedDoctor.Text = _IPdInfo.AssignedDoctor;
                txtPatient.Tag = _IPdInfo;

                HighLightButton(_IPdInfo.Status);
            }
        }

        private void HighLightButton(string _cabinState)
        {
            if (_cabinState.ToLower() == "cabin")
            {
                btnCabin.BackColor = Color.Green;
                btnCabin.ForeColor = Color.White;

                btnOT.ForeColor = Color.Black;
                btnPostOperative.ForeColor = Color.Black;
                btnOT.BackColor = Control.DefaultBackColor;
                btnPostOperative.BackColor = Control.DefaultBackColor;
            }

            if (_cabinState.ToLower() == "ot")
            {
                btnOT.BackColor = Color.Green;
                btnOT.ForeColor = Color.White;

                btnCabin.BackColor = Control.DefaultBackColor;
                btnCabin.ForeColor = Color.Black;
                btnPostOperative.ForeColor = Color.Black;
                btnPostOperative.BackColor = Control.DefaultBackColor;
            }

            if (_cabinState.ToLower() == "po")
            {
                btnPostOperative.BackColor = Color.Green;
                btnPostOperative.ForeColor = Color.White;

                btnOT.BackColor = Control.DefaultBackColor;
                btnOT.ForeColor = Color.Black;

                btnCabin.BackColor = Control.DefaultBackColor;
                btnCabin.ForeColor = Color.Black;
            }

        }

        private void btnOT_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to tranfer patient at OT?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                VMIPDInfo _IpdInfo =(VMIPDInfo)txtPatient.Tag;
                if (_IpdInfo != null)
                {
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdInfo.AdmissionId);
                    if (_pInfo != null)
                    {
                        _pInfo.Status = "OT";
                        _pInfo.StatusChangeBy = MainForm.LoggedinUser.Name;
                        new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                        HighLightButton(_pInfo.Status);

                        LoadPrevileges();
                    }
                }
            }
        }

        private void btnPostOperative_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to tranfer patient at Post Operative Zone?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                VMIPDInfo _IpdInfo = (VMIPDInfo)txtPatient.Tag;
                if (_IpdInfo != null)
                {
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdInfo.AdmissionId);
                    if (_pInfo != null)
                    {
                        _pInfo.Status = "PO";
                        _pInfo.StatusChangeBy = MainForm.LoggedinUser.Name;
                        new HospitalService().UpdateHospitalPatientInfo(_pInfo);
                        HighLightButton(_pInfo.Status);

                        LoadPrevileges();
                    }
                }
            }
        }

        private void btnCabin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to tranfer patient at Cabin?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                VMIPDInfo _IpdInfo = (VMIPDInfo)txtPatient.Tag;
                if (_IpdInfo != null)
                {
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdInfo.AdmissionId);
                    if (_pInfo != null)
                    {
                        _pInfo.Status = "Cabin";
                        _pInfo.StatusChangeBy = MainForm.LoggedinUser.Name;
                        new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                        HighLightButton(_pInfo.Status);

                        LoadPrevileges();
                    }
                }
            }
        }

        private void ctlPatientList_Load(object sender, EventArgs e)
        {

        }
    }
}
