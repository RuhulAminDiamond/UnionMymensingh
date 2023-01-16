using HDMS.Model;
using HDMS.Model.OPD;
using HDMS.Model.Users;
using HDMS.Model.ViewModel;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.OPD;
using HDMS.Windows.Forms.UI.Classes;
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

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmPatientSerialDisplayController : Form
    {
        public event EventHandler<MyEventArgs> OnMyChange = delegate { };

        public frmPatientSerialDisplayController()
        {
            InitializeComponent();
        }

        private void frmPatientSerialDisplayController_Load(object sender, EventArgs e)
        {

            lblTitle.Text = "Patients List, Date: " + Utils.GetServerDateAndTime().ToString("dd/MM/yyyy");

            Model.OPD.DisplaySetting dsp = new OPDPatientService().GetDisplaySetting();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (dsp.UpdateIntervelInSec * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            LoadTodysPatient(Utils.GetServerDateAndTime());

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoadTodysPatient(Utils.GetServerDateAndTime());
        }

        private async void LoadTodysPatient(DateTime _date)
        {

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_user.ChamberPractitionerId);
            int _CpId = 0;
            if (Practitioner != null)
            {
                _CpId = Practitioner.CPId;
            }

            List<VMPractitionerWisePatientSerial> _pList =await new ChamberPractitionerService().GetTodaysPatient( _date);

            FillGrid(_pList);

        }

        private void FillGrid(List<VMPractitionerWisePatientSerial> pList)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            bool isCalling = false;
            DataGridViewRow callingRow = new DataGridViewRow();
            foreach (var item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;

                if (item.Status.ToLower().Equals("calling"))
                {
                    isCalling = true;
                    callingRow = row;
                }


                row.CreateCells(dgPatient, item.DailyId, item.PatientName,item.PractionerName, item.Status);
                dgPatient.Rows.Add(row);
            }



            Thread thread = new Thread(() => { BlinkCallingRow(isCalling, callingRow); });
            thread.Start();
        }

        private void BlinkCallingRow(bool isCalling, DataGridViewRow callingRow)
        {
            while (isCalling)
            {
                callingRow.DefaultCellStyle.BackColor = Color.Red;
                Thread.Sleep(500);
                callingRow.DefaultCellStyle.BackColor = Color.Green;
                Thread.Sleep(500);
            }

            //return true;
        }

        private void dgPatient_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMPractitionerWisePatientSerial Obj = dgPatient.SelectedRows[0].Tag as VMPractitionerWisePatientSerial;
            if (Obj != null)
            {
                txtName.Text = Obj.PatientName;
                txtName.Tag = Obj;
                cmbStatus.Text = Obj.Status;
            }
            else
            {
                txtName.Text = "";
                txtName.Tag = null;
                cmbStatus.Text = "";
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                VMPractitionerWisePatientSerial pat = txtName.Tag as VMPractitionerWisePatientSerial;

                PractitionerWisePatientSerial ot = new CommonService().GetPractionerwisePatient(pat.Id);

                ot.Status = cmbStatus.Text;
                ot.PatientName = txtName.Text;
                new OPDPatientService().UpdatePatientSerialStatus(ot);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

