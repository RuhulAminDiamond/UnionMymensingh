using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;
using HDMS.Model.Users;
using HDMS.Model.ViewModel;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.OPD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class frmOPDRefund : Form
    {
        bool _PatientCancelled = false;


        public frmOPDRefund()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                LoadPatientHistory();
              
            }
        }

        private void LoadPatientHistory()
        {
            long _pId = 0;
            long.TryParse(txtBillNo.Text, out _pId);

            OPDPatientRecord _PatientInfo = new PatientService().GetOPDPatientByBillNo(_pId);

            if (_PatientInfo == null) _PatientInfo = new PatientService().GetOPDPatientByIdNo(_pId);

            if (_PatientInfo == null)
            {
                MessageBox.Show("Patient not found.", "HERP");
                txtBillNo.Tag = null;
            }
            else
            {

                


                txtBillNo.Tag = _PatientInfo;
                LoadRegPatientInfo(_PatientInfo.RegNo);


                txtRefBy.Text = new DoctorService().GetDoctorById(_PatientInfo.DoctorId).Name;
                txtRefBy.Tag = new DoctorService().GetDoctorById(_PatientInfo.DoctorId);
                dtpEntry.Value = _PatientInfo.EntryDate;

                btnCancelPatient.Enabled = true;
                if (_PatientInfo.GroupId==3 && !String.IsNullOrEmpty(_PatientInfo.Status) && _PatientInfo.Status!="Cancelled")
                {
                    DataSet ds = new OPDPatientService().GetConsultancyServiceList(_PatientInfo.PatientId);

                    DataTable dt = ds.Tables[0];



                    _SelectedServices = (from DataRow dr in dt.Rows
                                      select new SelectedServicesForOPDPatient()
                                      {
                                          ServiceOrConsultandId = Convert.ToInt32(dr["ServiceOrConsultantId"]),
                                          DisplayName = dr["ServiceName"].ToString(),
                                          Qty = Convert.ToInt32(dr["Qty"]),
                                          Rate = Convert.ToInt32(dr["Rate"]),
                                          TAmount = Convert.ToInt32(dr["TAmount"]),
                                       
                                          GroupId = Convert.ToInt32(dr["GroupId"]),
                                          VisitTypeId = Convert.ToInt32(dr["VisitTypeId"]),
                                          Status = dr["Status"].ToString(),
                                          UserName = dr["LoginName"].ToString(),

                                      }).ToList();


                    FillServiceGrid();

                    SetTotalAmount(_PatientInfo.PatientId);


                }else if (_PatientInfo.GroupId != 3 && !String.IsNullOrEmpty(_PatientInfo.Status) && _PatientInfo.Status != "Cancelled")
                {
                    DataSet ds = new OPDPatientService().GetOPDServiceListExceptConsultancy(_PatientInfo.PatientId);

                    DataTable dt = ds.Tables[0];



                    _SelectedServices = (from DataRow dr in dt.Rows
                                         select new SelectedServicesForOPDPatient()
                                         {
                                             ServiceOrConsultandId = Convert.ToInt32(dr["ServiceOrConsultantId"]),
                                             DisplayName = dr["ServiceName"].ToString(),
                                             Qty = Convert.ToInt32(dr["Qty"]),
                                             Rate = Convert.ToInt32(dr["Rate"]),
                                             TAmount = Convert.ToInt32(dr["TAmount"]),
                                          
                                             GroupId = Convert.ToInt32(dr["GroupId"]),
                                             Status = dr["Status"].ToString(),
                                             UserName = dr["LoginName"].ToString(),

                                         }).ToList();


                    FillServiceGrid();

                    SetTotalAmount(_PatientInfo.PatientId);
                }
                else
                {
                   // MessageBox.Show("This is a cancelled Id.", "HERP");
                    SetTotalAmount(_PatientInfo.PatientId);
                    //btnCancelPatient.Enabled = false;
                }
            }
        }

        private void FillServiceGrid()
        {
            dgServices.SuspendLayout();
            dgServices.Rows.Clear();
            foreach(var item in _SelectedServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;


                row.CreateCells(dgServices, item.ServiceOrConsultandId, item.DisplayName, item.Qty, item.Rate, item.TAmount);
                dgServices.Rows.Add(row);
            }

        }

        private void SetTotalAmount(long patientId)
        {
            List<OPDPatientLedgerRough> _pLedger = new OPDFinancialService().GetOPDPatienLedgerRough(patientId);
            double _totalBill = _pLedger.Where(q=>q.TransactionType==TransactionTypeEnum.OPDServiceCost.ToString()).Sum(x => x.Debit);
            double _totalPaid = _pLedger.Where(q => q.TransactionType == TransactionTypeEnum.OnEntryPayment.ToString()).Sum(x => x.Credit);
            double _totalDiscount = _pLedger.Where(q => q.TransactionType == TransactionTypeEnum.DiscountOnRegularCollection.ToString()).Sum(x => x.Credit);
            double _totalDueCollection = _pLedger.Where(q => q.TransactionType == TransactionTypeEnum.DueCollection.ToString()).Sum(x => x.Credit);
            double _totalDiscountOnDueCollection = _pLedger.Where(q => q.TransactionType == TransactionTypeEnum.DiscountOnDueCollection.ToString()).Sum(x => x.Credit);

            double _totalCancelled = _pLedger.Where(q => q.TransactionType == TransactionTypeEnum.ServiceCancelled.ToString()).Sum(x => x.Credit);

            double _due = _totalBill - (_totalPaid + _totalDiscount+ _totalDueCollection+ _totalDiscountOnDueCollection);

            txtTotalBill.Tag = _totalBill;
            txtTotalBill.Text = _totalBill.ToString();
            txtPaidTk.Text = _totalPaid.ToString();
            txtDiscountTk.Text = _totalDiscount.ToString();
            txtDueTk.Text = _due.ToString();

            txtCancelledTk.Text = _totalCancelled.ToString();

            SetReturnAmount(patientId);
        }

        private bool LoadRegPatientInfo(long regNo)
        {
            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(regNo);
            if (_record != null)
            {
                txtPatientName.Text = _record.FullName;
                txtYears.Text = _record.AgeYear;
                txtMonths.Text = _record.AgeMonth;
                txtDays.Text = _record.AgeDay;
                cmbGender.Text = _record.Sex;
                txtCountryCode.Text = _record.CountryCode;
                txtCellPhone.Text = _record.MobileNo;
                return true;

            }

            return false;
        }

        IList<SelectedServicesForOPDPatient> _SelectedServices;
        private void frmOPDRefund_Load(object sender, EventArgs e)
        {
            _SelectedServices = new List<SelectedServicesForOPDPatient>();
           // SetCancelAndRefundCondition();
        }

        private bool IsUserWithinAdminGroup(LoginUser loggedinUser)
        {
            User _user = new UserService().GetUserById(loggedinUser.UserId);
            if (_user.RoleId == 3 || _user.RoleId == 4 || _user.RoleId == 5 || _user.RoleId == 6)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void SetCancelAndRefundCondition()
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            if (_user.RoleId == 3 || _user.RoleId == 4 || _user.RoleId == 5 || _user.RoleId == 6)
            {
                btnCancelPatient.Text = "Cancel Selected Service";
                btnCancelPatient.Text = "Cancel patient";

                btnCancelPatient.Enabled = true;
                btnCancelSelectedTest.Enabled = true;
                btnRefund.Enabled = true;

                btnCancelPatient.Tag = "CancelAction";
                btnCancelSelectedTest.Tag = "CancelAction";
            }
            else
            {
                btnCancelSelectedTest.Text = "Approve Service Cancel";
                btnCancelPatient.Text = "Approve Patient Cancel";

                btnCancelPatient.Enabled = true;
                btnCancelSelectedTest.Enabled = true;
                btnRefund.Enabled = false;

                btnCancelPatient.Tag = "CancelApprove";
                btnCancelSelectedTest.Tag = "CancelApprove";
            }
        }


        private void btnCancelPatient_Click(object sender, EventArgs e)
        {
              
            

             DialogResult result = MessageBox.Show("Are you sure to cancel this opd patient?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes && dgServices.Rows.Count > 0 && txtBillNo.Tag != null)
                {

                    btnCancelPatient.Enabled = false;

                    OPDPatientRecord _Patient = (OPDPatientRecord)txtBillNo.Tag;

                   

                    if (new OPDPatientService().CancelPatient(_Patient.PatientId, MainForm.LoggedinUser.Name))
                    {

                        dgServices.SuspendLayout();
                        dgServices.Rows.Clear();

                        _PatientCancelled = true;
                        double _Amount = _SelectedServices.Sum(x => x.TAmount); //Convert.ToDouble(txtCancelledTk.Text);


                        //if (new OPDPatientService().CancelSAllervice(_Patient.PatientId))
                        //{
                            AdjustPatientLedgerForPatientCancel(_Patient.PatientId, _Amount);
                            SetReturnAmount(_Patient.PatientId);
                       // }
                    }

                    btnCancelPatient.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Service or bill not found.");
                }
            
        }

        private void SetReturnAmount(long patientId)
        {
            double _refundable = new OPDPatientLedgerService().GetRefundable(patientId);
            txtReturnableTk.Text = _refundable.ToString();
        }

        private void AdjustPatientLedgerForPatientCancel(long patientId, double amount)
        {
            double _discountGiven = new OPDPatientLedgerService().GetDiscountedAmount(patientId);
            double _currentBalance = new OPDPatientLedgerService().GetCurrentBalance(patientId);


            double _returnableAmount = (amount + _currentBalance) - _discountGiven;

            DateTime _trandate = Utils.GetServerDateAndTime();

            OPDPatientLedgerRough pLedger = new OPDPatientLedgerRough();
            List<OPDPatientLedgerRough> transactionList = new List<OPDPatientLedgerRough>();

            double balance = 0;

            balance = _currentBalance + amount;
            pLedger = new OPDPatientLedgerRough();
            pLedger.PatientId = patientId;
            pLedger.TranDate = _trandate;
            pLedger.TransactionTime = _trandate.ToString("hh:mm tt");
            pLedger.Particulars = "Patient Cancel";
            pLedger.Debit = 0;
            pLedger.Credit = amount;
            pLedger.Balance = balance;
            pLedger.TransactionType = TransactionTypeEnum.ServiceCancelled.ToString();
            pLedger.OperateBy = MainForm.LoggedinUser.Name ;
            transactionList.Add(pLedger);

            if (_discountGiven > 0)
            {
                balance = balance - _discountGiven;
                pLedger = new OPDPatientLedgerRough();
                pLedger.PatientId = patientId;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Discount Adjusted.";
                pLedger.Debit = _discountGiven;
                pLedger.Credit = 0;
                pLedger.Balance = balance;
                pLedger.TransactionType = TransactionTypeEnum.DiscountRefunded.ToString();
                pLedger.OperateBy = MainForm.LoggedinUser.Name; 
                transactionList.Add(pLedger);

            }

            //if (_returnableAmount > 0)
            //{
            //    balance = balance - _returnableAmount;
            //    pLedger = new OPDPatientLedgerRough();
            //    pLedger.PatientId = patientId;
            //    pLedger.TranDate = Utils.GetServerDateAndTime();
            //    pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
            //    pLedger.Particulars = "Refund Tk.";
            //    pLedger.Debit = _returnableAmount;
            //    pLedger.Credit = 0;
            //    pLedger.Balance = balance;
            //    pLedger.TransactionType = TransactionTypeEnum.Refund.ToString();
            //    pLedger.OperateBy = MainForm.LoggedinUser.Name;
            //    transactionList.Add(pLedger);

            //}

            if (transactionList.Count > 0)
            {
                OPDPatientLedgerService plService = new OPDPatientLedgerService();
                plService.SavePatientLedgerRough(transactionList);
                MessageBox.Show("Patient Cancel Successful.", "HERP");
            }

        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            //if (_PatientCancelled)
            //{
            //    MessageBox.Show("Refund successfull.");
            //    txtReturnableTk.Text = "0";
            //    _PatientCancelled = false;
            //    return;
            //}

            if (txtBillNo.Tag == null)
            {
                MessageBox.Show("Patient not selected"); return;
            }

            OPDPatientRecord _Patient = (OPDPatientRecord)txtBillNo.Tag;


            btnRefund.Enabled = false;

            double _refundtk = 0;

            double.TryParse(txtReturnableTk.Text, out _refundtk);

            OPDPatientLedgerRough pLedger = new OPDPatientLedgerRough();
            List<OPDPatientLedgerRough> transactionList = new List<OPDPatientLedgerRough>();

            if (_refundtk > 0)
            {

                pLedger = new OPDPatientLedgerRough();
                pLedger.PatientId = _Patient.PatientId;
                pLedger.TranDate = Utils.GetServerDateAndTime();
                pLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                pLedger.Particulars = "Refund Tk.";
                pLedger.Debit = _refundtk;
                pLedger.Credit = 0;
                pLedger.Balance = 0;
                pLedger.TransactionType = TransactionTypeEnum.Refund.ToString();
                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                transactionList.Add(pLedger);
            }
            else
            {
                MessageBox.Show("No. returnable amount found.", "HERP");
            }

            if (transactionList.Count > 0)
            {
                OPDPatientLedgerService plService = new OPDPatientLedgerService();
                plService.SavePatientLedgerRough(transactionList);
                MessageBox.Show("Refund successful.", "HERP");
                LoadPatientHistory();
            }

            txtReturnableTk.Text = "0";
            btnRefund.Enabled = true;
        }

        private void btnCancelSelectedTest_Click(object sender, EventArgs e)
        {

                DialogResult result = MessageBox.Show("Are you sure to cancel this service?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes && dgServices.SelectedRows.Count > 0 && txtBillNo.Tag != null)
                {

                    SelectedServicesForOPDPatient _SeletedItem = this.dgServices.SelectedRows[0].Tag as SelectedServicesForOPDPatient;
                    int _itemId = _SeletedItem.ServiceOrConsultandId;
                    string _Name = _SeletedItem.DisplayName;
                    OPDPatientRecord _Patient = (OPDPatientRecord)txtBillNo.Tag;
                    double _Cost = _SeletedItem.TAmount;


                    if (new OPDPatientService().CancelService(_Patient.PatientId, _itemId, _SeletedItem.GroupId, MainForm.LoggedinUser.UserId))
                    {
                        MessageBox.Show("Service: " + _Name + " cancelled successful.", "HERP");

                        if (_SeletedItem.GroupId != 3)
                        {
                            DataSet ds = new OPDPatientService().GetOPDServiceListExceptConsultancy(_Patient.PatientId);

                            DataTable dt = ds.Tables[0];



                            _SelectedServices = (from DataRow dr in dt.Rows
                                                 select new SelectedServicesForOPDPatient()
                                                 {
                                                     ServiceOrConsultandId = Convert.ToInt32(dr["ServiceOrConsultantId"]),
                                                     DisplayName = dr["ServiceName"].ToString(),
                                                     Qty = Convert.ToInt32(dr["Qty"]),
                                                     Rate = Convert.ToInt32(dr["Rate"]),
                                                     TAmount = Convert.ToInt32(dr["TAmount"]),
                                                  
                                                     GroupId = Convert.ToInt32(dr["GroupId"]),
                                                     Status = dr["Status"].ToString(),
                                                     UserName = dr["LoginName"].ToString(),

                                                 }).ToList();


                            FillServiceGrid();

                        }
                        else
                        {
                            DataSet ds = new OPDPatientService().GetConsultancyServiceList(_Patient.PatientId);

                            DataTable dt = ds.Tables[0];



                            _SelectedServices = (from DataRow dr in dt.Rows
                                                 select new SelectedServicesForOPDPatient()
                                                 {
                                                     ServiceOrConsultandId = Convert.ToInt32(dr["ServiceOrConsultantId"]),
                                                     DisplayName = dr["ServiceName"].ToString(),
                                                     Qty = Convert.ToInt32(dr["Qty"]),
                                                     Rate = Convert.ToInt32(dr["Rate"]),
                                                     TAmount = Convert.ToInt32(dr["TAmount"]),
                                                    
                                                     GroupId = Convert.ToInt32(dr["GroupId"]),
                                                     VisitTypeId = Convert.ToInt32(dr["VisitTypeId"]),
                                                     Status = dr["Status"].ToString(),
                                                     UserName = dr["LoginName"].ToString(),

                                                 }).ToList();


                            FillServiceGrid();
                        }


                        AdjustPatientLedger(_Patient.PatientId, _Name, _Cost);

                        SetTotalAmount(_Patient.PatientId);

                    }
                }
                else
                {
                    MessageBox.Show("Plz. select a service and try again.");
                }
            
        }

        private void AdjustPatientLedger(long patientId, string name, double cost)
        {
            double _discountGiven = new OPDPatientLedgerService().GetDiscountedAmount(patientId);

            double _invoiceTotal = 0;
            double.TryParse(txtTotalBill.Tag.ToString(), out _invoiceTotal);

            
           double _discountforCancelledService = (_discountGiven * cost) / _invoiceTotal;
            

            double _currentBalance = new OPDPatientLedgerService().GetCurrentBalance(patientId);

            double _returnableAmount = cost - _discountforCancelledService;

            OPDPatientLedgerRough pLedger = new OPDPatientLedgerRough();
            List<OPDPatientLedgerRough> transactionList = new List<OPDPatientLedgerRough>();

            double balance = 0;

            DateTime _trandate = Utils.GetServerDateAndTime();

            if (_discountGiven == 0)
            {
                balance = _currentBalance + cost;
                pLedger = new OPDPatientLedgerRough();
                pLedger.PatientId = patientId;
                pLedger.TranDate = _trandate;
                pLedger.TransactionTime = _trandate.ToString("hh:mm tt");
                pLedger.Particulars = "Service: " + name + "cancelled.";
                pLedger.Debit = 0;
                pLedger.Credit = cost;
                pLedger.Balance = Math.Round(balance, 2);
                pLedger.TransactionType = TransactionTypeEnum.ServiceCancelled.ToString();
                pLedger.OperateBy = MainForm.LoggedinUser.Name;
              
                pLedger.Remarks = "Service Cancelled";
                transactionList.Add(pLedger);
            }

            if (_discountGiven > 0)
            {

                balance = _currentBalance + cost;
                pLedger = new OPDPatientLedgerRough();
                pLedger.PatientId = patientId;
                pLedger.TranDate = _trandate;
                pLedger.TransactionTime = _trandate.ToString("hh:mm tt");
                pLedger.Particulars = "Service: " + name + "cancelled.";
                pLedger.Debit = 0;
                pLedger.Credit = cost;
                pLedger.Balance = Math.Round(balance, 2);
                pLedger.TransactionType = TransactionTypeEnum.ServiceCancelled.ToString();
                pLedger.OperateBy = MainForm.LoggedinUser.Name;

                pLedger.Remarks = "Service Cancelled";
                transactionList.Add(pLedger);


                balance = balance - Math.Round(_discountforCancelledService, 2);
                pLedger = new OPDPatientLedgerRough();
                pLedger.PatientId = patientId;
                pLedger.TranDate = _trandate;
                pLedger.TransactionTime = _trandate.ToString("hh:mm tt");
                pLedger.Particulars = "Discount Adjusted For Cancelled service: " + name;
                pLedger.Debit = Math.Round(_discountforCancelledService, 2);
                pLedger.Credit = 0;
                pLedger.Balance = Math.Round(balance, 2);
                pLedger.TransactionType = TransactionTypeEnum.ServiceCancelledDiscountAdjustment.ToString();
                pLedger.OperateBy = MainForm.LoggedinUser.Name;
               
                transactionList.Add(pLedger);


            }


            if (transactionList.Count > 0)
            {
                OPDPatientLedgerService plService = new OPDPatientLedgerService();
                plService.SavePatientLedgerRough(transactionList);
            }

        }

        private void dgServices_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectedServicesForOPDPatient _SeletedItem = this.dgServices.SelectedRows[0].Tag as SelectedServicesForOPDPatient;
            if (_SeletedItem != null)
            {
               
            }
        }
    }
}
