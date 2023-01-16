using HDMS.Model;
using HDMS.Model.Users;
using HDMS.Model.ViewModel;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Windows.Forms.UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmPatientSerialDisplaySystem : Form
    {

       
        
  //call it then you need to update:
       public frmPatientSerialDisplaySystem()
        {
            InitializeComponent();

            UpdateFont();
        }

        private void UpdateFont()
        {

           

            foreach (DataGridViewColumn c in dgPatient.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 35.5F, GraphicsUnit.Pixel);

            }

            dgPatient.Font = new Font("Segoe UI", 18,FontStyle.Bold, GraphicsUnit.Pixel);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void frmPatientSerialDisplaySystem_Load(object sender, EventArgs e)
        {
            frmPatientSerialDisplayController MyForm2 = new frmPatientSerialDisplayController();

            MyForm2.OnMyChange += UIChanged;

            LoadTodysPatient(Utils.GetServerDateAndTime());
        }

        private void UIChanged(object sender, MyEventArgs e)
        {
            List<VMPractitionerWisePatientSerial> p = e.EventInfo;
        }

        private async void LoadTodysPatient(DateTime _date)
        {

            //User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            //ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_user.ChamberPractitionerId);
            //int _CpId = 0;
            //if (Practitioner != null)
            //{
            //    _CpId = Practitioner.CPId;
            //}

            List<VMPractitionerWisePatientSerial> _pList = await new ChamberPractitionerService().GetTodaysPatient(_date);

            FillGrid(_pList);
        
        }

        private void FillGrid(List<VMPractitionerWisePatientSerial> pList)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach(var item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 65;
                row.Tag = item;
                row.CreateCells(dgPatient,item.PatientName,item.DailyId, item.PractionerName,item.SerilaTime, item.Status);
                dgPatient.Rows.Add(row);
            }
        }

        private void dgPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
