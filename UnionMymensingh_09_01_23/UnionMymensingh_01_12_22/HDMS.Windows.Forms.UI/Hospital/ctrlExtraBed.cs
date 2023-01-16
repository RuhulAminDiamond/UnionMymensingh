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
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Model.Enums;
using HDMS.Common.Utils;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlExtraBed : UserControl
    {
        public ctrlExtraBed()
        {
            InitializeComponent();
        }

        private void txtPatient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlPatientList.Visible = true;
                ctlPatientList.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlPatientList.Visible = false;
            ctlCabinSearchFrom.Visible = false;
            ctrlCabinSearchAllot.Visible = false;
        }

        private void ctrlExtraBed_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            ctlPatientList.Location = new Point(txtPatient.Location.X, txtPatient.Location.Y + txtPatient.Height);
            ctlCabinSearchFrom.Location = new Point(txtCabinfrm.Location.X, txtCabinfrm.Location.Y + txtCabinfrm.Height);
            ctrlCabinSearchAllot.Location = new Point(txtAllotCabin.Location.X, txtAllotCabin.Location.Y + txtAllotCabin.Height);


            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;
            ctlCabinSearchFrom.ItemSelected += ctlCabinSearchFrom_ItemSelected;
            ctrlCabinSearchAllot.ItemSelected += CtrlCabinSearchAllot_ItemSelected;


            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            dtpAllotmentDate.Value = Utils.GetServerDateAndTime();
        }

        private void CtrlCabinSearchAllot_ItemSelected(SearchResultListControl<VMCabinInfo> sender, VMCabinInfo item)
        {
            txtAllotCabin.Text = item.CabinNo.ToString();
            txtCabinRent.Text = item.Rent.ToString();
            txtAllotCabin.Tag = item;
            txtAllotCabin.Focus();
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
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }


        private void ctlCabinSearchFrom_ItemSelected(SearchResultListControl<VMCabinInfo> sender, VMCabinInfo item)
        {
            txtCabinfrm.Text = item.CabinNo.ToString();
            txtCabinRent.Text = item.Rent.ToString();
            txtCabinfrm.Tag = item;
            txtCabinfrm.Focus();
            sender.Visible = false;
          
        }

       

        private void ctlPatientList_ItemSelected(SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
            txtPatient.Text = item.BillNo.ToString();
            txtName.Text = item.Name;
            txtCabinNo.Text = item.BedCabinNo;
            txtAssignedDoctor.Text = item.AssignedDoctor;
            txtPatient.Tag = item;
            txtCabinfrm.Focus();
            sender.Visible = false;
            ctlPatientList.Visible = false;

            CalculateCabinFee();
        }

        private void CalculateCabinFee()
        {
            double _totalcabinCharge = 0;

            VMIPDInfo _ipdInfo = (VMIPDInfo)txtPatient.Tag;

            List<HpPatientAccomodationInfo> _hpAccomodation = new HospitalService().GetHpPatientExtraAccomodation(_ipdInfo.AdmissionId);

            foreach(HpPatientAccomodationInfo _accomInfo in _hpAccomodation)
            {

                CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);

                double _cabinCharge = new CalculateCabinCharge().CabinCharge(_accomInfo.AccomodateDate, _accomInfo.AccomodateTime, dtpAllotmentDate.Value, txtAllotmentTime.Text, _cabin.Rent);
                _totalcabinCharge = _totalcabinCharge + _cabinCharge;

           
            }

            txtAllotedExtraCabinCharge.Text = _totalcabinCharge.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtAllotmentTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void txtCabinfrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                VMIPDInfo _ipdInfo = (VMIPDInfo)txtPatient.Tag;
                if (_ipdInfo == null)
                {
                    MessageBox.Show("Plz. select patient and try again.");return;
                }

                ctlCabinSearchFrom.Visible = true;
                ctlCabinSearchFrom.LoadDataByType(_ipdInfo.AdmissionId.ToString());
            }
        }

        private void btnAllot_Click(object sender, EventArgs e)
        {
            if (txtPatient.Tag != null)
            {

                DialogResult result = MessageBox.Show("Are you sure to allot this cabin as extra cabin?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {

                    if (txtAllotCabin.Tag == null)
                    {
                        MessageBox.Show("Plz. select cabin to allot as Extra. Then try again.");
                        return;
                    }


                    VMIPDInfo _IpdInfo = (VMIPDInfo)txtPatient.Tag;
                    VMCabinInfo _cabin = (VMCabinInfo)txtAllotCabin.Tag;

                    HpPatientAccomodationInfo _currentAccomodation = new HpPatientAccomodationInfo();
                    _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                    _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _currentAccomodation.AdmissionId = _IpdInfo.AdmissionId;
                    _currentAccomodation.CabinId = _cabin.CabinId;
                    _currentAccomodation.OperatorRemarks = txtRemarks.Text;
                    _currentAccomodation.SoftwareRemarks = txtCabinfrm.Text + " alloted as extra cabin";
                    _currentAccomodation.Status = "Occupied";
                    _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;
                    _currentAccomodation.AllotType = HpBedAllotTypeEnum.ExtraBed.ToString();

                    new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);
                    MessageBox.Show("Extra cabin alloted successfully.");
                    txtPatient.Tag = null;
                    txtAllotCabin.Text = "";
                    txtAllotCabin.Tag = null;
                    txtCabinfrm.Text = "";
                    txtCabinfrm.Tag = null;

                    CabinInfo _cInfo = new HospitalCabinBedService().GetCabinInfoId(_cabin.CabinId);
                    _cInfo.IsBooked = true;
                    new HospitalCabinBedService().UpdateCabinInfo(_cInfo);
                }
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (txtPatient.Tag != null)
            {
                VMIPDInfo _IPDInfo = (VMIPDInfo)txtPatient.Tag;


                VMCabinInfo _cabinInfo = (VMCabinInfo)txtCabinfrm.Tag;

                if (_cabinInfo == null)
                {
                    MessageBox.Show("Plz. Select Extra Cabin and Try Again."); return;
                }

                double _cabinchrage = 0;
                double.TryParse(txtAllotedExtraCabinCharge.Text, out _cabinchrage);

                DialogResult result = MessageBox.Show("Are you sure to release the extra cabin?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {

                    //List<HpPatientAccomodationInfo> _hpAccomodation = new HospitalService().GetHpPatientExtraAccomodation(_IPDInfo.AdmissionId);

                    HpPatientAccomodationInfo _accomInfo = new HospitalService().GetHpPatientExtraAccomodationByAdmAndCabinId(_IPDInfo.AdmissionId, _cabinInfo.CabinId);

                  
                        CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);

                        //int _daysInCabin = new CalculateCabinCharge().DaysInHospital(_accomInfo.AccomodateDate, _accomInfo.AccomodateTime, dtpAllotmentDate.Value, txtAllotmentTime.Text, true);
                        //double _cabinCharge = _daysInCabin * _cabin.Rent;

                        // Cabin Charge Entry
                        //if (_daysInCabin > 0)
                        //{
                        //    HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                        //    _HpcabinCharge.AdmissionId = _accomInfo.AdmissionId;
                        //    _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                        //    _HpcabinCharge.Particulars = "Cabin charge: " + _cabin.CabinNo;
                        //    _HpcabinCharge.TotalDays = _daysInCabin;
                        //    _HpcabinCharge.Rate = _cabin.Rent;
                        //    _HpcabinCharge.Amount = _daysInCabin * _cabin.Rent;

                        //    new HpFinancialService().SaveCabinCharge(_HpcabinCharge);
                        //}

                        _cabin.IsBooked = false;
                        new HospitalCabinBedService().UpdateCabinInfo(_cabin);


                        _accomInfo.ReleaseDate = Utils.GetServerDateAndTime();
                        _accomInfo.ReleaseTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        _accomInfo.Status = "Vacant";
                        _accomInfo.AllotType = HpBedAllotTypeEnum.ReleasedAsEB.ToString();
                        new HospitalService().UpdateCurrentAccomodation(_accomInfo);

                  

                    if (new HospitalCabinBedService().ReleaseExtaCabin(_IPDInfo.AdmissionId, _cabin.CabinId))
                    {
                        MessageBox.Show("Extra Cabin Released Successfully");
                        
                        txtPatient.Tag = null;
                        txtAllotCabin.Text = "";
                        txtAllotCabin.Tag = null;
                        txtCabinfrm.Text = "";
                        txtCabinfrm.Tag = null;
                    }
                }
            }
        }

        private void ctlPatientList_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtPatient.Focus();
            }
        }

        private void ctlCabinSearchFrom_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCabinfrm.Focus();
            }
        }

        private void txtAllotCabin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                VMIPDInfo _ipdInfo = (VMIPDInfo)txtPatient.Tag;
                ctrlCabinSearchAllot.Visible = true;
                ctrlCabinSearchAllot.LoadData();
            }
        }

        private void ctrlCabinSearchAllot_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtAllotCabin.Focus();
            }
        }

        private void ctlCabinSearchFrom_SearchEsacaped_1(bool IsEscaped)
        {

        }
    }
}
