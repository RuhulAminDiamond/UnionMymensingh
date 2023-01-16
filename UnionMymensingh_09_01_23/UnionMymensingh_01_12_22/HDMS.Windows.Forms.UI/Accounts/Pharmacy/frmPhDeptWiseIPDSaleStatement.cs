using CrystalDecisions.Windows.Forms;
using HDMS.Model.Hospital;
using HDMS.Model.Users;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Service.Hospital;
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
    public partial class frmPhDeptWiseIPDSaleStatement : Form
    {
        public frmPhDeptWiseIPDSaleStatement()
        {
            InitializeComponent();
        }

        private void frmPhDeptWiseIPDSaleStatement_Load(object sender, EventArgs e)
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

            LoadPharmacist();
        }

        private void LoadPharmacist()
        {
            List<User> _User = new UserService().GetAllPharmacist();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "UserId";
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

        private void cmdShow_Click(object sender, EventArgs e)
        {

            ShowIPDSaleStatement();
            
        }


        private void ShowIPDSaleStatement()
        {
            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;

            string _department = string.Empty;


            _reportOPtion = "IPD";
            _reportHeader = "Pharmacy IPD Sale Statement";
            _department = "Department Name: ";

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;

            if (_dept.DeptId == 0)
            {
                _department = _department + "All";
            }
            else
            {
                _department = _department + _dept.Name;
            }


            string _user = string.Empty;
            if (cmbUser.Text.ToLower() == "all")
            {
                _user = "";
            }
            else
            {
                _user = cmbUser.Text;
            }


            DataSet dsSales = new PhReportingService().GetPhDeptWiseIPDaleStatement(dtpfrm.Value, dtpto.Value, _user, _reportOPtion, _dept.DeptId);

            rptPhIPDSaleStatement _phstatement = new rptPhIPDSaleStatement();

            _phstatement.SetDataSource(dsSales.Tables[0]);


            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _phstatement.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _phstatement.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _phstatement.SetParameterValue("reporttitle", _reportHeader);
            _phstatement.SetParameterValue("Dept", _department);

            rv.crviewer.ReportSource = _phstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

    }
}
