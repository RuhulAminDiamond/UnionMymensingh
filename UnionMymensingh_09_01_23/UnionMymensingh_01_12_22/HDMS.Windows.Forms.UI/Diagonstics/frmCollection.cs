using CrystalDecisions.Windows.Forms;
using DSBarCode;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using HDMS.Model.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Receiption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmCollection : Form
    {
        BarCodeCtrl _control2 = new BarCodeCtrl();
        SqlDataAdapter da;
        private List<SelectedTestItemsForPatient> _SelectedTests;
        private bool IsTRansactionReseted = false;

        double _originalDue = 0;

        public frmCollection()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            cmdSave.Enabled = false;
            cmdSave.Text = "Plz. Wait..";

            double _discount = 0, _paid = 0;

            double.TryParse(txtDiscount.Text, out _discount);
            double.TryParse(txtPaid.Text, out _paid);

            long _billNo = 0;

            long.TryParse(txtSerial.Text, out _billNo);

            Patient _patient = new PatientService().GetPatientByBillNo(_billNo);
            if (_patient == null) _patient = new PatientService().GetPatientByIdNo(_billNo);

            double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                          .Sum(t => Convert.ToDouble(t.Cells[1].Value));

            double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells[2].Value));

            double due = totalTestAmount - (totalPaidAmount + _discount + _paid);


            List<PatientLedger> transactionList = new List<PatientLedger>();
            PatientLedger pLedger = new PatientLedger();


            double _cardpaymentTk = 0;
            double _mobilePaymentTk = 0;
            PaymentMode _pMode = cmbPaymentMode.SelectedItem as PaymentMode;
            if (_pMode.Name.ToLower().Equals("card payment"))
            {
                double.TryParse(txtCardOrMobileReceiveTk.Text, out _cardpaymentTk);
            }

            if (_pMode.Name.ToLower().Equals("mobile banking"))
            {
                double.TryParse(txtCardOrMobileReceiveTk.Text, out _mobilePaymentTk);
            }


            double balance = totalPaidAmount - totalTestAmount;

            int _PCId = 0;
            PaymentChannel _pChannel = cmbPaymentChannel.SelectedItem as PaymentChannel;
            if (_pChannel != null)
            {
                _PCId = _pChannel.PCId;
            }

            double cashpaidTk = 0, discount = 0;
            double.TryParse(txtDiscount.Text, out discount);
            double.TryParse(txtPaid.Text, out cashpaidTk);


            Patient _Patient = (Patient)txtSerial.Tag;
            if (_Patient != null && _Patient.EntryDate < Utils.GetServerDateAndTime().Date)
            {

                if (discount > 0)
                {
                    discount = Convert.ToDouble(txtDiscount.Text);
                    balance = balance + discount;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = discount;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DiscountOnDueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.Remarks = txtRemarks.Text;
                    pLedger.PCId = 0;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }


                if (cashpaidTk > 0)
                {

                    balance = balance + cashpaidTk;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Due Collection (Cash)";
                    pLedger.Debit = 0;
                    pLedger.Credit = cashpaidTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = 1;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }

                if (_cardpaymentTk > 0)
                {

                    balance = balance + _cardpaymentTk;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Due Collection (By Card)";
                    pLedger.Debit = 0;
                    pLedger.Credit = _cardpaymentTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollectionByCard.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = 1;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }

                if (_mobilePaymentTk > 0)
                {

                    balance = balance + _mobilePaymentTk;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Due Collection (Mobile Banking)";
                    pLedger.Debit = 0;
                    pLedger.Credit = _mobilePaymentTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DueCollectionByMobileBanking.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = _PCId;
                    pLedger.TransactionNo = txtTransactionNo.Text;
                    transactionList.Add(pLedger);
                }

                //new PatientService().SetDuecollectionDateOnDailyStatement(RegNo);
            }
            else
            {

                if (discount > 0)
                {

                    balance = balance + discount;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = discount;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DiscountOnRegularCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.Remarks = txtRemarks.Text;
                    pLedger.PCId = 0;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }

                if (cashpaidTk > 0)
                {

                    balance = balance + cashpaidTk;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Regular collection (Cash)";
                    pLedger.Debit = 0;
                    pLedger.Credit = cashpaidTk;
                    pLedger.Balance = balance;
                    //pLedger.TransactionType = TransactionTypeEnum.OnEntryPayment.ToString();
                    pLedger.TransactionType = TransactionTypeEnum.DueCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = 1;
                    pLedger.TransactionNo = "";
                    transactionList.Add(pLedger);
                }

                if (_cardpaymentTk > 0)
                {

                    balance = balance + _cardpaymentTk;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Regular collection (By Card)";
                    pLedger.Debit = 0;
                    pLedger.Credit = _cardpaymentTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = _PCId;
                    pLedger.TransactionNo = txtTransactionNo.Text;
                    transactionList.Add(pLedger);
                }


                if (_mobilePaymentTk > 0)
                {

                    balance = balance + _mobilePaymentTk;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _patient.PatientId;
                    pLedger.TranDate = Utils.GetServerDateAndTime();
                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    pLedger.Particulars = "Regular collection (Mobile Banking)";
                    pLedger.Debit = 0;
                    pLedger.Credit = _mobilePaymentTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.PaymentbyMobileBanking.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    pLedger.PCId = _PCId;
                    pLedger.TransactionNo = txtTransactionNo.Text;
                    transactionList.Add(pLedger);
                }



            }


            if (transactionList.Count > 0)
            {
                PatientLedgerService plService = new PatientLedgerService();
                plService.SavePatientLedger(transactionList);

                MessageBox.Show("Payment collection successful", "HERP");
                txtPaid.Text = "";
                txtDiscount.Text = "";
                txtDiscountInPercent.Text = "";

                LoadInvestigations();

                LoadPaymentHistory();
            }


            cmdSave.Enabled = true;
            cmdSave.Text = "Save";

        }


        private void LoadBarcodeForId(string _PatientId)
        {

            _control2.BarCode = _PatientId.ToString(); // GetBarcodeString(_PatientId.ToString());//.Aggregate(string.Empty, (c, i) => c + i + ' '); 
            _control2.BarCodeHeight = 15;
            _control2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control2.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            _control2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control2.HeaderText = "";
            _control2.LeftMargin = 10;
            _control2.Location = new System.Drawing.Point(250, 380);
            //_control.Name = "userControl11";
            _control2.ShowFooter = true;
            _control2.ShowHeader = true;
            _control2.Size = new System.Drawing.Size(110, 40);
            _control2.TabIndex = 0;
            _control2.TopMargin = 1;
            _control2.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            _control2.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            this.Controls.Add(_control2);
        }

        private string GetBarcodeString(string _originalId)
        {
            string _appendZero = string.Empty;
            if (_originalId.Length == 1) _appendZero = "00000000";
            if (_originalId.Length == 2) _appendZero = "0000000";
            if (_originalId.Length == 3) _appendZero = "000000";
            if (_originalId.Length == 4) _appendZero = "00000";
            if (_originalId.Length == 5) _appendZero = "0000";
            if (_originalId.Length == 6) _appendZero = "000";
            if (_originalId.Length == 7) _appendZero = "00";
            if (_originalId.Length == 1) _appendZero = "0";

            return _appendZero + _originalId;
        }

        private void txtSerial_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (Int32)Keys.Enter)
            {
                LoadInvestigations();
                GetRefCommission();
                LoadPaymentHistory();
                // LoadBarcodeForId(txtSerial.Text);
            }
        }

        private void LoadInvestigations()
        {
            long _billNo = 0;
            long.TryParse(txtSerial.Text, out _billNo);

            Patient _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

            if (_PatientInfo == null) _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");

            }
            else
            {

                dtpEntry.Value = _PatientInfo.EntryDate;


                if (String.IsNullOrEmpty(_PatientInfo.Status))
                {
                    DataSet ds = new ReportService().GetTestList(_PatientInfo.PatientId);

                    DataTable dt = ds.Tables[0];



                    _SelectedTests = (from DataRow dr in dt.Rows
                                      select new SelectedTestItemsForPatient()
                                      {
                                          Id = Convert.ToInt32(dr["TestId"]),
                                          ReportTypeId = Convert.ToInt32(dr["ReportTypeId"].ToString()),
                                          Name = dr["TestName"].ToString(),
                                          Cost = Convert.ToDouble(dr["Cost"]),
                                          discountInPercent = dr["DiscountInPercent"].ToString(),
                                          discount = dr["Discount"].ToString(),
                                          Status = dr["TestStatus"].ToString(),
                                          UserName = dr["UserName"].ToString(),

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

        private void SetTotalAmount(long _PatientId)
        {
            double total = _SelectedTests.Sum(x => x.Cost);


            txtTestCostTk.Text = total.ToString();
            txtPaidTk.Text = new PatientLedgerService().GetPaidTk(_PatientId).ToString();

            double _discount = new PatientLedgerService().GetDicountTk(_PatientId);
            if (_discount > 0)
            {
                txtDiscountInPercent.Enabled = false;  // If discount given previously, discount in percent not allowed until and unless transactions are reseted.
            }

            txtDiscountTk.Text = _discount.ToString();
            txtCancelled.Text = new PatientLedgerService().GetCancelledAmount(_PatientId).ToString();
            txtDue.Text = new PatientLedgerService().GetPatientLedgerBalance(_PatientId).ToString();



            //new PatientService().GetInitialTestCost(_PatientId);

            double balance = new PatientService().GetCurrentBalance(_PatientId);

            if (balance > 0)
            {
                //txtReturnableTk.Text = Math.Abs(balance).ToString();
            }

        }



        private void GetRefCommission()
        {
            long patientId = 0;
            long.TryParse(txtSerial.Text, out patientId);
            Patient patientInfo = new PatientService().GetRfCommission(patientId);

            double totolCommission = 0;

            List< VMRfCommission> vMRfCommission = new PatientService().GetRfCommissionWithMeidaId(patientInfo.PatientId, patientInfo.MediaId);
            foreach(var com in vMRfCommission)
            {
                totolCommission += com.TotalCommission;
            }

            double totalDiscount = 0;

            List<VMRfCommission> vMGetDiscont = new PatientService().GetMediaDiscountByPatientId(patientInfo.PatientId, patientInfo.MediaId);

            foreach(var dis in vMGetDiscont)
            {
                totalDiscount += dis.Credit;
            }

            lblPcDiscount.Text = (totolCommission - totalDiscount).ToString() ;


        }



        private void FillTestGrid()
        {

            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach (SelectedTestItemsForPatient item in _SelectedTests)
            {
                if (item.Status != "Cancelled")
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Tag = item;
                    row.Height = 35;
                    row.CreateCells(dgTests, item.Id, item.Name, item.Cost, item.discountInPercent, item.discount, item.Status, item.UserName, false);
                    dgTests.Rows.Add(row);
                }
            }

        }


        private void LoadPaymentHistory()
        {
            if (!String.IsNullOrEmpty(txtSerial.Text))
            {
                if (Utility.IsNumeric(txtSerial.Text))
                {
                    long _billNo = 0;
                    long.TryParse(txtSerial.Text, out _billNo);

                    Patient _patient = new PatientService().GetPatientByIdNo(_billNo);
                    txtSerial.Tag = _patient;
                    gvLedger.Rows.Clear();
                    if (_patient != null)
                    {
                        List<PatientLedger> _pLedger = new PatientLedgerService().GetLedgerByPatientId(_patient.PatientId);
                        List<DiagPatientLedgerViewModel> _Lvm = new List<DiagPatientLedgerViewModel>();
                        foreach (PatientLedger _PL in _pLedger)
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

                        List<PatientLedger> _ldegerList = new PatientLedgerService().GetLedgerByPatientId(_patient.PatientId);

                        double totalTestAmount = _ldegerList.Sum(x => x.Debit);

                        double totalPaidAmount = _ldegerList.Sum(x => x.Credit);

                        double due = totalTestAmount - totalPaidAmount;
                        // Media  Commission
                        double meidaCommissionOnTest = new PatientLedgerService().GetMediaCommissionOnTest(_patient.PatientId);
                        // Media Discount 
                        double mediaCommissionDiscount = new PatientLedgerService().GetMediaCommissionOnDiscount(_patient.PatientId);

                        //lblPcDiscount.Text = (meidaCommissionOnTest - mediaCommissionDiscount).ToString();

                        // Load Media Name By Paitient Id 
                        VMMediaAndPatientName mediaByPatientName = new PatientLedgerService().GetMeidaAndPatientName(_patient.PatientId);

                        //lblPatientName.Text = mediaByPatientName.PatientName;
                        string patientName = new PatientLedgerService().GetPatientNameByPatientId(_patient.PatientId);

                        lblPatientName.Text = patientName;
                        if (mediaByPatientName != null) lblMediaName.Text = mediaByPatientName.MediaName;

                        if (due > 0)
                        {
                            txtDue.Text = due.ToString();
                            _originalDue = due;
                        }
                        else if (due < 0.5)
                        {
                            txtDue.Text = "0";
                        }


                    }
                }
            }

        }

        private void frmCollection_Load(object sender, EventArgs e)
        {
            _SelectedTests = new List<SelectedTestItemsForPatient>();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            if (MainForm.LoggedinUser.RoleName.ToLower() == "admin")
            {
                txtDiscount.Enabled = true;

            }
            else if (MainForm.LoggedinUser.RoleName.ToLower() == "manager")
            {
                txtDiscount.Enabled = true;

            }
            else
            {
                // txtDiscount.Enabled = false;
            }

            LoadPaymentModes();

        }

        private void LoadPaymentModes()
        {
            List<PaymentMode> _paymodes = new CommonService().GetPaymentModes();
            _paymodes.Insert(0, new PaymentMode() { PMId = 0, Name = "Select Mode" });
            cmbPaymentMode.DataSource = _paymodes;
            cmbPaymentMode.DisplayMember = "Name";
            cmbPaymentMode.ValueMember = "PMId";



            cmbPaymentMode.SelectedItem = _paymodes.Find(q => q.PMId == 1);

        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if(MainForm.LoggedinUser.RoleName != "Super Admin")
            {
                MessageBox.Show("Only Admin Discount Allow");
                txtDiscount.Text = "0";

                return;
            }

            long _billNo = 0;
            long.TryParse(txtSerial.Text, out _billNo);

            Patient _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

            if (_PatientInfo != null)
            {
                MediaLedger mediaLedger = new MediaService().GetPatientIdByMedia(_PatientInfo.PatientId);

                if (mediaLedger != null)
                {
                    MessageBox.Show("Media has been Paid ");
                    txtDiscount.Text = "";

                    return;

                }

            }

            CalculateAmount();
        }



        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();


        }

        private void cmdPrintReceipt_Click(object sender, EventArgs e)
        {
            long _billNo;
            long.TryParse(txtSerial.Text, out _billNo);


            Patient _Patient = new PatientService().GetPatientByIdNo(_billNo);
            List<PatientLedger> _ledgerVerify = new PatientLedgerService().GetLedgerByPatientId(_Patient.PatientId);
            List<TestsCost> _testCostVerify = new PatientService().GetTestList(_Patient.PatientId);
            if (_ledgerVerify.Count > 0 && _testCostVerify.Count > 0)
            {
                ShowCashMemo(_Patient.PatientId);

            }
            else
            {
                MessageBox.Show("Some transactional mis-matched found.It will be reversed.Plz. check and make a re-entry.", "HERP");

                dgTests.Rows.Clear();
            }
        }



        private async void ShowCashMemo(long RegNo)
        {

            bool isDue = false;
            bool isDiscounted = false;
            int _index = 0;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            DataSet dsReports = await new ReportService().GetCashMemo(RegNo);





            RptCashMemo _cashmemo = new RptCashMemo();



            _cashmemo.SetDataSource(dsReports);
            ReportViewer rv = new ReportViewer();

            List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(RegNo);

            List<VMCashMemoTranactionList> _cashtranList = Helper.GetCashMemotransaction(_pLedger);

            string _remarks = Helper.GetDiscountRemarks(_pLedger);

            if (String.IsNullOrEmpty(_remarks)) _remarks = "";

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
                    _cashmemo.SetParameterValue(p3, litem.Value);
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


            _cashmemo.SetParameterValue("CabinNo", "");
            _cashmemo.SetParameterValue("Remarks", _remarks);

            if (Configuration.ORG_CODE == "2")
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 3q Zjvq");
                _cashmemo.SetParameterValue("OrgLicenseNo", ComapnyDetail.MAH_AKH_Diag_License);
                _cashmemo.SetParameterValue("OrgRegCode", ComapnyDetail.MAH_AKH_Diag_RegCode);
            }
            else
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 2q Zjvq");
                _cashmemo.SetParameterValue("OrgLicenseNo", "License No:" + ComapnyDetail.MAH_NAY_Diag_License);
                _cashmemo.SetParameterValue("OrgRegCode", "Reg. Code:" + ComapnyDetail.MAH_NAY_Diag_RegCode);
            }


            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }


        private string GetPrefixedIdString(string _originalId)
        {
            string _appendZero = string.Empty;
            if (_originalId.Length == 1) _appendZero = "00000";
            if (_originalId.Length == 2) _appendZero = "0000";
            if (_originalId.Length == 3) _appendZero = "000";
            if (_originalId.Length == 4) _appendZero = "00";
            if (_originalId.Length == 5) _appendZero = "0";


            return _appendZero + _originalId;
        }

        private void txtDiscountInPercent_TextChanged(object sender, EventArgs e)
        {

            if(MainForm.LoggedinUser.RoleName != "Super Admin")
            {
                MessageBox.Show("Only Admin Discount Allow");
                txtDiscountInPercent.Text = "0";

                return;
            }

            long _billNo = 0;
            long.TryParse(txtSerial.Text, out _billNo);

            Patient _PatientInfo = new PatientService().GetPatientByIdNo(_billNo);

            if(_PatientInfo != null)
            {
                MediaLedger mediaLedger = new MediaService().GetPatientIdByMedia(_PatientInfo.PatientId);

               if(mediaLedger != null)
                {
                    MessageBox.Show("Media has been Paid ");
                    txtDiscount.Text = "";

                    return;

                }

            }

            txtDiscount.Text = "";

            CalculateAmount();
        }

        private void CalculateAmount()
        {
            double lessInPercent = 0, totalLess = 0;
            double _prevDisc = 0, prevPaid = 0;
            double _cashPayment = 0;
            double _cardormobPayment = 0;
            double _cancelledTk = 0;


            double.TryParse(txtPaid.Text, out _cashPayment);
            double.TryParse(txtCardOrMobileReceiveTk.Text, out _cardormobPayment);

            double.TryParse(txtDiscountTk.Text, out _prevDisc);
            double.TryParse(txtPaidTk.Text, out prevPaid);

            double.TryParse(txtDiscountInPercent.Text, out lessInPercent);
            double.TryParse(txtCancelled.Text, out _cancelledTk);

            double total = dgTests.Rows.Cast<DataGridViewRow>()
                                .Sum(t => Convert.ToDouble(t.Cells[2].Value));

            if (!IsTRansactionReseted)
            {
                if (_cancelledTk > 0)
                {
                    total = (total + _cancelledTk) - (_prevDisc + prevPaid);
                }
                else
                {
                    total = total - (_prevDisc + prevPaid);
                }
            }
            // double total = _SelectedTests.Where(item => item.ReportTypeId != 47).Sum(item => item.Cost);


            double totalDue = 0, currentdiscount = 0;
            double.TryParse(txtDiscount.Text, out currentdiscount);

            if (total > 0 && lessInPercent > 0)
            {

                totalLess = (total * lessInPercent) / 100;
                if (currentdiscount > totalLess) currentdiscount = currentdiscount - totalLess;
                currentdiscount = currentdiscount + totalLess;
                txtDiscount.Text = currentdiscount.ToString();

            }


            totalDue = Math.Round(_originalDue - (_cashPayment + _cardormobPayment + currentdiscount), 2);

            txtDue.Text = totalDue.ToString();


            // Check User Admin or  Supper Admin   Discount and commission  not applay 
            double.TryParse(txtDiscount.Text, out double _discountTk);

            if (MainForm.LoggedinUser.RoleName != "Admin" && MainForm.LoggedinUser.RoleName != "Super Admin" && _discountTk> 0)
            {
                // Media  Commission
               // double meidaCommissionOnTest = new PatientLedgerService().GetMediaCommissionOnTest(_patient.PatientId);
                // Media Discount 
              //  double mediaCommissionDiscount = new PatientLedgerService().GetMediaCommissionOnDiscount(_patient.PatientId);
                double _remaingCommission = 0;
                double.TryParse(lblPcDiscount.Text, out _remaingCommission);
                
                if((_remaingCommission - _discountTk) < 0)
                {
                    MessageBox.Show("You Can only Discount = " + _remaingCommission);
                    txtDiscount.Text = "";
                }



            }

            if (totalDue < 0)
            {
                MessageBox.Show("Amount mis-matched. Please recheck the payment.", "HERP");

                txtDiscountInPercent.Text = "0";
                txtDiscount.Text = "0";

                txtPaid.Text = "";
                txtCardOrMobileReceiveTk.Text = "";
                LoadPaymentModes();
                txtDue.Text = _originalDue.ToString();
            }


        }



        private double GetSubTractedAmount()
        {
            double _discout = 0, _paidtk = 0;
            double.TryParse(txtDiscount.Text, out _discout);
            double.TryParse(txtPaid.Text, out _paidtk);

            double _totalDeduction = _discout + _paidtk;

            return _totalDeduction;

        }

        private void btnResetTransations_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to reset previous transactions?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {


                IsTRansactionReseted = true;

                double balance = 0;
                double.TryParse(txtDue.Text, out balance);

                long _pId = 0;
                long.TryParse(txtSerial.Text, out _pId);

                List<PatientLedger> transactionList = new List<PatientLedger>();

                PatientLedger pLedger = new PatientLedger();

                double discount = 0;
                balance = 0 - balance;
                if (!String.IsNullOrEmpty(txtDiscountTk.Text) && Convert.ToDouble(txtDiscountTk.Text) > 0)
                {
                    discount = Convert.ToDouble(txtDiscountTk.Text);
                    balance = balance - discount;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _pId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Discount Reseted";
                    pLedger.Debit = discount;
                    pLedger.Credit = 0;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.DiscountOnRegularCollection.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }



                double paidTk = 0;
                if (!String.IsNullOrEmpty(txtPaidTk.Text) && Convert.ToDouble(txtPaidTk.Text) > 0)
                {
                    paidTk = Convert.ToDouble(txtPaidTk.Text);
                    balance = balance - paidTk;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _pId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Paid Reseted";
                    pLedger.Debit = paidTk;
                    pLedger.Credit = 0;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.OnEntryPayment.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }


                if (transactionList.Count > 0)
                {
                    PatientLedgerService plService = new PatientLedgerService();
                    plService.SavePatientLedger(transactionList);
                }

                MessageBox.Show("Trasaction reseted successfully.", "HERP");

                IsTRansactionReseted = true;
                txtDiscountInPercent.Enabled = true;

                LoadInvestigations();

                LoadPaymentHistory();

            }

        }



        private void dgTests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTests.Rows.Count > 0)
            {

                if (e.ColumnIndex == 3)  //example-'Column index=4'
                {

                    double disInPercent = Convert.ToDouble(dgTests.CurrentRow.Cells[3].Value);
                    int testId = Convert.ToInt32(dgTests.CurrentRow.Cells[0].Value);
                    _SelectedTests.Where(w => w.Id == testId).ToList().ForEach(s => s.discountInPercent = disInPercent.ToString());

                    if (disInPercent > 0)
                    {
                        double _currentDiscount = 0;

                        double.TryParse(txtDiscount.Text, out _currentDiscount);

                        double testAmount = Convert.ToDouble(dgTests.CurrentRow.Cells[2].Value);

                        double _disCount = (testAmount * disInPercent) / 100;

                        double _totalDiscount = _currentDiscount + _disCount;

                        txtDiscount.Text = _totalDiscount.ToString();
                    }


                }

                if (e.ColumnIndex == 4)  //example-'Column index=4'
                {

                    double disCount = 0;
                    double.TryParse(dgTests.CurrentRow.Cells[4].Value.ToString(), out disCount);

                    int testId = Convert.ToInt32(dgTests.CurrentRow.Cells[0].Value);
                    _SelectedTests.Where(w => w.Id == testId).ToList().ForEach(s => s.discount = disCount.ToString());

                    if (disCount > 0)
                    {
                        double _currentDiscount = 0;

                        double.TryParse(txtDiscount.Text, out _currentDiscount);

                        double testAmount = Convert.ToDouble(dgTests.CurrentRow.Cells[4].Value);

                        double _totalDiscount = _currentDiscount + disCount;

                        txtDiscount.Text = _totalDiscount.ToString();
                    }


                }
            }
        }

        private void dgTests_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentMode _pmode = cmbPaymentMode.SelectedItem as PaymentMode;
            if (_pmode != null)
            {
                List<PaymentChannel> _pChannelList = new CommonService().GetPaymentChannels(_pmode.PMId);
                _pChannelList.Insert(0, new PaymentChannel() { PCId = 0, Name = "Select Channel" });
                cmbPaymentChannel.DataSource = _pChannelList;
                cmbPaymentChannel.DisplayMember = "Name";
                cmbPaymentChannel.ValueMember = "PCId";

                if (_pmode.PMId == 1 || _pmode.PMId == 4 || _pmode.PMId == 5)
                {

                    cmbPaymentChannel.SelectedItem = _pChannelList.Find(q => q.PMId == _pmode.PMId);
                    txtTransactionNo.Enabled = false;
                    txtCardOrMobileReceiveTk.Enabled = false;
                }
                else
                {
                    txtTransactionNo.Enabled = true;
                    txtCardOrMobileReceiveTk.Enabled = true;
                }
            }
        }

        private void cmbPaymentChannel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCardOrMobileReceiveTk.Enabled)
                {
                    txtCardOrMobileReceiveTk.Focus();
                }
                else
                {
                    txtPaid.Focus();
                }
            }
        }

        private void txtCardOrMobileReceiveTk_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
