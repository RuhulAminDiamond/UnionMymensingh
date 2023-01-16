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

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmMediaCategoryWithcomission : Form
    {
        public frmMediaCategoryWithcomission()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCategoryName.Text))
            {

                

                MediaCategory mediaCategory = new DiagFinancialService().SaveMediaCategory(txtCategoryName.Text);

                if (mediaCategory != null)
                {
                    MessageBox.Show(" Data has been Saved ");
                    txtCategoryName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Place Entery Your Category Name");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
