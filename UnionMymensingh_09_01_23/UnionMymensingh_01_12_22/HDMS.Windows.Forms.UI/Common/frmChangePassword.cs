using HDMS.Common.Utils;
using HDMS.Model.Users;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
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
    public partial class frmChangePassword : Form
    {
        public static LoginUser LoggedinUser { get; set; }
        public frmChangePassword()
        {
            InitializeComponent();
            LoggedinUser = MainForm.LoggedinUser;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            lblUserId.Text = LoggedinUser.UserId.ToString();
            lblUserName.Text = LoggedinUser.Name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (new UserService().CheckOldPassword(lblUserName.Text, txtOldPassword.Text))
            {
                if (String.Compare(txtNewPassword.Text, txtConfirmNewPassword.Text) == 0)
                {
                    string[] _arr = HashGenerator.GetPasswordHashAndSalt(txtNewPassword.Text);
                    User _user = new UserService().GetUserById(Convert.ToInt32(lblUserId.Text));
                    _user.Password = _arr[0];
                    _user.Salt = _arr[1];
                    if (new UserService().ChangePassword(_user))
                    {
                        MessageBox.Show("Password changed successfully.", "HERP");
                    }
                    else
                    {
                        MessageBox.Show("Fail to change password.", "HERP");
                    }
                    
                }
                else
                {
                    MessageBox.Show("New password and confirm new password did not match.", "HERP");
                }
            }
            else
            {
                MessageBox.Show("Old password wrong.","HERP");
            }
        }
    }
}
