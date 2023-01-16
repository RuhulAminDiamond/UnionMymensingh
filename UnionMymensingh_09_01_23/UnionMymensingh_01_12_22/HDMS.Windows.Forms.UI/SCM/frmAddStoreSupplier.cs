using HDMS.Model.Common;
using HDMS.Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmAddStoreSupplier : Form
    {
        public frmAddStoreSupplier()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtName.Text))
            {
                SupplierInfo _sInfo = new SupplierInfo();
                _sInfo.Name = txtName.Text;
                _sInfo.ContactPerson = txtContactPerson.Text;
                _sInfo.CpMobileNo = txtMobileNo.Text;
                _sInfo.CpEmail = txtEmail.Text;
                _sInfo.Category = cmbCategory.Text;

                if(new CommonService().AddSupplier(_sInfo))
                {
                    MessageBox.Show("Supplier added successfully");
                    ClearFields();
                }
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtContactPerson.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            cmbCategory.Text = "";
        }

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
