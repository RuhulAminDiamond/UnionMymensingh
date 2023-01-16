using Services.POS;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;

namespace POS.Forms
{
    public partial class frmAddGroup : Form
    {
        public frmAddGroup()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgGroups.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgGroups.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }


        private void frmAddGroup_Load(object sender, EventArgs e)
        {
            LoadGroups();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtName.Text))
            {
                PhProductGroup _group = new PhProductGroup();
                _group.Name = txtName.Text;
               

                if (new PhProductService().AddGroup(_group))
                {
                    MessageBox.Show("New group created succesfully.");
                    txtName.Text = "";
                    LoadGroups();
                }
            }
            else
            {
                MessageBox.Show("Please fill the group name.");
            }

        }

        private void LoadGroups()
        {
            List<PhProductGroup> _pGroup = new PhProductService().GetAllGroups();
            dgGroups.AutoGenerateColumns = false;
            dgGroups.DataSource = _pGroup;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
