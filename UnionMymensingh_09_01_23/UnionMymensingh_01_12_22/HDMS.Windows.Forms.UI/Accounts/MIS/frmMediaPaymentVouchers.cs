﻿using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using HDMS.Model.MiniAccount;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.MiniAccounts;
using HDMS.Windows.Forms.UI.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
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
    public partial class frmMediaPaymentVouchers: Form
    {
        List<BusinessMedia> medias = new List<BusinessMedia>();
        bool flag = true;
        public frmMediaPaymentVouchers()
        {
            InitializeComponent();
        }

        private void frmMediaPayment_Load(object sender, EventArgs e)
        {
            // medias = new DiagFinancialService().GetAllMedias();
            // FillDgMedia(medias);
        }


        private void GetMediaNameByPatientEntry(DateTime dtpFrom, DateTime dtpTo)
        {
            medias = new MediaService().GetMediaNameByPatientEntry(dtpFrom, dtpTo);
            FillDgMedia(medias);

        }


        private void FillDgMedia(List<BusinessMedia> medias)
        {
            dgMedia.SuspendLayout();
            dgMedia.Rows.Clear();
            if (medias == null)
            {
                MessageBox.Show("No Media found");
                return;
            }
            foreach (BusinessMedia item in medias)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgMedia, item.Name);
                dgMedia.Rows.Add(row);
            }
        }




        private void dgMedia_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BusinessMedia media = dgMedia.SelectedRows[0].Tag as BusinessMedia;
            if (media != null)
            {
                lblMedia.Text = media.Name;
                btnShow_Click(null, null);
            }

            //if (new DiagFinancialService().GetMediaDueByPatient(dtFrom.Value, dtTo.Value, media.MediaId))
            //{
            //    MessageBox.Show(media.Name + " = Your Patient Due ");

            //}
        }

        private void btnShow_Click(object sender, EventArgs e)
        {


            if (dgMedia.SelectedRows.Count == 0 || dgMedia.SelectedRows[0].Tag == null)
            {
                MessageBox.Show("No media selected");
                return;
            }



            BusinessMedia media = dgMedia.SelectedRows[0].Tag as BusinessMedia;

            List<VMTestWiseMediaPayment> testWiseMediaPayments = new MediaService().GetTestWiseMediaPayments(dtFrom.Value, dtTo.Value, media.MediaId);
            FillDgTest(testWiseMediaPayments);

            List<VMPatientWiseMediaPayment> patientWiseMediaPayments = new MediaService().GetPatientWiseMediaPayments(dtFrom.Value, dtTo.Value, media.MediaId);
            FillDgPatient(patientWiseMediaPayments);


            double totalCommission = 0, totalDiscount = 0;


            foreach (DataGridViewRow row in dgTest.Rows)
            {
                if (row.Cells["Commission"].Value == null) continue;

                double.TryParse(row.Cells["Commission"].Value.ToString(), out double commission);
                totalCommission += commission;
            }
            lblCommission.Text = totalCommission.ToString();



            foreach (DataGridViewRow row in dgPatient.Rows)
            {
                if (row.Cells["TotalDiscount"].Value == null) continue;

                double.TryParse(row.Cells["TotalDiscount"].Value.ToString(), out double discount);
                totalDiscount += discount;
            }
            lblDiscount.Text = totalDiscount.ToString();


            lblPayable.Text = (totalCommission - totalDiscount).ToString();


            double.TryParse(lblPayable.Text, out _payable);

        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            // Print Recive First
                ShowMediaPaymentReceipt();

        }

        private void PatientCheck_CheckedChanged(Object sender, EventArgs e)
        {
            MessageBox.Show("hello Im checked");
        }



        private void FillDgPatient(List<VMPatientWiseMediaPayment> patientWiseMediaPayments)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();

            //DataGridViewCheckBoxColumn dgvcc = new DataGridViewCheckBoxColumn();
            //dgvcc.Name = "Check";
            //dgvcc.HeaderText = "Check Paitent";
            //dgvcc.Width = 120;
            //dgvcc.FalseValue = false;

            ////dgvcc.DisplayIndex = 0;
            //dgvcc.ValueType = typeof(bool);



            //if (flag)
            //{
            //    dgPatient.Columns.Add(dgvcc);

            //    flag = false;
            //}

            // DataTable datTab = new DataTable();






            foreach (VMPatientWiseMediaPayment item in patientWiseMediaPayments)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgPatient, item.PatientId, item.PatientName, item.RegularDiscount, item.DueDiscount, item.TotalDiscount, item.Check);
                dgPatient.Rows.Add(row);
            }
        }

        private void FillDgTest(List<VMTestWiseMediaPayment> testWiseMediaPayments)
        {
            dgTest.SuspendLayout();
            dgTest.Rows.Clear();
            foreach (VMTestWiseMediaPayment item in testWiseMediaPayments)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgTest, item.PatientId, item.PatientName, item.TestName,  item.Rate, item.MediaCommission);
                dgTest.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillDgMedia(medias.Where(x => x.Name.Trim().ToLower().Contains(txtSearchMedia.Text.Trim().ToLower())).ToList());
        }

        private void txtSearchMedia_TextChanged(object sender, EventArgs e)
        {
            FillDgMedia(medias.Where(x => x.Name.Trim().ToLower().Contains(txtSearchMedia.Text.Trim().ToLower())).ToList());
        }


  
        private void ShowMediaPaymentReceipt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PatientId", typeof(long));
            dt.Columns.Add("PatientName", typeof(string));
            dt.Columns.Add("TestName", typeof(string));
            dt.Columns.Add("Commission", typeof(double));
            dt.Columns.Add("Rate", typeof(double));

            foreach (DataGridViewRow dgvr in dgTest.Rows)
            {
                if (dgvr.Cells["PatientId"].Value == null) continue;

                long.TryParse(dgvr.Cells["PatientId"].Value.ToString(), out long patientId);
                string patientName = dgvr.Cells["PatientName"].Value.ToString();
                string testName = dgvr.Cells["TestName"].Value.ToString();
                double.TryParse(dgvr.Cells["Commission"].Value.ToString(), out double commission);
                double.TryParse(dgvr.Cells["Rate"].Value.ToString(), out double Rate);


                dt.Rows.Add(patientId, patientName, testName, commission, Rate);
            }

            double.TryParse(txtDiscountMinus.Text, out double discountMinus);
            double.TryParse(txtDiscountPluse.Text, out double discountPluse);


            rptMediaPaymentReceipt rpt = new rptMediaPaymentReceipt();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue("media", lblMedia.Text);
            rpt.SetParameterValue("dtFrom", dtFrom.Value);
            rpt.SetParameterValue("dtTo", dtTo.Value);

            double.TryParse(lblCommission.Text, out double totalCommission);
            rpt.SetParameterValue("totalCommission", totalCommission);
            double.TryParse(lblDiscount.Text, out double totalDiscount);
            rpt.SetParameterValue("totalDiscount", (totalDiscount - discountPluse) + discountMinus);
            double.TryParse(lblPayable.Text, out double totalPayable);
            rpt.SetParameterValue("payable", (totalPayable + discountPluse) - discountPluse);
           // rpt.SetParameterValue("TestRate",)
            rpt.SetParameterValue("userName", MainForm.LoggedinUser.Name);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        // Media Show 
        private void btnMediaShow_Click(object sender, EventArgs e)
        {
            // Media load Base on  Patients Entry and  isMedia False or 0  by Date 
            GetMediaNameByPatientEntry(dtFrom.Value, dtTo.Value);
        }

        private void btnMediaPaid_Click(object sender, EventArgs e)
        {

            MediaPaidListShow();

        }


        // show Paid List
        private void MediaPaidListShow()
        {
            string dateFrom = dtFrom.Value.ToString("yyyy-MM-dd");
            string dateTo = dtTo.Value.ToString("yyyy-MM-dd");
            //DateTime.TryParse(dateFrom, out DateTime.dtCFrom);
            // DateTime.TryParse(dateTo, out DateTime dttFrom);
            if (dgMedia.SelectedRows.Count == 0 || dgMedia.SelectedRows[0].Tag == null)
            {
                MessageBox.Show("No media selected");
                return;
            }
            BusinessMedia media = dgMedia.SelectedRows[0].Tag as BusinessMedia;
            DataSet dsMediaPayments = new ReportService().GetMediaPaidListData(Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo), media.MediaId);
            // DataSet dsMediaPayments = new ReportService().GetMediaPaidListData(dateFrom, dateFrom);

            rptMediaPaymentPaidList _rptPaidList = new rptMediaPaymentPaidList();
            _rptPaidList.SetDataSource(dsMediaPayments.Tables[0]);
            _rptPaidList.SetParameterValue("DateFrom", dtFrom.Value);
            _rptPaidList.SetParameterValue("DateTo", dtTo.Value);
            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptPaidList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }



        // GetCalculateTestwisePatientPayment

        public void GetCalculateTestwisePatientPayment()
        {
            VMTestWiseMediaPayment test = dgTest.Tag as VMTestWiseMediaPayment;

            double distCountPluse = 0;
            double.TryParse(txtDiscountPluse.Text, out distCountPluse);

            double discountMinus = 0;
            double.TryParse(txtDiscountMinus.Text, out discountMinus);

            double _lblDiscounts = 0;
            double.TryParse(lblDiscount.Text, out _lblDiscounts);

            double commission = 0;
            double totalCommission = 0;

            if (discountMinus > 0 && distCountPluse > 0)
            {
                MessageBox.Show("Pleace only one discount Add");
                txtDiscountMinus.Text = "";
                txtDiscountPluse.Text = "";

                return;
            }

            foreach (DataGridViewRow items in dgTest.Rows)
            {
                if (items.Cells["Commission"].Value == null) continue;
                double gridCommission = 0;
                double.TryParse(items.Cells["Commission"].Value.ToString(), out gridCommission);

                commission = commission + gridCommission;
            }

            totalCommission = commission;

            double _totalDiscount = 0;

            foreach (DataGridViewRow row in dgPatient.Rows)
            {
                if (row.Cells["Check"].Value == null) continue;
                //string isStringValue = dg.Cells["Check"].Value.ToString();
                //char strToNumber = Convert.ToChar(isStringValue);
                //bool.TryParse(strToNumber, out isBoollen);
                string isString = row.Cells["Check"].Value.ToString();

                if (isString == "1")
                {
                    double _tDiscount = 0;
                    double.TryParse(row.Cells["TotalDiscount"].Value.ToString(), out _tDiscount);
                    _totalDiscount += _tDiscount;
                }

            }



            if (distCountPluse > 0)
            {
                //commission = (commission + distCountPluse) - _lblDiscounts;
                commission = (commission + distCountPluse);


                // return;
            }


            if (discountMinus > 0)
            {
                commission = commission - discountMinus;

            }

            //double lblCommision = 0;
            //double.TryParse(lblCommission.Text, out lblCommision);


            lblCommission.Text = totalCommission.ToString();
            lblDiscount.Text = _totalDiscount.ToString();
            lblPayable.Text = (commission - _totalDiscount).ToString();
            //MessageBox.Show(commission + " ");
        }






        private void btnCalculate_Click(object sender, EventArgs e)
        {
            VMTestWiseMediaPayment test = dgTest.Tag as VMTestWiseMediaPayment;

            List<VMTestWiseMediaPayment> testWiseTotalCom = new List<VMTestWiseMediaPayment>();


           

            foreach (DataGridViewRow dg in dgPatient.Rows)
            {

                // bool isBoollen = false;
                if (dg.Cells["Check"].Value == null) continue;
                //string isStringValue = dg.Cells["Check"].Value.ToString();
                //char strToNumber = Convert.ToChar(isStringValue);
                //bool.TryParse(strToNumber, out isBoollen);
                string isString = dg.Cells["Check"].Value.ToString();


                // Get Test Wise Patient Media

                if (isString == "1")
                {
                    long patientId = 0;
                    long.TryParse(dg.Cells["PatientId2"].Value.ToString(), out patientId);
                    List<VMTestWiseMediaPayment> testWiseCom = new DiagFinancialService().GetCustomTestWiseMediaPayment(dtFrom.Value, dtTo.Value, patientId);

                    testWiseTotalCom.AddRange(testWiseCom);

                }
                // MessageBox.Show(dg.Cells["Check"].Value + " ");

                //if(isString == "1")
                //{
                //    long patientId = 0;
                //    long.TryParse(dg.Cells["PatientId2"].Value.ToString(), out patientId);
                //    List<VMPatientWiseMediaPayment> patientWisePayment = new DiagFinancialService().GetCustometPatientWiseMediaPayments(dtFrom.Value, dtTo.Value, patientId);
                //}



            }



            if (testWiseTotalCom.Count > 0)
            {

                FillDgTest(testWiseTotalCom);
                GetCalculateTestwisePatientPayment();
            }
        }

        double _payable = 0;




        private void txtDiscountPluse_TextChanged(object sender, EventArgs e)
        {
            double _discountPluse = 0;
            double.TryParse(txtDiscountPluse.Text, out _discountPluse);

            double _discountMinus = 0;
            double.TryParse(txtDiscountMinus.Text, out _discountMinus);

            if (_discountMinus > 0 && _discountPluse > 0)
            {
                MessageBox.Show("you can add only one");

                txtDiscountMinus.Text = "";
                txtDiscountPluse.Text = "";
                return;
            }


            double mmPay = 0;

            if (true)
            {

                mmPay = _payable + _discountPluse;

                lblPayable.Text = mmPay.ToString();
            }




        }

        private void txtDiscountMinus_TextChanged(object sender, EventArgs e)
        {
            double _discountPluse = 0;
            double.TryParse(txtDiscountPluse.Text, out _discountPluse);

            double _discountMinus = 0;
            double.TryParse(txtDiscountMinus.Text, out _discountMinus);

            if (_discountMinus > 0 && _discountPluse > 0)
            {
                MessageBox.Show("you can add only one");

                txtDiscountMinus.Text = "";
                txtDiscountPluse.Text = "";
                return;
            }


            double mmPay = 0;

            if (true)
            {

                mmPay = _payable - _discountMinus;

                lblPayable.Text = mmPay.ToString();
            }
        }

        private void btnInvestigation_Click(object sender, EventArgs e)
        {
            frmInvestigationEntry investigation = new frmInvestigationEntry();
            
            investigation.Show();
        }
    }
}
