using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.Marketing;
using HDMS.Model.Migrations;
using HDMS.Model.OPD;
using HDMS.Model.Rx;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.OPD;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Common;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.ChamberPractitioner;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmPatientSerialEntry : Form
    {

        DataSet ds;
        bool isDateParsed = false;
        bool unlocked = true;
        public frmPatientSerialEntry()
        {
            InitializeComponent();
        }

        private void lblRefBy_Click(object sender, EventArgs e)
        {

        }

        private void frmPatientSerialEntry_Load(object sender, EventArgs e)
        {
            hideDefault();
            ctrlMarketingAgentSearchControl.Location = new Point(txtMarketingAgent.Location.X, txtMarketingAgent.Location.Y + txtMarketingAgent.Height);
            ctrlMarketingAgentSearchControl.ItemSelected += CtrlMarketingAgentSearchControl_ItemSelected;

            ctrlPatientSerialBooking1.Location = new Point(txtPatientSearchMobile.Location.X, txtPatientSearchMobile.Location.Y + txtPatientSearchMobile.Height);
            ctrlPatientSerialBooking1.ItemSelected += ctrlPatientSerialBooking1_ItemSelected;

            dtp.Value = DateTime.Now;
            DateTime _dt = dtp.Value;

            lblNameOfWeekday.Text = _dt.DayOfWeek.ToString();

            //LoadServerDateAndTime();

            LoadDoctors();

            LoadVisitTypes();

        }

        private void hideDefault()
        {
            ctrlPatientSerialBooking1.Visible = false;
            ctrlMarketingAgentSearchControl.Visible = false;
        }

        private void ctrlPatientSerialBooking1_ItemSelected(SearchResultListControl<PractitionerWisePatientSerial> sender, PractitionerWisePatientSerial item)
        {
            OPDPatientVisitType visitType = new ChamberPractitionerService().GetVisitType(item.VisitTypeId);
            txtPatientSearchMobile.Text = item.MobileNo.ToString();
            cmbTitle.Text = item.Titel;
            txtPatientName.Text = item.PatientName;
            cmbGender.Text = item.Sex;
            txtDateofBirth.Text = item.DOB?.ToString("dd/M/yyyy");
            txtYears.Text = item.AgeYear;
            txtMonths.Text = item.AgeMonth;
            txtDays.Text = item.AgeDay;
            txtCellPhone.Text = item.MobileNo;
            cmbVisitType.Text = visitType.VisitType;
            txtAddress.Text = item.Address;
            txtOccupation.Text = item.Occupation;
            txtEmailAddress.Text = item.EmailId;
            txtStartTime.Text = item.StartTime;
            cmbStartAmPm.Text = item.StartAmPm;
            txtEndTime.Text = item.EndTime;

            txtPatientSearchMobile.Tag = item;
            sender.Visible = false;
            ctrlPatientSerialBooking1.Visible = false;

        }

        private void LoadServerDateAndTime()
        {
            txtStartTime.Text = Utils.GetServerDateAndTime().ToString("h:mm:ss tt");
            txtEndTime.Text = Utils.GetServerDateAndTime().ToString("h:mm:ss tt");
        }

        private void CtrlMarketingAgentSearchControl_ItemSelected(Controls.SearchResultListControl<Model.Marketing.MarketingAgent> sender, Model.Marketing.MarketingAgent item)
        {
            txtMarketingAgent.Text = item.Name;
            txtMarketingAgent.Tag = item;
            txtRemarks.Focus();
            sender.Visible = false;
        }

        private void LoadVisitTypes()
        {
            List<OPDPatientVisitType> _vtList = new OPDPatientService().GetVisitTypes();
            _vtList.Insert(0, new OPDPatientVisitType() { VisitTypeId = 0, VisitType = "" });
            cmbVisitType.DataSource = _vtList;
            cmbVisitType.DisplayMember = "VisitType";
            cmbVisitType.ValueMember = "VisitTypeId";
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



            LoadPatientSerialByDoctor(_prac, dtp.Value);
            lblSerialFor.Text = "Serial for: " + TV.SelectedNode.Text;

            //LoadSerialAvailableSlot(_prac);

        }

        private void LoadSerialAvailableSlot(ChamberPractitioner _practitioner)
        {
            int _dayCount = 0;
            DateTime _SearchEndDate = Utils.GetServerDateAndTime().AddDays(180);
            DateTime _SearchStartDate = Utils.GetServerDateAndTime();

            for (DateTime _dt = Utils.GetServerDateAndTime(); _dt < _SearchEndDate; _dt = _SearchStartDate.AddDays(_dayCount))
            {
                if (!CheckIsOffDay((ChamberPractitioner)txtDoctor.Tag, _dt))
                {

                    List<VMPractitionerWisePatientSerial> _pList = new ChamberPractitionerService().LoadPatientSerialByDoctor(_practitioner.CPId, _dt);

                    int _totalBooking = _pList.Count;

                    if (_totalBooking < _practitioner.PatientQuota)
                    {
                        lblAvailability.Text = "Serial Available On: " + _dt.ToString("dd/MM/yyyy") + " Serial No. will be: " + (_pList.Count + 1).ToString();
                        _dayCount = _dayCount + 180;
                        dtp.Value = _dt;

                    }
                    else
                    {
                        _dayCount = _dayCount + 1;
                    }

                    //lblAvailable.Text = (_practitioner.PatientQuota - _pList.Count).ToString();
                }
                else
                {
                    _dayCount = _dayCount + 1;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(txtPatientName.Text))
            {
                {
                    MessageBox.Show("Patient Name Required ");
                    return;
                }
            }

            if (String.IsNullOrEmpty(cmbGender.Text))
            {
                {
                    MessageBox.Show("Gender Required ");
                    return;
                }
            }

            //if (String.IsNullOrEmpty(txtDateofBirth.Text))
            //{
            //    {
            //        MessageBox.Show("Date of Birth Required ");
            //        return;
            //    }
            //}

            if (String.IsNullOrEmpty(txtCellPhone.Text))
            {
                {
                    MessageBox.Show("Mobile No Required ");
                    return;
                }
            }

            if (String.IsNullOrEmpty(cmbVisitType.Text))
            {
                {
                    MessageBox.Show("Visit Type Required ");
                    return;
                }
            }


            if (lblNameOfWeekday.Tag != null)
            {
                DateTime _dt = Convert.ToDateTime(lblNameOfWeekday.Tag);
                if (_dt.Date == dtp.Value.Date)
                {
                    MessageBox.Show("Sorry! It's off day"); return;
                }
            }



            string _endTime;
            _endTime = txtEndTime.Text + " " + cmbEndtAmPm.Text;

            DateTime _dateOfBirth = DateTime.Now;
            if (txtDateofBirth.Tag != null)
            {
                _dateOfBirth = Convert.ToDateTime(txtDateofBirth.Tag);

            }

            if (btnSave.Tag != null)
            {
                ChamberPractitioner _prac = txtDoctor.Tag as ChamberPractitioner;
                PatientSerial _ps = btnSave.Tag as PatientSerial;

                PractitionerWisePatientSerial _pr = new ChamberPractitionerService().GetPatientBySerialNo(_ps.Id);
                OPDPatientVisitType _visitType = (OPDPatientVisitType)cmbVisitType.SelectedItem;

                if (!string.IsNullOrEmpty(txtPatientName.Text) && _pr != null)
                {
                    _pr.PatientName = txtPatientName.Text;
                    _pr.Sex = cmbGender.Text;
                    _pr.Occupation = txtOccupation.Text;
                    _pr.Address = txtAddress.Text;
                    _pr.Sex = cmbGender.Text;
                    _pr.Remarks = txtRemarks.Text;
                    _pr.MobileNo = txtCellPhone.Text;
                    _pr.EmailId = txtEmailAddress.Text;
                    _pr.StartTime = txtStartTime.Text;
                    _pr.SerialDate = dtp.Value;
                    _pr.EndTime = _endTime;
                    _pr.VisitTypeId = _visitType.VisitTypeId;
                    _pr.AgeYear = txtYears.Text;
                    _pr.AgeMonth = txtMonths.Text;
                    _pr.AgeDay = txtDays.Text;
                    _pr.DOB = _dateOfBirth;
                    _pr.Titel = cmbTitle.Text;
                    _pr.SerialNo = Convert.ToInt32(txtSerialNo.Text);
                    _pr.SerilTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");



                    if (new PhProductClassificationService().UpdateDoctorSerialPatient(_pr))
                    {
                        MessageBox.Show("Update Successful.");
                        LoadPatientSerialByDoctor(_prac, dtp.Value);

                        ClearFields();

                        //btnDelete.Visible = false;
                        LoadDoctors();

                        // LoadServerDateAndTime();

                    }
                }
            }
            else
            {

                txtDailyId.Text = new PatientService().GetLastIdOfToday().ToString();


                DateTime _dt = dtp.Value;

                OPDPatientVisitType _visitType = (OPDPatientVisitType)cmbVisitType.SelectedItem;

                int MAId = 0;
                if (txtMarketingAgent.Tag != null)
                {
                    MarketingAgent _agent = (MarketingAgent)txtMarketingAgent.Tag;
                    MAId = _agent.MAId;
                }


                string _patientName;
                _patientName = txtPatientName.Text;


                string _EndTime;
                _EndTime = txtEndTime.Text + " " + cmbEndtAmPm.Text;

                if (txtDoctor.Tag != null && !String.IsNullOrEmpty(txtPatientName.Text))
                {
                    int _serialNo = new ChamberPractitionerService().GetSerialNo((ChamberPractitioner)txtDoctor.Tag, dtp.Value);
                    lblSerialNo.Text = _serialNo.ToString();
                    PractitionerWisePatientSerial _pSerial = new PractitionerWisePatientSerial();
                    _pSerial.SerialDate = dtp.Value;
                    if (!String.IsNullOrEmpty(txtSerialNo.Text))
                    {
                        _pSerial.SerialNo = Convert.ToInt32(txtSerialNo.Text);
                    }
                    else

                    {
                        int SrlNo = 0;
                        if (txtSerialNo.Tag != null)
                        {
                            VMPractitionerWisePatientSerial obj = txtSerialNo.Tag as VMPractitionerWisePatientSerial;
                            SrlNo = obj.SerialNo + 1;
                        }

                        if (SrlNo == 0) SrlNo = SrlNo + 1;

                        _pSerial.SerialNo = SrlNo;

                    }
                    _pSerial.ChamberPractitionerId = ((ChamberPractitioner)txtDoctor.Tag).CPId;
                    _pSerial.PatientName = _patientName;
                    _pSerial.MobileNo = txtCellPhone.Text;
                    _pSerial.Age = txtAge.Text;
                    _pSerial.Sex = cmbGender.Text;
                    _pSerial.VisitTypeId = _visitType.VisitTypeId;
                    _pSerial.MAId = MAId;
                    _pSerial.Remarks = txtRemarks.Text;
                    _pSerial.DOB = _dateOfBirth;
                    _pSerial.AgeYear = txtYears.Text;
                    _pSerial.AgeMonth = txtMonths.Text;
                    _pSerial.AgeDay = txtDays.Text;
                    _pSerial.StartTime = txtStartTime.Text;
                    _pSerial.StartAmPm = cmbStartAmPm.Text;
                    _pSerial.EndTime = _EndTime;
                    _pSerial.EmailId = txtEmailAddress.Text;
                    _pSerial.Address = txtAddress.Text;
                    _pSerial.Occupation = txtOccupation.Text;
                    _pSerial.Titel = cmbTitle.Text;
                    _pSerial.DailyId = Convert.ToInt32(txtDailyId.Text);
                    _pSerial.SerilTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");



                    _pSerial.Status = OPDPatientSerialStatusEnum.Pending.ToString();
                    string _message = CheckRequiredInformation();

                    if (new ChamberPractitionerService().CreateNewSerial(_pSerial))
                    {
                        MessageBox.Show("Serial generated successfully.");

                        ClearFields();

                        lblNameOfWeekday.Text = _dt.DayOfWeek.ToString();

                        LoadDoctors();
                    }

                    LoadPatientSerialByDoctor((ChamberPractitioner)txtDoctor.Tag, dtp.Value);
                }
                else
                {
                    MessageBox.Show("Some required information missing.");
                }
            }
        }

        private void ClearFields()
        {
            txtPatientName.Text = "";
            txtDateofBirth.Text = "";
            txtMonths.Text = "";
            txtYears.Text = "";
            txtDays.Text = "";
            txtCellPhone.Text = "";
            txtSerialNo.Text = "";

            dtp.Value = DateTime.Now;
            txtEmailAddress.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";
            txtAddress.Text = "";
            txtOccupation.Text = "";
            txtRemarks.Text = "";
            cmbGender.Text = "";
            cmbVisitType.Text = "";
            cmbTitle.Text = "";
            cmbStartAmPm.Text = "";
            cmbEndtAmPm.Text = "";
            btnSave.Text = "Save";
            btnSave.Tag = null;
            txtPatientSearchMobile.Text = "";
            txtPatientSearchMobile.Tag = null;

            txtDateofBirth.Text = "";
            cmbStartAmPm.Text = "";
            cmbEndtAmPm.Text = "";

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



            if (String.IsNullOrEmpty(txtOccupation.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Occupation";
                }
                else
                {
                    msg = msg + ", Occupation";
                }
            }


            if (String.IsNullOrEmpty(cmbVisitType.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Visity type";
                }
                else
                {
                    msg = msg + ", Visit Type";
                }
            }

            if (String.IsNullOrEmpty(txtEmailAddress.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "E-mail Address";
                }
                else
                {
                    msg = msg + ", E-mail Address";
                }
            }

            if (String.IsNullOrEmpty(txtStartTime.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Start Time";
                }
                else
                {
                    msg = msg + ", Start Time";
                }
            }


            if (String.IsNullOrEmpty(txtEndTime.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "End Time";
                }
                else
                {
                    msg = msg + ", End Time";
                }
            }

            if (String.IsNullOrEmpty(txtDateofBirth.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Date of Birth";
                }
                else
                {
                    msg = msg + ", Date of Birth";
                }
            }

            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Adress";
                }
                else
                {
                    msg = msg + ", Address";
                }
            }


            if (String.IsNullOrEmpty(txtStartTime.Text))
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "Start Time";
                }
                else
                {
                    msg = msg + ", Start Time";
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

            if (String.IsNullOrEmpty(txtDoctor.Text))
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

        private void LoadPatientSerialByDoctor(ChamberPractitioner _practitioner, DateTime _date)
        {

            lblPQuota.Text = _practitioner.PatientQuota.ToString();
            List<VMPractitionerWisePatientSerial> _pList = new ChamberPractitionerService().LoadPatientSerialByDoctor(_practitioner.CPId, _date);

            List<VMPractitionerWisePatientSerial> _sortList = _pList.OrderByDescending(x => x.SerialNo).ToList();
            VMPractitionerWisePatientSerial lastObj = _sortList.FirstOrDefault();
            // PractitionerWisePatientSerial obj = new PractitionerWisePatientSerial() 

            txtSerialNo.Tag = lastObj;

            lblBooked.Text = _pList.Count.ToString();

            lblAvailable.Text = (_practitioner.PatientQuota - _pList.Count).ToString();

            List<PatientSerial> __pSerialList = new List<PatientSerial>();


            foreach (var _patient in _pList)
            {
                PatientSerial _serial = new PatientSerial();
                _serial.SerialNo = _patient.SerialNo;
                _serial.Titel = _patient.Titel;
                _serial.PatientName = _patient.PatientName;
                _serial.Sex = _patient.Sex;
                _serial.MobileNo = _patient.MobileNo;
                _serial.VisitTypeId = _patient.VisitTypeId;
                _serial.VisitType = _patient.VisitType;
                _serial.StartTime = _patient.StartTime;
                _serial.EndTime = _patient.EndTime;
                _serial.EmailId = _patient.EmailId;
                if (_patient.DOB == null)
                {
                    _serial.DOB = null;
                }
                else
                {
                    _serial.DOB = _patient.DOB.GetValueOrDefault();
                }

                _serial.Address = _patient.Address;
                _serial.Remarks = _patient.Remarks;
                _serial.Occupation = _patient.Occupation;
                _serial.AgeYear = _patient.AgeYear;
                _serial.AgeMonth = _patient.AgeMonth;
                _serial.AgeDay = _patient.AgeDay;
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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds = new ReportService().GetPatientSerialByDoctor(((ChamberPractitioner)txtDoctor.Tag).CPId, dtp.Value);


            rptPatientSerial _patientSerial = new rptPatientSerial();

            _patientSerial.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _patientSerial.DataDefinition.FormulaFields[0].Text = "'" + dtp.Value.ToString(customFmts) + "'";
            _patientSerial.DataDefinition.FormulaFields[1].Text = "'" + txtDoctor.Text + "'";

            rv.crviewer.ReportSource = _patientSerial;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (txtDoctor.Tag != null)
            {
                if (!CheckIsOffDay((ChamberPractitioner)txtDoctor.Tag, dtp.Value))
                {
                    LoadPatientSerialByDoctor((ChamberPractitioner)txtDoctor.Tag, dtp.Value);
                    DateTime _dt = dtp.Value;
                    lblNameOfWeekday.Text = _dt.DayOfWeek.ToString();
                    lblNameOfWeekday.Tag = null;
                    //InitializeSerialSlot((ChamberPractitioner)txtDoctor.Tag, dtp.Value);
                }
                else
                {
                    MessageBox.Show(dtp.Value.ToString("dd/MM/yyyy") + " is off day");
                    lblNameOfWeekday.Tag = dtp.Value;
                }

            }
        }

        private void InitializeSerialSlot(ChamberPractitioner prac, DateTime _date)
        {
            List<PractitionerWisePatientSerial> pSerial = new ChamberPractitionerService().GetAllPatients(prac.CPId, _date);
            if (pSerial == null || pSerial.Count == 0)
            {
                int pquota = 0;
                int.TryParse(lblPQuota.Text, out pquota);
                List<PractitionerWisePatientSerial> pSerialObj = new List<PractitionerWisePatientSerial>();
                for (int i = 0; i < pquota; i++)
                {
                    PractitionerWisePatientSerial _pSerial = new PractitionerWisePatientSerial();
                    _pSerial.SerialDate = dtp.Value;
                    _pSerial.SerialNo = i + 1;
                    _pSerial.ChamberPractitionerId = ((ChamberPractitioner)txtDoctor.Tag).CPId;
                    _pSerial.PatientName = "";
                    _pSerial.MobileNo = "";
                    _pSerial.Age = "";
                    _pSerial.Sex = "";
                    _pSerial.VisitTypeId = 1;
                    _pSerial.MAId = 0;
                    _pSerial.Remarks = "";
                    _pSerial.DOB = null;
                    _pSerial.AgeYear = "";
                    _pSerial.AgeMonth = "";
                    _pSerial.AgeDay = txtDays.Text;
                    _pSerial.StartTime = "";
                    _pSerial.EndTime = "";
                    _pSerial.EmailId = "";
                    _pSerial.Address = "";
                    _pSerial.Occupation = "";

                    _pSerial.Status = OPDPatientSerialStatusEnum.Pending.ToString();

                    pSerialObj.Add(_pSerial);
                }

                if (pSerialObj.Count > 0)
                {
                    new ChamberPractitionerService().InitializeSerialSlot(pSerialObj);
                    LoadPatientSerialByDoctor(prac, _date);
                }
            }
        }

        private bool CheckIsOffDay(ChamberPractitioner _prac, DateTime dt)
        {
            CPOffDayCalender offDay = new DoctorService().GetCPOffDays(_prac, dt);
            if (offDay == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMarketingAgent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlMarketingAgentSearchControl.Visible = true;
                ctrlMarketingAgentSearchControl.LoadData();
            }
        }

        private void lblCellPhone_Click(object sender, EventArgs e)
        {

        }

        private void txtCellPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label89_Click(object sender, EventArgs e)
        {

        }

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDateofBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                isDateParsed = true;
                string _newdateString = "";
                string _dob = txtDateofBirth.Text;
                int Length = 0;
                Length = _dob.Length - 1;

                if (Length == 7)
                {
                    _newdateString = _dob.Substring(4, 4) + _dob.Substring(2, 2) + _dob.Substring(0, 2);

                }

                //else
                //{
                //    MessageBox.Show("Date Length did not match."); return;
                //}


                DateTime _dto;
                if (!string.IsNullOrEmpty(_newdateString) && DateTime.TryParseExact(_newdateString, "yyyyMMdd", CultureInfo.InvariantCulture
                                                           , DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out _dto))
                {

                    txtDateofBirth.Tag = _dto;
                    txtDateofBirth.Text = _dto.ToString("dd/MM/yyyy");

                    DateDiff dateDiff = new DateDiff(_dto, DateTime.Now);
                    int yrs = dateDiff.ElapsedYears;
                    int months = dateDiff.ElapsedMonths;
                    int dys = dateDiff.ElapsedDays;

                    txtYears.Text = yrs.ToString();
                    txtMonths.Text = months.ToString();
                    txtDays.Text = dys.ToString();
                }
                else
                {
                    // MessageBox.Show("Invalid date time format.");
                    txtDateofBirth.Text = "";
                }

                txtYears.Focus();
            }
        }

        private void txtYears_TextChanged(object sender, EventArgs e)
        {
            //int _yrs = 0;
            //int.TryParse(txtYears.Text, out _yrs);
            //if (_yrs <= 200)
            //{
            //    this.GetDOB();
            //}
            //else
            //{
            //    //MessageBox.Show("Years exceed the limit");
            //    //txtYears.Focus();
            //}
        }

        private void GetDOB()
        {
            int yrs = 0, mnths = 0, dys = 0;
            int.TryParse(txtYears.Text, out yrs);
            int.TryParse(txtMonths.Text, out mnths);
            int.TryParse(txtDays.Text, out dys);

            DateTime _dt = DateTime.Now;
            _dt = _dt.AddYears(0 - yrs);
            _dt = _dt.AddMonths(0 - mnths);
            _dt = _dt.AddDays(0 - dys);

            txtDateofBirth.Tag = _dt;
            txtDateofBirth.Text = _dt.ToString("dd/MM/yyyy");
        }

        private void txtMonths_TextChanged(object sender, EventArgs e)
        {
            //int _months = 0;
            //int.TryParse(txtMonths.Text, out _months);
            //if (_months > 0 && _months <= 12)
            //{
            //    this.GetDOB();
            //}
            //else
            //{
            //    //MessageBox.Show("days exceed the limit");
            //    //txtDays.Focus();
            //}
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            //int _dys = 0;
            //int.TryParse(txtDays.Text, out _dys);
            //if (_dys > 0 && _dys <= 31)
            //{
            //    this.GetDOB();
            //}
            //else
            //{
            //    //MessageBox.Show("days exceed the limit");
            //    //txtDays.Focus();
            //}

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void lblPatientName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblSerialNo_Click(object sender, EventArgs e)
        {

        }

        private void lblYears_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void gvPList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PatientSerial _pr = gvPList.SelectedRows[0].Tag as PatientSerial;//new PhProductClassificationService().GetDoctorPatientById(Convert.ToInt32(gvPList.Rows[e.RowIndex].Cells["Id"].Value));
                                                                             // new ProductClassicationService().GetGenericById(Convert.ToInt32(dgFormation.Rows[e.RowIndex].Cells["FormationId"].Value));
            OPDPatientVisitType _visitType = (OPDPatientVisitType)cmbVisitType.SelectedItem;

            if (_pr != null)
            {

                string[] arr = new string[2];
                arr = _pr.StartTime.Split(' ');

                string _st = string.Empty;
                string _ampm = string.Empty;
                if (arr != null && arr.Length > 1)
                {
                    _st = arr[0];
                    _ampm = arr[1];

                }
                else if (arr != null && arr.Length > 0)
                {
                    _st = arr[0];
                    _ampm = "";
                }


                string[] arrend = new string[2];
                arrend = _pr.EndTime.Split(' ');

                string _End = string.Empty;
                string _Endampm = string.Empty;

                if (arrend != null && arrend.Length > 1)
                {
                    _End = arrend[0];
                    _Endampm = arrend[1];
                }
                else if (arrend != null && arrend.Length > 0)
                {
                    _End = arrend[0];
                    _Endampm = "";
                }

                btnSave.Tag = _pr;
                txtPatientName.Text = _pr.PatientName;
                txtPatientName.Tag = _pr;
                cmbGender.Text = _pr.Sex;
                if (_pr.DOB == null)
                {
                    txtDateofBirth.Text = "";
                }
                else
                {
                    txtDateofBirth.Text = _pr.DOB.GetValueOrDefault().ToString("dd/MM/yyyy");
                }

                txtYears.Text = _pr.AgeYear;
                txtMonths.Text = _pr.AgeMonth;
                txtDays.Text = _pr.AgeDay;
                txtCellPhone.Text = _pr.MobileNo;
                cmbVisitType.Text = _pr.VisitType;
                txtAddress.Text = _pr.Address;
                txtOccupation.Text = _pr.Occupation;
                txtEmailAddress.Text = _pr.EmailId;
                txtStartTime.Text = _st;
                cmbStartAmPm.Text = _Endampm;
                txtEndTime.Text = _End;
                cmbEndtAmPm.Text = _Endampm;
                txtRemarks.Text = _pr.Remarks;
                cmbTitle.Text = _pr.Titel;
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                // btnDelete.Visible = true;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            txtPatientName.Text = "";
            cmbGender.Text = "";
            txtDateofBirth.Text = "";
            txtYears.Text = "";
            txtMonths.Text = "";
            txtDays.Text = "";
            txtOccupation.Text = "";
            txtRemarks.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";
            txtEmailAddress.Text = "";
            txtOccupation.Text = "";
            txtAddress.Text = "";
            txtCellPhone.Text = "";
            txtPatientName.Tag = null;
            btnSave.Text = "Save";
            btnSave.Tag = null;
            btnCancel.Visible = false;
            txtDateofBirth.Text = "";
            cmbVisitType.Text = "";
            cmbStartAmPm.Text = "";
            cmbEndtAmPm.Text = "";

            //LoadServerDateAndTime();
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTitle.Text.ToLower() == "mr." || cmbTitle.Text.ToLower() == "md.")
            {
                cmbGender.Text = "Male";
            }
            else if (cmbTitle.Text.ToLower() == "ms." || cmbTitle.Text.ToLower() == "mst." || cmbTitle.Text.ToLower() == "ms")
            {
                cmbGender.Text = "Female";
            }
            else if (cmbTitle.Text.ToLower() == "others.")
            {
                cmbGender.Text = "None";

            }
        }

        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
        }

        private void txtDateofBirth_Leave(object sender, EventArgs e)
        {

            if (!isDateParsed)
            {
                string _newdateString = "";
                string _dob = txtDateofBirth.Text;
                int Length = 0;
                Length = _dob.Length - 1;

                if (Length == 7)
                {
                    _newdateString = _dob.Substring(4, 4) + _dob.Substring(2, 2) + _dob.Substring(0, 2);

                }
                else
                {
                    MessageBox.Show("Date Length did not match."); return;
                }


                DateTime _dto;
                if (!string.IsNullOrEmpty(_newdateString) && DateTime.TryParseExact(_newdateString, "yyyyMMdd", CultureInfo.InvariantCulture
                                                           , DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out _dto))
                {

                    txtDateofBirth.Tag = _dto;
                    txtDateofBirth.Text = _dto.ToString("dd/MM/yyyy");

                    DateDiff dateDiff = new DateDiff(_dto, DateTime.Now);
                    int yrs = dateDiff.ElapsedYears;
                    int months = dateDiff.ElapsedMonths;
                    int dys = dateDiff.ElapsedDays;

                    txtYears.Text = yrs.ToString();
                    txtMonths.Text = months.ToString();
                    txtDays.Text = dys.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid date time format.");
                    txtDateofBirth.Text = "";
                }
            }
        }

        private void cmbTitle_KeyPress(object sender, KeyPressEventArgs e)
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

                txtDateofBirth.Focus();

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
                txtCellPhone.Focus();
            }
        }

        private void txtCellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbVisitType.Focus();
            }

        }

        private void cmbVisitType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtOccupation.Focus();
            }
        }

        private void txtOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEmailAddress.Focus();
            }
        }

        private void txtEmailAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtStartTime.Focus();
            }
        }

        private void txtStartTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbStartAmPm.Focus();
            }
        }

        private void cmbStartAmPm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtEndTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbEndtAmPm.Focus();
            }
        }

        private void cmbEndtAmPm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void cmbStartAmPm_TextChanged(object sender, EventArgs e)
        {
            if (cmbStartAmPm.Text.ToLower() == "am")
            {
                cmbEndtAmPm.Text = "Am";
            }
            else if (cmbStartAmPm.Text.ToLower() == "pm")
            {
                cmbEndtAmPm.Text = "Pm";
            }
        }

        private void txtPatientSearchMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtPatientSearchMobile.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtPatientSearchMobile.Text;
                    hideDefault();
                    ctrlPatientSerialBooking1.Visible = true;
                    ctrlPatientSerialBooking1.txtSearch.Text = _txt;
                    //txtPatientSearchMobile
                    ctrlPatientSerialBooking1.txtSearch.SelectionStart = ctrlPatientSerialBooking1.txtSearch.Text.Length;

                    ctrlPatientSerialBooking1.LoadData();
                }
            }
        }

        private void cmbTitle_TextChanged(object sender, EventArgs e)
        {
            if (cmbTitle.Text.ToLower() == "mr." || cmbTitle.Text.ToLower() == "md.")
            {
                cmbGender.Text = "Male";
            }
            else if (cmbTitle.Text.ToLower() == "ms." || cmbTitle.Text.ToLower() == "mst." || cmbTitle.Text.ToLower() == "ms")
            {
                cmbGender.Text = "Female";
            }
            else if (cmbTitle.Text.ToLower() == "others.")
            {
                cmbGender.Text = "None";

            }
        }

        private void ctrlPatientSerialBooking1_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCellPhone.Text = ctrlPatientSerialBooking1.txtSearch.Text;
                txtPatientSearchMobile.Focus();
            }
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            frmAvailableDoctor _frm = new frmAvailableDoctor();
            _frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PatientSerial patientSerial = gvPList.SelectedRows[0].Tag as PatientSerial;
            if (patientSerial != null)
            {
                ChamberPractitioner _prac = txtDoctor.Tag as ChamberPractitioner;
                PatientSerial _ps = btnSave.Tag as PatientSerial;
                PractitionerWisePatientSerial _pr = new ChamberPractitionerService().GetPatientBySerialNo(_ps.Id);

                if (new ChamberPractitionerService().DeletePatientSerial(_pr))
                {
                    MessageBox.Show("Deleted Successfully");

                    LoadPatientSerialByDoctor(_prac, dtp.Value);
                }
            }
        }
    }
}

