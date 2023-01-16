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

namespace HDMS.Windows.Forms.UI
{
    public partial class frmopdconsultantcategory : Form
    {
        public frmopdconsultantcategory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double _rate = 0;
            double _cppercent = 0;
            double _hppercent = 0;
            double.TryParse(txtRate.Text, out _rate);
            double.TryParse(txtCPPercent.Text, out _cppercent);
            double.TryParse(txtHPPercent.Text, out _hppercent);
           
            if (txtName.Tag != null)
            {
                HpOPDConsultantCategory _hpopdconsultantcat = (HpOPDConsultantCategory)txtName.Tag;
                _hpopdconsultantcat.Name = txtName.Text;
                _hpopdconsultantcat.Rate = _rate;
                _hpopdconsultantcat.CpPercent = _cppercent;
                _hpopdconsultantcat.HpPercent = _hppercent;

                if (new HospitalService().UpdateHpOPDConsultantCategory(_hpopdconsultantcat))
                {

                    MessageBox.Show("OPD Consultant category updated successfully.");
                    btnSave.Text = "Save";
                    txtName.Tag = null;
                    txtName.Text = "";
                    txtRate.Text = "";
                    txtCPPercent.Text = "";
                    txtHPPercent.Text = "";
                    LoadOPDConsultantCategory();
                }
            }
            else
            {

                if (!String.IsNullOrEmpty(txtName.Text))
                {
                    HpOPDConsultantCategory _hpdcat = new HpOPDConsultantCategory();
                    _hpdcat.Name = txtName.Text;
                    _hpdcat.Rate = _rate;
                    _hpdcat.CpPercent = _cppercent;
                    _hpdcat.HpPercent = _hppercent;

                    if (new HospitalService().SaveHpOPDConsultantCategory(_hpdcat))
                    {
                        MessageBox.Show("OPD Consultant category created successfully.");
                        txtName.Text = "";
                        txtRate.Text = "";
                        txtCPPercent.Text = "";
                        txtHPPercent.Text = "";
                        LoadOPDConsultantCategory();
                    }
                }
            }
        }

        private void LoadOPDConsultantCategory()
        {
            List<HpOPDConsultantCategory> _ccateList = new HospitalService().GetHpOPDConsultantCategories();
            dgOPdCCate.DataSource = _ccateList;
        }

        private void frmopdconsultantcategory_Load(object sender, EventArgs e)
        {
            LoadOPDConsultantCategory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgOPdCCate_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtName.Tag = new HospitalService().GetHpOPDConsultantCategoryById(Convert.ToInt32(dgOPdCCate.Rows[e.RowIndex].Cells["CategoryId"].Value.ToString()));
            btnSave.Text = "Update";
            if (txtName.Tag != null)
            {
                
                HpOPDConsultantCategory _hpd = (HpOPDConsultantCategory)txtName.Tag;

                txtName.Text = _hpd.Name;
                txtRate.Text = _hpd.Rate.ToString();

            }
        }
    }
}
