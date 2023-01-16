using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Common.Utils;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Rx;
using HDMS.Service.Rx;
using HDMS.Models.Pharmacy;
using HDMS.Windows.Forms.UI.Rx;
using HDMS.Model.Hospital;
using HDMS.Model.Users;
using HDMS.Service;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlTemplateDischargePart1 : UserControl
    {
        bool unlocked = true;

        public ctrlTemplateDischargePart1()
        {
            InitializeComponent();
        }


        private IList<SelectedMedicineForPatientOnDischarge> _SelectedMedicines;
        private async void ctrlTemplateDischargePart1_Load(object sender, EventArgs e)
        {
            HideDefaultHidden();

            _SelectedMedicines = new List<SelectedMedicineForPatientOnDischarge>();

            ctrlPhProductSearchControl.Location = new Point(txtBrand.Location.X, txtBrand.Location.Y);
            ctrlPhProductSearchControl.ItemSelected += CtrlPhProductSearchControl_ItemSelected;

            ctrlDosageSearch.Location = new Point(txtDosages.Location.X, txtDosages.Location.Y + txtDosages.Height);
            ctrlDosageSearch.ItemSelected += ctrlDosageSearch_ItemSelected;


           

            List<RxDuration> _duration = new RxService().GetRxDuration();

         
            cmbUnit.DataSource = _duration;
            cmbUnit.DisplayMember = "Name";
            cmbUnit.ValueMember = "DurationId";

            List<RxDoseApplication> _doseApp = new RxService().GetRxDoseApplication();

            cmbBeforeAfter.DataSource = _doseApp;
            cmbBeforeAfter.DisplayMember = "DoseApplyRole";
            cmbBeforeAfter.ValueMember = "DAppId";

            List<VMIPDInfo> _Plist = await  LoadPatients();

            FillListGrid(_Plist);

            txtSearchByCabin.Tag = _Plist;

        }

        private void ctrlDosageSearch_ItemSelected(SearchResultListControl<RxDosage> sender, RxDosage item)
        {
            //User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            if (radAdviceBn.Checked)
            {
                txtDosages.Text = item.DoseBnLong;

            }
            else
            {
                txtDosages.Text = item.DoseEnLong;
            }

            txtDosages.Tag = item;
            sender.Visible = false;
            txtDosages.Focus();
        }

        private async Task<List<VMIPDInfo>> LoadPatients()
        {

           List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfoForDischarge();

            return _lisPatientInfo;
         }

       

        private void HideDefaultHidden()
        {
            ctrlPhProductSearchControl.Visible = false;
            ctrlDosageSearch.Visible = false;
        }

        private void CtrlPhProductSearchControl_ItemSelected(Controls.SearchResultListControl<VWPhProductList> sender, VWPhProductList item)
        {
            txtBrand.Text = item.BrandName;
            txtGeneric.Text = item.GenericName;
            txtBrand.Tag = item;
            txtDosages.Focus();
            sender.Visible = false;
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtBrand.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideDefaultHidden();
                    string _outLet = "";
                    if (Configuration.ORG_CODE == "2")
                    {
                        _outLet = "2";
                    }
                    else
                    {
                        _outLet = "1";

                    }

                    ctrlPhProductSearchControl.Visible = true;
                    ctrlPhProductSearchControl.txtSearch.Text = _txt;
                    ctrlPhProductSearchControl.txtSearch.SelectionStart = ctrlPhProductSearchControl.txtSearch.Text.Length;

                    ctrlPhProductSearchControl.LoadDataByType(_txt + ">" + _outLet); // Out let Id appended for outlet specific product loading
                }
            }
        }

        private void txtDosages_KeyPress(object sender, KeyPressEventArgs e)
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

        private void HideAllDefaultHidden()
        {
            ctrlDosageSearch.Visible = false;
            ctrlPhProductSearchControl.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblCabin.Tag != null)
            {
                VMIPDInfo _IpdInfo = (VMIPDInfo)lblCabin.Tag;

                List<TreatmentOnDischarge> _treatmentList = new List<TreatmentOnDischarge>();

             
                foreach (DataGridViewRow row in dgProducts.Rows)
                {
                    SelectedMedicineForPatientOnDischarge selectedProduct = row.Tag as SelectedMedicineForPatientOnDischarge;
                    TreatmentOnDischarge _trt = new TreatmentOnDischarge();
                    _trt.AdmissionId = _IpdInfo.AdmissionId;
                    _trt.MedicineId = selectedProduct.Id;
                    _trt.MedicineName = selectedProduct.Name;
                    _trt.Dosage = selectedProduct.dosage;
                    _trt.IsDoseBanglaFont = selectedProduct.IsDoseBanglaFont;
                    _trt.BeforAfterMeal = selectedProduct.BeforAfterMeal;
                    _trt.IsBeforAfterMealBanglaFont = selectedProduct.IsBeforeAfterBanglaFont;
                    _trt.Duration = selectedProduct.duration;
                    _trt.Unit = selectedProduct.Unit;
                    _trt.IsUnitBanglaFont = selectedProduct.IsDurationBanglaFont;

                    _treatmentList.Add(_trt);

                }

                if (_treatmentList.Count > 0)
                {
                    if (new RxService().DeleteExistingTreatment(_IpdInfo))
                    {

                        new RxService().SaveIPDTreatmentOnDischarge(_treatmentList);
                        MessageBox.Show("Treatment successful.Plz. go to next page.");
                        _SelectedMedicines = new List<SelectedMedicineForPatientOnDischarge>();
                        dgProducts.Rows.Clear();
                        lblCabin.Tag = null;
                    }
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBrand.Tag != null && txtDosages.Tag != null)
            {

                User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

                RxDosage _dose = (RxDosage)txtDosages.Tag;

                RxDoseApplication _dosgeApp = (RxDoseApplication)cmbBeforeAfter.SelectedItem;

                RxDuration _duration = (RxDuration)cmbUnit.SelectedItem;


                new RxService().PopulateSelectedProductDataForIPDPatient(_SelectedMedicines, txtBrand.Tag as VWPhProductList, ((VWPhProductList)txtBrand.Tag).ProductId.ToString(), _dose, _dosgeApp, txtDuration.Text, _duration, false);
                FillProductGrid();

                txtDosages.Text = "";
                unlocked = false;
                txtBrand.Text = "";
                txtBrand.Focus();
                unlocked = true;
            }
            else
            {
                MessageBox.Show("Brand/Dosages required. Plz check them and try again."); return;
            }
        }

        private void FillProductGrid()
        {
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            int _count = 0;
            foreach (SelectedMedicineForPatientOnDischarge item in _SelectedMedicines)
            {
                _count++;
                DataGridViewRow row2 = new DataGridViewRow();
                row2.Height = 35;
                row2.Tag = item;

                row2.CreateCells(dgProducts, item.Name, item.dosage, item.BeforAfterMeal, item.duration, item.Unit, item.Id, _count);
                dgProducts.Rows.Add(row2);
            }
        }

        private void btnAddDosage_Click(object sender, EventArgs e)
        {
            {
                frmAddCentralDosageTemplate _frm = new frmAddCentralDosageTemplate();
                _frm.Show();
            }
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);


                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;

                lblCabin.Tag = _pInfo;

            }
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByCabin.Text, "cabin");
            }
        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = (List<VMIPDInfo>)txtSearchByCabin.Tag;


            if (_lisPatientInfo != null)
            {
                _lisPatientInfo = _lisPatientInfo.Where(x => x.BedCabinNo.Contains(_prefix)).ToList();

                FillListGrid(_lisPatientInfo);
            }
        }

        private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMIPDInfo item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.BedCabinNo, item.Name, item.AddmissionDate.ToString("dd/MM/yyyy"));
                dgPatient.Rows.Add(row);
            }

        }

        private void ctrlDosageSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDosages.Focus();
            }
        }

        private void ctrlPhProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtBrand.Focus();
            }
        }

        private void ctrlTemplateDischargePart1_Resize(object sender, EventArgs e)
        {

           

            

        }

        private void cmbBeforeAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDuration.Focus();
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbUnit.Focus();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }
    }
}
