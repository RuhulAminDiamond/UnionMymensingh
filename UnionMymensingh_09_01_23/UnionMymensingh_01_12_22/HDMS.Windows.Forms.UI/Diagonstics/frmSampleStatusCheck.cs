using HDMS.Model;
using HDMS.Model.Diagnostic.VM;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmSampleStatusCheck : Form
    {
        public frmSampleStatusCheck()
        {
            InitializeComponent();
        }

        private void frmSampleStatusCheck_Load(object sender, EventArgs e)
        {
            dtpEntry.Value = DateTime.Now;

            LoadPatientsByDate(dtpEntry.Value,"All");

            radAll.Checked = true;

        }

        private void LoadPatientsByDate(DateTime dtp1, string _type)
        {
            List<VMDiagPatient> _listOfPatient = new PatientService().GetDiagPatientByDate(dtp1, _type);

            FillPatientGrid(_listOfPatient);
        }

        private void FillPatientGrid(List<VMDiagPatient> _listOfPatient)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMDiagPatient item in _listOfPatient)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.BillNo, item.ReportId, item.Name);
                dgPatient.Rows.Add(row);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long billNo = 0;
                long.TryParse(txtBillNo.Text, out billNo);
                Patient _P = new PatientService().GetPatientByBillNo(billNo);
                Patient _patient = new PatientService().GetPatientById(billNo);

               /// string _billNo = _P.BillNo.ToString();

                if (_P != null && _P.Status != "Cancelled")
                {
                    LoadPatientsByBillNo(txtBillNo.Text);
                }else if (_patient != null && _patient.Status != "Cancelled" && _patient.PatientId > 0)
                {
                    LoadPatientByPatientId();
                }
                else
                {
                    MessageBox.Show("Bill Cancelled Or Invalid Bill No. OR Patient Id ");

                }
                
                //if (_P != null && _P.Status != "Cancelled")
                //{
                ////string _billNo =     _P.BillNo.ToString();
                //    if(_billNo.Length == 10)
                //    {
                //        LoadPatientsByBillNo(txtBillNo.Text);
                //    }
                //    else
                //    {
                //        LoadPatientByPatientId();
                //    }
                 
                   
                //}else
                //{
                //    MessageBox.Show("Bill Cancelled Or Invalid Bill No.");
                //}
            }
        }


         /* ================================ Load By Paitent Id ========================== */

        private void LoadPatientByPatientId()
        {
            long _patientId = 0;
            long.TryParse(txtBillNo.Text, out _patientId);

            List<VMDiagPatientAndTestDetail> _listOfPatient = new PatientService().GetDiagPatientAndTestDetailByPatientId(_patientId);

            if (_listOfPatient.Count > 0)
            {
                VMDiagPatientAndTestDetail _patient = _listOfPatient.FirstOrDefault();
                txtName.Text = _patient.Name;
                txtAge.Text = "";

            }


            FillSampleGrid(_listOfPatient);



            List<VMDiagPatientAndTestDetail> _listOfPatient2 = new PatientService().GetDiagPrintedOrDeliveredReportsByPatientId(_patientId);

            FillDeliveredReportGrid(_listOfPatient2);

        }

        private void LoadPatientsByBillNo(string _billNo)
        {
            long billNo = 0;
            long.TryParse(_billNo, out billNo);

            List<VMDiagPatientAndTestDetail> _listOfPatient = new PatientService().GetDiagPatientAndTestDetailByBillNo(billNo);

            if (_listOfPatient.Count > 0)
            {
                VMDiagPatientAndTestDetail _patient = _listOfPatient.FirstOrDefault();
                txtName.Text = _patient.Name;
                txtAge.Text = "";

            }
            

            FillSampleGrid(_listOfPatient);



            List<VMDiagPatientAndTestDetail> _listOfPatient2 = new PatientService().GetDiagPrintedOrDeliveredReportsByBillNo(billNo);

            FillDeliveredReportGrid(_listOfPatient2);

        }
       



        private void FillDeliveredReportGrid(List<VMDiagPatientAndTestDetail> _listOfPatient2)
        {
            string _status = string.Empty;

            dgDeliveredReport.SuspendLayout();
            dgDeliveredReport.Rows.Clear();
            foreach (VMDiagPatientAndTestDetail item in _listOfPatient2)
            {

                _status = Utils.GetReportStatus(item.ReportStatus);

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgDeliveredReport, item.BillNo, item.TestName, item.EntryDate.ToString("dd/MM/yyyy"), item.EntryTime, item.DeliveryDate.ToString("dd/MM/yyyy"), item.DeliveryTime, _status);
                dgDeliveredReport.Rows.Add(row);
            }
        }

        private void FillSampleGrid(List<VMDiagPatientAndTestDetail> _listOfPatient)
        {

            string _status = string.Empty;

            dgTests.SuspendLayout();
            dgTests.Rows.Clear();
            foreach (VMDiagPatientAndTestDetail item in _listOfPatient)
            {

                _status = Utils.GetReportStatus(item.ReportStatus);

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgTests, item.BillNo, item.TestName, item.EntryDate.ToString("dd/MM/yyyy"), item.EntryTime,item.DeliveryDate.ToString("dd/MM/yyyy"),item.DeliveryTime, _status);
                dgTests.Rows.Add(row);
            }
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMDiagPatient _pInfo = ((VMDiagPatient)row.Tag);
                txtName.Text = _pInfo.Name;
                txtBillNo.Text = _pInfo.BillNo.ToString();
                LoadPatientsByBillNo(_pInfo.BillNo.ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Enabled = false;
            btnShow.Text = "Wait..";

            LoadPatientsByDate(dtpEntry.Value,"All");

            btnShow.Enabled = true;
            btnShow.Text = "Show";
        }

        private void radIPD_Click(object sender, EventArgs e)
        {
            if (radIPD.Checked)
            {
                LoadPatientsByDate(dtpEntry.Value, "IPD");
            }
        }

        private void radOPD_Click(object sender, EventArgs e)
        {
            if (radOPD.Checked)
            {
                LoadPatientsByDate(dtpEntry.Value, "OPD");
            }
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                LoadPatientsByDate(dtpEntry.Value, "All");
            }
        }
    }
}
