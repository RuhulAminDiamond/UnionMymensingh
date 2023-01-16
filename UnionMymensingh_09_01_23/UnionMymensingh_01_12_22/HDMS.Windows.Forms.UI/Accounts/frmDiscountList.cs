using CrystalDecisions.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts;
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
    public partial class frmDiscountList : Form
    {
        public frmDiscountList()
        {
            InitializeComponent();
        }

        private void frmDiscountList_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

            List<User> _User = new UserService().GetAll();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "Id";
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            cmdShow.Enabled = false;
            cmdShow.Text = "Please wait..";

            DataSet ds = new ReportService().GetDiscountList(dtpfrm.Value, dtpto.Value);

            ReportViewer rv = new ReportViewer();
            rptDiscountList _rpt = new rptDiscountList();

            _rpt.SetDataSource(ds.Tables[0]);


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

             string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));
           


            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Enabled = true;
            cmdShow.Text = "Show";
        }
    }
}
