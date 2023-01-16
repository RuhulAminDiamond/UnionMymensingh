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
    public partial class frmAddDepartment : Form
    {
        public frmAddDepartment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                HpDepartment _hpdept = new HpDepartment();

                if (txtName.Tag != null)
                {
                    HpDepartment _vT = (HpDepartment)txtName.Tag;
                    _vT.Name = txtName.Text;
                    if (new HospitalCabinBedService().UpdateHpDepartment(_vT))
                    {
                        MessageBox.Show("Update Successful.");
                        txtName.Text = "";
                        txtName.Tag = null;
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;


                    }

                }
                else
                {


                    _hpdept.Name = txtName.Text;

                    if (new HospitalCabinBedService().SaveHpDepartment(_hpdept))
                    {
                        MessageBox.Show("Department added successfully.");
                        txtName.Text = "";


                    }
                }

                LoadDepartments();
            }
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _depts = new HospitalCabinBedService().GetDeptList();
            FillDeptGrid(_depts);
        }

        private void FillDeptGrid(List<HpDepartment> _deptList)
        {
            dgDepartments.SuspendLayout();
            dgDepartments.Rows.Clear();

            foreach (var item in _deptList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgDepartments, item.DeptId, item.Name);
                dgDepartments.Rows.Add(row);
            }
        }

        private void frmAddDepartment_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void dgDepartments_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HpDepartment _dept = (HpDepartment)dgDepartments.SelectedRows[0].Tag;

            if (_dept != null)
            {
                txtName.Text = _dept.Name;
                txtName.Tag = _dept;
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
