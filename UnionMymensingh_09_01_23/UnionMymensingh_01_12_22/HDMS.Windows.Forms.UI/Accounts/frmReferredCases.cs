using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmReferredCases : Form
    {
        SqlDataAdapter da;
        public frmReferredCases()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            cmdShow.Text = "Please wait...";
            cmdShow.Enabled = false;

            int _referralId = 0;
            if (txtRefdBy.Tag != null) _referralId = Convert.ToInt32(txtRefdBy.Tag);
            

            da = new SqlDataAdapter();
            DataSet dsReferredcase = new ReportService().GetReferredStatement(dtpfrm.Value, dtpto.Value, _referralId);
           

             RptReferredCases _referredStatement = new RptReferredCases();
            //int c = dsReports.Tables[0].Rows.Count;

           

            _referredStatement.SetDataSource(dsReferredcase.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _referredStatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _referredStatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";


            if (!String.IsNullOrEmpty(txtRefdBy.Text) && txtRefdBy.Tag != null)
            {
                _referredStatement.SetParameterValue("Refdby", "Refd. By : " + txtRefdBy.Text);
            }
            else
            {
                _referredStatement.SetParameterValue("Refdby", "");
            }

            

            rv.crviewer.ReportSource = _referredStatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Text = "Show";
            cmdShow.Enabled = true;
        }

        private void txtRefdBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                ctlDoctorSearch.Visible = false;
                int id;
                if (int.TryParse(txtRefdBy.Text.Trim(), out id))
                {
                    txtRefdBy.Text = new DoctorService().GetDoctorById(id).Name;
                    txtRefdBy.Tag = new DoctorService().GetDoctorById(id).DoctorId;
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
        }

        private void frmReferredCases_Load(object sender, EventArgs e)
        {
            ctlDoctorSearch.Location = new Point(txtRefdBy.Location.X, txtRefdBy.Location.Y + txtRefdBy.Height);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;
        }

        private void ctlDoctorSearch_ItemSelected(UI.Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtRefdBy.Text = item.Name;
            txtRefdBy.Tag = item.DoctorId;
            sender.Visible = false;
        }

        private void txtRefdBy_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRefdBy.Text))
            {
                txtRefdBy.Tag = null;
            }
        }

        private void btnByReferralDetail_Click(object sender, EventArgs e)
        {
            btnByReferralDetail.Text = "Please wait...";
            btnByReferralDetail.Enabled = false;

            int _referralId = 0;
            if (txtRefdBy.Tag != null) _referralId = Convert.ToInt32(txtRefdBy.Tag);


            if (_referralId == 0) {
                MessageBox.Show("Select referred doctor");
                return;
            }

            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            DataSet ds = new ReportService().GetReferredCaseByReferralDetail(Fromdate, Todate, _referralId);
          
            rptReferredCaseByReferralDetail _rpt = new rptReferredCaseByReferralDetail();
            _rpt.SetDataSource(ds.Tables[0]);

        
            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("datefrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));
            _rpt.SetParameterValue("referredby","Refd. by : "+ txtRefdBy.Text);


            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            btnByReferralDetail.Enabled = true;
            btnByReferralDetail.Text = "ByReferral Detail List";
        }

        private void btnIpd_Click(object sender, EventArgs e)
        {
            int _doctorId = 0;

            string _refdBy = string.Empty;

            if (String.IsNullOrWhiteSpace(txtRefdBy.Text))
            {
                _refdBy = "All";
            }
            else
            {
                _refdBy = txtRefdBy.Text;
            }

        

            if (txtRefdBy.Tag != null)
            {
                _doctorId = Convert.ToInt32(txtRefdBy.Tag);
            }


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;



            DataSet ds = new ReportService().GetReferredCaseByIPDOPD(_doctorId, Fromdate, Todate,"IPD");


            ReportViewer rv = new ReportViewer();
            RptRefdCaseByIPDorOPD _rpt = new RptRefdCaseByIPDorOPD();


            _rpt.SetDataSource(ds.Tables[0]);


            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtpfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtpto", dtpto.Value.ToString(customFmts));
            _rpt.SetParameterValue("ConsultantName", "Refd. by : " + _refdBy);
            _rpt.SetParameterValue("Refdtype", "IPD");

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();


        }

        private void btnOpd_Click(object sender, EventArgs e)
        {

            string _refdBy = string.Empty;

            if (String.IsNullOrWhiteSpace(txtRefdBy.Text))
            {
                _refdBy = "All";
            }
            else
            {
                _refdBy = txtRefdBy.Text;
            }

            int _doctorId = 0;

            if (txtRefdBy.Tag != null)
            {
                 _doctorId = Convert.ToInt32(txtRefdBy.Tag);
            }

           


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;



            DataSet ds = new ReportService().GetReferredCaseByIPDOPD(_doctorId, Fromdate, Todate, "OPD");


            ReportViewer rv = new ReportViewer();
            RptRefdCaseByIPDorOPD _rpt = new RptRefdCaseByIPDorOPD();


            _rpt.SetDataSource(ds.Tables[0]);


            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtpfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtpto", dtpto.Value.ToString(customFmts));
            _rpt.SetParameterValue("ConsultantName", "Refd. by : " + _refdBy);
            _rpt.SetParameterValue("Refdtype", "OPD");
            
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();


        }
    }
}
