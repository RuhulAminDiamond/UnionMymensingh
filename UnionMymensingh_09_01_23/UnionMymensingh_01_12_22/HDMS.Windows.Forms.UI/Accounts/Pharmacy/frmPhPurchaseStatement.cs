using CrystalDecisions.Windows.Forms;
using HDMS.Model.Pharmacy;
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

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmPhPurchaseStatement : Form
    {
        public frmPhPurchaseStatement()
        {
            InitializeComponent();
        }

        private void frmPhPurchaseStatement_Load(object sender, EventArgs e)
        {
            LoadOutlets();

            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

            ctrlManufacturerSearchControl.Location = new Point(txtSuplier.Location.X, txtSuplier.Location.Y);
            ctrlManufacturerSearchControl.ItemSelected += ctlSupllierSearchControl_ItemSelected;
        }

        private  void ctlSupllierSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSuplier.Text = item.Name;
            txtSuplier.Tag = item;
          
            sender.Visible = false;
        }

        private void LoadOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";

            cmbOutlet.SelectedItem = _outletLists.Find(x => x.OutLetId == 2);


        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int manufacId = 0;
            
            MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

            Manufacturer manufacturer = txtSuplier.Tag as Manufacturer;
            if (manufacturer != null)
            {
                manufacId = manufacturer.ManufacturerId;
            }

            DataSet ds = new PhFinancialService().GetPurchaseStatement(dtpfrm.Value,dtpto.Value, _outLet.OutLetId, manufacId);

         
           ShowBySupplier(ds);
            

        }

        private void ShowBySupplier(DataSet ds)
        {
            rptPurchaseStatementGroupBySupplier _rpt = new rptPurchaseStatementGroupBySupplier();


            _rpt.SetDataSource(ds.Tables[0]);


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            //rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ShowByRInvoice(DataSet ds)
        {
            rptPurchaseStatement _rpt = new rptPurchaseStatement();
       

             _rpt.SetDataSource(ds.Tables[0]);


             DateTime Fromdate = dtpfrm.Value;
             DateTime Todate = dtpto.Value;

             string customFmts = "dd/MM/yyyy";
             _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            //rv.crviewer.PrintReport();
            rv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long RInvoce = 0;
            long.TryParse(txtRInvoice.Text, out RInvoce);
            ShowPurchaseInvoice(RInvoce);
        }

        private void ShowPurchaseInvoice(long _ReceiveId)
        {
            rptPurchaseInvoice _rpt = new rptPurchaseInvoice();

            PhReceive _phInvoice = new PhFinancialService().GetPhReceiveById(_ReceiveId);

            DataSet ds = new PhFinancialService().GetPurchaseInvoice(_ReceiveId);

            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("discount", _phInvoice.DiscountTk);
            _rpt.SetParameterValue("vat", _phInvoice.VatTk);
            _rpt.SetParameterValue("gtotal", _phInvoice.TotalTk);

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
           // rv.crviewer.PrintReport();
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
    }
}
