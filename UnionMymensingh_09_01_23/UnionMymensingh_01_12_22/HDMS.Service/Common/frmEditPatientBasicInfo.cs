using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
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
using HDMS.Windows.Forms.UI.Controls;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmEditPatientBasicInfo : Form
    {
        public frmEditPatientBasicInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiagBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtDiagBillNo.Text, out _billNo);

                Patient _PatientInfo = new PatientService().GetPatientByBillNo(_billNo);

                if(_PatientInfo != null)
                {
                    txtDiagBillNo.Tag = _PatientInfo;
                    txtRegNo.Text = _PatientInfo.RegNo.ToString();

                    Doctor _d = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                    txtRefBy.Text = _d.Name;
                    txtRefBy.Tag = _d;
                    txtRefBy.Enabled = true;
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

                cmbSex.Text= _record.Sex;
            }
        }

        private void txtHospitalBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtHospitalBillNo.Text, out _billNo);

                HospitalPatientInfo _PatientInfo = new HospitalService().GetHospitalPatientByBillNo(_billNo);

                if (_PatientInfo != null)
                {
                    txtHospitalBillNo.Tag = _PatientInfo;
                    txtRegNo.Text = _PatientInfo.RegNo.ToString();
                    LoadPatientInfo(_PatientInfo.RegNo);
                }
                else
                {
                    MessageBox.Show("Patient not found.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRegNo.Text))
            {
                long _regNo = 0;
                long.TryParse(txtRegNo.Text, out _regNo);

                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);

                if (_record != null)
                {
                    _record.FullName = txtPatientName.Text;
                    _record.AgeYear = txtYears.Text;
                    _record.AgeMonth = txtMonths.Text;
                    _record.AgeDay = txtDays.Text;
                    _record.Sex = cmbSex.Text;
                    _record.Address = txtAddress.Text;
                    _record.MobileNo = txtPhone.Text;
                    _record.FatherName = txtFatherName.Text;
                    _record.MotherName = txtMotherName.Text;

                    if(new RegRecordService().UpdateRegRecord(_record))
                    {
                        if (txtDiagBillNo.Tag != null)
                        {
                            Patient _p = (Patient)txtDiagBillNo.Tag;
                            _p.AgeYear = txtYears.Text;
                            _p.AgeMonth = txtMonths.Text;
                            _p.AgeDay = txtDays.Text;
                            if(txtRefBy.Tag != null)
                            {
                                _p.DoctorId = ((Doctor)txtRefBy.Tag).DoctorId;
                            }
                            new PatientService().UpdatePatientInfo(_p);
                        }

                        if (txtHospitalBillNo.Tag != null)
                        {
                            HospitalPatientInfo _hpInfo = (HospitalPatientInfo)txtHospitalBillNo.Tag;
                            _hpInfo.AgeYear = txtYears.Text;
                            _hpInfo.AgeMonth = txtMonths.Text;
                            _hpInfo.AgeDay = txtDays.Text;
                            new HospitalService().UpdateHospitalPatientInfo(_hpInfo);

                        }

                        MessageBox.Show("Update Patient Info Successfull");
                        txtDiagBillNo.Tag = null;
                        txtHospitalBillNo.Tag = null;
                        txtRefBy.Tag = null;

                        txtRefBy.Enabled = false;
                    }

                }
            }
        }

        private void txtRefBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlDoctorSearch.Visible = true;
                ctrlDoctorSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {

                int id = 0;
                if (int.TryParse(txtRefBy.Text.Trim(), out id))
                {
                    txtRefBy.Text = new DoctorService().GetDoctorById(id).Name;
                    txtRefBy.Tag = new DoctorService().GetDoctorById(id);
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlDoctorSearch.Visible = false;
        }

        private void frmEditPatientBasicInfo_Load(object sender, EventArgs e)
        {
            ctrlDoctorSearch.Location = new Point(txtRefBy.Location.X, txtRefBy.Location.Y + txtRefBy.Height);
            ctrlDoctorSearch.ItemSelected += ctrlDoctorSearch_ItemSelected;

            txtRefBy.Enabled = false;
        }

        private void ctrlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtRefBy.Text = item.Name;
            txtRefBy.Tag = item;
            sender.Visible = false;
           
        }
    }
}
