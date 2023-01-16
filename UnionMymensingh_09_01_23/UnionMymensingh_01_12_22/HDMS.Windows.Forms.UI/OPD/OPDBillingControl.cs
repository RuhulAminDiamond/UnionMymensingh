using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Service.OPD;
using HDMS.Model.OPD.VM;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.Enums;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using HDMS.Model.Hospital;
using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Classes;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class OPDBillingControl : UserControl
    {
        public OPDBillingControl()
        {
            InitializeComponent();
        }

        private void OPDBillingControl_Load(object sender, EventArgs e)
        {
            List<VMOPDPatientRecord> _pList = new OPDPatientService().GetOPDPatientsUnderService();

            FillListGrid(_pList);
        }

        private void FillListGrid(List<VMOPDPatientRecord> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMOPDPatientRecord item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.BillNo, item.Name, item.EntryDate.ToString("dd/MM/yyyy"));
                dgPatient.Rows.Add(row);
            }

        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMOPDPatientRecord _pInfo = ((VMOPDPatientRecord)row.Tag);
                btnBillSave.Tag = _pInfo;

                lblName.Text = _pInfo.Name;

                List<VMOPDFinalBill> finalBillItems = new OPDFinancialService().GetOPDFinalBillItems(_pInfo.PatientId);

                FillBillGrid(finalBillItems);

            }
        }

        private void FillBillGrid(List<VMOPDFinalBill> finalBillItems)
        {

            dgLedger.SuspendLayout();
            dgLedger.Rows.Clear();
            double _serviceCharge = 0;
            foreach (VMOPDFinalBill item in finalBillItems)
            {
                _serviceCharge = _serviceCharge + (item.Total * item.ServiceChargeInPercent) / 100;

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgLedger, item.SrlNo, item.ServiceName, item.Qty, item.Rate, item.Total);
                dgLedger.Rows.Add(row);
            }

            CalculateBill(finalBillItems, _serviceCharge);
        }

        private void CalculateBill(List<VMOPDFinalBill> _finalBillItems, double serviceCharge)
        {
            txtDiscount.Text = "";
            txtPaid.Text = "";
            txtRemarks.Text = "";
            VMOPDPatientRecord tagPatient = (VMOPDPatientRecord)this.btnBillSave.Tag;

            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            //double _MedicineBill = _finalBillItems.Where(q=>q.ServiceName.ToLower()=="medicine bill").Sum(x => x.Total);
            //txtTotalBill.Tag = _MedicineBill;

            txtServiceCharge.Tag = serviceCharge;
            txtTotalBill.Text = _tDebit.ToString();

            double _total = 0;
            double.TryParse(_tDebit, out _total);

            double _serviceCharge = serviceCharge;

            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100;

            //}
            //else
            //{
            //    _serviceCharge = (_total * 25) / 100;
            //}





            double _gtotal = _total + _serviceCharge;

            txtServiceCharge.Text = _serviceCharge.ToString();
            txtGtotal.Text = _gtotal.ToString();


            VMOPDPatientRecord _pInfo = (VMOPDPatientRecord)btnBillSave.Tag;

            double _advancePaid = 0; // new HpFinancialService().GetRoughAdvancePaymentByPatient(_pInfo.AdmissionId);

            txtAdvancePaid.Text = _advancePaid.ToString();
            _gtotal = _gtotal - _advancePaid;

            txtDue.Text = _gtotal.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = Utils.GetServerDateAndTime().ToString("hh:mm tt");
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
         .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            double _total = 0;
            double.TryParse(_tDebit, out _total);



            double _advancePaid = 0;
            double.TryParse(txtAdvancePaid.Text, out _advancePaid);

            //double _MedicineBill = 0;
            //if (txtTotalBill.Tag != null)
            //{
            //     double.TryParse(txtTotalBill.Tag.ToString(), out _MedicineBill);
            //}

            double _serviceCharge = 0;

            double.TryParse(txtServiceCharge.Tag.ToString(), out _serviceCharge);

            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100;
            //}
            //else
            //{
            //    _serviceCharge = (_total * 25) / 100;
            //}


            double _disc = 0;

            double.TryParse(txtDiscount.Text, out _disc);

            if (_disc > _serviceCharge / 2)
            {
                DialogResult result = MessageBox.Show("Discount exceeds the limit 50% of service charge. Continue yet..", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    if (_disc > _serviceCharge)
                    {
                        txtDiscount.Text = _serviceCharge.ToString();
                        _disc = _serviceCharge;
                    }

                    txtPaid.Focus();

                }
                else
                {
                    txtDiscount.Text = "";
                    return;
                }
            }



            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100 - _disc;
            //}
            //else
            //{
            //    _serviceCharge= (_total  * 25) / 100 - _disc;
            //}


            _serviceCharge = _serviceCharge - _disc;

            txtServiceCharge.Text = _serviceCharge.ToString();

            txtGtotal.Text = (_total + _serviceCharge).ToString();

            txtDue.Text = ((_total - _advancePaid) + _serviceCharge).ToString();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
             .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();

            double _total = 0;
            double.TryParse(_tDebit, out _total);

            double _advancePaid = 0;
            double.TryParse(txtAdvancePaid.Text, out _advancePaid);


            double _disc = 0;

            double.TryParse(txtDiscount.Text, out _disc);

            //double _MedicineBill = 0;
            //if (txtTotalBill.Tag != null)
            //{
            //    double.TryParse(txtTotalBill.Tag.ToString(), out _MedicineBill);
            //}

            double _serviceCharge = 0;

            double.TryParse(txtServiceCharge.Text, out _serviceCharge);

            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100 - _disc;
            //}
            //else
            //{
            //    _serviceCharge = (_total * 25) / 100 - _disc;
            //}


            double _PaidTk = 0;
            double.TryParse(txtPaid.Text, out _PaidTk);


            txtDue.Text = ((_total + _serviceCharge) - (_PaidTk + _advancePaid)).ToString();

            double dueTk = 0;
            double.TryParse(txtDue.Text, out dueTk);

            //if (dueTk < 0)
            //{
            //    MessageBox.Show("Paid amount exceeds the bill amount. Plz. check it and try again");
            //    txtPaid.Text = "";
            //}
        }

        private void btnBillSave_Click(object sender, EventArgs e)
        {
            GenerateBill();
        }

        private void GenerateBill()
        {
           
            if (btnBillSave.Tag != null && !String.IsNullOrEmpty(lblName.Text))
            {


                VMOPDPatientRecord _pInfo = ((VMOPDPatientRecord)btnBillSave.Tag);

                if (_pInfo != null)
                {
                  

                    HpOPDBill _hbill = new HpOPDBill();
                    _hbill.PatientId = _pInfo.PatientId;
                    _hbill.BillDate = Utils.GetServerDateAndTime();
                    _hbill.BillTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _hbill.BillNo = _pInfo.BillNo;
                    _hbill.Remarks = txtRemarks.Text;
                    _hbill.BillType = "";
                    _hbill.PreparedBy = MainForm.LoggedinUser.Name;

                    long _hbillId = new OPDFinancialService().SaveOPDFinalBill(_hbill);
                    if (_hbillId > 0)
                    {

                        List<HpOPDBillDetail> _hbilldetailList = new List<HpOPDBillDetail>();
                        foreach (DataGridViewRow row in dgLedger.Rows)
                        {
                            VMOPDFinalBill selectedItems = row.Tag as VMOPDFinalBill;

                            HpOPDBillDetail _hbdetail = new HpOPDBillDetail();
                            _hbdetail.OPDBillId = _hbillId;
                            _hbdetail.ServiceName = selectedItems.ServiceName;
                            _hbdetail.Qty = selectedItems.Qty;
                            _hbdetail.Rate = selectedItems.Rate;
                            _hbdetail.Total = selectedItems.Total;
                            _hbilldetailList.Add(_hbdetail);
                        }

                        if (_hbilldetailList.Count > 0)
                        {
                            if (new OPDFinancialService().SaveOPDFinalBillDetail(_hbilldetailList))
                            {

                                MessageBox.Show("Final Bill Generated Successfully");

                                OPDPatientRecord _PInfo = new OPDPatientService().GetOPDPatientById(_pInfo.PatientId);
                                _PInfo.Status = OPDPatientStatusEnum.Released.ToString();
                                // _PInfo.Dischargedby = MainForm.LoggedinUser.Name;
                               
                                new OPDPatientService().UpdateOPDPatientInfo(_PInfo);

                                double balance = 0;
                                double _serviceCharge = 0;
                                double _total = 0;
                                double.TryParse(txtTotalBill.Text, out _total);

                                double _MedicineBill = 0;
                                if (txtTotalBill.Tag != null)
                                {
                                    double.TryParse(txtTotalBill.Tag.ToString(), out _MedicineBill);
                                }

                                double.TryParse(txtServiceCharge.Tag.ToString(), out _serviceCharge);
                                //if (Configuration.ORG_CODE == "2")
                                //{
                                //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100;
                                //}
                                //else
                                //{
                                //    _serviceCharge = (_total * 25) / 100;
                                //}

                                balance = 0 - Convert.ToDouble(txtTotalBill.Text);
                                //Save On Entry Payment Information
                                List<OPDPatientLedger> transactionList = new List<OPDPatientLedger>();

                                double discount = 0;
                                double.TryParse(txtDiscount.Text, out discount);

                                OPDPatientLedger pLedger = new OPDPatientLedger();
                                pLedger.OPDBillId = _hbillId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.Particulars = "Total Bill";
                                pLedger.Debit = Convert.ToDouble(txtTotalBill.Text);
                                pLedger.Credit = 0;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.HpTotalBiLL.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                transactionList.Add(pLedger);


                                balance = balance - _serviceCharge;
                                pLedger = new OPDPatientLedger();
                                pLedger.OPDBillId = _hbillId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.Particulars = "Service Charge";
                                pLedger.Debit = _serviceCharge;
                                pLedger.Credit = 0;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.HpServiceCharge.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                transactionList.Add(pLedger);


                                if (discount > 0)
                                {

                                    balance = balance + discount;
                                    pLedger = new OPDPatientLedger();
                                    pLedger.OPDBillId = _hbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.Particulars = "Discount";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = discount;
                                    pLedger.Balance = balance;
                                    pLedger.TransactionType = TransactionTypeEnum.HpDiscount.ToString();
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    transactionList.Add(pLedger);
                                }


                              
                                double paidTk = 0;
                                double.TryParse(txtPaid.Text, out paidTk);

                                if (paidTk > 0)
                                {


                                    balance = balance + paidTk;
                                    pLedger = new OPDPatientLedger();
                                    pLedger.OPDBillId = _hbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.Particulars = "Payment";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = paidTk;
                                    pLedger.Balance = balance;
                                    pLedger.TransactionType = TransactionTypeEnum.HpPaidAmount.ToString();
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    transactionList.Add(pLedger);

                                }

                                if (transactionList.Count > 0)
                                {
                                    OPDFinancialService fpService = new OPDFinancialService();
                                    fpService.SaveOPDFinalLedger(transactionList);
                                }

                            }
                        }

                        ViewPrintView(_hbillId);





                        dgLedger.SuspendLayout();
                        dgLedger.Rows.Clear();
                        // btnBillSave.Tag = null;
                        lblName.Text = "";
                       

                        txtAdvancePaid.Text = "";
                        txtServiceCharge.Text = "";
                        txtRemarks.Text = "";
                        txtGtotal.Text = "";
                        txtTotalBill.Text = "";
                        txtTotalBill.Tag = null;
                        txtDiscount.Text = "";
                        txtDue.Text = "";
                        txtPaid.Text = "";

                    }

                }

            }
            else
            {
                MessageBox.Show("Patient not selected. Plz select a patient and try again.");
            }
        }

        private void ViewPrintView(long _hbillId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            VMOPDPatientRecord _pInfo = ((VMOPDPatientRecord)btnBillSave.Tag);



            DataSet ds = new OPDFinancialService().GetOPDCashMemo(_hbillId);


            rptHpBill _rptBill = new rptHpBill();
            _rptBill.SetDataSource(ds);

            List<OPDPatientLedger> _pLedger = new OPDFinancialService().GetOPDPatientLedgerFinalById(_hbillId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetOPDBillCashMemotransaction(_pLedger);



            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _rptBill.SetParameterValue(p1, litem.Label);
                _rptBill.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rptBill.SetParameterValue(p3, "");
                }
                else
                {
                    if (litem.Value.ToString().ToLower().Contains('.'))
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString());
                    }
                    else
                    {
                        _rptBill.SetParameterValue(p3, litem.Value.ToString() + ".00");
                    }

                }

                if (litem.IsDue)
                {
                    isDue = true;
                }

                if (litem.IsDicounted)
                {
                    isDiscounted = true;
                }



            }


            for (int _count = _index + 1; _count <= 8; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rptBill.SetParameterValue(p1, "");
                _rptBill.SetParameterValue(p2, "");
                _rptBill.SetParameterValue(p3, "");
            }


            _rptBill.SetParameterValue("CabinNo", "");
            _rptBill.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
            _rptBill.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());
            _rptBill.SetParameterValue("WaterMark", "Print mode: " + "");

            if (isDue)
            {
                _rptBill.SetParameterValue("PayStatus", "DUE");
            }
            else
            {
                _rptBill.SetParameterValue("PayStatus", "PAID");
            }


            //Header & Footer Texts
            _rptBill.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);
            if (Configuration.ORG_CODE == "1")
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote1);
            }
            else
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote2);
            }


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptBill;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }
    }
}
