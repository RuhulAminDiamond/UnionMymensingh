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
    public partial class frmOrganigationInfo : Form
    {
        public frmOrganigationInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtShortName.Tag !=null)
            {
                OrganizationInfo _OrgInfo = new CommonService().GetOrganizationById(((OrganizationInfo)txtShortName.Tag).OrgId);

                _OrgInfo.Name = txtShortName.Text;
                _OrgInfo.ShortName = txtShortName.Text;
                _OrgInfo.CompanyId = Convert.ToInt32(cmbCompany.SelectedValue);

                if (!string.IsNullOrEmpty(txtShortName.Text) && _OrgInfo != null)
                {
                    if(new CommonService().UpdateOrgInfo(_OrgInfo))
                    {
                        MessageBox.Show("Data Updated.");
                        txtName.Tag = null;
                        LoadOrganization();
                    }
                }
            }
            else
            {
                OrganizationInfo OInfo = new OrganizationInfo();
                OInfo.Name = txtName.Text;
                OInfo.ShortName = txtShortName.Text;
                OInfo.CompanyId = Convert.ToInt32(cmbCompany.SelectedValue);

                if (new CommonService().SaveOrganizeInfo(OInfo))
                {
                    MessageBox.Show("Data Saved.");
                    LoadOrganization();
                    txtName.Text = "";
                    txtShortName.Text = "";
                }
                else
                {
                    MessageBox.Show("Save Failed.");
                }
            }
        }

        private void frmOrganigationInfo_Load(object sender, EventArgs e)
        {
            PopulatCompanyCombo(0);
            LoadOrganization();
        }

        private void LoadOrganization()
        {
            List<OrganizationInfo> OrgInfo = new CommonService().GetOrganizationList();
            dgOrganozation.AutoGenerateColumns = false;
            dgOrganozation.DataSource = OrgInfo;
        }

        private void PopulatCompanyCombo(int _CId)
        {
            List<CompanyInfo> CList = new CommonService().GetCompany();
            CList.Insert(0, new CompanyInfo() { CompanyId = 0, Name = "Select Company" });
            cmbCompany.DataSource = CList;
            cmbCompany.DisplayMember = "Name";
            cmbCompany.ValueMember = "CompanyId";

            if (_CId > 0)
            {
                cmbCompany.SelectedItem = CList.Find(x => x.CompanyId == _CId);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void dgOrganozation_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OrganizationInfo _OrgInfo = new CommonService().GetOrganizationById(Convert.ToInt32(dgOrganozation.Rows[e.RowIndex].Cells["OrgId"].Value));
            if (_OrgInfo != null)
            {
                txtName.Text = _OrgInfo.Name;
                txtName.Tag = _OrgInfo;
                txtShortName.Text = _OrgInfo.ShortName;
                PopulatCompanyCombo(_OrgInfo.CompanyId);
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
