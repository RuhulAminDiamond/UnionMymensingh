using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Service.Common;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmBringDischargeToLive : Form
    {
        public frmBringDischargeToLive()
        {
            InitializeComponent();
        }

        private void txtHospitalBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtHospitalBillNo.Text, out _billNo);

                HospitalPatientInfo _PatientInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNo);

                if (_PatientInfo != null)
                {
                    txtHospitalBillNo.Tag = _PatientInfo;
                    txtRegNo.Text = _PatientInfo.RegNo.ToString();

                    Doctor _d = new DoctorService().GetDoctorById(_PatientInfo.RefdDoctorId);
                    if (_d != null)
                    {
                        txtRefBy.Text = _d.Name;
                        txtRefBy.Tag = _d;
                    }

                    _d = new DoctorService().GetDoctorById(_PatientInfo.AssignDoctorId);
                    if (_d != null)
                    {
                        txtAssignedDoctor.Text = _d.Name;
                        txtAssignedDoctor.Tag = _d;
                    }

                    LoadPatientInfo(_PatientInfo.RegNo);
                }
                else
                {
                    MessageBox.Show("Patient not found.");
                }
            }
        }

        private void LoadPatientInfo(long regNo)
        {
            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(regNo);
            if (_record != null)
            {
                txtPatientName.Text = _record.FullName;
                txtYears.Text = _record.AgeYear;
                txtMonths.Text = _record.AgeMonth;
                txtDays.Text = _record.AgeDay;
                txtPhone.Text = _record.MobileNo;

                txtFatherName.Text = _record.FatherName;
                txtMotherName.Text = _record.FatherName;
                txtAddress.Text = _record.Address;

                cmbSex.Text = _record.Sex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBringDischargeToLive_Load(object sender, EventArgs e)
        {
            txtHospitalBillNo.Focus();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
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

        private void btnReturnToPreviousState_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtSecurityCode.Text))
            {
                MessageBox.Show("Security code required.");
                txtSecurityCode.Focus();
                return;
            }


            if(txtSecurityCode.Text != "101010")
            {
                MessageBox.Show("Security code did not match. Plz. provide valid security code and try again.");
                txtSecurityCode.Focus();
                return;
            }


            long _billNo = 0;
            long.TryParse(txtHospitalBillNo.Text, out _billNo);

            HospitalPatientInfo _PatientInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNo);

            if (_PatientInfo != null)
            {
                HospitalBill _hb = new HpFinancialService().GetHospitalBillByAdmissionId(_PatientInfo.AdmissionId);

                if (_hb != null)
                {
                    new HpFinancialService().DeleteExistingFinalBill(_hb.HospitalBillId);

                    _PatientInfo.Status = "Cabin";
                    _PatientInfo.DischargeDate = null;
                    _PatientInfo.DischargeTime = null;
                    _PatientInfo.Dischargedby = null;

                    new HospitalService().UpdateHospitalPatientInfo(_PatientInfo);
                    
                    HpPatientAccomodationInfo _hpAccom = new HospitalService().GetPatientLastAccomodatedCabin(_PatientInfo.AdmissionId);
                    if (_hpAccom != null)
                    {
                        _hpAccom.AllotType = HpBedAllotTypeEnum.PatientBed.ToString();
                        _hpAccom.Status = "Occupied";
                        _hpAccom.ReleaseDate = null;
                        _hpAccom.ReleaseTime = null;

                        new HospitalService().UpdateCurrentAccomodation(_hpAccom);

                        MessageBox.Show("Success. Patient backs to live"); 

                    }
                   
                }

            }
        }
    }
}
