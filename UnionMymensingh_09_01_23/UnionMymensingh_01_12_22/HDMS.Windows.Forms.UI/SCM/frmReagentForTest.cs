using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.Store;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Controls;
using Models.Store;
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

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmReagentForTest : Form
    {
        public frmReagentForTest()
        {
            InitializeComponent();
        }
        private IList<SelectedProductsToSaleOrReceive> _SelectedItems;
        private void frmReagentForTest_Load(object sender, EventArgs e)
        {

            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();


            ctlTestSearch.Location = new Point(txtTestCode.Location.X, txtTestCode.Location.Y);
            ctlTestSearch.ItemSelected += ctlTestSearch_ItemSelected;

            ctlProductSearchControl.Location = new Point(txtProduct.Location.X, txtProduct.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;

            LoadTests();
        }

        private void LoadTests()
        {
            List<TestItem> testList = new TestService().GetTestsForReAgentSetting();
            txtSearchTest.Tag = testList;
            dgTestItems.SuspendLayout();
            dgTestItems.Rows.Clear();
            foreach(var item in testList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgTestItems, item.TestId,item.Name);
                dgTestItems.Rows.Add(row);
            }
        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControl<StoreProductInfo> sender, StoreProductInfo item)
        {
            txtProduct.Text = item.ProductId.ToString();
            txtProduct.Tag = item;
            txtProductName.Text = item.Name;
            //txtRate.Text = item.PurchaseRate.ToString();
            txtQty.Focus();
            sender.Visible = false;
        }

        private void ctlTestSearch_ItemSelected(SearchResultListControl<TestItem> sender, TestItem item)
        {

            txtTestCode.Text = item.TestId.ToString();
            txtName.Text = item.Name;
            txtTestCode.Tag = item;
            txtTestCode.Focus();
            sender.Visible = false;
            ctlTestSearch.Visible = false;
        }

        private void txtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlTestSearch.Visible = true;
                ctlTestSearch.LoadData();
            }

        }

        private void HideAllDefaultHidden()
        {
            ctlTestSearch.Visible = false;
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlProductSearchControl.Visible = true;
                ctlProductSearchControl.LoadData();

            }


            else if (e.KeyChar == (char)Keys.Enter)
            {
                StoreProductInfo _PInfo = new StoreItemService().GetProductByCode(txtProduct.Text);
                if (_PInfo != null)
                {
                    txtProduct.Text = _PInfo.ProductCode;
                    txtProduct.Tag = _PInfo;
                    //txtRate.Text = _PInfo.PurchaseRate.ToString();
                    txtProduct.Focus();
                    //txtProductName.Text = _PInfo.Name.ToString();

                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }
            else
            {
                DisplayProductInformation();
            }
        }

        private void DisplayProductInformation()
        {
            StoreProductInfo _PInfo = new StoreItemService().GetProductByCode(txtProduct.Text);
            if (_PInfo != null)
            {
                txtProduct.Text = _PInfo.ProductCode;
                txtProduct.Tag = _PInfo;
                ////txtRate.Text = _PInfo.PurchaseRate.ToString();
                ////txtRate.Focus();
                txtProductName.Text = _PInfo.Name.ToString();

            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                double _qty = 0;
                double.TryParse(txtQty.Text, out _qty);

                if (_qty == 0)
                {
                    MessageBox.Show("Quantity required."); return;
                }

                new StoreItemService().PopulateSelectedItemDataforReagentTests(_SelectedItems, txtProduct.Tag as StoreProductInfo, Convert.ToDouble(txtQty.Text));
                FillItemGrid();


                txtQty.Text = "";
                txtProductName.Text = "";
                //txtProduct.Text = "";
                txtProduct.Focus();
            }
        }

        private void FillItemGrid()
        {
            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (SelectedProductsToSaleOrReceive item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.ProductId, item.Name, item.Qty);
                dgItems.Rows.Add(row);
            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int _testId = 0;
            if (txtTestCode.Tag != null)
            {
                TestItem _item = (TestItem)txtTestCode.Tag;
                _testId = _item.TestId;
            }

            if (_testId == 0)
            {
                MessageBox.Show("Plz. select test and try again.");
                return;
            }
            
            List<ReagentWithTest> _rDeatailsList = new List<ReagentWithTest>();
            foreach (DataGridViewRow row in dgItems.Rows)
            {
                SelectedProductsToSaleOrReceive selectedTests = row.Tag as SelectedProductsToSaleOrReceive;
                ReagentWithTest _rDetails = new ReagentWithTest();
                _rDetails.TestId = _testId;
                _rDetails.ProductId = Convert.ToInt16(selectedTests.ProductId);
                _rDetails.Qty = Convert.ToDouble(selectedTests.Qty);
                _rDeatailsList.Add(_rDetails);
               

            }

            if (_rDeatailsList.Count > 0)
            {
                if (new StoreItemService().SaveTestForReagent(_rDeatailsList))
                {
                    MessageBox.Show("Re-agent mapped with test successful.");

                    ClearForm();
                }
            }
        }

        private void ClearForm()
        {
            dgItems.Rows.Clear();
           

            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();

            txtTestCode.Tag = null;
            txtName.Text = "";
        }

        private void dgItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SelectedProductsToSaleOrReceive _SelectedItem = (SelectedProductsToSaleOrReceive)e.Row.Tag;
            _SelectedItems.Remove(e.Row.Tag as SelectedProductsToSaleOrReceive);
            

        }

        private void txtSearchTest_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTest.Tag != null && txtSearchTest.Text.ToLower()!="search test")
            {
                List<TestItem> _testList = (List<TestItem>)txtSearchTest.Tag;
                _testList = _testList.Where(x=>x.Name.Contains(txtSearchTest.Text.ToUpper())).ToList();
                LoadSearchTests(_testList);
            }
        }

        private void LoadSearchTests(List<TestItem> testList)
        {
            dgTestItems.SuspendLayout();
            dgTestItems.Rows.Clear();
            foreach (var item in testList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgTestItems, item.TestId, item.Name);
                dgTestItems.Rows.Add(row);
            }
        }

        private void dgTestItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgTestItems.Rows.Count > 0)
            {
                TestItem _item = dgTestItems.SelectedRows[0].Tag as TestItem;
                txtTestCode.Text = _item.TestId.ToString();
                txtName.Text = _item.Name;
                txtTestCode.Tag = _item;
                LoadAttachedProductWithThisTest(_item);
            }
        }

        private void LoadAttachedProductWithThisTest(TestItem item)
        {
            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();


            List<ReagentWithTest> _raList = new StoreItemService().GetReAgentsWithTest(item.TestId);
            foreach (var ra in _raList)
            {
                StoreProductInfo _pInfo = new StoreItemService().GetProductById(ra.ProductId);
                new StoreItemService().PopulateSelectedItemDataforReagentTests(_SelectedItems, _pInfo, ra.Qty);
            }
           
            FillItemGrid();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
