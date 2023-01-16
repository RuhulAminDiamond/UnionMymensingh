using HDMS.Model.Common;
using HDMS.Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmDiscountPlanSetup : Form
    {
        bool isLoaded = false;

        public frmDiscountPlanSetup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CorporateClient _client = (CorporateClient)cmbCompanyName.SelectedItem;
            RegDesignation _designation = (RegDesignation)cmbRegDesignation.SelectedItem;

            double _labDiscount = 0;
            double _NonlabDiscount = 0;
            double _IPDBedDiscount = 0;
            double _IPDServiceChargeDiscount = 0;
            double _VentilationDiscount = 0;
            double _OxygenDiscount = 0;
            double _PharmacyDiscount = 0;

            double.TryParse(txtLabDiscount.Text, out _labDiscount);
            double.TryParse(txtRadiologyImagingDiscount.Text, out _NonlabDiscount);
            double.TryParse(txtIPDBedDiscount.Text, out _IPDBedDiscount);
            double.TryParse(txtDiscountOnOxygenBill.Text, out _OxygenDiscount);
            double.TryParse(txtVentilationDiscount.Text, out _VentilationDiscount);
            double.TryParse(txtDiscountOnPharmacyBill.Text, out _PharmacyDiscount);
            double.TryParse(txtDiscountOnServiceCharge.Text, out _IPDServiceChargeDiscount);

            if (_client != null && _designation != null) {

                RegDiscountPlan _discountPlan = new RegDiscountPlan();
                _discountPlan.CompanyId = _client.CompanyId;
                _discountPlan.DesignationId = _designation.DesignationId;
                _discountPlan.LabDiscount = _labDiscount;
                _discountPlan.NonLabDiscount = _NonlabDiscount;
                _discountPlan.IPDBedDiscount = _IPDBedDiscount;
                _discountPlan.OxygenDiscount = _OxygenDiscount;
                _discountPlan.VentilationDiscount = _VentilationDiscount;
                _discountPlan.PharmacyDiscount = _PharmacyDiscount;
                _discountPlan.IPDServiceChargeDiscount = _IPDServiceChargeDiscount;

                if(new CommonService().SaveDiscountPlan(_discountPlan))
                {
                    MessageBox.Show("Discount plan created or updated successfully.");
                }
             }


        }

        private void frmDiscountPlanSetup_Load(object sender, EventArgs e)
        {
            isLoaded = false;

            LoadCorporateClients();
            LoadRegDesignations();

            isLoaded = true;
        }

        private void LoadRegDesignations()
        {
            List<RegDesignation> _regDesignation = new CommonService().GetRegDesignationList();
            _regDesignation.Insert(0, new RegDesignation() { DesignationId = 0, Designation = "Select Designation" });
            cmbRegDesignation.DataSource = _regDesignation;
            cmbRegDesignation.DisplayMember = "Designation";
            cmbRegDesignation.ValueMember = "DesignationId";
        }

        private void LoadCorporateClients()
        {
            List<CorporateClient> _corporateClients = new CommonService().GetCorporateClientList();
            _corporateClients.Insert(0, new CorporateClient() { CompanyId = 0, Name = "Select Company" });
            cmbCompanyName.DataSource = _corporateClients;
            cmbCompanyName.DisplayMember = "Name";
            cmbCompanyName.ValueMember = "CompanyId";
        }

        private void cmbRegDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                CorporateClient _client = (CorporateClient)cmbCompanyName.SelectedItem;
                RegDesignation _designation = (RegDesignation)cmbRegDesignation.SelectedItem;

                RegDiscountPlan _discountPlan = new CommonService().GetRegDiscountPlan(_client.CompanyId, _designation.DesignationId);

               txtLabDiscount.Text= _discountPlan.LabDiscount.ToString();
               txtRadiologyImagingDiscount.Text = _discountPlan.NonLabDiscount.ToString();
               txtIPDBedDiscount.Text = _discountPlan.IPDBedDiscount.ToString();
               txtDiscountOnOxygenBill.Text = _discountPlan.OxygenDiscount.ToString();
               txtVentilationDiscount.Text = _discountPlan.VentilationDiscount.ToString();
               txtDiscountOnPharmacyBill.Text = _discountPlan.PharmacyDiscount.ToString();
               txtDiscountOnServiceCharge.Text = _discountPlan.IPDServiceChargeDiscount.ToString();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
