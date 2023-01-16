using HDMS.Service.HR;
using HRM.Models;
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
    public partial class frmDivisionEntry : Form
    {
        public frmDivisionEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                EmpDivision _dept = new HrCommonService().GetDivisionById(Convert.ToInt32(((EmpDivision)txtName.Tag).DivId));
                if (!string.IsNullOrEmpty(txtName.Text) && _dept != null)
                {
                    _dept.Name = txtName.Text;
                    if (new HrCommonService().UpdateDivision(_dept))
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
                    EmpDivision dept = new EmpDivision();
                    string name = txtName.Text;
                    dept.Name = name;
                    if (new HrCommonService().AddDivision(dept))
                    {
                        MessageBox.Show("Data Saved Successful.");
                        //texManufacturerTextBox = "";
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
                    MessageBox.Show("Must be entry.");
                }
            }
        }

        private void LoadData()
        {
            List<EmpDivision> _divList = new HrCommonService().GetAllDivision();

            dgDivisions.Rows.Clear();
            foreach (var item in _divList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgDivisions, item.DivId, item.Name);

                dgDivisions.Rows.Add(row);
            }


        }

        private void frmDivisionEntry_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDivisions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EmpDivision _gr = new HrCommonService().GetDivisionById(Convert.ToInt32(dgDivisions.Rows[e.RowIndex].Cells["DivId"].Value));
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
    }
}
