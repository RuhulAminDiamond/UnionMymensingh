using AForge.Video;
using AForge.Video.DirectShow;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using HDMS.Model.Location;
using HDMS.Model.Migrations;
using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Rx;
using HDMS.Model.Rx.VModel;
using HDMS.Model.Users;
using HDMS.Model.ViewModel;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Pharmacy;
using HDMS.Service.Rx;
using HDMS.Windows.Forms.UI.Accounts;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Rx;
//using i00SpellCheck;
using Itenso.TimePeriod;
using MessageBoxExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmRxViewer : Form
    {
        public bool tickcolor = true;
        bool isLoaded = false;
        bool IsPatientInEditMode = false;
        bool IsSearchAdviceDisable = false;
        bool isSearchByBrand = true;
        bool isSearchByPreferredMedicine = false;
        bool isSearchByGeneric = false;
        bool unlocked = true;
        bool isRxDrugRowUpdateMode = false;
        private int _chamberPractitionerId = 0;

        public bool IsNewPatientPanelHide = true;
        public bool IsSearchPatientPanelHide = true;

        public bool isCalledFromHistoryBtn = false;
        public bool isCalledFromAdditionalInfoBtn = false;
        public bool isCalledFromOtherFindingsBtn = false;
        public bool isCalledFromCCBtn = false;
        public bool isCalledfromSaveAsDiseaseTemplate = false;
        public bool isCalledfromInsertFromDiseaseTemplate = false;

        public bool isCalledFromCreateTreatmentTemplateBtn = false;
        public bool isCalledFromInsertTreatmentTemplateBtn = false;
        public bool isCalledFromCreateAdiceTemplateBtn = false;
        public bool isCalledFromInsertAdiceTemplateBtn = false;
        public bool isCalledFromCreateTestTemplateBtn = false;
        public bool isCalledFromInsertTestTemplateBtn = false;

        public bool IsConvertedToBengli = false;

        String[] _histArr = new String[] { };
        String[] _pasthistArr = new String[] { };
        String[] _otherFindingArr = new String[] { };
        String[] _ccArr = new String[] { };

        public frmRxViewer()
        {
            InitializeComponent();

        }


        RxInitialData _InitialDataObj;
        private IList<RxSelectedMedicineForPatient> _SelectedMedicines;
        private IList<SelectedAdvice> _SelectedAdvices;
        private IList<RxVMTestTemplate> _SelectedTests;

        public IList<string> _templateItems;

        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private IList<VMReportDefination> _SelectedTestItemsForPathologyReport;

        private async void frmRxViewer_Load(object sender, EventArgs e)
        {
            //this.EnableControlExtensions();

            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

            EnableSpellCheckProperty();

            _templateItems = new List<string>();

            _InitialDataObj = new RxInitialData();
            _SelectedMedicines = new List<RxSelectedMedicineForPatient>();
            _SelectedTests = new List<RxVMTestTemplate>();
            _SelectedAdvices = new List<SelectedAdvice>();
            HideAllDefaultHidden();
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0; // default


            FinalFrame = new VideoCaptureDevice();
            //foreach (Control ctrl in this.Controls)
            //{
            //    ctrl.GotFocus += ctrl_GotFocus;
            //    ctrl.LostFocus += ctrl_LostFocus;
            //}




            ctlDoctorSearch.Location = new Point(txtRefdby.Location.X, txtRefdby.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            ctrlEarlierDoc1.Location = new Point(txtEarlierDoc1.Location.X, txtEarlierDoc1.Location.Y);
            ctrlEarlierDoc1.ItemSelected += ctrlEarlierDoc1_ItemSelected;

            ctrlEarlierDoc2.Location = new Point(txtEarlierDoc2.Location.X, txtEarlierDoc2.Location.Y);
            ctrlEarlierDoc2.ItemSelected += ctrlEarlierDoc2_ItemSelected;

            ctrlEarlierDoc3.Location = new Point(txtEarlierDoc3.Location.X, txtEarlierDoc3.Location.Y);
            ctrlEarlierDoc3.ItemSelected += ctrlEarlierDoc3_ItemSelected;

            ctrlEarlierDoc4.Location = new Point(txtEarlierDoc4.Location.X, txtEarlierDoc4.Location.Y);
            ctrlEarlierDoc4.ItemSelected += ctrlEarlierDoc4_ItemSelected;

            ctrlEarlierDoc5.Location = new Point(txtEarlierDoc5.Location.X, txtEarlierDoc5.Location.Y);
            ctrlEarlierDoc5.ItemSelected += ctrlEarlierDoc5_ItemSelected;

            ctrlEarlierDoc6.Location = new Point(txtEarlierDoc6.Location.X, txtEarlierDoc6.Location.Y);
            ctrlEarlierDoc6.ItemSelected += ctrlEarlierDoc6_ItemSelected;


            ctrlSearchByPreferredDrug.Location = new Point(txtBrand.Location.X, txtBrand.Location.Y);
            ctrlSearchByPreferredDrug.ItemSelected += ctrlSearchByPreferredDrug_ItemSelected;

            ctrlRxProductByBrand.Location = new Point(txtBrand.Location.X, txtBrand.Location.Y);
            ctrlRxProductByBrand.ItemSelected += ctrlRxProductByBrand_ItemSelected;

            ctrlRxProductByGeneric.Location = new Point(txtDose.Location.X, txtDose.Location.Y);
            ctrlRxProductByGeneric.ItemSelected += ctrlRxProductByGeneric_ItemSelected;
            

            ctrlDosageSearch.Location = new Point(txtDose.Location.X, txtDose.Location.Y + txtDose.Height);
            ctrlDosageSearch.ItemSelected += ctrlDosageSearch_ItemSelected;

            ctlTestSearchControl2.Location = new Point(txtTest.Location.X, txtTest.Location.Y);
            ctlTestSearchControl2.ItemSelected += ctlTestSearchControl2_ItemSelected;

            ctrlRxCpAdviceSearch.Location = new Point(txtSearchAdvices.Location.X, txtSearchAdvices.Location.Y-220);
            ctrlRxCpAdviceSearch.ItemSelected += CtrlRxCpAdviceSearch_ItemSelected;


            NewPatientEntryPanelPostionSet(IsNewPatientPanelHide);
            PatientSearchPanelPositionSet(IsSearchPatientPanelHide);

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            _chamberPractitionerId = _user.ChamberPractitionerId;
            if (_chamberPractitionerId == 0)
            {
                _chamberPractitionerId = _user.CpId;
            }
            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_chamberPractitionerId);

            if (Practitioner != null)
            {
                Doctor _d = new DoctorService().GetDoctorById(Practitioner.DoctorId);
                if (_d != null)
                {
                    txtReferredby.Text = _d.Name;
                    txtReferredby.Tag = _d;
                }
                
                panel2.Tag = Practitioner;

                _chamberPractitionerId = Practitioner.CPId;

                Task t1 = Task.Run(() => LoadLastPatientData(Practitioner.CPId));

               
                Task t2 = Task.Run(() => LoadDistricts());
                //await LoadDistricts();

                Task t3 = Task.Run(() => LoadLocalGurdianDistricts());

                //await LoadLocalGurdianDistricts();

                Task t4 = Task.Run(() => LoadRxDurationUnits());
                //await LoadRxDurationUnits();

                Task t5 = Task.Run(() => LoadRxAdvices(Practitioner.CPId));
                //await LoadRxAdvices(Practitioner.CPId);

                Task t6 = Task.Run(() => LoadCPRelatedSettingsData(Practitioner.CPId));

                //await LoadCPRelatedSettingsData(Practitioner.CPId);

                Task t7 = Task.Run(() => LoadPrinterSettings(Practitioner.CPId));
                //await LoadPrinterSettings(Practitioner.CPId);

                Task t14 = Task.Run(() => LoadPrintPreference(Practitioner.CPId));

                Task t8 = Task.Run(() => SetToolTipTexts());
                //await SetToolTipTexts();

                Task t9 = Task.Run(() => LoadPersonalPreference(Practitioner.CPId));

                Task t10 = Task.Run(() => LoadMedicines());

                Task t11 = Task.Run(() => LoadTitleCombo());

                Task t12 = Task.Run(() => LoadRxDosages());

                Task t13 = Task.Run(() => LoadOccupations());

               

                await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9,t10, t11,t12,t13);

                //Thread.Sleep(100);
                //Task t2 = new Task(()=> { LoadVisitNo(Practitioner.CPId); });
                //t2.Start();

                if (_user.RoleId == 41)
                {
                    DisableAccessOption();
                  
                    EnableAccessOptions(_user.UserId);
                   

                }

                if (Practitioner.ESignature != null)
                {
                    signaturebox.Image = byteArrayToImage(Practitioner.ESignature);
                }
                else
                {
                    signaturebox.Image = null;
                }

            }
            else
            {
                MessageBox.Show("Practioner not found."); return;
            }

            pnlHistory.Location = new Point(-536, 0);
            pnlCreateTemplate.Location= new Point(-536, 0);

            timer1.Stop();

        }

        private async Task<bool> LoadPrintPreference(int cPId)
        {
            RxPrintPreference _printPref =  new RxService().GetRxPrintPreference(cPId);
            btnPdf.Tag = _printPref;

            return await Task.FromResult(true);
        }

        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        private void ctrlEarlierDoc6_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtEarlierDoc6.Text = item.Name;
            txtEarlierDoc6.Tag = item;

            sender.Visible = false;
        }

        private void ctrlEarlierDoc5_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtEarlierDoc5.Text = item.Name;
            txtEarlierDoc5.Tag = item;

            sender.Visible = false;
        }

        private void ctrlEarlierDoc4_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtEarlierDoc4.Text = item.Name;
            txtEarlierDoc4.Tag = item;

            sender.Visible = false;
        }

        private void ctrlEarlierDoc3_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtEarlierDoc3.Text = item.Name;
            txtEarlierDoc3.Tag = item;

            sender.Visible = false;
        }

        private void ctrlEarlierDoc2_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtEarlierDoc2.Text = item.Name;
            txtEarlierDoc2.Tag = item;

            sender.Visible = false;
        }

        private void ctrlEarlierDoc1_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtEarlierDoc1.Text = item.Name;
            txtEarlierDoc1.Tag = item;

            sender.Visible = false;
        }

        private void LoadOccupations()
        {
            List<Occupation> _occulist = new CommonService().GetAllOccupations();
            this.Invoke(new MethodInvoker(delegate ()
            {
                cmbOccupationNE.DataSource= _occulist;
                cmbOccupationNE.DisplayMember = "Name";
                cmbOccupationNE.ValueMember = "Id";

            }));
        }

        private void LoadRxDosages()
        {
            List<RxDosage> _doseList = new RxService().GetRxCDbAllDosage().ToList();
            this.Invoke(new MethodInvoker(delegate ()
            {
                lbldosage.Tag = _doseList;

            }));
        }

        private void LoadTitleCombo()
        {
            List<TitleOrNamePrefix> _titleStrins = new RxService().GetTitleStrings();
            this.Invoke(new MethodInvoker(delegate ()
            {
                 cmbTitle.DataSource= _titleStrins;
                 cmbTitle.DisplayMember = "Title";
                 cmbTitle.ValueMember = "Id";

            }));
        }

        private void ctlTestSearchControl2_ItemSelected(SearchResultListControl<TestItem> sender, TestItem item)
        {
            unlocked = false;

            txtTest.Text = item.TestId.ToString();
            txtTest.Tag = item;
            txtTest.Focus();

            new RxService().PopulateRxSelectedTestData(_SelectedTests, item, txtTest.Text, "0");

            txtTest.Focus();

            FillTestGrid();

            SaveOrUpdateTestData();

            unlocked = true;
            sender.Visible = false;
        }

        private void LoadMedicines()
        {
            List<VMPhProductListForRxPerspective> _mList = new PhProductService().GetBasicProductInfoListForRxPerspective("", "").ToList();
            dgDrugs.Tag = _mList;
        }

        private void LoadPersonalPreference(int cPId)
        {
            RxPersonalPreferenceSetting _ps = new RxService().GetRxPersonalPrefernce(cPId);
            btnAddDosage.Tag = _ps;

            this.Invoke(new MethodInvoker(delegate ()
            {
               
                if (_ps!=null && _ps.IsDefaultAdviceInEnglish)
                {
                    radAdviceEn.Checked = true;
                }
                else
                {
                    radAdviceBn.Checked = true;
                }
            }));


            if (_ps.IsMedicineInterXEnable)
            {
                List<MedicineInterX> _MInterXs = new RxService().LoadMedicineInterXs();
                lblQty_MedicineInterX.Tag = _MInterXs;
            }

            
        }

        private void EnableAccessOptions(int userId)
        {
            try
            {
                List<RxCpSupportUserAccessOption> optList = new RxService().GetCpAssistAccessOptionsList(userId);
               
                foreach (RxCpSupportUserAccessOption item in optList)
                {
                    if (item.AccessOption.Equals("tab0"))
                    {
                        tabControl1.TabPages[0].Enabled = true;
                    }

                    if (item.AccessOption.Equals("tab1"))
                    {
                        tabControl1.TabPages[1].Enabled = true;
                    }

                    if (item.AccessOption.Equals("tab2"))
                    {
                        tabControl1.TabPages[2].Enabled = true;
                    }

                    if (item.AccessOption.Equals("CC"))
                    {
                        txtCC.Enabled = true;

                    }

                    if (item.AccessOption.Equals("NewPatient"))
                    {
                        btnNewPatient.Enabled = true;
                    }

                    if (item.AccessOption.Equals("SearchPatient"))
                    {
                        btnFind.Enabled = true;
                    }

                    if (item.AccessOption.Equals("History"))
                    {
                        txtHistoryNew.Enabled = true;

                    }
                    
                    if (item.AccessOption.Equals("DrugHistory"))
                    {
                        txtDrugHistory.Enabled = true;

                    }

                    if (item.AccessOption.Equals("Additional"))
                    {
                        txtAdditional.Enabled = true;
                    }

                    if (item.AccessOption.Equals("OtherFindings"))
                    {
                        txtOtherFindings.Enabled = true;
                    }

                    if (item.AccessOption.Equals("TreatmentPlan"))
                    {
                        txtTreatmentPlan.Enabled = true;

                    }

                    if (item.AccessOption.Equals("Settings"))
                    {
                        btnSetPreference.Enabled = true;
                    }

                    if (item.AccessOption.Equals("Treatment"))
                    {
                        txtBrand.Enabled = true;
                    }

                    if (item.AccessOption.Equals("Advices"))
                    {
                        txtSearchAdvices.Enabled = true;

                    }

                    if (item.AccessOption.Equals("TestAdvice"))
                    {
                        txtTest.Enabled = true;
                    }

                    if (item.AccessOption.Equals("Diagnosis"))
                    {
                        txtPrescriptionDiagnosis.Enabled = true;
                    }

                    if (item.AccessOption.Equals("TestAdvice"))
                    {
                        txtTest.Enabled = true;
                    }

                    if (item.AccessOption.Equals("Comments"))
                    {
                        txtCommentsReferral.Enabled = true;
                    }

                    if (item.AccessOption.Equals("Notes"))
                    {
                        txtNotes.Enabled = true;
                    }
                }

            }catch(Exception ex)
            {

            }
        }

        private void DisableAccessOption()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                tabControl1.TabPages[0].Enabled = false;
                tabControl1.TabPages[1].Enabled = false;
                tabControl1.TabPages[2].Enabled = false;
                tabControl1.TabPages[3].Enabled = false;
                btnNewPatient.Enabled = false;
                btnFind.Enabled = false;
                btnSetPreference.Enabled = false;
                txtCC.Enabled = false;
                txtHistoryNew.Enabled = false;
                txtAdditional.Enabled = false;
                txtTreatmentPlan.Enabled = false;
                txtOtherFindings.Enabled = false;
                txtDrugHistory.Enabled = false;
                txtSketh.Enabled = false;
                txtBrand.Enabled = false;
                txtSearchAdvices.Enabled = false;
                txtTest.Enabled = false;
                txtPrescriptionDiagnosis.Enabled = false;
            }));
        }

        private void EnableSpellCheckProperty()
        {

            string _dicPath = Path.Combine(Environment.CurrentDirectory, @"Rx\","dic.dic");
            string _synPath = Path.Combine(Environment.CurrentDirectory, @"Rx\", "syn.syn");

            //i00SpellCheck.FlatFileDictionary Dictionary = new i00SpellCheck.FlatFileDictionary(_dicPath, false);
            // //new i00SpellCheck.Synonyms().File= _synPath;

            //txtHistoryNew.EnableControlExtensions();

            //txtCC.SpellCheck().CurrentDictionary = Dictionary;
            //txtHistoryNew.SpellCheck().CurrentDictionary= Dictionary;
            ////txtHistoryNew.SpellCheck(true, null).CurrentSynonyms= new i00SpellCheck.Synonyms();
            ////txtHistoryNew.SpellCheck(true, null).CurrentDictionary.ShowUIEditor();
            //// txtHistoryNew.SpellCheck(true, null).CurrentDefinitions = def;
            //txtAdditional.SpellCheck().CurrentDictionary = Dictionary; 
            //txtTreatmentPlan.SpellCheck().CurrentDictionary = Dictionary;
            //txtOtherFindings.SpellCheck().CurrentDictionary = Dictionary;
            //txtDrugHistory.SpellCheck().CurrentDictionary = Dictionary;
            //txtNotes.SpellCheck().CurrentDictionary = Dictionary;
            //txtCommentsReferral.SpellCheck().CurrentDictionary = Dictionary;
            //txtCC.SpellCheck().CurrentDictionary = Dictionary;
            //txtTemplateDescription.SpellCheck().CurrentDictionary = Dictionary;
        }

        private async void PatientSearchPanelPositionSet(bool isSearchPatientPanelHide)
        {
            if (isSearchPatientPanelHide)
            {
                pnlSearchPatient.Location = new Point(-12500, 3);
            }
            else
            {
               
                pnlSearchPatient.Location = new Point(90, 3);
                List<RxVMPatientBasicInfo> _pList = await new RxService().GetRxPatientListAsync(DateTime.Now.AddDays(-100), DateTime.Now, _chamberPractitionerId);

                FillPatientList(_pList);

                pnlSearchPatient.Tag = _pList;


            }
        }

        private void FillPatientList(List<RxVMPatientBasicInfo> pList)
        {
            dgPatient.Rows.Clear();
            dgPatient.SuspendLayout();
            foreach(var item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgPatient, item.RegNo,item.Name,item.MobileNo,item.Address);
                dgPatient.Rows.Add(row);
            }
        }

        private Task<bool> SetToolTipTexts()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(btnNewPatient, "New Patient");
                toolTip1.SetToolTip(btnNewVisit, "New Visit");
                toolTip1.SetToolTip(btnSetPreference, "Preference Settings");
                toolTip1.SetToolTip(btnSaveasDeseaseTemplate, "Save as disease template.");
                toolTip1.SetToolTip(btnInsertfromdiseasetemplate, "Insert from disease template.");
                toolTip1.SetToolTip(btnAddEditHistory, "Add/Edit/Delete in history template.");
                toolTip1.SetToolTip(txtSearchAdvices, "To disable search press ctrl+D and to enable press ctrl+A.");

            }));

            return Task.FromResult(true);
        }

        private async Task<bool> LoadPrinterSettings(int cPId)
        {
            List<RxCPPrintPageSetup> _pageSetup = await new RxService().GetRxCPPageSetup(cPId);
            btnPrint.Tag = _pageSetup;

            return await Task.FromResult(true);
        }

        private void CtrlRxCpAdviceSearch_ItemSelected(SearchResultListControl<RxCPAdvice> sender, RxCPAdvice item)
        {
            new RxService().PopulateAdvices(_SelectedAdvices, item, radAdviceBn.Checked);
            txtSearchAdvices.Tag = item;
            txtSearchAdvices.Text = "";
            txtSearchAdvices.Focus();
            sender.Visible = false;
            PopulateAdviceList(_SelectedAdvices);
            SaveOrUpdateAdvice();
        }

        private void PopulateAdviceList(IList<SelectedAdvice> selectedAdvices)
        {
            lstAdvices.Items.Clear();
            foreach (var item in selectedAdvices)
            {
                lstAdvices.Items.Add(item.Advice);
            }
        }

        private void MnuTestsOnly_Click(object sender, EventArgs e)
        {
            if (txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                rptAdvicedTestsOnly _rx = new rptAdvicedTestsOnly();

                DataSet _ds = new RxService().GetRxAdvicedTestsDataSet(_visit.RxVisitId, _visit.CpId);
                _rx.SetDataSource(_ds);

                ReportViewer rv = new ReportViewer();

                if (btnPrint.Tag != null)
                {
                    List<RxCPPrintPageSetup> _psetup = (List<RxCPPrintPageSetup>)btnPrint.Tag;
                    RxCPPrintPageSetup setupObj = _psetup.Where(x => x.PageType == RxPageTypeEnum.TestsAdvicedOnly.ToString()).FirstOrDefault();

                    if (setupObj != null)
                    {
                        int _left = Convert.ToInt32(Math.Round(setupObj.LeftMargin)) * 100;
                        int _top = Convert.ToInt32(Math.Round(setupObj.TopMargin)) * 100;
                        int _right = Convert.ToInt32(Math.Round(setupObj.RightMargin)) * 100;
                        int _bottom = Convert.ToInt32(Math.Round(setupObj.BottomMargin)) * 100;
                        // PageMargins margins;
                        // // Get the PageMargins structure and set the 
                        // // margins for the report.
                        // margins = _rx.PrintOptions.PageMargins;
                        // margins.topMargin = Convert.ToInt32(Math.Round(setupObj.TopMargin));
                        // margins.rightMargin = Convert.ToInt32(Math.Round(setupObj.RightMargin));
                        // margins.bottomMargin = Convert.ToInt32(Math.Round(setupObj.BottomMargin));
                        // margins.leftMargin = Convert.ToInt32(Math.Round(setupObj.LeftMargin));

                        //_rx.PrintOptions.ApplyPageMargins(margins);



                        _rx.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;

                        _rx.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        _rx.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(_left, _top, _right, _bottom));
                    }


                }


                rv.crviewer.ReportSource = _rx;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private void MnuTreatmentPrint_Click(object sender, EventArgs e)
        {
            if (txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                rptRxTreatmentOnly _rx = new rptRxTreatmentOnly();

                DataSet _ds = new RxService().GetRxTreatmentDataSet(_visit.RxVisitId, _visit.CpId);
                _rx.SetDataSource(_ds);

                ReportViewer rv = new ReportViewer();

                if (btnPrint.Tag != null)
                {
                    List<RxCPPrintPageSetup> _psetup = (List<RxCPPrintPageSetup>)btnPrint.Tag;
                    RxCPPrintPageSetup setupObj = _psetup.Where(x => x.PageType == RxPageTypeEnum.TreatmentOnly.ToString()).FirstOrDefault();

                    if (setupObj != null)
                    {
                        int _left = Convert.ToInt32(Math.Round(setupObj.LeftMargin));
                        int _top = Convert.ToInt32(Math.Round(setupObj.TopMargin));
                        int _right = Convert.ToInt32(Math.Round(setupObj.RightMargin));
                        int _bottom = Convert.ToInt32(Math.Round(setupObj.BottomMargin));
                        // PageMargins margins;
                        // // Get the PageMargins structure and set the 
                        // // margins for the report.
                        // margins = _rx.PrintOptions.PageMargins;
                        // margins.topMargin = Convert.ToInt32(Math.Round(setupObj.TopMargin));
                        // margins.rightMargin = Convert.ToInt32(Math.Round(setupObj.RightMargin));
                        // margins.bottomMargin = Convert.ToInt32(Math.Round(setupObj.BottomMargin));
                        // margins.leftMargin = Convert.ToInt32(Math.Round(setupObj.LeftMargin));

                        //_rx.PrintOptions.ApplyPageMargins(margins);



                        _rx.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;

                        _rx.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        _rx.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(_left, _top, _right, _bottom));
                    }


                }


                rv.crviewer.ReportSource = _rx;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private  void MnuFullPrint_Click(object sender, EventArgs e)
        {
            RxPrintPreference printPref = btnPdf.Tag as RxPrintPreference;

            if (printPref.PrintFormat1)
            {
                PrintFullPrescriptionFormat1();
            }
            else if (printPref.PrintFormat2)
            {
                PrintFullPrescriptionFormat2();
            }
            else if (printPref.PrintFormat3)
            {
                PrintFullPrescriptionFormat3();
            }
            else if (printPref.PrintFormat4)
            {
                PrintFullPrescriptionFormat4();
            }

        }

        private async void PrintFullPrescriptionFormat1()
        {
            if (txtVisitNo.Tag != null && btnPrint.Tag != null)
            {

                List<RxCPPrintPageSetup> _psetup = (List<RxCPPrintPageSetup>)btnPrint.Tag;
                RxCPPrintPageSetup setupObj = _psetup.Where(x => x.PageType == RxPageTypeEnum.FullPrescription.ToString()).FirstOrDefault();


                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                await LoadPrinterSettings(_visit.CpId);

                new RxService().AccumulatePrescriptionDataVer2(_visit.RxVisitId, _visit.CpId);

                rptRxFullPrescriptionVer1 _rx = new rptRxFullPrescriptionVer1();


                DataSet _ds = new RxService().GetRxFullDataSetVer2(_visit.RxVisitId, _visit.CpId);
                _rx.SetDataSource(_ds);
                int _top = Convert.ToInt32(setupObj.TopMargin * 1000);
                _rx.ReportDefinition.Sections["Section2"].Height = _top;
               

                ReportViewer rv = new ReportViewer();

                PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();

                int _left = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _top2 = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _right = Convert.ToInt32(setupObj.RightMargin * 100);
                int _bottom = Convert.ToInt32(setupObj.BottomMargin * 100);

                PageMargins margins = new PageMargins();

                margins = _rx.PrintOptions.PageMargins;
                margins.bottomMargin = _bottom;
                margins.leftMargin = _left;
                margins.rightMargin = _right;
                margins.topMargin = _top2;
                _rx.PrintOptions.ApplyPageMargins(margins);

                // _rx.PrintOptions.PrinterName = "Canon LBP6030/6040/6018L XPS";



                rv.crviewer.ReportSource = _rx;

                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintMode = PrintMode.PrintToPrinter;
                //rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private async void PrintFullPrescriptionFormat3()
        {
            if (txtVisitNo.Tag != null && btnPrint.Tag != null)
            {

                List<RxCPPrintPageSetup> _psetup = (List<RxCPPrintPageSetup>)btnPrint.Tag;
                RxCPPrintPageSetup setupObj = _psetup.Where(x => x.PageType == RxPageTypeEnum.FullPrescription.ToString()).FirstOrDefault();


                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                await LoadPrinterSettings(_visit.CpId);

                new RxService().AccumulatePrescriptionDataVer2(_visit.RxVisitId, _visit.CpId);

               
                rptRxFullPrescriptionVer3 _rx = new rptRxFullPrescriptionVer3();

                DataSet _ds = new RxService().GetRxFullDataSetVer2(_visit.RxVisitId, _visit.CpId);
                _rx.SetDataSource(_ds);
                int _top = Convert.ToInt32(setupObj.TopMargin * 1000);
                _rx.ReportDefinition.Sections["Section2"].Height = _top;


                ReportViewer rv = new ReportViewer();

                PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();

                int _left = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _top2 = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _right = Convert.ToInt32(setupObj.RightMargin * 100);
                int _bottom = Convert.ToInt32(setupObj.BottomMargin * 100);

                PageMargins margins = new PageMargins();

                margins = _rx.PrintOptions.PageMargins;
                margins.bottomMargin = _bottom;
                margins.leftMargin = _left;
                margins.rightMargin = _right;
                margins.topMargin = _top2;
                _rx.PrintOptions.ApplyPageMargins(margins);

                // _rx.PrintOptions.PrinterName = "Canon LBP6030/6040/6018L XPS";



                rv.crviewer.ReportSource = _rx;

                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintMode = PrintMode.PrintToPrinter;
                //rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private object GetField(Object obj, String fieldName)
        {
            System.Reflection.FieldInfo fi = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return fi.GetValue(obj);
        }

        private async Task<bool> LoadCPRelatedSettingsData(int cPId)
        {
           await LoadHistoryData(cPId, false);
           await LoadPastHistoryData(cPId, false);
           await LoadOtherFindingsData(cPId,false);
           await LoadCCData(cPId, false);

            return await Task.FromResult(true);
        }

        private async Task<bool> LoadOtherFindingsData(int cPId, bool isInListBox)
        {
            List<RxCPOtherFinding> _otherFindingList = new RxService().GetRxCPOtherFindingsData(cPId);
            txtOtherFindings.Tag = _otherFindingList;

            List<string> _strList = new List<string>();
            foreach (var item in _otherFindingList)
            {
                _strList.Add(item.OtherFindingEn);
            }

            if (_strList.Count > 0)
            {
                _otherFindingArr = _strList.ToArray();
                txtOtherFindings.Values = _otherFindingArr;
            }

            if (isInListBox)
            {
                lstboxtemplateItem.Items.Clear();
                foreach (var item in _otherFindingList)
                {
                    lstboxtemplateItem.Items.Add(item.OtherFindingEn);
                }
            }

            return await Task.FromResult(true);
        }

        private async Task<bool> LoadPastHistoryData(int cPId, bool isInListBox)
        {
            List<RxCPPastHistory> _pastHistoryData = new RxService().GetRxCPPastHistoryData(cPId);
            txtAdditional.Tag = _pastHistoryData;

            List<string> _strList = new List<string>();
            foreach (var item in _pastHistoryData)
            {
                _strList.Add(item.HistoryEn);
            }

            if (_strList.Count > 0)
            {
                _pasthistArr = _strList.ToArray();
                txtAdditional.Values = _pasthistArr;
            }

            if (isInListBox)
            {
                lstboxtemplateItem.Items.Clear();
                foreach (var item in _pastHistoryData)
                {
                    lstboxtemplateItem.Items.Add(item.HistoryEn);
                }
            }

            return await Task.FromResult(true);
        }

        private async Task<bool> LoadHistoryData(int cPId, bool isInListBox)
        {
            List<RxCPHistory> _historyList = new RxService().GetRxCPHistoryData(cPId);
            txtHistoryNew.Tag = _historyList;

            List<string> _strList = new List<string>();
            foreach(var item in _historyList)
            {
                _strList.Add(item.HistoryEn);
            }

            if (_strList.Count > 0)
            {
                _histArr = _strList.ToArray();
                txtHistoryNew.Values = _histArr;
            }

            if (isInListBox)
            {
                lstboxtemplateItem.Items.Clear();
                foreach (var item in _historyList)
                {
                    lstboxtemplateItem.Items.Add(item.HistoryEn);
                }
            
            }


            return await Task.FromResult(true);
        }

        private void ctrlSearchByPreferredDrug_ItemSelected(SearchResultListControl_2<VWRxPhProductList> sender, VWRxPhProductList item)
        {
            //PickSelectedProduct(item);
            sender.Visible = false;
            unlocked = false;
            ChamberPractitioner _cp = (ChamberPractitioner)panel2.Tag;
            RxCPPreferredMedicine _pm = new RxService().GetRxPreferredMedicine(item.ProductId, _cp.CPId);
            if (_pm != null)
            {
                if (!string.IsNullOrEmpty(_pm.BeforeAfterEn))
                {
                    txtDose.Text = _pm.DoseLongBn + " (" + _pm.BeforeAfterEn + ")";
                }
                else
                {
                    txtDose.Text = _pm.DoseLongBn;
                }
                txtDurationValue.Text = _pm.Duration;
                cmbDurationUnit.Text = _pm.DurationUnit;
                txtQty.Text = _pm.Qty.ToString();
                txtQty.Focus();
            }
            else
            {
                txtDose.Focus();
            }
            
           
        }

        private Task<bool> LoadRxAdvices(int cPId)
        {
            List<RxCPAdvice> _rxAdvices = new RxService().GetAdvices();
            _rxAdvices.Insert(0, new RxCPAdvice() { RxCpAdvId = 0, AdviceBn="Select Advice", AdviceEn="Select Advice" });

            return Task.FromResult(true);

        }

        private void ctlTestSearch_ItemSelected(SearchResultListControl<RxCPPreferredTest> sender, RxCPPreferredTest item)
        {
            unlocked = false;
          
            txtTest.Text = item.TestId.ToString();
            txtTest.Tag = item;
            txtTest.Focus();

           // new RxService().PopulateRxSelectedTestData(_SelectedTests, item, txtTest.Text,"0");

            txtTest.Focus();

            FillTestGrid();

            SaveOrUpdateTestData();

            unlocked = true;
            sender.Visible = false;
        }

        private void FillTestGrid()
        {
            dgInvestigation.SuspendLayout();
            dgInvestigation.Rows.Clear();
            foreach (RxVMTestTemplate item in _SelectedTests)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
               
                row.CreateCells(dgInvestigation, item.Name, 0);
                dgInvestigation.Rows.Add(row);
            }

            

        }
        private Task<bool> LoadRxDurationUnits()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                List<RxDuration> _duration = new RxService().GetRxDuration();
                cmbDurationUnit.DataSource = _duration;
                cmbDurationUnit.DisplayMember = "Name";
                cmbDurationUnit.ValueMember = "DurationId";
            }));

            return Task.FromResult(true);
        }

        private async void ctrlDosageSearch_ItemSelected(SearchResultListControl<RxDosage> sender, RxDosage item)
        {

            txtDose.Tag = item;
            RxPersonalPreferenceSetting prefs = btnAddDosage.Tag as RxPersonalPreferenceSetting;
            if(prefs!=null && prefs.IsDefaultDoseInEnglish)
            {
                if (prefs.IsDefaultDoseInShortForm)
                {
                    txtDose.Text = item.DoseEnShort;
                }
                else
                {
                    txtDose.Text = item.DoseEnLong;
                }
            }
            else
            {
                if (prefs.IsDefaultDoseInShortForm)
                {
                    txtDose.Text = item.DoseBnShort;
                }
                else
                {
                    txtDose.Text = item.DoseBnLong;
                }
            }

            if (txtBrand.Tag != null)
            {
                VMPhProductListForRxPerspective _phprod = txtBrand.Tag as VMPhProductListForRxPerspective;
                
                if (_phprod.DoseId == 0)
                {
                    new RxService().SetDoseAsDefault(_phprod, item);

                    Task t6 = Task.Run(() => LoadMedicines());

                    await Task.WhenAll(t6);
                }
            }

            sender.Visible = false;
            txtDurationValue.Focus();
        }

        private void ctrlRxProductByFormarion_ItemSelected(SearchResultListControl_2<VWRxPhProductList> sender, VWRxPhProductList item)
        {
            //PickSelectedProduct(item);
            sender.Visible = false;
            //ctrlRxProductByGeneric.Visible = false;
            ctrlRxProductByBrand.Visible = false;
        }

        private void PickSelectedProduct(VMPhProductListForRxPerspective item)
        {
            RxPersonalPreferenceSetting prefs = btnAddDosage.Tag as RxPersonalPreferenceSetting;

            txtBrand.Tag = item;
            txtBrand.Text = item.BrandName;

            if (prefs.IsDefaultDoseFromPersonalDb)
            {
                RxCpDosage _d = new RxService().GetRxCPDosagesByGeneric(panel2.Tag as ChamberPractitioner, item.GenericId,item.FormationId);
                if (_d != null)
                {
                    if (prefs.IsDefaultDoseInEnglish)
                    {
                        if (prefs.IsDefaultDoseInShortForm)
                        {
                            txtDose.Text = _d.DoseEnShort;

                        }
                        else
                        {
                            txtDose.Text = _d.DoseEnLong;
                        }
                    }
                    else
                    {
                        if (prefs.IsDefaultDoseInShortForm)
                        {
                            txtDose.Text = _d.DoseBnShort;
                        }
                        else
                        {
                            txtDose.Text = _d.DoseBnLong;
                        }
                    }
                }

                RxCpDosageWithGenericMapping _mappingObj = new RxService().GetRxCpDosageWithGenericMapping(panel2.Tag as ChamberPractitioner,item.GenericId, item.FormationId);

                if (_mappingObj != null)
                {
                    txtDurationValue.Text =  GetConvertedEngToBengaliStr(_mappingObj.DefaultDuration.ToString());

                    IsConvertedToBengli = true;

                    if (!string.IsNullOrEmpty(_mappingObj.DDUnit))
                    {
                        cmbDurationUnit.Text = _mappingObj.DDUnit;
                        txtQty.Focus();
                    }
                    else
                    {
                        cmbDurationUnit.Focus();
                    }

                    if (!string.IsNullOrEmpty(_mappingObj.Qty))
                    {
                        txtQty.Text = _mappingObj.Qty;
                        txtQty.Focus();
                    }
                   

                }
            
            }
            else
            {
                if (prefs.IsDefaultDoseInEnglish)
                {
                    if (prefs.IsDefaultDoseInShortForm)
                    {
                        txtDose.Text = item.DoseEnShort;

                    }
                    else
                    {
                        txtDose.Text = item.DoseEnLong;
                    }
                }
                else
                {
                    if (prefs.IsDefaultDoseInShortForm)
                    {
                        txtDose.Text = item.DoseBnShort;
                    }
                    else
                    {
                        txtDose.Text = item.DoseBnLong;
                    }
                }
            }

             txtDose.Focus();

        }

        private void ctrlRxProductByGeneric_ItemSelected(SearchResultListControl_2<VMPhProductListForRxPerspective> sender, VMPhProductListForRxPerspective item)
        {
            PickSelectedProduct(item);

            sender.Visible = false;
            unlocked = false;
            //txtDose.Focus();
            ctrlRxProductByBrand.Visible = false;
        }

        private void ctrlRxProductByBrand_ItemSelected(SearchResultListControl_2<VMPhProductListForRxPerspective> sender, VMPhProductListForRxPerspective item)
        {
            // PickSelectedProduct(item);
            txtBrand.Tag = item;
            txtBrand.Text = item.BrandName;
            sender.Visible = false;
            unlocked = false;
          
            ctrlRxProductByGeneric.Visible = false;
            ShowAlternativeProductForThisGeneric(item);
            txtBrand.Focus();
            txtBrand.SelectionStart = txtBrand.Text.Length;
            //ctrlRxProductByFormarion.Visible = false;
            //ctrlRxProductByGeneric.Visible = false;
        }

        private void ShowAlternativeProductForThisGeneric(VMPhProductListForRxPerspective item)
        {
            ChamberPractitioner prac = (ChamberPractitioner)panel2.Tag;
           
            ctrlRxProductByGeneric.Visible = true;
            ctrlRxProductByGeneric.txtSearch.Text = "";
            ctrlRxProductByGeneric.LoadPhRxDataByType("", item.GenericName, "", prac.CPId, dgDrugs.Tag as List<VMPhProductListForRxPerspective>);
         
           // ctrlRxProductByGeneric.txtSearch.SelectionStart = ctrlRxProductByGeneric.txtSearch.Text.Length;
        }

        private void LoadVisitNo(int _cpId)
        {

            this.Invoke(new MethodInvoker(delegate()
            {
                

            }));

        }

        private async Task<bool> LoadLastPatientData(int cPId)
        {
            RegRecord _rec =  await new RegRecordService().GetLatestRegRecordByCpIdAsync(cPId); // Chamber Practitioner
            if (_rec != null)
            {
                this.Invoke(new MethodInvoker(async delegate ()
                {
                    txtHIN.Tag = _rec;
                    txtHIN.Text = _rec.RegNo.ToString();
                    txtName.Text = _rec.Title + " " + _rec.FullName;
                    txtCareOf.Text = _rec.CareOf;
                    dtpDOBP.Value = _rec.DOB;
                    lblAgeOnToday.Text = this.GetAgeFromDob(_rec.DOB);
                    cmbGender.Text = _rec.Sex;
                    txtHouse.Text = _rec.HouseNo;
                    txtRoadNo.Text = _rec.RoadNo;
                    cmbMaritalStatus.Text = _rec.MaritalStatus;
                    txtReferredby.Text = txtRefdby.Text;
                    txtPhone.Text = _rec.MobileNo;
                    cmbOccupation.Text = _rec.Profession;
                    cmbBloodGroup.Text = _rec.BloodGroup;
                    txtSons.Text = _rec.NoOfSons;
                    txtDaughter.Text = _rec.NoOfDaughters;

                    if (_rec.UpazilaOrAreaId > 0)
                    {
                        UpazilaOrArea _ua = new LocationService().GetUpazillaById(_rec.UpazilaOrAreaId);
                        txtArea.Text = _ua.Name;
                        txtDist.Text = new LocationService().GetDistrictById(_ua.DistrictId).Name;
                    }
                    else
                    {
                        txtArea.Text = "";
                    }

                    if (_rec.Referredby > 0)
                    {
                        Doctor _d = new DoctorService().GetDoctorById(_rec.Referredby);
                        txtReferredby.Text = _d.Name;
                    }


                    long _regNo = 0;
                    long.TryParse(txtHIN.Text, out _regNo);

                    RxPatientMasterData _md = await new RxService().GetRxMasterDataAsync(_regNo);
                    if (_md != null)
                    {
                        RxVisitHistory _visit = await new RxService().GetLastRxVisitHistoryAsync(_md.RxPMId, cPId);
                        if (_visit != null)
                        {
                            txtVisitNo.Text = _visit.VisitNo.ToString();
                            txtVisitNo.Tag = _visit;

                            await LoadinitialDatas(_visit);

                            _SelectedTests = await new RxService().GetPatientTestsAsync(_visit.RxVisitId);
                            FillTestGrid();


                            _SelectedMedicines = await new RxService().GetPatientTreatmentAsync(_visit.RxVisitId);
                            FillProductGrid();

                            _SelectedAdvices = await new RxService().GetSelectedAdviceAsync(_visit.RxVisitId);

                            PopulateAdviceList(_SelectedAdvices);

                           await  PopulateInitialDataAdvicedTestBox(_SelectedTests);

                        }
                    }



                   

                }));


                return await Task.FromResult(true);

            }
            else
            {
                return await Task.FromResult(false);
            }

            
        }

        private string GetAgeFromDob(DateTime dOB)
        {
            DateDiff dateDiff = new DateDiff(dOB, Utils.GetServerDateAndTime());
            int yrs = dateDiff.ElapsedYears;
            int months = dateDiff.ElapsedMonths;
            int dys = dateDiff.ElapsedDays;
            string age = Utility.GetConcatenatedAge(yrs.ToString(), months.ToString(), dys.ToString());

            return age;

        }

        private async Task LoadinitialDatas(RxVisitHistory visit)
        {
            RxInitialData _initDataObj = await new RxService().GetRxInitialDataObjAsync(visit.RxVisitId);

            if (_initDataObj != null)
            {
                txtCC.Text = _initDataObj.CC;
               
                txtHistoryNew.Text = _initDataObj.PresentHistory;
                txtAdditional.Text = _initDataObj.PastHistory;
                txtTreatmentPlan.Text = _initDataObj.TreatmentPaln;
                txtPrescription.Text = _initDataObj.Prescription;
                txtWeight.Text = _initDataObj.WeightInKg;
                txtHeight.Text = _initDataObj.Height;
                cmbHeightUnit.Text = _initDataObj.HeightUnit;
                txtBpErectTop.Text = _initDataObj.BpErrectTop;
                txtBPErectBottom.Text = _initDataObj.BpErrectBottom;
                txtBPSupineTop.Text = _initDataObj.BpSupineTop;
                txtBPSupineBottom.Text = _initDataObj.BpSupineBottom;
                txtPulse.Text = _initDataObj.Pulse;
                cmbPulseType.Text = _initDataObj.PulseBehaviour1;
                cmbPulseType2.Text = _initDataObj.PulseBehaviour2;
                txtOtherFindings.Text = _initDataObj.OtherFindings;
                txtDrugHistory.Text = _initDataObj.DrugHistory;
                txtPrescriptionDiagnosis.Text= _initDataObj.Diagnosis;
                txtDiagnosisDx.Text= _initDataObj.Dx;
                txtInitialDiagnosis.Text = _initDataObj.Diagnosis;
                txtCommentsReferral.Text = _initDataObj.CommentsOrReferral;
                txtFollowUpAfter.Text= _initDataObj.FollowUpAfter;
                lblBMI.Text = "BMI: "+ _initDataObj.BMI;

                if (_initDataObj.FollowUpOn != null)
                  dtpFollowOn.Value = _initDataObj.FollowUpOn.GetValueOrDefault();

                txtNotes.Text = _initDataObj.Notes;
            }
        }

        private async Task<bool> LoadLocalGurdianDistricts()
        {

            this.Invoke(new MethodInvoker(async delegate ()
            {
                List<District> _districtList = await new CommonService().GetAllDistricts();
                _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

                cmbLocalGurdianDistrict.DataSource = _districtList;
                cmbLocalGurdianDistrict.DisplayMember = "Name";
                cmbLocalGurdianDistrict.ValueMember = "DistrictId";

                isLoaded = true;
            }));

            return await Task.FromResult(true);
        }

        private async Task<bool> LoadDistricts()
        {

            this.Invoke(new MethodInvoker(async delegate ()
            {
            List<District> _districtList = await new CommonService().GetAllDistricts();
            _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

            cmbDistricts.DataSource = _districtList;
            cmbDistricts.DisplayMember = "Name";
            cmbDistricts.ValueMember = "DistrictId";

            isLoaded = true;


            }));

            return await Task.FromResult(true);
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

        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            
            txtRefdby.Text = item.Name;
            txtRefdby.Tag = item;
            
            sender.Visible = false;
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
            ctrlEarlierDoc6.Visible = false;
            ctrlEarlierDoc5.Visible = false;
            ctrlEarlierDoc4.Visible = false;
            ctrlEarlierDoc3.Visible = false;
            ctrlEarlierDoc2.Visible = false;
            ctrlEarlierDoc1.Visible = false;
            ctrlRxProductByBrand.Visible = false;
            ctrlRxCpAdviceSearch.Visible = false;
        }

        private void NewPatientEntryPanelPostionSet(bool isNewPatientPanelHide)
        {
            if (isNewPatientPanelHide)
            {
                pnlNewPatient.Location = new Point(-12500, 3);
            }
            else
            {
                pnlNewPatient.Location = new Point(20, 3);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tickcolor) txtSpAlert.BackColor = Color.Goldenrod;
            if (!tickcolor) txtSpAlert.BackColor = Color.Cyan;
            tickcolor = !tickcolor;
        }

        private void txtSpAlert_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSpAlert.Text))
            {
                timer1.Start();
                txtSpAlert.BackColor = Color.Red;
            }
            else
            {
                timer1.Stop();
                txtSpAlert.BackColor = Color.NavajoWhite;
            }
        }

     
        private void btnNewPatient_Click(object sender, EventArgs e)
        {

            NewPatientEntryPanelPostionSet(false);
        }

        private void btnPatientDemographicPanelHide_Click(object sender, EventArgs e)
        {
            NewPatientEntryPanelPostionSet(true);
        }

        private  void btnSavePaHistory_Click(object sender, EventArgs e)
        {
            SaveOrUpdateRegistrationData();
        }

        private void ClearExistingData()
        {
            txtCC.Text = "";
           
            txtHistoryNew.Text = "";
            txtAdditional.Text = "";
            txtTreatmentPlan.Text = "";
            txtOtherFindings.Text = "";
            txtDrugHistory.Text = "";
            txtSketh.Text = "";
            txtPrescriptionDiagnosis.Text = "";
            txtDiagnosisDx.Text = "";
            txtBpErectTop.Text = "";
            txtBPErectBottom.Text = "";
            txtBPSupineTop.Text = "";
            txtBPSupineBottom.Text = "";
            txtPulse.Text = "";
            txtWeight.Text = "";
            txtHeight.Text = "";
            lblBMI.Text = "";
            dgDrugs.Rows.Clear();
            dgInvestigation.Rows.Clear();
            lstAdvices.Items.Clear();
            txtCommentsReferral.Text = "";
            txtNotes.Text = "";
            txtTest.Text = "";
            txtPrescription.Text = "";
            txtAdvicedTests.Text = "";
            txtInitialDiagnosis.Text = "";
            IsImageCaptured = false;
            pictureBox2.Image = null;
            _SelectedMedicines = new List<RxSelectedMedicineForPatient>();
            _SelectedAdvices = new List<SelectedAdvice>();
            _SelectedTests = new List<RxVMTestTemplate>();

        }

        private void ClearNewEntryPanelField()
        {
            cmbTitle.Text = "";
            txtPatientName.Text = "";
            cmbTitle.Tag = null;
            cmbTitle.Text = "";
            txtPatientName.Text = "";
            txtYears.Text = "";
            txtMonths.Text = "";
            txtDays.Text = "";
            dtpDOB.Value = Utils.GetServerDateAndTime();
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            cmbGenderNE.Text = "";
            cmbOccupationNE.Text = "";
            cmbMaritalStatusNE.Text = "";
            txtHouseNo.Text = "";
            txtRoadNo.Text = "";
            txtVillage.Text = "";
            txtphoneNumbersNE.Text = "";
            txtEmailAddress.Text = "";
            txtLocalGurdianHouseNo.Text = "";
            txtLocalGurdianRoadNo.Text = "";
            txtPO.Text = "";
            txtNoOfSons.Text = "";
            cmbBGroup.Text = "";
            txtRefdby.Text = "";
            txtRefdby.Tag = null;
            IsPatientInEditMode = false;
        }

        private bool IsValidEntry( out string _message)
        {
            string _reqMsg = string.Empty;
            _reqMsg =  CheckRequiredFieldMessage(txtPatientName.Text, _reqMsg, "Name");
            _reqMsg =  CheckRequiredFieldMessage(txtPatientName.Text, _reqMsg, "Gender");
            _reqMsg = CheckRequiredFieldMessage(txtYears.Text+txtMonths.Text+txtDays.Text, _reqMsg, "Age");
            _reqMsg = CheckRequiredFieldMessage(txtYears.Text + txtMonths.Text + txtDays.Text, _reqMsg, "Age");

            _message = _reqMsg;

            if (string.IsNullOrEmpty(_reqMsg))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private string CheckRequiredFieldMessage(string _text, string _msg, string type)
        {
            if (String.IsNullOrEmpty(_text))
            {
                if (string.IsNullOrEmpty(_msg))
                {
                    return type;
                }
                else
                {
                    return _msg + ", " + type;
                }

            }
            else
            {

                return _msg;
            }
        }

        private void txtRefdby_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtRefdby.Text, out itemId))
            {

            }
            else
            {
                
                    string _txt = txtRefdby.Text;
                    if (!string.IsNullOrEmpty(_txt) && !IsPatientInEditMode)
                    {
                        HideAllDefaultHidden();
                        ctlDoctorSearch.Visible = true;
                        ctlDoctorSearch.txtSearch.Text = _txt;
                        ctlDoctorSearch.txtSearch.SelectionStart = ctlDoctorSearch.txtSearch.Text.Length;

                        ctlDoctorSearch.LoadData();
                    }
                
            }

        }

        private void ctlDoctorSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtRefdby.Focus();
            }
        }

        private void txtYears_TextChanged(object sender, EventArgs e)
        {
            int _yrs = 0;
            int.TryParse(txtYears.Text, out _yrs);
            if (_yrs <= 200)
            {
                this.GetDOB();
            }
            else
            {
                //MessageBox.Show("Years exceed the limit");
                //txtYears.Focus();
            }
        }

        private void GetDOB()
        {
            int yrs = 0, mnths = 0, dys = 0;
            int.TryParse(txtYears.Text, out yrs);
            int.TryParse(txtMonths.Text, out mnths);
            int.TryParse(txtDays.Text, out dys);

            DateTime _dt = DateTime.Now;
            _dt = _dt.AddYears(0 - yrs);
            _dt = _dt.AddMonths(0 - mnths);
            _dt = _dt.AddDays(0 - dys);

            dtpDOB.Value = _dt;
        }

        private void txtMonths_TextChanged(object sender, EventArgs e)
        {
            int _months = 0;
            int.TryParse(txtMonths.Text, out _months);
            if (_months > 0 && _months <= 12)
            {
                this.GetDOB();
            }
            else
            {
                //MessageBox.Show("days exceed the limit");
                //txtDays.Focus();
            }
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            int _dys = 0;
            int.TryParse(txtDays.Text, out _dys);
            if (_dys > 0 && _dys <= 31)
            {
                this.GetDOB();
            }
            else
            {
                //MessageBox.Show("days exceed the limit");
                //txtDays.Focus();
            }
        }

        private void dtpDOB_Leave(object sender, EventArgs e)
        {
            DateDiff dateDiff = new DateDiff(dtpDOB.Value, DateTime.Now);
            int yrs = dateDiff.ElapsedYears;
            int months = dateDiff.ElapsedMonths;
            int dys = dateDiff.ElapsedDays;

            txtYears.Text = yrs.ToString();
            txtMonths.Text = months.ToString();
            txtDays.Text = dys.ToString();

            
        }

        private void cmbDistricts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                District _dist = (District)cmbDistricts.SelectedItem;

                List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(_dist.DistrictId);
                _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
                cmbAreaOrThana.DataSource = _uaList;
                cmbAreaOrThana.DisplayMember = "Name";
                cmbAreaOrThana.ValueMember = "UpazilaId";
            }
        }

        private void cmbLocalGurdianDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                District _dist = (District)cmbLocalGurdianDistrict.SelectedItem;

                List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(_dist.DistrictId);
                _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
                cmbLocalGurdianThana.DataSource = _uaList;
                cmbLocalGurdianThana.DisplayMember = "Name";
                cmbLocalGurdianThana.ValueMember = "UpazilaId";
            }
        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPatientName.Text)) return;

            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await PopulateInitialDataPrescriptionBox(_SelectedMedicines);
            await PopulateInitialDataAdvicedTestBox(_SelectedTests);

            txtInitialDiagnosis.Text = txtPrescriptionDiagnosis.Text;


            if (tabControl1.SelectedTab.Tag.ToString().Equals("tab2"))
            {
                if (txtVisitNo.Tag != null)
                {
                   await  LoadLabTestsWithGroup(txtVisitNo.Tag as RxVisitHistory, radLastVisit.Checked, radAll.Checked);
                }
            }

        }


        public bool IsTreePopulated = false;

        private async Task LoadLabTestsWithGroup(RxVisitHistory _visit, bool IsLastVisit, bool isAll)
        {
            if (IsLastVisit)
            {
                //List<RxVMTestResult> _testResult =   await new LabService().GetRxLabResults(txtVisitNo.Tag as RxVisitHistory);


                Patient _patient = new PatientService().GetPatientByRxId(_visit.RxVisitId);
                if (_patient != null)
                {

                    radLastVisit.Tag = _patient;

                    //Load Tests
                    TreeNode parentNode = null;
                    DataTable dt = await new ReportService().GetDisticntReportTypeForPathologyReport(_patient.PatientId); //new ReportService().GetDisticntTestGroupForPathologyReport(Convert.ToInt32(txtRegNo.Text));



                    TV.Nodes.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        parentNode = TV.Nodes.Add(dr["Report_Type"].ToString());
                        parentNode.Tag = dr["ReportTypeId"].ToString() + "_" + "pNode"; //Parent Node
                        await PopulateTreeView(_patient.PatientId, Convert.ToInt32(dr["ReportTypeId"]), parentNode);
                    }

                    //TV.ExpandAll();
                    IsTreePopulated = true;
                    TV.Focus();
                }

            }
        }

        private async Task<bool> PopulateTreeView(long parentId, int ReportTypeId, TreeNode parentNode)
        {
            DataTable dtchildc = await new ReportService().GetPathologicalTestsByReportType(parentId, ReportTypeId);//new ReportService().GetPathologicalTestsByGroup(Convert.ToInt32(txtRegNo.Text), groupId);

            TreeNode childNode;
            foreach (DataRow dr in dtchildc.Rows)
            {
                if (parentNode == null)
                {
                    childNode = TV.Nodes.Add(dr["TestName"].ToString() + "->" + dr["ReportStatus"].ToString());
                    childNode.Tag = dr["TestId"];
                }
                else
                {
                    childNode = parentNode.Nodes.Add(dr["TestName"].ToString() + "->" + dr["ReportStatus"].ToString());
                    childNode.Tag = dr["TestId"];
                }

            }

            return await Task.FromResult(true);
        }

        private Task<bool> PopulateInitialDataAdvicedTestBox(IList<RxVMTestTemplate> selectedTests)
        {

                string _test = string.Empty;
                int srlCount = 1;
                foreach (var item in selectedTests)
                {
                    _test += srlCount.ToString() + "." + item.Name + Environment.NewLine;
                    srlCount += 1;
                }

                txtAdvicedTests.Text = _test;

                return Task.FromResult(true);
            
        }

        private Task<bool> PopulateInitialDataPrescriptionBox(IList<RxSelectedMedicineForPatient> selectedMedicines)
        {
            string _prescription = string.Empty;
            int srlCount = 1;
            foreach(var item in selectedMedicines)
            {
                _prescription += srlCount.ToString() + "." + item.BrandName + " " + Environment.NewLine +"  "+ item.dosage + Environment.NewLine;
                srlCount += 1;
            }

            txtPrescription.Text = _prescription;

            return Task.FromResult(true);

        }

        private void PopulateClinicalFeature(RxInitialData initialDataObj)
        {

            string _title1 = "C/C: ";
            txtClinicalFeature.Text = _title1 + Environment.NewLine + initialDataObj.CC+" "+ initialDataObj.CCDuration+" "+ _InitialDataObj.CCDurationUnit + Environment.NewLine + Environment.NewLine;

            string firstLine = txtClinicalFeature.Lines[0];
            txtClinicalFeature.Select(txtClinicalFeature.GetFirstCharIndexFromLine(0), firstLine.Length);
            txtClinicalFeature.SelectionFont = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);

            txtClinicalFeature.AppendText("History:" + Environment.NewLine);
            int lineCount = txtClinicalFeature.Lines.Count();
            string phLine = txtClinicalFeature.Lines[lineCount - 2];
            txtClinicalFeature.Select(txtClinicalFeature.GetFirstCharIndexFromLine(lineCount - 2), phLine.Length);
            txtClinicalFeature.SelectionFont = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);

            txtClinicalFeature.AppendText(initialDataObj.PresentHistory + Environment.NewLine + Environment.NewLine);



            txtClinicalFeature.AppendText("Past History:" + Environment.NewLine);
            lineCount = txtClinicalFeature.Lines.Count();
            phLine = txtClinicalFeature.Lines[lineCount - 2];
            txtClinicalFeature.Select(txtClinicalFeature.GetFirstCharIndexFromLine(lineCount - 2), phLine.Length);
            txtClinicalFeature.SelectionFont = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);

            txtClinicalFeature.AppendText(initialDataObj.PastHistory + Environment.NewLine + Environment.NewLine);

            txtClinicalFeature.AppendText("On Examination:" + Environment.NewLine);
            lineCount = txtClinicalFeature.Lines.Count();
            string OELine = txtClinicalFeature.Lines[lineCount - 2];
            txtClinicalFeature.Select(txtClinicalFeature.GetFirstCharIndexFromLine(lineCount - 2), OELine.Length);
            txtClinicalFeature.SelectionFont = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);

            string Oe = string.Empty;
            if (!string.IsNullOrEmpty(initialDataObj.Height))
            {
                Oe = "Ht:" + initialDataObj.Height + initialDataObj.HeightUnit;
            }

            if (!string.IsNullOrEmpty(Oe) && !string.IsNullOrEmpty(initialDataObj.WeightInKg))
            {
                Oe += ", " + "Wt:" + initialDataObj.WeightInKg + "Kg";

            } else if (!string.IsNullOrEmpty(initialDataObj.WeightInKg))
            {
                Oe = "Wt:" + initialDataObj.WeightInKg + "Kg";
            }

            txtClinicalFeature.AppendText(Oe + Environment.NewLine);

            string pulse = string.Empty;
            pulse = "Pulse:";
            if (!string.IsNullOrEmpty(txtPulse.Text))
            {
                pulse += txtPulse.Text;
            }

            pulse = GetConcatenatedStr(pulse,cmbPulseType.Text);
            pulse = GetConcatenatedStr(pulse, cmbPulseType2.Text);
            if(!string.IsNullOrEmpty(pulse)) pulse += ". ";

            txtClinicalFeature.AppendText(pulse);

            string bp = string.Empty;
           
            if (!string.IsNullOrEmpty(txtBpErectTop.Text))
            {
                bp = "BP Sitting:"+txtBpErectTop.Text;
            }

            if (!string.IsNullOrEmpty(bp) && !string.IsNullOrEmpty(txtBPErectBottom.Text))
            {
                bp += "/"+txtBPErectBottom.Text;
            }
            
            if(!string.IsNullOrEmpty(bp)) bp +=  "mmHg;";

            string _supbp = string.Empty;

            if (!string.IsNullOrEmpty(txtBPSupineTop.Text))
            {
                _supbp += "Supine:" + txtBPSupineTop.Text;
            }

            if (!string.IsNullOrEmpty(_supbp) && !string.IsNullOrEmpty(txtBPSupineBottom.Text))
            {
                _supbp += "/" + txtBPSupineBottom.Text+ "mn";
            }

            string _bpStr = string.Empty;

            if (!string.IsNullOrEmpty(bp))
            {
                _bpStr = bp;
            }

            if(!string.IsNullOrEmpty(_bpStr) && !string.IsNullOrEmpty(_supbp))
            {
                _bpStr += ", " + _supbp;

            }else if(string.IsNullOrEmpty(_bpStr) && !string.IsNullOrEmpty(_supbp))
            {
                _bpStr = _supbp;
            }

         
            txtClinicalFeature.AppendText(_bpStr);
        }

       

        private string GetConcatenatedStr(string _combineStr, string _text)
        {
           if(!string.IsNullOrEmpty(_combineStr) && !string.IsNullOrEmpty(_text))
           {
                return _combineStr + ", " + _text;

           }else if(string.IsNullOrEmpty(_combineStr) && !string.IsNullOrEmpty(_text))
           {
                return  _text;
           }
           else
           {
                return "";
           }
        }

        void changeLine(RichTextBox RTB, int line, string text)
        {
            int s1 = RTB.GetFirstCharIndexFromLine(line);
            int s2 = line < RTB.Lines.Count() - 1 ?
                      RTB.GetFirstCharIndexFromLine(line + 1) - 1 :
                      RTB.Text.Length;
            RTB.Select(s1, s2 - s1);
            RTB.SelectedText = text;
            RTB.SelectionFont = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
        }

        private void InsertOrUpdateInitialDataObj()
        {
            if (txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                _InitialDataObj = new RxInitialData();
                _InitialDataObj.RxVisitId = _visit.RxVisitId;
                _InitialDataObj.CC = txtCC.Text;
                _InitialDataObj.CCDuration = "";
                _InitialDataObj.CCDurationUnit = "";
                _InitialDataObj.PresentHistory = txtHistoryNew.Text;
                _InitialDataObj.PastHistory = txtAdditional.Text;
                _InitialDataObj.RxInitDDate = Utils.GetServerDateAndTime();
                _InitialDataObj.RxInitDTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _InitialDataObj.RxInitDUpdateDate = Utils.GetServerDateAndTime();
                _InitialDataObj.RxInitDUpdateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _InitialDataObj.TreatmentPaln = txtTreatmentPlan.Text;
                _InitialDataObj.Prescription = txtPrescription.Text;
                _InitialDataObj.WeightInKg = txtWeight.Text;
                _InitialDataObj.Height = txtHeight.Text;
                _InitialDataObj.HeightUnit = cmbHeightUnit.Text;
                _InitialDataObj.BpErrectTop = txtBpErectTop.Text;
                _InitialDataObj.BpErrectBottom = txtBPErectBottom.Text;
                _InitialDataObj.BpSupineTop = txtBPSupineTop.Text;
                _InitialDataObj.BpSupineBottom = txtBPSupineBottom.Text;
                _InitialDataObj.Pulse = txtPulse.Text;
                _InitialDataObj.PulseBehaviour1 = cmbPulseType.Text;

                _InitialDataObj.PulseBehaviour2 = cmbPulseType2.Text;
                _InitialDataObj.OtherFindings = txtOtherFindings.Text;
                _InitialDataObj.DrugHistory = txtDrugHistory.Text;
                _InitialDataObj.IsSketchAvailable = false;
                _InitialDataObj.CommentsOrReferral = txtCommentsReferral.Text;
                _InitialDataObj.Diagnosis = txtPrescriptionDiagnosis.Text;
                _InitialDataObj.Dx = txtDiagnosisDx.Text;
                _InitialDataObj.Notes = txtNotes.Text;
               
                if (!string.IsNullOrEmpty(lblBMI.Text))
                {
                    _InitialDataObj.BMI = lblBMI.Text.Replace("BMI: ","");
                }
                else {
                    _InitialDataObj.BMI = "";
                }
               
                 if (string.IsNullOrEmpty(txtFollowUpAfter.Text))
                 {
                    _InitialDataObj.FollowUpOn = dtpFollowOn.Value;
                 }
                 else
                 {
                    _InitialDataObj.FollowUpAfter = txtFollowUpAfter.Text;
                 }

                _InitialDataObj.CreatedUserId = MainForm.LoggedinUser.UserId;
                _InitialDataObj.ModifiedUserId = MainForm.LoggedinUser.UserId;
                if (radAfter.Checked)
                {
                    _InitialDataObj.FollowUpAfter = txtFollowUpAfter.Text+" "+ cmbAfterFollowUpTimeUnit.Text;
                }

                if (radOn.Checked)
                {
                    _InitialDataObj.FollowUpOn = dtpFollowOn.Value;
                }
                else
                {
                    _InitialDataObj.FollowUpOn = null;
                }

                 new RxService().InsertOrUpdateRxInitialData(_InitialDataObj);
            }
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text.Trim()))
            {
                unlocked = true;
            }
            
            if (unlocked && !isRxDrugRowUpdateMode && !string.IsNullOrEmpty(txtBrand.Text.Trim()))
            {
                ChamberPractitioner prac = (ChamberPractitioner)panel2.Tag;

                string _txt = txtBrand.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();


                  
                        ctrlRxProductByBrand.Visible = true;
                        ctrlRxProductByGeneric.Visible = false;
                        ctrlSearchByPreferredDrug.Visible = false;

                        ctrlRxProductByBrand.txtSearch.Text = _txt;
                        ctrlRxProductByBrand.txtSearch.SelectionStart = ctrlRxProductByBrand.txtSearch.Text.Length;


                        ctrlRxProductByBrand.searchBybrand = true;
                        ctrlRxProductByBrand.LoadPhRxDataByType(_txt, "", "", prac.CPId, dgDrugs.Tag as List<VMPhProductListForRxPerspective>);
                   
                }
            }
        }

        private void ctrlRxProductByBrand_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private void ctrlRxProductByGeneric_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private void ctrlRxProductByFormarion_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            string kval = e.KeyCode.ToString();

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
            {
                isSearchByGeneric = false;
                isSearchByBrand = false;
                isSearchByPreferredMedicine = true;
            }

            if (Control.ModifierKeys== Keys.Control && e.KeyCode == Keys.G)
            {
                isSearchByGeneric = true;
                isSearchByBrand = false;
                isSearchByPreferredMedicine = false;
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.B)
            {
                isSearchByBrand = true;
                isSearchByGeneric = false;
                isSearchByPreferredMedicine = false;
            }
        }

        private  void txtDose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space && string.IsNullOrEmpty(txtDose.Text))
            {
                HideAllDefaultHidden();
                ctrlDosageSearch.Visible = true;
                ctrlDosageSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                List<RxDosage> _doseList = lbldosage.Tag as List<RxDosage>;
                if (_doseList != null)
                {
                    RxDosage item = _doseList.Where(q => q.ShortKey.ToLower().Contains(txtDose.Text.Trim().ToLower())).FirstOrDefault();
                    if (item != null)
                    {
                        txtDose.Tag = item;
                        RxPersonalPreferenceSetting prefs = btnAddDosage.Tag as RxPersonalPreferenceSetting;
                        if (prefs != null && prefs.IsDefaultDoseInEnglish)
                        {
                            if (prefs.IsDefaultDoseInShortForm)
                            {
                                txtDose.Text = item.DoseEnShort;
                            }
                            else
                            {
                                txtDose.Text = item.DoseEnLong;
                            }
                        }
                        else
                        {
                            if (prefs.IsDefaultDoseInShortForm)
                            {
                                txtDose.Text = item.DoseBnShort;
                            }
                            else
                            {
                                txtDose.Text = item.DoseBnLong;
                            }
                        }

                        
                    }
                }
                txtDurationValue.Focus();
            }

           
        }

        private async void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                if (txtBrand.Tag != null && !string.IsNullOrEmpty(txtDose.Text) && !isRxDrugRowUpdateMode)
                {
                    IsConvertedToBengli = false; // For Dose Duration

                    User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

                    int _qty = 0;
                    int.TryParse(txtQty.Text,out _qty);

                    string _dose = txtDose.Text;
                    string _duration = txtDurationValue.Text+" "+ cmbDurationUnit.Text;

                    VMPhProductListForRxPerspective _selectedProd = txtBrand.Tag as VMPhProductListForRxPerspective;

                    string Interxresult = string.Empty;

                    if (lblQty_MedicineInterX.Tag != null)
                    {
                        List<MedicineInterX> _IntexList = lblQty_MedicineInterX.Tag as List<MedicineInterX>;

                        List<MedicineInterX> _InterXObjList = _IntexList.Where(x => x.Ag1_GenericId == _selectedProd.GenericId).ToList();

                        if (_InterXObjList != null && _InterXObjList.Count>0)
                        {
                            foreach (var item in _InterXObjList)
                            {
                                RxSelectedMedicineForPatient IntexObjExist = _SelectedMedicines.Where(x => x.GenericId == item.Ag2_GenericId).FirstOrDefault();

                                if (IntexObjExist != null)
                                {
                                    Interxresult = MyMessageBox.ShowBox(item.InterX,"InterX Alert");
                                }
                            }
                        }
                        else
                        {
                            _InterXObjList = _IntexList.Where(x => x.Ag2_GenericId == _selectedProd.GenericId).ToList();
                            if (_InterXObjList != null && _InterXObjList.Count > 0)
                            {

                                foreach (var item in _InterXObjList)
                                {
                                    RxSelectedMedicineForPatient IntexObjExist = _SelectedMedicines.Where(x => x.GenericId == item.Ag1_GenericId).FirstOrDefault();

                                    if (IntexObjExist != null)
                                    {
                                        Interxresult = MyMessageBox.ShowBox(item.InterX, "InterX Alert");
                                    }
                                }
                            }
                        }

                        

                    }

                    if (!string.IsNullOrEmpty(Interxresult) && Interxresult.Equals("2")) return;


                    if (_SelectedMedicines.Any(x => x.GenericId == _selectedProd.GenericId))
                    {
                        RxSelectedMedicineForPatient Obj = _SelectedMedicines.Where(x => x.GenericId == _selectedProd.GenericId).FirstOrDefault();

                        string result = MyMessageBox.ShowBox(Obj.BrandName + " already exists in the selected list for the Generic," + _selectedProd.GenericName+". Are you sure to proceed with the selection?", "Duplicate Generic");
                        if (result.Equals("1"))
                        {
                           

                            new RxService().PopulateRxSelectedProductDataForPatient(_SelectedMedicines, txtBrand.Tag as VMPhProductListForRxPerspective, ((VMPhProductListForRxPerspective)txtBrand.Tag).ProductId.ToString(), _dose, _duration, _qty, false);
                            FillProductGrid();

                           await SaveOrUpdateTreatment();
                        }

                        if (result.Equals("2"))
                        {
                            //MessageBox.Show("Cancel Button was Clicked");
                        }
                    }
                    else
                    {

                        new RxService().PopulateRxSelectedProductDataForPatient(_SelectedMedicines, txtBrand.Tag as VMPhProductListForRxPerspective, ((VMPhProductListForRxPerspective)txtBrand.Tag).ProductId.ToString(), _dose, _duration, _qty, false);
                        FillProductGrid();

                       await SaveOrUpdateTreatment();
                    }

                    txtDose.Text = "";
                    txtDose.Tag = null;
                    txtDurationValue.Text = "";
                    unlocked = false;
                    txtBrand.Text = "";
                    txtBrand.Tag = null;
                    txtQty.Text = "";
                   // cmbDurationUnit.Text = "";
                    txtBrand.Focus();
                    unlocked = true;
                    isRxDrugRowUpdateMode = false;
                }
                else if (txtBrand.Tag != null && !string.IsNullOrEmpty(txtDose.Text) && isRxDrugRowUpdateMode)
                {
                    int qty = 0;
                    int.TryParse(txtQty.Text, out qty);
                    RxSelectedMedicineForPatient _selectedItem = (RxSelectedMedicineForPatient)txtBrand.Tag;
                    _SelectedMedicines.Where(w => w.CPPMId == _selectedItem.CPPMId && w.ProductId== _selectedItem.ProductId).ToList().ForEach(s => s.dosage = txtDose.Text);
                    _SelectedMedicines.Where(w => w.CPPMId == _selectedItem.CPPMId && w.ProductId == _selectedItem.ProductId).ToList().ForEach(s => s.duration = txtDurationValue.Text+" "+cmbDurationUnit.Text);
                    _SelectedMedicines.Where(w => w.CPPMId == _selectedItem.CPPMId && w.ProductId == _selectedItem.ProductId).ToList().ForEach(s => s.Qty = qty);
                  
                    await SaveOrUpdateTreatment();
                   
                    FillProductGrid();
                   
                    txtDose.Text = "";
                    txtDurationValue.Text = "";
                    unlocked = false;
                    txtBrand.Text = "";
                    txtBrand.Focus();
                    unlocked = true;
                    isRxDrugRowUpdateMode = false;
                }
                else
                {
                    MessageBox.Show("Brand/Dosages required. Plz check them and try again."); return;
                }
            }
        }

        private void FillProductGrid()
        {
            dgDrugs.SuspendLayout();
            dgDrugs.Rows.Clear();
            foreach(var item in _SelectedMedicines)
            {
                DataGridViewRow _row = new DataGridViewRow();
                _row.Height = 25;
                _row.Tag = item;
                _row.CreateCells(dgDrugs, item.BrandName, item.dosage, item.duration, item.Qty);
                dgDrugs.Rows.Add(_row);
            }
        }

        private void txtDurationValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(!IsConvertedToBengli)
                    txtDurationValue.Text = GetConvertedEngToBengaliStr(txtDurationValue.Text);

                cmbDurationUnit.Focus();
            }
        }

        private string GetConvertedEngToBengaliStr(string _str)
        {
            char[] chrs = new char[100];

            int count = 0;
            foreach (char c in _str)
            {
                char ch = c;
                if (Char.IsDigit(c))
                {
                    ch = (char)('\u09E6' + c - '0');
                }
                chrs[count] = ch;
                count++;
            }

            string bengali_text = new string(chrs);

            return bengali_text;
        }

        private void txtTest_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtTest.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {

                    //ChamberPractitioner prac = (ChamberPractitioner)panel2.Tag;
                    string _txt = txtTest.Text;
                    HideAllDefaultHidden();
                    ctlTestSearchControl2.Visible = true;
                    ctlTestSearchControl2.txtSearch.Text = _txt;
                    ctlTestSearchControl2.txtSearch.SelectionStart = ctlTestSearchControl2.txtSearch.Text.Length;

                    ctlTestSearchControl2.LoadData();
                }
            }

        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string _discount = string.Empty;
                double discount = 0;
                double.TryParse(txtDiscount.Text, out discount);

                if (discount > 0)
                {
                    _discount = discount.ToString();
                }

                //new RxService().PopulateRxSelectedTestData(_SelectedTests, txtTest.Tag as RxCPPreferredTest, txtTest.Text, _discount);

                FillTestGrid();

                txtDiscount.Text = "";
                txtTest.Focus();
            }
        }

        private void dgDrugs_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;
            
            RxSelectedMedicineForPatient _SelectedItem = (RxSelectedMedicineForPatient)e.Row.Tag;

            if(new RxService().DeleteRxDrug(_SelectedItem, _visit.RxVisitId))
            {
                _SelectedMedicines.Remove(e.Row.Tag as RxSelectedMedicineForPatient);
            }
            else
            {
                MessageBox.Show("Item was not deleted. Plz. check and try again.");
            }

           
        
        }

        private void dgInvestigation_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;
            
            RxVMTestTemplate _SelectedItem = (RxVMTestTemplate)e.Row.Tag;
            _SelectedTests.Remove(e.Row.Tag as RxVMTestTemplate);

            new RxService().DeleteRxTest(_SelectedItem, _visit.RxVisitId);
        }

        private void txtBPErectBottom_Leave(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(txtBPErectBottom.Text) || string.IsNullOrEmpty(txtBpErectTop.Text))
            //{
            //    MessageBox.Show("BP erect value reuired.");
            //    txtBpErectTop.Focus();
            //    return;
            //}
        }

        private void txtBPSupineBottom_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtBPSupineBottom.Text) || string.IsNullOrEmpty(txtBPSupineTop.Text))
            //{
            //    MessageBox.Show("BP supine value reuired.");
            //    txtBPSupineTop.Focus();
            //    return;
            //}
        }

        private void btnSetPreference_Click(object sender, EventArgs e)
        {
            ChamberPractitioner Practitioner;
            if (panel2.Tag != null) {

                Practitioner = (ChamberPractitioner)panel2.Tag;

            }
            else
            {
                Practitioner = new ChamberPractitioner { CPId = 0,CPSId=0, Name = "" };
            }

            frmSetPreference _frm = new frmSetPreference(Practitioner);
            _frm.Show();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            
        }

        private void FillAdviceListBox()
        {
            lstAdvices.SuspendLayout();
            lstAdvices.Items.Clear();
           
            foreach(var item in _SelectedAdvices)
            {
                lstAdvices.Items.Add(item.Advice);
            }

        }

        private void lstAdvices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                string _selectedStr= lstAdvices.GetItemText(lstAdvices.SelectedItem);
                var ObjToRemove = _SelectedAdvices.Where(x => x.Advice.Contains(_selectedStr)).FirstOrDefault();
                if (ObjToRemove != null)
                {
                    lstAdvices.Items.Remove(lstAdvices.SelectedItem);
                    _SelectedAdvices.Remove(ObjToRemove);
                    new RxService().DeleteRxAdvice(ObjToRemove, _visit.RxVisitId);
                }
            }
        }

        private void ctrlRxProductByGeneric_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private void btnAddEditSymptoms_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHideHistoryPanel_Click(object sender, EventArgs e)
        {
            pnlHistory.Location = new Point(-536, 0);
        }

        private void ctlTestSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTest.Text = "";
                txtTest.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Point screenPoint = btnLastPatient.PointToScreen(new Point(btnPrint.Left, btnPrint.Bottom));
            if (screenPoint.Y + mnuPrint.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                mnuPrint.Show(btnPrint, new Point(0, -mnuPrint.Size.Height));
            }
            else
            {
                mnuPrint.Show(btnPrint, new Point(0, btnPrint.Height));
            }
        }

        private void txtHIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _regNo = 0;
                long.TryParse(txtHIN.Text,out _regNo);
                LoadPatientDemographicData(_regNo);
            }
        }

        private async void LoadPatientDemographicData(long regNo)
        {
            int _PractitionerId = 0;
            if (panel2.Tag != null)
            {
                ChamberPractitioner _practitioner = (ChamberPractitioner)panel2.Tag;
                _PractitionerId = _practitioner.CPId;
            }
            





            RegRecord _rec = await new RegRecordService().GetRegRecordByRegNoAsync(regNo);
            if (_rec != null)
            {
                txtHIN.Tag = _rec;
                txtHIN.Text = _rec.RegNo.ToString();
                txtName.Text = _rec.Title + " " + _rec.FullName;
                txtCareOf.Text = _rec.CareOf;
                dtpDOBP.Value = _rec.DOB;
                lblAgeOnToday.Text = this.GetAgeFromDob(_rec.DOB);
                cmbGender.Text = _rec.Sex;
                txtHouse.Text = _rec.HouseNo;
                txtRoadNo.Text = _rec.RoadNo;
                cmbMaritalStatus.Text = _rec.MaritalStatus;
                txtReferredby.Text = txtRefdby.Text;
                txtPhone.Text = _rec.MobileNo;
                cmbOccupation.Text = _rec.Profession;
                cmbBloodGroup.Text = _rec.BloodGroup;
                txtSons.Text = _rec.NoOfSons;
                txtDaughter.Text = _rec.NoOfDaughters;

                if (_rec.UpazilaOrAreaId > 0)
                {
                    UpazilaOrArea _ua = new LocationService().GetUpazillaById(_rec.UpazilaOrAreaId);
                    txtArea.Text = _ua.Name;
                    txtDist.Text = new LocationService().GetDistrictById(_ua.DistrictId).Name;
                }
                else
                {
                    txtArea.Text = "";
                }

                if (_rec.Referredby > 0)
                {
                    Doctor _d = new DoctorService().GetDoctorById(_rec.Referredby);
                    txtReferredby.Text = _d.Name;
                }

                long _rxPMasterId = 0;
                RxPatientMasterData _masterData = await new RxService().GetRxMasterDataAsync(_rec.RegNo);
                if (_masterData == null)
                {
                    RxPatientMasterData _rxpMd = new RxPatientMasterData();
                    _rxpMd.RegNo = _rec.RegNo;
                    _rxpMd.RxMasterDataDate = Utils.GetServerDateAndTime();
                    _rxpMd.OperateBy = MainForm.LoggedinUser.UserId;


                    new RxService().SaveRxPatientMasterData(_rxpMd);

                    _rxPMasterId = _rxpMd.RxPMId;

                    RxVisitHistory _visit = new RxVisitHistory();
                    _visit.RxPMId = _rxPMasterId;
                    _visit.CpId = _PractitionerId;
                    _visit.VisitNo = 1;
                    _visit.VisitDate = Utils.GetServerDateAndTime();
                    _visit.AgeYear = txtYears.Text;
                    _visit.AgeMonth = txtMonths.Text;
                    _visit.AgeDay = txtDays.Text;
                    _visit.IsServiceCompleted = false;
                    new RxService().SaveRxVisitHistory(_visit);
                }
                else
                {
                    _rxPMasterId = _masterData.RxPMId;

                    RxVisitHistory _lastVisit = await new RxService().GetLastRxVisitHistoryAsync(_rxPMasterId, _PractitionerId);


                    if (_lastVisit.IsServiceCompleted)
                    {
                        RxVisitHistory _visit = new RxVisitHistory();
                        _visit.RxPMId = _rxPMasterId;
                        _visit.CpId = _PractitionerId;
                        _visit.VisitNo = _lastVisit.VisitNo + 1;
                        _visit.VisitDate = Utils.GetServerDateAndTime();
                        _visit.AgeYear = txtYears.Text;
                        _visit.AgeMonth = txtMonths.Text;
                        _visit.AgeDay = txtDays.Text;
                        _visit.IsServiceCompleted = false;
                        new RxService().SaveRxVisitHistory(_visit);
                    }

                }

                LoadLastVisitData(_rxPMasterId,_PractitionerId);
            }
        }

        private async void LoadLastVisitData(long _masterId, int practitionerId)
        {
            RxVisitHistory _visit = await new RxService().GetLastRxVisitHistoryAsync(_masterId, practitionerId);
            if (_visit != null)
            {
                txtVisitNo.Text = _visit.VisitNo.ToString();
                txtVisitNo.Tag = _visit;

                RxInitialData _initDataObj = await new RxService().GetRxInitialDataObjAsync(_visit.RxVisitId);

                if (_initDataObj != null)
                {
                    txtCC.Text = _initDataObj.CC;
                    
                    txtHistoryNew.Text = _initDataObj.PresentHistory;
                    txtAdditional.Text = _initDataObj.PastHistory;
                    txtTreatmentPlan.Text = _initDataObj.TreatmentPaln;
                    txtPrescription.Text = _initDataObj.Prescription;
                    txtWeight.Text = _initDataObj.WeightInKg;
                    txtHeight.Text = _initDataObj.Height;
                    cmbHeightUnit.Text = _initDataObj.HeightUnit;
                    txtBpErectTop.Text = _initDataObj.BpErrectTop;
                    txtBPErectBottom.Text = _initDataObj.BpErrectBottom;
                    txtBPSupineTop.Text = _initDataObj.BpSupineTop;
                    txtBPSupineBottom.Text = _initDataObj.BpSupineBottom;
                    txtPulse.Text = _initDataObj.Pulse;
                    cmbPulseType.Text = _initDataObj.PulseBehaviour1;
                    cmbPulseType2.Text = _initDataObj.PulseBehaviour2;
                    txtOtherFindings.Text = _initDataObj.OtherFindings;
                    txtDrugHistory.Text = _initDataObj.DrugHistory;

                    txtCommentsReferral.Text= _initDataObj.CommentsOrReferral;
                    txtPrescriptionDiagnosis.Text = _initDataObj.Diagnosis;
                    txtDiagnosisDx.Text= _initDataObj.Dx;
                    txtFollowUpAfter.Text = _initDataObj.FollowUpAfter;
                    lblBMI.Text = "BMI: "+_initDataObj.BMI;

                    if (_initDataObj.FollowUpOn != null)
                    {
                        dtpFollowOn.Value = _initDataObj.FollowUpOn.GetValueOrDefault();
                    }

                }
                else
                {
                    txtCC.Text = "";
                   
                    txtHistoryNew.Text = "";
                    txtAdditional.Text = "";
                    txtTreatmentPlan.Text = "";
                    txtPrescription.Text = "";
                    txtWeight.Text = "";
                    txtHeight.Text = "";
                    cmbHeightUnit.Text = "";
                    txtBpErectTop.Text = "";
                    txtBPErectBottom.Text = "";
                    txtBPSupineTop.Text = "";
                    txtBPSupineBottom.Text = "";
                    txtPulse.Text = "";
                    cmbPulseType.Text = "";
                    cmbPulseType2.Text = "";
                    txtOtherFindings.Text = "";
                    txtDrugHistory.Text = "";

                    txtFollowUpAfter.Text = "";
                    txtCommentsReferral.Text ="";
                    txtPrescriptionDiagnosis.Text = "";
                    txtDiagnosisDx.Text = "";

                }

                _SelectedTests = await new RxService().GetPatientTestsAsync(_visit.RxVisitId);
                FillTestGrid();


                _SelectedMedicines = await new RxService().GetPatientTreatmentAsync(_visit.RxVisitId);
                FillProductGrid();

                _SelectedAdvices = await new RxService().GetSelectedAdviceAsync(_visit.RxVisitId);

                PopulateAdviceList(_SelectedAdvices);

              await  PopulateInitialDataAdvicedTestBox(_SelectedTests);


            }
        }

        private async void btnCreateDrugDb_Click(object sender, EventArgs e)
        {
            ResetBooleanFlag();
            int _cpId = 0;
            ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
            if (practitioner != null) _cpId = practitioner.CPId;
            lblTemplatePanelTitle.Text = "Add/Delete Treatment Template";
            SetCreateTemplatePanelVisibleLocation(450, 0);
            await LoadRxCpTreatmentTemplates(_cpId, true);

            isCalledFromCreateTreatmentTemplateBtn = true;
           
        }

        private void ctrlSearchByPreferredDrug_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private async void btnAddEditHistory_Click(object sender, EventArgs e)
        {
            lblAddEditTitleText.Text = "Add/Delete History";
            SetHistoryPanelVisibleLocation(320,0);
            ResetBooleanFlag();
            isCalledFromHistoryBtn = true;
          
            if (panel2.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)panel2.Tag;
                await LoadHistoryData(_prac.CPId,true);
            }
        }

        private void SetHistoryPanelVisibleLocation(int x, int y)
        {
            pnlHistory.Location = new Point(x, y);
        }

        public void ResetBooleanFlag()
        {

            isCalledFromHistoryBtn = false;
            isCalledFromAdditionalInfoBtn = false;
            isCalledFromOtherFindingsBtn = false;
            isCalledFromCCBtn = false;
            isCalledfromSaveAsDiseaseTemplate = false;
            isCalledfromInsertFromDiseaseTemplate = false;
            txtTemplateDescription.Tag = null;

            isCalledFromCreateTreatmentTemplateBtn = false;
            isCalledFromInsertTreatmentTemplateBtn = false;
            isCalledFromCreateAdiceTemplateBtn = false;
            isCalledFromInsertAdiceTemplateBtn = false;
            isCalledFromCreateTestTemplateBtn = false;
            isCalledFromInsertTestTemplateBtn = false;

    }

        private async void btnAdditionalHistory_Click(object sender, EventArgs e)
        {
            lblAddEditTitleText.Text = "Add/Delete Additional Info";
            SetHistoryPanelVisibleLocation(350, 0);
            ResetBooleanFlag();
            isCalledFromAdditionalInfoBtn = true;
           
            if (panel2.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)panel2.Tag;
                await LoadPastHistoryData(_prac.CPId, true);
            }
        }

        private async void btnOtherFindings_Click(object sender, EventArgs e)
        {
            lblAddEditTitleText.Text = "Add/Delete Other Findings";
            SetHistoryPanelVisibleLocation(320, 0);
            ResetBooleanFlag();
            isCalledFromOtherFindingsBtn = true;
           
            if (panel2.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)panel2.Tag;
                await LoadOtherFindingsData(_prac.CPId, true);
            }
        }

        private void btnAddTemplateItem_Click(object sender, EventArgs e)
        {
            SaveTemplateData();
        }

        private async void SaveTemplateData()
        {
            if (panel2.Tag != null)
            {
                ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
                if (isCalledFromHistoryBtn)
                {

                    RxCPHistory _history = new RxCPHistory();
                    _history.CPId = practitioner.CPId;
                    _history.HistoryEn = txtTemplateDescription.Text.Trim();
                    new RxService().SaveRxCpHistory(_history);

                    await LoadHistoryData(practitioner.CPId, true);

                    txtTemplateDescription.Text = "";

                }
                else if (isCalledFromAdditionalInfoBtn)
                {

                    RxCPPastHistory _pasthistory = new RxCPPastHistory();
                    _pasthistory.CPId = practitioner.CPId;
                    _pasthistory.HistoryEn = txtTemplateDescription.Text.Trim();
                    new RxService().SaveRxCpPastHistory(_pasthistory);

                   await LoadPastHistoryData(practitioner.CPId, true);

                    txtTemplateDescription.Text = "";

                }
                else if (isCalledFromOtherFindingsBtn)
                {

                    RxCPOtherFinding _OtherFindings = new RxCPOtherFinding();
                    _OtherFindings.CPId = practitioner.CPId;
                    _OtherFindings.OtherFindingEn = txtTemplateDescription.Text.Trim();
                    new RxService().SaveRxCpOtherFindings(_OtherFindings);

                   await LoadOtherFindingsData(practitioner.CPId, true);

                    txtTemplateDescription.Text = "";
                }
                else if (isCalledFromCCBtn)
                {

                    RxCpCC _cc = new RxCpCC();
                    _cc.CPId = practitioner.CPId;
                    _cc.CCEn = txtTemplateDescription.Text.Trim();
                    new RxService().SaveRxCpCC(_cc);

                    await LoadCCData(practitioner.CPId, true);

                    txtTemplateDescription.Text = "";
                }
                else if (isCalledfromSaveAsDiseaseTemplate)
                {

                    RxCPDiseaseTemplate _dp = new RxCPDiseaseTemplate();
                    _dp.CpId = practitioner.CPId;
                    _dp.DiseaseName = txtTemplateDescription.Text.Trim();
                    _dp.TerminalMacAddress= MainForm.WorkStationId;
                    new RxService().SaveRxCpDiseaseTemplate(_dp);

                    RxCPDiseaseTemplateHistoricalData _hd = new RxCPDiseaseTemplateHistoricalData();
                    _hd.DTId = _dp.DTId;
                    _hd.CC = txtCC.Text;
                    _hd.PresentHistory = txtHistoryNew.Text;
                    _hd.PastHistory = txtAdditional.Text;
                    _hd.TreatmentPaln = txtTreatmentPlan.Text;
                    _hd.OtherFindings = txtOtherFindings.Text;
                    _hd.DrugHistory = txtDrugHistory.Text;
                    _hd.Diagnosis = txtPrescriptionDiagnosis.Text;
                    _hd.CommentsOrReferral = txtCommentsReferral.Text;
                    _hd.Notes = txtNotes.Text;
                    new RxService().SaveRxCPDiseaseTemplateHistoricalData(_hd);

                  
                    List<RxCPDiseaseTemplateTreatmentData> _drugList = new List<RxCPDiseaseTemplateTreatmentData>();
                    foreach (var item in _SelectedMedicines)
                    {
                        RxCPDiseaseTemplateTreatmentData _td = new RxCPDiseaseTemplateTreatmentData();
                        _td.DTId =  _dp.DTId;
                        _td.CPPMId = item.CPPMId;
                        _td.ProductId = item.ProductId;
                        _td.BrandName = item.BrandName;
                        _td.dosage = item.dosage;
                        _td.duration = item.duration;
                        _td.Qty = item.Qty;

                        _drugList.Add(_td);
                    }

                    if (_drugList.Count > 0)
                    {
                        new RxService().SaveRxCPDiseaseTemplateTreatmentData(_drugList);
                    }

                    List<RxCPDiseaseTemplateTestData> _testList = new List<RxCPDiseaseTemplateTestData>();
                    foreach (var item in _SelectedTests)
                    {
                        RxCPDiseaseTemplateTestData _testObj = new RxCPDiseaseTemplateTestData();
                        _testObj.DTId = _dp.DTId;
                        _testObj.CPPTId = item.CPPTId;
                        _testObj.TestId = item.TestId;
                        _testList.Add(_testObj);
                    }

                    if (_testList.Count > 0)
                    {
                        new RxService().SaveRxCPDiseaseTemplateTestData(_testList);
                    }

                    List<RxCPDiseaseTemplateAdviceData> _advList = new List<RxCPDiseaseTemplateAdviceData>();
                    foreach (var item in _SelectedAdvices)
                    {
                        RxCPDiseaseTemplateAdviceData _advObj = new RxCPDiseaseTemplateAdviceData();
                        _advObj.DTId = _dp.DTId;
                        _advObj.RxCpAdvId = item.RxCpAdvId;
                        _advObj.Advice = item.Advice;
                        _advList.Add(_advObj);
                    }

                    if (_advList.Count > 0)
                    {
                        new RxService().SaveRxCPDiseaseTemplateAdviceData(_advList);
                    }

                    await LoadDiseaseTemplates(practitioner.CPId, true);

                    txtTemplateDescription.Text = "";
                }
            }
        }

        private void txtTemplateDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveTemplateData();
            }

        }

        private void txtTemplateDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.X)
            {
                pnlHistory.Location = new Point(-536, 0);
            }
        }

        private void txtHistoryNew_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = (e.KeyData == (Keys.Control | Keys.Enter));
        }

        private void txtAdditional_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = (e.KeyData == (Keys.Control | Keys.Enter));

        }

        private async void btnAddEditCC_Click(object sender, EventArgs e)
        {
            lblAddEditTitleText.Text = "Add/Delete CC";
            SetHistoryPanelVisibleLocation(450,0);
            isCalledFromCCBtn = true;
            isCalledFromHistoryBtn = false;
            isCalledFromAdditionalInfoBtn = false;
            isCalledFromOtherFindingsBtn = false;
            
            if (panel2.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)panel2.Tag;
                await LoadCCData(_prac.CPId, true);
            }
        }

        private async Task<bool> LoadCCData(int cPId, bool isInListBox)
        {
            List<RxCpCC> _ccList = new RxService().GetRxCPCCData(cPId);
            txtCC.Tag = _ccList;

            List<string> _strList = new List<string>();
            foreach (var item in _ccList)
            {
                _strList.Add(item.CCEn);
            }

            if (_strList.Count > 0)
            {
                _ccArr = _strList.ToArray();
                txtCC.Values = _ccArr;
            }

            if (isInListBox)
            {
                lstboxtemplateItem.Items.Clear();
                foreach (var item in _ccList)
                {
                    lstboxtemplateItem.Items.Add(item.CCEn);
                }

            }

            return await Task.FromResult(true);

        }

        private void txtCC_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = (e.KeyData == (Keys.Control | Keys.Enter));
        }

        private void txtOtherFindings_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = (e.KeyData == (Keys.Control | Keys.Enter));
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void ctrlSearchByPreferredDrug_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {
            SaveOrUpdateTreatment();

            SaveOrUpdateAdvice();

           
            SaveOrUpdateTestData();

            InsertOrUpdateInitialDataObj();

        }

        private void SaveOrUpdateAdvice()
        {
            if (txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;
                List<RxAdviceToPatient> _advList = new List<RxAdviceToPatient>();
                foreach (var item in _SelectedAdvices)
                {
                    RxAdviceToPatient _advObj = new RxAdviceToPatient();
                    _advObj.RxVisitId = _visit.RxVisitId;
                    _advObj.RxCpAdvId = item.RxCpAdvId;
                    _advObj.Advice = item.Advice;


                    _advList.Add(_advObj);
                }

                if (_advList.Count > 0)
                {
                    new RxService().InsertOrUpdateRxAdviceData(_advList);
                }

            }
        }

        private void SaveOrUpdateTestData()
        {
            if (txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;
                List<RxTest> _testList = new List<RxTest>();
                foreach(var item in _SelectedTests)
                {
                    RxTest _testObj = new RxTest();
                    _testObj.RxVisitId = _visit.RxVisitId;
                    _testObj.TestId = item.TestId; // Central Test Id
                    _testObj.CPPTId = item.CPPTId;
                    _testObj.discountInPercent = 0;
                    _testObj.discountGross = 0;

                    _testList.Add(_testObj);
                }

                if (_testList.Count > 0)
                {
                    new RxService().InsertOrUpdateRxTestData(_testList);
                }

            }
        }
        private async Task<bool> SaveOrUpdateTreatment()
        {
            if (txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;
                List<RxDrug> _drugList = new List<RxDrug>();
                foreach(var item in _SelectedMedicines)
                {
                    RxDrug _drug = new RxDrug();
                    _drug.RxVisitId = _visit.RxVisitId;
                    _drug.CPPMId = item.CPPMId;
                    _drug.ProductId = item.ProductId;
                    _drug.BrandName = item.BrandName;
                    _drug.dosage = item.dosage;
                    _drug.duration = item.duration;
                    _drug.Qty = item.Qty;

                    _drugList.Add(_drug);
                }

                if (_drugList.Count > 0)
                {
                   await  new RxService().InsertOrUpdateRxDrugData(_drugList);
                }

            }

            return await Task.FromResult(true);
        }

        private async void tabPage2_Leave(object sender, EventArgs e)
        {
            long _regNo = 0;
           

            long.TryParse(txtHIN.Text, out _regNo);
            RxPatientMasterData _md = await new RxService().GetRxMasterDataAsync(_regNo);
            if (_md != null)
            {


                if (panel2.Tag != null)
                {
                    ChamberPractitioner _pract = (ChamberPractitioner)panel2.Tag;
                    _chamberPractitionerId = _pract.CPId;
                }


                InsertOrUpdateInitialDataObj();

                PopulateClinicalFeature(_InitialDataObj);

                
            }
        }

        private void ctrlRxCpAdviceSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtSearchAdvices.Focus();
            }
        }

        private void txtSearchAdvices_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchAdvices.Text.Length > 1 && panel2.Tag!=null && !IsSearchAdviceDisable)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)panel2.Tag;
                string _txt = txtSearchAdvices.Text;
                HideAllDefaultHidden();
                ctrlRxCpAdviceSearch.Visible = true;
                ctrlRxCpAdviceSearch.txtSearch.Text = _txt;
                ctrlRxCpAdviceSearch.txtSearch.SelectionStart = ctrlRxCpAdviceSearch.txtSearch.Text.Length;

                ctrlRxCpAdviceSearch.LoadDataByType(_prac.CPId.ToString());
            }
        }

        private void ctrlRxProductByBrand_Load(object sender, EventArgs e)
        {

        }

        private async void btnSaveasDeseaseTemplate_Click(object sender, EventArgs e)
        {
            lblAddEditTitleText.Text = "Disease Name";
            pnlHistory.Location = new Point(300, 40);
            ResetBooleanFlag();
            isCalledfromSaveAsDiseaseTemplate = true;
           
            if (panel2.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)panel2.Tag;
                await LoadDiseaseTemplates(_prac.CPId,true);
            }
        }

        private async Task<bool> LoadDiseaseTemplates(int cPId,bool isInListBox)
        {
            List<RxCPDiseaseTemplate> _tList = await new RxService().GetDiseaseTemplateListAsync(cPId);

            txtTemplateDescription.Tag = _tList;

            if (isInListBox)
            {
                lstboxtemplateItem.Items.Clear();
                foreach (var item in _tList)
                {
                    lstboxtemplateItem.Items.Add(item.DiseaseName);
                }

            }

            return await Task.FromResult(true);
        }

        private async void btnCreateTestDb_Click(object sender, EventArgs e)
        {
            ResetBooleanFlag();
            int _cpId = 0;
            ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
            if (practitioner != null) _cpId = practitioner.CPId;
            lblTemplatePanelTitle.Text = "Add/Delete Test Template";
            SetCreateTemplatePanelVisibleLocation(650, 0);
            isCalledFromCreateTestTemplateBtn = true;

            await LoadTestTemplates(_cpId, true);

        }

        private void panel6_Leave(object sender, EventArgs e)
        {
            SaveOrUpdateTestData();
        }

        private async void btnInsertfromdiseasetemplate_Click(object sender, EventArgs e)
        {
            lblAddEditTitleText.Text = "Select Disease Name";
            pnlHistory.Location = new Point(300, 40);
            ResetBooleanFlag();
            isCalledfromInsertFromDiseaseTemplate = true;

            if (panel2.Tag != null)
            {
                ChamberPractitioner _prac = (ChamberPractitioner)panel2.Tag;
                await LoadDiseaseTemplates(_prac.CPId, true);
            }
        }

        private void txtTemplateDescription_TextChanged(object sender, EventArgs e)
        {
            if(isCalledfromSaveAsDiseaseTemplate || isCalledfromInsertFromDiseaseTemplate)
            {
                List<RxCPDiseaseTemplate> _dtList = (List<RxCPDiseaseTemplate>)txtTemplateDescription.Tag;
                if (_dtList != null)
                {
                    var dtList = _dtList.Where(x => x.DiseaseName.ToLower().Contains(txtTemplateDescription.Text.Trim().ToLower())).ToList();

                    if (_dtList.Count > 0)
                    {
                        lstboxtemplateItem.Items.Clear();
                        foreach (var item in dtList)
                        {
                            lstboxtemplateItem.Items.Add(item.DiseaseName);
                        }
                    }
                    else
                    {
                        lstboxtemplateItem.Items.Clear();
                        foreach (var item in _dtList)
                        {
                            lstboxtemplateItem.Items.Add(item.DiseaseName);
                        }
                    }
                }
            }
        }

        private async void lstboxtemplateItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstboxtemplateItem.Items.Count > 0 && isCalledfromInsertFromDiseaseTemplate)
            {
                

                List<RxCPDiseaseTemplate> _dtList = (List<RxCPDiseaseTemplate>)txtTemplateDescription.Tag;
                var dtObj = _dtList.Where(x => x.DiseaseName.ToLower().Contains(lstboxtemplateItem.SelectedItem.ToString().ToLower())).FirstOrDefault();

                if (dtObj != null)
                {
                    RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;
                    new RxService().DeleteExistingTemplateDataIfAny(_visit.RxVisitId);// If any template selected previously by mistake
                    
                    pnlHistory.Location = new Point(-536, 0);

                    RxCPDiseaseTemplateHistoricalData _hd = await new RxService().GetRxCPDiseaseTemplateHistoricalData(dtObj.DTId);

                    if (_hd != null)
                    {
                        txtHistoryNew.Text = _hd.PresentHistory;
                        txtAdditional.Text = _hd.PastHistory;
                        txtTreatmentPlan.Text = _hd.TreatmentPaln;
                        txtOtherFindings.Text = _hd.OtherFindings;
                        txtDrugHistory.Text = _hd.DrugHistory;
                        txtPrescriptionDiagnosis.Text = _hd.Diagnosis;
                        txtCommentsReferral.Text = _hd.CommentsOrReferral;
                        txtNotes.Text = _hd.Notes;
                    }

                   _SelectedMedicines =  await new RxService().GetRxCPDiseaseTemplateTreatmentDataAsync(dtObj.DTId);
                    FillProductGrid();

                    _SelectedTests = await new RxService().GetRxCpDiseaseTemplateTestsAsync(dtObj.DTId);
                    FillTestGrid();

                    _SelectedAdvices = await new RxService().GetRxCpDiseaseTemplateAdvicesAsync(dtObj.DTId);

                    PopulateAdviceList(_SelectedAdvices);


                }
            
            }
        }

        private async void btnNewVisit_Click(object sender, EventArgs e)
        {
            int _visitCount = 0;
            int.TryParse(txtVisitNo.Text, out _visitCount);
            long _regNo = 0;
            long.TryParse(txtHIN.Text,out _regNo);
            RxPatientMasterData _masterData = await new RxService().GetRxMasterDataAsync(_regNo);
            if (_masterData != null)
            {
                ClearExistingData();
                LoadCarryOnBlocksBlocks(_masterData.RxPMId, _chamberPractitionerId);

                this.GetYearMonthAgeFromDob(dtpDOBP.Value, out int Yrs, out int months, out int day);

                RxVisitHistory _visit = new RxVisitHistory();
                _visit.RxPMId = _masterData.RxPMId;
                _visit.CpId = _chamberPractitionerId;
                _visit.VisitNo = _visitCount+1;
                _visit.VisitDate = Utils.GetServerDateAndTime();
                if (Yrs > 0)
                {
                    _visit.AgeYear = Yrs.ToString();
                }
                else
                {
                    _visit.AgeYear = "";
                }

                if (months > 0)
                {
                    _visit.AgeMonth = months.ToString();
                }
                else
                {
                    _visit.AgeMonth = "";
                }
                if (day > 0)
                {
                    _visit.AgeDay = day.ToString();
                }
                else
                {
                    _visit.AgeDay = "";
                }

                _visit.IsServiceCompleted = false;
                new RxService().SaveRxVisitHistory(_visit);

                txtVisitNo.Tag = _visit;
                txtVisitNo.Text = _visit.VisitNo.ToString();
             
            }
            else
            {
                MessageBox.Show("Plz. select patient and try again.");
            }
        }

        private void GetYearMonthAgeFromDob(DateTime dOB, out int yrs, out int months, out int day)
        {
            DateDiff dateDiff = new DateDiff(dOB, Utils.GetServerDateAndTime());
             yrs = dateDiff.ElapsedYears;
             months = dateDiff.ElapsedMonths;
            day = dateDiff.ElapsedDays;
        }

        private async void LoadCarryOnBlocksBlocks(long rxPMId, int chamberPractitionerId)
        {
            RxCarryOnBlock cob = new RxService().GetRxCarryOnBlocks(chamberPractitionerId);
            if (cob == null)
            {
                MessageBox.Show("Carry on settings not found. Plz. check and try again"); return;
            }

            RxVisitHistory _visit = await new RxService().GetLastRxVisitHistoryAsync(rxPMId, chamberPractitionerId);
            if (_visit != null)
            {
                //txtVisitNo.Text = _visit.VisitNo.ToString();
                //txtVisitNo.Tag = _visit;

                RxInitialData _initDataObj = await new RxService().GetRxInitialDataObjAsync(_visit.RxVisitId);

                if (_initDataObj != null)
                {
                    if (cob.ChiefComplains)
                    {
                        txtCC.Text = _initDataObj.CC;
                    }
                    else
                    {
                        txtCC.Text = "";
                    }
                    if (cob.History)
                    {
                        txtHistoryNew.Text = _initDataObj.PresentHistory;
                    }
                    else
                    {
                        txtHistoryNew.Text = "";
                    }

                    if (cob.Additional)
                    {
                        txtAdditional.Text = _initDataObj.PastHistory;
                    }
                    else
                    {
                        txtAdditional.Text = "";
                    }

                    if (cob.Diagnosis)
                    {
                        txtPrescriptionDiagnosis.Text = _initDataObj.Diagnosis;
                    }
                    else
                    {
                        txtPrescriptionDiagnosis.Text = "";
                    }

                    if (cob.Dx)
                    {
                        txtDiagnosisDx.Text = _initDataObj.Dx;
                    }
                    else
                    {
                        txtDiagnosisDx.Text = "";
                    }

                    if (cob.Notes)
                    {
                        txtNotes.Text = _initDataObj.Notes;
                    }
                    else
                    {
                        txtNotes.Text = "";
                    }


                    txtTreatmentPlan.Text = "";
                    txtPrescription.Text = "";
                    if (cob.PhysicalFindings)
                    {
                        txtWeight.Text = _initDataObj.WeightInKg;
                        txtHeight.Text = _initDataObj.Height;
                        cmbHeightUnit.Text = _initDataObj.HeightUnit;
                        txtBpErectTop.Text = _initDataObj.BpErrectTop;
                        txtBPErectBottom.Text = _initDataObj.BpErrectBottom;
                        txtBPSupineTop.Text = _initDataObj.BpSupineTop;
                        txtBPSupineBottom.Text = _initDataObj.BpSupineBottom;
                        txtPulse.Text = _initDataObj.Pulse;
                        cmbPulseType.Text = _initDataObj.PulseBehaviour1;
                        cmbPulseType2.Text = _initDataObj.PulseBehaviour2;
                        lblBMI.Text = "BMI: "+_initDataObj.BMI;
                    }
                    else
                    {
                        txtWeight.Text = "";
                        txtHeight.Text = "";
                        cmbHeightUnit.Text = "";
                        txtBpErectTop.Text = "";
                        txtBPErectBottom.Text = "";
                        txtBPSupineTop.Text = "";
                        txtBPSupineBottom.Text = "";
                        txtPulse.Text = "";
                        cmbPulseType.Text = "";
                        cmbPulseType2.Text = "";
                        lblBMI.Text = "";
                    }
                    if (cob.OtherFindings)
                    {
                        txtOtherFindings.Text = _initDataObj.OtherFindings;
                    }
                    else
                    {
                        txtOtherFindings.Text = "";
                    }

                    if (cob.DrugHistory)
                    {
                        txtDrugHistory.Text = _initDataObj.DrugHistory;
                    }
                    else
                    {
                        txtDrugHistory.Text = "";
                    }
                      

                    txtCommentsReferral.Text = _initDataObj.CommentsOrReferral;

                    if (cob.Diagnosis)
                    {
                        txtPrescriptionDiagnosis.Text = _initDataObj.DrugHistory;
                    }
                    else
                    {
                        txtPrescriptionDiagnosis.Text = "";
                    }

                   

                    txtFollowUpAfter.Text = "";

                   

                }
                else
                {
                    txtCC.Text = "";

                    txtHistoryNew.Text = "";
                    txtAdditional.Text = "";
                    txtTreatmentPlan.Text = "";
                    txtPrescription.Text = "";
                    txtWeight.Text = "";
                    txtHeight.Text = "";
                    cmbHeightUnit.Text = "";
                    txtBpErectTop.Text = "";
                    txtBPErectBottom.Text = "";
                    txtBPSupineTop.Text = "";
                    txtBPSupineBottom.Text = "";
                    txtPulse.Text = "";
                    cmbPulseType.Text = "";
                    cmbPulseType2.Text = "";
                    txtOtherFindings.Text = "";
                    txtDrugHistory.Text = "";
                    txtNotes.Text = "";
                    txtFollowUpAfter.Text = "";
                    txtCommentsReferral.Text = "";
                    txtPrescriptionDiagnosis.Text = "";

                }

                if (cob.Tests)
                {
                    _SelectedTests = await new RxService().GetPatientTestsAsync(_visit.RxVisitId);
                    FillTestGrid();
                    await PopulateInitialDataAdvicedTestBox(_SelectedTests);
                }

                if (cob.Treatment)
                {
                    _SelectedMedicines = await new RxService().GetPatientTreatmentAsync(_visit.RxVisitId);
                    FillProductGrid();
                }

                if (cob.Advices)
                {
                    _SelectedAdvices = await new RxService().GetSelectedAdviceAsync(_visit.RxVisitId);

                    PopulateAdviceList(_SelectedAdvices);
                }

               


            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            PatientSearchPanelPositionSet(false);
        }

        private void btnHideSearchPanel_Click(object sender, EventArgs e)
        {
            PatientSearchPanelPositionSet(true);
        }

        private async void btnPrevVisit_Click(object sender, EventArgs e)
        {
            if (txtVisitNo.Tag != null)
            {

                RxVisitHistory _vh = (RxVisitHistory)txtVisitNo.Tag;

                RxVisitHistory _prevVisit = await new RxService().GetRxPreviousVisit(_vh.RxPMId, _vh.VisitNo-1);
                if(_prevVisit != null)
                {
                    txtVisitNo.Tag = _prevVisit;
                    txtVisitNo.Text = _prevVisit.VisitNo.ToString();

                    await LoadinitialDatas(_prevVisit);

                    _SelectedTests = await new RxService().GetPatientTestsAsync(_prevVisit.RxVisitId);
                    FillTestGrid();


                    _SelectedMedicines = await new RxService().GetPatientTreatmentAsync(_prevVisit.RxVisitId);
                    FillProductGrid();

                    _SelectedAdvices = await new RxService().GetSelectedAdviceAsync(_prevVisit.RxVisitId);

                    PopulateAdviceList(_SelectedAdvices);
                }
                else
                {
                    MessageBox.Show("Sorry! No. record found."); return;
                }
            }
        }

        private async void btnNextVisit_Click(object sender, EventArgs e)
        {
            if (txtVisitNo.Tag != null)
            {

                RxVisitHistory _vh = (RxVisitHistory)txtVisitNo.Tag;

                RxVisitHistory _prevVisit = await new RxService().GetRxPreviousVisit(_vh.RxPMId, _vh.VisitNo + 1);
                if (_prevVisit != null)
                {
                    txtVisitNo.Tag = _prevVisit;
                    txtVisitNo.Text = _prevVisit.VisitNo.ToString();

                    await LoadinitialDatas(_prevVisit);

                    _SelectedTests = await new RxService().GetPatientTestsAsync(_prevVisit.RxVisitId);
                    FillTestGrid();


                    _SelectedMedicines = await new RxService().GetPatientTreatmentAsync(_prevVisit.RxVisitId);
                    FillProductGrid();

                    _SelectedAdvices = await new RxService().GetSelectedAdviceAsync(_prevVisit.RxVisitId);

                    PopulateAdviceList(_SelectedAdvices);
                }
                else
                {
                    MessageBox.Show("Sorry! No. record found."); return;
                }
            }
        }

        private void txtHistoryNew_TextChanged(object sender, EventArgs e)
        {
            //if (!txtHistoryNew.IsSpellCheckEnabled())
            //{
            //    MessageBox.Show("Spell check not enabled");
            //    txtHistoryNew.EnableSpellCheck();
            //}
        }

        private void btnAddEditAdv_Click(object sender, EventArgs e)
        {
            frmAddAdvices _frm = new frmAddAdvices();
            _frm.Show();
        }

        private void btnAddDosage_Click(object sender, EventArgs e)
        {
            RxPersonalPreferenceSetting _ps = btnAddDosage.Tag as RxPersonalPreferenceSetting;
            if (_ps.IsDefaultDoseFromPersonalDb)
            {
                ChamberPractitioner _practitioner = panel2.Tag as ChamberPractitioner;

                frmAddCpDosageTemplate _frm = new frmAddCpDosageTemplate();
                _frm.Text = _frm.Text + "  ("+ _practitioner.Name + ")";
                _frm.Show();
            }
            else
            {
                frmAddCentralDosageTemplate _frm = new frmAddCentralDosageTemplate();
                _frm.Show();
            }
        }

        private async void dgDrugs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDrugs.Rows.Count > 0)
            {

                if (e.ColumnIndex == 1)  //example-'Column index=1'
                {

                    string _dose = dgDrugs.CurrentRow.Cells[1].Value.ToString();
                   
                    RxSelectedMedicineForPatient _selectedItem = (RxSelectedMedicineForPatient)dgDrugs.CurrentRow.Tag;
                    _SelectedMedicines.Where(w => w.CPPMId == _selectedItem.CPPMId && w.ProductId== _selectedItem.ProductId).ToList().ForEach(s => s.dosage = _dose);

                   await SaveOrUpdateTreatment();

                }

                if (e.ColumnIndex == 2)  //example-'Column index=1'
                {

                    string _duration = dgDrugs.CurrentRow.Cells[2].Value.ToString();

                    RxSelectedMedicineForPatient _selectedItem = (RxSelectedMedicineForPatient)dgDrugs.CurrentRow.Tag;
                    _SelectedMedicines.Where(w => w.CPPMId == _selectedItem.CPPMId && w.ProductId == _selectedItem.ProductId).ToList().ForEach(s => s.duration = _duration);
                   await SaveOrUpdateTreatment();

                }

                if (e.ColumnIndex == 3)  //example-'Column index=1'
                {

                    int Qty = 0;
                    string _qty = dgDrugs.CurrentRow.Cells[3].Value.ToString();
                    int.TryParse(_qty, out Qty);
                   
                    RxSelectedMedicineForPatient _selectedItem = (RxSelectedMedicineForPatient)dgDrugs.CurrentRow.Tag;
                    _SelectedMedicines.Where(w => w.CPPMId == _selectedItem.CPPMId && w.ProductId == _selectedItem.ProductId).ToList().ForEach(s => s.Qty = Qty);
                    await SaveOrUpdateTreatment();

                }
            }
        }

        private void dgDrugs_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDrugs.Rows.Count > 0)
            {

                isRxDrugRowUpdateMode = true;
                RxSelectedMedicineForPatient _selectedItem = (RxSelectedMedicineForPatient)dgDrugs.CurrentRow.Tag;
                //_SelectedMedicines.Where(w => w.CPPMId == _selectedItem.CPPMId).ToList().ForEach(s => s.dosage = _dose);
                txtBrand.Tag = _selectedItem;
                txtBrand.Text = _selectedItem.BrandName;
                txtDose.Text = _selectedItem.dosage;
                string[] arr = _selectedItem.duration.Split(' ');
                if (arr.Length > 1)
                {
                    txtDurationValue.Text = arr[0];
                    cmbDurationUnit.Text= arr[1];
                }
                else
                {
                    txtDurationValue.Text = arr[0];
                }

                txtQty.Focus();
                
            } 
        
        }

        private void cmbDurationUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void ctrlDosageSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDose.Focus();
            }
        }

        private void btnHideTemplatePanel_Click(object sender, EventArgs e)
        {
            pnlCreateTemplate.Location = new Point(-536, 0);
        }

        private async void btnSaveAndCreateAdviceTemplate_Click(object sender, EventArgs e)
        {
            ResetBooleanFlag();
            int _cpId = 0;
            ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
            if (practitioner != null) _cpId = practitioner.CPId;
            lblTemplatePanelTitle.Text = "Add/Delete Advice Template";
            SetCreateTemplatePanelVisibleLocation(450, 0);
            isCalledFromCreateAdiceTemplateBtn = true;

           await LoadAdviceTemplates(_cpId, true);
        }

        private void SetCreateTemplatePanelVisibleLocation(int x, int y)
        {
            pnlCreateTemplate.Location = new Point(x, y);
        }

        private void btnCreateTreatmentTemplate_Click(object sender, EventArgs e)
        {
            //frmCreateRxDrugDb _frm = new frmCreateRxDrugDb();
            frmDefaultDosePersonal _frm = new frmDefaultDosePersonal();
            _frm.Show();
        }

        private void btnCreateTestTemplate_Click(object sender, EventArgs e)
        {
            frmCreatePersonalTestDb _frm = new frmCreatePersonalTestDb();
            _frm.Show();
        }

        private async void btnInsertFromAdviceTemplate_Click(object sender, EventArgs e)
        {
            ResetBooleanFlag();
            txtTemplateName.Text = "";
            int _cpId = 0;
            ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
            if (practitioner != null) _cpId = practitioner.CPId;
            lblTemplatePanelTitle.Text = "Insert From Advice Template";
            SetCreateTemplatePanelVisibleLocation(450, 0);
            await LoadAdviceTemplates(_cpId, true);
            isCalledFromInsertAdiceTemplateBtn = true;
        }

        private async void btnInsertTreatmentTemplate_Click(object sender, EventArgs e)
        {
            ResetBooleanFlag();
            txtTemplateName.Text = "";
            int _cpId = 0;
            ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
            if (practitioner != null) _cpId = practitioner.CPId;
            lblTemplatePanelTitle.Text = "Insert Treatment Template";
            SetCreateTemplatePanelVisibleLocation(450, 0);
            await LoadRxCpTreatmentTemplates(_cpId, true);

            isCalledFromInsertTreatmentTemplateBtn = true;
            
        }

        private async void btnInsertFromTestTemplate_Click(object sender, EventArgs e)
        {

            ResetBooleanFlag();
            txtTemplateName.Text = "";
            int _cpId = 0;
            ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
            if (practitioner != null) _cpId = practitioner.CPId;
            lblTemplatePanelTitle.Text = "Insert From Test Template";
            SetCreateTemplatePanelVisibleLocation(650, 0);
            await LoadTestTemplates(_cpId, true);
            isCalledFromInsertTestTemplateBtn = true;

           
        }

        private void txtTemplateName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.X)
            {
                pnlCreateTemplate.Location = new Point(-536, 0);
            }
        }

        private void txtTemplateName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InsertOrUpdateTTAdvTemplate();
            }
        }

        private async void InsertOrUpdateTTAdvTemplate()
        {
            if (panel2.Tag != null)
            {
                ChamberPractitioner practitioner = (ChamberPractitioner)panel2.Tag;
                if (isCalledFromCreateTreatmentTemplateBtn)
                {

                    RxCPDrugTemplateMaster _ttm = new RxCPDrugTemplateMaster();
                    _ttm.CPId = practitioner.CPId;
                    _ttm.Name = txtTemplateName.Text;
                    _ttm.CreateDate = Utils.GetServerDateAndTime();
                    _ttm.IsDefault = false;
                    new RxService().SaveRxCpDrugTemplateMaster(_ttm);

                    List<RxCPDrugTemplateDetail> ttdList = new List<RxCPDrugTemplateDetail>();
                    foreach (var item in _SelectedMedicines)
                    {
                        RxCPDrugTemplateDetail _testdObj = new RxCPDrugTemplateDetail();
                        _testdObj.TemplateId = _ttm.TemplateId;
                        _testdObj.ProductId = item.ProductId;
                        _testdObj.CPPMId = item.CPPMId;
                        _testdObj.Dosage = item.dosage;
                        _testdObj.Duration = item.duration;
                        _testdObj.Qty = item.Qty;
                        ttdList.Add(_testdObj);
                    }

                    if (ttdList.Count > 0)
                    {
                        new RxService().SaveRxCPTreatmentTemplateDetailData(ttdList);
                    }

                    await LoadRxCpTreatmentTemplates(practitioner.CPId, true);

                    txtTemplateName.Text = "";

                }
                else if (isCalledFromCreateAdiceTemplateBtn)
                {

                    RxCpAdviceTemplateMaster _advtm = new RxCpAdviceTemplateMaster();
                    _advtm.CPId = practitioner.CPId;
                    _advtm.Name = txtTemplateName.Text;
                    _advtm.IsDefault = false;
                    _advtm.CreateDate = Utils.GetServerDateAndTime();
                    new RxService().SaveRxCpAdviceTemplateMaster(_advtm);


                    List<RxCpAdviceTemplateDetail> advtdList = new List<RxCpAdviceTemplateDetail>();
                    foreach (var item in _SelectedAdvices)
                    {
                        
                        RxCpAdviceTemplateDetail _advdObj = new RxCpAdviceTemplateDetail();
                        _advdObj.TemplateId = _advtm.TemplateId;
                        _advdObj.Advice = item.Advice;
                        _advdObj.RxCpAdvId = item.RxCpAdvId;
                         advtdList.Add(_advdObj);
                    }

                    if (advtdList.Count > 0)
                    {
                        new RxService().SaveRxCPAdviceTemplateDetailData(advtdList);
                    }


                    await LoadAdviceTemplates(practitioner.CPId, true);

                    txtTemplateName.Text = "";

                }
                else if (isCalledFromCreateTestTemplateBtn)
                {

                    RxCPTestTemplateMaster _ttm = new RxCPTestTemplateMaster();
                    _ttm.CPId = practitioner.CPId;
                    _ttm.Name = txtTemplateName.Text;
                    _ttm.IsDefault = false;
                    _ttm.CreateDate = Utils.GetServerDateAndTime();
                    new RxService().SaveRxCpTestTemplateMaster(_ttm);

                    List<RxCPTestTemplateDetail> ttdList = new List<RxCPTestTemplateDetail>();
                    foreach (var item in _SelectedTests)
                    {
                        RxCPTestTemplateDetail _testdObj = new RxCPTestTemplateDetail();
                        _testdObj.TemplateId = _ttm.TemplateId;
                        _testdObj.TestId = item.TestId;
                        _testdObj.CPPTId = item.CPPTId;
                       
                         ttdList.Add(_testdObj);
                    }

                    if (ttdList.Count > 0)
                    {
                        new RxService().SaveRxCPTestTemplateDetailData(ttdList);
                    }

                    await LoadTestTemplates(practitioner.CPId, true);

                    txtTemplateName.Text = "";
                }
                else if (isCalledFromCCBtn)
                {

                    RxCpCC _cc = new RxCpCC();
                    _cc.CPId = practitioner.CPId;
                    _cc.CCEn = txtTemplateDescription.Text;
                    new RxService().SaveRxCpCC(_cc);

                    await LoadCCData(practitioner.CPId, true);

                    txtTemplateDescription.Text = "";
                }
               
            }
        }

        private async Task<bool> LoadTestTemplates(int cPId, bool isInListBox)
        {
            List<RxCPTestTemplateMaster> _tList = new RxService().GetRxTestMasterTemplateList(cPId);
            btnCreateTestTemplate.Tag = _tList;

            if (isInListBox)
            {
                lstTemplates.Items.Clear();
                foreach (var item in _tList)
                {
                    lstTemplates.Items.Add(item.Name);
                }

            }


            return await Task.FromResult(true);
        }

        private async Task<bool> LoadAdviceTemplates(int cPId, bool isInListBox)
        {
            List<RxCpAdviceTemplateMaster> _tList = new RxService().GetRxAdviceMasterTemplateList(cPId);
            btnSaveAndCreateAdviceTemplate.Tag = _tList;

            if (isInListBox)
            {
                lstTemplates.Items.Clear();
                foreach (var item in _tList)
                {
                    lstTemplates.Items.Add(item.Name);
                }

            }


            return await Task.FromResult(true);
        }

        private async Task<bool> LoadRxCpTreatmentTemplates(int cPId, bool isInListBox)
        {
            List<RxCPDrugTemplateMaster> _tList = new RxService().GetRxDrugMasterTemplateList(cPId);
            btnCreateTreatmentTemplate.Tag = _tList;

            if (isInListBox)
            {
                lstTemplates.Items.Clear();
                foreach (var item in _tList)
                {
                    lstTemplates.Items.Add(item.Name);
                }

            }


            return await Task.FromResult(true);
        }

        private void txtTemplateName_TextChanged(object sender, EventArgs e)
        {
            if (isCalledFromCreateTreatmentTemplateBtn || isCalledFromInsertTreatmentTemplateBtn)
            {
                List<RxCPDrugTemplateMaster> _dtList = btnCreateTreatmentTemplate.Tag as List<RxCPDrugTemplateMaster>;
                if (_dtList != null)
                {
                    var dtList = _dtList.Where(x => x.Name.ToLower().Contains(txtTemplateName.Text.Trim().ToLower())).ToList();

                    if (_dtList.Count > 0)
                    {
                        lstTemplates.Items.Clear();
                        foreach (var item in dtList)
                        {
                            lstTemplates.Items.Add(item.Name);
                        }
                    }
                    else
                    {
                        lstTemplates.Items.Clear();
                        foreach (var item in _dtList)
                        {
                            lstTemplates.Items.Add(item.Name);
                        }
                    }
                }

            }
            else if (isCalledFromCreateAdiceTemplateBtn || isCalledFromInsertAdiceTemplateBtn)
            {

                List<RxCpAdviceTemplateMaster> _dtList = btnSaveAndCreateAdviceTemplate.Tag as List<RxCpAdviceTemplateMaster>;
                if (_dtList != null)
                {
                    var dtList = _dtList.Where(x => x.Name.ToLower().Contains(txtTemplateName.Text.Trim().ToLower())).ToList();

                    if (_dtList.Count > 0)
                    {
                        lstTemplates.Items.Clear();
                        foreach (var item in dtList)
                        {
                            lstTemplates.Items.Add(item.Name);
                        }
                    }
                    else
                    {
                        lstTemplates.Items.Clear();
                        foreach (var item in _dtList)
                        {
                            lstTemplates.Items.Add(item.Name);
                        }
                    }

                }
            }
            else if (isCalledFromCreateTestTemplateBtn || isCalledFromInsertTestTemplateBtn)
            {
                List<RxCPTestTemplateMaster> _dtList = btnCreateTestTemplate.Tag as List<RxCPTestTemplateMaster>;
                if (_dtList != null)
                {
                    var dtList = _dtList.Where(x => x.Name.ToLower().Contains(txtTemplateName.Text.Trim().ToLower())).ToList();

                    if (_dtList.Count > 0)
                    {
                        lstTemplates.Items.Clear();
                        foreach (var item in dtList)
                        {
                            lstTemplates.Items.Add(item.Name);
                        }
                    }
                    else
                    {
                        lstTemplates.Items.Clear();
                        foreach (var item in _dtList)
                        {
                            lstTemplates.Items.Add(item.Name);
                        }
                    }

                }
            }
        }

        private async void lstTemplates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTemplates.Items.Count > 0 && isCalledFromInsertTreatmentTemplateBtn)
            {
                List<RxCPDrugTemplateMaster> _dtList = (List<RxCPDrugTemplateMaster>)btnCreateTreatmentTemplate.Tag;
                var dtObj = _dtList.Where(x => x.Name.ToLower().Contains(lstTemplates.SelectedItem.ToString().ToLower())).FirstOrDefault();
                if (dtObj != null)
                {
                    _SelectedMedicines = await  new RxService().GetRxCpTreatmentTemplateData(dtObj.TemplateId);
                    FillProductGrid();
                    pnlCreateTemplate.Location = new Point(-536, 0);
                    await SaveOrUpdateTreatment();

                }
            } else if (lstTemplates.Items.Count > 0 && isCalledFromInsertAdiceTemplateBtn)
            {
                List<RxCpAdviceTemplateMaster> _dtList = (List<RxCpAdviceTemplateMaster>)btnSaveAndCreateAdviceTemplate.Tag;
                var dtObj = _dtList.Where(x => x.Name.ToLower().Contains(lstTemplates.SelectedItem.ToString().ToLower())).FirstOrDefault();
                if (dtObj != null)
                {
                    _SelectedAdvices = await new RxService().GetRxCpAdviceTemplateData(dtObj.TemplateId);
                    FillAdviceListBox();
                    pnlCreateTemplate.Location = new Point(-536, 0);
                    SaveOrUpdateAdvice();

                }
            }
            else if (lstTemplates.Items.Count > 0 && isCalledFromInsertTestTemplateBtn)
            {
                List<RxCPTestTemplateMaster> _dtList = (List<RxCPTestTemplateMaster>)btnCreateTestTemplate.Tag;
                var dtObj = _dtList.Where(x => x.Name.ToLower().Contains(lstTemplates.SelectedItem.ToString().ToLower())).FirstOrDefault();
                if (dtObj != null)
                {
                    _SelectedTests = await new RxService().GetRxCpTestTemplateData(dtObj.TemplateId);
                    FillTestGrid();
                    pnlCreateTemplate.Location = new Point(-536, 0);
                    SaveOrUpdateTestData();
                }
            }
        }

        private async void btnRefreshPage_Click(object sender, EventArgs e)
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            _chamberPractitionerId = _user.ChamberPractitionerId;
            if (_chamberPractitionerId == 0)
            {
                _chamberPractitionerId = _user.CpId;
            }
            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_chamberPractitionerId);

            if (Practitioner != null)
            {

                panel2.Tag = Practitioner;

                _chamberPractitionerId = Practitioner.CPId;
               
                Task t1 = Task.Run(() => LoadRxDurationUnits());
                //await LoadRxDurationUnits();

                Task t2 = Task.Run(() => LoadRxAdvices(Practitioner.CPId));
                //await LoadRxAdvices(Practitioner.CPId);

                Task t3 = Task.Run(() => LoadCPRelatedSettingsData(Practitioner.CPId));

                //await LoadCPRelatedSettingsData(Practitioner.CPId);

                Task t4 = Task.Run(() => LoadPrinterSettings(Practitioner.CPId));
                //await LoadPrinterSettings(Practitioner.CPId);

                

                Task t5 = Task.Run(() => LoadPersonalPreference(Practitioner.CPId));

                

                Task t6 = Task.Run(() => LoadMedicines());

                await Task.WhenAll(t1, t2, t3, t4, t5, t6);

                MessageBox.Show("Refresh done, Thanks.");
            }
            else
            {
                MessageBox.Show("Practioner not found."); return;
            }
        }

        private void ctlTestSearchControl2_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTest.Focus();
            }
        }

        private void btnEditPInfo_Click(object sender, EventArgs e)
        {
            IsPatientInEditMode = true;
            NewPatientEntryPanelPostionSet(false);
            RegRecord _rec = txtHIN.Tag as RegRecord;
            cmbTitle.Tag = _rec;

            cmbTitle.Text = _rec.Title;
            txtPatientName.Text = _rec.FullName;
            txtYears.Text = _rec.AgeYear;
            txtMonths.Text = _rec.AgeMonth;
            txtDays.Text = _rec.AgeDay;
            dtpDOB.Value = _rec.DOB;
            txtFatherName.Text = _rec.FatherName;
            txtMotherName.Text = _rec.MotherName;
            cmbGenderNE.Text = _rec.Sex;
            cmbOccupationNE.Text = _rec.Profession;
            cmbMaritalStatusNE.Text = _rec.MaritalStatus;
            txtHouseNo.Text = _rec.HouseNo;
            txtRoadNo.Text = _rec.RoadNo;
            txtVillage.Text = _rec.Village;
            txtphoneNumbersNE.Text = _rec.MobileNo;
            txtEmailAddress.Text = _rec.EmailId;
            txtLocalGurdianHouseNo.Text = _rec.CPHouseNo;
            txtLocalGurdianRoadNo.Text = _rec.CPRoadNo;
            txtPO.Text = _rec.PO;
            txtNoOfSons.Text = _rec.NoOfSons;
            cmbBGroup.Text = _rec.BloodGroup;

            Doctor _d = new DoctorService().GetDoctorById(_rec.Referredby);
            if (_d != null)
            {
                txtRefdby.Text = _d.Name;
                txtRefdby.Tag = _d;
            }

            IsPatientInEditMode = false;

        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            DialogResult _result = MessageBox.Show("Are you sure to clear the fields?", "Confirmation", MessageBoxButtons.YesNo);
            if(_result == DialogResult.Yes)
            {
                ClearNewEntryPanelField();
                
            }
        }

        private void cmbTitle_Leave(object sender, EventArgs e)
        {
            TitleOrNamePrefix _prefix = cmbTitle.SelectedItem as TitleOrNamePrefix;
            if (_prefix != null)
            {
                cmbGenderNE.Text = _prefix.Gender;
            }
        }

        private  void txtYears_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private async void SaveOrUpdateRegistrationData()
        {
            int _slefAreaId = 0;
            int _localGurdianAreaId = 0;
            int _chamberPractitionerId = 0;
            int _refdbyId = 0;

            IsPatientInEditMode = false;

            if (txtRefdby.Tag != null)
            {
                Doctor _doc = (Doctor)txtRefdby.Tag;
                _refdbyId = _doc.DoctorId;
            }

            if (panel2.Tag != null)
            {
                ChamberPractitioner _pract = (ChamberPractitioner)panel2.Tag;
                _chamberPractitionerId = _pract.CPId;
            }

            UpazilaOrArea _upAreaSelf = (UpazilaOrArea)cmbAreaOrThana.SelectedItem;
            if (_upAreaSelf != null)
            {
                _slefAreaId = _upAreaSelf.UpazilaId;
            }

            UpazilaOrArea _upAreaLG = (UpazilaOrArea)cmbLocalGurdianThana.SelectedItem;
            if (_upAreaLG != null)
            {
                _localGurdianAreaId = _upAreaLG.UpazilaId;
            }

            int _refdId = 0;
            if (txtRefdby.Tag != null)
            {
                Doctor _doc = (Doctor)txtRefdby.Tag;
                _refdId = _doc.DoctorId;
            }


            if (IsValidEntry(out string msg))
            {
                if (cmbTitle.Tag != null)
                {
                    RegRecord _regRecord = cmbTitle.Tag as RegRecord;
                    _regRecord.RegHex = "";
                    _regRecord.Title = cmbTitle.Text;
                    _regRecord.FirstName = "";
                    _regRecord.MiddleName = "";
                    _regRecord.LastName = "";
                    _regRecord.FullName = txtPatientName.Text; //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _regRecord.AgeYear = txtYears.Text;
                    _regRecord.AgeMonth = txtMonths.Text;
                    _regRecord.AgeDay = txtDays.Text;
                    _regRecord.DOB = dtpDOB.Value;
                    _regRecord.Sex = cmbGenderNE.Text;
                    _regRecord.MobileNo = txtphoneNumbersNE.Text;
                    _regRecord.EmailId = txtEmailAddress.Text;
                    _regRecord.FatherName = txtFatherName.Text;
                    _regRecord.MotherName = txtMotherName.Text;
                    _regRecord.HouseNo = txtHouseNo.Text;
                    _regRecord.RoadNo = txtRoadNo.Text;
                    _regRecord.Village = txtVillage.Text;
                    _regRecord.PO = txtPO.Text;
                    _regRecord.CareOf = txtCareOfNE.Text;
                    _regRecord.NationalId = "";
                    _regRecord.CPHouseNo = txtLocalGurdianHouseNo.Text;
                    _regRecord.CPRoadNo = txtLocalGurdianRoadNo.Text;
                    _regRecord.CPVillage = txtLocalGurdianVillage.Text;
                    _regRecord.CPPo = txtLocalGurdianPO.Text;
                    _regRecord.CompanyId = 0;
                    _regRecord.Status = "";
                    _regRecord.DesignationId = 0;
                    _regRecord.MaritalStatus = cmbMaritalStatusNE.Text;
                    _regRecord.Profession = cmbOccupationNE.Text;
                    _regRecord.UpazilaOrAreaId = _slefAreaId;
                    _regRecord.LocalGurdianUpazilaOrAreaId = _localGurdianAreaId;
                    _regRecord.UnionId = 0;
                    _regRecord.BloodGroup = cmbBGroup.Text;
                    _regRecord.CpId = _chamberPractitionerId;
                    _regRecord.Referredby = _refdbyId;
                    _regRecord.Discount = 0;
                    _regRecord.NoOfSons = txtNoOfSons.Text;
                    _regRecord.NoOfDaughters = txtNoOfDaughter.Text;
                    _regRecord.RegDate = Utils.GetServerDateAndTime();
                    _regRecord.IsRegisterd = false;

                    new RegRecordService().UpdateRegRecord(_regRecord);

                    if (_regRecord != null)
                    {
                        RegRecord _rec = new RegRecordService().GetRegRecordById(_regRecord.Id);
                        txtHIN.Tag = _rec;
                        txtName.Text = _rec.Title + " " + _rec.FullName;
                        txtCareOf.Text = _rec.CareOf;
                        dtpDOBP.Value = _rec.DOB;
                        lblAgeOnToday.Text = this.GetAgeFromDob(_rec.DOB);
                        cmbGender.Text = _rec.Sex;
                        txtHouse.Text = _rec.HouseNo;
                        txtRoadNo.Text = _rec.RoadNo;
                        cmbMaritalStatus.Text = _rec.MaritalStatus;
                        txtReferredby.Text = txtRefdby.Text;
                        txtPhone.Text = _rec.MobileNo;
                        cmbOccupation.Text = _rec.Profession;
                        cmbBloodGroup.Text = _rec.BloodGroup;
                        txtSons.Text = _rec.NoOfSons;
                        txtDaughter.Text = _rec.NoOfDaughters;

                        if (_rec.UpazilaOrAreaId > 0)
                        {
                            UpazilaOrArea _ua = new LocationService().GetUpazillaById(_rec.UpazilaOrAreaId);
                            txtArea.Text = _ua.Name;
                            txtDist.Text = new LocationService().GetDistrictById(_ua.DistrictId).Name;
                        }
                        else
                        {
                            txtArea.Text = "";
                        }

                        if (_rec.Referredby > 0)
                        {
                            Doctor _d = new DoctorService().GetDoctorById(_rec.Referredby);
                            txtReferredby.Text = _d.Name;
                        }
                    }


                  

                    NewPatientEntryPanelPostionSet(true);

                    //MessageBox.Show("Record saved successfully.");

                    ClearNewEntryPanelField();



                }
                else
                {
                    RegRecord _regRecord = new RegRecord();
                    _regRecord.RegNo = 0;
                    _regRecord.RegHex = "";
                    _regRecord.Title = cmbTitle.Text;
                    _regRecord.FirstName = "";
                    _regRecord.MiddleName = "";
                    _regRecord.LastName = "";
                    _regRecord.FullName = txtPatientName.Text; //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _regRecord.AgeYear = txtYears.Text;
                    _regRecord.AgeMonth = txtMonths.Text;
                    _regRecord.AgeDay = txtDays.Text;
                    _regRecord.DOB = dtpDOB.Value;
                    _regRecord.Sex = cmbGenderNE.Text;
                    _regRecord.MobileNo = txtphoneNumbersNE.Text;
                    _regRecord.EmailId = txtEmailAddress.Text;
                    _regRecord.FatherName = txtFatherName.Text;
                    _regRecord.MotherName = txtMotherName.Text;
                    _regRecord.HouseNo = txtHouseNo.Text;
                    _regRecord.RoadNo = txtRoadNo.Text;
                    _regRecord.Village = txtVillage.Text;
                    _regRecord.PO = txtPO.Text;
                    _regRecord.CareOf = txtCareOfNE.Text;
                    _regRecord.NationalId = "";
                    _regRecord.CPHouseNo = txtLocalGurdianHouseNo.Text;
                    _regRecord.CPRoadNo = txtLocalGurdianRoadNo.Text;
                    _regRecord.CPVillage = txtLocalGurdianVillage.Text;
                    _regRecord.CPPo = txtLocalGurdianPO.Text;
                    _regRecord.CompanyId = 0;
                    _regRecord.Status = "";
                    _regRecord.DesignationId = 0;
                    _regRecord.MaritalStatus = cmbMaritalStatusNE.Text;
                    _regRecord.Profession = cmbOccupationNE.Text;
                    _regRecord.UpazilaOrAreaId = _slefAreaId;
                    _regRecord.LocalGurdianUpazilaOrAreaId = _localGurdianAreaId;
                    _regRecord.UnionId = 0;
                    _regRecord.BloodGroup = cmbBGroup.Text;
                    _regRecord.CpId = _chamberPractitionerId;
                    _regRecord.Referredby = _refdbyId;
                    _regRecord.Discount = 0;
                    _regRecord.NoOfSons = txtNoOfSons.Text;
                    _regRecord.NoOfDaughters = txtNoOfDaughter.Text;
                    _regRecord.RegDate = Utils.GetServerDateAndTime();
                    _regRecord.IsRegisterd = false;
                    // _regRecord.Present_DistrictId = Convert.ToInt32(cmbDivision.SelectedValue);

                    RegRecord _recordSaved = new RegRecordService().SaveRegRecord(_regRecord);

                    if (_recordSaved != null)
                    {
                        RegRecord _rec = new RegRecordService().GetRegRecordById(_recordSaved.Id);
                        txtHIN.Tag = _rec;
                        txtHIN.Text = _rec.RegNo.ToString();
                        txtName.Text = _rec.Title + " " + _rec.FullName;
                        txtCareOf.Text = _rec.CareOf;
                        dtpDOBP.Value = _rec.DOB;
                        lblAgeOnToday.Text = this.GetAgeFromDob(_rec.DOB);
                        cmbGender.Text = _rec.Sex;
                        txtHouse.Text = _rec.HouseNo;
                        txtRoadNo.Text = _rec.RoadNo;
                        cmbMaritalStatus.Text = _rec.MaritalStatus;
                        txtReferredby.Text = txtRefdby.Text;
                        txtPhone.Text = _rec.MobileNo;
                        cmbOccupation.Text = _rec.Profession;
                        cmbBloodGroup.Text = _rec.BloodGroup;
                        txtSons.Text = _rec.NoOfSons;
                        txtDaughter.Text = _rec.NoOfDaughters;

                        if (_rec.UpazilaOrAreaId > 0)
                        {
                            UpazilaOrArea _ua = new LocationService().GetUpazillaById(_rec.UpazilaOrAreaId);
                            txtArea.Text = _ua.Name;
                            txtDist.Text = new LocationService().GetDistrictById(_ua.DistrictId).Name;
                        }
                        else
                        {
                            txtArea.Text = "";
                        }

                        if (_rec.Referredby > 0)
                        {
                            Doctor _d = new DoctorService().GetDoctorById(_rec.Referredby);
                            txtReferredby.Text = _d.Name;
                        }

                        //int _visitNo = 1;
                        long _rxPMasterId = 0;
                        RxPatientMasterData _masterData = await new RxService().GetRxMasterDataAsync(_rec.RegNo);
                        if (_masterData == null)
                        {
                            RxPatientMasterData _rxpMd = new RxPatientMasterData();
                            _rxpMd.RegNo = _rec.RegNo;
                            _rxpMd.RxMasterDataDate = Utils.GetServerDateAndTime();
                            _rxpMd.OperateBy = MainForm.LoggedinUser.UserId;


                            new RxService().SaveRxPatientMasterData(_rxpMd);

                            _rxPMasterId = _rxpMd.RxPMId;

                            RxVisitHistory _visit = new RxVisitHistory();
                            _visit.RxPMId = _rxPMasterId;
                            _visit.CpId = _chamberPractitionerId;
                            _visit.VisitNo = 1;
                            _visit.VisitDate = Utils.GetServerDateAndTime();
                            _visit.AgeYear = txtYears.Text;
                            _visit.AgeMonth = txtMonths.Text;
                            _visit.AgeDay = txtDays.Text;
                            _visit.IsServiceCompleted = false;
                            new RxService().SaveRxVisitHistory(_visit);

                            txtVisitNo.Tag = _visit;
                            txtVisitNo.Text = "1";
                        }
                        else
                        {
                            _rxPMasterId = _masterData.RxPMId;

                            RxVisitHistory _lastVisit = await new RxService().GetLastRxVisitHistoryAsync(_rxPMasterId, _chamberPractitionerId);


                            if (_lastVisit.IsServiceCompleted)
                            {
                                RxVisitHistory _visit = new RxVisitHistory();
                                _visit.RxPMId = _rxPMasterId;
                                _visit.CpId = _chamberPractitionerId;
                                _visit.VisitNo = _lastVisit.VisitNo + 1;
                                _visit.VisitDate = Utils.GetServerDateAndTime();
                                _visit.AgeYear = txtYears.Text;
                                _visit.AgeMonth = txtMonths.Text;
                                _visit.AgeDay = txtDays.Text;
                                _visit.IsServiceCompleted = false;
                                new RxService().SaveRxVisitHistory(_visit);

                                txtVisitNo.Tag = _visit;
                                txtVisitNo.Text = (_lastVisit.VisitNo + 1).ToString();
                            }

                        }



                        ClearExistingData();

                        NewPatientEntryPanelPostionSet(true);

                        //MessageBox.Show("Record saved successfully.");

                        ClearNewEntryPanelField();
                    }

                }
            }
            else
            {
                MessageBox.Show(msg + " required.");
            }
        }

        private void txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtMonths_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtMotherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void cmbOccupationNE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void cmbMaritalStatusNE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void cmbBGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtNoOfSons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtNoOfDaughter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtCareOfNE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtphoneNumbersNE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtHouseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtVillage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtRoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtRefdby_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private async void txtDose_Leave(object sender, EventArgs e)
        {
            if (txtBrand.Tag != null && txtDose.Tag!=null)
            {
                VMPhProductListForRxPerspective _phprod = txtBrand.Tag as VMPhProductListForRxPerspective;
                RxDosage item = txtDose.Tag as RxDosage;
                if (_phprod.DoseId == 0)
                {
                    new RxService().SetDoseAsDefault(_phprod, item);

                    Task t6 = Task.Run(() => LoadMedicines());

                    await Task.WhenAll(t6);
                }
            }


        }

        private void btnPrevPatinet_Click(object sender, EventArgs e)
        {
            long currentVisitId = 0;
            if (txtHIN.Tag != null && txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = txtVisitNo.Tag as RxVisitHistory;
                currentVisitId = _visit.RxVisitId;
                if (_visit != null)
                {
                    RxVMPatientBasicInfo _patient = new RxService().GetPreviousPatient(currentVisitId, _chamberPractitionerId);
                    if (_patient != null)
                    {
                        LoadPatientDemographicData(_patient.RegNo);

                    }
                
                }
            }else if(txtHIN.Tag != null)
            {
                //MessageBox.Show("");
            }
            
        }

        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            long currentVisitId = 0;
            if (txtHIN.Tag != null && txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = txtVisitNo.Tag as RxVisitHistory;
                currentVisitId = _visit.RxVisitId;
                if (_visit != null)
                {
                    RxVMPatientBasicInfo _patient = new RxService().GetNextPatient(currentVisitId, _chamberPractitionerId);
                    if (_patient != null)
                    {
                        LoadPatientDemographicData(_patient.RegNo);

                    }

                }
            }
            else if (txtHIN.Tag != null)
            {
                //MessageBox.Show("");
            }
        }

        private void btnLastPatient_Click(object sender, EventArgs e)
        {
            long currentVisitId = 0;
            if (txtHIN.Tag != null && txtVisitNo.Tag != null)
            {
                RxVisitHistory _visit = txtVisitNo.Tag as RxVisitHistory;
                currentVisitId = _visit.RxVisitId;
                if (_visit != null)
                {
                    RxVMPatientBasicInfo _patient = new RxService().GetLastPatient(currentVisitId, _chamberPractitionerId);
                    if (_patient != null)
                    {
                        LoadPatientDemographicData(_patient.RegNo);

                    }

                }
            }
            else if (txtHIN.Tag != null)
            {
                //MessageBox.Show("");
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                FilterPatient(txtSearchByName.Text, "PName");
            }

           
        }

        private void FilterPatient(string searchStr, string param)
        {
            List<RxVMPatientBasicInfo> _lisPatientInfo = pnlSearchPatient.Tag as List<RxVMPatientBasicInfo>;

            if (!string.IsNullOrEmpty(searchStr.Trim()))
            {
                if (param.Equals("RegNo"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.RegNo.ToString().ToLower().Contains(searchStr.Trim().ToLower())).ToList();

                if (param.Equals("PName"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.Name.ToLower().Contains(searchStr.Trim().ToLower())).ToList();

                if (param.Equals("MobileNo"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.MobileNo.ToString().Contains(searchStr.Trim().ToLower())).ToList();

                if (param.Equals("Address"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.Address.ToLower().Contains(searchStr.Trim().ToLower())).ToList();

                

            }

            if (_lisPatientInfo == null || _lisPatientInfo.Count() == 0) return;



            FillPatientList(_lisPatientInfo);

        }

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByMobile.Text.Trim() == "Search by Mobile No")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                FilterPatient(txtSearchByMobile.Text, "MobileNo");
            }
        }

        private void txtSearchByRegNo_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByRegNo.Text.Trim() == "Search by Mobile No")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                FilterPatient(txtSearchByRegNo.Text, "RegNo");
            }
        }

        private void txtSearchByAddess_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByAddess.Text.Trim() == "Search by Address")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                FilterPatient(txtSearchByAddess.Text, "Address");
            }
        }

        private void dgPatient_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RxVMPatientBasicInfo _patient = dgPatient.SelectedRows[0].Tag as RxVMPatientBasicInfo;
            if (_patient != null)
            {
                LoadPatientDemographicData(_patient.RegNo);
                PatientSearchPanelPositionSet(true);
            }
        }

        private void txtRefdby_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                SaveOrUpdateRegistrationData();
            }
        }

        private void txtEarlierDoc1_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtEarlierDoc1.Text, out itemId))
            {

            }
            else
            {

                string _txt = txtEarlierDoc1.Text;
                if (!string.IsNullOrEmpty(_txt) && !IsPatientInEditMode)
                {
                    HideAllDefaultHidden();
                    ctrlEarlierDoc1.Visible = true;
                    ctrlEarlierDoc1.txtSearch.Text = _txt;
                    ctrlEarlierDoc1.txtSearch.SelectionStart = ctrlEarlierDoc1.txtSearch.Text.Length;

                    ctrlEarlierDoc1.LoadData();
                }

            }
        }

        private void txtEarlierDoc2_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtEarlierDoc2.Text, out itemId))
            {

            }
            else
            {

                string _txt = txtEarlierDoc2.Text;
                if (!string.IsNullOrEmpty(_txt) && !IsPatientInEditMode)
                {
                    HideAllDefaultHidden();
                    ctrlEarlierDoc2.Visible = true;
                    ctrlEarlierDoc2.txtSearch.Text = _txt;
                    ctrlEarlierDoc2.txtSearch.SelectionStart = ctrlEarlierDoc2.txtSearch.Text.Length;

                    ctrlEarlierDoc2.LoadData();
                }

            }
        }

        private void txtEarlierDoc3_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtEarlierDoc3.Text, out itemId))
            {

            }
            else
            {

                string _txt = txtEarlierDoc3.Text;
                if (!string.IsNullOrEmpty(_txt) && !IsPatientInEditMode)
                {
                    HideAllDefaultHidden();
                    ctrlEarlierDoc3.Visible = true;
                    ctrlEarlierDoc3.txtSearch.Text = _txt;
                    ctrlEarlierDoc3.txtSearch.SelectionStart = ctrlEarlierDoc3.txtSearch.Text.Length;

                    ctrlEarlierDoc3.LoadData();
                }

            }
        }

        private void txtEarlierDoc4_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtEarlierDoc4.Text, out itemId))
            {

            }
            else
            {

                string _txt = txtEarlierDoc4.Text;
                if (!string.IsNullOrEmpty(_txt) && !IsPatientInEditMode)
                {
                    HideAllDefaultHidden();
                    ctrlEarlierDoc4.Visible = true;
                    ctrlEarlierDoc4.txtSearch.Text = _txt;
                    ctrlEarlierDoc4.txtSearch.SelectionStart = ctrlEarlierDoc4.txtSearch.Text.Length;

                    ctrlEarlierDoc4.LoadData();
                }

            }
        }

        private void txtEarlierDoc5_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtEarlierDoc5.Text, out itemId))
            {

            }
            else
            {

                string _txt = txtEarlierDoc5.Text;
                if (!string.IsNullOrEmpty(_txt) && !IsPatientInEditMode)
                {
                    HideAllDefaultHidden();
                    ctrlEarlierDoc5.Visible = true;
                    ctrlEarlierDoc5.txtSearch.Text = _txt;
                    ctrlEarlierDoc5.txtSearch.SelectionStart = ctrlEarlierDoc5.txtSearch.Text.Length;

                    ctrlEarlierDoc5.LoadData();
                }

            }
        }

        private void txtEarlierDoc6_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtEarlierDoc6.Text, out itemId))
            {

            }
            else
            {

                string _txt = txtEarlierDoc6.Text;
                if (!string.IsNullOrEmpty(_txt) && !IsPatientInEditMode)
                {
                    HideAllDefaultHidden();
                    ctrlEarlierDoc6.Visible = true;
                    ctrlEarlierDoc6.txtSearch.Text = _txt;
                    ctrlEarlierDoc6.txtSearch.SelectionStart = ctrlEarlierDoc6.txtSearch.Text.Length;

                    ctrlEarlierDoc6.LoadData();
                }

            }
        }

        private void cmbTitle_SelectedValueChanged(object sender, EventArgs e)
        {
            TitleOrNamePrefix _prefix = cmbTitle.SelectedItem as TitleOrNamePrefix;
            if (_prefix != null)
            {
                cmbGenderNE.Text = _prefix.Gender;
            }
        }

        private void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ctrlRxProductByGeneric.Visible = false;
                if (txtBrand.Tag != null)
                {
                    PickSelectedProduct(txtBrand.Tag as VMPhProductListForRxPerspective);
                }

                txtDose.Focus();
            }
        }

        private void frmRxViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
            {
                RxPrintPreference printPref = btnPdf.Tag as RxPrintPreference;

                if (printPref.PrintFormat1)
                {
                    PrintFullPrescriptionFormat1();
                }
                else if(printPref.PrintFormat2)
                {
                    PrintFullPrescriptionFormat2();
                }
                else if (printPref.PrintFormat3)
                {
                    PrintFullPrescriptionFormat3();
                }
                else if (printPref.PrintFormat4)
                {
                    PrintFullPrescriptionFormat4();
                }
                else if (printPref.PrintFormat5)
                {
                    //PrintFullPrescriptionFormat5();
                }
                else if (printPref.PrintFormat6)
                {
                    //PrintFullPrescriptionFormat6();
                }
                else if (printPref.PrintFormat7)
                {
                   // PrintFullPrescriptionFormat7();
                }
                else if (printPref.PrintFormat8)
                {
                    //PrintFullPrescriptionFormat8();
                }
            }
        }

        private async void PrintFullPrescriptionFormat4()
        {
            if (txtVisitNo.Tag != null && btnPrint.Tag != null)
            {

                List<RxCPPrintPageSetup> _psetup = (List<RxCPPrintPageSetup>)btnPrint.Tag;
                RxCPPrintPageSetup setupObj = _psetup.Where(x => x.PageType == RxPageTypeEnum.FullPrescription.ToString()).FirstOrDefault();


                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                await LoadPrinterSettings(_visit.CpId);

                new RxService().AccumulatePrescriptionDataVer2(_visit.RxVisitId, _visit.CpId);

                
                rptRxFullPrescriptionVer4 _rx = new rptRxFullPrescriptionVer4();

                DataSet _ds = new RxService().GetRxFullDataSetVer2(_visit.RxVisitId, _visit.CpId);
                _rx.SetDataSource(_ds);
                int _top = Convert.ToInt32(setupObj.TopMargin * 1000);
                _rx.ReportDefinition.Sections["Section2"].Height = _top;


                ReportViewer rv = new ReportViewer();

                PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();

                int _left = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _top2 = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _right = Convert.ToInt32(setupObj.RightMargin * 100);
                int _bottom = Convert.ToInt32(setupObj.BottomMargin * 100);

                PageMargins margins = new PageMargins();

                margins = _rx.PrintOptions.PageMargins;
                margins.bottomMargin = _bottom;
                margins.leftMargin = _left;
                margins.rightMargin = _right;
                margins.topMargin = _top2;
                _rx.PrintOptions.ApplyPageMargins(margins);

                // _rx.PrintOptions.PrinterName = "Canon LBP6030/6040/6018L XPS";



                rv.crviewer.ReportSource = _rx;

                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintMode = PrintMode.PrintToPrinter;
                //rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private async void PrintFullPrescriptionFormat2()
        {
            if (txtVisitNo.Tag != null && btnPrint.Tag != null)
            {

                List<RxCPPrintPageSetup> _psetup = (List<RxCPPrintPageSetup>)btnPrint.Tag;
                RxCPPrintPageSetup setupObj = _psetup.Where(x => x.PageType == RxPageTypeEnum.FullPrescription.ToString()).FirstOrDefault();


                RxVisitHistory _visit = (RxVisitHistory)txtVisitNo.Tag;

                await LoadPrinterSettings(_visit.CpId);

                new RxService().AccumulatePrescriptionDataVer3(_visit.RxVisitId, _visit.CpId);

                rptRxFullPrescriptionVer2 _rx = new rptRxFullPrescriptionVer2();


                DataSet _ds = new RxService().GetRxFullDataSetForPrintV3(_visit.RxVisitId, _visit.CpId);
                _rx.SetDataSource(_ds);
                int _top = Convert.ToInt32(setupObj.TopMargin * 1000);
                _rx.ReportDefinition.Sections["Section1"].Height = _top;


                ReportViewer rv = new ReportViewer();

                PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();

                int _left = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _top2 = Convert.ToInt32(setupObj.LeftMargin * 100);
                int _right = Convert.ToInt32(setupObj.RightMargin * 100);
                int _bottom = Convert.ToInt32(setupObj.BottomMargin * 100);

                PageMargins margins = new PageMargins();

                margins = _rx.PrintOptions.PageMargins;
                margins.bottomMargin = _bottom;
                margins.leftMargin = _left;
                margins.rightMargin = _right;
                margins.topMargin = _top2;
                _rx.PrintOptions.ApplyPageMargins(margins);

                // _rx.PrintOptions.PrinterName = "Canon LBP6030/6040/6018L XPS";



                rv.crviewer.ReportSource = _rx;

                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintMode = PrintMode.PrintToPrinter;
                //rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private void ctrlEarlierDoc3_Load(object sender, EventArgs e)
        {

        }

        private void lstboxtemplateItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                string _selectedStr = lstboxtemplateItem.GetItemText(lstboxtemplateItem.SelectedItem);
                if (isCalledFromCCBtn)
                {
                    new RxService().DeleteRxSavedCC(_chamberPractitionerId,_selectedStr);
                }

                if (isCalledFromHistoryBtn)
                {
                    new RxService().DeleteRxCpSavedHistory(_chamberPractitionerId, _selectedStr);
                }

                if (isCalledFromAdditionalInfoBtn)
                {
                    new RxService().DeleteRxCpSavedAdditionalHistory(_chamberPractitionerId, _selectedStr);
                }

                if (isCalledFromOtherFindingsBtn)
                {
                    new RxService().DeleteRxCpSavedOtherFindings(_chamberPractitionerId, _selectedStr);
                }

               

                lstboxtemplateItem.Items.Remove(lstboxtemplateItem.SelectedItem);
            }
        }

        private void btnCameraPostion_Click(object sender, EventArgs e)
        {
            SetCameraFramepositionInCenter();
        }

        private void SetCameraFramepositionInCenter()
        {
            pnlPhotoFramePosition.Location = new Point(490, 150);
        }

        private void btnHideCameraFramePosition_Click(object sender, EventArgs e)
        {
            pnlPhotoFramePosition.Location = new Point(-490, 150);
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
            FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void frmRxViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalFrame.SignalToStop();
            FinalFrame.WaitForStop();
        }

        bool IsImageCaptured = false;
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (pbox.Image != null)
            {
                Image Image = (Bitmap)pbox.Image.Clone();

                //Bitmap varBmp = new Bitmap(pictureBox2.Image);
                Bitmap newBitmap = new Bitmap(Image, new Size(160, 130));

                pictureBox2.Image = newBitmap;
                if (!IsImageCaptured)
                {
                    SaveProfileImage();
                    IsImageCaptured = true;
                }
                else
                {
                    UpdateProfileImage();
                }

                pnlPhotoFramePosition.Location = new Point(-490, 150);

            }
        }

        private void SaveProfileImage()
        {
            string _conString = Utility.GetImageDbConnectionString();
            SqlConnection con = new SqlConnection(_conString);
            try
            {


                byte[] imagedata = GetImagebyte();

                string qry = @"insert into MemberImages (RegNo,ProfileImage) values(@RegNo, @ProfileImage)";

                //Initialize SqlCommand object for insert.
                SqlCommand SqlCom = new SqlCommand(qry, con);

                //We are passing Original Image Path and 
                //Image byte data as SQL parameters.
                SqlCom.Parameters.Add(new SqlParameter("@RegNo", (object)txtHIN.Text));
                SqlCom.Parameters.Add(new SqlParameter("@ProfileImage", (object)imagedata));

                //Open connection and execute insert query.
                con.Open();
                SqlCom.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }


        private void UpdateProfileImage()
        {
            string _conString = Utility.GetImageDbConnectionString();
            SqlConnection con = new SqlConnection(_conString);
            try
            {

                long _rRegNo = 0;
                long.TryParse(txtHIN.Text, out _rRegNo);

                string qry = string.Format("Delete from MemberImages Where RegNo={0}", _rRegNo);
                con.Open();
                SqlCommand SqlCom = new SqlCommand(qry, con);
                SqlCom.ExecuteNonQuery();
                con.Close();

                byte[] imagedata = GetImagebyte();

                qry = @"insert into MemberImages (RegNo,ProfileImage) values(@RegNo, @ProfileImage)";
                SqlCom = new SqlCommand(qry, con);
                //Initialize SqlCommand object for insert.


                //We are passing Original Image Path and 
                //Image byte data as SQL parameters.
                SqlCom.Parameters.Add(new SqlParameter("@RegNo", (object)txtHIN.Text));
                SqlCom.Parameters.Add(new SqlParameter("@ProfileImage", (object)imagedata));

                //Open connection and execute insert query.
                con.Open();
                SqlCom.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        private byte[] GetImagebyte()
        {
            Byte[] imgBytes = null;
            ImageConverter imgConverter = new ImageConverter();
            imgBytes = (System.Byte[])imgConverter.ConvertTo(pictureBox2.Image, Type.GetType("System.Byte[]"));
            return imgBytes;
        }

        private void radOn_Click(object sender, EventArgs e)
        {
            if (radOn.Checked)
            {
                dtpFollowOn.Enabled = true;
                txtFollowUpAfter.Text = "";
                txtFollowUpAfter.Enabled = false;
            }
           
        }

        private void radAfter_Click(object sender, EventArgs e)
        {
            if (radAfter.Checked)
            {
                dtpFollowOn.Enabled = false;
                txtFollowUpAfter.Enabled = true;
            }
        }

        private void txtPrescriptionDiagnosis_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtFollowUpAfter_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void dtpFollowOn_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtCommentsReferral_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtHistoryNew_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtAdditional_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtTreatmentPlan_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtOtherFindings_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtDrugHistory_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtCC_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void PatientQueue_Click(object sender, EventArgs e)
        {
            SetPatientQueuePanelVisible();
        }

        private async void SetPatientQueuePanelVisible()
        {
            pnlWaitingList.Location = new Point(400, 45);
            List<RxVMPatientBasicInfo> _pList = await new RxService().GetRxWaitingPatientListAsync(dtpdate.Value, dtpdate.Value, _chamberPractitionerId);

            FillWaitingPatientList(_pList);

            pnlWaitingList.Tag = _pList;
        }

        private void FillWaitingPatientList(List<RxVMPatientBasicInfo> pList)
        {
            dgQueuedPatient.Rows.Clear();
            dgQueuedPatient.SuspendLayout();
            pList = pList.OrderBy(x => x.RxVisitId).ToList();
            int count = 1;
            foreach (var item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgQueuedPatient, item.PSrlNo, item.RegNo, item.Name, item.Age, item.MobileNo, item.Address);
                dgQueuedPatient.Rows.Add(row);
                count += 1;
            }
        }

        private void btnHideQueuePanel_Click(object sender, EventArgs e)
        {
            HidePatientQueuePanelVisible();
        }

        private void HidePatientQueuePanelVisible()
        {
            pnlWaitingList.Location = new Point(-12500, 45);
        }

        private void dgQueuedPatient_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RxVMPatientBasicInfo _patient = dgQueuedPatient.SelectedRows[0].Tag as RxVMPatientBasicInfo;
            if (_patient != null)
            {
                dgQueuedPatient.Tag = _patient;
                LoadPatientDemographicData(_patient.RegNo);
                HidePatientQueuePanelVisible();
            }
        }

        private void btnRefreshWaitingList_Click(object sender, EventArgs e)
        {
            SetPatientQueuePanelVisible();
        }


        bool isListReset = true;
        private void TV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (IsTreePopulated)
            {
                if (TV.SelectedNode.Tag == null) return;

                string[] arr = null;
                arr = TV.SelectedNode.Tag.ToString().Split('_');

                Patient _p = radLastVisit.Tag as Patient;

                List<VMReportDefination> _testList = new List<VMReportDefination>();

                if (arr.Length > 1)  // By Report Type
                {

                    LoadTestResultByReportType(arr[0], _p.ReportIdPrefix+_p.ReportId.ToString());
                    isListReset = false;
                    gvTestsDetails.Tag = arr[0];

                }
                else   // By Test Item
                {

                    if (!isListReset)
                    {
                        _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
                        isListReset = true;
                    }

                    if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
                    {
                        arr = e.Node.Parent.Tag.ToString().Split('_');

                        int _currentReportType = 0;
                        int.TryParse(arr[0], out _currentReportType);

                        int _selectedReportType = 0;
                        if (gvTestsDetails.Tag != null)
                        {
                            int.TryParse(gvTestsDetails.Tag.ToString(), out _selectedReportType);
                        }

                        if (_currentReportType != _selectedReportType)
                        {
                            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
                            isListReset = true;
                        }

                        gvTestsDetails.Tag = arr[0];
                    }



                    int _testId = 0;
                    if (TV.SelectedNode.Tag != null)
                    {
                        int.TryParse(TV.SelectedNode.Tag.ToString(), out _testId);
                    }

                   // LoadTestResultByTestId(_testId, _p.ReportIdPrefix + _p.ReportId.ToString());

                }
            }
        }

        private async void LoadTestResultByReportType(string _reportTypeId, string _reportId)
        {
            //C5489 Immunology LIS Result should be Resolved.

            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            List<VMReportDefination> _testList = new List<VMReportDefination>();


            Patient _Patient = radLastVisit.Tag as Patient;


            int reportTypeId = 0;
            int.TryParse(_reportTypeId, out reportTypeId);



            ReportType _rType = new TestService().GetReportTypesById(reportTypeId);



            DataTable dtchildc = await new ReportService().GetPathologicalTestsByReportType(_Patient.PatientId, reportTypeId);
            foreach (DataRow dr in dtchildc.Rows)
            {
                _testList = new List<VMReportDefination>();

                TestItem _testItem = new TestService().GetTestItemById(Convert.ToInt32(dr["TestId"]));

                txtName.Tag = _testItem.Specimen;

                if (_testItem == null) return;

               
                int _rTypeId = 0;
                int _priorityId = 100;

                List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId, _reportId);
                if (priorityObj != null && priorityObj.Count > 0)
                {
                    foreach (var item in priorityObj)
                    {
                        _rTypeId = item.ReportTypeId;
                        if (_priorityId > item.Priority)
                            _priorityId = item.Priority;

                    }
                }

                if (_priorityId == 100) _priorityId = 0;

              //  lblReportTypeId.Text = _rTypeId.ToString();
               // lblPriorityId.Text = _priorityId.ToString();  // If same sample runs on different machine


                DataTable _dt = await new ReportService().GetPreviousReportTestDetailsByPatientByTestId(_Patient.PatientId, _testItem.TestId, _rTypeId, _priorityId);  // If already report done
                if (_dt.Rows.Count > 0)
                {

                    _testList = (from DataRow _dr in _dt.Rows
                                 select new VMReportDefination()
                                 {
                                     PatientId = Convert.ToInt64(_dr["PatientId"]),
                                     ReportId = Convert.ToInt64(_dr["Id"]),
                                     ReportDoctor = Convert.ToInt32(_dr["ReportDoctor"]),
                                     ReportTechnologist = Convert.ToInt32(_dr["ReportTechnologist"]),
                                     TestTitle = _dr["TestTitle"].ToString(),
                                     TestName = _dr["TestName"].ToString(),
                                     TestResult = _dr["TestResult"].ToString(),
                                     ResultOption = _dr["ResultOption"].ToString(),
                                     MachineResult = _dr["LisValue"].ToString(),
                                     MachineCode = _dr["InstrumentName"].ToString(),
                                     ResultUnit = _dr["ResultUnit"].ToString(),
                                     TestDetailId = Convert.ToInt32(_dr["TestDetailId"]),
                                     TestId = Convert.ToInt32(_dr["TestId"]),
                                     GroupId = Convert.ToInt32(_dr["GroupId"]),
                                     GroupTitle = _dr["GroupTitle"].ToString(),
                                     ReportTypeId = Convert.ToInt32(_dr["ReportTypeId"]),
                                     TestTitle_FontBold = Convert.ToInt32(_dr["TestTitle_FontBold"]),
                                     NormalValue = _dr["NormalResult"].ToString(),
                                     DetailReportOrder = Convert.ToInt32(_dr["DetailReportOrder"]),
                                     TestReportOrder = Convert.ToInt32(_dr["TestReportOrder"]),
                                     GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"])

                                 }).ToList();


                    new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                    VMReportDefination rdef = _SelectedTestItemsForPathologyReport.FirstOrDefault();
                    PathologyReport _pReport = new ReportService().GetPathologyNonWordReportById(rdef.ReportId);
                    //LoadReportConsultants(_pReport.ReportDoctor);
                    //LoadReportTechnologists(_pReport.ReportTechnologist);
                   // txtReportSerial.Text = rdef.ReportId.ToString();
                  //  txtReportSerial.Tag = _pReport;

                    //FillTestGridForPreviousReport();
                }
                else
                {

                    DataTable _selectedTest = await new ReportService().GetTestDetailsForReport(_Patient.PatientId, _testItem.TestId, _rTypeId, _priorityId);

                    if (_selectedTest.Rows.Count > 0)
                    {


                        _testList = (from DataRow _dr in _selectedTest.Rows
                                     select new VMReportDefination()
                                     {
                                         PatientId = Convert.ToInt64(_dr["PatientId"]),
                                         ReportId = 0,
                                         ReportDoctor = 0,
                                         ReportTechnologist = 0,
                                         TestTitle = _dr["TestTitle"].ToString(),
                                         TestName = _dr["TestName"].ToString(),
                                         TestResult = _dr["TestResult"].ToString(),
                                         MachineResult = _dr["LisValue"].ToString(),
                                         MachineCode = _dr["InstrumentName"].ToString(),
                                         ResultUnit = _dr["ResultUnit"].ToString(),
                                         ResultOption = _dr["ResultOption"].ToString(),
                                         TestDetailId = Convert.ToInt32(_dr["Id"]),
                                         TestId = Convert.ToInt32(_dr["TestId"]),
                                         GroupId = Convert.ToInt32(_dr["GroupId"]),
                                         GroupTitle = _dr["GroupTitle"].ToString(),
                                         ReportTypeId = Convert.ToInt32(_dr["ReportTypeId"]),
                                         TestTitle_FontBold = Convert.ToInt32(_dr["TestTitle_FontBold"]),
                                         NormalValue = _dr["NormalResult"].ToString(),
                                         DetailReportOrder = Convert.ToInt32(_dr["DetailReportOrder"]),
                                         TestReportOrder = Convert.ToInt32(_dr["TestReportOrder"]),
                                         GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"])

                                     }).ToList();

                    }

                    if (_testList.Count > 0)
                        new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                }

            }




            if (_SelectedTestItemsForPathologyReport != null)
            {
                VMReportDefination _rdef = _SelectedTestItemsForPathologyReport.Where(x => x.ReportDoctor > 0).FirstOrDefault();
                if (_rdef != null)
                {
                   // LoadReportConsultants(_rdef.ReportDoctor);
                   // LoadReportTechnologists(_rdef.ReportTechnologist);
                }
            }

            FillTestResultGrid();


            //}
        }

        private void FillTestResultGrid()
        {
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            string _testResult = string.Empty;

            string[] mCodes = new string[200];
            int count = 0;
            foreach (VMReportDefination item in _SelectedTestItemsForPathologyReport)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;

                if (!item.MachineCode.Contains("ESRRoller20"))
                {
                    mCodes[count] = item.MachineCode;
                    count++;
                }

                if (String.IsNullOrEmpty(item.TestResult))
                {
                    _testResult = "";

                    if (item.IsNewResult)
                    {
                        _testResult = item.MachineResult;
                    }
                    else
                    {
                        _testResult = "";
                    }

                }
                else
                {

                    if (item.IsNewResult)
                    {
                        _testResult = item.MachineResult;
                    }
                    else
                    {
                        _testResult = item.TestResult;
                    }
                }

                if (item.TestName.ToLower() == "urine r/e" || item.TestName.ToLower() == "stool r/e" || item.TestName.ToLower() == "urine analysis")
                {
                    string _result = item.MachineResult;
                    if (string.IsNullOrEmpty(_result))
                    {
                        _result = item.NormalValue;
                    }

                    row.CreateCells(gvTestsDetails, item.TestTitle, _result, item.MachineResult, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId);
                }
                else
                {
                    row.CreateCells(gvTestsDetails, item.TestTitle, _testResult, item.MachineResult, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId);
                }

                if (item.TestTitle_FontBold == 1)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
                else
                {
                    row.ReadOnly = false;

                    // row.Cells[2].Style.BackColor = Color.LightSeaGreen;

                    row.Cells[2].ReadOnly = true;

                    row.Cells[1].Style.BackColor = System.Drawing.Color.Linen;
                }



                gvTestsDetails.Rows.Add(row);

            }

           
        }

        private void cmbHeightUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtWeight.Text) && !string.IsNullOrEmpty(txtHeight.Text))
            {
                DateDiff dateDiff = new DateDiff(dtpDOBP.Value, Utils.GetServerDateAndTime());
                int yrs = dateDiff.ElapsedYears;
                if (yrs >= 18 && yrs <= 65)
                {
                    double weight = 0;
                    double.TryParse(txtWeight.Text, out weight);
                    double height = 0;  // Standard meter for BMI calculation
                    double.TryParse(txtHeight.Text, out height);

                    if (cmbHeightUnit.Text.ToLower().Equals("in"))
                    {
                        height = height * 2.54;
                    }

                    height = height / 100; // Converted to meter from cm

                    double bmi = Math.Round(weight / (height * height), 2);

                    string bmiStrDisplay = "BMI: "+ bmi.ToString() + " kg/m2 ";
                   

                    lblBMI.ForeColor = Color.Red;

                    if (bmi < 18.5) bmiStrDisplay = bmiStrDisplay + "("+Constants.BMIUnderWeight+")";
                    if (bmi >= 18.5 && bmi < 24.9) {
                        bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMINormalWeight + ")";
                        lblBMI.ForeColor = Color.Green;
                    }
                    if (bmi > 24.9 && bmi < 29.9) bmiStrDisplay = bmiStrDisplay + "("+Constants.BMIOverWeight + ")";
                    if (bmi > 29.9 && bmi < 34.9) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIObesityClass1 + ")";
                    if (bmi > 34.9 && bmi < 39.9) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIObesityClass1I + ")";
                    if (bmi >= 40) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIObesityClass1II + ")";

                    lblBMI.Text = bmiStrDisplay;

                }
            }
        }

        private void txtHeight_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWeight.Text) && !string.IsNullOrEmpty(txtHeight.Text) && !string.IsNullOrEmpty(cmbHeightUnit.Text))
            {
                DateDiff dateDiff = new DateDiff(dtpDOBP.Value, Utils.GetServerDateAndTime());
                int yrs = dateDiff.ElapsedYears;
                if (yrs >= 18 && yrs <= 65)
                {
                    double weight = 0;
                    double.TryParse(txtWeight.Text, out weight);
                    double height = 0;  // Standard meter for BMI calculation
                    double.TryParse(txtHeight.Text, out height);

                    if (cmbHeightUnit.Text.ToLower().Equals("in"))
                    {
                        height = height * 2.54;
                    }

                    height = height / 100; // Converted to meter from cm

                    double bmi = Math.Round(weight / (height * height), 2);

                    string bmiStrDisplay = "BMI: " + bmi.ToString() + " kg/m2 ";


                    lblBMI.ForeColor = Color.Red;

                    if (bmi < 18.5) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIUnderWeight + ")";
                    if (bmi >= 18.5 && bmi < 24.9)
                    {
                        bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMINormalWeight + ")";
                        lblBMI.ForeColor = Color.Green;
                    }
                    if (bmi > 24.9 && bmi < 29.9) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIOverWeight + ")";
                    if (bmi > 29.9 && bmi < 34.9) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIObesityClass1 + ")";
                    if (bmi > 34.9 && bmi < 39.9) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIObesityClass1I + ")";
                    if (bmi >= 40) bmiStrDisplay = bmiStrDisplay + "(" + Constants.BMIObesityClass1II + ")";

                    lblBMI.Text = bmiStrDisplay;

                }
            }

        }

        private void txtDiagnosisDx_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void cmbAfterFollowUpTimeUnit_Leave(object sender, EventArgs e)
        {
            InsertOrUpdateInitialDataObj();
        }

        private void txtSearchAdvices_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D)
            {
                IsSearchAdviceDisable = true;
               
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.A)
            {
                IsSearchAdviceDisable = false;
               
            }
        }

        private void txtSearchAdvices_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtSearchAdvices.Text))
                {
                    new RxService().PopulateDirectWrittenAdvices(_SelectedAdvices, txtSearchAdvices.Text,_chamberPractitionerId);
                    PopulateAdviceList(_SelectedAdvices);
                    SaveOrUpdateAdvice();
                    txtSearchAdvices.Text = "";

                    
                }
            }
        }
    }
}
