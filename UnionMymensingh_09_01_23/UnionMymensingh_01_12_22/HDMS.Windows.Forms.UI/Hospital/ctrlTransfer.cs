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
using HDMS.Model;
using HDMS.Service.Hospital;
using HDMS.Model.Hospital;
using HDMS.Common.Utils;
using HDMS.Model.Enums;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlTransfer : UserControl
    {
        public ctrlTransfer()
        {
            InitializeComponent();
        }

        private void txtCabinfrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {

            }
        }

        private void txtCabinTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlCabinSearchto.Visible = true;
                ctlCabinSearchto.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlPatientList.Visible = false;
            ctlCabinSearchto.Visible = false;
            ctlCabinSearchFrom.Visible = false;
        }

        private void ctrlTransfer_Load(object sender, EventArgs e)
        {
            ctlPatientList.Location = new Point(txtPatient.Location.X, txtPatient.Location.Y + txtPatient.Height);
            ctlCabinSearchFrom.Location = new Point(txtCabinfrm.Location.X, txtCabinfrm.Location.Y + txtCabinfrm.Height);
            ctlCabinSearchto.Location = new Point(txtCabinTo.Location.X, txtCabinTo.Location.Y + txtCabinTo.Height);


            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;
            ctlCabinSearchFrom.ItemSelected += ctlCabinSearchFrom_ItemSelected;
            ctlCabinSearchto.ItemSelected += ctlCabinSearchto_ItemSelected;


            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            dtpTransfer.Value =Utils.GetServerDateAndTime();
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

       

        private void ctlCabinSearchto_ItemSelected(SearchResultListControl<VMCabinInfo> sender, VMCabinInfo item)
        {
            txtCabinTo.Text = item.CabinNo.ToString();
            txtCabinTo.Tag = item;
            txtCabinTo.Focus();
            sender.Visible = false;
            sender.Visible = false;
        }

        private void ctlCabinSearchFrom_ItemSelected(SearchResultListControl<VMCabinInfo> sender, VMCabinInfo item)
        {
            throw new NotImplementedException();
        }

        private void ctlPatientList_ItemSelected(SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
            txtPatient.Text = item.BillNo.ToString();
            txtName.Text = item.Name;
            txtCabinNo.Text = item.BedCabinNo;
            txtCabinfrm.Text = item.BedCabinNo;
            txtAssignedDoctor.Text = item.AssignedDoctor;
            txtPatient.Tag = item;
            txtCabinTo.Focus();
            sender.Visible = false;
            ctlPatientList.Visible = false;

            CalculateCabinFee();
        }

        private void CalculateCabinFee()
        {
            VMIPDInfo _ipdInfo = (VMIPDInfo)txtPatient.Tag;

            HpPatientAccomodationInfo _hpAccomodation = new HospitalService().GetHpPatientCurrentAccomodation(_ipdInfo.AdmissionId);

            if (_hpAccomodation != null)
            {
              

                //Calculate cabin charge for Vacanted cabin

                CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_hpAccomodation.CabinId);

                double _cabinCharge = new CalculateCabinCharge().CabinCharge(_hpAccomodation.AccomodateDate, _hpAccomodation.AccomodateTime, dtpTransfer.Value, txtTransferTime.Text, _cabin.Rent);
                txtCabinCharge.Text = _cabinCharge.ToString();
              
                //

            }
        }

        private void ctlPatientList_Load(object sender, EventArgs e)
        {

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

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (txtPatient.Tag != null)
            {
                if(!radioBooked.Checked && !radioFree.Checked)
                {
                    MessageBox.Show("No option selected for cabin."); return;
                }

                if (txtCabinTo.Tag == null)
                {
                    MessageBox.Show("Cabin to not selected."); return;
                }

                VMCabinInfo _wc = (VMCabinInfo)txtCabinTo.Tag;

                if (_wc != null)
                {
                    VMIPDInfo _ipdInfo = (VMIPDInfo)txtPatient.Tag; 

                    HpPatientAccomodationInfo _hpAccomodation = new HospitalService().GetHpPatientCurrentAccomodation(_ipdInfo.AdmissionId);

                    if (_hpAccomodation != null)
                    {
                        if (radioFree.Checked)
                        {

                            //Release current cabin



                            _hpAccomodation.ReleaseDate = Utils.GetServerDateAndTime();
                            _hpAccomodation.ReleaseTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                            _hpAccomodation.Status = "Vacant";
                            _hpAccomodation.AllotType = HpBedAllotTypeEnum.ReleasedAsTB.ToString();
                            new HospitalService().UpdateCurrentAccomodation(_hpAccomodation);

                          //End of Release current cabin

                            //Calculate cabin charge for Vacanted cabin

                            CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_hpAccomodation.CabinId);

                            //int _daysInCabin = new CalculateCabinCharge().DaysInHospital(_hpAccomodation.AccomodateDate, _hpAccomodation.AccomodateTime, dtpTransfer.Value, txtTransferTime.Text, true);
                            //double _cabinCharge = _daysInCabin * _cabin.Rent;

                            //// Cabin Charge Entry
                            //if (_daysInCabin > 0)
                            //{
                            //    HpCabinCharge _HpcabinCharge = new HpCabinCharge();
                            //    _HpcabinCharge.AdmissionId = _hpAccomodation.AdmissionId;
                            //    _HpcabinCharge.TranDate = Utils.GetServerDateAndTime();
                            //    _HpcabinCharge.Particulars = "Cabin charge: " + _cabin.CabinNo;
                            //    _HpcabinCharge.TotalDays = _daysInCabin;
                            //    _HpcabinCharge.Rate = _cabin.Rent;
                            //    _HpcabinCharge.Amount = _daysInCabin * _cabin.Rent;

                            //    new HpFinancialService().SaveCabinCharge(_HpcabinCharge);
                            //}

                            //Update Released Cabin Status

                             _cabin.IsBooked = false;
                             new HospitalCabinBedService().UpdateCabinInfo(_cabin);


                            //End of Update Released Cabin Status

                            //End of Cabin Charge

                            //Allot new accomadation

                            //
                            // Before allot new cabin check either this or some cabin included this one already holded by him as extra cabin

                            VMCabinInfo _transfertoabin = (VMCabinInfo)txtCabinTo.Tag;

                             List<HpPatientAccomodationInfo> _checkAccomList = new HospitalCabinBedService().GetExtraCabinListByPatient(_hpAccomodation.AdmissionId);

                          if(_checkAccomList.Any(x=>x.CabinId== _transfertoabin.CabinId))
                          {
                                HpPatientAccomodationInfo _accomInf = _checkAccomList.Where(x => x.AdmissionId == _hpAccomodation.AdmissionId && x.CabinId == _transfertoabin.CabinId).FirstOrDefault();
                                _accomInf.Status = "Occupied";
                                _accomInf.AllotType = "PatientBed";

                                 new HospitalService().UpdateCurrentAccomodation(_accomInf);

                            }
                            else
                            {

                                HpPatientAccomodationInfo _currentAccomodation = new HpPatientAccomodationInfo();
                                _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                                _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                _currentAccomodation.AdmissionId = _hpAccomodation.AdmissionId;
                                _currentAccomodation.CabinId = ((VMCabinInfo)txtCabinTo.Tag).CabinId;
                                _currentAccomodation.OperatorRemarks = txtRemarks.Text;
                                _currentAccomodation.SoftwareRemarks = "Transfer from " + txtCabinfrm.Text + " to " + txtCabinTo.Text;
                                _currentAccomodation.Status = "Occupied";
                                _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;
                                _currentAccomodation.AllotType = HpBedAllotTypeEnum.PatientBed.ToString();

                                new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);


                            }


                            //Update Occupied Cabin Status

                            _cabin = new HospitalCabinBedService().GetCabinInfoId(((VMCabinInfo)txtCabinTo.Tag).CabinId);
                            _cabin.IsBooked = true;
                            new HospitalCabinBedService().UpdateCabinInfo(_cabin);


                            //End of Update Occupied Cabin Status

                            MessageBox.Show("Transfer successfull.");
                            txtPatient.Tag = null;

                        }else if(radioBooked.Checked)
                        {



                            _hpAccomodation.ReleaseDate = Utils.GetServerDateAndTime();
                            _hpAccomodation.ReleaseTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                            _hpAccomodation.Status = "Vacant";
                            _hpAccomodation.AllotType = HpBedAllotTypeEnum.ReleasedAsTB.ToString();
                            new HospitalService().UpdateCurrentAccomodation(_hpAccomodation);

                           

                             HpPatientAccomodationInfo _currentAccomodation = new HpPatientAccomodationInfo();
                            _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                            _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                            _currentAccomodation.AdmissionId = _hpAccomodation.AdmissionId;
                            _currentAccomodation.CabinId = _hpAccomodation.CabinId;
                            _currentAccomodation.OperatorRemarks = txtRemarks.Text;
                            _currentAccomodation.SoftwareRemarks = "Alloted as Extra Cabin";
                            _currentAccomodation.Status = "Occupied";
                            _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;
                            _currentAccomodation.AllotType = HpBedAllotTypeEnum.ExtraBed.ToString();

                            new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);


                             _currentAccomodation = new HpPatientAccomodationInfo();
                            _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                            _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                            _currentAccomodation.AdmissionId = _hpAccomodation.AdmissionId;
                            _currentAccomodation.CabinId = ((VMCabinInfo)txtCabinTo.Tag).CabinId;
                            _currentAccomodation.OperatorRemarks = txtRemarks.Text;
                            _currentAccomodation.SoftwareRemarks = "Transfer from " + txtCabinfrm.Text + " to " + txtCabinTo.Text;
                            _currentAccomodation.Status = "Occupied";
                            _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;
                            _currentAccomodation.AllotType = HpBedAllotTypeEnum.PatientBed.ToString();

                            new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);

                            //Update Occupied Cabin Status

                            CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(((VMCabinInfo)txtCabinTo.Tag).CabinId);
                            _cabin.IsBooked = true;
                            new HospitalCabinBedService().UpdateCabinInfo(_cabin);


                            //End of Update Occupied Cabin Status

                            MessageBox.Show("Transfer successfull.");
                            txtPatient.Tag = null;

                        }else
                        {
                            MessageBox.Show("No option selected.");
                            return;
                        }
                    }

                }
                else
                {

                }


            }
            else
            {
                MessageBox.Show("Patient not selected.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTransferTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void btnTransferToExtraCabin_Click(object sender, EventArgs e)
        {

            if (txtPatient.Tag != null)
            {
                VMIPDInfo _ipdInfo = (VMIPDInfo)txtPatient.Tag;

                HpPatientAccomodationInfo _hpAccomodation = new HospitalService().GetHpPatientCurrentAccomodation(_ipdInfo.AdmissionId);

                List<HpPatientAccomodationInfo> _checkAccomList = new HospitalCabinBedService().GetExtraCabinListByPatient(_ipdInfo.AdmissionId);

                if (_checkAccomList.Count > 1)
                {
                    MessageBox.Show("There are more than one extra cabin. Please accomplish this other way.");
                    return;
                }

                if (radioFree.Checked)
                {
                    if (_checkAccomList.Count > 0)
                    {
                        HpPatientAccomodationInfo _accomInf = _checkAccomList.Where(x => x.AdmissionId == _ipdInfo.AdmissionId).FirstOrDefault();
                        _accomInf.Status = "Vacant";
                        _accomInf.ReleaseDate = Utils.GetServerDateAndTime();
                        _accomInf.ReleaseTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        if(_accomInf.AllotType == HpBedAllotTypeEnum.ExtraBed.ToString())
                        {
                            _accomInf.AllotType = HpBedAllotTypeEnum.ReleasedAsEB.ToString();
                        }
                        else
                        {
                            _accomInf.AllotType = HpBedAllotTypeEnum.ReleasedAsTB.ToString();
                        }
                     

                        new HospitalService().UpdateCurrentAccomodation(_accomInf);

                        //Allot Extra Bed as PatientBed
                      
                        HpPatientAccomodationInfo _currentAccomodation = new HpPatientAccomodationInfo();
                        _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                        _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        _currentAccomodation.AdmissionId = _hpAccomodation.AdmissionId;
                        _currentAccomodation.CabinId = _accomInf.CabinId;
                        _currentAccomodation.OperatorRemarks = txtRemarks.Text;
                        _currentAccomodation.SoftwareRemarks = "Transfer from " + txtCabinfrm.Text + " to " + txtCabinTo.Text;
                        _currentAccomodation.Status = "Occupied";
                        _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;
                        _currentAccomodation.AllotType = HpBedAllotTypeEnum.PatientBed.ToString();

                        new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);

                        //End of Allot Extra Bed as PatientBed

                        _hpAccomodation.Status = "Vacant";
                        _hpAccomodation.ReleaseDate = Utils.GetServerDateAndTime();
                        _hpAccomodation.ReleaseTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        _hpAccomodation.AllotType = HpBedAllotTypeEnum.ReleasedAsTB.ToString();
                        new HospitalService().UpdateCurrentAccomodation(_hpAccomodation);

                        MessageBox.Show("Transfer successful.");


                        CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_hpAccomodation.CabinId);

                      
                        //Update Released Cabin Status

                        _cabin.IsBooked = false;
                        new HospitalCabinBedService().UpdateCabinInfo(_cabin);

                        txtPatient.Tag = null;
                    }
                }else if (radioBooked.Checked)
                {

                    _checkAccomList = new HospitalCabinBedService().GetExtraCabinListByPatient(_ipdInfo.AdmissionId);


                    if (_checkAccomList.Count == 0)
                    {
                        MessageBox.Show("No alloted extra cabin found");return;
                    }

                    _hpAccomodation.ReleaseDate = Utils.GetServerDateAndTime();
                    _hpAccomodation.ReleaseTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _hpAccomodation.Status = "Vacant";
                    _hpAccomodation.AllotType= HpBedAllotTypeEnum.ReleasedAsTB.ToString();
                    new HospitalService().UpdateCurrentAccomodation(_hpAccomodation);

                    HpPatientAccomodationInfo _currentAccomodation = new HpPatientAccomodationInfo();
                    _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                    _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _currentAccomodation.AdmissionId = _hpAccomodation.AdmissionId;
                    _currentAccomodation.CabinId = _hpAccomodation.CabinId;
                    _currentAccomodation.OperatorRemarks = txtRemarks.Text;
                    _currentAccomodation.SoftwareRemarks = txtCabinfrm.Text + " alloted as extra cabin";
                    _currentAccomodation.Status = "Occupied";
                    _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;
                    _currentAccomodation.AllotType = HpBedAllotTypeEnum.ExtraBed.ToString();

                    new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);



                    HpPatientAccomodationInfo _accomInf = _checkAccomList.Where(x => x.AdmissionId == _ipdInfo.AdmissionId).FirstOrDefault();
                    _accomInf.ReleaseDate = Utils.GetServerDateAndTime();
                    _accomInf.ReleaseTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _accomInf.Status = "Vacant";
                    _accomInf.AllotType = HpBedAllotTypeEnum.ReleasedAsEB.ToString();

                    new HospitalService().UpdateCurrentAccomodation(_accomInf);

                    // Turn extra bed to patient bed

                     _currentAccomodation = new HpPatientAccomodationInfo();
                    _currentAccomodation.AccomodateDate = Utils.GetServerDateAndTime();
                    _currentAccomodation.AccomodateTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _currentAccomodation.AdmissionId = _accomInf.AdmissionId;
                    _currentAccomodation.CabinId = _accomInf.CabinId;
                    _currentAccomodation.OperatorRemarks = txtRemarks.Text;
                    _currentAccomodation.SoftwareRemarks = "Extra bed turns to patient bed.";
                    _currentAccomodation.Status = "Occupied";
                    _currentAccomodation.OperateBy = MainForm.LoggedinUser.Name;
                    _currentAccomodation.AllotType = HpBedAllotTypeEnum.PatientBed.ToString();

                    new HospitalService().SaveHpPatientAccomadationInfo(_currentAccomodation);

                    //Update Occupied Cabin Status

                    CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_hpAccomodation.CabinId);
                    _cabin.IsBooked = true;
                    new HospitalCabinBedService().UpdateCabinInfo(_cabin);

                     _cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInf.CabinId);
                    _cabin.IsBooked = true;
                    new HospitalCabinBedService().UpdateCabinInfo(_cabin);


                    //End of Update Occupied Cabin Status

                    MessageBox.Show("Transfer successfull.");
                    txtPatient.Tag = null;

                }
            }else
            {
                MessageBox.Show("Patient not found.");
            }
        }

        private void ctlCabinSearchFrom_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCabinfrm.Focus();
            }
        }

        private void ctlPatientList_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtPatient.Focus();
            }
        }

        private void ctlCabinSearchto_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCabinTo.Focus();
            }
        }
    }
}
