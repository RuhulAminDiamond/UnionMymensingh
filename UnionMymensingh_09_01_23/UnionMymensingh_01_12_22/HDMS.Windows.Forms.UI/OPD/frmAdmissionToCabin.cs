using CrystalDecisions.Windows.Forms;
using DSBarCode;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Service.OPD;
using HDMS.Windows.Forms.UI.Common;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmAdmissionToCabin : Form
    {

        BarCodeCtrl _control = new BarCodeCtrl();
        bool isLoaded = false;
        bool isInMaxView = true;

        public frmAdmissionToCabin()
        {
            InitializeComponent();
        }

        private IList<RegUniqueKeyTracker> _ukeyList;

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            isLoaded = false;

            ctlDoctorSearch.Location = new Point(txtRefdby.Location.X, txtRefdby.Location.Y+ txtRefdby.Height);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            ctlAssignedDoctor.Location = new Point(txtAssignDoctor.Location.X, txtAssignDoctor.Location.Y + txtAssignDoctor.Height);
            ctlAssignedDoctor.ItemSelected += ctlAssignedDoctor_ItemSelected;
            
            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadServerDateAndTime();
          

            //txtBillNo.Text = GetNewBillNo();


            LoadAccomodationTypes();

            txtAdmissionFee.Text = GetAdmissionFee();

            

            LoadPatientList();

            LoadFloors();

            LoadCabinList();

            isLoaded = true;
        }

        private void LoadCabinList()
        {
            List<CabinInfo> _cabinList = new HospitalCabinBedService().GetFreeCabinList();
            _cabinList.Insert(0, new CabinInfo() { CabinId = 0, CabinNo = "Select Cabin" });
            cmbCabinView.DataSource = _cabinList;
            cmbCabinView.DisplayMember = "CabinNo";
            cmbCabinView.ValueMember = "CabinId";
        }

        private void LoadFloors()
        {
            List<FloorInfo> _floor = new HospitalCabinBedService().GetFloorList();
            _floor.Insert(0, new FloorInfo() { FloorId = 0, Name = "Select Floor" });
            cmbFloor.DataSource = _floor;
            cmbFloor.DisplayMember = "Name";
            cmbFloor.ValueMember = "FloorId";
        }

        private void LoadPatientList()
        {
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfo().ToList();

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);

        }

    private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
    {
        dgPatient.SuspendLayout();
        dgPatient.Rows.Clear();
        foreach (VMIPDInfo item in _lisPatientInfo)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Tag = item;
            row.Height = 35;
            row.CreateCells(dgPatient, item.BillNo, item.AddmissionDate.ToString("dd/MM/yyyy"), item.AdmTime, item.Name, item.BedCabinNo, item.AssignedDoctor, item.FatherName, item.MobileNo, item.Status);
            dgPatient.Rows.Add(row);
        }

    }

    private void LoadAccomodationTypes()
        {
            List<HpPatientAccomodationType> _HpPatientAccomodationTypeList = new HospitalCabinBedService().GetAccomodationTypes();

            _HpPatientAccomodationTypeList.Insert(0, new HpPatientAccomodationType() { AccomodationTypeId = 0, AccomodationType = "--Select---" });
            cmbAdmittedTo.DataSource = _HpPatientAccomodationTypeList;

            cmbAdmittedTo.DisplayMember = "AccomodationType";
            cmbAdmittedTo.ValueMember = "AccomodationTypeId";
        }

        private string GetAdmissionFee()
        {
            HpParameterSetup _hpAdmissionFee = new HpFinancialService().GetAdmissionFee();

            return _hpAdmissionFee.Amount.ToString();
        }

        private void LoadServerDateAndTime()
        {
            dtpAdmission.Value = Utils.GetServerDateAndTime();
            txtAdmissionTime.Text = Utils.GetServerDateAndTime().ToString("h:mm:ss tt");
        }

        private string GetNewBillNo()
        {
            string _billPart1 = Utils.GetBillNo();
            long _billNo = new Random().Next(10000, 99999);
            string _billPart2 = _billNo.ToString() + "1";

            string _BillNo = _billPart1 + _billPart2;

            if (!new HospitalService().IsBillNoAlloted(Convert.ToInt64(_BillNo)))
            {
                return _BillNo.ToString();
            }

            GetNewBillNo();

            return "";
        }


        void ctlAssignedDoctor_ItemSelected(Controls.SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtAssignDoctor.Text = item.Name;
            txtAssignDoctor.Tag = item;
            sender.Visible = false;
        }

        private string GetNextAdmissionNo()
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
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string msg = ValidateEntry();
            long _regNo = 0;
            long _billNo = 0;
            int _cabinId = 0;
            long _admissionId = 0;

            long _opdBillNo = 0;
            long.TryParse(txtOPDBillNo.Text, out _opdBillNo);

            OPDPatientRecord _opdRecord = new HospitalEmergencyService().GetPatientInfoByBillNo(_opdBillNo);

            if (_opdRecord == null)
            {
                MessageBox.Show("Invalid opd bill no."); return;
            }

            _cabinId = Convert.ToInt32(cmbCabinOrOther.SelectedValue);
            if (_cabinId == 0)
            {
                MessageBox.Show("No cabin or bed selected"); return;
            }

            LoadServerDateAndTime();

            if (String.IsNullOrEmpty(msg))
            {

                if (txtPrevBillNo.Tag != null)
                {

                    long.TryParse(txtPrevBillNo.Tag.ToString(),out _admissionId);
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_admissionId);

                    ViewAdmissionForm(_pInfo);

                }
                else
                {


                    cmdSave.Enabled = false;
                    cmdSave.Text = "Pz. Wait.";

                    double _admissionFee = 0;
                    double.TryParse(txtAdmissionFee.Text, out _admissionFee);
                    long.TryParse(txtOPDBillNo.Text, out _regNo);


                    long.TryParse(txtBillNo.Text, out _billNo);
                    HospitalPatientInfo _hpInfo = new HospitalService().GetIPDInfoByBillNo(_billNo);
                    if (_hpInfo != null) txtBillNo.Text = GetNewBillNo();
                    long.TryParse(txtBillNo.Text, out _billNo);

                    HospitalPatientInfo _patientInfo = new HospitalPatientInfo();

                    RegRecord _regTracker = GetRegNoLong();

                    _patientInfo.RegNo = _regTracker.RegNo;
                    _patientInfo.BillNo = 0;
                    _patientInfo.OPDBillNo = _opdBillNo;
                    _patientInfo.AgeYear = txtYears.Text;
                    _patientInfo.AgeMonth = txtMonths.Text;
                    _patientInfo.AgeDay = txtDays.Text;


                    _patientInfo.AddmissionDate = Utils.GetServerDateAndTime();
                    _patientInfo.Time = txtAdmissionTime.Text;
                    _patientInfo.AssignDoctorId = ((Doctor)txtAssignDoctor.Tag).DoctorId;
                    _patientInfo.RefdDoctorId = ((Doctor)txtRefdby.Tag).DoctorId;

                    _patientInfo.WardOrCabinId = Convert.ToInt32(cmbCabinOrOther.SelectedValue);

                    _patientInfo.CabinOrWardBedDisplayString = GetCabinBedDisplayString();
                    _patientInfo.Admittedby = MainForm.LoggedinUser.Name;


                    _patientInfo.Status = "Cabin";

                    _admissionId = new HospitalService().SaveHospitalPatientInfo(_patientInfo);

                    if (_admissionId > 0)
                    {
                        CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_cabinId);
                        _cabin.IsBooked = true;
                        new HospitalCabinBedService().UpdateCabinInfo(_cabin);

                        HpPatientAccomodationInfo _currentAccomodation = new HpPatientAccomodationInfo();
                        _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                        _currentAccomodation.AccomodateTime = txtAdmissionTime.Text;
                        _currentAccomodation.AdmissionId = _admissionId;
                        _currentAccomodation.CabinId = Convert.ToInt32(cmbCabinOrOther.SelectedValue);
                        _currentAccomodation.OperatorRemarks = "New Admission";
                        _currentAccomodation.SoftwareRemarks = "New admission";
                        _currentAccomodation.Status = "Occupied";
                        _currentAccomodation.AllotType = HpBedAllotTypeEnum.PatientBed.ToString();
                        _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;

                        new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);

                    }

                    MessageBox.Show("Patient admission information saved successfully.");


                    //_regTracker.IsUsed = true;
                    //new RegRecordService().UpdateRegTracker(_regTracker);

                    cmdSave.Enabled = true;
                    cmdSave.Text = "Save";

                    //Hp Patient Ledger Entry

                    double _hpadmissionFee = 0;
                    double.TryParse(txtAdmissionFee.Text, out _hpadmissionFee);

                    if (_hpadmissionFee > 0)
                    {
                        HpPatientLedger _hpLedger = new HpPatientLedger();
                        _hpLedger.AdmissionId = _admissionId;
                        _hpLedger.TranDate = Utils.GetServerDateAndTime();
                        _hpLedger.Particulars = "Admission Fee";
                        _hpLedger.Debit = _hpadmissionFee;
                        _hpLedger.Credit = 0;
                        _hpLedger.Balance = 0 - _hpadmissionFee; // Negative balance means patient is payable this amount
                        _hpLedger.TransactionType = TransactionTypeEnum.HpAdmissionFee.ToString();
                        _hpLedger.OperateBy = MainForm.LoggedinUser.Name;

                        if (new HpFinancialService().SaveHpLedgerTransaction(_hpLedger))
                        {

                        }

                    }

                    // End of Hp Patient Ledger Entry

                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_admissionId);
                    txtBillNo.Text = _pInfo.BillNo.ToString();
                    ViewAdmissionForm(_pInfo);

                    LoadCabinList();

                    //txtPatientName.Text = "";


                    ClearFields();
                }
            }else
            {
                MessageBox.Show(msg+" required.");
            }
        }

        private RegRecord GetRegNoLong()
        {
            long _regNo = 0;
          

          

          

            RegRecord _rgRecord = new RegRecord();
            _rgRecord.RegNo = 0;
            _rgRecord.FullName = txtPatientName.Text;
            _rgRecord.AgeYear = txtYears.Text;
            _rgRecord.AgeMonth = txtMonths.Text;
            _rgRecord.AgeDay = txtDays.Text;
            // _record.BloodGroup = "";//cbBloodGroup.Text;
            _rgRecord.FatherName = txtFatherName.Text;
            _rgRecord.MaritalStatus = cmbMaritalStatus.Text;
            _rgRecord.Profession = txtOccupation.Text;
            _rgRecord.MotherName = txtMotherName.Text;
            _rgRecord.SpouseName = txtSpouseName.Text;
            _rgRecord.ContactPerson = txtContactPerson.Text;
            _rgRecord.RelationWithPatient = txtRelationWithPatient.Text;
            _rgRecord.CPAddress = txtCPAddress.Text;
            _rgRecord.CPMobile = txtMobile.Text;
            _rgRecord.CPNationalId = txtNationalID.Text;
            _rgRecord.Sex = cmbSex.Text;
            _rgRecord.CountryCode = "1";
            _rgRecord.MobileNo = txtPhone.Text;
            _rgRecord.DOB = GetDob();

            RegRecord _record = new RegRecordService().SaveRegRecord(_rgRecord);

            _record = new RegRecordService().GetRegRecordById(_record.Id);

            return _record;
           

        }



        private RegUniqueKeyTracker GetNewRegNo()
        {

            RegUniqueKeyTracker _regTracker = new RegRecordService().GetRegUniqueKey(MainForm.WorkStationId, Utils.GetServerDateAndTime().ToString("yy"), Utils.GetServerDateAndTime().Month);

            if (_regTracker == null)
            {

                new RegRecordService().GenerateRegKey(MainForm.LoggedinUser.Name, MainForm.WorkStationId,"",250, Convert.ToInt32(Configuration.ORG_CODE));

                _regTracker = new RegRecordService().GetRegUniqueKey(MainForm.WorkStationId, Utils.GetServerDateAndTime().ToString("yy"), Utils.GetServerDateAndTime().Month);

                return _regTracker;
            }

            return _regTracker;


        }

        private List<RegUniqueKeyTracker> GenerateKeyForWorkStation(string workStationId)
        {

            List<RegUniqueKeyTracker> _regKeys = new List<RegUniqueKeyTracker>();

            for (int _count = 0; _count < 300; _count++)
            {
                long _regNumber = 0;



                string _regPart1 = Utils.GetRegNo();
                long _regNo = new Random().Next(100000, 999999);
                string _regPart2 = _regNo.ToString() + "1";

                string _RegNo = _regPart1 + _regPart2;

                if (!new RegRecordService().IsRegUniqueKeyAlloted(Convert.ToInt64(_RegNo)))
                {
                    long.TryParse(_RegNo, out _regNumber);

                    RegUniqueKeyTracker _uk = new RegUniqueKeyTracker();
                    _uk.RegNo = _regNumber;
                    _uk.GenerateFrom = workStationId;
                    _regKeys.Add(_uk);

                    // new TestService().PopulateKeyItems(_ukeyList, _regNumber, workStationId);

                }

            }

            return _regKeys;


        }




        private string GetCabinBedDisplayString()
        {
           
                return cmbCabinOrOther.Text;
           
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

     

        private void ViewAdmissionForm(HospitalPatientInfo _pInfo)
        {
            ReportViewer rv = new ReportViewer();
            rptAdmission _admf = new rptAdmission();

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            DataSet ds = new HospitalReportService().GetAdmissionRecordByAdmissionId(_pInfo.AdmissionId);

            _admf.SetDataSource(ds.Tables[0]);

            _admf.SetParameterValue("BillNo", _pInfo.BillNo.ToString());
            _admf.SetParameterValue("RegNo", _pInfo.RegNo.ToString());

            _admf.SetParameterValue("Admittedby", "("+_user.FullName+")");

            rv.crviewer.ReportSource = _admf;
            
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void ShowAdmissionInfo(HospitalPatientInfo _pInfo)
        {

             RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_pInfo.RegNo);

            if (_record != null)
            {
                txtPatientName.Text = _record.FullName;
                cmbSex.Text = _record.Sex;
                txtFatherName.Text = _record.FatherName;
                txtMotherName.Text = _record.MotherName;
                txtAddress.Text= _record.Address;
                txtPhone.Text = _record.MobileNo;
                txtOccupation.Text = _record.Profession;
                txtSpouseName.Text = _record.SpouseName;
                txtContactPerson.Text = _record.ContactPerson;
                txtRelationWithPatient.Text = _record.RelationWithPatient;
                txtMobile.Text = _record.CPMobile;
                txtCPAddress.Text = _record.CPAddress;

            }

              txtPrevBillNo.Text = _pInfo.BillNo.ToString();
              txtPrevBillNo.Tag = _pInfo.AdmissionId;

             // cmdSave.Text = "Update";
            lblPStatus.Text = _pInfo.Status;

                 txtYears.Text = _pInfo.AgeYear.ToString();
                 txtMonths.Text= _pInfo.AgeMonth.ToString();
                 txtDays.Text = _pInfo.AgeDay.ToString();
              
                
            cmbAdmittedTo.Text = "Cabin";
            List<CabinInfo> _cabinList = new HospitalCabinBedService().GetCabinList();
           _cabinList.Insert(0, new CabinInfo { CabinId = 0, Description = "Select Cabin", Rent = 0 });
            cmbCabinOrOther.DataSource = _cabinList;
            cmbCabinOrOther.DisplayMember = "Description";
            cmbCabinOrOther.ValueMember = "CabinId";

            

            cmbCabinOrOther.SelectedItem = _cabinList.Find(q => q.CabinId == _pInfo.WardOrCabinId);

         

            Doctor _assigDoc = new DoctorService().GetDoctorById(_pInfo.AssignDoctorId);
            Doctor _refdDoctor = new DoctorService().GetDoctorById(_pInfo.RefdDoctorId);

            txtAssignDoctor.Text = _assigDoc.Name;
            txtAssignDoctor.Tag = _assigDoc;

            txtRefdby.Text = _refdDoctor.Name;
            txtRefdby.Tag = _refdDoctor;


        }

        private void ClearFields()
        {
            txtPatientName.Text = "";
            txtFatherName.Text = "";
            txtPatientName.Text = "";
            cmbSex.Text =  "";
            txtFatherName.Text =  "";
            txtMotherName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtOccupation.Text = "";
            txtSpouseName.Text = "";
            txtContactPerson.Text = "";
            txtRelationWithPatient.Text = "";
            txtMobile.Text = "";
            txtCPAddress.Text = "";
            cmbCabinOrOther.Text = "";

            cmdSave.Text = "Save";
            

        }

        private string ValidateEntry()
        {
            string _msg = string.Empty;
         
            if(String.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                _msg = "Patient Name";
            }

            return _msg;

        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPrevBillNo.Text))
            {
                HospitalPatientInfo _PInfo = new HospitalService().GetLatestAdmittedPatient();
                if (_PInfo == null) return;

                ShowAdmissionInfo(_PInfo);
            }

            else if (!String.IsNullOrEmpty(txtPrevBillNo.Text))
            {

                if (txtPrevBillNo.Tag != null)
                {

                    long _AdmissionId = Convert.ToInt64(txtPrevBillNo.Tag);
                  
                    HospitalPatientInfo _PatientInfo = new HospitalService().GetHospitalPatientInfoById(_AdmissionId-1);
                    if (_PatientInfo == null) {
                        _PatientInfo = new HospitalService().GetLatestAdmittedPatient();
                    } 
                    ShowAdmissionInfo(_PatientInfo);
                }
            }
            

        }

        private void ShowPatientInfo(HospitalPatientInfo _patient)
        {
            txtOPDBillNo.Text = _patient.RegNo.ToString();
          
         
            txtAssignDoctor.Text = _patient.AssignDoctorId.ToString();
            //cmbOccupation.Text = _patient.Occupation;
           
            
           
        }

        private void cmdNxt_Click(object sender, EventArgs e)
        {
            HospitalPatientInfo _patient;
            if (txtOPDBillNo.Tag == null)
            {
                _patient = new HospitalService().GetHospitalPatientInfoById(new HospitalService().GetFirstPatientById().AdmissionId);
                 txtOPDBillNo.Tag = _patient;

            }
            else
            {
                _patient = new HospitalService().GetHospitalPatientInfoById(((HospitalPatientInfo)txtOPDBillNo.Tag).AdmissionId + 1);
                txtOPDBillNo.Tag = _patient;

            }

            if (_patient != null)
            {
                
                ShowPatientInfo(_patient);
            }
            else
            {
                ClearFields();
            }
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
           // txtRegNo.Text = GetNewRegNo();
            ClearFields();
            txtOPDBillNo.Tag = null;

            txtPrevBillNo.Tag = null;

            LoadCabinList();
        }

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _regNo = 0;
                Int64.TryParse(txtOPDBillNo.Text, out _regNo);
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
                if (_record != null)
                {
                    txtPatientName.Text = _record.FullName;
                    txtYears.Text = _record.AgeYear;
                    txtMonths.Text = _record.AgeMonth;
                    txtDays.Text = _record.AgeDay;
                    txtPhone.Text = _record.MobileNo;
                    txtAddress.Text = _record.Address;
                    cmbSex.Text = _record.Sex;
                    cmbMaritalStatus.Text = _record.MaritalStatus;
                    txtOccupation.Text = _record.Profession;

                    txtAdmissionFee.Text = "500";

                    Image _profileImage = GetProfileImage(txtOPDBillNo.Text);
                    pbox.Image = _profileImage;

                    LoadBarcode();
                }
            }
        }

        private Image GetProfileImage(string _regNo)
        {
            SqlConnection con = new SqlConnection(Utility.GetImageDbConnectionString());
            MemoryStream stream = new MemoryStream();
            try
            {
                
                SqlCommand cmd = new SqlCommand("select ProfileImage from MemberImages where RegNo='"+_regNo+"'", con);
                con.Open();
                byte[] b = (byte[])cmd.ExecuteScalar();
                
                stream.Write(b, 0, b.Length);
                Bitmap bm = new Bitmap(stream);
                con.Close();
                return bm;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
                stream.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRefdby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
            ctlAssignedDoctor.Visible = false;
        }

        private void btnFindRefdby_Click(object sender, EventArgs e)
        {
            frmDoctorList _dcList = new frmDoctorList();
            _dcList.ShowDialog();
        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
        }

        void ctlDoctorSearch_ItemSelected(Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtRefdby.Text = item.Name;
            txtRefdby.Tag = item;
            sender.Visible = false;
        }

        

        private void txtAssignDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlAssignedDoctor.Visible = true;
                ctlAssignedDoctor.LoadData();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrevBillNo.Text))
            {

                long _billNo = 0;
                long.TryParse(txtPrevBillNo.Text, out _billNo);

                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_billNo);

                  
                    if (_pInfo == null)
                    {
                    return;
                    }


                    ViewAdmissionForm(_pInfo);
                
            }

        }

        private void LoadBarcode()
        {
            //txtRegNo.Text = GetNextRegNo();

            _control.BarCode = txtOPDBillNo.Text.Aggregate(string.Empty, (c, i) => c + i + ' ');
            _control.BarCodeHeight = 15;
            _control.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            _control.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control.HeaderText = "";
            _control.LeftMargin = 10;
            _control.Location = new System.Drawing.Point(450, 200);
            //_control.Name = "userControl11";
            _control.ShowFooter = true;
            _control.ShowHeader = true;
            _control.Size = new System.Drawing.Size(410, 40);
            _control.TabIndex = 0;
            _control.TopMargin = 1;
            _control.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            _control.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            this.Controls.Add(_control);

            //ClearFields();
        }

        private void ctlAssignedDoctor_ItemSelected()
        {

        }

        private void ctlDoctorSearch_ItemSelected()
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void cmbAdmittedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (isLoaded)
            {
                HpPatientAccomodationType _accomType = (HpPatientAccomodationType)cmbAdmittedTo.SelectedItem;

                List<CabinInfo> _cabinList = new HospitalCabinBedService().GetAccomodationList(_accomType.AccomodationTypeId, 0);
                _cabinList.Insert(0, new CabinInfo { CabinId = 0, Description = "--Select Cabin--", Rent = 0 });

                cmbCabinOrOther.DataSource = _cabinList;
                cmbCabinOrOther.DisplayMember = "CabinNo";
                cmbCabinOrOther.ValueMember = "CabinId";

                cmbCabinOrOther.SelectedItem = _cabinList.Find(q => q.CabinId == 0);
            }

        
        }

       

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCabinList_Click(object sender, EventArgs e)
        {
            frmCabinList _frm = new frmCabinList();
            _frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtAdmissionTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            
                pnlPatient.Location = new Point(pnlPatient.Location.X + 1250, pnlPatient.Location.Y);

                isInMaxView = false;

                 btnMaxView.Visible = true;
            
        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(18, 19);

            isInMaxView = true;

            btnMaxView.Visible = false;
        }

        private void cmbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoByFloor(Convert.ToInt32(cmbFloor.SelectedValue)).ToList();

                lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

                FillListGrid(_lisPatientInfo);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatientList();
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);
                txtCabin.Tag = _pInfo;

                txtCabin.Text = _pInfo.BedCabinNo;
                txtCabin.Tag = _pInfo;
            }
        }

        private void btnUpdateCabin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to update the cabin number?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                CabinInfo _Cabin = (CabinInfo)cmbCabinView.SelectedItem;
                if (_Cabin.CabinId == 0)
                {
                    MessageBox.Show("Cabin not selected"); return;
                }

                if (txtCabin.Tag == null)
                {
                    MessageBox.Show("Patient  not selected"); return;
                }

                VMIPDInfo _IpdPInfo = (VMIPDInfo)txtCabin.Tag;


                 HpPatientAccomodationInfo _pAccomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_IpdPInfo.AdmissionId);
                if(_pAccomInfo != null)
                {

                    FeeCurrentCabin(_pAccomInfo.CabinId);

                    _pAccomInfo.CabinId = _Cabin.CabinId;
                    _pAccomInfo.Status = "Occupied";
                    _pAccomInfo.AllotType = "PatientBed";

                    if (new HospitalService().UpdateAllotedCabin(_pAccomInfo))
                    {
                        MessageBox.Show("Cabin info updated successfully.");
                      
                        LoadPatientList();
                    }

                }
                

            }

            }

        private void FeeCurrentCabin(int cabinId)
        {
            CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(cabinId);
            _Cabin.IsBooked = false;
            new HospitalCabinBedService().UpdateCabinInfo(_Cabin);


        }

        private void FeeCurrentCabin()
        {
            throw new NotImplementedException();
        }

        private void txtPrevBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _admissionNo = 0;
                long.TryParse(txtPrevBillNo.Text, out _admissionNo);

                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_admissionNo);

                if (_pInfo != null)
                {
                    ShowAdmissionInfo(_pInfo);
                }
                else
                {
                    MessageBox.Show("Patient not found. Plz. check the admission no and try again.");
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                LoadPatientsDatabyName(txtName.Text, "PName");
            }

        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoBySearchParameter(_prefix, type).ToList();

            if (_lisPatientInfo.Count() == 0) return;

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByCabin.Text, "cabin");
            }
        }

        private void txtAdmId_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "By Adm. Id")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
        }

        private void txtSearchByAssignDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByAssignDoc.Text.Trim() == "Search by Assign Doc")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByAssignDoc.Text, "assigndoc");
            }
        }

        private void cmdNxt_Click_1(object sender, EventArgs e)
        {

        }

        private void txtOPDBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                Int64.TryParse(txtOPDBillNo.Text, out _billNo);

                OPDPatientRecord _opdpr = new OPDPatientService().GetPatientByBillNo(_billNo);

                if (_opdpr != null)
                {
                    if (!LoadRegPatientInfo(_opdpr.RegNo))
                    {
                        MessageBox.Show("Bill No not found.Please check and try again.");
                        return;
                    }

                    txtBillNo.Tag = _opdpr;
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
                txtMobile.Text = _record.MobileNo;
                cmbSex.Text = _record.Sex;
                cmbMaritalStatus.Text = _record.MaritalStatus;
                return true;
            }

            return false;
        }
    }
    }

