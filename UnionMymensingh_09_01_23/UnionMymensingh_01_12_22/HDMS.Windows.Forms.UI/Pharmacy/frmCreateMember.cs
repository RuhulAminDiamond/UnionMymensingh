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
using HDMS.Model.Common;
using HDMS.Service.Pharmacy;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmCreateMember : Form
    {
        public frmCreateMember()
        {
            InitializeComponent();
        }

        private void frmCreateMember_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();
            ctlEmployeeSearchControl.Location = new Point(txtEmployee.Location.X, txtEmployee.Location.Y);
            ctlEmployeeSearchControl.ItemSelected += ctlEmployeeSearchControl_ItemSelected;

            txtEmployee.Enabled = false;

            LoadMembers();
        }

        private void ctlEmployeeSearchControl_ItemSelected(SearchResultListControl<VMEmployeeInfo> sender, VMEmployeeInfo item)
        {
            txtEmployee.Text = item.EmployeeId.ToString();
            txtEmployee.Tag = item;
            txtCustomerName.Text = item.EmployeeName;
            txtMobile.Text = item.MobileNo;
            txtAdrees.Text = item.Address;

            txtCustomerName.Focus();

            sender.Visible = false;
        }

        private void cmbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMembershipType.Text == "Employee")
            {
                txtEmployee.Enabled = true;
                txtEmployee.Focus();

            }else
            {
                txtEmployee.Enabled = false;
                cmbMembershipType.Focus();
            }
        }

        private void txtMember_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            long _employeeId = 0;
            if(txtEmployee.Tag != null)
            {
                _employeeId = ((VMEmployeeInfo)txtEmployee.Tag).EmployeeId;
            }


            if (String.IsNullOrEmpty(cmbMembershipType.Text))
            {
                MessageBox.Show("Membership Type Required.");
                cmbMembershipType.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Name required."); return;
            }

            PhMemberInfo _memInfo = new PhMemberInfo();
            _memInfo.EmployeeId = _employeeId;
            _memInfo.MembershipCategory = cmbMembershipType.Text;
            _memInfo.Name = txtCustomerName.Text;
            _memInfo.MobileNo = txtMobile.Text;
            _memInfo.Address = txtAdrees.Text;
            _memInfo.Remarks = txtCareOf.Text;

            if(new PhFinancialService().SavePhMemberInfo(_memInfo))
            {
                MessageBox.Show("New member created successfully.");
                LoadMembers();
            }
        }

        private void LoadMembers()
        {
            List<PhMemberInfo> cList = new PhFinancialService().GetAllMember().ToList();
            FillListGrid(cList);
        }

        private void FillListGrid(List<PhMemberInfo> cList)
        {
            dgCustomers.SuspendLayout();
            dgCustomers.Rows.Clear();

            foreach (var customer in cList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = customer;
                row.CreateCells(dgCustomers, customer.MemberId, customer.Name, customer.MembershipCategory,customer.Address, customer.MobileNo);
                dgCustomers.Rows.Add(row);
            }
        }

        private void ctlEmployeeSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtEmployee.Focus();
            }
        }
    }
}
