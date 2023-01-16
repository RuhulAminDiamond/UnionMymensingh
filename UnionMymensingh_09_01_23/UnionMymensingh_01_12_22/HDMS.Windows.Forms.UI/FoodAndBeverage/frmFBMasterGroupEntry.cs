
using HDMS.Model.Store;
using Models.Store;
using Services.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    public partial class frmFBMasterGroupEntry : Form
    {
        public frmFBMasterGroupEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtGroupName.Text))
            {
                StoreMasterGroup _stgroup = new StoreMasterGroup();
                _stgroup.Name = txtGroupName.Text;

                new StoreItemService().SaveStoreMasterGroup(_stgroup);

                MessageBox.Show("Master Group Created Successfully.");

                txtGroupName.Text = "";

            }
            else
            {
                MessageBox.Show("Master Group Name Required.");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
