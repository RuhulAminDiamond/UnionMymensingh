using CrystalDecisions.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
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
    public partial class frmPhStockTransferStatement : Form
    {
        public frmPhStockTransferStatement()
        {
            InitializeComponent();
        }

        private void frmPhStockTransferStatement_Load(object sender, EventArgs e)
        {
            LoadfromOutLets();
            LoadTooutlets();
        }

        private void LoadTooutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbToOutlet.DataSource = _outletLists;
            cmbToOutlet.DisplayMember = "Name";
            cmbToOutlet.ValueMember = "OutletId";

        }

        private void LoadfromOutLets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbFromOutlet.DataSource = _outletLists;
            cmbFromOutlet.DisplayMember = "Name";
            cmbFromOutlet.ValueMember = "OutletId";
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            MedicineOutlet _fromoutlet = (MedicineOutlet)cmbFromOutlet.SelectedItem;
            MedicineOutlet _tooutlet = (MedicineOutlet)cmbToOutlet.SelectedItem;

            if (_fromoutlet.OutLetId == 0 || _tooutlet.OutLetId==0)
            {
                MessageBox.Show("Plz. select outlet and try again."); return;
            }

            DataSet ds = new PhProductService().GetPhStockTransferStatement(dtpfrm.Value,dtpto.Value, _fromoutlet.OutLetId, _tooutlet.OutLetId);

            rptPhStockTransferStatement _rpt = new rptPhStockTransferStatement();

            _rpt.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();

            _rpt.SetParameterValue("datefrm", dtpfrm.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("frmOutlet", cmbFromOutlet.Text);
            

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
