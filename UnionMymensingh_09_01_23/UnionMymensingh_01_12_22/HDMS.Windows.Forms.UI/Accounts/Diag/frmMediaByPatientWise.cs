using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.Accounts;
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
    public partial class frmMediaByPatientWise : Form
    {
        public frmMediaByPatientWise()
        {
            InitializeComponent();
        }

        private void frmMediaByPatientWise_Load(object sender, EventArgs e)
        {
            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y);
            ctlMediaSearchControl.ItemSelected += ctlMediaSearchControl_ItemSelected;
        }

        private void ctlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item.MediaId;

            sender.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            int _referralId = 0;
            if (txtMedia.Tag != null) _referralId = Convert.ToInt32(txtMedia.Tag);


            if (_referralId == 0)
            {
                MessageBox.Show("Select referred doctor");
                return;
            }

            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            DataSet ds = new ReportService().GetReferrelByMediaPatientWise(Fromdate, Todate, _referralId);

            rptReferralByMediaPatientWise _rpt = new rptReferralByMediaPatientWise();
            _rpt.SetDataSource(ds.Tables[0]);


            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _rpt.SetParameterValue("referredby", "Refd. by : " + txtMedia.Text);


            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HiddenAllDefaults();
                ctlMediaSearchControl.Visible = true;
                ctlMediaSearchControl.LoadData();
            }
        }

        private void HiddenAllDefaults()
        {
            ctlMediaSearchControl.Visible = false;
        }
    }
}
