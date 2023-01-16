using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Receiption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmDepositSlip : Form
    {
        public frmDepositSlip()
        {
            InitializeComponent();
        }

        private void frmDepositSlip_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            List<User> _User = new List<User>();

            if (_user.RoleId == 1)
            {
                _User = new UserService().GetAll();
                _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "Id";

            }
            else if (_user.RoleId == 3 || _user.RoleId == 10)
            {
                _User = new UserService().GetUserByRoleId(4);
                _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "Id";
            }
            else
            {
                _User = new UserService().GetAll();
                cmbUser.DataSource = _User;
                cmbUser.DisplayMember = "LoginName";
                cmbUser.ValueMember = "Id";
                cmbUser.SelectedItem = _User.Find(q => q.UserId == MainForm.LoggedinUser.UserId);
                cmbUser.Enabled = false;
            }


        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
            if (radIPD.Checked)
            {
                _reportOPtion = "IPD";
                _reportHeader = "IPD Patient Statement";
            }
            else if (radOPD.Checked)
            {
                _reportOPtion = "OPD";
                _reportHeader = "OPD Patient Statement";
            }
            else if (radAll.Checked)
            {
                _reportOPtion = "All";
                _reportHeader = "Patient Statement";
            }


            VMDepositSlip _slip = new ReportService().GetDepositSlip(dtpfrm.Value, dtpto.Value, cmbUser.Text, _reportOPtion);
            ReportViewer rv = new ReportViewer();

            rptDepositSlip _rpt = new rptDepositSlip();

            string _fullName = string.Empty;
            User _user = (User)cmbUser.SelectedItem;

            if (_user.UserId > 0)
            {
                _user = new UserService().GetUserById(_user.UserId);
                _fullName = _user.FullName;

            }
            else
            {
                _fullName = cmbUser.Text;
            }

            _rpt.SetParameterValue("eDate", dtpfrm.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("todate", dtpto.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("LoginName",cmbUser.Text);
            _rpt.SetParameterValue("FullName", _fullName); 
             _rpt.SetParameterValue("ReportMode", _reportOPtion);

            _rpt.SetParameterValue("totalPatient", _slip.totalPatient.ToString());

            _rpt.SetParameterValue("TotalRegularCollection", _slip.PaidAmount.ToString());
            
            _rpt.SetParameterValue("DueCollection", _slip.DueCollection.ToString());
            _rpt.SetParameterValue("totalAmountReceived", (_slip.PaidAmount+ _slip.DueCollection).ToString());

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }


    }
}
