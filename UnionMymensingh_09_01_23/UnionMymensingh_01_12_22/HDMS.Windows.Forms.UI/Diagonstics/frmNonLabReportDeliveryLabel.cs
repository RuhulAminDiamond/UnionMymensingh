using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmNonLabReportDeliveryLabel : Form
    {
       

        public frmNonLabReportDeliveryLabel()
        {
            InitializeComponent();
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtBillNo.Text, out _billNo);

                //Load PatientInfo
                Patient _PatientInfo = new PatientService().GetPatientByBillNo(_billNo);
                if (_PatientInfo == null)
                    _PatientInfo = new PatientService().GetDiagPatientById(_billNo);
                if (_PatientInfo == null)
                {
                    MessageBox.Show("Patient not found.", "HERP");
                    txtBillNo.Tag = null;
                }
                else
                {
                    // LoadBarcodeForId("0000000"+_pId.ToString());

                    txtDays.Tag = _PatientInfo.ReportIdPrefix + _PatientInfo.ReportId.ToString();

                    txtBillNo.Tag = _PatientInfo;
                    LoadRegPatientInfo(_PatientInfo.RegNo);


                    txtRefBy.Text = new DoctorService().GetDoctorById(_PatientInfo.DoctorId).Name;
                    txtRefBy.Tag = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                    dtpEntry.Value = _PatientInfo.EntryDate;
                    txtEntryTime.Text = _PatientInfo.EntryTime;
                    dtpDelivery.Value = _PatientInfo.DeliveryDate;
                    txtDeliveryTime.Text = _PatientInfo.DeliveryTime;
                    if (_PatientInfo.AdmissionNo > 0)
                    {
                        HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNoAny(_PatientInfo.AdmissionNo);
                        if (_hp.Status.ToLower() == "discharged")
                        {
                            txtCabin.Text = "";
                        }
                        else
                        {
                            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hp.AdmissionId);
                            if (_accomInfo != null)
                            {
                                CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                                txtCabin.Text = _cabin.CabinNo;
                            }
                            else
                            {
                                txtCabin.Text = "";
                            }
                        }

                    }
                    else
                    {
                        txtCabin.Text = "";
                    }


                    if (String.IsNullOrEmpty(_PatientInfo.Status))
                    {
                        List<ViewModelReportTests> reportTests = new TestService().GetAllNonLabTestByPatientId(_PatientInfo.PatientId).ToList();

                       
                        FillTestGrid(reportTests);
                        AddToStatusToGrid(_PatientInfo.PatientId);

                    }
                    else
                    {
                        MessageBox.Show("This is a cancelled Id.", "HERP");

                    }
                }
            }
        }

        private void AddToStatusToGrid(long patientId)
        {
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();

            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Select for Label";
            dgvCmb.Width = 200;

           

            if (dgTests.Columns.Contains("Chk") && dgTests.Columns["Chk"].Visible)
            {
                foreach (DataGridViewRow row in dgTests.Rows)
                {
                  
                        row.Cells["Chk"].Value = false;
                 
                }

            }
            else
            {

                dgTests.Columns.Add(dgvCmb);

                foreach (DataGridViewRow row in dgTests.Rows)
                {
                   
                   
                    row.Cells["Chk"].Value = false;
             
                }

          }
        }

        private void FillTestGrid(List<ViewModelReportTests> _SelectedTests)
        {
            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach (ViewModelReportTests item in _SelectedTests)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgTests, item.Id, item.Name, false);
                dgTests.Rows.Add(row);
            }

        }

        private bool LoadRegPatientInfo(long _regNo)
        {
            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
            if (_record != null)
            {
                txtPatientName.Text = _record.FullName;
                txtYears.Text = _record.AgeYear;
                txtMonths.Text = _record.AgeMonth;
                txtDays.Text = _record.AgeDay;

                cmbGender.Text = _record.Sex;
                txtMobileNo.Text = _record.MobileNo;

                return true;

            }

            return false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(cmbPrinter.Text))
            {
                MessageBox.Show("Printer not selected. Plz. select printer and try again.");
                return;
            }

            VMFolderLabelParameter _lblParam = new VMFolderLabelParameter();
            _lblParam.IdNo = txtBillNo.Text;
            _lblParam.Name = txtPatientName.Text;
            _lblParam.Age = Utility.GetConcatenatedAge(txtYears.Text, txtMonths.Text, txtDays.Text);
            _lblParam.Sex = cmbGender.Text;
            _lblParam.MobileNo = txtMobileNo.Text;
            _lblParam.RefdBy = txtRefBy.Text;
            _lblParam.CabinNo = txtCabin.Text;
            _lblParam.EntryDate = dtpEntry.Value.ToString("dd/MM/yyyy");
            _lblParam.EntryTime = txtEntryTime.Text;
            

            _lblParam.Tests = GetTestsName();

            BarCodePrintHelper _bPrintHelper = new BarCodePrintHelper(_lblParam);
            _bPrintHelper.print(cmbPrinter.Text);
        }

        private string GetTestsName()
        {

            string _labelString = string.Empty;

            Patient _patient = (Patient)txtBillNo.Tag;

            foreach (DataGridViewRow row in dgTests.Rows)
            {
                if ((bool)row.Cells["Chk"].Value == true)
                {
                    ViewModelReportTests _seletedItem = (ViewModelReportTests)row.Tag;
                    if (String.IsNullOrEmpty(_labelString))
                    {
                        _labelString = _seletedItem.Name;

                    }else
                    {
                        _labelString = _labelString + ", "+ _seletedItem.Name;
                    }

                    if (_patient != null)
                    {
                        TestsCost _cost = new TestService().GetTestCostById(_patient.PatientId, _seletedItem.Id);
                        _cost.ReportStatus = ReportStatusEnum.OP.ToString();
                        new TestsCostService().UpdateReportStatusByTest(_cost);
                    }

                }
            }

            return _labelString;
        }
    }
}
