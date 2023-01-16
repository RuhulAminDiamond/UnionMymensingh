using HDMS.Model.Common;
using HDMS.Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmMemberCreate : Form
    {
        public frmMemberCreate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Member name required"); return;
            }

            if (String.IsNullOrEmpty(txtMobile.Text))
            {
                MessageBox.Show("Mobile no required"); return;
            }

            if(txtName.Tag != null)
            {

            }
            else
            {
                MemberInfo _member = new MemberInfo();
                _member.Name = txtName.Text;
                _member.MobileNo = txtMobile.Text;
                _member.Address = txtAddress.Text;
                _member.Remarks = txtRemarks.Text;

                if(new MemberService().CreateMember(_member))
                {
                    MessageBox.Show("Member created successfully.");
                    txtName.Text = "";
                    txtMobile.Text = "";
                    txtAddress.Text = "";
                    txtRemarks.Text = "";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
