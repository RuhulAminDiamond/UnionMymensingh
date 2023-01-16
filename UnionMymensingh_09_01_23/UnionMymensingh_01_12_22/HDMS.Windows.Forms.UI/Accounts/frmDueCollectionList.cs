using CrystalDecisions.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Service;
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
    public partial class frmDueCollectionList : Form
    {
        SqlDataAdapter da;
        public frmDueCollectionList()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            DataSet dsDueCollectionList = new ReportService().GetDueCollectionList(dtpfrm.Value, dtpto.Value, cmbUser.Text);
           
            //int c = dsReports.Tables[0].Rows.Count;

            RptDueCollectionList _rdcList = new RptDueCollectionList();

            _rdcList.SetDataSource(dsDueCollectionList.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _rdcList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _rdcList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _rdcList.SetParameterValue("Collectedby", "Collected by: "+cmbUser.Text);

            rv.crviewer.ReportSource = _rdcList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmDueCollectionList_Load(object sender, EventArgs e)
        {
            List<User> _User = new UserService().GetAll();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "Id";
        }
    }
}
