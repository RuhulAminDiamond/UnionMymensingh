
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
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
    public partial class frmStrength : Form
    {
        public frmStrength()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgStrength.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgStrength.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Tag!=null)
            {
                Strength _gr = new PhProductClassificationService().GetStrengthById(Convert.ToInt32(((Strength)txtName.Tag).StrengthId));
                if (!string.IsNullOrEmpty(txtName.Text) && _gr != null)
                {
                    _gr.Name = txtName.Text;
                    if (new PhProductClassificationService().UpdateStrength(_gr))
                    {
                        MessageBox.Show("Update Successful.");
                        txtName.Text = "";
                        txtName.Tag = null;
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        LoadData();

                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(txtName.Text))
            {


                string name = txtName.Text;
                Strength strength = new Strength();
                strength.Name = txtName.Text;

                if (new PhProductClassificationService().AddStrength(strength))
                {
                    MessageBox.Show("Data Save Successful.");
                    txtName.Text = "";
                    LoadData();
                    
                }
                else
                {
                    MessageBox.Show("Data Save Failed.");
                }
            }
                else
                {
                    MessageBox.Show("Name cann't be blank.");
                }
            }
           
        }

        private void frmStrength_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<Strength> strengthList = new PhProductClassificationService().GetStrength().ToList();
            dgStrength.AutoGenerateColumns = false;
            dgStrength.DataSource = strengthList;
        }

       

        private void DGVStrength_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Strength _gr = new PhProductClassificationService().GetStrengthById(Convert.ToInt32(dgStrength.Rows[e.RowIndex].Cells["StrengthId"].Value));

            if (_gr != null)
            {
                txtName.Text = _gr.Name;
                txtName.Tag = _gr;
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Tag = null;
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                Strength _gr = new PhProductClassificationService().GetStrengthById(Convert.ToInt32(((Strength)txtName.Tag).StrengthId));
                if (_gr != null)
                {
                    if (new PhProductClassificationService().DeleteStrength(_gr))
                    {
                        MessageBox.Show("Successfully Deleted.");
                        LoadData();
                    }
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
