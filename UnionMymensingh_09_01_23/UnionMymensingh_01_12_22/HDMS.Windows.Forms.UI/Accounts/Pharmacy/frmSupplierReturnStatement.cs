using CrystalDecisions.Windows.Forms;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
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
    public partial class frmSupplierReturnStatement : Form
    {
        public frmSupplierReturnStatement()
        {
            InitializeComponent();
        }

        private void frmSupplierReturnStatement_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

            ctrlManufacturerSearchControl.Location = new Point(txtSuplier.Location.X, txtSuplier.Location.Y);
            ctrlManufacturerSearchControl.ItemSelected += ctrlManufacturerSearchControl_ItemSelected;
        }

        private void ctrlManufacturerSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSuplier.Text = item.Name;
            txtSuplier.Tag = item;

            sender.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            rptSupplierReturn _rpt = new rptSupplierReturn();

            int _manufacturerId = 0;

            if (txtSuplier.Tag != null)
            {
                Manufacturer _manufacturer = (Manufacturer)txtSuplier.Tag;
                _manufacturerId = _manufacturer.ManufacturerId;
            }
           
             DataSet ds = new PhProductService().GetPhSupplierReturnStatement(dtpfrm.Value,dtpto.Value, _manufacturerId);

            _rpt.SetDataSource(ds.Tables[0]);


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("datefrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtSuplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlManufacturerSearchControl.Visible = true;
                ctrlManufacturerSearchControl.LoadData();

            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlManufacturerSearchControl.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
