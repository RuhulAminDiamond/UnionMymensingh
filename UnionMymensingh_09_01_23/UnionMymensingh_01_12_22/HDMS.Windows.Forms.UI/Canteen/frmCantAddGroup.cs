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
using Models.Canteen;

namespace POS.Forms
{
    public partial class frmCantAddGroup : Form
    {
        public frmCantAddGroup()
        {
            InitializeComponent();
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtName.Text))
            {
                CantGroup _group = new CantGroup();
                _group.Name = txtName.Text;
            

                if (new CantItemService().AddGroup(_group))
                {
                    MessageBox.Show("New group created succesfully.");
                    txtName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please fill the group name.");
                //dfdfdfdf dfdsf sdfsdfsd f sdfsdf sdfsdfsdfd
            }

        }

        private void frmCantAddGroup_Load(object sender, EventArgs e)
        {
            //This is a test change for github sayfywfuywqf ywfduywqf wyfuywq
            //hywyqwdywqvcywqvcwqa ywqvfyqwfwqifq
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

            //This is a test change for github sayfywfuywqf ywfduywqf wyfuywq
            //hywyqwdywqvcywqvcwqa ywqvfyqwfwqifq
        }
    }
}
