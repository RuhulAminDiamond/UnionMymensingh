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
using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using CrystalDecisions.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmStockPrint : Form
    {
        public frmStockPrint()
        {
            InitializeComponent();
        }

        private void frmStockPrint_Load(object sender, EventArgs e)
        {
           
            ctlSupllierSearchControl.ItemSelected += ctlSupllierSearchControl_ItemSelected;

            LoadOutlets();

            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;
        }

        private void ctlSupllierSearchControl_ItemSelected(SearchResultListControl<SupplierInfo> sender, SupplierInfo item)
        {
            txtSuplier.Text = item.Name;
            txtSuplier.Tag = item;
            dtpfrm.Focus();
            sender.Visible = false;
        }

        private void txtSuplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlSupllierSearchControl.Visible = true;
                ctlSupllierSearchControl.LoadData();

            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpfrm.Focus();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlSupllierSearchControl.Visible = false;
        }

        private void LoadOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

            if (_outLet.OutLetId == 0)
            {
                MessageBox.Show("Medicine outlet not selected."); return;
            }

            DataSet ds = new PhProductService().GetPhStockByDate(dtpfrm.Value,dtpto.Value, _outLet.OutLetId);

            rptPhStockByDate _rptStock = new rptPhStockByDate();

            _rptStock.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _rptStock.SetParameterValue("datefrm",dtpfrm.Value.ToString(customFmts));
            _rptStock.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));


            rv.crviewer.ReportSource = _rptStock;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
