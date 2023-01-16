using HDMS.Model.HR;
using HDMS.Service.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmManualAttendance : Form
    {
        public frmManualAttendance()
        {
            InitializeComponent();
        }

        private void frmManualAttendance_Load(object sender, EventArgs e)
        {

            LoadDepartments(0);

            LoadEmployess();
        }

        private void LoadDepartments(int _deptId)
        {
            List<EmpDepartment> deptList = new HrCommonService().GetAllDepartments().ToList();
            deptList.Insert(0, new EmpDepartment() { DeptId = 0, Name = "Select Dept." });
            cmbDept.DataSource = deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";

            if (_deptId > 0)
            {
                cmbDept.SelectedItem = deptList.Find(q => q.DeptId == _deptId);
            }
        }

        private void LoadEmployess()
        {
            List<VMEmployeeInfo> _empInfo = new EmployeeService().GetAll();
            FileEmpGrid(_empInfo);
        }

        private void FileEmpGrid(List<VMEmployeeInfo> _empList)
        {
            dgEmployee.SuspendLayout();
            dgEmployee.Rows.Clear();
            foreach (VMEmployeeInfo item in _empList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;


                row.CreateCells(dgEmployee, item.EmployeeName, item.DeptName, item.Designation,item.CL);
                dgEmployee.Rows.Add(row);


            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
