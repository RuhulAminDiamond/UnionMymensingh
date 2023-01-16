using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using Services.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Forms
{
    public partial class frmWardInfo : Form
    {
        public frmWardInfo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadWardInfo();
            LoadWardBedInfo();
          
        }

        private void LoadWardBedInfo()
        {
            List<WardBedInfo> WbiList = new HospitalCabinBedService().GetWardBedInfo().ToList();
            dgWardBed.AutoGenerateColumns = false;
            dgWardBed.DataSource = WbiList;
        }

       

        private void LoadWardInfo()
        {
            List<WardInfo> _wi = new HospitalCabinBedService().GetWarInfo().ToList();
            dgWardInfo.AutoGenerateColumns = false;
            dgWardInfo.DataSource = _wi;

            List<WardInfo> _wil = new HospitalCabinBedService().GetWarInfo().ToList();
            _wil.Insert(0, new WardInfo() { WardId = 0, Description = "Select Ward" });
            cbWard.DataSource = _wil;
            cbWard.DisplayMember = "Description";
            cbWard.ValueMember = "WardId";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Tag != null)
            {
                WardInfo _wi = new HospitalCabinBedService().GetWarInfoById(Convert.ToInt32(((WardInfo)txtDescription.Tag).WardId));
                if (!string.IsNullOrEmpty(txtDescription.Text) && _wi != null)
                {
                    int rent = 0;
                    int.TryParse(txtRent.Text, out rent);
                    _wi.Description = txtDescription.Text;
                    if (new HospitalCabinBedService().UpdateWardInfo(_wi))
                    {
                        MessageBox.Show("Update Successfull.");
                        txtDescription.Text = "";
                        txtRent.Text = "";
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        LoadWardInfo();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed.");
                    }
                }
            }
            else
            {
                int rent = 0;
                int.TryParse(txtRent.Text, out rent);
                WardInfo wi = new WardInfo();
                wi.Description = txtDescription.Text;
                if (new HospitalCabinBedService().SaveWardInfo(wi))
                {
                    MessageBox.Show("saved Successfull.");
                    txtDescription.Text = "";
                    txtRent.Text = "";
                    LoadWardInfo();
                }
                else
                {
                    MessageBox.Show("save Failed.");
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtRent.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }

        private void dgWardInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            WardInfo _wi = new HospitalCabinBedService().GetWarInfoById(Convert.ToInt32(dgWardInfo.Rows[e.RowIndex].Cells["WardId"].Value));
            txtDescription.Tag = _wi;
            txtDescription.Text = _wi.Description;
            btnSave.Text = "Update";
            btnCancel.Visible = true;
            btnDelete.Visible = true;
        }

        private void btnBedSave_Click(object sender, EventArgs e)
        {
            int rent=0;
            int.TryParse(txtRent.Text,out rent);
             WardBedInfo wbi = new WardBedInfo();
             wbi.WardId =Convert.ToInt32(cbWard.SelectedValue);
             wbi.Description = txtBadDescription.Text;
             wbi.Rent = rent;
             if (new HospitalCabinBedService().SaveWardBedInfo(wbi))
             {
                 MessageBox.Show("Save Successfull.");
                 cbWard.SelectedIndex = 0;
                 txtBadDescription.Text = "";
                 txtRent.Text = "";
                 LoadWardBedInfo();
             }
             else
             {
                 MessageBox.Show("Save Failed.");
             }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
