using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using Models;
using CrystalDecisions.Windows.Forms;
using Services.POS;

using HDMS.Service;
using HDMS.Model.Users;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Reports.Canteen;

namespace POS.Forms.ReportForm
{
    public partial class frmCantSaleStatement : Form
    {
        public frmCantSaleStatement()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowSalesInvoice();
        }
        private void ShowSalesInvoice()
        {
            string _userName = string.Empty;

            if (cmbuser.Text == "All")
            {
                _userName = "";
            }
            else
            {
                _userName = cmbuser.Text;
            }

            ReportViewer rv = new ReportViewer();
            rptSaleStatement _rpt = new rptSaleStatement();

          
            DateTime Fromdate = dtpFromdate.Value;
             DateTime Todate = dtpTodate.Value;

            DataSet ds = new ReportingService().GetCanteenSaleStatement(Fromdate, Todate, _userName);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm", Fromdate.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dateto", Todate.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("UserName", cmbuser.Text);


          


            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ReportSalesInvoice_Load(object sender, EventArgs e)
        {
               dtpFromdate.Value = DateTime.Now;
                dtpTodate.Value = DateTime.Now;

            LoadUsers();
        }

        private void LoadUsers()
        {
            List<User> _userList = new UserService().GetAll();
            _userList.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbuser.DataSource = _userList;
            cmbuser.DisplayMember = "LoginName";
            cmbuser.ValueMember = "UserId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
