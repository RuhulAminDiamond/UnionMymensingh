using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Common.Utils;
using HDMS.Service.Doctors;
using HDMS.Model.ViewModel;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Model.Rx;
using HDMS.Service.Rx;
using HDMS.Model.Diagnostic.VM;
using System.Diagnostics;
using System.IO;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class RxReportControl : UserControl
    {
        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;


        public event EntryCompletedEventHandler EntryCompleted;
        public RxReportControl()
        {
            InitializeComponent();
        }


        public delegate void EntryCompletedEventHandler(object sender);
        private IList<VMReportDefination> _SelectedTestItemsForPathologyReport;
        private void RxReportControl_Load(object sender, EventArgs e)
        {
            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
        }

        private void txtRxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            long _RxId = 0;
            long.TryParse(txtRxId.Text, out _RxId);
            if (e.KeyChar == (char)Keys.Enter)
            {
                Patient _patient = new PatientService().GetPatientByRxId(_RxId);
                if (_patient != null)
                {
                   
                    txtRefdBy.Text = new DoctorService().GetDoctorById(_patient.DoctorId).Name;
                    List<PathologyReport> _PathReport = new ReportService().GetPathologyReportByPatientId(_patient.PatientId);

                    LoadListViewItem(_PathReport);
                }
            }
        }

        private void LoadListViewItem(List<PathologyReport> _pathReport)
        {
           // lvReports.Items.Clear();
            
            foreach (var item in _pathReport)
            {
                ListViewItem lvi1 = new ListViewItem();
                lvi1.Text = item.Id.ToString();
                lvi1.SubItems.Add(new ReportService().GetTestByReportId(item.Id));
               // lvReports.Items.Add(lvi1);
            }
            

        

        }

        private void lvReports_MouseDoubleClick(object sender, MouseEventArgs e)
        {
         //   string rid = lvReports.SelectedItems[0].Text;

            long _reportId = 0;
            long.TryParse("rid", out _reportId);
            DataTable dt = new ReportService().GetPreviousReportTestDetails(_reportId);

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
                             NormalValue = dr["NormalResult"].ToString(),

                         }).ToList();



            new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

            FillTestGridForPreviousReport();
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

                List<Patient> _pBills = new PatientService().GetPatientIdsByRegNo(_regNo);
                FillBillNoGrid(_pBills);
            }
        }

        private void FillBillNoGrid(List<Patient> _pBills)
        {
            dgBillIds.SuspendLayout();
            dgBillIds.Rows.Clear();
            foreach (var item in _pBills)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgBillIds, item.BillNo, item.EntryDate.ToString("dd/MM/yyyy"), item.EntryTime);

                dgBillIds.Rows.Add(row);

            }
        }

        private bool LoadRegPatientInfo(long _regNo)
        {
            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
            if (_record != null)
            {
                txtName.Text = _record.FullName;
                txtAge.Text = Utility.GetConcatenatedAge(_record.AgeYear, _record.AgeMonth, _record.AgeDay);
                txtSex.Text = _record.Sex;
                //txtRefdBy.Text = _record.MaritalStatus;
                return true;
            }

            return false;
        }

        private void dgBillIds_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgBillIds.SelectedRows.Count != 0)
            {
                _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

                DataGridViewRow row = this.dgBillIds.SelectedRows[0];
                Patient _pInfo = ((Patient)row.Tag);

                List<VWTestItem> _tItems = new PatientService().GetTestItemsByPatientId(_pInfo.PatientId);

                Doctor _d = new DoctorService().GetDoctorById(_pInfo.DoctorId);

                if (_d != null)
                {
                    txtRefdBy.Text = _d.Name;
                    txtRefdBy.Tag = _d;

                }

                FillTestGrid(_tItems);

            }
        }

        private void FillTestGrid(List<VWTestItem> _tItems)
        {
            dgTestList.SuspendLayout();
            dgTestList.Rows.Clear();
            foreach (var item in _tItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgTestList, item.TestName, item.TestId);

                dgTestList.Rows.Add(row);

            }
        }

        private async void dgTestList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgTestList.SelectedRows.Count != 0)
            {

                _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();

                DataGridViewRow row = this.dgTestList.SelectedRows[0];
                VWTestItem _pInfo = ((VWTestItem)row.Tag);

                if (_pInfo.ReportTypeId == 13 || _pInfo.ReportTypeId == 15)
                {
                    ShowReportsOnListViewMsWordFormat(_pInfo.BillNo.ToString());

                }else if(_pInfo.ReportTypeId == 33)
                {
                    ShowReportsOnListViewMsPdfFormat(_pInfo.PatientId.ToString());
                }
                else
                {

                    TestItem _testItem = new TestService().GetTestItemById(_pInfo.TestId);

                    int _rTypeId = 0;
                    int _priorityId = 100; // Higher priority for selection highest one (lower in number)

                    List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId, "");
                    if (priorityObj != null && priorityObj.Count > 0)
                    {
                        foreach (var item in priorityObj)
                        {
                            _rTypeId = item.ReportTypeId;
                            if (_priorityId > item.Priority)
                                _priorityId = item.Priority;

                        }
                    }


                    DataTable _dt = await new ReportService().GetPreviousReportTestDetailsByPatientByTestId(_pInfo.PatientId, _pInfo.TestId, _rTypeId, _priorityId);  // If already report done
                    if (_dt.Rows.Count > 0)
                    {

                        List<VMReportDefination> _testList = (from DataRow _dr in _dt.Rows
                                                              select new VMReportDefination()
                                                              {
                                                                  ReportId = Convert.ToInt64(_dr["Id"]),
                                                                  TestTitle = _dr["TestTitle"].ToString(),
                                                                  TestName = _dr["TestName"].ToString(),
                                                                  TestResult = _dr["TestResult"].ToString(),
                                                                  ResultUnit = _dr["ResultUnit"].ToString(),
                                                                  TestDetailId = Convert.ToInt32(_dr["TestDetailId"]),
                                                                  TestId = Convert.ToInt32(_dr["TestId"]),
                                                                  GroupId = Convert.ToInt32(_dr["GroupId"]),
                                                                  NormalValue = _dr["NormalResult"].ToString(),
                                                                  TestTitle_FontBold = Convert.ToInt32(_dr["TestTitle_FontBold"])

                                                              }).ToList();



                        new TestService().PopulateSelectedTestForReport(_SelectedTestItemsForPathologyReport, _testList);

                        FillTestGridForPreviousReport();
                    }
                }

            }

        }

        private void ShowReportsOnListViewMsPdfFormat(string billNo)
        {
            DataTable dt = new TemplateService().GetNonLabPdfReports(billNo);

            lvScannedReports.Items.Clear();
            lvScannedReports.SmallImageList = imgListLarge2;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string displayText = dr[1].ToString() + "-" + dr[3].ToString();
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.ToolTipText = dr[3].ToString();
                listitem.ImageIndex = 1;
                lvScannedReports.Items.Add(listitem);


            }


        }

        private void ShowReportsOnListViewMsWordFormat(string billNo)
        {
            DataTable dt = new TemplateService().GetNonLabReports(billNo);

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



            // lvReports.LargeImageList = imgListLarge;

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

            string _reportType = new ReportService().GetReportType(Ids);


            byte[] reportcontent = new TemplateService().GetPreviousReport(Ids);

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
          //  process.Exited += process_Exited_oldreport;

            process.WaitForExit();
        }

        private void KillRunningProcess()
        {
            Process[] procs = Process.GetProcessesByName("winword");

            foreach (Process proc in procs)
                proc.Kill();
        }

        private void lvScannedReports_DoubleClick(object sender, EventArgs e)
        {
            if (lvScannedReports.SelectedItems.Count == 1)
            {
                this.KillBrowserProcess();

                ListView.SelectedListViewItemCollection items = lvScannedReports.SelectedItems;

                ListViewItem lvItem = items[0];

            
                this.ViewReport(lvItem.Text);

            }
        }

        private void ViewReport(string fileName)
        {


            try
            {
                string[] Ids = fileName.Split('-');

                ReportFilePath = new TemplateService().GetNewReportFilePath();
                ReportFileNameWithPath = ReportFilePath + @"\" + DateTime.Now.Ticks.ToString() + "-" + "test" + ".pdf";


                long _billNo = 0;
                int _testId = 0;

                long.TryParse(Ids[0], out _billNo);
                int.TryParse(Ids[1], out _testId);

                byte[] _reportcontent = new ReportService().GetReportContentByRegNoAnd(_billNo, _testId);


                if (!Directory.Exists(ReportFilePath))
                {
                    Directory.CreateDirectory(@ReportFilePath);
                }

                if (File.Exists(ReportFileNameWithPath))
                {
                    File.Delete(ReportFileNameWithPath);
                }




                FileStream fsmaster = new FileStream(ReportFileNameWithPath, FileMode.OpenOrCreate);
                BinaryWriter br = new BinaryWriter(fsmaster);
                br.Write(_reportcontent);
                fsmaster.Dispose();
                br.Dispose();



                ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
                Process process = Process.Start(psi);
                //  process.EnableRaisingEvents = true;


                //process.WaitForExit();
            }
            catch (Exception ex)
            {

            }

        }

        private void KillBrowserProcess()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.MainWindowTitle != "")
                {
                    string s = process.ProcessName.ToLower();
                    if (s == "iexplore" || s == "iexplorer" || s == "chrome" || s == "firefox")
                        process.Kill();
                }
            }
        }
    }
}
