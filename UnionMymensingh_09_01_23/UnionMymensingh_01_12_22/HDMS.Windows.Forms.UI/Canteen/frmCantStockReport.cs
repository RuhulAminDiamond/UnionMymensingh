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

using Models;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Reports.Canteen;

namespace POS.Forms.ReportForm
{
    public partial class frmCantStockReport : Form
    {
        public frmCantStockReport()
        {
            InitializeComponent();
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            dtpFromdate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            btnReport.Enabled = false;
            btnReport.Text = "Please wait..";
            ShowStock();
            btnReport.Enabled = true;
            btnReport.Text = "Show Report";
        }

        private void ShowStock()
        {
            ReportViewer rv = new ReportViewer();
            rptStock _rpt = new rptStock();

            string _rptOption = string.Empty;

            if (radValued.Checked)
            {
                _rptOption = "Valued";
            }
            else
            {
                _rptOption = "All";
            }

            DataSet ds = new ReportingService().GetStockStatement(dtpFromdate.Value,dtpTodate.Value, _rptOption);
            _rpt.SetDataSource(ds.Tables[0]);



            _rpt.SetParameterValue("dtfrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dtto", dtpTodate.Value.ToString("dd/MM/yyyy"));
           


            //// _rpt.DataDefinition.FormulaFields[4].Text = "'" + txtInWord.Text + "'";


            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

     
    }
}
