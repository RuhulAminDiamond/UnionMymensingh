//using HDMS.Service.LogisticSaleUnit;
using CrystalDecisions.Windows.Forms;
using HDMS.Model.SCM.VWModel;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
//using HDMS.Windows.Forms.UI.Reports.Logistics;
using HDMS.Windows.Forms.UI.Reports.SCM;
using Models.Store;
using Services.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Store
{
    public partial class frmStoreRoll : Form
    {
        bool unlocked = true;
        public frmStoreRoll()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptStoreROL _rpt = new rptStoreROL();


            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            string _rptOption = string.Empty;
            VWStoreProductList _pInfo = new VWStoreProductList();
            if (txtProduct.Tag != null)
            {
                _pInfo = txtProduct.Tag as VWStoreProductList;
            }

            StoreGroup group = cmbGroup.SelectedItem as StoreGroup;


            DataSet ds = new StoreItemService().GetROL(Fromdate, Todate, _pInfo.ProductId, group.GroupId);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm", Fromdate.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dateto", Todate.ToString("dd/MM/yyyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void frmStoreRoll_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            List<StoreGroup> grpList = new StoreItemService().GetAllGroups();
            grpList.Insert(0, new StoreGroup() { GroupId = 0, Name = "All" });

            cmbGroup.DataSource = grpList;

            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupId";


            ctlProductSearchControl.Location = new Point(txtProduct.Location.X, txtProduct.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearchControl.Visible = false;
        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControl<VWStoreProductList> sender, VWStoreProductList item)
        {
            txtProduct.Text = item.Name;
            txtProduct.Tag = item;
            // txtProductName.Text = item.Name;
            // txtRate.Text = item.PurchaseRate.ToString();
            // txtRate.Focus();
            sender.Visible = false;
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlProductSearchControl.Visible = true;
                ctlProductSearchControl.LoadDataByType("> ");


            }
        }

        private void ctlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProduct.Focus();
            }
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProduct.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    // LogisticOutlet _outLet = (LogisticOutlet)cmbOutlet.SelectedItem;

                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadDataByType(_txt); // Out let Id appended for outlet specific product loading
                }
            }
        }
    }
}