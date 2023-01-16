using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmReportFeeSetup : Form
    {
        public frmReportFeeSetup()
        {
            InitializeComponent();
        }

        private void frmReportFeeSetup_Load(object sender, EventArgs e)
        {
            HideSearchControls();

            ctrlReportConsultantSearchControl.Location = new Point(txtConsultant.Location.X, txtConsultant.Location.Y);
            ctrlReportTypeSearchControl.Location = new Point(txtReportType.Location.X, txtReportType.Location.Y);

            ctrlReportConsultantSearchControl.ItemSelected += CtrlReportConsultantSearchControl_ItemSelected;
            ctrlReportTypeSearchControl.ItemSelected += CtrlReportTypeSearchControl_ItemSelected;

            ctrlReportConsultantSearchControlSingle.Location = new Point(txtSingleConsultant.Location.X, txtSingleConsultant.Location.Y);
            ctrlReportConsultantSearchControlSingle.ItemSelected += ctrlReportConsultantSearchControlSingle_ItemSelected;

            ctrlreportTypeSearchControlSingle.Location = new Point(txtSingleReportType.Location.X, txtSingleReportType.Location.Y);
            ctrlreportTypeSearchControlSingle.ItemSelected += ctrlreportTypeSearchControlSingle_ItemSelected;
        }

        private void CtrlReportConsultantSearchControl_ItemSelected(Controls.SearchResultListControl<Model.ReportConsultant> sender, Model.ReportConsultant item)
        {
            txtConsultant.Text = item.Name;
            txtConsultant.Tag = item;
            txtReportType.Focus();
            sender.Visible = false;
        }

        private void CtrlReportTypeSearchControl_ItemSelected(Controls.SearchResultListControl<Model.ReportType> sender, Model.ReportType item)
        {
            txtReportType.Text = item.Report_Type;
            txtReportType.Tag = item;
            txtDefaultFee.Focus();
            sender.Visible = false;

            /* ==================== Checke  Report Fee Object Data Exists or Not  =================*/
            ReportConsultant consultant = txtConsultant.Tag as ReportConsultant;

            LoadCousultanTst();

            //LoadDgTests(item);

        }

        private void LoadDgTests(ReportType item)
        {
            List<TestItem> testItems = new TestService().GetAllTestByReportTypeId(item.ReportTypeId);
            //FillDgTests(testItems);
        }



        private void LoadCousultanTst()
        {
            ReportConsultant _reportConsultant = txtConsultant.Tag as ReportConsultant;
            ReportType _reportType = txtReportType.Tag as ReportType;
            if (_reportType != null)
            {
                List<VMConsutantentTstFeeSeupt> vMTestId = new TestService().GetAllTestByReportType(_reportType.ReportTypeId);

                List<VMConsutantentTstFeeSeupt> reports = new TestService().ShowAllConsultantReportTypeIdAdnFee(_reportType.ReportTypeId, _reportConsultant.RCId);
                if (reports.Count > 0)
                {

                 
                   // List<VMConsutantentTstFeeSeupt> vMConsutantentTstFeeSeupts = new List<VMConsutantentTstFeeSeupt>();
                  //  vMConsutantentTstFeeSeupts.AddRange(reports);

                    //foreach (VMConsutantentTstFeeSeupt item in vMTestId)
                    //{
                    //    if (!vMConsutantentTstFeeSeupts.Contains(item))
                    //    {
                    //        vMConsutantentTstFeeSeupts.Append(item);
                    //    }
                    //}


                    FillDgTests(reports);
                        txtReportType.Tag = reports;
                    }
                    else
                    {

                        FillDgTests(vMTestId);


                    }



                }

            }


        /*=====================  single Data  media fee add ========================= */




            private void FillDgTests(List<VMConsutantentTstFeeSeupt> testItems)
            {
                dgTests.SuspendLayout();
                dgTests.Rows.Clear();
                foreach (VMConsutantentTstFeeSeupt item in testItems)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Height = 25;
                    row.Tag = item;
                    row.CreateCells(dgTests, item.Name, item.Fee.ToString(), item.Rate.ToString());
                    dgTests.Rows.Add(row);
                }
            }

            private void HideSearchControls()
            {
                ctrlReportConsultantSearchControl.Visible = false;
                ctrlReportTypeSearchControl.Visible = false;
            ctrlReportConsultantSearchControlSingle.Visible = false;
             ctrlreportTypeSearchControlSingle.Visible = false;
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                ReportConsultant reportConsultant = txtConsultant.Tag as ReportConsultant;


                if (reportConsultant == null)
                {
                    MessageBox.Show("Please select a consultant.");
                    return;
                }

                List<ReportFee> reportFees = new List<ReportFee>();

                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    if (row.Tag == null) continue;

                    //TestItem testItem = row.Tag as TestItem;
                    VMConsutantentTstFeeSeupt testItem = row.Tag as VMConsutantentTstFeeSeupt;
                    if (testItem == null) continue;

                    double.TryParse(row.Cells["Fee"].Value.ToString(), out double fee);

                    ReportFee reportFee = new ReportFee();
                    reportFee.RCId = reportConsultant.RCId;
                    reportFee.TestId = testItem.TestId;
                    reportFee.Fee = fee;
                    reportFee.ReportTypeId = testItem.ReportTypeId;
                    reportFee.RFId = testItem.RFId;
                    reportFees.Add(reportFee);
                }

                var reportFee1 = GetReportTestIdAndConsultantId(reportFees[0].ReportTypeId, reportFees[0].RCId);

                if (reportFees.Count > 0)
                {
                    if (reportFee1 != null)
                    {
                        if (reportFee1.RFId != 0)
                        {
                            if (UpdateReportFee(reportFees))
                            {
                                MessageBox.Show("Consultant fee Update  successfully.");
                                return;
                            };
                        }
                    }

                    if (new ReportService().SaveReportFees(reportFees))
                    {
                        MessageBox.Show("Saved successfully.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred. Try again later.");
                    }
                }
            }

            private bool UpdateReportFee(List<ReportFee> reportFee)
            {
                return new TestService().UpdateReportFee(reportFee);
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void txtConsultant_TextChanged(object sender, EventArgs e)
            {
                ctrlReportConsultantSearchControl.Visible = true;
                ctrlReportConsultantSearchControl.txtSearch.Text = txtConsultant.Text;
                ctrlReportConsultantSearchControl.txtSearch.SelectionStart = ctrlReportConsultantSearchControl.txtSearch.Text.Length;
                ctrlReportConsultantSearchControl.LoadData();
            }

            private void txtReportType_TextChanged(object sender, EventArgs e)
            {
                ctrlReportTypeSearchControl.Visible = true;
                //  ctrlReportTypeSearchControl.txtSearch.Text = txtReportType.Text;
                ctrlReportTypeSearchControl.txtSearch.SelectionStart = ctrlReportTypeSearchControl.txtSearch.Text.Length;
                ctrlReportTypeSearchControl.LoadData();



            }

            private ReportFee GetReportTestIdAndConsultantId(int reporttypeId, int consultanteId)
            {
               ReportFee reportFee = new ReportService().GetReportTestIdAndCoultantId(reporttypeId, consultanteId);

                return reportFee;
            }
            private void ctrlReportConsultantSearchControl_SearchEsacaped(bool IsEscaped)
            {
                if (IsEscaped) txtConsultant.Focus();
            }

            private void ctrlReportTypeSearchControl_SearchEsacaped(bool IsEscaped)
            {
                if (IsEscaped) txtReportType.Focus();
            }

            private void txtDefaultFee_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    double.TryParse(txtDefaultFee.Text, out double defaultFee);

                    foreach (DataGridViewRow row in dgTests.Rows)
                    {
                        if (row.Tag == null) continue;

                        row.Cells["Fee"].Value = defaultFee.ToString();
                    }
                }
            }

        private void txtSingleConsultant_TextChanged(object sender, EventArgs e)
        {
            ctrlReportConsultantSearchControlSingle.Visible = true;
            ctrlReportConsultantSearchControlSingle.txtSearch.Text = txtConsultant.Text;
            ctrlReportConsultantSearchControlSingle.txtSearch.SelectionStart = ctrlReportConsultantSearchControlSingle.txtSearch.Text.Length;
            ctrlReportConsultantSearchControlSingle.LoadData();
        }

        private void txtSingleReportType_TextChanged(object sender, EventArgs e)
        {
            ctrlreportTypeSearchControlSingle.Visible = true;
            ctrlreportTypeSearchControlSingle.txtSearch.Text = txtConsultant.Text;
            ctrlreportTypeSearchControlSingle.txtSearch.SelectionStart = ctrlreportTypeSearchControlSingle.txtSearch.Text.Length;
            ctrlreportTypeSearchControlSingle.LoadData();
        }

        private void txtSingleTestName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctrlReportConsultantSearchControlSingle_ItemSelected(Controls.SearchResultListControl<ReportConsultant> sender, ReportConsultant item)
        {
            txtSingleConsultant.Text = item.Name;
            txtSingleConsultant.Tag = item;
            txtSingleReportType.Focus();
            sender.Visible = false;

        }

        private void ctrlreportTypeSearchControlSingle_ItemSelected(Controls.SearchResultListControl<ReportType> sender, ReportType item)
        {
            txtSingleReportType.Text = item.Report_Type;
            txtSingleReportType.Tag = item;
            txtSingleTestName.Focus();
            sender.Visible = false;
        }
    }
    }
