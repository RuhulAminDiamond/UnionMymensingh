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
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Common.Utils;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlRelease : UserControl
    {
        public ctrlRelease()
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

        private void ctrlRelease_Load(object sender, EventArgs e)
        {

            ctlPatientList.Location = new Point(txtPatient.Location.X, txtPatient.Location.Y + txtPatient.Height);
            ctlPatientList.ItemSelected += ctlPatientList_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
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

        private void ctlPatientList_ItemSelected(Controls.SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
            txtPatient.Text = item.AdmissionId.ToString();
            txtName.Text = item.Name;
            txtCabinNo.Text = item.BedCabinNo;
            txtAssignedDoctor.Text = item.AssignedDoctor;
            txtPatient.Tag = item;
            txtPatient.Focus();
            sender.Visible = false;
            ctlPatientList.Visible = false;
        }

        private void btnDischargeNow_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to dischare this patient?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                if (txtPatient.Tag != null) {
                    VMIPDInfo _IpdPatient = (VMIPDInfo)txtPatient.Tag;
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_IpdPatient.AdmissionId);
                    HpPatientAccomodationInfo _pAccomInfo = new HospitalService().GetHpPatientCurrentAccomodation(_IpdPatient.AdmissionId);

                    if (_pInfo != null)
                    {

                     if(_pAccomInfo != null)
                     {
                            CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_pAccomInfo.CabinId);
                            _Cabin.IsBooked = false;
                            new HospitalCabinBedService().UpdateCabinInfo(_Cabin);

                            _pAccomInfo.Status = "Vacant";
                            _pAccomInfo.AllotType = "Released";

                            new HospitalService().UpdateCurrentAccomodation(_pAccomInfo);
                      }
                   
                       _pInfo.Status = HospitalPatientStatusEnum.Discharged.ToString();
                       
                        new HospitalService().UpdateHospitalPatientInfo(_pInfo);

                        MessageBox.Show("Patient Discharged");
                    }
                        
                        
                 }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
