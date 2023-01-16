using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Common.Utils;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Rx;
using HDMS.Service.Rx;
using HDMS.Models.Pharmacy;
using HDMS.Windows.Forms.UI.Rx;
using HDMS.Model.Hospital;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Model.ViewModel;
using HDMS.Model.Diagnostic.VM;
using HDMS.Service.Doctors;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlTemplateIPDTestResult : UserControl
    {
        bool unlocked = true;

        public ctrlTemplateIPDTestResult()
        {
            InitializeComponent();
        }


        private IList<RxSelectedMedicineForPatient> _SelectedMedicines;
        private async void ctrlTemplateDischargePart1_Load(object sender, EventArgs e)
        {



           

        }

        private async Task<List<VMIPDInfo>> LoadPatients()
        {

            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfoForDischarge();

            return _lisPatientInfo;
        }

        private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMIPDInfo item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.BedCabinNo, item.Name, item.AddmissionDate.ToString("dd/MM/yyyy"));
                dgPatient.Rows.Add(row);
            }

        }

       

       

       

      

       

       

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);


                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;

                lblCabin.Tag = _pInfo;


                List<Patient> _pBills = new PatientService().GetPatientIdsByRegNo(_pInfo.RegNo);
                FillBillNoGrid(_pBills);

            }
        }

        private void FillBillNoGrid(List<Patient> pBills)
        {
            dgBillIds.SuspendLayout();
            dgBillIds.Rows.Clear();
            foreach (var item in pBills)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgBillIds, item.BillNo, item.EntryDate.ToString("dd/MM/yyyy"), item.EntryTime);

                dgBillIds.Rows.Add(row);

            }
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByCabin.Text, "cabin");
            }
        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = (List<VMIPDInfo>)txtSearchByCabin.Tag;


            if (_lisPatientInfo != null)
            {
                _lisPatientInfo = _lisPatientInfo.Where(x => x.BedCabinNo.Contains(_prefix)).ToList();

                FillListGrid(_lisPatientInfo);
            }
        }

        private IList<VMReportDefination> _SelectedTestItemsForPathologyReport;
        private async  void ctrlTemplateIPDTestResult_Load(object sender, EventArgs e)
        {
            List<VMIPDInfo> _Plist = await LoadPatients();
            _SelectedTestItemsForPathologyReport = new List<VMReportDefination>();
            FillListGrid(_Plist);

            txtSearchByCabin.Tag = _Plist;
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

                }
                else if (_pInfo.ReportTypeId == 33)
                {
                    ShowReportsOnListViewMsPdfFormat(_pInfo.PatientId.ToString());
                }
                else
                {

                    TestItem _testItem = new TestService().GetTestItemById(_pInfo.TestId);

                    int _rTypeId = 0;
                    int _priorityId = 100;

                    List<VMReportPriority> priorityObj = new ReportService().GetReportPriorityObj(_testItem.ReportTypeId,"");
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
    }
}
