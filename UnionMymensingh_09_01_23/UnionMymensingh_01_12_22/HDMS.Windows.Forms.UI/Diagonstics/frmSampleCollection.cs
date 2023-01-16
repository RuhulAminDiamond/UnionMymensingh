using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.SampleLabel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DSBarCode.BarCodeCtrl;

namespace HDMS.Windows.Forms.UI.Diagonstics
{  

    public partial class frmSampleCollection : Form
    {

        private int leftMargin = 10;
        private int topMargin = 10;
        private int height = 50;
        private bool showHeader = false;
        private bool showFooter = true;
        private String headerText = "BarCode Demo";
        private BarCodeWeight weight = BarCodeWeight.Small;
        private Font headerFont = new Font("Courier", 18);
        private Font barcodeFont = new Font("Arial Narrow", 8);
        private Font footerFont = new Font("Arial Narrow", 8);

        private List<SelectedTestItemsForPatient> _SelectedTests;

        private List<SelectedTestItemsForPatient> _testListToPrintLabel;

        string _testLabel = string.Empty;
        string _regNo = string.Empty;
        string _patientInfo = string.Empty;
        string _printdateTime = string.Empty;
        bool isPanelMinimized = true;

        public frmSampleCollection()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgTests.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgTests.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }


        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private async void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               await LoadPatientAndTestDetails();
            }
        }

        private async Task<bool>  LoadPatientAndTestDetails()
        {
            long _billNo = 0;
            long.TryParse(txtBillNo.Text, out _billNo);

            //Load PatientInfo
            Patient _PatientInfo = new PatientService().GetDiagPatientById(_billNo);

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

                if (_PatientInfo.AdmissionNo > 0)
                {
                    HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNoAny(_PatientInfo.AdmissionNo);

                    if (_hp == null)
                        return await Task.FromResult(true);
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
                    DataSet ds = await new ReportService().GetTestListForSampleCollection(_PatientInfo.PatientId);

                    DataTable dt = ds.Tables[0];



                    _SelectedTests = (from DataRow dr in dt.Rows
                                      select new SelectedTestItemsForPatient()
                                      {
                                          TestCostId = Convert.ToInt64(dr["Id"]),
                                          Id = Convert.ToInt32(dr["TestId"]),
                                          Name = dr["TestName"].ToString(),
                                          ShortName = dr["ShortName"].ToString(),
                                          ReportStatus = dr["ReportStatus"].ToString(),
                                          CollectionTypeId = GetCollectionTypeId(dr["CollectionTypeId"]),   //CollectionTypeId 1 means this sample required individual single tube
                                          ReportTypeId = Convert.ToInt32(dr["ReportTypeId"]),
                                          VTId = Convert.ToInt32(dr["VTId"]),
                                          BarcodeLabel = dr["BarcodeLabel"].ToString(),
                                          CategoryId = Convert.ToInt32(dr["CategoryId"])
                                      }).ToList();


                    int _numberOfIndividualVacu = _SelectedTests.Where(x => x.CollectionTypeId == 1).Count();
                    //if(_SelectedTests.Count()> _numberOfIndividualVacu)
                    //{
                    //    lblTotal.Text = "Total Vacu Required: " + (_numberOfIndividualVacu + 1).ToString();
                    //}
                    //else
                    //{
                    //    lblTotal.Text = "Total Vacu : " + _numberOfIndividualVacu.ToString();
                    //}

                    // _SelectedTests = GetProcessedSelectedTest(_SelectedTests);

                    FillTestGrid();
                    AddToStatusToGrid(_PatientInfo.PatientId);
                    // SaveAndPrint();

                }
                else
                {
                    MessageBox.Show("This is a cancelled Id.", "HERP");

                }
            }

            return await Task.FromResult(true);

        }

        private List<SelectedTestItemsForPatient> GetProcessedSelectedTest(List<SelectedTestItemsForPatient> _SelectedTests)
        {
            List<SelectedTestItemsForPatient> _SelectedT = new List<SelectedTestItemsForPatient>();
            foreach(var item in _SelectedTests)
            {
                SelectedTestItemsForPatient _tp = new SelectedTestItemsForPatient();
                List<SampleCollectionSetting> _scs = new TestService().GetSampleCollectionSetting(item.Id);
                if (_scs.Count() == 0)
                {
                    _tp.TestCostId = item.TestCostId;
                    _tp.Id = item.Id;
                    _tp.Name = item.Name;
                    _tp.ShortName = item.ShortName;
                    _tp.ReportStatus = item.ReportStatus;
                    _tp.CollectionTypeId = item.CollectionTypeId;
                    _tp.ReportTypeId = item.ReportTypeId;
                    _tp.VTId = item.VTId;
                    _tp.BarcodeLabel = item.BarcodeLabel;
                    _tp.CategoryId = item.CategoryId;
                    _SelectedT.Add(_tp);
                }
                else
                {
                    foreach(var scs in _scs)
                    {
                        _tp = new SelectedTestItemsForPatient();
                        _tp.TestCostId = item.TestCostId;
                        _tp.Id = scs.MainTestId;
                        _tp.Name = scs.Description;
                        _tp.ShortName = item.ShortName;
                        _tp.ReportStatus = item.ReportStatus;
                        _tp.CollectionTypeId = item.CollectionTypeId;
                        _tp.ReportTypeId = item.ReportTypeId;
                        _tp.BarcodeLabel = item.BarcodeLabel;
                        _tp.CategoryId = item.CategoryId;
                        _SelectedT.Add(_tp);
                    }
                }
            }

            return _SelectedT;
        }

        private int? GetCollectionTypeId(object _collectionType)
        {
            if (_collectionType == DBNull.Value) return null;

            if (_collectionType == null) return null;

            return Convert.ToInt32(_collectionType);

          
        }

        private void FillTestGrid()
        {

            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach (SelectedTestItemsForPatient item in _SelectedTests)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgTests, item.Id, item.Name, item.BarcodeLabel,false);
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
                return true;

            }

            return false;

        }


        private void AddToStatusToGrid(long _pId)
        {

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();

            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Sample Collection Status";
            dgvCmb.Width = 200;

            List<TestsCost> _collectedTest = new PatientService().GetSampleCollectedTests(_pId);

            if (dgTests.Columns.Contains("Chk") && dgTests.Columns["Chk"].Visible)
            {
                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    int _testId = Convert.ToInt32(row.Cells[0].Value);
                    if (_collectedTest.Exists(x => x.TestId == _testId))
                    {
                        //chkParent.Checked = true;
                        row.Cells["Chk"].Value = true;
                    }
                    else
                    {
                        row.Cells["Chk"].Value = true;
                    }

                }

            }
            else
            {

                dgTests.Columns.Add(dgvCmb);

                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    int _testId = Convert.ToInt32(row.Cells[0].Value);
                    if (_collectedTest.Exists(x => x.TestId == _testId))
                    {
                        //chkParent.Checked = true;
                        row.Cells["Chk"].Value = true;
                    }
                    else
                    {
                        row.Cells["Chk"].Value = true;
                    }

                }

            }
  
        }

        private async void frmSampleCollection_Load(object sender, EventArgs e)
        {
            
            SetTogglePositionForPanel(true);

           await  LoadPatients(Utils.GetServerDateAndTime());
        }

        private async Task<bool> LoadPatients(DateTime _EntryDate)
        {
            List<Patient> _pList = await new PatientService().GetSampleCollecTablePatientList(_EntryDate);

            FillPatientWaitingGrid(_pList);

            return await Task.FromResult(true);

        }

        private void FillPatientWaitingGrid(List<Patient> _pList)
        {
            dgPatients.Rows.Clear();
            foreach(var item in _pList)
            {
                RegRecord _rr = new RegRecordService().GetRegRecordByRegNo(item.RegNo);

                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgPatients, item.ReportIdPrefix+item.ReportId.ToString(), _rr.FullName,item.EntryDate.ToString("dd/MM/yyyy"),item.EntryTime);

                dgPatients.Rows.Add(row);
            }
        }

        private void SetTogglePositionForPanel(bool _IspanleMinimized)
        {
            if (_IspanleMinimized)
            {
                lblRequisitionPanel.Location = new Point(930, 61);

                button1.Location = new Point(20, 14);
                button1.Text = "<-----<< << <<";

                isPanelMinimized = false;

            }
            else
            {
                lblRequisitionPanel.Location = new Point(350, 61);

                button1.Location = new Point(20, 14);
                button1.Text = ">> >> >> ----->";

                isPanelMinimized = true;

            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
           

            await SaveAndPrint();

            
        }


        private async Task<bool> SaveAndPrint()
        {

            int count = 0;
            int.TryParse(lblTotal.Text, out count);
            string _combinedTests = string.Empty;

            btnSave.Enabled = false;
            btnSave.Text = "Plz. Wait..";

            string _age = Utility.GetConcatenatedAge(txtYears.Text, txtMonths.Text, txtDays.Text);

            try
            {

                List<TestsCost> _testCostList = new List<TestsCost>();

                List<SelectedTestItemsForPatient> _testListToPrintLabel = new List<SelectedTestItemsForPatient>();

                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    if ((bool)row.Cells["Chk"].Value == true)
                    {
                        SelectedTestItemsForPatient _seletedItem = (SelectedTestItemsForPatient)row.Tag;
                        

                     //   int _NoOfGroupTests = _SelectedTests.Where(x => x.ReportTypeId == _seletedItem.ReportTypeId).ToList().Count;

                        if (_seletedItem.ReportStatus == ReportStatusEnum.NE.ToString() || _seletedItem.ReportStatus == ReportStatusEnum.SC.ToString())
                        {
                            TestsCost _tCost = new TestsCostService().GetTestCostByTestId(_seletedItem.TestCostId);
                            _testListToPrintLabel.Add(_seletedItem);

                            _tCost.ReportStatus = ReportStatusEnum.SC.ToString();
                            _tCost.SampleCollectedBy = MainForm.LoggedinUser.Name;
                            _testCostList.Add(_tCost);

                        }
                    }
                }


             

                if (_testListToPrintLabel.Count > 0)
                {
                    //For Vacutainer RED 4ml  -- Vacu Type Id==2


                       this.PrintRedVaculabels(_testListToPrintLabel, _age);


                    // Start of Lavender


                    this.PrintLavenderVaculabels(_testListToPrintLabel, _age);



                    // Start of Lavender


                    this.PrintBlueVaculabels(_testListToPrintLabel, _age);




                    // Start of Urine/Urine Pot


                    this.PrintUrineLabel(_testListToPrintLabel, _age);



                    // Start of UrineCS Label


                    this.PrintUrineCSLabel(_testListToPrintLabel, _age);



                    // Start of Stool Pot


                    this.PrintStoolPotLabel(_testListToPrintLabel, _age);



                    // Start of Sputam Pot


                    this.PrintSputamPotLabel(_testListToPrintLabel, _age);


                    // Start of Blood/CS


                    this.PrintbloodCSLabel(_testListToPrintLabel, _age);

                    // Start of 3Vacutainer Lavender

                    this.PrintLabelFor3VacutainerLavendar(_testListToPrintLabel,_age);

                }



                if (_testCostList.Count > 0)
                {
                    new TestsCostService().UpdateReportStatus(_testCostList);

                    Patient _P = (Patient)txtBillNo.Tag;
                    _P.SampleCollectionStatus = SampleCollectionStatusEnum.FC.ToString();
                    new PatientService().UpdatePatientInfo(_P);

                    await  LoadPatients(Utils.GetServerDateAndTime());

                    // MessageBox.Show("Sample received successful.");
                    // ViewPrintReceivedSampleList();
                    // ClearWindow();

                }
            }
            catch (Exception ex)
            {
                btnSave.Enabled = true;
                btnSave.Text = "Print Label";
                return await Task.FromResult(false);
            }

            UpdateStatusToGrid();

            btnSave.Enabled = true;
            btnSave.Text = "Print Label";
            return await Task.FromResult(true);

            //txtBillNo.Text = "";
        }

        private void PrintLabelFor3VacutainerLavendar(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {
            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _crossMatching = _testListToPrintLabel.Where(x => x.VTId == 6 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_crossMatching.Count > 0)
            {
                foreach (var item in _crossMatching)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Urine Tube for individual tube required for each Test

            _crossMatching = _testListToPrintLabel.Where(x => x.VTId == 6 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_crossMatching.Count > 0)
            {
                foreach (var item in _crossMatching)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }

            _crossMatching = _testListToPrintLabel.Where(x => x.VTId == 6 && x.CategoryId == 2 && x.CollectionTypeId == 1).ToList();

            if (_crossMatching.Count > 0)
            {
                foreach (var item in _crossMatching)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }

        }

        private void PrintBlueVaculabels(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {
            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _blueVacues = _testListToPrintLabel.Where(x => x.VTId == 11 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_blueVacues.Count > 0)
            {
                foreach (var item in _blueVacues)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    //PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Lavendar vacu for corresponding CUS

            _blueVacues = _testListToPrintLabel.Where(x => x.VTId == 11 && x.CategoryId == 2 && x.CollectionTypeId == 2).ToList();
            if (_blueVacues.Count > 0)
            {
                SelectedTestItemsForPatient _selected = _blueVacues.FirstOrDefault();

                PrintCode _pCode = new PrintCode();
                _testLabel = _selected.BarcodeLabel;
                _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

            }


            // Blue vacu for individual tube required for each Test

            _blueVacues = _testListToPrintLabel.Where(x => x.VTId == 11 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_blueVacues.Count > 0)
            {
                foreach (var item in _blueVacues)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }


        }

        private void PrintbloodCSLabel(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {
            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _bloodCS = _testListToPrintLabel.Where(x => x.VTId == 10 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_bloodCS.Count > 0)
            {
                foreach (var item in _bloodCS)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Urine Tube for individual tube required for each Test

            _bloodCS = _testListToPrintLabel.Where(x => x.VTId == 10 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_bloodCS.Count > 0)
            {
                foreach (var item in _bloodCS)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }
        }

        private void PrintSputamPotLabel(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {
            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _SputamPot = _testListToPrintLabel.Where(x => x.VTId == 9 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_SputamPot.Count > 0)
            {
                foreach (var item in _SputamPot)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Urine Tube for individual tube required for each Test

            _SputamPot = _testListToPrintLabel.Where(x => x.VTId == 9 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_SputamPot.Count > 0)
            {
                foreach (var item in _SputamPot)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }
        }

        private void PrintStoolPotLabel(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {
            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _StoolPot = _testListToPrintLabel.Where(x => x.VTId == 8 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_StoolPot.Count > 0)
            {
                foreach (var item in _StoolPot)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Urine Tube for individual tube required for each Test

            _StoolPot = _testListToPrintLabel.Where(x => x.VTId == 8 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_StoolPot.Count > 0)
            {
                foreach (var item in _StoolPot)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }
        }

        private void PrintUrineCSLabel(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {

            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _UrineTueOrPot = _testListToPrintLabel.Where(x => x.VTId == 7 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_UrineTueOrPot.Count > 0)
            {
                foreach (var item in _UrineTueOrPot)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Urine Tube for individual tube required for each Test

            _UrineTueOrPot = _testListToPrintLabel.Where(x => x.VTId == 7 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_UrineTueOrPot.Count > 0)
            {
                foreach (var item in _UrineTueOrPot)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }
        }

        private void PrintUrineLabel(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {

            string _combinedTests = string.Empty;



            // Urine Tube for individual tube for combined urine Test

            List<SelectedTestItemsForPatient> _UrineTueOrPot = _testListToPrintLabel.Where(x => x.VTId == 4 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_UrineTueOrPot.Count > 0)
            {
                foreach (var item in _UrineTueOrPot)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Urine Tube for individual tube required for each Test

            _UrineTueOrPot = _testListToPrintLabel.Where(x => x.VTId == 4 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_UrineTueOrPot.Count > 0)
            {
                foreach (var item in _UrineTueOrPot)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }



            _combinedTests = string.Empty;

            _UrineTueOrPot = _testListToPrintLabel.Where(x => x.VTId == 5 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_UrineTueOrPot.Count > 0)
            {
                foreach (var item in _UrineTueOrPot)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Urine vacu for individual tube required for each Test

            _UrineTueOrPot = _testListToPrintLabel.Where(x => x.VTId == 5 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_UrineTueOrPot.Count > 0)
            {
                foreach (var item in _UrineTueOrPot)
                {

                    PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }

        }

        private void PrintLavenderVaculabels(List<SelectedTestItemsForPatient> _testListToPrintLabel, string _age)
        {
            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _lavenderVacues = _testListToPrintLabel.Where(x => x.VTId == 3 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_lavenderVacues.Count > 0)
            {
                foreach (var item in _lavenderVacues)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    //PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }


            // Lavendar vacu for corresponding CUS

            _lavenderVacues = _testListToPrintLabel.Where(x => x.VTId == 3 && x.CategoryId == 2  && x.CollectionTypeId == 2).ToList();
            if (_lavenderVacues.Count > 0)
            {
                SelectedTestItemsForPatient _selected = _lavenderVacues.FirstOrDefault();

                //PrintCode _pCode = new PrintCode();
                _testLabel = _selected.BarcodeLabel;
                _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

            }


            // Red vacu for individual tube required for each Test

            _lavenderVacues = _testListToPrintLabel.Where(x => x.VTId == 3 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_lavenderVacues.Count > 0)
            {
                foreach (var item in _lavenderVacues)
                {

                    //PrintCode _pCode = new PrintCode();
                    _testLabel = item.BarcodeLabel;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

                }

            }


           


            // End Of Lavender
        }

        private void PrintRedVaculabels(List<SelectedTestItemsForPatient> _testListToPrintLabel,string _age)
        {

            string _combinedTests = string.Empty;

            List<SelectedTestItemsForPatient> _redVacues = _testListToPrintLabel.Where(x => x.VTId == 2 && x.CategoryId == 1 && x.CollectionTypeId == 2).ToList();


            if (_redVacues.Count > 0)
            {
                foreach (var item in _redVacues)
                {

                    if (String.IsNullOrEmpty(_combinedTests))
                    {
                        _combinedTests = item.BarcodeLabel;
                    }
                    else
                    {
                        _combinedTests = _combinedTests + ", " + item.BarcodeLabel;
                    }

                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                   // PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                     this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                }


                _combinedTests = string.Empty;

            }

            // Red vacu for corresponding CUS for Collection Tye 2

            _redVacues = _testListToPrintLabel.Where(x => x.VTId == 2 && x.CategoryId == 2 && x.CollectionTypeId == 2).ToList();
            if (_redVacues.Count > 0)
            {
                SelectedTestItemsForPatient _selected = _redVacues.FirstOrDefault();

               // PrintCode _pCode = new PrintCode();
                _testLabel = _selected.BarcodeLabel;
                _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                 this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);

            }


            // End Of Red Vacu and Corresrponding CUS


            // Red vacu for individual tube required for each Test

            _redVacues = _testListToPrintLabel.Where(x => x.VTId == 2 && x.CategoryId == 1 && x.CollectionTypeId == 1).ToList();

            if (_redVacues.Count > 0)
            {
                foreach (var item in _redVacues)
                {

                    List<SelectedTestItemsForPatient> _selectedSingleTubeTests = _testListToPrintLabel.Where(x => x.VTId == 2 && x.Id == item.Id).ToList();

                    foreach (var sItem in _selectedSingleTubeTests)
                    {
                       // PrintCode _pCode = new PrintCode();
                        _testLabel = sItem.BarcodeLabel;
                        _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                        this.PrintLabel(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text + "/" + _age);
                    }

                }

            }


        }

        private void UpdateStatusToGrid()
        {
            long _billNo = 0;
            long.TryParse(txtBillNo.Text, out _billNo);

            //Load PatientInfo
            Patient _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");
                txtBillNo.Tag = null;
            }

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();

            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Sample Collection Status";
            dgvCmb.Width = 200;
            dgTests.Columns.Add(dgvCmb);

            List<TestsCost> _collectedTest = new PatientService().GetSampleCollectedTests(_PatientInfo.PatientId);

            foreach (DataGridViewRow row in dgTests.Rows)
            {
                int _testId = Convert.ToInt32(row.Cells[0].Value);
                if (_collectedTest.Exists(x => x.TestId == _testId))
                {
                    //chkParent.Checked = true;
                    row.Cells["Chk"].Value = false;
                }
                else
                {
                    row.Cells["Chk"].Value = false;
                }

            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                string _ImagePath = @"C:\Reg123.png";

                if (File.Exists(_ImagePath))
                {
                    //Load the image from the file
                    Image img = Image.FromFile(@"C:\Reg123.png");

                    //Adjust the size of the image to the page to print the full image without loosing any part of it
                    Rectangle m = e.MarginBounds;

                    if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
                    }
                    e.Graphics.DrawImage(img, m);
                }
            }
            catch (Exception)
            {

            }
        }

        private string GetPrefixedIdString(string _originalId)
        {
            string _appendZero = string.Empty;
            if (_originalId.Length == 1) _appendZero = "000000";
            if (_originalId.Length == 2) _appendZero = "00000";
            if (_originalId.Length == 3) _appendZero = "0000";
            if (_originalId.Length == 4) _appendZero = "000";
            if (_originalId.Length == 5) _appendZero = "00";
           

            return _appendZero + _originalId;
        }

        private void PrintLabel(DataTable _dt)
        {
            //string _file = "C:\\SampleBarcodeImages\\Reg123.png";
        

            //if (File.Exists(@"C:\SampleBarcodeImages\Reg123.png"))
            //{
            //    File.Delete(@"C:\SampleBarcodeImages\Reg123.png");
            //}

           
            //if (!Directory.Exists("C:\\SampleBarcodeImages")) Directory.CreateDirectory("C:\\SampleBarcodeImages");
            // _control2.SaveImage(_file);

            rptSampleLabel _sLabel = new rptSampleLabel();

            _sLabel.SetDataSource(_dt);
            //_sLabel.SetParameterValue("BarcodeLocation", _file);

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _sLabel;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
           // _sLabel.PrintToPrinter(_labelCount, true, 0, 0);
            rv.crviewer.PrintReport();
            rv.Show();


        }

      

        private void btn2SavePrint_Click(object sender, EventArgs e)
        {
        PrintCode p = new PrintCode();

            int count = 0;
            int callNumber = 0;
            int.TryParse(lblTotal.Text, out count);
            string _combinedTests = string.Empty;
            
            try
            {
               

                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    if ((bool)row.Cells["Chk"].Value == true)
                    {
                        SelectedTestItemsForPatient _seletedItem = (SelectedTestItemsForPatient)row.Tag;
                        if (_seletedItem.ReportStatus == ReportStatusEnum.NE.ToString())
                        {

                            if (_seletedItem.CollectionTypeId == 1)
                            {
                                PrintCode _pCode = new PrintCode();
                                _testLabel = _seletedItem.ShortName;
                                _regNo = GetPrefixedIdString(txtBillNo.Text);
                                Thread.Sleep(100);
                                callNumber = callNumber + 1;
                                Print(_pCode.generateBarcode(_regNo, _testLabel, callNumber.ToString()));
                                
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(_combinedTests))
                                {
                                    _combinedTests = _seletedItem.Name;
                                }
                                else
                                {
                                    _combinedTests = _combinedTests + ", " + _seletedItem.Name;
                                }
                            }
                        }
                    }
                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = GetPrefixedIdString(txtBillNo.Text);
                    Thread.Sleep(100);
                    callNumber = callNumber + 1;
                    Print(_pCode.generateBarcode(_regNo, _testLabel, callNumber.ToString()));
                }

               
            }
            catch (Exception ex)
            {


            }


           // p.generateBarcode("010078","Blood Glucose 1 hour after BF");
        }

        public void Print(Image _barCodeImg)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ START - {0} - {1} -------------------]", MethodBase.GetCurrentMethod(), DateTime.Now.ToShortDateString()));
            logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "Parameter: 1: [Name - {0}, Value - {1}", "None]", Convert.ToString("")));

            try
            {
                if (_barCodeImg==null) return; // Prevents execution of below statements if filename is not selected.

                PrintDocument pd = new PrintDocument();

                //Disable the printing document pop-up dialog shown during printing.
                PrintController printController = new StandardPrintController();
                pd.PrintController = printController;

                //For testing only: Hardcoded set paper size to particular paper.
                pd.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Custom 1.6x1", 150, 103);
                pd.DefaultPageSettings.PaperSize = new PaperSize("Custom 1.6x1", 150, 103);

                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                pd.PrintPage += (sndr, args) =>
                {
                    System.Drawing.Image i = _barCodeImg;

                    //Adjust the size of the image to the page to print the full image without loosing any part of the image.
                    System.Drawing.Rectangle m = args.PageBounds;

                    //Logic below maintains Aspect Ratio.
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    //Calculating optimal orientation.
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    pd.DefaultPageSettings.Landscape = m.Width > m.Height;
                    //Putting image in center of page.
                    m.Y = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Height - m.Height) / 2);
                    m.X = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Width - m.Width) / 2);
                    args.Graphics.DrawImage(i, m);
                };

                PrintDialog pdialog = new PrintDialog();
                DialogResult result = pdialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pd.Print();

                }

             
            }
            catch (Exception ex)
            {
                //log.ErrorFormat("Error : {0}\n By : {1}-{2}", ex.ToString(), this.GetType(), MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));
               // txtMessage.Text = logMessage.ToString();
                // log.Info(logMessage.ToString());
            }
        }

        private void btnPrintToken_Click(object sender, EventArgs e)
        {
            DataSet ds;

            long _billNo = 0;
            long.TryParse(txtBillNo.Text, out _billNo);

            Patient _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

            if(_PatientInfo==null)
            {
                MessageBox.Show("Patient not found"); return;
            }

            ds = new DataSet();
            ds = new ReportService().GetLabTokenData(_PatientInfo.PatientId);



            LabToken _cashmemo = new LabToken();

            _cashmemo.SetDataSource(ds.Tables[0]);

            
           

            ReportViewer rv = new ReportViewer();

            _cashmemo.SetParameterValue("CabinNo", txtCabin.Text);
            _cashmemo.SetParameterValue("printedby", MainForm.LoggedinUser.Name);

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTogglePositionForPanel(isPanelMinimized);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatients(Utils.GetServerDateAndTime());
            dgPatientTestList.Rows.Clear();
        }

        private void dgPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Patient _P = dgPatients.Rows[e.RowIndex].Tag as Patient;
            txtBillNo.Text = _P.PatientId.ToString();
            LoadTests(_P);

        }

        private async void LoadTests(Patient _P)
        {
            DataSet ds = await new ReportService().GetTestListForSampleCollection(_P.PatientId);

            DataTable dt = ds.Tables[0];



            _SelectedTests = (from DataRow dr in dt.Rows
                              select new SelectedTestItemsForPatient()
                              {
                                  TestCostId = Convert.ToInt64(dr["Id"]),
                                  Id = Convert.ToInt32(dr["TestId"]),
                                  Name = dr["TestName"].ToString(),
                                  ShortName = dr["ShortName"].ToString(),
                                  ReportStatus = dr["ReportStatus"].ToString(),
                                  CollectionTypeId = GetCollectionTypeId(dr["CollectionTypeId"]),   //CollectionTypeId 1 means this sample required individual single tube
                                  ReportTypeId = Convert.ToInt32(dr["ReportTypeId"]),
                                  VTId = Convert.ToInt32(dr["VTId"]),
                                  BarcodeLabel = dr["BarcodeLabel"].ToString(),
                                  CategoryId = Convert.ToInt32(dr["CategoryId"])
                              }).ToList();


            FillWaitingTestGrid(_SelectedTests);
        }

        private void FillWaitingTestGrid(List<SelectedTestItemsForPatient> _SelectedTests)
        {
            dgPatientTestList.Rows.Clear();
            foreach(var item in _SelectedTests)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgPatientTestList,item.Id,item.Name,item.ShortName);

                dgPatientTestList.Rows.Add(row);
            }
        }

        private async void dgPatientTestList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatientTestList.Rows.Count > 0)
            {
                SetTogglePositionForPanel(true);
                await LoadPatientAndTestDetails();
            }
        }

        public void PrintLabel(string _tests, string _reportIdNo, string _pInfo)
        {
            _patientInfo = _pInfo;
            _printdateTime = Utils.GetServerDateAndTime().ToString("dd/MM/yyyy hh:mm tt");

            _regNo = this.GetPrefixedIdString(_reportIdNo);


            // string defaultPrinterName = "TEC B-EV4 (203 dpi)";// "TEC B-EV4 (203 dpi)";
            string defaultPrinterName = "Brother QL-800";

            picBarcode.Image = Image.FromStream(Code128bBarcode.CreateBarcode128b(_regNo));
            Byte[] arrImage = Code128bBarcode.CreateBarcode128b(_regNo).GetBuffer();
            Print(defaultPrinterName);
        }

        public void Print(string _printername)
        {
            PrinterSettings ps = new PrinterSettings();
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;

            ps.PrinterName = _printername;//Code to set default printer name
            pd.PrinterSettings.PrinterName = _printername;//Code to set default printer name 

            //if (pd.ShowDialog() == DialogResult.OK)
            //{
            pd.Document.Print();
            // }
        }

       

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            using (Graphics g = e.Graphics)
            {
                 Font reportIdfnt = new Font("Arial", 10, FontStyle.Bold);
                 Font testLabelfnt = new Font("Arial Narrow", 8, FontStyle.Bold);   

                g.DrawImage(picBarcode.Image, 30, 10);
                g.DrawString(_regNo, reportIdfnt, System.Drawing.Brushes.Black, 65, 65);
                g.DrawString(_testLabel, testLabelfnt, System.Drawing.Brushes.Black, 9, 85);
                g.DrawString(_patientInfo, testLabelfnt, System.Drawing.Brushes.Black, 10, 100);
                g.DrawString(_printdateTime, testLabelfnt, System.Drawing.Brushes.Black, 10, 115);

            }

            // picBarcode_Paint(sender, new PaintEventArgs(e.Graphics, this.ClientRectangle));

        }

        private void picBarcode_Paint(object sender, PaintEventArgs e)
        {
            int footerX = 90;
            int yTop = 40;
            e.Graphics.DrawString(_regNo, footerFont, Brushes.Black, footerX, yTop);
            yTop += 15;
            e.Graphics.DrawString(_testLabel, footerFont, Brushes.Black, footerX - 50, yTop);
            yTop += 15;
            e.Graphics.DrawString("Faruq Ahammd", footerFont, Brushes.Black, footerX - 50, yTop);
            yTop += 15;
            e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), footerFont, Brushes.Black, footerX - 50, yTop);
        }
    }


    public class PrintCode
    {
        #region Properties and Variables
        PrintDocument pdoc = null;
        private string testsLabel;
        private string _patientInfo;
        private string regNo;

        public PrintCode()
        {
        }
        #endregion



        #region Print Page using Printer
        public void print(string _tests, string _regNo, string _pInfo)
        {
            try
            {
                testsLabel = _tests;  //_tests;
                _patientInfo = _pInfo;
                regNo = _regNo;
                PrintDialog pd = new PrintDialog();
                string strDefaultPrinter = pd.PrinterSettings.PrinterName;//Code to get default printer name  
               
                // pdoc.PrintPage += delegate (object s, EventArgs e1) { pdoc_PrintPage(s, e,""); };

                //*************************Code to set Default Printer*************************************

                if (Configuration.ORG_CODE == "1")
                {

                    pdoc = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    Font font = new Font("IDAutomationHC39M", 12);//set default font for page
                    PaperSize psize = new PaperSize("Custom", 200, 155);//set paper size sing code
                                                                        // pdoc.OriginAtMargins = true;
                    pd.Document = pdoc;
                    pd.Document.DefaultPageSettings.PaperSize = psize;

                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                    string defaultPrinterName = "Brother QL-800"; //?? Write printer name here  //ps.PrinterName; // Code to get default printer

                    if (defaultPrinterName == "Brother QL-800")
                    {
                        ps.PrinterName = "Brother QL-800";//Code to set default printer name
                        pd.PrinterSettings.PrinterName = "Brother QL-800";//Code to set default printer name 
                    }
                    else
                    {
                        ps.PrinterName = defaultPrinterName;//Code to set default printer name
                        pd.PrinterSettings.PrinterName = defaultPrinterName;//Code to set default printer name 
                    }
                }else
                {



                    pdoc = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    Font font = new Font("IDAutomationHC39M", 12);//set default font for page
                    PaperSize psize = new PaperSize("Custom", 200, 145);//set paper size sing code
                                                                        // pdoc.OriginAtMargins = true;
                    pd.Document = pdoc;
                    pd.Document.DefaultPageSettings.PaperSize = psize;

                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                    string defaultPrinterName = "Brother QL-800"; //?? Write printer name here  //ps.PrinterName; // Code to get default printer

                    if (defaultPrinterName == "Brother QL-800")
                    {
                        ps.PrinterName = "Brother QL-800";//Code to set default printer name
                        pd.PrinterSettings.PrinterName = "Brother QL-800";//Code to set default printer name 
                    }
                    else
                    {
                        ps.PrinterName = defaultPrinterName;//Code to set default printer name
                        pd.PrinterSettings.PrinterName = defaultPrinterName;//Code to set default printer name 
                    }
                }

                //************************************End**************************************************


                //DialogResult result = pd.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    pdoc.Print();

                //}


                //***************************************************************End*****************************************************************//

            }
            catch (Exception ex)
            {


            }

        }

         void pdoc_PrintPage(object  sender, PrintPageEventArgs e)
        {

            string _testLabel1 = string.Empty;
            string _testLabel2 = string.Empty;
            int strLength = testsLabel.Length;
            

            if (testsLabel.Length > 30)
            {
                _testLabel1 = stringExtensions.Slice(testsLabel, 0, 30);
                _testLabel2 = stringExtensions.Slice(testsLabel, 30, strLength);
            }
            else
            {
                _testLabel1 = testsLabel;
                _testLabel2 = "";
            }

            StringFormat sf = new StringFormat();
            //-------------------------------------End-----------------------------------------------------//


            Font font = new Font("IDAutomationHC39M", 12);// set default font size
            float fontHeight = font.GetHeight();
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            //int startX = 35;// Position of x-axis
            //int startY = -40;//starting position of y-axis
           if (Configuration.ORG_CODE == "1")
            {
                startX = 30;// Position of x-axis
                startY = 20;//starting position of y-axis
                Offset = 0;
                e.Graphics.DrawString("*" + regNo + "*", new Font("IDAutomationHC39M", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset); // new Font("IDAutomationHC39M", 18) Set the Barcode height and Boldness
                Offset = Offset + 60; //75
                e.Graphics.DrawString(_testLabel1, new Font("Times New Roman", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX - 20, startY + Offset);

                Offset = Offset + 15; //75
                e.Graphics.DrawString(_testLabel2, new Font("Times New Roman", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX - 20, startY + Offset);
            }
            else
            {
                startX = 30;// Position of x-axis
                startY = 20;//starting position of y-axis
                Offset = 0;
                e.Graphics.DrawString("*" + regNo + "*", new Font("IDAutomationHC39M", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset); // new Font("IDAutomationHC39M", 18) Set the Barcode height and Boldness
                Offset = Offset + 60; //75
                e.Graphics.DrawString(_testLabel1, new Font("Times New Roman", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX - 20, startY + Offset);

                Offset = Offset + 15; //75
                e.Graphics.DrawString(_testLabel2, new Font("Times New Roman", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX - 20, startY + Offset);


                Offset = Offset + 6; //75
                e.Graphics.DrawString(_patientInfo, new Font("Times New Roman", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX - 20, startY + Offset);

                Offset = Offset + 15; //75
                e.Graphics.DrawString(DateTime.Now.ToString("hh:mm tt"), new Font("Times New Roman", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX - 20, startY + Offset);


            }

            //Offset = Offset + 20;
            //********************************************End********************************************

            //Offset = 0;
        }
        #endregion

        public Image generateBarcode(string id, string tests,string callNumber)
        {
            int w = id.Length*30;
            Bitmap oBitmap = new Bitmap(w, 100);
            Graphics oGraphics = Graphics.FromImage(oBitmap);
            Font oFont = new Font("IDAutomationHC39M", 16);
            PointF oPoint = new PointF(2f, 2f);
            SolidBrush oBrushWrite = new SolidBrush(Color.Black);
            SolidBrush oBrush = new SolidBrush(Color.White);
            oGraphics.FillRectangle(oBrush, 0, 0, w, 100);
            oGraphics.DrawString("*" + id + "*", oFont, oBrushWrite, oPoint);
            oPoint = new PointF(2f, 80f);
            oGraphics.DrawString(tests, new Font("Arial Narrow", 8, FontStyle.Regular), oBrushWrite, oPoint);

            string _path = @"C:/barcodes/";
           
            using (FileStream fs = File.Open(_path + id+ callNumber + ".jpg", FileMode.Create))
            {
                oBitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

            }

            oBitmap.Dispose();
            Image imgbarcode = Image.FromFile(_path + id+ callNumber + ".jpg");

            return imgbarcode;
        }




    }
}
