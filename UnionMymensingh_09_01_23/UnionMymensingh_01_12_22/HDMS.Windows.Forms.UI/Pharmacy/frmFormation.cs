
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
    public partial class frmFormation : Form
    {
        public frmFormation()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgFormation.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgFormation.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Tag !=null)
            {
                Formation _gr = new PhProductClassificationService().GetFormationById(Convert.ToInt32(((Formation)txtName.Tag).FormationId));
                if (!string.IsNullOrEmpty(txtName.Text) && _gr != null)
                {
                    _gr.Name = txtName.Text;
                    if (new PhProductClassificationService().UpdateFormation(_gr))
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
             if (!string.IsNullOrEmpty(txtName.Text))
            {
                Formation formation = new Formation();
                formation.Name = txtName.Text;
                if (new PhProductClassificationService().AddFormation(formation))
                {
                    MessageBox.Show("Data Saved Succesfull.");
                    txtName.Text = "";
                    LoadData();

                }
                else
                {
                    MessageBox.Show("Data Saved Failed.");
                }
            }
            else
            {
                MessageBox.Show("Name required.");
            }
            }
        }

        private void frmFormation_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<Formation> formationList = new PhProductClassificationService().GetFormation().ToList();
            dgFormation.AutoGenerateColumns = false;
            dgFormation.DataSource = formationList;
        }

        private void dgFormation_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Formation _gr = new PhProductClassificationService().GetFormationById(Convert.ToInt32(dgFormation.Rows[e.RowIndex].Cells["FormationId"].Value));
               // new ProductClassicationService().GetGenericById(Convert.ToInt32(dgFormation.Rows[e.RowIndex].Cells["FormationId"].Value));

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
                Formation _gr = new PhProductClassificationService().GetFormationById(Convert.ToInt32(((Formation)txtName.Tag).FormationId));
                if (_gr != null)
                {
                    if (new PhProductClassificationService().DeleteFormation(_gr))
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
