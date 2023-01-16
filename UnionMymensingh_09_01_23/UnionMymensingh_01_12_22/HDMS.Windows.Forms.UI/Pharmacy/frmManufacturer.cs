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
    public partial class frmManufacturer : Form
    {
        public frmManufacturer()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgManufacturer.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgManufacturer.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int _accountId = 0;
            int.TryParse(txtAccountId.Text, out _accountId);
            
            if(txtName.Tag != null)
           {
               Manufacturer _gr = new PhProductClassificationService().GetManufactureById(Convert.ToInt32(((Manufacturer)txtName.Tag).ManufacturerId));
                if (!string.IsNullOrEmpty(txtName.Text) && _gr!=null)
                {
                    _gr.Name = txtName.Text;
                    _gr.ManufacturerAccId = _accountId;
                    if (new PhProductClassificationService().UpdateManufacturer(_gr))
                    {
                        MessageBox.Show("Update Successful.");
                        txtName.Text = "";
                        txtName.Tag = null;
                        txtAccountId.Text = "";
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
                Manufacturer manufacturer = new Manufacturer();
                string name = txtName.Text;
                manufacturer.Name = name;
                manufacturer.ManufacturerAccId = _accountId;
                if (new PhProductClassificationService().AddManufacturer(manufacturer))
                {
                    MessageBox.Show("Data Saved Successful.");
                        txtAccountId.Text = "";
                        txtName.Text = "";
                        //texManufacturerTextBox = "";
                        LoadData();
                }
                else
                {
                    MessageBox.Show("Data Saved Failed.");
                }
            }
            else
            {
                MessageBox.Show("Must be entry.");
            }
           }
        }

        private void frmManufacturer_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
           IList<Manufacturer>ManufacturerList =new PhProductClassificationService().GetManufacturer();
           dgManufacturer.AutoGenerateColumns = false;
           dgManufacturer.DataSource = ManufacturerList;
        }

        private void DGVManufacturer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Manufacturer _gr = new PhProductClassificationService().GetManufactureById(Convert.ToInt32(dgManufacturer.Rows[e.RowIndex].Cells["ManufacturerId"].Value));
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
                Manufacturer _mfr = new PhProductClassificationService().GetManufactureById(Convert.ToInt32(((Manufacturer)txtName.Tag).ManufacturerId));
                if (_mfr != null)
                {

                    List<PhProductInfo> _phprdList = new PhProductService().GetProductListByManufacturer(_mfr.ManufacturerId);

                    if (_phprdList.Count > 0)
                    {
                        MessageBox.Show("Product/s found under this manufacturer. To delete the manufacturer first delete/update the product info.");
                        return;
                    }
                    else
                    {
                        if (new PhProductClassificationService().DeleteManufacturer(_mfr))
                        {
                            MessageBox.Show("Successfully Deleted.");
                            LoadData();
                        }
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
