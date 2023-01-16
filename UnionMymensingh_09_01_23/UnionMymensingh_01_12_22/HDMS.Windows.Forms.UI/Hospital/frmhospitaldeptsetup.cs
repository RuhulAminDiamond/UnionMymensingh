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
    public partial class frmhospitaldeptsetup : Form
    {
        public frmhospitaldeptsetup()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgDepts.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgDepts.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int _admfee = 0;
            int.TryParse(txtAdmFee.Text, out _admfee);

            if (txtName.Tag != null)
            {
                HpDepartment _hpd = (HpDepartment)txtName.Tag;
                _hpd.Name = txtName.Text;
                _hpd.Description = txtDescription.Text;
                _hpd.Admissionfee = _admfee;
                if (new HospitalService().UpdateHpDept(_hpd))
                {
                    btnSave.Text = "Save";
                    txtName.Tag = null;

                    LoadDepartments();
                }
            }
            else
            {

                if (!String.IsNullOrEmpty(txtName.Text))
                {
                    HpDepartment _hpd = new HpDepartment();
                    _hpd.Name = txtName.Text;
                    _hpd.Description = txtDescription.Text;
                    _hpd.Admissionfee = _admfee;
                    if (new HospitalService().SaveHpDepartment(_hpd))
                    {
                        MessageBox.Show("Dept. created successfully.");
                        txtName.Text = "";
                        txtDescription.Text = "";
                        LoadDepartments();
                    }
                }
            }
        }

        private void frmhospitaldeptsetup_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalService().GetHpDepartments();
            dgDepts.DataSource = _deptList;
        }

        private void dgDepts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtName.Tag = new HospitalService().GetHpDeptById(Convert.ToInt32(dgDepts.Rows[e.RowIndex].Cells["DeptId"].Value.ToString()));
            btnSave.Text = "Update";
            if (txtName.Tag != null)
            {
                HpDepartment _hpd = (HpDepartment)txtName.Tag;

                txtName.Text = _hpd.Name;
                txtDescription.Text = _hpd.Description;
            
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
;
