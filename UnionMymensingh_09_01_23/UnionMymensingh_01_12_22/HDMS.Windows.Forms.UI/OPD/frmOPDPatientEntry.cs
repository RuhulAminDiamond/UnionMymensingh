using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Common.Utils;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Service.OPD;
using HDMS.Service.Diagonstics;
using HDMS.Model.Common;
using HDMS.Model.OPD;
using HDMS.Model.Enums;
using HDMS.Service.Common;
using System.Globalization;
using HDMS.Windows.Forms.UI.Reports.OPD;
using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Classes;
using CrystalDecisions.Windows.Forms;
using HDMS.Service.Doctors;
using HDMS.Model.OPD.VM;
using Itenso.TimePeriod;
using HDMS.Model.Diagnostic.VM;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class frmOPDPatientEntry : Form
    {
        bool unlocked = true;
        bool IsNewEntry = true;
        DataSet ds;

        bool CalledFromOtherPlace = false;

        public frmOPDPatientEntry()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgService.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgService.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }


        private IList<VMSelectedService> _SelectedServices;
        private async void frmOPDPatientEntry_Load(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(3, 0);
            pnlPatient.Size = new Size(1412, 694);


            HideAllDefaultHidden();

         
            _SelectedServices = new List<VMSelectedService>();
            ctlDoctorSearch.Location = new Point(txtRefBy.Location.X, txtRefBy.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            ctlConsultantSearch.Location = new Point(txtService.Location.X, txtService.Location.Y);
            ctlConsultantSearch.ItemSelected += ctlConsultantSearch_ItemSelected;


            ctlOpdService.Location = new Point(txtService.Location.X, txtService.Location.Y);
            ctlOpdService.ItemSelected += ctlOpdService_ItemSelected;

            

            lblEntryDateValue.Text = DateTime.Now.ToString(Configuration.DATE_TIME_FORMAT);
        
            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadServiceType(0);

            LoadOPDVisitTypes();

            unlocked = false;

            Doctor _d = new DoctorService().GetDoctorById(1);

            txtRefBy.Text = _d.Name;
            txtRefBy.Tag = _d;

            unlocked = true;

            if (Configuration.ORG_CODE == "1")
            {
                cmdCollection.Visible = false;
                txtPaid.Enabled = false;

            }
            else
            {
                cmdCollection.Visible = true;
                txtPaid.Enabled = true;

            }



            List<VMDiagPatientBasicInfo> _Plist = await LoadPatients();
            if (_Plist == null)
                return;
            dgPatient.Tag = _Plist;
            lblTotalPatient.Text = _Plist.Count.ToString();
            FillListGrid(_Plist);



        }

        private async Task<List<VMDiagPatientBasicInfo>> LoadPatients()
        {
            List<VMDiagPatientBasicInfo> _Plist = await new OPDPatientService().GetOPDPatienInfo(dtpdiagfrm.Value, dtpdiagto.Value);

            if (_Plist == null)
                return _Plist;
            dgPatient.Tag = _Plist;
            lblTotalPatient.Text = _Plist.Count.ToString();
            FillListGrid(_Plist);

            return _Plist;
        }

        private void FillListGrid(List<VMDiagPatientBasicInfo> plist)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMDiagPatientBasicInfo item in plist)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.BillNo, item.EntryDate, item.EntryTime, item.PatientName, item.UserName, item.Sex, item.Ageyear, item.MobileNo);
                dgPatient.Rows.Add(row);
            }
        }

        private void LoadOPDVisitTypes()
        {
            List<OPDPatientVisitType> _vtList = new OPDPatientService().GetVisitTypes();
            _vtList.Insert(0, new OPDPatientVisitType() { VisitTypeId = 0, VisitType = "Select Type" });
            cmbVisitType.DataSource = _vtList;
            cmbVisitType.DisplayMember = "VisitType";
            cmbVisitType.ValueMember = "VisitTypeId";
        }

        private void ctlConsultantSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtService.Text = item.Name;
            txtService.Tag = item;
            OPDPatientVisitType vType = (OPDPatientVisitType)cmbVisitType.SelectedItem;
            if (vType.VisitTypeCode == "NP")
            {
                txtRate.Text = item.ConsultancyFee1.ToString();

            }else if (vType.VisitTypeCode == "OP")
            {
                txtRate.Text = item.ConsultancyFee2.ToString();
            }
            else
            {
                txtRate.Text = item.ConsultancyFeeReportOpinion.ToString();
            }

            txtQty.Focus();
            unlocked = true;
            sender.Visible = false;
        }

        private void LoadServiceType(int _serviceType)
        {
            List<OPDServiceGroup> _sgroup = new HospitalService().getOpdServiceGroups();
            _sgroup.Insert(0, new OPDServiceGroup() { GroupId = 0, Name = "Select Service" });
            cmbServiceType.DataSource = _sgroup;
            cmbServiceType.DisplayMember = "Name";
            cmbServiceType.ValueMember = "GroupId";

            if(_serviceType > 0) { 
                  cmbServiceType.SelectedItem = _sgroup.Find(q => q.GroupId == _serviceType);
            }
        }

        private void ctlOpdService_ItemSelected(SearchResultListControl<VMOPDServiceHead> sender, VMOPDServiceHead item)
        {
            unlocked = false;
            txtService.Text = item.ServiceHeadName;
            txtService.Tag = item;
            txtRate.Text = item.Rate.ToString();
            txtQty.Focus();
            unlocked = true;
            sender.Visible = false;
           
        }

        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtRefBy.Text = item.Name;
            txtRefBy.Tag = item;
            txtRate.Text = item.ConsultancyFee1.ToString();
            unlocked = true;
            sender.Visible = false;
            
        }

        private string GetNewBillNo()
        {
            throw new NotImplementedException();
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

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
            ctlOpdService.Visible = false;
            ctlConsultantSearch.Visible = false;
        }

        private void label14_Click(object sender, EventArgs e)
        {

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

        private void txtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            OPDServiceGroup _sgroup = (OPDServiceGroup)cmbServiceType.SelectedItem;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtQty.Text) && txtService.Tag != null)
                {
                    int _Qty = 0;
                    double _Rate = 0;
                    int.TryParse(txtQty.Text, out _Qty);
                    double.TryParse(txtRate.Text, out _Rate);

                    if (_sgroup.GroupId == 3)
                    {
                        Doctor _doc = (Doctor)txtService.Tag;

                        new HospitalService().PopulateSelectedOPDConsultancyServices(_SelectedServices, _doc, _Rate, _Qty, _sgroup, MainForm.LoggedinUser.Name);
                        FillServiceGrid();

                    }else
                    {
                        VMOPDServiceHead _Servicehead = (VMOPDServiceHead)txtService.Tag;

                        new HospitalService().PopulateSelectedOPDServices(_SelectedServices, _Servicehead, _Rate, _Qty, _sgroup,MainForm.LoggedinUser.Name);
                        FillServiceGrid();
                    }

                    OPDServiceGroup _sg = (OPDServiceGroup)cmbServiceType.SelectedItem;
                    if (_sg.GroupId == 3)
                    {
                        txtPaid.Text = txtGrandTotal.Text;
                        btnSave.Focus();
                    }
                    else
                    {
                        txtService.Focus();
                    }

                    unlocked = false;
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtService.Text = "";
                    txtService.Tag = null;

                  

                    unlocked = true;

                }
                else
                {
                    MessageBox.Show("Service not selected.");
                }

            }
        }

        private void FillServiceGrid()
        {
            dgService.SuspendLayout();
            dgService.Rows.Clear();
            foreach (VMSelectedService item in _SelectedServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgService, item.ServiceHeadName, item.Rate, item.Qty,  item.Amount, item.EnteredBy, false);
                dgService.Rows.Add(row);
            }

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            txtTotalAmount.Text = dgService.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

            txtGrandTotal.Text = dgService.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

            txtDue.Text = dgService.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

            double _due = 0, _paid = 0;
            double.TryParse(txtDue.Text, out _due);
            double.TryParse(txtPaid.Text, out _paid);

            if (txtBillNo.Tag != null)
            {
                txtDue.Text = (_due - _paid).ToString();
            }

        }

        private void txtDiscountInPercent_TextChanged(object sender, EventArgs e)
        {
            SetPercentDiscountAmount();
        }

        private void SetPercentDiscountAmount()
        {
            if (IsNewEntry)
            {
                double lessInPercent = 0, _totalLess = 0;

                double.TryParse(txtDiscountInPercent.Text, out lessInPercent);
                double total = _SelectedServices.Sum(x => x.Amount);
                _totalLess = (total * lessInPercent) / 100;

                        txtDiscount.Text = _totalLess.ToString();
                        txtGrandTotal.Text = (total - _totalLess).ToString();
                        txtDue.Text = (total - _totalLess).ToString();
            
            }
        }

        private void cmbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OPDServiceGroup _sgroup = (OPDServiceGroup)cmbServiceType.SelectedItem;
            if (_sgroup.GroupId == 3)
            {
                lblServiceTitle.Location= new Point(26, 171);
                lblServiceTitle.Text = "Consultant";
            }
            else
            {
                lblServiceTitle.Location= new Point(48, 171);
                lblServiceTitle.Text = "Service";
            }
        }

        private void txtService_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            OPDServiceGroup _sgroup = (OPDServiceGroup)cmbServiceType.SelectedItem;
            if (int.TryParse(txtService.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtService.Text;
                    HideAllDefaultHidden();
                    if (_sgroup.GroupId == 3)
                    {
                        OPDPatientVisitType _vType = (OPDPatientVisitType)cmbVisitType.SelectedItem;

                        if (_vType.VisitTypeId == 0)
                        {
                            MessageBox.Show("Visit Type Required"); cmbVisitType.Focus();
                            return;
                        }

                        ctlConsultantSearch.Visible = true;
                        ctlConsultantSearch.txtSearch.Text = _txt;
                        ctlConsultantSearch.txtSearch.SelectionStart = ctlConsultantSearch.txtSearch.Text.Length;

                        ctlConsultantSearch.LoadData();

                    }else
                    {
                        ctlOpdService.Visible = true;
                        ctlOpdService.txtSearch.Text = _txt;
                        ctlOpdService.txtSearch.SelectionStart = ctlOpdService.txtSearch.Text.Length;

                        ctlOpdService.LoadDataByType(_sgroup.GroupId.ToString());
                    }
                }
            }
        }

        private void txtService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OPDServiceGroup _sgroup = (OPDServiceGroup)cmbServiceType.SelectedItem;

                if (unlocked)
                {
                    string _txt = txtService.Text;
                    HideAllDefaultHidden();
                    if (_sgroup.GroupId == 3)
                    {
                        

                        ctlConsultantSearch.Visible = true;
                        ctlConsultantSearch.txtSearch.Text = _txt;
                        ctlConsultantSearch.txtSearch.SelectionStart = ctlConsultantSearch.txtSearch.Text.Length;

                        ctlConsultantSearch.LoadData();
                    }
                    else
                    {
                        ctlOpdService.Visible = true;
                        ctlOpdService.txtSearch.Text = _txt;
                        ctlOpdService.txtSearch.SelectionStart = ctlOpdService.txtSearch.Text.Length;

                        ctlOpdService.LoadDataByType(_sgroup.GroupId.ToString());
                    }
                }
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void dgService_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            VMSelectedService _SelectedItem = (VMSelectedService)e.Row.Tag;
          
            _SelectedServices.Remove(e.Row.Tag as VMSelectedService);
            CalculateTotalAmount();

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (IsNewEntry)
            {
                double total = _SelectedServices.Sum(y => y.Amount);

                txtPaid.Text = "";
             
                txtDue.Text = (total  - GetSubTractedAmount()).ToString();
                txtGrandTotal.Text = txtDue.Text;

                

            }
            
        }

        private int GetOPDServiceGroup()
        {
            OPDServiceGroup sgroup = (OPDServiceGroup)cmbServiceType.SelectedItem;

            return sgroup.GroupId;
        }

        private double GetSubTractedAmount()
        {
            double _discout = 0, _paidtk = 0;



            double.TryParse(txtDiscount.Text, out _discout);



            double.TryParse(txtPaid.Text, out _paidtk);

            double _totalDeduction = _discout + _paidtk;

            return _totalDeduction;

        }



        private void ctlConsultantSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtService.Focus();
            }
        }

        private void ctlDoctorSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtRefBy.Focus();
            }
        }

        private void ctlOpdService_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtService.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddNewPatient();
        }

        private void AddNewPatient()
        {
            long _regNo = 0;
            long _billNo = 0;
            long _RxId = 0;
            long _admissionNo = 0;
            double _discountInPercent = 0;


            OPDServiceGroup _selectedServiceType = (OPDServiceGroup)cmbServiceType.SelectedItem;
            OPDPatientVisitType _visitType = (OPDPatientVisitType)cmbVisitType.SelectedItem;

            if (_selectedServiceType.GroupId == 0)
            {
                MessageBox.Show("Plz. Select Service Type and Try again.");return;
            }


            long.TryParse(txtBillNo.Text, out _billNo);
     
         
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

                        double.TryParse(txtDiscountInPercent.Text, out _discountInPercent);

                     

                        long.TryParse(txtBillNo.Text, out _billNo);


                        RegRecord _regTracker = GetRegNoLong();

                        txtRegNo.Text = _regTracker.RegNo.ToString();
                       

                        //  txtDailyId.Text = new PatientService().GetLastIdOfToday().ToString();
                        //  txtDailyId.Tag = new PatientService().GetReportIdForThisPatient();


                        OPDPatientRecord patient = new OPDPatientRecord();
                        patient.BillNo = _billNo;

                      
                        patient.RegNo = _regTracker.RegNo; 

                       
                       
                       
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
                       
                        patient.DoctorId = ((Doctor)txtRefBy.Tag).DoctorId;
                        patient.DiscountCareOf = txtCareOf.Text;
                        patient.DiscountInPercent = _discountInPercent;
                        patient.GroupId = _selectedServiceType.GroupId;
                        patient.VisitTypeId = _visitType.VisitTypeId;
                        patient.Status = OPDPatientStatusEnum.UnderService.ToString();

                        patient.UserId = MainForm.LoggedinUser.UserId;

                        long _pId = OPDPatientService.SavePatient(patient);

                        if (_pId > 0)
                        {


                            string testsConducted = string.Empty;

                            List<OPDServiceCost> serviceCosts = new List<OPDServiceCost>();

                            DateTime _deliveyDate = DateTime.Now;

                            List<HpConsultantLedger> _hpcLdgerList = new List<HpConsultantLedger>();

                            foreach (DataGridViewRow row in dgService.Rows)
                            {
                                VMSelectedService selectedService = row.Tag as VMSelectedService;
                                OPDServiceCost sCost = new OPDServiceCost();
                                sCost.PatientId = _pId;
                                sCost.ServiceOrConsultantId = selectedService.ServiceHeadId;
                                sCost.Qty = selectedService.Qty;
                                sCost.Rate = selectedService.Rate;
                                sCost.TAmount = selectedService.Amount;
                                sCost.GroupId = selectedService.ServiceGroupId;
                                sCost.Status = "";

                                 serviceCosts.Add(sCost);

                                if (String.IsNullOrEmpty(testsConducted))
                                {
                                    testsConducted = testsConducted + selectedService.ServiceHeadName;
                                }
                                else
                                {
                                    testsConducted = testsConducted + "," + selectedService.ServiceHeadName;
                                }


                                if (selectedService.ServiceGroupId == 3)
                                {
                                    double _currentBalance = new HpFinancialService().GetConsultantCurrentBalance(selectedService.ServiceHeadId);

                                    double _balance = _currentBalance + selectedService.Amount;

                                    HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                                    _hpcLedger.DoctorId = selectedService.ServiceHeadId;
                                    _hpcLedger.TranDate = Utils.GetServerDateAndTime();
                                    _hpcLedger.TransactionTime= Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                    _hpcLedger.Particulars = "OPD Service Patient Id: " + _pId.ToString();
                                    _hpcLedger.Debit = 0;
                                    _hpcLedger.Credit = selectedService.Amount;
                                    _hpcLedger.Balance = _balance; // Negative balance means patient is payable this amount
                                    _hpcLedger.TransactionType = TransactionTypeEnum.ConsultantFee.ToString();
                                    _hpcLedger.OperateBy = MainForm.LoggedinUser.Name;

                                    _hpcLdgerList.Add(_hpcLedger);

                                }


                            }

                            //Save On Individual Tests Information
                            if (serviceCosts.Count > 0)
                            {
                                OPDPatientService oService = new OPDPatientService();
                                oService.SaveTestsCost(serviceCosts);

                            }


                            if (_hpcLdgerList.Count > 0)
                            {
                                new HpFinancialService().SaveHpConsultantTransaction(_hpcLdgerList);
                            }

                            // OPD Patient Ledger Rough/Advance

                            double balance = 0;
                            double _totalBill = 0;
                            double _gTotal = 0;
                            double discount = 0;

                            double.TryParse(txtTotalAmount.Text, out _totalBill);
                            double.TryParse(txtGrandTotal.Text, out _gTotal);
                            double.TryParse(txtDiscount.Text, out discount);

                            balance = 0 - _totalBill;

                            List<OPDPatientLedgerRough> transactionList = new List<OPDPatientLedgerRough>();

                            OPDPatientLedgerRough pLedger = new OPDPatientLedgerRough();
                            pLedger.PatientId = _pId;
                            pLedger.TranDate = Utils.GetServerDateAndTime();
                            pLedger.Particulars = "Total Bill";
                            pLedger.Debit = _totalBill;
                            pLedger.Credit = 0;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.OPDServiceCost.ToString();
                            pLedger.OperateBy = MainForm.LoggedinUser.Name;
                            transactionList.Add(pLedger);

                            if (discount > 0)
                            {

                                balance = balance + discount;
                                pLedger = new OPDPatientLedgerRough();
                                pLedger.PatientId = _pId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.Particulars = "Discount";
                                pLedger.Debit = 0;
                                pLedger.Credit = discount;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.DiscountOnRegularCollection.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                transactionList.Add(pLedger);
                            }



                            double paidTk = 0;
                            double.TryParse(txtPaid.Text, out paidTk);

                            if (paidTk > 0)
                            {


                                balance = balance + paidTk;
                                pLedger = new OPDPatientLedgerRough();
                                pLedger.PatientId = _pId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.Particulars = "Payment";
                                pLedger.Debit = 0;
                                pLedger.Credit = paidTk;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.OnEntryPayment.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                transactionList.Add(pLedger);

                            }

                            if (transactionList.Count > 0)
                            {
                                OPDFinancialService fpService = new OPDFinancialService();
                                fpService.SaveOPDRoughLedger(transactionList);
                            }



                            // End of OPD Patient Ledger Rough/Advance

                            MessageBox.Show("Patient entry successful.", "HERP");
                            double grandTotal = Convert.ToDouble(txtGrandTotal.Text);
                            ShowCashMemo(_pId, grandTotal);
                            //ShowCashMemo2(_pId, grandTotal);
                            //PrepareForNextOne();

                            //LoadCountInformation();

                            //IsKeyPressed = false;
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

        private void ShowCashMemo(long _PId, double gTotal)
        {

            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            string _serviceType = string.Empty;
            string _serviceTitle = string.Empty;

            OPDServiceGroup _sg = (OPDServiceGroup)cmbServiceType.SelectedItem;
            if (_sg.GroupId == 3)
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
            ds = new ReportService().GetOPDCashMemo(_PId, _serviceType);

            RptOPDCashMemo _cashmemo = new RptOPDCashMemo();

            _cashmemo.SetDataSource(ds);
            _cashmemo.SetParameterValue("CabinNo", "");

            

            ReportViewer rv = new ReportViewer();

            List<OPDPatientLedgerRough> _pLedger = new PatientService().GetOPDPatientLedgerRoughById(_PId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetOPDRoughCashMemotransaction(_pLedger);



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
            _cashmemo.SetParameterValue("Remarks", txtCareOf.Text);

            if (Configuration.ORG_CODE == "2")
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 3q Zjvq");
            }
            else
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 2q Zjvq");
            }


            _cashmemo.SetParameterValue("ServiceTitle", _serviceTitle);

            btnSave.Text = "Save";

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            rv.Show();

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
                _rgRecord.RefdId = 0;
                _rgRecord.RegDate = Utils.GetServerDateAndTime();
                RegRecord _record = new RegRecordService().SaveRegRecord(_rgRecord);

                _record = new RegRecordService().GetRegRecordById(_record.Id);

                return _record;

            }

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

        private string CheckRequiredInformation()
        {
          
            string msg = string.Empty;

            if (String.IsNullOrEmpty(txtPatientName.Text))
            {
                msg = "Patient Name";
            }

            if (String.IsNullOrEmpty(txtYears.Text) && String.IsNullOrEmpty(txtMonths.Text) && String.IsNullOrEmpty(txtDays.Text))
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

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            if (IsNewEntry)
            {
                double total = dgService.Rows.Cast<DataGridViewRow>()
                              .Sum(t => Convert.ToDouble(t.Cells[3].Value));

                txtDue.Text = (total - GetSubTractedAmount()).ToString();
            }
           
        }

        private void txtPatientName_MouseLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPatientName.Text)) return;

            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
            if (txtPatientName.Text.Substring(0, 2).ToLower() == "mr")
            {
                cmbGender.Text = "Male";
            }

            if (txtPatientName.Text.Substring(0, 2).ToLower() == "ms")
            {
                cmbGender.Text = "Female";
            }

            txtYears.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            PrepareForNextOne();
        }

        private void PrepareForNextOne()
        {
            ClearFields();
          
            _SelectedServices = new List<VMSelectedService>();
      
        }



        private void ClearFields()
        {
            unlocked = false;

            txtRegNo.Text = "";
            txtBillNo.Text = "";
            txtPrevBill.Text = "";
           
            txtPatientName.Text = "";
            txtRefBy.Text = "";
            txtRefBy.Tag = null;
            txtBillNo.Tag = null;
          
            txtYears.Text = "";
            txtMonths.Text = "";
            txtDays.Text = "";
          
            txtDiscountInPercent.Text = "";
            txtDiscount.Text = "";
            txtTotalAmount.Text = "";
            txtGrandTotal.Text = "";
            txtPaid.Text = "";
            txtCellPhone.Text = "";
            txtCareOf.Text = "";
            txtDue.Text = "";
            IsNewEntry = true;
          
      
            dgService.Rows.Clear();
            txtCellPhone.Focus();
            unlocked = true;
          
            //lblPreviousPaid.Visible = true;
        }

        private void txtCellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPatientName.Focus();
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

        private void txtRefBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbServiceType.Focus();
            }
        }

        private void cmbServiceType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbVisitType.Focus();
            }
        }

        private void txtYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMonths.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            long _billNo;
            long.TryParse(txtBillNo.Text, out _billNo);

            if (_billNo == 0)
            {
                long.TryParse(txtPrevBill.Text, out _billNo);
            }

            OPDPatientRecord _Patient = new OPDPatientService().GetPatientByBillNo(_billNo);
            if (_Patient != null)
            {
                ShowCashMemo(_Patient.PatientId, 0);
            }
        }

        private void cmdCollection_Click(object sender, EventArgs e)
        {
            frmOPDCashCollection _frm = new frmOPDCashCollection();
            _frm.Show();
        }

        private void cmbVisitType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtService.Focus();
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            OPDPatientRecord _patient = null;
            CalledFromOtherPlace = true;

            if (String.IsNullOrEmpty(txtPrevBill.Text))
            {
                _patient = new OPDPatientService().GetLastReceivedPatientByUser(MainForm.LoggedinUser.UserId);
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtPrevBill.Text, out _billNo);
                OPDPatientRecord _Patient = new OPDPatientService().GetPatientByBillNo(_billNo);
                _patient = new OPDPatientService().GetOPDPatientById(_Patient.PatientId - 1);

            }

            if (_patient != null)
            {
                txtPrevBill.Text = _patient.BillNo.ToString();
                LoadServiceType(_patient.GroupId);
                LoadPrevoiusPatientInfo(_patient);
            }
            else
            {
                MessageBox.Show("Patient not found.");
                _SelectedServices = new List<VMSelectedService>();
                ClearFields();

            }
        }

        private void btnNextId_Click(object sender, EventArgs e)
        {
            OPDPatientRecord _patient = null;
            CalledFromOtherPlace = true;

            if (String.IsNullOrEmpty(txtPrevBill.Text))
            {
                _patient = new OPDPatientService().GetFirstReceivedPatientByUser(MainForm.LoggedinUser.UserId);
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtPrevBill.Text, out _billNo);
                OPDPatientRecord _Patient = new OPDPatientService().GetPatientByBillNo(_billNo);
                _patient = new OPDPatientService().GetOPDPatientById(_Patient.PatientId + 1);


            }

            if (_patient != null)
            {
                txtPrevBill.Text = _patient.BillNo.ToString();
                LoadServiceType(_patient.GroupId);
                LoadPrevoiusPatientInfo(_patient);
            }
            else
            {
                MessageBox.Show("Patient not found.");
                _SelectedServices = new List<VMSelectedService>();
                ClearFields();
            }

        }

        private void LoadPrevoiusPatientInfo(OPDPatientRecord _Patient)
        {
            OPDPatientRecord _PatientInfo = new OPDPatientService().GetOPDPatientById(_Patient.PatientId);

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

                //txtDiscountInPercent.Text = _PatientInfo.DiscountInPercent.ToString();


                unlocked = false;

                txtRefBy.Text = new DoctorService().GetDoctorById(_PatientInfo.DoctorId).Name;
                txtRefBy.Tag = _PatientInfo.DoctorId;

                unlocked = true;



                lblEntrtyDate.Text = _PatientInfo.EntryDate.ToShortDateString();


                if (_PatientInfo.Status.Equals("UnderService"))
                {

                    //OPDServiceGroup _sGroup = new OPDPatientService().GetOPDServiceGroup(_PatientInfo.GroupId);

                    string _serviceType = string.Empty;
                    if (_PatientInfo.GroupId == 3)
                    {
                        _serviceType = "Consultant";
                    }
                    else
                    {
                        _serviceType = "Others";
                    }

                    ds = new ReportService().GetOPDCashMemo(_Patient.PatientId, _serviceType);

                    DataTable dt = ds.Tables[0];

                    _SelectedServices = (from DataRow dr in dt.Rows
                                         select new VMSelectedService()
                                         {
                                             ServiceHeadId = Convert.ToInt32(dr["ServiceOrConsultantId"]),
                                             ServiceGroupId = Convert.ToInt32(dr["GroupId"]),
                                             ServiceHeadName = dr["ServiceName"].ToString(),
                                             Rate = Convert.ToDouble(dr["Rate"].ToString()),
                                             Qty = Convert.ToInt32(dr["Qty"].ToString()),
                                             ServiceCharge = 0,
                                             Amount = Convert.ToDouble(dr["Amount"].ToString()),
                                             EnteredBy = dr["ReceivedByName"].ToString(),
                                             ServiceDate = Convert.ToDateTime(dr["EntryDate"])
                                         }).ToList();


                    FillSeviceGridPrevPatient(_Patient.PatientId);
                    //LoadBarcode();
                    //LoadBarcodeForId(txtPatientId.Text);



                }
                else
                {
                    MessageBox.Show("This is a cancelled Id.", "HERP");

                }
            }
        }

        private bool LoadRegPatientInfo(long regNo)
        {
            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(regNo);
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
            else
            {
                return false;
            }

        }

        private void FillSeviceGridPrevPatient(long pId)
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

            // CalculateTotalAmount();
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
                    txtRegNo.Tag = _record;
                    // LoadBarcode();
                    txtRefBy.Focus();
                }
            }
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            List<VMDiagPatientBasicInfo> _Plist = await LoadPatients();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            List<VMDiagPatientBasicInfo> _regList = dgPatient.Tag as List<VMDiagPatientBasicInfo>;

            if (_regList == null)
                return;

            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Trim() == "Search by name")
            {
                FillListGrid(_regList);//await LoadPatients();
            }
            else
            {
                _regList = _regList.Where(x => x.PatientName.ToString().ToLower().Contains(txtName.Text.ToLower())).ToList();
                FillListGrid(_regList);
            }
        }

        private void txtPatientBillNo_TextChanged(object sender, EventArgs e)
        {
            List<VMDiagPatientBasicInfo> _regList = dgPatient.Tag as List<VMDiagPatientBasicInfo>;

            if (_regList == null)
                return;

            if (string.IsNullOrWhiteSpace(txtPatientBillNo.Text) || txtBillNo.Text.Trim() == "Search by Bill No")
            {
                FillListGrid(_regList);
                //await  LoadPatients();
            }
            else
            {
                _regList = _regList.Where(x => x.BillNo.ToString().ToLower().Contains(txtPatientBillNo.Text.ToLower())).ToList();
                FillListGrid(_regList);

            }
        }

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            List<VMDiagPatientBasicInfo> _regList = dgPatient.Tag as List<VMDiagPatientBasicInfo>;

            if (_regList == null)
                return;

            if (string.IsNullOrWhiteSpace(txtSearchByMobile.Text) || txtSearchByMobile.Text.Trim() == "Search by Mobile No")
            {
                FillListGrid(_regList); //await LoadPatients();
            }
            else
            {
                _regList = _regList.Where(x => x.MobileNo.ToString().ToLower().Contains(txtSearchByMobile.Text.ToLower())).ToList();

                FillListGrid(_regList);

            }
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(pnlPatient.Location.X + 1310, pnlPatient.Location.Y);

            // isInMaxView = false;

            btnMaxView.Visible = true;
        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(18, 12);



            btnMaxView.Visible = false;
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMDiagPatientBasicInfo _pInfo = ((VMDiagPatientBasicInfo)row.Tag);


                OPDPatientRecord _Patient = new OPDPatientService().GetOPDPatientById(_pInfo.BillNo);
                if (_Patient != null)
                {
                    ShowCashMemoFromDashBoard(_Patient.PatientId, 0);
                }

            }
        }

        private void ShowCashMemoFromDashBoard(long _PId, int v)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            string _serviceType = string.Empty;
            string _serviceTitle = string.Empty;

            OPDServiceCost _sg = new OPDPatientService().GetOPDServiceCost(_PId);


            // OPDServiceGroup _sg = (OPDServiceGroup)cmbServiceType.SelectedItem;
            if (_sg.GroupId == 3)
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
            ds = new ReportService().GetOPDCashMemo(_PId, _serviceType);

            RptOPDCashMemo _cashmemo = new RptOPDCashMemo();

            _cashmemo.SetDataSource(ds);
            _cashmemo.SetParameterValue("CabinNo", "");



            ReportViewer rv = new ReportViewer();

            List<OPDPatientLedgerRough> _pLedger = new PatientService().GetOPDPatientLedgerRoughById(_PId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetOPDRoughCashMemotransaction(_pLedger);
           // double paidamount = new PatientLedgerService().GetOPDPaidTk(_PId);


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
            _cashmemo.SetParameterValue("Remarks", txtCareOf.Text);


            //string word = NumberToWords.ConvertAmount((paidamount));
            //_cashmemo.SetParameterValue("InWord", word);

            if (Configuration.ORG_CODE == "2")
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 3q Zjvq");
            }
            else
            {
                _cashmemo.SetParameterValue("ReportDeliveryText", "wi‡cvU© †Wwjfvix 2q Zjvq");
            }


            _cashmemo.SetParameterValue("ServiceTitle", _serviceTitle);

            btnSave.Text = "Save";

            rv.crviewer.ReportSource = _cashmemo;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // _cashmemo.PrintToPrinter(3, true, 0, 0);
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
