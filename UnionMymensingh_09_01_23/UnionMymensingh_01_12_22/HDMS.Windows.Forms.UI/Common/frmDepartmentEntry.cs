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
    public partial class frmDepartmentEntry : Form
    {
        bool isLoaded = false;

        public frmDepartmentEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                Department _dept = new Department();
                _dept.BusinessUnitId = Convert.ToInt32(cmbBusinessUnit.SelectedValue);
                _dept.Name = txtName.Text;
                _dept.ActivityNote = txtActivityNote.Text;
                _dept.Status = cmbStatus.Text;

                if(new CommonService().SaveDepartment(_dept))
                {
                    MessageBox.Show("Department created successfully.");
                    txtName.Text = "";
                    LoadDepartments();
                }else
                {
                    MessageBox.Show("Department creation failed.");
                }
            }
        }

        private void LoadDepartments()
        {
            List<Department> _lisDept = new CommonService().GetAllDepartment();
            
            dgvDepartments.AutoGenerateColumns = false;
            dgvDepartments.DataSource = _lisDept;
        }

        private void frmDepartmentEntry_Load(object sender, EventArgs e)
        {
            isLoaded = false;
            LoadDepartments();
            PopulateOrganization();
            isLoaded = true;
        }

        private void PopulateOrganization()
        {
            List<OrganizationInfo> OrgList = new CommonService().GetOrganizationList();
            OrgList.Insert(0, new OrganizationInfo() { OrgId = 0, Name = "Select Organization" });
            cmbOrganization.DataSource = OrgList;
            cmbOrganization.DisplayMember = "Name";
            cmbOrganization.ValueMember = "OrgId";

            //List<BusinessUnit> BU = new CommonService().GetbusinessUnit();
        }

        private void cmbOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                PopulateBusinessUnitCombo(Convert.ToInt32(cmbOrganization.SelectedValue));
            }
        }

        private void PopulateBusinessUnitCombo(int OrgId)
        {
            List<BusinessUnit> _bUnitList = new CommonService().GetbusinessUnitByOrgId(OrgId);
            _bUnitList.Insert(0, new BusinessUnit() { BusinessUnitId = 0, Name = "Select Business Unit" });
            cmbBusinessUnit.DataSource = _bUnitList;
            cmbBusinessUnit.DisplayMember = "Name";
            cmbBusinessUnit.ValueMember = "BusinessUnitId";
        }
    }
}
