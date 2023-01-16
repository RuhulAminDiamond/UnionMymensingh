using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Services.POS;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Pharmacy;
using Store.Forms;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Service;
using HDMS.Model.Users;
using HDMS.Windows.Forms.UI;

namespace POS.Forms
{
    public partial class PhProductEntryControl : UserControl
    {

        bool isLoaded = false;
        
        public PhProductEntryControl()
        {
            InitializeComponent();
        }

        private void PhProductEntryControl_Load(object sender, EventArgs e)
        {
           
          
            isLoaded = false;
            
            LoadGroup(0);
            //LoadSubGroup();
            LoadFormation(0);
            LoadManufacturer(0);
            LoadGeneric(0);

            isLoaded = true;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadProductInfo("","");

            SetRateEditingPrevilage();
        }

        private void SetRateEditingPrevilage()
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if(_user.RoleId != 20 && _user.RoleId != 1 && _user.RoleId != 2)
            {
                txtPPrice.Enabled = false;
                txtSalePrice.Enabled = false;
            }
        }

        private void LoadProductInfo(string name, string _type)
        {
            List<VWPhProductList> _pList = new PhProductService().GetBasicProductInfoList(name, _type).ToList();
            FillListGrid(_pList);
        }

        private void FillListGrid(List<VWPhProductList> pList)
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (VWPhProductList item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgProducts, item.ProductId,  item.BrandName, item.GroupName, item.GenericName, item.Manufacturer,  item.PurchaseRate, item.SaleRate, item.Unit, item.PkgUnit, item.QtyPerBox, item.ROLIndoor,item.ROLOutdoor);
                dgProducts.Rows.Add(row);
            }
        }

      

        private void LoadProductInfo(VWPhProductList item)
        {
            txtBName.Text = item.BrandName;
           
            PhProductInfo _PInfo = new PhProductService().GetProductById(item.ProductId);

                              
            LoadFormation(_PInfo.FormationId);
            LoadGeneric(_PInfo.GenericId);
            LoadManufacturer(_PInfo.ManufacturerId);
            cmbUnit.Text = _PInfo.Unit;
            txtPPrice.Text = Convert.ToString(item.PurchaseRate);
            txtSalePrice.Text = Convert.ToString(item.SaleRate);
            //txtIndicate.Text = _PInfo.Indication;
            //txtDosage.Text = _PInfo.DosageAdmistration;
            ////txtPreperation.Text = _PInfo.Preperation;
            //txtSideEffact.Text = _PInfo.SideEffact;
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }
        private void LoadGeneric(int _groupId)
        {
            if (_groupId > 0)
            {
                List<Generic> gList = new PhProductClassificationService().GetGenList().ToList();
                gList = gList.Where(x => x.GroupId == _groupId).ToList();
                gList.Insert(0, new Generic() { GenericId = 0, Name = "Select Generic" });
                cmbGeneric.DataSource = gList;
                cmbGeneric.DisplayMember = "Name";
                cmbGeneric.ValueMember = "GenericId";
            }
            else
            {
                List<Generic> gList = new PhProductClassificationService().GetGenList().ToList();
                gList.Insert(0, new Generic() { GenericId = 0, Name = "Select Generic" });
                cmbGeneric.DataSource = gList;
                cmbGeneric.DisplayMember = "Name";
                cmbGeneric.ValueMember = "GenericId";
               
            }
        }

        private void LoadManufacturer(int _manufacturer)
        {
            List<Manufacturer> mList = new PhProductClassificationService().GetManufacturer().ToList();
            mList.Insert(0, new Manufacturer() { ManufacturerId = 0, Name = "Select Manufacturer" });
            cmbManufacturer.DataSource = mList;
            cmbManufacturer.DisplayMember = "Name";
            cmbManufacturer.ValueMember = "ManufacturerId";
            if (_manufacturer > 0)
            {
                cmbManufacturer.SelectedItem = mList.Find(x => x.ManufacturerId == _manufacturer);
            }
        }

        private void LoadFormation(int _formationId)
        {
            List<Formation> fList = new PhProductClassificationService().GetFormation().ToList();
            fList.Insert(0, new Formation() { FormationId = 0, Name = "Select Formation" });
            cmbFormation.DataSource = fList;
            cmbFormation.DisplayMember = "Name";
            cmbFormation.ValueMember = "FormationId";
            if (_formationId > 0)
            {
                cmbFormation.SelectedItem = fList.Find(x => x.FormationId == _formationId);
            }
        }

       

        private void LoadGroup(int _groupId)
        {
            List<PhProductGroup> gList = new PhProductService().GetAllGroups();
            gList.Insert(0, new PhProductGroup() { GroupId = 0, Name = "Select Group" });
            cmbGroup.DataSource = gList;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupId";

            if (_groupId > 0)
            {
                cmbGroup.SelectedItem = gList.Find(x => x.GroupId == _groupId);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtProductId_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)Keys.Space)
            //{
            //    HideAllDefaultHidden();
            //    ctlProductSearchControl.Visible = true;
            //    ctlProductSearchControl.LoadData();


            //}
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBName.Focus();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearchControl.Visible = false;
        }

        private void txtBName_KeyPress(object sender, KeyPressEventArgs e)
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
                
            }
        }

        private void cmbSubGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbGeneric.Focus();
            }
        }

        private void cmbGeneric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbFormation.Focus();
            }
        }

        private void cmbFormation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbManufacturer.Focus();
            }
        }

        private void cmbManufacturer_KeyPress(object sender, KeyPressEventArgs e)
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
                txtPPrice.Focus();
            }
        }

        private void txtPharchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSalePrice.Focus();
            }
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPerceneDecrease.Focus();
            }
        }

        private void txtIndicate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
               // txtDosage.Focus();
            }
        }

        private void txtDosage_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                //txtPreperation.Focus();
            }
        }

        private void txtPreperation_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                //txtSideEffact.Focus();
            }
        }

        private void txtSideEffact_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                PhProductGroup _Group = (PhProductGroup)cmbGroup.SelectedItem;
                LoadGeneric(_Group.GroupId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int _sgId = 0, genId = 0, _formId = 0, _manufacId = 0,_rolIndoor,_rolOutDoor=0,qtyperbox=0;

            double _pprice = 0;
            double.TryParse(txtPPrice.Text, out _pprice);
            double _sPrice = 0;
            double.TryParse(txtSalePrice.Text, out _sPrice);

            int.TryParse(txtROLIndoor.Text, out _rolIndoor);
            int.TryParse(txtROLOutDoor.Text, out _rolOutDoor);
            int.TryParse(txtQtyPerBox.Text, out qtyperbox);

            if (cmbPackagingStyle.Text.ToLower() == "box" && qtyperbox==0)
            {
                MessageBox.Show("Qty per box required.");
                txtQtyPerBox.Focus();
                return;
            }

           
            Generic _generic = (Generic)cmbGeneric.SelectedItem;
            Formation _f = (Formation)cmbFormation.SelectedItem;
            Manufacturer _m = (Manufacturer)cmbManufacturer.SelectedItem;

            if (_generic.GenericId == 0 || _m.ManufacturerId == 0)
            {
                MessageBox.Show("Generic/Manufacturer not selected. Plz. select them and try again.");return;
            }


               
             genId = _generic.GenericId; 
            if (_f.FormationId == 0) { _formId = 1; } else { _formId = _f.FormationId; }
            _manufacId = _m.ManufacturerId; 


            if (!CheckValidity(_generic, _f, _m))
            {
                MessageBox.Show("Formation Or Manufacturer not selected. Plz. verify and try again.");
                return; 
            }

            if (txtBName.Tag != null)
            {
                VWPhProductList PItem = (VWPhProductList)txtBName.Tag;
                PhProductInfo _PInfo = new PhProductService().GetProductById(PItem.ProductId);


               
                _PInfo.BrandName = txtBName.Text;
                _PInfo.BarCode ="";
                    // Convert.ToInt32(cmbSubGroup.SelectedValue);
                _PInfo.GenericId = genId;       // Convert.ToInt32(cmbGeneric.SelectedValue);
                _PInfo.FormationId = _formId;   //Convert.ToInt32(cmbFormation.SelectedValue);
                _PInfo.ManufacturerId = _manufacId;   //Convert.ToInt32(cmbManufacturer.SelectedValue);
                _PInfo.Unit = cmbUnit.Text;
                _PInfo.PkgUnit = cmbPackagingStyle.Text;
                _PInfo.QtyPerBox = qtyperbox;
                _PInfo.PurchasePrice = _pprice;
                _PInfo.SalePrice = _sPrice;
                _PInfo.Indication = "";
                _PInfo.ContraIndication = "";
                _PInfo.DosageAdmistration = "";
                _PInfo.Preperation = "";// txtPreperation.Text;
                _PInfo.SideEffact = "";
                _PInfo.ROLIndoor = _rolIndoor;
                _PInfo.ROLOutdoor = _rolOutDoor;
                if (new PhProductClassificationService().UpdateProduct(_PInfo))
                {
                    MessageBox.Show("Update Successful.");
                    //LoadProductInfo("", "");
                    ClearFields();
                    LoadGroup(0);
                   
                    LoadFormation(0);
                    LoadGeneric(0);
                    LoadManufacturer(0);
                    cmbUnit.Text = "";
                }
                else
                {
                    MessageBox.Show("Update Failed.");
                }

            }
            else
            {
          
            
            
            string _msg = ValidationCheck();

            string _msgdv = ValidationDropdownVale();

            if (!String.IsNullOrEmpty(_msgdv))
            {
                MessageBox.Show(_msgdv + " not selected. ");
                return;
            }

          

            if (String.IsNullOrEmpty(_msg))
            {
               
                
                
                PhProductInfo PhP_Info = new PhProductInfo();
             
                PhP_Info.BarCode = "";
                PhP_Info.BrandName = txtBName.Text;
                
                PhP_Info.GenericId = genId;
                PhP_Info.FormationId = _formId;
                PhP_Info.ManufacturerId = _manufacId;
                PhP_Info.Unit = cmbUnit.Text;
                PhP_Info.PkgUnit = cmbPackagingStyle.Text;
                PhP_Info.QtyPerBox = qtyperbox;
                PhP_Info.PurchasePrice =_pprice;
                PhP_Info.SalePrice = _sPrice;
                PhP_Info.Indication = "";
                PhP_Info.ContraIndication = "";
                PhP_Info.DosageAdmistration = "";
                PhP_Info.Preperation = "";//txtPreperation.Text;
                PhP_Info.SideEffact = "";
                PhP_Info.ROLIndoor = _rolIndoor;
                PhP_Info.ROLOutdoor = _rolOutDoor;
                PhP_Info.DoseId = 0;
               if (new PhProductService().SaveProduct(PhP_Info))
                {
                    MessageBox.Show("Product Save Succesful.");
                    LoadProductInfo("", "");
                    ClearFields();

                }
                else
                {
                    MessageBox.Show("Product Save Failed.");
                }

            }
            else
            {
                MessageBox.Show(_msg + " required. ");
            }
          }
        }

        private bool CheckValidity( Generic _generic, Formation _f, Manufacturer _m)
        {
            bool isValid = true;

            //if( (_subGroup.SubGroupId==0) || (_generic.GenericId==0) || (_f.FormationId==0) || (_m.ManufacturerId == 0)){
            if ((_f.FormationId == 0) || (_m.ManufacturerId == 0))
            {
                isValid = false;
            }

            return isValid;
        }

        private void ClearFields()
        {
            txtBName.Text = "";

            txtBName.Tag = null;
           
            txtPPrice.Text="";
            txtSalePrice.Text = "";
            txtPerceneDecrease.Text = "";
            
            txtQtyPerBox.Text = "";
            txtQtyPerBox.PlaceHolderText = "Qty per box";
            //txtPreperation.Text = "";
           
            btnSave.Text = "Save";
        }

        private string ValidationDropdownVale()
        {
            string _msg = string.Empty;

            //if (Convert.ToInt32(cmbGroup.SelectedValue) == 0) { _msg = "Group"; }

            //if (Convert.ToInt32(cmbSubGroup.SelectedValue) == 0) {

            //    if (!String.IsNullOrEmpty(_msg))
            //    {
            //        _msg = _msg + ", " + "Sub Group";
            //    }
            //    else
            //    {
            //        _msg = "Sub Group";
            //    }
            //}

            //if (Convert.ToInt32(cmbGeneric.SelectedValue) == 0) { 
            //    if(!string.IsNullOrEmpty(_msg))
            //    {
            //        _msg = _msg + "," + "Generic";
            //    }
            //    else
            //    {
            //        _msg = "Generic";
            //    }
                
            //}


            if (Convert.ToInt32(cmbFormation.SelectedValue) == 0) {
                if (!string.IsNullOrEmpty(_msg))
                {
                    _msg = _msg + "," + "Formation";
                }
                _msg = "Formation";
            }
            if (Convert.ToInt32(cmbManufacturer.SelectedValue) == 0)
            {
                if (!string.IsNullOrEmpty(_msg))
                {
                    _msg = _msg + "," + "Manufacturer";
                }
                _msg = "Manufacturer";
            }

            if (String.IsNullOrEmpty(cmbUnit.Text))
            {
                if (!string.IsNullOrEmpty(_msg))
                {
                    _msg = _msg + "," + "Unit";
                }
                _msg = "Unit";
            }


            return _msg;

        }

        private string ValidationCheck()
        {
            string msg = string.Empty;

            msg = GetMessage(msg, "Brand Name",txtBName.Text);

            //msg = GetMessage(msg, "Group", cmbGroup.Text);

           // msg = GetMessage(msg, "Sub Group", cmbSubGroup.Text);

            //msg = GetMessage(msg, "Generic", cmbGeneric.Text);

            return msg;
        }

        private string GetMessage(string _currentmsg, string type, string _value)
        {
            if (String.IsNullOrEmpty(_value) && String.IsNullOrEmpty(_currentmsg)) return type;
            
            if (!String.IsNullOrEmpty(_value) && !String.IsNullOrEmpty(_currentmsg)) return _currentmsg+", "+ type;

            if (String.IsNullOrEmpty(_value) && !String.IsNullOrEmpty(_currentmsg)) return _currentmsg ;

          

            return "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //new frmStuffs().form();
            this.Parent.Dispose();
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByName.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                LoadProductInfo(txtSearchByName.Text, "PName");
            }
        }

        private void dgProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
            VWPhProductList _SelectedItem = dgProducts.SelectedRows[0].Tag as VWPhProductList;

            txtBName.Tag = _SelectedItem;
          
            txtBName.Text = _SelectedItem.BrandName;
            txtPPrice.Text = _SelectedItem.PurchaseRate.ToString();
            txtSalePrice.Text = _SelectedItem.SaleRate.ToString();
            cmbUnit.Text = _SelectedItem.Unit;
            cmbPackagingStyle.Text = _SelectedItem.PkgUnit;
            txtQtyPerBox.Text = _SelectedItem.QtyPerBox.ToString();

            LoadCombos(_SelectedItem);

            btnCancel.Visible = true;
            btnSave.Text = "Update";
        }

        private void LoadCombos(VWPhProductList _SelectedItem)
        {
            PhProductInfo _PInfo = new PhProductService().GetProductById(_SelectedItem.ProductId);

            Generic _g = new PhProductService().GetPhProducGenId(_PInfo.GenericId);

            LoadGroupWithSelectedGenGroupId(_g.GroupId,_g.GenericId);

            LoadManufacturer(_PInfo.ManufacturerId);

            LoadFormation(_PInfo.FormationId);

            


        }

        private void LoadFormationWithSelectedOne(int formationId)
        {
            throw new NotImplementedException();
        }

        private void LoadManufacturerWithSelectedOne(int manufacturerId)
        {
            throw new NotImplementedException();
        }

        private void LoadGenericWithSelectedOne(int genericId)
        {
        }

        private void LoadGroupWithSelectedGenGroupId(int groupId, int genericId)
        {
            List<PhProductGroup> groupList = new PhProductService().GetAllGroups();
            groupList.Insert(0, new PhProductGroup() { GroupId = 0, Name = "Select Group" });
            cmbGroup.DataSource = groupList;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupId";

            if (groupId > 0)
            {
                cmbGroup.SelectedItem = groupList.Find(x => x.GroupId == groupId);

                List<Generic> gList = new PhProductClassificationService().GetGenList().ToList();
                gList.Insert(0, new Generic() { GenericId = 0, Name = "Select Generic" });
                gList = gList.Where(x => x.GroupId == groupId).ToList();
                cmbGeneric.DataSource = gList;
                cmbGeneric.DisplayMember = "Name";
                cmbGeneric.ValueMember = "GenericId";

                if (genericId > 0)
                {
                    cmbGeneric.SelectedItem = gList.Find(q => q.GenericId == genericId);
                   
                }



            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBName.Tag = null;
            txtBName.Text = "";
            txtBName.Text = "";
            txtPPrice.Text = "";
            txtSalePrice.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            frmAddGroup _frm = new frmAddGroup();
            _frm.Show();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            LoadGroup(0);
            //LoadSubGroup();
            LoadFormation(0);
            LoadManufacturer(0);
            LoadGeneric(0);

            isLoaded = true;

          

            LoadProductInfo("", "");
        }

        private void btnAddSubGroup_Click(object sender, EventArgs e)
        {
            frmSubGroup _frm = new frmSubGroup();
            _frm.Show();
        }

        private void btnAddGeneric_Click(object sender, EventArgs e)
        {
            frmGeniric _frm = new frmGeniric();
            _frm.Show();
        }

        private void btnAddManufacturer_Click(object sender, EventArgs e)
        {
            frmManufacturer _frm = new frmManufacturer();
            _frm.Show();
        }

        private void btnAddFormation_Click(object sender, EventArgs e)
        {
            frmFormation _frm = new frmFormation();
            _frm.Show();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadProductInfo("", "");
        }

        private void cmbGeneric_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                Generic _g = (Generic)cmbGeneric.SelectedItem;

                LoadProductInfoByGeneric(_g.GenericId);
            }
        }

        private void LoadProductInfoByGeneric(int genericId)
        {
            List<VWPhProductList> _pList = new PhProductService().GetBasicProductInfoList("", "").ToList();
            FillListGrid(_pList);
        }

        private void txtPerceneDecrease_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double percent = 0;
                double sp = 0;
                double.TryParse(txtSalePrice.Text, out sp);
                double.TryParse(txtPerceneDecrease.Text, out percent);

                if (percent > 0)
                {
                    double pp = Math.Round((sp - (sp * percent) / 100), 2);
                    txtPPrice.Text = pp.ToString();
                    cmbGroup.Focus();
                }
                else
                {
                    MessageBox.Show("Percent required");
                    txtPerceneDecrease.Focus();
                }



            }
        }
    }
}
