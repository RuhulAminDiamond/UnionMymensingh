using HDMS.Model;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;
using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Service.Hospital;
using HDMS.Service.OPD;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
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
    public partial class crtlOPDProcedureBillDistribution : UserControl
    {
        bool unlocked = true;
        bool isEditMode = false;

        public crtlOPDProcedureBillDistribution()
        {
            InitializeComponent();
        }

        private void txtServiceItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlServicetem.Visible = true;
                ctrlServicetem.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlServicetem.Visible = false;
            ctrlDoctor.Visible = false;
        }

        private void txtDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlDoctor.Visible = true;
                ctrlDoctor.LoadData();
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtQty.Text) && txtServiceItem.Tag != null && txtDoctor.Tag != null)
                {
                    double _Qty = 0;
                    double _Rate = 0;
                    double.TryParse(txtQty.Text, out _Qty);
                    double.TryParse(txtRate.Text, out _Rate);

                    ServiceHead _Servicehead = (ServiceHead)txtServiceItem.Tag;
                    Doctor _doctor = (Doctor)txtDoctor.Tag;


                    new OPDPatientService().PopulateSelectedServiceData(_SelectedOTServices, _Servicehead, _doctor, _Rate, _Qty, MainForm.LoggedinUser.Name);

                    FillServiceGrid();

                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtDoctor.Text = "";
                    txtDoctor.Tag = null;

                    txtServiceItem.Text = "";
                    txtServiceItem.Tag = null;

                    txtServiceItem.Focus();

                }
                else
                {
                    MessageBox.Show("Service/Doctor not selected.");
                }

            }
        }

        private void FillServiceGrid()
        {
            dgService.SuspendLayout();
            dgService.Rows.Clear();
            foreach (VMSelectedOTServices item in _SelectedOTServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgService, item.ServiceHeadName, item.DoctorName, item.Rate, item.Qty, item.Amount, item.EnteredBy, false);
                dgService.Rows.Add(row);
            }

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            txtTotalBill.Text = dgService.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[4].Value)).ToString();
        }

        private IList<VMSelectedOTServices> _SelectedOTServices;
        private IList<VMSelectedService> _SelectedServices;
        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private void crtlOPDProcedureBillDistribution_Load(object sender, EventArgs e)
        {
            _SelectedOTServices = new List<VMSelectedOTServices>();
            _SelectedServices = new List<VMSelectedService>();
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            ctrlDoctor.Location = new Point(txtDoctor.Location.X, txtDoctor.Location.Y + txtDoctor.Height);
            ctrlDoctor.ItemSelected += ctrlDoctor_ItemSelected;

            ctrlServicetem.Location = new Point(txtServiceItem.Location.X, txtServiceItem.Location.Y + txtServiceItem.Height);
            ctrlServicetem.ItemSelected += ctrlServicetem_ItemSelected;

            ctrlService.Location = new Point(txtService.Location.X, txtService.Location.Y + txtService.Height);
            ctrlService.ItemSelected += ctrlService_ItemSelected;

            ctlProductSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;


            LoadProcudureBillDistributedPatient();

            LoadOutlets(2);



        }

        private void LoadOutlets(int outletId)
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";

            // User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            cmbOutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == outletId);
            cmbOutlet.Enabled = false;


            //if (_user.AssignedOutLet == 0)
            //{
            //    cmbOutlet.Enabled = true;
            //}
            //else
            //{
            //    cmbOutlet.Enabled = false;
            //}

            //if(_user.AssignedOutLet == 2 || _user.AssignedOutLet == 3)
            //{
            //    IsInddorSale = false;
            //}
        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControlForPharmacy<VWPhProductListForSale> sender, VWPhProductListForSale item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.BrandName;
            txtUnitPrice.Text = item.SalePrice.ToString();
            txtQuantity.Focus();

            UpdateStockOnUILabel(item);

            sender.Visible = false;
        }

        private void UpdateStockOnUILabel(VWPhProductListForSale item)
        {
            PhStockInfo _st = new PhProductService().GetPhStockByStckId(item.StckId);
            lblStockAvailable.Text = _st.CurrentStock.ToString();

            List<VWPhProductListForSale> pList = cmbOutlet.Tag as List<VWPhProductListForSale>;

            pList.Where(w => w.StckId == item.StckId).ToList().ForEach(s => s.StockAvailable = _st.CurrentStock);

            cmbOutlet.Tag = pList;
        }

        private void ctrlService_ItemSelected(SearchResultListControl<ServiceHead> sender, ServiceHead item)
        {
            txtService.Text = item.ServiceHeadName.ToString();
            txtService.Tag = item;
            txtServiceRate.Text = item.Rate.ToString();
            txtServiceRate.Focus();
            sender.Visible = false;
            ctrlService.Visible = false;
        }

        private void ctrlServicetem_ItemSelected(SearchResultListControl<ServiceHead> sender, ServiceHead item)
        {
            txtServiceItem.Text = item.ServiceHeadName.ToString();
            txtServiceItem.Tag = item;
            txtDoctor.Focus();
            sender.Visible = false;
            ctrlServicetem.Visible = false;
        }

        private void ctrlDoctor_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtDoctor.Text = item.Name;
            txtDoctor.Tag = item;

            if (txtServiceItem.Tag != null)
            {
                Model.Hospital.ServiceHead _shead = (Model.Hospital.ServiceHead)txtServiceItem.Tag;
                txtRate.Text = _shead.Rate.ToString();
                txtRate.Enabled = true;
                txtRate.Focus();
            }
            else
            {
                txtRate.Enabled = true;
                txtRate.Focus();
            }
            sender.Visible = false;
            ctrlDoctor.Visible = false;
        }

        private async void LoadProcudureBillDistributedPatient()
        {
            // List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetOPdBillingDistributedPatient();

            List<VMOPDProcudureBill> _lisPatientInfo = await new OPDFinancialService().GetOPdPatientProcedurBill();

            FillListGrid(_lisPatientInfo);
        }

        private void FillListGrid(List<VMOPDProcudureBill> _lisPatientInfo)
        {
            dgProcBills.SuspendLayout();
            dgProcBills.Rows.Clear();
            foreach (VMOPDProcudureBill item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgProcBills, item.BillNo, item.FullName, item.DischargeDate.ToString("dd/MM/yyyy"));
                dgProcBills.Rows.Add(row);
            }
        }

        private void dgProcBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgProcBills.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgProcBills.SelectedRows[0];
                VMOPDProcudureBill _pInfo = ((VMOPDProcudureBill)row.Tag);
                btnBillSave.Tag = _pInfo;

                lblBillNo.Text = _pInfo.BillNo.ToString();
                lblName.Text = _pInfo.FullName;
                lblTotalBill.Text = _pInfo.TotalBill.ToString();
                lblPaid.Text = _pInfo.TotalPaid.ToString();
                lblDue.Text = _pInfo.TotalDue.ToString();
                lbldis.Text = _pInfo.TotalDiscount.ToString();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBillSave_Click(object sender, EventArgs e)
        {
            if (btnBillSave.Tag == null)
            {
                MessageBox.Show("Patient not selected."); return;
            }

            if (dgService.Rows.Count == 0)
            {
                MessageBox.Show("No item selected"); return;
            }

            VMOPDProcudureBill _pInfo = (VMOPDProcudureBill)btnBillSave.Tag;

          
            if (_pInfo != null)
            {
                List<OPDProcedureServiceBillDetail> _sbillList = new List<OPDProcedureServiceBillDetail>();

                long _billNo = 0;
                long.TryParse(lblBillNo.Text, out _billNo);

                HospitalPatientInfo _OPDPInfo = new HospitalService().GetOPProcedurePatientByOPDBillNo(_billNo);

                OPDProcedureServiceBill _OPDSbill = new OPDProcedureServiceBill();
                _OPDSbill.SDate= Utils.GetServerDateAndTime();
                _OPDSbill.ServiceAmount = Convert.ToDouble(txtTotalAmount.Text);

                long _OpdServiceBillId = new HpFinancialService().SaveOPDProcedureServiceBill(_OPDSbill);

                foreach (DataGridViewRow row in dgNormalService.Rows)
                {
                    VMSelectedService _SelectedServices = row.Tag as VMSelectedService;

                    OPDProcedureServiceBillDetail OPDsbd = new OPDProcedureServiceBillDetail();
                    OPDsbd.SBId = _OpdServiceBillId;
                    OPDsbd.AdmissionId = _OPDPInfo.AdmissionId;
                    OPDsbd.ServiceHeadId = _SelectedServices.ServiceHeadId;
                    OPDsbd.Rate = _SelectedServices.Rate;
                    OPDsbd.Qty = _SelectedServices.Qty;
                    OPDsbd.ServiceCharge = _SelectedServices.ServiceCharge;
                    OPDsbd.ServiceDate = _SelectedServices.ServiceDate;
                    OPDsbd.ServiceTime = _SelectedServices.ServiceDate.ToShortTimeString();
                    OPDsbd.CreatedBy = MainForm.LoggedinUser.Name;
                    OPDsbd.ModifiedBy = MainForm.LoggedinUser.Name;
                    OPDsbd.ModifiedDate = Utils.GetServerDateAndTime();
                    _sbillList.Add(OPDsbd);
                }



               

                new HospitalService().SaveOPDServiceBillDetails(_sbillList);


                OpdProcedureBillDistribution _Distributebill = new OpdProcedureBillDistribution();
                _Distributebill.BillNo = _pInfo.BillNo;
                _Distributebill.ProcedureBillId = _pInfo.ProcedureBillId;
                _Distributebill.DistributeTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                _Distributebill.DistributeDate = Utils.GetServerDateAndTime();
                _Distributebill.PreparedBy = MainForm.LoggedinUser.Name;

                int _distributedId = new HpFinancialService().SaveOPDDistributedBill(_Distributebill);

                List<HpConsultantLedger> _hpcLdgerList = new List<HpConsultantLedger>();

                if (_distributedId > 0)
                {

                    List<OpdProcedureBillDistributionDetail> _ObilldetaildistributionList = new List<OpdProcedureBillDistributionDetail>();
                    foreach (DataGridViewRow row in dgService.Rows)
                    {
                        VMSelectedOTServices selectedItems = row.Tag as VMSelectedOTServices;

                         OpdProcedureBillDistributionDetail _Opddistributiondetail = new OpdProcedureBillDistributionDetail();
                        _Opddistributiondetail.DisId = _distributedId;
                        _Opddistributiondetail.ServiceHeadId = selectedItems.ServiceHeadId;
                        _Opddistributiondetail.DoctorId = selectedItems.DoctorId;
                        _Opddistributiondetail.qnt = selectedItems.Qty;
                        _Opddistributiondetail.Amount = selectedItems.Amount;
                        _ObilldetaildistributionList.Add(_Opddistributiondetail);

                        double _otcurrentBalance = new HpFinancialService().GetConsultantCurrentBalance(selectedItems.DoctorId);

                        double _otbalance = _otcurrentBalance + (selectedItems.Rate * selectedItems.Qty);

                         HpConsultantLedger _hpcLedger = new HpConsultantLedger();
                        _hpcLedger.DoctorId = selectedItems.DoctorId;
                        _hpcLedger.TranDate = Utils.GetServerDateAndTime();
                        _hpcLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        _hpcLedger.Particulars = "ProcedureBill: " + "," + selectedItems.ServiceHeadName + "( Bill No: " + lblBillNo.Text + ", " + lblName.Text + " )";
                        _hpcLedger.Debit = 0;
                        _hpcLedger.Credit = selectedItems.Rate * selectedItems.Qty;
                        _hpcLedger.Balance = _otbalance;   // positive balance means doctor will claim this amount against his/her service
                        _hpcLedger.TransactionType = TransactionTypeEnum.OPDPorcedurebill.ToString();
                        _hpcLedger.OperateBy = MainForm.LoggedinUser.Name;

                        _hpcLdgerList.Add(_hpcLedger);
                    }

                    if (_ObilldetaildistributionList.Count > 0)
                    {
                        if (new HpFinancialService().SaveOpdProceduredistributionBillDetail(_ObilldetaildistributionList))
                        {
                            new HpFinancialService().SaveHpConsultantTransaction(_hpcLdgerList);
                            MessageBox.Show("Distributed Bill Successfully");

                            OpdProcedureBill _PInfo = new HospitalService().GetOPDProcedurePatientInfoById(_pInfo.ProcedureBillId);
                            _PInfo.isBillDistributed = true;

                            new HospitalService().UpdateOPDProcedurePatientInfo(_PInfo);

                            LoadProcudureBillDistributedPatient();

                            dgService.SuspendLayout();
                            dgService.Rows.Clear();

                            dgNormalService.SuspendLayout();
                            dgNormalService.Rows.Clear();

                        }

                    }
                }

            }
        }

        private void dgService_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            VMSelectedOTServices _SelectedItem = (VMSelectedOTServices)e.Row.Tag;

            _SelectedOTServices.Remove(e.Row.Tag as VMSelectedOTServices);
            CalculateTotalAmount();
        }

        private void txtService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlService.Visible = true;
                ctrlService.LoadData();
            }
        }

        private void txtServiceRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtServiceQty.Focus();
            }
        }

        private void txtServiceQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtServiceQty.Text) && txtService.Tag != null)
                {
                    int _Qty = 0;
                    double _Rate = 0;
                    int.TryParse(txtServiceQty.Text, out _Qty);
                    double.TryParse(txtServiceRate.Text, out _Rate);

                    ServiceHead _Servicehead = (ServiceHead)txtService.Tag;

                    new HospitalService().PopulateSelectedServices(_SelectedServices, _Servicehead, dtpServiceDate.Value, _Rate, _Qty, MainForm.LoggedinUser.Name);
                    FillServiceHeadGrid();
                    txtServiceQty.Text = "";
                    txtService.Text = "";
                    txtService.Text = "";
                    txtService.Tag = null;

                    txtService.Focus();

                }
                else
                {
                    MessageBox.Show("Service not selected.");
                }

            }
        }

        private void FillServiceHeadGrid()
        {
            dgNormalService.SuspendLayout();
            dgNormalService.Rows.Clear();
            foreach (VMSelectedService item in _SelectedServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgNormalService, item.ServiceHeadName, item.Rate, item.Qty, item.Amount, item.ServiceDate, item.EnteredBy, false);
                dgNormalService.Rows.Add(row);
            }

            CalculateServiceTotalAmount();
        }

        private void CalculateServiceTotalAmount()
        {
            txtTotalAmount.Text = dgNormalService.Rows.Cast<DataGridViewRow>()
              .Sum(t => Convert.ToInt32(t.Cells[3].Value)).ToString();   
        }

        bool IsCachedStockUpdated = false;
        private async void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {

                if (!IsCachedStockUpdated)
                {
                    await LoadMedicineStocks();
                    IsCachedStockUpdated = true;
                }

                if (cmbOutlet.Tag == null)
                {
                    MessageBox.Show("Plz. select outlet and try again."); return;
                }

                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 3)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadDataByTypeFromSuppliedList(_txt + ">" + _outLet.OutLetId.ToString(), cmbOutlet.Tag as List<VWPhProductListForSale>); // Out let Id appended for outlet specific product loading
                }
            }
        }

        private async Task<bool> LoadMedicineStocks()
        {
            string brandName = "";
            MedicineOutlet _outLet = cmbOutlet.SelectedItem as MedicineOutlet;
            if (_outLet.OutLetId > 0)
            {
                List<VWPhProductListForSale> _ItemList = new PhProductService().GetPhItemForSale(brandName + ">" + _outLet.OutLetId.ToString()).ToList();
                cmbOutlet.Tag = _ItemList;
            }

            return await Task.FromResult(true);
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlProductSearchControl.Visible = true;
                ctlProductSearchControl.LoadDataByType(txtProductCode.Text + ">" + _outLet.OutLetId.ToString());
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(txtProductCode.Text))
                {
                    txtQty.Focus();
                }
                else
                {
                    HideAllDefaultHidden();
                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.LoadDataByType(txtProductCode.Text + ">" + _outLet.OutLetId.ToString());
                }
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtProductCode.Tag == null) return;

                VWPhProductListForSale _PL = (VWPhProductListForSale)txtProductCode.Tag;

                double _qty = 0, _rate = 0, _total = 0;
                double.TryParse(txtQuantity.Text, out _qty);
                double.TryParse(txtUnitPrice.Text, out _rate);

                if (isEditMode)
                {
                    List<PhSelectedProductsToSaleOrReceiveOrOrder> _removeList = _SelectedItems.Where(x => x.Id == _PL.ProductId).ToList();
                    foreach (var item in _removeList)
                    {
                        if (item.Id == _PL.ProductId)
                        {
                            _SelectedItems.Remove(item);
                        }
                    }

                    isEditMode = false;
                }


                if (_qty == 0)
                {
                    MessageBox.Show("Quantity Blank.");
                    txtUnitPrice.Text = "";
                    txtQuantity.Text = "";
                    txtDrescription.Text = "";
                    unlocked = false;
                    txtProductCode.Text = "";
                    unlocked = true;
                    txtProductCode.Focus();
                    return;
                }

                if (_PL.StockAvailable < _qty)
                {


                    new PhProductService().PopulateSelectedItemDataForSaleFromMultipleLot(_SelectedItems, txtProductCode.Tag as VWPhProductListForSale, _rate, _qty);

                    FillItemGrid();

                    txtUnitPrice.Text = "";
                    txtQuantity.Text = "";
                    txtDrescription.Text = "";
                    txtProductCode.Text = "";
                    txtProductCode.Focus();

                    txtProductCode.Tag = null;

                    unlocked = true;

                    return;
                }



                new PhProductService().PopulateSelectedItemDataForSale(_SelectedItems, txtProductCode.Tag as VWPhProductListForSale, _rate, _qty);
                FillItemGrid();

                unlocked = false;

                txtUnitPrice.Text = "";
                txtQuantity.Text = "";
                txtDrescription.Text = "";
                txtProductCode.Text = "";
                txtProductCode.Focus();

                txtProductCode.Tag = null;

                unlocked = true;
            }
        }

        private void FillItemGrid()
        {

            dgSales.SuspendLayout();
            dgSales.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                if (item.Qty > 0)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.Tag = item;
                    row.CreateCells(dgSales, item.Id, item.Name, item.ExpireDate.ToString("dd/MM/yyyy"), item.SRate, item.Qty, item.Total, item.BatchNo, item.PTotal);
                    dgSales.Rows.Add(row);
                }
            }

            CalculateAmount();
        }

        private void CalculateAmount()
        {
           // txtTotalItem.Text = _SelectedItems.Count().ToString();

            double _total = 0, _purchaseTotal = 0;

            _total = Math.Round(dgSales.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[5].Value)), 2);

            _purchaseTotal = Math.Round(dgSales.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[7].Value)), 2);

            double x = _total - Math.Truncate(_total);

            if (x < 0.5)
            {
                _total = _total - x;

            }
            else
            {
                _total = _total - x + 1;
            }

            txtSubTotal.Text = _total.ToString();

            txtSubTotal.Tag = Math.Round(_purchaseTotal, 2);  // Invoice cost price anchored here.
        }
    }
}

