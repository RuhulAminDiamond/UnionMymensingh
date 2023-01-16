using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Rx;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Service.Rx;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Rx;
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
    public partial class frmPhDoseAndAdministrationEntry : Form
    {
        bool isLoaded = false;

        public frmPhDoseAndAdministrationEntry()
        {
            InitializeComponent();
        }

        private async void frmPhDoseAndAdministrationEntry_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();
            isLoaded = false;
            await LoadGroup(0);
            //LoadSubGroup();
           await LoadFormation(0);
           await LoadManufacturer(0);
           await LoadGeneric(0);

            List<RxDuration> _duration = new RxService().GetRxDuration();


            cmbDurationUnit.DataSource = _duration;
            cmbDurationUnit.DisplayMember = "Name";
            cmbDurationUnit.ValueMember = "DurationId";

            List<RxDoseApplication> _doseApp = new RxService().GetRxDoseApplication();

            cmbBeforeAfter.DataSource = _doseApp;
            cmbBeforeAfter.DisplayMember = "DoseApplyRole";
            cmbBeforeAfter.ValueMember = "DAppId";


            isLoaded = true;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            ctrlDosageSearch.Location = new Point(txtDoseShortEn.Location.X-500, txtDoseShortEn.Location.Y);
            ctrlDosageSearch.ItemSelected += CtrlDosageSearch_ItemSelected;


            await LoadProductInfo("","");
        }

        private void CtrlDosageSearch_ItemSelected(SearchResultListControl<RxDosage> sender, RxDosage item)
        {
            txtDoseShortEn.Tag = item;
            txtDoseShortEn.Text = item.DoseEnShort;
            txtDoseEnLong.Text = item.DoseEnLong;
            txtlDoseBnLong.Text = item.DoseBnLong;
            txtDoseShortBn.Text = item.DoseBnShort;
            cmbBeforeAfter.Focus();
            sender.Visible = false;
        }

        private async Task<bool> LoadProductInfo(string brand, string generic)
        {
            List<VMPhProductListForRxPerspective> _pList = await new PhProductService().GetBasicProductInfoListAsync(brand, generic);

            dgProducts.Tag = _pList;

            
            FillListGrid(_pList);

            return await Task.FromResult(true);
        }

        private void FillListGrid(List<VMPhProductListForRxPerspective> pList)
        {
            lbltotalItems.Text = pList.Count.ToString();
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (var item in pList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgProducts, item.ProductId, item.BrandName, item.GroupName, item.GenericName, item.Manufacturer, item.DoseBnLong, item.DoseEnLong, item.DoseBnShort, item.DoseEnShort, item.BeforeAfterBn,item.Duration,item.DurationUnit);
                dgProducts.Rows.Add(row);
            }
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

        private async Task<bool> LoadGroup(int _groupId)
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

            return await Task.FromResult(true);
        }

        private async Task<bool> LoadFormation(int _formationId)
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

            return await Task.FromResult(true);
        }

        private async Task<bool> LoadManufacturer(int _manufacturer)
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

            return await Task.FromResult(true);
        }

        private  async Task<bool> LoadGeneric(int _groupId)
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

            return await Task.FromResult(true);
        }

        private async void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByName.Text.Trim() == "Search by brand name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {
                string _gen = "";
                if(!txtSearchByGen.Text.Trim().Equals("Search by generic"))
                {
                    _gen = txtSearchByGen.Text;
                }
                await LoadSortedProductInfo(txtSearchByName.Text, _gen);
            }
        }

        private async Task<bool> LoadSortedProductInfo(string brand, string gen)
        {
            List<VMPhProductListForRxPerspective> pList = dgProducts.Tag as List<VMPhProductListForRxPerspective>;
            if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(gen))
            {
                pList = pList.Where(x => x.BrandName.ToLower().Contains(brand.Trim().ToLower()) && x.GenericName.ToLower().Contains(gen.Trim().ToLower())).ToList();
            }
            else if (!string.IsNullOrEmpty(brand))
            {
                pList = pList.Where(x => x.BrandName.ToLower().Contains(brand.Trim().ToLower())).ToList();
            }
            else if (!string.IsNullOrEmpty(gen))
            {
                pList = pList.Where(x => x.GenericName.ToLower().Contains(gen.Trim().ToLower())).ToList();
            }
                
            FillListGrid(pList);
            return await Task.FromResult(true);
        }

        private void dgProducts_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMPhProductListForRxPerspective _SelectedItem = dgProducts.SelectedRows[0].Tag as VMPhProductListForRxPerspective;

            txtBName.Tag = _SelectedItem;

            txtBName.Text = _SelectedItem.BrandName;
           

            LoadCombos(_SelectedItem);

            btnCancel.Visible = true;
            btnSave.Text = "Update";
        }

        private async void LoadCombos(VMPhProductListForRxPerspective _SelectedItem)
        {
            PhProductInfo _PInfo = new PhProductService().GetProductById(_SelectedItem.ProductId);

            Generic _g = new PhProductService().GetPhProducGenId(_PInfo.GenericId);

            LoadGroupWithSelectedGenGroupId(_g.GroupId, _g.GenericId);

           await LoadManufacturer(_PInfo.ManufacturerId);

           await LoadFormation(_PInfo.FormationId);

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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int _sgId = 0, genId = 0, _formId = 0, _manufacId = 0, _rolIndoor, _rolOutDoor = 0, qtyperbox = 0;

            int doseId = 0;
            if (txtDoseShortEn.Tag != null)
            {
                RxDosage _dose = (RxDosage)txtDoseShortEn.Tag;
                doseId = _dose.DoseId; 
            }

            if (doseId == 0)
            {
                MessageBox.Show("Plz. select a dose and try again"); return;
            }

            Generic _generic = (Generic)cmbGeneric.SelectedItem;
            Formation _f = (Formation)cmbFormation.SelectedItem;
            Manufacturer _m = (Manufacturer)cmbManufacturer.SelectedItem;

            if (_generic.GenericId == 0 || _m.ManufacturerId == 0)
            {
                MessageBox.Show("Generic/Manufacturer not selected. Plz. select them and try again."); return;
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
                VMPhProductListForRxPerspective PItem = (VMPhProductListForRxPerspective)txtBName.Tag;
                PhProductInfo _PInfo = new PhProductService().GetProductById(PItem.ProductId);



                _PInfo.BrandName = txtBName.Text;
                _PInfo.BarCode = "";
                // Convert.ToInt32(cmbSubGroup.SelectedValue);
                _PInfo.GenericId = genId;       // Convert.ToInt32(cmbGeneric.SelectedValue);
                _PInfo.FormationId = _formId;   //Convert.ToInt32(cmbFormation.SelectedValue);
                _PInfo.ManufacturerId = _manufacId;   //Convert.ToInt32(cmbManufacturer.SelectedValue);
                _PInfo.Indication = txtIndicate.Text;
                _PInfo.ContraIndication = txtContraIndication.Text;
                _PInfo.DosageAdmistration = "";
                _PInfo.Preperation = "";// txtPreperation.Text;
                _PInfo.SideEffact = txtSideEffact.Text;
                _PInfo.DoseLongBn = txtlDoseBnLong.Text;
                _PInfo.DoseLongEn = txtDoseEnLong.Text;
                _PInfo.DoseShortBn = txtDoseShortBn.Text;
                _PInfo.DoseShortEn = txtDoseShortEn.Text;
                _PInfo.BeforeAfterEn = cmbBeforeAfter.Text;
                _PInfo.Duration = txtDurationValue.Text;
                _PInfo.DurationUnit = cmbDurationUnit.Text;
                _PInfo.DoseId = doseId;
                if (new PhProductClassificationService().UpdateProduct(_PInfo))
                {
                    MessageBox.Show("Update Successful.");
                    //LoadProductInfo("", "");
                    ClearFields();
                   await LoadGroup(0);

                    await LoadFormation(0);
                    await LoadGeneric(0);
                    await LoadManufacturer(0);
                   
                }
                else
                {
                    MessageBox.Show("Update Failed.");
                }

            }

        }

        private void ClearFields()
        {
            txtBName.Text = "";

            txtBName.Tag = null;

            txtDoseEnLong.Tag = null;

            txtSideEffact.Text = "";
            txtlDoseBnLong.Text = "";

            txtDoseEnLong.Text = "";
            txtDoseShortBn.Text = "";
            txtDoseShortEn.Text = "";
            txtSideEffact.Text = "";
            txtIndicate.Text = "";
            txtContraIndication.Text = "";

            btnSave.Text = "Save";
        }

        private bool CheckValidity(Generic _generic, Formation _f, Manufacturer _m)
        {
            bool isValid = true;

            //if( (_subGroup.SubGroupId==0) || (_generic.GenericId==0) || (_f.FormationId==0) || (_m.ManufacturerId == 0)){
            if ((_f.FormationId == 0) || (_m.ManufacturerId == 0))
            {
                isValid = false;
            }

            return isValid;
        }

        private async void btnRefreshList_Click(object sender, EventArgs e)
        {
            await LoadProductInfo("", "");
        }

        private void btnAddDosage_Click(object sender, EventArgs e)
        {
            frmAddCentralDosageTemplate _frm = new frmAddCentralDosageTemplate();
            _frm.Show();
        }

        private void HideAllDefaultHidden()
        {
            ctrlDosageSearch.Visible = false;
        }

        private async void txtSearchByGen_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByGen.Text.Trim() == "Search by generic")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {
                string brand = "";
                if (!txtSearchByName.Text.Trim().Equals("Search by brand name"))
                {
                    brand = txtSearchByName.Text;
                }
                
                await LoadSortedProductInfo(brand, txtSearchByGen.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtDoseShortEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlDosageSearch.Visible = true;
                ctrlDosageSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbBeforeAfter.Focus();
            }

        }
    }
}
