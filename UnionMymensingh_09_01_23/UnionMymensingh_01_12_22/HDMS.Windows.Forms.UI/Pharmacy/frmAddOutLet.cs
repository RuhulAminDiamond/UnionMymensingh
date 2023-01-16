using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmAddOutLet : Form
    {
        public frmAddOutLet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCodeNo.Tag != null)
            {
                MedicineOutlet _outlet = (MedicineOutlet)txtCodeNo.Tag;
                _outlet.CodeNo = txtCodeNo.Text;
                _outlet.Name = txtName.Text;
                _outlet.Description = txtDescription.Text;

                if(new PhProductService().UpdateOutletInfo(_outlet))
                {
                    MessageBox.Show("Outlet info updated successfully.");
                    btnSave.Text = "Save";
                    ClearFileds();
                    LoadOutLets();
                }

            }
            else
            {

                if (!String.IsNullOrWhiteSpace(txtCodeNo.Text) && !String.IsNullOrWhiteSpace(txtName.Text))
                {
                    MedicineOutlet _outlet = new MedicineOutlet();
                    _outlet.CodeNo = txtCodeNo.Text;
                    _outlet.Name = txtName.Text;
                    _outlet.Description = txtDescription.Text;

                    if (new PhProductService().CreateOutlet(_outlet))
                    {
                        MessageBox.Show("Outlet created successfully.");
                        LoadOutLets();
                        ClearFileds();
                    }
                }
            }
        }

        private void LoadOutLets()
        {
            List<MedicineOutlet> _medicineOutlet = new PhProductService().GetAllMedicineOutlets();
            dgOutlet.AutoGenerateColumns = false;
            dgOutlet.DataSource = _medicineOutlet;

        }

        private void ClearFileds()
        {
            txtCodeNo.Tag = null;
            txtCodeNo.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            
        }

        private void frmAddOutLet_Load(object sender, EventArgs e)
        {
            LoadOutLets();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgOutlet_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
            MedicineOutlet _outLet = new PhProductService().getOutletById(Convert.ToInt32(dgOutlet.Rows[e.RowIndex].Cells["OutletId"].Value));

            txtCodeNo.Text = _outLet.CodeNo;
            txtName.Text = _outLet.Name;
            txtDescription.Text = _outLet.Description;

            txtCodeNo.Tag = _outLet;

            btnSave.Text = "Update";

        }
    }
}
