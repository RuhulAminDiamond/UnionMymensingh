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
using HDMS.Model;
using HDMS.Service.Hospital;
using HDMS.Model.Enums;
using HDMS.Common.Utils;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlOT : UserControl
    {
        public ctrlOT()
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

        private IList<VMSelectedOTServices> _SelectedOTServices;

        private void ctrlOT_Load(object sender, EventArgs e)
        {

            _SelectedOTServices = new List<VMSelectedOTServices>();

            ctlPatientList.Location = new Point(txtPatient.Location.X, txtPatient.Location.Y + txtPatient.Height);
            ctrlServicetem.Location = new Point(txtServiceItem.Location.X, txtServiceItem.Location.Y + txtServiceItem.Height);
            ctrlDoctor.Location = new Point(txtDoctor.Location.X, txtDoctor.Location.Y + txtDoctor.Height);
            ctrlSurgeon.Location = new Point(txtCheifSurgeon.Location.X, txtCheifSurgeon.Location.Y + txtCheifSurgeon.Height);

            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;
            ctrlServicetem.ItemSelected += ctrlServicetem_ItemSelected;
            ctrlDoctor.ItemSelected += ctrlDoctor_ItemSelected;
            ctrlSurgeon.ItemSelected += ctrlSurgeon_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

        }

        private void ctrlSurgeon_ItemSelected(Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtCheifSurgeon.Text = item.Name;
            txtCheifSurgeon.Tag = item;
            sender.Visible = false;
            ctrlSurgeon.Visible = false;
        }

        private void ctrlDoctor_ItemSelected(Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtDoctor.Text = item.Name;
            txtDoctor.Tag = item;

            if (txtServiceItem.Tag != null)
            {
                Model.Hospital.ServiceHead _shead = (Model.Hospital.ServiceHead)txtServiceItem.Tag;
                txtRate.Text = _shead.Rate.ToString();
                txtRate.Enabled = true;
                txtRate.Focus();
            }
            else
            {
                txtRate.Enabled = true;
                txtRate.Focus();
            }
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

            FillPastServiceGrid(item);
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

        private void txtCheifSurgeon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlSurgeon.Visible = true;
                ctrlSurgeon.LoadData();
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


                    new HospitalService().PopulateSelectedServiceData(_SelectedOTServices, _Servicehead, _doctor, _Rate, _Qty, MainForm.LoggedinUser.Name);

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
            foreach (VMSelectedOTServices item in _SelectedOTServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgService, item.ServiceHeadName, item.DoctorName, item.Rate, item.Qty, item.ServiceCharge, item.Amount, item.EnteredBy, false);
                dgService.Rows.Add(row);
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            btnSave.Enabled = false;
            btnSave.Text = "Plz. Wait..";

            if (txtPatient.Tag == null)
            {
                MessageBox.Show("Patient not selected."); return;
            }

            if (dgService.Rows.Count == 0)
            {
                MessageBox.Show("No item selected"); return;
            }

            VMIPDInfo _pInfo = (VMIPDInfo)txtPatient.Tag;

            OTSchedule _schedule = new OTSchedule();
            _schedule.AdmissionId = _pInfo.AdmissionId;
            _schedule.OSDate = dtpStartDate.Value;
            _schedule.OSTime = dtpStartTime.Value.ToString("hh:mm tt");
            _schedule.OEDate = dtpEndDate.Value;
            _schedule.OETime = dtpEndTime.Value.ToString("hh:mm tt");
            _schedule.OTName = txtOTName.Text;
            _schedule.ChiefSurgeonId = ((Doctor)txtCheifSurgeon.Tag).DoctorId;
            _schedule.IndicationOfSurgery = txtIndicationOfSurgery.Text;
            _schedule.IncisionType = txtIncisionType.Text;
            _schedule.AnaesthesiaType = cmbAnaesthesiaType.Text;
            _schedule.OTType = cmbOTtype.Text;
            _schedule.UserName = MainForm.LoggedinUser.Name;

            long _OTId = new HospitalService().SaveOTSchedule(_schedule);

            double _currentBalance = new HpFinancialService().GetPatientCurrentBalance(_pInfo.AdmissionId);
            double _balance = _currentBalance;



            List<HpPatientLedger> _hpLedegerList = new List<HpPatientLedger>();
            List<HpConsultantLedger> _hpcLdgerList = new List<HpConsultantLedger>();

            List<OTExecutionDetail> _otelist = new List<OTExecutionDetail>();
            if (_OTId > 0)
            {
                foreach (DataGridViewRow row in dgService.Rows)
                {
                    VMSelectedOTServices selectedOTServices = row.Tag as VMSelectedOTServices;
                    //ServiceHead _sHead = new HospitalService().GetServiceHeadById(selectedOTServices.ServiceHeadId);
                    OTExecutionDetail oted = new OTExecutionDetail();
                    oted.OTId = _OTId;
                    oted.ServiceHeadId = selectedOTServices.ServiceHeadId;
                    oted.DoctorId = selectedOTServices.DoctorId;
                    oted.Rate = selectedOTServices.Rate;
                    oted.Qty = selectedOTServices.Qty;
                    oted.ServiceCharge = selectedOTServices.ServiceCharge;
                    oted.ServiceDate = dtpEndDate.Value;
                    oted.ServiceTime = dtpEndTime.Value.ToShortTimeString();
                    oted.UserName = MainForm.LoggedinUser.Name;
                    _otelist.Add(oted);




                    _balance = _balance - selectedOTServices.Rate * selectedOTServices.Qty;


                    HpPatientLedger _hpLedger = new HpPatientLedger();
                    _hpLedger.AdmissionId = _pInfo.AdmissionId;
                    _hpLedger.TranDate = Utils.GetServerDateAndTime();
                    _hpLedger.Particulars = "OT Service Id: " + _OTId.ToString();
                    _hpLedger.Debit = selectedOTServices.Rate * selectedOTServices.Qty;
                    _hpLedger.Credit = 0;
                    _hpLedger.Balance = _balance; // Negative balance means patient is payable this amount
                    _hpLedger.TransactionType = TransactionTypeEnum.OTBiLL.ToString();
                    _hpLedger.OperateBy = MainForm.LoggedinUser.Name;

                    _hpLedegerList.Add(_hpLedger);



                    double _otcurrentBalance = new HpFinancialService().GetConsultantCurrentBalance(selectedOTServices.DoctorId);

                    double _otbalance = _otcurrentBalance + (selectedOTServices.Rate * selectedOTServices.Qty);

                    HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                    _hpcLedger.DoctorId = selectedOTServices.DoctorId;
                    _hpcLedger.TranDate = Utils.GetServerDateAndTime();
                    _hpcLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _hpcLedger.Particulars = selectedOTServices.ServiceHeadName + "( Bill No: " + txtPatient.Text + ", " + txtCabinNo.Text + " )";
                    _hpcLedger.Debit = 0;
                    _hpcLedger.Credit = selectedOTServices.Rate * selectedOTServices.Qty;
                    _hpcLedger.Balance = _otbalance;   // positive balance means doctor will claim this amount against his/her service
                    _hpcLedger.TransactionType = TransactionTypeEnum.OTBiLL.ToString();
                    _hpcLedger.OperateBy = MainForm.LoggedinUser.Name;

                    _hpcLdgerList.Add(_hpcLedger);



                }

                if (new HospitalService().SaveOTExecutioDetails(_otelist))
                {


                    new HpFinancialService().SaveHpLedgerTransactionList(_hpLedegerList);

                    new HpFinancialService().SaveHpConsultantTransaction(_hpcLdgerList);

                    MessageBox.Show("Record saved successfully.");
                    _SelectedOTServices = new List<VMSelectedOTServices>();
                    dgService.Rows.Clear();
                    txtPatient.Tag = null;
                }
            }


            btnSave.Enabled = true;
            btnSave.Text = "Save";

        }

        private void dgService_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

            _SelectedOTServices.Remove(e.Row.Tag as VMSelectedOTServices);

        }

        private void ctlPatientList_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtPatient.Focus();
        }

        private void ctrlServicetem_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtServiceItem.Focus();
        }

        private void ctrlDoctor_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtDoctor.Focus();
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime _StartDateAndTime = new CalculateCabinCharge().CombinedDateAndTimePart(dtpStartDate.Value.Date, dtpStartTime.Value.ToString("hh:mm tt"));

            DateTime _EndDateAndTime = new CalculateCabinCharge().CombinedDateAndTimePart(dtpEndDate.Value.Date, dtpEndTime.Value.ToString("hh:mm tt"));

            double _timeDistanceInhours = new CalculateCabinCharge().GetTimeDistanceInHours(dtpStartDate.Value.Date, dtpStartTime.Value.ToString("hh:mm tt"), dtpEndDate.Value.Date, dtpEndTime.Value.ToString("hh:mm tt"));

            string _otdh = "";
            string _otdm = "";

            string _otd = _timeDistanceInhours.ToString();

            string[] arr = new string[3];
            arr = _otd.Split('.');

            int _lenghth = arr.Length;

            if (_lenghth == 1 || _lenghth == 2) _otdh = arr[0];

            if (_lenghth == 2) _otdm = Math.Round(Convert.ToDouble(arr[1]) / 100 * 60).ToString();

            if (String.IsNullOrEmpty(_otdm))
            {
                lblOtDuration.Text = "OT Duration :" + _otdh + " hours.";

            }
            else
            {
                lblOtDuration.Text = "OT Duration :" + _otdh + " hours and " + _otdm + " minutes";
            }

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatient_TextChanged(object sender, EventArgs e)
        {

        }

        private void FillPastServiceGrid(VMIPDInfo info)
        {
            List<VMSelectedOTServices> pastServices = new HospitalService().GetPastServices(info.AdmissionId);

            dgPastService.SuspendLayout();
            dgPastService.Rows.Clear();
            foreach (VMSelectedOTServices item in pastServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 25;
                row.CreateCells(dgPastService, item.ServiceHeadName, item.DoctorName, item.Rate, item.Qty, item.ServiceCharge, item.Amount, item.EnteredBy, false);
                dgPastService.Rows.Add(row);
            }
        }
    }
}
