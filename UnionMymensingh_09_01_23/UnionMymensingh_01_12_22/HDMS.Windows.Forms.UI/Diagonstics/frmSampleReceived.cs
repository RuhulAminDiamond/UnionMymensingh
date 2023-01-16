using CrystalDecisions.Windows.Forms;
using DSBarCode;
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

namespace HDMS.Windows.Forms.UI.Diagonstics
{  

    public partial class frmSampleReceived : Form
    {

        BarCodeCtrl _control2 = new BarCodeCtrl();
        private List<SelectedTestItemsForPatient> _SelectedTests;
        string _testLabel = string.Empty;
        string _regNo = string.Empty;

        IList<SelectedTestItemsForPatient> _seletedTestItems;
        IList<SelectedTestItemsForPatient> _sampleCollectedTestItems;

        public frmSampleReceived()
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
                int _idLength = txtBillNo.Text.Length;
                string _prefix = txtBillNo.Text.Slice(0, 1);
                string _rn = txtBillNo.Text.Slice(1, _idLength);

                long _reportId = 0;
                long.TryParse(_rn, out _reportId);

                //long _billNo = 0;
                //long.TryParse(txtBillNo.Text, out _billNo);
                Patient _PatientInfo = new PatientService().GetPatientByReportPrefixAndId(_prefix, _reportId);

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
                                              TestCostId= Convert.ToInt64(dr["Id"]),
                                              Id = Convert.ToInt32(dr["TestId"]),
                                              Name = dr["TestName"].ToString(),
                                              ShortName = dr["ShortName"].ToString(),
                                              ReportStatus = dr["ReportStatus"].ToString(),
                                              CollectionTypeId = GetCollectionTypeId(dr["CollectionTypeId"])

                                          }).ToList();


                        int _numberOfIndividualVacu = _SelectedTests.Where(x => x.CollectionTypeId == 1).Count();
                       

                         GetProcessedSelectedTest(_SelectedTests);

                        FillTestGrid();
                        AddToStatusToGrid(_PatientInfo.PatientId);
                        // SaveAndPrint();
                        txtBillNo.Text = "";
                        txtBillNo.Tag = null;
                    }
                    else
                    {
                        MessageBox.Show("This is a cancelled Id.", "HERP");
                       
                    }
                }
            }
        }

        private IList<SelectedTestItemsForPatient> GetProcessedSelectedTest(List<SelectedTestItemsForPatient> _SelectedTests)
        {
          
            foreach(var item in _SelectedTests)
            {
                SelectedTestItemsForPatient _tp = new SelectedTestItemsForPatient();
                List<SampleCollectionSetting> _scs = new TestService().GetSampleCollectionSetting(item.Id);
                if (_scs.Count() == 0)
                {
                    _tp.ShortBillNo = txtBillNo.Text;
                    _tp.TestCostId = item.TestCostId;
                    _tp.Id = item.Id;
                    _tp.Name = item.Name;
                    _tp.ShortName = item.ShortName;
                    _tp.ReportStatus = item.ReportStatus;
                    _tp.CollectionTypeId = item.CollectionTypeId;
                    _seletedTestItems.Add(_tp);
                }
                else
                {
                    foreach(var scs in _scs)
                    {
                        _tp = new SelectedTestItemsForPatient();
                        _tp.ShortBillNo = txtBillNo.Text;
                        _tp.TestCostId = item.TestCostId;
                        _tp.Id = scs.MainTestId;
                        _tp.Name = scs.Description;
                        _tp.ShortName = item.ShortName;
                        _tp.ReportStatus = item.ReportStatus;
                        _seletedTestItems.Add(_tp);
                    }
                }
            }

            return _seletedTestItems;
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
            foreach (SelectedTestItemsForPatient item in _seletedTestItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgTests, item.ShortBillNo, item.Id, item.Name,false);
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

            if (dgTests.Columns.Contains("Chk") && dgTests.Columns["Chk"].Visible)
            {
                foreach (DataGridViewRow row in dgTests.Rows)
                {

                    row.Cells["Chk"].Value = true;

                }
            }else
            {
                dgTests.Columns.Add(dgvCmb);
                foreach (DataGridViewRow row in dgTests.Rows)
                {

                    row.Cells["Chk"].Value = true;

                }

            }





        }


      
        private void frmSampleCollection_Load(object sender, EventArgs e)
        {
            _seletedTestItems = new  List<SelectedTestItemsForPatient>();
            _sampleCollectedTestItems = new List<SelectedTestItemsForPatient>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveAndPrint();
        }


        private void SaveAndPrint()
        {

            int count = 0;
            int.TryParse(lblTotal.Text, out count);
            string _combinedTests = string.Empty;
            try
            {
                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    if ((bool)row.Cells["Chk"].Value == true)
                    {
                        SelectedTestItemsForPatient _seletedItem = (SelectedTestItemsForPatient)row.Tag;
                        if (_seletedItem.ReportStatus == ReportStatusEnum.SC.ToString())
                        {

                            if (_seletedItem.CollectionTypeId == 1)
                            {
                                PrintCode _pCode = new PrintCode();
                                _testLabel = _seletedItem.ShortName;
                                _regNo = txtDays.Tag.ToString();//GetPrefixedIdString(txtBillNo.Text);
                                //_pCode.print(_testLabel, _regNo);
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(_combinedTests))
                                {
                                    _combinedTests = _seletedItem.ShortName;
                                }
                                else
                                {
                                    _combinedTests = _combinedTests + ", " + _seletedItem.ShortName;
                                }
                            }
                        }
                    }
                }

                if (!String.IsNullOrEmpty(_combinedTests))
                {
                    PrintCode _pCode = new PrintCode();
                    _testLabel = _combinedTests;
                    _regNo = txtDays.Tag.ToString(); //GetPrefixedIdString(txtBillNo.Text);
                    _pCode.print(_testLabel, _regNo, txtPatientName.Text + "/" + cmbGender.Text);
                }
            }
            catch (Exception ex)
            {


            }



            long _pId = 0;
            long.TryParse(txtBillNo.Text, out _pId);
            List<TestsCost> _testList = new List<TestsCost>();

            foreach (DataGridViewRow row in dgTests.Rows)
            {
                if ((bool)row.Cells["Chk"].Value == true)
                {
                    SelectedTestItemsForPatient _seletedItem = (SelectedTestItemsForPatient)row.Tag;
                    if (_seletedItem.ReportStatus == ReportStatusEnum.SC.ToString())
                    {
                        TestsCost _cost = new TestsCost(); //new  TestService().GetTestCostById(_pId, _seletedItem.Id);
                        _cost.PatientId = _pId;

                        _cost.TestId = _seletedItem.Id;
                        _cost.ReportStatus = ReportStatusEnum.SC.ToString();
                        _testList.Add(_cost);
                    }
                }

            }

            if (_testList.Count() > 0)
            {

               // if (new TestService().UpdateTestCost(_testList)) // For sample collection status
               // {
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("PatientId", typeof(string));
                    //dt.Columns.Add("TestName", typeof(string));

                    //foreach(var item in _testList)
                    //{
                    //    SelectedTestItemsForPatient _selected = _SelectedTests.Where(x => x.Id == item.TestId).FirstOrDefault();
                    //    dt.Rows.Add(GetPrefixedIdString(txtRegNo.Text), _selected.Name);
                    //}

                    //PrintLabel(dt);
                //}

            }
            else
            {
                MessageBox.Show("Sample already collected");
            }


            UpdateStatusToGrid();


            //txtBillNo.Text = "";
        }

        private void UpdateStatusToGrid()
        {
            long _billNo = 0;
            long.TryParse(txtBillNo.Text, out _billNo);

            //Load PatientInfo
            Patient _PatientInfo = new PatientService().GetPatientByBillNo(_billNo);

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
            if (_originalId.Length == 1) _appendZero = "00000";
            if (_originalId.Length == 2) _appendZero = "0000";
            if (_originalId.Length == 3) _appendZero = "000";
            if (_originalId.Length == 4) _appendZero = "00";
            if (_originalId.Length == 5) _appendZero = "0";
           

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

        private void LoadBarcodeForId(string _PatientId)
        {
            _control2.BarCode = _PatientId;//.Aggregate(string.Empty, (c, i) => c + i + ' '); 
            _control2.BarCodeHeight = 35;
            _control2.Font = new System.Drawing.Font("Comic Sans MS", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control2.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            _control2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control2.HeaderText = "Buro Health Care";
            _control2.LeftMargin = 10;
            _control2.Location = new System.Drawing.Point(950, 480);
            //_control.Name = "userControl11";
            _control2.ShowFooter = true;
            _control2.ShowHeader = true;
            _control2.Size = new System.Drawing.Size(190, 75);
            _control2.TabIndex = 0;
            _control2.TopMargin = 1;
            _control2.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            _control2.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            this.Controls.Add(_control2);
        }

        private void btn2SavePrint_Click(object sender, EventArgs e)
        {
            

            int count = 0;
            int callNumber = 0;
            int.TryParse(lblTotal.Text, out count);
            string _combinedTests = string.Empty;
            
            try
            {

                List<TestsCost> _testCostList = new List<TestsCost>();

                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    if ((bool)row.Cells["Chk"].Value == true)
                    {
                        SelectedTestItemsForPatient _seletedItem = (SelectedTestItemsForPatient)row.Tag;
                        if (_seletedItem.ReportStatus == ReportStatusEnum.NE.ToString() || _seletedItem.ReportStatus == ReportStatusEnum.SC.ToString())
                        {
                            TestsCost _tCost = new TestsCostService().GetTestCostByTestId(_seletedItem.TestCostId);
                            if (_seletedItem.CollectionTypeId == 1)
                            {

                                _tCost.ReportStatus = ReportStatusEnum.SR.ToString();
                                _tCost.SampleReceivedDate = Utils.GetServerDateAndTime();
                                _tCost.SampleReceivedTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                _tCost.SampleReceivedBy = MainForm.LoggedinUser.Name;

                            }
                            else
                            {
                                _tCost.ReportStatus = ReportStatusEnum.SR.ToString();
                                _tCost.SampleReceivedDate = Utils.GetServerDateAndTime();
                                _tCost.SampleReceivedTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                _tCost.SampleReceivedBy = MainForm.LoggedinUser.Name;
                            }

                            _testCostList.Add(_tCost);
                        }

                        _seletedItem.SampleReceivedDate = Utils.GetServerDateAndTime();
                        _seletedItem.SampleReceivedTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        _seletedItem.SampleReceivedBy = MainForm.LoggedinUser.Name;

                        _sampleCollectedTestItems.Add(_seletedItem);
                    }
                }

                if (_testCostList.Count > 0)
                {
                    new TestsCostService().UpdateReportStatus(_testCostList);
                    MessageBox.Show("Sample received successful.");
                    ViewPrintReceivedSampleList();
                    ClearWindow();
                
                }

            }
            catch (Exception  ex)
            {


            }


           // p.generateBarcode("010078","Blood Glucose 1 hour after BF");
        }

        private void ViewPrintReceivedSampleList()
        {
            DataSet ds = new TestsCostService().GetReceivedSampleList(_sampleCollectedTestItems);
            rptSampleReceiveByLabStatement _rpt = new rptSampleReceiveByLabStatement();
            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void ClearWindow()
        {
            _seletedTestItems = new List<SelectedTestItemsForPatient>();
        }

        private void btnPrintToken_Click(object sender, EventArgs e)
        {
            DataSet ds;

            long _billNo = 0;
            long.TryParse(txtBillNo.Text, out _billNo);

            Patient _PatientInfo = new PatientService().GetPatientByBillNo(_billNo);

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

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtReceiveTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }
    }

}
