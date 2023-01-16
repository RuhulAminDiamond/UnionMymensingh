using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmDueList : Form
    {
        SqlDataAdapter da;
        public frmDueList()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
            if (radIPD.Checked)
            {
                _reportOPtion = "IPD";
                _reportHeader = "IPD DUE LIST";
            }
            else if (radOPD.Checked)
            {
                _reportOPtion = "OPD";
                _reportHeader = "OPD DUE LIST";
            }
            else if (radAll.Checked)
            {
                _reportOPtion = "All";
                _reportHeader = "DUE LIST";
            }

            if (String.IsNullOrEmpty(_reportOPtion))
            {
                MessageBox.Show("Plz. select an report option and try again."); return;
            }

            da = new SqlDataAdapter();
            DataSet dsDueList = new ReportService().GetDueList(dtpfrm.Value, dtpto.Value, _reportOPtion);
           
            //int c = dsReports.Tables[0].Rows.Count;

            RptDueList _dueList = new RptDueList();

            _dueList.SetDataSource(dsDueList.Tables[0]);

       

            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _dueList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _dueList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _dueList.SetParameterValue("reportheader", _reportHeader);

            rv.crviewer.ReportSource = _dueList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
