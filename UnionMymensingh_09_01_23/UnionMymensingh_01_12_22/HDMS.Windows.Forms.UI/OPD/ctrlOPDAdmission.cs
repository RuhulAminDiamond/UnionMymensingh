using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Location;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
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
    public partial class ctrlOPDAdmission : UserControl
    {
        bool isLoaded = false;
        bool isInMaxView = true;

        public ctrlOPDAdmission()
        {
            InitializeComponent();
        }

        private async void ctrlOPDAdmission_Load(object sender, EventArgs e)
        {
            isLoaded = false;

            ctlDoctorSearch.Location = new Point(txtRefdby.Location.X, txtRefdby.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;
            ctlAssignedDoctor.Location = new Point(txtAssignDoctor.Location.X, txtAssignDoctor.Location.Y);
            ctlAssignedDoctor.ItemSelected += ctlAssignedDoctor_ItemSelected;

            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y);
            ctlMediaSearchControl.ItemSelected += ctlMediaSearchControl_ItemSelected;

            ctrlHpPackageSearchControl.Location = new Point(txtPackage.Location.X, txtPackage.Location.Y);
            ctrlHpPackageSearchControl.ItemSelected += ctrlHpPackageSearchControl_ItemSelected;


            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadServerDateAndTime();


            //txtBillNo.Text = GetNewBillNo();


            LoadAccomodationTypes();

            txtAdmissionFee.Text = GetAdmissionFee();





            LoadFloors();

            LoadCabinList();

            LoadDepartments();

            LoadDepartments_2();

            LoadDistricts();

            LoadLocalGurdianDistricts();

            List<VMIPDInfo> _Plist = await LoadPatients();

            FillListGrid(_Plist);
            // LoadPatientList();

            isLoaded = true;
        }

        private async Task<List<VMIPDInfo>> LoadPatients()
        {

            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentOPDAdmittedInfo();

            return _lisPatientInfo;
        }

        private async void LoadDistricts()
        {
            List<District> _districtList = await new CommonService().GetAllDistricts();
            _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

            cmbDistricts.DataSource = _districtList;
            cmbDistricts.DisplayMember = "Name";
            cmbDistricts.ValueMember = "DistrictId";

            isLoaded = true;
        }

        private async void LoadLocalGurdianDistricts()
        {
            List<District> _districtList = await new CommonService().GetAllDistricts();
            _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

            cmbLocalGurdianDistrict.DataSource = _districtList;
            cmbLocalGurdianDistrict.DisplayMember = "Name";
            cmbLocalGurdianDistrict.ValueMember = "DistrictId";

            isLoaded = true;
        }

        private void LoadDepartments_2()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList = _deptList.Where(x => x.Name.ToLower().Equals("opd")).ToList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });
            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList = _deptList.Where(x => x.Name.ToLower().Equals("opd")).ToList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });
            cmbDepartment.DataSource = _deptList;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "DeptId";
        }

        private void LoadCabinList()
        {
            List<CabinInfo> _cabinList = new HospitalCabinBedService().GetFreeCabinList();
            _cabinList.Insert(0, new CabinInfo() { CabinId = 0, CabinNo = "Select Cabin" });

        }

        private void LoadFloors()
        {
            List<FloorInfo> _floor = new HospitalCabinBedService().GetFloorList();
            _floor.Insert(0, new FloorInfo() { FloorId = 0, Name = "Select Floor" });
            cmbDept.DataSource = _floor;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "FloorId";
        }

        private string GetAdmissionFee()
        {
            HpParameterSetup _hpAdmissionFee = new HpFinancialService().GetAdmissionFee();

            return _hpAdmissionFee.Amount.ToString();
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
                row.CreateCells(dgPatient, item.BillNo, item.AddmissionDate.ToString("dd/MM/yyyy"), item.AdmTime, item.Name, item.BedCabinNo, item.AssignedDoctor, item.MobileNo, item.CPAddress, item.Status);
                dgPatient.Rows.Add(row);
            }

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

        }

        private void LoadAccomodationTypes()
        {
            List<HpPatientAccomodationType> _HpPatientAccomodationTypeList = new HospitalCabinBedService().GetAccomodationTypes();


            _HpPatientAccomodationTypeList = _HpPatientAccomodationTypeList.Where(x => x.AccomodationType.ToLower().Equals("opd")).ToList();
            _HpPatientAccomodationTypeList.Insert(0, new HpPatientAccomodationType() { AccomodationTypeId = 0, AccomodationType = "--Select---" });
            cmbAdmittedTo.DataSource = _HpPatientAccomodationTypeList;

            cmbAdmittedTo.DisplayMember = "AccomodationType";
            cmbAdmittedTo.ValueMember = "AccomodationTypeId";
        }

        private void LoadServerDateAndTime()
        {
            dtpAdmission.Value = Utils.GetServerDateAndTime();
            txtAdmissionTime.Text = Utils.GetServerDateAndTime().ToString("h:mm:ss tt");
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

        private void ctrlHpPackageSearchControl_ItemSelected(SearchResultListControl<HpPackage> sender, HpPackage item)
        {
            txtPackage.Text = item.Name;
            txtPackage.Tag = item;
            sender.Visible = false;
            cmdSave.Focus();
        }

        private void ctlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item.MediaId;
            txtMedia.Focus();
            sender.Visible = false;
        }

        private void ctlAssignedDoctor_ItemSelected(Controls.SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtAssignDoctor.Text = item.Name;
            txtAssignDoctor.Tag = item;
            sender.Visible = false;
        }

        private void ctlDoctorSearch_ItemSelected(Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtRefdby.Text = item.Name;
            txtRefdby.Tag = item;
            sender.Visible = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string msg = ValidateEntry();
            long _regNo = 0;
            long _billNo = 0;
            int _cabinId = 0;
            long _admissionId = 0;
            int _PackageId = 0;

            int _MediaId = 0;

            HpDepartment _dept = (HpDepartment)cmbDepartment.SelectedItem;

            if (_dept.DeptId == 0)
            {
                MessageBox.Show("Plz. select department and try again."); return;
            }


            if (txtMedia.Tag != null)
            {
                _MediaId = Convert.ToInt32(txtMedia.Tag);
            }


            if (txtPackage.Tag != null)
            {
                HpPackage _Pkg = (HpPackage)txtPackage.Tag;
                _PackageId = _Pkg.PkgId;
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

                    long.TryParse(txtPrevBillNo.Tag.ToString(), out _admissionId);
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_admissionId);

                    ViewAdmissionForm(_pInfo);

                }
                else
                {


                    cmdSave.Enabled = false;
                    cmdSave.Text = "Pz. Wait.";

                    double _admissionFee = 0;
                    double.TryParse(txtAdmissionFee.Text, out _admissionFee);
                    long.TryParse(txtRegNo.Text, out _regNo);


                    long.TryParse(txtBillNo.Text, out _billNo);
                    HospitalPatientInfo _hpInfo = new HospitalService().GetIPDInfoByBillNo(_billNo);
                    if (_hpInfo != null) txtBillNo.Text = GetNewBillNo();
                    long.TryParse(txtBillNo.Text, out _billNo);

                    HospitalPatientInfo _patientInfo = new HospitalPatientInfo();

                    RegRecord _regTracker = GetRegNoLong();

                    _patientInfo.RegNo = _regTracker.RegNo;
                    _patientInfo.BillNo = 0;
                    _patientInfo.AgeYear = txtYears.Text;
                    _patientInfo.AgeMonth = txtMonths.Text;
                    _patientInfo.AgeDay = txtDays.Text;


                    _patientInfo.AddmissionDate = Utils.GetServerDateAndTime();
                    _patientInfo.Time = txtAdmissionTime.Text;
                    _patientInfo.AssignDoctorId = ((Doctor)txtAssignDoctor.Tag).DoctorId;
                    _patientInfo.RefdDoctorId = ((Doctor)txtRefdby.Tag).DoctorId;
                    _patientInfo.MediaId = _MediaId;
                    _patientInfo.WardOrCabinId = Convert.ToInt32(cmbCabinOrOther.SelectedValue);

                    _patientInfo.CabinOrWardBedDisplayString = GetCabinBedDisplayString();
                    _patientInfo.Admittedby = MainForm.LoggedinUser.Name;
                    _patientInfo.DeptId = _dept.DeptId;
                    _patientInfo.PackageId = _PackageId;
                    _patientInfo.Status = "Cabin";

                    _admissionId = new HospitalService().SaveHospitalPatientInfo(_patientInfo);

                    if (_admissionId > 0)
                    {
                        CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_cabinId);
                        _cabin.IsBooked = true;
                        new HospitalCabinBedService().UpdateCabinInfo(_cabin);

                        HpPatientAccomodationInfo _currentAccomodation = new HpPatientAccomodationInfo();
                        _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                        _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
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
            }
            else
            {
                MessageBox.Show(msg + " required.");
            }
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

        private RegRecord GetRegNoLong()
        {
            long _regNo = 0;

            long.TryParse(txtRegNo.Text, out _regNo);

            if (_regNo > 0)
            {
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
                if (_record != null)
                {
                    return _record;
                }
                else
                {
                    RegRecord _recorgd = GetNewRegRecord();

                    return _recorgd;
                }

            }
            else
            {

                RegRecord _record = GetNewRegRecord();

                return _record;

            }
        }

        private RegRecord GetNewRegRecord()
        {

            int _slefAreaId = 0;
            int _localGurdianAreaId = 0;
            int _chamberPractitionerId = 0;
            int _refdbyId = 0;


            UpazilaOrArea _upAreaSelf = (UpazilaOrArea)cmbAreaOrThana.SelectedItem;
            if (_upAreaSelf != null)
            {
                _slefAreaId = _upAreaSelf.UpazilaId;
            }

            UpazilaOrArea _upAreaLG = (UpazilaOrArea)cmbLocalGurdianThana.SelectedItem;
            if (_upAreaLG != null)
            {
                _localGurdianAreaId = _upAreaLG.UpazilaId;
            }

            int _refdId = 0;
            if (txtRefdby.Tag != null)
            {
                Doctor _doc = (Doctor)txtRefdby.Tag;
                _refdId = _doc.DoctorId;
            }

            RegRecord _regRecord = new RegRecord();
            _regRecord.RegNo = 0;
            _regRecord.FullName = txtPatientName.Text;
            _regRecord.AgeYear = txtYears.Text;
            _regRecord.AgeMonth = txtMonths.Text;
            _regRecord.AgeDay = txtDays.Text;
            _regRecord.Sex = cmbGender.Text;
            _regRecord.MobileNo = txtphoneNumbersNE.Text;
            _regRecord.EmailId = txtEmailAddress.Text;
            _regRecord.FatherName = txtFatherName.Text;
            _regRecord.MotherName = txtMotherName.Text;
            _regRecord.HouseNo = txtHouseNo.Text;
            _regRecord.RoadNo = txtRoadNo.Text;
            _regRecord.Village = txtVillage.Text;
            _regRecord.PO = txtPO.Text;
            _regRecord.CareOf = txtCareOf.Text;

            _regRecord.PatientAddress = Utils.GetPatientAddress(txtCareOf.Text, txtHouseNo.Text, txtRoadNo.Text, txtVillage.Text, txtPO.Text, cmbDistricts.Text, cmbAreaOrThana.Text);

            _regRecord.NationalId = txtNationalId.Text;
            _regRecord.ContactPerson = txtLocalGurdianName.Text;
            _regRecord.CPHouseNo = txtLocalGurdianHouseNo.Text;
            _regRecord.CPRoadNo = txtLocalGurdianRoadNo.Text;
            _regRecord.CPVillage = txtLocalGurdianVillage.Text;
            _regRecord.CPPo = txtLocalGurdianPO.Text;
            _regRecord.CPMobile = txtContactPersonNumber.Text;
            _regRecord.RelationWithPatient = cmbRelationshipWithPatient.Text;
            _regRecord.CPAddress = Utils.GetPatientAddress("", txtLocalGurdianHouseNo.Text, txtLocalGurdianRoadNo.Text, txtLocalGurdianVillage.Text, txtLocalGurdianPO.Text, cmbLocalGurdianDistrict.Text, cmbLocalGurdianThana.Text);
            _regRecord.CompanyId = 0;
            _regRecord.Status = "";
            _regRecord.DesignationId = 0;
            _regRecord.MaritalStatus = cmbMaritalStatus.Text;
            _regRecord.Profession = cmbOccupation.Text;
            _regRecord.UpazilaOrAreaId = _slefAreaId;
            _regRecord.LocalGurdianUpazilaOrAreaId = _localGurdianAreaId;
            _regRecord.UnionId = 0;
            _regRecord.BloodGroup = cmbBloodGroup.Text;
            _regRecord.CpId = _chamberPractitionerId;
            _regRecord.Referredby = _refdbyId;
            _regRecord.Discount = 0;
            _regRecord.NoOfSons = "";
            _regRecord.NoOfDaughters = "";

            _regRecord.DOB = GetDob();
            _regRecord.RegDate = Utils.GetServerDateAndTime();
            _regRecord.RefdId = 0;

            RegRecord _record = new RegRecordService().SaveRegRecord(_regRecord);

            _record = new RegRecordService().GetRegRecordById(_record.Id);

            return _record;
        }

        private RegUniqueKeyTracker GetNewRegNo()
        {

            RegUniqueKeyTracker _regTracker = new RegRecordService().GetRegUniqueKey(MainForm.WorkStationId, Utils.GetServerDateAndTime().ToString("yy"), Utils.GetServerDateAndTime().Month);

            if (_regTracker == null)
            {

                new RegRecordService().GenerateRegKey(MainForm.LoggedinUser.Name, MainForm.WorkStationId, "", 250, Convert.ToInt32(Configuration.ORG_CODE));

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

            _admf.SetParameterValue("Admittedby", "(" + _user.FullName + ")");

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
                cmbGender.Text = _record.Sex;
                txtFatherName.Text = _record.FatherName;
                txtMotherName.Text = _record.MotherName;
                // txtAddress.Text= _record.Address;
                txtContactPersonNumber.Text = _record.MobileNo;
                cmbOccupation.Text = _record.Profession;
                //txtSpouseName.Text = _record.SpouseName;
                //txtL.Text = _record.ContactPerson;
                cmbRelationshipWithPatient.Text = _record.RelationWithPatient;
                // txtMobile.Text = _record.CPMobile;
                txtLocalGurdianHouseNo.Text = _record.CPHouseNo;

            }

            txtPrevBillNo.Text = _pInfo.BillNo.ToString();
            txtPrevBillNo.Tag = _pInfo.AdmissionId;

            // cmdSave.Text = "Update";
            lblPStatus.Text = _pInfo.Status;

            txtYears.Text = _pInfo.AgeYear.ToString();
            txtMonths.Text = _pInfo.AgeMonth.ToString();
            txtDays.Text = _pInfo.AgeDay.ToString();


            cmbAdmittedTo.Text = "Cabin";
            List<CabinInfo> _cabinList = new HospitalCabinBedService().GetCabinList();
            _cabinList.Insert(0, new CabinInfo { CabinId = 0, Description = "Select Cabin", Rent = 0 });
            cmbCabinOrOther.DataSource = _cabinList;
            cmbCabinOrOther.DisplayMember = "Description";
            cmbCabinOrOther.ValueMember = "CabinId";



            cmbCabinOrOther.SelectedItem = _cabinList.Find(q => q.CabinId == _pInfo.WardOrCabinId);


            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });
            cmbDepartment.DataSource = _deptList;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "DeptId";

            cmbDepartment.SelectedItem = _deptList.Find(q => q.DeptId == _pInfo.DeptId);


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
            cmbGender.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtHouseNo.Text = "";
            txtYears.Text = "";
            txtMonths.Text = "";
            txtDays.Text = "";

            txtLocalGurdianHouseNo.Text = "";
            txtLocalGurdianRoadNo.Text = "";
            txtLocalGurdianVillage.Text = "";
            txtLocalGurdianPO.Text = "";
            txtContactPersonNumber.Text = "";
            cmbRelationshipWithPatient.Text = "";
            txtLocalGurdianName.Text = "";
            txtEmailAddress.Text = "";
            cmbOccupation.Text = "";
            txtNationalId.Text = "";
            cmbCabinOrOther.Text = "";
            txtPackage.Text = "";

            txtRefdby.Text = "";
            txtAssignDoctor.Text = "";
            txtRefdby.Tag = null;
            txtAssignDoctor.Tag = null;

            txtPackage.Tag = null;
            cmdSave.Text = "Save";


        }

        private string ValidateEntry()
        {
            string _msg = string.Empty;

            if (String.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                _msg = "Patient Name";
            }

            return _msg;

        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTitle.Text.ToLower() == "mr." || cmbTitle.Text.ToLower() == "md.")
            {
                cmbGender.Text = "Male";
            }
            else if (cmbTitle.Text.ToLower() == "miss." || cmbTitle.Text.ToLower() == "mst." || cmbTitle.Text.ToLower() == "ms" || cmbTitle.Text.ToLower() == "mrs.")
            {
                cmbGender.Text = "Female";
            }
        }

        private void cmbTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtPatientName.Focus();

            }
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
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

                txtFatherName.Focus();

            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                dtpDOB.Focus();

            }
        }

        private void dtpDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtMotherName.Focus();

            }
        }

        private void txtMotherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                cmbOccupation.Focus();

            }
        }

        private void cmbOccupation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cmbMaritalStatus.Focus();

            }
        }

        private void cmbMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cmbBloodGroup.Focus();

            }
        }

        private void cmbBloodGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtNationalId.Focus();

            }
        }

        private void txtNationalId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                txtCareOf.Focus();

            }
        }

        private void txtCareOf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                txtphoneNumbersNE.Focus();

            }
        }

        private void cmbAdmittedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                HpDepartment _dept = (HpDepartment)cmbDepartment.SelectedItem;

                if (_dept.DeptId == 0) { MessageBox.Show("Plz. select department and try again."); return; }


                HpPatientAccomodationType _accomType = (HpPatientAccomodationType)cmbAdmittedTo.SelectedItem;

                List<CabinInfo> _cabinList = new HospitalCabinBedService().GetAccomodationList(_accomType.AccomodationTypeId, _dept.DeptId);
                _cabinList.Insert(0, new CabinInfo { CabinId = 0, Description = "--Select Cabin--", Rent = 0 });

                cmbCabinOrOther.DataSource = _cabinList;
                cmbCabinOrOther.DisplayMember = "CabinNo";
                cmbCabinOrOther.ValueMember = "CabinId";

                cmbCabinOrOther.SelectedItem = _cabinList.Find(q => q.CabinId == 0);
            }
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

        private void txtAssignDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlAssignedDoctor.Visible = true;
                ctlAssignedDoctor.LoadData();
            }
        }

        private void txtMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlMediaSearchControl.Visible = true;
                ctlMediaSearchControl.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
            ctlAssignedDoctor.Visible = false;
            ctlMediaSearchControl.Visible = false;

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

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            // txtRegNo.Text = GetNewRegNo();
            ClearFields();
            txtRegNo.Tag = null;

            txtPrevBillNo.Tag = null;

            LoadCabinList();
        }

        private void btnCabinList_Click(object sender, EventArgs e)
        {
            frmCabinList _frm = new frmCabinList();
            _frm.Show();
        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(18, 12);

            isInMaxView = true;

            btnMaxView.Visible = false;
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(pnlPatient.Location.X + 1280, pnlPatient.Location.Y);

            isInMaxView = false;

            btnMaxView.Visible = true;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            List<VMIPDInfo> _Plist = await LoadPatients();

            FillListGrid(_Plist);
        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPatientName.Text)) return;

            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
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
