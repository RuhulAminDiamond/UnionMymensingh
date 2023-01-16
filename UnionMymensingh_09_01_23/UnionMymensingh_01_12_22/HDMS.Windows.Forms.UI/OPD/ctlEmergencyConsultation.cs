using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Service.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Service.OPD;
using HDMS.Model.Hospital;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Model.Enums;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class ctlEmergencyConsultation : UserControl
    {
        bool unlocked = true;
        bool IsNewEntry = true;
        DataSet ds;

        public ctlEmergencyConsultation()
        {
            InitializeComponent();
        }

        private IList<VMSelectedService> _SelectedServices;
        private void ctlEmergencyConsultation_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            _SelectedServices = new List<VMSelectedService>();
            ctlDoctorSearch.Location = new Point(txtRefBy.Location.X, txtRefBy.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            ctlConsultantSearch.Location = new Point(txtConsultant.Location.X, txtConsultant.Location.Y);
            ctlConsultantSearch.ItemSelected += ctlConsultantSearch_ItemSelected;

        }

        private void ctlConsultantSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtConsultant.Text = item.Name;
            txtConsultant.Tag = item;
            txtRate.Text = item.ConsultancyFee1.ToString();
            txtRate.Focus();
            unlocked = true;
            sender.Visible = false;
        }

        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtRefBy.Text = item.Name;
            txtRefBy.Tag = item;
            txtConsultant.Focus();
             unlocked = true;
            sender.Visible = false;
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
            ctlConsultantSearch.Visible = false;
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

        private void txtConsultant_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtConsultant.Text;
                HideAllDefaultHidden();
                
                    ctlConsultantSearch.Visible = true;
                    ctlConsultantSearch.txtSearch.Text = _txt;
                    ctlConsultantSearch.txtSearch.SelectionStart = ctlConsultantSearch.txtSearch.Text.Length;

                    ctlConsultantSearch.LoadData();
               
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtQty.Text) && txtConsultant.Tag != null)
                {
                    int _Qty = 0;
                    double _Rate = 0;
                    int.TryParse(txtQty.Text, out _Qty);
                    double.TryParse(txtRate.Text, out _Rate);

                  
                        Doctor _doc = (Doctor)txtConsultant.Tag;

                        new HospitalService().PopulateSelectedEmergencyConsultancyServices(_SelectedServices, _doc, _Rate, _Qty,  MainForm.LoggedinUser.Name);
                        FillConsultantServiceGrid();

                    
                }
            }
        }

        private void FillConsultantServiceGrid()
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

                        OPDPatientRecord patient = new OPDPatientRecord();


                        patient.RegNo = GetRegNoLong().RegNo;
                        patient.BillNo = 0;
                       

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


                        patient.EntryDate = DateTime.Now;
                        patient.EntryTime = DateTime.Now.ToString("hh:mm tt");

                        patient.DoctorId = ((Doctor)txtRefBy.Tag).DoctorId;
                        patient.DiscountCareOf = txtCareOf.Text;
                        patient.DiscountInPercent = _discountInPercent;



                        patient.UserId = MainForm.LoggedinUser.UserId;

                        long _pId = OPDPatientService.SavePatient(patient);

                        if (_pId > 0)
                        {
                            string testsConducted = string.Empty;
                            OPDPatientRecord _opr = new OPDPatientService().GetOPDPatientById(_pId);

                            txtBillNo.Text = _opr.BillNo.ToString();

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


                           

                            MessageBox.Show("Patient entry successful.", "HERP");
                            double grandTotal = Convert.ToDouble(txtGrandTotal.Text);
                            ShowCashMemo(_pId, grandTotal);
                           
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

        private void ShowCashMemo(long _pId, double grandTotal)
        {
            throw new NotImplementedException();
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
            _rgRecord.CountryCode = txtCountryCode.Text;
            _rgRecord.MobileNo = txtCellPhone.Text;
            _rgRecord.DOB = GetDob();

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
    }
}
