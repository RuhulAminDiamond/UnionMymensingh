using CrystalDecisions.Windows.Forms;
using HDMS.Model.Hospital;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
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

namespace HDMS.Windows.Forms.UI.Accounts.MIS
{
    public partial class frmhpdialycollection : Form
    {
        SqlDataAdapter da;

        public frmhpdialycollection()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            string _deptName = string.Empty;

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;


            if (_dept.DeptId == 0)
            {
                _deptName = "All";
            }else
            {
                _deptName = _dept.Name;
            }


            da = new SqlDataAdapter();
            DataSet dsDailyC = new HpFinancialService().GetHpDailyCollection(dtpfrm.Value, dtpto.Value, _dept.DeptId);

            //int c = dsReports.Tables[0].Rows.Count;

            rptHpDailyCollection _collecList = new rptHpDailyCollection();

            _collecList.SetDataSource(dsDailyC.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _collecList.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _collecList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _collecList.SetParameterValue("department", _deptName); 
            _collecList.SetParameterValue("Collectionby","");

            rv.crviewer.ReportSource = _collecList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmhpdialycollection_Load(object sender, EventArgs e)
        {
            LoadDepartments();

            LoadUsers();
        }

        private void LoadUsers()
        {
            List<User> _User = new UserService().GetAll();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "Id";
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });


            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";
        }



        private void btnShowByUser_Click(object sender, EventArgs e)
        {

            string _deptName = string.Empty;

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;


            if (_dept.DeptId == 0)
            {
                _deptName = "All";
            }
            else
            {
                _deptName = _dept.Name;
            }


            da = new SqlDataAdapter();
            DataSet dsDailyC = new HpFinancialService().GetHpDailyCollection_2(dtpfrm.Value, dtpto.Value, cmbUser.Text,_dept.DeptId);

            //int c = dsReports.Tables[0].Rows.Count;

            rptHpDailyCollection_2 _collecList = new rptHpDailyCollection_2();

            _collecList.SetDataSource(dsDailyC.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _collecList.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _collecList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _collecList.SetParameterValue("Collectionby", cmbUser.Text);
            _collecList.SetParameterValue("department", _deptName);

            // _collecList.SetParameterValue("Collectedby", "Collected by: " + cmbUser.Text);

            rv.crviewer.ReportSource = _collecList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnIPD_Click(object sender, EventArgs e)
        {
            string _deptName = string.Empty;

            _deptName = "IPD";

            da = new SqlDataAdapter();
            DataSet dsDailyC = new HpFinancialService().GetHpDailyCollection_IPD(dtpfrm.Value, dtpto.Value, cmbUser.Text, 15);

            //int c = dsReports.Tables[0].Rows.Count;

            rptHpDailyCollection_2 _collecList = new rptHpDailyCollection_2();

            _collecList.SetDataSource(dsDailyC.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _collecList.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _collecList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _collecList.SetParameterValue("Collectionby", cmbUser.Text);
            _collecList.SetParameterValue("department", _deptName);

            // _collecList.SetParameterValue("Collectedby", "Collected by: " + cmbUser.Text);

            rv.crviewer.ReportSource = _collecList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnOPD_Click(object sender, EventArgs e)
        {
            string _deptName = string.Empty;

            _deptName = "OPD";

            da = new SqlDataAdapter();
            DataSet dsDailyC = new HpFinancialService().GetHpDailyCollection_OPD(dtpfrm.Value, dtpto.Value, cmbUser.Text, 15);

            //int c = dsReports.Tables[0].Rows.Count;

            rptHpDailyCollection_2 _collecList = new rptHpDailyCollection_2();

            _collecList.SetDataSource(dsDailyC.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _collecList.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _collecList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _collecList.SetParameterValue("Collectionby", cmbUser.Text);
            _collecList.SetParameterValue("department", _deptName);

            // _collecList.SetParameterValue("Collectedby", "Collected by: " + cmbUser.Text);

            rv.crviewer.ReportSource = _collecList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewestReport_Click(object sender, EventArgs e)
        {
            string _deptName = string.Empty;

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;


            if (_dept.DeptId == 0)
            {
                _deptName = "All";
            }
            else
            {
                _deptName = _dept.Name;
            }


            da = new SqlDataAdapter();
            DataSet dsDailyC = new HpFinancialService().GetHpDailyCollection_3(dtpfrm.Value, dtpto.Value, cmbUser.Text, _dept.DeptId);

            //int c = dsReports.Tables[0].Rows.Count;

            rptHpDailyCollection_3 _collecList = new rptHpDailyCollection_3();

            _collecList.SetDataSource(dsDailyC.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _collecList.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _collecList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _collecList.SetParameterValue("Collectionby", cmbUser.Text);
            _collecList.SetParameterValue("department", _deptName);

            // _collecList.SetParameterValue("Collectedby", "Collected by: " + cmbUser.Text);

            rv.crviewer.ReportSource = _collecList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
