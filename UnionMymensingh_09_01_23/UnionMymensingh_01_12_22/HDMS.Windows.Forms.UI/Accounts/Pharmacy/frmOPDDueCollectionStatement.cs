using CrystalDecisions.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    public partial class frmOPDDueCollectionStatement : Form
    {
        public frmOPDDueCollectionStatement()
        {
            InitializeComponent();
        }

        private void frmOPDDueCollectionStatement_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = Utils.GetServerDateAndTime();
            dtpto.Value = Utils.GetServerDateAndTime();
            LoadUsers();
        }

        private void LoadUsers()
        {

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            List<User> _User = new List<User>();

            if (_user.RoleId == 1 || _user.RoleId == 20)
            {
                _User = new UserService().GetAllPharmacist();
                _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "UserId";

            }
           else
            {
                _User = new UserService().GetAll();
                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "UserId";
                cmbUser.SelectedItem = _User.Find(q => q.UserId == MainForm.LoggedinUser.UserId);
                cmbUser.Enabled = false;
            }


        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            string _user = string.Empty;
            if (cmbUser.Text.ToLower() == "all")
            {
                _user = "";
            }
            else
            {
                _user = cmbUser.Text;
            }

            DataSet ds = new PhFinancialService().GetPhDueCollection(dtpfrm.Value,dtpto.Value, _user);

            rptPhDueCollectionStatement _rpt = new rptPhDueCollectionStatement();
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("dtfrm",dtpfrm.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("operateby",cmbUser.Text);

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
    }
