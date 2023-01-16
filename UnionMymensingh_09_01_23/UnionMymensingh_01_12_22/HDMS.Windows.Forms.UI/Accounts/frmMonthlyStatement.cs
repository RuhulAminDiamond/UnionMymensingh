using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmMonthlyStatement : Form
    {
        public frmMonthlyStatement()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            cmdShow.Enabled = false;
            cmdShow.Text = "Please wait..";
            ReportViewer rv = new ReportViewer();
            rptMonthlyStatement _rpt = new rptMonthlyStatement();
            _rpt.SetDatabaseLogon("Syscom", "fm#s21928", "Server", "Diag", true);


            
            _rpt.SetParameterValue("@Year", cmbYear.Text );
            _rpt.SetParameterValue("@Month", ((ListItem)cmbMonth.SelectedItem).Value);



            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Enabled = true;
            cmdShow.Text = "Show";
        }

        private void frmMonthlyStatement_Load(object sender, EventArgs e)
        {
            cmbMonth.Items.Add(new ListItem("January", "1"));
            cmbMonth.Items.Add(new ListItem("February", "2"));
            cmbMonth.Items.Add(new ListItem("March", "3"));
            cmbMonth.Items.Add(new ListItem("April", "4"));
            cmbMonth.Items.Add(new ListItem("May", "5"));
            cmbMonth.Items.Add(new ListItem("June", "6"));
            cmbMonth.Items.Add(new ListItem("July", "7"));
            cmbMonth.Items.Add(new ListItem("August", "8"));
            cmbMonth.Items.Add(new ListItem("September", "9"));
            cmbMonth.Items.Add(new ListItem("October", "10"));
            cmbMonth.Items.Add(new ListItem("November", "11"));
            cmbMonth.Items.Add(new ListItem("December", "12"));
        }
    }
}
