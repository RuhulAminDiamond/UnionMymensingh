using CrystalDecisions.Windows.Forms;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    public partial class frmOpeningClosingNewEdition : Form
    {
        public frmOpeningClosingNewEdition()
        {
            InitializeComponent();
        }

        private void cmdViewStatement_Click(object sender, EventArgs e)
        {

            cmdViewStatement.Text = "Plz. Wait..";
            cmdViewStatement.Enabled = false;

            DataSet ds = new PhProductService().GetPhOpeningClosingStock(dtpfrm.Value, dtpfrm.Value.AddDays(1));

            //int c = dsReports.Tables[0].Rows.Count;

            rptOpeningClosing _opcList = new rptOpeningClosing();

            _opcList.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _opcList.SetParameterValue("opcdate", dtpfrm.Value.ToString(customFmts));
            //_collecList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            //_collecList.SetParameterValue("Collectionby", "");

            rv.crviewer.ReportSource = _opcList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
           // rv.crviewer.PrintReport();
            rv.Show();

            cmdViewStatement.Text = "View Statement";
            cmdViewStatement.Enabled = true;

        }
    }
}
