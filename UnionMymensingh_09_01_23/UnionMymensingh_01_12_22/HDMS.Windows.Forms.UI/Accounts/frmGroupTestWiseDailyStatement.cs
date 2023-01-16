
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using HDMS.Model.Diagnostic;
using Services;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts;

namespace HDMS.Windows.Forms.UI.Accounts
{
   

    public partial class frmGroupTestWiseDailyStatement : Form
    {
        SqlDataAdapter da;
        public frmGroupTestWiseDailyStatement()
        {
            InitializeComponent();
        }

        public object ToolPanelViewType { get; private set; }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            da = new SqlDataAdapter();
            DataSet dsDueList = new ReportService().GetGroupwiseTestAmount(Convert.ToInt32( cmbParent.SelectedValue) , 0,dtpfrm.Value, dtpto.Value);

            //int c = dsReports.Tables[0].Rows.Count;
            string customFmts = "dd/MM/yyyy";
            ReportViewer rv = new ReportViewer();
            if (cmbParent.SelectedIndex == 0)
            {
                rptMasterTestGroupStatement _dueList = new rptMasterTestGroupStatement();
                _dueList.SetDataSource(dsDueList.Tables[0]);
                _dueList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
                _dueList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
                rv.crviewer.ReportSource = _dueList;
                rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
            else
            {
                DataTable dtList = new ReportService().GetTestGroupNameByMasterGroup(Convert.ToInt32(cmbParent.SelectedValue));
                if (dtList.Rows.Count == 8)
                {
                    rptTestGroupStatementColumn8 _dueList = new rptTestGroupStatementColumn8();
                    _dueList.SetDataSource(dsDueList.Tables[0]);
                    _dueList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
                    _dueList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

                   

                    for (int i=1;i<=8;i++)
                    {

                        _dueList.SetParameterValue("Column"+i.ToString(), dtList.Rows[i-1][1].ToString());
                    }

                    rv.crviewer.ReportSource = _dueList;
                    rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    rv.crviewer.PrintReport();
                    rv.Show();
                }

                else if (dtList.Rows.Count == 5)
                {
                    rptTestGroupStatementColumn5 _dueList = new rptTestGroupStatementColumn5();
                    _dueList.SetDataSource(dsDueList.Tables[0]);
                    _dueList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
                    _dueList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";



                    for (int i = 1; i <= 5; i++)
                    {

                        _dueList.SetParameterValue("Column" + i.ToString(), dtList.Rows[i - 1][1].ToString());
                    }

                    rv.crviewer.ReportSource = _dueList;
                    rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    rv.crviewer.PrintReport();
                    rv.Show();
                }

                else if (dtList.Rows.Count == 3)
                {
                    rptTestGroupStatementColumn3 _dueList = new rptTestGroupStatementColumn3();
                    _dueList.SetDataSource(dsDueList.Tables[0]);
                    _dueList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
                    _dueList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
                    for (int i = 1; i <= 3; i++)
                    {

                        _dueList.SetParameterValue("Column" + i.ToString(), dtList.Rows[i - 1][1].ToString());
                    }
                    rv.crviewer.ReportSource = _dueList;
                    rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    rv.crviewer.PrintReport();
                    rv.Show();
                }
                else if (dtList.Rows.Count == 2)
                {
                    rptTestGroupStatementColumn2 _dueList = new rptTestGroupStatementColumn2();
                    _dueList.SetDataSource(dsDueList.Tables[0]);
                    _dueList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
                    _dueList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
                    for (int i = 1; i <= 2; i++)
                    {

                        _dueList.SetParameterValue("Column" + i.ToString(), dtList.Rows[i - 1][1].ToString());
                    }
                    rv.crviewer.ReportSource = _dueList;
                    rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    rv.crviewer.PrintReport();
                    rv.Show();
                }
                else if (dtList.Rows.Count == 1)
                {
                    rptTestGroupStatementColumn1 _dueList = new rptTestGroupStatementColumn1();
                    _dueList.SetDataSource(dsDueList.Tables[0]);
                    _dueList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
                    _dueList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
                    for (int i = 1; i <= 1; i++)
                    {

                        _dueList.SetParameterValue("Column" + i.ToString(), dtList.Rows[i - 1][1].ToString());
                    }
                    rv.crviewer.ReportSource = _dueList;
                    rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    rv.crviewer.PrintReport();
                    rv.Show();
                }
            }
           



           
           
           

           
           


            return;
            /*scmdShow.Enabled = false;
            cmdShow.Text = "Please wait..";
            ReportViewer rv = new ReportViewer();
            rptDailyStatement _rpt = new rptDailyStatement();
            _rpt.SetDatabaseLogon("Syscom", "fm#s21928", "Server", "Diag", true);


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;


            _rpt.SetParameterValue("@startpDate", Fromdate.ToShortDateString());
            _rpt.SetParameterValue("@enddate", Todate.ToShortDateString());

            string customFmts = "dd/MM/yyyy";
            _rpt.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _rpt.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";


            Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            _rpt.SetParameterValue("companyName", _company.Name);
            _rpt.SetParameterValue("companyAddress", _company.Address);
            _rpt.SetParameterValue("companyPhoneNo", _company.PhoneNo);



            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Enabled = true;
            cmdShow.Text = "Show";
            */
        }

        private void frmGroupTestWiseDailyStatement_Load(object sender, EventArgs e)
        {
            PopulateGroupCombo();
        }

        private void PopulateGroupCombo()
        {
            List<MasterTestGroup> mList = new TestService().GetMasterGroups();
            mList.Insert(0, new MasterTestGroup() { MasterTestGroupId = 0, Name = "ALL Master Group" });
            cmbParent.DataSource = mList;
            cmbParent.DisplayMember = "Name";
            cmbParent.ValueMember = "MasterTestGroupId";
        }
    }
}
