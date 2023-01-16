using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Service.Media;
using HDMS.Windows.Forms.UI.Controls;
//using HDMS.Windows.Forms.UI.Media.Reports;
using HDMS.Windows.Forms.UI.Reports.Media;
using HDMS.Windows.Forms.UI.Reports.MIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Media
{
    public partial class frmMediaCommissionStatement : Form
    {
        public frmMediaCommissionStatement()
        {
            InitializeComponent();
        }

        private void btnShowStatement_Click(object sender, EventArgs e)
        {
            int MediaId = 0;
            BusinessMedia media = txtMedia.Tag as BusinessMedia;
            if (media != null) MediaId = media.MediaId;

            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            bool isPaid = !cbUnpaid.Checked;
            ReportClass rpt;

            //if (isPaid)
            //{
            //    rpt = new rptMediaCommissionStatement();
            //}
            //else
            //{
            //    rpt = new rptMediaUnpaidStatement();
            //}

            //DataSet ds = MediaService.getMediaStatementDataset(from, to, MediaId, isPaid);
            DataSet ds = MediaService.GetHospitalMeidaPaymentStatement(from, to, MediaId);


            rpt = new rtpHospitalMediaStatement();

            rpt.SetDataSource(ds.Tables[0]);
            rpt.SetParameterValue("From", from);
            rpt.SetParameterValue("To", to);
            rpt.SetParameterValue("Medianame", "All");

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ShowPaidStatement(DateTime from, DateTime to, int mediaId)
        {
            DataSet ds;
            ds = MediaService.getMediaStatementDataset(from, to, mediaId);

            rptMediaCommissionStatement _rpt = new rptMediaCommissionStatement();
            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();

            _rpt.SetParameterValue("DateFrom", dtpFrom.Value);
            _rpt.SetParameterValue("DateTo", dtpTo.Value);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ShowUnpaidStatement(DateTime from, DateTime to, int mediaId)
        {
            DataSet ds = MediaService.getMediaStatementDataset(from, to, mediaId, false);

            rptMediaUnpaidStatement _rpt = new rptMediaUnpaidStatement();
            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();

            _rpt.SetParameterValue("From", from);
            _rpt.SetParameterValue("To", to);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmMediaCommissionStatement_Load(object sender, EventArgs e)
        {
            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y);
            ctlMediaSearchControl.ItemSelected += CtlMediaSearchControl_ItemSelected;
        }

        private void CtlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item;
            txtMedia.Focus();
            sender.Visible = false;
        }

        private void ctlMediaSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedia.Focus();
            }
        }

        private void txtMedia_TextChanged(object sender, EventArgs e)
        {
            string _txt = txtMedia.Text;
            HideAllDefaultHidden();
            ctlMediaSearchControl.Visible = true;
            ctlMediaSearchControl.txtSearch.Text = _txt;
            ctlMediaSearchControl.txtSearch.SelectionStart = ctlMediaSearchControl.txtSearch.Text.Length;
            ctlMediaSearchControl.LoadData();
        }

        private void HideAllDefaultHidden()
        {
            ctlMediaSearchControl.Visible = false;
        }

        private void btnMediaWaise_Click(object sender, EventArgs e)
        {
            int MediaId = 0;
            string mediaName = "";
            BusinessMedia media = txtMedia.Tag as BusinessMedia;
            if(media == null)
            {
                MessageBox.Show("Plase Select Media Name");
                return;
            }
            if (media != null) { 
                MediaId = media.MediaId;
                mediaName = media.Name;


            }

            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            bool isPaid = !cbUnpaid.Checked;
            ReportClass rpt;

         
            DataSet ds = MediaService.GetHospitalMeidaWaisePaymentStatement(from, to, MediaId);


            rpt = new rtpHospitalMediaStatement();

            rpt.SetDataSource(ds.Tables[0]);
            rpt.SetParameterValue("From", from);
            rpt.SetParameterValue("To", to);
            rpt.SetParameterValue("Medianame", mediaName);


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
