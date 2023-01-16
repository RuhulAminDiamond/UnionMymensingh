using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.ViewModel;
using HDMS.Repository.ServiceObjects;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Receiption;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmEditPatientInfo : Form
    {

        private List<SelectedTestItemsForPatient> _SelectedTests;
        private static LoginUser LoggedinUser { get; set; }

        bool _PatientCancelled = false;
        public frmEditPatientInfo()
        {
            InitializeComponent();
            UpdateFont();
            LoggedinUser = MainForm.LoggedinUser;
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgTests.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgTests.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
            //dgTests.RowTemplate.Height = 30;
        }

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                LoadPatientHistory();
                //Load PatientInfo

            }
        }

        private void LoadPatientHistory()
        {
            long _pId = 0;
            long.TryParse(txtBillNo.Text, out _pId);

            Patient _PatientInfo = new PatientService().GetPatientByBillNo(_pId);

            if (_PatientInfo == null) _PatientInfo = new PatientService().GetPatientByIdNo(_pId);

            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");
                txtBillNo.Tag = null;
            }
            else
            {
                txtBillNo.Tag = _PatientInfo;
                LoadRegPatientInfo(_PatientInfo.RegNo);


                txtRefBy.Text = new DoctorService().GetDoctorById(_PatientInfo.DoctorId).Name;
                txtRefBy.Tag = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                dtpEntry.Value = _PatientInfo.EntryDate;

                btnCancelPatient.Enabled = true;

                if (String.IsNullOrEmpty(_PatientInfo.Status))
                {
                  DataSet ds = new ReportService().GetTestList(_PatientInfo.PatientId);

                    //_SelectedTests = new ReportService().GetTestListByPatientBillNo(_PatientInfo.PatientId);

                    DataTable dt = ds.Tables[0];
                    _SelectedTests = (from DataRow dr in dt.Rows
                                      select new SelectedTestItemsForPatient()
                                      {
                                          Id = Convert.ToInt32(dr["TestId"]),
                                          TestCode = Convert.ToInt32(dr["TestCode"]),

                                          ReportTypeId = Convert.ToInt32(dr["ReportTypeId"].ToString()),
                                          Name = dr["TestName"].ToString(),
                                          Cost = Convert.ToDouble(dr["Cost"]),
                                          discountInPercent = dr["DiscountInPercent"].ToString(),
                                          discount = dr["Discount"].ToString(),
                                          Status = dr["TestStatus"].ToString(),
                                          UserName = dr["UserName"].ToString(),
                                          IsCancelApprove =  Convert.ToBoolean(dr["IsCancelApprove"]),


                                      }).ToList();


                    FillTestGrid();

                    SetTotalAmount(_PatientInfo.PatientId);


                }
                else
                {
                    MessageBox.Show("This is a cancelled Id.", "HERP");
                    btnCancelPatient.Enabled = false;
                }
            }
        }

        private bool LoadRegPatientInfo(long _regNo)
        {
            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
            if (_record != null)
            {
                txtPatientName.Text = _record.FullName;
                txtYears.Text = _record.AgeYear;
                txtMonths.Text = _record.AgeMonth;
                txtDays.Text = _record.AgeDay;
                cmbGender.Text = _record.Sex;
                txtCountryCode.Text = _record.CountryCode;
                txtCellPhone.Text = _record.MobileNo;
                return true;

            }

            return false;

        }


        private void SetTotalAmount(long _PatientId)
        {
            double total = _SelectedTests.Sum(x => x.Cost);


            txtTestCostTk.Text = total.ToString();

            double _invoiceTotal = new PatientLedgerService().GetInvoiceTotal(_PatientId);

            txtTestCostTk.Tag = _invoiceTotal;

            txtPaidTk.Text = new PatientLedgerService().GetPaidTk(_PatientId).ToString();
            txtDiscountTk.Text = new PatientLedgerService().GetDicountTk(_PatientId).ToString();
            txtDueTk.Text = new PatientLedgerService().GetPatientLedgerBalance(_PatientId).ToString();
            txtCancelledTk.Text = new PatientLedgerService().GetCancelledAmount(_PatientId).ToString();


            //new PatientService().GetInitialTestCost(_PatientId);

            double balance = new PatientService().GetCurrentBalance(_PatientId);

            if (balance > 0)
            {
                txtReturnableTk.Text = Math.Abs(balance).ToString();
            }

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
                    row.CreateCells(dgTests, item.TestCode, item.Name, item.Cost, item.discountInPercent, item.discount, item.Status,  item.UserName, (item.IsCancelApprove ? "Yes" : "No"));
                    dgTests.Rows.Add(row);
                }
            }

        }

        private void btnCancelSelectedTest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to cancel this test?", "Confirmation", MessageBoxButtons.YesNoCancel);



            if (result == DialogResult.Yes && dgTests.SelectedRows.Count != 0 && txtBillNo.Tag != null)
            {
                double _individualDiscInPercent = 0;
                double _individualDiscGross = 0;

                SelectedTestItemsForPatient _SeletedItem = this.dgTests.SelectedRows[0].Tag as SelectedTestItemsForPatient;
                int _itemId = _SeletedItem.Id;
                string _Name = _SeletedItem.Name;
                Patient _Patient = (Patient)txtBillNo.Tag;
                double _Cost = _SeletedItem.Cost;

                /*----------- Check you are  user role not super admin -----------*/

                if (MainForm.LoggedinUser.RoleName != "Super Admin" && _SeletedItem.IsCancelApprove == false)
                {
                    MessageBox.Show("You can not Cancel Test ");
                    return;
                }

                /*------------- Update Is Apporve Id -----------------*/

                if(MainForm.LoggedinUser.RoleName == "Super Admin")
                {
                   

                    new PatientService().IsApproveCancelTest(_Patient.PatientId, _itemId, LoggedinUser.UserId, txtRemark.Text,true);

                    MessageBox.Show("Test Cancel Is Approved");
                    FillTestGrid();
                    return;
                }



                if (CheckIsReportPrinted(_Patient, _itemId))
                {
                    MessageBox.Show("Test will not cancel.Report already printed for this test.");
                    return;
                }

                double.TryParse(_SeletedItem.discountInPercent, out _individualDiscInPercent);
                double.TryParse(_SeletedItem.discount, out _individualDiscGross);

                

               


                if (new PatientService().CancelTest(_Patient.PatientId, _itemId, LoggedinUser.UserId, txtRemark.Text))
                {
                    MessageBox.Show("Test: " + _Name + " cancelled successful.", "HERP");
                    DataSet ds = new ReportService().GetTestList(_Patient.PatientId);

                    DataTable dt = ds.Tables[0];


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        UpdatePatientStatus(_Patient.PatientId); // Set Status Cancelled in Patients Table 
                    }


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
                                          IsCancelApprove = Convert.ToBoolean(dr["IsCancelApprove"]),
                                      }).ToList();


                    FillTestGrid();

                    string testGroup = new TestService().GetDailyStatementHeaderName(_itemId);

                    AdjustDailyStatement(_Patient.PatientId, testGroup, _Cost);

                    AdjustPatientLedger(_Patient.PatientId, _Name, _Cost, _individualDiscInPercent, _individualDiscGross);

                    SetTotalAmount(_Patient.PatientId);

                }
            }
        }

        private void UpdatePatientStatus(long patientId)
        {
            Patient _p = new PatientService().GetPatientByIdNo(patientId);

            _p.Status = "Cancelled";
            new PatientService().UpdatePatientInfo(_p);
        }

        private bool CheckIsReportPrinted(Patient _Patient, int _itemId)
        {
            bool IsReportPrinted = new TestService().IsReportPrinted(_Patient, _itemId);

            return IsReportPrinted;
        }

        private void AdjustDailyStatement(long _regNo, string testGroup, double _Cost)
        {
            new PatientService().AdjustDailyStatement(_regNo, testGroup, _Cost);
        }

        private void AdjustPatientLedger(long RegNo, string testName, double _testCost, double individualDiscInPercent, double individualDiscGross)
        {
            double _discountGiven = new TestService().GetDiscountedAmount(RegNo);

            double _invoiceTotal = 0;
            double.TryParse(txtTestCostTk.Tag.ToString(), out _invoiceTotal);

            // double discountOnthistest = (_testCost * individualDiscInPercent) / 100 + individualDiscGross;
            double discountOnthistest = (_testCost * individualDiscInPercent) / 100;

            double _discountforCancelledTest = 0;

            if (discountOnthistest > 0)
            {
                _discountGiven = discountOnthistest;
                _discountforCancelledTest = discountOnthistest;
            }
            else
            {
                _discountforCancelledTest = (_discountGiven * _testCost) / _invoiceTotal;
            }

            double _currentBalance = new PatientService().GetCurrentBalance(RegNo);

            double _returnableAmount = _testCost - _discountforCancelledTest;

            PatientLedger pLedger = new PatientLedger();
            List<PatientLedger> transactionList = new List<PatientLedger>();

            double balance = 0;

            if (_discountGiven == 0)
            {
                balance = _currentBalance + _testCost;
                pLedger = new PatientLedger();
                pLedger.PatientId = RegNo;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Test Cancel: " + testName;
                pLedger.Debit = 0;
                pLedger.Credit = _testCost;
                pLedger.Balance = Math.Round(balance, 2);
                pLedger.TransactionType = TransactionTypeEnum.TestCancelled.ToString();
                pLedger.OperateBy = LoggedinUser.Name;
                pLedger.PCId = 0;
                pLedger.TransactionNo = "";
                transactionList.Add(pLedger);
            }

            if (_discountGiven > 0)
            {

                balance = _currentBalance + _testCost;

                pLedger = new PatientLedger();
                pLedger.PatientId = RegNo;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Test Cancel: " + testName;
                pLedger.Debit = 0;
                pLedger.Credit = _testCost;
                pLedger.Balance = Math.Round(balance, 2);
                pLedger.TransactionType = TransactionTypeEnum.TestCancelled.ToString();
                pLedger.OperateBy = LoggedinUser.Name;
                pLedger.PCId = 0;
                pLedger.TransactionNo = "";
                transactionList.Add(pLedger);


                balance = balance - Math.Round(_discountforCancelledTest, 2);
                pLedger = new PatientLedger();
                pLedger.PatientId = RegNo;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Discount Adjusted For Cancelled Test: " + testName;
                pLedger.Debit = Math.Round(_discountforCancelledTest, 2);
                pLedger.Credit = 0;
                pLedger.Balance = Math.Round(balance, 2);
                pLedger.TransactionType = TransactionTypeEnum.TestCancelledDiscountAdjustment.ToString();
                pLedger.OperateBy = LoggedinUser.Name;
                pLedger.PCId = 0;
                pLedger.TransactionNo = "";
                transactionList.Add(pLedger);


            }


            if (transactionList.Count > 0)
            {
                PatientLedgerService plService = new PatientLedgerService();
                plService.SavePatientLedger(transactionList);
            }

        }

        private void btnRefund_Click(object sender, EventArgs e)
        {

            if (_PatientCancelled)
            {
                MessageBox.Show("Refund successfull.");
                txtReturnableTk.Text = "0";
                _PatientCancelled = false;
                return;
            }

            if (txtBillNo.Tag == null)
            {
                MessageBox.Show("Patient not selected"); return;
            }

            Patient _Patient = (Patient)txtBillNo.Tag;


            btnRefund.Enabled = false;

            double _refundtk = 0;

            double.TryParse(txtReturnableTk.Text, out _refundtk);

            PatientLedger pLedger = new PatientLedger();
            List<PatientLedger> transactionList = new List<PatientLedger>();

            if (_refundtk > 0)
            {

                pLedger = new PatientLedger();
                pLedger.PatientId = _Patient.PatientId;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Refund Tk.";
                pLedger.Debit = _refundtk;
                pLedger.Credit = 0;
                pLedger.Balance = 0;
                pLedger.TransactionType = TransactionTypeEnum.Refund.ToString();
                pLedger.OperateBy = LoggedinUser.Name;
                pLedger.PCId = 1;
                pLedger.TransactionNo = "";
                transactionList.Add(pLedger);
            }
            else
            {
                MessageBox.Show("No. returnable amount found.", "HERP");
            }

            if (transactionList.Count > 0)
            {
                PatientLedgerService plService = new PatientLedgerService();
                plService.SavePatientLedger(transactionList);
                MessageBox.Show("Refund successful.", "HERP");
                LoadPatientHistory();
            }

            txtReturnableTk.Text = "0";
            btnRefund.Enabled = true;
        }

        private void txtRefBy_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlDoctorSearch.Visible = true;
                ctrlDoctorSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {

                int id = 0;
                if (int.TryParse(txtRefBy.Text.Trim(), out id))
                {
                    txtRefBy.Text = new DoctorService().GetDoctorById(id).Name;
                    txtRefBy.Tag = new DoctorService().GetDoctorById(id);
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlDoctorSearch.Visible = false;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (txtBillNo.Tag == null)
            {
                MessageBox.Show("Please select patient first.", "HERP");
            }

            Patient _PatinetInfo = (Patient)txtBillNo.Tag;

            _PatinetInfo.DoctorId = ((Doctor)txtRefBy.Tag).DoctorId;
            _PatinetInfo.Cabin = txtCabin.Text;
            _PatinetInfo.AgeYear = txtYears.Text;
            _PatinetInfo.AgeMonth = txtMonths.Text;
            _PatinetInfo.AgeDay = txtDays.Text;

            if (new PatientService().UpdatePatientInfo(_PatinetInfo))
            {
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_PatinetInfo.RegNo);
                _record.FullName = txtPatientName.Text;
                _record.CountryCode = txtCountryCode.Text;
                _record.MobileNo = txtCellPhone.Text;
                _record.Sex = cmbGender.Text;

                new RegRecordService().UpdateRegRecord(_record);

                MessageBox.Show("Patient Info Updated Successfully.", "HERP");
            }
        }

        private void btnCancelPatient_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure to cancel this patient?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes && txtBillNo.Tag != null)
            {

                btnCancelPatient.Enabled = false;

                Patient _Patient = (Patient)txtBillNo.Tag;

                /*----------- Check you are  user role not super admin -----------*/
                bool isApprovedTrue = new PatientService().GetApproveByAdminCheck(_Patient.PatientId);

                if (MainForm.LoggedinUser.RoleName != "Super Admin" && isApprovedTrue == false)
                {
                    MessageBox.Show("You can not patient  Cancel  ");
                    return;
                }

                /*------------- Update Is Apporve Id -----------------*/

                if (MainForm.LoggedinUser.RoleName == "Super Admin")
                {


                    new PatientService().IsApproveCancelPatient(_Patient.PatientId, LoggedinUser.UserId, txtRemark.Text, true);

                    MessageBox.Show("Test Cancel Is Approved");
                    FillTestGrid();
                    return;
                }

                if (CheckIsReportPrintedForThisPatient(_Patient))
                {
                    MessageBox.Show("Bill will not cancel.Report already printed for this bill.");
                    btnCancelPatient.Enabled = true;
                    return;
                }


                if (CheckIsAnyTestCancelledAlreadt(_Patient))
                {
                    MessageBox.Show("Patient will not cancel as a whole.Try to cancel one by one test.");
                    btnCancelPatient.Enabled = true;
                    return;
                }

               

                if (new PatientService().CancelPatient(_Patient.PatientId, LoggedinUser.Name, txtRemark.Text))
                {

                    dgTests.SuspendLayout();
                    dgTests.Rows.Clear();

                    _PatientCancelled = true;
                    double _Cost = _SelectedTests.Sum(x => x.Cost); //Convert.ToDouble(txtCancelledTk.Text);

                    AdjustPatientLedgerForPatientCancel(_Patient.PatientId, _Cost);
                    SetReturnAmount(_Patient.PatientId);
                }

                btnCancelPatient.Enabled = true;
            }

        }

        private bool CheckIsAnyTestCancelledAlreadt(Patient _Patient)
        {
            List<TestsCost> _testList = new TestService().GetCancelledTestList(_Patient.PatientId);
            if (_testList.Count == 0)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private bool CheckIsReportPrintedForThisPatient(Patient _Patient)
        {
            bool IsReportPrinted = new TestService().CheckIsReportPrintedForThisPatient(_Patient);

            return IsReportPrinted;
        }

        private void SetReturnAmount(long _PatientId)
        {

            double _refundable = new PatientLedgerService().GetRefundable(_PatientId);
            txtReturnableTk.Text = _refundable.ToString();

        }

        private void AdjustPatientLedgerForPatientCancel(long _regNo, double _Cost)
        {
            double _discountGiven = new TestService().GetDiscountedAmount(_regNo);
            double _currentBalance = new PatientService().GetCurrentBalance(_regNo);


            double _returnableAmount = (_Cost + _currentBalance) - _discountGiven;



            PatientLedger pLedger = new PatientLedger();
            List<PatientLedger> transactionList = new List<PatientLedger>();

            double balance = 0;

            balance = _currentBalance + _Cost;
            pLedger = new PatientLedger();
            pLedger.PatientId = _regNo;
            pLedger.TranDate = Utils.GetServerDateAndTime();
            pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
            pLedger.Particulars = "Patient Cancel";
            pLedger.Debit = 0;
            pLedger.Credit = _Cost;
            pLedger.Balance = balance;
            pLedger.TransactionType = TransactionTypeEnum.TestCancelled.ToString();
            pLedger.OperateBy = LoggedinUser.Name;
            pLedger.PCId = 0;
            pLedger.TransactionNo = "";
            transactionList.Add(pLedger);

            if (_discountGiven > 0)
            {
                balance = balance - _discountGiven;
                pLedger = new PatientLedger();
                pLedger.PatientId = _regNo;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Discount Adjusted.";
                pLedger.Debit = _discountGiven;
                pLedger.Credit = 0;
                pLedger.Balance = balance;
                pLedger.TransactionType = TransactionTypeEnum.DiscountRefunded.ToString();
                pLedger.OperateBy = LoggedinUser.Name;
                pLedger.PCId = 0;
                pLedger.TransactionNo = "";
                transactionList.Add(pLedger);

            }

            if (_returnableAmount > 0)
            {
                balance = balance - _returnableAmount;
                pLedger = new PatientLedger();
                pLedger.PatientId = _regNo;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Refund Tk.";
                pLedger.Debit = _returnableAmount;
                pLedger.Credit = 0;
                pLedger.Balance = balance;
                pLedger.TransactionType = TransactionTypeEnum.Refund.ToString();
                pLedger.OperateBy = LoggedinUser.Name;
                pLedger.PCId = 0;
                pLedger.TransactionNo = "";
                transactionList.Add(pLedger);

            }


            if (transactionList.Count > 0)
            {
                PatientLedgerService plService = new PatientLedgerService();
                plService.SavePatientLedger(transactionList);

               // if (new PatientService().UpdatePatinetMediaId(_regNo))
                //{
                    MessageBox.Show("Refund successful.", "HERP");

               // }

            }

        }

        private void frmEditPatientInfo_Load(object sender, EventArgs e)
        {
            _SelectedTests = new List<SelectedTestItemsForPatient>();
            ctrlDoctorSearch.Location = new Point(txtRefBy.Location.X, txtRefBy.Location.Y + txtRefBy.Height);
            ctrlDoctorSearch.ItemSelected += ctrlDoctorSearch_ItemSelected;

            var role = MainForm.LoggedinUser;
            //MessageBox.Show(role.RoleName + " " + " role Id"+ role.RoleId);

            /**========== check where user role supper admin allow only test cancels =========== **/
            if(role.RoleName == "Super Admin")
            {
                //MessageBox.Show(role.RoleName + " inside  " + " role Id" + role.RoleId);
                btnCancelSelectedTest.Text = "Approve Test Cancel ";
                btnCancelPatient.Text = "Approve Pateint Cancel";
                btnRefund.Enabled = false;

            }



        }

        private void ctrlDoctorSearch_ItemSelected(UI.Controls.SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtRefBy.Text = item.Name;
            txtRefBy.Tag = item;
            sender.Visible = false;
            txtCabin.Focus();

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void txtTestCostTk_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmdPrintReceipt_Click(object sender, EventArgs e)
        {
            long _billNo;
            long.TryParse(txtBillNo.Text, out _billNo);


            Patient _Patient = (Patient)txtBillNo.Tag;

            if (_Patient == null) return;

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



            // string _file2 = "C:\\RegBarcodeImages\\PId123.png";

            //if (File.Exists(@"C:\RegBarcodeImages\Reg123.png"))
            //{
            //    File.Delete(@"C:\RegBarcodeImages\Reg123.png");
            //}

            //if (File.Exists(@"C:\RegBarcodeImages\PId123.png"))
            //{
            //    File.Delete(@"C:\RegBarcodeImages\PId123.png");
            //}

            //if (!Directory.Exists("C:\\RegBarcodeImages")) Directory.CreateDirectory("C:\\RegBarcodeImages");
            ////_control.SaveImage(_file);
            //_control2.SaveImage(_file2);





            RptCashMemo _cashmemo = new RptCashMemo();



            _cashmemo.SetDataSource(dsReports);
            ReportViewer rv = new ReportViewer();

            List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(RegNo);

            List<VMCashMemoTranactionList> _cashtranList = Helper.GetCashMemotransaction(_pLedger);

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
            _cashmemo.SetParameterValue("Remarks", "");

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
