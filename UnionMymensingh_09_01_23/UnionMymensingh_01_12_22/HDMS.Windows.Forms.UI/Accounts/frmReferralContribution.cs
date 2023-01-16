using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmReferralContribution : Form
    {
        public frmReferralContribution()
        {
            InitializeComponent();
        }

        private void frmReferralByDoctorPatientWise_Load(object sender, EventArgs e)
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

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
        }

        private void ctlDoctorSearch_Load(object sender, EventArgs e)
        {

        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            int _referralId = 0;
            if (txtRefdBy.Tag != null) _referralId = Convert.ToInt32(txtRefdBy.Tag);


            if (_referralId == 0)
            {
                MessageBox.Show("Select referred doctor");
                return;
            }

            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            DataSet ds = new ReportService().GetReferrelContribution(Fromdate, Todate, _referralId);

            rptReferralContribution _rpt = new rptReferralContribution();
            _rpt.SetDataSource(ds.Tables[0]);


            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _rpt.SetParameterValue("referredby",  txtRefdBy.Text);


            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtRefdBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
