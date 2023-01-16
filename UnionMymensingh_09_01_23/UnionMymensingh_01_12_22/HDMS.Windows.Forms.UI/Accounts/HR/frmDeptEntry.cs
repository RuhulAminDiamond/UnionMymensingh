using HDMS.Model.HR;
using HDMS.Service.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmDeptEntry : Form
    {
        public frmDeptEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                EmpDepartment _dept = new HrCommonService().GetDeptById(Convert.ToInt32(((EmpDepartment)txtName.Tag).DeptId));
                if (!string.IsNullOrEmpty(txtName.Text) && _dept != null)
                {
                    _dept.Name = txtName.Text;
                    if (new HrCommonService().UpdateDept(_dept))
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
                    EmpDepartment dept = new EmpDepartment();
                    string name = txtName.Text;
                    dept.Name = name;
                    if (new HrCommonService().AddDept(dept))
                    {
                        MessageBox.Show("Data Saved Successful.");
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

        private void LoadData()
        {
            IList<EmpDepartment> ManufacturerList = new HrCommonService().GetDepartments();
            dgDept.AutoGenerateColumns = false;
            dgDept.DataSource = ManufacturerList;
        }

        private void dgDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EmpDepartment _gr = new HrCommonService().GetDeptById(Convert.ToInt32(dgDept.Rows[e.RowIndex].Cells["DeptId"].Value));
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                EmpDepartment _gr = new HrCommonService().GetDeptById(Convert.ToInt32(((EmpDepartment)txtName.Tag).DeptId));
                if (_gr != null)
                {
                    if (new HrCommonService().DeleteDept(_gr))
                    {
                        MessageBox.Show("Successfully Deleted.");
                        LoadData();
                    }
                }

            }
        }

        private void frmDeptEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
