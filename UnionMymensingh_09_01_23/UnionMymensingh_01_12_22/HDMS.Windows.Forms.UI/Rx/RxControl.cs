using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Model.ViewModel;
using HDMS.Model;
using HDMS.Service.Rx;
using HDMS.Service.Doctors;
using HDMS.Model.Rx;
using HDMS.Windows.Forms.UI.Reports.Rx;
using CrystalDecisions.Windows.Forms;
using System.IO;
using DSBarCode;
using HDMS.Model.Pharmacy;
using HDMS.Models.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Common.Utils;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Rx.VModel;
using HDMS.Model.Enums;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class RxControl : UserControl
    {
        public event EntryCompletedEventHandler EntryCompleted;

        bool unlocked = true;
        bool isInMaxView = false;
        bool isPatientHistoryMaxPanel = true;
        bool isBlankNeeded = true;
        bool IsTestTemplateSearch = false;
        string WrittenCommitedHistoryText = string.Empty;
        string NewSearchHistoryText = string.Empty;

        TextBox selectedTextBox = new TextBox();
        public static ChamberPractitioner consultant = new ChamberPractitioner();

        public RxControl(ChamberPractitioner _Practitioner)
        {
            InitializeComponent();
            this.dgProducts.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13, FontStyle.Regular);
            this.dgProducts.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("SutonnyMJ", 13, FontStyle.Regular);
            this.dgProducts.Columns[2].DefaultCellStyle.Font = new System.Drawing.Font("SutonnyMJ", 13, FontStyle.Regular);


            this.dgTests.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13, FontStyle.Regular);
            this.dgTests.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13, FontStyle.Regular);

            this.dgProducts.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dgProducts.DefaultCellStyle.SelectionBackColor = Color.Black;

            consultant = _Practitioner;

            UpdateFont();


        }

        private void UpdateFont()
        {
            //Change cell font
            //foreach (DataGridViewColumn c in dgRegisteredMember.Columns)
            //{
            //    c.DefaultCellStyle.Font = new Font("Segoe UI", 12.5F, GraphicsUnit.Pixel);

            //}

            //dgRegisteredMember.Font = new Font("Segoe UI", 12.5F, GraphicsUnit.Pixel);
        }

        public delegate void EntryCompletedEventHandler(object sender);

        private IList<SelectedTestItemsForPatient> _SelectedTests;
        private IList<SelectedMedicineForPatient> _SelectedProducts;
        private IList<SelectedAdvice> _SelectedAdvices;
        private void RxControl_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            _SelectedTests = new List<SelectedTestItemsForPatient>();
            _SelectedProducts = new List<SelectedMedicineForPatient>();
            _SelectedAdvices = new List<SelectedAdvice>();

            //ctrlDiagnosisSearch.Location = new Point(txtSearchDiagnosis.Location.X, txtSearchDiagnosis.Location.Y + txtSearchDiagnosis.Height);
            //ctrlDiagnosisSearch.ItemSelected += CtrlDiagnosisSearch_ItemSelected;

            //ctrlResumeOfHistory.Location = new Point(txtPastHistory.Location.X, txtPastHistory.Location.Y + txtPastHistory.Height-20);
            //ctrlResumeOfHistory.ItemSelected += ctrlResumeOfHistory_ItemSelected;


            ctlTestSearch.Location = new Point(txtInvestigation.Location.X, txtInvestigation.Location.Y + txtInvestigation.Height);
            ctlTestSearch.ItemSelected += ctlTestSearch_ItemSelected;
            ctlProductSearch.Location = new Point(txtMedicine.Location.X, txtMedicine.Location.Y + txtMedicine.Height);
            ctlProductSearch.ItemSelected += ctlProductSearch_ItemSelected;

            ctrlPhProductSearchByGen.Location = new Point(txtGeneric.Location.X, txtGeneric.Location.Y + txtGeneric.Height);
            ctrlPhProductSearchByGen.ItemSelected += ctrlPhProductSearchByGen_ItemSelected;

            ctrlHistorySearchControl.ItemSelected += ctrlHistorySearchControl_ItemSelected;

            ctrlPhysicalExamItemSearchControl.ItemSelected += ctrlPhysicalExamItemSearchControl_ItemSelected;


            crtlTestTemplateSearchControl.Location = new Point(txtInvestigation.Location.X, txtInvestigation.Location.Y + txtInvestigation.Height);
            crtlTestTemplateSearchControl.ItemSelected += crtlTestTemplateSearchControl_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            //Doctor _doctor = new DoctorService().GetDoctorByUserId(MainForm.LoggedinUser.UserId);
            if (consultant != null)
            {
                txtRxBy.Text = consultant.Name;
                txtRxBy.Tag = consultant;
            }
            else
            {
                txtRxBy.Text = "";
                txtRxBy.Tag = null;
            }

            List<RxDosage> _dosage = new RxService().GetDosages(consultant.CPId);
            List<RxDuration> _duration = new RxService().GetRxDuration();

            cmbDosage.DataSource = _dosage;
            cmbDosage.DisplayMember = "ShortDescription";
            cmbDosage.ValueMember = "DoseId";

            cmbDuration.DataSource = _duration;
            cmbDuration.DisplayMember = "Name";
            cmbDuration.ValueMember = "DurationId";

            LoadAdvices(consultant.CPId);


            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;


            LoadPatients();

            SetPatientHistoryPanel();

        }

        private void crtlTestTemplateSearchControl_ItemSelected(SearchResultListControl<RxTestTemplateMaster> sender, RxTestTemplateMaster item)
        {
            unlocked = false;
            txtInvestigation.Text = item.Name;

            txtInvestigation.Tag = item;
            txtInvestigation.Focus();

            LoadTemplateTests(item.TemplateId);

            sender.Visible = false;
            unlocked = true;
        }

        private void LoadTemplateTests(long templateId)
        {
            List<SelectedTestItemsForPatient> _testTemplate = new RxService().GetRxTestTemplateItem(templateId);
            foreach (var item in _testTemplate)
            {
                _SelectedTests.Add(item);
            }
            FillTestGrid(_SelectedTests);
        }

        private void ctrlPhysicalExamItemSearchControl_ItemSelected(SearchResultListControl<RxGeneralPhysicalExamSubItem> sender, RxGeneralPhysicalExamSubItem item)
        {
            isBlankNeeded = false;

            if (!String.IsNullOrEmpty(selectedTextBox.Text))
            {
                selectedTextBox.Text = selectedTextBox.Text + ", " + item.SubItemName;
            }
            else
            {
                selectedTextBox.Text = item.SubItemName;
            }

            WrittenCommitedHistoryText = selectedTextBox.Text;

            selectedTextBox.Tag = item;
            sender.Visible = false;

            selectedTextBox.SelectionStart = selectedTextBox.Text.Length;
            selectedTextBox.SelectionLength = 0;

            selectedTextBox.Focus();
        }

        private void ctrlHistorySearchControl_ItemSelected(SearchResultListControl<RxPatientHistorySubItem> sender, RxPatientHistorySubItem item)
        {
            isBlankNeeded = false;

            if (!String.IsNullOrEmpty(selectedTextBox.Text))
            {
                selectedTextBox.Text = selectedTextBox.Text + ", " + item.SubItemName;
            }
            else
            {
                selectedTextBox.Text = item.SubItemName;
            }

            WrittenCommitedHistoryText = selectedTextBox.Text;

            selectedTextBox.Tag = item;
            sender.Visible = false;

            selectedTextBox.SelectionStart = selectedTextBox.Text.Length;
            selectedTextBox.SelectionLength = 0;

            selectedTextBox.Focus();
        }

        private void SetPatientHistoryPanel()
        {
            pnlPatientHistory.Location = new Point(0, 0);

            pnlPatient.Location = new Point(1275, 65);
            btnMaxView.Visible = true;
            isInMaxView = false;

            isPatientHistoryMaxPanel = true;

            btnPatientHistoryPanel.Text = "<< <<";
        }

        private void LoadPatients()
        {
            List<RxVMPatientBasicInfo> _rxpList = new RxService().GetRxPatientList(dtpfrm.Value, dtpto.Value);
            FillRxPatientGrid(_rxpList);
            lblTotalPatient.Text = _rxpList.Count.ToString();
        }

        private void FillRxPatientGrid(List<RxVMPatientBasicInfo> _rxpList)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (var item in _rxpList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgPatient, item.RxId, item.Name, item.MobileNo, item.Date.ToString("dd/MM/yyyy"),item.VisitStatus);
                dgPatient.Rows.Add(row);
            }
        }

        private void ctrlPhProductSearchByGen_ItemSelected(SearchResultListControl<VWPhProductList> sender, VWPhProductList item)
        {
            unlocked = false;
            txtGeneric.Text = item.GenericName;
            txtMedicine.Text = item.BrandName;
            txtMedicine.Tag = item;
            cmbDosage.Focus();
            sender.Visible = false;
            unlocked = true;

        }



        private void LoadAdvices(int _CpId)
        {
            List<RxSavedAdvice> _advices = new RxService().GetAdvicesByCP(_CpId);
            _advices.Insert(0, new RxSavedAdvice() { Id = 0, Advice = "Select Advice" });
            cmbAdvices.DataSource = _advices;
            cmbAdvices.DisplayMember = "Advice";
            cmbAdvices.ValueMember = "Id";
        }

        private void ctlProductSearch_ItemSelected(Controls.SearchResultListControl<VWPhProductList> sender, VWPhProductList item)
        {
            unlocked = false;
            txtMedicine.Text = item.BrandName;
            txtGeneric.Text = item.GenericName;
            txtMedicine.Tag = item;
            cmbDosage.Focus();
            sender.Visible = false;
            unlocked = true;
        }



        void ctlTestSearch_ItemSelected(Controls.SearchResultListControl<Model.TestItem> sender, Model.TestItem item)
        {
            txtInvestigation.Text = item.TestId.ToString();
            txtInvestigation.Tag = item;
            txtInvestigation.Focus();
            sender.Visible = false;
            ctlTestSearch.Visible = false;
            new RxService().PopulateSelectedTestData(_SelectedTests, txtInvestigation.Tag as TestItem, txtInvestigation.Text);
            FillTestGrid(_SelectedTests);

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

        private void txtDiagnosis_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FillTestGrid(IList<SelectedTestItemsForPatient> _SelectedTests)
        {
            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach (SelectedTestItemsForPatient item in _SelectedTests)
            {
                DataGridViewRow row1 = new DataGridViewRow();
                row1.Height = 35;
                row1.Tag = item;
                row1.CreateCells(dgTests, item.Id, item.Name, item.DeliveryDate, item.DeliveryTime, item.Cost, false);
                dgTests.Rows.Add(row1);
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearch.Visible = false;
            ctrlPhProductSearchByGen.Visible = false;
            ctlTestSearch.Visible = false;
            ctrlHistorySearchControl.Visible = false;

        }

        private void txtMedicine_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Space)
            //{
            //    HideAllDefaultHidden();
            //    ctlProductSearch.Visible = true;
            //    ctlProductSearch.LoadDataByType("");
            //}
            //else if (e.KeyChar == (char)Keys.Enter)
            //{
            //    ctlProductSearch.Visible = false;

            //}
        }



        private void FillProductGrid(IList<SelectedMedicineForPatient> _SelectedProducts)
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            int _count = 0;
            foreach (SelectedMedicineForPatient item in _SelectedProducts)
            {
                _count++;
                DataGridViewRow row2 = new DataGridViewRow();
                row2.Height = 35;
                row2.Tag = item;

                row2.CreateCells(dgProducts, item.Name, item.dosage, item.duration, item.Id, _count);
                dgProducts.Rows.Add(row2);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtMedicine.Tag != null)
            {
                new RxService().PopulateSelectedProductData(_SelectedProducts, txtMedicine.Tag as VWPhProductList, ((VWPhProductList)txtMedicine.Tag).ProductId.ToString(), cmbDosage.Text, cmbBeforeAfter.Text, cmbDuration.Text);
                FillProductGrid(_SelectedProducts);

                cmbDuration.Text = "";
                cmbBeforeAfter.Text = "";
                cmbDosage.Text = "";
                txtMedicine.Text = "";
                txtGeneric.Text = "";
                txtMedicine.Focus();

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCC _frmSymtomps = new frmCC();
            _frmSymtomps.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            string _message = CheckRequiredInformation();

            int _practitionerId = 0;
            int _refDocId = 0;

            if (txtRxBy.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)txtRxBy.Tag;
                _practitionerId = _prac.CPId;
                _refDocId = _prac.DoctorId;
            }


            if (String.IsNullOrEmpty(_message))
            {

                RegRecord _regTracker = GetRegNoLong();
                txtRegNo.Text = _regTracker.RegNo.ToString();

                RxPatientInfo _patientinfo = new RxPatientInfo();
                _patientinfo.AgeYear = txtYears.Text;
                _patientinfo.AgeMonth = txtMonths.Text;
                _patientinfo.AgeDay = txtDays.Text;
                _patientinfo.RegNo = _regTracker.RegNo;
                _patientinfo.RxDate = Utils.GetServerDateAndTime();
                _patientinfo.RxTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");



                _patientinfo.CPId = _practitionerId;
                _patientinfo.PractitionerRefdDoctorId = _refDocId;


                _patientinfo.PatientType = "OPD";
                _patientinfo.OperateBy = MainForm.LoggedinUser.UserId;

                long _RxId = new RxService().SaveRxPatient(_patientinfo);

                if (_RxId > 0)
                {
                    List<RxTest> _listrxDiagnosis = new List<RxTest>();
                    List<RxDrug> _listrxDrugs = new List<RxDrug>();
                    List<RxAdviceToPatient> _adviceList = new List<RxAdviceToPatient>();

                    foreach (DataGridViewRow row in dgTests.Rows)
                    {
                        SelectedTestItemsForPatient selectedTests = row.Tag as SelectedTestItemsForPatient;
                        RxTest _rxDiag = new RxTest();
                        _rxDiag.RxId = _RxId;
                        _rxDiag.TestId = selectedTests.Id;

                        _listrxDiagnosis.Add(_rxDiag);

                    }

                    bool isDiagnosisSaved = new RxService().SaveRxTestSaved(_listrxDiagnosis);


                    foreach (DataGridViewRow row in dgProducts.Rows)
                    {
                        SelectedMedicineForPatient selectedProduct = row.Tag as SelectedMedicineForPatient;
                        RxDrug _rxDiag = new RxDrug();
                        _rxDiag.RxId = _RxId;
                        _rxDiag.ProductId = selectedProduct.Id;
                        _rxDiag.dosage = selectedProduct.dosage;
                        _rxDiag.duration = selectedProduct.duration;

                        _listrxDrugs.Add(_rxDiag);

                    }

                    bool isDrugSaved = new RxService().SaveDrug(_listrxDrugs);


                    foreach (DataGridViewRow row in dgAdvices.Rows)
                    {
                        SelectedAdvice selectedAdvice = row.Tag as SelectedAdvice;
                        RxAdviceToPatient _rxAdvice = new RxAdviceToPatient();
                        _rxAdvice.RxId = _RxId;
                        _rxAdvice.AdviceId = selectedAdvice.AdviceId;

                        _adviceList.Add(_rxAdvice);

                    }

                    if (_adviceList.Count > 0)
                        new RxService().SaveAdvices(_adviceList);


                    if (isDiagnosisSaved && isDrugSaved)
                    {
                        MessageBox.Show("Record saved successfully.");
                        ViewRxReport(_RxId);
                        LoadPatients();
                    }
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show(_message);
            }
        }

        private string CheckRequiredInformation()
        {
            string msg = string.Empty;

            if (String.IsNullOrEmpty(txtMobileNo.Text))
            {
                msg = "Mobile No";
            }


            if (String.IsNullOrEmpty(txtPatientName.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Patient Name";
                }
                else
                {
                    msg = msg + ", Patient Name";
                }
            }

            int _ageY = 0;
            int _ageM = 0;
            int _ageD = 0;

            int.TryParse(txtYears.Text, out _ageY);
            int.TryParse(txtMonths.Text, out _ageM);
            int.TryParse(txtDays.Text, out _ageD);

            if (_ageY == 0 && _ageM == 0 && _ageD == 0)
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Age";
                }
                else
                {
                    msg = msg + ", Age";
                }
            }

            if (String.IsNullOrEmpty(cmbGender.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Sex";
                }
                else
                {
                    msg = msg + ", Sex";
                }
            }

            if (String.IsNullOrEmpty(txtRxBy.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Rx By";
                }
                else
                {
                    msg = msg + ", Rx By";
                }
            }


            if (String.IsNullOrEmpty(msg))
            {
                return msg;
            }
            else
            {
                return msg + " Required.";
            }


        }

        private RegRecord GetRegNoLong()
        {
            long _regNo = 0;


            //RegUniqueKeyTracker _regTracker = GetNewRegNo();
            // txtRegNo.Text = 0;


            long.TryParse(txtRegNo.Text, out _regNo);

            RegRecord _rrecord = new RegRecordService().GetRegRecordByRegNo(_regNo);

            if (_rrecord != null)
            {
                return _rrecord;
            }
            else
            {

                RegRecord _rgRecord = new RegRecord();
                _rgRecord.RegNo = 0;
                _rgRecord.FullName = txtPatientName.Text;
                if (!String.IsNullOrWhiteSpace(txtYears.Text))
                {
                    int _yrs = 0;
                    int.TryParse(txtYears.Text, out _yrs);
                    if (_yrs > 0)
                    {
                        _rgRecord.AgeYear = txtYears.Text.Trim();
                    }
                    else
                    {
                        _rgRecord.AgeYear = string.Empty;
                    }

                }
                else
                {
                    _rgRecord.AgeYear = string.Empty;
                }

                if (!String.IsNullOrWhiteSpace(txtMonths.Text))
                {
                    int _mnths = 0;
                    int.TryParse(txtMonths.Text, out _mnths);
                    if (_mnths > 0)
                    {
                        _rgRecord.AgeMonth = txtMonths.Text.Trim();
                    }
                    else
                    {
                        _rgRecord.AgeMonth = string.Empty;
                    }

                }
                else
                {
                    _rgRecord.AgeMonth = string.Empty;
                }

                if (!String.IsNullOrWhiteSpace(txtDays.Text))
                {
                    int _dys = 0;
                    int.TryParse(txtDays.Text, out _dys);
                    if (_dys > 0)
                    {
                        _rgRecord.AgeDay = txtDays.Text.Trim();
                    }
                    else
                    {
                        _rgRecord.AgeDay = string.Empty;
                    }

                }
                else
                {
                    _rgRecord.AgeDay = string.Empty;
                }

                _rgRecord.Sex = cmbGender.Text;
                _rgRecord.CountryCode = "";
                _rgRecord.MobileNo = txtMobileNo.Text;
                _rgRecord.DOB = GetDob();

                RegRecord _record = new RegRecordService().SaveRegRecord(_rgRecord);


                _record = new RegRecordService().GetRegRecordById(_record.Id);

                return _record;

            }

        }

        private string GetNewRegNo()
        {
            string _regPart1 = Utils.GetRegNo();
            long _regNo = new Random().Next(1000, 9999);
            string _regPart2 = _regNo.ToString() + "1";

            string _RegNo = _regPart1 + _regPart2;

            if (!new RegRecordService().IsRegAlloted(Convert.ToInt64(_RegNo)))
            {
                return _RegNo.ToString();
            }

            GetNewRegNo();

            return "";
        }


        private DateTime GetDob()
        {
            int yrs = 0, mnths = 0, dys = 0;
            int.TryParse(txtYears.Text, out yrs);
            int.TryParse(txtMonths.Text, out mnths);
            int.TryParse(txtDays.Text, out dys);

            DateTime _dt = DateTime.Now;
            _dt = _dt.AddYears(0 - yrs);
            _dt = _dt.AddMonths(0 - mnths);
            _dt = _dt.AddDays(0 - dys);

            return _dt;
        }

        private bool LoadPrescribedRegPatientInfo(long _regNo)
        {
            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
            if (_record != null)
            {
                txtPatientName.Text = _record.FullName;

                txtMobileNo.Text = _record.MobileNo;
                cmbGender.Text = _record.Sex;
                cmbMaritalStatus.Text = _record.MaritalStatus;
                return true;
            }

            return false;
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
                txtMobileNo.Text = _record.MobileNo;
                cmbGender.Text = _record.Sex;
                cmbMaritalStatus.Text = _record.MaritalStatus;
                return true;
            }

            return false;
        }

        private void ViewRxReport(long _RxId)
        {
            DataSet ds = new RxService().GetRxReportData(_RxId);

            rptRx _rpt = new rptRx();

            _rpt.SetDataSource(ds);

            _rpt.SetParameterValue("RegNo", txtRegNo.Text);

            ReportViewer rv = new ReportViewer();


            // _cashmemo.DataDefinition.FormulaFields[5].Text = txtHCVAdjustment.Text;
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtInvestigation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();

                if (IsTestTemplateSearch)
                {
                    crtlTestTemplateSearchControl.Visible = true;
                    crtlTestTemplateSearchControl.LoadDataByType(consultant.CPId.ToString());

                }
                else
                {
                    ctlTestSearch.Visible = true;
                    ctlTestSearch.LoadData();

                }


            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                ctlTestSearch.Visible = false;
                crtlTestTemplateSearchControl.Visible = false;
            }
        }



        private void txtRxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            long _RxId = 0;
            long.TryParse(txtRxId.Text, out _RxId);
            if (e.KeyChar == (char)Keys.Enter)
            {

                // ViewRxReport(_RxId);
                LoadPrescriptionData(_RxId);
            }
        }

        private void LoadPrescriptionData(long _RxId)
        {
            RxPatientInfo _pInfo = new RxService().GetRxPatientInfoByRxId(_RxId);
            if (_pInfo != null)
            {

                txtRxId.Tag = _RxId;

                txtRegNo.Text = _pInfo.RegNo.ToString();
                txtYears.Text = _pInfo.AgeYear;
                txtMonths.Text = _pInfo.AgeMonth;
                txtDays.Text = _pInfo.AgeDay;

                LoadPrescribedRegPatientInfo(_pInfo.RegNo);

                LoadRxPatientHistories(_RxId);

                LoadPhisicalExams(_RxId);

                List<SelectedTestItemsForPatient> _testsList = new RxService().GetTestsByRxId(_RxId);

                FillTestGrid(_testsList);

                List<SelectedMedicineForPatient> _medicineList = new RxService().GetSelectedMedicineByRxId(_RxId);
                FillProductGrid(_medicineList);

                List<SelectedAdvice> _advList = new RxService().GetSelectedAdicesByRxId(_RxId);
                FillAdviceGrid(_advList);

            }
        }

        private void LoadPhisicalExams(long _RxId)
        {

            unlocked = false;
            RxPatientPhysicalExam _rxPhysicalExam = new RxService().GetRxPatientPhysicalExam(_RxId);
            if (_rxPhysicalExam != null)
            {
                
                cmbAppearance.Text = _rxPhysicalExam.Appearance;
                txtNutrition.Text = _rxPhysicalExam.Nutrition;
                cmbDecubius.Text = _rxPhysicalExam.Decubitus;
                cmbCoperation.Text = _rxPhysicalExam.Cooperation;
                cmbAnaemia.Text = _rxPhysicalExam.Anaemia;
                cmbJaundice.Text = _rxPhysicalExam.Jaundice;
                txtCyanosis.Text = _rxPhysicalExam.Cyanosis;
                cmbClubbing.Text = _rxPhysicalExam.Clubbing;
                _rxPhysicalExam.Koilonychia = cmbKoilonychia.Text;
                cmbLeukonychia.Text = _rxPhysicalExam.Leukonychia;
                cmbOedema.Text = _rxPhysicalExam.Oedema;
                cmbDehydration.Text = _rxPhysicalExam.Dehydration;
                cmbBonyTenderness.Text=_rxPhysicalExam.Bonytenderness;
                cmbPigmentation.Text = _rxPhysicalExam.Pigmentation;
                cmbLympNodes.Text = _rxPhysicalExam.Lymphnodes;
                cmbThyroid.Text = _rxPhysicalExam.Thyroidgland;
                cmbBreasts.Text = _rxPhysicalExam.Breasts;
                cmbBodyHair.Text = _rxPhysicalExam.Bodyhair;
                txtPulse.Text = _rxPhysicalExam.Pulse;
                txtBPCystol.Text = _rxPhysicalExam.BPCystol;
                txtBPDiaStol.Text = _rxPhysicalExam.BPDiastol;
                txtWeight.Text = _rxPhysicalExam.Weight;
                cmbWtUnit.Text = _rxPhysicalExam.WeightUnit;
                txtTemperature.Text = _rxPhysicalExam.Temperature;
                txtRespiration.Text = _rxPhysicalExam.Respirtaion;
                cmbNeck.Text = _rxPhysicalExam.Neck;
                cmbAxilla.Text = _rxPhysicalExam.Axilla;
                txtHead.Text = _rxPhysicalExam.Head;
                cmbRash.Text = _rxPhysicalExam.Rash;
                cmbScarMark.Text = _rxPhysicalExam.Scarmark;
                cmbScratchMark.Text = _rxPhysicalExam.Scratchmark;

            }else
            {
                cmbAppearance.Text = "";
                txtNutrition.Text = "";
                cmbDecubius.Text = "";
                cmbCoperation.Text = "";
                cmbAnaemia.Text = "";
                cmbJaundice.Text = "";
                txtCyanosis.Text = "";
                cmbClubbing.Text = "";
                _rxPhysicalExam.Koilonychia = "";
                cmbLeukonychia.Text = "";
                cmbOedema.Text = "";
                cmbDehydration.Text = "";
                cmbBonyTenderness.Text = "";
                cmbPigmentation.Text = "";
                cmbLympNodes.Text = "";
                cmbThyroid.Text = "";
                cmbBreasts.Text = "";
                cmbBodyHair.Text = "";
                txtPulse.Text = "";
                txtBPCystol.Text = "";
                txtBPDiaStol.Text = "";
                txtWeight.Text = "";
                cmbWtUnit.Text = "";
                txtTemperature.Text = "";
                txtRespiration.Text = "";
                cmbNeck.Text = "";
                cmbAxilla.Text = "";
                txtHead.Text = "";
                cmbRash.Text = "";
                cmbScarMark.Text = "";
                cmbScratchMark.Text = "";
            }


            unlocked = true;
        }
        private void LoadRxPatientHistories(long _RxId)
        {
            unlocked = false;

            RxPatientHistory _rxH = new RxService().GetRxPatientHistories(_RxId);
            if (_rxH != null)
            {
              
                txtCC.Text = _rxH.ChiefComplains;
                txtCCD.Text = _rxH.CCDuration;
                txtPresentillness.Text = _rxH.Presentillness;
                txtPastillness.Text = _rxH.Pastillness;
                txtFamilyHistory.Text = _rxH.FamilyHistory;
                txtPersonalHistory.Text = _rxH.PersonalHistory;
                txtSocioEconomicHistory.Text = _rxH.SocioEconomicHistory;
                txtPsychiatricHistory.Text = _rxH.PsychiatricHistory;
                txtDrugAndTreatment.Text = _rxH.DrugAndTreatmentHistory;
                txtAllergyHistory.Text = _rxH.AllergyHistory;
                txtImmunizationHistory.Text = _rxH.ImmunizationHistory;
                txtMeanstrualHistory.Text = _rxH.MeanstrualAndObstetricHistory;
                txtOtherHistory.Text = _rxH.OtherHistory;

              
            }else
            {
                txtCC.Text = "";
                txtCCD.Text = "";
                txtPresentillness.Text = "";
                txtPastillness.Text = "";
                txtFamilyHistory.Text = "";
                txtPersonalHistory.Text = "";
                txtSocioEconomicHistory.Text = "";
                txtPsychiatricHistory.Text = "";
                txtDrugAndTreatment.Text = "";
                txtAllergyHistory.Text = "";
                txtImmunizationHistory.Text = "";
                txtMeanstrualHistory.Text = "";
                txtOtherHistory.Text = "";

            }


            unlocked = true;
        }

        private void ctlProductSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedicine.Focus();
            }
        }

        private void ctlTestSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtInvestigation.Focus();
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbAdvices.SelectedValue) > 0)
            {
                new RxService().PopulateSelectedAdviceData(_SelectedAdvices, (RxSavedAdvice)cmbAdvices.SelectedItem);
                FillAdviceGrid(_SelectedAdvices);

            }

        }

        private void FillAdviceGrid(IList<SelectedAdvice> _SelectedAdvices)
        {
            dgAdvices.SuspendLayout();
            dgAdvices.Rows.Clear();
            foreach (var item in _SelectedAdvices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgAdvices, item.AdviceId, item.Advice);
                dgAdvices.Rows.Add(row);
            }
        }

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _regNo = 0;
                Int64.TryParse(txtRegNo.Text, out _regNo);
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);

                if (!LoadRegPatientInfo(_regNo))
                {
                    MessageBox.Show("Reg No not found.Please check and try again.");
                }

                if (_record != null)
                {

                    // LoadBarcode();
                    // txtRefBy.Focus();
                }

                List<RxPatientInfo> _rxReports = new RxService().GetRxesByRegNo(_regNo);
               // FillRxGrid(_rxReports);
            }
        }

      

        private void btnNext_Click(object sender, EventArgs e)
        {
            txtRegNo.Text = "";
            txtPatientName.Text = "";

            txtDays.Text = "";
            txtYears.Text = "";
            txtMonths.Text = "";
            txtCC.Text = "";
            txtPresentillness.Text = "";
            txtPastillness.Text = "";
            txtFamilyHistory.Text = "";
            txtPersonalHistory.Text = "";
            txtSocioEconomicHistory.Text = "";
            txtPsychiatricHistory.Text = "";
            txtDrugAndTreatment.Text = "";
            txtAllergyHistory.Text = "";
            txtImmunizationHistory.Text = "";
            txtMeanstrualHistory.Text = "";
            txtOtherHistory.Text = "";

            txtMobileNo.Text = "";


            txtBPCystol.Text = "";
            txtBPDiaStol.Text = "";

            dgTests.Rows.Clear();
            dgProducts.Rows.Clear();
         
            dgAdvices.Rows.Clear();

            _SelectedTests = new List<SelectedTestItemsForPatient>();
            _SelectedProducts = new List<SelectedMedicineForPatient>();
            _SelectedAdvices = new List<SelectedAdvice>();


        }

       
        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtRxId.Text))
            {
                long _rxId = 0;
                long.TryParse(txtRxId.Text, out _rxId);

                ViewRxReport(_rxId);
            }

        }

        private void txtCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddDiagnosisTemplate _frm = new frmAddDiagnosisTemplate();
            _frm.Show();
        }

        private void txtPastHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && (e.Alt || e.Control || e.Shift))
            {
                HideAllDefaultHidden();

            }
        }

        private void ctrlResumeOfHistory_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                //txtPastHistory.Focus();
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

                    string _outLet = "";
                    if (Configuration.ORG_CODE == "2")
                    {
                        _outLet = "2";
                    }
                    else
                    {
                        _outLet = "1";

                    }

                    ctlProductSearch.Visible = true;
                    ctlProductSearch.txtSearch.Text = _txt;
                    ctlProductSearch.txtSearch.SelectionStart = ctlProductSearch.txtSearch.Text.Length;

                    ctlProductSearch.LoadDataByType(_txt + ">" + _outLet); // Out let Id appended for outlet specific product loading
                }
            }
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtYears.Focus();
            }
        }

        private void txtYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMonths.Focus();
            }
        }



        private void txtMonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDays.Focus();
            }
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbGender.Focus();
            }
        }

        private void txtCellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbMaritalStatus.Focus();
            }
        }

        private void txtPulse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtWeight.Focus();
            }
        }

        private void txtBP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtWeight.Focus();
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //txtPastHistory.Focus();
            }
        }

        private void txtGeneric_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtGeneric.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    string _outLet = "";
                    if (Configuration.ORG_CODE == "2")
                    {
                        _outLet = "2";
                    }
                    else
                    {
                        _outLet = "1";

                    }

                    ctrlPhProductSearchByGen.Visible = true;
                    ctrlPhProductSearchByGen.txtSearch.Text = _txt;
                    ctrlPhProductSearchByGen.txtSearch.SelectionStart = ctrlPhProductSearchByGen.txtSearch.Text.Length;

                    ctrlPhProductSearchByGen.LoadDataByType(_txt + ">" + _outLet); // Out let Id appended for outlet specific product loading
                }
            }
        }

        private void ctrlPhProductSearchByGen_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtGeneric.Focus();
            }
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(pnlPatient.Location.X + 750, 65);

            isInMaxView = false;

            btnMaxView.Visible = true;
        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(553, 50);

            isInMaxView = true;

            btnMaxView.Visible = false;
        }

        private void btnPref_Click(object sender, EventArgs e)
        {
            frmSetPreference _frm = new frmSetPreference(consultant);
            _frm.Show();
        }

        private void btnCreateTreatmentTemplate_Click(object sender, EventArgs e)
        {

        }

        private void btnPatientHistoryPanel_Click(object sender, EventArgs e)
        {
            if (isPatientHistoryMaxPanel)
            {
                pnlPatientHistory.Location = new Point(-1240, pnlPatientHistory.Location.Y);

                isPatientHistoryMaxPanel = false;

                btnPatientHistoryPanel.Text = ">> >>";

            }
            else
            {
                pnlPatientHistory.Location = new Point(0, pnlPatientHistory.Location.Y);

                isPatientHistoryMaxPanel = true;

                btnPatientHistoryPanel.Text = "<< <<";
            }
        }

        private void btnCCAdd_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.CC.ToString());
            _frm.Show();
        }

        private void btnPresentIllnessAdd_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.PrIL.ToString());
            _frm.Show();
        }

        private void btnPassIllness_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.PaIL.ToString());
            _frm.Show();
        }

        private void btnFamilyHistory_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.FaH.ToString());
            _frm.Show();
        }

        private void btnPersonalHistory_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.PeH.ToString());
            _frm.Show();
        }

        private void btnSocioEconomic_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.SeH.ToString());
            _frm.Show();
        }

        private void btnPsychiatricAdd_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.PscyH.ToString());
            _frm.Show();
        }

        private void btnDrugAndTreatmentAdd_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.DrH.ToString());
            _frm.Show();
        }

        private void btnAllergyAdd_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.AH.ToString());
            _frm.Show();
        }

        private void btnImmunizationAdd_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.ImH.ToString());
            _frm.Show();
        }

        private void btnMenstrualAdd_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.MoH.ToString());
            _frm.Show();
        }

        private void btnOtherHistory_Click(object sender, EventArgs e)
        {
            frmAddPatientHistory _frm = new frmAddPatientHistory(RxPatientHistoryAddCalledFrom.OH.ToString());
            _frm.Show();
        }

        private void txtCC_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtCC;
            ctrlHistorySearchControl.Location = new Point(txtCC.Location.X, txtCC.Location.Y);

            int itemId;
            if (int.TryParse(txtCC.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtCC.Text;
                    if (isBlankNeeded)
                    {
                        txtCC.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtCC.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.CC.ToString());
                }
            }
        }

        private void ctrlHistorySearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCC.Focus();
            }
        }

        private void txtPresentillness_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtPresentillness;
            ctrlHistorySearchControl.Location = new Point(txtPresentillness.Location.X, txtPresentillness.Location.Y);

            int itemId;
            if (int.TryParse(txtPresentillness.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtPresentillness.Text;
                    if (isBlankNeeded)
                    {
                        txtPresentillness.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtPresentillness.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.PrIL.ToString());
                }
            }
        }

        private void txtPastillness_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtPastillness;
            ctrlHistorySearchControl.Location = new Point(txtPastillness.Location.X, txtPastillness.Location.Y);

            int itemId;
            if (int.TryParse(txtPastillness.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtPastillness.Text;
                    if (isBlankNeeded)
                    {
                        txtPastillness.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtPastillness.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.PaIL.ToString());
                }
            }
        }

        private void txtFamilyHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtFamilyHistory;
            ctrlHistorySearchControl.Location = new Point(txtFamilyHistory.Location.X, txtFamilyHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtFamilyHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtFamilyHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtFamilyHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtFamilyHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.FaH.ToString());
                }
            }
        }

        private void txtPersonalHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtPersonalHistory;
            ctrlHistorySearchControl.Location = new Point(txtPersonalHistory.Location.X, txtPersonalHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtPersonalHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtPersonalHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtPersonalHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtPersonalHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.PeH.ToString());
                }
            }
        }

        private void txtSocioEconomicHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtSocioEconomicHistory;
            ctrlHistorySearchControl.Location = new Point(txtSocioEconomicHistory.Location.X, txtSocioEconomicHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtSocioEconomicHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtSocioEconomicHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtSocioEconomicHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtSocioEconomicHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.SeH.ToString());
                }
            }
        }

        private void txtPhychiatricHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtPsychiatricHistory;
            ctrlHistorySearchControl.Location = new Point(txtPsychiatricHistory.Location.X, txtPsychiatricHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtPsychiatricHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtPsychiatricHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtPsychiatricHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtPsychiatricHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.PscyH.ToString());
                }
            }
        }

        private void txtDrugAndTreatment_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtDrugAndTreatment;
            ctrlHistorySearchControl.Location = new Point(txtDrugAndTreatment.Location.X, txtDrugAndTreatment.Location.Y);

            int itemId;
            if (int.TryParse(txtDrugAndTreatment.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtDrugAndTreatment.Text;
                    if (isBlankNeeded)
                    {
                        txtDrugAndTreatment.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtDrugAndTreatment.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.DrH.ToString());
                }
            }
        }

        private void txtAllergyHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtAllergyHistory;
            ctrlHistorySearchControl.Location = new Point(txtAllergyHistory.Location.X, txtAllergyHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtAllergyHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtAllergyHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtAllergyHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtAllergyHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.AH.ToString());
                }
            }
        }

        private void txtImmunizationHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtImmunizationHistory;
            ctrlHistorySearchControl.Location = new Point(txtImmunizationHistory.Location.X, txtImmunizationHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtImmunizationHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtImmunizationHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtImmunizationHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtImmunizationHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.ImH.ToString());
                }
            }
        }

        private void txtMeanstrualHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtMeanstrualHistory;
            ctrlHistorySearchControl.Location = new Point(txtMeanstrualHistory.Location.X, txtMeanstrualHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtMeanstrualHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtMeanstrualHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtMeanstrualHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtMeanstrualHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.MoH.ToString());
                }
            }
        }

        private void txtOtherHistory_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtOtherHistory;
            ctrlHistorySearchControl.Location = new Point(txtOtherHistory.Location.X, txtOtherHistory.Location.Y);

            int itemId;
            if (int.TryParse(txtOtherHistory.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtOtherHistory.Text;
                    if (isBlankNeeded)
                    {
                        txtOtherHistory.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtOtherHistory.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.OH.ToString());
                }
            }
        }

        private void txtCC_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtPresentillness_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtPastillness_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtFamilyHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtPersonalHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtSocioEconomicHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtPhychiatricHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtDrugAndTreatment_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtAllergyHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtImmunizationHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtMeanstrualHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtOtherHistory_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void btnAddMedicineTemplate_Click(object sender, EventArgs e)
        {
            frmCreateTreatmantTemplate _frm = new frmCreateTreatmantTemplate();
            _frm.Show();
        }



        private void txtCCD_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtCCD;
            ctrlHistorySearchControl.Location = new Point(txtCCD.Location.X, txtCCD.Location.Y);

            int itemId;
            if (int.TryParse(txtCCD.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtCCD.Text;
                    if (isBlankNeeded)
                    {
                        txtCCD.Text = "";
                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt;
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtCC.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlHistorySearchControl.Visible = true;
                        ctrlHistorySearchControl.txtSearch.Text = _txt.Trim();
                        ctrlHistorySearchControl.txtSearch.SelectionStart = ctrlHistorySearchControl.txtSearch.Text.Length;
                    }

                    ctrlHistorySearchControl.LoadDataByType(RxPatientHistoryAddCalledFrom.CCD.ToString());
                }
            }

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.APPR.ToString());
            _frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.BLD.ToString());
            _frm.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.NTR.ToString());
            _frm.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.DCTBT.ToString());
            _frm.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.COO.ToString());
            _frm.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.ANM.ToString());
            _frm.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.JND.ToString());
            _frm.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.CYN.ToString());
            _frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.CLB.ToString());
            _frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.KLN.ToString());
            _frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.LKN.ToString());
            _frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.ODMA.ToString());
            _frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.DHD.ToString());
            _frm.Show();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.BNTND.ToString());
            _frm.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.PGT.ToString());
            _frm.Show();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.LYMPHN.ToString());
            _frm.Show();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.THYGLND.ToString());
            _frm.Show();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.BRT.ToString());
            _frm.Show();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.BH.ToString());
            _frm.Show();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.PLS.ToString());
            _frm.Show();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.BP.ToString());
            _frm.Show();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.TMP.ToString());
            _frm.Show();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.RSP.ToString());
            _frm.Show();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.NCK.ToString());
            _frm.Show();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.AXL.ToString());
            _frm.Show();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.HEAD.ToString());
            _frm.Show();
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.RASH.ToString());
            _frm.Show();
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.SCM.ToString());
            _frm.Show();
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            frmAddGeneralPhysicalExam _frm = new frmAddGeneralPhysicalExam(RxGeneralPhysicalExamAddCalledFrom.SCRM.ToString());
            _frm.Show();
        }

       
        private void txtAppearance_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void ctrlPhysicalExamItemSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                selectedTextBox.Focus();
            }
        }

      

        private void txtBuild_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void btnCreateInvTemplate_Click(object sender, EventArgs e)
        {
            frmAddTestTemplate _frm = new frmAddTestTemplate();
            _frm.Show();
        }

        private void btnSearchInvTemplate_Click(object sender, EventArgs e)
        {
            if (!IsTestTemplateSearch)
            {
                IsTestTemplateSearch = true;

            }
            else
            {
                IsTestTemplateSearch = false;
            }


            if (IsTestTemplateSearch)
            {
                lblInvestigation.Text = "Template";
                lblInvestigation.Location = new Point(lblInvestigation.Location.X - 40, lblInvestigation.Location.Y);
                txtInvestigation.Focus();
            }
            else
            {
                lblInvestigation.Text = "Inv.";
                lblInvestigation.Location = new Point(lblInvestigation.Location.X + 100, lblInvestigation.Location.Y);
                txtInvestigation.Focus();
            }
        }

        private void crtlTestTemplateSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtInvestigation.Focus();
            }
        }

        private void txtNutrition_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtNutrition;
            ctrlPhysicalExamItemSearchControl.Location = new Point(txtNutrition.Location.X, txtNutrition.Location.Y);

            int itemId;
            if (int.TryParse(txtNutrition.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtNutrition.Text;
                    if (isBlankNeeded)
                    {
                        txtNutrition.Text = "";
                        ctrlPhysicalExamItemSearchControl.Visible = true;
                        ctrlPhysicalExamItemSearchControl.txtSearch.Text = _txt;
                        ctrlPhysicalExamItemSearchControl.txtSearch.SelectionStart = ctrlPhysicalExamItemSearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtNutrition.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlPhysicalExamItemSearchControl.Visible = true;
                        ctrlPhysicalExamItemSearchControl.txtSearch.Text = _txt.Trim();
                        ctrlPhysicalExamItemSearchControl.txtSearch.SelectionStart = ctrlPhysicalExamItemSearchControl.txtSearch.Text.Length;
                    }

                    ctrlPhysicalExamItemSearchControl.LoadDataByType(RxGeneralPhysicalExamAddCalledFrom.NTR.ToString());
                }
            }
        }

       
        private void txtNutrition_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtDecibitus_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

        private void txtCooperation_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

       

        private void txtAnaemia_Leave(object sender, EventArgs e)
        {
            isBlankNeeded = true;
        }

      

        private void txtCyanosis_TextChanged(object sender, EventArgs e)
        {
            selectedTextBox = txtCyanosis;
            ctrlPhysicalExamItemSearchControl.Location = new Point(txtCyanosis.Location.X, txtCyanosis.Location.Y);

            int itemId;
            if (int.TryParse(txtCyanosis.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    HideAllDefaultHidden();
                    string _txt = txtCyanosis.Text;
                    if (isBlankNeeded)
                    {
                        txtCyanosis.Text = "";
                        ctrlPhysicalExamItemSearchControl.Visible = true;
                        ctrlPhysicalExamItemSearchControl.txtSearch.Text = _txt;
                        ctrlPhysicalExamItemSearchControl.txtSearch.SelectionStart = ctrlPhysicalExamItemSearchControl.txtSearch.Text.Length;
                    }
                    else
                    {
                        int startIndex = WrittenCommitedHistoryText.Length;
                        if (txtCyanosis.Text.Length > startIndex)
                        {
                            _txt = _txt.Substring(startIndex);
                        }
                        else
                        {
                            _txt = "";
                        }


                        ctrlPhysicalExamItemSearchControl.Visible = true;
                        ctrlPhysicalExamItemSearchControl.txtSearch.Text = _txt.Trim();
                        ctrlPhysicalExamItemSearchControl.txtSearch.SelectionStart = ctrlPhysicalExamItemSearchControl.txtSearch.Text.Length;
                    }

                    ctrlPhysicalExamItemSearchControl.LoadDataByType(RxGeneralPhysicalExamAddCalledFrom.CYN.ToString());
                }
            }
        }

     
      

        private void pictureBox21_Click_1(object sender, EventArgs e)
        {
            frmAddAdvices _frm = new frmAddAdvices();
            _frm.Show();
        }

        private void pictureBox22_Click_1(object sender, EventArgs e)
        {
            frmAddDosageTemplate _frm = new frmAddDosageTemplate();
            _frm.Show();
        }

        private void btnSavePhyExam_Click(object sender, EventArgs e)
        {
            if (txtRxId.Tag != null)
            {
                long _RxId = 0;
                long.TryParse(txtRxId.Tag.ToString(), out _RxId);

                RxPatientPhysicalExam _rxPhysicalExam = new RxPatientPhysicalExam();
                _rxPhysicalExam = new RxService().GetRxPhysicalExam(_RxId);
                if (_rxPhysicalExam == null)
                {
                    unlocked = false;
                    _rxPhysicalExam = new RxPatientPhysicalExam();
                    _rxPhysicalExam.RxId = _RxId;
                    _rxPhysicalExam.Appearance = cmbAppearance.Text;
                    _rxPhysicalExam.Nutrition = txtNutrition.Text;
                    _rxPhysicalExam.Decubitus = cmbDecubius.Text;
                    _rxPhysicalExam.Cooperation = cmbCoperation.Text;
                    _rxPhysicalExam.Anaemia = cmbAnaemia.Text;
                    _rxPhysicalExam.Jaundice = cmbJaundice.Text;
                    _rxPhysicalExam.Cyanosis = txtCyanosis.Text;
                    _rxPhysicalExam.Clubbing = cmbClubbing.Text;
                    _rxPhysicalExam.Koilonychia = cmbKoilonychia.Text;
                    _rxPhysicalExam.Leukonychia = cmbLeukonychia.Text;
                    _rxPhysicalExam.Oedema = cmbOedema.Text;
                    _rxPhysicalExam.Dehydration = cmbDehydration.Text;
                    _rxPhysicalExam.Bonytenderness = cmbBonyTenderness.Text;
                    _rxPhysicalExam.Pigmentation = cmbPigmentation.Text;
                    _rxPhysicalExam.Lymphnodes = cmbLympNodes.Text;
                    _rxPhysicalExam.Thyroidgland = cmbThyroid.Text;
                    _rxPhysicalExam.Breasts = cmbBreasts.Text;
                    _rxPhysicalExam.Bodyhair = cmbBodyHair.Text;
                    _rxPhysicalExam.Pulse = txtPulse.Text;
                    _rxPhysicalExam.BPCystol = txtBPCystol.Text;
                    _rxPhysicalExam.BPDiastol = txtBPDiaStol.Text;
                    _rxPhysicalExam.Weight = txtWeight.Text;
                    _rxPhysicalExam.WeightUnit = cmbWtUnit.Text;
                    _rxPhysicalExam.Temperature = txtTemperature.Text;
                    _rxPhysicalExam.Respirtaion = txtRespiration.Text;
                    _rxPhysicalExam.Neck = cmbNeck.Text;
                    _rxPhysicalExam.Axilla = cmbAxilla.Text;
                    _rxPhysicalExam.Head = txtHead.Text;
                    _rxPhysicalExam.Rash = cmbRash.Text;
                    _rxPhysicalExam.Scarmark = cmbScarMark.Text;
                    _rxPhysicalExam.Scratchmark = cmbScratchMark.Text;

                    new RxService().SaveRxPatientPhysicalExam(_rxPhysicalExam);

                    MessageBox.Show("Physical exam save successful");

                    unlocked = true;

                }
                else
                {

                    _rxPhysicalExam.RxId = _RxId;
                    _rxPhysicalExam.Appearance = cmbAppearance.Text;
                    _rxPhysicalExam.Nutrition = txtNutrition.Text;
                    _rxPhysicalExam.Decubitus = cmbDecubius.Text;
                    _rxPhysicalExam.Cooperation = cmbCoperation.Text;
                    _rxPhysicalExam.Anaemia = cmbAnaemia.Text;
                    _rxPhysicalExam.Jaundice = cmbJaundice.Text;
                    _rxPhysicalExam.Cyanosis = txtCyanosis.Text;
                    _rxPhysicalExam.Clubbing = cmbClubbing.Text;
                    _rxPhysicalExam.Koilonychia = cmbKoilonychia.Text;
                    _rxPhysicalExam.Leukonychia = cmbLeukonychia.Text;
                    _rxPhysicalExam.Oedema = cmbOedema.Text;
                    _rxPhysicalExam.Dehydration = cmbDehydration.Text;
                    _rxPhysicalExam.Bonytenderness = cmbBonyTenderness.Text;
                    _rxPhysicalExam.Pigmentation = cmbPigmentation.Text;
                    _rxPhysicalExam.Lymphnodes = cmbLympNodes.Text;
                    _rxPhysicalExam.Thyroidgland = cmbThyroid.Text;
                    _rxPhysicalExam.Breasts = cmbBreasts.Text;
                    _rxPhysicalExam.Bodyhair = cmbBodyHair.Text;
                    _rxPhysicalExam.Pulse = txtPulse.Text;
                    _rxPhysicalExam.BPCystol = txtBPCystol.Text;
                    _rxPhysicalExam.BPDiastol = txtBPDiaStol.Text;
                    _rxPhysicalExam.Weight = txtWeight.Text;
                    _rxPhysicalExam.WeightUnit = cmbWtUnit.Text;
                    _rxPhysicalExam.Temperature = txtTemperature.Text;
                    _rxPhysicalExam.Respirtaion = txtRespiration.Text;
                    _rxPhysicalExam.Neck = cmbNeck.Text;
                    _rxPhysicalExam.Axilla = cmbAxilla.Text;
                    _rxPhysicalExam.Head = txtHead.Text;
                    _rxPhysicalExam.Rash = cmbRash.Text;
                    _rxPhysicalExam.Scarmark = cmbScarMark.Text;
                    _rxPhysicalExam.Scratchmark = cmbScratchMark.Text;

                    new RxService().UpdateRxPatientPhysicalExam(_rxPhysicalExam);

                    MessageBox.Show("Physical exam update successful");
                }

            }
        }

        private void ctrlHistorySearchControl_Load(object sender, EventArgs e)
        {

        }

        private void txtPatientName_MouseEnter(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;

            ctrl.BackColor = Color.NavajoWhite;
        }

        private void txtPatientName_MouseLeave(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;

            ctrl.BackColor = Color.White;
        }



        private void txtCareGiver_MouseEnter(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;

            ctrl.BackColor = Color.NavajoWhite;
        }

        private void txtCareGiver_MouseLeave(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;

            ctrl.BackColor = Color.White;
        }

        private void btnSavePaHistory_Click(object sender, EventArgs e)
        {
            string _message = CheckRequiredInformation();

            int _practitionerId = 0;
            int _refDocId = 0;
            long _RxId = 0;

            if (txtRxBy.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)txtRxBy.Tag;
                _practitionerId = _prac.CPId;
                _refDocId = _prac.DoctorId;
            }

            if (txtRxId.Tag != null)
            {
                _RxId = Convert.ToInt64(txtRxId.Tag.ToString());
            }


            if (String.IsNullOrEmpty(_message))
            {

                RegRecord _regTracker = GetRegNoLong();
                txtRegNo.Text = _regTracker.RegNo.ToString();

                 RxPatientInfo _patientinfo = new RxPatientInfo();
                _patientinfo = new RxService().GetRxPatientInfoByRxId(_RxId);
                if (_patientinfo == null)
                {
                    _patientinfo = new RxPatientInfo();
                    _patientinfo.AgeYear = txtYears.Text;
                    _patientinfo.AgeMonth = txtMonths.Text;
                    _patientinfo.AgeDay = txtDays.Text;
                    _patientinfo.RegNo = _regTracker.RegNo;
                    _patientinfo.RxDate = Utils.GetServerDateAndTime();
                    _patientinfo.RxTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");

                    _patientinfo.VisitStatus = RxPatientVisitStatusEnum.Waiting.ToString();

                    _patientinfo.CPId = _practitionerId;
                    _patientinfo.PractitionerRefdDoctorId = _refDocId;


                    _patientinfo.PatientType = "OPD";
                    _patientinfo.OperateBy = MainForm.LoggedinUser.UserId;

                    _RxId = new RxService().SaveRxPatient(_patientinfo);


                    
                }
                else
                {
                    _patientinfo.AgeYear = txtYears.Text;
                    _patientinfo.AgeMonth = txtMonths.Text;
                    _patientinfo.AgeDay = txtDays.Text;
                    _patientinfo.RegNo = _regTracker.RegNo;
                    _patientinfo.RxDate = Utils.GetServerDateAndTime();
                    _patientinfo.RxTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");

                    _patientinfo.VisitStatus = RxPatientVisitStatusEnum.Waiting.ToString();

                    _patientinfo.CPId = _practitionerId;
                    _patientinfo.PractitionerRefdDoctorId = _refDocId;


                    _patientinfo.PatientType = "OPD";
                    _patientinfo.OperateBy = MainForm.LoggedinUser.UserId;

                     new RxService().UpdateRxPatient(_patientinfo);

                }

                if (_RxId > 0)
                {
                    txtRxId.Text = _RxId.ToString();
                    txtRxId.Tag = _RxId;
                    RxPatientHistory _rxH = new RxPatientHistory();
                    _rxH = new RxService().GetRxHistory(_RxId);
                    if (_rxH == null)
                    {
                        _rxH = new RxPatientHistory();
                        _rxH.RxId = _RxId;
                        _rxH.ChiefComplains = txtCC.Text;
                        _rxH.CCDuration = txtCCD.Text;
                        _rxH.Presentillness = txtPresentillness.Text;
                        _rxH.Pastillness = txtPastillness.Text;
                        _rxH.FamilyHistory = txtFamilyHistory.Text;
                        _rxH.PersonalHistory = txtPersonalHistory.Text;
                        _rxH.SocioEconomicHistory = txtSocioEconomicHistory.Text;
                        _rxH.PsychiatricHistory = txtPsychiatricHistory.Text;
                        _rxH.DrugAndTreatmentHistory = txtDrugAndTreatment.Text;
                        _rxH.AllergyHistory = txtAllergyHistory.Text;
                        _rxH.ImmunizationHistory = txtImmunizationHistory.Text;
                        _rxH.MeanstrualAndObstetricHistory = txtMeanstrualHistory.Text;
                        _rxH.OtherHistory = txtOtherHistory.Text;

                        new RxService().SaveRxPatientHistory(_rxH);

                        MessageBox.Show("Patient basic info & history save successful");

                    }
                    else
                    {
                        _rxH.RxId = _RxId;
                        _rxH.ChiefComplains = txtCC.Text;
                        _rxH.CCDuration = txtCCD.Text;
                        _rxH.Presentillness = txtPresentillness.Text;
                        _rxH.Pastillness = txtPastillness.Text;
                        _rxH.FamilyHistory = txtFamilyHistory.Text;
                        _rxH.PersonalHistory = txtPersonalHistory.Text;
                        _rxH.SocioEconomicHistory = txtSocioEconomicHistory.Text;
                        _rxH.PsychiatricHistory = txtPsychiatricHistory.Text;
                        _rxH.DrugAndTreatmentHistory = txtDrugAndTreatment.Text;
                        _rxH.AllergyHistory = txtAllergyHistory.Text;
                        _rxH.ImmunizationHistory = txtImmunizationHistory.Text;
                        _rxH.MeanstrualAndObstetricHistory = txtMeanstrualHistory.Text;
                        _rxH.OtherHistory = txtOtherHistory.Text;
                        new RxService().UpdateRxPatientHistory(_rxH);


                        MessageBox.Show("Patient basic info & history update successful");
                    }

                    LoadPatients();
                }
            }
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.Rows.Count > 0)
            {
                RxVMPatientBasicInfo _rxpBasic = dgPatient.SelectedRows[0].Tag as RxVMPatientBasicInfo;

                lblName.Text = _rxpBasic.Name;
                lblGender2.Text = _rxpBasic.Sex;
                lblAge2.Text = _rxpBasic.Age;
            }
        }
    }
  }
