using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using HDMS.Model.Media;
using HDMS.Model.ViewModel;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Media;
using HDMS.Windows.Forms.UI.Reports.Media;
using HDMS.Windows.Forms.UI.Reports.MIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.MIS
{
    public partial class frmIPDMediaPayment : Form
    {
        private readonly object lblDiscount;
        private readonly object txtDiscount;
        private object lblTotalTestCost;

        public frmIPDMediaPayment()
        {
            InitializeComponent();
        } 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrevBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long.TryParse(txtBillNo.Text, out long _billNo);

                VMIPDPaymentInfo _patient = IPDMediaService.GetPatientByBillNo(_billNo);

                if (_patient == null || _patient.PatientName == null) {
                    MessageBox.Show($"Patient not found with the id {_billNo}");
                    return;
                }

                DisplayPatientInfo(_patient);
            }
        }

        private void DisplayPatientInfo(VMIPDPaymentInfo patient)
        {
            txtCellPhone.Text = patient.PhoneNo;
            txtMedia.Text = patient.MediaName;
            cmbGender.Text = patient.Gender;
            txtPatientName.Text = patient.PatientName;
            lblPaymentStatus.Text = patient.IsPaid ? "Paid" : "Not Paid";
            btnPay.Enabled = !patient.IsPaid;
            txtMediaCommission.Text = patient.MediaCommission.ToString();
            txtMediaCommission.Enabled = !patient.IsPaid;
            txtBillNo.Tag = patient;
        }

        private void frmMediaPaymentbyPatientId_Load(object sender, EventArgs e)
        {
            txtBillNo.Focus();
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            long.TryParse(txtBillNo.Text, out long billNo);
            VMIPDPaymentInfo info = txtBillNo.Tag as VMIPDPaymentInfo;
            double.TryParse(txtMediaCommission.Text, out double payable);
            if (payable <= 0)
            {
                return;
            }

            if (info.MediaId==0)
            {
                MessageBox.Show("No Media Found.");
                return;
            }
            else
            {
                if (info.IsPaid)
                {
                    MessageBox.Show("Already Paid");
                    return;
                }
                else
                {
                    bool paid = IPDMediaService.PayIPDMedia(billNo, payable);
                    if (paid)
                    {
                        MessageBox.Show("Media Payment Successfull");
                        info.IsPaid = true;
                        info.MediaCommission = payable;
                        DisplayPatientInfo(info);

                        rptMediaPaymentHos mediah = new rptMediaPaymentHos();
                        mediah.SetParameterValue("Name", info.PatientName);
                        mediah.SetParameterValue("MediaName", info.MediaName);
                        mediah.SetParameterValue("MediaCommission", info.MediaCommission);
                        mediah.SetParameterValue("PhoneNo", info.PhoneNo);
                        mediah.SetParameterValue("MediaId", info.MediaId);
                        mediah.SetParameterValue("Gender", info.Gender);
                        mediah.SetParameterValue("BillNo", txtBillNo.Text);

                        ReportViewer rv = new ReportViewer();
                        rv.crviewer.ReportSource = mediah;
                        rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                        rv.crviewer.PrintReport();
                        rv.Show();

                        return;
                    }
                }

            }
        }

        private void showAndPrintReceipt(Patient patient)
        {
            int patientId = Int32.Parse(txtBillNo.Text);
            DataSet ds = Service.Media.MediaService.getMediaPaymentReceiptByPatientId(patient);

            rptMediaPaymentReceipt rpt = new rptMediaPaymentReceipt();
            rpt.SetDataSource(ds.Tables[0]);

            //rpt.SetParameterValue("payable", btnPay.Text);
            //rpt.SetParameterValue("MediaName", txtMedia.Text);
            //rpt.SetParameterValue("Discount", txtDiscount.Text);
            //rpt.SetParameterValue("PatientName", txtPatientName.Text);
            //rpt.SetParameterValue("TotalCosts", lblTotalTestCost.Text);
            //rpt.SetParameterValue("TotalCommission", txtMediaCommission.Text);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

}