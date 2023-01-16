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
using HDMS.Model.Common;
using HDMS.Windows.Forms.UI.Controls;

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmReferralByDoctorPatientWise : Form
    {

        bool unlocked = true;
        public frmReferralByDoctorPatientWise()
        {
            InitializeComponent();
        }

        private void frmReferralByDoctorPatientWise_Load(object sender, EventArgs e)
        {


            ctlDoctorSearch.Location = new Point(txtRefdBy.Location.X, txtRefdBy.Location.Y + txtRefdBy.Height);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;


            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y);
            ctlMediaSearchControl.ItemSelected += ctlMediaSearchControl_ItemSelected;

        }

        private void ctlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item.MediaId;

            sender.Visible = false;
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

            DataSet ds = new ReportService().GetReferrelByDoctorPatientWise(Fromdate, Todate, _referralId);

            rptReferralByDoctorPatientWise _rpt = new rptReferralByDoctorPatientWise();
            _rpt.SetDataSource(ds.Tables[0]);


            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _rpt.SetParameterValue("referredby", "Refd. by : " + txtRefdBy.Text);


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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
        }

        private void btnMediaStatement_Click(object sender, EventArgs e)
        {
            int _referralId = 0;
            if (txtMedia.Tag != null) _referralId = Convert.ToInt32(txtMedia.Tag);


            if (_referralId == 0)
            {
                MessageBox.Show("Select media");
                return;
            }

            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

           // DataSet ds = new ReportService().GetReferrelByMediaPatientWise(Fromdate, Todate, _referralId);

            rptReferralByDoctorPatientWise _rpt = new rptReferralByDoctorPatientWise();
           // _rpt.SetDataSource(ds.Tables[0]);


            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _rpt.SetParameterValue("referredby", "Media Name : " + txtMedia.Text);


            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtMedia_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtMedia.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtMedia.Text;
                    HideAllDefaultHidden();
                    ctlMediaSearchControl.Visible = true;
                    ctlMediaSearchControl.txtSearch.Text = _txt;
                    ctlMediaSearchControl.txtSearch.SelectionStart = ctlMediaSearchControl.txtSearch.Text.Length;

                    ctlMediaSearchControl.LoadData();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int _referralId = 0;
            //if (txtRefdBy.Tag != null) _referralId = Convert.ToInt32(txtRefdBy.Tag);


            //if (_referralId == 0)
            //{
            //    MessageBox.Show("Select referred doctor");
            //    return;
            //}

            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            //DataSet ds = new ReportService().GetReferrelByDoctorPatientWise1(Fromdate, Todate);

            rptReferralByDoctorPatientWise _rpt = new rptReferralByDoctorPatientWise();
           // _rpt.SetDataSource(ds.Tables[0]);


            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
           // _rpt.SetParameterValue("referredby", "Refd. by : " + txtRefdBy.Text);


            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
