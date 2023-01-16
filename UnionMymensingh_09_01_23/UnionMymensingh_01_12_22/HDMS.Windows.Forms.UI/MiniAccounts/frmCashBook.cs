using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using HDMS.Windows.Forms.UI.Reports.Accounts;
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

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmCashBook : Form
    {
        SqlDataAdapter da;
        public frmCashBook()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            string CheckPaymentState = string.Empty;

            if (cmbUser.Text == "")
            {
                MessageBox.Show("Please select user.","HERP");
                return;
            }

            if (chkWithoutCheck.Checked)
            {
                CheckPaymentState = chkWithoutCheck.Tag.ToString();
            }
            else if(chkWithCheck.Checked)
            {
                CheckPaymentState = chkWithCheck.Tag.ToString();
            }
            else
            {
                CheckPaymentState = "All";
            }


            BusinessUnit _bUnit = (BusinessUnit)cmbBusinessUnit.SelectedItem;
            DataSet dsCashBook = new DataSet();
            if (_bUnit.BusinessUnitId == 0)
            {
                MessageBox.Show("Plz. select business unit and try again."); return;
            }
            else if (_bUnit.BusinessUnitId == 1)
            {
                dsCashBook = new ReportService().GetCashBookDiag(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            }
            else if (_bUnit.BusinessUnitId == 2)
            {
                dsCashBook = new ReportService().GetCashBookHos(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            }
            else if (_bUnit.BusinessUnitId == 3)
            {
                dsCashBook = new ReportService().GetCashBookPhar(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            }
            else
            {
                dsCashBook = new ReportService().GetCashBook(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            }

            DataTable table=new DataTable();
            double _total = new ReportService().GetCashBookTotal();
            double _creditTotal = new ReportService().GetCashBookCreditTotal();
            double _debitTotal = new ReportService().GetCashBookDebitTotal();

            RptCashBook _rptCashBook = new RptCashBook();

            _rptCashBook.SetDataSource(dsCashBook.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _rptCashBook.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _rptCashBook.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
            _rptCashBook.DataDefinition.FormulaFields[2].Text = "'" + _total + "'";
            _rptCashBook.DataDefinition.FormulaFields[3].Text = "'" + _creditTotal + "'";
            _rptCashBook.DataDefinition.FormulaFields[4].Text = "'" + _debitTotal + "'";
            _rptCashBook.DataDefinition.FormulaFields[5].Text = "'" + cmbUser.Text + "'";
            //_cashmemo.DataDefinition.FormulaFields[4].Text = txtDue.Text;
            rv.crviewer.ReportSource = _rptCashBook;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }


        private void frmCashBook_Load(object sender, EventArgs e)
        {
            chkWithCheck.Checked = false;
            chkWithoutCheck.Checked = true;

            List<User> _User = new UserService().GetAll();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "UserId";

            List<BusinessUnit> _bUnits = new CommonService().GetbusinessUnit();
            _bUnits.Insert(0, new BusinessUnit() { BusinessUnitId = 0, Name = "Select B.Unit" });

            cmbBusinessUnit.DataSource = _bUnits;
            cmbBusinessUnit.DisplayMember = "Name";
            cmbBusinessUnit.ValueMember = "BusinessUnitId";

        }

        private void chkWithoutCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithoutCheck.Checked)
            {
                chkWithCheck.Checked = false;
            }
        }

        private void chkWithCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithCheck.Checked)
            {
                chkWithoutCheck.Checked = false;
            }
        }

        private void btnShowByDate_Click(object sender, EventArgs e)
        {
            string CheckPaymentState = string.Empty;

            if (cmbUser.Text == "")
            {
                MessageBox.Show("Please select user.", "HERP");
                return;
            }

            if (chkWithoutCheck.Checked)
            {
                CheckPaymentState = chkWithoutCheck.Tag.ToString();
            }
            else if (chkWithCheck.Checked)
            {
                CheckPaymentState = chkWithCheck.Tag.ToString();
            }
            else
            {
                CheckPaymentState = "All";
            }


            BusinessUnit _bUnit = (BusinessUnit)cmbBusinessUnit.SelectedItem;
            DataSet dsCashBook = new DataSet();
            //if (_bUnit.BusinessUnitId == 0)
            //{
            //    MessageBox.Show("Plz. select business unit and try again."); return;
            //}
            //else if (_bUnit.BusinessUnitId == 1)
            //{
            //    dsCashBook = new ReportService().GetCashBookDiagDateWise(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            //}
            //else if (_bUnit.BusinessUnitId == 2)
            //{
            //    dsCashBook = new ReportService().GetCashBookHosDateWise(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            //}
            //else if (_bUnit.BusinessUnitId == 3)
            //{
            //    dsCashBook = new ReportService().GetCashBookPharDateWise(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            //}
            //else
            //{
            //    dsCashBook = new ReportService().GetCashBook(dtpfrm.Value, dtpto.Value, CheckPaymentState, cmbUser.Text, _bUnit.BusinessUnitId);
            //}




            DataTable table = new DataTable();

            double _total = new ReportService().GetCashBookTotal();
            double _creditTotal = new ReportService().GetCashBookCreditTotal();
            double _debitTotal = new ReportService().GetCashBookDebitTotal();

            //RptCashBookDateWise _rptCashBook = new RptCashBookDateWise();

            //_rptCashBook.SetDataSource(dsCashBook.Tables[0]);
            //ReportViewer rv = new ReportViewer();
            //string customFmts = "dd/MM/yyyy";
            //_rptCashBook.SetParameterValue("dtpfrm", dtpfrm.Value.ToString(customFmts));
            //_rptCashBook.SetParameterValue("dtpto", dtpto.Value.ToString(customFmts));
            
            //rv.crviewer.ReportSource = _rptCashBook;
            //rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            //rv.crviewer.PrintReport();
            //rv.Show();
        }
    }
}
