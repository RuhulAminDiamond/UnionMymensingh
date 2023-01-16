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

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmOrderStatement : Form
    {
        public frmOrderStatement()
        {
            InitializeComponent();
        }

        private void frmOrderStatement_Load(object sender, EventArgs e)
        {
            ctrlManufacturerSearchControl.Location = new Point(txtSuplier.Location.X, txtSuplier.Location.Y);
            ctrlManufacturerSearchControl.ItemSelected += ctrlManufacturerSearchControl_ItemSelected;
        }

        private void ctrlManufacturerSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSuplier.Text = item.Name;
            txtSuplier.Tag = item;

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
        }

        private void HideAllDefaultHidden()
        {
            ctrlManufacturerSearchControl.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            DataSet ds = new PhFinancialService().GetOrderStatement(dtpfrm.Value,dtpto.Value,txtSuplier.Tag as Manufacturer);

            rptOrderStatement _rpt = new rptOrderStatement();


            _rpt.SetDataSource(ds.Tables[0]);


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }
    }
}
