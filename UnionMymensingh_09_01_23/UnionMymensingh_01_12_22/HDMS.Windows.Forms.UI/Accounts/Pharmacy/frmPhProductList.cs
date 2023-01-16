using CrystalDecisions.Windows.Forms;
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

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmPhProductList : Form
    {
        public frmPhProductList()
        {
            InitializeComponent();
        }

        private void frmPhProductList_Load(object sender, EventArgs e)
        {
           
            LoadManufacturer();


        }

        private void LoadManufacturer()
        {
            List<Manufacturer> mList = new PhProductClassificationService().GetManufacturer().ToList();
            mList.Insert(0, new Manufacturer() { ManufacturerId = 0, Name = "Select Manufacturer" });
            cmbManufacturer.DataSource = mList;
            cmbManufacturer.DisplayMember = "Name";
            cmbManufacturer.ValueMember = "ManufacturerId";
            
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {

            Manufacturer _manuf = (Manufacturer)cmbManufacturer.SelectedItem;

            DataSet ds = new PhReportingService().GetProductList(_manuf.ManufacturerId);
             rptProductList _pList = new rptProductList();

             _pList.SetDataSource(ds.Tables[0]);

            if (_manuf.ManufacturerId == 0)
            {
                _pList.SetParameterValue("Manufacturer", "All");
            }
            else
            {
                _pList.SetParameterValue("Manufacturer", cmbManufacturer.Text);
            }
            

            ReportViewer rv = new ReportViewer();
            rv.crviewer. ReportSource = _pList;
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
