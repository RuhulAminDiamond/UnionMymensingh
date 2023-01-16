using CrystalDecisions.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
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

namespace HDMS.Windows.Forms.UI.Accounts.MIS
{
    public partial class frmUserWiseMeidaPaymentList : Form
    {
        SqlDataAdapter da;
        public frmUserWiseMeidaPaymentList()
        {
            InitializeComponent();
        }

        private void ctrlUserSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtUserName.Focus();
        }

        private void frmUserWiseMeidaPaymentList_Load(object sender, EventArgs e)
        {
            ctrlUserSearchControl.Location = new Point(txtUserName.Location.X, txtUserName.Location.Y);

            HideAllControls();
        }


        private void HideAllControls()
        {
            ctrlUserSearchControl.Visible = false;
        }
        private void ctrlUserSearchControl_ItemSelected(Controls.SearchResultListControl<VMUserDetail> sender, VMUserDetail item)
        {
            txtUserName.Text = item.LoginName;
            txtUserName.Tag = item;
            sender.Visible = false;
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllControls();
                ctrlUserSearchControl.Visible = true;
                ctrlUserSearchControl.LoadData();
            }
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Place Select User Name ");

                return;
            }

            VMUserDetail vMUserDetail = txtUserName.Tag as VMUserDetail;
            da = new SqlDataAdapter();
            DataSet dsConsultancy =  new MediaService().GetUserWiseMediayPayment(vMUserDetail.Id, dtpfrm.Value, dtpto.Value);

            //int c = dsReports.Tables[0].Rows.Count;

            rptUserWiseMeidaPaymentList _consultancy = new rptUserWiseMeidaPaymentList();

            _consultancy.SetDataSource(dsConsultancy.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            //  _consultancy.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            // _consultancy.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _consultancy.SetParameterValue("DateFrom", dtpfrm.Value.ToString(customFmts));
            _consultancy.SetParameterValue("DateTo", dtpfrm.Value.ToString(customFmts));


            rv.crviewer.ReportSource = _consultancy;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Enabled = true;
            cmdShow.Text = "Show";





        }
    }
}
