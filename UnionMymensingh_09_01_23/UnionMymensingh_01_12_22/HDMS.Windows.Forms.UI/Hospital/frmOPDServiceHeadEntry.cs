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
    public partial class frmOPDServiceHeadEntry : Form
    {
        bool isLoaded = false;

        public frmOPDServiceHeadEntry()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgServiceHeads.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgServiceHeads.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                int _sgId = 0;
                double _rate = 0;
                double.TryParse(txtRate.Text, out _rate);

                int.TryParse(txtSGroupId.Text, out _sgId);
                OPDServiceHead _sh = (OPDServiceHead)txtName.Tag;
                _sh.SubGroupId = _sgId;
                _sh.ServiceHeadName = txtName.Text;
                _sh.Rate = _rate;

                if (new HospitalService().UpdateOPDServiceHead(_sh))
                {
                    MessageBox.Show("Update Successful");
                    txtName.Tag = null;
                    txtName.Text = "";
                    txtRate.Text = "";
                    btnSave.Text = "Save";
                    LoadServiceHeads();
                }

            }
            else
            {
                double _rate = 0;
                double.TryParse(txtRate.Text, out _rate);

                OPDServiceSubGroup _ssg = (OPDServiceSubGroup)cmbSubGroups.SelectedItem;

                OPDServiceHead _sh = new OPDServiceHead();
                _sh.SubGroupId = _ssg.SubGroupId;
                _sh.ServiceHeadName = txtName.Text;
                _sh.Rate = _rate;
                if (chkServiceCharge.Checked)
                {
                    _sh.ServiceCharge = true;

                }
                else
                {
                    _sh.ServiceCharge = false;
                }

                if (chkVat.Checked)
                {
                    _sh.Vat = true;
                }
                else
                {
                    _sh.Vat = false;
                }



                if (new HospitalService().SaveOPDServiceHead(_sh))
                {
                    MessageBox.Show("OPD Service head entry successful");
                    txtName.Text = "";
                    txtRate.Text = "";
                    LoadServiceHeads();
                }
            }
        }

        private void LoadServiceHeads()
        {
            List<OPDServiceHead> _shList = new HospitalService().GetAllOPDServiceHeads();
            dgServiceHeads.AutoGenerateColumns = false;
            dgServiceHeads.DataSource = _shList;

        }

        private void frmOPDServiceHeadEntry_Load(object sender, EventArgs e)
        {
            isLoaded = false;

            LoadServiceHeads();

            LoadServiceSubGroup();

            isLoaded = true;
        }

        private void LoadServiceSubGroup()
        {
            List<OPDServiceSubGroup> _ssgList = new HospitalService().GetAllOPDServiceSubGroups();
            _ssgList.Insert(0, new OPDServiceSubGroup() { SubGroupId = 0, Name = "Select Group" });
            cmbSubGroups.DataSource = _ssgList;
            cmbSubGroups.DisplayMember = "Name";
            cmbSubGroups.ValueMember = "SubGroupId";
        }

        private void cmbSubGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                OPDServiceSubGroup _ssg = (OPDServiceSubGroup)cmbSubGroups.SelectedItem;
                txtSGroupId.Text = _ssg.GroupId.ToString();
                List<OPDServiceHead> _ssgList = new HospitalService().GetAllOPDServiceHeadBySubGroupId(_ssg.SubGroupId);
                dgServiceHeads.AutoGenerateColumns = false;
                dgServiceHeads.DataSource = _ssgList;
            }
        }

        private void dgServiceHeads_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            isLoaded = false;
            OPDServiceHead _cf = new HospitalService().GetOPDServiceHeadById(Convert.ToInt32(dgServiceHeads.Rows[e.RowIndex].Cells["ServiceHeadId"].Value));
            List<OPDServiceSubGroup> _ssgList = new HospitalService().GetAllOPDServiceSubGroups();
            cmbSubGroups.DataSource = _ssgList;
            cmbSubGroups.DisplayMember = "Name";
            cmbSubGroups.ValueMember = "SubGroupId";
            cmbSubGroups.SelectedItem = _ssgList.Find(q => q.SubGroupId == _cf.SubGroupId);

            txtName.Text = _cf.ServiceHeadName;
            txtName.Tag = _cf;
            txtRate.Text = _cf.Rate.ToString();

            chkServiceCharge.Checked = false;
            chkVat.Checked = false;

            if (_cf.ServiceCharge) chkServiceCharge.Checked = true;
            if (_cf.Vat) chkVat.Checked = true;

            btnSave.Text = "Update";
            isLoaded = true;
        }
    }
}
