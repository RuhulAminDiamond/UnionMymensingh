using HDMS.Model.Enums;
using HDMS.Model.HR;
using HDMS.Model.HR.VM;
using HDMS.Model.Users;
using HDMS.Service;
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
    public partial class frmLeaveManagement : Form
    {
        public frmLeaveManagement()
        {
            InitializeComponent();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgEmployee.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgEmployee.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void frmLeaveManagement_Load(object sender, EventArgs e)
        {
            LoadLeaveApplicationList(LeaveAppStatusEnum.Pending.ToString());
        }

        private void LoadLeaveApplicationList(string _applicationStatus)
        {
            int _deptId = 0;

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            EmployeeInfo _empInfo = new EmployeeInfo();

            if (_user.RoleId != 40 && _user.EmployeeId>0)
            {
                 _empInfo = new EmployeeService().GetEmployeeById(_user.EmployeeId);
                _deptId = _empInfo.DeptId;

            }else if (_user.RoleId == 40)
            {
                 _empInfo = new EmployeeService().GetEmployeeById(_user.EmployeeId);
                _deptId = _empInfo.DeptId;
            }

            List<VMLeaveApplication> _leavAppList = new HrCommonService().GetLeaveApplicationList(_applicationStatus, _deptId, _empInfo);
            FillLeaveGrid(_leavAppList);
        }

        private void FillLeaveGrid(List<VMLeaveApplication> _leavAppList)
        {
            dgEmployee.SuspendLayout();
            dgEmployee.Rows.Clear();

            foreach(var item in _leavAppList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgEmployee, item.EmployeeId, item.EmployeeName, item.DeptName, item.Designation, item.ApprovalLevel1, item.ApprovalLevel3);
                dgEmployee.Rows.Add(row);
            }
        }

        private void dgEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgEmployee.Rows.Count > 0)
            {
                int _clExp = 0;

                VMLeaveApplication _lApp = dgEmployee.SelectedRows[0].Tag as VMLeaveApplication;
                txtPurposeOfLeave.Text = _lApp.AppSubject;
                txtApplication.Text = _lApp.Application;
                lblDatefrm.Text = _lApp.Leavefrom.ToString("dd/MM/yyyy");
                lblDateto.Text = _lApp.Leaveto.ToString("dd/MM/yyyy");
                lblTotalCL.Text = _lApp.CL.ToString();
                lblCLExp.Text = new HrCommonService().GetCLExpense(_lApp.EmployeeId,Utils.GetServerDateAndTime().Year);

                int.TryParse(lblCLExp.Text,out _clExp);

                lblCLRemains.Text = (_lApp.CL - _clExp).ToString();

                TimeSpan difference = _lApp.Leaveto - _lApp.Leavefrom;

                lblTotaldays.Text = difference.Days.ToString();

                txtApplication.Tag = _lApp;

            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if (_user.RoleId != 40 && _user.EmployeeId > 0)
            {
                EmployeeInfo _empInfo = new EmployeeService().GetEmployeeById(_user.EmployeeId);

                if (txtApplication.Tag != null)
                {
                    VMLeaveApplication _lapp = (VMLeaveApplication)txtApplication.Tag;

                    LeaveApplication leaveapp = new HrCommonService().GetLeaveApplicationById(_lapp.ApplicationId);
                    leaveapp.ApprovalStatusLevel1= LeaveAppStatusEnum.Approved.ToString();
                    new HrCommonService().UpdateLeaveApplication(leaveapp);
                    MessageBox.Show("Approval Successful");
                    LoadLeaveApplicationList(LeaveAppStatusEnum.Pending.ToString());
                }
                
            }if(_user.RoleId == 40 && _user.EmployeeId > 0)
            {
                VMLeaveApplication _lapp = (VMLeaveApplication)txtApplication.Tag;

                LeaveApplication leaveapp = new HrCommonService().GetLeaveApplicationById(_lapp.ApplicationId);
                leaveapp.ApprovalStatusLevel3 = LeaveAppStatusEnum.Approved.ToString();
                new HrCommonService().UpdateLeaveApplication(leaveapp);
                MessageBox.Show("Approval Successful");
                LoadLeaveApplicationList(LeaveAppStatusEnum.Pending.ToString());

            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

        }
    }
}
