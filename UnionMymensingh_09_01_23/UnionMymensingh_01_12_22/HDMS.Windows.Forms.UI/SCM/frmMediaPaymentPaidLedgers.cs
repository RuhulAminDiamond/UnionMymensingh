using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Service.Diagonstics;
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

namespace HDMS.Windows.Forms.UI.SCM
{
    public partial class frmMediaPaymentPaidLedgers : Form
    {
        public frmMediaPaymentPaidLedgers()
        {
            InitializeComponent();
        }

        private void ctrlMediaSearchControlFromPayments_ItemSelected(Controls.SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMediaName.Text = item.Name;
            txtMediaName.Tag = item;

            sender.Visible = false;

        }

        private void HideAllControlls()
        {
            ctrlMediaSearchControlFromPayments.Visible = false;
        }

        private void frmMediaPaymentPaidLedgers_Load(object sender, EventArgs e)
        {
            HideAllControlls();
            ctrlMediaSearchControlFromPayments.Location = new Point(txtMediaName.Location.X, txtMediaName.Location.Y);

            ctrlMediaSearchControlFromPayments.ItemSelected += ctrlMediaSearchControlFromPayments_ItemSelected;
        }

        private void txtMediaName_TextChanged(object sender, EventArgs e)
        {
            HideAllControlls();
            ctrlMediaSearchControlFromPayments.Visible = true;
            ctrlMediaSearchControlFromPayments.LoadData();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            BusinessMedia business = txtMediaName.Tag as BusinessMedia;
            if(business == null)
            {
                MessageBox.Show("Place Select Media ");

                return;
            }
          
            DataSet ds = new ReportService().GetMediaLeadgerSummery(business.MediaId, dtpFrom.Value, dtpTo.Value);
            rptMediaPaymentLadgerSummary _rpt = new rptMediaPaymentLadgerSummary();

            _rpt.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _rpt.SetParameterValue("MediaName", business.Name);
            _rpt.SetParameterValue("dtfrm", dtpFrom.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtpTo", dtpTo.Value.ToString(customFmts)); 



            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
