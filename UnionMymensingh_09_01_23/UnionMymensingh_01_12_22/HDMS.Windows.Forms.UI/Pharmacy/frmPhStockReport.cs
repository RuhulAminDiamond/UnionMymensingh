using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils.ComapnyDetail;
using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Users;
using HDMS.Models.Pharmacy;
using HDMS.Service;
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

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmPhStockReport : Form
    {
        public frmPhStockReport()
        {
            InitializeComponent();
        }

        private void frmPhStockReport_Load(object sender, EventArgs e)
        {
            LoadManufacturers();

            LoadOutlets();

            LoadStock("");
        }

        private void LoadManufacturers()
        {
            List<Manufacturer> mList = new PhProductClassificationService().GetManufacturer().ToList();
            mList.Insert(0, new Manufacturer() { ManufacturerId = 0, Name = "Select Manufacturer" });
            cmbManufacturer.DataSource = mList;
            cmbManufacturer.DisplayMember = "Name";
            cmbManufacturer.ValueMember = "ManufacturerId";
        }

        private void LoadStock(string _searchString)
        {
            MedicineOutlet _moutLet = (MedicineOutlet)cmbOutlet.SelectedItem;
            Manufacturer _manufacturer = (Manufacturer)cmbManufacturer.SelectedItem;
            List<VMPhStock> _stckList = new PhProductService().GetPhStock(_moutLet.OutLetId, _searchString, _manufacturer.ManufacturerId).ToList();
            _stckList = _stckList.Where(x => x.StockAvail > 0).ToList();

            dgStock.AutoGenerateColumns = false;
            dgStock.DataSource = _stckList;

            lblTotalItems.Text = _stckList.Count().ToString();
        }

        private void LoadOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";

            //User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            //cmbOutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == _user.AssignedOutLet);

            //if (_user.AssignedOutLet == 0)
            //{
            //    cmbOutlet.Enabled = true;

            //    cmbOutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == 1);
            //}
            //else
            //{
            //    cmbOutlet.Enabled = false;
            //}

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStock(""); //MedicineOutlet _outlet = (MedicineOutlet)cmbOutlet.SelectedItem;
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
           
                LoadStock(txtSearchByName.Text);
            
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

            string _reportHeader = string.Empty;
            int stockParam = 0;
            int.TryParse(txtStock.Text, out stockParam);

            MedicineOutlet _moutLet = (MedicineOutlet)cmbOutlet.SelectedItem;

            Manufacturer _manufacturer = (Manufacturer)cmbManufacturer.SelectedItem;

            _reportHeader = _moutLet.Name + " Stock Report";

            DataSet  _stckds = new PhProductService().GetPhStockDataset(_moutLet.OutLetId, "", stockParam, _manufacturer.ManufacturerId);

            rptPhStock _stockReport = new rptPhStock();

            _stockReport.SetDataSource(_stckds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            //string customFmts = "dd/MM/yyyy";
            //_stockReport.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            //_stockReport.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";


            _stockReport.SetParameterValue("OrgName", ComapnyDetail.CompanyName); 
            _stockReport.SetParameterValue("rptheader", _reportHeader);


            rv.crviewer.ReportSource = _stockReport;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnPrintPreviewOpClosing_Click(object sender, EventArgs e)
        {
            string _reportHeader = string.Empty;
            int stockParam = 0;
            int.TryParse(txtStock.Text, out stockParam);

            MedicineOutlet _moutLet = (MedicineOutlet)cmbOutlet.SelectedItem;

            _reportHeader = _moutLet.Name + " Stock Report";

            DataSet _stckds = new PhProductService().GetPhOpeningClosingStockDataset(dtfrm.Value,dtto.Value);

            rptPhStockStatement _stockReport = new rptPhStockStatement();

            _stockReport.SetDataSource(_stckds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            //string customFmts = "dd/MM/yyyy";
            //_stockReport.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            //_stockReport.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";


            _stockReport.SetParameterValue("OrgName", ComapnyDetail.CompanyName);
            _stockReport.SetParameterValue("ReportHeader", _reportHeader);


            rv.crviewer.ReportSource = _stockReport;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
