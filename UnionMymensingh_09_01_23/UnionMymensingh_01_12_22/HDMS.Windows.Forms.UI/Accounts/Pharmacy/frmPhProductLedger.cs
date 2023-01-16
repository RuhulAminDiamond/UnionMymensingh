using CrystalDecisions.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
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
    public partial class frmPhProductLedger : Form
    {

        bool unlocked = true;


        public frmPhProductLedger()
        {
            InitializeComponent();
        }

        private void frmPhProductLedger_Load(object sender, EventArgs e)
        {
            ctrlProductSearch.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y+txtProductCode.Height);
            ctrlProductSearch.ItemSelected += CtrlProductSearch_ItemSelected1; ;

            LoadOutLets();
        }

        private void CtrlProductSearch_ItemSelected1(Controls.SearchResultListControl<VWPhProductList> sender, VWPhProductList item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
        
         
            sender.Visible = false;
        }

        private void LoadOutLets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";
        }

        private void CtrlProductSearch_ItemSelected(Controls.SearchResultListControl<VWPhProductInfo> sender, VWPhProductInfo item)
        {
            txtProductCode.Text = item.BrandName;
            txtProductCode.Tag = item;
            sender.Visible = false;
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlProductSearch.Visible = true;
                ctrlProductSearch.LoadDataByType("");
            }
        }

        private void ctrlProductSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            if (txtProductCode.Tag == null)
            {
                MessageBox.Show("Plz. select a product and try again."); return;
            }

            MedicineOutlet _outlet = cmbOutlet.SelectedItem as MedicineOutlet;
            if(_outlet.OutLetId==0)
            {
                MessageBox.Show("Plz. select outlet and try again. Thank you."); return;

            }


            cmdShow.Text = "Plz. Wait..";
            cmdShow.Enabled = false;

            DataSet ds = new PhProductService().GetPhProductLedger(dtpfrm.Value, dtpto.Value,txtProductCode.Tag as VWPhProductList, _outlet.OutLetId);

            //int c = dsReports.Tables[0].Rows.Count;

            rptPhProductLedger _opcList = new rptPhProductLedger();

            _opcList.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            _opcList.SetParameterValue("datefrm", dtpfrm.Value.ToString(customFmts));
            _opcList.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));
            _opcList.SetParameterValue("brandName", txtProductCode.Text);
            _opcList.SetParameterValue("prodId", (txtProductCode.Tag as VWPhProductList).ProductId);
            _opcList.SetParameterValue("outlet", cmbOutlet.Text);
            rv.crviewer.ReportSource = _opcList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            //rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Text = "Show";
            cmdShow.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

                    ctrlProductSearch.Visible = true;
                    ctrlProductSearch.txtSearch.Text = _txt;
                    ctrlProductSearch.txtSearch.SelectionStart = ctrlProductSearch.txtSearch.Text.Length;

                    ctrlProductSearch.LoadDataByType(_txt + ">" + _outLet.OutLetId.ToString()); // Out let Id appended for outlet specific product loading
                }

            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlProductSearch.Visible = false;
        }
    }
}
