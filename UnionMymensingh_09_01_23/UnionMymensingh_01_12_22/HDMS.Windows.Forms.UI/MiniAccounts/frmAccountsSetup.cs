
using HDMS.Model.MiniAccount;
using HDMS.Service.MiniAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.MiniAccounts
{
    public partial class frmAccountsSetup : Form
    {
        public frmAccountsSetup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbType.Text) && !String.IsNullOrEmpty(txtHeadName.Text))
            {
                MiniAccountHead _accHead = new MiniAccountHead();
                _accHead.Name = txtHeadName.Text;
                _accHead.Type = cmbType.Text;
                if (new MiniAccountService().SaveAccountHead(_accHead))
                {
                    MessageBox.Show("Account head creates successfully.","HERP");
                    txtHeadName.Text = "";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
