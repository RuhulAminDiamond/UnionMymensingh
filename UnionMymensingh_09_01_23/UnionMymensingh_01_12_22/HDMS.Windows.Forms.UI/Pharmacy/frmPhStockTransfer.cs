using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Model.Enums;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmPhStockTransfer : Form
    {

        bool isPanelMinimized = true;
        bool unlocked = true;

        string IPDRequisitionDeliveryStatus = RequisitionStatusEnum.Served.ToString();

        public frmPhStockTransfer()
        {
            InitializeComponent();
        }

        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;

        private void frmStockTransfer_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();

           

            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            ctlProductSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;

            ctlReplaceProductSearchControl.Location = new Point(txtReplaceby.Location.X, txtReplaceby.Location.Y);
            ctlReplaceProductSearchControl.ItemSelected += ctlReplaceProductSearchControl_ItemSelected;

            LoadfromOutLets();
            LoadToOutLets(0);


            LoadRequisitions();

            SetTogglePositionForPanel(true);
        }

        private void ctlReplaceProductSearchControl_ItemSelected(SearchResultListControlForPharmacy<VWPhProductListForSale> sender, VWPhProductListForSale item)
        {
            txtReplaceby.Text = item.BrandName;
            txtReplaceby.Tag = item;

            txtReplaceby.Focus();

            sender.Visible = false;
        }

        private void LoadRequisitions()
        {

            List<VMOutletMedicineRequisition> _reqList = new PhProductService().GetAllPhOutletRequisition(dtp1.Value);
            FillIndentGrid(_reqList);

            dgRequisitionList.Rows.Clear();
            dgRequisitionList.Tag = null;
        }

        private void FillIndentGrid(List<VMOutletMedicineRequisition> _hpReqList)
        {
            dgRequistions.SuspendLayout();
            dgRequistions.Rows.Clear();
            foreach (VMOutletMedicineRequisition item in _hpReqList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;


                row.CreateCells(dgRequistions, item.RequisitionId, item.FromOutlet, item.RequisitionBy, item.RequisitionStatus);
                dgRequistions.Rows.Add(row);


            }

        }

        private void SetTogglePositionForPanel(bool _IspanleMinimized)
        {
            if (_IspanleMinimized)
            {
                lblRequisitionPanel.Location = new Point(930, 50);

                button1.Location = new Point(20, 14);
                button1.Text = "<-----<< << <<";

                isPanelMinimized = false;

            }
            else
            {
                lblRequisitionPanel.Location = new Point(10, 50);

                button1.Location = new Point(20, 14);
                button1.Text = ">> >> >> ----->";

                isPanelMinimized = true;

            }
        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControlForPharmacy<VWPhProductListForSale> sender, VWPhProductListForSale item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.BrandName;
            txtUnitPrice.Text = item.SalePrice.ToString();
            txtQuantity.Focus();

            sender.Visible = false;
        }

        private void LoadToOutLets(int _outletId)
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbToOutlet.DataSource = _outletLists;
            cmbToOutlet.DisplayMember = "Name";
            cmbToOutlet.ValueMember = "OutletId";

            if (_outletId > 0)
            {
                cmbToOutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == _outletId);
                cmbToOutlet.Enabled = false;
            }
            else
            {
                cmbToOutlet.Enabled = true;
            }

            
        }

        private void LoadfromOutLets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbFromOutlet.DataSource = _outletLists;
            cmbFromOutlet.DisplayMember = "Name";
            cmbFromOutlet.ValueMember = "OutletId";

            cmbFromOutlet.SelectedItem = _outletLists.Find(x => x.OutLetId == 2);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmbFromOutlet.SelectedItem;

                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadDataByType(_txt + ">" + _outLet.OutLetId.ToString()); // Out let Id appended for outlet specific product loading
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearchControl.Visible = false;
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
                    MessageBox.Show("Stock Insufficient!");
                    //txtProductCode.Tag = null;
                    txtProductCode.Focus();

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
            double _qty = 0;

            dgSales.SuspendLayout();
            dgSales.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                if (item.Qty > 0)
                {
                    _qty = _qty + item.Qty;
                    DataGridViewRow row = new DataGridViewRow();
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.Tag = item;
                    row.CreateCells(dgSales, item.Id, item.Name, item.BatchNo, item.ExpireDate.ToString("dd/MM/yyyy"), item.PRate, item.Qty, item.Total, item.Discount);
                    dgSales.Rows.Add(row);
                }
            }


            txtTotalItems.Text = _qty.ToString();

         }

        private void ctlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            MedicineOutlet _fromOutlet = (MedicineOutlet)cmbFromOutlet.SelectedItem;
            MedicineOutlet _toOutlet = (MedicineOutlet)cmbToOutlet.SelectedItem;

            long _requisitionNo = 0;
            long.TryParse(txtRequisitionNo.Text, out _requisitionNo);

            if(_fromOutlet.OutLetId==0 || _toOutlet.OutLetId == 0)
            {
                MessageBox.Show("From outlet and To outlet required."); return;
            }

            if (dgSales.Rows.Count > 0)
            {
                DateTime _transferDate = Utils.GetServerDateAndTime();


                PhStockTransferRecord _sttr = new PhStockTransferRecord();
                _sttr.TDate = _transferDate;
                _sttr.TTime= _transferDate.ToString("hh:mm tt");
                _sttr.FromOutLet = _fromOutlet.OutLetId;
                _sttr.ToOutLet = _toOutlet.OutLetId;
                _sttr.RequisitionNo = _requisitionNo;
                _sttr.OperateBy = MainForm.LoggedinUser.Name;
                
                if(new PhProductService().SaveStockTransferRecord(_sttr))
                {
                    List<PhStockTransferRecordDetail> _rdDetailsList = new List<PhStockTransferRecordDetail>();
                    foreach (DataGridViewRow row in dgSales.Rows)
                    {
                        PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                        PhStockTransferRecordDetail pid = new PhStockTransferRecordDetail();
                        pid.StTId = _sttr.StTId;
                        pid.ProductId = selectedTests.Id;
                        pid.LotNo = selectedTests.LotNo;
                        pid.Qty = selectedTests.Qty;

                        _rdDetailsList.Add(pid);
                    }

                    if (new PhProductService().AddStockTransferDetails(_rdDetailsList))
                    {
                        MessageBox.Show("Stock Transfer Successful.");

                        new PhProductService().AddUpdateStockOnTransfer(_rdDetailsList, _fromOutlet.OutLetId,_toOutlet.OutLetId, _transferDate,MainForm.LoggedinUser.Name);

                        dgSales.Rows.Clear();
                        txtRequisitionNo.Text = "";

                        VMOutletMedicineRequisition _Mreq = (VMOutletMedicineRequisition)btnCancel.Tag;
                        if (_Mreq != null)
                        {
                            PhOutletMedicinieRequisition _OMReq = new PhProductService().GetOutletMedicineRequisitionByReqId(_Mreq.RequisitionId);
                            _OMReq.Status = RequisitionStatusEnum.Served.ToString();
                            new PhProductService().UpdateOutletRequisition(_OMReq);
                        }


                        PrintViewOfTransferList(_sttr.StTId);


                        LoadRequisitions();

                        dgSales.Rows.Clear();

                        _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                    }
                }
            }

        }

        private void PrintViewOfTransferList(long stTId)
        {
            DataSet ds = new PhProductService().GetPhStockTransferInvoice(stTId);

            PhTransferInvoivce _rpt = new PhTransferInvoivce();

            _rpt.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();

            _rpt.SetParameterValue("CompanyName", "Mount Adora Pharmacy");
            if (Configuration.ORG_CODE == "1")
            {
                _rpt.SetParameterValue("CAddress", "Nayasarak, Mirboxtula, Sylhet.");
                _rpt.SetParameterValue("CMobile", "01316-209558");
            }
            else
            {
                _rpt.SetParameterValue("CAddress", "Akhalia, Sylhet");
                _rpt.SetParameterValue("CMobile", "01316-209575");
            }

            
            _rpt.SetParameterValue("InvoiceHeaderText", "TRANSFER INVOICE");


            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTogglePositionForPanel(isPanelMinimized);
        }

        private void dgRequistions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMOutletMedicineRequisition _mreq = dgRequistions.SelectedRows[0].Tag as VMOutletMedicineRequisition;
            txtRequisitionNo.Text = dgRequistions.Rows[e.RowIndex].Cells["RequisitionId"].Value.ToString();

            btnCancel.Tag = _mreq;

            LoadToOutLets(_mreq.FromOutletId);

            //dgRequistions.Visible = false;
            LoadRequitedProducts(_mreq.RequisitionId);
        }

        private void LoadRequitedProducts(long _reqNo)
        {

            PhOutletMedicinieRequisition _MedReq = new PhProductService().GetOutletMedicineRequisitionByReqId(_reqNo);
            txtRequisitionNo.Tag = _MedReq;

            if (_MedReq == null) return;

          

            if (_MedReq != null)
            {
                List<VMOutletRequisitionList> _mReqDetail = new PhProductService().GetOutletMedicineRequisitionDetailByReqId(_MedReq.RequisitionId, _MedReq.ToOutletId);
                dgRequisitionList.Visible = true;
                FillReqProductGrid(_mReqDetail);

            }
        }

        private void FillReqProductGrid(List<VMOutletRequisitionList> _mReqDetail)
        {
            dgRequisitionList.SuspendLayout();
            dgRequisitionList.Rows.Clear();

            dgRequisitionList.Tag = _mReqDetail;

            if (_mReqDetail == null) return;



            foreach (VMOutletRequisitionList item in _mReqDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgRequisitionList, item.ProductId, item.BrandName, item.ReqQty,item.TransferQty, item.AvailQty, item.IsStockShort, item.Status, item.ReplaceRemarks);
                dgRequisitionList.Rows.Add(row);
            }
            // CalculateAmount();
        }

        private void dgRequisitionList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            VMOutletMedicineRequisition _reqMaster = btnCancel.Tag as VMOutletMedicineRequisition;
            foreach (DataGridViewRow row in dgRequisitionList.Rows)
            {
                VMOutletRequisitionList selectedItem = row.Tag as VMOutletRequisitionList;
                

                new PhProductService().PopulateSelectedItemDataForSaleAgainstRequisition(_SelectedItems, selectedItem, _reqMaster);

            }



            List<PhSelectedProductsToSaleOrReceiveOrOrder> _distinctItem = _SelectedItems.GroupBy(x => x.Id).Select(q => q.First()).ToList();

            if (_distinctItem.Count > 0 && _distinctItem.Count == dgRequisitionList.Rows.Count)
            {
                IPDRequisitionDeliveryStatus = RequisitionStatusEnum.Served.ToString();

            }
            else if (_distinctItem.Count > 0 && _distinctItem.Count < dgRequisitionList.Rows.Count)
            {
                IPDRequisitionDeliveryStatus = RequisitionStatusEnum.PartiallyServed.ToString();

            }
            else
            {
                IPDRequisitionDeliveryStatus = RequisitionStatusEnum.Pending.ToString();
            }

       

            FillItemGrid();

            isPanelMinimized = true;
            SetTogglePositionForPanel(isPanelMinimized);

        

            LoadRequisitions();

        }

        private void txtReplaceby_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtReplaceby.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmbFromOutlet.SelectedItem;

                    ctlReplaceProductSearchControl.Visible = true;
                    ctlReplaceProductSearchControl.txtSearch.Text = _txt;
                    ctlReplaceProductSearchControl.txtSearch.SelectionStart = ctlReplaceProductSearchControl.txtSearch.Text.Length;

                    ctlReplaceProductSearchControl.LoadDataByType(_txt + ">" + _outLet.OutLetId.ToString()); // Out let Id appended for outlet specific product loading
                }
            }

        }

        private void ctlReplaceProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtReplaceby.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Tag != null)
            {

                DialogResult result = MessageBox.Show("Are you sure to cancel this indent?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    VMOutletMedicineRequisition requisition = btnCancel.Tag as VMOutletMedicineRequisition;

                    new PhProductService().CancelOutletMedicineRequisition(requisition.RequisitionId);

                    LoadRequisitions();
                }

            }
        }

        private void ctlReplaceProductSearchControl_Load(object sender, EventArgs e)
        {

        }

        private void dgRequisitionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgReqQuantityUpdate(object sender, DataGridViewCellEventArgs e)
        {
            double qty;
            if(e.ColumnIndex==3)
            {
                
                for (int i=0;i<=dgRequisitionList.Rows.Count-1;i++)
                {
                    var obj = dgRequisitionList.Rows[i].Tag as VMOutletRequisitionList;
                    var quantity = dgRequisitionList.Rows[i].Cells[3].Value.ToString();
                    double.TryParse(quantity, out qty);
                    obj.TransferQty = qty;
                    dgRequisitionList.Rows[i].Tag = obj;
                }

            }
        }

        private void txtReplaceby_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtReplaceby.Tag != null)
                {
                    if (dgRequisitionList.Tag != null)
                    {
                        VWPhProductListForSale _PhProduct = (VWPhProductListForSale)txtReplaceby.Tag;

                        List<VMOutletRequisitionList> _reqList = (List<VMOutletRequisitionList>)dgRequisitionList.Tag;

                        VMOutletRequisitionList _requisition = _reqList.Where(x => x.GenericId == _PhProduct.GenericId).FirstOrDefault();

                        if (_requisition == null)
                        {
                            MessageBox.Show("Product not matching with any generic. Plz. check and try again.");

                        }
                        else
                        {
                           // PhOutletMedicineRequisitionDetail _reqDetail = new PhProductService().GetHpMedicineRequisitionDetail(_requisition.RequisitionId, _requisition.ProductId);
                            PhOutletMedicineRequisitionDetail _reqDetail = new PhProductService().GetPhOutletRequisitionDetail(_requisition.RequisitionId, _requisition.ProductId);
                            _reqDetail.ProductId = _PhProduct.ProductId;
                            _reqDetail.ReplaceRemarks = "Replaced of: " + _requisition.BrandName;

                            new PhProductService().UpdatePhMedicineRequisitionDetail(_reqDetail);
                            //ToOutletId
                            List<VMOutletRequisitionList> _mReqDetail = new PhProductService().GetOutletMedicineRequisitionDetailByReqId(_requisition.RequisitionId,1); ;
                            //dgRequisitionList.Visible = true;
                            FillReqProductGrid(_mReqDetail);

                        }

                    }
                }
            }
        }
    }
}
