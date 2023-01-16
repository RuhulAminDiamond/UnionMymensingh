using HDMS.Model.Hospital;
using HDMS.Model.OPD;
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
    public partial class frmOPDServiceGroupCreate : Form
    {
        public frmOPDServiceGroupCreate()
        {
            InitializeComponent();
        }

        private void frmOPDServiceGroupCreate_Load(object sender, EventArgs e)
        {
            LoadServiceSubGroups();
            LoadServiceGroups(0);
        }

        private void LoadServiceSubGroups()
        {
            List<OPDServiceSubGroup> _ssgList = new HospitalService().getOpdServiceSubGroups();
            dgServiceSubGroups.AutoGenerateColumns = false;
            dgServiceSubGroups.DataSource = _ssgList;

        }

        private void LoadServiceGroups(int _groupId)
        {
            List<OPDServiceGroup> _sgList = new HospitalService().getOpdServiceGroups();
            dgGroups.AutoGenerateColumns = false;
            dgGroups.DataSource = _sgList;

            List<OPDServiceGroup> _sgList2 = new HospitalService().getOpdServiceGroups();
            _sgList2.Insert(0, new OPDServiceGroup { GroupId = 0, Name = "Select Group" });
            cmbGroups.DataSource = _sgList2;
            cmbGroups.DisplayMember = "Name";
            cmbGroups.ValueMember = "GroupId";

            if (_groupId > 0)
            {
                cmbGroups.SelectedItem = _sgList2.Find(q => q.GroupId == _groupId);
            }

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
                    OPDServiceGroup _sGroup = new OPDServiceGroup();
                    _sGroup.Name = txtGroupName.Text;
                    _sGroup.CreateDate = Utils.GetServerDateAndTime();
                    _sGroup.Modifieddate= Utils.GetServerDateAndTime();
                    if (new HospitalService().CreateOPDServiceGroup(_sGroup))
                    {
                        MessageBox.Show("OPD Service Group Created Successfully.");
                        txtGroupName.Text = "";
                        LoadServiceSubGroups();
                        LoadServiceGroups(0);
                    }
                }
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

                OPDServiceSubGroup _ssgroup = (OPDServiceSubGroup)txtSubGroupNamme.Tag;
                _ssgroup.GroupId = Convert.ToInt32(cmbGroups.SelectedValue);
                _ssgroup.Name = txtSubGroupNamme.Text;

                if (new HospitalService().UpdateHpOPDServiceSubGroup(_ssgroup))
                {
                    MessageBox.Show("OPD Service sub group updated successfully.");
                    txtGroupName.Text = "";
                    txtGroupName.Tag = null;

                    LoadServiceGroups(0);
                    LoadServiceSubGroups();
                    btnSave.Text = "Save";
                }

            }
            else
            {
                OPDServiceSubGroup _ssgroup = new OPDServiceSubGroup();
                _ssgroup.GroupId = Convert.ToInt32(cmbGroups.SelectedValue);
                _ssgroup.Name = txtSubGroupNamme.Text;

                if (new HospitalService().SaveHpOPDServiceSubGroup(_ssgroup))
                {
                    MessageBox.Show("OPD Service sub group created successfully.");
                    txtGroupName.Text = "";
                    txtGroupName.Tag = null;
                    LoadServiceGroups(0);
                    LoadServiceSubGroups();
                    btnSave.Text = "Save";
                }
            }
        }

        private void btnBedCancel_Click(object sender, EventArgs e)
        {
            txtSubGroupNamme.Text = "";
            txtSubGroupNamme.Tag = null;
            btnBedCancel.Visible = false;
            btnDeleteSubGroup.Visible = false;

            btnBedSave.Text = "Save";
        }

        private void dgGroups_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OPDServiceGroup _cf = new HospitalService().GetOPDServiceGroupById(Convert.ToInt32(dgGroups.Rows[e.RowIndex].Cells["GroupId"].Value));
            txtGroupName.Text = _cf.Name;
            txtGroupName.Tag = _cf;

            btnSave.Text = "Update";
        }

        private void dgServiceSubGroups_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OPDServiceSubGroup _cf = new HospitalService().GetOPDServiceSubGroupById(Convert.ToInt32(dgServiceSubGroups.Rows[e.RowIndex].Cells["SubGroupId"].Value));
            txtSubGroupNamme.Text = _cf.Name;
            txtSubGroupNamme.Tag = _cf;

            LoadServiceGroups(_cf.GroupId);

            btnBedSave.Text = "Update";
            btnBedCancel.Visible = true;
            btnDeleteSubGroup.Visible = true;
        }
    }
}
