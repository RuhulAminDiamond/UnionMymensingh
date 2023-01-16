using HDMS.Model.Enums;
using HDMS.Model.HR;
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
    public partial class frmLeaveApplication : Form
    {
        public frmLeaveApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLeaveApplication_Load(object sender, EventArgs e)
        {
            LoadApplicantInfo();
        }

        private void LoadApplicantInfo()
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            EmployeeInfo _employeeInfo = new EmployeeService().GetEmployeeById(_user.EmployeeId);

            if (_employeeInfo != null)
            {
                EmpDepartment _empDept = new EmployeeService().GetDept(_employeeInfo.DeptId);
                EmpDesignation _empDesignation = new EmployeeService().GetDesignation(_employeeInfo.DesignationId);

                lblName.Text = _employeeInfo.EmployeeName;
                lblDept.Text = _empDept.Name;
                lblDesig.Text = _empDesignation.Name;

                lblName.Tag = _employeeInfo;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lblName.Tag != null)
            {
                LeaveApplication _lApp = new LeaveApplication();
                _lApp.EmployeeId = ((EmployeeInfo)lblName.Tag).EmployeeId;
                _lApp.AppDate = Utils.GetServerDateAndTime();
                _lApp.ApplicationTo = txtTo.Text;
                _lApp.ApplicationThrough = txtThrough.Text;
                _lApp.AppSubject = txtPurposeOfLeave.Text;
                _lApp.Application = txtApplication.Text;
                _lApp.Leavefrom = datefrm.Value;
                _lApp.Leaveto = dateto.Value;
                _lApp.ApprovalStatusLevel1 = LeaveAppStatusEnum.Pending.ToString();
                _lApp.ApprovalStatusLevel2 = LeaveAppStatusEnum.Pending.ToString();
                _lApp.ApprovalStatusLevel3 = LeaveAppStatusEnum.Pending.ToString();
                if (new HrCommonService().SaveLeaveApplication(_lApp))
                {
                    MessageBox.Show("Application send successfull");
                    lblName.Tag = null;
                    txtTo.Text = "";
                    txtPurposeOfLeave.Text = "";
                    txtApplication.Text = "";
                }
            }else
            {

            }
        }
    }
}
