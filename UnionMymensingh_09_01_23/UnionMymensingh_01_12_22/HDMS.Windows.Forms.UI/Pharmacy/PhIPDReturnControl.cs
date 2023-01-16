using HDMS.Model;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Service.Hospital;
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

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class PhIPDReturnControl : UserControl
    {
        List<PhSelectedProductsToSaleOrReceiveOrOrder> _ReturnItems;
        List<PhSelectedProductsToSaleOrReceiveOrOrder> _SoldItems;

        bool isLoaded = false;

        public PhIPDReturnControl()
        {
            InitializeComponent();
        }

        private void PhIPDReturnControl_Load(object sender, EventArgs e)
        {

        }

        private async void txtHIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                long _admissionId = 0; // AdmissionId treated as billNo
                long.TryParse(txtHIN.Text, out _admissionId);

                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_admissionId);

                if (_pInfo == null)
                {
                    MessageBox.Show("Patient record not found.");
                    return;
                }

                if (_pInfo.Status.ToLower() == "discharged")
                {

                    MessageBox.Show("It's a discharged patient.");
                    return;
                }

                txtHIN.Tag = _pInfo;



                List<PhInvoice> _invList = new PhProductService().GetInvoiceListByAdmissionNo(_admissionId);

                _SoldItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                //foreach (PhInvoice invItem in _invList)
                //{
                List<VMPhSoldItem> _soldItems = new PhProductService().GetPhIPDSoldItems(_admissionId);

                foreach (var lineitem in _soldItems)
                {
                    PhSelectedProductsToSaleOrReceiveOrOrder _sItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
                    // PhProductInfo _prdInfo = new PhProductService().GetProductById(lineitem.ProductId);

                    _sItem.InvoiceId = lineitem.InvoiceId;
                    _sItem.Id = lineitem.ProductId;
                    _sItem.Code = lineitem.ProductId.ToString();
                    _sItem.Name = lineitem.BrandName;
                    _sItem.Unit = lineitem.Unit;
                    _sItem.Qty = lineitem.Qty;
                    _sItem.RetQty = lineitem.RetQty;
                    _sItem.Unit = lineitem.Unit;
                    _sItem.SRate = lineitem.SaleRate;
                    _sItem.PRate = lineitem.PurchaseRate;
                    _sItem.LotNo = lineitem.LotNo;
                    _sItem.OutLetId = lineitem.OutLetId;
                    _sItem.Total = lineitem.TotalPrice;
                    _SoldItems.Add(_sItem);

                }
                // }


                FillItemGrid(_SoldItems);

                await new PhProductService().SetOpeningStock(Utils.GetServerDateAndTime());

            }
        }

        private void FillItemGrid(List<PhSelectedProductsToSaleOrReceiveOrOrder> _soldItems)
        {

            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _soldItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 25;
                row.CreateCells(dgItems, item.LotNo, item.Code, item.Name, item.Qty, item.RetQty, item.Unit, item.SRate, item.Total);
                dgItems.Rows.Add(row);
            }


            // CalculateAmount();
            //dgTests.ResumeLayout();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

        }
    }
}
