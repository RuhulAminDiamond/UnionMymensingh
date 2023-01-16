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
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.Users;
using HDMS.Service;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlDischargeRequest : UserControl
    {
        public ctrlDischargeRequest()
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
           
        }

        private IList<VMSelectedService> _SelectedServices;
        private void ctrlServices_Load(object sender, EventArgs e)
        {

            _SelectedServices = new List<VMSelectedService>();
            ctlPatientList.Location = new Point(txtPatient.Location.X, txtPatient.Location.Y + txtPatient.Height);
          
            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;
         

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadPrevileges();

            lblConfirmedby.Text = MainForm.LoggedinUser.Name;

        }

        private void LoadPrevileges()
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if (_user.FloorId >= 0)
            {


                if (_user.RoleId == 34)
                {
                    LoadOTOrPostOperativePatient("OT", _user.FloorId);
                }
                else if (_user.RoleId == 37)
                {
                    LoadOTOrPostOperativePatient("PO", _user.FloorId);
                }
                else if (_user.RoleId == 40)
                {
                    LoadEmergencyPatient("OPD", _user.FloorId);
                }
                else if (_user.RoleId == 1)
                {
                    LoadAdmittedPatients();
                }
                else
                {
                    LoadAdmittedPatientListByFloor(_user.FloorId);
                }


                //txtPatient.Enabled = false;

                FloorInfo _floor = new HospitalCabinBedService().GetFloorById(_user.FloorId);

                if (_floor != null)
                {
                    lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name + ", " + _floor.Name.ToString();
                }
                else
                {
                    lblLoggedInInfo.Text = "Logged in as " + MainForm.LoggedinUser.Name;
                }

            }


        }

        private void LoadEmergencyPatient(string v, int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentEmergencyPatients();
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }
        }

        private void LoadAdmittedPatients()
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentIPDs();
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }
        }

        private void LoadOTOrPostOperativePatient(string _otOrPo, int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentOTOrPostOperativePatients(floorId, _otOrPo);
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }
        }

        private void LoadAdmittedPatientListByFloor(int floorId)
        {
            List<VMIPDInfo> _IPDPInfoList = new HospitalService().GetCurrentIPDInfoByFloor(floorId);
            lvPatients.Items.Clear();
            lvPatients.SmallImageList = imgListLarge;
            foreach (VMIPDInfo ipdItem in _IPDPInfoList)
            {

                string displayText = ipdItem.BedCabinNo;
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.Tag = ipdItem.AdmissionId;
                listitem.ToolTipText = listitem.Name;
                listitem.ImageIndex = 0;
                lvPatients.Items.Add(listitem);
            }

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
      

        private void ctlPatientList_ItemSelected(Controls.SearchResultListControl<Model.Hospital.ViewModel.VMIPDInfo> sender, Model.Hospital.ViewModel.VMIPDInfo item)
        {
            txtPatient.Text = item.AdmissionId.ToString();
            txtName.Text = item.Name;
            txtCabinNo.Text = item.BedCabinNo;
            txtAssignedDoctor.Text = item.AssignedDoctor;
            txtPatient.Tag = item;
          
            sender.Visible = false;
            ctlPatientList.Visible = false;
        }

        

      

       

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtPatient.Tag == null) return;

            VMIPDInfo _IpdPatient = txtPatient.Tag as VMIPDInfo;
            if (_IpdPatient != null)
            {
                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdPatient.AdmissionId);
                _pInfo.RecommededDateForDischarge = dtpDate.Value;
                _pInfo.RecommededTimeForDischarge = dtpTime.Value.ToString("hh:mm tt");
                _pInfo.DischargeRecommendationConfirmedby = MainForm.LoggedinUser.Name;

                new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                MessageBox.Show("Request delivered successfully.");

            }



        }

        private void dgService_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _SelectedServices.Remove(e.Row.Tag as VMSelectedService);
        }


        private void ctlPatientList_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped) txtPatient.Focus();
        }

        private void lvPatients_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvPatients.SelectedItems.Count == 1)
            {
              

                ListView.SelectedListViewItemCollection items = lvPatients.SelectedItems;

                ListViewItem lvItem = items[0];

                if (lvItem.Tag != null)
                {
                    long _admissionId = 0;
                    long.TryParse(lvItem.Tag.ToString(), out _admissionId);
                    LoadPatientInfo(_admissionId);
                
                    
                }else
                {
                    MessageBox.Show("Patient not found.");
                }

            }
        }

     


        private void LoadPatientInfo(long _admissionId)
        {
            VMIPDInfo _IPdInfo = new HospitalService().GetIPDInfoById(_admissionId);

            if (_IPdInfo != null)
            {
                txtPatient.Text = _IPdInfo.AdmissionId.ToString();
                txtName.Text = _IPdInfo.Name;
                txtCabinNo.Text = _IPdInfo.BedCabinNo;
                txtAssignedDoctor.Text = _IPdInfo.AssignedDoctor;
                txtPatient.Tag = _IPdInfo;

                HighLightButton(_IPdInfo.Status);
            }
        }

        private void HighLightButton(string _cabinState)
        {
            if (_cabinState.ToLower() == "cabin")
            {
                btnCabin.BackColor = Color.Green;
                btnCabin.ForeColor = Color.White;

                btnOT.ForeColor = Color.Black;
                btnPostOperative.ForeColor = Color.Black;
                btnOT.BackColor = Control.DefaultBackColor;
                btnPostOperative.BackColor = Control.DefaultBackColor;
            }

            if (_cabinState.ToLower() == "ot")
            {
                btnOT.BackColor = Color.Green;
                btnOT.ForeColor = Color.White;

                btnCabin.BackColor = Control.DefaultBackColor;
                btnCabin.ForeColor = Color.Black;
                btnPostOperative.ForeColor = Color.Black;
                btnPostOperative.BackColor = Control.DefaultBackColor;
            }

            if (_cabinState.ToLower() == "po")
            {
                btnPostOperative.BackColor = Color.Green;
                btnPostOperative.ForeColor = Color.White;

                btnOT.BackColor = Control.DefaultBackColor;
                btnOT.ForeColor = Color.Black;

                btnCabin.BackColor = Control.DefaultBackColor;
                btnCabin.ForeColor = Color.Black;
            }

        }

        private void btnOT_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to tranfer patient at OT?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                VMIPDInfo _IpdInfo =(VMIPDInfo)txtPatient.Tag;
                if (_IpdInfo != null)
                {
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdInfo.AdmissionId);
                    if (_pInfo != null)
                    {
                        _pInfo.Status = "OT";
                        _pInfo.StatusChangeBy = MainForm.LoggedinUser.Name;
                        new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                        HighLightButton(_pInfo.Status);

                        LoadPrevileges();
                    }
                }
            }
        }

        private void btnPostOperative_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to tranfer patient at Post Operative Zone?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                VMIPDInfo _IpdInfo = (VMIPDInfo)txtPatient.Tag;
                if (_IpdInfo != null)
                {
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdInfo.AdmissionId);
                    if (_pInfo != null)
                    {
                        _pInfo.Status = "PO";
                        _pInfo.StatusChangeBy = MainForm.LoggedinUser.Name;
                        new HospitalService().UpdateHospitalPatientInfo(_pInfo);
                        HighLightButton(_pInfo.Status);

                        LoadPrevileges();
                    }
                }
            }
        }

        private void btnCabin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to tranfer patient at Cabin?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                VMIPDInfo _IpdInfo = (VMIPDInfo)txtPatient.Tag;
                if (_IpdInfo != null)
                {
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdInfo.AdmissionId);
                    if (_pInfo != null)
                    {
                        _pInfo.Status = "Cabin";
                        _pInfo.StatusChangeBy = MainForm.LoggedinUser.Name;
                        new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                        HighLightButton(_pInfo.Status);

                        LoadPrevileges();
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnWithDrawDR_Click(object sender, EventArgs e)
        {
            if (txtPatient.Tag == null) return;
            
            VMIPDInfo _IpdPatient = txtPatient.Tag as VMIPDInfo;
            if (_IpdPatient != null)
            {
                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdPatient.AdmissionId);
                _pInfo.RecommededDateForDischarge = null;
                _pInfo.RecommededTimeForDischarge = null;
                _pInfo.DischargeRecommendationConfirmedby = null;

                new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                MessageBox.Show("Request withdrawn successfully.");

            }

        }
    }
}
