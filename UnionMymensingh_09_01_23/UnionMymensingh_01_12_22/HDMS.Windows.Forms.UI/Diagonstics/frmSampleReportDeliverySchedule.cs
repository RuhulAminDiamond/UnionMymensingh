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
    public partial class frmSampleReportDeliverySchedule : Form
    {
        public frmSampleReportDeliverySchedule()
        {
            InitializeComponent();
        }

        private void frmSampleReportDeliverySchedule_Load(object sender, EventArgs e)
        {
           
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            long billNo = 0;
            //  long.TryParse(_billNo, out billNo);


            btnShow.Text = "Plz. Wait.";
            btnShow.Enabled = false;

            int _ReportTypeId = GetReportTypeId();

            string _IpdOpdOrAll = GetIPD_OPD_ALL();


            if (_ReportTypeId == 0)
            {
                MessageBox.Show("No report category selected. Plz. select one and try again.");
                btnShow.Text = "Show";
                btnShow.Enabled = true;
                return;
            } 


            List<VMDiagPatientAndTestDetail> _listOfUndeliveredPatient = new PatientService().GetDiagUndeliveredTestDetailByDateAndTime(dtpEntry.Value,dtptime.Value, _ReportTypeId, _IpdOpdOrAll);

           
            FillSampleGrid(_listOfUndeliveredPatient);



            List<VMDiagPatientAndTestDetail> _listOfPatient2 = new PatientService().GetDiagDeliveredTestDetailByDateAndTime(dtpEntry.Value, dtptime.Value, _ReportTypeId, _IpdOpdOrAll);

            FillDeliveredReportGrid(_listOfPatient2);

            if(_listOfUndeliveredPatient.Count==0 && _listOfPatient2.Count == 0)
            {
                MessageBox.Show("No record found.");
            }

            btnShow.Text = "Show";
            btnShow.Enabled = true;
        }

        private string GetIPD_OPD_ALL()
        {
            if (radIPD.Checked)
            {
                return "IPD";

            }else if(radOPD.Checked)
            {
                return "OPD";
            }else
            {
                return "All";
            }
        }

        private int GetReportTypeId()
        {
            int _reportType = 0;

            if (radBiochem.Checked)
            {
                int.TryParse(radBiochem.Tag.ToString(), out _reportType);

            }else if (radImmu.Checked)
            {
                int.TryParse(radImmu.Tag.ToString(), out _reportType);
            }
            else if (radHaema.Checked)
            {
                int.TryParse(radHaema.Tag.ToString(), out _reportType);
            }
            else if (radCP.Checked)
            {
                int.TryParse(radCP.Tag.ToString(), out _reportType);
            }
            else if (radSero.Checked)
            {
                int.TryParse(radSero.Tag.ToString(), out _reportType);
            }
            else if (radMicro.Checked)
            {
                int.TryParse(radMicro.Tag.ToString(), out _reportType);
            }
            else if (radUrine.Checked)
            {
                int.TryParse(radUrine.Tag.ToString(), out _reportType);
            }
            else if (radStool.Checked)
            {
                int.TryParse(radStool.Tag.ToString(), out _reportType);
            }

            return _reportType;
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
                row.CreateCells(dgDeliveredReport, item.BillNo, item.ReportId, item.TestName, item.EntryDate.ToString("dd/MM/yyyy"), item.EntryTime, item.DeliveryDate.ToString("dd/MM/yyyy"), item.DeliveryTime, _status);
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
                row.CreateCells(dgTests, item.BillNo, item.ReportId, item.TestName, item.EntryDate.ToString("dd/MM/yyyy"), item.EntryTime, item.DeliveryDate.ToString("dd/MM/yyyy"), item.DeliveryTime, _status);
                dgTests.Rows.Add(row);
            }
        }
    }
}
