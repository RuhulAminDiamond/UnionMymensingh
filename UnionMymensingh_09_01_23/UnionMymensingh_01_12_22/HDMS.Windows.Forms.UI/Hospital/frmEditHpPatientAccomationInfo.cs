using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmEditHpPatientAccomationInfo : Form
    {
        public frmEditHpPatientAccomationInfo()
        {
            InitializeComponent();
        }

        private void txtHBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _hbillNo = 0;
                long.TryParse(txtHBillNo.Text, out _hbillNo);

                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_hbillNo);
                txtHBillNo.Tag = _pInfo;
                List<VMHpPatientAccomodationInfo> accomList  = new HospitalService().GetHpAccomDetails(_pInfo.AdmissionId);

                FillAccomGrid(accomList);

                CalculateCurrentCabinCharges(_pInfo);

                
            }
        }

        private void CalculateCurrentCabinCharges(HospitalPatientInfo _pInfo)
        {
            List<HpCabinCharge> _cabinChargeList = new List<HpCabinCharge>();

            //CalculateCabinChargeWith24HousPlusGraceperiodRole(_pInfo);

            new HpFinancialService().DeleteExistingCabinChargeCalculation(_pInfo.AdmissionId);

            this.SegmantizeTheAccomodation(_pInfo);

            this.SegmantizeTheExtraAccomodation(_pInfo);

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
            for (var date = _pInfo.AddmissionDate.AddDays(1); date <= Utils.GetServerDateAndTime(); date = date.AddDays(1))
            {
                HpCabinChargeSegmantDetail _billForThisDate = new HospitalCabinBedService().GetCabinChargeSegmantDetailByDate(date);

                if (_billForThisDate.OccupationStatus.ToLower() == "release")
                {
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
                else
                {

                    _dateCount = _dateCount + 1;

                    if (_dateCount == _totalOccupiedDate)
                    {

                        if (_ccMaster.IsOccupationMorethanTwoCalendarDate)
                        {
                            DateTime _ThresholdTimeFor6HoursGrace = new DateTime(_billForThisDate.StayingDate.Year, _billForThisDate.StayingDate.Month, _billForThisDate.StayingDate.Day, 6, 0, 0);
                            if (Utils.GetServerDateAndTime().TimeOfDay <= _ThresholdTimeFor6HoursGrace.TimeOfDay) // Bill not applicable for release day
                            {

                            }
                            else
                            {
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
                        }
                        else
                        {
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
                    }
                    else
                    {
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
                }


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


            Thread.Sleep(100);
            List<VMHpFinalBill> cabinBillItems = new HpFinancialService().GetHpCabinBillItems(_pInfo.AdmissionId, IsAdmissionFeeApplicable);

            FillBillGrid(cabinBillItems);
      
        
     }

        private void FillBillGrid(List<VMHpFinalBill> cabinBillItems)
        {
            dgLedger.SuspendLayout();
            dgLedger.Rows.Clear();
            double _serviceCharge = 0;
            foreach (VMHpFinalBill item in cabinBillItems)
            {
                _serviceCharge = _serviceCharge + (item.Total * item.ServiceChargeInPercent) / 100;

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgLedger, item.SrlNo, item.ServiceName, item.Qty, item.Rate, item.Total);
                dgLedger.Rows.Add(row);
            }
        }

        private void SegmantizeTheAccomodation(HospitalPatientInfo _pInfo)
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
                _timeDistanceInhours = new CalculateCabinCharge().GetTimeDistanceInHours(_pInfo.AddmissionDate, _pInfo.Time, Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("hh:mm tt"));
                _days = _timeDistanceInhours / 24;
                _hours = _timeDistanceInhours % 24;

                if (_hours >= 2) IsAdmissionDayBillApplicable = true;

            }

            if (_rollingDateList.Count > 1)
            {
                // DateTime _ThresholdTimeFor6HoursGrace = new DateTime(_pInfo.AddmissionDate.Year, _pInfo.AddmissionDate.Month, _pInfo.AddmissionDate.Day, 18, 0, 0);
                DateTime _ThresholdTimeFor12HoursGrace = new DateTime(_pInfo.AddmissionDate.Year, _pInfo.AddmissionDate.Month, _pInfo.AddmissionDate.Day, 12, 0, 0);
                DateTime _ActualAdmissionDateAndTime = new CalculateCabinCharge().CombinedDateAndTimePart(_pInfo.AddmissionDate, _pInfo.Time);

                if (_ActualAdmissionDateAndTime.TimeOfDay < _ThresholdTimeFor12HoursGrace.TimeOfDay)
                {
                    IsAdmissionDayBillApplicable = true;
                }

            }

            HpCabinChargeSegmantMaster _cabinChargeMaster = new HpCabinChargeSegmantMaster();
            _cabinChargeMaster.AdmissionId = _pInfo.AdmissionId;
            _cabinChargeMaster.AdmissionDate = _pInfo.AddmissionDate;
            _cabinChargeMaster.AdmissionTime = _pInfo.Time;
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

        private void SegmantizeTheExtraAccomodation(HospitalPatientInfo _pInfo)
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


        private void FillAccomGrid(List<VMHpPatientAccomodationInfo> accomList)
        {
            dgAccomInfo.SuspendLayout();
            dgAccomInfo.Rows.Clear();
            int count = 1;
            foreach(var item in accomList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 25;
                row.CreateCells(dgAccomInfo, count,item.AccomodateDate,item.AccomodateTime,item.CabinNo,item.ReleaseDate.GetValueOrDefault(),item.ReleaseTime,item.AllotType,item.OperateBy,item.Status);
                dgAccomInfo.Rows.Add(row);
                count += 1;
            }
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgAccomInfo_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMHpPatientAccomodationInfo _accomInfo = dgAccomInfo.SelectedRows[0].Tag as VMHpPatientAccomodationInfo;
            if (_accomInfo != null)
            {
                btnUpdate.Tag = _accomInfo;
                txtAccomdate.Text = _accomInfo.AccomodateDate.ToString(); 
                txtAccomTime.Text = _accomInfo.AccomodateTime;
                txtReleasedate.Text = _accomInfo.ReleaseDate.GetValueOrDefault().ToString();
                txtReleaseTime.Text = _accomInfo.ReleaseTime;
                cmbAllotType.Text = _accomInfo.AllotType;
                cmbStatus.Text = _accomInfo.Status;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag != null)
            {
                VMHpPatientAccomodationInfo _accomInfo = btnUpdate.Tag as VMHpPatientAccomodationInfo;
                HpPatientAccomodationInfo _accInfo = new HospitalService().GetHpAccomInfo(_accomInfo.AccomId);
                if (_accInfo != null)
                {
                    _accInfo.AccomodateDate = Convert.ToDateTime(txtAccomdate.Text);
                    _accInfo.AccomodateTime = txtAccomTime.Text;
                    //if (_accomInfo.ReleaseDate == null) { }
                    //_accInfo.ReleaseDate = Convert.ToDateTime(txtReleasedate.Text);
                    //_accInfo.ReleaseTime = txtReleaseTime.Text;
                    _accInfo.AllotType = cmbAllotType.Text;
                    _accInfo.Status = cmbStatus.Text;

                    new HospitalService().UpdateCurrentAccomodation(_accInfo);

                    long _hbillNo = 0;
                    long.TryParse(txtHBillNo.Text, out _hbillNo);

                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_hbillNo);
                    txtHBillNo.Tag = _pInfo;
                    List<VMHpPatientAccomodationInfo> accomList = new HospitalService().GetHpAccomDetails(_pInfo.AdmissionId);

                    FillAccomGrid(accomList);

                    CalculateCurrentCabinCharges(_pInfo);
                }

            }
        }

        private void frmEditHpPatientAccomationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
