
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
    public partial class frmSubGroup : Form
    {
        public frmSubGroup()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgSubGroup.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgSubGroup.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if(txtName.Tag!=null)
           {
                
                
                   if (!string.IsNullOrEmpty(txtName.Text))
                   {
                       //_gr.Name = txtName.Text;
                       
                   }
               
           }
           else
           {
                if (!String.IsNullOrEmpty(txtName.Text))
            {
                PhSubGroup sg = new PhSubGroup();
                sg.GroupId = Convert.ToInt32(cmbGroup.SelectedValue);
                sg.Name = txtName.Text;

                if (new PhProductClassificationService().GetAllSubGroup(sg))
                {
                    MessageBox.Show("Data Save Successful.");
                    txtName.Text = "";
                    loadSubGroup();
                }
                else
                {
                    MessageBox.Show("Data Save Failed.");
                }

            }
            else
            {
                MessageBox.Show("Name cann't be blank.");
            }
           }
        }

        private void frmSubGroup_Load(object sender, EventArgs e)
        {

            loadSubGroup();
            PopulateProductGroup();
        }

        private void PopulateProductGroup()
        {
            List<PhProductGroup> gList = new PhProductClassificationService().GetProductgroups().ToList();
            gList.Insert(0, new PhProductGroup() { GroupId = 0, Name = "Select Group" });
            cmbGroup.DataSource = gList;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupId";
        }

        private void loadSubGroup()
        {
          

        }

        private void dgSubGroup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
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
               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}