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
using HDMS.Model.OPD;
using HDMS.Service.OPD;
using HDMS.Model.OPD.VM;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class ctrlEmergencyDoctors : UserControl
    {
        public ctrlEmergencyDoctors()
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
                //HideAllDefaultHidden();
                //ctlPatientList.Visible = true;
                //ctlPatientList.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtPatient.Text, out _billNo);

                OPDPatientRecord _record = new HospitalEmergencyService().GetPatientInfoByBillNo(_billNo);
                if (_record != null)
                {
                    VMIPDInfo _IPdInfo = new HospitalEmergencyService().GetPatientInfoById(_record.PatientId);

                    if (_IPdInfo != null)
                    {

                        txtName.Text = _IPdInfo.Name;

                        txtPatient.Tag = _IPdInfo;

                        txtServiceItem.Focus();
                    }

                }
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
            LoadAdmittedPatients();



           // txtPatient.Enabled = false;


            lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name;

            LoadAdmittedPatients();
        }

        private void LoadAdmittedPatients()
        {
            List<VMOPDPatientRecord> _pList = new OPDPatientService().GetOPDPatientsUnderService();
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgList1;
            foreach (VMOPDPatientRecord ipdItem in _pList)
            {

                string displayText = ipdItem.BillNo.ToString();
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.PatientId;
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
            txtPatient.Text = item.BillNo.ToString();
            txtName.Text = item.Name;
         
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

            OPDPatientRecord _pInfo = new HospitalEmergencyService().GetPatientInfoByBillNo(_billNo);

            if (_pInfo == null) return;


            HpDoctorServiceBill _hpsb = new HpDoctorServiceBill();
            _hpsb.DSDate = Utils.GetServerDateAndTime();
            _hpsb.ServiceAmount = gtotal;

            long _hsbId = new HospitalService().SaveDoctorServiceBill(_hpsb);
       

            List<OPDDoctorServiceBillDetail> _dsblist = new List<OPDDoctorServiceBillDetail>();
            List<HpConsultantLedger> _hpcLdgerList = new List<HpConsultantLedger>();

            foreach (DataGridViewRow row in dgService.Rows)
            {
                VMSelectedDoctorService selectedServices = row.Tag as VMSelectedDoctorService;
                //ServiceHead _sHead = new HospitalService().GetServiceHeadById(selectedOTServices.ServiceHeadId);
                OPDDoctorServiceBillDetail dsbd = new OPDDoctorServiceBillDetail();
                dsbd.DSBId = _hsbId;
                dsbd.PatientId = _pInfo.PatientId;
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


                //double _currentBalance = new OPDFinancialService().GetBalanceByPatient(selectedServices.DoctorId);

                //double _balance = _currentBalance + (selectedServices.Rate * selectedServices.Qty);


                //HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                //_hpcLedger.DoctorId = selectedServices.DoctorId;
                //_hpcLedger.TranDate = Utils.GetServerDateAndTime();
                //_hpcLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                //_hpcLedger.Particulars = selectedServices.ServiceHeadName;
                //_hpcLedger.Debit = 0;
                //_hpcLedger.Credit = selectedServices.Rate* selectedServices.Qty;
                //_hpcLedger.Balance = _balance; // Negative balance means patient is payable this amount
                //_hpcLedger.TransactionType = TransactionTypeEnum.ConsultantFee.ToString();
                //_hpcLedger.OperateBy = MainForm.LoggedinUser.Name;

                //_hpcLdgerList.Add(_hpcLedger);

              

            }

            if (new HospitalEmergencyService().SaveDoctorServiceDetails(_dsblist))
            {
                MessageBox.Show("Record saved successfully.");

              //  new HpFinancialService().SaveHpConsultantTransaction(_hpcLdgerList);

                double _currentBalance = new OPDFinancialService().GetBalanceByPatient(_pInfo.PatientId);

                double _balance = _currentBalance - gtotal;


              

                _SelectedDoctorServices = new List<VMSelectedDoctorService>();

                txtPatient.Text = "";
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
                    long _patientId = 0;
                    long.TryParse(lvItem.Tag.ToString(), out _patientId);
                    LoadPatientInfo(_patientId);
                   // LoadDelivedServices(_admissionId);

                }
                else
                {
                    MessageBox.Show("Patient not found.");
                }

            }
        }

        private void LoadPatientInfo(long _pId)
        {
            VMOPDPatientRecord _OpdInfo = new  OPDPatientService().GetOPDInfoById(_pId);

            if (_OpdInfo != null)
            {
                txtPatient.Text = _OpdInfo.BillNo.ToString();
                txtName.Text = _OpdInfo.Name;
              
                txtPatient.Tag = _OpdInfo;

               
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //LoadEmergencyPatientByDate(dtp1.Value);
        }
    }
}
