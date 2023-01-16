using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;
using HDMS.Model.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Service.OPD;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.OPD;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class OPDConsultancyFeeCollectionControl : UserControl
    {
        bool unlocked = true;
        bool IsNewEntry = true;
        bool CalledFromOtherPlace = false;

        DataSet ds;

        public OPDConsultancyFeeCollectionControl()
        {
            InitializeComponent();
        }


        private IList<VMSelectedService> _SelectedServices;
        private void OPDConsultancyFeeCollectionControl_Load(object sender, EventArgs e)
        {
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

            LoadServiceTypeExceptOutdoorOPDConsultation(0);

            LoadOPDVisitTypes();

            LoadDoctors();



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

            pnlPatientSerial.Size = new Size(1288, 627);
            pnlPatientSerial.Location = new Point(15, 15);
            btnMovePanel.Text = ">>>";

        }

        private void LoadDoctors()
        {

            List<ChamberPractitioner> _chamberPractitioner = new ChamberPractitionerService().GetAllActivePractitioner();
            TV.Nodes.Clear();

            TreeNode MainNode = new TreeNode();
            MainNode.Text = "Select Doctor";
            TV.Nodes.Add(MainNode);

            foreach (var item in _chamberPractitioner)
            {
                TreeNode child = new TreeNode();
                child.Text = item.Name;
                child.Tag = item;
                MainNode.Nodes.Add(child);
            }

            TV.ExpandAll();
        }

        private void TV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtDoctor.Text = TV.SelectedNode.Text;
            txtDoctor.Tag = TV.SelectedNode.Tag;

            ChamberPractitioner _prac = (ChamberPractitioner)txtDoctor.Tag;

            if (_prac == null) return;
            LoadPatientSerialByDoctor(_prac, dtp.Value);
        }

        private void LoadPatientSerialByDoctor(ChamberPractitioner _practitioner, DateTime _date)
        {

            
            List<VMPractitionerWisePatientSerial> _pList = new ChamberPractitionerService().LoadPatientSerialByDoctor(_practitioner.CPId, _date);

            List<VMPractitionerWisePatientSerial> _sortList = _pList.OrderByDescending(x => x.SerialNo).ToList();
            VMPractitionerWisePatientSerial lastObj = _sortList.FirstOrDefault();

            List<PatientSerial> __pSerialList = new List<PatientSerial>();


            foreach (var _patient in _pList)
            {
                PatientSerial _serial = new PatientSerial();
                _serial.ChamberPractitionerId = _patient.ChamberPractitionerId;
                _serial.SerialNo = _patient.SerialNo;
                _serial.SerialDate = _patient.SerialDate;
                _serial.Titel = _patient.Titel;
                _serial.PatientName = _patient.PatientName;
                _serial.MobileNo = _patient.MobileNo;
                _serial.EmailId = _patient.EmailId;
                _serial.Address = _patient.Address;
                _serial.Occupation = _patient.Occupation;
                _serial.Age = _patient.Age;
                _serial.AgeYear = _patient.AgeYear;
                _serial.AgeMonth = _patient.AgeMonth;
                _serial.AgeDay = _patient.AgeDay;
                _serial.DOB = _patient.DOB.GetValueOrDefault();
                _serial.Sex = _patient.Sex;
                _serial.VisitTypeId = _patient.VisitTypeId;
                _serial.VisitType = _patient.VisitType;
                _serial.VisitTypeCode = _patient.VisitTypeCode;
                _serial.StartTime = _patient.StartTime;
                _serial.EndTime = _patient.EndTime;
                _serial.Remarks = _patient.Remarks;
                _serial.Id = _patient.Id;

                __pSerialList.Add(_serial);

            }

            FillPatientGrid(__pSerialList);

        }

        private void FillPatientGrid(List<PatientSerial> _pSerial)
        {
            gvPList.SuspendLayout();
            gvPList.Rows.Clear();
            foreach (var item in _pSerial)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;

                string dob = string.Empty;
                if (item.DOB != null)
                {
                    dob = item.DOB.GetValueOrDefault().ToString("dd/MM/yyyy");
                }

                row.CreateCells(gvPList, item.SerialNo, item.Titel + item.PatientName, item.VisitType, item.MobileNo, item.StartTime, item.EndTime, item.Address, item.Remarks, item.Occupation);
                gvPList.Rows.Add(row);
            }

        }

        private void gvPList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PatientSerial patientSerial = gvPList.SelectedRows[0].Tag as PatientSerial;
            if (patientSerial != null)
            {
                btnMovePanel_Click(null, null);

                txtCellPhone.Text = patientSerial.MobileNo;
                txtPatientName.Text = patientSerial.Titel + " " + patientSerial.PatientName;
                txtYears.Text = patientSerial.AgeYear;
                txtMonths.Text = patientSerial.AgeMonth;
                txtDays.Text = patientSerial.AgeDay;
                cmbGender.Text = patientSerial.Sex;
                cmbVisitType.Text = patientSerial.VisitType;

                ChamberPractitioner chamberPractitioner = new DoctorService().GetChamberPractitionerById(patientSerial.ChamberPractitionerId);
                Doctor doctor = new DoctorService().GetDoctorById(chamberPractitioner.DoctorId);
                txtService.Text = doctor.Name;
                txtService.Tag = doctor;

                if (patientSerial.VisitTypeCode.Equals("BNP"))
                {
                    txtRate.Text = doctor.ConsultancyFee1.ToString();
                }
                else if (patientSerial.VisitTypeCode.Equals("NP"))
                {
                    txtRate.Text = doctor.ConsultancyFee2.ToString();
                }
                else if (patientSerial.VisitTypeCode.Equals("OP"))
                {
                    txtRate.Text = doctor.ConsultancyFee3.ToString();
                }
                else if (patientSerial.VisitTypeCode.Equals("SG"))
                {
                    txtRate.Text = doctor.ConsultancyFee4.ToString();
                }
                else if (patientSerial.VisitTypeCode.Equals("IPD"))
                {
                    txtRate.Text = doctor.IPDConsultancyFee.ToString();
                }
                else
                {
                    txtRate.Text = doctor.ConsultancyFeeReportOpinion.ToString();
                }

                HideAllDefaultHidden();

            }
        }

        private void ctlConsultantSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtService.Text = item.Name;
            txtService.Tag = item;
            OPDPatientVisitType vType = (OPDPatientVisitType)cmbVisitType.SelectedItem;
            if (vType.VisitTypeCode.Equals("BNP"))
            {
                txtRate.Text = item.ConsultancyFee1.ToString();

            }
            else if (vType.VisitTypeCode.Equals("NP"))
            {
                txtRate.Text = item.ConsultancyFee2.ToString();
            }
            else if (vType.VisitTypeCode.Equals("OP"))
            {
                txtRate.Text = item.ConsultancyFee3.ToString();
            }
            else if (vType.VisitTypeCode.Equals("SG"))
            {
                txtRate.Text = item.ConsultancyFee4.ToString();
            }
            else if (vType.VisitTypeCode.Equals("IPD"))
            {
                txtRate.Text = item.IPDConsultancyFee.ToString();
            }
            else
            {
                txtRate.Text = item.ConsultancyFeeReportOpinion.ToString();
            }

            txtQty.Focus();
            unlocked = true;
            sender.Visible = false;
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
            cmbServiceType.Focus();
            sender.Visible = false;

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

        private void LoadOPDVisitTypes()
        {
            List<OPDPatientVisitType> _vtList = new OPDPatientService().GetVisitTypes();
            _vtList.Insert(0, new OPDPatientVisitType() { VisitTypeId = 0, VisitType = "Select Type" });
            cmbVisitType.DataSource = _vtList;
            cmbVisitType.DisplayMember = "VisitType";
            cmbVisitType.ValueMember = "VisitTypeId";
        }

        private void LoadServiceTypeExceptOutdoorOPDConsultation(int _serviceType)
        {
            List<OPDServiceGroup> _sgroup = new HospitalService().getOpdServiceGroups().Where(x => x.GroupId == 23).ToList();
            cmbServiceType.DataSource = _sgroup;
            cmbServiceType.DisplayMember = "Name";
            cmbServiceType.ValueMember = "GroupId";

            if (_serviceType > 0)
            {
                cmbServiceType.SelectedItem = _sgroup.Find(q => q.GroupId == _serviceType);
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
            ctlOpdService.Visible = false;
            ctlConsultantSearch.Visible = false;
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

        private void txtYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMonths.Focus();
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

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        private void cmbServiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVisitType.Focus();
            }
        }

        private void cmbVisitType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtService.Focus();
            }
        }

        private void txtService_TextChanged(object sender, EventArgs e)
        {
            ctlConsultantSearch.Visible = true;
            ctlConsultantSearch.txtSearch.Text = txtService.Text;
            ctlConsultantSearch.txtSearch.SelectionStart = ctlConsultantSearch.txtSearch.Text.Length;

            ctlConsultantSearch.LoadData();
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
                    if (_sgroup.GroupId == 17)
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

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            if (IsNewEntry)
            {
                double total = dgService.Rows.Cast<DataGridViewRow>()
                              .Sum(t => Convert.ToDouble(t.Cells[3].Value));

                txtDue.Text = (total - GetSubTractedAmount()).ToString();
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
                MessageBox.Show("Plz. Select Service Type and Try again."); return;
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


                        //if (txtRefBy.Tag == null)
                        //{
                        //    MessageBox.Show("Please select refd. doctor then try again.");
                        //    btnSave.Enabled = true;
                        //    btnSave.Text = "Save";
                        //    return;
                        //}

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

                            //ShowCashMemo(_pId, grandTotal);
                            //ShowCashMemo2(_pId, grandTotal);
                            //PrepareForNextOne();
                            //LoadCountInformation();
                            //IsKeyPressed = false;
                            //scop.Complete();

                            ShowOpdConsultationToken();
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

        private void ShowOpdConsultationToken()
        {
            string doctor = "";
            if (dgService.Rows[0].Cells["serviceName"].Value != null)
                doctor = dgService.Rows[0].Cells["serviceName"].Value.ToString();

            string tokenNo = "";
            if (gvPList.SelectedRows[0].Cells["SerialNo"].Value != null)
                tokenNo = gvPList.SelectedRows[0].Cells["SerialNo"].Value.ToString();

            string mobile = "";
            if (gvPList.SelectedRows[0].Cells["MobileNo"].Value != null)
                mobile = gvPList.SelectedRows[0].Cells["MobileNo"].Value.ToString();


            rptOpdConsultationToken rpt = new rptOpdConsultationToken();

            rpt.SetParameterValue("doctor", doctor);
            rpt.SetParameterValue("tokenNo", tokenNo);
            rpt.SetParameterValue("date", Utils.GetServerDateAndTime());
            rpt.SetParameterValue("name", txtPatientName.Text);
            rpt.SetParameterValue("age", txtYears.Text);
            rpt.SetParameterValue("mobile", mobile);
            rpt.SetParameterValue("visitType", cmbVisitType.Text);
            rpt.SetParameterValue("amount", txtPaid.Text);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

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
            if (_sg.GroupId == 17)
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
            //  CalledFromOtherPlace = true;

            //RegUniqueKeyTracker _regTracker = GetNewRegNo();
            // txtRegNo.Text = 0;


            long.TryParse(txtRegNo.Text, out _regNo);

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
            _rgRecord.RegDate = Utils.GetServerDateAndTime();
            _rgRecord.RefdId = 0;

            RegRecord _record = new RegRecordService().SaveRegRecord(_rgRecord);

            _record = new RegRecordService().GetRegRecordById(_record.Id);

            return _record;



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

                    Doctor _doc = (Doctor)txtService.Tag;

                    new HospitalService().PopulateSelectedOPDConsultancyServices(_SelectedServices, _doc, _Rate, _Qty, _sgroup, MainForm.LoggedinUser.Name);
                    FillServiceGrid();

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
            HideAllDefaultHidden();

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
                row.CreateCells(dgService, item.ServiceHeadName, item.Rate, item.Qty, item.Amount, item.EnteredBy, false);
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

        private void txtPatientName_Leave(object sender, EventArgs e)
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

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
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

        private void btnMovePanel_Click(object sender, EventArgs e)
        {
            if (btnMovePanel.Text == ">>>")
            {
                pnlPatientSerial.Location = new Point(1195, 15);
                btnMovePanel.Text = "<<<";
            }
            else
            {
                pnlPatientSerial.Location = new Point(15, 15);
                btnMovePanel.Text = ">>>";
            }
        }

        private void btnSerial_Click(object sender, EventArgs e)
        {
            frmPatientSerialEntry frm =new frmPatientSerialEntry();
            frm.Show();
        }
    }
}
