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
using HDMS.Model.Hospital;
using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Model.Enums;
using System.Threading;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.IPD;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.IPD;
using HDMS.Windows.Forms.UI.Hospital;
using HDMS.Model.OPD.VM;
using HDMS.Model.OPD;
using HDMS.Windows.Forms.UI.Reports.OPD;
using HDMS.Model.Common;
using HDMS.Service.Common;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class ctrlOPDProcedureBill : UserControl
    {
        bool unlocked = true;
        public ctrlOPDProcedureBill()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgPatient.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgPatient.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private IList<VMSelectedService> _SelectedServices;
        private void ctrlMR_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();
            _SelectedServices = new List<VMSelectedService>();

            dtpDischarge.Value = Utils.GetServerDateAndTime();
            ToolTip toolTip1 = new ToolTip();


            ctrlProcedureSearch.Location = new Point(txtProcedure.Location.X, txtProcedure.Location.Y);
            ctrlProcedureSearch.ItemSelected += CtrlProcedureSearch_ItemSelected;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            //toolTip1.SetToolTip(this.btnCCNote, "Cabin charge justification");
            LoadPatients();
            LoadPaymentModes();
        }

       
            private void LoadPaymentModes()
            {
                List<PaymentMode> _paymodes = new CommonService().GetPaymentModes();
                _paymodes.Insert(0, new PaymentMode() { PMId = 0, Name = "Select Mode" });
                cmbPaymentMode.DataSource = _paymodes;
                cmbPaymentMode.DisplayMember = "Name";
                cmbPaymentMode.ValueMember = "PMId";



                cmbPaymentMode.SelectedItem = _paymodes.Find(q => q.PMId == 1);

            }
        

        private void CtrlProcedureSearch_ItemSelected(Controls.SearchResultListControl<Model.OPD.VM.VMOPDServiceHead> sender, Model.OPD.VM.VMOPDServiceHead item)
        {
            txtProcedure.Text = item.ServiceHeadName;
            txtProcedure.Tag = item;
            txtRate.Text = item.Rate.ToString();
            txtQty.Text = "1";
            txtQty.Focus();
            sender.Visible = false;
        }

        private async void LoadPatients()
        {
            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentOPDAdmittedInfo();

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
                row.CreateCells(dgPatient, item.BedCabinNo, item.Name, item.AddmissionDate.ToString("dd/MM/yyyy"));
                dgPatient.Rows.Add(row);
            }

        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);
                btnBillSave.Tag = _pInfo;

                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;

            }

        }








        private void FillBillGrid(List<VMHpFinalBill> finalBillItems)
        {

            dgLedger.SuspendLayout();
            dgLedger.Rows.Clear();
            double _serviceCharge = 0;
            foreach (VMHpFinalBill item in finalBillItems)
            {
                _serviceCharge = _serviceCharge + (item.Total * 0) / 100;

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgLedger, item.SrlNo, item.ServiceName, item.Qty, item.Rate, item.Total);
                dgLedger.Rows.Add(row);
            }

            CalculateBill(finalBillItems, _serviceCharge);
        }

        private void CalculateBill(List<VMHpFinalBill> _finalBillItems, double serviceCharge)
        {
            txtDiscount.Text = "";
            txtPaid.Text = "";
            txtRemarks.Text = "";
            VMIPDInfo tagPatient = (VMIPDInfo)this.btnBillSave.Tag;

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


            VMIPDInfo _pInfo = (VMIPDInfo)btnBillSave.Tag;

            double _advancePaid = new HpFinancialService().GetRoughAdvancePaymentByPatient(_pInfo.AdmissionId);

            txtAdvancePaid.Text = _advancePaid.ToString();
            _gtotal = _gtotal - _advancePaid;

            txtDue.Text = _gtotal.ToString();
        }

        private void pathTransfer_Click(object sender, EventArgs e)
        {
            List<Patient> _pList = new PatientService().GetIndoorPatientList();

            List<HpPatientLedger> _hpLedegerList = new List<HpPatientLedger>();
            foreach (Patient _p in _pList)
            {
                HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNo(_p.AdmissionNo);
                if (_hp != null)
                {
                    double _pathBalance = new PatientLedgerService().GetPatientLedgerBalance(_p.PatientId);
                    double _currenthpBalance = new HpFinancialService().GetPatientCurrentBalance(_hp.AdmissionId);

                    HpPatientLedger _hpLedger = new HpPatientLedger();
                    _hpLedger.AdmissionId = _hp.AdmissionId;
                    _hpLedger.TranDate = _p.EntryDate;
                    _hpLedger.Particulars = "Pathology Bill No : " + _p.BillNo.ToString();
                    _hpLedger.Debit = _pathBalance;
                    _hpLedger.Credit = 0;
                    _hpLedger.Balance = _currenthpBalance - _pathBalance; // Negative balance means patient is payable this amount
                    _hpLedger.TransactionType = TransactionTypeEnum.HpPathologyBill.ToString();
                    _hpLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _hpLedegerList.Add(_hpLedger);

                }

            }

            if (_hpLedegerList.Count() > 0)
            {
                new HpFinancialService().SaveHpLedgerTransactionList(_hpLedegerList);
                MessageBox.Show("Transfreed");
            }
        }

        private void btnBillSave_Click(object sender, EventArgs e)
        {


            if (dgLedger.Rows.Count == 0)
            {
                MessageBox.Show("No service found. You may cancel this admission"); return;
            }

            bool isDischarged = false;

            DialogResult result = MessageBox.Show("Are you sure to discharge this patient?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                isDischarged = true;
            }

            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);
            HospitalPatientInfo _PInfo = new HospitalService().GetHospitalPatientInfoById(_pInfo.AdmissionId);

            if (_PInfo.Status.ToLower() != "discharged")
            {
                GenerateBillByType("Final");            // Final Bill Generate
            }
            else
            {
                MessageBox.Show("Patient already discharged.");
            }
            LoadPatients();
        }

        private void GenerateBillByType(string _billType)
        {

            string _Cabin = string.Empty;
            CabinInfo _cabinObj = new CabinInfo();
            int _pmodId = 0;
            PaymentMode _pMode = cmbPaymentMode.SelectedItem as PaymentMode;
            if (_pMode != null)
            {
                _pmodId = _pMode.PMId;
            }

            
            int _PCId = 0;
            PaymentChannel _pChannel = cmbPaymentChannel.SelectedItem as PaymentChannel;
            if (_pChannel != null)
            {
                _PCId = _pChannel.PCId;
            }

            if (btnBillSave.Tag != null && !String.IsNullOrEmpty(lblName.Text))
            {


                VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

                if (_pInfo != null)
                {
                    //List<HpPatientLedgerRough> _pLFinal = new HpFinancialService().GetRoughAdvancePaymentList(_pInfo.AdmissionId);


                    OpdProcedureBill _pbill = new OpdProcedureBill();
                    _pbill.AdmissionId = _pInfo.AdmissionId;
                    _pbill.BillDate = Utils.GetServerDateAndTime();
                    _pbill.BillTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _pbill.BillNo = _pInfo.BillNo;
                    _pbill.Remarks = txtRemarks.Text;
                    _pbill.BillType = _billType;
                    _pbill.PreparedBy = MainForm.LoggedinUser.Name;
                    _pbill.isBillDistributed = false;
                    long _pbillId = new HpFinancialService().SaveOpdProcedureBill(_pbill);
                    if (_pbillId > 0)
                    {

                        List<OpdProcedureBillDetails> _ObilldetailList = new List<OpdProcedureBillDetails>();
                        foreach (DataGridViewRow row in dgLedger.Rows)
                        {
                            VMSelectedService selectedItems = row.Tag as VMSelectedService;

                            OpdProcedureBillDetails _Opddetail = new OpdProcedureBillDetails();
                            _Opddetail.ProcedureBillId = _pbillId;
                            _Opddetail.ServiceName = selectedItems.ServiceHeadName;
                            _Opddetail.Qty = selectedItems.Qty;
                            _Opddetail.Rate = selectedItems.Rate;
                            _Opddetail.Total = selectedItems.Amount;
                            _ObilldetailList.Add(_Opddetail);
                        }

                        if (_ObilldetailList.Count > 0)
                        {
                            if (new HpFinancialService().SaveOpdProcedureBillDetail(_ObilldetailList))
                            {

                                MessageBox.Show("Final Bill Generated Successfully");

                                _cabinObj = GetCabinNo(_pbillId);

                                HospitalPatientInfo _PInfo = new HospitalService().GetHospitalPatientInfoById(_pInfo.AdmissionId);
                                _PInfo.Status = "Discharged";
                                // _PInfo.Dischargedby = MainForm.LoggedinUser.Name;
                                _PInfo.DischargeDate = Utils.GetServerDateAndTime();
                                _PInfo.DischargeTime = Utils.GetServerDateAndTime().ToString("HH:mm:ss tt");
                                _PInfo.Dischargedby = MainForm.LoggedinUser.Name;
                                new HospitalService().UpdateHospitalPatientInfo(_PInfo);


                                Free_Cabin(_pInfo);

                                new HospitalCabinBedService().UpdateCurrentAccomodation(_pInfo.AdmissionId);

                                double balance = 0;
                                double _serviceCharge = 0;
                                double _total = 0;
                                double.TryParse(txtTotalBill.Text, out _total);

                                double _MedicineBill = 0;
                                if (txtTotalBill.Tag != null)
                                {
                                    double.TryParse(txtTotalBill.Tag.ToString(), out _MedicineBill);
                                }

                                balance = 0 - Convert.ToDouble(txtTotalBill.Text);
                                //Save On Entry Payment Information
                                List<OpdProcedurepatientLedger> transactionList = new List<OpdProcedurepatientLedger>();

                                double discount = 0;
                                double.TryParse(txtDiscount.Text, out discount);

                                OpdProcedurepatientLedger pLedger = new OpdProcedurepatientLedger();
                                pLedger.ProcedureBillId = _pbillId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.Particulars = "Total Bill";
                                pLedger.Debit = Convert.ToDouble(txtTotalBill.Text);
                                pLedger.Credit = 0;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.HpTotalBiLL.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                transactionList.Add(pLedger);


                                balance = balance - _serviceCharge;
                                pLedger = new OpdProcedurepatientLedger();
                                pLedger.ProcedureBillId = _pbillId;
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
                                    pLedger = new OpdProcedurepatientLedger();
                                    pLedger.ProcedureBillId = _pbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.Particulars = "Discount";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = discount;
                                    pLedger.Balance = balance;
                                    pLedger.TransactionType = TransactionTypeEnum.HpDiscount.ToString();
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    transactionList.Add(pLedger);
                                }


                                // Check whether advance payment made by this user

                                double _advancePaidTk = 0; //new HpFinancialService().GetAdvancePaymentByPatient(_pInfo.AdmissionId);
                                double.TryParse(txtAdvancePaid.Text, out _advancePaidTk);

                                

                                double paidTk = 0;
                                double.TryParse(txtPaid.Text, out paidTk);

                                if (paidTk > 0)
                                {
                                    balance = balance + paidTk;
                                    pLedger = new OpdProcedurepatientLedger();
                                    pLedger.ProcedureBillId = _pbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.Particulars = "Payment";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = paidTk;
                                    pLedger.Balance = balance;
                                    pLedger.TransactionType = TransactionTypeEnum.HpPaidAmount.ToString();
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    transactionList.Add(pLedger);

                                }
                               
                                double paymentBymobileOrcard = 0;
                                double.TryParse(txtCardOrMobileReceiveTk.Text, out paymentBymobileOrcard);
                                
                                if (paymentBymobileOrcard > 0)
                                {

                                    balance = balance + paymentBymobileOrcard;
                                    pLedger = new OpdProcedurepatientLedger();
                                    pLedger.ProcedureBillId = _pbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.Particulars = "Payment by MobileBamking Or Card";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = paymentBymobileOrcard;
                                    pLedger.Balance = balance;
                                    if (_pmodId == 2)
                                    {
                                        pLedger.TransactionType = TransactionTypeEnum.PaymentbyMobileBanking.ToString();
                                    }
                                    else if(_pmodId==3)
                                    {
                                        pLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                                    }
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    transactionList.Add(pLedger);

                                }

                                if (transactionList.Count > 0)
                                {
                                    HpFinancialService fpService = new HpFinancialService();
                                    fpService.SaveOpdProcedureLedger(transactionList);
                                }

                            }
                        }

                        ViewPrintView(_pbillId, _billType, _cabinObj.CabinNo);


                        dgLedger.SuspendLayout();
                        dgLedger.Rows.Clear();
                        // btnBillSave.Tag = null;
                        lblName.Text = "";
                        lblCabin.Text = "";

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

        private void Free_Cabin(VMIPDInfo _pInfo)
        {

            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedService().GetHpOccupiedCabinListByAdmisissionId(_pInfo.AdmissionId);

            foreach (var acconObj in _accomList)
            {
                CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(acconObj.CabinId);

                _cabin.IsBooked = false;
                new HospitalCabinBedService().UpdateCabinInfo(_cabin);
            }


        }

        private void ViewPrintView(long _billId, string _billType, string _Cabin)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            if(string.IsNullOrEmpty(_Cabin))
            {
                _Cabin = "";
            }

            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);



            DataSet ds = new HpFinancialService().GetOpdCashMemo(_billId);


            rptOpdProcedureBill _rptBill = new rptOpdProcedureBill();
            _rptBill.SetDataSource(ds);

            List<OpdProcedurepatientLedger> _pLedger = new HpFinancialService().GetProcedurePatientLedgerFinalById(_billId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetOpdProcedureCashMemotransaction(_pLedger);



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


            _rptBill.SetParameterValue("CabinNo", _Cabin);
            _rptBill.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
            _rptBill.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());
            _rptBill.SetParameterValue("WaterMark", "Print mode: " + _billType);

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
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote1);
                _rptBill.SetParameterValue("OrgLicenseNo", "License No:" + ComapnyDetail.MAH_NAY_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", "Reg. Code:" + ComapnyDetail.MAH_NAY_Hospital_RegCode);
            }
            else
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote2);
                _rptBill.SetParameterValue("OrgLicenseNo", ComapnyDetail.MAH_AKH_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", ComapnyDetail.MAH_AKH_Hospital_RegCode);
            }


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptBill;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private CabinInfo GetCabinNo(long _billId)
        {
            OpdProcedureBill _hbill = new HpFinancialService().GetOpdProcedureBillById(_billId);

            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hbill.AdmissionId);

            if (_accomInfo == null)
            {
                return new CabinInfo();
               
            }
            else
            {
                CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                return _Cabin;
            }


        }
        private CabinInfo GetCabinNoByOpdProcedureBill(long _billId)
        {
            OpdProcedureBill _hbill = new HpFinancialService().GetOpdProcedureBillById(_billId);

            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hbill.AdmissionId);

            if (_accomInfo == null)
            {
                return new CabinInfo();

            }
            else
            {
                CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                return _Cabin;
            }


        }

        private CabinInfo GetRoughBillCabinNo(long _billId)
        {
            HospitalRoughBill _hbill = new HpFinancialService().GetHospitalRoughBillById(_billId);

            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_hbill.AdmissionId);

            if (_accomInfo == null)
            {
                return new CabinInfo();
            }
            else
            {
                CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                return _Cabin;
            }


        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
           .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

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
            //if (!String.IsNullOrEmpty(txtServiceCharge.Tag.ToString()))
            //{
            //    double.TryParse(txtServiceCharge.Tag.ToString(), out _serviceCharge);
            //}

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

            //if (_disc > _serviceCharge / 2)
            //{
            //    DialogResult result = MessageBox.Show("Discount exceeds the limit 50% of service charge. Continue yet..", "Confirmation", MessageBoxButtons.YesNoCancel);

            //    if (result == DialogResult.Yes)
            //    {
            //        if (_disc > _serviceCharge)
            //        {
            //            txtDiscount.Text = _serviceCharge.ToString();
            //            _disc = _serviceCharge;
            //        }

            //        txtPaid.Focus();

            //    }
            //    else
            //    {
            //        txtDiscount.Text = "";
            //        return;
            //    }
            //}



            //if (Configuration.ORG_CODE == "2")
            //{
            //    _serviceCharge = (_MedicineBill * 5) / 100 + ((_total - _MedicineBill) * 25) / 100 - _disc;
            //}
            //else
            //{
            //    _serviceCharge= (_total  * 25) / 100 - _disc;
            //}


            _serviceCharge = _serviceCharge - _disc;

            //txtServiceCharge.Text = _serviceCharge.ToString();
            txtServiceCharge.Text = "";

            txtGtotal.Text = (_total + _serviceCharge).ToString();

            txtDue.Text = ((_total - _advancePaid) + _serviceCharge).ToString();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
             .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

            double _total = 0;
            double.TryParse(_tDebit, out _total);

            double _advancePaid = 0;
            double.TryParse(txtAdvancePaid.Text, out _advancePaid);


            double paymentBymobileOrcard = 0;
            double.TryParse(txtCardOrMobileReceiveTk.Text, out paymentBymobileOrcard);


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


            txtDue.Text = ((_total + _serviceCharge) - (_PaidTk + _advancePaid + _disc+ paymentBymobileOrcard)).ToString();

            double dueTk = 0;
            double.TryParse(txtDue.Text, out dueTk);

            //if (dueTk < 0)
            //{
            //    MessageBox.Show("Paid amount exceeds the bill amount. Plz. check it and try again");
            //    txtPaid.Text = "";
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = Utils.GetServerDateAndTime().ToString("hh:mm tt");
        }

        private void btnRoughBill_Click(object sender, EventArgs e)
        {

            if (dgLedger.Rows.Count == 0)
            {
                MessageBox.Show("No service found. You may cancel this admission"); return;
            }

            string _msg = "Rough bill generated successfully.";

            GenerateRoughBill("Rough", _msg);



            // CalculateBill();
        }

        private void GenerateRoughBill(string _billType, string _msg)
        {
            string _Cabin = string.Empty;
            CabinInfo _cabinObj = new CabinInfo();

            if (btnBillSave.Tag != null && !String.IsNullOrEmpty(lblName.Text))
            {


                VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

                if (_pInfo != null)
                {
                    List<HpPatientLedgerRough> _pLRough = new HpFinancialService().GetRoughAdvancePaymentList(_pInfo.AdmissionId);

                    if (!new HpFinancialService().DeleteExistingBill(_pInfo.AdmissionId))
                    {
                        return;
                    }

                    HospitalRoughBill _hbill = new HospitalRoughBill();
                    _hbill.AdmissionId = _pInfo.AdmissionId;
                    _hbill.BillDate = Utils.GetServerDateAndTime();
                    _hbill.BillTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    _hbill.BillNo = _pInfo.BillNo;
                    _hbill.Remarks = txtRemarks.Text;
                    _hbill.BillType = _billType;
                    _hbill.PreparedBy = MainForm.LoggedinUser.Name;

                    long _hbillId = new HpFinancialService().SaveHpRoughBill(_hbill);
                    if (_hbillId > 0)
                    {

                        List<HospitalRoughBillDetail> _hbilldetailList = new List<HospitalRoughBillDetail>();
                        foreach (DataGridViewRow row in dgLedger.Rows)
                        {
                            VMHpFinalBill selectedItems = row.Tag as VMHpFinalBill;

                            HospitalRoughBillDetail _hbdetail = new HospitalRoughBillDetail();
                            _hbdetail.HospitalRoughBillId = _hbillId;
                            _hbdetail.ServiceName = selectedItems.ServiceName;
                            _hbdetail.Qty = selectedItems.Qty;
                            _hbdetail.Rate = selectedItems.Rate;
                            _hbdetail.Total = selectedItems.Total;
                            _hbilldetailList.Add(_hbdetail);
                        }

                        if (_hbilldetailList.Count > 0)
                        {
                            if (new HpFinancialService().SaveHpRoughBillDetail(_hbilldetailList))
                            {

                                MessageBox.Show(_msg);


                                _cabinObj = GetRoughBillCabinNo(_hbillId);



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
                                List<HpPatientLedgerRough> transactionList = new List<HpPatientLedgerRough>();

                                double discount = 0;
                                double.TryParse(txtDiscount.Text, out discount);

                                HpPatientLedgerRough pLedger = new HpPatientLedgerRough();
                                pLedger.HospitalRoughBillId = _hbillId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                pLedger.Particulars = "Total Bill";
                                pLedger.Debit = Convert.ToDouble(txtTotalBill.Text);
                                pLedger.Credit = 0;
                                pLedger.Balance = balance;
                                pLedger.TransactionType = TransactionTypeEnum.HpTotalBiLL.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                transactionList.Add(pLedger);


                                balance = balance - _serviceCharge;
                                pLedger = new HpPatientLedgerRough();
                                pLedger.HospitalRoughBillId = _hbillId;
                                pLedger.TranDate = Utils.GetServerDateAndTime();
                                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
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
                                    pLedger = new HpPatientLedgerRough();
                                    pLedger.HospitalRoughBillId = _hbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                    pLedger.Particulars = "Discount";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = discount;
                                    pLedger.Balance = balance;
                                    pLedger.TransactionType = TransactionTypeEnum.HpDiscount.ToString();
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    transactionList.Add(pLedger);
                                }


                                // Check whether advance payment made by this user

                                double _advancePaidTk = 0; //new HpFinancialService().GetAdvancePaymentByPatient(_pInfo.AdmissionId);
                                double.TryParse(txtAdvancePaid.Text, out _advancePaidTk);

                                if (_advancePaidTk > 0)
                                {

                                    foreach (HpPatientLedgerRough _rl in _pLRough)
                                    {
                                        balance = balance + _rl.Credit;
                                        pLedger = new HpPatientLedgerRough();
                                        pLedger.HospitalRoughBillId = _hbillId;
                                        pLedger.TranDate = _rl.TranDate;
                                        pLedger.TransactionTime = _rl.TransactionTime;
                                        pLedger.Particulars = "Advance Payment";
                                        pLedger.Debit = 0;
                                        pLedger.Credit = _rl.Credit;
                                        pLedger.Balance = balance;
                                        pLedger.TransactionType = TransactionTypeEnum.HpAdvance.ToString();
                                        pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                        transactionList.Add(pLedger);
                                    }
                                }

                                double paidTk = 0;
                                double.TryParse(txtPaid.Text, out paidTk);

                                if (paidTk > 0)
                                {


                                    balance = balance + paidTk;
                                    pLedger = new HpPatientLedgerRough();
                                    pLedger.HospitalRoughBillId = _hbillId;
                                    pLedger.TranDate = Utils.GetServerDateAndTime();
                                    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                    pLedger.Particulars = "Advance Payment";
                                    pLedger.Debit = 0;
                                    pLedger.Credit = paidTk;
                                    pLedger.Balance = balance;
                                    pLedger.TransactionType = TransactionTypeEnum.HpAdvance.ToString();
                                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                                    transactionList.Add(pLedger);



                                }

                                if (transactionList.Count > 0)
                                {
                                    HpFinancialService fpService = new HpFinancialService();
                                    fpService.SaveHpRoughLedger(transactionList);
                                }

                            }
                        }

                        if (_billType.ToLower() == "rough")
                        {
                            ViewRoughPrintView(_hbillId, _billType, _cabinObj.CabinNo);
                        }
                        else
                        {
                            ViewAdvanceReceipt(_hbillId, _cabinObj.CabinNo);
                        }

                        dgLedger.SuspendLayout();
                        dgLedger.Rows.Clear();
                        lblName.Text = "";
                        lblCabin.Text = "";

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
        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentMode _pmode = cmbPaymentMode.SelectedItem as PaymentMode;
            if (_pmode != null)
            {
                List<PaymentChannel> _pChannelList = new CommonService().GetPaymentChannels(_pmode.PMId);
                _pChannelList.Insert(0, new PaymentChannel() { PCId = 0, Name = "Select Channel" });
                cmbPaymentChannel.DataSource = _pChannelList;
                cmbPaymentChannel.DisplayMember = "Name";
                cmbPaymentChannel.ValueMember = "PCId";

                if (_pmode.PMId == 1 || _pmode.PMId == 4 || _pmode.PMId == 5)
                {

                    cmbPaymentChannel.SelectedItem = _pChannelList.Find(q => q.PMId == _pmode.PMId);
                    txtTransactionNo.Enabled = false;
                    txtCardOrMobileReceiveTk.Enabled = false;
                }
                else
                {
                    txtTransactionNo.Enabled = true;
                    txtCardOrMobileReceiveTk.Enabled = true;
                }
            }
        }

        private void ViewAdvanceReceipt(long _hbillId, string cabinNo)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

            if (_pInfo != null)
            {

                HospitalPatientInfo _PatientInfo = new HospitalService().GetHospitalPatientInfoById(_pInfo.AdmissionId);

                if (_PatientInfo.Status.ToLower() == "discharged")
                {
                    MessageBox.Show("Patient already discharged."); return;
                }


                HospitalRoughBill _rBill = new HpFinancialService().GetHospitalRoughBillByAdmissionId(_pInfo.AdmissionId);

                if (_rBill == null)
                {
                    MessageBox.Show("No transaction found."); return;
                }


                CabinInfo _cabinObj = GetRoughBillCabinNo(_rBill.HospitalRoughBillId);

                DataSet ds = new HpFinancialService().GetHpRoughCashMemo(_rBill.HospitalRoughBillId);

                rptMoneyReceipt _moneyReceipt = new rptMoneyReceipt();

                _moneyReceipt.SetDataSource(ds);

                List<HpPatientLedgerRough> _pLRough = new HpFinancialService().GetRoughAdvancePaymentList(_pInfo.AdmissionId);

                if (_pLRough.Count == 0)
                {
                    MessageBox.Show("No advance found."); return;
                }

                long maxTran = _pLRough.Max(w => w.TranId);
                var _ledger = _pLRough.Where(w => w.TranId == maxTran).FirstOrDefault();


                _moneyReceipt.SetParameterValue("CabinNo", _cabinObj.CabinNo);
                _moneyReceipt.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
                _moneyReceipt.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());

                _moneyReceipt.SetParameterValue("AdvanceTk", _ledger.Credit.ToString());


                // Header and Footer Settings
                _moneyReceipt.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);
                if (Configuration.ORG_CODE == "1")
                {
                    _moneyReceipt.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                    _moneyReceipt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", " + ComapnyDetail.EmailAddress);
                    _moneyReceipt.SetParameterValue("footnote", ComapnyDetail.footNote1);
                }
                else
                {
                    _moneyReceipt.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                    _moneyReceipt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                    _moneyReceipt.SetParameterValue("footnote", ComapnyDetail.footNote2);
                }



                ReportViewer rv = new ReportViewer();
                rv.crviewer.ReportSource = _moneyReceipt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private void ViewRoughPrintView(long _billId, string _billType, string _Cabin)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            if (string.IsNullOrEmpty(_Cabin)) _Cabin = "";

            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);



            DataSet ds = new HpFinancialService().GetHpRoughCashMemo(_billId);


            rptHpBill _rptBill = new rptHpBill();
            _rptBill.SetDataSource(ds);

            List<HpPatientLedgerRough> _pLedger = new HpFinancialService().GetPatientLedgerRoughById(_billId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetHospitalRoughCashMemotransaction(_pLedger);



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


            _rptBill.SetParameterValue("CabinNo", _Cabin);
            _rptBill.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
            _rptBill.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());
            _rptBill.SetParameterValue("WaterMark", "Print mode: " + _billType);




            if (isDue)
            {
                _rptBill.SetParameterValue("PayStatus", "DUE");
            }
            else
            {
                _rptBill.SetParameterValue("PayStatus", "PAID");
            }


            // Header and Footer Settings
            _rptBill.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);


            if (Configuration.ORG_CODE == "1")
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_BillingContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote1);
                _rptBill.SetParameterValue("OrgLicenseNo", "License No:" + ComapnyDetail.MAH_NAY_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", "Reg. Code:" + ComapnyDetail.MAH_NAY_Hospital_RegCode);
            }
            else
            {
                _rptBill.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                _rptBill.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                _rptBill.SetParameterValue("footnote", ComapnyDetail.footNote2);
                _rptBill.SetParameterValue("OrgLicenseNo", ComapnyDetail.MAH_AKH_Hospital_License);
                _rptBill.SetParameterValue("OrgRegCode", ComapnyDetail.MAH_AKH_Hospital_RegCode);
            }



            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rptBill;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnDueCollection_Click(object sender, EventArgs e)
        {
            frmHpDueCollection _frm = new frmHpDueCollection();
            _frm.Show();
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByCabin.Text, "cabin");
            }
        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentOPDInfoBySearchParameter(_prefix, type).ToList();

            if (_lisPatientInfo.Count() == 0) return;

            // lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
        }

        private void btnMoneyReceipt_Click(object sender, EventArgs e)
        {
            string _msg = "Advance collection successful.";

            GenerateRoughBill("Advance", _msg);
        }

        private void dgLedger_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgLedger.SelectedRows.Count != 0)
            //{
            //    DataGridViewRow row = this.dgLedger.SelectedRows[0];
            //    VMHpFinalBill _bInfo = ((VMHpFinalBill)row.Tag);

            //    VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

            //    if (_bInfo.ServiceName.ToLower().Trim() == "medicine bill")
            //    {

            //        ViewMedicineDetail(_pInfo.BillNo, lblCabin.Text);

            //    }
            //    else if (_bInfo.ServiceName.ToLower().Trim() == "investigations bill")
            //    {
            //        ViewInvestigationDetail(_pInfo.BillNo, lblCabin.Text);
            //    }
            //    else if (_bInfo.ServiceName.ToLower().Trim() == "consultant fee")
            //    {
            //        ViewConsultancyList(_pInfo.BillNo, lblCabin.Text);
            //    }
            //}
        }

        private void ViewConsultancyList(long billNo, string CabinNo)
        {
            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(billNo);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new HpFinancialService().GetConsultancyDetailsByPatientId(_pInfo.AdmissionId);


            rptConsultancyByPatient _rpt = new rptConsultancyByPatient();
            _rpt.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            // _invDetail.SetParameterValue("CabinNo", _CabinNo);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewInvestigationDetail(long _billNum, string _CabinNo)
        {
            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNum);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new DiagFinancialService().GetInvestigationDetailsByPatientId(_pInfo.AdmissionId);


            rptIPDInvestigationList _invDetail = new rptIPDInvestigationList();
            _invDetail.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            _invDetail.SetParameterValue("CabinNo", _CabinNo);

            rv.crviewer.ReportSource = _invDetail;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewMedicineDetail(long _billNum, string _Cabin)
        {

            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNum);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new PhReportingService().GetMedicineDetailsByPatientId(_pInfo.AdmissionId);


            rptIPDPatientMedicineDetail _medicineDetail = new rptIPDPatientMedicineDetail();
            _medicineDetail.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            _medicineDetail.SetParameterValue("CabinNo", _Cabin);

            rv.crviewer.ReportSource = _medicineDetail;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnCCNote_Click(object sender, EventArgs e)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnBillSave.Tag);

            if (_pInfo != null)
            {
                DataSet ds = new HpFinancialService().GetCabinChargeDetails(_pInfo.AdmissionId);

                rptCabinChargeJustificationNote _rpt = new rptCabinChargeJustificationNote();

                _rpt.SetDataSource(ds);

                //_rpt.SetParameterValue("RegNo", txtRegNo.Text);

                ReportViewer rv = new ReportViewer();


                // _cashmemo.DataDefinition.FormulaFields[5].Text = txtHCVAdjustment.Text;
                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtProcedure_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProcedure.Text;
                HideAllDefaultHidden();

                ctrlProcedureSearch.Visible = true;
                ctrlProcedureSearch.txtSearch.Text = _txt;
                ctrlProcedureSearch.txtSearch.SelectionStart = ctrlProcedureSearch.txtSearch.Text.Length;

                ctrlProcedureSearch.LoadData();


            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlProcedureSearch.Visible = false;
        }

        private void ctrlProcedureSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProcedure.Focus();
            }
        }

        private void txtQtykeeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar ==(char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtQty.Text))
                {
                    int _Qty = 0;
                    double _Rate = 0;
                    int.TryParse(txtQty.Text, out _Qty);
                    double.TryParse(txtRate.Text, out _Rate);
                    VMOPDServiceHead _Servicehead = (VMOPDServiceHead)txtProcedure.Tag;

                    new HospitalService().PopulateSelectedOPDServices(_SelectedServices, _Servicehead, _Rate, _Qty, MainForm.LoggedinUser.Name);
                    FillServiceGrid();
                    unlocked = false;
                    txtQty.Text = "";
                    txtRate.Text = "";
                    //txtService.Text = "";
                    //txtService.Tag = null;



                    unlocked = true;
                }
            }
        }
        private void FillServiceGrid()
        {
            dgLedger.SuspendLayout();
            dgLedger.Rows.Clear();
            foreach (VMSelectedService item in _SelectedServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgLedger, item.ServiceHeadName, item.Rate, item.Qty, item.Amount);
                dgLedger.Rows.Add(row);
            }

            CalculateTotalAmount();
        }
        private void CalculateTotalAmount()
        {
            txtTotalBill.Text = dgLedger.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

            txtGtotal.Text = dgLedger.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

            txtDue.Text = dgLedger.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

            double _due = 0, _paid = 0;
            double.TryParse(txtDue.Text, out _due);
            double.TryParse(txtPaid.Text, out _paid);

           
           txtDue.Text = (_due - _paid).ToString();
           

        }



        private void txtqtychanged(object sender, EventArgs e)
        {
            txtQty.Focus();
        }

        private void dgledgerDeleteRow(object sender, DataGridViewRowEventArgs e)
        {
            VMSelectedService _SelectedItem = (VMSelectedService)e.Row.Tag;

            _SelectedServices.Remove(e.Row.Tag as VMSelectedService);
            CalculateTotalAmount();
        }

        private void ctrlProcedureSearch_Load(object sender, EventArgs e)
        {

        }

        private void txtCardOrMobileReceiveTk_TextChanged(object sender, EventArgs e)
        {
            string _tDebit = dgLedger.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();

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
            double.TryParse(txtCardOrMobileReceiveTk.Text, out _PaidTk);


            txtDue.Text = ((_total + _serviceCharge) - (_PaidTk + _advancePaid)).ToString();

            double dueTk = 0;
            double.TryParse(txtDue.Text, out dueTk);

            //if (dueTk < 0)
            //{
            //    MessageBox.Show("Paid amount exceeds the bill amount. Plz. check it and try again");
            //    txtPaid.Text = "";
            //}
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
