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
using HDMS.Repository.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using CrystalDecisions.Windows.Forms;
using System.Threading;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlPatientBill : UserControl
    {
        public ctrlPatientBill()
        {
            InitializeComponent();
        }

        private void ctrlPatientBill_Load(object sender, EventArgs e)
        {
            LoadPatientsData();
        }

        private async void LoadPatientsData()
        {
            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfo();

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
        }

        private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMIPDInfo item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.AdmissionId,item.AddmissionDate.ToString("dd/MM/yyyy"), item.AdmTime ,item.Name, item.BedCabinNo, item.AssignedDoctor, item.FatherName, item.MobileNo, item.Status);
                dgPatient.Rows.Add(row);
            }

        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            double _total = 0;
            if (dgPatient.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);
                txtHospitalBill.Tag = _pInfo;

                double _hpbill = new HpFinancialService().GetHospitalBill(_pInfo.AdmissionId);

                double _transferredCabinCharge = new HpFinancialService().GetAlreadySavedCabinCharge(_pInfo.AdmissionId); //
                double _cabinCharge = new HpFinancialService().GetCabinCharge(_pInfo.AdmissionId,Utils.GetServerDateAndTime(), Utils.GetServerDateAndTime().ToString("HH:mm:ss tt"));

                txtHospitalBill.Text = (_hpbill+ _cabinCharge+ _transferredCabinCharge + 600).ToString();

                double _pathbill = new HpFinancialService().GetPathologyBill(_pInfo.BillNo);
                txtPathologyBill.Text = _pathbill.ToString();

                double _medicinebill = new HpFinancialService().GetMedicineBill(_pInfo.AdmissionId);
                txtMedicineBill.Text = _medicinebill.ToString();

                double _doctorbill = new HpFinancialService().GetDoctorBill(_pInfo.AdmissionId);

                double _OtDoctorBill = new HpFinancialService().GetOTDoctorBill(_pInfo.AdmissionId);

                txtDoctorBill.Text = (_OtDoctorBill+_doctorbill).ToString();

                _total = _hpbill + _pathbill + _medicinebill + _doctorbill;

                double _sCharge = _total * 25 / 100;

                txtServiceCharge.Text = _sCharge.ToString();

                _total = _total + _sCharge;

                txtTotalBill.Text = _total.ToString();
                txtDueBill.Text = _total.ToString();
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (txtHospitalBill.Tag != null)
            {
                VMIPDInfo _pInfo = ((VMIPDInfo)txtHospitalBill.Tag);

                new HpFinancialService().AccumulateHpFinalBill(_pInfo.AdmissionId);
                Thread.Sleep(100);
                DataSet ds = new HpFinancialService().GetHpFinalBill(_pInfo.AdmissionId);

                //CalculateCabinCharge();

                rptHpBill _rpt = new rptHpBill();

                _rpt.SetDataSource(ds.Tables[0]);

             
                _rpt.SetParameterValue("pLabel1","Total Amount");
                _rpt.SetParameterValue("pDivider1", ":");

                _rpt.SetParameterValue("ServiceCharge", "0");

                _rpt.SetParameterValue("PaidAmount", "0");

                _rpt.SetParameterValue("Discount", "0");

                _rpt.SetParameterValue("NetPayable", "0");

                ReportViewer rv = new ReportViewer();
                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

              

            }
        }

        private void CalculateCabinCharge()
        {
            throw new NotImplementedException();
        }

        private void CalculateAdmissionFee()
        {
            throw new NotImplementedException();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Please Wailt...";

            LoadPatientsData();

            btnRefresh.Enabled = true;
            btnRefresh.Text = "Refresh";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoBySearchParameter(_prefix, type).ToList();

            if (_lisPatientInfo.Count() == 0) return;

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }else
            {
              
                   LoadPatientsDatabyName(txtName.Text, "PName");
            }
        }

        private void txtCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtCabin.Text.Trim() == "Search by cabin")
            {
               // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }else
            {
               
                    LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
        }

        private void txtAdmId_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "By Adm. Id")
            {
               // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }else
            {
              
                    LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
        }

        private void txtAssignDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtAssignDoc.Text.Trim() == "Search by Assign Doc")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtAssignDoc.Text, "assigndoc");
            }
        }

        private void dgPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
