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
    public partial class frmJobCirculation : Form
    {
        public frmJobCirculation()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCirculationTitle.Tag != null)
            {
                JobCirculation _JCirculation = new HrCommonService().GetJobCirculationById(Convert.ToInt32(((JobCirculation)txtCirculationTitle.Tag).JCId));
                if (!string.IsNullOrEmpty(txtCirculationTitle.Text) && _JCirculation != null)
                {

                    _JCirculation.CirculationNo = txtCirculationNo.Text;
                    _JCirculation.CirculationTitle = txtCirculationTitle.Text;

                    if (new HrCommonService().UpdateJobCirculation(_JCirculation))
                    {
                        MessageBox.Show("Update Successful.");
                        txtCirculationNo.Text = "";
                        txtCirculationTitle.Text = "";
                        txtCirculationTitle.Tag = null;
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        LoadData();

                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCirculationTitle.Text))
                {
                    JobCirculation _JCir  = new JobCirculation();
                    _JCir.CirculationNo = txtCirculationNo.Text;
                    _JCir.CirculationTitle = txtCirculationTitle.Text; ;
                    if (new HrCommonService().AddJobCirculation(_JCir))
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
            IList<JobCirculation> circulationList = new HrCommonService().GetJobCirculations();
            dgJobCirculations.AutoGenerateColumns = false;
            dgJobCirculations.DataSource = circulationList;
        }

        private void dgDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            JobCirculation _gr = new HrCommonService().GetCircularById(Convert.ToInt32(dgJobCirculations.Rows[e.RowIndex].Cells["JCId"].Value));
        
            if (_gr != null)
            {
                txtCirculationNo.Text = _gr.CirculationNo;
                txtCirculationTitle.Text = _gr.CirculationTitle;
                txtCirculationTitle.Tag = _gr;
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
            txtCirculationNo.Text = "";
            txtCirculationTitle.Text = "";
            txtCirculationTitle.Tag = null;
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCirculationTitle.Tag != null)
            {
                EmpDepartment _gr = new HrCommonService().GetDeptById(Convert.ToInt32(((EmpDepartment)txtCirculationTitle.Tag).DeptId));
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
            LoadData();
        }
    }
}
