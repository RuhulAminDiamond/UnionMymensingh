using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Services.POS;
using Models.Canteen;

namespace POS.Forms
{
    public partial class frmCantAddMember : Form
    {
        public frmCantAddMember()
        {
            InitializeComponent();
        }

        private void customerSaveButton_Click(object sender, EventArgs e)
        {

            if (txtCustomerName.Tag != null)
            {
                CantMemberInfo _member = (CantMemberInfo)txtCustomerName.Tag;

                _member.Name = txtCustomerName.Text;
                _member.Address = txtAdrees.Text;
                _member.MobileNo = txtMobile.Text;
                _member.CareOf = txtCareOf.Text;

                if (new CustomerServices().UpdateCustomer(_member))
                {
                    MessageBox.Show("Member updated successfully.");
                    LoadCustomerList();
                    ClearForm();
                }

            }
            else
            {

                CantMemberInfo customer = new CantMemberInfo();
                customer.Name = txtCustomerName.Text;
                customer.Address = txtAdrees.Text;
                customer.MobileNo = txtMobile.Text;
                customer.CareOf = txtCareOf.Text;

                if (new CustomerServices().AddNewCustomer(customer))
                {
                    MessageBox.Show("New Customer added successfully.");
                    LoadCustomerList();
                    ClearForm();
                }
            }

        }

        private void ClearForm()
        {
            txtCustomerName.Text = "";
            txtAdrees.Text = "";
            txtMobile.Text = "";
            txtCareOf.Text = "";
           

        }

        private void customerNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtAdrees.Focus();
            }
        }

        

        private void customerAdreesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtMobile.Focus();
            }
        }

        private void customerMobileTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtCareOf.Focus();
            }
        }

        private void customerPhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               
            }
        }

        private void customerEmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerUI_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        private void LoadCustomerList()
        {
            List<CantMemberInfo> cList = new CustomerServices().GetAllCustomer().ToList();
            FillListGrid(cList);
        }

        private void FillListGrid(List<CantMemberInfo> cList)
        {
            dgCustomers.SuspendLayout();
            dgCustomers.Rows.Clear();

            foreach (var customer in cList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = customer;
                row.CreateCells(dgCustomers,customer.MemberId,customer.Name,customer.Address,customer.MobileNo);
                dgCustomers.Rows.Add(row);
            }
        }

        private void dgCustomers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgCustomers.SelectedRows.Count > 0)
            {
                CantMemberInfo _member = dgCustomers.SelectedRows[0].Tag as CantMemberInfo;
                txtCustomerName.Text = _member.Name;
                txtAdrees.Text = _member.Address;
                txtMobile.Text = _member.MobileNo;
                txtCareOf.Text = _member.CareOf;

                txtCustomerName.Tag = _member;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtAdrees.Text = "";
            txtMobile.Text = "";
            txtCareOf.Text = "";

            txtCustomerName.Tag = null;
        }
    }
}
