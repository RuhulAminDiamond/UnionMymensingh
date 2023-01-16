using CrystalDecisions.Windows.Forms;
using HDMS.Model.MiniAccount;
using HDMS.Service.Diagonstics;
using HDMS.Service.MiniAccounts;
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

namespace HDMS.Windows.Forms.UI.MiniAccounts
{
    public partial class frmHeadWiseExpenseDetails : Form
    {
        SqlDataAdapter da;
        public frmHeadWiseExpenseDetails()
        {
            InitializeComponent();
        }

        private void frmHeadWiseExpenseDetails_Load(object sender, EventArgs e)
        {
            LoadAccountHeadsByType("Expense");
        }

        private void LoadAccountHeadsByType(string _type)
        {

            cmbHead.DataSource = null;
            cmbHead.ResetText();


            List<MiniAccountHead> _accHeads = new MiniAccountService().GetAccountHeadsByType(_type);

            _accHeads.Insert(0, new MiniAccountHead() { Id = 0, Name = "Select Head" });
            cmbHead.DataSource = _accHeads;

            MiniAccountHead _acc = new MiniAccountHead();
            cmbHead.ValueMember = "Id";
            cmbHead.DisplayMember = "Name";



        }

        private void cmbHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHead.Tag = new MiniAccountService().GetAccountHeadObj(cmbHead.Text);
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            if (cmbHead.Tag != null)
            {
                da = new SqlDataAdapter();
                DataSet dsHeadwiseExpense = new MiniAccountService().GetExpenseDetailsByHead(dtpfrm.Value, dtpto.Value, (MiniAccountHead)cmbHead.Tag);
               
                //int c = dsReports.Tables[0].Rows.Count;

                RptHeadWiseExpenseDetails _rdexpList = new RptHeadWiseExpenseDetails();

                _rdexpList.SetDataSource(dsHeadwiseExpense.Tables[0]);



                ReportViewer rv = new ReportViewer();
                string customFmts = "dd/MM/yyyy";
                
                _rdexpList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
                _rdexpList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
                _rdexpList.DataDefinition.FormulaFields[2].Text = "'" + cmbHead.Text + "'";

                rv.crviewer.ReportSource = _rdexpList;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
            else
            {
                MessageBox.Show("Please select head name.","HERP");
            }
        }
    }
}
