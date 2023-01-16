using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital;
using HDMS.Model;
using HDMS.Service.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Enums;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.IPD;
using CrystalDecisions.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlDoctors : UserControl
    {
        public ctrlDoctors()
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
            ctrlDoctor.Visible = false;
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

        private void txtDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlDoctor.Visible = true;
                ctrlDoctor.LoadData();
            }
        }

        private IList<VMSelectedDoctorService> _SelectedDoctorServices;
        private void ctrlDoctors_Load(object sender, EventArgs e)
        {
            _SelectedDoctorServices = new List<VMSelectedDoctorService>();
            
            ctlPatientList.Location = new Point(txtPatient.Location.X, txtPatient.Location.Y + txtPatient.Height);
            ctrlServicetem.Location = new Point(txtServiceItem.Location.X, txtServiceItem.Location.Y + txtServiceItem.Height);
            ctrlDoctor.Location = new Point(txtDoctor.Location.X, txtDoctor.Location.Y + txtDoctor.Height);
            

            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;
            ctrlServicetem.ItemSelected += ctrlServicetem_ItemSelected;
            ctrlDoctor.ItemSelected += ctrlDoctor_ItemSelected;
            

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


                if (_user.RoleId == 34)
                {
                    LoadOTOrPostOperativePatient("OT", _user.FloorId);
                }
                else if (_user.RoleId == 37)
                {
                    LoadOTOrPostOperativePatient("PO", _user.FloorId);
                }
                else if (_user.RoleId == 40)
                {
                    LoadEmergencyPatient("OPD", _user.FloorId);
                }
                else if (_user.RoleId == 1)
                {
                    LoadAdmittedPatients();
                }
                else
                {
                    LoadAdmittedPatientListByFloor(_user.FloorId);
                }


                //txtPatient.Enabled = false;

                FloorInfo _floor = new HospitalCabinBedService().GetFloorById(_user.FloorId);

                if (_floor != null)
                {
                    lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name + ", " + _floor.Name.ToString();
                }else
                {
                    lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name;
                }

            }


        }

        private void LoadEmergencyPatient(string v, int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentEmergencyPatients();
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgList1;
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
            lvPatients.SmallImageList = imgList1;
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
            lvPatients.SmallImageList = imgList1;
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
            lvPatients.SmallImageList = imgList1;
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

        private void ctrlDoctor_ItemSelected(Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtDoctor.Text = item.Name;
            txtDoctor.Tag = item;
            txtRate.Focus();
            sender.Visible = false;
            ctrlDoctor.Visible = false;
        }

        private void ctrlServicetem_ItemSelected(Controls.SearchResultListControl<Model.Hospital.ServiceHead> sender, Model.Hospital.ServiceHead item)
        {
            txtServiceItem.Text = item.ServiceHeadName.ToString();
            txtServiceItem.Tag = item;
            txtDoctor.Focus();
            sender.Visible = false;
            ctrlServicetem.Visible = false;
        }

        private void ctlPatientList_ItemSelected(Controls.SearchResultListControl<Model.Hospital.ViewModel.VMIPDInfo> sender, Model.Hospital.ViewModel.VMIPDInfo item)
        {
            txtPatient.Text = item.AdmissionId.ToString();
            txtName.Text = item.Name;
            txtCabinNo.Text = item.BedCabinNo;
            txtAssignedDoctor.Text = item.AssignedDoctor;
            txtPatient.Tag = item;
            txtPatient.Focus();
            sender.Visible = false;
            ctlPatientList.Visible = false;

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
                if (!String.IsNullOrEmpty(txtQty.Text) && txtServiceItem.Tag != null && txtDoctor.Tag != null)
                {
                    double _Qty = 0;
                    double _Rate = 0;
                    double.TryParse(txtQty.Text, out _Qty);
                    double.TryParse(txtRate.Text, out _Rate);

                    ServiceHead _Servicehead = (ServiceHead)txtServiceItem.Tag;
                    Doctor _doctor = (Doctor)txtDoctor.Tag;


                    new HospitalService().PopulateSelectedDoctorServiceData(_SelectedDoctorServices, _Servicehead, _doctor, _Rate, _Qty, dtpServiceDate.Value, MainForm.LoggedinUser.Name);
                    FillServiceGrid();
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtDoctor.Text = "";
                    txtDoctor.Tag = null;

                    txtServiceItem.Text = "";
                    txtServiceItem.Tag = null;

                    txtServiceItem.Focus();

                }
                else
                {
                    MessageBox.Show("Service/Doctor not selected.");
                }

            }
        }

        private void FillServiceGrid()
        {
            dgService.SuspendLayout();
            dgService.Rows.Clear();
            foreach (VMSelectedDoctorService item in _SelectedDoctorServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgService, item.ServiceHeadName, item.DoctorName, item.Rate, item.Qty, item.ServiceCharge, item.Amount,item.ServiceDate, item.CreatedBy, false);
                dgService.Rows.Add(row);
            }

            CalculateTotalAmount();
        }


        private void CalculateTotalAmount()
        {
            txtTotalAmount.Text = dgService.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[5].Value)).ToString();

            txtServiceCharge.Text = dgService.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            long.TryParse(txtPatient.Text, out _billNo);

            double _serviceAmount = 0, _serviceCharge=0, gtotal=0;
            double.TryParse(txtTotalAmount.Text, out _serviceAmount);
            double.TryParse(txtServiceCharge.Text, out _serviceCharge);
            gtotal = _serviceAmount + _serviceCharge;

            if (dgService.Rows.Count == 0)
            {
                return;
            }

            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_billNo);

            if (_pInfo == null) return;


            HpDoctorServiceBill _hpsb = new HpDoctorServiceBill();
            _hpsb.DSDate = Utils.GetServerDateAndTime();
            _hpsb.ServiceAmount = gtotal;

            long _hsbId = new HospitalService().SaveDoctorServiceBill(_hpsb);


            List<DoctorServiceBillDetail> _dsblist = new List<DoctorServiceBillDetail>();
            List<HpConsultantLedger> _hpcLdgerList = new List<HpConsultantLedger>();

            foreach (DataGridViewRow row in dgService.Rows)
            {
                VMSelectedDoctorService selectedServices = row.Tag as VMSelectedDoctorService;
                //ServiceHead _sHead = new HospitalService().GetServiceHeadById(selectedOTServices.ServiceHeadId);
                DoctorServiceBillDetail dsbd = new DoctorServiceBillDetail();
                dsbd.DSBId = _hsbId;
                dsbd.AdmissionId = _pInfo.AdmissionId;
                dsbd.ServiceHeadId = selectedServices.ServiceHeadId;
                dsbd.DoctorId = selectedServices.DoctorId;
                dsbd.Rate = selectedServices.Rate;
                dsbd.Qty = selectedServices.Qty;
                dsbd.ServiceCharge = selectedServices.ServiceCharge;
                dsbd.ServiceDate = selectedServices.ServiceDate;
                dsbd.ServiceTime = selectedServices.ServiceDate.ToShortTimeString();
                dsbd.CreatedBy = MainForm.LoggedinUser.Name;
                dsbd.ModifiedBy = MainForm.LoggedinUser.Name;
                dsbd.ModifiedDate = Utils.GetServerDateAndTime();
                _dsblist.Add(dsbd);

                //Consultant Ledger


                double _currentBalance = new HpFinancialService().GetConsultantCurrentBalance(selectedServices.DoctorId);

                double _balance = _currentBalance + (selectedServices.Rate * selectedServices.Qty);


                HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                _hpcLedger.DoctorId = selectedServices.DoctorId;
                _hpcLedger.TranDate = Utils.GetServerDateAndTime();
                _hpcLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _hpcLedger.Particulars = selectedServices.ServiceHeadName+"( BillNo: "+ txtPatient.Text +", "+ txtCabinNo.Text+")";
                _hpcLedger.Debit = 0;
                _hpcLedger.Credit = selectedServices.Rate* selectedServices.Qty;
                _hpcLedger.Balance = _balance; // Negative balance means patient is payable this amount
                _hpcLedger.TransactionType = TransactionTypeEnum.ConsultantFee.ToString();
                _hpcLedger.OperateBy = MainForm.LoggedinUser.Name;

                _hpcLdgerList.Add(_hpcLedger);

              

            }

            if (new HospitalService().SaveDoctorServiceDetails(_dsblist))
            {
                MessageBox.Show("Record saved successfully.");

                new HpFinancialService().SaveHpConsultantTransaction(_hpcLdgerList);

                double _currentBalance = new HpFinancialService().GetPatientCurrentBalance(_pInfo.AdmissionId);

                double _balance = _currentBalance - gtotal;


                HpPatientLedger _hpLedger = new HpPatientLedger();
                _hpLedger.AdmissionId = _pInfo.AdmissionId;
                _hpLedger.TranDate = Utils.GetServerDateAndTime();
                _hpLedger.Particulars = "Consultant Service Id: " + _hsbId.ToString();
                _hpLedger.Debit = gtotal;
                _hpLedger.Credit = 0;
                _hpLedger.Balance = _balance; // Negative balance means patient is payable this amount
                _hpLedger.TransactionType = TransactionTypeEnum.ConsultantFee.ToString();
                _hpLedger.OperateBy = MainForm.LoggedinUser.Name;

                new HpFinancialService().SaveHpLedgerTransaction(_hpLedger);


                _SelectedDoctorServices = new List<VMSelectedDoctorService>();

                txtPatient.Text = "";
                dgService.Rows.Clear();
                txtPatient.Tag = null;


            }

        }

        private void ctrlDoctor_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtDoctor.Focus();
        }

        private void ctlPatientList_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtPatient.Focus();
        }

        private void ctrlServicetem_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtServiceItem.Focus();
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
                    LoadDeliveredServices(_admissionId);
                }
                else
                {
                    MessageBox.Show("Patient not found.");
                }

            }
        }

        private void LoadDeliveredServices(long _admissionId)
        {
            List<VMSelectedDoctorService> _deliveredServices= new HospitalService().GetDeliveredDoctorConsultancies(_admissionId);

            FillDeliveredServiceGrid(_deliveredServices);
        }

        private void FillDeliveredServiceGrid(List<VMSelectedDoctorService> _dsList)
        {
            dgDDServices.SuspendLayout();
            dgDDServices.Rows.Clear();
            foreach (VMSelectedDoctorService item in _dsList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgDDServices, item.ServiceHeadName, item.DoctorName, item.Rate, item.Qty,  item.Amount,  item.CreatedBy, false);
                dgDDServices.Rows.Add(row);
            }

           
        }

        private void LoadPatientInfo(long _admissionId)
        {
            VMIPDInfo _IPdInfo = new HospitalService().GetIPDInfoById(_admissionId);

            if (_IPdInfo != null)
            {
                txtPatient.Text = _IPdInfo.AdmissionId.ToString();
                txtName.Text = _IPdInfo.Name;
                txtCabinNo.Text = _IPdInfo.BedCabinNo;
                txtAssignedDoctor.Text = _IPdInfo.AssignedDoctor;
                txtPatient.Tag = _IPdInfo;

               
            }
        }

        private void btnInvestigations_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            long.TryParse(txtPatient.Text, out _billNo);


            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNo);



            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new DiagFinancialService().GetInvestigationDetailsByPatientId(_pInfo.AdmissionId);


            rptIPDInvestigationList _invDetail = new rptIPDInvestigationList();
            _invDetail.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            _invDetail.SetParameterValue("CabinNo", txtCabinNo.Text);

            rv.crviewer.ReportSource = _invDetail;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
