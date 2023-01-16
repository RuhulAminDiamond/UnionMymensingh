using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmHospitalServiceGroupCreate : Form
    {
        public frmHospitalServiceGroupCreate()
        {
            InitializeComponent();
        }

        private void frmServ_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Tag != null)
            {


            }
            else
            {

                if (!String.IsNullOrEmpty(txtGroupName.Text))
                {
                    ServiceGroup _sGroup = new ServiceGroup();
                    _sGroup.Name = txtGroupName.Text;
                    if (new HospitalService().CreateServiceGroup(_sGroup))
                    {

                    }
                }
            }
        }

        private void frmHospitalServiceGroupCreate_Load(object sender, EventArgs e)
        {
            LoadServiceGroups(0);
            LoadServiceSubGroups();
        }

        private void LoadServiceSubGroups()
        {
            List<ServiceSubGroup> _ssgList = new HospitalService().getServiceSubGroups();
            dgServiceSubGroups.AutoGenerateColumns = false;
            dgServiceSubGroups.DataSource = _ssgList;

        }

        private void LoadServiceGroups(int _groupId)
        {
            List<ServiceGroup> _sgList = new HospitalService().getServiceGroups();
            dgGroups.AutoGenerateColumns = false;
            dgGroups.DataSource = _sgList;

            List<ServiceGroup> _sgList2 = new HospitalService().getServiceGroups();
            _sgList2.Insert(0, new ServiceGroup { GroupId = 0, Name = "Select Group" });
             cmbGroups.DataSource = _sgList2;
            cmbGroups.DisplayMember = "Name";
            cmbGroups.ValueMember =   "GroupId";

            if (_groupId > 0)
            {
                cmbGroups.SelectedItem = _sgList2.Find(q => q.GroupId == _groupId);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBedSave_Click(object sender, EventArgs e)
        {
            if (txtSubGroupNamme.Tag != null)
            {

                ServiceSubGroup _ssgroup = (ServiceSubGroup)txtSubGroupNamme.Tag;
                _ssgroup.GroupId = Convert.ToInt32(cmbGroups.SelectedValue);
                _ssgroup.Name = txtSubGroupNamme.Text;

                if (new HospitalService().UpdateHpSubGroup(_ssgroup))
                {
                    MessageBox.Show("Service sub group updated successfully.");
                    txtGroupName.Text = "";
                    txtGroupName.Tag = null;

                    LoadServiceGroups(0);
                    LoadServiceSubGroups();
                    btnSave.Text = "Save";
                }

            }
            else
            {
                ServiceSubGroup _ssgroup = new ServiceSubGroup();
                _ssgroup.GroupId = Convert.ToInt32(cmbGroups.SelectedValue);
                _ssgroup.Name = txtSubGroupNamme.Text;

                if (new HospitalService().SaveHpSubGroup(_ssgroup))
                {
                    MessageBox.Show("Service sub group created successfully.");
                    txtGroupName.Text = "";
                    txtGroupName.Tag = null;
                    LoadServiceGroups(0);
                    LoadServiceSubGroups();
                    btnSave.Text = "Save";
                }
            }
        }

        private void dgGroups_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ServiceGroup _cf = new HospitalService().GetServiceById(Convert.ToInt32(dgGroups.Rows[e.RowIndex].Cells["GroupId"].Value));
            txtGroupName.Text = _cf.Name;
            txtGroupName.Tag = _cf;

            btnSave.Text = "Update";
           
        }

        private void dgServiceSubGroups_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ServiceSubGroup _cf = new HospitalService().GetServiceSubGroupById(Convert.ToInt32(dgServiceSubGroups.Rows[e.RowIndex].Cells["SubGroupId"].Value));
            txtSubGroupNamme.Text = _cf.Name;
            txtSubGroupNamme.Tag = _cf;

            LoadServiceGroups(_cf.GroupId);

            btnBedSave.Text = "Update";
            btnBedCancel.Visible = true;
            btnDeleteSubGroup.Visible = true;
        }

        private void btnBedCancel_Click(object sender, EventArgs e)
        {
            txtSubGroupNamme.Text = "";
            txtSubGroupNamme.Tag = null;
            btnBedCancel.Visible = false;
            btnDeleteSubGroup.Visible = false;

            btnBedSave.Text = "Save";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSubGroup_Click(object sender, EventArgs e)
        {

        }
    }
}
