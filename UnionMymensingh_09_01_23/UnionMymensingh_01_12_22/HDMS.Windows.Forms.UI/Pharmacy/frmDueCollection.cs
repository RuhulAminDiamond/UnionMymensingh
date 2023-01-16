using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.Pharmacy;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Service.Hospital;
using System.Data.SqlClient;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.IPD;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Canteen;
using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using HDMS.Model.Common;
using HDMS.Service.Common;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmDueCollection : Form
    {
        public frmDueCollection()
        {
            InitializeComponent();
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadPaymentHistory();
            }
        }

        private void LoadPaymentHistory()
        {
            if (!String.IsNullOrEmpty(txtBillNo.Text))
            {
                long _billNo = 0;
                long.TryParse(txtBillNo.Text, out _billNo);

                PhInvoice _invoice = new PhProductService().GetPhInvoiceByBillNo(_billNo);

                if (_invoice == null)
                {
                    MessageBox.Show("Invoce not found. Please check and try again.");
                    return;
                }

                txtBillNo.Tag = _invoice;

                List<PhSaleLedger> _pLedgerItesms = new PhProductService().GetPhLedgerByInvoice(_invoice.InvoiceId);

                gvLedger.AutoGenerateColumns = false;
                gvLedger.DataSource = _pLedgerItesms;

                double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDouble(t.Cells["Debit"].Value));

                double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDouble(t.Cells["Credit"].Value));

                double due = totalTestAmount - totalPaidAmount;

                if (due > 0)
                {
                    txtDue.Text = due.ToString();
                }
                else
                {

                }

            }

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumeric(txtDiscount.Text))
            {


                double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                         .Sum(t => Convert.ToDouble(t.Cells["Debit"].Value));

                double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDouble(t.Cells["Credit"].Value));

                double total = 0;


                total = totalTestAmount - totalPaidAmount;


                double _discount = 0;
                double.TryParse(txtDiscount.Text, out _discount);


                txtDue.Text = (total - _discount).ToString();

            }
            else
            {

            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            double _discount = 0, _paid = 0;

            double.TryParse(txtDiscount.Text, out _discount);
            double.TryParse(txtPaid.Text, out _paid);


            double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                     .Sum(t => Convert.ToDouble(t.Cells["Debit"].Value));

            double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells["Credit"].Value));


            double totalDue = 0;


            totalDue = totalTestAmount - (totalPaidAmount + _discount + _paid);


            txtDue.Text = Math.Round(totalDue, 0).ToString();

            double _dueTk = 0;
            double.TryParse(txtDue.Text, out _dueTk);

            if (_dueTk < 0)
            {
                MessageBox.Show("Amount mis-matched. Please recheck the payment.", "HERP");


                txtDue.Text = totalDue.ToString();
                txtDiscount.Text = "";

                txtPaid.Text = "";
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            double _discount = 0, _paid = 0;

            double.TryParse(txtDiscount.Text, out _discount);
            double.TryParse(txtPaid.Text, out _paid);


            double paidTk = 0;
            double discount = 0;


            double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                          .Sum(t => Convert.ToDouble(t.Cells["Debit"].Value));

            double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells["Credit"].Value));

            double due = totalTestAmount - (totalPaidAmount + _discount + _paid);

            double balance = totalPaidAmount - totalTestAmount;

            if (txtIPDBillNo.Tag != null)
            {
                //if (due > 0)
                //{ 
                //    MessageBox.Show("Medicine bill due not allowed."); return;
                //}


                HospitalPatientInfo _PInfo = (HospitalPatientInfo)txtIPDBillNo.Tag;

                List<PhIPDSaleLedger> IpdtransactionList = new List<PhIPDSaleLedger>();
                PhIPDSaleLedger ipdLedger = new PhIPDSaleLedger();

                if (_PInfo != null)
                {

                    if (_discount > 0)
                    {
                        discount = Convert.ToDouble(txtDiscount.Text);
                        balance = Math.Round(balance + discount, 0);
                        ipdLedger = new PhIPDSaleLedger();
                        ipdLedger.AdmissionId = _PInfo.AdmissionId;
                        ipdLedger.TranDate = DateTime.Now;
                        ipdLedger.Particulars = "Discount";
                        ipdLedger.Debit = 0;
                        ipdLedger.Credit = discount;
                        ipdLedger.Balance = balance;
                        ipdLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                        ipdLedger.OperateBy = MainForm.LoggedinUser.Name;
                        IpdtransactionList.Add(ipdLedger);
                    }


                    if (_paid > 0)
                    {
                        paidTk = Convert.ToDouble(txtPaid.Text);
                        balance = Math.Round(balance + paidTk, 0);
                        ipdLedger = new PhIPDSaleLedger();
                        ipdLedger.AdmissionId = _PInfo.AdmissionId;
                        ipdLedger.TranDate = DateTime.Now;
                        ipdLedger.Particulars = "Due Collection";
                        ipdLedger.Debit = 0;
                        ipdLedger.Credit = paidTk;
                        ipdLedger.Balance = balance;
                        ipdLedger.TransactionType = TransactionTypeEnum.PhDueCollection.ToString();
                        ipdLedger.OperateBy = MainForm.LoggedinUser.Name;
                        IpdtransactionList.Add(ipdLedger);
                    }

                    if (IpdtransactionList.Count > 0)
                    {
                        PhFinancialService prdService = new PhFinancialService();
                        prdService.SavePhIPDSaleLedger(IpdtransactionList);

                        MessageBox.Show("Payment collection successful", "HERP");
                        LoadPaymentHistory();

                        //Settle the Invoice Bill for IPD Patient

                        SettleDueOfIPdInvoices(_PInfo.BillNo, _discount);

                        //End Settle the Invoice Bill for IPD Patient

                        txtDiscount.Text = "";

                        txtPaid.Text = "";
                    }

                }
            }
            else
            {

                PhInvoice _PhInvoice = (PhInvoice)txtBillNo.Tag;

                List<PhSaleLedger> transactionList = new List<PhSaleLedger>();
                PhSaleLedger pLedger = new PhSaleLedger();


                if (_PhInvoice != null)
                {

                    if (_discount > 0)
                    {
                        discount = Convert.ToDouble(txtDiscount.Text);
                        balance = balance + discount;
                        pLedger = new PhSaleLedger();
                        pLedger.InvoiceId = _PhInvoice.InvoiceId;
                        pLedger.TranDate = DateTime.Now;
                        pLedger.Particulars = "Discount";
                        pLedger.Debit = 0;
                        pLedger.Credit = discount;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                        pLedger.OperateBy = MainForm.LoggedinUser.Name;
                        transactionList.Add(pLedger);
                    }


                    if (_paid > 0)
                    {
                        paidTk = Convert.ToDouble(txtPaid.Text);
                        balance = balance + paidTk;
                        pLedger = new PhSaleLedger();
                        pLedger.InvoiceId = _PhInvoice.InvoiceId;
                        pLedger.TranDate = DateTime.Now;
                        pLedger.Particulars = "Due Collection";
                        pLedger.Debit = 0;
                        pLedger.Credit = paidTk;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.PhDueCollection.ToString();
                        pLedger.OperateBy = MainForm.LoggedinUser.Name;
                        transactionList.Add(pLedger);
                    }

                    if (transactionList.Count > 0)
                    {
                        PhProductService prdService = new PhProductService();
                        prdService.SavePhSaleLedger(transactionList);

                        MessageBox.Show("Payment collection successful", "HERP");
                        LoadPaymentHistory();
                        txtDiscount.Text = "";

                        txtPaid.Text = "";
                    }
                }

            }
        }

        private void SettleDueOfIPdInvoices(long billNo, double discount)
        {


            bool isDiscountSettle = false;
           
            
            List<PhInvoice> _phInvList = new PhFinancialService().GetPhInvoicesByAdmissionNo(billNo);
            PhSaleLedger pLedger = new PhSaleLedger();
            List<PhSaleLedger> _saleLedgerList = new List<PhSaleLedger>();
            foreach (var item in _phInvList)
            {
                List<PhSaleLedger> _curretLedgerForthisInvoice = new PhFinancialService().GetCurrenPhInvoiceLedger(item.InvoiceId);
                double _debit = _curretLedgerForthisInvoice.Sum(x => x.Debit);
                double _credit = _curretLedgerForthisInvoice.Sum(x => x.Credit);
                double _due = _debit - _credit;

                if (!isDiscountSettle && discount <= _due)
                {
                    pLedger = new PhSaleLedger();
                    pLedger = new PhSaleLedger();
                    pLedger.InvoiceId = item.InvoiceId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = discount;
                    pLedger.Balance = 0;
                    pLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _saleLedgerList.Add(pLedger);


                    _due = _due - discount;

                     if(_due>0)
                    {
                        pLedger = new PhSaleLedger();
                        pLedger = new PhSaleLedger();
                        pLedger.InvoiceId = item.InvoiceId;
                        pLedger.TranDate = Utils.GetServerDateAndTime();
                        pLedger.Particulars = "Due Collection";
                        pLedger.Debit = 0;
                        pLedger.Credit = _due;
                        pLedger.Balance = 0;
                        pLedger.TransactionType = TransactionTypeEnum.PhDueCollection.ToString();
                        pLedger.OperateBy = MainForm.LoggedinUser.Name;
                        _saleLedgerList.Add(pLedger);
                    }

                    isDiscountSettle = true;

                }
                else if (!isDiscountSettle && discount > _due)
                {
                    pLedger = new PhSaleLedger();
                    pLedger = new PhSaleLedger();
                    pLedger.InvoiceId = item.InvoiceId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = _due;
                    pLedger.Balance = 0;
                    pLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _saleLedgerList.Add(pLedger);

                    discount = discount - _due;

                    isDiscountSettle = false;

                }
                else
                {

                    pLedger = new PhSaleLedger();
                    pLedger = new PhSaleLedger();
                    pLedger.InvoiceId = item.InvoiceId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.Particulars = "Due Collection";
                    pLedger.Debit = 0;
                    pLedger.Credit = _due;
                    pLedger.Balance = 0;
                    pLedger.TransactionType = TransactionTypeEnum.PhDueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _saleLedgerList.Add(pLedger);
                }
            }

            if (_saleLedgerList.Count > 0)
            {
                new PhFinancialService().SavePhSaleLedgerList(_saleLedgerList);
            }
        }

            

        
    
    



        private void frmDueCollection_Load(object sender, EventArgs e)
        {
            ctlPatientList.Location = new Point(txtIPDBillNo.Location.X, txtIPDBillNo.Location.Y + txtIPDBillNo.Height);

            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;
        }

        private void ctlPatientList_ItemSelected(SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
            txtIPDBillNo.Text = item.BillNo.ToString();
          
           // txtCabin.Text = item.BedCabinNo;

            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(item.BillNo);

            txtIPDBillNo.Tag = _pInfo;

            lblPatientInfo.Text = "Name: " + item.Name + " Cabin: " + item.BedCabinNo;

           // txtProductCode.Focus();
            sender.Visible = false;
            ctlPatientList.Visible = false;

            LoadTransactions(item.AdmissionId);

        }

        private void LoadTransactions(long admissionId)
        {
            List<PhIPDSaleLedger> _ipdList = new PhFinancialService().GetIPDTransactions(admissionId);
            FillIPDTransactionGrid(_ipdList);
        }

        private void FillIPDTransactionGrid(List<PhIPDSaleLedger> _ipdList)
        {
            gvLedger.SuspendLayout();
            gvLedger.Rows.Clear();
            foreach(var item in _ipdList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(gvLedger, item.TranDate.ToString("dd/MM/yyyy"),item.Debit,item.Credit, item.Balance, item.Particulars,item.OperateBy);

                gvLedger.Rows.Add(row);
            }

            CalculateAmount(_ipdList);
        }

        private void CalculateAmount(List<PhIPDSaleLedger> _ipdtranList)
        {
            double totalAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                      .Sum(t => Convert.ToDouble(t.Cells["Debit"].Value));

            double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells["Credit"].Value));

            txtTotalTk.Text = totalAmount.ToString();

            double due = totalAmount - totalPaidAmount;

            double _discount = _ipdtranList.Where(x => x.TransactionType == TransactionTypeEnum.PhDiscount.ToString()).Sum(t => t.Credit);
            double _refund = _ipdtranList.Where(x => x.TransactionType == TransactionTypeEnum.PhRefund.ToString()).Sum(t => t.Credit);

            txtDiscountTk.Text = _discount.ToString();

            txtCancelled.Text = _refund.ToString();

            totalPaidAmount = totalPaidAmount - (_discount + _refund);

            txtPaidTk.Text = totalPaidAmount.ToString();


            if (due > 0)
            {
                txtDue.Text = Math.Round(due,0).ToString();
            }
            else
            {
                txtDue.Text = "";
            }
        }

        private void txtIPDBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlPatientList.Visible = true;
                ctlPatientList.LoadData();
            }

            long billNo = 0;
            long.TryParse(txtIPDBillNo.Text, out billNo);

            if (e.KeyChar == (char)Keys.Enter)
            {
                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(billNo);

                if (_pInfo != null)
                {
                    txtIPDBillNo.Tag = _pInfo;
                    RegRecord rr = new RegRecordService().GetRegRecordByRegNo(_pInfo.RegNo);
                    if (rr != null) {
                        lblPatientInfo.Text = rr.FullName;
                    }
                    LoadTransactions(_pInfo.AdmissionId);
                }
            }


        }

        private void HideAllDefaultHidden()
        {
            ctlPatientList.Visible = false;
        }

        private void cmdPrintReceipt_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            long.TryParse(txtBillNo.Text,out _billNo);

            PhInvoice _Invoice = new PhProductService().GetPhInvoiceByBillNo(_billNo);

            if (_Invoice != null)
            {
                PrintSaleInvoice(_Invoice.InvoiceId);
            }else
            {
                MessageBox.Show("Invalid bill no.");
            }

        }

        private void PrintSaleInvoice(long invocieId)
        {

            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            DataSet ds = new PhReportingService().GetSaleEntryDataSetByinvocieId(invocieId);

            rptPosSaleInvoice2 _rpt = new rptPosSaleInvoice2();

            _rpt.SetDataSource(ds.Tables[0]);

            PhInvoice _pInvoice = new PhReportingService().GetPhInvoiceById(invocieId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetPhCashMemoTransactionList(_pInvoice,"");

            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _rpt.SetParameterValue(p1, litem.Label);
                _rpt.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rpt.SetParameterValue(p3, litem.Value.ToString() + ".00");
                }
                else
                {
                    _rpt.SetParameterValue(p3, litem.Value.ToString() + ".00");
                }

                if (litem.IsDue)
                {
                    isDue = true;
                }

                if (litem.IsDicounted)
                {
                    isDiscounted = true;
                }



            }

            for (int _count = _index + 1; _count <= 5; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rpt.SetParameterValue(p1, "");
                _rpt.SetParameterValue(p2, "");
                _rpt.SetParameterValue(p3, "");
            }



            _rpt.SetParameterValue("CompanyName", "Mount Adhora Pharmacy");
          //  _rpt.SetParameterValue("CustomerName", "");

         //   _rpt.SetParameterValue("CustMobile", "");

            if (Configuration.ORG_CODE == "1")
            {
                _rpt.SetParameterValue("CAddress", "Nayasarak, Mirboxtula, Sylhet.");
                _rpt.SetParameterValue("CMobile", "01316-209558");
            }
            else
            {
                _rpt.SetParameterValue("CAddress", "Akhalia, Sylhet");
                _rpt.SetParameterValue("CMobile", "01316-209575");
            }

            //RptSaleProduct _rpt = new RptSaleProduct();


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HospitalPatientInfo _pInfo = (HospitalPatientInfo)txtIPDBillNo.Tag;

            if (_pInfo != null)
            {

                VMIPDInfo _ipdPatient = new HospitalService().GetIPDInfoById(_pInfo.AdmissionId);

                DataSet _ds = new PhFinancialService().GetIndoorSaleLedger(_pInfo.AdmissionId);
                IndoorPatientMedicineLadger _rpt = new IndoorPatientMedicineLadger();

                _rpt.SetDataSource(_ds.Tables[0]);



                ReportViewer rv = new ReportViewer();
                string customFmts = "dd/MM/yyyy";
                _rpt.SetParameterValue("BillNo", txtIPDBillNo.Text);
                _rpt.SetParameterValue("Name", _ipdPatient.Name);
                _rpt.SetParameterValue("Addate", _pInfo.AddmissionDate.ToString(customFmts));


                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        }
    }
}
