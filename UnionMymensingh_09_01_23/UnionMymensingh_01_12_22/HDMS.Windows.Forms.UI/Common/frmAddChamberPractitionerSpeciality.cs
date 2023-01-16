using HDMS.Model.Common;
using HDMS.Service.Doctors;
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
    public partial class frmAddChamberPractitionerSpeciality : Form
    {
        public frmAddChamberPractitionerSpeciality()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                ChamberPractitionerSpeciality _cp = new DoctorService().GetChamberPractionerSpecialityById(Convert.ToInt32(((ChamberPractitionerSpeciality)txtName.Tag).CPSId));
                if (!string.IsNullOrEmpty(txtName.Text) && _cp != null)
                {
                    _cp.Name = txtName.Text;
                    if (new DoctorService().UpdateChamberPractionerSpeciality(_cp))
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
                    ChamberPractitionerSpeciality _cprac = new ChamberPractitionerSpeciality();
                    _cprac.Name = txtName.Text;
                    if (new DoctorService().AddChamberPractitionerSpeciality(_cprac))
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

        private void LoadData()
        {
            List<ChamberPractitionerSpeciality> cpsList = new DoctorService().GetChamberPractitionerSpecialityList().ToList();
            dgCP.AutoGenerateColumns = false;
            dgCP.DataSource = cpsList;
        }

        private void dgCP_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChamberPractitionerSpeciality _gr = new DoctorService().GetChamberPractionerSpecialityById(Convert.ToInt32(dgCP.Rows[e.RowIndex].Cells["FormationId"].Value));
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

        private void frmAddChamberPractitionerSpeciality_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Tag = null;
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }
    }
}
