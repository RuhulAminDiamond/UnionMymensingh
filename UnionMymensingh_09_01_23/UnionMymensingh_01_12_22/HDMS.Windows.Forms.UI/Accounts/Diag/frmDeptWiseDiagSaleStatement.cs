using CrystalDecisions.Windows.Forms;
using HDMS.Model.Hospital;
using HDMS.Model.Users;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmDeptWiseDiagSaleStatement : Form
    {
        public frmDeptWiseDiagSaleStatement()
        {
            InitializeComponent();
        }

        private void frmDeptWiseDiagSaleStatement_Load(object sender, EventArgs e)
        {
            LoginUser _user = MainForm.LoggedinUser;
            User _userd = new UserService().GetUserById(_user.UserId);

            if (_userd.RoleId == 39)
            {
                LoadDepartments(_userd.DeptId);
            }
            else
            {
                LoadDepartments(0);
            }

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

            }
            else if (_user.RoleId == 3 || _user.RoleId == 10)
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

        private void LoadDepartments(int _deptId)
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });


            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";


            if (_deptId > 0)
            {
                cmbDept.SelectedItem = _deptList.Find(q => q.DeptId == _deptId);
                cmbDept.Enabled = false;
            }

        }

        private void btnStatement_Click(object sender, EventArgs e)
        {
            btnStatement.Text = "Plz. Wait..";
            btnStatement.Enabled = false;

            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;


            string _deptName = "Department Name: " ;
           
             _reportOPtion = "IPD";
            _reportHeader = "IPD Patient Statement";

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;

            if (_dept.DeptId == 0)
            {
                _deptName = _deptName + "All";

            }else
            {
                _deptName = _deptName + cmbDept.Text;
            }
           

            if (String.IsNullOrEmpty(_reportOPtion))
            {
                MessageBox.Show("Plz. select an report option and try again."); return;
            }


            DataSet ds = new DataSet();
            int _refdBy = 0;


            ds = new ReportService().GetDiagDeptWisePatientStatement(dtpfrm.Value, dtpto.Value, cmbUser.Text, _reportOPtion, _dept.DeptId);

            RptDiagIPDPatientStatement _pstatement = new RptDiagIPDPatientStatement();

            _pstatement.SetDataSource(ds.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _pstatement.DataDefinition.FormulaFields[2].Text = "'" + "User Name :" + cmbUser.Text + "'";


            _pstatement.DataDefinition.FormulaFields[3].Text = "'" + _reportHeader + "'";

            _pstatement.SetParameterValue("Dept",_deptName);

            rv.crviewer.ReportSource = _pstatement;
             rv.crviewer.ToolPanelView = ToolPanelViewType.None;
             rv.crviewer.PrintReport();
             rv.Show();

             btnStatement.Text = "Statement";
             btnStatement.Enabled = true;
        }
    }
}
