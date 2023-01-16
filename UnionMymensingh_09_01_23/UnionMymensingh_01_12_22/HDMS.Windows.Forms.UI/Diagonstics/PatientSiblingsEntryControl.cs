using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Service.Doctors;
using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Repository.ServiceObjects;
using HDMS.Model.ViewModel;
using HDMS.Model.Enums;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Receiption;
using CrystalDecisions.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;
using DSBarCode;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Model.Rx;
using HDMS.Service.Rx;
using Itenso.TimePeriod;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Diagnostic;
using HDMS.Service.Hospital;
using HDMS.Model.Hospital;
using HDMS.Model.Common.VW;
using System.Threading;
using static HDMS.Windows.Forms.UI.Utils;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class PatientSiblingsEntryControl : UserControl
    {
        public event EntryCompletedEventHandler EntryCompleted;
        private SqlDataAdapter da;
        private DataSet ds;
        BarCodeCtrl _control = new BarCodeCtrl();
        BarCodeCtrl _control2 = new BarCodeCtrl();
        bool IsNewEntry = true;
        bool unlocked = true;
        bool IsKeyPressed = false;

        bool CalledFromOtherPlace = false;

        bool IsListEmpty = false;


        public LoginUser loggedInUser { get; set; }


        public PatientSiblingsEntryControl()
        {

            InitializeComponent();

            UpdateFont();



        }





        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgTests.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgTests.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EntryCompleted != null) EntryCompleted(this);
        }

        public delegate void EntryCompletedEventHandler(object sender);

        private void txtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlTestSearch.Visible = true;
                ctlTestSearch.txtSearch.Text = "";
                ctlTestSearch.LoadData();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                ctlTestSearch.Visible = false;
                new TestService().PopulateSelectedTestData(_SelectedTests, txtTestCode.Tag as TestItem, txtTestCode.Text, dtpDeliveryDate.Value, txtDeliveryTime.Text);
                FillTestGrid();
                unlocked = false;
                txtTestCode.Text = "";
                unlocked = true;
                SetTestCount();
            }
        }

        private void FillTestGridForPrevPatient(long _PatientId)
        {

            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach (SelectedTestItemsForPatient item in _SelectedTests)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;
                row.DefaultCellStyle.BackColor = Color.Yellow;
                //row.Frozen = true;
                row.CreateCells(dgTests, item.TestCode, item.Name, item.DeliveryDate, item.DeliveryTime, item.Cost, item.discountInPercent, item.discount, false);
                dgTests.Rows.Add(row);
            }

            SetAmount(_PatientId);
        }

        private void FillTestGrid()
        {

            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach (SelectedTestItemsForPatient item in _SelectedTests)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;
                if (txtBillNo.Tag != null)
                {
                    if (item.AdditionType.ToLower() == "cancelled")
                    {
                        row.HeaderCell.Value = "(-)";
                        row.DefaultCellStyle.BackColor = Color.OrangeRed;

                    }
                    if (item.AdditionType.ToLower() == "old") row.DefaultCellStyle.BackColor = Color.Yellow;
                    if (item.AdditionType.ToLower() == "new")
                    {
                        row.HeaderCell.Value = "(+)";
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }

                row.CreateCells(dgTests, item.TestCode, item.Name, item.DeliveryDate, item.DeliveryTime, item.Cost, item.discountInPercent, item.discount);
                dgTests.Rows.Add(row);


            }



            if (IsNewEntry)
            {
                CalculateTestAmount();

                SetIndividualTestDiscount();
            }
            else
            {
                CalculateNewlyAddedTestAmount();

                // SetIndividualTestDiscountForNewAddedTest();

            }
            //dgTests.ResumeLayout();
        }

        private void CalculateNewlyAddedTestAmount()
        {
            long _pId = 0;
            long.TryParse(txtBillNo.Text, out _pId);

            double _prevDue = new ReportService().GetDueTk(_pId);

            double _newTestAmount = _SelectedTests.Where(x => x.AdditionType.ToLower() == "new").Sum(y => y.Cost);

            txtTotalAmount.Text = _newTestAmount.ToString();

            txtVat.Text = "0"; //TO ADD VAT CALL new VatService().GetVateRates()

            txtGrandTotal.Text = _newTestAmount.ToString();

            txtDue.Text = (_prevDue + _newTestAmount).ToString();



        }

        private void SetIndividualTestDiscountForNewAddedTest()
        {
            throw new NotImplementedException();
        }

        private void CalculateTestAmount()
        {
            txtTotalAmount.Text = dgTests.Rows.Cast<DataGridViewRow>()
             .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            txtVat.Text = "0"; //TO ADD VAT CALL new VatService().GetVateRates()

            txtGrandTotal.Text = dgTests.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            txtDue.Text = dgTests.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            double _due = 0, _paid = 0;
            double.TryParse(txtDue.Text, out _due);
            double.TryParse(txtPaid.Text, out _paid);

            if (txtBillNo.Tag != null)
            {
                txtDue.Text = (_due - _paid).ToString();
            }



        }

        private void SetIndividualTestDiscount()
        {

            foreach (SelectedTestItemsForPatient item in _SelectedTests)
            {

                double _discInPercent = 0;
                double.TryParse(item.discountInPercent, out _discInPercent);

                if (_discInPercent > 0)
                {
                    double _currentDiscount = 0;

                    double.TryParse(txtDiscount.Text, out _currentDiscount);

                    double testAmount = item.Cost;

                    double _disCount = (testAmount * _discInPercent) / 100;

                    double _totalDiscount = _currentDiscount + _disCount;

                    txtDiscount.Text = _totalDiscount.ToString();
                }
            }
        }

        private IList<SelectedTestItemsForPatient> _SelectedTests;
        private IList<SelectedTestItemsForPatient> _TubeTests;


        private void PatientEntryControl_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            _SelectedTests = new List<SelectedTestItemsForPatient>();
            _TubeTests = new List<SelectedTestItemsForPatient>();

            ctlTestSearch.Location = new Point(txtTestCode.Location.X, txtTestCode.Location.Y);
            ctlTestSearch.ItemSelected += ctlTestSearch_ItemSelected;
            ctlDoctorSearch.Location = new Point(txtRefBy.Location.X, txtRefBy.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            ctlDiscRequestedBy.Location = new Point(txtRequestedby.Location.X, txtRequestedby.Location.Y);
            ctlDiscRequestedBy.ItemSelected += ctlDiscRequestedBy_ItemSelected;

            ctrlRegRecordSearch.Location = new Point(txtRegNo.Location.X, txtRegNo.Location.Y);
            ctrlRegRecordSearch.ItemSelected += ctrlRegRecordSearch_ItemSelected;

            ctlPatientSearch.Location = new Point(txtCellPhone.Location.X, txtCellPhone.Location.Y);
            ctlPatientSearch.ItemSelected += ctlPatientSearch_ItemSelected;

            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y);
            ctlMediaSearchControl.ItemSelected += ctlMediaSearchControl_ItemSelected;


            lblEntryDateValue.Text = DateTime.Now.ToString(Configuration.DATE_TIME_FORMAT);
            LoadCountInformation();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            //txtTestCode.GotFocus += GotFocus.EventHandler(RemoveText);
            //txtTestCode.LostFocus += LostFocus.EventHandler(AddText);

            //txtCellPhone.Select();

            // txtDailyId.Text = GetDailyId(DateTime.Now);
            // txtDeliveryTime.Text =  GetDeliveryTime();
            lblRecievedByValue.Text = MainForm.LoggedinUser.Name;

            txtBillNo.Text = "";

            // LoadBarcode();
        }

        private void ctlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item.MediaId;
            txtTestCode.Focus();
            sender.Visible = false;
        }

        private string GetNewBillNo()
        {
            string _billPart1 = Utils.GetBillNo();
            long _billNo = new Random().Next(10000, 99999);
            string _billPart2 = _billNo.ToString() + Configuration.ORG_CODE;

            string _BillNo = _billPart1 + _billPart2;

            if (!new PatientService().IsBillNoAlloted(Convert.ToInt64(_BillNo)))
            {
                return _BillNo.ToString();
            }

            GetNewBillNo();

            return "";
        }


        private void ctlPatientSearch_ItemSelected(SearchResultListControl<RegRecord> sender, RegRecord item)
        {
            CalledFromOtherPlace = true;

            //RegRecord _rRecord= new RegRecordService().GetRegRecordByRegNo(item.RegNo);

            txtCellPhone.Text = item.MobileNo;
            txtRegNo.Text = item.RegNo.ToString();
            txtPatientName.Text = item.FullName;
            txtYears.Text = item.AgeYear.ToString();
            txtMonths.Text = item.AgeMonth.ToString();
            txtDays.Text = item.AgeDay.ToString();
            cmbGender.Text = item.Sex;
            sender.Visible = false;
            CalledFromOtherPlace = false;
            txtRefBy.Focus();
        }

        private void ctrlRegRecordSearch_ItemSelected(SearchResultListControl<RegRecord> sender, RegRecord item)
        {
            txtRegNo.Text = item.RegNo.ToString();
            txtRegNo.Tag = item;
            sender.Visible = false;

            txtRegNo.Focus();
        }

        private void ctlDiscRequestedBy_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtRequestedby.Text = item.Name;
            txtRequestedby.Tag = item.DoctorId;
            txtDiscountAdjustFromReferral.Text = item.RequestedPatientDiscountAdjustFromRefDoctor.ToString();
            sender.Visible = false;
        }

        private void LoadBarcode()
        {
            //txtRegNo.Text = GetNextRegNo();

            _control.BarCode = txtRegNo.Text;//.Aggregate(string.Empty, (c, i) => c + i + ' '); 
            _control.BarCodeHeight = 15;
            _control.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            _control.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control.HeaderText = "";
            _control.LeftMargin = 10;
            _control.Location = new System.Drawing.Point(650, 480);
            //_control.Name = "userControl11";
            _control.ShowFooter = true;
            _control.ShowHeader = true;
            _control.Size = new System.Drawing.Size(180, 40);
            _control.TabIndex = 0;
            _control.TopMargin = 1;
            _control.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            _control.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            this.Controls.Add(_control);

            //ClearFields();
        }



        private string GetDailyId(DateTime dateTime)
        {
            return new PatientService().GetDailyId(dateTime).ToString();
        }

        private string GetNextServiceId(long regNo)
        {
            return new PatientService().GetNextServiceId(regNo).ToString();
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

            ctrl.BackColor = Color.NavajoWhite;
        }

        void ctlDoctorSearch_ItemSelected(Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            unlocked = false;
            txtRefBy.Text = item.Name;
            txtRefBy.Tag = item.DoctorId;
            unlocked = true;
            sender.Visible = false;
            txtCabin.Focus();

        }

        void ctlTestSearch_ItemSelected(Controls.SearchResultListControl<Model.TestItem> sender, Model.TestItem item)
        {

            unlocked = false;
            txtTestCode.Text = item.TestId.ToString();
            txtTestCode.Tag = item;
            txtTestCode.Focus();


            new TestService().PopulateSelectedTestData(_SelectedTests, txtTestCode.Tag as TestItem, txtTestCode.Text, dtpDeliveryDate.Value, txtDeliveryTime.Text);
            FillTestGrid();


            SetPercentDiscountAmount();

            SetTestCount();


            txtTestCode.Focus();
            txtTestCode.Text = "";
            unlocked = true;
            sender.Visible = false;
        }

        private void SetTestCount()
        {
            int totalTest = _SelectedTests.Where(item => item.ReportTypeId != 63).Count();
            lblTotalTest.Text = totalTest.ToString();
        }

        private void txtRefBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                ctlDoctorSearch.Visible = false;
                int id;
                if (int.TryParse(txtRefBy.Text.Trim(), out id))
                {
                    Doctor _doctor = new DoctorService().GetDoctorById(id);
                    if (_doctor != null)
                    {
                        unlocked = false;
                        txtRefBy.Text = new DoctorService().GetDoctorById(id).Name;
                        txtRefBy.Tag = new DoctorService().GetDoctorById(id).DoctorId;
                        unlocked = true;
                    }
                    else
                    {
                        MessageBox.Show("Doctor not found for this code. Plz. type a valid code and try again.");
                        return;
                    }
                }

                txtCabin.Focus();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
            ctlTestSearch.Visible = false;
            ctlDiscRequestedBy.Visible = false;

            ctrlRegRecordSearch.Visible = false;
            ctlPatientSearch.Visible = false;
            ctlMediaSearchControl.Visible = false;
        }



        private void dgTests_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SelectedTestItemsForPatient _SelectedItem = (SelectedTestItemsForPatient)e.Row.Tag;
            if (_SelectedItem.AdditionType.ToLower() == "old")
            {
                //_SelectedTests.Where(w => w.Id == _SelectedItem.Id).ToList().ForEach(s => s.AdditionType = "Cancelled");
                MessageBox.Show("This row will not be deleted.Just temporarily hide from the list");

            }
            else
            {

                _SelectedTests.Remove(e.Row.Tag as SelectedTestItemsForPatient);
                CalculateTestAmount();

            }


        }

        private void lblTotalPatients_Click(object sender, EventArgs e)
        {
            lblTotalPatientsValue.Text = new PatientService().GetNumberofPatient(MainForm.LoggedinUser).ToString();
        }

        private void LoadCountInformation()
        {
            PatientService service = new PatientService();
            //lblTotalPatientsValue.Text = service.GetNumberofPatient((this.ParentForm.MdiParent as MainForm).LoggedinUser).ToString();
            //lblCurrentRegNoValue.Text = service.GetLastRegistrtionNo().ToString();
            // lblCurrentDailyIdValue.Text = service.GetLastIdOfToday().ToString();
        }

        private void lblCurrentRegNo_Click(object sender, EventArgs e)
        {
            lblCurrentRegNoValue.Text = new PatientService().GetLastRegistrtionNo().ToString();

        }

        private void lblCarrentDailyId_Click(object sender, EventArgs e)
        {
            lblCurrentDailyIdValue.Text = new PatientService().GetLastIdOfToday().ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBillNo.Tag == null)
            {
                try
                {
                    btnSave.Enabled = false;
                    btnSave.Text = "Wait.Plz.";
                    AddNewPatient();
                    btnSave.Enabled = true;
                    btnSave.Text = "Save";
                    btnNext.Focus();

                }
                catch (Exception ex)
                {

                    btnSave.Enabled = true;
                    btnSave.Text = "Save";
                    // btnNext.Focus();

                }


            }
            else
            {

                //UpdatePrevPatient();
            }


        }

        private void UpdatePrevPatient()
        {

            long _PatientId = 0;

            long.TryParse(txtBillNo.Text, out _PatientId);

            Patient _Patient = new PatientService().GetPatientByIdNo(_PatientId);

            //if(_Patient.EntryDate.ToShortDateString() != Utils.GetServerDateAndTime().ToShortDateString())
            //{
            //    MessageBox.Show("Sorry! Edit/Update only allowed for current date patient.");
            //    return;
            //}


            double currentdiscountAmount = 0;
            double currentPaidAmount = 0;
            double currentTestCost = 0;

            double earlyTestCost = new PatientLedgerService().GetInitialTestCost(_PatientId).Debit;
            double earlydiscount = new PatientService().GetDiscountAmount(_PatientId);
            double earlyPaidTk = new PatientService().GetPaidTk(_PatientId);
            double balance = new PatientLedgerService().GetPatientLedgerBalance(_PatientId);


            double.TryParse(txtDiscount.Text, out currentdiscountAmount);
            double.TryParse(txtPaid.Text, out currentPaidAmount);
            double.TryParse(txtTotalAmount.Text, out currentTestCost);

            double newlydiscount = currentdiscountAmount - earlydiscount;
            double newlyPaidTk = currentPaidAmount - earlyPaidTk;
            double newlyTestCost = currentTestCost - earlyTestCost;


            if (newlyTestCost > 0)   //New test added
            {
                HandleNewTestAddedActivity(_PatientId, newlyTestCost, newlydiscount, newlyPaidTk, balance);

            }
            else if (newlyTestCost == 0 && newlyPaidTk > 0)   //Due collected
            {


            }
            else
            {

                MessageBox.Show("No changes made");

            }





        }

        private void HandleNewTestAddedActivity(long _PatientId, double newtestcost, double newdiscount, double newpaidtk, double _balance)
        {
            long _regNo = 0;
            long _RxId = 0;

            DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);

            List<PatientLedger> transactionList = new List<PatientLedger>();


            string _message = CheckRequiredInformation();

            btnSave.Enabled = false;

            if (String.IsNullOrEmpty(_message))
            {
                if (result == DialogResult.Yes)
                {
                    if (txtRefBy.Tag == null)
                    {
                        MessageBox.Show("Please select refd. doctor then try again.");
                        btnSave.Enabled = true;
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtDue.Text))
                    {
                        if (Convert.ToDouble(txtDue.Text) < 0)
                        {
                            MessageBox.Show("Payment mis-matched.Plz. recheck it again.", "HERP");
                            btnSave.Enabled = true;
                            btnSave.Text = "Save";
                            return;
                        }
                    }



                    long.TryParse(txtRxId.Text, out _RxId);


                    long.TryParse(txtRegNo.Text, out _regNo);

                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
                    if (_record != null)
                    {
                        _record.MobileNo = txtCellPhone.Text;
                        _record.FullName = txtPatientName.Text;
                        new RegRecordService().UpdateRegRecord(_record);

                    }


                    PatientService patientService = new PatientService();

                    Patient patient = new PatientService().GetPatientByIdNo(_PatientId);
                    patient.AgeYear = txtYears.Text;
                    patient.AgeMonth = txtMonths.Text;
                    patient.AgeDay = txtDays.Text;
                    patient.DeliveryDate = dtpDeliveryDate.Value;
                    patient.DeliveryTime = txtDeliveryTime.Text;
                    patient.DoctorId = Convert.ToInt32(txtRefBy.Tag);
                    patient.DiscountCareOf = txtCareOf.Text;
                    patient.RxId = _RxId;
                    patient.Cabin = txtCabin.Text;
                    patient.Isfree = false;
                    patient.Updateby = MainForm.LoggedinUser.UserId;


                    patientService.UpdatePatientInfo(patient);

                    string testsConducted = string.Empty;

                    List<TestsCost> testsCost = new List<TestsCost>();

                    foreach (DataGridViewRow row in dgTests.Rows)
                    {
                        SelectedTestItemsForPatient selectedTests = row.Tag as SelectedTestItemsForPatient;
                        if (selectedTests.AdditionType.ToLower() == "new")
                        {
                            TestsCost tCost = new TestsCost();
                            tCost.PatientId = _PatientId;
                            tCost.TestId = selectedTests.Id;
                            tCost.Cost = selectedTests.Cost;
                            tCost.ConsultantId = 0;

                            double.TryParse(row.Cells[5].Value.ToString(), out double discPercent);
                            tCost.DiscountInPercent = discPercent;

                            double.TryParse(row.Cells[6].Value.ToString(), out double discTaka);
                            tCost.Discount = discTaka;

                            tCost.ReportStatus = "";
                            tCost.Status = "";
                            tCost.UserId = MainForm.LoggedinUser.UserId;
                            testsCost.Add(tCost);


                            if (String.IsNullOrEmpty(testsConducted))
                            {
                                testsConducted = testsConducted + selectedTests.Name;
                            }
                            else
                            {
                                testsConducted = testsConducted + "," + selectedTests.Name;
                            }
                        }


                    }

                    if (testsCost.Count > 0)
                    {
                        TestsCostService tService = new TestsCostService();
                        tService.SaveTestsCost(testsCost);
                    }




                    PatientLedger pLedger;
                    _balance = _balance + newtestcost;
                    pLedger = new PatientLedger();
                    pLedger.PatientId = _PatientId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "New test/s added";
                    pLedger.Debit = newtestcost;
                    pLedger.Credit = 0;
                    pLedger.Balance = _balance;
                    pLedger.TransactionType = TransactionTypeEnum.AddendumTestCost.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);


                    if (newpaidtk > 0)
                    {
                        _balance = _balance - newpaidtk;
                        pLedger = new PatientLedger();
                        pLedger.PatientId = _PatientId;
                        pLedger.TranDate = DateTime.Now;
                        pLedger.Particulars = "On Entry Payment";
                        pLedger.Debit = 0;
                        pLedger.Credit = newpaidtk;
                        pLedger.Balance = _balance;
                        pLedger.TransactionType = TransactionTypeEnum.OnEntryPayment.ToString();
                        pLedger.OperateBy = MainForm.LoggedinUser.Name;
                        transactionList.Add(pLedger);
                    }

                    if (newdiscount > 0)
                    {
                        _balance = _balance - newdiscount;
                        pLedger = new PatientLedger();
                        pLedger.PatientId = _PatientId;
                        pLedger.TranDate = DateTime.Now;
                        pLedger.Particulars = "Discount";
                        pLedger.Debit = 0;
                        pLedger.Credit = newdiscount;
                        pLedger.Balance = _balance;
                        pLedger.TransactionType = TransactionTypeEnum.DiscountOnRegularCollection.ToString();
                        pLedger.OperateBy = MainForm.LoggedinUser.Name;
                        transactionList.Add(pLedger);
                    }


                    if (transactionList.Count > 0)
                    {
                        PatientLedgerService plService = new PatientLedgerService();
                        plService.SavePatientLedger(transactionList);
                    }

                    MessageBox.Show("Patient entry successful.", "HERP");
                    double grandTotal = Convert.ToDouble(txtGrandTotal.Text);
                    ShowCashMemo(_PatientId);
                    ShowCashMemo2(_PatientId);

                    btnSave.Enabled = true;
                    btnSave.Text = "Save";

                }
                else
                {
                    btnSave.Enabled = true;
                    btnSave.Text = "Save";
                }
            }
        }

        private async void ShowCashMemo2(long _PatientId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;
            ds = new DataSet();
            ds = await new ReportService().GetCashMemo(_PatientId);



            RptCashMemoCopy2 _cashmemo = new RptCashMemoCopy2();

            _cashmemo.SetDataSource(ds);

            //_cashmemo.SetParameterValue("RegBarcodeLocation", _file);
            if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            {
                _cashmemo.SetParameterValue("CabinNo", "Cabin :" + txtCabin.Text);

            }
            else
            {
                _cashmemo.SetParameterValue("CabinNo", "");

            }

            ReportViewer rv = new ReportViewer();

            List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(_PatientId);
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

            _cashmemo.SetParameterValue("Remarks", txtCareOf.Text);

            btnSave.Text = "Save";

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            //rv.Show();

        }

        private void AddNewPatient()
        {
            long _regNo = 0;
            long _billNo = 0;
            long _RxId = 0;
            long _admissionNo = 0;
            string _discountCardNo = txtDiscountCardNo.Text;
            double _discountInPercentAgainstCard = 0;
            double _discountInPercent = 0;
            int _MediaId = 0;

            long.TryParse(txtBillNo.Text, out _billNo);
            long.TryParse(txtAdmissionNo.Text, out _admissionNo);


            if (txtMedia.Tag != null)
            {
                _MediaId = Convert.ToInt32(txtMedia.Tag);
            }


            if (!String.IsNullOrEmpty(_discountCardNo))
            {
                DiscountCardType _cType = (DiscountCardType)lblCardBy.Tag;
                _discountInPercentAgainstCard = _cType.DiscountInPercent;
            }

            if (_admissionNo > 0)
            {
                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_admissionNo);
                if (_pInfo == null)
                {
                    MessageBox.Show("Invalid admission no. Please check and try again"); return;
                }
            }

            string _message = CheckRequiredInformation();

            if (String.IsNullOrEmpty(_message))
            {

                try
                {


                    DialogResult result = MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNoCancel);



                    btnSave.Enabled = false;
                    btnSave.Text = "Wait Plz..";


                    if (result == DialogResult.Yes)
                    {


                        if (txtRefBy.Tag == null)
                        {
                            MessageBox.Show("Please select refd. doctor then try again.");
                            btnSave.Enabled = true;
                            btnSave.Text = "Save";
                            return;
                        }

                        if (!String.IsNullOrEmpty(txtDue.Text))
                        {
                            if (Convert.ToDouble(txtDue.Text) < 0)
                            {
                                MessageBox.Show("Payment mis-matched.Plz. recheck it again.", "HERP");
                                btnSave.Enabled = true;
                                btnSave.Text = "Save";
                                return;
                            }
                        }


                        int _disCountRequestBy = 0;
                        double _discountAdjustfromRequester = 0;

                        if (txtRequestedby.Tag != null)
                        {
                            int.TryParse(txtRequestedby.Tag.ToString(), out _disCountRequestBy);
                        }

                        double.TryParse(txtDiscountAdjustFromReferral.Text, out _discountAdjustfromRequester);

                        long.TryParse(txtRxId.Text, out _RxId);



                        double.TryParse(txtDiscountInPercent.Text, out _discountInPercent);

                        PatientService patientService = new PatientService();


                        //  Patient _patient = new PatientService().GetPatientByBillNo(_billNo);

                        //if (_patient != null)
                        //{
                        //    txtBillNo.Text = GetNewBillNo();

                        //}

                        //if (txtBillNo.Text.Length < 10) { txtBillNo.Text = GetNewBillNo(); }  //TODO : Code refactoring must be done in this block

                        //long.TryParse(txtBillNo.Text, out _billNo);

                        // (this.ParentForm.MdiParent as MainForm).logge



                        txtDailyId.Text = new PatientService().GetLastIdOfToday().ToString();
                        txtDailyId.Tag = new PatientService().GetReportIdForThisPatient();


                        Patient patient = new Patient();
                        patient.BillNo = 0;

                        RegRecord _regTracker = GetRegNoLong();

                        txtRegNo.Text = _regTracker.RegNo.ToString();
                        patient.RegNo = _regTracker.RegNo;

                        patient.AdmissionNo = _admissionNo;
                        patient.DailyId = Convert.ToInt32(txtDailyId.Text);
                        patient.ReportIdPrefix = "B";
                        patient.ReportId = 0; //Convert.ToInt64(txtDailyId.Tag);


                        if (!String.IsNullOrWhiteSpace(txtYears.Text))
                        {
                            int _yrs = 0;
                            int.TryParse(txtYears.Text, out _yrs);
                            if (_yrs > 0)
                            {
                                patient.AgeYear = txtYears.Text.Trim();
                            }
                            else
                            {
                                patient.AgeYear = string.Empty;
                            }

                        }
                        else
                        {
                            patient.AgeYear = string.Empty;
                        }

                        if (!String.IsNullOrWhiteSpace(txtMonths.Text))
                        {
                            int _mnths = 0;
                            int.TryParse(txtMonths.Text, out _mnths);
                            if (_mnths > 0)
                            {
                                patient.AgeMonth = txtMonths.Text.Trim();
                            }
                            else
                            {
                                patient.AgeMonth = string.Empty;
                            }

                        }
                        else
                        {
                            patient.AgeMonth = string.Empty;
                        }

                        if (!String.IsNullOrWhiteSpace(txtDays.Text))
                        {
                            int _dys = 0;
                            int.TryParse(txtDays.Text, out _dys);
                            if (_dys > 0)
                            {
                                patient.AgeDay = txtDays.Text.Trim();
                            }
                            else
                            {
                                patient.AgeDay = string.Empty;
                            }

                        }
                        else
                        {
                            patient.AgeDay = string.Empty;
                        }


                        patient.EntryDate = Utils.GetServerDateAndTime();
                        patient.EntryTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        patient.DeliveryDate = dtpDeliveryDate.Value;
                        patient.DeliveryTime = GetDeliveryTime();
                        //patient.IsMediaCommissionPaid = false;
                        patient.DoctorId = Convert.ToInt32(txtRefBy.Tag);
                        patient.MediaId = _MediaId;
                        // patient.IsMediaCommissionPaid = false;
                        patient.DiscountCareOf = txtCareOf.Text;
                        patient.DiscountInPercent = _discountInPercent;
                        patient.RxId = _RxId;

                        patient.Cabin = txtCabin.Text;
                        patient.DiscountRequestById = _disCountRequestBy;
                        patient.DiscountGivenByRequestInPercent = _discountAdjustfromRequester;

                        patient.DiscountCardNo = _discountCardNo;
                        patient.DiscountHonouredInPercentAgainstCardNo = _discountInPercentAgainstCard;

                        patient.Isfree = false;
                        patient.UserId = MainForm.LoggedinUser.UserId;

                        long _pId = patientService.SavePatient(patient);

                        if (_pId > 0)
                        {

                            Patient _patient = new PatientService().GetPatientByIdNo(_pId);

                            txtBillNo.Text = _patient.BillNo.ToString();

                            string testsConducted = string.Empty;

                            List<TestsCost> testsCost = new List<TestsCost>();

                            DateTime _deliveyDate = DateTime.Now;

                            foreach (DataGridViewRow row in dgTests.Rows)
                            {
                                SelectedTestItemsForPatient selectedTests = row.Tag as SelectedTestItemsForPatient;

                                double _discInPercent = 0;
                                double.TryParse(selectedTests.discountInPercent, out _discInPercent);

                                int qty = 1;
                                if (selectedTests.ReportTypeId == 63)
                                {
                                    string[] arr = new string[2];
                                    arr[0] = "";
                                    arr[1] = "";
                                    string testName = selectedTests.Name;
                                    arr = testName.Split('-');
                                    if (arr.Length > 1 && !String.IsNullOrEmpty(arr[1]))
                                    {
                                        string _currentPcs = arr[1];
                                        string _currentPcno = _currentPcs[0].ToString();
                                        qty = Convert.ToInt32(_currentPcno);
                                    }
                                }


                                TestsCost tCost = new TestsCost();
                                tCost.PatientId = _pId;
                                tCost.TestId = selectedTests.Id;
                                tCost.Qty = qty;
                                tCost.Cost = selectedTests.Cost;

                                double.TryParse(row.Cells[5].Value.ToString(), out double discPercent);
                                tCost.DiscountInPercent = discPercent;

                                double.TryParse(row.Cells[6].Value.ToString(), out double discTaka);
                                tCost.Discount = discTaka;

                                tCost.ConsultantId = 0;
                                tCost.DeliveryDate = selectedTests.DeliveryDate;
                                tCost.DeliveryTime = selectedTests.DeliveryTime;
                                tCost.ReportStatus = ReportStatusEnum.NE.ToString();
                                tCost.Status = "";
                                tCost.UserId = MainForm.LoggedinUser.UserId;
                                testsCost.Add(tCost);

                                if (String.IsNullOrEmpty(testsConducted))
                                {
                                    testsConducted = testsConducted + selectedTests.Name;
                                }
                                else
                                {
                                    testsConducted = testsConducted + "," + selectedTests.Name;
                                }


                            }

                            //Save On Individual Tests Information
                            if (testsCost.Count > 0)
                            {
                                TestsCostService tService = new TestsCostService();
                                tService.SaveTestsCost(testsCost);
                            }

                            if (_discountCardNo != "")
                            {
                                VMDiscountCard _dcard = (VMDiscountCard)txtDiscountCardNo.Tag;
                                DiscountCard _card = new CommonService().GetDiscountCardByCardNo(_discountCardNo);
                                _card.status = "Used";
                                _card.UsedDate = Utils.GetServerDateAndTime();

                                new CommonService().UpdateCardStatus(_card);
                            }



                            double balance = 0;
                            double _testAmount = 0;
                            double.TryParse(txtTotalAmount.Text, out _testAmount);
                            balance = 0 - _testAmount;
                            //Save On Entry Payment Information
                            List<PatientLedger> transactionList = new List<PatientLedger>();

                            PatientLedger pLedger = new PatientLedger();
                            pLedger.PatientId = _pId;
                            pLedger.TranDate = Utils.GetServerDateAndTime();

                            pLedger.Particulars = testsConducted;
                            pLedger.Debit = _testAmount;
                            pLedger.Credit = 0;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.TestCost.ToString();
                            pLedger.OperateBy = MainForm.LoggedinUser.Name;
                            pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                            transactionList.Add(pLedger);




                            double discount = 0;
                            double.TryParse(txtDiscount.Text, out discount);
                            if (discount > 0)
                            {
                                discount = Convert.ToDouble(txtDiscount.Text);
                                balance = balance + discount;
                                pLedger = new PatientLedger();
                                pLedger.PatientId = _pId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                pLedger.Particulars = "Discount";
                                pLedger.Debit = 0;
                                pLedger.Credit = discount;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.DiscountOnRegularCollection.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                pLedger.Remarks = txtCareOf.Text;
                                transactionList.Add(pLedger);
                            }



                            double paidTk = 0;
                            double.TryParse(txtPaid.Text, out paidTk);
                            if (paidTk > 0)
                            {
                                paidTk = Convert.ToDouble(txtPaid.Text);
                                balance = balance + paidTk;
                                pLedger = new PatientLedger();
                                pLedger.PatientId = _pId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                pLedger.Particulars = "On Entry Payment";
                                pLedger.Debit = 0;
                                pLedger.Credit = paidTk;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.OnEntryPayment.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                transactionList.Add(pLedger);
                            }

                            if (transactionList.Count > 0)
                            {

                                if (new PatientLedgerService().SavePatientLedger(transactionList))
                                {

                                    MessageBox.Show("Patient entry successful.", "HERP");

                                    if (_MediaId > 0)  // TODO: Set Media Ledger Here.
                                    {


                                    }

                                    List<PatientLedger> _ledgerVerify = new PatientLedgerService().GetLedgerByPatientId(_pId);
                                    List<TestsCost> _testCostVerify = new PatientService().GetTestList(_pId);

                                    if (_ledgerVerify.Count > 0 && _testCostVerify.Count > 0)
                                    {
                                        ShowCashMemo(_pId);
                                        ShowCashMemo2(_pId);
                                        ShowCashMemo3(_pId);
                                        PrepareForNextOne();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Some transactional mis-matched found.Plz. check and try again.", "HERP");

                                    }



                                }
                                else
                                {
                                    MessageBox.Show("Some transactional mis-matched found.Plz. check and try again.", "HERP");

                                }

                            }
                            else
                            {
                                MessageBox.Show("Some transactional mis-matched found.Plz. check and try again.", "HERP");

                            }





                            LoadCountInformation();

                            IsKeyPressed = false;
                            //scop.Complete();
                        }
                    }
                    // }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show(_message, "HERP");
                btnSave.Text = "Save";
            }


            cmbGender.Text = "";

            btnSave.Enabled = true;
            btnSave.Text = "Save";
        }

        private async void ShowCashMemo3(long _PatientId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;
            ds = new DataSet();
            ds = await new ReportService().GetCashMemo(_PatientId);



            RptCashMemoUserCopy _cashmemo = new RptCashMemoUserCopy();

            _cashmemo.SetDataSource(ds);

            //_cashmemo.SetParameterValue("RegBarcodeLocation", _file);
            if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            {
                _cashmemo.SetParameterValue("CabinNo", "Cabin :" + txtCabin.Text);

            }
            else
            {
                _cashmemo.SetParameterValue("CabinNo", "");

            }

            ReportViewer rv = new ReportViewer();

            List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(_PatientId);
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

            _cashmemo.SetParameterValue("Remarks", txtCareOf.Text);

            btnSave.Text = "Save";

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            //rv.Show();
        }



        private RegRecord GetRegNoLong()
        {
            long _regNo = 0;
            CalledFromOtherPlace = true;

            //RegUniqueKeyTracker _regTracker = GetNewRegNo();
            // txtRegNo.Text = 0;


            long.TryParse(txtRegNo.Text, out _regNo);

            RegRecord _rrecord = new RegRecordService().GetRegRecordByRegNo(_regNo);

            if (_rrecord != null)
            {
                return _rrecord;
            }
            else
            {

                RegRecord _rgRecord = new RegRecord();
                _rgRecord.RegNo = 0;
                _rgRecord.FullName = txtPatientName.Text;
                if (!String.IsNullOrWhiteSpace(txtYears.Text))
                {
                    int _yrs = 0;
                    int.TryParse(txtYears.Text, out _yrs);
                    if (_yrs > 0)
                    {
                        _rgRecord.AgeYear = txtYears.Text.Trim();
                    }
                    else
                    {
                        _rgRecord.AgeYear = string.Empty;
                    }

                }
                else
                {
                    _rgRecord.AgeYear = string.Empty;
                }

                if (!String.IsNullOrWhiteSpace(txtMonths.Text))
                {
                    int _mnths = 0;
                    int.TryParse(txtMonths.Text, out _mnths);
                    if (_mnths > 0)
                    {
                        _rgRecord.AgeMonth = txtMonths.Text.Trim();
                    }
                    else
                    {
                        _rgRecord.AgeMonth = string.Empty;
                    }

                }
                else
                {
                    _rgRecord.AgeMonth = string.Empty;
                }

                if (!String.IsNullOrWhiteSpace(txtDays.Text))
                {
                    int _dys = 0;
                    int.TryParse(txtDays.Text, out _dys);
                    if (_dys > 0)
                    {
                        _rgRecord.AgeDay = txtDays.Text.Trim();
                    }
                    else
                    {
                        _rgRecord.AgeDay = string.Empty;
                    }

                }
                else
                {
                    _rgRecord.AgeDay = string.Empty;
                }

                _rgRecord.Sex = cmbGender.Text;
                _rgRecord.CountryCode = "";
                _rgRecord.MobileNo = txtCellPhone.Text;
                _rgRecord.DOB = GetDob();

                RegRecord _record = new RegRecordService().SaveRegRecord(_rgRecord);

                _record = new RegRecordService().GetRegRecordById(_record.Id);

                return _record;

            }

        }

        private string GetDeliveryTime()
        {

            dtpDeliveryDate.Value = DateTime.Now;

            if (Configuration.ORG_CODE == "1")
            {
                DateTime _firsthalf = Convert.ToDateTime(("2:00 PM"));
                DateTime _secondHalf = Convert.ToDateTime(("07:30 PM"));
                DateTime _thirdHalf = Convert.ToDateTime(("9:30 PM"));

                DateTime _t1 = Utils.GetServerDateAndTime();
                if (_t1.TimeOfDay.Ticks <= _firsthalf.TimeOfDay.Ticks) return "5.30 PM";


                if (_t1.TimeOfDay.Ticks > _firsthalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _secondHalf.TimeOfDay.Ticks) return "9:30 PM";

                if (_t1.TimeOfDay.Ticks > _secondHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _thirdHalf.TimeOfDay.Ticks) return "11:30 PM";


                dtpDeliveryDate.Value = DateTime.Now.AddDays(1);
                return "5:30 PM";

            }
            else
            {


                //Summer Schedule
                DateTime _firsthalf = Convert.ToDateTime(("1:00 PM"));
                DateTime _secondHalf = Convert.ToDateTime(("3:00 PM"));
                DateTime _thirdHalf = Convert.ToDateTime(("4:00 PM"));
                DateTime _4thhalf = Convert.ToDateTime(("5:00 PM"));
                DateTime _5thHalf = Convert.ToDateTime(("6:00 PM"));
                DateTime _6thHalf = Convert.ToDateTime(("7:00 PM"));
                DateTime _7thhalf = Convert.ToDateTime(("8:00 PM"));
                DateTime _8thHalf = Convert.ToDateTime(("9:30 PM"));

                DateTime _t1 = Utils.GetServerDateAndTime();




                if (_t1.TimeOfDay.Ticks <= _firsthalf.TimeOfDay.Ticks) return "3:30 PM";

                if (_t1.TimeOfDay.Ticks > _firsthalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _secondHalf.TimeOfDay.Ticks) return "5:45 PM";

                if (_t1.TimeOfDay.Ticks > _secondHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _thirdHalf.TimeOfDay.Ticks) return "6:30 PM";

                if (_t1.TimeOfDay.Ticks > _thirdHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _4thhalf.TimeOfDay.Ticks) return "7:30 PM";

                if (_t1.TimeOfDay.Ticks > _4thhalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _5thHalf.TimeOfDay.Ticks) return "8:30 PM";

                if (_t1.TimeOfDay.Ticks > _5thHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _6thHalf.TimeOfDay.Ticks) return "9:30 PM";

                if (_t1.TimeOfDay.Ticks > _6thHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _7thhalf.TimeOfDay.Ticks) return "10:30 PM";

                if (_t1.TimeOfDay.Ticks > _7thhalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _8thHalf.TimeOfDay.Ticks) return "11:30 PM";

                dtpDeliveryDate.Value = DateTime.Now.AddDays(1);
                return "3:30 PM";


                //End of Summer Schedule  



                //Ramadan Schedule

                /*
                    DateTime _firsthalf = Convert.ToDateTime(("1:00 PM"));
                    DateTime _secondHalf = Convert.ToDateTime(("2:00 PM"));
                    DateTime _thirdHalf = Convert.ToDateTime(("3:00 PM"));
                    DateTime _4thhalf = Convert.ToDateTime(("4:00 PM"));
                    DateTime _5thHalf = Convert.ToDateTime(("5:00 PM"));
                    DateTime _6thHalf = Convert.ToDateTime(("6:00 PM"));
                    DateTime _7thhalf = Convert.ToDateTime(("7:00 PM"));
                    DateTime _8thHalf = Convert.ToDateTime(("8:30 PM"));

                    DateTime _t1 = Utils.GetServerDateAndTime();

                    if (_t1.TimeOfDay.Ticks <= _firsthalf.TimeOfDay.Ticks) return "3:30 PM";

                    if (_t1.TimeOfDay.Ticks > _firsthalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _secondHalf.TimeOfDay.Ticks) return "4:30 PM";

                    if (_t1.TimeOfDay.Ticks > _secondHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _thirdHalf.TimeOfDay.Ticks) return "5:30 PM";

                    if (_t1.TimeOfDay.Ticks > _thirdHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _4thhalf.TimeOfDay.Ticks) return "6:30 PM";

                    if (_t1.TimeOfDay.Ticks > _4thhalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _5thHalf.TimeOfDay.Ticks) return "7:30 PM";

                    if (_t1.TimeOfDay.Ticks > _5thHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _6thHalf.TimeOfDay.Ticks) return "8:30 PM";

                    if (_t1.TimeOfDay.Ticks > _6thHalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _7thhalf.TimeOfDay.Ticks) return "9:30 PM";

                    if (_t1.TimeOfDay.Ticks > _7thhalf.TimeOfDay.Ticks && _t1.TimeOfDay.Ticks <= _8thHalf.TimeOfDay.Ticks) return "10:30 PM";

                    dtpDeliveryDate.Value = DateTime.Now.AddDays(1);
                    return "3:30 PM";


                    //End of Ramadan Schedule

                    */
            }

        }

        private void LoadBarcodeForId(string _PatientId)
        {

            _control2.BarCode = _PatientId.ToString();// GetBarcodeString(_PatientId.ToString());//.Aggregate(string.Empty, (c, i) => c + i + ' '); 
            _control2.BarCodeHeight = 15;
            _control2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control2.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            _control2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control2.HeaderText = "";
            _control2.LeftMargin = 10;
            _control2.Location = new System.Drawing.Point(950, 480);
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

        private DateTime GetDob()
        {
            int yrs = 0, mnths = 0, dys = 0;
            int.TryParse(txtYears.Text, out yrs);
            int.TryParse(txtMonths.Text, out mnths);
            int.TryParse(txtDays.Text, out dys);

            DateTime _dt = DateTime.Now;
            _dt = _dt.AddYears(0 - yrs);
            _dt = _dt.AddMonths(0 - mnths);
            _dt = _dt.AddDays(0 - dys);

            return _dt;
        }

        private RegUniqueKeyTracker GetNewRegNo()
        {

            string _workStationId = MainForm.WorkStationId; //MainForm.WorkStationId;

            RegUniqueKeyTracker _regTracker = new RegRecordService().GetRegUniqueKey(_workStationId, Utils.GetServerDateAndTime().ToString("yy"), Utils.GetServerDateAndTime().Month);

            if (_regTracker == null)
            {



                _regTracker = new RegRecordService().GetRegUniqueKey(_workStationId, Utils.GetServerDateAndTime().ToString("yy"), Utils.GetServerDateAndTime().Month);

                return _regTracker;
            }

            return _regTracker;


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
                txtCellPhone.Text = _record.MobileNo;
                cmbGender.Text = _record.Sex;
                txtDiscountInPercent.Text = _record.Discount.ToString();

                DateDiff _dateDiff = new DateDiff(_record.DOB, DateTime.Now);
                int yrs = _dateDiff.ElapsedYears;
                int months = _dateDiff.ElapsedMonths;
                int dys = _dateDiff.ElapsedDays;

                txtYears.Text = yrs.ToString();
                txtMonths.Text = months.ToString();
                txtDays.Text = dys.ToString();


                return true;

            }

            return false;

        }


        private string CheckRequiredInformation()
        {
            string msg = string.Empty;

            if (String.IsNullOrEmpty(txtCellPhone.Text))
            {
                msg = "Mobile No";
            }


            if (String.IsNullOrEmpty(txtPatientName.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Patient Name";
                }
                else
                {
                    msg = msg + ", Patient Name";
                }
            }

            int _ageY = 0;
            int _ageM = 0;
            int _ageD = 0;

            int.TryParse(txtYears.Text, out _ageY);
            int.TryParse(txtMonths.Text, out _ageM);
            int.TryParse(txtDays.Text, out _ageD);

            if (_ageY == 0 && _ageM == 0 && _ageD == 0)
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Age";
                }
                else
                {
                    msg = msg + ", Age";
                }
            }

            if (String.IsNullOrEmpty(cmbGender.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Sex";
                }
                else
                {
                    msg = msg + ", Sex";
                }
            }

            if (String.IsNullOrEmpty(txtRefBy.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Refd. By";
                }
                else
                {
                    msg = msg + ", Refd. By";
                }
            }


            if (String.IsNullOrEmpty(msg))
            {
                return msg;
            }
            else
            {
                return msg + " Required.";
            }


        }

        private async void ShowCashMemo(long _PId)
        {

            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;
            ds = new DataSet();
            ds = await new ReportService().GetCashMemo(_PId);



            RptCashMemo _cashmemo = new RptCashMemo();

            _cashmemo.SetDataSource(ds);

            //_cashmemo.SetParameterValue("RegBarcodeLocation", _file);
            if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            {
                _cashmemo.SetParameterValue("CabinNo", "Cabin :" + txtCabin.Text);

            }
            else
            {
                _cashmemo.SetParameterValue("CabinNo", "");

            }

            ReportViewer rv = new ReportViewer();

            List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(_PId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetCashMemotransaction(_pLedger);

            string _remarks = Helper.GetDiscountRemarks(_pLedger);

            if (String.IsNullOrEmpty(_remarks)) _remarks = "";

            List<TestGroup> _tGroups = new PatientService().GetTestGroupsByPatientId(_PId);

            string _movementString = new PatientService().GetMovementString(_tGroups);

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

            _cashmemo.SetParameterValue("MovementString", _movementString);
            _cashmemo.SetParameterValue("Remarks", _remarks);

            if (Configuration.ORG_CODE == "2")
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 3q Zjvq");
            }
            else
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 2q Zjvq");
            }

            btnSave.Text = "Save";

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            // rv.Show();

            // Thread.Sleep(500);

            // rv.Close();

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


        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }

        private void dgTests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            if (IsNewEntry)
            {
                double total = _SelectedTests.Where(x => x.ReportTypeId != 63).Sum(y => y.Cost);
                double _VacuTotal = _SelectedTests.Where(x => x.ReportTypeId == 63).Sum(y => y.Cost);

                txtDue.Text = ((total + _VacuTotal) - GetSubTractedAmount()).ToString();
                txtGrandTotal.Text = txtDue.Text;
            }
            else
            {
                long _pId = 0;
                long.TryParse(txtBillNo.Text, out _pId);

                double _disc = 0;
                double.TryParse(txtDiscount.Text, out _disc);

                double _PrevDue = new ReportService().GetDueTk(_pId);
                double total = _SelectedTests.Where(x => x.AdditionType.ToLower() == "new").Sum(y => y.Cost);

                txtDue.Text = (total + _PrevDue - GetSubTractedAmount()).ToString();
                txtGrandTotal.Text = (total - _disc).ToString();
            }

        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            if (IsNewEntry)
            {
                double total = dgTests.Rows.Cast<DataGridViewRow>()
                              .Sum(t => Convert.ToDouble(t.Cells[4].Value));

                txtDue.Text = (total - GetSubTractedAmount()).ToString();
            }
            else
            {
                long _pId = 0;
                long.TryParse(txtBillNo.Text, out _pId);
                double _dueTk = new ReportService().GetDueTk(_pId);
                double _testAmount = _SelectedTests.Where(x => x.AdditionType.ToLower() == "new").Sum(y => y.Cost);
                double _discount = 0;
                double.TryParse(txtDiscount.Text, out _discount);

                double _total = _dueTk + _testAmount - _discount;
                ;

                txtDue.Text = (_total - GetSubTractedAmountForAppendTest()).ToString();
            }


        }

        private double GetSubTractedAmountForAppendTest()
        {
            double _paidtk = 0;



            double.TryParse(txtPaid.Text, out _paidtk);

            double _totalDeduction = _paidtk;

            return _totalDeduction;
        }

        private double GetSubTractedAmount()
        {
            double _discout = 0, _paidtk = 0;



            double.TryParse(txtDiscount.Text, out _discout);



            double.TryParse(txtPaid.Text, out _paidtk);

            double _totalDeduction = _discout + _paidtk;

            return _totalDeduction;

        }

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumeric(txtGrandTotal.Text) && Utility.IsNumeric(txtPercent.Text))
            {
                double gtotal = Convert.ToDouble(txtGrandTotal.Text);
                double percent = Convert.ToDouble(txtPercent.Text);
                double discount = Math.Round((gtotal * percent) / 100);
                txtDiscountAmount.Text = discount.ToString();
                txtDiscountedAmount.Text = (gtotal - discount).ToString();
            }
        }

        private void lblRecievedBy_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAddReferral_Click(object sender, EventArgs e)
        {
            frmAddReferral frmar = new frmAddReferral();
            frmar.Show();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            PrepareForNextOne();

            // LoadBarcode();
        }

        private void PrepareForNextOne()
        {
            ClearFields();
            //txtRegNo.Text = GetNextRegNo();

            txtDailyId.Text = new PatientService().GetLastIdOfToday().ToString();
            _SelectedTests = new List<SelectedTestItemsForPatient>();
            _TubeTests = new List<SelectedTestItemsForPatient>();


        }



        private void ClearFields()
        {
            unlocked = false;


            txtDiscountCardNo.Text = "";
            txtDiscountCardNo.Tag = null;
            lblCardBy.Text = "";
            lblCardBy.Tag = null;

            txtRegNo.Text = "";
            txtBillNo.Text = "";
            txtPrevBill.Text = "";
            txtRxId.Text = "";
            txtPatientName.Text = "";
            txtRefBy.Text = "";
            txtRefBy.Tag = null;
            txtBillNo.Tag = null;
            txtAdmissionNo.Text = "";
            txtAdmissionNo.Tag = null;
            txtYears.Text = "";
            txtMonths.Text = "";
            txtDays.Text = "";
            txtCabin.Text = "";
            txtDiscountInPercent.Text = "";
            txtDiscount.Text = "";
            txtTotalAmount.Text = "";
            txtGrandTotal.Text = "";
            txtPaid.Text = "";
            txtCellPhone.Text = "";
            txtCareOf.Text = "";
            txtDue.Text = "";
            IsNewEntry = true;
            txtRequestedby.Tag = null;
            txtRequestedby.Text = "";
            txtDiscountAdjustFromReferral.Text = "";
            txtDeliveryTime.Text = GetDeliveryTime();
            dgTests.Rows.Clear();
            txtCellPhone.Focus();
            unlocked = true;
            IsKeyPressed = false;
            lblPreviousPaid.Visible = true;
        }

        private void txtPoorFund_TextChanged(object sender, EventArgs e)
        {

            double total = dgTests.Rows.Cast<DataGridViewRow>()
                          .Sum(t => Convert.ToDouble(t.Cells[4].Value));


            txtDue.Text = (total - GetSubTractedAmount()).ToString();


        }

        private void cmdCollection_Click(object sender, EventArgs e)
        {
            frmCollection frmar = new frmCollection();
            frmar.Show();
        }

        private void txtHCVAdjustment_TextChanged(object sender, EventArgs e)
        {
            double total = dgTests.Rows.Cast<DataGridViewRow>()
                          .Sum(t => Convert.ToDouble(t.Cells[4].Value));

            txtDue.Text = (total - GetSubTractedAmount()).ToString();


        }

        private void txtDiscountInPercent_TextChanged(object sender, EventArgs e)
        {
            SetPercentDiscountAmount();

        }

        private void SetPercentDiscountAmount()
        {
            if (IsNewEntry)
            {
                double lessInPercent = 0, totalLess = 0;

                double.TryParse(txtDiscountInPercent.Text, out lessInPercent);

                //double total =  dgTests.Rows.Cast<DataGridViewRow>()
                //            .Sum(t => Convert.ToDouble(t.Cells[4].Value));
                double total = _SelectedTests.Where(item => item.ReportTypeId != 63).Sum(item => item.Cost);
                double _vacuTotal = _SelectedTests.Where(item => item.ReportTypeId == 63).Sum(item => item.Cost);

                if (total > 0)
                {
                    if (txtBillNo.Tag == null)  // Non-update mode
                    {
                        totalLess = (total * lessInPercent) / 100;
                        txtGrandTotal.Text = ((total + _vacuTotal) - totalLess).ToString();
                        txtDiscount.Text = totalLess.ToString();
                    }
                    else   //Update mode
                    {
                        double _total = 0;
                        long _PatientId = 0;
                        long.TryParse(txtBillNo.Text, out _PatientId);


                        double _prevdiscount = new PatientService().GetDiscountAmount(_PatientId);

                        double.TryParse(txtTotalAmount.Text, out _total);

                        double _newtotal = _SelectedTests.Where(item => item.AdditionType.ToLower() == "new").Sum(item => item.Cost);
                        double _newdiscount = (_newtotal * lessInPercent) / 100;
                        double _totalLess = _prevdiscount + _newdiscount;
                        txtDiscount.Text = _totalLess.ToString();
                        txtGrandTotal.Text = (_total - _totalLess).ToString();

                    }
                }
            }
            else
            {
                double lessInPercent = 0, totalLess = 0;

                double.TryParse(txtDiscountInPercent.Text, out lessInPercent);

                double _tDue = 0;
                double.TryParse(txtDue.Text, out _tDue);

                //double total =  dgTests.Rows.Cast<DataGridViewRow>()
                //            .Sum(t => Convert.ToDouble(t.Cells[4].Value));
                double total = _SelectedTests.Where(item => item.ReportTypeId != 63 && item.AdditionType.ToLower() == "new").Sum(item => item.Cost);

                if (total > 0)
                {
                    if (txtBillNo.Tag == null)  // Non-update mode
                    {
                        totalLess = (total * lessInPercent) / 100;
                        txtGrandTotal.Text = (total - totalLess).ToString();
                        txtDiscount.Text = totalLess.ToString();
                    }
                    else   //Update mode
                    {
                        double _total = 0;
                        long _PatientId = 0;
                        long.TryParse(txtBillNo.Text, out _PatientId);
                        double _prevdiscount = 0;

                        double.TryParse(txtTotalAmount.Text, out _total);

                        double _newtotal = _SelectedTests.Where(item => item.AdditionType.ToLower() == "new").Sum(item => item.Cost);
                        double _newdiscount = (_newtotal * lessInPercent) / 100;
                        double _totalLess = _prevdiscount + _newdiscount;
                        txtDiscount.Text = _totalLess.ToString();
                        txtGrandTotal.Text = (_total - _totalLess).ToString();
                        txtDue.Text = (_tDue - _totalLess).ToString();
                    }
                }

            }

        }

        private void btnEditPatientInfo_Click(object sender, EventArgs e)
        {
            frmEditPatientInfo frmedit = new frmEditPatientInfo();
            frmedit.Show();
        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtPatientName.Text)) return;

            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());

            if (txtPatientName.Text.Length > 2 && txtPatientName.Text.Substring(0, 3).ToLower() == "mrs")
            {
                cmbGender.Text = "Female";
            }
            else if (txtPatientName.Text.Substring(0, 2).ToLower() == "mr")
            {
                cmbGender.Text = "Male";
            }
            else if (txtPatientName.Text.Substring(0, 2).ToLower() == "ms")
            {
                cmbGender.Text = "Female";
            }
            else
            {
                cmbGender.Text = "";
            }

            txtYears.Focus();
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnSave.Focus();
        }

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _regNo = 0;
                Int64.TryParse(txtRegNo.Text, out _regNo);
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);

                if (!LoadRegPatientInfo(_regNo))
                {
                    MessageBox.Show("Reg No not found.Please check and try again.");
                }

                if (_record != null)
                {

                    // LoadBarcode();
                    txtRefBy.Focus();
                }
            }
        }

        private void txtRxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _RxId = 0;
                long.TryParse(txtRxId.Text, out _RxId);

                CalledFromOtherPlace = true;

                RxPatientMasterData rxPatient = null;// new RxService().GetPatientByRxId(_RxId);
                if (rxPatient != null)
                {

                    unlocked = false;
                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(rxPatient.RegNo);
                    txtRegNo.Text = rxPatient.RegNo.ToString();
                    unlocked = true;

                    if (_record != null)
                    {
                        txtPatientName.Text = _record.FullName;
                        txtYears.Text = _record.AgeYear;
                        txtMonths.Text = _record.AgeMonth;
                        txtDays.Text = _record.AgeDay;
                        txtCellPhone.Text = _record.MobileNo;
                        //txtAddress.Text = _record.Present_Vill_House_RoadNo + ", " + _record.Present_PostOffice;
                        cmbGender.Text = _record.Sex;

                        Doctor _doctor = null;// new DoctorService().GetDoctorById(rxPatient.PractitionerRefdDoctorId);
                        unlocked = false;
                        if (_doctor != null)
                        {
                            txtRefBy.Text = _doctor.Name;
                            txtRefBy.Tag = _doctor.DoctorId;
                        }
                        else
                        {
                            txtRefBy.Text = "N.F";
                            txtRefBy.Tag = null;
                        }

                        unlocked = true;

                        List<RxTest> _listDiagnosis = new RxService().GetRxTestsByRxId(_RxId);
                        /*  foreach (var item in _listDiagnosis)
                           {
                               TestItem titem = new TestService().GetTestItemById(item.TestId);

                               SelectedTestItemsForPatient _selectedTest = new SelectedTestItemsForPatient();
                               _selectedTest.Id = titem.TestId;
                               _selectedTest.Name = titem.Name;
                               _selectedTest.ReportTypeId = titem.ReportTypeId;
                               _selectedTest.DeliveryDate = dtpDeliveryDate.Value.ToString();
                               _selectedTest.DeliveryTime = txtDeliveryTime.Text;
                               _selectedTest.Cost = titem.Rate;
                               _selectedTest.discount = "0";
                               _selectedTest.discountInPercent = "0";
                               _selectedTest.AdditionType = "New";
                               DataGridViewRow row = new DataGridViewRow();
                               row.Height = 35;
                               row.Tag = _selectedTest;
                               _SelectedTests.Add(_selectedTest);
                               row.CreateCells(dgTests, titem.TestId, titem.Name, dtpDeliveryDate.Value, txtDeliveryTime.Text, titem.Rate, false);
                               dgTests.Rows.Add(row);
                           }
                           */

                        CalculateTestAmount();

                        //LoadBarcode();
                        txtPaid.Focus();
                    }

                }
            }
        }

        private void txtCellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // LoadPrevoiusPatientInfo();
                // txtPatientName.Focus();



            }
        }

        private void LoadPrevoiusPatientInfo()
        {
            List<RegRecord> _record = new RegRecordService().GetRegRecordByMobileNo(txtCellPhone.Text).ToList();
            if (_record.Count() == 1)
            {
                RegRecord record = _record.FirstOrDefault();

                CalledFromOtherPlace = true;
                unlocked = false;
                txtRegNo.Text = record.RegNo.ToString();
                txtPatientName.Text = record.FullName;
                txtYears.Text = record.AgeYear;
                txtMonths.Text = record.AgeMonth;
                txtDays.Text = record.AgeDay;
                cmbGender.Text = record.Sex;
                txtRefBy.Focus();
                unlocked = true;

            }
            else if (_record.Count() > 1)
            {
                ctlPatientSearch.Visible = true;
                ctlPatientSearch.txtSearch.Text = "";
                ctlPatientSearch.LoadDataByType(txtCellPhone.Text);
                ctlPatientSearch.txtSearch.Focus();
            }
            else
            {
                txtPatientName.Focus();
            }


            if (txtCellPhone.Text.Length > 11)
            {
                MessageBox.Show("Mobile no exceeds 10 digit. Please check and try again.");
                txtCellPhone.Focus();
            }



        }

        private void txtPatientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalledFromOtherPlace = true;
                long _PId = 0;
                long.TryParse(txtBillNo.Text, out _PId);
                LoadPrevoiusPatientInfo(_PId);
            }
        }

        private async void LoadPrevoiusPatientInfo(long _PId)
        {
            Patient _PatientInfo = new PatientService().GetPatientByIdNo(_PId);

            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");
                txtRegNo.Tag = null;
                IsNewEntry = true;
                unlocked = false;
            }
            else
            {

                IsNewEntry = false;

                txtBillNo.Tag = _PatientInfo; //This will be checked for either new patient or old patient

                txtRegNo.Text = _PatientInfo.RegNo.ToString();
                LoadRegPatientInfo(_PatientInfo.RegNo);

                txtRegNo.Tag = _PatientInfo;

                if (_PatientInfo.AdmissionNo > 0)
                {
                    txtAdmissionNo.Text = _PatientInfo.AdmissionNo.ToString();
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_PatientInfo.AdmissionNo);
                    if (_pInfo != null)
                    {
                        HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_pInfo.AdmissionId);
                        if (_accomInfo != null)
                        {
                            CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                            txtCabin.Text = _Cabin.CabinNo;
                        }
                    }
                }
                else
                {
                    txtAdmissionNo.Text = "";
                    txtCabin.Text = "";
                }

                //txtDiscountInPercent.Text = _PatientInfo.DiscountInPercent.ToString();


                unlocked = false;

                txtRefBy.Text = new DoctorService().GetDoctorById(_PatientInfo.DoctorId).Name;
                txtRefBy.Tag = _PatientInfo.DoctorId;

                unlocked = true;

                Doctor _requestedDoc = new DoctorService().GetDoctorById(_PatientInfo.DiscountRequestById);
                if (_requestedDoc != null)
                {
                    txtRequestedby.Text = _requestedDoc.Name;
                    txtRequestedby.Tag = _requestedDoc.DoctorId.ToString();
                    txtDiscountAdjustFromReferral.Text = _PatientInfo.DiscountGivenByRequestInPercent.ToString();

                }


                lblEntrtyDate.Text = _PatientInfo.EntryDate.ToShortDateString();


                if (String.IsNullOrEmpty(_PatientInfo.Status))
                {
                    DataSet ds = await new ReportService().GetCashMemo(_PatientInfo.PatientId);

                    DataTable dt = ds.Tables[0];



                    _SelectedTests = (from DataRow dr in dt.Rows
                                      select new SelectedTestItemsForPatient()
                                      {
                                          Id = Convert.ToInt32(dr["TestId"]),
                                          TestCode = Convert.ToInt32(dr["TestCode"]),
                                          Qty = Convert.ToInt32(dr["Qty"]),
                                          ReportTypeId = Convert.ToInt32(dr["ReportTypeId"].ToString()),
                                          Name = dr["TestName"].ToString(),
                                          Cost = Convert.ToDouble(dr["Cost"]),
                                          discountInPercent = dr["DiscountInPercent"].ToString(),
                                          TestDeliveryDate = dr["TestDeliveryDate"].ToString(),
                                          TestDeliveryTime = dr["TestDeliveryTime"].ToString(),
                                          discount = dr["Discount"].ToString(),
                                          Status = dr["TestStatus"].ToString(),
                                          UserName = dr["ReceivedByName"].ToString(),
                                          AdditionType = "Old" // Previously entered test called for review
                                      }).ToList();


                    FillTestGridForPrevPatient(_PId);
                    //LoadBarcode();
                    //LoadBarcodeForId(txtPatientId.Text);



                }
                else
                {
                    MessageBox.Show("This is a cancelled Id.", "HERP");

                }
            }
        }

        private void SetAmount(long patientId)
        {

            //double total = dgTests.Rows.Cast<DataGridViewRow>()
            //                .Sum(t => Convert.ToDouble(t.Cells[4].Value));

            //txtTotalAmount.Text = total.ToString();

            double discount = new PatientService().GetDiscountAmount(patientId);
            double PaidTk = new PatientService().GetPaidTk(patientId);
            double dueTk = new ReportService().GetDueTk(patientId);
            // double gTotal = total - discount;

            txtDue.Text = dueTk.ToString();

            lblPreviousPaid.Visible = true;
            lblPreviousPaid.Text = "Paid Tk. :" + PaidTk.ToString();

            // txtGrandTotal.Text= total.ToString();
            //  txtDiscount.Text = discount.ToString();
            // txtPaid.Text = PaidTk.ToString();



            //double balance = new PatientService().GetCurrentBalance(patientId);

            //if (balance > 0)
            //{
            //   // txtReturnableTk.Text = Math.Abs(balance).ToString();
            //}

        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            Patient _patient = null;
            CalledFromOtherPlace = true;

            if (String.IsNullOrEmpty(txtPrevBill.Text))
            {
                _patient = new PatientService().GetLastReceivedPatientByUser(MainForm.LoggedinUser.UserId);
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtPrevBill.Text, out _billNo);
                Patient _Patient = new PatientService().GetPatientByBillNo(_billNo);
                _patient = new PatientService().GetPatientByIdNo(_Patient.PatientId - 1);

            }

            if (_patient != null)
            {
                txtPrevBill.Text = _patient.BillNo.ToString();
                LoadPrevoiusPatientInfo(_patient.PatientId);
            }
            else
            {
                MessageBox.Show("Patient not found.");
                _SelectedTests = new List<SelectedTestItemsForPatient>();
                ClearFields();

            }
        }

        private void btnNextId_Click(object sender, EventArgs e)
        {
            Patient _patient = null;
            CalledFromOtherPlace = true;

            if (String.IsNullOrEmpty(txtPrevBill.Text))
            {
                _patient = new PatientService().GetFirstReceivedPatientByUser(MainForm.LoggedinUser.UserId);
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtPrevBill.Text, out _billNo);
                _patient = new PatientService().GetPatientByIdNo(_billNo + 1);

            }

            if (_patient != null)
            {
                txtPrevBill.Text = _patient.BillNo.ToString();
                LoadPrevoiusPatientInfo(_patient.PatientId);
            }
            else
            {
                MessageBox.Show("Patient not found.");
                _SelectedTests = new List<SelectedTestItemsForPatient>();
                ClearFields();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            double _gtotal = 0;
            long.TryParse(txtPrevBill.Text, out _billNo);

            Patient _Patient = new PatientService().GetPatientByBillNo(_billNo);

            if (_Patient == null) _Patient = new PatientService().GetPatientByIdNo(_billNo);

            if (_Patient == null) return;

            List<PatientLedger> _ledgerVerify = new PatientLedgerService().GetLedgerByPatientId(_Patient.PatientId);
            List<TestsCost> _testCostVerify = new PatientService().GetTestList(_Patient.PatientId);

            if (_ledgerVerify.Count > 0 && _testCostVerify.Count > 0)
            {
                ShowCashMemo(_Patient.PatientId);
                ShowCashMemo2(_Patient.PatientId);
                ShowCashMemo3(_Patient.PatientId);
            }
            else
            {
                MessageBox.Show("Some transactional mis-matched found.It will be reversed.Plz. check and make a re-entry.", "HERP");

                PrepareForNextOne();
            }

        }

        private void txtCellPhone_Leave(object sender, EventArgs e)
        {
            //LoadPrevoiusPatientInfo();


        }

        //private void dgTests_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgTests.CurrentCell.ColumnIndex == 5)  //example-'Column index=4'
        //    {

        //        double disInPercent =Convert.ToDouble(dgTests.CurrentRow.Cells[5].Value);
        //        if (disInPercent > 0)
        //        {
        //            double _currentDiscount = 0;

        //            double.TryParse(txtDiscount.Text, out _currentDiscount);

        //            double testAmount = Convert.ToDouble(dgTests.CurrentRow.Cells[4].Value);

        //            double _disCount = (testAmount * disInPercent) / 100;

        //            double _totalDiscount = _currentDiscount + _disCount;

        //            txtDiscount.Text = _totalDiscount.ToString();
        //        }


        //    }
        //}

        private void dgTests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTests.Rows.Count > 0)
            {

                if (e.ColumnIndex == 5)  //example-'Column index=4'
                {

                    double disInPercent = 0;

                    double.TryParse(dgTests.CurrentRow.Cells[5].Value.ToString(), out disInPercent);

                    if (disInPercent == 0) return;

                    SelectedTestItemsForPatient _selectedItem = (SelectedTestItemsForPatient)dgTests.CurrentRow.Tag;
                    _SelectedTests.Where(w => w.Id == _selectedItem.Id).ToList().ForEach(s => s.discountInPercent = disInPercent.ToString());

                    if (disInPercent > 0)
                    {
                        double _currentDiscount = 0;

                        double.TryParse(txtDiscount.Text, out _currentDiscount);

                        double testAmount = 0;
                        if (IsNewEntry)
                        {
                            testAmount = Convert.ToDouble(dgTests.CurrentRow.Cells[4].Value);
                        }
                        else
                        {
                            testAmount = _SelectedTests.Where(x => x.Id == _selectedItem.Id && x.AdditionType.ToLower() == "new").Sum(y => y.Cost);
                        }


                        double _disCount = (testAmount * disInPercent) / 100;

                        double _totalDiscount = _currentDiscount + _disCount;

                        txtDiscount.Text = _totalDiscount.ToString();
                    }


                }

                if (e.ColumnIndex == 6)  //example-'Column index=4'
                {

                    double disCount = 0;
                    double.TryParse(dgTests.CurrentRow.Cells[6].Value.ToString(), out disCount);

                    if (disCount == 0) return;

                    SelectedTestItemsForPatient _selectedItem = (SelectedTestItemsForPatient)dgTests.CurrentRow.Tag;
                    _SelectedTests.Where(w => w.Id == _selectedItem.Id).ToList().ForEach(s => s.discount = disCount.ToString());

                    if (disCount > 0)
                    {
                        double _currentDiscount = 0;

                        double.TryParse(txtDiscount.Text, out _currentDiscount);


                        double testAmount = 0;
                        if (IsNewEntry)
                        {
                            testAmount = Convert.ToDouble(dgTests.CurrentRow.Cells[4].Value);
                        }
                        else
                        {
                            testAmount = _SelectedTests.Where(x => x.Id == _selectedItem.Id && x.AdditionType.ToLower() == "new").Sum(y => y.Cost);
                        }

                        double _totalDiscount = _currentDiscount + disCount;

                        txtDiscount.Text = _totalDiscount.ToString();
                    }


                }

                if (e.ColumnIndex == 2)  //example-'Column index=4'
                {

                    string _deliveryDate = dgTests.CurrentRow.Cells[2].Value.ToString();


                    SelectedTestItemsForPatient _selectedItem = (SelectedTestItemsForPatient)dgTests.CurrentRow.Tag;
                    _SelectedTests.Where(w => w.Id == _selectedItem.Id).ToList().ForEach(s => s.DeliveryDate = _deliveryDate.ToString());

                }

                if (e.ColumnIndex == 3)  //example-'Column index=4'
                {

                    string _deliveryTime = dgTests.CurrentRow.Cells[3].Value.ToString();


                    SelectedTestItemsForPatient _selectedItem = (SelectedTestItemsForPatient)dgTests.CurrentRow.Tag;
                    _SelectedTests.Where(w => w.Id == _selectedItem.Id).ToList().ForEach(s => s.DeliveryTime = _deliveryTime.ToString());

                }

            }
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtYears.Focus();
            }
        }

        private void txtMonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDays.Focus();
            }
        }

        private void txtYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMonths.Focus();
            }
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbGender.Focus();
            }
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRefBy.Focus();
            }
        }

        private void txtCabin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTestCode.Focus();
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPaid.Focus();
            }
        }

        private void txtCareOf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPaid.Focus();
            }
        }

        private void txtCellPhone_Layout(object sender, LayoutEventArgs e)
        {
            txtCellPhone.Focus();
        }

        private void txtDiscountInPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDiscount.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {


            if (IsNewEntry)
            {

                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    SelectedTestItemsForPatient selectedTests = row.Tag as SelectedTestItemsForPatient;

                    _SelectedTests.Where(w => w.Id == selectedTests.Id).ToList().ForEach(s => s.discountInPercent = "");
                    _SelectedTests.Where(w => w.Id == selectedTests.Id).ToList().ForEach(s => s.discount = "");


                    if (selectedTests.AdditionType.ToLower() == "new")
                    {
                        row.Cells[5].Value = "";
                        row.Cells[6].Value = "";
                    }


                }

                txtDiscountInPercent.Text = "";
                txtDiscount.Text = "";


            }
            else
            {
                foreach (DataGridViewRow row in dgTests.Rows)
                {
                    SelectedTestItemsForPatient selectedTests = row.Tag as SelectedTestItemsForPatient;

                    _SelectedTests.Where(w => w.Id == selectedTests.Id && w.AdditionType.ToLower() == "new").ToList().ForEach(s => s.discountInPercent = "");
                    _SelectedTests.Where(w => w.Id == selectedTests.Id && w.AdditionType.ToLower() == "new").ToList().ForEach(s => s.discount = "");

                    if (selectedTests.AdditionType.ToLower() == "new")
                    {
                        row.Cells[5].Value = "";
                        row.Cells[6].Value = "";
                    }


                }

                txtDiscountInPercent.Text = "";
                txtDiscount.Text = "";

            }

        }

        private void txtRequestedby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDiscRequestedBy.Visible = true;
                ctlDiscRequestedBy.LoadData();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void txtRegNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTestCode_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtTestCode.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtTestCode.Text;
                    HideAllDefaultHidden();
                    ctlTestSearch.Visible = true;
                    ctlTestSearch.txtSearch.Text = _txt;
                    ctlTestSearch.txtSearch.SelectionStart = ctlTestSearch.txtSearch.Text.Length;

                    ctlTestSearch.LoadData();
                }
            }
        }

        private void txtRefBy_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtRefBy.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtRefBy.Text;
                    HideAllDefaultHidden();
                    ctlDoctorSearch.Visible = true;
                    ctlDoctorSearch.txtSearch.Text = _txt;
                    ctlDoctorSearch.txtSearch.SelectionStart = ctlDoctorSearch.txtSearch.Text.Length;

                    ctlDoctorSearch.LoadData();
                }
            }
        }

        private void txtPrevBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalledFromOtherPlace = true;
                long _billNo = 0;
                long.TryParse(txtPrevBill.Text, out _billNo);

                Patient _patient = new PatientService().GetPatientByBillNo(_billNo);
                if (_patient == null) _patient = new PatientService().GetPatientByIdNo(_billNo);

                if (_patient == null) return;

                LoadPrevoiusPatientInfo(_patient.PatientId);
            }
        }

        private void txtAdmissionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtAdmissionNo.Text, out _billNo);
                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_billNo);

                if (_pInfo == null)
                {
                    MessageBox.Show("Patient not found.");
                    txtAdmissionNo.Text = "";
                    return;
                }

                txtAdmissionNo.Tag = _pInfo;

                //Doctor _refdDoc = new DoctorService().GetDoctorById(_pInfo.AssignDoctorId); // Mount Adora Hospital

                //  unlocked = false;
                //  txtRefBy.Text = _refdDoc.Name;
                //  txtRefBy.Tag = _refdDoc.DoctorId;
                //  unlocked = true;

                //HpPatientAccomodationInfo _accomInfo = new HospitalService().GetHpPatientCurrentAccomodation(_pInfo.AdmissionId);

                //if (_accomInfo != null)
                //{
                //    CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                //    if (_Cabin != null)
                //    {
                //        txtCabin.Text = _Cabin.CabinNo;
                //    }
                //}

                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_pInfo.RegNo);

                CalledFromOtherPlace = true;
                if (_record != null)
                {
                    // txtRegNo.Text = _record.RegNo.ToString();
                    txtCellPhone.Text = _record.CPMobile;
                    txtPatientName.Text = _record.FullName;
                    // cmbGender.Text = _record.Sex;
                    // txtCabin.Text=_record.

                }

                // txtYears.Text = _pInfo.AgeYear.ToString();
                // txtMonths.Text = _pInfo.AgeMonth.ToString();
                // txtDays.Text = _pInfo.AgeDay.ToString();

                txtRefBy.Focus();
                CalledFromOtherPlace = false;

                IsKeyPressed = true;

            }
        }

        private void ctlTestSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTestCode.Focus();
            }
        }

        private void ctlDoctorSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtRefBy.Focus();
            }
        }

        private void ctrlRegRecordSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtRegNo.Focus();
            }
        }

        private void txtAdmissionNo_Leave(object sender, EventArgs e)
        {
            if (!IsKeyPressed)
            {
                long _billNo = 0;
                long.TryParse(txtAdmissionNo.Text, out _billNo);
                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_billNo);

                if (_pInfo == null)
                {
                    MessageBox.Show("Patient not found.");
                    txtAdmissionNo.Text = "";
                    return;
                }

                txtAdmissionNo.Tag = _pInfo;

                //Doctor _refdDoc = new DoctorService().GetDoctorById(_pInfo.AssignDoctorId); // Mount Adora Hospital

                //unlocked = false;
                //txtRefBy.Text = _refdDoc.Name;
                //txtRefBy.Tag = _refdDoc.DoctorId;
                unlocked = true;

                HpPatientAccomodationInfo _accomInfo = new HospitalService().GetHpPatientCurrentAccomodation(_pInfo.AdmissionId);

                if (_accomInfo != null)
                {
                    CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                    if (_Cabin != null)
                    {
                        txtCabin.Text = _Cabin.CabinNo;
                    }
                }

                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_pInfo.RegNo);

                CalledFromOtherPlace = true;
                if (_record != null)
                {
                    // txtRegNo.Text = _record.RegNo.ToString();
                    txtCellPhone.Text = _record.MobileNo;
                    txtPatientName.Text = _record.FullName;
                    //cmbGender.Text = _record.Sex;

                }

                //txtYears.Text = _pInfo.AgeYear.ToString();
                //txtMonths.Text = _pInfo.AgeMonth.ToString();
                //txtDays.Text = _pInfo.AgeDay.ToString();

                txtRefBy.Focus();
                CalledFromOtherPlace = false;

                IsKeyPressed = true;

            }
        }

        private void txtDiscountCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SetCardPrevilege();
            }
        }

        private void SetCardPrevilege()
        {


            if (!String.IsNullOrEmpty(txtDiscountCardNo.Text))
            {



                VMDiscountCard _cardM = new CommonService().GetDiscountCard(txtDiscountCardNo.Text, Utils.GetServerDateAndTime());

                if (_cardM != null)
                {
                    txtDiscountCardNo.Tag = _cardM;

                    Doctor _d = new DoctorService().GetDoctorById(_cardM.DoctorId);
                    DiscountCardType _cType = new CommonService().GetDiscountCardTypeById(_cardM.CardTypeId);

                    if (_d != null)
                    {
                        lblCardBy.Text = _d.Name;
                        lblCardBy.Tag = _cType;
                        txtDiscountInPercent.Text = _cType.DiscountInPercent.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Doctor not found. Plz. contact with IT Dept."); return;
                    }

                }
                else
                {
                    txtDiscountCardNo.Text = "";
                    txtDiscountCardNo.Tag = null;
                    lblCardBy.Text = "";
                    lblCardBy.Tag = null;
                }

            }
            else
            {
                //MessageBox.Show("Invalid card no.");
            }
        }

        private void txtDiscountCardNo_MouseLeave(object sender, EventArgs e)
        {
            // SetCardPrevilege();
        }

        private void ctlPatientSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCellPhone.Focus();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            double _gtotal = 0;
            long.TryParse(txtPrevBill.Text, out _billNo);

            Patient _Patient = new PatientService().GetPatientByBillNo(_billNo);
            List<PatientLedger> _ledgerVerify = new PatientLedgerService().GetLedgerByPatientId(_Patient.PatientId);
            if (_ledgerVerify.Count > 0)
            {
                PreviewCashMemo(_Patient.PatientId);

            }
            else
            {
                MessageBox.Show("Bill not found", "HERP");
                //  RollBackEntry(_Patient.PatientId);
                PrepareForNextOne();
            }
        }

        private async void PreviewCashMemo(long _PId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;
            ds = new DataSet();
            ds = await new ReportService().GetCashMemo(_PId);



            RptCashMemo _cashmemo = new RptCashMemo();

            _cashmemo.SetDataSource(ds);

            //_cashmemo.SetParameterValue("RegBarcodeLocation", _file);
            if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            {
                _cashmemo.SetParameterValue("CabinNo", "Cabin :" + txtCabin.Text);

            }
            else
            {
                _cashmemo.SetParameterValue("CabinNo", "");

            }

            ReportViewer rv = new ReportViewer();

            List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(_PId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetCashMemotransaction(_pLedger);

            string _remarks = Helper.GetDiscountRemarks(_pLedger);

            if (String.IsNullOrEmpty(_remarks)) _remarks = "";

            List<TestGroup> _tGroups = new PatientService().GetTestGroupsByPatientId(_PId);

            string _movementString = new PatientService().GetMovementString(_tGroups);

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

            _cashmemo.SetParameterValue("MovementString", _movementString);
            _cashmemo.SetParameterValue("Remarks", _remarks);

            if (Configuration.ORG_CODE == "2")
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 3q Zjvq");
            }
            else
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 2q Zjvq");
            }

            btnSave.Text = "Save";

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            // rv.crviewer.PrintReport();
            rv.Show();

            // Thread.Sleep(500);

            // rv.Close();

        }

        private void txtMedia_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtMedia.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtMedia.Text;
                    HideAllDefaultHidden();
                    ctlMediaSearchControl.Visible = true;
                    ctlMediaSearchControl.txtSearch.Text = _txt;
                    ctlMediaSearchControl.txtSearch.SelectionStart = ctlMediaSearchControl.txtSearch.Text.Length;

                    ctlMediaSearchControl.LoadData();
                }
            }

        }

        private void txtMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTestCode.Focus();
            }
        }

        private void ctlMediaSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedia.Focus();
            }
        }
    }
}
