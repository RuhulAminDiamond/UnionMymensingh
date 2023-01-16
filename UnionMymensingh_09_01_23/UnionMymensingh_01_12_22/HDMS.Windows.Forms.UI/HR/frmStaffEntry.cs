using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model.HR;

using HDMS.Model.Location;
using HDMS.Service.Common;
using HDMS.Service.HR;
using HDMS.Windows.Forms.UI.Reports.HR;
using HRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmStaffEntry : Form
    {
        bool isLoaded = false;
       

        public frmStaffEntry()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmpDivision _division = (EmpDivision)cmbDivision.SelectedItem;
            EmpDepartment _dept = (EmpDepartment)cmbDept.SelectedItem;
            EmpDesignation _desig = (EmpDesignation)cmbDesignation.SelectedItem;

            if (_dept.DeptId == 0)
            {
                MessageBox.Show("Department not selected"); return;
            }

            if (_desig.DesignationId == 0)
            {
                MessageBox.Show("Designation not selected"); return;
            }

            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Employee name required.");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtEmployeeNo.Text))
            {
                MessageBox.Show("Employee no required.");
                return;
            }

            bool _IsHoD = false;
            if (radYes.Checked)
            {
                _IsHoD = true;
            }

            if (txtName.Tag != null)
            {
                EmployeeInfo _employee = txtName.Tag as EmployeeInfo;

                _employee.EmployeeNo = txtEmployeeNo.Text;
                _employee.EmployeeName = txtName.Text;
                _employee.FatherName = txtFatherName.Text;
                _employee.MotherName = txtMotherName.Text;
                _employee.BloodGroup = cmbBloodGroup.Text;
                _employee.DateofBirth = dtpDateofBirth.Value;
                _employee.Sex = cmbSex.Text;
                _employee.Religion = cmbReligion.Text;
                _employee.Nationality = new EmployeeService().GetCountryByName(cmbNationality.Text).CountryId;

                _employee.NationIDorPPNo = txtNationIDorPPNo.Text;
                _employee.MaritalStatus = cmbMaritalStatus.Text;
                _employee.PermanentAddress = txtPermanentAddress.Text;
                _employee.PresentAddress = txtPresentAddress.Text;
                _employee.District = txtDistrict.Text;
                _employee.Thana = txtThana.Text;
                _employee.PostOffice = txtPostOffice.Text;
                _employee.CareOf = txtCareOf.Text;
                _employee.MobileNo = txtMobileNo.Text;

                _employee.EmailId = txtEmail.Text;
                _employee.EmpDivisionId = _division.DivId;
                _employee.DeptId = _dept.DeptId;
                _employee.DesignationId = _desig.DesignationId;
                _employee.IsHoD = _IsHoD;
                _employee.Confirmationdate = dtpConfirm.Value;
                _employee.JoiningDate = dtpJoin.Value;
                _employee.experience = txtexperience.Text;
                _employee.JoiningSalry = Convert.ToDouble( txtJoiningSalary.Text);
                _employee.WorkingHouse = Convert.ToDouble(txtDutyHourse.Text);

                List<EmployeeEducationalQualification> _EmpEduQualification = new List<EmployeeEducationalQualification>();


                foreach (DataGridViewRow row in dgEducationalQualification.Rows)
                {
                    EmployeeEducationalQualification _SelectedServices = row.Tag as EmployeeEducationalQualification;

                    EmployeeEducationalQualification EmpEducationQualification = new EmployeeEducationalQualification();
                    EmpEducationQualification.EmployeeId = _employee.EmployeeId;
                    EmpEducationQualification.NameOfExam = _SelectedServices.NameOfExam;
                    EmpEducationQualification.Passingyear = _SelectedServices.Passingyear;
                    EmpEducationQualification.Department = _SelectedServices.Department;
                    EmpEducationQualification.GPA = _SelectedServices.GPA;
                    EmpEducationQualification.Board = _SelectedServices.Board;
                    _EmpEduQualification.Add(EmpEducationQualification);
                }

                new HrCommonService().SaveEmployeeEducationalQualification(_EmpEduQualification);


                if (new EmployeeService().UpdateEmployee(_employee))
                {
                    MessageBox.Show("Employee information updated successfully.");
                    SaveProfileImage(_employee.EmployeeId);
                    txtName.Tag = null;
                    ClearFields();
                }
            }
            else
            {
                EmployeeInfo _emp = new EmployeeInfo();
                _emp.EmployeeNo = txtEmployeeNo.Text;
                _emp.EmployeeName = txtName.Text;
                _emp.FatherName = txtFatherName.Text;
                _emp.MotherName = txtMotherName.Text;
                _emp.BloodGroup = cmbBloodGroup.Text;
                _emp.DateofBirth = dtpDateofBirth.Value;
                _emp.Sex = cmbSex.Text;
                _emp.Religion = cmbReligion.Text;
                _emp.Nationality = ((Country)cmbNationality.SelectedItem).CountryId;

                _emp.NationIDorPPNo = txtNationIDorPPNo.Text;
                _emp.MaritalStatus = cmbMaritalStatus.Text;
                _emp.PermanentAddress = txtPermanentAddress.Text;
                _emp.PresentAddress = txtPresentAddress.Text;
                _emp.District = txtDistrict.Text;
                _emp.Thana = txtThana.Text;
                _emp.PostOffice = txtPostOffice.Text;
                _emp.CareOf = txtCareOf.Text;
                _emp.MobileNo = txtMobileNo.Text;

                _emp.EmailId = txtEmail.Text;
                _emp.EmpDivisionId = _division.DivId;
                _emp.DeptId = _dept.DeptId;
                _emp.DesignationId = _desig.DesignationId;
                _emp.IsHoD = _IsHoD;
                _emp.Confirmationdate = dtpConfirm.Value;
                _emp.JoiningDate = dtpJoin.Value;
                _emp.experience = txtexperience.Text;
                _emp.JoiningSalry =Convert.ToDouble( txtJoiningSalary.Text);
                _emp.WorkingHouse = Convert.ToDouble(txtDutyHourse.Text);

                long _empId = new EmployeeService().SaveStaffInfo(_emp);


                List<EmployeeEducationalQualification> _EmpEduQualification = new List<EmployeeEducationalQualification>();


                foreach (DataGridViewRow row in dgEducationalQualification.Rows)
                {
                    EmployeeEducationalQualification _SelectedServices = row.Tag as EmployeeEducationalQualification;

                    EmployeeEducationalQualification EmpEducationQualification = new EmployeeEducationalQualification();
                    EmpEducationQualification.EmployeeId = _empId;
                    EmpEducationQualification.NameOfExam = _SelectedServices.NameOfExam;
                    EmpEducationQualification.Passingyear = _SelectedServices.Passingyear;
                    EmpEducationQualification.Department = _SelectedServices.Department;
                    EmpEducationQualification.GPA = _SelectedServices.GPA;
                    EmpEducationQualification.Board = _SelectedServices.Board;
                    _EmpEduQualification.Add(EmpEducationQualification);
                }

                new HrCommonService().SaveEmployeeEducationalQualification(_EmpEduQualification);

                if (_empId > 0)
                {
                    MessageBox.Show("Employee info added successfully.");
                    SaveProfileImage(_empId);
                    PrintPreviewProfile(_empId);
                    ClearFields();
                }
            }

        }

        private void SaveProfileImage(long _employeeId)
        {
            string _conString = Configuration.ConnectionString;
            SqlConnection con = new SqlConnection(_conString);
            try
            {
                string qry = string.Empty;
                SqlCommand SqlCom;

                byte[] imagedata = GetImagebyte();

                qry = @"
                    DELETE FROM EmpProfileImages WHERE EmployeeId = @EmployeeId
                    insert into EmpProfileImages (EmployeeId,ProfileImage) values(@EmployeeId, @ProfileImage)";
                SqlCom = new SqlCommand(qry, con);

                SqlCom.Parameters.Add(new SqlParameter("@EmployeeId", (object)_employeeId));
                SqlCom.Parameters.Add(new SqlParameter("@ProfileImage", (object)imagedata));

                //Open connection and execute insert query.
                con.Open();
                SqlCom.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }

        private byte[] GetImagebyte()
        {
            ImageConverter imgConverter = new ImageConverter();
            byte[] imgBytes = (byte[])imgConverter.ConvertTo(PIC_PROFILE.Image, Type.GetType("System.Byte[]"));
            return imgBytes;
        }


        private void ClearFields()
        {
            txtEmployeeNo.Text = "";
            txtName.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            LoadBloodGroups();
            LoadGenders();
            LoadReligions();
            LoadNationality(1);

            txtNationIDorPPNo.Text = "";
            LoadMaritalStatus();
            txtPermanentAddress.Text = "";
            txtPresentAddress.Text = "";
            txtDistrict.Text = "";
            txtThana.Text = "";
            txtPostOffice.Text = "";
            txtCareOf.Text = "";
            txtMobileNo.Text = "";
            txtJoiningSalary.Text = "";
            txtexperience.Text = "";
            txtDutyHourse.Text = "";

            txtEmail.Text = "";
            LoadEmpDivisions(0);
            LoadDesignations(0);
            //LoadDepartments(0);
            radNo.Checked = true;

            txtName.Tag = null;
            LoadProfileImage(0);

            LoadEmployee();
            dgEducationalQualification.SuspendLayout();
            dgEducationalQualification.Rows.Clear();


        }

        private IList<EmployeeEducationalQualification> _SelectedServices;

       

        private void frmStaffEntry_Load(object sender, EventArgs e)
        {
            // LoadDepartments(0);

            _SelectedServices = new List<EmployeeEducationalQualification>();

            LoadDesignations(0);

            LoadNationality(1);

            LoadEmpDivisions(0);

            LoadBloodGroups();

            LoadMaritalStatus();

            LoadGenders();

            LoadReligions();

            LoadEmployee();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }



        }


        private void LoadReligions()
        {
            List<Religion> _rList = new EmployeeService().GetReligions();
            _rList.Insert(0, new Religion() { Id = 0, Name = "Select Religion" });
            cmbReligion.DataSource = _rList;
            cmbReligion.DisplayMember = "Name";
            cmbReligion.ValueMember = "Id";
        }

        private void LoadGenders()
        {
            List<Gender> _genList = new EmployeeService().GetGenders();
            _genList.Insert(0, new Gender() { Id = 0, Name = "Select Gender" });
            cmbSex.DataSource = _genList;
            cmbSex.DisplayMember = "Name";
            cmbSex.ValueMember = "Id";
        }

        private void LoadMaritalStatus()
        {
            List<MaritalStatus> _msts = new EmployeeService().GetMaritalStatus();
            _msts.Insert(0, new MaritalStatus() { Id = 0, Status = "Select Status" });
            cmbMaritalStatus.DataSource = _msts;
            cmbMaritalStatus.DisplayMember = "Status";
            cmbMaritalStatus.ValueMember = "Id";
        }

        private void LoadBloodGroups()
        {
            List<BloodGroup> _bgList = new EmployeeService().GetBloodGroups();
            _bgList.Insert(0, new BloodGroup() { Id = 0, BGType = "Select Blood Group" });
            cmbBloodGroup.DataSource = _bgList;
            cmbBloodGroup.DisplayMember = "BGType";
            cmbBloodGroup.ValueMember = "Id";
        }

        private void LoadEmpDivisions(int divisionId)
        {
            List<EmpDivision> _empDivisions = new EmployeeService().GetEmpDivisions();
            _empDivisions.Insert(0, new EmpDivision() { DivId = 0, Name = "Select Division" });
            cmbDivision.DataSource = _empDivisions;
            cmbDivision.DisplayMember = "Name";
            cmbDivision.ValueMember = "DivId";

            if (divisionId > 0)
            {
                cmbDivision.SelectedItem = _empDivisions.Find(q => q.DivId == divisionId);
            }
        }

        private void LoadNationality(int CountryId)
        {
            List<Country> _cList = new LocationService().GetAllCountry();
            cmbNationality.DataSource = _cList;
            cmbNationality.DisplayMember = "Name";
            cmbNationality.ValueMember = "CountryId";
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

            ctrl.BackColor = Color.NavajoWhite;
        }


        private void LoadEmployee()
        {
            List<VMEmployeeInfo> _empInfo = new EmployeeService().GetAll();
            dgEmployee.Tag = _empInfo;
            FileEmpGrid(_empInfo);
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


                row.CreateCells(dgEmployee, item.EmployeeId, item.EmployeeName, item.DeptName, item.Designation, item.JoiningDate.ToString("dd/MM/yyyy"));
                dgEmployee.Rows.Add(row);


            }

        }

        private void LoadDesignations(int _desigId)
        {

            isLoaded = false;

            List<EmpDesignation> desigList = new HrCommonService().GetDesignations().ToList();
            desigList.Insert(0, new EmpDesignation() { DesignationId = 0, Name = "Select Desination" });
            cmbDesignation.DataSource = desigList;
            cmbDesignation.DisplayMember = "Name";
            cmbDesignation.ValueMember = "Id";

            if (_desigId > 0)
            {
                cmbDesignation.SelectedItem = desigList.Find(q => q.DesignationId == _desigId);
            }

            isLoaded = true;
        }


        private void LoadDepartments(int _deptId)
        {
            EmpDepartment _empDept = new HrCommonService().GetDeptById(_deptId);
            if (_empDept != null)
            {
                List<EmpDivision> _divList = new HrCommonService().GetAllDivision();
                cmbDivision.DataSource = _divList;
                cmbDivision.DisplayMember = "Name";
                cmbDivision.ValueMember = "DivId";

                cmbDivision.SelectedItem = _divList.Find(q => q.DivId == _empDept.DivId);

                List<EmpDepartment> deptList = new HrCommonService().GetDepartmentsByDivId(_empDept.DivId).ToList();
                deptList.Insert(0, new EmpDepartment() { DeptId = 0, Name = "Select Dept" });
                cmbDept.DataSource = deptList;
                cmbDept.DisplayMember = "Name";
                cmbDept.ValueMember = "DeptId";

                cmbDept.SelectedItem = deptList.Find(q => q.DeptId == _deptId);

            }


        }


        private void LoadDepartmentsByDivision(int _divId)
        {
            List<EmpDepartment> deptList = new HrCommonService().GetAllDepartments().ToList();
            deptList.Insert(0, new EmpDepartment() { DeptId = 0, Name = "Select Dept" });
            cmbDept.DataSource = deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";

            //if (_deptId > 0)
            //{
            //    cmbDept.SelectedItem = deptList.Find(q => q.DeptId == _deptId);
            //}
        }

        private void dgEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMEmployeeInfo selectedEmployee = dgEmployee.SelectedRows[0].Tag as VMEmployeeInfo;

            EmployeeInfo employee = new EmployeeService().GetEmployeeById(selectedEmployee.EmployeeId);

            txtEmployeeNo.Text = employee.EmployeeNo;
            txtName.Text = employee.EmployeeName;
            txtFatherName.Text = employee.FatherName;
            txtMotherName.Text = employee.MotherName;
            cmbBloodGroup.Text = employee.BloodGroup;
            dtpDateofBirth.Value = employee.DateofBirth;
            cmbSex.Text = employee.Sex;
            cmbReligion.Text = employee.Religion;
            cmbNationality.Text = new EmployeeService().GetCountryById(employee.Nationality).Name;

            txtNationIDorPPNo.Text = employee.NationIDorPPNo;
            cmbMaritalStatus.Text = employee.MaritalStatus;
            txtPermanentAddress.Text = employee.PermanentAddress;
            txtPresentAddress.Text = employee.PresentAddress;
            txtDistrict.Text = employee.District;
            txtThana.Text = employee.Thana;
            txtPostOffice.Text = employee.PostOffice;
            txtCareOf.Text = employee.CareOf;
            txtMobileNo.Text = employee.MobileNo;
            txtexperience.Text = employee.experience;
            txtJoiningSalary.Text = employee.JoiningSalry.ToString();
            txtDutyHourse.Text = employee.WorkingHouse.ToString();

            txtEmail.Text = employee.EmailId;
            LoadEmpDivisions(employee.EmpDivisionId);
            LoadDepartments(employee.DeptId);
            LoadDesignations(employee.DesignationId);
            if (employee.IsHoD) radYes.Checked = true;
            else radNo.Checked = true;
            dtpConfirm.Value = employee.Confirmationdate;
            dtpJoin.Value = employee.JoiningDate;

            LoadProfileImage(employee.EmployeeId);

            txtName.Tag = employee;

            
                List<EmployeeEducationalQualification> emedu = new HrCommonService().GetEmployeeEducation(selectedEmployee.EmployeeId).ToList();

                FilGrid(emedu);

        }

        private void FilGrid(List<EmployeeEducationalQualification> emedu)
        {
            dgEducationalQualification.SuspendLayout();
            dgEducationalQualification.Rows.Clear();
            foreach (EmployeeEducationalQualification item in emedu)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgEducationalQualification, item.NameOfExam, item.Passingyear, item.Department, item.GPA, item.Board);
                dgEducationalQualification.Rows.Add(row);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Tag = null;
            txtEmployeeNo.Tag = null;
            ClearFields();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                PIC_PROFILE.Image = new Bitmap(open.FileName);
                // image file path  
                // textBox1.Text = open.FileName;
            }
        }

        private void txtEmployeeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadEmployee(txtEmployeeNo.Text);
                txtName.Focus();
            }
        }

        private void LoadEmployee(string _employeeNo)
        {
            EmployeeInfo _employee = new EmployeeService().GetEmployeeByEmployeeNo(_employeeNo);
            if (_employee != null)
            {
                txtEmployeeNo.Tag = _employee;

                txtEmployeeNo.Text = _employee.EmployeeNo;
                txtName.Text = _employee.EmployeeName; ;
                txtFatherName.Text = _employee.FatherName;
                txtMotherName.Text = _employee.MotherName;
                cmbBloodGroup.Text = _employee.BloodGroup;
                cmbSex.Text = _employee.Sex;
                cmbReligion.Text = _employee.Religion;


                txtNationIDorPPNo.Text = _employee.NationIDorPPNo;
                cmbMaritalStatus.Text = _employee.MaritalStatus;

                txtPermanentAddress.Text = _employee.PermanentAddress;
                txtPresentAddress.Text = _employee.PresentAddress;
                txtMobileNo.Text = _employee.MobileNo;
                txtEmail.Text = _employee.EmailId;


                LoadProfileImage(_employee.EmployeeId);

            }
        }

        private void LoadProfileImage(long employeeId)
        {
            if (employeeId > 0)
            {
                string _conString = Configuration.ConnectionString;
                SqlConnection con = new SqlConnection(_conString);
                try
                {
                    string qry = string.Empty;
                    qry = string.Format(@"SELECT ProfileImage FROM EmpProfileImages WHERE EmployeeId = {0}", employeeId);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand(qry, con));
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        Byte[] data = new Byte[0];
                        data = (Byte[])(dataSet.Tables[0].Rows[0]["ProfileImage"]);
                        MemoryStream mem = new MemoryStream(data);
                        PIC_PROFILE.Image = Image.FromStream(mem);
                    }
                    else
                    {
                        PIC_PROFILE.Image = null;
                    }
                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                PIC_PROFILE.Image = null;
            }
        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtEmployeeNo.Text))
            {
                EmployeeInfo _emp = (EmployeeInfo)txtEmployeeNo.Tag;
                _emp = new EmployeeService().GetEmployeeById(_emp.EmployeeId - 1);
                if (_emp != null)
                {
                    LoadEmployee(_emp.EmployeeNo);
                }

            }
            else
            {
                EmployeeInfo _emp = new EmployeeService().GetLastEmployee();
                if (_emp != null)
                {
                    LoadEmployee(_emp.EmployeeNo);
                }
            }
        }

        private void btnNextId_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtEmployeeNo.Text) && txtEmployeeNo.Tag != null)
            {
                EmployeeInfo _emp = (EmployeeInfo)txtEmployeeNo.Tag;
                _emp = new EmployeeService().GetEmployeeById(_emp.EmployeeId + 1);
                if (_emp != null)
                {
                    LoadEmployee(_emp.EmployeeNo);
                }

            }
            else
            {
                EmployeeInfo _emp = new EmployeeService().GetFirstEmployee();
                if (_emp != null)
                {
                    LoadEmployee(_emp.EmployeeNo);
                }
            }
        }

        private void dgEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrintProfile_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                EmployeeInfo _emp = (EmployeeInfo)txtName.Tag;
                PrintPreviewProfile(_emp.EmployeeId);
            }
        }

        private void PrintPreviewProfile(long employeeId)
        {
            DataSet ds = new EmployeeService().GetEmployeeDetailsById(employeeId);

            rptEmployeeProfile _rpt = new rptEmployeeProfile();
            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        // Get Print Employee Id Card
        //private void PrintEmployeeIdCard(long employeeId)
        //{
        //    DataSet ds = new EmployeeService().GetEmployeeIdCardPrint(employeeId);

        //    rptEmployeeIdCard _rpt = new rptEmployeeIdCard();
        //    _rpt.SetDataSource(ds.Tables[0]);

        //    ReportViewer rv = new ReportViewer();

        //    rv.crviewer.ReportSource = _rpt;
        //    rv.crviewer.ToolPanelView = ToolPanelViewType.None;
        //    rv.crviewer.PrintReport();
        //    rv.Show();

        //}

        private void txtEmployeeNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void cmbBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateofBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMotherName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFatherName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                EmpDivision _division = (EmpDivision)cmbDivision.SelectedItem;
                if (_division != null)
                {
                    List<EmpDepartment> deptList = new HrCommonService().GetDepartmentsByDivId(_division.DivId).ToList();
                    deptList.Insert(0, new EmpDepartment() { DeptId = 0, Name = "Select Dept" });
                    cmbDept.DataSource = deptList;
                    cmbDept.DisplayMember = "Name";
                    cmbDept.ValueMember = "DeptId";
                }


            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            List<VMEmployeeInfo> _empInfo = dgEmployee.Tag as List<VMEmployeeInfo>;
            if (_empInfo == null)
                return;

            if (string.IsNullOrWhiteSpace(txtSearchByName.Text) || txtSearchByName.Text.Trim() == "Employee Name Name")
            {
                LoadOpdDueList();
            }
            else
            {
                LoadEmployeelist(_empInfo);

            }
        }

        private void LoadEmployeelist(List<VMEmployeeInfo> _empInfo)
        {
            _empInfo = _empInfo.Where(x => x.EmployeeName.ToLower().Contains(txtSearchByName.Text.ToLower())).ToList();
            FileEmpGrid(_empInfo);
        }

        private void LoadOpdDueList()
        {
            List<VMEmployeeInfo> _empInfo = new EmployeeService().GetAll();
            dgEmployee.Tag = _empInfo;
            FileEmpGrid(_empInfo);
        }

        private void LoadEmployeebyName(string ename, string type)
        {
            List<VMEmployeeInfo> _empList = new HrCommonService().GetEmployeeByName(ename, type);
            FileEmpGrid(_empList);
        }

        private void btnIdcard_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {

                VMEmployeeInfo _emp = (VMEmployeeInfo)txtName.Tag;
               // PrintEmployeeIdCard(_emp.EmployeeId);

            }
            else if (!String.IsNullOrWhiteSpace(txtEmployeeNo.Text))
            {
                EmployeeInfo _emp = (EmployeeInfo)txtEmployeeNo.Tag;
                _emp = new EmployeeService().GetEmployeeById(_emp.EmployeeId - 1);
                if (_emp != null)
                {
                   // PrintEmployeeIdCard(_emp.EmployeeId);
                }

            }



        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void PIC_PROFILE_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadSignature_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picSignature.Image = new Bitmap(open.FileName);
            }
        }

        private void txtExamName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtpassingYear.Focus();
            }
        }

        private void txtpassingYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtDepatment.Focus();
            }
        }

        private void txtDepatment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtGPA.Focus();
            }
        }

        private void txtGPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtBoard.Focus();
            }
        }

        private void txtBoard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int _passingYear = 0;
                int.TryParse(txtpassingYear.Text, out _passingYear);

                new EmployeeService().PopulateSelectedServices(_SelectedServices, txtExamName.Text, _passingYear, txtDepatment.Text, txtGPA.Text, txtBoard.Text);
                FillServiceGrid();
                txtExamName.Text = "";
                txtpassingYear.Text = "";
                txtBoard.Text = "";
                txtGPA.Text = "";
                txtDepatment.Text = "";

                txtExamName.Focus();
            }
        }

        private void FillServiceGrid()
        {
            dgEducationalQualification.SuspendLayout();
            dgEducationalQualification.Rows.Clear();
            foreach (EmployeeEducationalQualification item in _SelectedServices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgEducationalQualification, item.NameOfExam, item.Passingyear, item.Department, item.GPA, item.Board);
                dgEducationalQualification.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtFatherName.Focus();
            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtMotherName.Focus();
            }
        }

        private void txtMotherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbBloodGroup.Focus();
            }
        }

        private void cmbBloodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                dtpDateofBirth.Focus();
            }
        }

        private void dtpDateofBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbSex.Focus();
            }
        }

        private void cmbReligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbNationality.Focus();
            }
        }

        private void cmbSex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbReligion.Focus();
            }
        }

        private void cmbNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtNationIDorPPNo.Focus();
            }
        }

        private void txtNationIDorPPNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbMaritalStatus.Focus();
            }
        }

        private void cmbMaritalStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtPermanentAddress.Focus();
            }
        }

        private void txtPermanentAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtPresentAddress.Focus();
            }
        }

        private void txtPresentAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtDistrict.Focus();
            }
        }

        private void txtDistrict_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtThana.Focus();
            }
        }

        private void txtThana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtPostOffice.Focus();
            }
        }

        private void txtPostOffice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(Char)Keys.Enter)
            {
                txtCareOf.Focus();
            }
        }

        private void txtCareOf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtMobileNo.Focus();
            }
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbDivision.Focus();
            }
        }

        private void txtDutyHourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtJoiningSalary.Focus();
            }
        }

        private void cmbDivision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbDept.Focus();
            }
        }

        private void cmbDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                cmbDesignation.Focus();
            }
        }

        private void cmbDesignation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                dtpConfirm.Focus();
            }
        }

        private void dtpConfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                dtpJoin.Focus();
            }
        }

        private void dtpJoin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtDutyHourse.Focus();
            }
        }

        private void txtJoiningSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtexperience.Focus();
            }
        }
    }
}
