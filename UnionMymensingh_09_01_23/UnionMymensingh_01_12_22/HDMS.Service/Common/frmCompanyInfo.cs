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
    public partial class frmCompanyInfo : Form
    {
        public frmCompanyInfo()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtName.Tag !=null)
            {
                CompanyInfo _CInfo = new CommonService().GetCompanyById(((CompanyInfo)txtName.Tag).CompanyId);
                if (!string.IsNullOrEmpty(txtName.Text) && _CInfo != null)
                {
                    _CInfo.Name = txtName.Text;
                    _CInfo.ShortName = txtShortName.Text;
                    _CInfo.Address = txtAddress.Text;
                    _CInfo.MobileNo = txtMobile.Text;
                    _CInfo.PhoneNo = txtPhoneNo.Text;
                    _CInfo.Email = txtEmail.Text;
                    _CInfo.Website = txtWebSite.Text;
                    if(new CommonService().UpdateCompanyInfo(_CInfo))
                    {
                        MessageBox.Show("Data Update Successful.");
                        txtName.Text = "";
                        txtShortName.Text = "";
                        txtAddress.Text = "";
                        txtMobile.Text = "";
                        txtPhoneNo.Text = "";
                        txtEmail.Text = "";
                        txtWebSite.Text = "";
                        txtName.Tag = null;
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        LoadCompanyInfo();
                    }
                    else
                    {
                        MessageBox.Show("Data Update Failed.");
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(txtName.Text))
                {

                    CompanyInfo CInfo = new CompanyInfo();
                    CInfo.Name = txtName.Text;
                    CInfo.ShortName = txtShortName.Text;
                    CInfo.Address = txtAddress.Text;
                    CInfo.MobileNo = txtMobile.Text;
                    CInfo.PhoneNo = txtPhoneNo.Text;
                    CInfo.Email = txtEmail.Text;
                    CInfo.Website = txtWebSite.Text;
                    if (new CommonService().SaveCompany(CInfo))
                    {
                        MessageBox.Show("Data Saved Successful.");
                        LoadCompanyInfo();
                        txtName.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Saved Failed.");
                    }

                }
                else
                {
                    MessageBox.Show("Must Value Entry.");
                }
            }
        }

        private void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            LoadCompanyInfo();
        }

        private void LoadCompanyInfo()
        {
            List<CompanyInfo> CInfo = new CommonService().GetCompany();
            dgCompanyInfo.AutoGenerateColumns = false;
            dgCompanyInfo.DataSource = CInfo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgCompanyInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CompanyInfo _gr = new CommonService().GetCompanyById(Convert.ToInt32(dgCompanyInfo.Rows[e.RowIndex].Cells["CompanyId"].Value));
            if (_gr != null)
            {
                txtName.Text = _gr.Name;
                txtName.Tag = _gr;
                txtShortName.Text = _gr.ShortName;
                txtAddress.Text = _gr.Address;
                txtMobile.Text = _gr.MobileNo;
                txtPhoneNo.Text = _gr.PhoneNo;
                txtEmail.Text = _gr.Email;
                txtWebSite.Text = _gr.Website;
              
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
        }
    }
}
