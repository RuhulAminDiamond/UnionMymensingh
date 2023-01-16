using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Models.Pharmacy;
using HDMS.Service.Diagonstics;
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
    public partial class frmSupplierPayment : Form
    {

        Manufacturer supplier;
        PhReceive receive;
        public frmSupplierPayment()
        {
            InitializeComponent();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupplierPayment_Load(object sender, EventArgs e)
        {
            ctrlmanufacturerSearchControl.Visible = false;
            ctrlmanufacturerSearchControl.Location =new Point(txtSuplier.Location.X, txtSuplier.Location.Y+txtSuplier.Height);
            ctrlmanufacturerSearchControl.ItemSelected += ctrlmanufacturerSearchControl_ItemSelected;
        }

        private void ctrlmanufacturerSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSuplier.Text =item.Name;
            txtSuplier.Tag =item;
            sender.Visible =false;
            supplier = txtSuplier.Tag as Manufacturer;
            double balance = 0;
            if (supplier!=null)
            {
                receive = new PhFinancialService().GetPhReceiveByManufacturerId(supplier.ManufacturerId);
                balance = new PhFinancialService().GetManuFactureLedger(supplier.ManufacturerId);
               
            }
            lblBalance.Text = balance.ToString();

        }

        private void txtSuplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Space)
            {
                ctrlmanufacturerSearchControl.Visible = true;
                ctrlmanufacturerSearchControl.LoadData();
                
            }
        }

        private void ctrlmanufacturerSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if(IsEscaped)
            {
                txtSuplier.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtSuplier.Tag == null)
            {
                MessageBox.Show("Please Select Supplier Name");
                return;
            }
            DataSet ds = new ReportService().GetSupplierPaymentList(supplier.ManufacturerId,dtpfrm.Value,dtpto.Value);
            
            Manufacturer supplierInfo = txtSuplier.Tag as Manufacturer;
            
            ReportViewer rv = new ReportViewer();
            rptSupplierPaymentDetails rpt = new rptSupplierPaymentDetails();
            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            string customFmts = "dd/MM/yyyy";

            rpt.SetDataSource(ds.Tables[0]);

            rpt.SetParameterValue("dtfrm", dtpfrm.Value.Date.ToString(customFmts));
            rpt.SetParameterValue("dtto", dtpto.Value.Date.ToString(customFmts));
            rpt.SetParameterValue("SupplierName",supplierInfo.Name);



            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            double pay = 0;
            double.TryParse(txtPayment.Text, out pay);

            if (pay>0)
            {
                double balance = 0;
                double.TryParse(lblBalance.Text, out balance);
                balance = balance - pay;
                dtpDate.Value =Utils.GetServerDateAndTime();
                ManufacturerLedger ledger =new ManufacturerLedger();
                ledger.Credit = 0;
                ledger.Debit = pay;
                ledger.ManufacturerId = supplier.ManufacturerId;
                ledger.Trandate = dtpDate.Value;
                ledger.Particulars = txtRemarks.Text;
                ledger.Balance = balance;
                if(new PhFinancialService().SaveManufacturerLedger(ledger))
                {
                    MessageBox.Show("Payment Saved Successfully");

                    txtPayment.Text = "";
                    txtRemarks.Text = "";
                    txtSuplier.Text = "";
                }

            }
        }



        private void frmSupplierPayment_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ctrlmanufacturerSearchControl_Load(object sender, EventArgs e)
        {

        }
    }
}
