
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

namespace HDMS.Store
{
    public partial class frmGroupEntry : Form
    {
        public frmGroupEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            StoreMasterGroup _smg = (StoreMasterGroup)cmbParent.SelectedItem;
            if (_smg.StoreMasterGroupId == 0)
            {
                MessageBox.Show("Plz. select parent and try again."); return;
            }

            if (!String.IsNullOrEmpty(txtGroupName.Text))
            {
                StoreGroup _stgroup = new StoreGroup();
                _stgroup.StoreMasterGroupId = _smg.StoreMasterGroupId;
                _stgroup.Name = txtGroupName.Text;

                new StoreItemService().SaveGroup(_stgroup);

                MessageBox.Show("Group Entry Successful.");

                txtGroupName.Text = "";

            }
            else
            {
                MessageBox.Show("Group Name Required.");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGroupEntry_Load(object sender, EventArgs e)
        {
            List<StoreMasterGroup> _sm = new StoreItemService().GetStoreMasterGroups();
            _sm.Insert(0, new StoreMasterGroup() { StoreMasterGroupId = 0, Name = "Select Parent" });
            cmbParent.DataSource = _sm;
            cmbParent.DisplayMember = "Name";
            cmbParent.ValueMember = "StoreMasterGroupId";
        }
    }
}
