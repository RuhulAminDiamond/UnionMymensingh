using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Hospital;
using HDMS.Model.LIS;
using HDMS.Model.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Pathology;
using Novacode;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmPathologyReportLIS : Form
    {

        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;
        ReportConsultant _doctor = new ReportConsultant();
        public delegate void _UpdateRepotListOnWordFileClose(long patientId, DateTime _date);

        private IList<Template> _SelectedTemplates;
        static DocX g_document;

        bool IsReportDone = false;

        public bool IsComboLoaded = false;

        public bool IsPathMachineLoaded = false;

        public bool IsTreePopulated = false;

        bool isListReset = false;

        bool isLabMachineLoadedFromTv = false;

        SqlDataAdapter da;


      

        public frmPathologyReportLIS()
        {
            InitializeComponent();
        }

        private async void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                LoadPahologicalMachines();

                this.gvTestsDetails.DataSource = null;
                this.gvTestsDetails.Rows.Clear();
                _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

                int _idLength = txtBillNo.Text.Length;
                string _prefix = txtBillNo.Text.Slice(0, 1);
                string _rn = txtBillNo.Text.Slice(1, _idLength);

                long _PatientId = 0;
                long.TryParse(txtBillNo.Text, out _PatientId);
                
                
                
                long _reportId = 0;
                long.TryParse(_rn, out _reportId);



                Patient _PatientInfo = new PatientService().GetDiagPatientById(_PatientId);
                
               // Patient _PatientInfo = new PatientService().GetPatientByReportPrefixAndId(_prefix, _reportId);  // new PatientService().GetPatientByBillNo(_billNo);

                //if (_PatientInfo == null)
                //{

                //    long _billNo = 0;
                //    long.TryParse(txtBillNo.Text, out _billNo);

                //    _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

                //}

                string _patientdemographicadata = string.Empty;

                if (_PatientInfo == null)
                {
                    MessageBox.Show("Patient not found.", "HERP");
                    txtBillNo.Tag = null;
                    return;
                }


                string _cabinNo = string.Empty;
                if (_PatientInfo.AdmissionNo > 0)
                {

                    HpPatientAccomodationInfo _accomInfo = new HpPatientAccomodationInfo();
                    HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientInfoById(_PatientInfo.AdmissionNo);

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
                        _cabinNo= _cabin.CabinNo;
                    }
                    else
                    {
                        txtCabin.Text = "N/A";
                        _cabinNo = "";
                    }

                }
                else
                {
                    txtCabin.Text = "";
                    _cabinNo = "";
                }


                txtBillNo.Tag = _PatientInfo;
                txtRegistrationNo.Text = _PatientInfo.RegNo.ToString();
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_PatientInfo.RegNo);
                if (_record != null)
                {
                    txtName.Text = _record.FullName;
                    _patientdemographicadata = getPatientDemographicData(_patientdemographicadata,_record.FullName);
                    txtName.Tag = "";
                    string _ageStr = Utility.GetConcatenatedAge(_record.AgeYear, _record.AgeMonth, _record.AgeDay);
                    txtAge.Text = _ageStr;
                    _patientdemographicadata = getPatientDemographicData(_patientdemographicadata, _ageStr);
                    txtSex.Text = _record.Sex;
                    _patientdemographicadata = getPatientDemographicData(_patientdemographicadata, _record.Sex);
                    if (_PatientInfo.AdmissionNo > 0)
                    {
                        txtMobile.Text = _record.CPMobile;
                        _patientdemographicadata = getPatientDemographicData(_patientdemographicadata, _record.CPMobile);
                    }
                    else
                    {
                        txtMobile.Text = _record.MobileNo;
                        _patientdemographicadata = getPatientDemographicData(_patientdemographicadata, _record.MobileNo);
                    }

                    txtSex.Tag = _record;

                    if(!string.IsNullOrEmpty(_cabinNo))
                         _patientdemographicadata = getPatientDemographicData(_patientdemographicadata, "Cabin No: "+ _cabinNo);
                }
                txtDailyId.Text = _PatientInfo.DailyId.ToString();
                txtDailyId.Tag = _PatientInfo.ReportIdPrefix + _PatientInfo.ReportId.ToString();
                Doctor _doc = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                txtRefdBy.Text = _doc.Name;
                txtRefdBy.Tag = _doc;
                lblRefdby.Text= _doc.Name;
                dtpEntry.Value = _PatientInfo.EntryDate;
                lblReceiveTime.Text = _PatientInfo.EntryTime;
                lblPatientInformation.Text = _patientdemographicadata;

              
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
                    parentNode.Tag = dr["ReportTypeId"].ToString() + "_" + "pNode"; //Parent Node
                   await PopulateTreeView(_PatientInfo.PatientId, Convert.ToInt32(dr["ReportTypeId"]), parentNode);
                }

                TV.ExpandAll();
                IsTreePopulated = true;
                TV.Focus();



            }



            //if (e.KeyChar == (char)Keys.Enter)
            //{

            //    this.gvTestsDetails.DataSource = null;
            //    this.gvTestsDetails.Rows.Clear();
            //    _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

              

            //    LoadResultWithPatientInfo(txtBillNo.Text);

            //}
        }

        private string getPatientDemographicData(string _dd, string appendableInfo)
        {
            string _appendedStr = string.Empty;
            if (string.IsNullOrEmpty(_dd) && !string.IsNullOrEmpty(appendableInfo)) 
            {
                _appendedStr = appendableInfo;
                return _appendedStr;
            }else if(!string.IsNullOrEmpty(_dd) && !string.IsNullOrEmpty(appendableInfo))
            {
                _appendedStr = _dd + ", " + appendableInfo;

            }else if(!string.IsNullOrEmpty(_dd) && string.IsNullOrEmpty(appendableInfo))
            {
                _appendedStr = _dd;
            }

            return _appendedStr;
        }

        private async Task<bool> PopulateTreeView(long parentId, int ReportTypeId, TreeNode parentNode)
        {
            DataTable dtchildc = await new ReportService().GetPathologicalTestsByReportType(parentId, ReportTypeId);//new ReportService().GetPathologicalTestsByGroup(Convert.ToInt32(txtRegNo.Text), groupId);

            TreeNode childNode;
            foreach (DataRow dr in dtchildc.Rows)
            {
                string status = string.Empty;
                if (parentNode == null)
                {
                    if (dr["ReportStatus"].ToString() == "RP")
                        status = "Report Print";
                    if (dr["ReportStatus"].ToString() == "NE")
                        status = "New Entry";


                    childNode = TV.Nodes.Add(dr["TestName"].ToString() + "->" + status);
                    childNode.Tag = dr["TestId"];
                }
                else
                {
                    if (dr["ReportStatus"].ToString() == "RP")
                        status = "Report Print";
                    if (dr["ReportStatus"].ToString() == "NE")
                        status = "New Entry";
                    childNode = parentNode.Nodes.Add(dr["TestName"].ToString() + "->" + status);
                    childNode.Tag = dr["TestId"];
                }

            }

            return await Task.FromResult(true);
        }


        private void LoadResultWithPatientInfo(string _patientId)
        {

            int _idLength = _patientId.Length;

            string _prefix = _patientId.Slice(0, 1);
            string _rn = _patientId.Slice(1, _idLength);

            long _reportId = 0;
            long.TryParse(_rn, out _reportId);

            //long _billNo = 0;
            //long.TryParse(txtBillNo.Text, out _billNo);
            Patient _PatientInfo = new PatientService().GetPatientByReportPrefixAndId(_prefix, _reportId);  // new PatientService().GetPatientByBillNo(_billNo);
            if (_PatientInfo == null) return;


            if (_PatientInfo.AdmissionNo > 0)
            {
                HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNoAny(_PatientInfo.AdmissionNo);
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
                        txtCabin.Text = _cabin.CabinNo;
                    }
                    else
                    {
                        txtCabin.Text = "N/A";
                    }
                }

            }
            else
            {
                txtCabin.Text = "";
            }

            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");
                txtBillNo.Tag = null;
            }
            else
            {
                txtBillNo.Tag = _PatientInfo;
                txtRegistrationNo.Text = _PatientInfo.RegNo.ToString();
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_PatientInfo.RegNo);
                if (_record != null)
                {
                    txtName.Text = _record.FullName;
                    txtAge.Text = Utility.GetConcatenatedAge(_record.AgeYear, _record.AgeMonth, _record.AgeDay);
                    txtSex.Text = _record.Sex;
                    if (_PatientInfo.AdmissionNo > 0)
                    {
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

            }


            LoadTestItems(_patientId);


        }

        private void LoadTestItems(string _patientId)
        {
            List<VMReportDefination> _reportItems = new ReportService().GetLISReportDetails(_patientId).ToList();

             FillTestGrid(_reportItems);
        }

        private void FillTestGrid(List<VMReportDefination> _rItems)
        {
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            foreach (VMReportDefination item in _rItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;

                string _testName = item.TestName.ToLower().TrimEnd() ;

                if (_testName == "urine r/e" || _testName == "stool r/e")
                {
                    row.CreateCells(gvTestsDetails, item.TestTitle, item.NormalValue, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId);
                }
                else
                {
                    if(item.TestDetailId == 1053 || item.TestDetailId == 1066)
                    {
                        float _val = 0;

                        float.TryParse(item.Value, out _val);

                        _val = _val * 1000;

                      
                            string _valStr = _val.ToString();
                            string _nvalStr = string.Empty;
                            if (_valStr.Length == 4) _nvalStr = _valStr.Insert(1, ",");
                            if (_valStr.Length == 5) _nvalStr = _valStr.Insert(2, ",");
                            if (_valStr.Length >= 6) {
                            _nvalStr = _valStr.Insert(1, ",");
                            _nvalStr = _nvalStr.Insert(4, ",");
                           } 


                        row.CreateCells(gvTestsDetails, item.TestTitle, _nvalStr, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId, item.DefaultValue);
                    }
                    else
                    {
                        string _result = item.Value;
                        if (_result.Length == 1) _result = "0" + _result;

                        row.CreateCells(gvTestsDetails, item.TestTitle, _result, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId, item.DefaultValue);

                    }
                    
                }

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
        }

        private IList<VMReportDefination> _SelectedTestItemsForPathologyReport;
        private void frmPathologyReportLIS_Load(object sender, EventArgs e)
        {
            IsComboLoaded = false;


            ctrlTemplateSearch.Location = new Point(txtTemplate.Location.X, txtTemplate.Location.Y + txtTemplate.Height);
            ctrlTemplateSearch.ItemSelected += ctrlTemplateSearch_ItemSelected;


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

            LoadPahologicalMachines();

            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            lblPreparedBy.Text = MainForm.LoggedinUser.Name;
            lblPreparedBy2.Text = MainForm.LoggedinUser.Name;
            lblPrepareDateTime2.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");


            IList<TemplateType> t_type = new TemplateService().GetMasterTemplateCategories().ToList(); //List<TemplateType>();
            t_type = t_type.Where(x => x.Name == "Path").ToList();
            //t_type.Insert(0, new TemplateType()
            //{
            //    Id = 0,
            //    Name = "Select Type"
            //});

            cmbType.DataSource = t_type;
            cmbType.DisplayMember = "Name";


            IsComboLoaded = true;
        }

        private void LoadPahologicalMachines()
        {
            List<PathologicalMachine> _PathMachines = new TestService().GetAllPathologicalMachines();
            _PathMachines.Insert(0, new PathologicalMachine()
            {
                Id = 0,
                MachineName = " "
            });

            cmbMachine.DataSource = _PathMachines;
            cmbMachine.DisplayMember = "MachineName";
            cmbMachine.ValueMember = "Id";
        }

        private void ctrlTemplateSearch_ItemSelected(UI.Controls.SearchResultListControl<Template> sender, Template item)
        {
            txtTemplate.Text = item.TemplateName;
            txtTemplate.Tag = item.Id;
            txtTemplate.Focus();
            sender.Visible = false;
        }


        private void CmdSaveAndPrintReport_Click(object sender, EventArgs e)
        {
            PathologyReport _report = new PathologyReport();

            if (txtBillNo.Tag != null)
            {
                if (cmbPathologist.Tag == null)
                {
                    MessageBox.Show("Pathologist not selected.", "HERP");
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
                        MessageBox.Show("DC Value :" + _dcValue.ToString() + ". It should be 100. Plz. check and try again.");
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

                }
                catch (Exception ex)
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

        }

        private int GetDCValue()
        {
            int _dc = 0;
            int _dcTotal = 0;
            foreach (DataGridViewRow row in gvTestsDetails.Rows)
            {
                VMReportDefination selectedTests = row.Tag as VMReportDefination;

                if (selectedTests.TestTitle == "Neutrophils" || selectedTests.TestTitle == "Lymphocytes" || selectedTests.TestTitle == "Monocytes" ||
                    selectedTests.TestTitle == "Eosinophils" || selectedTests.TestTitle == "Basophils")
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

        private void SaveAndPrintReport(PathologyReport _report)
        {
            bool isDynamicReport = false;
            string _staticvalues = string.Empty;
            string _staticfields = string.Empty;
            bool IsStaticReport = false;
            string staticReportType = string.Empty;

            Patient _patient = (Patient)txtBillNo.Tag;


            if (_report == null || _report.Id == 0)
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
                var Lisresult = row.Cells["MValue"].Value;

                string _selectTestName = selectedTests.TestName.ToLower();

                if (_selectTestName.TrimEnd() == "urine r/e" || _selectTestName.TrimEnd() == "stool r/e" || _selectTestName.TrimEnd() == "urine analysis")
                {


                    // 
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

                    if (Lisresult != null)
                    {
                        _reportdetail.MachineResult = Lisresult.ToString();
                    }
                    else
                    {
                        _reportdetail.MachineResult = "";
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
                if (staticReportType.TrimEnd() == "urine r/e" || staticReportType.TrimEnd() == "urine analysis")
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
            _urinereport.DataDefinition.FormulaFields[2].Text = "'" + _Patient.PatientId.ToString() + "'";
            _urinereport.DataDefinition.FormulaFields[1].Text = "'" + txtName.Text + "'";
            _urinereport.DataDefinition.FormulaFields[0].Text = "'" + txtRefdBy.Text.Replace('\'', '\"') + "'";
            _urinereport.DataDefinition.FormulaFields[6].Text = "'" + dtpEntry.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[5].Text = "'" + dtpDelivery.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[4].Text = "'" + txtAge.Text + "'";
            _urinereport.DataDefinition.FormulaFields[3].Text = "'" + txtSex.Text + "'";
            _urinereport.DataDefinition.FormulaFields[17].Text = "'" + txtDailyId.Text + "'";
            _urinereport.DataDefinition.FormulaFields[18].Text = "'" + txtCabin.Text + "'";

            _urinereport.SetParameterValue("printedby", lblPreparedBy.Text);

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
                _urinereport.SetParameterValue("ReportId", "(" + txtDailyId.Tag.ToString() + ")");

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
            _urinereport.DataDefinition.FormulaFields[2].Text = "'" + _Patient.PatientId.ToString() + "'";
            _urinereport.DataDefinition.FormulaFields[1].Text = "'" + txtName.Text + "'";
            _urinereport.DataDefinition.FormulaFields[0].Text = "'" + txtRefdBy.Text.Replace('\'', '\"') + "'";
            _urinereport.DataDefinition.FormulaFields[6].Text = "'" + dtpEntry.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[5].Text = "'" + dtpDelivery.Value.ToString(customFmts) + "'";
            _urinereport.DataDefinition.FormulaFields[4].Text = "'" + txtAge.Text + "'";
            _urinereport.DataDefinition.FormulaFields[3].Text = "'" + txtSex.Text + "'";
            _urinereport.DataDefinition.FormulaFields[17].Text = "'" + txtCabin.Text + "'";
            _urinereport.DataDefinition.FormulaFields[18].Text = "'" + txtDailyId.Text + "'";

            _urinereport.SetParameterValue("printedby", lblPreparedBy.Text);

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
                _urinereport.SetParameterValue("ReportId", "(" + txtDailyId.Tag.ToString() + ")");

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



        private async void ViewReport(long reportId)
        {

            string _identity5 = string.Empty;
            string _identity3 = string.Empty;
            string _comments = string.Empty;

            if (!String.IsNullOrEmpty(txtAnyComments.Text))
            {
                _comments = txtAnyComments.Text;
            }


            VMReportDefination _rdef = _SelectedTestItemsForPathologyReport.FirstOrDefault();
            if (_rdef != null)
            {
                if(_rdef.TestId==155 || _rdef.TestId == 1979)
                {
                    int totalDc = GetDCValue();
                    if (totalDc < 100)
                    {
                        MessageBox.Show("DC value should be 100. Plz. check and try again."); return;
                    }
                }
            }

            Patient _Patient = (Patient)txtBillNo.Tag;

            DataSet dsReports = new DataSet();
            dsReports = new ReportService().GetPathologyReportData(_SelectedTestItemsForPathologyReport);  //new ReportService().GetPathologicalTestDataByReportId(reportId);

            //da.Fill(dsReports, "dtPathologicalReportData");




            RptPathologyGeneralFormat _pathreport = new RptPathologyGeneralFormat();

            _pathreport.SetDataSource(dsReports.Tables[0]);




            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pathreport.DataDefinition.FormulaFields[0].Text = "'" + _Patient.PatientId.ToString() + "'";
            _pathreport.DataDefinition.FormulaFields[1].Text = "'" + txtName.Text + "'";
            _pathreport.DataDefinition.FormulaFields[2].Text = "'" + txtRefdBy.Text.Replace('\'', '\"') + "'";
            _pathreport.DataDefinition.FormulaFields[3].Text = "'" + dtpEntry.Value.ToString(customFmts) + "'";
            _pathreport.DataDefinition.FormulaFields[4].Text = "'" + dtpDelivery.Value.ToString(customFmts) + "'";
            _pathreport.DataDefinition.FormulaFields[5].Text = "'" + txtAge.Text + "'";
            _pathreport.DataDefinition.FormulaFields[6].Text = "'" + txtSex.Text + "'";
            _pathreport.DataDefinition.FormulaFields[21].Text = "'" + txtMobile.Text + "'";

            if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            {
                _pathreport.DataDefinition.FormulaFields[17].Text = "'" + "Cabin: " + txtCabin.Text + "'";
            }
            else
            {
                _pathreport.DataDefinition.FormulaFields[17].Text = "'" + "" + "'";
            }
            _pathreport.DataDefinition.FormulaFields[18].Text = "'" + txtDailyId.Text + "'";
            _pathreport.DataDefinition.FormulaFields[19].Text = "'" + lblPreparedBy.Text + "'";

            if (!String.IsNullOrEmpty(cmbMachine.Text))
            {
                _pathreport.SetParameterValue("MachineName", cmbMachine.Text);
            }
            else
            {
                _pathreport.SetParameterValue("MachineName", "");

            }

            _pathreport.SetParameterValue("ReportTypes", txtReportType.Text);
            _pathreport.SetParameterValue("BillNoString", txtBillNo.Text);
            _pathreport.SetParameterValue("RegNoString", txtRegistrationNo.Text);

            if (txtDailyId.Tag != null)
            {
                _pathreport.SetParameterValue("ReportSrl", "(" + txtDailyId.Tag.ToString() + ")");
            }
            else
            {
                _pathreport.SetParameterValue("ReportSrl", "");
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

            _pathreport.DataDefinition.FormulaFields[22].Text = "'" + txtName.Tag.ToString() + "'";

            if (!String.IsNullOrEmpty(_comments))
            {
                _pathreport.SetParameterValue("CommentsTitle", "Comments : ");

            }
            else
            {
                _pathreport.SetParameterValue("CommentsTitle", "");
            }

            _pathreport.SetParameterValue("AnyComments", _comments);

            //string fileNameWithPath = GeneratePDF(reportId, txtBillNo.Tag as Patient, txtSex.Tag as RegRecord, _pathreport);

            //if (!string.IsNullOrEmpty(fileNameWithPath))
            //{
            //    this.SendToMail(txtBillNo.Tag as Patient, txtSex.Tag as RegRecord,fileNameWithPath);
            //}
            

            rv.crviewer.ReportSource = _pathreport;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        public void SendToMail(Patient patient, RegRecord regRecord,string fileNameWithPath)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.UseDefaultCredentials = false;
                mail.From = new MailAddress("emslfiles2020@gmail.com");
                mail.To.Add("faruqemslbd@gmail.com");
                mail.Subject = "Test Mail - 1";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(fileNameWithPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("engrfaruqahamad@gmail.com", "password");
                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private string GeneratePDF(long reportId, Patient patient, RegRecord regRecord, RptPathologyGeneralFormat pathreport)
        {
            try
            {
                string rootPath = (Path.GetDirectoryName(Application.StartupPath).Replace(@"debug\", string.Empty)).Replace(@"bin", string.Empty);
                string fileNameWithPath = rootPath + @"ExportedReports\\"+ DateTime.Now.Ticks.ToString() +"_"+reportId.ToString()+".pdf";
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = fileNameWithPath;
                CrExportOptions = pathreport.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }

                pathreport.Export();

                return fileNameWithPath;
            }
            catch (Exception ex)
            {
                return "";

                //MessageBox.Show(ex.ToString());
            }

          
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
            // txtCabin.Text = "";
            txtReportSerial.Tag = null;
            txtReportType.Tag = "";

            tabControl1.Tag = null;
            tabPage1.Tag = null;
            IsPathMachineLoaded = false;

            LoadPahologicalMachines();

            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
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

                isLabMachineLoadedFromTv = true;

                List<VMReportDefination> _testList = new List<VMReportDefination>();

                if (arr.Length > 1)  // By Report Type
                {

                    LoadTestResultByReportType(arr[0], txtBillNo.Text);
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

                    LoadTestResultByTestId(_testId, txtBillNo.Text);

                }
            }
        }

        private async void LoadTestResultByTestId(int _testId, string _reportId)
        {

            // _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            List<VMReportDefination> _testList = new List<VMReportDefination>();



            TestItem _testItem = new TestService().GetTestItemById(_testId);
            txtName.Tag = _testItem.Specimen;

            if (_testItem == null) return;


            // Set Flag for DC Value Checked

            if (_testItem.TestId == 155 || _testItem.TestId == 1979)
            {
                txtReportType.Tag = "DCChk";
            }


            ReportType _reportType = new TestService().GetReportTypesById(_testItem.ReportTypeId);
            txtReportType.Text = _reportType.Report_Type;



            if (!String.IsNullOrEmpty(_reportType.TestCarriedOutBy))
            {
                cmbMachine.Text = _reportType.TestCarriedOutBy;
            }
            else
            {
                cmbMachine.Text = "";
            }

            Patient _Patient = (Patient)txtBillNo.Tag;


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

            lblReportTypeId.Text = _rTypeId.ToString();
            lblPriorityId.Text = _priorityId.ToString();

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
                                 IsNewResult=false,
                                 MachineResult = _dr["LisValue"].ToString(),
                                 MachineCode = _dr["InstrumentName"].ToString(),
                                 ResultUnit = _dr["ResultUnit"].ToString(),
                                 ResultOption= _dr["ResultOption"].ToString(),
                                 TestDetailId = Convert.ToInt32(_dr["TestDetailId"]),
                                 TestId = Convert.ToInt32(_dr["TestId"]),
                                 ReportTypeId = Convert.ToInt32(_dr["ReportTypeId"]),
                                 GroupId = Convert.ToInt32(_dr["GroupId"]),
                                 TestTitle_FontBold = Convert.ToInt32(_dr["TestTitle_FontBold"]),
                                 NormalValue = _dr["NormalResult"].ToString(),
                                // DefaultValue = Convert.ToString(_dr["DefaultValue"]),


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


                DataTable _selectedTest = await new ReportService().GetTestDetailsForReport(_Patient.PatientId, _testItem.TestId, _rTypeId,_priorityId);

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
                                     GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"]),
                                     DefaultValue = Convert.ToString(_dr["DefaultValue"])

                                 }).ToList();

                           }

                new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                FillTestGrid();
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
                row.CreateCells(gvTestsDetails, item.TestTitle, item.TestResult, item.MachineResult, item.ResultUnit, item.NormalValue, item.DefaultValue);

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

        private TestItem GetTestById(int _testId)
        {
            return new TestService().GetTestItemById(_testId);
        }

        private async void LoadTestResultByReportType(string _reportTypeId, string _reportId)
        {
            //C5489 Immunology LIS Result should be Resolved.

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
               // ReportType _reportType = new TestService().GetReportTypesById(reportTypeId);
                txtReportType.Text = _rType.Report_Type;

                DataTable dtchildc = await new ReportService().GetPathologicalTestsByReportType(_Patient.PatientId, reportTypeId);
                foreach (DataRow dr in dtchildc.Rows)
                {
                   _testList = new List<VMReportDefination>();

                    TestItem _testItem = new TestService().GetTestItemById(Convert.ToInt32(dr["TestId"]));

                    txtName.Tag = _testItem.Specimen;

                if (_testItem == null) return;

                    if (_testItem.TestId == 155 || _testItem.TestId == 1979)
                    {
                        txtReportType.Tag = "DCChk";
                    }
                    else
                    {
                        txtReportType.Tag = "";
                    }
                int _rTypeId = 0;
                int _priorityId = 100;

                List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId, _reportId);
                if(priorityObj != null && priorityObj.Count > 0)
                {
                    foreach(var item in priorityObj)
                    {
                        _rTypeId = item.ReportTypeId;
                        if(_priorityId> item.Priority)
                           _priorityId = item.Priority;

                    }
                }

                if (_priorityId == 100) _priorityId = 0;

                lblReportTypeId.Text = _rTypeId.ToString();
                lblPriorityId.Text = _priorityId.ToString();  // If same sample runs on different machine


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
                                         GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"]),
                                        // DefaultValue = Convert.ToString(_dr["DefaultValue"])

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

                    DataTable _selectedTest = await new ReportService().GetTestDetailsForReport(_Patient.PatientId, _testItem.TestId, _rTypeId,_priorityId);

                    if (_selectedTest.Rows.Count > 0)
                    {


                        _testList = (from DataRow _dr in _selectedTest.Rows
                                     select new VMReportDefination()
                                     {
                                         PatientId = Convert.ToInt64(_dr["PatientId"]),
                                         ReportId = 0,
                                         ReportDoctor=0,
                                         ReportTechnologist=0,
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
                                         GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"]),
                                         DefaultValue = Convert.ToString(_dr["DefaultValue"])

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
                    LoadReportConsultants(_rdef.ReportDoctor);
                    LoadReportTechnologists(_rdef.ReportTechnologist);
                }
            }

            FillTestGrid();

               
            //}
        }

        private void ViewLISDataForReport(List<TEMPLISPatientRecord> _lisRecords)
        {
           // throw new NotImplementedException();
        }

        private async void LoadLISTestResultByReportTypeAndDevice(int reportTypeId, string _deviceCode, int priority)
        {
            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            List<VMReportDefination> _testList = new List<VMReportDefination>();


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
                }
                else
                {
                    txtReportType.Tag = "";
                }

                int _rTypeId = 0;
                int _priorityId = 100;

                List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId, txtBillNo.Text);
                if (priorityObj != null && priorityObj.Count > 0)
                {
                    foreach (var item in priorityObj)
                    {
                        _rTypeId = item.ReportTypeId;
                        if (_priorityId > item.Priority)
                            _priorityId = item.Priority;

                    }
                }

                lblReportTypeId.Text = _rTypeId.ToString();
                lblPriorityId.Text = _priorityId.ToString();

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
                                     GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"]),
                                     DefaultValue = Convert.ToString(_dr["DefaultValue"])

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

                    DataTable _selectedTest = await new ReportService().GetTestDetailsForReport(_Patient.PatientId, _testItem.TestId, _rTypeId,_priorityId);

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
                                         MachineCode = _dr["InstrumentName"].ToString(),
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
                                         GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"]),
                                         DefaultValue = Convert.ToString(_dr["DefaultValue"])

                                     }).ToList();
                        
                    }
                }

            }


            if (_testList.Count == 0) return;

            new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

            FillTestGrid();
        }


        private void LoadPathologicalMachines(int reportTypeId, string machineCode)
        {
            IsPathMachineLoaded = false;

           
            cmbMachine.DataSource = null;

            List<PathologicalMachine> _pathMachines = new LabService().GetPathologyMachineByReportTypeId(reportTypeId);
            _pathMachines.Insert(0, new PathologicalMachine()
            {
                Id = 0,
                MachineName = " "
            });

            cmbMachine.DataSource = _pathMachines;
            cmbMachine.DisplayMember = "MachineName";
            cmbMachine.ValueMember = "Id";

            PathologicalMachine _machine = _pathMachines.Where(q => q.MachineShortName == machineCode).FirstOrDefault();
            if (_machine != null)
            {
                cmbMachine.Text = _machine.MachineName;
            }

            IsPathMachineLoaded = true;
        }

        private TEMPLISResultRecord GetMachineResult(long _PatientRecordId, long _PatientId, int ReportDefId)
        {
            TEMPLISResultRecord _lisResultObj = new LabService().GetLISResultRecord(_PatientRecordId,_PatientId, ReportDefId);

            TEMPLISResultRecord _retobj = new TEMPLISResultRecord();

            if (_lisResultObj == null)
            {
                _retobj.PatientRecordId = 0;
                _retobj.Value = "";
                _retobj.ReportDefId = 0;

                return _retobj;
            }
            else
            {
                return _lisResultObj;
            }
           

           
        }

        private void FillTestGrid()
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
                       // _testResult = "";
                        _testResult = item.DefaultValue;
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
                       // _testResult = item.TestResult;
                        _testResult = item.TestResult;
                    }
                }

                if (item.TestName.ToLower().TrimEnd() == "urine r/e" || item.TestName.ToLower() == "stool r/e" || item.TestName.ToLower() == "urine analysis")
                {
                    string _result = item.MachineResult;
                    if (string.IsNullOrEmpty(_result))
                    {
                        _result = item.NormalValue;
                    }

                    row.CreateCells(gvTestsDetails, item.TestTitle, _result, item.MachineResult, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId, item.DefaultValue);
                }
                else
                {
                    row.CreateCells(gvTestsDetails, item.TestTitle, _testResult, item.MachineResult, item.ResultUnit, item.NormalValue, item.GroupTitle, item.TestDetailId, item.DefaultValue);
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

            if (mCodes.Length > 0)
            {
                List<PathologicalMachine> _PathMachines = new TestService().GetAllPathologicalMachines();

                _PathMachines = _PathMachines.Where(x => mCodes.Contains(x.MachineShortName)).ToList();

                if (_PathMachines.Count > 0)
                {
                    cmbMachine.Text = _PathMachines.FirstOrDefault().MachineName;
                }


            }
        }

        private void txtBillNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int _idLength = txtBillNo2.Text.Length;
                string _prefix = txtBillNo2.Text.Slice(0, 1);
                string _rn = txtBillNo2.Text.Slice(1, _idLength);

                long _reportId = 0;
                long.TryParse(_rn, out _reportId);

                long _patintId = 0;
                long.TryParse(txtBillNo2.Text, out _patintId);


                // long _billNo = 0;
                // long.TryParse(txtBillNo2.Text,out _billNo);
               // Patient _patient = new PatientService().GetPatientByReportPrefixAndId(_prefix, _reportId); //new PatientService().GetPatientByBillNo(_billNo);

                Patient _patient = new PatientService().GetPatientByIdNo(_patintId);

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
                        HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientInfoById(_patient.AdmissionNo);
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

                    this.ShowReportsOnListView(((Patient)txtBillNo2.Tag).PatientId, DateTimePicker.Value);
                }
                else
                {
                    MessageBox.Show("Patient not found.", "HERP");
                }
            }

        }

        private void ShowReportsOnListView(long patientId, DateTime _datetime)
        {
            DataTable dt = new TemplateService().GetReports(null, patientId, _datetime, "Path");

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

            if (TV2.SelectedNode.Tag != null)
                txtReportType.Text = ((ViewModelReportTests)TV2.SelectedNode.Tag).ReportType;

        }

        private void txtTemplate_KeyPress(object sender, KeyPressEventArgs e)
        {
            ReportTechnologist _technologist = new ReportTechnologist();

            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlTemplateSearch.Visible = true;
                ReportConsultant  consultants = cmbConsultant.Tag  as ReportConsultant;
                //ctrlTemplateSearch.LoadDataByType(cmbType.Text);
                ctrlTemplateSearch.LoadDataByType(consultants.RCId.ToString());
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

                        Patient _P = (Patient)txtBillNo2.Tag;

                        MsWordReport newReport = new MsWordReport();
                        newReport.RegNo = _P.PatientId.ToString();
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
            Invoke(new _UpdateRepotListOnWordFileClose(ShowReportsOnListView), new object[] { 0, Convert.ToDateTime(DateTimePicker.Value) });
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
            template.ReplaceText("Reg_No", _Patient.PatientId.ToString());
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
                //template.ReplaceText("Tech_2", _technologist.Identity2);
                //template.ReplaceText("Tech_3", _technologist.Identity3);
                //template.ReplaceText("Tech_4", "");

            }

            return template;
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

        private void ctrlTemplateSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTemplate.Focus();
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

        private void gvTestsDetails_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            VMReportDefination _SelectedItem = (VMReportDefination)e.Row.Tag;
            _SelectedTestItemsForPathologyReport.Remove(e.Row.Tag as VMReportDefination);
        }

        private void gvTestsDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                int lastRowOfGv = gvTestsDetails.Rows.Count - 1;

                if (gvTestsDetails.CurrentRow.Index == lastRowOfGv)
                {
                    PathologyReport _report = new PathologyReport();

                    if (txtBillNo.Tag != null)
                    {
                        if (cmbPathologist.Tag == null)
                        {
                            MessageBox.Show("Pathologist not selected.", "HERP");
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
                                MessageBox.Show("DC Value :" + _dcValue.ToString() + ". It should be 100. Plz. check and try again.");
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

                        }
                        catch (Exception ex)
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
                }
                else
                {
                    gvTestsDetails.Focus();
                }

            }
        }

        private void cmbMachine_Click(object sender, EventArgs e)
        {
            isLabMachineLoadedFromTv = true;
        }

        private void cmbMachine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int _reportTypeId = 0;
                int _priorityId = 0;
                int.TryParse(lblReportTypeId.Text, out _reportTypeId);
                int.TryParse(lblPriorityId.Text, out _priorityId);
               
                    // tabControl1.Tag contains ReportTypeId



                    PathologicalMachine _machine = (PathologicalMachine)cmbMachine.SelectedItem;
                    if (IsSampleRunOnThisMachine(_machine, txtBillNo.Text))
                    {
                        LoadTestResultByReportTypeAndMachine(txtBillNo.Text,_reportTypeId, _machine.MachineName, _machine.Priority);
                    }
                    else
                    {
                        MessageBox.Show("No result found this lab machine");
                    }

                
            }
        }

        private bool IsSampleRunOnThisMachine(PathologicalMachine machine, string reportId)
        {
            TEMPLISPatientRecord _pRecord = new ReportService().GetTempLISPatientRecord(reportId, machine.MachineShortName);
            if (_pRecord != null)
            {
               return true;
            }
            else
            {
                return false;
            }
        }

        private async void LoadTestResultByReportTypeAndMachine(string reportId, int reportTypeId, string machineName, int priority)
        {
            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
            gvTestsDetails.SuspendLayout();
            gvTestsDetails.Rows.Clear();
            List<VMReportDefination> _testList = new List<VMReportDefination>();



            txtReportType.Tag = "";

           


            ReportType _rType = new TestService().GetReportTypesById(reportTypeId);

            //if (!String.IsNullOrEmpty(_rType.TestCarriedOutBy))
            //{
            //    cmbMachine.Text = _rType.TestCarriedOutBy;
            //}
            //else
            //{
            //    cmbMachine.Text = "";
            //}



            Patient _Patient = (Patient)txtBillNo.Tag;
            // ReportType _reportType = new TestService().GetReportTypesById(reportTypeId);

            if (_rType != null)
            {
                txtReportType.Text = _rType.Report_Type;
            }
            else
            {
                txtReportType.Text = "";
            }

            DataTable dtchildc = await new ReportService().GetPathologicalTestsByReportType(_Patient.PatientId, reportTypeId);
            foreach (DataRow dr in dtchildc.Rows)
            {
                _testList = new List<VMReportDefination>();

                TestItem _testItem = new TestService().GetTestItemById(Convert.ToInt32(dr["TestId"]));

                txtName.Tag = _testItem.Specimen;

                if (_testItem == null) return;

                if (_testItem.TestId == 155 || _testItem.TestId == 1979)
                {
                    txtReportType.Tag = "DCChk";
                }
                else
                {
                    txtReportType.Tag = "";
                }
                //int _rTypeId = 0;
                //int _priorityId = 100;

                //List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId, reportId);
                //if (priorityObj != null && priorityObj.Count > 0)
                //{
                //    foreach (var item in priorityObj)
                //    {
                //        _rTypeId = item.ReportTypeId;
                //        if (_priorityId > item.Priority)
                //            _priorityId = item.Priority;

                //    }
                //}

                lblReportTypeId.Text = reportTypeId.ToString();
                lblPriorityId.Text = priority.ToString();  // If same sample runs on different machine


                DataTable _dt = await new ReportService().GetPreviousReportTestDetailsByPatientByTestId(_Patient.PatientId, _testItem.TestId, reportTypeId, priority);  // If already report done
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
                                     GroupReportOrder = Convert.ToInt32(_dr["GroupReportOrder"]),
                                     DefaultValue = Convert.ToString(_dr["DefaultValue"])

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

                    DataTable _selectedTest = await new ReportService().GetTestDetailsForReport(_Patient.PatientId, _testItem.TestId, reportTypeId, priority);

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
                    LoadReportConsultants(_rdef.ReportDoctor);
                    LoadReportTechnologists(_rdef.ReportTechnologist);
                }
            }

            FillTestGrid();

        }

        object item;
        DataGridViewComboBoxCell combo;
        bool bValidating;
        int colIndex = 0;
        int rowIndex = 0;

        private void gvTestsDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvTestsDetails.Columns["TestResult"].Index)
            {
                if (e.RowIndex < 0) return;
                VMReportDefination rdef = gvTestsDetails.Rows[e.RowIndex].Tag as VMReportDefination;
                if (combo == null)
                {
                    combo = new DataGridViewComboBoxCell();
                    //these data will be displayed in comboBox:
                    if (rdef != null && !string.IsNullOrEmpty(rdef.ResultOption))
                    {
                        string[] data = rdef.ResultOption.Split(',');
                        combo.Items.AddRange(data);
                        this.gvTestsDetails[e.ColumnIndex, e.RowIndex] = combo;
                        colIndex = e.ColumnIndex;
                        rowIndex = e.RowIndex;
                    }

                    bValidating = true;

                }
            }
        }

        private void gvTestsDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            item = cb.Text;
        }

        private void gvTestsDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == gvTestsDetails.Columns["TestResult"].Index && e.RowIndex > -1)
            {
                if (gvTestsDetails.Rows[e.RowIndex].IsNewRow) { return; }

                if (bValidating)
                {
                    string selectedItem = e.FormattedValue.ToString();
                    if (String.IsNullOrEmpty(selectedItem))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        bValidating = false;//finally set to false!!
                        combo = null;
                        if (item != null && !string.IsNullOrEmpty(item.ToString()))
                        {
                            gvTestsDetails[colIndex, rowIndex] = new DataGridViewTextBoxCell();

                            gvTestsDetails[colIndex, rowIndex].Value = item;
                        }
                    }
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBillNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
