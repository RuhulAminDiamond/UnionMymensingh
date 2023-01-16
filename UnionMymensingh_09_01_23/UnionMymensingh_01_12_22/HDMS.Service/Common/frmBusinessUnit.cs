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
    public partial class frmBusinessUnit : Form
    {
        public frmBusinessUnit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BusinessUnit BU = new BusinessUnit();
            BU.Name = txtName.Text;
            BU.OrgId = Convert.ToInt32(cmbOrganization.SelectedValue);
            if(new CommonService().SaveBusinessUnit(BU))
            {
                MessageBox.Show("Data Saved");
                txtName.Text = "";
                LoadBusinessUnits();
            }else
            {
                MessageBox.Show("Data Save Failed.");
            }
        }

        private void LoadBusinessUnits()
        {
            List<BusinessUnit> _bUnitList = new CommonService().GetbusinessUnit();
            dgBUnits.AutoGenerateColumns = false;
            dgBUnits.DataSource = _bUnitList;

        }

        private void frmBusinessUnit_Load(object sender, EventArgs e)
        {
            LoadBusinessUnits();
            PopulateOranizetion();
        }

        private void PopulateOranizetion()
        {
            List<OrganizationInfo> OInfo = new CommonService().GetOrganizationList();
            OInfo.Insert(0, new OrganizationInfo() { OrgId = 0, Name = "Select Organization" });
            cmbOrganization.DataSource = OInfo;
            cmbOrganization.DisplayMember = "Name";
            cmbOrganization.ValueMember = "OrgId";
        }

      
    }
}
