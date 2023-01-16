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
    public partial class frmStaffEntry : Form
    {
        public frmStaffEntry()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            EmpDepartment _dept = (EmpDepartment)cmbDept.SelectedItem;
            EmpDesignation _desig = (EmpDesignation)cmbDesignation.SelectedItem;

            if (_dept.DeptId == 0)
            {
                MessageBox.Show("Department not selected"); return;
            }

            if (_desig.DesignationId == 0)
            {
                MessageBox.Show("Designation not selected"); return;
            }

            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Employee name required.");
                return;
            }

            if (txtName.Tag != null)
            {
                


                VMEmployeeInfo _empInfo = (VMEmployeeInfo)txtName.Tag;

                EmployeeInfo _employee = new EmployeeService().GetEmployeeById(_empInfo.EmployeeId);

                _employee.EmployeeName = txtName.Text;
               

                _employee.DeptId = _dept.DeptId;
                _employee.DesignationId = _desig.DesignationId;

                

                if (new EmployeeService().UpdateEmployee(_employee))
                {
                    MessageBox.Show("Employee information updated successfully.");
                    txtName.Tag = null;

                }
            }
            else
            {

                    EmployeeInfo _emp = new EmployeeInfo();
                    _emp.EmployeeName = txtName.Text;
                 
                _emp.DeptId = _dept.DeptId;
                _emp.DesignationId = _desig.DesignationId;

               
              

                if (new EmployeeService().SaveStaffInfo(_emp))
                    {
                        MessageBox.Show("Employee info added successfully.");
                    }

                
            }
          
        }

        private void frmStaffEntry_Load(object sender, EventArgs e)
        {
            LoadDepartments(0);

            LoadDesignations(0);

            LoadEmployee();
        }

        private void LoadEmployee()
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
               

                row.CreateCells(dgEmployee, item.EmployeeId, item.EmployeeName, item.DeptName, item.Designation, item.JoiningDate);
                dgEmployee.Rows.Add(row);


            }

        }

        private void LoadDesignations(int _desigId)
        {
            List<EmpDesignation> desigList = new HrCommonService().GetDesignations().ToList();
            desigList.Insert(0, new EmpDesignation() { DesignationId = 0, Name = "Select Desination" });
            cmbDesignation.DataSource = desigList;
            cmbDesignation.DisplayMember = "Name";
            cmbDesignation.ValueMember = "Id";

            if (_desigId > 0)
            {
                cmbDesignation.SelectedItem = desigList.Find(q => q.DesignationId == _desigId);
            }
        }

        private void LoadDepartments(int _deptId)
        {
            List<EmpDepartment> deptList = new HrCommonService().GetDepartments().ToList();
            deptList.Insert(0, new EmpDepartment() { DeptId = 0, Name = "Select Desination" });
            cmbDept.DataSource = deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "Id";

            if (_deptId > 0)
            {
                cmbDept.SelectedItem = deptList.Find(q => q.DeptId == _deptId);
            }
        }

        private void dgEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMEmployeeInfo selectedEmployee = dgEmployee.SelectedRows[0].Tag as VMEmployeeInfo;

            txtName.Text = selectedEmployee.EmployeeName;

            LoadDepartments(selectedEmployee.DeptId);

            LoadDesignations(selectedEmployee.DesignationId);

            txtName.Tag = selectedEmployee;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Tag = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
