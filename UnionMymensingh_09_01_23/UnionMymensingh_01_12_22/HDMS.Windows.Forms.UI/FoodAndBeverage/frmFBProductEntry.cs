using HDMS.Model.Store;
using HDMS.Service.Accounting;
using Models.Accounting;
using Models.Store;
using Models.ViewModel;
using Services.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    public partial class frmFBProductEntry : Form
    {
        public frmFBProductEntry()
        {
            InitializeComponent();
        }

        private void frmProductEntry_Load(object sender, EventArgs e)
        {
            cmbGroup.DataSource = new StoreItemService().GetAllGroups();
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupId";
            LoadProductInfo("", "");
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double _pRate = 0, _sRate = 0, _hRate = 0;
            int _rol = 0;

            double.TryParse(txtCost.Text, out _pRate);
            double.TryParse(txtSaleRate.Text, out _sRate);


            if (txtPName.Tag == null)
            {

                AccountHead accHead = new AccountHead();
                accHead.CompanyId = 1;
                accHead.ParentAccountHeadId = 193;
                accHead.AccCode = 0;
                accHead.AccountHeadName = txtPName.Text + " Purchase";
                accHead.Description = txtPName.Text + " Purchase"; ;
                accHead.TopAccountHead = 1;

                accHead.IsPostingHead = true;
                accHead.IsCashHead = false;
                accHead.IsBankHead = false;
                accHead.IsBalanceSheet = true;
                accHead.IsIncomeExpense = false;
                accHead.IsReceivedPayment = false;

                new AccountService().AddNewAccountHead(accHead);

                int _debitAccId = accHead.AccId;

                txtDebitAccCode.Text = _debitAccId.ToString();

                accHead = new AccountHead();
                accHead.CompanyId = 1;
                accHead.ParentAccountHeadId = 213;
                accHead.AccCode = 0;
                accHead.AccountHeadName = txtPName.Text + " Expense";
                accHead.Description = txtPName.Text + " Expense"; ;
                accHead.TopAccountHead = 5;

                accHead.IsPostingHead = true;
                accHead.IsCashHead = false;
                accHead.IsBankHead = false;
                accHead.IsBalanceSheet = false;
                accHead.IsIncomeExpense = true;
                accHead.IsReceivedPayment = false;

                new AccountService().AddNewAccountHead(accHead);

                int _creditAccId = accHead.AccId;

                txtCreditAccCode.Text = _creditAccId.ToString();


                StoreProductInfo STPInfo = new StoreProductInfo();
                STPInfo.ProductCode = txtItemCode.Text;
                STPInfo.Name = txtPName.Text;
                STPInfo.GroupId = Convert.ToInt32(cmbGroup.SelectedValue);
                STPInfo.Unit = cmbUnit.Text;
                STPInfo.PurchaseRate = _pRate;
                STPInfo.SaleRate = _sRate;
                STPInfo.DebitAccId = _debitAccId;
                STPInfo.CreditAccId = _creditAccId;

                new StoreItemService().SaveNewProduct(STPInfo);
                MessageBox.Show("Product info added successfully.");
                ClearForm();
            }
            else
            {
                VMStoreItemInfo _iTem = (VMStoreItemInfo)txtPName.Tag;
                StoreProductInfo _P = new StoreItemService().GetProductById(_iTem.ProductId);
                _P.ProductCode = txtItemCode.Text.Replace("'", "''");
                _P.Name = txtPName.Text;
                _P.GroupId = Convert.ToInt32(cmbGroup.SelectedValue);
                _P.Unit = cmbUnit.Text;
                _P.PurchaseRate = _pRate;
                _P.SaleRate = _sRate;
                _P.WholeSaleRate = _hRate;
              
                _P.ROL = _rol;
                _P.ROL = _rol;

                if (new StoreItemService().UpdateProductInfo(_P))
                {
                    MessageBox.Show("Product info updated successfully.");
                    ClearForm();
                }
            }

            LoadProductInfo("", "");

        }

        private void ClearForm()
        {
            txtItemCode.Text = "";
            txtItemCode.Tag = null;
            txtPName.Text = "";
            txtCost.Text = "";
            txtDebitAccCode.Text = "";
            txtCreditAccCode.Text = "";

        }

        private void LoadProductInfo(string name, string _type)
        {
            List<VMStoreItemInfo> _pList = new StoreItemService().GetBasicItemInfoList(name, _type).ToList();
            FillListGrid(_pList);
        }

        private void FillListGrid(List<VMStoreItemInfo> pList)
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (VMStoreItemInfo item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgProducts, item.ProductCode, item.ProductName, item.PurchaseRate, item.SaleRate, item.Unit, item.GroupName,item.DebitAccId,item.CreditAccId);
                dgProducts.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMStoreItemInfo _SelectedItem = dgProducts.SelectedRows[0].Tag as VMStoreItemInfo;

            txtItemCode.Text = _SelectedItem.ProductCode;
            txtPName.Tag = _SelectedItem;

            txtPName.Text = _SelectedItem.ProductName;
            txtCost.Text = _SelectedItem.PurchaseRate.ToString();
            txtSaleRate.Text = _SelectedItem.SaleRate.ToString();
            cmbUnit.Text = _SelectedItem.Unit;

            txtDebitAccCode.Text = _SelectedItem.DebitAccId.ToString();
            txtCreditAccCode.Text = _SelectedItem.CreditAccId.ToString();

            LoadCombos(_SelectedItem);

            btnCancel.Visible = true;
            btnSave.Text = "Update";
        }

        private void LoadCombos(VMStoreItemInfo _SelectedItem)
        {
            StoreProductInfo _PInfo = new StoreItemService().GetProductById(_SelectedItem.ProductId);
            LoadGroup(_PInfo.GroupId);
        }

        private void LoadGroup(int groupId)
        {
            List<StoreGroup> _grpList = new StoreItemService().GetAllGroups();
            cmbGroup.DataSource = _grpList;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupId";

            cmbGroup.SelectedItem = _grpList.Find(q => q.GroupId == groupId);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
