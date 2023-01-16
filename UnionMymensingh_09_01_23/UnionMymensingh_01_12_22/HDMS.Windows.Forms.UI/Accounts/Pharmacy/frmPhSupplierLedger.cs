using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Models.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Service.Accounting;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;

namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    public partial class frmPhSupplierLedger : Form
    {
        public frmPhSupplierLedger()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhSupplierLedger_Load(object sender, EventArgs e)
        {
            ctrlManufacturerSearchControl.Location = new Point(txtSuplier.Location.X, txtSuplier.Location.Y);
            ctrlManufacturerSearchControl.ItemSelected += ctlSupllierSearchControl_ItemSelected;

            dtpFromdate.Value = Utils.GetServerDateAndTime();
            dtpTodate.Value = Utils.GetServerDateAndTime();
        }

        private void ctlSupllierSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSuplier.Text = item.Name;
            txtSuplier.Tag = item;
            btnShow.Focus();
            sender.Visible = false;
        }

        private void txtSuplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlManufacturerSearchControl.Visible = true;
                ctrlManufacturerSearchControl.LoadData();

            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnShow.Focus();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlManufacturerSearchControl.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            if (txtSuplier.Tag != null)
            {

                Manufacturer _manufacturer = (Manufacturer)txtSuplier.Tag;

                DataSet _ds = new PhFinancialService().GetSupplierLedger(dtpFromdate.Value,dtpTodate.Value, _manufacturer.ManufacturerId);
                rptPhSupplierLedger _rpt = new rptPhSupplierLedger();

                _rpt.SetDataSource(_ds.Tables[0]);



                ReportViewer rv = new ReportViewer();
                string customFmts = "dd/MM/yyyy";
                _rpt.SetParameterValue("datefrm", Utils.GetServerDateAndTime().ToString(customFmts));
                _rpt.SetParameterValue("dateto", Utils.GetServerDateAndTime().ToString(customFmts));

                _rpt.SetParameterValue("Supplier", _manufacturer.Name);

                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
               // rv.crviewer.PrintReport();
                rv.Show();
            
           }else
            {
                MessageBox.Show("Supplier not selected. Plz. select supplier and try again.");
            }
        }
    }
}
