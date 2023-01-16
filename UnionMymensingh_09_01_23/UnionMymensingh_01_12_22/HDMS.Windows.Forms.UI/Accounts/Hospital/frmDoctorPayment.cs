using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Hospital
{
    public partial class frmDoctorPayment : Form
    {
        public frmDoctorPayment()
        {
            InitializeComponent();
        }



        private void frmDoctorPayment_Load(object sender, EventArgs e)
        {
            LoadDoctors();

            lblDate.Text = DateTime.Now.ToString(Configuration.DATE_TIME_FORMAT);
            lblUserName.Text = MainForm.LoggedinUser.Name;
            txtTransactionNo.Text = GetTransactionNo();
        }

        private string GetTransactionNo()
        {
            string _year = Utils.GetServerDateAndTime().Year.ToString().Substring(2,2);
            string _month = Utils.GetServerDateAndTime().Month.ToString();
            string _day = Utils.GetServerDateAndTime().Day.ToString();

            if (_month.Length == 1) _month = "0" + _month;
            if (_day.Length == 1) _day = "0" + _day;

            return _year + _month + _day + new Random().Next(100, 999).ToString() + new Random().Next(10, 99).ToString() + Configuration.ORG_CODE;
        }

        private void LoadDoctors()
        {
            List<Doctor> _dList = new DoctorService().GetAllDoctors().ToList();
            FillDoctorGrid(_dList);
        }

        private void FillDoctorGrid(List<Doctor> _dList)
        {
            dgDoc.SuspendLayout();
            dgDoc.Rows.Clear();

            foreach (Doctor _d in _dList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = _d;

                row.CreateCells(dgDoc, _d.DoctorId, _d.Name);
                dgDoc.Rows.Add(row);
            }
        }

        private void dgDoc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Doctor _d = dgDoc.SelectedRows[0].Tag as Doctor;

          
            double _balance = new HpFinancialService().GetConsultantLedgerBalance(_d.DoctorId);

            txtBalance.Text = _balance.ToString();
            txtBalance.Tag = _balance;
            lblConsultant.Text = _d.Name;
            lblUserName.Tag = _d;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblUserName.Tag != null)
            {
                double _payment = 0, bal=0;
                double.TryParse(txtPayment.Text, out _payment);
                double.TryParse(txtBalance.Text, out bal);

                string _particulars = string.Empty;
                _particulars = txtRemarks.Text;

                string _tranNo = GetTransactionNo();

                if (String.IsNullOrEmpty(_particulars))
                {
                    _particulars = "Payment Transaction No :" + _tranNo;

                }else
                {
                    _particulars = _particulars + ", "+ "Payment Transaction No :" + _tranNo;
                }

                if (_payment > 0)
                {
                     Doctor _d = (Doctor)lblUserName.Tag;
                     HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                    _hpcLedger.DoctorId = _d.DoctorId;
                    _hpcLedger.TranDate = Utils.GetServerDateAndTime();
                    _hpcLedger.TransactionTime= Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _hpcLedger.Particulars = _particulars;
                    _hpcLedger.Debit = _payment;
                    _hpcLedger.Credit =0;
                    _hpcLedger.Balance = bal; // Negative balance means patient is payable this amount
                    _hpcLedger.TransactionType = TransactionTypeEnum.ConsultantFee.ToString();
                    _hpcLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _hpcLedger.PaymentTransactionNo = Convert.ToInt64(_tranNo);
                    _hpcLedger.PaymentEntryTime = DateTime.Now.ToString("hh:mm tt");
                     txtTransactionNo.Text = _tranNo;
                     new HpFinancialService().SaveHpConsultantTransactionUnit(_hpcLedger);
                    MessageBox.Show("Payment successful");

                    ShowPaymentVoucher(txtTransactionNo.Text);

                    txtPayment.Text = "";
                    txtBalance.Text = "";
                    txtRemarks.Text = "";
                    lblUserName.Tag = null;
                    lblConsultant.Text = "";
                }
            }
            else
            {

            }
        }

        private void ShowPaymentVoucher(string _tranNo)
        {
            long tranNo = Convert.ToInt64(_tranNo);
            HpConsultantLedger _cLedger = new HpFinancialService().GetConsultantLedgerByTransactionNo(tranNo);

            rptConsultantPaymentSlip _rpt = new rptConsultantPaymentSlip();

            Doctor _d = new DoctorService().GetDoctorById(_cLedger.DoctorId);

          

           
            _rpt.SetParameterValue("TransactionNo", txtTransactionNo.Text);
            _rpt.SetParameterValue("eDate", lblDate.Text);
            
            _rpt.SetParameterValue("PaymentTo", _d.Name);
            _rpt.SetParameterValue("ProcessBy", MainForm.LoggedinUser.Name);

            _rpt.SetParameterValue("Amount", Spell.SpellAmount.comma(Convert.ToDecimal(_cLedger.Debit.ToString())));
            _rpt.SetParameterValue("InWords", Spell.SpellAmount.InWrods(Convert.ToDecimal(_cLedger.Debit.ToString())));


            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (txtBalance.Tag != null)
            {
                double _bal = Convert.ToDouble(txtBalance.Tag);
                double _payment = 0;
                double.TryParse(txtPayment.Text, out _payment);

                txtBalance.Text = (_bal - _payment).ToString();

                //if((_bal - _payment) < 0)
                //{
                //    MessageBox.Show("Payment exceeds the balance.");
                //    txtPayment.Text = "0";
                //}
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ShowPaymentVoucher(txtTransactionNo.Text);
        }

        private void txtSearchDoctor_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchDoctor.Text.Trim() == "Search doctor")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                LoadDoctorDatabyName(txtSearchDoctor.Text, "DName");
            }
        }

        private void LoadDoctorDatabyName(string _searcgString, string v)
        {
            List<Doctor> _dList = new DoctorService().GetDoctorBySearchString(_searcgString);

            if (_dList == null) return;

            if (_dList.Count == 0) return;

            FillDoctorGrid(_dList);
        }
    }
}
