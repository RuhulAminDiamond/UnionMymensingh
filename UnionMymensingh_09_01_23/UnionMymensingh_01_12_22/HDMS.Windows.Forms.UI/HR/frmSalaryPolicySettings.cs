using HDMS.Model.HR;
using HDMS.Service.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmSalaryPolicySettings : Form
    {

        bool isLoaded = false;
        List<VMEmployeeInfo> _empInfolist;
        public frmSalaryPolicySettings()
        {
            InitializeComponent();
        }

        private void frmSalarySettings_Load(object sender, EventArgs e)
        {
            isLoaded = false;

            LoadEmployess();

           

            isLoaded = true;
        }

        private void LoadEmployess()
        {
             _empInfolist = new EmployeeService().GetAll();
            FileEmpGrid(_empInfolist);
        }

        private void FileEmpGrid(List<VMEmployeeInfo> _empList)
        {
            dgEmployee.SuspendLayout();
            dgEmployee.Rows.Clear();
            foreach (VMEmployeeInfo item in _empList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;


                row.CreateCells(dgEmployee,item.EmployeeName, item.Designation, item.JoiningDate);
                dgEmployee.Rows.Add(row);


            }

        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (lblName.Tag == null)
            {
                MessageBox.Show("Employee not selected."); return;
            }

            VMEmployeeInfo _empInfo = (VMEmployeeInfo)lblName.Tag;

            double _basicAmount = 0;
            double _houseRentInPercent = 0;
            double _medicalAllownceInPercent = 0;
            double _mobileAllownceTk = 0;
            double _transportAllownce = 0;
            double _festivalBonusInPercent = 0;
            double _overTimePerhour = 0;
            double _lateDeductionPerhour = 0;
            double _taxdeduction = 0;
            double _pfdeduction = 0;
            double _insurancededuction = 0;
            double total = 0;
            double.TryParse(txtTotalAmount.Text,out total);
            double.TryParse(txtBasicSalary.Text, out _basicAmount);
            double.TryParse(txtHouseRent.Text, out _houseRentInPercent);
            double.TryParse(txtMedicalAllownce.Text, out _medicalAllownceInPercent);
            double.TryParse(txtMobileAllownce.Text, out _mobileAllownceTk);
            double.TryParse(txtTransportAllownce.Text, out _transportAllownce);
            double.TryParse(txtFestivalBonus.Text, out _festivalBonusInPercent);
            double.TryParse(txtOvertime.Text, out _overTimePerhour);
            double.TryParse(txtLateDeduction.Text, out _lateDeductionPerhour);

            double.TryParse(txtTaxDeduction.Text, out _taxdeduction);
            double.TryParse(txtPFDeduction.Text, out _pfdeduction);
            double.TryParse(txtInsuranceDeduction.Text, out _insurancededuction);

            HRSalaryPolicy _sp = new HrCommonService().GetHrSalaryPolicyById(_empInfo.EmployeeId);

            if (_sp != null)
            {
                _sp.EmployeeId = _empInfo.EmployeeId;
                _sp.BasicAmount = _basicAmount;
                _sp.HouseRentInPercentOfBasic = _houseRentInPercent;
                _sp.MedicalAllownceInPercentOfBasic= _medicalAllownceInPercent;
                _sp.MobileAllownceTk = _mobileAllownceTk;
                _sp.TransportAllownceTk = _transportAllownce;
                _sp.FestivalBonusInPercentOfBasic = _festivalBonusInPercent;
                _sp.OvertimePerHour = _overTimePerhour;
                _sp.LateDeductionPerHour = _lateDeductionPerhour;
                _sp.TaxDeduction = _taxdeduction;
                _sp.PfDeduction = _pfdeduction;
                _sp.InsuranceDeduction = _insurancededuction;
                _sp.TotalSalary =total;
                if (new HrCommonService().UpdateSalaryPolicy(_sp))
                {
                    MessageBox.Show("Salary policy updated successfully.");

                    clearForm();
                }

            }
            else
            {
                _sp = new HRSalaryPolicy();

                _sp.EmployeeId = _empInfo.EmployeeId;
                _sp.BasicAmount = _basicAmount;
                _sp.HouseRentInPercentOfBasic = _houseRentInPercent;
                _sp.MedicalAllownceInPercentOfBasic = _medicalAllownceInPercent;
                _sp.MobileAllownceTk = _mobileAllownceTk;
                _sp.TransportAllownceTk = _transportAllownce;
                _sp.FestivalBonusInPercentOfBasic = _festivalBonusInPercent;
                _sp.OvertimePerHour = _overTimePerhour;
                _sp.LateDeductionPerHour = _lateDeductionPerhour;
                _sp.TaxDeduction = _taxdeduction;
                _sp.PfDeduction = _pfdeduction;
                _sp.InsuranceDeduction = _insurancededuction;
                _sp.TotalSalary =total;

                if (new HrCommonService().SaveSalaryPolicy(_sp))
                {
                    MessageBox.Show("Salary policy saved successfully.");

                    clearForm();
                }

            }
           
        }



        private void clearForm()
        {
            lblName.Tag = null;

            lblName.Text = "";
            lblDept.Text = "";

            txtBasicSalary.Text = "";
            txtFestivalBonus.Text = "";
            txtHouseRent.Text = "";
            txtInsuranceDeduction.Text = "";
            txtLateDeduction.Text = "";
            txtMedicalAllownce.Text = "";
            txtMobileAllownce.Text = "";
            txtOvertime.Text = "";
            txtPFDeduction.Text = "";
            txtTaxDeduction.Text = "";
            txtTotalAmount.Text = "";
            txtTransportAllownce.Text = "";
            txtTotalAmount.Text = "";
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {

            } 
        }

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {

            }
        }

        private void dgEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgEmployee.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgEmployee.SelectedRows[0];
                VMEmployeeInfo _empInfo = (VMEmployeeInfo)row.Tag;
                lblName.Tag = _empInfo;

                lblName.Text = _empInfo.EmployeeName;
                lblDept.Text = _empInfo.DeptName;
                
                LoadExistingPolicy(_empInfo.EmployeeId);

                txtTotalAmount.Focus();
            }
        }

        private void LoadExistingPolicy(long employeeId)
        {
            HRSalaryPolicy _sp= new HrCommonService().GetHrSalaryPolicyById(employeeId);

            if (_sp != null)
            {
                txtBasicSalary.Text = _sp.BasicAmount.ToString();
                txtHouseRent.Text = _sp.HouseRentInPercentOfBasic.ToString();
                txtMedicalAllownce.Text = _sp.MedicalAllownceInPercentOfBasic.ToString();
                txtMobileAllownce.Text = _sp.MobileAllownceTk.ToString();
                txtTransportAllownce.Text = _sp.TransportAllownceTk.ToString();
                txtFestivalBonus.Text = _sp.FestivalBonusInPercentOfBasic.ToString();
                txtOvertime.Text = _sp.OvertimePerHour.ToString();
                txtLateDeduction.Text = _sp.LateDeductionPerHour.ToString();
                txtTaxDeduction.Text= _sp.TaxDeduction.ToString();
                txtPFDeduction.Text = _sp.PfDeduction.ToString();
                txtInsuranceDeduction.Text = _sp.InsuranceDeduction.ToString();
                txtTotalAmount.Text =_sp.TotalSalary.ToString();
                txtBasicSalary.Tag = _sp;

            }else
            {
                txtBasicSalary.Text = "";
                txtHouseRent.Text = "";
                txtMedicalAllownce.Text = "";
                txtMobileAllownce.Text = "";
                txtTransportAllownce.Text = "";
                txtFestivalBonus.Text = "";
                txtOvertime.Text = "";
                txtLateDeduction.Text = "";
                txtTaxDeduction.Text = "";
                txtPFDeduction.Text = "";
                txtInsuranceDeduction.Text = "";

            }
        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _totalAmount = 0;
                double.TryParse(txtTotalAmount.Text, out _totalAmount);

                double _basicSalary = (_totalAmount * 60) / 100;
                double _houseRent= (_totalAmount * 20) / 100;
                double _medicalAllownce = (_totalAmount * 10) / 100;
                double _transportAllownce = (_totalAmount * 5) / 100;
                double _mobileAllownce = (_totalAmount * 5) / 100;

                txtBasicSalary.Text = _basicSalary.ToString();
                txtHouseRent.Text = _houseRent.ToString();
                txtMedicalAllownce.Text = _medicalAllownce.ToString();
                txtTransportAllownce.Text = _transportAllownce.ToString();
                txtMobileAllownce.Text = _mobileAllownce.ToString();
            }
        }

        private void dgEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchByName_TextChanged(object sender, EventArgs e)
        {
            if(_empInfolist!=null)
            {
                List<VMEmployeeInfo>  policieslist =_empInfolist.Where(x=>x.EmployeeName.ToLower().Contains(SearchByName.Text.ToLower())).ToList();
                FileEmpGrid(policieslist);
            }
        }
    }
}
