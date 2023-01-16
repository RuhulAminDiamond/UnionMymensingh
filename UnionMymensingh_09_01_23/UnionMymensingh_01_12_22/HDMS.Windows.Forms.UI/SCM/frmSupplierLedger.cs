using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Windows.Forms.UI.Controls;
using Services.Store;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;

namespace HDMS.Windows.Forms.UI.Store
{
    public partial class frmSupplierLedger : Form
    {
        public frmSupplierLedger()
        {
            InitializeComponent();
        }

        private void frmSupplierLedger_Load(object sender, EventArgs e)
        {
            HiddenDefault();

            ctlSupplierSearch.Location = new Point(txtCustomer.Location.X, txtCustomer.Location.Y + txtCustomer.Height);
            ctlSupplierSearch.ItemSelected += ctlSupplierSearch_ItemSelected;


            dtpFromdate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;
        }

        private void ctlSupplierSearch_ItemSelected(SearchResultListControl<SupplierInfo> sender, SupplierInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item;
            sender.Visible = false;
        }

        private void HiddenDefault()
        {
            ctlSupplierSearch.Visible = false;
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlSupplierSearch.Visible = true;
                ctlSupplierSearch.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlSupplierSearch.Visible = false;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptCustomerLedger _rpt = new rptCustomerLedger();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("Member not selected."); return;
            }

            SupplierInfo _mInfo = (SupplierInfo)txtCustomer.Tag;


            DataSet ds = new StoreItemService().GetSupplierLedger(_mInfo.SupplierId, Fromdate.Date, Todate.Date);
            _rpt.SetDataSource(ds.Tables[0]);
            // Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            _rpt.SetParameterValue("companyName", "Khandaker Alkash and Amina Hospital");
            _rpt.SetParameterValue("CustomerName", txtCustomer.Text);

            _rpt.SetParameterValue("dtfrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dtto", dtpTodate.Value.ToString("dd/MM/yyyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
