using HDMS.Common.Utils;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI
{
    public partial class LoginForm : Form
    {

       public static LoginUser loggedInuser=null;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
             PerformLogin();
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void PerformLogin()
        {
            //if (new SecurityService().IsLicenseExipred())
            //{
            //    MessageBox.Show("System out of service.Plz. Contact your vendor."); return;
            //}


            if ((new UserService()).CheckLogin(txtUserName.Text, txtPassword.Text, out loggedInuser))
            {

               // string applicationDirectory = Application.StartupPath;

               // string rootPath = (Path.GetDirectoryName(Application.StartupPath).Replace(@"debug\", string.Empty)).Replace(@"bin", string.Empty);
               // string _rootPath = rootPath.Replace(@"bin", string.Empty);
                  
                  new MainForm(loggedInuser).Show();

                //var url = $"?userName={txtUserName.Text}&password={txtPassword.Text}";

                //var request = (HttpWebRequest)WebRequest.Create(url);
            
                //request.Method = "POST";
                //request.ContentType = "application/json";
               
                //var response = (HttpWebResponse)request.GetResponse();

                //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();



                this.Hide();
            }
            else
            {
                MessageBox.Show("User name or password mismatched", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
