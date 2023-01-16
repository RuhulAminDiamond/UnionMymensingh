using CrystalDecisions.Windows.Forms;
using DSBarCode;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
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
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Location;
using Itenso.TimePeriod;
using HDMS.Model.Marketing;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmAdmission : Form
    {

        BarCodeCtrl _control = new BarCodeCtrl();
        bool isLoaded = false;
        bool isInMaxView = true;
        bool unlocked = true;

        public frmAdmission()
        {
            InitializeComponent();
        }

        private IList<RegUniqueKeyTracker> _ukeyList;

        private async void frmAdmission_Load(object sender, EventArgs e)
        {
            isLoaded = false;
            HideAllDefaultHidden();

            pnlPatient.Location = new Point(12, 10);
            pnlPatient.Size = new Size(1338, 679);

            ctlDoctorSearch.Location = new Point(txtRefdby.Location.X, txtRefdby.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;


            ctlAssignedDoctor.Location = new Point(txtAssignDoctor.Location.X, txtAssignDoctor.Location.Y);
            ctlAssignedDoctor.ItemSelected += ctlAssignedDoctor_ItemSelected;

            MarketingAgentSearchControl.Location = new Point(txtMarketingAgent.Location.X, txtMarketingAgent.Location.Y);
            MarketingAgentSearchControl.ItemSelected += MarketingAgentSearchControl_ItemSelected;

            ctrlHpPackageSearchControl.Location = new Point(txtPackage.Location.X, txtPackage.Location.Y);
            ctrlHpPackageSearchControl.ItemSelected += ctrlHpPackageSearchControl_ItemSelected;

            ctrlCorporateClient.Location = new Point(txtCorporateClient.Location.X, txtCorporateClient.Location.Y);
            ctrlCorporateClient.ItemSelected += ctrlCorporateClient_ItemSelected;


            ctlMediaSearchControl.Location = new Point(txtMedia.Location.X, txtMedia.Location.Y);
            ctlMediaSearchControl.ItemSelected += ctlMediaSearchControl_ItemSelected;


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

            LoadDistricts(0);

            LoadOccupation();

            LoadLocalGurdianDistricts(0);

            LoadRelationWithPatient();

            

            List<VMIPDInfo> _Plist = await LoadPatients();

            dgPatient.Tag = _Plist;

            btnAdmissionCancel.Tag = _Plist;

            FillListGrid(_Plist);

            isLoaded = true;

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if(_user.UserId==1 || _user.UserId==2)
            {
                btnAdmissionCancel.Enabled = true;
            }
            else
            {
                btnAdmissionCancel.Enabled = false;
            }

        }

        private void ctlMediaSearchControl_ItemSelected(SearchResultListControl<BusinessMedia> sender, BusinessMedia item)
        {
            txtMedia.Text = item.Name;
            txtMedia.Tag = item;
            cmbDepartment.Focus();
            sender.Visible = false;
        }

        private void LoadRelationWithPatient()
        {
            //List<Relation> OccupationList = new CommonService().GetRelations();
            //OccupationList.Insert(0, new Relation() { Id = 0, Name = "Select Relation" });
            //cmbRelationshipWithPatient.DataSource = OccupationList;
            //cmbRelationshipWithPatient.DisplayMember = "Name";
            //cmbRelationshipWithPatient.ValueMember = "Id";
            //isLoaded = true;
        }

        private void MarketingAgentSearchControl_ItemSelected(SearchResultListControl<MarketingAgent> sender, MarketingAgent item)
        {
            unlocked = false;
            txtMarketingAgent.Text = item.Name;
            txtMarketingAgent.Tag = item;
            unlocked = true;
            sender.Visible = false;
            txtCorporateClient.Focus();
        }


        private void ctrlCorporateClient_ItemSelected(SearchResultListControl<CorporateClient> sender, CorporateClient item)
        {
            unlocked = false;
            txtCorporateClient.Text = item.Name;
            txtCorporateClient.Tag = item;
            unlocked = true;
            sender.Visible = false;
            cmbDepartment.Focus();
        }

        private  void LoadOccupation()
        {
            List<Occupation> OccupationList =  new CommonService().GetAllOccupations();
            OccupationList.Insert(0, new Occupation() { Id = 0, Name = "Select Occupation" });
            cmbOccupation.DataSource = OccupationList;
            cmbOccupation.DisplayMember = "Name";
            cmbOccupation.ValueMember = "Id";
            isLoaded = true;
        }

        private async void LoadDistricts(int districtId)
        {
            List<District> _districtList = await new CommonService().GetAllDistricts();
            _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

            cmbDistricts.DataSource = _districtList;
            cmbDistricts.DisplayMember = "Name";
            cmbDistricts.ValueMember = "DistrictId";

            if (districtId > 0)
            {
                cmbDistricts.SelectedItem = _districtList.Find(x => x.DistrictId == districtId);
            }


            isLoaded = true;
        }

        private async void LoadLocalGurdianDistricts(int districtId)
        {
            List<District> _districtList = await new CommonService().GetAllDistricts();
            _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

            cmbLocalGurdianDistrict.DataSource = _districtList;
            cmbLocalGurdianDistrict.DisplayMember = "Name";
            cmbLocalGurdianDistrict.ValueMember = "DistrictId";

            if (districtId > 0)
            {
                cmbLocalGurdianDistrict.SelectedItem = _districtList.Find(x => x.DistrictId == districtId);
            }

            isLoaded = true;
        }

        private async Task<List<VMIPDInfo>> LoadPatients()
        {

            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfoForDischarge();

            return _lisPatientInfo;
        }

        private void ctrlHpPackageSearchControl_ItemSelected(SearchResultListControl<HpPackage> sender, HpPackage item)
        {
            txtPackage.Text = item.Name;
            txtPackage.Tag = item;
            //txtPackage.Text = item.PkgTotal.ToString();
            //txtPackage.Tag = item;
            sender.Visible = false;
            cmdSave.Focus();
        }

        private void LoadDepartments_2()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });
           

            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
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

        //private void LoadPatientList()
        //{
        //    List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfo().ToList();

        //    lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

        //    FillListGrid(_lisPatientInfo);

        //}

    private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
    {
        
        dgPatient.SuspendLayout();
        dgPatient.Rows.Clear();
        foreach (VMIPDInfo item in _lisPatientInfo)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Tag = item;
            row.Height = 35;
            row.CreateCells(dgPatient, item.BillNo, item.AddmissionDate.ToString("dd/MM/yyyy"), item.AdmTime, item.Name, item.BedCabinNo, item.AssignedDoctor, item.MobileNo,item.CPAddress, item.Status);
            dgPatient.Rows.Add(row);
        }

         lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

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
            unlocked = false;
            txtAssignDoctor.Text = item.Name;
            txtAssignDoctor.Tag = item;
            unlocked = true;
            sender.Visible = false;

            //txtAssignDoctor.Text = item.Name;
            //txtAssignDoctor.Tag = item;
            //sender.Visible = false;
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
            int _PackageId = 0;
            int _CompanyId = 0;
            //int _MAId = 0;

            int _MediaId = 0;

            HpDepartment _dept = (HpDepartment)cmbDepartment.SelectedItem;

            if (_dept.DeptId == 0)
            {
                MessageBox.Show("Plz. select department and try again."); return;
            }


            if (txtCorporateClient.Tag != null)
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeId.Text))
                {
                    MessageBox.Show("Employee ID is Reqruired");
                    return;
                }
            }



            //if (txtCorporateClient.Tag != null)
            //{
            //    CorporateClient _rx = txtCorporateClient.Tag as CorporateClient;
            //    _CompanyId = _rx.CompanyId;
            //    if(string.IsNullOrWhiteSpace(txtEmployeeId.Text))
            //    {
            //        MessageBox.Show("Please select EmployeeId and try again.");
            //        return;
            //    }
            //}


            if (txtPackage.Tag != null)
            {
                HpPackage _Pkg = (HpPackage)txtPackage.Tag;
                _PackageId = _Pkg.PkgId;
            }
            if (txtMedia.Tag != null)
            {
                BusinessMedia m = txtMedia.Tag as BusinessMedia;
                _MediaId = m.MediaId;
            }


            //if (txtMarketingAgent.Tag != null)
            //{
            //    MarketingAgent _ma = txtMarketingAgent.Tag as MarketingAgent;
            //    _MAId = _ma.MAId;
            //}


            _cabinId = Convert.ToInt32(cmbCabinOrOther.SelectedValue);
            if (_cabinId == 0)
            {
                MessageBox.Show("No cabin or bed selected"); return;
            }


            if (txtRefdby.Tag == null || txtAssignDoctor.Tag == null)
            {
                MessageBox.Show("Referred/Assigned doctor required"); return;
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
                    long.TryParse(txtRegNo.Text, out _regNo);


                    long.TryParse(txtBillNo.Text, out _billNo);
                    HospitalPatientInfo _hpInfo = new HospitalService().GetIPDInfoByBillNo(_billNo);
                    if (_hpInfo != null) txtBillNo.Text = GetNewBillNo();
                    // long.TryParse(txtBillNo.Text, out _billNo);

                    HospitalPatientInfo _patientInfo = new HospitalPatientInfo();

                    RegRecord _regTracker = GetRegNoLong();

                    _patientInfo.RegNo = _regTracker.RegNo;
                    _patientInfo.BillNo = 0;
                    _patientInfo.AgeYear = txtYears.Text;
                    _patientInfo.AgeMonth = txtMonths.Text;
                    _patientInfo.AgeDay = txtDays.Text;
                    if (cmbClientType.SelectedIndex > -1)
                    _patientInfo.AddmissionDate = Utils.GetServerDateAndTime();
                    _patientInfo.Time = txtAdmissionTime.Text;
                    _patientInfo.AssignDoctorId = ((Doctor)txtAssignDoctor.Tag).DoctorId;
                    _patientInfo.RefdDoctorId = ((Doctor)txtRefdby.Tag).DoctorId;
                    //_patientInfo.MediaId = _MAId;
                    _patientInfo.MediaId = _MediaId;
                    // _patientInfo.CompanyId = _CompanyId;
                    _patientInfo.WardOrCabinId = Convert.ToInt32(cmbCabinOrOther.SelectedValue);

                    _patientInfo.CabinOrWardBedDisplayString = GetCabinBedDisplayString();
                    _patientInfo.Admittedby = MainForm.LoggedinUser.Name;
                    _patientInfo.DeptId = _dept.DeptId;

                    //_patientInfo.EmployeeId = txtEmployeeId.Text;
                    _patientInfo.PackageId = _PackageId;
                    _patientInfo.Status = "Cabin";
                    _patientInfo.PharmacyClearance = "";
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
            }else
            {
                MessageBox.Show(msg+" required.");
            }
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

            int _patientDistrictId = 0;
            int _patientAreaId = 0;
            int _localGDistrictId = 0;
            int _localGurdianAreaId = 0;

            UpazilaOrArea _upAreaSelf = (UpazilaOrArea)cmbAreaOrThana.SelectedItem;
            if (_upAreaSelf != null && _upAreaSelf.UpazilaId > 0)
            {
                _patientAreaId = _upAreaSelf.UpazilaId;
            }

            District _patientdistrict = cmbDistricts.SelectedItem as District;
            if (_patientdistrict != null && _patientdistrict.DistrictId > 0)
            {
                _patientDistrictId = _patientdistrict.DistrictId;
            }

            UpazilaOrArea _upAreaLG = (UpazilaOrArea)cmbLocalGurdianThana.SelectedItem;
            if (_upAreaLG != null)
            {
                _localGurdianAreaId = _upAreaLG.UpazilaId;
            }

            District _LGtdistrict = cmbLocalGurdianDistrict.SelectedItem as District;
            if (_LGtdistrict != null && _LGtdistrict.DistrictId > 0)
            {
                _localGDistrictId = _LGtdistrict.DistrictId;
            }

            int _refdId = 0;
            if (txtRefdby.Tag != null)
            {
                Doctor _doc = (Doctor)txtRefdby.Tag;
                _refdId = _doc.DoctorId;
            }

            int CompanyId=0;
            if (txtCorporateClient.Tag != null)
            {
                CorporateClient _cclient= txtCorporateClient.Tag as CorporateClient;

                CompanyId = _cclient.CompanyId;
            }


            RegRecord _regRecord = new RegRecord();
            _regRecord.RegNo = 0;
            _regRecord.Title = cmbTitle.Text;
            _regRecord.FirstName = ""; //txt1stName.Text;
            _regRecord.MiddleName = ""; //txtMiddleName.Text;
            _regRecord.LastName = ""; //txtLastName.Text;
            _regRecord.FullName = txtPatientName.Text;
            _regRecord.AgeYear = txtYears.Text;
            _regRecord.AgeMonth = txtMonths.Text;
            _regRecord.AgeDay = txtDays.Text;
            _regRecord.DOB = dtpDOB.Value;
            _regRecord.Sex = cmbGender.Text;
            _regRecord.FatherName = txtFatherName.Text;
            _regRecord.MotherName = txtMotherName.Text;
            _regRecord.CareOf = txtCareOf.Text;
            _regRecord.HouseNo = txtHouseNo.Text;
            _regRecord.RoadNo = txtRoadNo.Text;
            _regRecord.Village = txtVillage.Text;
            _regRecord.PO = txtPO.Text;
            _regRecord.PatientAddress = txtPatientAddress.Text;
            _regRecord.MobileNo = txtPatientContactNumbers.Text;
            _regRecord.NationalId = txtNationalId.Text;
            _regRecord.ContactPerson = txtLocalGurdianName.Text;

            _regRecord.CPMobile = txtContactPersonNumber.Text;
            _regRecord.CPHouseNo = txtLocalGurdianHouseNo.Text;
            _regRecord.CPRoadNo = txtLocalGurdianRoadNo.Text;
            _regRecord.CPVillage = txtLocalGurdianVillage.Text;
            _regRecord.CPPo = txtLocalGurdianPO.Text;
            _regRecord.CPAddress = txtGuardianAddress.Text;
            _regRecord.RelationWithPatient = cmbRelationshipWithPatient.Text;
            _regRecord.CompanyId = CompanyId;
            _regRecord.MaritalStatus = cmbMaritalStatus.Text;
            _regRecord.Profession = cmbOccupation.Text;
            _regRecord.UnionId = 0;
            _regRecord.BloodGroup = cmbBloodGroup.Text;
            _regRecord.RegDate = Utils.GetServerDateAndTime();
            _regRecord.RefdId = _refdId;
            _regRecord.IsRegisterd = true;

            RegRecord _record = new RegRecordService().SaveRegRecord(_regRecord);

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

            _admf.SetParameterValue("PrintedBy", MainForm.LoggedinUser.Name);

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
                 txtMonths.Text= _pInfo.AgeMonth.ToString();
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


            //Doctor _assigDoc = new DoctorService().GetDoctorById(_pInfo.AssignDoctorId);

            unlocked = false;

            Doctor _d = new DoctorService().GetDoctorById(_pInfo.RefdDoctorId);
            txtRefdby.Text = _d.Name;
            txtRefdby.Tag = _d;
            txtRefdby.Enabled = true;

            unlocked = true;


            
           unlocked = false;

            Doctor _assigDoc = new DoctorService().GetDoctorById(_pInfo.AssignDoctorId);
            txtAssignDoctor.Text = _assigDoc.Name;
            txtAssignDoctor.Tag = _assigDoc;
            txtAssignDoctor.Enabled = true;

            unlocked = true;


        }

        private void ClearFields()
        {
            txtPatientName.Text = "";
            txtFatherName.Text = "";
            txtPatientName.Text = "";
            cmbGender.Text =  "";
            txtFatherName.Text =  "";
            txtMotherName.Text = "";
            txtHouseNo.Text = "";
            txtYears.Text = "";
            txtMonths.Text = "";
            txtDays.Text = "";
            txtCorporateClient.Text = "";
            txtCorporateClient.Tag = null;
            txtEmployeeId.Text = "";

            txtLocalGurdianHouseNo.Text = "";
            txtLocalGurdianRoadNo.Text = "";
            txtLocalGurdianVillage.Text = "";
            txtLocalGurdianPO.Text = "";
            txtContactPersonNumber.Text = "";
            cmbRelationshipWithPatient.Text="";
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

            txtMarketingAgent.Text = "";
            txtMarketingAgent.Tag = null;

            txtPackage.Tag = null;
            cmdSave.Text = "Save";
            

        }

        private string ValidateEntry()
        {
            string msg = string.Empty;
         
            if(String.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                msg = "Patient Name ";
            }
            //if(string.IsNullOrWhiteSpace(txtLocalGurdianHouseNo.Text))
            //{
            //    msg += "Local Guardian House No ";
            //}
            //if (string.IsNullOrWhiteSpace(txtLocalGurdianName.Text))
            //{
            //    msg += "Local Guardian Name ";
            //}
            //if (string.IsNullOrWhiteSpace(txtLocalGurdianPO.Text))
            //{
            //    msg += "Local Guardian PO ";
            //}
            //if (string.IsNullOrWhiteSpace(txtLocalGurdianRoadNo.Text))
            //{
            //    msg += "Local Guardian Road No ";
            //}
            //if (string.IsNullOrWhiteSpace(txtLocalGurdianVillage.Text))
            //{
            //    msg += "Local Guardian Village ";
            //}
            //if (string.IsNullOrWhiteSpace(txtContactPersonNumber.Text))
            //{
            //    msg += "Local Guardian Mobile No ";
            //}
            //if (string.IsNullOrWhiteSpace(cmbRelationshipWithPatient.Text))
            //{
            //    msg += "Local Guardian Relation ";
            //}
            //if (string.IsNullOrWhiteSpace(cmbLocalGurdianDistrict.Text))
            //{
            //    msg += "Local Guardian District ";
            //}
            //if (string.IsNullOrWhiteSpace(cmbLocalGurdianThana.Text))
            //{
            //    msg += "Local Guardian Thana ";
            //}
            return msg;

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
            txtRegNo.Text = _patient.RegNo.ToString();
          
         
            txtAssignDoctor.Text = _patient.AssignDoctorId.ToString();
            //cmbOccupation.Text = _patient.Occupation;
           
            
           
        }

        private void cmdNxt_Click(object sender, EventArgs e)
        {
            HospitalPatientInfo _patient;
            if (txtRegNo.Tag == null)
            {
                _patient = new HospitalService().GetHospitalPatientInfoById(new HospitalService().GetFirstPatientById().AdmissionId);
                 txtRegNo.Tag = _patient;

            }
            else
            {
                _patient = new HospitalService().GetHospitalPatientInfoById(((HospitalPatientInfo)txtRegNo.Tag).AdmissionId + 1);
                txtRegNo.Tag = _patient;

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
            txtRegNo.Tag = null;

            txtPrevBillNo.Tag = null;

            LoadCabinList();
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
                    MessageBox.Show("RegNo not found. Please check and try again.");
                }

                if (_record != null)
                {
                    txtRegNo.Tag = _record;
                    // LoadBarcode();
                    //txtRefBy.Focus();
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
                //CorporateClient client = new RegRecordService().GetCorporateClient(_record.CompanyId);
                //if (client != null)
                //{
                //    unlocked = false;
                //    txtCorporateClient.Text = client.Name;
                //    txtCorporateClient.Tag = client;

                //   // txtEmployeeId.Text = _record.EmployeeId;

                //    unlocked = true;
                //}
                txtFatherName.Text = _record.FatherName;
                txtMotherName.Text = _record.MotherName;
                txtSpouse.Text = _record.SpouseName;
               
                cmbMaritalStatus.Text = _record.MaritalStatus;
                cmbOccupation.Text = _record.Profession;
                txtPatientContactNumbers.Text = _record.MobileNo;
                cmbBloodGroup.Text = _record.BloodGroup;
                //txtEmailAddress.Text = _record.Email;
               
                txtNationalId.Text = _record.NationalId;

               // txtEmployeeId.Text = _record.EmployeeId;

                txtHouseNo.Text = _record.HouseNo;
                txtRoadNo.Text = _record.RoadNo;
                txtVillage.Text = _record.Village;
                txtPO.Text = _record.PO;
                txtCareOf.Text = _record.CareOf;

                txtLocalGurdianName.Text = _record.CPName;
                txtLocalGurdianHouseNo.Text = _record.CPHouseNo;
                txtLocalGurdianRoadNo.Text = _record.CPRoadNo;
                txtLocalGurdianVillage.Text = _record.CPVillage;
                txtLocalGurdianPO.Text = _record.CPPo;
               
                cmbRelationshipWithPatient.Text = _record.RelationWithPatient;
                txtContactPersonNumber.Text = _record.CPMobile;

                //if (_record.DistrictId > 0) LoadDistricts(_record.DistrictId);

                //if (_record.CPDistrictId > 0) LoadLocalGurdianDistricts(_record.CPDistrictId);

                //if (_record.ArearOrThanaId > 0) LoadPatientDistricstsThana(_record.DistrictId, _record.ArearOrThanaId);

                //if (_record.CPArearOrThanaId > 0) LoadLGDistricstsThana(_record.CPDistrictId, _record.CPArearOrThanaId);

                txtPatientAddress.Text = _record.PatientAddress;
                txtGuardianAddress.Text = _record.CPAddress;

                picMember.Image = Utils.GetProfileImage(_record.RegNo);


                return true;

            }

            return false;

        }

        private void LoadLGDistricstsThana(int cPDistrictId, int cPArearOrThanaId)
        {
            List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(cPDistrictId);
            _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
            cmbLocalGurdianDistrict.DataSource = _uaList;
            cmbLocalGurdianDistrict.DisplayMember = "Name";
            cmbLocalGurdianDistrict.ValueMember = "UpazilaId";

            if (cPArearOrThanaId > 0)
            {
                cmbLocalGurdianThana.SelectedItem = _uaList.Find(x => x.UpazilaId == cPArearOrThanaId);
            }
        }

        private void LoadPatientDistricstsThana(int districtId, int arearOrThanaId)
        {
            List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(districtId);
            _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
            cmbAreaOrThana.DataSource = _uaList;
            cmbAreaOrThana.DisplayMember = "Name";
            cmbAreaOrThana.ValueMember = "UpazilaId";

            if (arearOrThanaId > 0)
            {
                cmbAreaOrThana.SelectedItem = _uaList.Find(x => x.UpazilaId == arearOrThanaId);
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
            ctrlCorporateClient.Visible = false;
            MarketingAgentSearchControl.Visible = false;

        }

        private void btnFindRefdby_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPatientName.Text)) return;

            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
        }

        void ctlDoctorSearch_ItemSelected(Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {

            unlocked = false;
            txtRefdby.Text = item.Name;
            txtRefdby.Tag = item;
            unlocked = true;
            sender.Visible = false;

            //txtRefdby.Text = item.Name;
            //txtRefdby.Tag = item;
            //sender.Visible = false;

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

            _control.BarCode = txtRegNo.Text.Aggregate(string.Empty, (c, i) => c + i + ' ');
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

       

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCabinList_Click(object sender, EventArgs e)
        {
            frmCabinList _cabiblist = new frmCabinList();
            _cabiblist.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtAdmissionTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            
                pnlPatient.Location = new Point(pnlPatient.Location.X + 1300, pnlPatient.Location.Y);

                isInMaxView = false;

                 btnMaxView.Visible = true;
            
        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(12, 10);

            isInMaxView = true;

            btnMaxView.Visible = false;
        }

        private void cmbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoByDept(Convert.ToInt32(cmbDept.SelectedValue)).ToList();

                lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

                FillListGrid(_lisPatientInfo);
            }
        }

        private  async void btnRefresh_Click(object sender, EventArgs e)
        {
            List<VMIPDInfo> _Plist = await LoadPatients();

            FillListGrid(_Plist);
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);
                btnAdmissionCancel.Tag = _pInfo;

                HospitalPatientInfo _HPpInfo = new HospitalService().GetHospitalPatientByBillNo(_pInfo.BillNo);


                if (_pInfo == null)
                {
                    return;
                }


              //  ViewAdmissionForm(_HPpInfo);


            }
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
            if (txtName.Text.Trim() == "Search by name")
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
            List<VMIPDInfo> _lisPatientInfo = dgPatient.Tag as List<VMIPDInfo>;  //new HospitalService().GetCurrentIPDInfoBySearchParameter(_prefix, type).ToList();
            if (!string.IsNullOrEmpty(_prefix.Trim()))
            {
                if (type.Equals("PName"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.Name.ToLower().Contains(_prefix.Trim().ToLower())).ToList();

                if (type.Equals("Cabin"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.BedCabinNo.ToLower().Contains(_prefix.Trim().ToLower())).ToList();

                if (type.Equals("Admid"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.BillNo.ToString().Contains(_prefix.Trim().ToLower())).ToList();

                if (type.Equals("Assigndoc"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.AssignedDoctor.ToLower().Contains(_prefix.Trim().ToLower())).ToList();

                if (type.Equals("RefdDoc"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.RefDoctor.ToLower().Contains(_prefix.Trim().ToLower())).ToList();


                if (type.Equals("MobileNo"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.CPMobile.ToLower().Contains(_prefix.Trim().ToLower())).ToList();

                if (type.Equals("Address"))
                    _lisPatientInfo = _lisPatientInfo.Where(x => x.PatientAddress.ToLower().Contains(_prefix.Trim().ToLower())).ToList();

                //if (type.Equals("CareOf"))
                //    _lisPatientInfo = _lisPatientInfo.Where(x => x.MediaName.ToLower().Contains(_prefix.Trim().ToLower())).ToList();

            }

            if (_lisPatientInfo == null || _lisPatientInfo.Count() == 0) return;

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            lblTotalPatient.Tag = _lisPatientInfo;

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

                LoadPatientsDatabyName(txtSearchByCabin.Text, "Cabin");
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

                LoadPatientsDatabyName(txtAdmId.Text, "Admid");
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

                LoadPatientsDatabyName(txtSearchByAssignDoc.Text, "Assigndoc");
            }
        }

        private void cmdNxt_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByMobile.Text.Trim() == "Search by Mobile No")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByMobile.Text, "MobileNo");
            }
        }

        private void txtSearchByAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByAddress.Text.Trim() == "Search by Address")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByAddress.Text, "Address");
            }
        }

        private void dgPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        

        private void ctlAssignedDoctor_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtAssignDoctor.Text = string.Empty;
                txtAssignDoctor.Focus();
            }
        }

        private void ctlDoctorSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtRefdby.Text = string.Empty;
                txtRefdby.Focus();
            }
        }

        private void txtMedia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {

            string _deptName = string.Empty;

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;


            if (_dept.DeptId == 0)
            {
                _deptName = "All";
            }
            else
            {
                _deptName = _dept.Name;
            }

            DataSet ds = new ReportService().GetHpAdmittedPatientList(_dept.DeptId);

            ReportViewer rv = new ReportViewer();
            rptHpAdmittedPatientList _rpt = new rptHpAdmittedPatientList();

            _rpt.SetDataSource(ds.Tables[0]);
            _rpt.SetParameterValue("datefrm", "");
            _rpt.SetParameterValue("dateto", "");
            _rpt.SetParameterValue("department", _deptName);


            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtPackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlHpPackageSearchControl.Visible = true;
                ctrlHpPackageSearchControl.LoadData();
            }
        }

        private void ctrlHpPackageSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtPackage.Text =string.Empty;
                txtPackage.Focus();
            }
        }

        private void cmbDistricts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                District _dist = (District)cmbDistricts.SelectedItem;


                List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(_dist.DistrictId);
                _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
                cmbAreaOrThana.DataSource = _uaList;
                cmbAreaOrThana.DisplayMember = "Name";
                cmbAreaOrThana.ValueMember = "UpazilaId";

                if (cmbAreaOrThana.SelectedIndex == 0)
                {
                    if (IsCityAddress)
                    {
                        SetCityAddress(txtHouseNo.Text, txtRoadNo.Text, "", _dist.Name);
                    }
                    else
                    {
                        SetVillageAddress(txtVillage.Text, txtPO.Text, "", _dist.Name);
                    }
                }
                else
                {
                    if (IsCityAddress)
                    {
                        SetCityAddress(txtHouseNo.Text, txtRoadNo.Text, cmbAreaOrThana.Text, _dist.Name);
                    }
                    else
                    {
                        SetVillageAddress(txtHouseNo.Text, txtRoadNo.Text, cmbAreaOrThana.Text, _dist.Name);
                    }
                }
            }
        }

        private void cmbLocalGurdianDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                District _dist = cmbLocalGurdianDistrict.SelectedItem as District;

                if (_dist == null) return;

                List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(_dist.DistrictId);
                _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
                cmbLocalGurdianThana.DataSource = _uaList;
                cmbLocalGurdianThana.DisplayMember = "Name";
                cmbLocalGurdianThana.ValueMember = "UpazilaId";

                if (cmbLocalGurdianThana.SelectedIndex == 0)
                {
                    if (IsCityAddress)
                    {
                        SetLocalGurdianCityAddress(txtLocalGurdianHouseNo.Text, txtLocalGurdianRoadNo.Text, "", _dist.Name);
                    }
                    else
                    {
                        SetLocalGurdianVillageAddress(txtLocalGurdianVillage.Text, txtLocalGurdianPO.Text, "", _dist.Name);
                    }
                }
                else
                {
                    if (IsCityAddress)
                    {
                        SetCityAddress(txtHouseNo.Text, txtRoadNo.Text, cmbAreaOrThana.Text, _dist.Name);
                    }
                    else
                    {
                        SetVillageAddress(txtHouseNo.Text, txtRoadNo.Text, cmbAreaOrThana.Text, _dist.Name);
                    }
                }


            }
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTitle.Text.ToLower() == "mr." || cmbTitle.Text.ToLower() == "md." ||  cmbTitle.Text.ToLower() == "mr" || cmbTitle.Text.ToLower() == "md")
            {
                cmbGender.Text = "Male";
                //txtPatientName.Text = cmbTitle.Text;
            }
            else if (cmbTitle.Text.ToLower() == "miss." || cmbTitle.Text.ToLower() == "mst." || cmbTitle.Text.ToLower() == "ms" || cmbTitle.Text.ToLower() == "mrs" || cmbTitle.Text.ToLower() == "mrs.")
            {
                cmbGender.Text = "Female";
               // txtPatientName.Text = cmbTitle.Text+" ";
            }
        }

        private void txtCorporateClient_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtCorporateClient.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtCorporateClient.Text;
                    HideAllDefaultHidden();
                    ctrlCorporateClient.Visible = true;
                    ctrlCorporateClient.txtSearch.Text = _txt;
                    ctrlCorporateClient.txtSearch.SelectionStart = ctrlCorporateClient.txtSearch.Text.Length;

                    ctrlCorporateClient.LoadData();
                }
            }
        }

        private void ctrlCorporateClient_SearchEsacaped(bool IsEscaped)
        {
            if(IsEscaped)
            {
                txtCorporateClient.Text = string.Empty;
                txtCorporateClient.Focus();

            }
                    
        }

        private void txtRefdby_TextChanged(object sender, EventArgs e)
        {
            if(txtRefdby.Text.Length>1)
            { 
            int itemId;
            if (int.TryParse(txtRefdby.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtRefdby.Text;
                    HideAllDefaultHidden();
                    ctlDoctorSearch.Visible = true;
                    ctlDoctorSearch.txtSearch.Text = _txt;
                    ctlDoctorSearch.txtSearch.SelectionStart = ctlDoctorSearch.txtSearch.Text.Length;

                    ctlDoctorSearch.LoadData();
                }
            }

            }
        }

        private void txtAssignDoctor_TextChanged(object sender, EventArgs e)
        {

           if(txtAssignDoctor.Text.Length>1)
            { 
            int itemId;
            if (int.TryParse(txtAssignDoctor.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtAssignDoctor.Text;
                    HideAllDefaultHidden();
                    ctlAssignedDoctor.Visible = true;
                    ctlAssignedDoctor.txtSearch.Text = _txt;
                    ctlAssignedDoctor.txtSearch.SelectionStart = ctlAssignedDoctor.txtSearch.Text.Length;

                    ctlAssignedDoctor.LoadData();
                }
            }

        
        }


        }


       

        private void txtPackage_TextChanged(object sender, EventArgs e)
        {

            if(txtPackage.Text.Length>1)
            { 
            HideAllDefaultHidden();
            ctrlHpPackageSearchControl.Visible = true;
            ctrlHpPackageSearchControl.txtSearch.Text =txtPackage.Text;
            ctrlHpPackageSearchControl.txtSearch.SelectionStart = ctrlHpPackageSearchControl.txtSearch.Text.Length;
            ctrlHpPackageSearchControl.LoadData();
            }
        }

        private void txtMarketingAgent_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtMarketingAgent.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtMarketingAgent.Text;
                    HideAllDefaultHidden();
                    MarketingAgentSearchControl.Visible = true;
                    MarketingAgentSearchControl.txtSearch.Text = _txt;
                    MarketingAgentSearchControl.txtSearch.SelectionStart = MarketingAgentSearchControl.txtSearch.Text.Length;

                    MarketingAgentSearchControl.LoadData();
                }
            }
        }

        private void MarketingAgentSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
                txtMarketingAgent.Focus();
        }

        bool IsCityAddress = false;
        private void txtHouseNo_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = true;
            SetCityAddress(txtHouseNo.Text, txtRoadNo.Text, cmbAreaOrThana.Text, cmbDistricts.Text);
        }

        private void SetCityAddress(string houseNo, string roadNo, string AreaOrThana, string district)
        {
            string addSegment1 = string.Empty;
            if (!string.IsNullOrEmpty(houseNo)) addSegment1 = "House #" + houseNo;

            string addSegment2 = string.Empty;
            if (!string.IsNullOrEmpty(roadNo)) addSegment2 = "Road #" + roadNo;

            string addSegment3 = string.Empty;
            if (!string.IsNullOrEmpty(AreaOrThana)) addSegment3 = "Area/Thana: " + AreaOrThana;

            string addSegment4 = string.Empty;
            if (!string.IsNullOrEmpty(district)) addSegment4 = "District: " + district;

            string address = string.Empty;
            if (!string.IsNullOrEmpty(addSegment1)) address = addSegment1;

            if (!string.IsNullOrEmpty(addSegment2))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment2;
                }
                else
                {
                    address = addSegment2;
                }
            }

            if (!string.IsNullOrEmpty(addSegment3))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment3;
                }
                else
                {
                    address = addSegment3;
                }
            }

            if (!string.IsNullOrEmpty(addSegment4))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment4;
                }
                else
                {
                    address = addSegment4;
                }
            }

            txtPatientAddress.Text = address;

        }

        private void txtRoadNo_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = true;
            SetCityAddress(txtHouseNo.Text, txtRoadNo.Text, cmbAreaOrThana.Text, cmbDistricts.Text);
        }

        private void txtVillage_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = false;
            SetVillageAddress(txtVillage.Text, txtPO.Text, cmbAreaOrThana.Text, cmbDistricts.Text);
        }

        private void SetVillageAddress(string village, string po, string AreaorThana, string district)
        {
            string addSegment1 = string.Empty;
            if (!string.IsNullOrEmpty(village)) addSegment1 = "Village: " + village;

            string addSegment2 = string.Empty;
            if (!string.IsNullOrEmpty(po)) addSegment2 = "P.O: " + po;

            string addSegment3 = string.Empty;
            if (!string.IsNullOrEmpty(AreaorThana)) addSegment3 = "Area/Thana: " + AreaorThana;

            string addSegment4 = string.Empty;
            if (!string.IsNullOrEmpty(district)) addSegment4 = "District: " + district;

            string address = string.Empty;
            if (!string.IsNullOrEmpty(addSegment1)) address = addSegment1;

            if (!string.IsNullOrEmpty(addSegment2))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment2;
                }
                else
                {
                    address = addSegment2;
                }
            }

            if (!string.IsNullOrEmpty(addSegment3))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment3;
                }
                else
                {
                    address = addSegment3;
                }
            }

            if (!string.IsNullOrEmpty(addSegment4))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment4;
                }
                else
                {
                    address = addSegment4;
                }
            }

            txtPatientAddress.Text = address;
        }

        private void txtPO_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = false;
            SetVillageAddress(txtVillage.Text, txtPO.Text, cmbAreaOrThana.Text, cmbDistricts.Text);
        }

        private void cmbAreaOrThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpazilaOrArea _upz = (UpazilaOrArea)cmbAreaOrThana.SelectedItem;
            if (_upz.UpazilaId > 0)
            {
                if (IsCityAddress)
                {
                    SetCityAddress(txtHouseNo.Text, txtRoadNo.Text, _upz.Name, cmbDistricts.Text);
                }
                else
                {
                    SetVillageAddress(txtVillage.Text, txtPO.Text, _upz.Name, cmbDistricts.Text);
                }
            }
        }

        private void txtLocalGurdianHouseNo_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = true;
            SetLocalGurdianCityAddress(txtLocalGurdianHouseNo.Text, txtLocalGurdianRoadNo.Text, cmbLocalGurdianThana.Text, cmbLocalGurdianDistrict.Text);
        }

        private void SetLocalGurdianCityAddress(string houseNo, string roadNo, string AreaOrThana, string district)
        {
            string addSegment1 = string.Empty;
            if (!string.IsNullOrEmpty(houseNo)) addSegment1 = "House #" + houseNo;

            string addSegment2 = string.Empty;
            if (!string.IsNullOrEmpty(roadNo)) addSegment2 = "Road #" + roadNo;

            string addSegment3 = string.Empty;
            if (!string.IsNullOrEmpty(AreaOrThana)) addSegment3 = "Area/Thana: " + AreaOrThana;

            string addSegment4 = string.Empty;
            if (!string.IsNullOrEmpty(district)) addSegment4 = "District: " + district;

            string address = string.Empty;
            if (!string.IsNullOrEmpty(addSegment1)) address = addSegment1;

            if (!string.IsNullOrEmpty(addSegment2))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment2;
                }
                else
                {
                    address = addSegment2;
                }
            }

            if (!string.IsNullOrEmpty(addSegment3))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment3;
                }
                else
                {
                    address = addSegment3;
                }
            }

            if (!string.IsNullOrEmpty(addSegment4))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment4;
                }
                else
                {
                    address = addSegment4;
                }
            }

            txtGuardianAddress.Text = address;
        }


        private void SetLocalGurdianVillageAddress(string village, string po, string AreaorThana, string district)
        {
            string addSegment1 = string.Empty;
            if (!string.IsNullOrEmpty(village)) addSegment1 = "Village: " + village;

            string addSegment2 = string.Empty;
            if (!string.IsNullOrEmpty(po)) addSegment2 = "P.O: " + po;

            string addSegment3 = string.Empty;
            if (!string.IsNullOrEmpty(AreaorThana)) addSegment3 = "Area/Thana: " + AreaorThana;

            string addSegment4 = string.Empty;
            if (!string.IsNullOrEmpty(district)) addSegment4 = "District: " + district;

            string address = string.Empty;
            if (!string.IsNullOrEmpty(addSegment1)) address = addSegment1;

            if (!string.IsNullOrEmpty(addSegment2))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment2;
                }
                else
                {
                    address = addSegment2;
                }
            }

            if (!string.IsNullOrEmpty(addSegment3))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment3;
                }
                else
                {
                    address = addSegment3;
                }
            }

            if (!string.IsNullOrEmpty(addSegment4))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    address = address + ", " + addSegment4;
                }
                else
                {
                    address = addSegment4;
                }
            }

            txtGuardianAddress.Text = address;
        }

        private void txtLocalGurdianVillage_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = false;
            SetLocalGurdianVillageAddress(txtLocalGurdianVillage.Text, txtLocalGurdianPO.Text, cmbLocalGurdianThana.Text, cmbLocalGurdianDistrict.Text);
        }

        private void txtLocalGurdianPO_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = false;
            SetLocalGurdianVillageAddress(txtLocalGurdianVillage.Text, txtLocalGurdianPO.Text, cmbLocalGurdianThana.Text, cmbLocalGurdianDistrict.Text);
        }

        private void txtLocalGurdianRoadNo_TextChanged(object sender, EventArgs e)
        {
            IsCityAddress = true;
            SetLocalGurdianCityAddress(txtLocalGurdianHouseNo.Text, txtLocalGurdianRoadNo.Text, cmbLocalGurdianThana.Text, cmbLocalGurdianDistrict.Text);
        }

        private void cmbLocalGurdianThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpazilaOrArea _upz = (UpazilaOrArea)cmbLocalGurdianThana.SelectedItem;
            if (_upz.UpazilaId > 0)
            {
                if (IsCityAddress)
                {
                    SetLocalGurdianCityAddress(txtLocalGurdianHouseNo.Text, txtLocalGurdianRoadNo.Text, _upz.Name, cmbDistricts.Text);
                }
                else
                {
                    SetLocalGurdianVillageAddress(txtLocalGurdianVillage.Text, txtLocalGurdianPO.Text, _upz.Name, cmbLocalGurdianDistrict.Text);
                }
            }
        }

        private void btnAdmissionCancel_Click(object sender, EventArgs e)
        {
            if (btnAdmissionCancel.Tag != null)
            {
                VMIPDInfo _patient = btnAdmissionCancel.Tag as VMIPDInfo;
                if (_patient != null)                            
                {
                    //bool isCabinChargeApplied = new HospitalService().IsCabinChargeApplied(_patient.AddmissionDate,Utils.GetServerDateAndTime());

                    bool isCabinChargeApplied = new HospitalService().IsCabinChargeApplied(_patient, Utils.GetServerDateAndTime());

                    bool isAnyDueTreatmentdone = new PatientService().IsAnyDueInInvestigationDone(_patient);

                    bool isIpdServiceProvided = new HospitalService().IsAnyIpdServiceProvided(_patient);

                    string _msg = string.Empty;

                    if (isCabinChargeApplied)
                    {
                        _msg = "Cabin";
                    }

                    if (isAnyDueTreatmentdone)
                    {
                        if (!string.IsNullOrEmpty(_msg))
                        {
                            _msg = "Investigation";
                        }
                        else
                        {
                            _msg = _msg + " , " + " Investigation ";
                        }


                    }

                    if (isIpdServiceProvided)
                    {
                        if (!string.IsNullOrEmpty(_msg))
                        {
                            _msg = "IPD";
                        }
                        else
                        {
                            _msg = _msg + " and " + " IPD ";
                        }

                    }

                    double _advancePaid = new HpFinancialService().GetRoughAdvancePaymentByPatient(_patient.AdmissionId);

                    if (_advancePaid!=0)
                    {
                        MessageBox.Show("Plz Return Advance Amount And Tray Again.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(_msg))
                    {
                        _msg = _msg + " services are provided to this patient. Admission cancel is not permitted now.";

                        MessageBox.Show(_msg);

                        //DialogResult _2ndconfirmation = MessageBox.Show(_msg + " Are you still sure to cancel this admission? ", "Confirmation", MessageBoxButtons.YesNoCancel);

                        //if(_2ndconfirmation == DialogResult.Yes)
                        //{
                        //    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_patient.AdmissionId);
                        //    _pInfo.Status = "Cancelled";
                        //    new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                        //    Free_Cabin(_patient);

                        //    MessageBox.Show("Admission cancel successful");
                        //}
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure to cancel this admission?", "Confirmation", MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.Yes)
                        {
                            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_patient.AdmissionId);
                            _pInfo.Status = "Cancelled";
                          
                            _pInfo.Cancelledby = MainForm.LoggedinUser.Name;
                            new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                            Free_Cabin(_patient);
                            MessageBox.Show("Admission cancel successful");


                            List<VMIPDInfo> _lisPatientInfo = new List<VMIPDInfo>();

                           // List<VMIPDInfo> _Plist = await LoadPatients();

                            FillListGrid(_lisPatientInfo);



                        }
                    }


                }
            }
            else
            {

            }
        }

        private void Free_Cabin(VMIPDInfo _pInfo)
        {

            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedService().GetHpOccupiedCabinListByAdmisissionId(_pInfo.AdmissionId);

            foreach (var acconObj in _accomList)
            {
                CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(acconObj.CabinId);

                _cabin.IsBooked = false;
                new HospitalCabinBedService().UpdateCabinInfo(_cabin);
            }


        }

        private void dgPatient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgPatient_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);

                HospitalPatientInfo _HPpInfo = new HospitalService().GetHospitalPatientByBillNo(_pInfo.BillNo);


                if (_pInfo == null)
                {
                    return;
                }


                ViewAdmissionForm(_HPpInfo);


            }
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

                    ctlMediaSearchControl.LoadDataByType("Media");
                }
            }
        }

        private void ctlMediaSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedia.Focus();
            }
        }

        private void cmbRelationshipWithPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void ctrlHpPackageSearchControl_Load(object sender, EventArgs e)
        {

        }

        private void pnlPatient_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

