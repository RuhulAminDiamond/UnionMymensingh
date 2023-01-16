using CrystalDecisions.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Service.Accounting;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.FormalAccounts
{
    public partial class frmVoucherStatement : Form
    {
        public frmVoucherStatement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVoucherStatement_Load(object sender, EventArgs e)
        {
            dtpFromdate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();
            dtpTodate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();

            
            List<User> accountsUsers = new AccountService().GetAccountsUsers();
            accountsUsers.Insert(0, new User() {UserId=0, LoginName = "All" });

            cmbUser.DataSource = accountsUsers;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "UserId";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            User user = cmbUser.SelectedItem as User;

            string _voucherType = string.Empty;
            string _drcr = string.Empty;
            String ReportTitle = string.Empty;
            if (radIncome.Checked)
            {
                _voucherType = "Credit";
                 _drcr = "C";
                 ReportTitle = "Income Vouchers";
            }
            else if (radExpense.Checked)
            {
                _voucherType = "Debit";
                _drcr = "D";
                ReportTitle = "Expense Vouchers";
            }
            else
            {
                _voucherType = "Journal";
                _drcr = "JV";
                ReportTitle = "Journal Vouchers";
            }
            
            
            ReportViewer rv = new ReportViewer();
            rptVoucherStatement _rpt = new rptVoucherStatement();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;
            string customFmts = "dd/MM/yyyy";
          
            DataSet ds = new AccountService().GetVoucherStatement(dtpFromdate.Value, dtpTodate.Value, _voucherType, _drcr, user.LoginName);
            _rpt.SetDataSource(ds.Tables[0]);

            double _grandTotal = Math.Round(ds.Tables[0].AsEnumerable().Sum(x => x.Field<Double>("Amount")));

            _rpt.SetParameterValue("datefrm", Fromdate.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString(customFmts));
            _rpt.SetParameterValue("ReportTitle", ReportTitle + " (" + user.LoginName + ")");
            _rpt.SetParameterValue("Inwords", Spell.SpellAmount.InWrods(Convert.ToDecimal(_grandTotal)));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
