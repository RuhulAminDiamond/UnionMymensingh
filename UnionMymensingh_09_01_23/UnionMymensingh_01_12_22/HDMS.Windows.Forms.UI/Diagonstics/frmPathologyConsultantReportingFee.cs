using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmPathologyConsultantReportingFee : Form
    {

        DataSet ds = new DataSet();


        public frmPathologyConsultantReportingFee()
        {
            InitializeComponent();
        }


        private void frmPathologyConsultantReportingFee_Load(object sender, EventArgs e)
        {

            FillDgPathologisService(GetAllPathlogisServiceFeeWithPatientId(DateTime.Now, DateTime.Now));
            IsNotPaidConsultanPayment(DateTime.Now, DateTime.Now, 0);

            HiddenAllControl();
        }

        private void IsNotPaidConsultanPayment(DateTime dptFrom, DateTime dptTo, int doctorId)
        {
            List<PathologyReport> pathologyReports = new ReportService().IsNotPaidConsultanPayment(dptFrom, dptTo, doctorId);

            lblConsultant.Tag = pathologyReports;
        }

        public List<VMPathologistServiceFee> GetAllPathlogisServiceFeeWithPatientId(DateTime dptFrom, DateTime dptTo)
        {

            List<VMPathologistServiceFee> pathologist = new ReportService().GetAllPathlogisServiceFeeWithPatientId(dptFrom, dptTo);

            return pathologist;

        }

        public void FillDgPathologisService(List<VMPathologistServiceFee> items)
        {
            double sum = 0;

            dgPathologisFee.SuspendLayout();
            dgPathologisFee.Rows.Clear();

            if (items == null) return;

            foreach (VMPathologistServiceFee item in items)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                //row.CreateCells(dgPathologisFee, item.PatientName, item.Fee.ToString(), item.Rate.ToString());
                row.CreateCells(dgPathologisFee, item.PatientId, item.Consultant, item.PatientName, item.Cost.ToString(), item.TotalFee.ToString());
                dgPathologisFee.Rows.Add(row);

                // Total Fee Show
                sum += item.TotalFee;
                lblTotal.Text = sum.ToString();
            }

            dgPathologisFee.Tag = items;

        }

        private void crtGradeintBackground_Paint(object sender, PaintEventArgs e)
        {
            ctrlReportConsultantSearchControl.Location = new Point(txtConsultantSerarch.Location.X, txtConsultantSerarch.Location.Y + txtConsultantSerarch.Height);


            //ctrlTemplateSearch.ItemSelected += ctrlTemplateSearch_ItemSelected;
        }



        private void ctrlReportConsultantSearchControl_ItemSelected(Controls.SearchResultListControl<ReportConsultant> sender, ReportConsultant item)
        {
            txtConsultantSerarch.Text = item.Name;
            txtConsultantSerarch.Tag = item;
            sender.Visible = false;

        }

        private void HiddenAllControl()
        {
            ctrlReportConsultantSearchControl.Visible = false;
        }

        private void txtConsultantSerarch_TextChanged(object sender, EventArgs e)
        {
            ctrlReportConsultantSearchControl.Visible = true;
            ctrlReportConsultantSearchControl.LoadData();
        }



        private void btnShow_Click(object sender, EventArgs e)
        {
            ReportConsultant rpt = txtConsultantSerarch.Tag as ReportConsultant;
            if (rpt != null)
            {
                GetSinglePalthlogistServiceFeeByPaitent(rpt.RCId, dtpFrom.Value, dtpTo.Value);
                IsNotPaidConsultanPayment(dtpFrom.Value.Date,  dtpTo.Value.Date, rpt.RCId);
                return;
            }

            FillDgPathologisService(GetAllPathlogisServiceFeeWithPatientId(dtpFrom.Value, dtpTo.Value));
            IsNotPaidConsultanPayment(dtpFrom.Value.Date, dtpTo.Value.Date, 0);




        }

        public List<VMPathologistServiceFee> GetSinglePalthlogistServiceFeeByPaitent(int consultantId, DateTime dtpFrom, DateTime dtpTo)
        {
            List<VMPathologistServiceFee> singlePathologist = new ReportService().GetSinglePalthlogistServiceFeeByPaitent(consultantId, dtpFrom, dtpTo);

            FillDgPathologisService(singlePathologist);
            return singlePathologist;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowConsultantWaiseReport_Click(object sender, EventArgs e)
        {
            ReportConsultant rpt = txtConsultantSerarch.Tag as ReportConsultant;

            if (rpt == null)
            {
                MessageBox.Show("Plece Select Pathologist Name");
                return;
            }

            ds = new ReportService().GetPathologistServiceReportFeeWithConsultentId(rpt.RCId, dtpFrom.Value, dtpTo.Value);

            if (ds == null)
            {
                MessageBox.Show("No Data Found");
                return;
            }

            rptPathologistServiceFee rptPathologist = new rptPathologistServiceFee();
            rptPathologist.SetDataSource(ds.Tables[0]);
            rptPathologist.SetParameterValue("DateFrom", dtpFrom.Value);
            rptPathologist.SetParameterValue("DateTo", dtpTo.Value);

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = rptPathologist;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void btnSaveConsultancy_Click(object sender, EventArgs e)
        {
            /*================= Save Data Consultent Ledgers Table ================ */
            ReportConsultant rpt = txtConsultantSerarch.Tag as ReportConsultant;

            if(rpt == null)
            {
                MessageBox.Show("Please Select Consultent Name ");

                return;

            }

            //if (rpt.RCId <= 0)
            //{
            //    MessageBox.Show("Please Select Consultent Name ");

            //    return;
            //}


            DialogResult dialogResult = MessageBox.Show("Are you Sure Consultan Payment", "Consulation Payment", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                List<ConsultentLedger> consultent = new List<ConsultentLedger>();
                
                DateTime currentDate = DateTime.Now;
                foreach (DataGridViewRow item in dgPathologisFee.Rows)
                {

                    if (item.Cells["PatientName"].Value == null) continue;

                    long _patientId = Convert.ToInt64(item.Cells["PatientId"].Value);
                    string _consulentName = Convert.ToString(item.Cells["Consultant"].Value);
                    string _patientName = Convert.ToString(item.Cells["PatientName"].Value);
                    double _totalFee = Convert.ToDouble(item.Cells["TotalFee"].Value);
                    int _consultentId = Convert.ToInt32(rpt.RCId);
                    ConsultentLedger ledger = new ConsultentLedger();
                   

                    if (_totalFee > 0)
                    {
                        ledger.ConsultantName = _consulentName;
                        ledger.ConsultentId = _consultentId;
                        ledger.Credit = _totalFee;
                        ledger.PatientId = _patientId;
                        ledger.TranDate = currentDate;
                        ledger.PatientName = _patientName;
                        ledger.Particulars = "Normal Transection";
                        ledger.TransectionType = "NormalTransection";
                      


                        consultent.Add(ledger);
                       

                    }
                    else
                    {
                        ConsultentLedger led = new ConsultentLedger();
                        led.ConsultantName = _consulentName;
                        led.ConsultentId = _consultentId;
                        led.Credit = _totalFee;
                        led.PatientId = _patientId;
                        led.TranDate = currentDate;
                        led.PatientName = _patientName;
                        led.Particulars = "TransectionWithZerro";
                        led.TransectionType = "TransectionWithZerro";

                        consultent.Add(led);
                        
                    }

                }




                if (new ReportService().SavePathologistPaymentDetails(consultent))
                {

                    List<PathologyReport> pathologyReports = new List<PathologyReport>();
                    List< PathologyReport> rr = lblConsultant.Tag as List<PathologyReport>;

                    foreach(PathologyReport item in rr)
                    {

                        item.IsPaid = true;
                        pathologyReports.Add(item);
                    }

                  
                     new ReportService().UpdatePathologyReportIsPaid(pathologyReports);

                    MessageBox.Show("Data has been saved Successfull");
                    /*-------------------- 
                     *  Pathology Grid Cleare 
                     * -----------------------
                     */
                    dgPathologisFee.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Something went Wrong");
                }

                ds = new ReportService().GetConsultentPaymentWithZerroOrNormal(dtpFrom.Value, dtpTo.Value, rpt.RCId);


                rptPathologistServiceFee rptPathologist = new rptPathologistServiceFee();
                rptPathologist.SetDataSource(ds.Tables[0]);
                rptPathologist.SetParameterValue("DateFrom", dtpFrom.Value);
                rptPathologist.SetParameterValue("DateTo", dtpTo.Value);

                ReportViewer rv = new ReportViewer();

                rv.crviewer.ReportSource = rptPathologist;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        






        }

        private void ctrlReportConsultantSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtConsultantSerarch.Focus();
        }

       

        private void dgPathologisFee_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0 && e.ColumnIndex == 4)
            {
                double sum = 0;

                List<VMPathologistServiceFee> items = dgPathologisFee.Tag as List<VMPathologistServiceFee>;

                foreach(DataGridViewRow item in dgPathologisFee.Rows )
                {
                    double total = Convert.ToDouble(item.Cells["TotalFee"].Value);

                    sum += total;

                }
                lblTotal.Text = sum.ToString();

                // dgPathologisFee.Tag = null;

              //  MessageBox.Show("cell Eneter ");

            }
           

        }
    }
}
