using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.HR;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Service.HR;
using HDMS.Model.HR.VM;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmIssueLoan : Form
    {
        public frmIssueLoan()
        {
            InitializeComponent();
        }

        private void frmIssueLoan_Load(object sender, EventArgs e)
        {
            ctlEmployeeSearchControl.Location = new Point(txtEmployee.Location.X, txtEmployee.Location.Y);
            ctlEmployeeSearchControl.ItemSelected += ctlEmployeeSearchControl_ItemSelected;

            LoadLoanInfo();
        }

        private void LoadLoanInfo()
        {
            List<VMLoanInfo> _loanList = new EmployeeService().GetAllLoans();
        }

        private void ctlEmployeeSearchControl_ItemSelected(SearchResultListControl<VMEmployeeInfo> sender, VMEmployeeInfo item)
        {
            txtEmployee.Text = item.EmployeeId.ToString();
            txtEmployee.Tag = item;
            txtName.Text = item.EmployeeName;
            txtDept.Text = item.DeptName;
            txtDesignation.Text = item.Designation;

            txtIssueAmount.Focus();

            sender.Visible = false;
        }

        private void txtEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlEmployeeSearchControl.Visible = true;
                ctlEmployeeSearchControl.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlEmployeeSearchControl.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployee.Tag != null)
            {
                int _startYear = 0;
                int.TryParse(cmbYear.Text, out _startYear);

                VMEmployeeInfo _empInfo = (VMEmployeeInfo)txtEmployee.Tag;

                double _issueAmount = 0;
                double.TryParse(txtIssueAmount.Text, out _issueAmount);

                int _NoOfInstallment = 0;
                int.TryParse(txtTotalInstallment.Text, out _NoOfInstallment);

                double _installmentAmount = 0;

                if (_issueAmount > 0 && _NoOfInstallment > 0)
                {

                    _installmentAmount = _issueAmount / _NoOfInstallment;
                    EmpLoanInfo _linfo = new EmpLoanInfo();
                    _linfo.EmployeeId = _empInfo.EmployeeId;
                    _linfo.IssueDate = Utils.GetServerDateAndTime();
                    _linfo.IssueAmount = _issueAmount;
                    _linfo.NoOfInstallment = _NoOfInstallment;
                    _linfo.AmountPerInstallment = _installmentAmount;
                    _linfo.InstallmentStartMonth = cmbMonth.Text;
                    _linfo.InstallmentStartYear = _startYear;

                    if(new EmployeeService().SaveLoanInfo(_linfo))
                    {
                        MessageBox.Show("Loan Issue Successful"); 
                        ClearFields();
                        return;
                    }

                }

                  

            }
        }

        private void ClearFields()
        {
            txtEmployee.Text = "";
            txtEmployee.Tag = null;
            txtName.Text = "";
        }

        private void txtTotalInstallment_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                double _issueAmount = 0;
                double.TryParse(txtIssueAmount.Text, out _issueAmount);

                int _NoOfInstallment = 0;
                int.TryParse(txtTotalInstallment.Text, out _NoOfInstallment);

                double _installmentAmount = 0;

                if (_issueAmount > 0 && _NoOfInstallment > 0)
                {
                    _installmentAmount = _issueAmount / _NoOfInstallment;
                    txtAmountPerInstallment.Text = _installmentAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Issue Amount and No of Installment required.");
                    return;
                }
            }
        }
    }
}
