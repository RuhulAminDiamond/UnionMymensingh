
using HDMS.Model.Pharmacy.ViewModels;
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
    public partial class frmGeniric : Form
    {
        public frmGeniric()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgGeneric.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgGeneric.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PhProductGroup _group = (PhProductGroup)cmbGroup.SelectedItem;
            if (_group.GroupId == 0)
            {
                MessageBox.Show("Plz. select group and try again."); return;
            }
            
            if (txtName.Tag != null)
            {
                
                Generic _gr = new PhProductClassificationService().GetGenericById(Convert.ToInt32(((Generic)txtName.Tag).GenericId));
                if (!string.IsNullOrEmpty(txtName.Text) && _gr!=null)
                {
                    _gr.Name = txtName.Text;
                    _gr.GroupId = _group.GroupId;
                    if (new PhProductClassificationService().UpdateGeneric(_gr))
                    {
                        MessageBox.Show("Update Successful.");
                        txtName.Text = "";
                        txtName.Tag = null;
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        LoadGeneric();

                    } 
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    string name = txtName.Text;
                    Generic generic = new Generic();
                    generic.Name = name;
                    generic.GroupId = _group.GroupId;
                    if (new PhProductClassificationService().AddGeneric(generic))
                    {
                        MessageBox.Show("Data Saved Successful.");
                        txtName.Text = "";
                        LoadGeneric();
                    }
                    else
                    {
                        MessageBox.Show("Data Saved Failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Must be entry generic name.");
                }
            }
            
            
           
        }

        private void frmGeniric_Load(object sender, EventArgs e)
        {

            LoadPhProductGroups(0);
            
            LoadGeneric();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }
        }

        private void LoadPhProductGroups(int _groupId)
        {
            List<PhProductGroup> _groupList = new PhProductService().GetAllGroups();
            _groupList.Insert(0,new PhProductGroup() { GroupId=0,Name="Select Group" });

            cmbGroup.DataSource = _groupList;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupId";
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

        private void LoadGeneric()
        {
            List<VMGeneric> genList = new PhProductClassificationService().GetAllGeneric();
            dgGeneric.SuspendLayout();
            dgGeneric.Rows.Clear();
            foreach(var item in genList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgGeneric,item.GenericId, item.GenName,item.GroupName);
                dgGeneric.Rows.Add(row);
            }
        }

        private void dgGeneric_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Generic _gr = new PhProductClassificationService().GetGenericById(Convert.ToInt32(dgGeneric.Rows[e.RowIndex].Cells["GenericId"].Value));

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
                Generic _gr = new PhProductClassificationService().GetGenericById(Convert.ToInt32(((Generic)txtName.Tag).GenericId));

                List<PhProductInfo> _prdList = new PhProductService().GetProductsByGeneric(_gr.GenericId);

                if (_gr != null)
                {
                    if (new PhProductClassificationService().DeleteGeneric(_gr))
                    {
                        MessageBox.Show("Successfully Deleted.");
                        LoadGeneric();
                    }
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchGeneric_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchGeneric.Text!= "Search Generic" && txtSearchGeneric.Text.Length > 1)
            {
                LoadGenericByName(txtSearchGeneric.Text);
            }
            else
            {
                LoadGeneric();
            }
        }

        private void LoadGenericByName(string _searchStr)
        {
            List<VMGeneric> genList = new PhProductClassificationService().GetGenericBySearchStr(_searchStr);
            dgGeneric.SuspendLayout();
            dgGeneric.Rows.Clear();
            foreach (var item in genList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgGeneric, item.GenericId, item.GenName, item.GroupName);
                dgGeneric.Rows.Add(row);
            }
        }
    }
}
