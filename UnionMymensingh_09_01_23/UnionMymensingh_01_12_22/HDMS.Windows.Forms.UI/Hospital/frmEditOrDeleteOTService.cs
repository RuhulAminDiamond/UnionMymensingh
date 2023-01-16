using HDMS.Common.Utils;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmEditOrDeleteOTService : Form
    {
        public frmEditOrDeleteOTService()
        {
            InitializeComponent();
        }

        private void frmEditOrDeleteConsultancyService_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private async void LoadPatients()
        {
            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfo();

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

              

                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;
                dtpDischarge.Tag = _pInfo;

                List<VMConsultancyEdit> _cList = new HpFinancialService().GetOTServiceList(_pInfo.AdmissionId);

                FillServiceListGrid(_cList);

            }
        }

        private void FillServiceListGrid(List<VMConsultancyEdit> _cList)
        {
            dgServices.SuspendLayout();
            dgServices.Rows.Clear();
            foreach (VMConsultancyEdit item in _cList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgServices, item.ServiceDate.ToString("dd/MM/yyyy"), item.DoctorName, item.ServiceName, item.Rate, item.Qty,item.Total);
                dgServices.Rows.Add(row);
            }
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
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoBySearchParameter(_prefix, type).ToList();

            if (_lisPatientInfo.Count() == 0) return;

            // lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
        }

        private void dgServices_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgServices.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgServices.SelectedRows[0];
                VMConsultancyEdit _consultancy = ((VMConsultancyEdit)row.Tag);

                btnDelete.Tag = _consultancy;

                txtQty.Tag = _consultancy.Qty;
                txtQty.Text= _consultancy.Qty.ToString();
            

                txtRate.Tag = _consultancy.Rate;
                txtRate.Text = _consultancy.Rate.ToString();
               

                txtTotal.Tag = _consultancy.Total;
                txtTotal.Text = _consultancy.Total.ToString();
             

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Tag != null)
            {
                VMIPDInfo _IpdInfo = (VMIPDInfo)dtpDischarge.Tag;

                VMConsultancyEdit _consultancy = ((VMConsultancyEdit)btnDelete.Tag);

                if(_consultancy != null)
                {
                    if (_consultancy.Qty > 1)
                    {
                         DialogResult result = MessageBox.Show("It will delete " + _consultancy.Qty.ToString() + " consultancy at a time. Will you proceed?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes) {

                        }
                        else
                        {
                            return;
                        }
                    }

                    OTExecutionDetail _billDetail = new HpFinancialService().GetOTConsultancyServiceById(_consultancy.DSBDId);

                    if(_billDetail != null)
                    {
                        DoctorServiceDeleteLog _dLog = new DoctorServiceDeleteLog();
                        _dLog.AdmissionId = _IpdInfo.AdmissionId;
                        _dLog.ServiceHeadId = _billDetail.ServiceHeadId;
                        _dLog.DoctorId = _billDetail.ServiceHeadId;
                        _dLog.Rate = _billDetail.Rate;
                        _dLog.Qty = _billDetail.Qty;
                        _dLog.Vat = _billDetail.Vat;
                        _dLog.ServiceCharge = _billDetail.ServiceCharge;
                        _dLog.ServiceDate = _billDetail.ServiceDate;
                        _dLog.ServiceTime = _billDetail.ServiceTime;
                        _dLog.CreatedBy = MainForm.LoggedinUser.Name;
                        _dLog.ModifiedDate = Utils.GetServerDateAndTime();
                        _dLog.DeletedBy = MainForm.LoggedinUser.Name;

                        if(new HpFinancialService().SaveConsultancyServiceDeleteLog(_dLog))
                        {
                            new HpFinancialService().DeleteOTConsultancyService(_billDetail);
                              MessageBox.Show("OT Consultancy service deleted successfully.");

                            double _currentBalance = new HpFinancialService().GetConsultantCurrentBalance(_billDetail.DoctorId);

                            double _balance = _currentBalance - (_billDetail.Rate * _billDetail.Qty);

                            List<HpConsultantLedger> _hpcLdgerList = new List<HpConsultantLedger>();


                            HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                            _hpcLedger.DoctorId = _billDetail.DoctorId;
                            _hpcLedger.TranDate = Utils.GetServerDateAndTime();
                            _hpcLedger.TransactionTime= Utils.GetServerDateAndTime().ToString("hh:mm tt");
                            _hpcLedger.Particulars = _consultancy.ServiceName + " deleted. ( BillNo: " + _IpdInfo.BillNo.ToString() + ", Cabin: " + lblCabin.Text+" )";
                            _hpcLedger.Debit = _billDetail.Rate * _billDetail.Qty;
                            _hpcLedger.Credit = 0;
                            _hpcLedger.Balance = _balance; // Negative balance means patient is payable this amount
                            _hpcLedger.TransactionType = TransactionTypeEnum.ConsultantFee.ToString();
                            _hpcLedger.OperateBy = MainForm.LoggedinUser.Name;

                            _hpcLdgerList.Add(_hpcLedger);

                            new HpFinancialService().SaveHpConsultantTransaction(_hpcLdgerList);

                            btnDelete.Tag = null;

                            List<VMConsultancyEdit> _cList = new HpFinancialService().GetOTServiceList(_IpdInfo.AdmissionId);

                            FillServiceListGrid(_cList);
                        }

                    }

                }

            }
            else
            {
                MessageBox.Show("No record found to delete");
            }
        }

        private void btnUpdateAmount_Click(object sender, EventArgs e)
        {
            if (btnDelete.Tag != null)
            {

               if(txtQty.Tag==null || txtRate.Tag == null)
                {
                    return;
                }
                // MessageBox.Show("Under construction"); return; // TODO: after complete delete this line

                string _msgtype = string.Empty;

                VMConsultancyEdit _consultancy = ((VMConsultancyEdit)btnDelete.Tag);

                VMIPDInfo _IpdInfo = (VMIPDInfo)dtpDischarge.Tag;

           

                if (_consultancy != null)
                {
                    OTExecutionDetail _billDetail = new HpFinancialService().GetOTConsultancyServiceById(_consultancy.DSBDId);

                    double _rate = 0;
                    double.TryParse(txtRate.Text, out _rate);

                    int _qty = 0;
                    int.TryParse(txtQty.Text, out _qty);

                    double _prevQty = 0;
                    double.TryParse(txtQty.Tag.ToString(), out _prevQty);

                    double _prevRate = 0;
                    double.TryParse(txtRate.Tag.ToString(), out _prevRate);

                    double _prevTotal = 0;
                    double.TryParse(txtTotal.Tag.ToString(), out _prevTotal);

                    if(_qty>0 && _rate > 0 && _qty > 0)
                    {

                        double _currentBalance = new HpFinancialService().GetConsultantCurrentBalance(_billDetail.DoctorId);

                        double _balance = _currentBalance - (_prevTotal - (_qty * _rate));

                        List<HpConsultantLedger> _hpcLdgerList = new List<HpConsultantLedger>();
                        
                            _billDetail.Qty = _qty;
                            _billDetail.Rate = _rate;
                            _billDetail.ServiceCharge = (_qty * _rate * Constants.HpServiceChargeInPercent)/100;
                         
                            if (new HpFinancialService().UpdateOTServiceBill(_billDetail))
                            {
                                HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                                _hpcLedger.DoctorId = _billDetail.DoctorId;
                                _hpcLedger.TranDate = Utils.GetServerDateAndTime();
                                _hpcLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                                _hpcLedger.Particulars = _consultancy.ServiceName + " decreased from "+ _prevRate.ToString() + " to " + _rate.ToString()+" ( BillNo: " + _IpdInfo.BillNo.ToString() + ", Cabin: " + lblCabin.Text + " )";
                                _hpcLedger.Debit = _prevTotal - (_qty * _rate);
                                _hpcLedger.Credit = 0;
                                _hpcLedger.Balance = _balance; // Negative balance means patient is payable this amount
                                _hpcLedger.TransactionType = TransactionTypeEnum.ConsultantFee.ToString();
                                _hpcLedger.OperateBy = MainForm.LoggedinUser.Name;

                                _hpcLdgerList.Add(_hpcLedger);

                                new HpFinancialService().SaveHpConsultantTransaction(_hpcLdgerList);

                                MessageBox.Show("Update successful.");

                              btnDelete.Tag = null;

                            List<VMConsultancyEdit> _cList = new HpFinancialService().GetOTServiceList(_IpdInfo.AdmissionId);

                            FillServiceListGrid(_cList);
                        }
                        
                    }else
                    {
                        MessageBox.Show("Some constraints Fail. Plz. check and try again."); 
                    }
                }
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btnDelete.Tag != null)
                {
                    int _qty = 0;
                    int.TryParse(txtQty.Text, out _qty);

                    VMConsultancyEdit _consultancy = ((VMConsultancyEdit)btnDelete.Tag);


                    txtRate.Text = (_consultancy.Rate * _qty).ToString();
                }
            }
    
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            int _qty = 0;
            int.TryParse(txtQty.Text, out _qty);

            double _rate = 0;
            double.TryParse(txtRate.Text, out _rate);

            double _prevRate = 0;
            double.TryParse(txtRate.Tag.ToString(), out _prevRate);

            if(_rate > _prevRate)
            {
                MessageBox.Show("Rate increase not allowed. If it is your requirements then plz. delete this service and make a re-entry.");
                txtRate.Text = txtRate.Tag.ToString();
            }

            txtTotal.Text = (_rate * _qty).ToString();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            int _qty = 0;
            int.TryParse(txtQty.Text, out _qty);

            double _rate = 0;
            double.TryParse(txtRate.Text, out _rate);

            int _prevQty = 0;
            int.TryParse(txtQty.Tag.ToString(),out _prevQty);

            if (_qty > _prevQty)
            {
                MessageBox.Show("Quantity increase not allowed. If it is your requirements then plz. delete this service and make a re-entry.");
                txtQty.Text = txtQty.Tag.ToString();
            }

            txtTotal.Text = (_rate * _qty).ToString();
        }
    }
}
