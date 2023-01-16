using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Reports.Canteen;
using Services.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.ReportForm
{
    public partial class frmCantDueCollectionStatement : Form
    {
        public frmCantDueCollectionStatement()
        {
            InitializeComponent();
        }

        private void frmDueCollection_Load(object sender, EventArgs e)
        {
            dtpFromdate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptCantDueCollection _rpt = new rptCantDueCollection();


            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            DataSet ds = new ReportingService().GetDueCollectionList(Fromdate, Todate);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm", Fromdate.ToString("dd/MM/yyy"));
            _rpt.SetParameterValue("dateto", Todate.ToString("dd/MM/yyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
