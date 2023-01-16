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
using HDMS.Model.OPD;
using HDMS.Service.OPD;
using HDMS.Model.Enums;

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

                Patient _PatientInfo = new PatientService().GetDiagPatientById(_billNo);

                if(_PatientInfo != null)
                {
                    txtDiagBillNo.Tag = _PatientInfo;
                    txtRegNo.Text = _PatientInfo.RegNo.ToString();

                    Doctor _d = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                    txtRefBy.Text = _d.Name;
                    txtRefBy.Tag = _d;
                    txtRefBy.Enabled = true;

                    txtRemarks.Text = _PatientInfo.DiscountCareOf;

                    List<PatientLedger> _pLedgerList = new PatientLedgerService().GetLedgerByPatientId(_PatientInfo.PatientId);

                    PatientLedger ledgerObj = _pLedgerList.Where(x => x.TransactionType == TransactionTypeEnum.TestCancelled.ToString()).FirstOrDefault();

                    if (ledgerObj != null)
                    {
                        txtRemaksCancelledTest.Text = ledgerObj.Remarks;
                    }


                    if (_PatientInfo.MediaId > 0)
                    {
                        BusinessMedia media = new DoctorService().getMediaById(_PatientInfo.MediaId);
                        if (media != null)
                        {
                            txtMedia.Text = media.Name;
                            txtMedia.Tag = media;
                        }
                    }
                    else
                    {
                        txtMedia.Text = "";
                        txtMedia.Tag = null;
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
                txtMotherName.Text = _record.MotherName;
                txtAddress.Text = _record.Address;
                txtSpouseName.Text = _record.SpouseName;
                cmbSex.Text= _record.Sex;
                txtAddress.Text = _record.Address;

                txtCareOf.Text = _record.CareOf;
                txtphoneNumbersNE.Text = _record.MobileNo;
                txtHouseNo.Text = _record.HouseNo;
                txtVillage.Text = _record.Village;
                txtRoadNo.Text = _record.RoadNo;
                txtPO.Text = _record.PO;
                txtPDistrict.Text = _record.District;
                txtPThana.Text = _record.ArearOrThana;

                txtLocalGurdianName.Text = _record.ContactPerson;
                txtLocalGurdianHouseNo.Text = _record.CPHouseNo;
                txtLocalGurdianVillage.Text = _record.CPVillage;
                txtLocalGurdianRoadNo.Text = _record.CPHouseNo;
                txtLocalGurdianPO.Text = _record.CPPo;
                cmbRelationshipWithPatient.Text = _record.RelationWithPatient;
                txtCPDistrict.Text = _record.CPDistrict;
                txtCPThana.Text = _record.CPArearOrThana;
                txtContactPersonNumber.Text = _record.CPMobile;
                txtEmailAddress.Text = _record.EmailId;

            }
        }

        private void txtHospitalBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtHospitalBillNo.Text, out _billNo);

                HospitalPatientInfo _PatientInfo = new HospitalService().GetHospitalPatientInfoById(_billNo);

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

                    if (_PatientInfo.MediaId > 0)
                    {
                        BusinessMedia media = new DoctorService().getMediaById(_PatientInfo.MediaId);
                        if (media != null)
                        {
                            txtMedia.Text = media.Name;
                            txtMedia.Tag = media;
                        }
                    }
                    else
                    {
                        txtMedia.Text = "";
                        txtMedia.Tag = null;
                    }
                   

                    LoadPatientInfo(_PatientInfo.RegNo);


                    HospitalBill _hbill = new HpFinancialService().GetHospitalBillByAdmissionId(_PatientInfo.AdmissionId);
                    if (_hbill != null)
                    {
                        txtRemarks.Text = _hbill.Remarks;
                    }
                    else
                    {
                        txtRemarks.Text = "";
                    }

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
                    _record.SpouseName = txtSpouseName.Text;
                    _record.PresentAddress = txtAddress.Text;
                    _record.CareOf = txtCareOf.Text;
                    _record.MobileNo = txtphoneNumbersNE.Text;
                    _record.HouseNo = txtHouseNo.Text;
                    _record.Village =  txtVillage.Text;
                    _record.RoadNo = txtRoadNo.Text;
                    _record.PO = txtPO.Text;
                    _record.District = txtPDistrict.Text;
                    _record.ArearOrThana = txtPThana.Text;

                    _record.ContactPerson = txtLocalGurdianName.Text;
                    _record.CPHouseNo = txtLocalGurdianHouseNo.Text;
                    _record.CPVillage = txtLocalGurdianVillage.Text;
                    _record.CPHouseNo = txtLocalGurdianRoadNo.Text;
                    _record.CPPo = txtLocalGurdianPO.Text;
                    _record.RelationWithPatient = cmbRelationshipWithPatient.Text;
                    _record.CPDistrict = txtCPDistrict.Text;
                    _record.CPArearOrThana = txtCPThana.Text;
                    _record.CPMobile = txtContactPersonNumber.Text;
                    _record.EmailId = txtEmailAddress.Text;

                    _record.PatientAddress = Utils.GetPatientAddress(txtCareOf.Text, txtHouseNo.Text, txtRoadNo.Text, txtVillage.Text, txtPO.Text, txtPDistrict.Text, txtPThana.Text);
                    _record.CPAddress = Utils.GetPatientAddress("", txtLocalGurdianHouseNo.Text, txtLocalGurdianRoadNo.Text, txtLocalGurdianVillage.Text, txtLocalGurdianPO.Text, txtCPDistrict.Text, txtCPThana.Text);


                    if (new RegRecordService().UpdateRegRecord(_record))
                    {
                        if (txtDiagBillNo.Tag != null)
                        {
                            Patient _p = (Patient)txtDiagBillNo.Tag;
                            _p.AgeYear = txtYears.Text;
                            _p.AgeMonth = txtMonths.Text;
                            _p.AgeDay = txtDays.Text;
                            _p.DiscountCareOf = txtRemarks.Text;

                            if(txtRefBy.Tag != null)
                            {
                                _p.DoctorId = ((Doctor)txtRefBy.Tag).DoctorId;
                            }
                            new PatientService().UpdatePatientInfo(_p);
                        }

                        if (txtOPDBillNo.Tag!=null)
                        {
                            OPDPatientRecord _O = (OPDPatientRecord)txtOPDBillNo.Tag;
                            _O.AgeYear = txtYears.Text;
                            _O.AgeMonth = txtMonths.Text;
                            _O.AgeDay = txtDays.Text;
                            _O.DiscountCareOf = txtRemarks.Text;
                            if (txtRefBy.Tag != null)
                            {
                                _O.DoctorId = ((Doctor)txtRefBy.Tag).DoctorId;
                            }
                            new PatientService().UpdateOPdPatientInfo(_O);

                        }

                        if (txtHospitalBillNo.Tag != null)
                        {
                            HospitalPatientInfo _hpInfo = (HospitalPatientInfo)txtHospitalBillNo.Tag;
                            _hpInfo.AgeYear = txtYears.Text;
                            _hpInfo.AgeMonth = txtMonths.Text;
                            _hpInfo.AgeDay = txtDays.Text;

                            if(txtRefBy.Tag != null)
                            {
                                _hpInfo.RefdDoctorId = ((Doctor)txtRefBy.Tag).DoctorId;
                            }

                            if (txtAssignedDoctor.Tag != null)
                            {
                                _hpInfo.AssignDoctorId = ((Doctor)txtAssignedDoctor.Tag).DoctorId;
                            }

                            if (txtMedia.Tag != null)
                            {
                                _hpInfo.MediaId = ((BusinessMedia)txtMedia.Tag).MediaId;
                            }

                            new HospitalService().UpdateHospitalPatientInfo(_hpInfo);

                            HospitalBill _hbill = new HpFinancialService().GetHospitalBillByAdmissionId(_hpInfo.AdmissionId);
                            if (_hbill != null)
                            {
                                _hbill.Remarks = txtRemarks.Text;
                                new HpFinancialService().UpdateHospitalBill(_hbill);
                            }

                        }

                        if (txtDiagBillNo.Tag != null)
                        {
                            Patient _patient = txtDiagBillNo.Tag as Patient;

                            if (txtMedia.Tag != null)
                            {
                                _patient.MediaId = ((BusinessMedia)txtMedia.Tag).MediaId;

                                new PatientService().UpdatePatientInfo(_patient);
                            }

                        }

                        MessageBox.Show("Update Patient Info Successfull");
                        txtDiagBillNo.Tag = null;
                        txtHospitalBillNo.Tag = null;
                        txtRefBy.Tag = null;
                        txtMedia.Tag = null;
                        //txtRefBy.Enabled = false;

                        ClearFields();
                    }

                }
            }
        }


        internal static string GetPatientAddress(string careOf, string _houseNo, string roadNo, string village, string po, string district, string _areaOrThanaha)
        {
            string _address = string.Format("{0}{1}{2}{3}{4}{5}{6}'", PrepareAddressString("Care of: ", careOf), PrepareAddressString("House No: ", _houseNo), PrepareAddressString("Road No", roadNo), PrepareAddressString("Village: ", village), PrepareAddressString("PO: ", po), PrepareAddressString("Area/Thana: ", _areaOrThanaha), PrepareAddressString("District: ", district));
            return _address;
        }

        private static string PrepareAddressString(string title, string _value)
        {
            if (!string.IsNullOrEmpty(_value)) return title + _value + ",";

            return "";
        }

        private void ClearFields()
        {
            txtPatientName.Text = "";
            txtYears.Text = "";
            txtMonths.Text = "";
            txtDays.Text = "";
            txtPhone.Text = "";

            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtAddress.Text = "";
            txtSpouseName.Text = "";
            cmbSex.Text = "";
            txtAddress.Text = "";

            txtCareOf.Text = "";
            txtphoneNumbersNE.Text = "";
            txtHouseNo.Text = "";
            txtVillage.Text = "";
            txtRoadNo.Text = "";
            txtPO.Text = "";
            txtPDistrict.Text = "";
            txtPThana.Text = "";

            txtLocalGurdianName.Text = "";
            txtLocalGurdianHouseNo.Text = "";
            txtLocalGurdianVillage.Text = "";
            txtLocalGurdianRoadNo.Text = "";
            txtLocalGurdianPO.Text = "";
            cmbRelationshipWithPatient.Text = "";
            txtCPDistrict.Text = "";
            txtCPThana.Text = "";
            txtContactPersonNumber.Text = "";
            txtEmailAddress.Text = "";
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
            ctlAssignedDoctor.Visible = false;
        }

        private void frmEditPatientBasicInfo_Load(object sender, EventArgs e)
        {
            ctrlDoctorSearch.Location = new Point(txtRefBy.Location.X, txtRefBy.Location.Y + txtRefBy.Height);
            ctrlDoctorSearch.ItemSelected += ctrlDoctorSearch_ItemSelected;

            ctlAssignedDoctor.Location = new Point(txtAssignedDoctor.Location.X, txtAssignedDoctor.Location.Y);
            ctlAssignedDoctor.ItemSelected += ctlAssignedDoctor_ItemSelected;

            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y);
            ctlMediaSearchControl.ItemSelected += ctlMediaSearchControl_ItemSelected;


            txtRefBy.Enabled = true;


            if (MainForm.LoggedinUser.RoleName == "Receiptionist")
            {
                txtMedia.Enabled = false;

            }
            else
            {
                txtMedia.Enabled = true;
            }

        }

        private void ctlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item;
            txtMedia.Focus();
            sender.Visible = false;
        }

        private void ctlAssignedDoctor_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtAssignedDoctor.Text = item.Name;
            txtAssignedDoctor.Tag = item;
            sender.Visible = false;

        }

        private void ctrlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtRefBy.Text = item.Name;
            txtRefBy.Tag = item;
            sender.Visible = false;
           
        }

        private void txtAssignedDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlAssignedDoctor.Visible = true;
                ctlAssignedDoctor.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {

                int id = 0;
                if (int.TryParse(txtAssignedDoctor.Text.Trim(), out id))
                {
                    txtAssignedDoctor.Text = new DoctorService().GetDoctorById(id).Name;
                    txtAssignedDoctor.Tag = new DoctorService().GetDoctorById(id);
                }
            }
        }

        private void txtMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlMediaSearchControl.Visible = true;
                ctlMediaSearchControl.LoadData();
            }
        }

        private void ctlMediaSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedia.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtOPDBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtOPDBillNo.Text, out _billNo);

                OPDPatientRecord _PatientInfo = new OPDPatientService().GetOPDPatientByBillNo(_billNo);

                if (_PatientInfo != null)
                {
                    txtOPDBillNo.Tag = _PatientInfo;
                    txtRegNo.Text = _PatientInfo.RegNo.ToString();

                    Doctor _d = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                    txtRefBy.Text = _d.Name;
                    txtRefBy.Tag = _d;
                    txtRefBy.Enabled = true;

                    //if (_PatientInfo.MediaId > 0)
                    //{
                    //    BusinessMedia media = new DoctorService().getMediaById(_PatientInfo.MediaId);
                    //    if (media != null)
                    //    {
                    //        txtMedia.Text = media.Name;
                    //        txtMedia.Tag = media;
                    //    }
                    //}
                    //else
                    //{
                    //    txtMedia.Text = "";
                    //    txtMedia.Tag = null;
                    //}


                    txtRemarks.Text = _PatientInfo.DiscountCareOf;

                    LoadPatientInfo(_PatientInfo.RegNo);


                }
                else
                {
                    MessageBox.Show("Patient not found.");
                }
            }
        }
  

    }
}
