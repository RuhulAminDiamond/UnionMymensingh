using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.Enums;
using Services.POS;
using Models;
using Models.ViewModel;
using Models.Canteen;
using HDMS.Windows.Forms.UI.Controls;

namespace POS.Forms
{
    public partial class ProductEntryControl : UserControl
    {

        public event EntryCompletedEventHandler EntryCompleted;
        public ProductEntryControl()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgProducts.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgProducts.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }


        public delegate void EntryCompletedEventHandler(object sender);
        private void ProductEntryControl_Load(object sender, EventArgs e)
        {
           // ctlProductSearch.Location = new Point(txtItemCode.Location.X, txtItemCode.Location.Y + txtItemCode.Height);
            //ctlProductSearch.ItemSelected += CtlProductSearch_ItemSelected;


            cmbUnit.DataSource = Enum.GetValues(typeof(UnitEnum));

            cmbGroup.DataSource = new CantItemService().GetAllGroups();
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "Id";

            LoadProductInfo("", "");
        }

        private void CtlProductSearch_ItemSelected(SearchResultListControl<CantProductInfo> sender, CantProductInfo item)
        {
            throw new NotImplementedException();
        }

        private void LoadProductInfo(string name, string _type)
        {
            List<CantVWItemInfo> _pList = new CantItemService().GetBasicItemInfoList(name, _type).ToList();
            FillListGrid(_pList);
        }

        private void FillListGrid(List<CantVWItemInfo> pList)
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (CantVWItemInfo item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgProducts,  item.ProductCode, item.ProductName, item.PurchaseRate, item.SaleRate, item.Unit, item.GroupName);
                dgProducts.Rows.Add(row);
            }
        }


        private void txtPId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
               
            }
            
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtItemCode.Tag != null)
                {
                    CantProductInfo _product = new CantItemService().GetProductById(Convert.ToInt32(txtItemCode.Tag));

                    txtItemCode.Text = _product.ProductCode;
                    txtPName.Text = _product.Name;
                    cmbGroup.SelectedValue = _product.GroupId;
                    cmbUnit.Text = _product.Unit;
                    txtCost.Text = _product.PurchaseRate.ToString();
               
                   

                }
                
                txtPName.Focus();
            }
        }

        private void HideAllDefaultHidden()
        {
            //ctlProductSearch.Visible = false;
        }

        private void txtPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbGroup.Focus();
            }
        }

        private void cmbGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbUnit.Focus();
            }
        }

        private void cmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCost.Focus();
            }
        }

  
        private void txtROL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidEntry())
            {
                double _pRate = 0, _sRate = 0, _hRate = 0;
                int _rol = 0;

                double.TryParse(txtCost.Text, out _pRate);
                double.TryParse(txtSaleRate.Text, out _sRate);
             
                
              

                if (txtPName.Tag == null)
                {
                    CantProductInfo _P = new CantItemService().GetProductByCode(txtItemCode.Text);

                    if (_P == null)
                    {
                        CantProductInfo _pInfo = new CantProductInfo();
                        _pInfo.ProductCode = txtItemCode.Text.Replace("'", "''");
                        _pInfo.Name = txtPName.Text.Replace("'", "''");
                        _pInfo.GroupId = Convert.ToInt32(cmbGroup.SelectedValue);
                        _pInfo.Unit = cmbUnit.Text;
                        _pInfo.PurchaseRate = _pRate;
                        _pInfo.SaleRate = _sRate;
                        _pInfo.WholeSaleRate = _hRate;
                        _pInfo.ROL = _rol;
                      

                        if (new CantItemService().AddNewProduct(_pInfo))
                        {
                            MessageBox.Show("New product added successfully.");
                            ClearForm();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product code already exists. Please choose another code.");
                    }
                }
                else
                {
                    CantVWItemInfo _iTem = (CantVWItemInfo)txtPName.Tag;
                    CantProductInfo _P = new CantItemService().GetProductById(_iTem.ProductId);
                    _P.ProductCode = txtItemCode.Text.Replace("'", "''");
                    _P.Name = txtPName.Text;
                    _P.GroupId = Convert.ToInt32(cmbGroup.SelectedValue);
                    _P.Unit = cmbUnit.Text;
                    _P.PurchaseRate = _pRate;
                    _P.SaleRate = _sRate;
                    _P.WholeSaleRate = _hRate;
                    _P.ROL = _rol;
                    _P.ROL = _rol;
                  
                    if (new CantItemService().UpdateProductInfo(_P))
                    {
                        MessageBox.Show("Product info updated successfully.");
                        ClearForm();
                    }

                }

                LoadProductInfo("", "");

            }
        }

        private void ClearForm()
        {
            txtItemCode.Text = "";
            txtItemCode.Tag = null;
            txtPName.Text = "";
            txtCost.Text = "";
          
          

        }

        private bool IsValidEntry()
        {
            

            if (String.IsNullOrEmpty(txtItemCode.Text) || String.IsNullOrEmpty(txtPName.Text)) return false;

            if (String.IsNullOrEmpty(txtCost.Text)) txtCost.Text = "0";

         
            //2017_09_08
           

                return true;
        }

        private void ctlProductSearch_ItemSelected(SearchResultListControl<CantProductInfo> sender, CantProductInfo item)
        {
            txtItemCode.Text = item.ProductCode;
            txtItemCode.Tag = item.Id;
            txtItemCode.Focus();
            sender.Visible = false;
        }

        //private void ctlProductSearch_ItemSelected(Controls.SearchResultListControl<T> sender, ProductInfo item)
        //{

        //}

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void ctlProductSearch_ItemSelected()
        {

        }

        private void txtQtyPerCartoon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCost.Focus();
            }
        }

        private void dgProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CantVWItemInfo _SelectedItem = dgProducts.SelectedRows[0].Tag as CantVWItemInfo;

            txtItemCode.Text = _SelectedItem.ProductCode;
            txtPName.Tag = _SelectedItem;

            txtPName.Text = _SelectedItem.ProductName;
            txtCost.Text = _SelectedItem.PurchaseRate.ToString();
            txtSaleRate.Text = _SelectedItem.SaleRate.ToString();
            cmbUnit.Text = _SelectedItem.Unit;
            LoadCombos(_SelectedItem);

            btnCancel.Visible = true;
            btnSave.Text = "Update";
        }

        private void LoadCombos(CantVWItemInfo _SelectedItem)
        {
          
            CantProductInfo _PInfo = new CantItemService().GetProductById(_SelectedItem.ProductId);
            LoadGroup(_PInfo.GroupId);

        }

        private void LoadGroup(int groupId)
        {
            List<CantGroup> _grpList= new CantItemService().GetAllGroups();
            cmbGroup.DataSource = _grpList;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "Id";

            cmbGroup.SelectedItem = _grpList.Find(q => q.Id == groupId);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPName.Tag = null;
            txtPName.Text = "";
            txtCost.Text = "";
            txtSaleRate.Text = "";
            txtItemCode.Text = "";
            btnSave.Text = "Save";
        }
    }
    
}
