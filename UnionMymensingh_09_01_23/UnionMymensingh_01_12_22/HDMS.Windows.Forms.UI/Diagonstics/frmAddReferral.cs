using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Hospital;
using HDMS.Model.Users;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmAddReferral : Form
    {
        bool unlocked = true;

        public frmAddReferral()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            ReferralCategory _refCat = (ReferralCategory)cmbRefType.SelectedItem;


            double _consultancyFee1 = 0;
            double _consultancyFee2 = 0;
            double _consultancyFee3 = 0;
            double _consultancyFee4 = 0;
            double _IPDConsultancy = 0;
            double _consultancyFeeReportOpinion = 0;
            double _HpPercent = 0;
            double _CpPercent = 0;
            
            double.TryParse(txtCFBrandNew.Text, out _consultancyFee1);
            double.TryParse(txtCFNew.Text, out _consultancyFee2);
            double.TryParse(txtCFOld.Text, out _consultancyFee3);
            double.TryParse(txtCFGuestOrStaff.Text, out _consultancyFee4);
            double.TryParse(txtCFIDP.Text, out _IPDConsultancy);
            double.TryParse(txtCFReportOpinion.Text, out _consultancyFeeReportOpinion);
            double.TryParse(txtCpPercent.Text, out _CpPercent);
            double.TryParse(txtHpPercent.Text, out _HpPercent);

            double _selfDiscount = 0;
            double.TryParse(txtSelfDiscount.Text, out _selfDiscount);

            double _requestDiscountAdjust = 0;
            double.TryParse(txtRequestAdjustment.Text, out _requestDiscountAdjust);

            int _deptId = 0; 
            int _cateId = 0; 
            HpDepartment _dept = cmbDept.SelectedItem as HpDepartment;
            _deptId = _dept.DeptId;
            _cateId = _refCat.RefCategoryId;

            if (_refCat.RefCategoryId == 0)
            {
                MessageBox.Show("Ref. category required.");
                return;
            }

            if (txtDoctorSearch.Tag != null)
            {
                Doctor _doc = new DoctorService().GetDoctorById(Convert.ToInt32(txtDoctorSearch.Tag));

                _doc.Name = txtReferral.Text;
                _doc.ConsultancyFee1 = _consultancyFee1;
                _doc.ConsultancyFee2 = _consultancyFee2;
                _doc.ConsultancyFee3 = _consultancyFee3;
                _doc.ConsultancyFee4 = _consultancyFee4;
                _doc.IPDConsultancyFee = _IPDConsultancy;
                _doc.ConsultancyFeeReportOpinion = _consultancyFeeReportOpinion;
                _doc.RefCategoryId = _cateId;
                _doc.DeptId = _deptId;
                _doc.OPDConsultantCategoryId = _cateId;
                _doc.ConsultancyFeeReportOpinion = _consultancyFeeReportOpinion;
                _doc.CpPercent = _CpPercent;
                _doc.HpPercent = _HpPercent;
                _doc.OPDConsultantCategoryId = 0;
                if (rdNo.Checked)
                {
                    _doc.IsSelfFullFree = false;
                }
                else
                {
                    _doc.IsSelfFullFree = true;
                }

                _doc.IsOPDConsultant = rdIsOPDYes.Checked;

               if(new DoctorService().UpdateDoctorRecord(_doc))
               {

                    MessageBox.Show("Doctor record updated successful.");
                    ClearFields();
               }
            }
            else
            {

                if (!String.IsNullOrEmpty(txtReferral.Text))
                {
                    if (!new DoctorService().IsExists(txtReferral.Text))
                    {

                        Doctor _doctor = new Doctor();
                        _doctor.Name = txtReferral.Text;
                        _doctor.ConsultancyFee1 = _consultancyFee1;
                        _doctor.ConsultancyFee2 = _consultancyFee2;
                        _doctor.ConsultancyFee3 = _consultancyFee3;
                        _doctor.ConsultancyFee4 = _consultancyFee4;
                        _doctor.IPDConsultancyFee = _IPDConsultancy;
                        _doctor.ConsultancyFeeReportOpinion = _consultancyFeeReportOpinion;
                        _doctor.RefCategoryId = _cateId;
                        if (rdNo.Checked)
                        {
                            _doctor.IsSelfFullFree = false;
                        }
                        else
                        {
                            _doctor.IsSelfFullFree = true;
                        }

                        _doctor.IsOPDConsultant = rdIsOPDYes.Checked;

                        _doctor.SelfDiscountAllowed = _selfDiscount;
                        _doctor.RequestedPatientDiscountAdjustFromRefDoctor = _requestDiscountAdjust;
                        _doctor.UserId = 1;


                        string msg = new DoctorService().SaveNewReferral(_doctor);
                        MessageBox.Show(msg, "HERP");
                         ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Doctor already exists.", "HERP");
                    }

                }
            }
        }

        private void ClearFields()
        {
            txtDoctorSearch.Tag = null;
            txtReferral.Text = "";
            rdIsOPDNo.Checked = true;
            LoadDepartments(0);
            LoadConsultantCategories(0);
            txtCFBrandNew.Text = "";
            txtCFNew.Text = "";
            txtCFReportOpinion.Text = "";
            txtCFOld.Text = "";
            txtCFIDP.Text = "";
            txtCFGuestOrStaff.Text = "";
            txtHpPercent.Text = "";
            txtCpPercent.Text = "";
            txtRequestAdjustment.Text = "";
            txtSelfDiscount.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmAddReferral_Load(object sender, EventArgs e)
        {

            ctlDoctorSearch.Location = new Point(txtDoctorSearch.Location.X, txtDoctorSearch.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;


            List<ReferralCategory> _rcList = new DoctorService().GetRefCategories();
            _rcList.Insert(0, new ReferralCategory() { RefCategoryId = 0, Name = "Select Category" });
            cmbRefType.DataSource = _rcList;
            cmbRefType.DisplayMember = "Name";
            cmbRefType.ValueMember = "RefCategoryId";

            SetOPDStatus(false);

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            if (_user.RoleId==1 || _user.RoleId == 2 || _user.RoleId == 10)
            {
                rdIsOPDNo.Enabled = true;
                rdIsOPDYes.Enabled = true;

            }else
            {
                rdIsOPDNo.Enabled = false;
                rdIsOPDYes.Enabled = false;
            }

        }

        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtDoctorSearch.Text = item.Name;
            txtDoctorSearch.Tag = item.DoctorId;
            txtReferral.Text= item.Name;
            
             LoadDepartments(item.DeptId);
             LoadConsultantCategories(item.OPDConsultantCategoryId);

                txtSelfDiscount.Text = item.SelfDiscountAllowed.ToString();
                
                txtCFBrandNew.Text = item.ConsultancyFee1.ToString();
                txtCFNew.Text= item.ConsultancyFee2.ToString();
                txtCFOld.Text = item.ConsultancyFee3.ToString();
                txtCFGuestOrStaff.Text = item.ConsultancyFee4.ToString();
                txtCFIDP.Text = item.IPDConsultancyFee.ToString();
                txtCFReportOpinion.Text = item.ConsultancyFeeReportOpinion.ToString();
                txtHpPercent.Text =  item.HpPercent.ToString();
                txtCpPercent.Text = item.CpPercent.ToString();
                rdIsOPDYes.Checked = true;   
           
            unlocked = true;
            sender.Visible = false;
          
        }

        private void SetOPDStatus(bool _sts)
        {
            cmbDept.Enabled = _sts;
            cmbConsultancyType.Enabled = _sts;
            txtCFBrandNew.Enabled = _sts;
            txtHpPercent.Enabled = _sts;
            txtCpPercent.Enabled = _sts;

            LoadDepartments(0);
            LoadConsultantCategories(0);

        }

        private void LoadConsultantCategories(int _cateId)
        {
            List<HpOPDConsultantCategory> _ccateList = new HospitalService().GetHpOPDConsultantCategories();
            _ccateList.Insert(0, new HpOPDConsultantCategory() { CategoryId = 0, Name = "Select Type" });
            cmbConsultancyType.DataSource = _ccateList;
            cmbConsultancyType.DisplayMember = "Name";
            cmbConsultancyType.ValueMember = "CategoryId";

            if (_cateId > 0)
            {
                cmbDept.SelectedItem = _ccateList.Where(x => x.CategoryId == _cateId);
            }

        }

        private void LoadDepartments(int _dept)
        {
            List<HpDepartment> _depts = new HospitalService().GetHpDepartments();
            _depts.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Dept." });
            cmbDept.DataSource = _depts;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";

            if (_dept > 0)
            {
                cmbDept.SelectedItem = _depts.Where(x => x.DeptId == _dept);
            }
        }

        private void rdIsOPDYes_Click(object sender, EventArgs e)
        {
            if (rdIsOPDYes.Checked)
            {
                SetOPDStatus(true);
            }
        }

        private void rdIsOPDNo_Click(object sender, EventArgs e)
        {
            if (rdIsOPDNo.Checked)
            {
                SetOPDStatus(true);
            }
        }

        private void txtDoctorSearch_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtDoctorSearch.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtDoctorSearch.Text;
                    HideAllDefaultHidden();
                    ctlDoctorSearch.Visible = true;
                    ctlDoctorSearch.txtSearch.Text = _txt;
                    ctlDoctorSearch.txtSearch.SelectionStart = ctlDoctorSearch.txtSearch.Text.Length;

                    ctlDoctorSearch.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible=false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlDoctorSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDoctorSearch.Focus();
            }
        }
    }
}
