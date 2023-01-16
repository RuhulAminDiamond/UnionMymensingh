using CrystalDecisions.Windows.Forms;
using HDMS.Model.Hospital;
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
    public partial class frmDischargedPatientStatement : Form
    {
        SqlDataAdapter da;

        public frmDischargedPatientStatement()
        {
            InitializeComponent();
        }

        private void frmDischargedPatientStatement_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

            LoadDepartments();
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });


            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";
        }

        private void cmdShow_Click(object sender, EventArgs e)
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
            DataSet dsReports = new HpFinancialService().GetDischargedPatient(dtpfrm.Value, dtpto.Value, _dept.DeptId);

            //int c = dsReports.Tables[0].Rows.Count;

            rptHpDischargedBillStatement _dischargeList = new rptHpDischargedBillStatement();

            _dischargeList.SetDataSource(dsReports.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _dischargeList.SetParameterValue("reportTitle", "Discharged Patient List");
            _dischargeList.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _dischargeList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _dischargeList.SetParameterValue("department", _deptName);

            rv.crviewer.ReportSource = _dischargeList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowAllByAdmisison_Click(object sender, EventArgs e)
        {
           
        }
    }
}
