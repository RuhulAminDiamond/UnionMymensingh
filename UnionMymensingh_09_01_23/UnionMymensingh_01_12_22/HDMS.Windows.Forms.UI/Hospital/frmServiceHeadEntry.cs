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
    public partial class frmServiceHeadEntry : Form
    {
        bool isLoaded = false;
        public frmServiceHeadEntry()
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


        private void frmServiceHeadEntry_Load(object sender, EventArgs e)
        {
            isLoaded = false;

            LoadServiceHeads();

            LoadServiceSubGroup();

            isLoaded = true; 
        }

        private void LoadServiceSubGroup()
        {
            List<ServiceSubGroup> _ssgList = new HospitalService().GetAllServiceSubGroups();
            _ssgList.Insert(0, new ServiceSubGroup() { SubGroupId = 0, Name = "Select Group" });
            cmbSubGroups.DataSource = _ssgList;
            cmbSubGroups.DisplayMember = "Name";
            cmbSubGroups.ValueMember = "SubGroupId";
        }

      

        private void LoadServiceHeads()
        {
            List<ServiceHead> _shList = new HospitalService().GetAllServiceHeads();
            dgServiceHeads.AutoGenerateColumns = false;
            dgServiceHeads.DataSource = _shList;

        }

        private void dgServiceHeads_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            isLoaded = false;
            ServiceHead _cf = new HospitalService().GetServiceHeadById(Convert.ToInt32(dgServiceHeads.Rows[e.RowIndex].Cells["ServiceHeadId"].Value));
            List<ServiceSubGroup> _ssgList = new HospitalService().GetAllServiceSubGroups();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                int _sgId = 0;
                double _rate = 0;
                double.TryParse(txtRate.Text, out _rate);

                int.TryParse(txtSGroupId.Text, out _sgId);
                ServiceHead _sh = (ServiceHead)txtName.Tag;
                _sh.SubGroupId = _sgId;
                _sh.ServiceHeadName = txtName.Text;
                _sh.Rate = _rate;

                if(new HospitalService().UpdateServiceHead(_sh))
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

                ServiceSubGroup _ssg = (ServiceSubGroup)cmbSubGroups.SelectedItem;

                ServiceHead _sh = new ServiceHead();
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

              

                if (new HospitalService().SaveServiceHead(_sh))
                {
                    MessageBox.Show("Service head entry successful");
                    txtName.Text="";
                    txtRate.Text = "";
                    LoadServiceHeads();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSubGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                ServiceSubGroup _ssg = (ServiceSubGroup)cmbSubGroups.SelectedItem;
                txtSGroupId.Text = _ssg.GroupId.ToString();
                List<ServiceHead> _ssgList = new HospitalService().GetAllServiceHeadBySubGroupId(_ssg.SubGroupId);
                dgServiceHeads.AutoGenerateColumns = false;
                dgServiceHeads.DataSource = _ssgList;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Tag = null;
            txtName.Text = "";
            txtRate.Text = "";
            chkServiceCharge.Checked = false;
            chkVat.Checked = false;
            btnSave.Text = "Save";

            LoadServiceSubGroup();
        }
    }
}
