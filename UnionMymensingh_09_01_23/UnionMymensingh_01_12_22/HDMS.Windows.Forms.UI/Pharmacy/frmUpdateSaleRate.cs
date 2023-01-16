using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmUpdateSaleRate : Form
    {
        public frmUpdateSaleRate()
        {
            InitializeComponent();
        }

        private void frmUpdateSaleRate_Load(object sender, EventArgs e)
        {
            ctrlProductSearch.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y + txtProductCode.Height);
            ctrlProductSearch.ItemSelected += CtrlProductSearch_ItemSelected;
        }

        private void CtrlProductSearch_ItemSelected(Controls.SearchResultListControl<VWPhProductInfo> sender, VWPhProductInfo item)
        {
            txtProductCode.Text = item.BrandName;
            txtProductCode.Tag = item;
            sender.Visible = false;

            LoadPhStockInfo(item.ProductId);
        }

        private void LoadPhStockInfo(int productId)
        {
            List<VWPhStockWithLotAndExpireInfo> _stockList = new PhProductService().GetPhStockList(productId);
            FillGrid(_stockList);
        }

        private void FillGrid(List<VWPhStockWithLotAndExpireInfo> stockList)
        {
            dgStocks.SuspendLayout();
            dgStocks.Rows.Clear();
            foreach(var item in stockList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgStocks,item.LotNo,item.CurrentStock,item.PurchaseRate,item.SaleRate,item.BatchNo,item.ExpireDate.ToString("dd/MM/yyyy"));
                dgStocks.Rows.Add(row);
            }
        }

        private void dgStocks_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VWPhStockWithLotAndExpireInfo _stockInfo = dgStocks.SelectedRows[0].Tag as VWPhStockWithLotAndExpireInfo;
            if (_stockInfo != null)
            {
                VWPhProductInfo _pinfo = txtProductCode.Tag as VWPhProductInfo;
                txtLotNo.Tag = _stockInfo;
                txtLotNo.Text = _stockInfo.LotNo.ToString();
                txtPRate.Text = _stockInfo.PurchaseRate.ToString();
                txtSaleRate.Text = _pinfo.SalePrice.ToString();  //_stockInfo.SaleRate.ToString();
                txtBatchNo.Text = _stockInfo.BatchNo;
                txtExpDate.Text = _stockInfo.ExpireDate.ToString("dd/MM/yyyy");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtLotNo.Tag != null)
            {

                string updateStr = string.Empty;
                double _pRate=0, _sRate =0;
                double.TryParse(txtSaleRate.Text, out _sRate);
                double.TryParse(txtPRate.Text, out _pRate);

                updateStr = "Update successful";

                VWPhStockWithLotAndExpireInfo _stockInfo =  txtLotNo.Tag as VWPhStockWithLotAndExpireInfo;

                PhStockInfo phStck = new PhProductService().GetPhStockInfo(_stockInfo.StckId);
                phStck.PurchaseRate = _pRate;
                phStck.SaleRate = _sRate;
                new PhProductService().UpdatePhStockInfo(phStck);

                PhProductInfo _phProduct = new PhProductService().GetProductById(_stockInfo.ProductId);
                _phProduct.SalePrice = _sRate;
                new PhProductClassificationService().UpdateProduct(_phProduct);


                DateTime? _date = GetParsedExpDate();

                PhLotInfo lotInfo = new PhProductService().GetPhLotInfo(_stockInfo.LotNo);
                lotInfo.BatchNo = txtBatchNo.Text;
                if (_date == null)
                {
                    MessageBox.Show("Date format should be dd/MM/yyyy");
                    updateStr = "Update successful except expire date.";
                }
                else
                {
                    lotInfo.ExpireDate = _date.GetValueOrDefault();
                }
                new PhProductService().UpdatePhLotInfo(lotInfo);

                MessageBox.Show(updateStr);

                LoadPhStockInfo(_stockInfo.ProductId);

                txtLotNo.Tag = null;
                txtLotNo.Text = "";
                txtPRate.Text = "";
                txtBatchNo.Text = "";
                txtExpDate.Text = "";
                txtSaleRate.Text = "";
            }
        }

        private DateTime? GetParsedExpDate()
        {
            
                try
                {

                    string _expDate = DateTime.ParseExact(txtExpDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                   .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                    return Convert.ToDateTime(_expDate);

                }
                catch (Exception ex)
                {
                    return null;
                }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlProductSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Focus();
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
          
            string _txt = txtProductCode.Text.Trim();
            if (_txt.Length > 1)
            {
                ctrlProductSearch.Visible = true;
                ctrlProductSearch.txtSearch.Text = _txt;
                ctrlProductSearch.txtSearch.SelectionStart = ctrlProductSearch.txtSearch.Text.Length;

                ctrlProductSearch.LoadDataByType(_txt);
            }

        }
    }
}
