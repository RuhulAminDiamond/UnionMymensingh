using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model.Enums;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using HDMS.Service.OPD;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Reports.OPD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class frmOPDCashCollection : Form
    {
        DataSet ds;

        public frmOPDCashCollection()
        {
            InitializeComponent();
        }

        private void txtOPDBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadServices();

                LoadPaymentHistory();
            }
        }

        private void LoadPaymentHistory()
        {
            //if (!String.IsNullOrEmpty(txtOPDBillNo.Text))
            //{
               // if (Utility.IsNumeric(txtOPDBillNo.Text))
               // {
                    long _billNo = 0;
                    long.TryParse(txtOPDBillNo.Text, out _billNo);

                    OPDPatientRecord _patient = new OPDPatientService().GetPatientByPatientId(_billNo);
                    txtOPDBillNo.Tag = _patient;
                    gvLedger.Rows.Clear();
                    List<OPDPatientLedgerRough> _pLedger = new OPDPatientLedgerService().GetLedgerByPatientId(_patient.PatientId);
                    List<DiagPatientLedgerViewModel> _Lvm = new List<DiagPatientLedgerViewModel>();
                    foreach (OPDPatientLedgerRough _PL in _pLedger)
                    {
                        DiagPatientLedgerViewModel lvm = new DiagPatientLedgerViewModel();
                        lvm.Date = _PL.TranDate;
                        lvm.TestAmount = _PL.Debit;
                        lvm.PaidAmount = _PL.Credit;
                        lvm.Balance = _PL.Balance;
                        lvm.Particulars = _PL.Particulars;
                        lvm.OperateBy = _PL.OperateBy;
                        _Lvm.Add(lvm);
                    }

                    var bindingList = new BindingList<DiagPatientLedgerViewModel>(_Lvm);
                    var source = new BindingSource(bindingList, null);
                    gvLedger.AutoGenerateColumns = true;
                    gvLedger.DataSource = source;

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


               // }
            //}

        }

        private void LoadServices()
        {

            string _serviceType = string.Empty;

            long _billNo = 0;
            long.TryParse(txtOPDBillNo.Text, out _billNo);

            OPDPatientRecord _PatientInfo = new OPDPatientService().GetPatientByPatientId(_billNo);

            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");

            }
            else
            {

                dtpEntry.Value = _PatientInfo.EntryDate;


                if (!String.IsNullOrEmpty(_PatientInfo.Status))
                {
                    OPDServiceCost _sCost = new OPDPatientService().GetOPDServiceCost(_PatientInfo.PatientId);

                    if(_sCost.GroupId == 3)
                    {
                        _serviceType = "Consultant";
                    }
                    else
                    {
                        _serviceType = "Others";
                    }

                    dtpEntry.Tag = _serviceType;

                    DataSet ds = new OPDReportService().GetServiceList(_PatientInfo.PatientId, _serviceType);

                    DataTable dt = ds.Tables[0];



                    _SelectedServices = (from DataRow dr in dt.Rows
                                      select new VMSelectedService()
                                      {
                                          ServiceHeadId = Convert.ToInt32(dr["ServiceOrConsultantId"]),
                                          ServiceGroupId = Convert.ToInt32(dr["GroupId"].ToString()),
                                          ServiceHeadName = dr["ServiceHeadName"].ToString(),
                                          Rate = Convert.ToDouble(dr["Rate"]),
                                          Qty = Convert.ToInt32(dr["Qty"].ToString()),
                                          Amount = Convert.ToDouble(dr["TAmount"].ToString())
                                      }).ToList();


                    FillTestGrid();

                   SetTotalAmount(_PatientInfo.PatientId);


                }
                else
                {
                    MessageBox.Show("This is a cancelled Id.", "HERP");

                }
            
        }
    }

        private void SetTotalAmount(long patientId)
        {
            double total = _SelectedServices.Sum(x => x.Amount);


            txtTestCostTk.Text = total.ToString();
            txtPaidTk.Text = new OPDPatientLedgerService().GetPaidTk(patientId).ToString();

            double _discount = new OPDPatientLedgerService().GetDicountTk(patientId);
            if (_discount > 0)
            {
                txtDiscountInPercent.Enabled = false;  // If discount given previously, discount in percent not allowed until and unless transactions are reseted.
            }

            txtDiscountTk.Text = _discount.ToString();
            txtCancelled.Text = new OPDPatientLedgerService().GetCancelledAmount(patientId).ToString();
            txtDue.Text = new OPDPatientLedgerService().GetPatientLedgerBalance(patientId).ToString();



            //new PatientService().GetInitialTestCost(_PatientId);

            double balance = new OPDPatientLedgerService().GetCurrentBalance(patientId);

            if (balance > 0)
            {
                //txtReturnableTk.Text = Math.Abs(balance).ToString();
            }
        }

        private void FillTestGrid()
        {
            dgService.SuspendLayout();
            dgService.Rows.Clear();
            foreach (VMSelectedService item in _SelectedServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgService, item.ServiceHeadName, item.Rate, item.Qty, item.Amount, item.EnteredBy, false);
                dgService.Rows.Add(row);
            }

            //CalculateTotalAmount();
        }

        private IList<VMSelectedService> _SelectedServices;
        private void frmOPDCashCollection_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiscountInPercent_TextChanged(object sender, EventArgs e)
        {
            SetPercentDiscountAmount();
        }

        private void SetPercentDiscountAmount()
        {
            double lessInPercent = 0, totalLess = 0;
            double _prevDisc = 0, prevPaid = 0;

            double.TryParse(txtDiscountTk.Text, out _prevDisc);
            double.TryParse(txtPaidTk.Text, out prevPaid);

            double.TryParse(txtDiscountInPercent.Text, out lessInPercent);

            double total = dgService.Rows.Cast<DataGridViewRow>()
                                .Sum(t => Convert.ToDouble(t.Cells[3].Value));

            
            // double total = _SelectedTests.Where(item => item.ReportTypeId != 47).Sum(item => item.Cost);

            if (total > 0)
            {

                totalLess = (total * lessInPercent) / 100;

                txtDiscount.Text = totalLess.ToString();


            }

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumeric(txtDiscount.Text))
            {


                double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                         .Sum(t => Convert.ToDouble(t.Cells[1].Value));

                double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDouble(t.Cells[2].Value));

                double total = 0;

                //if (IsTRansactionReseted)
                //{
                //    total = totalTestAmount;

                //}
                //else
                //{
                total = totalTestAmount - totalPaidAmount;
                //}



                if (!String.IsNullOrEmpty(txtDiscount.Text))
                {
                    txtDue.Text = (total - Convert.ToDouble(txtDiscount.Text)).ToString();
                }
                else
                {
                    txtDue.Text = total.ToString();
                }
            }
            else
            {
                // MessageBox.Show("Please enter only numbers");
                //txtDiscount.Text = txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1);
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            double _discount = 0, _paid = 0;

            double.TryParse(txtDiscount.Text, out _discount);
            double.TryParse(txtPaid.Text, out _paid);


            double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                     .Sum(t => Convert.ToDouble(t.Cells[1].Value));

            double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells[2].Value));


            double totalDue = 0;

         
            totalDue = totalTestAmount - (totalPaidAmount + _discount + _paid);
         

            txtDue.Text = totalDue.ToString();



            if (totalDue < 0)
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

            long _billNo = 0;

            long.TryParse(txtOPDBillNo.Text, out _billNo);

            OPDPatientRecord _patient = new OPDPatientService().GetPatientByPatientId(_billNo);


            long RegNo = _patient.PatientId;

            double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                          .Sum(t => Convert.ToDouble(t.Cells[1].Value));

            double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells[2].Value));

            double due = totalTestAmount - (totalPaidAmount + _discount + _paid);


            List<OPDPatientLedgerRough> transactionList = new List<OPDPatientLedgerRough>();
            OPDPatientLedgerRough pLedger = new OPDPatientLedgerRough();



            double balance = totalPaidAmount - totalTestAmount;


            double paidTk = 0;
            double discount = 0;
            OPDPatientRecord _Patient = (OPDPatientRecord)txtOPDBillNo.Tag;
            if (_Patient != null && _Patient.EntryDate < DateTime.Now.Date)
            {

                if (!String.IsNullOrEmpty(txtDiscount.Text) && Convert.ToDouble(txtDiscount.Text) > 0)
                {
                    discount = Convert.ToDouble(txtDiscount.Text);
                    balance = balance + discount;
                    pLedger = new OPDPatientLedgerRough();
                    pLedger.PatientId = RegNo;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = discount;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DiscountOnDueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }


                if (!String.IsNullOrEmpty(txtPaid.Text) && Convert.ToDouble(txtPaid.Text) > 0)
                {
                    paidTk = Convert.ToDouble(txtPaid.Text);
                    balance = balance + paidTk;
                    pLedger = new OPDPatientLedgerRough();
                    pLedger.PatientId = RegNo;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Due Collection";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }

                
            }
            else
            {

                if (!String.IsNullOrEmpty(txtDiscount.Text) && Convert.ToDouble(txtDiscount.Text) > 0)
                {
                    discount = Convert.ToDouble(txtDiscount.Text);
                    balance = balance + discount;
                    pLedger = new OPDPatientLedgerRough();
                    pLedger.PatientId = RegNo;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = discount;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DiscountOnRegularCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }

                if (!String.IsNullOrEmpty(txtPaid.Text) && Convert.ToDouble(txtPaid.Text) > 0)
                {
                    paidTk = Convert.ToDouble(txtPaid.Text);
                    balance = balance + paidTk;
                    pLedger = new OPDPatientLedgerRough();
                    pLedger.PatientId = RegNo;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "On Entry Payment";
                    pLedger.Debit = 0;
                    pLedger.Credit = paidTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.OnEntryPayment.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }

                //new PatientService().SetDueOnDailyStatement(RegNo, due, _discount);

            }


            if (transactionList.Count > 0)
            {
                OPDPatientLedgerService plService = new OPDPatientLedgerService();
                plService.SavePatientLedgerRough(transactionList);

                MessageBox.Show("Payment collection successful", "HERP");

                if (due == 0)
                {
                    _patient.Status= OPDPatientStatusEnum.Released.ToString();
                    new OPDPatientService().UpdateOPDPatientInfo(_patient);
                }

                LoadPaymentHistory();



                txtDiscount.Text = "";

                txtPaid.Text = "";
            }

        }

        private void cmdPrintReceipt_Click(object sender, EventArgs e)
        {
            long _billNo;
            long.TryParse(txtOPDBillNo.Text, out _billNo);


            OPDPatientRecord _Patient = new OPDPatientService().GetPatientByBillNo(_billNo);
            ShowCashMemo(_Patient.PatientId);
        }

        private void ShowCashMemo(long patientId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            string _serviceType = string.Empty;
            string _serviceTitle = string.Empty;

           
            if (dtpEntry.Tag.ToString() == "Consultant")
            {
                _serviceType = "Consultant";
                _serviceTitle = "Consultant Name";
            }
            else
            {
                _serviceType = "Others";
                _serviceTitle = "Service Name";
            }

            ds = new DataSet();
            ds = new ReportService().GetOPDCashMemo(patientId, dtpEntry.Tag.ToString());

            RptOPDCashMemo _cashmemo = new RptOPDCashMemo();

            _cashmemo.SetDataSource(ds);
            _cashmemo.SetParameterValue("CabinNo", "");



            ReportViewer rv = new ReportViewer();

            List<OPDPatientLedgerRough> _pLedger = new OPDPatientService().GetOPDPatientLedgerRough(patientId);

            List<VMCashMemoTranactionList> _cashtranList =  Helper.GetOPDCashMemotransaction(_pLedger);



            // string _movementString = new PatientService().GetMovementString(_tGroups);

            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _cashmemo.SetParameterValue(p1, litem.Label);
                _cashmemo.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _cashmemo.SetParameterValue(p3, "");
                }
                else
                {
                    _cashmemo.SetParameterValue(p3, litem.Value.ToString() + ".00");
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


            for (int _count = _index + 1; _count <= 6; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _cashmemo.SetParameterValue(p1, "");
                _cashmemo.SetParameterValue(p2, "");
                _cashmemo.SetParameterValue(p3, "");
            }

            if (isDiscounted)
            {
                _cashmemo.SetParameterValue("lineSeperator1", "Discount");

                if (isDue)
                {
                    _cashmemo.SetParameterValue("lineSeperator2", "Due");
                }
                else
                {
                    _cashmemo.SetParameterValue("lineSeperator2", "");
                }
            }
            else
            {

                _cashmemo.SetParameterValue("lineSeperator1", "");
                _cashmemo.SetParameterValue("lineSeperator2", "");
            }

            if (isDue)
            {
                _cashmemo.SetParameterValue("PayStatus", "DUE");
            }
            else
            {
                _cashmemo.SetParameterValue("PayStatus", "PAID");
            }

            _cashmemo.SetParameterValue("MovementString", "");
            _cashmemo.SetParameterValue("Remarks", "");

            if (Configuration.ORG_CODE == "2")
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 3q Zjvq");
            }
            else
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 2q Zjvq");
            }


            _cashmemo.SetParameterValue("ServiceTitle", _serviceTitle);

         

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
