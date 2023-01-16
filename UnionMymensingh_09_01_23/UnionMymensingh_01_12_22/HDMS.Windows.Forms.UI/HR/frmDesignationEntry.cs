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
    public partial class frmDesignationEntry : Form
    {
        public frmDesignationEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                EmpDesignation _desig = new HrCommonService().GetDesignationById(Convert.ToInt32(((EmpDesignation)txtName.Tag).DesignationId));
                if (!string.IsNullOrEmpty(txtName.Text) && _desig != null)
                {
                    _desig.Name = txtName.Text;
                    if (new HrCommonService().UpdateDesignation(_desig))
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
                    EmpDesignation desig = new EmpDesignation();
                    string name = txtName.Text;
                    desig.Name = name;
                    if (new HrCommonService().AddDesignation(desig))
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
            IList<EmpDesignation> ManufacturerList = new HrCommonService().GetDesignations();
            dgDesignation.AutoGenerateColumns = false;
            dgDesignation.DataSource = ManufacturerList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDesignationEntry_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
