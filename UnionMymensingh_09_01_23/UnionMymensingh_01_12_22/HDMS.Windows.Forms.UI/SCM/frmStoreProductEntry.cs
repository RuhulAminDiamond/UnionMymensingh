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

namespace HDMS.Store
{
    public partial class frmStoreProductEntry : Form
    {
        public frmStoreProductEntry()
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
            int.TryParse(txtROL.Text, out _rol);

            if (txtPName.Tag == null)
            {

                //AccountHead accHead = new AccountHead();
                //accHead.CompanyId = 1;
                //accHead.ParentAccountHeadID = 193;
                //accHead.AccCode = 0;
                //accHead.AccountHeadName = txtPName.Text + " Purchase";
                //accHead.Description = txtPName.Text + " Purchase"; ;
                //accHead.TopAccountHead = 1;

                //accHead.IsPostingHead = 1;
                //accHead.IsCashHead = 0;
                //accHead.IsBankHead = 0;
                //accHead.IsBalanceSheet = 1;
                //accHead.IsIncomeExpense = 0;
                //accHead.IsReceivedPayment = 0;

                //new AccountService().AddNewAccountHead(accHead);

               // int _debitAccId = accHead.AccId;

               //  txtDebitAccCode.Text = _debitAccId.ToString();

                //accHead = new AccountHead();
                //accHead.CompanyId = 1;
                //accHead.ParentAccountHeadID = 213;
                //accHead.AccCode = 0;
                //accHead.AccountHeadName = txtPName.Text + " Expense";
                //accHead.Description = txtPName.Text + " Expense"; ;
                //accHead.TopAccountHead = 5;

                //accHead.IsPostingHead = 1;
                //accHead.IsCashHead = 0;
                //accHead.IsBankHead = 0;
                //accHead.IsBalanceSheet = 0;
                //accHead.IsIncomeExpense = 1;
                //accHead.IsReceivedPayment = 0;

                //new AccountService().AddNewAccountHead(accHead);

                //int _creditAccId = accHead.AccId;

                //txtCreditAccCode.Text = _creditAccId.ToString();


                StoreProductInfo STPInfo = new StoreProductInfo();
                STPInfo.ProductCode = txtItemCode.Text;
                STPInfo.Name = txtPName.Text;
                STPInfo.GroupId = Convert.ToInt32(cmbGroup.SelectedValue);
                STPInfo.Unit = cmbUnit.Text;
                STPInfo.PurchaseRate = _pRate;
                STPInfo.SaleRate = _sRate;
                STPInfo.ROL = _rol;
                STPInfo.DebitAccId = 0;
                STPInfo.CreditAccId = 0;

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
            txtROL.Text = "";
            btnSave.Text = "Save";
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
                row.CreateCells(dgProducts, item.ProductId, item.ProductName, item.PurchaseRate, item.SaleRate, item.Unit, item.ROL, item.GroupName,item.DebitAccId,item.CreditAccId);
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
            txtROL.Text = _SelectedItem.ROL.ToString();
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
            ClearForm();
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByName.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                LoadProductStoreProducts();
            }
        }

        private void LoadProductStoreProducts()
        {
            string _brandName = string.Empty;

            if (txtSearchByName.Text.Trim() == "Search by name")
            {
                _brandName = "";
            }
            else
            {
                _brandName = txtSearchByName.Text;
            }


            LoadProductInfo(_brandName,"");

        }
    }
}
