using HDMS.Service.Diagonstics;
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using HDMS.Service.Doctors;
using HDMS.Model.Users;
using HDMS.Service;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmDiagPatientStatement : Form
    {
        SqlDataAdapter da;
        DataSet ds;
        WaitWnd.WaitWndFun waitForm = new WaitWnd.WaitWndFun();
        public frmDiagPatientStatement()
        {
            InitializeComponent();
        }

        private async void cmdShow_Click(object sender, EventArgs e)
        {
            waitForm.Show(this);
            cmdShow.Text = "Plz. Wait..";
            btnStatement.Enabled = false;
            btnCancelledPatient.Enabled = false;
            cmdShow.Enabled = false;


            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
            if (radIPD.Checked)
            {
                _reportOPtion = "IPD";
                _reportHeader = "IPD Collection Statement";
            }
            else if (radOPD.Checked)
            {
                _reportOPtion = "OPD";
                _reportHeader = "OPD Collection Statement";
            }
            else if (radAll.Checked)
            {
                _reportOPtion = "All";
                _reportHeader = "Collection Statement";
            }

            if (String.IsNullOrEmpty(_reportOPtion))
            {
                MessageBox.Show("Plz. select an report option and try again."); return;
            }


            //ds = new DataSet();
            //int _refdBy = 0;


            //ds = new ReportService().GetCollectionStatement(dtpfrm.Value, dtpto.Value, cmbUser.Text, _reportOPtion);

            DataSet results = await GetCollectionDatasetAsync(dtpfrm.Value, dtpto.Value, cmbUser.Text, _reportOPtion); //


            RptDiagPatientStatement _pstatement = new RptDiagPatientStatement();

            _pstatement.SetDataSource(results.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
           
                _pstatement.DataDefinition.FormulaFields[2].Text = "'" + "User Name :" + cmbUser.Text + "'";

            _pstatement.SetParameterValue("Dept", "");


            _pstatement.DataDefinition.FormulaFields[3].Text = "'" + _reportHeader + "'";
            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            waitForm.Close();
           
            rv.crviewer.PrintReport();
            rv.ShowDialog();

            cmdShow.Text = "Collec. Sheet";
            btnStatement.Enabled = true;
            btnCancelledPatient.Enabled = true;
            cmdShow.Enabled = true;


        }

        private async Task<DataSet> GetCollectionDatasetAsync(DateTime dtpfrm, DateTime dtpto, string _userName, string reportOPtion)
        {
            var _result = await new ReportService().GetDiagCollectionStatementDataSetAsync(dtpfrm, dtpto, _userName, reportOPtion);


            return _result;
        }

        private void txtRefdBy_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void HideAllDefaultHidden()
        {
           
        }

        private void frmDiagPatientStatement_Load(object sender, EventArgs e)
        {
           
            dtpfrm.Value = Utils.GetServerDateAndTime();
            dtpto.Value = Utils.GetServerDateAndTime();
            LoadUsers();


        }

        private void LoadUsers()
        {

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            List<User> _User = new List<User>();

            if (_user.RoleId == 1)
            {
                _User = new UserService().GetAll();
                _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "UserId";
                cmbUser.SelectedItem = _User.Find(q => q.UserId == MainForm.LoggedinUser.UserId);
                cmbUser.Enabled = true;

            }
            else if(_user.RoleId == 3 || _user.RoleId == 10)
            {
                _User = new UserService().GetUserByRoleId(4);
                _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "UserId";
            }
            else
            {
                _User = new UserService().GetAll();
                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "UserId";
                cmbUser.SelectedItem = _User.Find(q => q.UserId == MainForm.LoggedinUser.UserId);
                cmbUser.Enabled = false;
            }





        }

        private void ctlDoctorSearch_ItemSelected(UI.Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
           
            sender.Visible = false;
        }

        private void btnCancelledPatient_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            int _refdBy = 0;

           
            ds = new ReportService().GetCancelledPatientStatement(dtpfrm.Value, dtpto.Value, _refdBy);
           
            RptDiagPatientStatement _pstatement = new RptDiagPatientStatement();

            _pstatement.SetDataSource(ds.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
           
            _pstatement.DataDefinition.FormulaFields[3].Text = "'" + "Daily Patient Statement (Cancelled)" + "'";
            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private async void btnStatement_Click(object sender, EventArgs e)
        {
            btnStatement.Text = "Plz. Wait..";
            btnStatement.Enabled = false;
            btnCancelledPatient.Enabled = false;
            cmdShow.Enabled = false;

            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
            if (radIPD.Checked)
            {
                _reportOPtion = "IPD";
                _reportHeader = "IPD Patient Statement";
            }
            else if (radOPD.Checked)
            {
                _reportOPtion = "OPD";
                _reportHeader = "OPD Patient Statement";
            }
            else if (radAll.Checked)
            {
                _reportOPtion = "All";
                _reportHeader = "Patient Statement";
            }

            if (String.IsNullOrEmpty(_reportOPtion))
            {
                MessageBox.Show("Plz. select an report option and try again."); return;
            }


            //ds = new DataSet();
            //int _refdBy = 0;


            //ds = new ReportService().GetPatientStatement(dtpfrm.Value, dtpto.Value, cmbUser.Text, _reportOPtion);


            DataSet results = await GetDatasetAsync(dtpfrm.Value, dtpto.Value, cmbUser.Text, _reportOPtion); //
            
            RptDiagPatientStatement _pstatement = new RptDiagPatientStatement();

            _pstatement.SetDataSource(results.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _pstatement.DataDefinition.FormulaFields[2].Text = "'" + "User Name :" + cmbUser.Text + "'";

            _pstatement.SetParameterValue("Dept", "");
            _pstatement.DataDefinition.FormulaFields[3].Text = "'" + _reportHeader + "'";

            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            btnStatement.Text = "Statement";
            btnStatement.Enabled = true;
            btnCancelledPatient.Enabled = true;
            cmdShow.Enabled = true;
        }

        private async Task<DataSet> GetDatasetAsync(DateTime dtpfrm, DateTime dtpto, string _user, string reportOPtion)
        {

           var _result =  await new ReportService().GetDiagPatientStatementDataSetAsync(dtpfrm, dtpto, _user, reportOPtion);


            return  _result;
        }

        private void frmDiagPatientStatement_FormClosed(object sender, FormClosedEventArgs e)
        {
             
        }
    }
}
