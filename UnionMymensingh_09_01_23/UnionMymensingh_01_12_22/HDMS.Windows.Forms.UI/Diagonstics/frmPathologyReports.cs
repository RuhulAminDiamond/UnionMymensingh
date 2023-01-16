using CrystalDecisions.Windows.Forms;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Pathology;
using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenXmlPowerTools;
using DocumentFormat.OpenXml.Wordprocessing;
using HDMS.Service.Common;
using HDMS.Model.Common;
using HDMS.Service.Hospital;
using HDMS.Model.Hospital;
using HDMS.Model.Diagnostic;
using HDMS.Model.Diagnostic.VM;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmPathologyReports : Form
    {
        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;
        ReportConsultant _doctor = new ReportConsultant();
        public delegate void _UpdateRepotListOnWordFileClose(long regNo, DateTime _date);

        private IList<Template> _SelectedTemplates;
        static DocX g_document;

        bool IsReportDone = false;

        public bool IsComboLoaded = false;

        public bool IsTreePopulated = false;

        bool isListReset = false;

        SqlDataAdapter da;
        public frmPathologyReports()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in gvTestsDetails.Columns)
            {
                c.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            gvTestsDetails.Font = new System.Drawing.Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private async void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               
                this.gvTestsDetails.DataSource = null;
                this.gvTestsDetails.Rows.Clear();
                _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

                int _idLength = txtBillNo.Text.Length;
                string _prefix = txtBillNo.Text.Slice(0, 1);
                string _rn= txtBillNo.Text.Slice(1, _idLength);

                long _reportId = 0;
                long.TryParse(_rn,out _reportId);

                
                Patient _PatientInfo = new PatientService().GetPatientByReportPrefixAndId(_prefix, _reportId);  // new PatientService().GetPatientByBillNo(_billNo);

                if (_PatientInfo == null) {

                    long _billNo = 0;
                    long.TryParse(txtBillNo.Text, out _billNo);

                    _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

                }


                if (_PatientInfo == null) {
                    MessageBox.Show("Patient not found.", "HERP");
                    txtBillNo.Tag = null;
                    return;
                } 
              

                if (_PatientInfo.AdmissionNo > 0)
                {

                    HpPatientAccomodationInfo _accomInfo = new HpPatientAccomodationInfo();
                    HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNoAny(_PatientInfo.AdmissionNo);

                    if (_hp.Status.ToLower() == "discharged")
                    {
                         _accomInfo = new HospitalCabinBedService().GetReleasedAsPBCabinByPatient(_hp.AdmissionId);
                        
                    }
                    else
                    {
                        _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hp.AdmissionId);
                       
                    }

                    if (_accomInfo != null)
                    {
                        CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                        txtCabin.Text = _cabin.CabinNo;
                    }
                    else
                    {
                        txtCabin.Text = "N/A";
                    }

                }
                else
                {
                    txtCabin.Text = "";
                }

              
                    txtBillNo.Tag = _PatientInfo;
                    txtRegistrationNo.Text = _PatientInfo.RegNo.ToString();
                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_PatientInfo.RegNo);
                    if (_record != null)
                    {
                        txtName.Text = _record.FullName;
                        txtAge.Text = Utility.GetConcatenatedAge(_record.AgeYear, _record.AgeMonth, _record.AgeDay);
                        txtSex.Text = _record.Sex;
                        if (_PatientInfo.AdmissionNo > 0) {
                            txtMobile.Text = _record.CPMobile;
                        }
                        else
                        {
                            txtMobile.Text = _record.MobileNo;
                        }
                           

                    }
                    txtDailyId.Text = _PatientInfo.DailyId.ToString();
                    txtDailyId.Tag = _PatientInfo.ReportIdPrefix + _PatientInfo.ReportId.ToString();
                    txtRefdBy.Text = new DoctorService().GetDoctorById(_PatientInfo.DoctorId).Name;
                    txtRefdBy.Tag = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                    dtpEntry.Value = _PatientInfo.EntryDate;
                    lblReceiveTime.Text = _PatientInfo.EntryTime;

                


                List<PathologyReport> _pReportList = new ReportService().GetReportDoneListByPatientId(_PatientInfo.PatientId);

                if (_pReportList.Count() > 0)
                {
                    IsReportDone = false;
                }

                //Load Tests
                TreeNode parentNode = null;
                DataTable dt = await new ReportService().GetDisticntReportTypeForPathologyReport(_PatientInfo.PatientId); //new ReportService().GetDisticntTestGroupForPathologyReport(Convert.ToInt32(txtRegNo.Text));



                TV.Nodes.Clear();            
                foreach (DataRow dr in dt.Rows)
                {
                    parentNode = TV.Nodes.Add(dr["Report_Type"].ToString());
                    parentNode.Tag = dr["ReportTypeId"].ToString()+"_"+"pNode"; //Parent Node
                    PopulateTreeView(_PatientInfo.PatientId, Convert.ToInt32(dr["ReportTypeId"]), parentNode);
                }

                //TV.ExpandAll();
                IsTreePopulated = true;
                TV.Focus();

                

            }
        }

        private async void PopulateTreeView(long parentId, int ReportTypeId, TreeNode parentNode)
        {
            DataTable dtchildc = await new ReportService().GetPathologicalTestsByReportType(parentId, ReportTypeId);//new ReportService().GetPathologicalTestsByGroup(Convert.ToInt32(txtRegNo.Text), groupId);

            TreeNode childNode;
            foreach (DataRow dr in dtchildc.Rows)
            {
                if (parentNode == null){
                    childNode = TV.Nodes.Add(dr["TestName"].ToString()+ "->"+ dr["ReportStatus"].ToString());
                    childNode.Tag = dr["TestId"];
                }
                else
                {
                    childNode = parentNode.Nodes.Add(dr["TestName"].ToString() + "->" + dr["ReportStatus"].ToString());
                    childNode.Tag = dr["TestId"];
                }
                    
            }
        }

        private void TV_DoubleClick(object sender, EventArgs e)
        {
           
            //gvTestsDetails.Columns["Test Result"].DefaultCellStyle.BackColor = Color.LightYellow;

        }

        //private void ProcessCombinedReport(TestItem _testItem)
        //{

        //    List<GroupReportItem> _gRItem = new TestService().GetGroupRetportItemsById(_testItem.TestId).ToList();

        //    foreach (var subitem in _gRItem)
        //    {
        //        List<ReportDefination> _selectedTest = new ReportService().GetTestDetailsForReport(subitem.TestId).ToList();

        //        if (_selectedTest.Count == 0)
        //        {
        //            MessageBox.Show("Report defination not found.", "HERP");
        //            return;
        //        }

        //        List<VMReportDefination> _testList = new List<VMReportDefination>();

        //        foreach (var item in _selectedTest)
        //        {
        //            VMReportDefination _rdef = new VMReportDefination();
        //            _rdef.TestDetailId = item.Id;
        //            _rdef.GroupId = item.GroupId;
        //            _rdef.TestId = item.TestId;
        //            _rdef.TestTitle = item.TestTitle;
        //            _rdef.TestName = GetTestById(item.TestId).Name;
        //            _rdef.GroupTitle = item.GroupTitle;
        //            _rdef.NormalValue = item.NormalValue;
        //            _rdef.ResultUnit = item.ResultUnit;
        //            _rdef.TestTitle_FontBold = item.TestTitle_FontBold;
        //            _rdef.TestTitle_FontItalic = item.TestTitle_FontItalic;
        //            _rdef.TestTitle_FontUnderline = item.TestTitle_FontUnderline;
        //            _rdef.LowerLimit = item.LowerLimit;
        //            _rdef.UpperLimit = item.UpperLimit;
        //            _testList.Add(_rdef);
        //        }



        //        new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

        //        FillTestGrid();
        //    }
        //}

        private TestItem GetTestById(int _testId)
        {
            return new TestService().GetTestItemById(_testId);
        }

        private void FillTestGrid()
        {
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            string _testResult = string.Empty;
            foreach (VMReportDefination item in _SelectedTestItemsForPathologyReport)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;

                if (String.IsNullOrEmpty(item.TestResult))
                {
                    _testResult = "";
                }else
                {
                    _testResult = item.TestResult;
                }
               
                if (item.TestName.ToLower() == "urine r/e" || item.TestName.ToLower() == "stool r/e")
                {
                    row.CreateCells(gvTestsDetails, item.TestTitle,  item.NormalValue, item.ResultUnit, item.NormalValue, item.GroupTitle,item.TestDetailId);
                }
                else
                {
                    row.CreateCells(gvTestsDetails, item.TestTitle, _testResult, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId);
                }

                if(item.TestTitle_FontBold==1){
                    row.ReadOnly=true;
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                } else{
                    row.ReadOnly = false;
                }

                
                gvTestsDetails.Rows.Add(row);
                
            }
        }

        private IList<VMReportDefination> _SelectedTestItemsForPathologyReport;
        private void frmPathologyReports_Load(object sender, EventArgs e)
        {

            ctrlTemplateSearch.Location = new Point(txtTemplate.Location.X, txtTemplate.Location.Y + txtTemplate.Height);
            ctrlTemplateSearch.ItemSelected += ctrlTemplateSearch_ItemSelected;

            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

            IsComboLoaded = false;

            IList<ReportConsultant> ReportDoctors = new DoctorService().GetPathologyConsultants();
            ReportDoctors.Insert(0, new ReportConsultant()
            {
                RCId = 0,
                Name = "Select Pathologist"
            });

            cmbPathologist.DataSource = ReportDoctors;
            cmbPathologist.DisplayMember = "Name";
            cmbPathologist.ValueMember = "RCId";

            cmbConsultant.DataSource = ReportDoctors;
            cmbConsultant.DisplayMember = "Name";
            cmbConsultant.ValueMember = "RCId";

            IList<ReportTechnologist> ReportTechnologists = new DoctorService().GetReportTechnologists();
            ReportTechnologists.Insert(0, new ReportTechnologist()
            {
                Id = 0,
                Name = "Select Technologist"
            });
            cmbTechnologist.DataSource = ReportTechnologists;
            cmbTechnologist.DisplayMember = "Name";
            cmbTechnologist.ValueMember = "Id";

            cmbTechnologist2.DataSource = ReportTechnologists;
            cmbTechnologist2.DisplayMember = "Name";
            cmbTechnologist2.ValueMember = "Id";

            List<PathologicalMachine> _PathMachines = new TestService().GetAllPathologicalMachines();
            _PathMachines.Insert(0, new PathologicalMachine()
            {
                Id = 0,
                MachineName = " "
            });

            cmbMachine.DataSource = _PathMachines;
            cmbMachine.DisplayMember = "MachineName";
            cmbMachine.ValueMember = "Id";

            IsComboLoaded = true;

            IList<TemplateType> t_type = new TemplateService().GetMasterTemplateCategories().ToList(); //List<TemplateType>();
            t_type = t_type.Where(x => x.Name == "Path").ToList();
            //t_type.Insert(0, new TemplateType()
            //{
            //    Id = 0,
            //    Name = "Select Type"
            //});

            cmbType.DataSource = t_type;
            cmbType.DisplayMember = "Name";


            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            lblPreparedBy.Text = MainForm.LoggedinUser.Name;
            lblPreparedBy2.Text = MainForm.LoggedinUser.Name;
            lblPrepareDateTime2.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");

            gvTestsDetails.Tag = null;

            LoadTodaysReport(DateTime.Now);

            this.ShowReportsOnListView(0, DateTimePicker.Value);

        }

        private void LoadTodaysReport(DateTime dateTime)
        {
            List<VWMReportDoneList> _todyasReport = new ReportService().GetTodaysReportList(dateTime);

            lvPrevReport.Items.Clear();
            foreach(var _item in _todyasReport){
                 ListViewItem lvItem = new ListViewItem();
                 lvItem.Text=_item.BillNo.ToString();
                 lvItem.Tag = new ReportService().GetPathologyNonWordReportById(Convert.ToInt64(_item.ReportId));
                 lvItem.SubItems.Add(_item.ReportTests);
                 lvItem.SubItems.Add(_item.ReportId);
                 lvPrevReport.Items.Add(lvItem);
            }

           
           


        }

        private void CmdSaveAndPrintReport_Click(object sender, EventArgs e)
        {
            PathologyReport _report = new PathologyReport();
            
            if (txtBillNo.Tag != null)
            {
                if (cmbPathologist.Tag == null)
                {
                    MessageBox.Show("Pathologist not selected.","HERP");
                    return;
                }

                if (cmbTechnologist.Tag == null)
                {
                    MessageBox.Show("Technologist not selected.", "HERP");
                    return;
                }

                if (txtReportType.Tag != null && txtReportType.Tag.ToString() == "DCChk")
                {
                    int _dcValue = GetDCValue();
                    if (_dcValue != 100)
                    {
                        MessageBox.Show("DC Value :"+ _dcValue.ToString()+". It should be 100. Plz. check and try again.");
                        return;
                    }

                }

                if (gvTestsDetails.Tag == null)
                {
                    MessageBox.Show("Report type not found."); return;
                }

                try
                {

                    int _reportType = 0;
                    int.TryParse(gvTestsDetails.Tag.ToString(), out _reportType);

                    CmdSaveAndPrintReport.Text = "Plz. Wait..";
                    CmdSaveAndPrintReport.Enabled = false;

                    //if (!String.IsNullOrEmpty(txtReportSerial.Text))
                    //{


                    //    PathologyReport _nwReport = (PathologyReport)txtReportSerial.Tag;

                    //    _nwReport.ReportDoctor = ((ReportConsultant)cmbPathologist.Tag).RCId;
                    //    _nwReport.ReportTechnologist = ((ReportTechnologist)cmbTechnologist.Tag).Id;
                    //    _nwReport.ModifiedBy = lblPreparedBy.Text;
                    //    _nwReport.AnyComments = txtAnyComments.Text;
                    //    _nwReport.ModifiedDate = Utils.GetServerDateAndTime();
                    //    _nwReport.ModifiedTime= Utils.GetServerDateAndTime().ToString("hh:mm tt"); 

                    //    if (new ReportService().UpdatePathologyNonWordReport(_nwReport))
                    //    {

                    //        UpdateReportDetails(_nwReport);

                    //        //if (new ReportService().DeleteExistingReportDetails(_nwReport.Id))
                    //        //{
                    //        //    SaveAndPrintReport(_nwReport.Id);
                    //        //}

                    //        CmdSaveAndPrintReport.Text = "Save and Print Report";
                    //        CmdSaveAndPrintReport.Enabled = true;

                    //    }

                    //}else
                    //{

                    Patient _patient = (Patient)txtBillNo.Tag;
                    _report.PatientId = _patient.PatientId;
                    _report.ReportDate = Utils.GetServerDateAndTime();
                    _report.ReportTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _report.ReportDoctor = ((ReportConsultant)cmbPathologist.Tag).RCId;
                    _report.ReportTechnologist = ((ReportTechnologist)cmbTechnologist.Tag).Id;
                    _report.PreparedBy = lblPreparedBy.Text;
                    _report.ReportType = _reportType;
                    _report.AnyComments = txtAnyComments.Text;
                    _report.ModifiedDate = Utils.GetServerDateAndTime();
                    _report.ModifiedTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");

                    PathologyReport _pr = new ReportService().SavePathologyNonWordReport(_report);

                    if (_pr.Id > 0)
                    {

                        SaveAndPrintReport(_pr);

                    }
                    else
                    {
                        // MessageBox.Show("");
                    }


                    CmdSaveAndPrintReport.Text = "Save and Print Report";
                    CmdSaveAndPrintReport.Enabled = true;

                }catch(Exception ex)
                {
                    MessageBox.Show("Some inconsistency found.");

                    CmdSaveAndPrintReport.Text = "Save and Print Report";
                    CmdSaveAndPrintReport.Enabled = true;

                    gvTestsDetails.SuspendLayout();
                    gvTestsDetails.Rows.Clear();
                    txtReportType.Text = "";
                    txtReportSerial.Text = "";
                    txtAnyComments.Text = "";
                    // txtCabin.Text = "";
                    txtReportSerial.Tag = null;
                    gvTestsDetails.Tag = null;
                   // txtReportType.Tag = "";
                    _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

                    isListReset = true;

                    return;
                }

                //}
            }

            //txtReportType.Tag = "";
        }

        private void UpdateReportDetails(PathologyReport _report)
        {

            bool isDynamicReport = false;
            string _staticvalues = string.Empty;
            string _staticfields = string.Empty;
            bool IsStaticReport = false;
            string staticReportType = string.Empty;

            //List<PathologyNonWordReportReportDetail> _reportDetails = new ReportService().GetPathologyNonWordReportDetailById(_report.Id);
            //foreach (DataGridViewRow row in gvTestsDetails.Rows)
            //{
            //    VMReportDefination selectedTests = row.Tag as VMReportDefination;

            //    var _result = "";
            //    if (row.Cells["TestResult"].Value != null)
            //    {
            //        _result= row.Cells["TestResult"].Value.ToString();
            //    }

            //    _reportDetails.Where(w => w.TestDetailId == selectedTests.TestDetailId).ToList().ForEach(s => s.TestResult = _result);

            //}

                 // new ReportService().UpdatePathologyNonWordReportDetails(_reportDetails);  // Previously added item will be updated.


            //List<PathologyNonWordReportReportDetail> _pathItems = new List<PathologyNonWordReportReportDetail>();
            //foreach (DataGridViewRow row in gvTestsDetails.Rows)
            //{
            //    VMReportDefination selectedTests = row.Tag as VMReportDefination;
            //    if(!_reportDetails.Any(q=>q.TestId== selectedTests.TestId))
            //    {
            //        PathologyNonWordReportReportDetail pnwrd = new PathologyNonWordReportReportDetail();
            //        pnwrd.ReportId = _report.Id;
            //        pnwrd.TestId = selectedTests.TestId;
            //        pnwrd.TestDetailId = selectedTests.TestDetailId;
            //        pnwrd.TestTitle = selectedTests.TestTitle;
            //        if (row.Cells["TestResult"].Value == null || row.Cells["TestResult"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["TestResult"].Value.ToString()))
            //        {
            //            pnwrd.TestResult = "";
            //        }
            //        else
            //        {
            //            pnwrd.TestResult = row.Cells["TestResult"].Value.ToString();
            //        }
                    
            //        pnwrd.ResultUnit= selectedTests.ResultUnit;
            //        pnwrd.NormalResult = selectedTests.NormalValue;
            //        _pathItems.Add(pnwrd);
            //    }
           
            //}

            //if (_pathItems.Count > 0)
            //{
            //    new ReportService().SavePathologicalReportDetail(_pathItems,_report);
            //}

            foreach (DataGridViewRow row in gvTestsDetails.Rows)
            {
                VMReportDefination selectedTests = row.Tag as VMReportDefination;

                var fieldName = row.Cells["TestTitle"].Value;
                var result = row.Cells["TestResult"].Value;

                if (selectedTests.TestName.ToLower() == "urine r/e" || selectedTests.TestName.ToLower() == "stool r/e")
                {
                    staticReportType = selectedTests.TestName.ToLower();
                    if (String.IsNullOrEmpty(_staticvalues))
                    {
                        _staticfields = fieldName.ToString();
                        _staticvalues = result.ToString();
                    }
                    else
                    {
                        _staticfields = _staticfields + "," + fieldName.ToString();
                        if (result != null)
                        {
                            _staticvalues = _staticvalues + "," + result.ToString();
                        }
                        else
                        {
                            _staticvalues = _staticvalues + "," + "";
                        }

                    }

                    IsStaticReport = true;
                }else
                {
                    isDynamicReport = true;
                }

                string _tstResult = string.Empty;

                if (row.Cells["TestResult"].Value == null || row.Cells["TestResult"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["TestResult"].Value.ToString()))
                {
                    _tstResult = "";
                }
                else
                {
                    _tstResult = row.Cells["TestResult"].Value.ToString();
                }

                _SelectedTestItemsForPathologyReport.Where(w => w.TestDetailId == selectedTests.TestDetailId).ToList().ForEach(s => s.TestResult = _tstResult);

            }


            if (IsStaticReport)
            {
                string[] _values = _staticvalues.Split(',');
                string[] _fields = _staticfields.Split(',');

                DataTable dt_fields = new DataTable();
                dt_fields.Columns.Add("Fields", typeof(String));
                DataRow workRow1;
                foreach (string field in _fields)
                {
                    workRow1 = dt_fields.NewRow();
                    workRow1["Fields"] = field.Trim();
                    dt_fields.Rows.Add(workRow1);
                }

                DataTable dt_values = new DataTable();
                dt_values.Columns.Add("FieldValue", typeof(String));
                DataRow workRow2;
                foreach (string val in _values)
                {
                    workRow2 = dt_values.NewRow();
                    workRow2["FieldValue"] = val.Trim();
                    dt_values.Rows.Add(workRow2);
                }


                new ReportService().GenerateStaticReport(dt_fields, dt_values);
                if (staticReportType == "urine r/e")
                {
                    ViewUrineReport(_report.Id);
                }
                else
                {
                    ViewStoolReport(_report.Id);
                }

            }

            if (isDynamicReport)
            {

                ViewReport(_report.Id);

            }
        }
        private void SaveAndPrintReport(PathologyReport _report)
        {
            bool isDynamicReport = false;
            string _staticvalues = string.Empty;
            string _staticfields = string.Empty;
            bool IsStaticReport = false;
            string staticReportType = string.Empty;

            Patient _patient = (Patient)txtBillNo.Tag;


            if (_report == null || _report.Id==0)
            {
                MessageBox.Show("Some inconsistency found"); return;
            }


            List<PathologyNonWordReportReportDetail> _reportdetailList = new List<PathologyNonWordReportReportDetail>();
            foreach (DataGridViewRow row in gvTestsDetails.Rows)
            {
                VMReportDefination selectedTests = row.Tag as VMReportDefination;
                PathologyNonWordReportReportDetail _reportdetail = new PathologyNonWordReportReportDetail();

                var fieldName = row.Cells["TestTitle"].Value;
                var result = row.Cells["TestResult"].Value;

                if (selectedTests.TestName.ToLower() == "urine r/e" || selectedTests.TestName.ToLower() == "stool r/e")
                {
                    staticReportType = selectedTests.TestName.ToLower();
                    if (String.IsNullOrEmpty(_staticvalues))
                    {
                        _staticfields = fieldName.ToString();
                        _staticvalues = result.ToString();
                    }
                    else
                    {
                        _staticfields = _staticfields + "," + fieldName.ToString();
                        if (result != null)
                        {
                            _staticvalues = _staticvalues + "," + result.ToString();
                        }
                        else
                        {
                            _staticvalues = _staticvalues + "," + "";
                        }

                    }

                    if (result != null)
                    {
                        _reportdetail.ReportId = _report.Id;
                        _reportdetail.TestId = selectedTests.TestId;
                        _reportdetail.TestDetailId = selectedTests.TestDetailId;
                        _reportdetail.TestTitle = selectedTests.TestTitle;
                        _reportdetail.TestResult = result.ToString();
                        _reportdetail.ResultUnit = selectedTests.ResultUnit;
                        _reportdetail.NormalResult = selectedTests.NormalValue;
                     
                        _reportdetailList.Add(_reportdetail);
                    }

                    IsStaticReport = true;

                }
                else
                {


                    //if (result != null)
                    //{
                        _reportdetail.ReportId = _report.Id;
                        _reportdetail.TestId = selectedTests.TestId;
                        _reportdetail.TestDetailId = selectedTests.TestDetailId;
                        _reportdetail.TestTitle = selectedTests.TestTitle;
                        if (result != null)
                        {
                            _reportdetail.TestResult = result.ToString();
                        }
                        else
                        {
                            _reportdetail.TestResult = "";
                        }
                        
                        _reportdetail.ResultUnit = selectedTests.ResultUnit;
                        _reportdetail.NormalResult = selectedTests.NormalValue;
                     
                        _reportdetailList.Add(_reportdetail);
                    //}

                    isDynamicReport = true;

                }

                string _tstResult = string.Empty;

                if (row.Cells["TestResult"].Value == null || row.Cells["TestResult"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["TestResult"].Value.ToString()))
                {
                    _tstResult = "";
                }
                else
                {
                    _tstResult = row.Cells["TestResult"].Value.ToString();
                }

                _SelectedTestItemsForPathologyReport.Where(w => w.TestDetailId == selectedTests.TestDetailId).ToList().ForEach(s => s.TestResult = _tstResult);
                _SelectedTestItemsForPathologyReport.Where(w => w.TestDetailId == selectedTests.TestDetailId).ToList().ForEach(s => s.ReportId = _report.Id);
                _SelectedTestItemsForPathologyReport.Where(w => w.TestDetailId == selectedTests.TestDetailId).ToList().ForEach(s => s.PatientId = _patient.PatientId);


            }


            if (new ReportService().AddOrUpdateReportItems(_SelectedTestItemsForPathologyReport))
            {
                List<VMReportDefination> _DistinctTestObj = _SelectedTestItemsForPathologyReport.GroupBy(i => new { i.TestId })
                                                       .Select(g => g.First())
                                                      .ToList();

                new TestService().UpdateReportStatus(_DistinctTestObj);
            }
            else
            {
                MessageBox.Show("Some inconsistency found."); return;
            }

          

            //if (_reportdetailList.Count > 0)
            //{
            //    new ReportService().SavePathologicalReportDetail(_reportdetailList,_report);

            //}else
            //{
            //    MessageBox.Show("No item found."); return;
            //}


            if (IsStaticReport)
            {
                string[] _values = _staticvalues.Split(',');
                string[] _fields = _staticfields.Split(',');

                DataTable dt_fields = new DataTable();
                dt_fields.Columns.Add("Fields", typeof(String));
                DataRow workRow1;
                foreach (string field in _fields)
                {
                    workRow1 = dt_fields.NewRow();
                    workRow1["Fields"] = field.Trim();
                    dt_fields.Rows.Add(workRow1);
                }

                DataTable dt_values = new DataTable();
                dt_values.Columns.Add("FieldValue", typeof(String));
                DataRow workRow2;
                foreach (string val in _values)
                {
                    workRow2 = dt_values.NewRow();
                    workRow2["FieldValue"] = val.Trim();
                    dt_values.Rows.Add(workRow2);
                }


                new ReportService().GenerateStaticReport(dt_fields, dt_values);
                if (staticReportType == "urine r/e")
                {
                    ViewUrineReport(_report.Id);
                }
                else
                {
                    ViewStoolReport(_report.Id);
                }

            }

            if (isDynamicReport)
            {
          
                ViewReport(_report.Id);
                
            }
       
        }

        private int GetDCValue()
        {
            int _dc = 0;
            int _dcTotal = 0;
            foreach (DataGridViewRow row in gvTestsDetails.Rows)
            {
                VMReportDefination selectedTests = row.Tag as VMReportDefination;

                if (selectedTests.TestTitle == "Neutrophils" || selectedTests.TestTitle == "Lymphocyte" || selectedTests.TestTitle == "Monocyte" ||
                    selectedTests.TestTitle == "Eosinophil" || selectedTests.TestTitle == "Basophil")
                {

                    var _val = row.Cells["TestResult"].Value;
                    if (_val != null)
                    {
                        int.TryParse(_val.ToString(), out _dc);
                        _dcTotal = _dcTotal + _dc;
                    }
                }

            }

            return _dcTotal;
        }

        private void ViewStoolReport(long p)
        {
            string _identity5 = string.Empty;
            string _identity3 = string.Empty;

            Patient _Patient = (Patient)txtBillNo.Tag;

            DataSet dsReports = new ReportService().GetPathologicalStaticTestData();
           
            rptstool _urinereport = new rptstool();

            _urinereport.SetDataSource(dsReports.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _urinereport.DataDefinition.FormulaFields[2].Text = "'" + _Patient.BillNo.ToString() + "'";
            _urinereport.DataDefinition.FormulaFields[1].Text = "'" + txtName.Text + "'";
            _urinereport.DataDefinition.FormulaFields[0].Text = "'" + txtRefdBy.Text.Replace('\'', '\"') + "'";
            _urinereport.DataDefinition.FormulaFields[6].Text = "'" + dtpEntry.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[5].Text = "'" + dtpDelivery.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[4].Text = "'" + txtAge.Text + "'";
            _urinereport.DataDefinition.FormulaFields[3].Text = "'" + txtSex.Text + "'";
            _urinereport.DataDefinition.FormulaFields[17].Text = "'" + txtDailyId.Text + "'";
            _urinereport.DataDefinition.FormulaFields[18].Text = "'" + txtCabin.Text + "'";

            _urinereport.SetParameterValue("printedby",lblPreparedBy.Text);

            _urinereport.SetParameterValue("BillNo", txtBillNo.Text);

            if (txtBillNo.Tag != null)
            {
                _urinereport.SetParameterValue("RegNo", txtBillNo.Tag.ToString());

            }
            else
            {
                _urinereport.SetParameterValue("RegNo", "");
            }


            if (cmbPathologist.Tag != null)
            {


                ReportConsultant _consultant = (ReportConsultant)cmbPathologist.Tag;
                if (!String.IsNullOrEmpty(_consultant.DIdentityLine5))
                {
                    _identity5 = _consultant.DIdentityLine5.Replace("'", "''");
                }

                if (!String.IsNullOrEmpty(_consultant.DIdentityLine3))
                {
                    _identity3 = _consultant.DIdentityLine3.Replace("'", "''");
                }

                _urinereport.DataDefinition.FormulaFields[7].Text = "'" + _consultant.Name + "'";
                _urinereport.DataDefinition.FormulaFields[8].Text = "'" + (String.IsNullOrEmpty(_consultant.DIdentityLine1) ? "" : _consultant.DIdentityLine1) + "'";
                _urinereport.DataDefinition.FormulaFields[9].Text = "'" + _consultant.DIdentityLine2 + "'";
                _urinereport.DataDefinition.FormulaFields[10].Text = "'" + _identity3 + "'";
                //_pathreport.ParameterFields[10].CurrentValues.Add(_consultant.DIdentityLine3);
                _urinereport.DataDefinition.FormulaFields[11].Text = "'" + _consultant.DIdentityLine4 + "'";
                _urinereport.DataDefinition.FormulaFields[12].Text = "'" + _identity5 + "'";
            }

            if (cmbTechnologist.Tag != null)
            {
                ReportTechnologist _technologist = (ReportTechnologist)cmbTechnologist.Tag;
                _urinereport.DataDefinition.FormulaFields[13].Text = "'" + _technologist.Name + "'";
                _urinereport.DataDefinition.FormulaFields[14].Text = "'" + _technologist.Identity1 + "'";
                _urinereport.DataDefinition.FormulaFields[15].Text = "'" + _technologist.Identity2 + "'";
                _urinereport.DataDefinition.FormulaFields[16].Text = "'" + _technologist.Identity3 + "'";
            }


            if (txtDailyId.Tag != null)
            {
                _urinereport.SetParameterValue("ReportId", "("+txtDailyId.Tag.ToString()+")");

            }
            else
            {
                _urinereport.SetParameterValue("ReportId", "");
            }

            rv.crviewer.ReportSource = _urinereport;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewUrineReport(long reportId)
        {
            string _identity5 = string.Empty;
            string _identity3 = string.Empty;

            Patient _Patient = (Patient)txtBillNo.Tag;

            DataSet dsReports = new ReportService().GetPathologicalStaticTestData();
            
            rpturine _urinereport = new rpturine();

            _urinereport.SetDataSource(dsReports.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _urinereport.DataDefinition.FormulaFields[2].Text = "'" + _Patient.BillNo.ToString() + "'";
            _urinereport.DataDefinition.FormulaFields[1].Text = "'" + txtName.Text + "'";
            _urinereport.DataDefinition.FormulaFields[0].Text = "'" + txtRefdBy.Text.Replace('\'', '\"') + "'";
            _urinereport.DataDefinition.FormulaFields[6].Text = "'" + dtpEntry.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[5].Text = "'" + dtpDelivery.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[4].Text = "'" + txtAge.Text + "'";
            _urinereport.DataDefinition.FormulaFields[3].Text = "'" + txtSex.Text + "'";
            _urinereport.DataDefinition.FormulaFields[17].Text = "'" + txtCabin.Text + "'";
            _urinereport.DataDefinition.FormulaFields[18].Text = "'" + txtDailyId.Text + "'";

            _urinereport.SetParameterValue("printedby",lblPreparedBy.Text);

            _urinereport.SetParameterValue("BillNo", txtBillNo.Text);

            if (txtBillNo.Tag != null)
            {
                _urinereport.SetParameterValue("RegNo", txtBillNo.Tag.ToString());

            } else {
                _urinereport.SetParameterValue("RegNo", "");
           }



            if (cmbPathologist.Tag != null)
            {
                
                
                ReportConsultant _consultant = (ReportConsultant)cmbPathologist.Tag;
                if (!String.IsNullOrEmpty(_consultant.DIdentityLine5))
                {
                    _identity5 = _consultant.DIdentityLine5.Replace("'", "''");
                }

                if (!String.IsNullOrEmpty(_consultant.DIdentityLine3))
                {
                    _identity3 = _consultant.DIdentityLine3.Replace("'", "''");
                }
                
                _urinereport.DataDefinition.FormulaFields[7].Text = "'" + _consultant.Name + "'";
                _urinereport.DataDefinition.FormulaFields[8].Text = "'" + (String.IsNullOrEmpty(_consultant.DIdentityLine1) ? "" : _consultant.DIdentityLine1) + "'";
                _urinereport.DataDefinition.FormulaFields[9].Text = "'" + _consultant.DIdentityLine2 + "'";
                _urinereport.DataDefinition.FormulaFields[10].Text = "'" + _identity3 + "'";
                //_pathreport.ParameterFields[10].CurrentValues.Add(_consultant.DIdentityLine3);
                _urinereport.DataDefinition.FormulaFields[11].Text = "'" + _consultant.DIdentityLine4 + "'";
                _urinereport.DataDefinition.FormulaFields[12].Text = "'" + _identity5 + "'";
            }

            if (cmbTechnologist.Tag != null)
            {
                ReportTechnologist _technologist = (ReportTechnologist)cmbTechnologist.Tag;
                _urinereport.DataDefinition.FormulaFields[13].Text = "'" + _technologist.Name + "'";
                _urinereport.DataDefinition.FormulaFields[14].Text = "'" + _technologist.Identity1 + "'";
                _urinereport.DataDefinition.FormulaFields[15].Text = "'" + _technologist.Identity2 + "'";
                _urinereport.DataDefinition.FormulaFields[16].Text = "'" + _technologist.Identity3 + "'";
            }

            if (txtDailyId.Tag != null) {
                _urinereport.SetParameterValue("ReportId", "("+txtDailyId.Tag.ToString()+")");

            }else
            {
                _urinereport.SetParameterValue("ReportId", "");
            }

            rv.crviewer.ReportSource = _urinereport;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewReport(long reportId)
        {

            string _identity5 = string.Empty;
            string _identity3 = string.Empty;
            string _comments = string.Empty;

            if (!String.IsNullOrEmpty(txtAnyComments.Text))
            {
                _comments = txtAnyComments.Text;
            }

            Patient _Patient = (Patient)txtBillNo.Tag;

            DataSet dsReports = new DataSet();
            dsReports = new ReportService().GetPathologyReportData(_SelectedTestItemsForPathologyReport);  //new ReportService().GetPathologicalTestDataByReportId(reportId);

            //da.Fill(dsReports, "dtPathologicalReportData");

            


            RptPathologyGeneralFormat _pathreport = new RptPathologyGeneralFormat();

            _pathreport.SetDataSource(dsReports.Tables[0]);




            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pathreport.DataDefinition.FormulaFields[0].Text = "'" + _Patient.BillNo.ToString() + "'";
            _pathreport.DataDefinition.FormulaFields[1].Text = "'" + txtName.Text + "'";
            _pathreport.DataDefinition.FormulaFields[2].Text = "'" + txtRefdBy.Text.Replace('\'', '\"') + "'";
            _pathreport.DataDefinition.FormulaFields[3].Text = "'" + dtpEntry.Value.ToString(customFmts) + "'";
            _pathreport.DataDefinition.FormulaFields[4].Text = "'" + dtpDelivery.Value.ToString(customFmts) + "'";
            _pathreport.DataDefinition.FormulaFields[5].Text = "'" + txtAge.Text + "'";
            _pathreport.DataDefinition.FormulaFields[6].Text = "'" + txtSex.Text + "'";
            _pathreport.DataDefinition.FormulaFields[21].Text = "'" + txtMobile.Text + "'";

            if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            {
                _pathreport.DataDefinition.FormulaFields[17].Text = "'" + "Cabin: "+txtCabin.Text + "'";
            }else
            {
                _pathreport.DataDefinition.FormulaFields[17].Text = "'" + "" + "'";
            }
            _pathreport.DataDefinition.FormulaFields[18].Text = "'" + txtDailyId.Text + "'";
            _pathreport.DataDefinition.FormulaFields[19].Text = "'" + lblPreparedBy.Text + "'";

            if (!String.IsNullOrEmpty(cmbMachine.Text)) { 
               _pathreport.SetParameterValue("MachineName",cmbMachine.Text);
            }else{
               _pathreport.SetParameterValue("MachineName","");
               
            }

            _pathreport.SetParameterValue("ReportTypes", txtReportType.Text);
            _pathreport.SetParameterValue("BillNoString", txtBillNo.Text);
            _pathreport.SetParameterValue("RegNoString", txtRegistrationNo.Text);

            if (txtDailyId.Tag != null)
            {
                _pathreport.SetParameterValue("ReportSrl", "("+txtDailyId.Tag.ToString()+")");
            }else
            {
                _pathreport.SetParameterValue("ReportSrl","");
            }

            _pathreport.SetParameterValue("ReceivedTime", lblReceiveTime.Text);

            if (cmbPathologist.Tag != null)
            {
                ReportConsultant _consultant = (ReportConsultant)cmbPathologist.Tag;
                if (!String.IsNullOrEmpty(_consultant.DIdentityLine5))
                {
                    _identity5 = _consultant.DIdentityLine5.Replace("'", "''");
                }

                if (!String.IsNullOrEmpty(_consultant.DIdentityLine3))
                {
                    _identity3 = _consultant.DIdentityLine3.Replace("'", "''");
                }
               
                _pathreport.DataDefinition.FormulaFields[7].Text = "'" + _consultant.Name + "'";
                _pathreport.DataDefinition.FormulaFields[8].Text = "'" + (String.IsNullOrEmpty(_consultant.DIdentityLine1) ? "" : _consultant.DIdentityLine1) + "'";
                _pathreport.DataDefinition.FormulaFields[9].Text = "'" + _consultant.DIdentityLine2 + "'";
                _pathreport.DataDefinition.FormulaFields[10].Text = "'" + _identity3 + "'";
                //_pathreport.ParameterFields[10].CurrentValues.Add(_consultant.DIdentityLine3);
                _pathreport.DataDefinition.FormulaFields[11].Text = "'" + _consultant.DIdentityLine4 + "'";
                _pathreport.DataDefinition.FormulaFields[12].Text = "'" + _identity5 + "'";
                _pathreport.DataDefinition.FormulaFields[20].Text = "'" + _consultant.DIdentityLine6 + "'";
            }

            if (cmbTechnologist.Tag != null)
            {
                ReportTechnologist _technologist = (ReportTechnologist)cmbTechnologist.Tag;
                _pathreport.DataDefinition.FormulaFields[13].Text = "'" + _technologist.Name + "'";
                _pathreport.DataDefinition.FormulaFields[14].Text = "'" + _technologist.Identity1 + "'";
                _pathreport.DataDefinition.FormulaFields[15].Text = "'" + _technologist.Identity2 + "'";
                _pathreport.DataDefinition.FormulaFields[16].Text = "'" + _technologist.Identity3 + "'";
            }


            if (!String.IsNullOrEmpty(_comments))
            {
                _pathreport.SetParameterValue("CommentsTitle", "Comments : ");

            }
            else
            {
                _pathreport.SetParameterValue("CommentsTitle", "");
            }

            _pathreport.SetParameterValue("AnyComments", _comments);

            rv.crviewer.ReportSource = _pathreport;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            

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


        private void cmbPathologist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsComboLoaded)
            {
                ReportConsultant _doctor = new DoctorService().GetReportConsultantById(Convert.ToInt32(cmbPathologist.SelectedValue));
                cmbPathologist.Tag = _doctor;
            }
        }

        private void cmbTechnologist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsComboLoaded)
            {
                ReportTechnologist _ReportTechnologist = new DoctorService().GetTechnologistById(Convert.ToInt32(cmbTechnologist.SelectedValue));
                cmbTechnologist.Tag = _ReportTechnologist;
            }
        }


       
        private void button1_Click(object sender, EventArgs e)
        {
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            txtReportType.Text = "";
            txtReportSerial.Text = "";
            txtAnyComments.Text = "";
           // txtCabin.Text = "";
            txtReportSerial.Tag = null;
            gvTestsDetails.Tag = null;
            txtReportType.Tag = "";
            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

            isListReset = true;
        }

        private void gvTestsDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
                e.CellStyle.BackColor = System.Drawing.Color.LightYellow;
        }

        private void txtRegNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRegNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int _idLength = txtBillNo2.Text.Length;
                string _prefix = txtBillNo2.Text.Slice(0, 1);
                string _rn = txtBillNo2.Text.Slice(1, _idLength);

                long _reportId = 0;
                long.TryParse(_rn, out _reportId);


                // long _billNo = 0;
                // long.TryParse(txtBillNo2.Text,out _billNo);
                Patient _patient = new PatientService().GetPatientByReportPrefixAndId(_prefix, _reportId); //new PatientService().GetPatientByBillNo(_billNo);



                if (_patient != null)
                {

                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_patient.RegNo);
                    if (_record != null)
                    {
                        txtPatientName.Text = _record.FullName;
                       
                        txtSex2.Text = _record.Sex;
                    }

                    txtBillNo2.Tag = _patient;
                    txtMemberRegNo.Text = _patient.RegNo.ToString();
                    txtAge2.Text = Utility.GetConcatenatedAge(_patient.AgeYear, _patient.AgeMonth, _patient.AgeDay);
                    txtDID2.Text = _patient.DailyId.ToString();
                    txtDID2.Tag = _patient.ReportIdPrefix + _patient.ReportId.ToString();

                    txtDate.Text = _patient.EntryDate.ToString("dd/MM/yyyy");

                    if (_patient.AdmissionNo > 0)
                    {
                        HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNoAny(_patient.AdmissionNo);
                        if (_hp.Status.ToLower() == "discharged")
                        {
                            txtCabin.Text = "N/A";
                        }
                        else
                        {
                            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hp.AdmissionId);
                            if (_accomInfo != null)
                            {
                                CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                                txtCabin2.Text = _cabin.CabinNo;
                            }
                            else
                            {
                                txtCabin2.Text = "N/A";
                            }
                        }

                    }
                    else
                    {
                        txtCabin2.Text = "";
                    }



                    List<ViewModelReportTests> reportTests = new TestService().GetAllPathologyTestByRegNoLegacy(_patient.PatientId).ToList();
                    txtRefBy.Text = new DoctorService().GetDoctorByIdFromLegacy(_patient.DoctorId).Name;

                    TV2.Nodes.Clear();

                    TreeNode MainNode = new TreeNode();
                    MainNode.Text = "Select Test";
                    TV2.Nodes.Add(MainNode);

                    foreach (var item in reportTests)
                    {
                        TreeNode child = new TreeNode();
                        child.Text = item.Name;
                        child.Tag = item;
                        MainNode.Nodes.Add(child);
                    }

                    TV2.ExpandAll();
                    TV2.Focus();

                    this.ShowReportsOnListView( ((Patient)txtBillNo2.Tag).PatientId, DateTimePicker.Value);
                }
                else
                {
                    MessageBox.Show("Patient not found.", "HERP");
                }
            }
        }

        private void ShowReportsOnListView(long RegNo, DateTime _datetime)
        {
            DataTable dt = new TemplateService().GetReports(null,RegNo, _datetime, "Path");

            lvReports.Items.Clear();
            lvReports.SmallImageList = imgListLarge;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string displayText = dr[1].ToString() + "-" + dr[2].ToString();
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.ToolTipText = dr[3].ToString();
                listitem.ImageIndex = 1;
                lvReports.Items.Add(listitem);
            }

        }

        private void TV2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtCurrentTestName.Tag = string.Empty;
            txtCurrentTestName.Text = string.Empty;
            txtCurrentTestName.Text = TV2.SelectedNode.Text;
            txtCurrentTestName.Tag = TV2.SelectedNode.Tag;

         if (TV2.SelectedNode.Tag!=null)
            txtReportType.Text = ((ViewModelReportTests)TV2.SelectedNode.Tag).ReportType;

          
        }

        private void txtTemplate_KeyPress(object sender, KeyPressEventArgs e)
        {
            ReportTechnologist _technologist = new ReportTechnologist();

            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlTemplateSearch.Visible = true;

                ctrlTemplateSearch.LoadDataByType(cmbType.Text);
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                ctrlTemplateSearch.Visible = false;
                int id;

                if (txtCurrentTestName.Tag == null)
                {
                    MessageBox.Show("No test selected for report.", "HERP");
                    return;
                }

                this.KillRunningProcess();

                if (int.TryParse(txtTemplate.Tag.ToString(), out id))
                {

                    _doctor = (ReportConsultant)cmbConsultant.SelectedItem;
                    _technologist = (ReportTechnologist)cmbTechnologist2.SelectedItem;

                    if (_doctor.RCId != 0 && _technologist.Id != 0)
                    {
                        this.ShowTemplate(id);
                    }
                    else
                    {
                        MessageBox.Show("Consultant/Technologist not selected. Plz. check and try again.");
                    }
                }
            }
        }

        private void KillRunningProcess()
        {
            Process[] procs = Process.GetProcessesByName("winword");

            foreach (Process proc in procs)
                proc.Kill();
        }
        private void HideAllDefaultHidden()
        {
            ctrlTemplateSearch.Visible = false;
            
        }

        private void ctrlTemplateSearch_ItemSelected(UI.Controls.SearchResultListControl<Template> sender, Template item)
        {
            txtTemplate.Text = item.TemplateName;
            txtTemplate.Tag = item.Id;
            txtTemplate.Focus();
            sender.Visible = false;
        }


        private void ShowTemplate(int templateId)
        {


            ReportFilePath = new TemplateService().GetNewReportFilePath();
            ReportFileNameWithPath = ReportFilePath + @"\" + txtBillNo2.Text + "-" + ((ViewModelReportTests)txtCurrentTestName.Tag).Id.ToString() + ".docx";

            TempMasterReoprtNameWithPath = ReportFilePath + @"\" + txtBillNo2.Text + "-" + ((ViewModelReportTests)txtCurrentTestName.Tag).Id.ToString() + ".docx";
            TempChildReoprtNameWithPath = ReportFilePath + @"\" + txtBillNo2.Text + "-" + ((ViewModelReportTests)txtCurrentTestName.Tag).Id.ToString() + ".docx";

            byte[] _masteremplatecontent = new TemplateService().GetWordMasterTemplateContent(1);
            byte[] _childtemplatecontent = new TemplateService().GetWordTemplateContent(templateId);


            if (!Directory.Exists(ReportFilePath))
            {
                Directory.CreateDirectory(@ReportFilePath);
            }

            if (File.Exists(ReportFileNameWithPath))
            {
                File.Delete(ReportFileNameWithPath);
            }



            List<Source> documentBuilderSources = new List<Source>();
            List<byte[]> docs = new List<byte[]>();
            docs.Add(_masteremplatecontent);
            docs.Add(_childtemplatecontent);
            byte[] reportcontent = this.OpenAndCombine(docs);

            FileStream fsmaster = new FileStream(ReportFileNameWithPath, FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fsmaster);
            br.Write(reportcontent);
            fsmaster.Dispose();
            br.Dispose();


            g_document = CreateReportFromTemplate(DocX.Load(@ReportFileNameWithPath));
            g_document.SaveAs(ReportFileNameWithPath);

            ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
            Process process = Process.Start(psi);
            process.EnableRaisingEvents = true;
            process.Exited += process_Exited;

            process.WaitForExit();

        }

        private byte[] OpenAndCombine(IList<byte[]> documents)
        {
            MemoryStream mainStream = new MemoryStream();

            mainStream.Write(documents[0], 0, documents[0].Length);
            mainStream.Position = 0;

            int pointer = 1;
            byte[] ret;
            try
            {
                using (WordprocessingDocument mainDocument = WordprocessingDocument.Open(mainStream, true))
                {

                    XElement newBody = XElement.Parse(mainDocument.MainDocumentPart.Document.Body.OuterXml);

                    for (pointer = 1; pointer < documents.Count; pointer++)
                    {
                        WordprocessingDocument tempDocument = WordprocessingDocument.Open(new MemoryStream(documents[pointer]), true);
                        XElement tempBody = XElement.Parse(tempDocument.MainDocumentPart.Document.Body.OuterXml);

                        newBody.Add(tempBody);
                        mainDocument.MainDocumentPart.Document.Body = new Body(newBody.ToString());
                        mainDocument.MainDocumentPart.Document.Save();
                        mainDocument.Package.Flush();
                    }
                }
            }
            catch (OpenXmlPackageException oxmle)
            {
                throw new Exception(string.Format(CultureInfo.CurrentCulture, "Error while merging files. Document index {0}", pointer), oxmle);

            }
            catch (Exception e)
            {
                throw new Exception(string.Format(CultureInfo.CurrentCulture, "Error while merging files. Document index {0}", pointer), e);
            }
            finally
            {
                ret = mainStream.ToArray();
                mainStream.Close();
                mainStream.Dispose();
            }
            return (ret);
        }

        private DocX CreateReportFromTemplate(DocX template)
        {

            if (txtCurrentTestName.Tag != null)
            {
                ViewModelReportTests reportTest = (ViewModelReportTests)txtCurrentTestName.Tag;
                string reportGroupName = Utility.GetReportGroupName(reportTest.GroupId);
               // template.ReplaceText("Report_Type", reportGroupName);
            }

            Patient _Patient = (Patient)txtBillNo2.Tag;

            template.ReplaceText("bill_no", GetPrefixedIdString(txtBillNo2.Text));
            template.ReplaceText("member_regno", txtMemberRegNo.Text);
            template.ReplaceText("Reg_No", _Patient.BillNo.ToString());
            template.ReplaceText("Admission_No", "");
            template.ReplaceText("Received_date", txtDate.Text);
            template.ReplaceText("Report_Date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));

            template.ReplaceText("Report_Type", txtReportType.Text);
           
            template.ReplaceText("Patient_Name", txtPatientName.Text);
            template.ReplaceText("Patient_Age", txtAge2.Text.Replace(" ", ""));
            template.ReplaceText("Patient_Sex", txtSex2.Text);
            template.ReplaceText("Refd_By", txtRefBy.Text);
            template.ReplaceText("Test_Name", txtCurrentTestName.Text);

            if (!String.IsNullOrWhiteSpace(txtCabin2.Text))
            {
                template.ReplaceText("Cabin_No", "Cabin :" + txtCabin2.Text);
            }
            else
            {
                template.ReplaceText("Cabin_No", "");
            }

            if (txtDID2.Tag != null)
            {
                template.ReplaceText("Report_No", txtDID2.Tag.ToString());

            }
            else
            {
                template.ReplaceText("Report_No", "");
            }

            ReportConsultant _doctor = (ReportConsultant)cmbConsultant.Tag;

            template.ReplaceText("Doctor_Name", _doctor.Name);
            template.ReplaceText("Identity_Line1", _doctor.DIdentityLine1);
            template.ReplaceText("Identity_Line2", _doctor.DIdentityLine2);
            template.ReplaceText("Identity_Line3", _doctor.DIdentityLine3);
            template.ReplaceText("Identity_Line4", _doctor.DIdentityLine4);
            template.ReplaceText("Identity_Line5", " ");

            ReportTechnologist _technologist = (ReportTechnologist)cmbTechnologist2.Tag;
            if (_technologist != null)
            {
                template.ReplaceText("Tech_Name", _technologist.Name);
                template.ReplaceText("Tech_1", _technologist.Identity1);
                template.ReplaceText("Tech_2", _technologist.Identity2);
                template.ReplaceText("Tech_3", _technologist.Identity3);
                template.ReplaceText("Tech_4", "");
               
            }

            return template;
        }

        private void process_Exited(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(ReportFileNameWithPath);
                if (fileInfo.CreationTime.CompareTo(fileInfo.LastWriteTime) < 0)
                {
                    using (BinaryReader b = new BinaryReader(File.Open(ReportFileNameWithPath, FileMode.Open)))
                    {
                        int length = (int)b.BaseStream.Length;
                        byte[] ReportContent = new byte[length];
                        b.Read(ReportContent, 0, length);

                        bool isReportExists = new TemplateService().IsReportExists(txtBillNo.Text, (ViewModelReportTests)txtCurrentTestName.Tag);

                        Patient _P =  (Patient)txtBillNo2.Tag;

                        MsWordReport newReport = new MsWordReport();
                        newReport.RegNo = _P.BillNo.ToString();
                        newReport.PatientId = _P.PatientId;
                        newReport.TestInfo = (ViewModelReportTests)txtCurrentTestName.Tag;
                        newReport.ReportContent = ReportContent;
                        newReport._ReportDoctor = _doctor;
                        newReport.PreparedBy = lblPreparedBy.Text;
                        newReport.PreparedDate = DateTime.Now;
                        newReport.Preparedtime = DateTime.Now.ToString("hh:mm:ss");
                        newReport.ReportType = cmbType.Text;
                        string msg = string.Empty;

                        if (isReportExists)
                        {
                            msg = new TemplateService().UpdateReport(newReport);
                        }
                        else
                        {
                            msg = new TemplateService().SaveReport(newReport);
                        }


                        if (String.Compare(msg, "Success") == 0)
                        {
                            // MessageBox.Show("File Saved");
                        }
                        else
                        {
                            MessageBox.Show("Save to DB Fail.");
                        }

                        Thread t = new Thread(new ThreadStart(this.UpdateReportList));
                        t.IsBackground = true;
                        t.Start();

                        //this.Invoke(new MethodInvoker(this.ShowReportsOnListView("", DateTimePicker.Value))); 


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HERP");
            }

        }

        private void UpdateReportList()
        {
            Invoke(new _UpdateRepotListOnWordFileClose(ShowReportsOnListView), new object[] { "", Convert.ToDateTime(DateTimePicker.Value) });
        }


        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.ShowReportsOnListView(0, DateTimePicker.Value);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pnlPreviousReport.Visible = true;
            }
            else
            {
                pnlPreviousReport.Visible = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadTodaysReport(dateTimePicker1.Value);
        }

        private void lvPrevReport_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PathologyReport _RecalldoneReport = (PathologyReport)lvPrevReport.Items[lvPrevReport.SelectedIndices[0]].Tag;
            Patient _PatientInfo = new PatientService().GetPatientByIdNo(_RecalldoneReport.PatientId);

                LoadPreviousReportData(_PatientInfo, _RecalldoneReport);

                pnlPreviousReport.Visible = false;
                checkBox1.Checked = false;
            

        }

        private void LoadPreviousReportData(Patient _PatientInfo, PathologyReport _RecalldoneReport)
        {
            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");
                txtBillNo.Tag = null;
            }else if(_RecalldoneReport == null)
            {
                return;
            }
            else
            {
                txtReportSerial.Text = _RecalldoneReport.Id.ToString();
                txtReportSerial.Tag = _RecalldoneReport;
                txtBillNo.Tag = _PatientInfo;
                txtBillNo.Text = _PatientInfo.ReportIdPrefix + _PatientInfo.ReportId.ToString();

                txtRefdBy.Text = new DoctorService().GetDoctorById(_PatientInfo.DoctorId).Name;
                txtRefdBy.Tag = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);

                ReportConsultant _reportDoctor = new DoctorService().GetReportConsultantById(_RecalldoneReport.ReportDoctor);
                ReportTechnologist _reportTechnologist = new DoctorService().GetTechnologistById(_RecalldoneReport.ReportTechnologist);

                cmbPathologist.Text = _reportDoctor.Name;
                cmbTechnologist.Text = _reportTechnologist.Name;

                cmbPathologist.Tag = _reportDoctor;
                cmbTechnologist.Tag = _reportTechnologist;

                dtpEntry.Value = _PatientInfo.EntryDate;

                DataTable dt = new ReportService().GetPreviousReportTestDetails(_RecalldoneReport.Id);

                List<VMReportDefination> _testList = new List<VMReportDefination>();
                _testList = (from DataRow dr in dt.Rows
                             select new VMReportDefination()
                             {
                                 TestTitle = dr["TestTitle"].ToString(),
                                 TestName = dr["TestName"].ToString(),
                                 TestResult = dr["TestResult"].ToString(),
                                 ResultUnit = dr["ResultUnit"].ToString(),
                                 TestDetailId = Convert.ToInt32(dr["TestDetailId"]),
                                 TestId = Convert.ToInt32(dr["TestId"]),
                                 GroupId = Convert.ToInt32(dr["GroupId"]),
                                 TestTitle_FontBold= Convert.ToInt32(dr["TestTitle_FontBold"]),
                                 NormalValue = dr["NormalResult"].ToString(),

                             }).ToList();



                new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                FillTestGridForPreviousReport();
            }
        }

        private void FillTestGridForPreviousReport()
        {
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            long _reportId = 0;
            foreach (VMReportDefination item in _SelectedTestItemsForPathologyReport)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                _reportId = item.ReportId;
                row.CreateCells(gvTestsDetails, item.TestTitle, item.TestResult, item.ResultUnit, item.NormalValue);

                if (item.TestTitle_FontBold == 1)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
                else
                {
                    row.ReadOnly = false;
                }

                gvTestsDetails.Rows.Add(row);

            }

            if (_reportId > 0)
            {

                PathologyReport _pReport = new ReportService().GetPathologyNonWordReportById(_reportId);

                txtReportSerial.Text = _reportId.ToString();
                txtReportSerial.Tag = _pReport;
            }
        }

        private void lvReports_DoubleClick(object sender, EventArgs e)
        {
            if (lvReports.SelectedItems.Count == 1)
            {
                this.KillRunningProcess();

                ListView.SelectedListViewItemCollection items = lvReports.SelectedItems;

                ListViewItem lvItem = items[0];
                this.ViewPreviousReport(lvItem.Text);

            }
        }

        private void ViewPreviousReport(string fileName)
        {
            txtAge.Tag = fileName;          // For later use during update database
            string[] Ids = fileName.Split('-');

            //string _reportType = new ReportService().GetReportType(Ids);
            //cmbType.Text = _reportType;

            byte[] reportcontent = new TemplateService().GetPreviousReport(Ids);

            Int32 _ConsultantId = new WordReportService().GetConsultantId(Ids);
            ReportConsultant _Consultant = new DoctorService().GetReportConsultantById(_ConsultantId);
            cmbConsultant.Text = _Consultant.Name;
            cmbConsultant.Tag = _Consultant;

            ReportFilePath = new TemplateService().GetOldReportFilePath();
            ReportFileNameWithPath = ReportFilePath + @"\" + fileName + ".docx";

            if (!Directory.Exists(ReportFilePath))
            {
                Directory.CreateDirectory(ReportFilePath);
            }

            if (File.Exists(ReportFileNameWithPath))
            {
                File.Delete(ReportFileNameWithPath);
            }

            FileStream fs = new FileStream(ReportFileNameWithPath, FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(reportcontent);
            fs.Dispose();
            br.Dispose();

            ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
            Process process = Process.Start(psi);
            process.EnableRaisingEvents = true;
            process.Exited += process_Exited_oldreport;

            process.WaitForExit();    
        }

        private void process_Exited_oldreport(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(ReportFileNameWithPath);
                if (fileInfo.CreationTime.CompareTo(fileInfo.LastWriteTime) < 0)
                {
                    using (BinaryReader b = new BinaryReader(File.Open(ReportFileNameWithPath, FileMode.Open)))
                    {
                        int length = (int)b.BaseStream.Length;
                        byte[] ReportContent = new byte[length];
                        b.Read(ReportContent, 0, length);


                        string[] Ids = txtAge.Tag.ToString().Split('-');

                        ViewModelReportTests reportTest = new TestService().GetSelectedPathTestByRegNoLegacy(Ids[0], Ids[1]);

                        MsWordReport newReport = new MsWordReport();
                        newReport.RegNo = Ids[0];
                        newReport.TestInfo = reportTest;
                        newReport.ReportContent = ReportContent;
                        newReport.PreparedBy = lblPreparedBy.Text;
                        newReport.ReportType = cmbType.Text;
                        newReport._ReportDoctor = (ReportConsultant)cmbConsultant.Tag;
                        newReport.PreparedDate = DateTime.Now;
                        newReport.Preparedtime = DateTime.Now.ToString("hh:mm:ss");

                        string msg = string.Empty;
                        msg = new TemplateService().UpdateReport(newReport);


                        if (String.Compare(msg, "Success") == 0)
                        {
                            //MessageBox.Show("File Updated");
                        }
                        else
                        {
                            MessageBox.Show("DB. Update Fail.");
                        }


                        Thread t = new Thread(new ThreadStart(this.UpdateReportList));
                        t.IsBackground = true;
                        t.Start();


                        //this.ShowReportsOnListView("", DateTimePicker.Value);


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HERP");
            }

        }

        private void cmbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsComboLoaded)
            {
                ReportConsultant _doctor = new DoctorService().GetReportConsultantById(Convert.ToInt32(cmbConsultant.SelectedValue));
                cmbConsultant.Tag = _doctor;
            }
        }

        private void cmbTechnologist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsComboLoaded)
            {
                ReportTechnologist _ReportTechnologist = new DoctorService().GetTechnologistById(Convert.ToInt32(cmbTechnologist2.SelectedValue));
                cmbTechnologist2.Tag = _ReportTechnologist;
            }
        }

        private void TV_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (IsTreePopulated)
            {
                if (TV.SelectedNode.Tag == null) return;

                string[] arr = null;
                arr = TV.SelectedNode.Tag.ToString().Split('_');

                txtReportType.Text = "";
                txtReportType.Tag = null;

                List<VMReportDefination> _testList = new List<VMReportDefination>();

                if (arr.Length > 1)  // By Report Type
                {

                    LoadTestResultByReportType(arr[0]);
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

                        if(_currentReportType != _selectedReportType)
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

                    LoadTestResultByTestId(_testId);

                }
            }

        }

        private async void LoadTestResultByTestId(int _testId)
        {

           // _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            List<VMReportDefination> _testList = new List<VMReportDefination>();

           

            TestItem _testItem = new TestService().GetTestItemById(_testId);

            if (_testItem == null) return;


            // Set Flag for DC Value Checked

            if (_testItem.TestId == 155 || _testItem.TestId == 1979)
            {
                txtReportType.Tag = "DCChk";
            }


            ReportType _reportType = new TestService().GetReportTypesById(_testItem.ReportTypeId);
            txtReportType.Text = _reportType.Report_Type;

            Patient _Patient = (Patient)txtBillNo.Tag;

            int _rTypeId = 0;
            int _priorityId = 100;

            List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId, _Patient.ReportIdPrefix+ _Patient.ReportId.ToString());
            if (priorityObj != null && priorityObj.Count > 0)
            {
                foreach (var item in priorityObj)
                {
                    _rTypeId = item.ReportTypeId;
                    if (_priorityId > item.Priority)
                        _priorityId = item.Priority;

                }
            }


            DataTable _dt = await new ReportService().GetPreviousReportTestDetailsByPatientByTestId(_Patient.PatientId, _testItem.TestId, _rTypeId, _priorityId);  // If already report done
            if (_dt.Rows.Count > 0)
            {

                _testList = (from DataRow _dr in _dt.Rows
                             select new VMReportDefination()
                             {
                                 PatientId = Convert.ToInt64(_dr["PatientId"]),
                                 ReportId = Convert.ToInt64(_dr["Id"]),
                                 TestTitle = _dr["TestTitle"].ToString(),
                                 TestName = _dr["TestName"].ToString(),
                                 TestResult = _dr["TestResult"].ToString(),
                                 ResultUnit = _dr["ResultUnit"].ToString(),
                                 TestDetailId = Convert.ToInt32(_dr["TestDetailId"]),
                                 TestId = Convert.ToInt32(_dr["TestId"]),
                                 ReportTypeId= Convert.ToInt32(_dr["ReportTypeId"]),
                                 GroupId = Convert.ToInt32(_dr["GroupId"]),
                                 TestTitle_FontBold = Convert.ToInt32(_dr["TestTitle_FontBold"]),
                                 NormalValue = _dr["NormalResult"].ToString(),

                             }).ToList();

           
                VMReportDefination _repdef = _testList.FirstOrDefault();

               
                PathologyReport _pReport = new ReportService().GetPathologyNonWordReportById(_repdef.ReportId);
                txtReportSerial.Text = _repdef.ReportId.ToString();
                txtReportSerial.Tag = _pReport;
                LoadReportConsultants(_pReport.ReportDoctor);
                LoadReportTechnologists(_pReport.ReportTechnologist);
                //LoadPreviousReportData(_Patient, _pReport);

                new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                FillTestGridForPreviousReport();

                IsReportDone = false;
            }
            else
            {


                DataTable _selectedTest = await new ReportService().GetTestDetailsForReport(_Patient.PatientId, _testItem.TestId,0,0);

                if (_selectedTest.Rows.Count > 0)
                {


                    _testList = (from DataRow _dr in _selectedTest.Rows
                                 select new VMReportDefination()
                                 {
                                     PatientId = Convert.ToInt64(_dr["PatientId"]),
                                     ReportId = 0,
                                     TestTitle = _dr["TestTitle"].ToString(),
                                     TestName = _dr["TestName"].ToString(),
                                     TestResult = _dr["TestResult"].ToString(),
                                     MachineResult = _dr["LisValue"].ToString(),
                                     ResultUnit = _dr["ResultUnit"].ToString(),
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


                new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                FillTestGrid();
            }
        }

        private async void LoadTestResultByReportType(string _reportTypeId)
        {
            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            List<VMReportDefination> _testList = new List<VMReportDefination>();

            txtReportType.Tag = "";

            int reportTypeId = 0;
            int.TryParse(_reportTypeId, out reportTypeId);

            ReportType _rType = new TestService().GetReportTypesById(reportTypeId);

            if (!String.IsNullOrEmpty(_rType.TestCarriedOutBy))
            {
                cmbMachine.Text = _rType.TestCarriedOutBy;
            }
            else
            {
                cmbMachine.Text = "";
            }

            Patient _Patient = (Patient)txtBillNo.Tag;

          

            ReportType _reportType = new TestService().GetReportTypesById(reportTypeId);
            txtReportType.Text = _reportType.Report_Type;

            DataTable dtchildc = await new ReportService().GetPathologicalTestsByReportType(_Patient.PatientId, reportTypeId);
            foreach (DataRow dr in dtchildc.Rows)
            {
                TestItem _testItem = new TestService().GetTestItemById(Convert.ToInt32(dr["TestId"]));

                if (_testItem == null) return;

                if (_testItem.TestId == 155 || _testItem.TestId == 1979)
                {
                    txtReportType.Tag = "DCChk";
                }else
                {
                    txtReportType.Tag = "";
                }

               

                int _rTypeId = 0;
                int _priorityId = 100;

                List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId, _Patient.ReportIdPrefix+_Patient.ReportId.ToString());
                if (priorityObj != null && priorityObj.Count > 0)
                {
                    foreach (var item in priorityObj)
                    {
                        _rTypeId = item.ReportTypeId;
                        if (_priorityId > item.Priority)
                            _priorityId = item.Priority;

                    }
                }


                DataTable _dt = await new ReportService().GetPreviousReportTestDetailsByPatientByTestId(_Patient.PatientId, _testItem.TestId, _rTypeId, _priorityId);  // If already report done

                if (_dt.Rows.Count > 0)
                {

                    _testList = (from DataRow _dr in _dt.Rows
                                 select new VMReportDefination()
                                 {
                                     PatientId = Convert.ToInt64(_dr["PatientId"]),
                                     ReportId = Convert.ToInt64(_dr["Id"]),
                                     TestTitle = _dr["TestTitle"].ToString(),
                                     TestName = _dr["TestName"].ToString(),
                                     TestResult = _dr["TestResult"].ToString(),
                                     ResultUnit = _dr["ResultUnit"].ToString(),
                                     TestDetailId = Convert.ToInt32(_dr["TestDetailId"]),
                                     TestId = Convert.ToInt32(_dr["TestId"]),
                                     GroupId = Convert.ToInt32(_dr["GroupId"]),
                                     GroupTitle = _dr["GroupTitle"].ToString(),
                                     ReportTypeId= Convert.ToInt32(_dr["ReportTypeId"]),
                                     TestTitle_FontBold = Convert.ToInt32(_dr["TestTitle_FontBold"]),
                                     NormalValue = _dr["NormalResult"].ToString(),
                                     DetailReportOrder= Convert.ToInt32(_dr["DetailReportOrder"]),
                                     TestReportOrder = Convert.ToInt32(_dr["TestReportOrder"]),
                                     GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"])

                                 }).ToList();


                    new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                    VMReportDefination rdef = _SelectedTestItemsForPathologyReport.FirstOrDefault();
                    PathologyReport _pReport = new ReportService().GetPathologyNonWordReportById(rdef.ReportId);
                    //LoadReportConsultants(_pReport.ReportDoctor);
                    //LoadReportTechnologists(_pReport.ReportTechnologist);
                    txtReportSerial.Text = rdef.ReportId.ToString();
                    txtReportSerial.Tag = _pReport;

                    //FillTestGridForPreviousReport();
                }
                else
                {

                    DataTable _selectedTest = await new ReportService().GetTestDetailsForReport(_Patient.PatientId, _testItem.TestId,0,0);

                    if (_selectedTest.Rows.Count > 0)
                    {


                        _testList = (from DataRow _dr in _selectedTest.Rows
                                     select new VMReportDefination()
                                     {
                                         PatientId = Convert.ToInt64(_dr["PatientId"]),
                                         ReportId = 0,
                                         TestTitle = _dr["TestTitle"].ToString(),
                                         TestName = _dr["TestName"].ToString(),
                                         TestResult = _dr["TestResult"].ToString(),
                                         MachineResult = _dr["LisValue"].ToString(),
                                         ResultUnit = _dr["ResultUnit"].ToString(),
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
                     }
             
            }


            if (_testList.Count == 0) return;

            new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

            FillTestGrid();
        }

        private void LoadReportTechnologists(int reportTechnologist)
        {
            List<ReportTechnologist> ReportTechnologists = new DoctorService().GetReportTechnologists().ToList();
            ReportTechnologists.Insert(0, new ReportTechnologist()
            {
                Id = 0,
                Name = "Select Technologist"
            });
            cmbTechnologist.DataSource = ReportTechnologists;
            cmbTechnologist.DisplayMember = "Name";
            cmbTechnologist.ValueMember = "Id";

            cmbTechnologist.SelectedItem = ReportTechnologists.Find(q => q.Id == reportTechnologist);
            cmbTechnologist.Tag = ReportTechnologists.Find(q => q.Id == reportTechnologist);
        }

        private void LoadReportConsultants(int reportDoctor)
        {
            List<ReportConsultant> ReportDoctors = new DoctorService().GetPathologyConsultants().ToList();
            ReportDoctors.Insert(0, new ReportConsultant()
            {
                RCId = 0,
                Name = "Select Pathologist"
            });

            cmbPathologist.DataSource = ReportDoctors;
            cmbPathologist.DisplayMember = "Name";
            cmbPathologist.ValueMember = "RCId";

            cmbPathologist.SelectedItem = ReportDoctors.Find(q => q.RCId == reportDoctor);
            cmbPathologist.Tag = ReportDoctors.Find(q => q.RCId == reportDoctor);

        }

        private void gvTestsDetails_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter){

                gvTestsDetails.Focus();
            }
        }

        private void TV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TV.Nodes.Count > 0 && TV.SelectedNode.Tag != null)
                {
                    var val = TV.SelectedNode.Tag;
                }
              //  MessageBox.Show("hhhhh");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void TV2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTemplate.Focus();
            }
        }

        private void ctrlTemplateSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtTemplate.Focus();
        }

        private void gvTestsDetails_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            VMReportDefination _SelectedItem = (VMReportDefination)e.Row.Tag;
           _SelectedTestItemsForPathologyReport.Remove(e.Row.Tag as VMReportDefination);
        }
    }
}
