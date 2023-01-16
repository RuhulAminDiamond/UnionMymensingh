using CrystalDecisions.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Repository.ServiceObjects;
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
    public partial class frmUserwisePatientReceiptStatement : Form
    {
        SqlDataAdapter da;
        private LoginUser _LoggedInUser { get; set; }
        public frmUserwisePatientReceiptStatement()
        {
            InitializeComponent();

            this._LoggedInUser = MainForm.LoggedinUser;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
            if (radIPD.Checked)
            {
                _reportOPtion = "IPD";
                _reportHeader = "IPD Received Statement";
            }
            else if (radOPD.Checked)
            {
                _reportOPtion = "OPD";
                _reportHeader = "OPD Received Statement";
            }
            else if (radAll.Checked)
            {
                _reportOPtion = "All";
                _reportHeader = "Patient Received Statement";
            }

            if (String.IsNullOrEmpty(_reportOPtion))
            {
                MessageBox.Show("Plz. select an report option and try again."); return;
            }


            User _u = (User)cmbUser.SelectedItem;

            da = new SqlDataAdapter();
            DataSet dsUserwisePatientWithOnEntryDatePaymentReceiptReport = new ReportService().GetUserWisePatientReceiptStatement(dtpfrm.Value, dtpto.Value, _u.LoginName, _reportOPtion);
             //int c = dsReports.Tables[0].Rows.Count;

            RptUserwisePatientWithOnEntryDateReceiptReport _pstatement = new RptUserwisePatientWithOnEntryDateReceiptReport();

            _pstatement.SetDataSource(dsUserwisePatientWithOnEntryDatePaymentReceiptReport.Tables[0]);


            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + cmbUser.Text + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[2].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _pstatement.SetParameterValue("ReportHeader", _reportHeader);


            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmUserwisePatientReceiptStatement_Load(object sender, EventArgs e)
        {
            List<User> _User = new UserService().GetAll();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "UserId";

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);


            if (_user.RoleId == 1 || _user.RoleId == 3)
            {

            }
            else
            {

                cmbUser.SelectedItem = _User.Find(q => q.UserId == MainForm.LoggedinUser.UserId);
                cmbUser.Enabled = false;
            }
        }
    }
}
