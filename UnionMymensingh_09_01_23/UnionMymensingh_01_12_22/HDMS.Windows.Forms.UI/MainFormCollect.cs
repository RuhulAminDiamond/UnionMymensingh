using CrystalDecisions.Windows.Forms;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Accounts;
using HDMS.Windows.Forms.UI.Common;
using HDMS.Windows.Forms.UI.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI
{
    public partial class MainFormCollect : Form
    {
        public static LoginUser LoggedinUser{get; set;}
        public MainFormCollect(LoginUser user)
        {
            InitializeComponent();
            LoggedinUser = user;
        }

      


        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.MdiParent = this;
            form.Show();
        }

        public void LoginSuccess(LoginUser user)
        {
           
            //this.lblUserId.Text = LoggedinUser.Id.ToString();
        }

        private void SetEnabled(ToolStripMenuItem item)
        {
            foreach (ToolStripMenuItem childItem in item.DropDownItems)
            {
                if (new UserService().IsUserPermitted(Convert.ToString(childItem.Tag), LoggedinUser))
                {
                    childItem.Enabled = true;
                    SetEnabled(childItem);
                }
                else
                {
                    childItem.Enabled = false;
                }
            }
        }

       
        private void ShowChildForm(Form form)
        {
            form.MdiParent = this;
            form.WindowState = FormWindowState.Minimized;
            form.Show();
            form.WindowState = FormWindowState.Maximized;

        }

       
        private void tubeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       
      
       
        private void MainFormCollect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
       
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        
        private void mnuSampleCollection_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmSampleCollection());
        }

        private void MainFormCollect_Load(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (new UserService().IsUserPermitted(Convert.ToString(item.Tag), LoggedinUser))
                {
                    item.Enabled = true;
                    SetEnabled(item);
                }
                else
                {
                    item.Enabled = false;
                }
            }

            this.FormClosed += MainFormCollect_FormClosed;
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmChangePassword());
        }

        private void setCollectionRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmSetSampleCollectionRole());
        }
    }
}
