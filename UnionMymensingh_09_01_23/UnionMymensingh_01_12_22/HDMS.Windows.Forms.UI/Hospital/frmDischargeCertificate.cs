using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using HDMS.Windows.Forms.UI.Rx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Rx;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Pharmacy;
using HDMS.Service.Rx;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Service.Diagonstics;
using HDMS.Model.Pharmacy.ViewModels;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmDischargeCertificate : Form
    {
        bool unlocked = true;

        public frmDischargeCertificate()
        {
            InitializeComponent();
            
        }

        
        private void btnDischargeCertificate_Click(object sender, EventArgs e)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)txtBillNo.Tag);
            if (_pInfo == null)
            {
                MessageBox.Show("Patient not selected."); return;
            }

            SaveDischargeDetails(_pInfo);

            ViewDischargeCertificate(_pInfo);

            ClearForm();
        }

        private void ClearForm()
        {
            txtBillNo.Tag = null;
            txtBillNo.Text = "";
            lblCabin.Text = "";
            lblName.Text = "";
            txtDiagnosis.Text = "";
            txtPersonalHistory.Text = "";
            txtInvestigations.Text = "";
            txtOTName.Text = "";
            txtOTType.Text = "";
            txtIndicationOfSurgery.Text = "";
            txtIncisionType.Text = "";
            txtAnaesthesiaType.Text = "";
            dgProducts.Rows.Clear();
            txtMedicalOfficer.Text = "";
            txtMedicalOfficer.Tag = null;
        }

        private void SaveDischargeDetails(VMIPDInfo _pInfo)
        {
            if (txtMedicalOfficer.Tag == null)
            {
                MessageBox.Show("Medical officer not selected."); return;

            }

            ReportConsultant _medicalOfficer = (ReportConsultant)txtMedicalOfficer.Tag;

            DischargeCertificateMaster _dcm = new DischargeCertificateMaster();
            _dcm.AdmissionId = _pInfo.AdmissionId;
            _dcm.RCId = _medicalOfficer.RCId;
            _dcm.DischareDate = Utils.GetServerDateAndTime();
            _dcm.DischargeTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
            _dcm.Remarks = "";
            _dcm.CertificateBy = MainForm.LoggedinUser.Name;

            long _dischargeId = new HospitalService().SaveDischargeMaster(_dcm);

            if (_dischargeId > 0)
            {

                int _displayOrder = 0;

                List<DischargeCertificateDetail> _dcdList = new List<DischargeCertificateDetail>();

                DischargeCertificateDetail _dcdetail = new DischargeCertificateDetail();
                _dcdetail.DischargeId = _dischargeId;
                _dcdetail.DescriptionTitle = "Diagnosis";
                _dcdetail.DescriptionLabel = "";
                _dcdetail.Description = txtDiagnosis.Text;
                _dcdetail.DisplayOrder = _displayOrder;

                _dcdList.Add(_dcdetail);

                _displayOrder = _displayOrder + 1;

                _dcdetail = new DischargeCertificateDetail();
                _dcdetail.DischargeId = _dischargeId;
                _dcdetail.DescriptionTitle = "Resume Of History";
                _dcdetail.DescriptionLabel = "";
                _dcdetail.Description = txtPersonalHistory.Text;
                _dcdetail.DisplayOrder = _displayOrder;

                _dcdList.Add(_dcdetail);

                _displayOrder = _displayOrder + 1;

                if (!String.IsNullOrEmpty(txtOTName.Text))
                {

                    OTSchedule _ots = new HospitalService().GetOTScheduleByAdmissionId(_pInfo.AdmissionId);

                    _dcdetail = new DischargeCertificateDetail();
                    _dcdetail.DischargeId = _dischargeId;
                    _dcdetail.DescriptionTitle = "Operation Note";
                    _dcdetail.DescriptionLabel = "Date :";
                    _dcdetail.Description = _ots.OEDate.ToString("dd/MM/yyyy");
                    _dcdetail.DisplayOrder = _displayOrder;

                    _dcdList.Add(_dcdetail);

                

                    _dcdetail = new DischargeCertificateDetail();
                    _dcdetail.DischargeId = _dischargeId;
                    _dcdetail.DescriptionTitle = "Operation Note";
                    _dcdetail.DescriptionLabel = "Time :";
                    _dcdetail.Description = _ots.OETime;
                    _dcdetail.DisplayOrder = _displayOrder;
                    _dcdList.Add(_dcdetail);

                   

                    _dcdetail = new DischargeCertificateDetail();
                    _dcdetail.DischargeId = _dischargeId;
                    _dcdetail.DescriptionTitle = "Operation Note";
                    _dcdetail.DescriptionLabel = "Type of Anaesthesia :";
                    _dcdetail.Description = _ots.AnaesthesiaType;
                    _dcdetail.DisplayOrder = _displayOrder;
                    _dcdList.Add(_dcdetail);

                    List<OTExecutionDetail> _surgeonDetail = new HospitalService().GetOTSurgeon(_ots.OTId);
                    foreach (var item in _surgeonDetail)
                    {
                        Doctor _doc = new DoctorService().GetDoctorById(item.DoctorId);
                    
                        _dcdetail = new DischargeCertificateDetail();
                        _dcdetail.DischargeId = _dischargeId;
                        _dcdetail.DescriptionTitle = "Operation Note";
                        _dcdetail.DescriptionLabel = "Surgeon's Name :";
                        _dcdetail.Description = _doc.Name;
                        _dcdetail.DisplayOrder = _displayOrder;
                        _dcdList.Add(_dcdetail);
                    }

                    List<OTExecutionDetail> _anaesthesiaDetail = new HospitalService().GetOTAnaesthetists(_ots.OTId);

                    foreach (var item in _anaesthesiaDetail)
                    {
                        Doctor _doc = new DoctorService().GetDoctorById(item.DoctorId);
                    

                        _dcdetail = new DischargeCertificateDetail();
                        _dcdetail.DischargeId = _dischargeId;
                        _dcdetail.DescriptionTitle = "Operation Note";
                        _dcdetail.DescriptionLabel = "Anaesthetists Name :";
                        _dcdetail.Description = _doc.Name;
                        _dcdetail.DisplayOrder = _displayOrder;
                        _dcdList.Add(_dcdetail);
                    }

                    List<OTExecutionDetail> _assistantSurgeonDetail = new HospitalService().GetOTAssistantSurgeonDetail(_ots.OTId);
                    foreach (var item in _assistantSurgeonDetail)
                    {
                        Doctor _doc = new DoctorService().GetDoctorById(item.DoctorId);
                     

                        _dcdetail = new DischargeCertificateDetail();
                        _dcdetail.DischargeId = _dischargeId;
                        _dcdetail.DescriptionTitle = "Operation Note";
                        _dcdetail.DescriptionLabel = "Assistant Surgeon :";
                        _dcdetail.Description = _doc.Name;
                        _dcdetail.DisplayOrder = _displayOrder;

                        _dcdList.Add(_dcdetail);
                    }
                }

                _displayOrder = _displayOrder + 1;

                _dcdetail = new DischargeCertificateDetail();
                _dcdetail.DischargeId = _dischargeId;
                _dcdetail.DescriptionTitle = "Investigations";
                _dcdetail.DescriptionLabel = "";
                _dcdetail.Description = txtInvestigations.Text;
                _dcdetail.DisplayOrder = _displayOrder;

                _dcdList.Add(_dcdetail);

                if (_dcdList.Count > 0)
                {
                    new HospitalService().SaveDischargeDetails(_dcdList);
                }


                if (dgProducts.Rows.Count > 0)
                {
                    List<TreatmentOnDischarge> _treatmentList = new List<TreatmentOnDischarge>();
                    foreach (DataGridViewRow row in dgProducts.Rows)
                    {
                        SelectedMedicineForPatientOnDischarge selectedMed = row.Tag as SelectedMedicineForPatientOnDischarge;
                        TreatmentOnDischarge _tod = new TreatmentOnDischarge();
                        _tod.AdmissionId = _pInfo.AdmissionId;
                        _tod.MedicineId = selectedMed.Id;
                        _tod.MedicineName = selectedMed.Name;
                        _tod.Dosage = selectedMed.dosage;
                        _tod.Duration = selectedMed.duration;
                        _tod.Unit = selectedMed.Unit;
                        _treatmentList.Add(_tod);
                    }


                    if (_treatmentList.Count > 0)
                    {
                        new HospitalService().SaveTreatmentOnDischarge(_treatmentList);
                    }
                }

            }


        }

        private void ViewDischargeCertificate(VMIPDInfo _pInfo)
        {


            // DataSet ds = new HospitalReportService().GetPatientBasicInfoByAdmissionId(_pInfo.AdmissionId);

            DataSet ds = new HospitalReportService().GetDischargeData(_pInfo.AdmissionId);

            rptDischargeCertificate _rpt = new rptDischargeCertificate();

            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("CabinNo", lblCabin.Text);
            _rpt.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());

            // Header and Footer Settings
            _rpt.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);

            _rpt.SetParameterValue("BillNo", _pInfo.BillNo);
            _rpt.SetParameterValue("Name", _pInfo.Name);
            _rpt.SetParameterValue("AdmDate", _pInfo.AddmissionDate.ToString("dd/MM/yyyy"));

            _rpt.SetParameterValue("Age", _pInfo.Age);
            _rpt.SetParameterValue("MobileNo", _pInfo.MobileNo);
            _rpt.SetParameterValue("RefdBy", _pInfo.RefDoctor);
            _rpt.SetParameterValue("Gender", _pInfo.Gender);
            


            if (Configuration.ORG_CODE == "1")
            {
                _rpt.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                _rpt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rpt.SetParameterValue("footnote", ComapnyDetail.footNote1);
            }
            else
            {
                _rpt.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rpt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rpt.SetParameterValue("footnote", ComapnyDetail.footNote2);
            }

            ReportConsultant _consultant = (ReportConsultant)txtMedicalOfficer.Tag;


           _rpt.SetParameterValue("MedicalOfficer", _consultant.Name);
           _rpt.SetParameterValue("IdentityLine1", _consultant.DIdentityLine1);
           _rpt.SetParameterValue("IdentityLine2", _consultant.DIdentityLine2);
           _rpt.SetParameterValue("IdentityLine3", _consultant.DIdentityLine3);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private IList<SelectedMedicineForPatientOnDischarge> _SelectedMedicines;
      

        private void frmDischargeCertificate_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            _SelectedMedicines = new List<SelectedMedicineForPatientOnDischarge>();


            ctrlDiagnosisSearch.Location = new Point(txtSearchDiagnosis.Location.X, txtSearchDiagnosis.Location.Y + txtSearchDiagnosis.Height);
            ctrlDiagnosisSearch.ItemSelected += CtrlDiagnosisSearch_ItemSelected;

         

            ctrlDosageSearch.Location = new Point(txtDosages.Location.X, txtDosages.Location.Y + txtDosages.Height);
            ctrlDosageSearch.ItemSelected += ctrlDosageSearch_ItemSelected;

            ctrlMedicineSearchControl.Location = new Point(txtMedicine.Location.X, txtMedicine.Location.Y + txtMedicine.Height);
            ctrlMedicineSearchControl.ItemSelected += ctrlMedicineSearchControl_ItemSelected;

            ctrlMedicalOfficerSearchControl.Location = new Point(txtMedicalOfficer.Location.X, txtMedicalOfficer.Location.Y + txtMedicalOfficer.Height);
            ctrlMedicalOfficerSearchControl.ItemSelected += ctrlMedicalOfficerSearchControl_ItemSelected;

            ctrlHpPatientSearch.Location = new Point(txtBillNo.Location.X, txtBillNo.Location.Y + txtBillNo.Height);
            ctrlHpPatientSearch.ItemSelected += ctrlHpPatientSearch_ItemSelected;

            LoadPatients();


            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }
        }

        private void ctrlHpPatientSearch_ItemSelected(SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
            txtBillNo.Text = item.BillNo.ToString();
            txtBillNo.Tag = item;
            lblName.Text = item.Name;
            lblCabin.Text = item.BedCabinNo;
            LoadDischargeDetails(item);
            sender.Visible = false;
            txtBillNo.Focus();
        }

        private void ctrlMedicalOfficerSearchControl_ItemSelected(SearchResultListControl<ReportConsultant> sender, ReportConsultant item)
        {
            txtMedicalOfficer.Text = item.Name;
            txtMedicalOfficer.Tag = item;
            sender.Visible = false;
            txtMedicalOfficer.Focus();
        }

        private void ctrlMedicineSearchControl_ItemSelected(SearchResultListControlForPharmacy<VWPhProductListForSale> sender, VWPhProductListForSale item)
        {
            txtMedicine.Text = item.BrandName;

            PhProductInfo _pInfo = new PhProductService().GetProductById(item.ProductId);

            txtMedicine.Tag = _pInfo;
            sender.Visible = false;
            txtMedicine.Focus();
        }

        private void ctrlDosageSearch_ItemSelected(SearchResultListControl<RxDosage> sender, RxDosage item)
        {
            txtDosages.Text = item.DoseBnLong;
            txtDosages.Tag = item;
            sender.Visible = false;
            txtDosages.Focus();
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

            ctrl.BackColor = Color.NavajoWhite;
        }


        private void HideAllDefaultHidden()
        {
            ctrlDiagnosisSearch.Visible = false;
           
            ctrlDosageSearch.Visible = false;
            ctrlMedicineSearchControl.Visible = false;
            ctrlHpPatientSearch.Visible = false;
            ctrlMedicalOfficerSearchControl.Visible = false;

        }

        private void CtrlDiagnosisSearch_ItemSelected(Controls.SearchResultListControl<Model.Rx.RxDiagnosis> sender, Model.Rx.RxDiagnosis item)
        {
            txtSearchDiagnosis.Text = item.Name;
            txtSearchDiagnosis.Tag = item;
            sender.Visible = false;
            txtSearchDiagnosis.Focus();
        }

        private void LoadPatients()
        {
           // List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfo().ToList();

            
        }

       
       

        private void LoadDischargeDetails(VMIPDInfo _pInfo)
        {

            OTSchedule _ots = new OTService().GetOTSchedule(_pInfo.AdmissionId);
            if (_ots != null)
            {
                txtOTName.Text = _ots.OTName;

                txtIndicationOfSurgery.Text = _ots.IndicationOfSurgery;
                txtIncisionType.Text = _ots.IncisionType;
                txtAnaesthesiaType.Text = _ots.AnaesthesiaType;
                txtOTType.Text = _ots.OTType;
            }

            List<VMInvestigationList> _InvestigationList = new TestService().GetIPDPatientInvestigations(_pInfo.BillNo);

            if(_InvestigationList != null && _InvestigationList.Count > 0)
            {
                string _investigations = Utils.GetIPDInvestigations(_InvestigationList);
                txtInvestigations.Text = _investigations;
            }

        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            frmAddDiagnosisTemplate _frm = new frmAddDiagnosisTemplate();
            _frm.Show();
        }

        private void txtSearchDiagnosis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlDiagnosisSearch.Visible = true;
                ctrlDiagnosisSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtSearchDiagnosis.Text))
                {
                    if (!String.IsNullOrEmpty(txtDiagnosis.Text))
                    {
                        txtDiagnosis.Text = txtDiagnosis.Text+", "+txtSearchDiagnosis.Text;
                    }
                    else
                    {
                        txtDiagnosis.Text = txtSearchDiagnosis.Text;
                    }
                  
                }
            }
        }

        private void btnAddResumeOfHistory_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearchROH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
              
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtSearchROH.Text))
                {
                    if (!String.IsNullOrEmpty(txtPersonalHistory.Text))
                    {
                        txtPersonalHistory.Text = txtSearchROH.Text + ", " + txtSearchROH.Text;
                    }
                    else
                    {
                        txtPersonalHistory.Text = txtSearchROH.Text;
                    }

                }
            }
        }

        private void txtDosages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlDosageSearch.Visible = true;
                ctrlDosageSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDuration.Focus();
            }
        }

        private void btnAddDosage_Click(object sender, EventArgs e)
        {
            frmAddCpDosageTemplate _frm = new frmAddCpDosageTemplate();
            _frm.Show();
        }

        private void ctrlDosageSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDosages.Focus();
            }
        }

        private void ctrlResumeOfHistory_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtSearchROH.Focus();
            }
        }

        private void ctrlDiagnosisSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDiagnosis.Focus();
            }
        }

        private void txtMedicine_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtMedicine.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    string _outLet = string.Empty;

                    if (Configuration.ORG_CODE == "2")
                    {
                        _outLet = "2";
                    }else
                    {
                        _outLet = "1";
                    }

                    ctrlMedicineSearchControl.Visible = true;
                    ctrlMedicineSearchControl.txtSearch.Text = _txt;
                    ctrlMedicineSearchControl.txtSearch.SelectionStart = ctrlMedicineSearchControl.txtSearch.Text.Length;

                    ctrlMedicineSearchControl.LoadDataByType(_txt + ">" + _outLet); // Out let Id appended for outlet specific product loading
                }
            }
        }

        private void txtMedicine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDosages.Focus();
            }
        }

        private void ctrlMedicineSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedicine.Focus();
            }
        }

        private void ctrlDosageSearch_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDosages.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMedicine.Tag != null)
            {
                new RxService().PopulateSelectedProductDataForIPDPatient(_SelectedMedicines, txtMedicine.Tag as VWPhProductList, ((VWPhProductList)txtMedicine.Tag).ProductId.ToString(), null, null, txtDuration.Text, null, true);
                FillProductGrid();
                txtDuration.Text = "";
                txtDosages.Text = "";
                unlocked = false;
                txtMedicine.Text = "";
                txtMedicine.Focus();
                unlocked = true;
            }
        }

        private void FillProductGrid()
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            int _count = 0;
            foreach (SelectedMedicineForPatientOnDischarge item in _SelectedMedicines)
            {
                _count++;
                DataGridViewRow row2 = new DataGridViewRow();
                row2.Height = 35;
                row2.Tag = item;

                row2.CreateCells(dgProducts, item.Name, item.dosage, item.duration, item.Unit, item.Id, _count);
                dgProducts.Rows.Add(row2);
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbUnit.Focus();
            }
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlHpPatientSearch.Visible = true;
                ctrlHpPatientSearch.LoadData();
            }

            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    VMIPDInfo _ipdInfo= new HospitalService().
            //}
        }

        private void ctrlHpPatientSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBillNo.Focus();
            }
        }

        private void ctrlMedicalOfficerSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedicalOfficer.Focus();
            }
        }

        private void txtMedicalOfficer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlMedicalOfficerSearchControl.Visible = true;
                ctrlMedicalOfficerSearchControl.LoadData();
            }
        }

        private void cmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void ctrlMedicineSearchControl_Load(object sender, EventArgs e)
        {

        }
    }
}
