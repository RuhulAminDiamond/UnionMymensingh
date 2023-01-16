using HDMS.Model;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using HDMS.Service.Diagonstics;
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

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmReportDelivery : Form
    {
        public frmReportDelivery()
        {
            InitializeComponent();
        }

        private void frmReportDelivery_Load(object sender, EventArgs e)
        {
            dtpEntry.Value = DateTime.Now;

            LoadPatientsByDate(dtpEntry.Value);
        }

        private void LoadPatientsByDate(DateTime dtp1)
        {
            List<VMDiagPatient> _listOfPatient = new PatientService().GetDiagPatientByDate(dtp1,"");

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
                row.CreateCells(dgPatient, item.PatientId, item.Name);
                dgPatient.Rows.Add(row);
            }

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
            AddToStatusToGrid(_listOfPatient);
        }
        bool isFlug = false;
        private void AddToStatusToGrid(List<VMDiagPatientAndTestDetail> pList)
        {

            DataGridViewButtonColumn dgvbt = new DataGridViewButtonColumn();
            dgvbt.Name = "dbt";
            dgvbt.HeaderText = "Is Delivered";
            dgvbt.Text = "Delivered";   // works also when bound

           

            dgvbt.UseColumnTextForButtonValue = true; //

            //if (dgTests.Columns.Contains("dbt") && dgTests.Columns["dbt"].Visible)
            //{


            //}else
            //{
            //    dgTests.Columns.Add(dgvbt);
            //}

            if (!isFlug)
            {
                dgTests.Columns.Add(dgvbt);
                dgTests.CellClick += new DataGridViewCellEventHandler(dgTests_CellClick);
                isFlug = true;
            }


            
        }

        private void dgTests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTests.Rows.Count>0 && e.RowIndex >= 0 && e.ColumnIndex==4)
            {

                VMDiagPatientAndTestDetail _dpd = dgTests.Rows[e.RowIndex].Tag as VMDiagPatientAndTestDetail;
                if(_dpd.ReportStatus != "RP")
                {
                    if(_dpd.ReportStatus == "RD")
                    {
                        MessageBox.Show("Report All Ready Deliverd");
                   
                        return;
                    }
                    MessageBox.Show("Report can not delivery Because Your Report not to ready");
                    return;
                }
              


                if(_dpd != null)
                {

                    TestsCost _tc = new TestsCostService().GetTestCostByPatientAndTestId(_dpd.PatientId, _dpd.TestId);

                    _tc.ReportStatus = ReportStatusEnum.RD.ToString();
                    _tc.ReportDeliveredBy = MainForm.LoggedinUser.Name;

                    if (new TestsCostService().UpdateReportStatusByTest(_tc))
                    {
                        MessageBox.Show("Report delivered successful");
                        LoadPatientsByBillNo(txtBillNo.Text);
                    }

                }


                //MessageBox.Show(this, e.RowIndex.ToString() + " Clicked!");
                //...
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
                row.CreateCells(dgTests, item.BillNo, item.TestName, _status, item.ReportDeliveredBy );
                dgTests.Rows.Add(row);
            }
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtBillNo.Text, out _billNo);
                Patient _Patient = new PatientService().GetPatientByIdNo(_billNo);

                if (_Patient != null)
                {

                    List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(_Patient.PatientId);

                    if (!Helper.IsDiagDueInvoice(_pLedger))
                    {
                        LoadPatientsByBillNo(txtBillNo.Text);

                    }else
                    {
                        MessageBox.Show("It's a due Invoice. Plz. settle the due amount and try again.");
                    }
                }
            }
        }

        private void dtpEntry_ValueChanged(object sender, EventArgs e)
        {
            LoadPatientsByDate(dtpEntry.Value);
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMDiagPatient _pInfo = ((VMDiagPatient)row.Tag);
                txtName.Text = _pInfo.Name;
                txtBillNo.Text = _pInfo.PatientId.ToString();


                List<PatientLedger> _pLedger = new PatientService().GetPatientLedgerById(_pInfo.PatientId);
                if (!Helper.IsDiagDueInvoice(_pLedger))
                {
                    LoadPatientsByBillNo(_pInfo.PatientId.ToString());

                }
                else
                {
                    MessageBox.Show("It's a due Invoice. Plz. settle the due amount and try again.");
                }
               
            }
        }

        private void btnDeliveredAll_Click(object sender, EventArgs e)
        {

            List<TestsCost> _tCostList = new List<TestsCost>();
            foreach (DataGridViewRow row in dgTests.Rows)
            {
                VMDiagPatientAndTestDetail selectedTests = row.Tag as VMDiagPatientAndTestDetail;

                TestsCost _tc = new TestsCostService().GetTestCostByPatientAndTestId(selectedTests.PatientId, selectedTests.TestId);
                if (_tc.ReportStatus != "RP")
                {
                    MessageBox.Show("All Report are not Ready for Deailivery");

                    return;
                }
                _tc.ReportStatus = ReportStatusEnum.RD.ToString();
                _tc.ReportDeliveredBy = MainForm.LoggedinUser.Name;
                _tCostList.Add(_tc);
            }

            if (_tCostList.Count > 0)
            {
                new TestsCostService().UpdateReportStatus(_tCostList);

                MessageBox.Show("Report deliverd successful.");

                LoadPatientsByBillNo(txtBillNo.Text);
            }
        }
    }
}
