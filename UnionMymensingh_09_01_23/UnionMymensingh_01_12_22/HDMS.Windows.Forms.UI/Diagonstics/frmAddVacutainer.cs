using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmAddVacutainer : Form
    {
        public frmAddVacutainer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                VacuType _vType = new VacuType();

                if (txtName.Tag != null)
                {
                    VacuType _vT = (VacuType)txtName.Tag;
                    _vT.VType = txtName.Text;
                    if (new TestService().UpdateVacuType(_vT))
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

                 
                    _vType.VType = txtName.Text;

                    if (new TestService().SaveVacuType(_vType))
                    {
                        MessageBox.Show("Vacu added successfully.");
                        txtName.Text = "";

                       
                    }
                }

                LoadVacuTypes();
            }
        }

        private void dgVacus_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VacuType _vacu = (VacuType)dgVacus.SelectedRows[0].Tag;

            if (_vacu != null)
            {
                txtName.Text = _vacu.VType;
                txtName.Tag = _vacu;
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
        }

        private void frmAddVacutainer_Load(object sender, EventArgs e)
        {
            LoadVacuTypes();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }


        private void LoadVacuTypes()
        {
            List<VacuType> _type = new TestService().GetVacuList();
            FillVacuGrid(_type);
        }

        private void FillVacuGrid(List<VacuType> _typeList)
        {
            dgVacus.SuspendLayout();
            dgVacus.Rows.Clear();

            foreach(var item in _typeList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgVacus, item.VTId, item.VType);
                dgVacus.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
