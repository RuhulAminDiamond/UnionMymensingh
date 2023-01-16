using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using HDMS.Model.Hospital;
using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Model.Enums;
using System.Threading;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.IPD;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.IPD;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Model.Accounting.VModel;
using HDMS.Windows.Forms.UI.Reports.OPD;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlDayWiseBill : UserControl
    {
        bool isInMaxView = true;
        WaitWnd.WaitWndFun waitForm = new WaitWnd.WaitWndFun();
        public ctrlDayWiseBill()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgPatient.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgPatient.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void ctrlMR_Load(object sender, EventArgs e)
        {
         

            dtpDischarge.Value = Utils.GetServerDateAndTime();
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            toolTip1.SetToolTip(this.btnCCNote, "Cabin charge justification");
            LoadPatients();

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

        private async void LoadPatients()
        {
            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfo();
            dgPatient.Tag = _lisPatientInfo;
            FillListGrid(_lisPatientInfo);

            if(_lisPatientInfo!=null)
                lblTotalPatient.Text = _lisPatientInfo.Count.ToString();

        }

        private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMIPDInfo item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgPatient, item.BillNo,item.Name, item.AddmissionDate.ToString("dd/MM/yyyy"), item.AdmTime, item.BedCabinNo,item.RecommededDateForDischarge,item.RecommededTimeForDischarge,item.DischargeRecommendationConfirmedby,item.AssignedDoctor,item.RefDoctor);
                dgPatient.Rows.Add(row);
            }

        }

       

        private void GoToPackageBillingMethod(VMIPDInfo _pInfo)
        {
            List<VMHpFinalBill> finalBillItems = new List<VMHpFinalBill>();

            HpPackage _Package = new HospitalService().GetHpPackageById(_pInfo.PackageId);
            VMHpFinalBill _hpFbill = new VMHpFinalBill();
            _hpFbill.SrlNo = 1;
            _hpFbill.ServiceName = _Package.Name;
            _hpFbill.Qty = 1;
            _hpFbill.Rate= _Package.PkgTotal;
            _hpFbill.Total = _Package.PkgTotal;

            finalBillItems.Add(_hpFbill);

            FillBillGrid(finalBillItems);
        }

        private void SegmantizeTheExtraAccomodation(VMIPDInfo _pInfo)
        {
            bool IsAdmissionDayAndReleaseDaySame = false;
            bool IsAdmissionDayBillApplicable = false;
            bool IsOccupationMorethanTwoCalendarDate = false;
            bool IsAdmissionDay = false;

            List<DateTime> _rollingDateList = new List<DateTime>();

            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedService().GetHpExtraAccomodationListByPatient(_pInfo.AdmissionId);

            if (_accomList.Count == 0) return;

            HpPatientAccomodationInfo _extraAccomInfo = _accomList.FirstOrDefault();

            for (var date = _extraAccomInfo.AccomodateDate; date <= Utils.GetServerDateAndTime(); date = date.AddDays(1))
            {
                _rollingDateList.Add(date);
            }

          

            double _timeDistanceInhours = 0;
            double _days = 0;
            double _hours = 0;

            HpCabinChargeSegmantMaster _ccMS = new HospitalCabinBedService().GetHpCabinChargeMasterSegmant();

            _rollingDateList = new List<DateTime>(); // For Release and Occupied Date Count

            //  DateTime _firstBillingHour = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_pInfo.AddmissionDate.Date, _pInfo.AdmTime, "11:59:59 PM");

            List<HpCabinChargeSegmantDetail> ccgList = new List<HpCabinChargeSegmantDetail>();

            foreach (var item in _accomList)
            {
                ccgList = new List<HpCabinChargeSegmantDetail>();

                if (item.AllotType.ToLower() == "releasedaseb")
                {

                    for (var date = item.AccomodateDate; date <= item.ReleaseDate; date = date.AddDays(1))
                    {

                        HpCabinChargeSegmantDetail ccg = new HpCabinChargeSegmantDetail();
                        ccg.SMId = _ccMS.SMId;
                        ccg.BookOrder = item.AccomId;
                        ccg.AdmissionId = item.AdmissionId;
                        ccg.CabinId = item.CabinId;
                        CabinInfo _c = new HospitalCabinBedService().GetCabinInfoId(item.CabinId);
                        ccg.CabinNo = _c.CabinNo;
                        ccg.Rent = _c.Rent;
                        ccg.StayingDate = date;
                        ccg.OccupationStatus = "ExtraRelease";
                        ccg.IsAdmissionDay = false;
                        

                        ccgList.Add(ccg);

                    }

                }
                else
                {
                    for (var date = item.AccomodateDate; date <= Utils.GetServerDateAndTime(); date = date.AddDays(1))
                    {

                        HpCabinChargeSegmantDetail ccg = new HpCabinChargeSegmantDetail();
                        ccg.SMId = _ccMS.SMId;
                        ccg.BookOrder = item.AccomId;
                        ccg.AdmissionId = item.AdmissionId;
                        ccg.CabinId = item.CabinId;
                        CabinInfo _c = new HospitalCabinBedService().GetCabinInfoId(item.CabinId);
                        ccg.CabinNo = _c.CabinNo;
                        ccg.Rent = _c.Rent;
                        ccg.StayingDate = date;
                        ccg.OccupationStatus = "ExtraRelease";

                         ccg.IsAdmissionDay = false;
                       

                        ccgList.Add(ccg);

                    }
                }

                if (ccgList.Count > 0)
                {
                    new HospitalCabinBedService().SaveHpCabinChargeSegmantDetail(ccgList);
                }
            }

        }

        private void SegmantizeTheAccomodation(VMIPDInfo _pInfo)
        {
            bool IsAdmissionDayAndReleaseDaySame = false;
            bool IsAdmissionDayBillApplicable = false;
            bool IsOccupationMorethanTwoCalendarDate = false;
            bool IsAdmissionDay = false;

            List<DateTime> _rollingDateList = new List<DateTime>();

            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedService().GetHpAccomodationListByPatient(_pInfo.AdmissionId);

            if (_pInfo.AddmissionDate.Date == Utils.GetServerDateAndTime().Date)
            {
                IsAdmissionDayAndReleaseDaySame = true;
            }

            for (var date = _pInfo.AddmissionDate; date <= Utils.GetServerDateAndTime(); date = date.AddDays(1))
            {
                _rollingDateList.Add(date);
            }

            if (_rollingDateList.Count > 2)
            {
                IsOccupationMorethanTwoCalendarDate = true;
            }

            double _timeDistanceInhours = 0;
            double _days = 0;
            double _hours = 0;


            if (IsAdmissionDayAndReleaseDaySame)
            {
                _timeDistanceInhours = new CalculateCabinCharge().GetTimeDistanceInHours(_pInfo.AddmissionDate, _pInfo.AdmTime, Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"));
                _days = _timeDistanceInhours / 24;
                _hours = _timeDistanceInhours % 24;

                if (_hours >= 2) IsAdmissionDayBillApplicable = true;

            }

            if (_rollingDateList.Count > 1)
            {
                // DateTime _ThresholdTimeFor6HoursGrace = new DateTime(_pInfo.AddmissionDate.Year, _pInfo.AddmissionDate.Month, _pInfo.AddmissionDate.Day, 18, 0, 0);
                DateTime _ThresholdTimeFor12HoursGrace = new DateTime(_pInfo.AddmissionDate.Year, _pInfo.AddmissionDate.Month, _pInfo.AddmissionDate.Day, 12, 0, 0);
                DateTime _ActualAdmissionDateAndTime = new CalculateCabinCharge().CombinedDateAndTimePart(_pInfo.AddmissionDate, _pInfo.AdmTime);

                if (_ActualAdmissionDateAndTime.TimeOfDay < _ThresholdTimeFor12HoursGrace.TimeOfDay)
                {
                    IsAdmissionDayBillApplicable = true;
                }

            }

            HpCabinChargeSegmantMaster _cabinChargeMaster = new HpCabinChargeSegmantMaster();
            _cabinChargeMaster.AdmissionId = _pInfo.AdmissionId;
            _cabinChargeMaster.AdmissionDate = _pInfo.AddmissionDate;
            _cabinChargeMaster.AdmissionTime = _pInfo.AdmTime;
            _cabinChargeMaster.IsAdmissionDayBillApplicable = IsAdmissionDayBillApplicable;
            _cabinChargeMaster.IsAdmissionDayAndReleaseDaySame = IsAdmissionDayAndReleaseDaySame;
            _cabinChargeMaster.IsOccupationMorethanTwoCalendarDate = IsOccupationMorethanTwoCalendarDate;

            long _MasterId = new HospitalCabinBedService().SaveHpCabinChargeSegmantMaster(_cabinChargeMaster);

            _rollingDateList = new List<DateTime>(); // For Release and Occupied Date Count

            //  DateTime _firstBillingHour = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_pInfo.AddmissionDate.Date, _pInfo.AdmTime, "11:59:59 PM");

            List<HpCabinChargeSegmantDetail> ccgList = new List<HpCabinChargeSegmantDetail>();

            foreach (var item in _accomList)
            {
                ccgList = new List<HpCabinChargeSegmantDetail>();

                if (item.AllotType.ToLower() == "releasedastb")
                {

                    for (var date = item.AccomodateDate; date <= item.ReleaseDate; date = date.AddDays(1))
                    {

                        HpCabinChargeSegmantDetail ccg = new HpCabinChargeSegmantDetail();
                        ccg.SMId = _MasterId;
                        ccg.BookOrder = item.AccomId;
                        ccg.AdmissionId = item.AdmissionId;
                        ccg.CabinId = item.CabinId;
                        CabinInfo _c = new HospitalCabinBedService().GetCabinInfoId(item.CabinId);
                        ccg.CabinNo = _c.CabinNo;
                        ccg.AccomodationTypeId = _c.AccomodationTypeId;
                        ccg.ServiceHeadId = new HospitalCabinBedService().GetCabinServiceHeadId(_c.AccomodationTypeId).ServiceHeadId;
                        ccg.Rent = _c.Rent;
                        ccg.StayingDate = date;
                        ccg.OccupationStatus = "Release";
                        if (_pInfo.AddmissionDate.Date == date.Date)
                        {
                            ccg.IsAdmissionDay = true;
                        }
                        else
                        {
                            ccg.IsAdmissionDay = false;
                        }

                        ccgList.Add(ccg);

                    }

                }
                else
                {
                    for (var date = item.AccomodateDate; date <= Utils.GetServerDateAndTime(); date = date.AddDays(1))
                    {

                        HpCabinChargeSegmantDetail ccg = new HpCabinChargeSegmantDetail();
                        ccg.SMId = _MasterId;
                        ccg.BookOrder = item.AccomId;
                        ccg.AdmissionId = item.AdmissionId;
                        ccg.CabinId = item.CabinId;
                        CabinInfo _c = new HospitalCabinBedService().GetCabinInfoId(item.CabinId);
                        ccg.CabinNo = _c.CabinNo;
                        ccg.AccomodationTypeId = _c.AccomodationTypeId;
                        ccg.ServiceHeadId = new HospitalCabinBedService().GetCabinServiceHeadId(_c.AccomodationTypeId).ServiceHeadId;
                        ccg.Rent = _c.Rent;
                        ccg.StayingDate = date;
                        ccg.OccupationStatus = "Occupied";

                        if (_pInfo.AddmissionDate.Date == date.Date)
                        {
                            ccg.IsAdmissionDay = true;
                        }
                        else
                        {
                            ccg.IsAdmissionDay = false;
                        }

                        ccgList.Add(ccg);

                    }
                }

                if (ccgList.Count > 0)
                {
                    new HospitalCabinBedService().SaveHpCabinChargeSegmantDetail(ccgList);
                }
            }

        }


        private void CalculateCabinChargeWith24HousPlusGraceperiodRole(VMIPDInfo _pInfo)
        {
            int _daysInCabin = 0;
            double _cabinCharge = 0;
            bool isWithin24Hours = false;
            bool isTransferredOccuredWithin24Hours = false;
            bool isBedTransferredHappened = false;
            bool isSandwichedhours_Greater_Than_GracePeriod_Considerable = false;
            bool isCurrentOccupiedCabinWithin24HoursOfAdmission = false;
            DateTime _tempReleaseDate = DateTime.Now;

            DateTime _tempAccomdate = DateTime.Now;

            string _billJustification = string.Empty;

            List<HpCabinCharge> _cabinChargeList = new List<HpCabinCharge>();

           

            btnBillSave.Tag = _pInfo;

            lblName.Text = _pInfo.Name;
            lblCabin.Text = _pInfo.BedCabinNo;

            DateTime _accomodateDate; // This variable willl carry the accomodate date for patients transferred serveral time within 24 hours
            bool IsOccupiedCabinFoundForTransferredWithin24Hours = false;
            // bool IsOccupiedCabinTheLeastBill = false;
            bool IsOccupiedCabinTheLastBookingCabin = false;
            int OccupiedCabinId = 0;





            new HpFinancialService().DeleteExistingCabinChargeCalculation(_pInfo.AdmissionId);

            HospitalPatientInfo _hpInfo = new HospitalService().GetHospitalPatientInfoById(_pInfo.AdmissionId);
            DateTime _admissionDate = _hpInfo.AddmissionDate;
            string _admissionTime = _hpInfo.Time;

            HpPatientAccomodationInfo _currentAccomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_pInfo.AdmissionId);

            double _gracePeriod = new CalculateCabinCharge().GetGracePeriod(_hpInfo.AddmissionDate, _hpInfo.Time);
            if (_gracePeriod > 6) _gracePeriod = 6;

            // this.SegmantizeTheAccomodation(_pInfo, _gracePeriod);

            //Get Time difference beween Admission date time and current date time

            double _timeDistanceInhours = new CalculateCabinCharge().GetTimeDistanceInHours(_admissionDate, _admissionTime, Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"));
            double _days = _timeDistanceInhours / 24;
            double _hours = _timeDistanceInhours % 24;
            if (_days <= 1 && _hours >= 2 && _hours <= 24)
            {
                HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                _HpcabinCharge.CabinId = _currentAccomInfo.CabinId;
                CabinInfo _ci = new HospitalCabinBedService().GetCabinInfoId(_currentAccomInfo.CabinId);
                _HpcabinCharge.Particulars = "Cabin charge: " + _ci.CabinNo;
                _HpcabinCharge.TotalDays = 1;
                _HpcabinCharge.Rate = _ci.Rent;
                _HpcabinCharge.Amount = _ci.Rent * 1;
                _HpcabinCharge.BillJustification = "Bill for staying " + _hours.ToString() + "Hours which is more than 1 hour";
                _cabinChargeList.Add(_HpcabinCharge);

                new HpFinancialService().SaveCabinChargeRange(_cabinChargeList);

            }
            else

            {



                //Cbin charge generated from Bed/Cabin Transfer where AllotType is ReleasedAsTB
                List<DateTime> _patientDistinctVacantedDate = new HospitalCabinBedService().GetDistinctVacantedDateByPatient(_pInfo.AdmissionId);
                List<HpCabinCharge> _tempcabinChargeList = new List<HpCabinCharge>();

                int _dateCount = 0;  // To find the last transfer where a new cabin occupied by the patient


                List<VMHpCabinCharge> _cabinChargeListWithin24Hours = new List<VMHpCabinCharge>();

                foreach (DateTime dt in _patientDistinctVacantedDate)
                {
                    _dateCount = _dateCount + 1;

                    int _totalTransferCount = 0;

                    isBedTransferredHappened = true;

                    List<VMCabinAccomodationInfo> _cInfoList = new HospitalCabinBedService().GetBedTransferredAccomInfo(_pInfo.AdmissionId, dt);

                    if (_cInfoList.Count > 0)
                    {
                        // Check whether within 24 hours



                        foreach (var item in _cInfoList)
                        {

                            _totalTransferCount = _totalTransferCount + 1;
                            //isWithin24Hours = new CalculateCabinCharge().IsWithin24Hours(_admissionDate, _admissionTime, item.ReleaseDate, item.ReleaseTime);

                            if (_gracePeriod < 6)
                            {
                                _tempAccomdate = new CalculateCabinCharge().CombinedDateAndTimePart(_admissionDate.AddDays(2), "12:00 AM");

                            }
                            else
                            {
                                _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_admissionDate, _admissionTime, 24 + _gracePeriod);
                            }


                            isWithin24Hours = new CalculateCabinCharge().IsWithin24Hours(item.AccomodateDate, item.AccomodateTime, _tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _gracePeriod);

                            if (isWithin24Hours)
                            {

                                isTransferredOccuredWithin24Hours = true;

                                _daysInCabin = 1; // For First 24 hours + Grace Period

                                double _sandwichedTime = 0;
                                if (_tempAccomdate > item.ReleaseDate || _gracePeriod < 6)
                                {
                                    _sandwichedTime = 0;
                                }
                                else
                                {
                                    _sandwichedTime = new CalculateCabinCharge().GetTimeDistanceInHours(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _tempAccomdate.Date.AddDays(1), "12:00 AM");
                                }



                                if (_sandwichedTime > 0)
                                {
                                    _daysInCabin = _daysInCabin + 1;
                                    _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _sandwichedTime);
                                }

                                if (_dateCount == _patientDistinctVacantedDate.Count && _totalTransferCount == _cInfoList.Count)
                                {
                                    _tempReleaseDate = new CalculateCabinCharge().CombinedDateAndTimePart(item.ReleaseDate, "12:00 AM");

                                    _daysInCabin = _daysInCabin + new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _tempReleaseDate.Date, _tempReleaseDate.ToString("hh:mm tt"), 0, false, true);

                                }
                                else
                                {
                                    _daysInCabin = _daysInCabin + new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), item.ReleaseDate, item.ReleaseTime, 0, false, true);
                                }



                                isCurrentOccupiedCabinWithin24HoursOfAdmission = new CalculateCabinCharge().IsWithin24Hours(_admissionDate, _admissionTime, _currentAccomInfo.AccomodateDate, _currentAccomInfo.AccomodateTime, _gracePeriod);

                                if (isCurrentOccupiedCabinWithin24HoursOfAdmission)
                                {
                                    IsOccupiedCabinFoundForTransferredWithin24Hours = true;

                                    VMHpCabinCharge _pcabinCharge = new VMHpCabinCharge();
                                    _pcabinCharge.BookingOrder = _currentAccomInfo.AccomId;
                                    _pcabinCharge.AdmissionId = _pInfo.AdmissionId;
                                    _pcabinCharge.TranDate = Utils.GetServerDateAndTime();

                                    CabinInfo _c = new HospitalCabinBedService().GetCabinInfoId(_currentAccomInfo.CabinId);

                                    OccupiedCabinId = _c.CabinId;

                                    _pcabinCharge.CabinId = _c.CabinId;
                                    _pcabinCharge.AccomodationTypeId = _c.AccomodationTypeId;
                                    _pcabinCharge.Particulars = "Cabin Charge: " + _c.CabinNo;
                                    _pcabinCharge.TotalDays = _daysInCabin;
                                    _pcabinCharge.Rate = _c.Rent;
                                    _pcabinCharge.Amount = _c.Rent * _daysInCabin;

                                    _cabinChargeListWithin24Hours.Add(_pcabinCharge);

                                    if (String.IsNullOrEmpty(_billJustification))
                                    {
                                        _billJustification = item.CabinNo + ":" + item.Rent.ToString();
                                    }
                                    else
                                    {
                                        _billJustification = _billJustification + ", " + item.CabinNo + ":" + item.Rent.ToString();
                                    }

                                }


                                if (String.IsNullOrEmpty(_billJustification))
                                {
                                    _billJustification = item.CabinNo + ":" + item.Rent.ToString();
                                }
                                else
                                {
                                    _billJustification = _billJustification + ", " + item.CabinNo + ":" + item.Rent.ToString();
                                }


                                VMHpCabinCharge _HpcabinCharge = new VMHpCabinCharge();
                                _HpcabinCharge.BookingOrder = item.BookingOrder;
                                _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                                _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                                _HpcabinCharge.CabinId = item.CabinId;
                                _HpcabinCharge.AccomodationTypeId = item.AccomodationTypeId;
                                _HpcabinCharge.Particulars = "Cabin charge: " + item.CabinNo;
                                _HpcabinCharge.TotalDays = _daysInCabin;
                                _HpcabinCharge.Rate = item.Rent;
                                _HpcabinCharge.Amount = item.Rent * _daysInCabin;

                                _cabinChargeListWithin24Hours.Add(_HpcabinCharge);


                            }
                            else
                            {

                                //First 24 hours will be selected from _cabinChargeListWithin24Hours and rest of the days bill will be calculated from below function

                                _timeDistanceInhours = new CalculateCabinCharge().GetTimeDistanceInHours(item.AccomodateDate, item.AccomodateTime, _admissionDate.AddDays(1), _admissionTime); // Time remain to fill up first 24 hours threshold



                                if (_timeDistanceInhours > 0)
                                {
                                    _daysInCabin = 1; // For First 24 hours + Grace Period

                                    _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(item.AccomodateDate, item.AccomodateTime, _timeDistanceInhours + _gracePeriod);

                                    double _sandwichedTime = 0;
                                    if (_tempAccomdate.Date > item.ReleaseDate.Date)
                                    {
                                        _sandwichedTime = 0;
                                    }
                                    else
                                    {
                                        _sandwichedTime = new CalculateCabinCharge().GetTimeDistanceInHours(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _tempAccomdate.Date.AddDays(1), "12:00 AM");
                                    }



                                    if (_sandwichedTime > 0)
                                    {
                                        _daysInCabin = _daysInCabin + 1;
                                        _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _sandwichedTime);
                                    }

                                    if (String.IsNullOrEmpty(_billJustification))
                                    {
                                        _billJustification = item.CabinNo + " : " + item.Rent.ToString();
                                    }
                                    else
                                    {
                                        _billJustification = _billJustification + ", " + item.CabinNo + " : " + item.Rent.ToString();
                                    }

                                }
                                else
                                {
                                    DateTime _currentDateAndTime = new CalculateCabinCharge().CombinedDateAndTimePart(item.AccomodateDate, item.AccomodateTime);

                                    if (_tempAccomdate < _currentDateAndTime)
                                        _tempAccomdate = new CalculateCabinCharge().CombinedDateAndTimePart(item.AccomodateDate, item.AccomodateTime);
                                }



                                if (isTransferredOccuredWithin24Hours)
                                {
                                    _daysInCabin = new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), item.ReleaseDate, item.ReleaseTime, 0, false, isSandwichedhours_Greater_Than_GracePeriod_Considerable);
                                }
                                else
                                {

                                    _daysInCabin = _daysInCabin + new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), item.ReleaseDate, item.ReleaseTime, _gracePeriod, false, true);
                                }


                                if (_daysInCabin > 0)
                                {
                                    HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                                    _HpcabinCharge.BookingOrder = item.BookingOrder;
                                    _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                                    _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                                    _HpcabinCharge.CabinId = item.CabinId;
                                    _HpcabinCharge.Particulars = "Cabin charge: " + item.CabinNo;
                                    _HpcabinCharge.TotalDays = _daysInCabin;
                                    _HpcabinCharge.Rate = item.Rent;
                                    _HpcabinCharge.Amount = item.Rent * _daysInCabin;
                                    _HpcabinCharge.BillJustification = "Cabin charge for " + item.CabinNo + " after elapsed of first 24 hours and grace period";

                                    _cabinChargeList.Add(_HpcabinCharge);
                                }
                            }
                        }

                    }

                }


                if (_cabinChargeListWithin24Hours.Count > 0)
                {
                    var _cabinWithin24hours = _cabinChargeListWithin24Hours.Where(q => q.AccomodationTypeId == 2 || q.AccomodationTypeId == 3 || q.AccomodationTypeId == 4 || q.AccomodationTypeId == 6).OrderBy(x => x.Rate).FirstOrDefault();
                    if (_cabinWithin24hours == null)
                    {
                        _cabinWithin24hours = _cabinChargeListWithin24Hours.OrderByDescending(x => x.BookingOrder).FirstOrDefault();
                    }

                    HpCabinCharge _HpcabinChargeW24 = new HpCabinCharge();
                    _HpcabinChargeW24.AdmissionId = _cabinWithin24hours.AdmissionId;
                    _HpcabinChargeW24.TranDate = Utils.GetServerDateAndTime();
                    _HpcabinChargeW24.CabinId = _cabinWithin24hours.CabinId;
                    _HpcabinChargeW24.Particulars = _cabinWithin24hours.Particulars;
                    _HpcabinChargeW24.TotalDays = _cabinWithin24hours.TotalDays;
                    _HpcabinChargeW24.Rate = _cabinWithin24hours.Rate;
                    _HpcabinChargeW24.Amount = _cabinWithin24hours.Rate * _cabinWithin24hours.TotalDays;
                    _HpcabinChargeW24.BillJustification = "Cabin rolled within 24 hours: " + _billJustification;

                    if (OccupiedCabinId == _cabinWithin24hours.CabinId)
                    {
                        IsOccupiedCabinTheLastBookingCabin = true;
                        if (String.IsNullOrEmpty(_billJustification))
                        {
                            _billJustification = "Occupied cabin found within 24 hours with minimum bill.So it will consider the occupied cabin Accomodation date & time as Admission Date and Time, Others will be discarded.";
                        }
                        else
                        {
                            _billJustification = _billJustification + " Occupied cabin found within 24 hours with minimum bill.So it will consider the occupied cabin Accomodation date & time as Admission Date and Time, Others will be discarded.";
                        }
                    }
                    else
                    {
                        _cabinChargeList.Insert(0, _HpcabinChargeW24);
                    }

                }


                if (_cabinChargeList.Count > 0)
                {

                    new HpFinancialService().SaveCabinChargeRange(_cabinChargeList);
                }

                //Cabin charge generated from Extra Bed/Cabin Release where AllotType is ReleasedAsEB
                _patientDistinctVacantedDate = new HospitalCabinBedService().GetDistinctEBVacantedDateByPatient(_pInfo.AdmissionId);
                _cabinChargeList = new List<HpCabinCharge>();
                foreach (DateTime dt in _patientDistinctVacantedDate)
                {
                    VMCabinAccomodationInfo _cInfo = new HospitalCabinBedService().GetExtraBedReleasedAccomInfo(_pInfo.AdmissionId, dt);

                    if (_cInfo != null)
                    {
                        _daysInCabin = new CalculateCabinCharge().DaysInHospital(_cInfo.AccomodateDate, _cInfo.AccomodateTime, _cInfo.ReleaseDate, _cInfo.ReleaseTime, 0, false, isSandwichedhours_Greater_Than_GracePeriod_Considerable);

                        HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                        _HpcabinCharge.BookingOrder = _cInfo.BookingOrder;
                        _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                        _HpcabinCharge.TranDate = _cInfo.ReleaseDate;
                        _HpcabinCharge.TranTime = _cInfo.ReleaseTime;
                        _HpcabinCharge.Particulars = "Extra Cabin charge: " + _cInfo.CabinNo;
                        _HpcabinCharge.TotalDays = _daysInCabin;
                        _HpcabinCharge.Rate = _cInfo.Rent;
                        _HpcabinCharge.Amount = _cInfo.Rent * _daysInCabin;
                        _HpcabinCharge.BillJustification = "Released Extra cabin (" + _cInfo.CabinNo + ":" + _cInfo.Rent.ToString() + ") bill for " + _cInfo.AccomodateDate + " " + _cInfo.AccomodateTime + " To + " + _cInfo.ReleaseDate + " " + _cInfo.ReleaseTime;
                        _cabinChargeList.Add(_HpcabinCharge);
                    }

                }

                if (_cabinChargeList.Count > 0)
                {
                    new HpFinancialService().SaveCabinChargeRange(_cabinChargeList);
                }


                int _daysInExtrCabin = 0;
                double _extracabinCharge = 0;
                double extraCabinRent = 0;
                CabinInfo _extraCabin = new CabinInfo();
                string _extraParticulars = string.Empty;
                List<VMCabinAccomodationInfo> _occupiedExtracabinList = new HospitalCabinBedService().GetOccupiedExtracabin(_pInfo.AdmissionId);
                _cabinChargeList = new List<HpCabinCharge>();

                foreach (VMCabinAccomodationInfo eacommInfo in _occupiedExtracabinList)
                {
                    _daysInExtrCabin = new CalculateCabinCharge().DaysInHospital(eacommInfo.AccomodateDate, eacommInfo.AccomodateTime, Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"), 0, false, isSandwichedhours_Greater_Than_GracePeriod_Considerable);

                    _extraParticulars = "Extra Cabin Charge: " + _extraCabin.CabinNo;
                    HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                    _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                    _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                    _HpcabinCharge.TranTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _HpcabinCharge.Particulars = "Extra Cabin charge: " + eacommInfo.CabinNo;
                    _HpcabinCharge.TotalDays = _daysInExtrCabin;
                    _HpcabinCharge.Rate = eacommInfo.Rent;
                    _HpcabinCharge.Amount = eacommInfo.Rent * _daysInExtrCabin;
                    _HpcabinCharge.BillJustification = "Occupied Extra cabin (" + eacommInfo.CabinNo + ":" + eacommInfo.Rent.ToString() + ") bill for " + eacommInfo.AccomodateDate + " " + eacommInfo.AccomodateTime + " To + " + Utils.GetServerDateAndTime() + " " + Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _cabinChargeList.Add(_HpcabinCharge);

                }

                if (_cabinChargeList.Count > 0)
                {
                    new HpFinancialService().SaveCabinChargeRange(_cabinChargeList);
                }



                //Occupied Cabin Bill Calculation

                HpPatientAccomodationInfo _pAccomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_pInfo.AdmissionId);

                if (_pAccomInfo != null)
                {

                    isSandwichedhours_Greater_Than_GracePeriod_Considerable = true;

                    CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_pAccomInfo.CabinId);

                    if (IsOccupiedCabinFoundForTransferredWithin24Hours && IsOccupiedCabinTheLastBookingCabin)
                    {
                        _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_admissionDate.AddDays(1), _admissionTime, _gracePeriod);

                        double _sandwichedTime = 0;
                        if (_tempAccomdate > Utils.GetServerDateAndTime())
                        {
                            _sandwichedTime = 0;
                        }
                        else
                        {
                            _sandwichedTime = new CalculateCabinCharge().GetTimeDistanceInHours(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _tempAccomdate.Date.AddDays(1), "12:00 AM");
                        }

                        if (_sandwichedTime > 0)
                        {
                            _daysInCabin = _daysInCabin + 1;
                            _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _sandwichedTime);
                        }


                        _daysInCabin = _daysInCabin + new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"), 0, false, isSandwichedhours_Greater_Than_GracePeriod_Considerable);
                    }
                    else if (IsOccupiedCabinFoundForTransferredWithin24Hours && !IsOccupiedCabinTheLastBookingCabin)
                    {
                        _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_admissionDate.AddDays(1), _admissionTime, _gracePeriod);

                        double _sandwichedTime = 0;
                        if (_tempAccomdate > Utils.GetServerDateAndTime())
                        {
                            _sandwichedTime = 0;
                        }
                        else
                        {
                            _sandwichedTime = new CalculateCabinCharge().GetTimeDistanceInHours(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _tempAccomdate.Date.AddDays(1), "12:00 AM");
                        }

                        if (_sandwichedTime > 0)
                        {
                            _daysInCabin = _daysInCabin + 1;
                            _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _sandwichedTime);
                        }

                        _daysInCabin = _daysInCabin + new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"), 0, false, isSandwichedhours_Greater_Than_GracePeriod_Considerable);
                    }
                    else
                    {
                        if (isBedTransferredHappened)
                        {
                            _tempAccomdate = new CalculateCabinCharge().CombinedDateAndTimePart(_pAccomInfo.AccomodateDate, "12:00 AM");

                            _daysInCabin = new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"), _gracePeriod, false, isSandwichedhours_Greater_Than_GracePeriod_Considerable);
                        }
                        else
                        {
                            _timeDistanceInhours = new CalculateCabinCharge().GetTimeDistanceInHours(_admissionDate, _admissionTime, Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"));

                            if (_timeDistanceInhours > 24)
                            {
                                if (_gracePeriod < 6)
                                {
                                    _tempAccomdate = new CalculateCabinCharge().CombinedDateAndTimePart(_pAccomInfo.AccomodateDate.AddDays(2), "12:00 AM");
                                }
                                else
                                {

                                    _gracePeriod = _gracePeriod + 24;
                                    _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_pAccomInfo.AccomodateDate, _pAccomInfo.AccomodateTime, _gracePeriod);
                                }
                                _daysInCabin = 1; // 1 for First 24 hours + Grace Period


                                double _sandwichedTime = 0;
                                if (_tempAccomdate > Utils.GetServerDateAndTime())
                                {
                                    _sandwichedTime = 0;
                                }
                                else
                                {
                                    _sandwichedTime = new CalculateCabinCharge().GetTimeDistanceInHours(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _tempAccomdate.Date.AddDays(1), "12:00 AM");
                                }



                                if (_sandwichedTime > 0)
                                {
                                    _daysInCabin = _daysInCabin + 1;
                                    _tempAccomdate = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), _sandwichedTime);
                                }

                                _daysInCabin = _daysInCabin + new CalculateCabinCharge().DaysInHospital(_tempAccomdate.Date, _tempAccomdate.ToString("hh:mm tt"), Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"), 0, false, true);

                            }

                            if (String.IsNullOrEmpty(_billJustification))
                            {
                                _billJustification = "No bed transfer happened for this patient.First Bill will be for 24 hours + grace period: " + (_gracePeriod - 24).ToString();
                            }
                            else
                            {
                                _billJustification = _billJustification + "No bed transfer happened for this patient.First Bill will be for 24 hours + grace period: " + (_gracePeriod - 24).ToString();
                            }

                            //else
                            //{

                            //    _daysInCabin = new CalculateCabinCharge().DaysInHospital(_pAccomInfo.AccomodateDate, _pAccomInfo.AccomodateTime, Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"), 0, false);
                            //}
                        }

                    }


                    if (_daysInCabin > 0)
                    {
                        _cabinCharge = _daysInCabin * _Cabin.Rent;

                        string _particulars = "Cabin Charge: " + _Cabin.CabinNo;

                        HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                        _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                        _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                        _HpcabinCharge.TranTime = Utils.GetServerDateAndTime().ToString("HH:mm:ss tt");
                        _HpcabinCharge.Particulars = "Cabin charge: " + _Cabin.CabinNo;
                        _HpcabinCharge.TotalDays = _daysInCabin;
                        _HpcabinCharge.Rate = _Cabin.Rent;
                        _HpcabinCharge.Amount = _Cabin.Rent * _daysInCabin;
                        _HpcabinCharge.BillJustification = _billJustification;
                        new HpFinancialService().SaveCabinCharge(_HpcabinCharge);
                    }
                }



            }

        }


       
        private void FillBillGrid(List<VMHpFinalBill> finalBillItems)
        {

            dgLedger.SuspendLayout();
            dgLedger.Rows.Clear();
            double _serviceCharge = 0;
            foreach (VMHpFinalBill item in finalBillItems)
            {
                _serviceCharge = _serviceCharge + (item.Total * item.ServiceChargeInPercent) / 100;

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgLedger, item.SrlNo, item.ServiceName, item.Qty, item.Rate, item.Total);
                dgLedger.Rows.Add(row);
            }

            CalculateBill(finalBillItems, _serviceCharge);
        }

        private void CalculateBill(List<VMHpFinalBill>  _finalBillItems,double serviceCharge)
        {
            txtDiscount.Text = "";
            txtPaid.Text = "";
            txtRemarks.Text = "";
            VMIPDInfo tagPatient = (VMIPDInfo)this.btnBillSave.Tag;

            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            //double _MedicineBill = _finalBillItems.Where(q=>q.ServiceName.ToLower()=="medicine bill").Sum(x => x.Total);
            //txtTotalBill.Tag = _MedicineBill;

            txtServiceCharge.Tag = serviceCharge;
            txtTotalBill.Text = _tDebit.ToString();

            double _total = 0;
            double.TryParse(_tDebit, out _total);

            double _serviceCharge = serviceCharge;

            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100;
               
            //}
            //else
            //{
            //    _serviceCharge = (_total * 25) / 100;
            //}

          

         

            double _gtotal = _total + _serviceCharge;

            txtServiceCharge.Text = _serviceCharge.ToString();
            txtGtotal.Text = _gtotal.ToString();


            VMIPDInfo _pInfo = (VMIPDInfo)btnBillSave.Tag;

            double _advancePaid = new HpFinancialService().GetRoughAdvancePaymentByPatient(_pInfo.AdmissionId);

            txtAdvancePaid.Text = _advancePaid.ToString();
            _gtotal = _gtotal - _advancePaid;

            txtDue.Text = _gtotal.ToString();
        }

        private void pathTransfer_Click(object sender, EventArgs e)
        {
            List<Patient> _pList = new PatientService().GetIndoorPatientList();

            List<HpPatientLedger> _hpLedegerList = new List<HpPatientLedger>();
            foreach (Patient _p in _pList)
            {
                HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNo(_p.AdmissionNo);
                if (_hp != null)
                {
                    double _pathBalance = new PatientLedgerService().GetPatientLedgerBalance(_p.PatientId);
                    double _currenthpBalance = new HpFinancialService().GetPatientCurrentBalance(_hp.AdmissionId);

                    HpPatientLedger _hpLedger = new HpPatientLedger();
                    _hpLedger.AdmissionId = _hp.AdmissionId;
                    _hpLedger.TranDate = _p.EntryDate;
                    _hpLedger.Particulars = "Pathology Bill No : " + _p.BillNo.ToString();
                    _hpLedger.Debit = _pathBalance;
                    _hpLedger.Credit = 0;
                    _hpLedger.Balance = _currenthpBalance - _pathBalance; // Negative balance means patient is payable this amount
                    _hpLedger.TransactionType = TransactionTypeEnum.HpPathologyBill.ToString();
                    _hpLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _hpLedegerList.Add(_hpLedger);

                }

            }

            if (_hpLedegerList.Count() > 0)
            {
                new HpFinancialService().SaveHpLedgerTransactionList(_hpLedegerList);
                MessageBox.Show("Transfreed");
            }
        }

        private async void btnBillSave_Click(object sender, EventArgs e)
        {
            if (btnBillSave.Tag == null)
            {
                MessageBox.Show("Patient not selected."); return;
            }

            if (dgLedger.Rows.Count == 0)
            {
                MessageBox.Show("No item selected"); return;
            }



            if (btnBillSave.Tag != null && !String.IsNullOrEmpty(lblName.Text))
            {

                VMHospitalDayWiseBillCarrier carrierDataObj = new VMHospitalDayWiseBillCarrier();

                carrierDataObj.PreparedBy = MainForm.LoggedinUser.Name;
                DateTime _transactionDateTime = Utils.GetServerDateAndTime();
                carrierDataObj.TDate = _transactionDateTime;
                carrierDataObj.TransactionTime = _transactionDateTime.ToString("hh:mm tt");

                VMIPDInfo _pInfo = (VMIPDInfo)btnBillSave.Tag;


                if (_pInfo != null)
                {

                    HpDayWiseBill _DayWisebill = new HpDayWiseBill();
                    _DayWisebill.BillNo = _pInfo.BillNo;
                    _DayWisebill.AdmissionId = _pInfo.AdmissionId;
                    _DayWisebill.DayBillNo = 0;
                    _DayWisebill.BillTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _DayWisebill.BillDate = Utils.GetServerDateAndTime();
                    _DayWisebill.Billdatefrom = dtpfrm.Value;
                    _DayWisebill.BillTimefrom = dtpfromtime.Value.ToString("hh:mm tt");
                    _DayWisebill.Billdateto = dtpto.Value;
                    _DayWisebill.BillTimeTo = dtptotime.Value.ToString("hh:mm tt");
                    _DayWisebill.PreparedBy = MainForm.LoggedinUser.Name;
                    carrierDataObj.hdaybill = _DayWisebill;


                    List<HpDayWiseBillDetail> _DayWiseBillDetailsList = new List<HpDayWiseBillDetail>();
                    foreach (DataGridViewRow row in dgLedger.Rows)
                    {
                        VMHpFinalBill selectedItems = row.Tag as VMHpFinalBill; ;

                        HpDayWiseBillDetail _DayWiseBillDetail = new HpDayWiseBillDetail();
                        _DayWiseBillDetail.ServiceHeadId = selectedItems.ServiceHeadId;
                        _DayWiseBillDetail.ServiceName = selectedItems.ServiceName;
                        _DayWiseBillDetail.Rate = selectedItems.Rate;
                        _DayWiseBillDetail.qnt = selectedItems.Qty;
                        _DayWiseBillDetail.Amount = selectedItems.Total;
                        _DayWiseBillDetailsList.Add(_DayWiseBillDetail);
                    }

                    if (_DayWiseBillDetailsList.Count > 0)
                    {
                    
                        carrierDataObj.hdaybilldetails = _DayWiseBillDetailsList;

                        carrierDataObj.pInfo = _pInfo;

                        double balance = 0;
                        double _serviceCharge = 0;
                        double _total = 0;
                        double.TryParse(txtTotalBill.Text, out _total);

                        double _MedicineBill = 0;
                        if (txtTotalBill.Tag != null)
                        {
                            double.TryParse(txtTotalBill.Tag.ToString(), out _MedicineBill);
                        }

                        double.TryParse(txtServiceCharge.Tag.ToString(), out _serviceCharge);

                        int _pmodId = 0;
                        PaymentMode _pMode = cmbPaymentMode.SelectedItem as PaymentMode;
                        if (_pMode != null)
                        {
                            _pmodId = _pMode.PMId;
                        }


                        int _PCId = 0;
                        PaymentChannel _pChannel = cmbPaymentChannel.SelectedItem as PaymentChannel;
                        if (_pChannel != null)
                        {
                            _PCId = _pChannel.PCId;
                        }

                        balance = 0 - _total;
                        carrierDataObj.SaleAmount = _total;
                        carrierDataObj.ServiceCharge = _serviceCharge;


                        double discount = 0;
                        double.TryParse(txtDiscount.Text, out discount);

                        carrierDataObj.DiscountAmount = discount;



                        double _advancePaidTk = 0; //new HpFinancialService().GetAdvancePaymentByPatient(_pInfo.AdmissionId);
                        double.TryParse(txtAdvancePaid.Text, out _advancePaidTk);
                        double cashpaidTk = 0;
                        double.TryParse(txtPaid.Text, out cashpaidTk);
                        double cardormobhpaidTk = 0;
                        double.TryParse(txtCardOrMobileReceiveTk.Text, out cardormobhpaidTk);

                        
                        carrierDataObj.CashPaidAmount = cashpaidTk;


                        if (cardormobhpaidTk > 0)
                        {

                            if (_pmodId == 2)
                            {
                                carrierDataObj.MobilePayment = cardormobhpaidTk;
                            }

                            if (_pmodId == 3)
                            {
                                carrierDataObj.CardPayment = cardormobhpaidTk;
                            }



                        }

                        carrierDataObj.VirtualPaymentCharge = 0;

                    }


                VMHospitalDayWiseBillCarrier2 _savedObj = await new HpFinancialService().SaveAndGetDayWiseBill(carrierDataObj);

                    ViewPrintView(_savedObj.SaveHpdayWIseBill.DayWiseBillId, lblCabin.Text);

                    dgLedger.SuspendLayout();
                    dgLedger.Rows.Clear();

                    txtTotalBill.Text = "";
                    txtGtotal.Text = "";
                    txtDiscount.Text = "";
                    txtPaid.Text = "";
                    txtDue.Text = "";
                    txtAdvancePaid.Text = "";
                    txtServiceCharge.Text = "";


                }

            }

           
           

           //             if (transactionList.Count > 0)
           //             {
           //                 HpFinancialService fpService = new HpFinancialService();
           //                 fpService.SaveDayWiseBillingLedger(transactionList);
           //             }

           //             
                        
           //             dgLedger.SuspendLayout();
           //             dgLedger.Rows.Clear();

           //             txtTotalBill.Text = "";
           //             txtGtotal.Text = "";
           //             txtDiscount.Text = "";
           //             txtPaid.Text = "";
           //             txtDue.Text = "";
           //             txtAdvancePaid.Text = "";
           //             txtServiceCharge.Text = "";
           //         }

           //         }

           //     }

            }


        private void ViewPrintView(long _billId, string _Cabin)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            if (string.IsNullOrEmpty(_Cabin))
            {
                _Cabin = "";
            }

            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

            DataSet ds = new HpFinancialService().GetDayWiseBillCashMemo(_billId);

            rptHPDayWIseBill _rptBill = new rptHPDayWIseBill();
            _rptBill.SetDataSource(ds);

            List<HPDayWiseBillingLedger> _pLedger = new HpFinancialService().GetDayWiseBillingLedgerById(_billId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetDayWiseCashMemotransaction(_pLedger);

            foreach (var litem in _cashtranList)
            {
                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();

                _rptBill.SetParameterValue(p1, litem.Label);
                _rptBill.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rptBill.SetParameterValue(p3, "");
                }
                else
                {
                    if (litem.Value.ToString().ToLower().Contains('.'))
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString());
                    }
                    else
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString() + ".00");
                    }

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


            for (int _count = _index + 1; _count <= 8; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rptBill.SetParameterValue(p1, "");
                _rptBill.SetParameterValue(p2, "");
                _rptBill.SetParameterValue(p3, "");
            }


            _rptBill.SetParameterValue("CabinNo", _Cabin);
            _rptBill.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
            _rptBill.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());
            _rptBill.SetParameterValue("WaterMark", "");

            if (isDue)
            {
                _rptBill.SetParameterValue("PayStatus", "DUE");
            }
            else
            {
                _rptBill.SetParameterValue("PayStatus", "PAID");
            }

            //Header & Footer Texts
            _rptBill.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);

            if (Configuration.ORG_CODE == "1")
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote1);
                _rptBill.SetParameterValue("OrgLicenseNo", "License No:" + ComapnyDetail.MAH_NAY_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", "Reg. Code:" + ComapnyDetail.MAH_NAY_Hospital_RegCode);
            }
            else
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote2);
                _rptBill.SetParameterValue("OrgLicenseNo", ComapnyDetail.MAH_AKH_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", ComapnyDetail.MAH_AKH_Hospital_RegCode);
            }


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptBill;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void Free_Cabin(VMIPDInfo _pInfo)
        {

            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedService().GetHpOccupiedCabinListByAdmisissionId(_pInfo.AdmissionId);

            foreach(var acconObj in _accomList)
            {
                CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(acconObj.CabinId);

                _cabin.IsBooked = false;
                new HospitalCabinBedService().UpdateCabinInfo(_cabin);
            }

           
        }

        private void ViewPrintView(long _billId, string _billType, string _Cabin)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);



            DataSet ds = new HpFinancialService().GetHpCashMemo(_billId);


            rptHpBill _rptBill = new rptHpBill();
            _rptBill.SetDataSource(ds);

            List<HpPatientLedgerFinal> _pLedger = new HpFinancialService().GetPatientLedgerFinalById(_billId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetHospitalCashMemotransaction(_pLedger);



            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _rptBill.SetParameterValue(p1, litem.Label);
                _rptBill.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rptBill.SetParameterValue(p3, "");
                }
                else
                {
                    if (litem.Value.ToString().ToLower().Contains('.')) {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString());
                    }else
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString()+".00");
                    }
                   
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


            for (int _count = _index + 1; _count <= 8; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rptBill.SetParameterValue(p1, "");
                _rptBill.SetParameterValue(p2, "");
                _rptBill.SetParameterValue(p3, "");
            }


            _rptBill.SetParameterValue("CabinNo", _Cabin);
            _rptBill.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
            _rptBill.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());
            _rptBill.SetParameterValue("WaterMark", "Print mode: " + _billType);

            if (isDue)
            {
                _rptBill.SetParameterValue("PayStatus", "DUE");
            }
            else
            {
                _rptBill.SetParameterValue("PayStatus", "PAID");
            }


            //Header & Footer Texts
            _rptBill.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);
            if (Configuration.ORG_CODE == "1")
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote1);
                _rptBill.SetParameterValue("OrgLicenseNo", "License No:" + ComapnyDetail.MAH_NAY_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", "Reg. Code:" + ComapnyDetail.MAH_NAY_Hospital_RegCode);
            }
            else
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote2);
                _rptBill.SetParameterValue("OrgLicenseNo", ComapnyDetail.MAH_AKH_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", ComapnyDetail.MAH_AKH_Hospital_RegCode);
            }

           

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptBill;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private CabinInfo GetCabinNo(long _billId)
        {
            HospitalBill _hbill = new HpFinancialService().GetHospitalBillById(_billId);

            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hbill.AdmissionId);

            if (_accomInfo == null)
            {
                return new CabinInfo();
            }
            else
            {
                CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                return _Cabin;
            }


        }

        private CabinInfo GetRoughBillCabinNo(long _billId)
        {
            HospitalRoughBill _hbill = new HpFinancialService().GetHospitalRoughBillById(_billId);

            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hbill.AdmissionId);

            if (_accomInfo == null)
            {
                return new CabinInfo();
            }
            else
            {
                CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                return _Cabin;
            }


        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalBill();
        }

        private void CalculateFinalBill()
        {
            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
          .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            double _total = 0;
            double.TryParse(_tDebit, out _total);



            double _advancePaid = 0;
            double.TryParse(txtAdvancePaid.Text, out _advancePaid);

            double _cardormobpaid = 0;
            double.TryParse(txtCardOrMobileReceiveTk.Text, out _cardormobpaid);

            double _cashpaid = 0;
            double.TryParse(txtPaid.Text, out _cashpaid);

            //double _MedicineBill = 0;
            //if (txtTotalBill.Tag != null)
            //{
            //     double.TryParse(txtTotalBill.Tag.ToString(), out _MedicineBill);
            //}

            double _serviceCharge = 0;

            double.TryParse(txtServiceCharge.Tag.ToString(), out _serviceCharge);

            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100;
            //}
            //else
            //{
            //    _serviceCharge = (_total * 25) / 100;
            //}


            double _disc = 0;

            double.TryParse(txtDiscount.Text, out _disc);

            if (_disc > _serviceCharge / 2)
            {
                DialogResult result = MessageBox.Show("Discount exceeds the limit 50% of service charge. Continue yet..", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    if (_disc > _serviceCharge)
                    {
                        txtDiscount.Text = _serviceCharge.ToString();
                        _disc = _serviceCharge;
                    }

                    txtPaid.Focus();

                }
                else
                {
                    txtDiscount.Text = "";
                    return;
                }
            }



            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100 - _disc;
            //}
            //else
            //{
            //    _serviceCharge= (_total  * 25) / 100 - _disc;
            //}


            _serviceCharge = _serviceCharge - _disc;

            txtServiceCharge.Text = _serviceCharge.ToString();

            txtGtotal.Text = (_total + _serviceCharge).ToString();

            txtDue.Text = ((_total - (_advancePaid + _cardormobpaid + _cashpaid) + _serviceCharge)).ToString();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalBill();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = Utils.GetServerDateAndTime().ToString("hh:mm tt");
        }

        private void btnRoughBill_Click(object sender, EventArgs e)
        {

            string _msg = "Rough bill generated successfully.";

            GenerateRoughBill("Rough", _msg);

            

           // CalculateBill();
        }

        private void GenerateRoughBill(string _billType,string _msg)
        {
            string _Cabin = string.Empty;
            CabinInfo _cabinObj = new CabinInfo();

            if (btnBillSave.Tag != null && !String.IsNullOrEmpty(lblName.Text))
            {


                VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

                if (_pInfo != null)
                {
                    List<HpPatientLedgerRough> _pLRough = new HpFinancialService().GetRoughAdvancePaymentList(_pInfo.AdmissionId);

                    if (!new HpFinancialService().DeleteExistingBill(_pInfo.AdmissionId))
                    {
                        return;
                    }

                    HospitalRoughBill _hbill = new HospitalRoughBill();
                    _hbill.AdmissionId = _pInfo.AdmissionId;
                    _hbill.BillDate = Utils.GetServerDateAndTime();
                    _hbill.BillTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _hbill.BillNo = _pInfo.BillNo;
                    _hbill.Remarks = txtRemarks.Text;
                    _hbill.BillType = _billType;
                    _hbill.PreparedBy = MainForm.LoggedinUser.Name;

                    long _hbillId = new HpFinancialService().SaveHpRoughBill(_hbill);
                    if (_hbillId > 0)
                    {

                        List<HospitalRoughBillDetail> _hbilldetailList = new List<HospitalRoughBillDetail>();
                        foreach (DataGridViewRow row in dgLedger.Rows)
                        {
                            VMHpFinalBill selectedItems = row.Tag as VMHpFinalBill;

                            HospitalRoughBillDetail _hbdetail = new HospitalRoughBillDetail();
                            _hbdetail.HospitalRoughBillId = _hbillId;
                            _hbdetail.ServiceName = selectedItems.ServiceName;
                            _hbdetail.Qty = selectedItems.Qty;
                            _hbdetail.Rate = selectedItems.Rate;
                            _hbdetail.Total = selectedItems.Total;
                            _hbilldetailList.Add(_hbdetail);
                        }

                        if (_hbilldetailList.Count > 0)
                        {
                            if (new HpFinancialService().SaveHpRoughBillDetail(_hbilldetailList))
                            {

                                MessageBox.Show(_msg);


                                _cabinObj = GetRoughBillCabinNo(_hbillId);



                                double balance = 0;
                                double _serviceCharge = 0;
                                double _total = 0;
                                double.TryParse(txtTotalBill.Text, out _total);

                                double _MedicineBill = 0;
                                if (txtTotalBill.Tag != null)
                                {
                                    double.TryParse(txtTotalBill.Tag.ToString(), out _MedicineBill);
                                }

                                double.TryParse(txtServiceCharge.Tag.ToString(), out _serviceCharge);
                                //if (Configuration.ORG_CODE == "2")
                                //{
                                //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100;
                                //}
                                //else
                                //{
                                //    _serviceCharge = (_total * 25) / 100;
                                //}



                                balance = 0 - Convert.ToDouble(txtTotalBill.Text);
                                //Save On Entry Payment Information
                                List<HpPatientLedgerRough> transactionList = new List<HpPatientLedgerRough>();

                                double discount = 0;
                                double.TryParse(txtDiscount.Text, out discount);

                                HpPatientLedgerRough pLedger = new HpPatientLedgerRough();
                                pLedger.HospitalRoughBillId = _hbillId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                pLedger.Particulars = "Total Bill";
                                pLedger.Debit = Convert.ToDouble(txtTotalBill.Text);
                                pLedger.Credit = 0;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.HpTotalBiLL.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                pLedger.TransactionTerminal = MainForm.WorkStationId;

                                transactionList.Add(pLedger);


                                balance = balance - _serviceCharge;
                                pLedger = new HpPatientLedgerRough();
                                pLedger.HospitalRoughBillId = _hbillId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                pLedger.Particulars = "Service Charge";
                                pLedger.Debit = _serviceCharge;
                                pLedger.Credit = 0;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.HpServiceCharge.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                pLedger.TransactionTerminal = MainForm.WorkStationId;

                                transactionList.Add(pLedger);


                                if (discount > 0)
                                {

                                    balance = balance + discount;
                                    pLedger = new HpPatientLedgerRough();
                                    pLedger.HospitalRoughBillId = _hbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                    pLedger.Particulars = "Discount";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = discount;
                                    pLedger.Balance = balance;
                                    pLedger.TransactionType = TransactionTypeEnum.HpDiscount.ToString();
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    pLedger.TransactionTerminal = MainForm.WorkStationId;

                                    transactionList.Add(pLedger);
                                }


                                // Check whether advance payment made by this user

                                double _advancePaidTk = 0; //new HpFinancialService().GetAdvancePaymentByPatient(_pInfo.AdmissionId);
                                double.TryParse(txtAdvancePaid.Text, out _advancePaidTk);

                                if (_advancePaidTk > 0)
                                {

                                    foreach (HpPatientLedgerRough _rl in _pLRough)
                                    {
                                        balance = balance + _rl.Credit;
                                        pLedger = new HpPatientLedgerRough();
                                        pLedger.HospitalRoughBillId = _hbillId;
                                        pLedger.TranDate = _rl.TranDate;
                                        pLedger.TransactionTime = _rl.TransactionTime;
                                        pLedger.Particulars = "Advance Payment";
                                        pLedger.Debit = 0;
                                        pLedger.Credit = _rl.Credit;
                                        pLedger.Balance = balance;
                                        pLedger.TransactionType = TransactionTypeEnum.HpAdvance.ToString();
                                        pLedger.OperateBy = _rl.OperateBy;
                                        pLedger.TransactionTerminal = _rl.TransactionTerminal;

                                        transactionList.Add(pLedger);
                                    }
                                }

                                double paidTk = 0;
                                double.TryParse(txtPaid.Text, out paidTk);

                                if (paidTk > 0)
                                {

                                  
                                        balance = balance + paidTk;
                                        pLedger = new HpPatientLedgerRough();
                                        pLedger.HospitalRoughBillId = _hbillId;
                                        pLedger.TranDate = Utils.GetServerDateAndTime();
                                        pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                        pLedger.Particulars = "Advance Payment";
                                        pLedger.Debit = 0;
                                        pLedger.Credit = paidTk;
                                        pLedger.Balance = balance;
                                        pLedger.TransactionType = TransactionTypeEnum.HpAdvance.ToString();
                                        pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                        pLedger.TransactionTerminal = MainForm.WorkStationId;

                                        transactionList.Add(pLedger);

                                        
                                   
                                }

                                if (transactionList.Count > 0)
                                {
                                    HpFinancialService fpService = new HpFinancialService();
                                    fpService.SaveHpRoughLedger(transactionList);
                                }

                            }
                        }

                        if (_billType.ToLower() == "rough")
                        {
                            ViewRoughPrintView(_hbillId, _billType, _cabinObj.CabinNo);
                        }
                        else
                        {
                            ViewAdvanceReceipt(_hbillId, _cabinObj.CabinNo);
                        }

                        dgLedger.SuspendLayout();
                        dgLedger.Rows.Clear();
                        lblName.Text = "";
                        lblCabin.Text = "";
                       
                        txtAdvancePaid.Text = "";
                        txtServiceCharge.Text = "";
                        txtRemarks.Text = "";
                        txtGtotal.Text = "";
                        txtTotalBill.Text = "";
                        txtTotalBill.Tag = null;
                        txtDiscount.Text = "";
                        txtDue.Text = "";
                        txtPaid.Text = "";
                    }

                }

            }
            else
            {
                MessageBox.Show("Patient not selected. Plz select a patient and try again.");
            }

        }

        private void ViewAdvanceReceipt(long _hbillId, string cabinNo)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

            if (_pInfo != null)
            {

                HospitalPatientInfo _PatientInfo = new HospitalService().GetHospitalPatientInfoById(_pInfo.AdmissionId);

                if (_PatientInfo.Status.ToLower() == "discharged")
                {
                    MessageBox.Show("Patient already discharged."); return;
                }


                HospitalRoughBill _rBill = new HpFinancialService().GetHospitalRoughBillByAdmissionId(_pInfo.AdmissionId);

                if (_rBill == null)
                {
                    MessageBox.Show("No transaction found."); return;
                }


                CabinInfo _cabinObj = GetRoughBillCabinNo(_rBill.HospitalRoughBillId);

                DataSet ds = new HpFinancialService().GetHpRoughCashMemo(_rBill.HospitalRoughBillId);

                rptMoneyReceipt _moneyReceipt = new rptMoneyReceipt();

                _moneyReceipt.SetDataSource(ds);

                List<HpPatientLedgerRough> _pLRough = new HpFinancialService().GetRoughAdvancePaymentList(_pInfo.AdmissionId);

                if (_pLRough.Count == 0)
                {
                    MessageBox.Show("No advance found."); return; 
                }

                long maxTran = _pLRough.Max(w => w.TranId);
                var _ledger = _pLRough.Where(w => w.TranId == maxTran).FirstOrDefault();


                _moneyReceipt.SetParameterValue("CabinNo", _cabinObj.CabinNo);
                _moneyReceipt.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
                _moneyReceipt.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());

                _moneyReceipt.SetParameterValue("AdvanceTk", _ledger.Credit.ToString());


                // Header and Footer Settings
                _moneyReceipt.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);
                if (Configuration.ORG_CODE == "1")
                {
                    _moneyReceipt.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                    _moneyReceipt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", " + ComapnyDetail.EmailAddress);
                    _moneyReceipt.SetParameterValue("footnote", ComapnyDetail.footNote1);
                }
                else
                {
                    _moneyReceipt.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                    _moneyReceipt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                    _moneyReceipt.SetParameterValue("footnote", ComapnyDetail.footNote2);
                }



                ReportViewer rv = new ReportViewer();
                rv.crviewer.ReportSource = _moneyReceipt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private void ViewRoughPrintView(long _billId, string _billType, string _Cabin)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);



            DataSet ds = new HpFinancialService().GetHpRoughCashMemo(_billId);


            rptHpBill _rptBill = new rptHpBill();
            _rptBill.SetDataSource(ds);

            List<HpPatientLedgerRough> _pLedger = new HpFinancialService().GetPatientLedgerRoughById(_billId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetHospitalRoughCashMemotransaction(_pLedger);



            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _rptBill.SetParameterValue(p1, litem.Label);
                _rptBill.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rptBill.SetParameterValue(p3, "");
                }
                else
                {
                    if (litem.Value.ToString().ToLower().Contains('.'))
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString());
                    }
                    else
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString() + ".00");
                    }
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


            for (int _count = _index + 1; _count <= 8; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rptBill.SetParameterValue(p1, "");
                _rptBill.SetParameterValue(p2, "");
                _rptBill.SetParameterValue(p3, "");
            }


            _rptBill.SetParameterValue("CabinNo", _Cabin);
            _rptBill.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
            _rptBill.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());
            _rptBill.SetParameterValue("WaterMark", "Print mode: " + _billType);




            if (isDue)
            {
                _rptBill.SetParameterValue("PayStatus", "DUE");
            }
            else
            {
                _rptBill.SetParameterValue("PayStatus", "PAID");
            }


            // Header and Footer Settings
            _rptBill.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);
            if (Configuration.ORG_CODE == "1")
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", "+ ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote1);
            }
            else
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote2);
            }

           

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptBill;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnDueCollection_Click(object sender, EventArgs e)
        {
            frmHpDueCollection _frm = new frmHpDueCollection();
            _frm.Show();
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByCabin.Text, "Cabin");
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
                //    _lisPatientInfo = _lisPatientInfo.Where(x => x.ca.ToLower().Contains(_prefix.Trim().ToLower())).ToList();

            }

            if (_lisPatientInfo == null || _lisPatientInfo.Count() == 0) return;

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            lblTotalPatient.Tag = _lisPatientInfo;

            FillListGrid(_lisPatientInfo);
        }

        private void btnMoneyReceipt_Click(object sender, EventArgs e)
        {
            string _msg = "Advance collection successful.";

            GenerateRoughBill("Advance", _msg);
        }

        private void dgLedger_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgLedger.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgLedger.SelectedRows[0];
                VMHpFinalBill _bInfo = ((VMHpFinalBill)row.Tag);

                VMIPDInfo _pInfo= ((VMIPDInfo)btnBillSave.Tag);

                if (_bInfo.ServiceName.ToLower().Trim()== "medicine bill")
                {

                    ViewMedicineDetail(_pInfo.BillNo, lblCabin.Text);

                }
                else if(_bInfo.ServiceName.ToLower().Trim() == "investigations bill")
                {
                    ViewInvestigationDetail(_pInfo.BillNo, lblCabin.Text);
                }
                else if (_bInfo.ServiceName.ToLower().Trim() == "consultation")
                {
                    ViewConsultancyList(_pInfo.BillNo, lblCabin.Text);
                }
                else if (_bInfo.ServiceName.ToLower().Trim() == "in patient care")
                {
                    ViewInPatientCare(_pInfo.BillNo, lblCabin.Text);
                }
            }
        }

        private void ViewInPatientCare(long billNo, string text)
        {
            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(billNo);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new HpFinancialService().GetInPatientCareServiceByPatientId(_pInfo.AdmissionId);


            rptConsultancyByPatient _rpt = new rptConsultancyByPatient();
            _rpt.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            // _invDetail.SetParameterValue("CabinNo", _CabinNo);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewConsultancyList(long billNo, string CabinNo)
        {
            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(billNo);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new HpFinancialService().GetConsultancyDetailsByPatientId(_pInfo.AdmissionId);


            rptConsultancyByPatient _rpt = new rptConsultancyByPatient();
            _rpt.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

           // _invDetail.SetParameterValue("CabinNo", _CabinNo);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewInvestigationDetail(long _billNum, string _CabinNo)
        {
            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNum);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new DiagFinancialService().GetInvestigationDetailsByPatientId(_pInfo.AdmissionId);


            rptIPDInvestigationList _invDetail = new rptIPDInvestigationList();
            _invDetail.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            _invDetail.SetParameterValue("CabinNo", _CabinNo);

            rv.crviewer.ReportSource = _invDetail;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewMedicineDetail(long _billNum, string _Cabin)
        {

            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNum);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new PhReportingService().GetMedicineDetailsByPatientId(_pInfo.AdmissionId);


            rptIPDPatientMedicineDetail _medicineDetail = new rptIPDPatientMedicineDetail();
            _medicineDetail.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            _medicineDetail.SetParameterValue("CabinNo", _Cabin);

            rv.crviewer.ReportSource = _medicineDetail;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnCCNote_Click(object sender, EventArgs e)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

            if (_pInfo != null)
            {
                DataSet ds = new HpFinancialService().GetCabinChargeDetails(_pInfo.AdmissionId);

                rptCabinChargeJustificationNote _rpt = new rptCabinChargeJustificationNote();

                _rpt.SetDataSource(ds);

                //_rpt.SetParameterValue("RegNo", txtRegNo.Text);

                ReportViewer rv = new ReportViewer();


                // _cashmemo.DataDefinition.FormulaFields[5].Text = txtHCVAdjustment.Text;
                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(18, 12);

            isInMaxView = true;

            btnMaxView.Visible = false;
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            SetPatientMinView();
        }

        private void SetPatientMinView()
        {

            pnlPatient.Location = new Point(pnlPatient.Location.X + 1300, pnlPatient.Location.Y);

            isInMaxView = false;

            btnMaxView.Visible = true;
        }

        private void dgPatient_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {
                waitForm.Show();

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);
                btnBillSave.Tag = _pInfo;

                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;
               

                if (_pInfo.PackageId > 0)
                {
                    GoToPackageBillingMethod(_pInfo);
                }
                else
                {

                    List<HpCabinCharge> _cabinChargeList = new List<HpCabinCharge>();

                    //CalculateCabinChargeWith24HousPlusGraceperiodRole(_pInfo);

                    new HpFinancialService().DeleteExistingCabinChargeCalculation(_pInfo.AdmissionId);

                    this.DayWiseSegmantizeTheAccomodation(_pInfo,dtpfrm.Value,dtpto.Value);

                    this.DaywiseSegmantizeTheExtraAccomodation(_pInfo, dtpfrm.Value, dtpto.Value);

                    List<HpCabinChargeSegmantDetail> _ccsDlist = new List<HpCabinChargeSegmantDetail>();

                    HpCabinChargeSegmantMaster _ccMaster = new HospitalCabinBedService().GetCabinChargeSegmantMaster();

                    //Admission Day Bill Count
                    HpCabinChargeSegmantDetail _ccAdmissionDay = new HospitalCabinBedService().GetAdmissionDayCabinChargeSegmantDetail();
                    if (_ccAdmissionDay != null && _ccMaster.IsAdmissionDayBillApplicable)
                    {
                        HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                        _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                        _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                        _HpcabinCharge.CabinId = _ccAdmissionDay.CabinId;

                        _HpcabinCharge.Particulars = "Cabin charge: " + _ccAdmissionDay.CabinNo;

                        _HpcabinCharge.TotalDays = 1;
                        _HpcabinCharge.Rate = _ccAdmissionDay.Rent;
                        _HpcabinCharge.Amount = _ccAdmissionDay.Rent * 1;
                        _HpcabinCharge.AccomodationTypeId = _ccAdmissionDay.AccomodationTypeId;
                        _HpcabinCharge.ServiceHeadId = _ccAdmissionDay.ServiceHeadId;
                        _HpcabinCharge.BillJustification = "Bill for Admission Day";
                        _cabinChargeList.Add(_HpcabinCharge);

                        new HpFinancialService().SaveCabinChargeRange(_cabinChargeList);
                    }

                    // Block to Calculate Cabin Charge Other than Admission Day

                    List<HpCabinChargeSegmantDetail> _ccsdforcurrentoccupation = new HospitalCabinBedService().GetCabinChargeSegmantDetailForCurrentOccupation(_pInfo.AddmissionDate);
                    int _totalOccupiedDate = _ccsdforcurrentoccupation.Count;
                    int _dateCount = 0;

                    _cabinChargeList = new List<HpCabinCharge>();
                    for (var date = dtpfrm.Value.Date; date <= dtpto.Value.Date; date = date.AddDays(1))
                    {
                        HpCabinChargeSegmantDetail _billForThisDate = new HospitalCabinBedService().GetCabinChargeSegmantDetailByDate(date);

                       
                            
                                HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                                _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                                _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                                _HpcabinCharge.CabinId = _billForThisDate.CabinId;

                                _HpcabinCharge.Particulars = "Cabin charge: " + _billForThisDate.CabinNo;
                                _HpcabinCharge.TotalDays = 1;
                                _HpcabinCharge.Rate = _billForThisDate.Rent;
                                _HpcabinCharge.Amount = _billForThisDate.Rent * 1;
                                _HpcabinCharge.AccomodationTypeId = _billForThisDate.AccomodationTypeId;
                                _HpcabinCharge.ServiceHeadId = _billForThisDate.ServiceHeadId;
                                _HpcabinCharge.BillJustification = "Bill for the date of : " + date.ToString("dd/MM/yyyy");
                                _cabinChargeList.Add(_HpcabinCharge);
                            
                        


                    }


                    if (_cabinChargeList.Count > 0)
                    {
                        new HpFinancialService().SaveCabinChargeRange(_cabinChargeList);
                    }

                    // Block to Calculate Extra Cabin Charge

                    List<HpCabinChargeSegmantDetail> _ccsdforextraccupation = new HospitalCabinBedService().GetCabinChargeSegmantDetailForExtraOccupation();

                    if (_ccsdforextraccupation.Count > 0)
                    {
                        HpCabinChargeSegmantDetail _sgd = _ccsdforextraccupation.FirstOrDefault();

                        _cabinChargeList = new List<HpCabinCharge>();
                        for (var date = _sgd.StayingDate; date <= Utils.GetServerDateAndTime(); date = date.AddDays(1))
                        {
                            HpCabinChargeSegmantDetail _billForThisDate = new HospitalCabinBedService().GetExtraCabinChargeSegmantDetailByDate(date);

                            if (_billForThisDate != null)
                            {
                                HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                                _HpcabinCharge.AdmissionId = _pInfo.AdmissionId;
                                _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                                _HpcabinCharge.CabinId = _billForThisDate.CabinId;

                                _HpcabinCharge.Particulars = "Extar Cabin charge: " + _billForThisDate.CabinNo;
                                _HpcabinCharge.TotalDays = 1;
                                _HpcabinCharge.Rate = _billForThisDate.Rent;
                                _HpcabinCharge.Amount = _billForThisDate.Rent * 1;
                                _HpcabinCharge.AccomodationTypeId = _billForThisDate.AccomodationTypeId;
                                _HpcabinCharge.ServiceHeadId = _billForThisDate.ServiceHeadId;
                                _HpcabinCharge.BillJustification = "Bill for the date of : " + date.ToString("dd/MM/yyyy");
                                _cabinChargeList.Add(_HpcabinCharge);
                            }

                        }


                        if (_cabinChargeList.Count > 0)
                        {
                            new HpFinancialService().SaveCabinChargeRange(_cabinChargeList);
                        }
                    }


                    bool IsAdmissionFeeApplicable = true;


                    DateTime _startDateTime = new CalculateCabinCharge().CombinedDateAndTimePart(dtpfrm.Value, dtpfromtime.Value.ToString());

                    DateTime _endDateTime = new CalculateCabinCharge().CombinedDateAndTimePart(dtpto.Value, dtptotime.Value.ToString());

                    Thread.Sleep(100);
                    List<VMHpFinalBill> finalBillItems = new HpFinancialService().GetHpDayWiseBillItems(_pInfo.AdmissionId, _startDateTime.ToString("MM/dd/yyyy HH:mm:ss"), _endDateTime.ToString("MM/dd/yyyy HH:mm:ss"), IsAdmissionFeeApplicable);

                    FillBillGrid(finalBillItems);
                     waitForm.Close();
                    
                    if (isInMaxView)
                    {
                        SetPatientMinView();
                    }
                }

            }


        }

        private void DaywiseSegmantizeTheExtraAccomodation(VMIPDInfo _pInfo, DateTime _dtpfrm, DateTime _dtpto)
        {
            bool IsAdmissionDayAndReleaseDaySame = false;
            bool IsAdmissionDayBillApplicable = false;
            bool IsOccupationMorethanTwoCalendarDate = false;
            bool IsAdmissionDay = false;

            List<DateTime> _rollingDateList = new List<DateTime>();

            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedService().GetHpExtraAccomodationListByPatient(_pInfo.AdmissionId);

            if (_accomList.Count == 0) return;

          
            HpCabinChargeSegmantMaster _ccMS = new HospitalCabinBedService().GetHpCabinChargeMasterSegmant();

            _rollingDateList = new List<DateTime>(); //For Release and Occupied Date Count

            //  DateTime _firstBillingHour = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_pInfo.AddmissionDate.Date, _pInfo.AdmTime, "11:59:59 PM");

            List<HpCabinChargeSegmantDetail> ccgList = new List<HpCabinChargeSegmantDetail>();

            foreach (var item in _accomList)
            {
                ccgList = new List<HpCabinChargeSegmantDetail>();

                
                    for (var date = _dtpfrm.Date; date <= _dtpto.Date; date = date.AddDays(1))
                    {

                        HpCabinChargeSegmantDetail ccg = new HpCabinChargeSegmantDetail();
                        ccg.SMId = _ccMS.SMId;
                        ccg.BookOrder = item.AccomId;
                        ccg.AdmissionId = item.AdmissionId;
                        ccg.CabinId = item.CabinId;
                        CabinInfo _c = new HospitalCabinBedService().GetCabinInfoId(item.CabinId);
                        ccg.CabinNo = _c.CabinNo;
                        ccg.Rent = _c.Rent;
                        ccg.StayingDate = date;
                        ccg.OccupationStatus = "ExtraOccupied";

                        ccg.IsAdmissionDay = false;
                        ccgList.Add(ccg);

                    }
                

                if (ccgList.Count > 0)
                {
                    new HospitalCabinBedService().SaveHpCabinChargeSegmantDetail(ccgList);
                }
            }
        }

        private void DayWiseSegmantizeTheAccomodation(VMIPDInfo _pInfo, DateTime _dtfrm, DateTime _dtpto)
        {
            bool IsAdmissionDayAndReleaseDaySame = false;
            bool IsAdmissionDayBillApplicable = false;
            bool IsOccupationMorethanTwoCalendarDate = false;
            bool IsAdmissionDay = false;

            //List<DateTime> _rollingDateList = new List<DateTime>();

            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedService().GetHpAccomodationListByPatient(_pInfo.AdmissionId);

            //if (_pInfo.AddmissionDate.Date == Utils.GetServerDateAndTime().Date)
            //{
            //    IsAdmissionDayAndReleaseDaySame = true;
            //}

            //for (var date = _pInfo.AddmissionDate; date <= Utils.GetServerDateAndTime(); date = date.AddDays(1))
            //{
            //    _rollingDateList.Add(date);
            //}

            //if (_rollingDateList.Count > 2)
            //{
            //    IsOccupationMorethanTwoCalendarDate = true;
            //}

            double _timeDistanceInhours = 0;
            double _days = 0;
            double _hours = 0;


            //if (IsAdmissionDayAndReleaseDaySame)
            //{
            //    _timeDistanceInhours = new CalculateCabinCharge().GetTimeDistanceInHours(_pInfo.AddmissionDate, _pInfo.AdmTime, Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"));
            //    _days = _timeDistanceInhours / 24;
            //    _hours = _timeDistanceInhours % 24;

            //    if (_hours >= 2) IsAdmissionDayBillApplicable = true;

            //}

            //if (_rollingDateList.Count > 1)
            //{
            //    // DateTime _ThresholdTimeFor6HoursGrace = new DateTime(_pInfo.AddmissionDate.Year, _pInfo.AddmissionDate.Month, _pInfo.AddmissionDate.Day, 18, 0, 0);
            //    DateTime _ThresholdTimeFor12HoursGrace = new DateTime(_pInfo.AddmissionDate.Year, _pInfo.AddmissionDate.Month, _pInfo.AddmissionDate.Day, 12, 0, 0);
            //    DateTime _ActualAdmissionDateAndTime = new CalculateCabinCharge().CombinedDateAndTimePart(_pInfo.AddmissionDate, _pInfo.AdmTime);

            //    if (_ActualAdmissionDateAndTime.TimeOfDay < _ThresholdTimeFor12HoursGrace.TimeOfDay)
            //    {
            //        IsAdmissionDayBillApplicable = true;
            //    }

            //}



            HpCabinChargeSegmantMaster _cabinChargeMaster = new HpCabinChargeSegmantMaster();
            _cabinChargeMaster.AdmissionId = _pInfo.AdmissionId;
            _cabinChargeMaster.AdmissionDate = _pInfo.AddmissionDate;
            _cabinChargeMaster.AdmissionTime = _pInfo.AdmTime;
            _cabinChargeMaster.IsAdmissionDayBillApplicable = false;
            _cabinChargeMaster.IsAdmissionDayAndReleaseDaySame = false;
            _cabinChargeMaster.IsOccupationMorethanTwoCalendarDate = IsOccupationMorethanTwoCalendarDate;

            long _MasterId = new HospitalCabinBedService().SaveHpCabinChargeSegmantMaster(_cabinChargeMaster);

            //_rollingDateList = new List<DateTime>(); // For Release and Occupied Date Count

            //  DateTime _firstBillingHour = new CalculateCabinCharge().GetAccomodateDateAddingGracePeriod(_pInfo.AddmissionDate.Date, _pInfo.AdmTime, "11:59:59 PM");

            List<HpCabinChargeSegmantDetail> ccgList = new List<HpCabinChargeSegmantDetail>();

            foreach (var item in _accomList)
            {
                ccgList = new List<HpCabinChargeSegmantDetail>();

               
                    for (var date = _dtfrm.Date; date <= _dtpto.Date; date = date.AddDays(1))
                    {

                        HpCabinChargeSegmantDetail ccg = new HpCabinChargeSegmantDetail();
                        ccg.SMId = _MasterId;
                        ccg.BookOrder = item.AccomId;
                        ccg.AdmissionId = item.AdmissionId;
                        ccg.CabinId = item.CabinId;
                        CabinInfo _c = new HospitalCabinBedService().GetCabinInfoId(item.CabinId);
                        ccg.CabinNo = _c.CabinNo;
                        ccg.AccomodationTypeId = _c.AccomodationTypeId;
                        ccg.ServiceHeadId = new HospitalCabinBedService().GetCabinServiceHeadId(_c.AccomodationTypeId).ServiceHeadId;
                        ccg.Rent = _c.Rent;
                        ccg.StayingDate = date;
                        ccg.OccupationStatus = "Occupied";

                       
                            ccg.IsAdmissionDay = false;
                        

                        ccgList.Add(ccg);

                    }
                

                if (ccgList.Count > 0)
                {
                    new HospitalCabinBedService().SaveHpCabinChargeSegmantDetail(ccgList);
                }
            }
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
           

                CalculateFinalBill();
            
        }

        private void txtCardOrMobileReceiveTk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTransactionNo.Focus();
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

        private void txtAdmId_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "By Bill No")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtAdmId.Text, "Admid");
            }
        }

        private void txtSearchByRefdDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByRefdDoc.Text.Trim() == "Search by Refd. Doc")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByRefdDoc.Text, "RefdDoc");
            }
        }

        private void pnlPatient_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_clicked(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void btnDateWiseBillShow_Click(object sender, EventArgs e)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);
           
            btnBillSave.Tag = _pInfo;

            bool IsAdmissionFeeApplicable = true;

            List<VMHpFinalBill> finalBillItems = new HpFinancialService().GetHpFinalBillItems(_pInfo.AdmissionId, IsAdmissionFeeApplicable);

              FillBillGrid(finalBillItems);
        }

        private void btnDueCollection_Click_1(object sender, EventArgs e)
        {
            frmHpDayWiseDueCollection _frm = new frmHpDayWiseDueCollection();
            _frm.Show();
        }
    }
}
