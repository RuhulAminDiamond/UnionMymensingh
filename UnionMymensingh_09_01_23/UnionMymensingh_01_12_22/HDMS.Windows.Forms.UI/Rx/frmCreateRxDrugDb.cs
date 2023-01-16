using HDMS.Model;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Rx;
using HDMS.Model.Rx.VModel;
using HDMS.Model.Users;
using HDMS.Models.Pharmacy;
using HDMS.Service;
using HDMS.Service.Doctors;
using HDMS.Service.Pharmacy;
using HDMS.Service.Rx;
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

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmCreateRxDrugDb : Form
    {

        bool unlocked = true;
        bool isLoaded = false;
        bool ishitfromGen = false;
        bool isInClearmode = false;

        public frmCreateRxDrugDb()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _sgId = 0, genId = 0, _formId = 0, _manufacId = 0,prodId=0;

            ChamberPractitioner _cp = (ChamberPractitioner)lblBrand.Tag;

            if (txtBrand.Tag != null)
            {
                VWRxPhProductList _pInfo = (VWRxPhProductList)txtBrand.Tag;
                prodId = _pInfo.ProductId;
            }

            if (lblPDBBrandName.Tag != null) // When In Edit/Update Mode
            {
                VMCPPreferredMedicine _pm = (VMCPPreferredMedicine)lblPDBBrandName.Tag;
                if (txtBrand.Tag != null)
                {
                    VWRxPhProductList _pInfo = (VWRxPhProductList)txtBrand.Tag;
                    prodId = _pInfo.ProductId;
                }
                else
                {
                    if (txtBrandShortName.Tag != null)
                    {
                        PhProductInfo _p = (PhProductInfo)txtBrandShortName.Tag;
                        prodId = _p.ProductId;
                    }
                   
                }
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

            int _qty = 0;
            int.TryParse(txtQtyOrPieces.Text,out _qty);

            if (lblPDBBrandName.Tag != null)
            {
                VMCPPreferredMedicine _pm = (VMCPPreferredMedicine)lblPDBBrandName.Tag;

                RxCPPreferredMedicine _preferredMedicine = new RxPhProductService().GetRxCPPProductById(_pm.CPPMId);
                _preferredMedicine.CPId = _cp.CPId;
                _preferredMedicine.ProductId = prodId;
                _preferredMedicine.BrandName = txtBrandNamePDB.Text;
                _preferredMedicine.BrandShortName = txtBrandShortName.Text;
                _preferredMedicine.GenericId = genId;
                _preferredMedicine.FormationId = _formId;
                _preferredMedicine.ManufacturerId = _manufacId;
                _preferredMedicine.DoseShortEn = txtDoseShortEn.Text;
                _preferredMedicine.DoseShortBn = txtDoseShortBn.Text;
                _preferredMedicine.DoseLongEn = txtDoseEnLong.Text;
                _preferredMedicine.DoseLongBn = txtlDoseBnLong.Text;
                _preferredMedicine.BeforeAfterEn = cmbBeforeAfter.Text;
                _preferredMedicine.Duration = txtDurationValue.Text;
                _preferredMedicine.DurationUnit = cmbDurationUnit.Text;
                _preferredMedicine.Qty = _qty;
                if (new RxService().UpCPPreferredDrugs(_preferredMedicine))
                {
                    MessageBox.Show("Drug info update successful.");
                    ClearForm();
                    LoadCpDrugDb(_cp.CPId);
                }


            }
            else
            {
                RxCPPreferredMedicine _preferredMedicine = new RxCPPreferredMedicine();
                _preferredMedicine.CPId = _cp.CPId;
                _preferredMedicine.ProductId = prodId;
                _preferredMedicine.BrandName = txtBrandNamePDB.Text;
                _preferredMedicine.BrandShortName = txtBrandShortName.Text;
                _preferredMedicine.GenericId = genId;
                _preferredMedicine.FormationId = _formId;
                _preferredMedicine.ManufacturerId = _manufacId;
                _preferredMedicine.DoseShortEn = txtDoseShortEn.Text;
                _preferredMedicine.DoseShortBn = txtDoseShortBn.Text;
                _preferredMedicine.DoseLongEn = txtDoseEnLong.Text;
                _preferredMedicine.DoseLongBn = txtlDoseBnLong.Text;
                _preferredMedicine.BeforeAfterEn = cmbBeforeAfter.Text;
                _preferredMedicine.Duration = txtDurationValue.Text;
                _preferredMedicine.DurationUnit = cmbDurationUnit.Text;
                _preferredMedicine.Qty = _qty;
                if (new RxService().SaveCPPreferredDrugs(_preferredMedicine))
                {
                    MessageBox.Show("Drug info save successful.");
                    ClearForm();
                    LoadCpDrugDb(_cp.CPId);
                }
            }
            
        }

        private bool CheckValidity(Generic generic, Formation _f, Manufacturer _m)
        {
            bool isValid = true;

            //if( (_subGroup.SubGroupId==0) || (_generic.GenericId==0) || (_f.FormationId==0) || (_m.ManufacturerId == 0)){
            if ((_f.FormationId == 0) || (_m.ManufacturerId == 0))
            {
                isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            txtlDoseBnLong.Tag = null;
            txtlDoseBnLong.Text = "";
            txtDoseEnLong.Text = "";
            txtDoseShortEn.Text = "";

            cmbBeforeAfter.Text = "";
            txtDurationValue.Text = "";
            cmbDurationUnit.Text = "";
            txtQtyOrPieces.Text = "";
            txtBrand.Tag = null;
            txtBrand.Text = "";
            txtBrandNamePDB.Text = "";
            lblPDBBrandName.Tag = null;
            txtBrandShortName.Tag = null;
            txtBrand.Focus();
        }

        private void frmAddDosageTemplate_Load(object sender, EventArgs e)
        {


            isLoaded = false;

            chkDisable.Checked = true;

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



            ctrlRxProductByBrand.Location = new Point(txtBrand.Location.X, txtBrand.Location.Y);
            ctrlRxProductByBrand.ItemSelected += ctrlRxProductByBrand_ItemSelected;

            ctrlDosageSearch.Location= new Point(txtlDoseBnLong.Location.X, txtlDoseBnLong.Location.Y);
            ctrlDosageSearch.ItemSelected += CtrlDosageSearch_ItemSelected;

            ctrlRxProductByGeneric.Location = new Point(txtRxProductbyGen.Location.X-200, txtRxProductbyGen.Location.Y);
            ctrlRxProductByGeneric.ItemSelected += ctrlRxProductByGeneric_ItemSelected;


            List<RxDuration> _duration = new RxService().GetRxDuration();


            cmbDurationUnit.DataSource = _duration;
            cmbDurationUnit.DisplayMember = "Name";
            cmbDurationUnit.ValueMember = "DurationId";

            List<RxDoseApplication> _doseApp = new RxService().GetRxDoseApplication();

            cmbBeforeAfter.DataSource = _doseApp;
            cmbBeforeAfter.DisplayMember = "DoseApplyRole";
            cmbBeforeAfter.ValueMember = "DAppId";




            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_user.ChamberPractitionerId);

            if (Practitioner != null)
            {
                lblBrand.Tag = Practitioner;

                LoadCpDrugDb(Practitioner.CPId);
            }

            
        }

        private void ctrlRxProductByGeneric_ItemSelected(SearchResultListControl_2<VMPhProductListForRxPerspective> sender, VMPhProductListForRxPerspective item)
        {
            txtRxProductbyGen.Text = item.GenericName;
            txtRxProductbyGen.Tag = item;
            txtBrand.Tag = item;
            txtBrand.Text = item.BrandName;
            txtBrandNamePDB.Text = item.BrandName;
            txtRxProductbyGen.Focus();
           // LoadCombos(item);

            ishitfromGen = false;
            sender.Visible = false;
        }

        private void CtrlDosageSearch_ItemSelected(SearchResultListControl<RxCpDosage> sender, RxCpDosage item)
        {
            txtlDoseBnLong.Tag = item;
            txtlDoseBnLong.Text = item.DoseBnLong;
            txtDoseEnLong.Text = item.DoseEnLong;
            txtDoseShortBn.Text = item.DoseBnShort;
            txtDoseShortEn.Text = item.DoseEnShort;
            txtDoseShortBn.Focus();
            sender.Visible = false;
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

        private void ctrlRxProductByBrand_ItemSelected(SearchResultListControl_2<VMPhProductListForRxPerspective> sender, VMPhProductListForRxPerspective item)
        {
            txtBrand.Tag = item;
            txtBrand.Text = item.BrandName;
            txtBrandNamePDB.Text=  item.BrandName;
            txtBrandNamePDB.Focus();

            sender.Visible = false;
            LoadCombos(item);
         
        }

        private void LoadCombos(VMPhProductListForRxPerspective item)
        {

            try
            {
                PhProductInfo _PInfo = new PhProductService().GetProductById(item.ProductId);
                Generic _g = new PhProductService().GetGeneric(_PInfo.GenericId);

                LoadGroupWithSelectedGenGroupId(_g.GroupId, _g.GenericId);

                LoadManufacturer(_PInfo.ManufacturerId);

                LoadFormation(_PInfo.FormationId);
            
            }catch(Exception ex)
            {

            }
        }

        private void LoadCombosInEditCall(VMCPPreferredMedicine item)
        {

            try
            {
                PhProductInfo _PInfo = new PhProductService().GetProductById(item.ProductId);
                if (_PInfo != null)
                {
                    isInClearmode = true;
                    
                    txtBrand.Text = _PInfo.BrandName;
                    txtBrandShortName.Tag = _PInfo;

                    Generic _g = new PhProductService().GetGeneric(_PInfo.GenericId);

                    LoadGroupWithSelectedGenGroupId(_g.GroupId, _g.GenericId);

                    LoadManufacturer(_PInfo.ManufacturerId);

                    LoadFormation(_PInfo.FormationId);

                    isInClearmode = false;
                }
                else
                {
                    RxCPPreferredMedicine _pm = new RxPhProductService().GetRxCPPProductById(item.CPPMId);

                    Generic _g = new PhProductService().GetGeneric(_pm.GenericId);

                    LoadGroupWithSelectedGenGroupId(_g.GroupId, _g.GenericId);

                    LoadManufacturer(_pm.ManufacturerId);

                    LoadFormation(_pm.FormationId);

                }

            }
            catch (Exception ex)
            {

            }
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

        private void LoadCpDrugDb(int cPId)
        {
            List<VMCPPreferredMedicine> _durgList = new RxService().GetCpPreferredMedicine(cPId);

            FillGrid(_durgList);

            dgDrug.Tag = _durgList;

        }

       
        private void FillGrid(List<VMCPPreferredMedicine> _dosageList)
        {
            dgDrug.SuspendLayout();
            dgDrug.Rows.Clear();

            foreach (var item in _dosageList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgDrug, item.CPPMId, item.BrandName, item.DoseLongBn, item.DoseLongEn, item.DoseShortBn, item.DoseShortEn, item.BeforeAfterEn,item.Duration,item.DurationUnit);
                dgDrug.Rows.Add(row);
            }
        }

        private void btnSetPreferrence_Click(object sender, EventArgs e)
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

           

        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text))
            {
                unlocked = true;
            }

            if (unlocked && !ishitfromGen && !isInClearmode)
            {
                ChamberPractitioner _cp = (ChamberPractitioner)lblBrand.Tag;
                
                HideAllDefaultHidden();

                string _txt = txtBrand.Text.Trim();
                if (_txt.Length >= 2)
                {
                       
                        ctrlRxProductByBrand.Visible = true;
                      
                        ctrlRxProductByBrand.txtSearch.Text = _txt;
                        ctrlRxProductByBrand.txtSearch.SelectionStart = ctrlRxProductByBrand.txtSearch.Text.Length;


                        ctrlRxProductByBrand.searchBybrand = true;
                        ctrlRxProductByBrand.LoadPhRxDataByType(_txt, "", "", _cp.CPId,null);

                    
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlRxProductByBrand.Visible=false;
            ctrlDosageSearch.Visible = false;
            ctrlRxProductByGeneric.Visible = false;
        }

        private void ctrlRxProductByBrand_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private void ctrlDosageSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtlDoseBnLong.Focus();
            }
        }

        private void txtlDoseBnLong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChamberPractitioner _cp = (ChamberPractitioner)lblBrand.Tag;
            if (e.KeyChar == (char)Keys.Space && !chkDisable.Checked)
            {
                HideAllDefaultHidden();
                ctrlDosageSearch.Visible = true;
                ctrlDosageSearch.LoadDataByType(_cp.CPId.ToString());
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbBeforeAfter.Focus();
            }
        }

        private void dgDrug_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            VMCPPreferredMedicine _SelectedItem = (VMCPPreferredMedicine)e.Row.Tag;

            new RxService().DeleteDrugFromCpPersonalDb(_SelectedItem);

            
        }

        private void ctrlRxProductByGeneric_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                ishitfromGen = false;
                txtRxProductbyGen.Focus();
            }
        }

        private void txtRxProductbyGen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ishitfromGen = true;

                ChamberPractitioner _cp = (ChamberPractitioner)lblBrand.Tag;

                HideAllDefaultHidden();

                ctrlRxProductByGeneric.Visible = true;

                ctrlRxProductByGeneric.txtSearch.Text = "";
                ctrlRxProductByGeneric.txtSearch.SelectionStart = ctrlRxProductByGeneric.txtSearch.Text.Length;
                ctrlRxProductByGeneric.LoadPhRxDataByType("", cmbGeneric.Text, "", _cp.CPId,null);
            }
        }

        private void txtSearchByBrandName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByBrandName.Text.Trim() == "Search by brand name")
            {
                LoadProductInfo("");
            }
            else
            {

                LoadProductInfo(txtSearchByBrandName.Text);
            }
        }

        private void LoadProductInfo(string searchtxt)
        {
          
            if(dgDrug.Tag!= null && !string.IsNullOrEmpty(searchtxt))
            {
                List<VMCPPreferredMedicine> _drgList = (List<VMCPPreferredMedicine>)dgDrug.Tag;
                _drgList = _drgList.Where(x => x.BrandName.ToLower().Contains(searchtxt.ToLower())).ToList();

                FillGrid(_drgList);
            }
            else if (dgDrug.Tag != null && string.IsNullOrEmpty(searchtxt))
            {
                List<VMCPPreferredMedicine> _drgList = (List<VMCPPreferredMedicine>)dgDrug.Tag;
                FillGrid(_drgList);
            }
           
        }

        private void btnAddDosage_Click(object sender, EventArgs e)
        {
            frmAddCpDosageTemplate _frm = new frmAddCpDosageTemplate();
            _frm.Show();
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Back || e.KeyCode == Keys.Delete)
            {
                isInClearmode = true;
            }
            else
            {
                isInClearmode = false;
            }
        }

        private void dgDrug_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDrug.Rows.Count > 0)
            {
                VMCPPreferredMedicine pm = dgDrug.CurrentRow.Tag as VMCPPreferredMedicine;
                if (pm != null)
                {

                    lblPDBBrandName.Tag = pm;

                    txtBrandNamePDB.Text= pm.BrandName ;
                    txtBrandShortName.Text = pm.BrandShortName;

                    txtDoseShortEn.Text=pm.DoseShortEn ;
                    txtDoseShortBn.Text= pm.DoseShortBn;
                    txtDoseEnLong.Text= pm.DoseLongEn;
                    txtlDoseBnLong.Text= pm.DoseLongBn;
                    cmbBeforeAfter.Text= pm.BeforeAfterEn;
                    txtDurationValue.Text= pm.Duration;
                    cmbDurationUnit.Text= pm.DurationUnit;
                    txtQtyOrPieces.Text =  pm.Qty.ToString();

                    LoadCombosInEditCall(pm);
                   
                }
            }
        }

        private void ctrlDosageSearch_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtlDoseBnLong.Focus();
            }
        }
    }
}
