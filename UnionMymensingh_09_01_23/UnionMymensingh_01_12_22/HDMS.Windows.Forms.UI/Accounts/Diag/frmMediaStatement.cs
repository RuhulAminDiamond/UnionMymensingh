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
using HDMS.Service.Diagonstics;
//using HDMS.Windows.Forms.UI.Reports.Diagnostic.Media;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Rx;

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmMediaStatement : Form
    {
        public frmMediaStatement()
        {
            InitializeComponent();
        }

        private void frmMediaStatement_Load(object sender, EventArgs e)
        {

            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y+txtMedia.Height);
            ctlMediaSearchControl.ItemSelected += ctlMediaSearchControl_ItemSelected;

            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

        }

        private void ctlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item;
            sender.Visible = false;
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

        private void btnShow_Click(object sender, EventArgs e)
        {

            int mediaId = 0;
            string _mediaName = "All";

            if (txtMedia.Tag != null)
            {
                BusinessMedia _media = (BusinessMedia)txtMedia.Tag;
                mediaId = _media.MediaId;
                _mediaName = _media.Name;
            }

           


                DataSet ds = new ReportService().GetMediaStatement(mediaId, dtpfrm.Value, dtpto.Value);


                rptMediaStatement _rpt = new rptMediaStatement();

                _rpt.SetDataSource(ds.Tables[0]);



                ReportViewer rv = new ReportViewer();
                string customFmts = "dd/MM/yyyy";

                _rpt.SetParameterValue("MediaName", _mediaName);
                _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
                _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
              

             

                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            

        }

        private void txtMedia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
