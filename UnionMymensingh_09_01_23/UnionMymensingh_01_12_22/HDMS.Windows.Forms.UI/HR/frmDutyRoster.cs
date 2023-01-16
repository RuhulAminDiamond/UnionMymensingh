using CrystalDecisions.Windows.Forms;
using HDMS.Model.HR;
using HDMS.Service.HR;
using HDMS.Windows.Forms.UI.Reports.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmDutyRoster : Form
    {
        public frmDutyRoster()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgEmployeeRoster.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgEmployeeRoster.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Tag != null)
            {
                
            }
            else
            {
               
            }
        }

        private void LoadData()
        {
            
            LoadDepartments(0);

            LoadDesignations(0);

        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Tag = null;
         
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (txtName.Tag != null)
            //{
            //    EmpDepartment _gr = new HrCommonService().GetDeptById(Convert.ToInt32(((EmpDepartment)txtName.Tag).DeptId));
            //    if (_gr != null)
            //    {
            //        if (new HrCommonService().DeleteDept(_gr))
            //        {
            //            MessageBox.Show("Successfully Deleted.");
            //            LoadData();
            //        }
            //    }

            //}
        }

      

        private void LoadDesignations(int _desigId)
        {
            List<EmpDesignation> desigList = new HrCommonService().GetDesignations().ToList();
            desigList.Insert(0, new EmpDesignation() { DesignationId = 0, Name = "Select Desination" });
            cmbDesignation.DataSource = desigList;
            cmbDesignation.DisplayMember = "Name";
            cmbDesignation.ValueMember = "Id";

            if (_desigId > 0)
            {
                cmbDesignation.SelectedItem = desigList.Find(q => q.DesignationId == _desigId);
            }
        }

        private void LoadDepartments(int _deptId)
        {
            List<EmpDepartment> deptList = new HrCommonService().GetAllDepartments().ToList();
            deptList.Insert(0, new EmpDepartment() { DeptId = 0, Name = "Select Employee" });
            cmbDept.DataSource = deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "Id";

            if (_deptId > 0)
            {
                cmbDept.SelectedItem = deptList.Find(q => q.DeptId == _deptId);
            }
        }

        private void LoadEmployees()
        {

            //IList<VMEmployeeInfo> _empInfo = ;
            EmpDepartment _dept = (EmpDepartment)cmbDept.SelectedItem;
            EmpDesignation _desig = (EmpDesignation)cmbDesignation.SelectedItem;


            IList<VMEmployeeInfo> empMorningList = new EmployeeService().GetEmployeeByDeptDesig(_dept.DeptId, _desig.DesignationId);
            IList<VMEmployeeInfo> empEveningList = new EmployeeService().GetEmployeeByDeptDesig(_dept.DeptId, _desig.DesignationId);
            IList<VMEmployeeInfo> empNightList = new EmployeeService().GetEmployeeByDeptDesig(_dept.DeptId, _desig.DesignationId);


            IList<VMEmployeeInfo> empOverTimeList = new EmployeeService().GetEmployeeByDeptDesig(_dept.DeptId, _desig.DesignationId);
            IList<VMEmployeeInfo> empDayOfList = new EmployeeService().GetEmployeeByDeptDesig(_dept.DeptId, _desig.DesignationId);

            



            empMorningList.Insert(0, new VMEmployeeInfo() { EmployeeId = 0, EmployeeName = "Select Employee" });
            cmbMorning.DataSource = empMorningList;
            cmbMorning.DisplayMember = "EmployeeName";
            cmbMorning.ValueMember = "EmployeeId";

            empEveningList.Insert(0, new VMEmployeeInfo() { EmployeeId = 0, EmployeeName = "Select Employee" });
            cmbEvening.DataSource = empEveningList;
            cmbEvening.DisplayMember = "EmployeeName";
            cmbEvening.ValueMember = "EmployeeId";

            empNightList.Insert(0, new VMEmployeeInfo() { EmployeeId = 0, EmployeeName = "Select Employee" });
            cmbNight.DataSource = empNightList;
            cmbNight.DisplayMember = "EmployeeName";
            cmbNight.ValueMember = "EmployeeId";

            empOverTimeList.Insert(0, new VMEmployeeInfo() { EmployeeId = 0, EmployeeName = "Select Employee" });
            cmbOverTime.DataSource = empOverTimeList;
            cmbOverTime.DisplayMember = "EmployeeName";
            cmbOverTime.ValueMember = "EmployeeId";

            empDayOfList.Insert(0, new VMEmployeeInfo() { EmployeeId = 0, EmployeeName = "Select Employee" });
            cmbDayof.DataSource = empDayOfList;
            cmbDayof.DisplayMember = "EmployeeName";
            cmbDayof.ValueMember = "EmployeeId";



            //if (_deptId > 0)
            //{
            //cmbDept.SelectedItem = deptList.Find(q => q.DeptId == _deptId);
            //}
        }


        private void LoadDutyRoster(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadEmployee()
        {

            EmpDepartment _dept = (EmpDepartment)cmbDept.SelectedItem;
            EmpDesignation _desig = (EmpDesignation)cmbDesignation.SelectedItem;


            IList<VMEmployeeInfo> _empInfo = new EmployeeService().GetEmployeeByDeptDesig(_dept.DeptId, _desig.DesignationId);
     
        }

       

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDesignation.SelectedIndex > 0 && cmbDept.SelectedIndex>0)
                LoadEmployees();
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDesignation.SelectedIndex > 0 && cmbDept.SelectedIndex > 0)
                LoadEmployees();
        }

        private void btnDisplayRoster_Click(object sender, EventArgs e)
        {
            DisplayRoster();
         
            
        }

        private void btnMorning_Click(object sender, EventArgs e)
        {
            if (cmbMorning.SelectedIndex > 0)
            {

                bool containsItem = lbMorning.Items.Contains((VMEmployeeInfo)cmbMorning.SelectedItem);


                VMEmployeeInfo _emp = new VMEmployeeInfo();
                _emp.EmployeeId = ((VMEmployeeInfo) cmbMorning.SelectedItem).EmployeeId;
                _emp.EmployeeName = ((VMEmployeeInfo)cmbMorning.SelectedItem).EmployeeName;
                lbMorning.Items.Add(_emp);

                //lbMorning.DisplayMember = "EmployeeName";
                //lbMorning.ValueMember = "EmployeeId";

            }
        }

        private void btnEvening_Click(object sender, EventArgs e)
        {
            if (cmbEvening.SelectedIndex > 0)
            {
                VMEmployeeInfo _emp = new VMEmployeeInfo();
                _emp.EmployeeId = ((VMEmployeeInfo)cmbEvening.SelectedItem).EmployeeId;
                _emp.EmployeeName = ((VMEmployeeInfo)cmbEvening.SelectedItem).EmployeeName;
                lbEvening.Items.Add(_emp);
            }
        }

        private void btnNight_Click(object sender, EventArgs e)
        {
            if (cmbNight.SelectedIndex > 0)
            {
                VMEmployeeInfo _emp = new VMEmployeeInfo();
                _emp.EmployeeId = ((VMEmployeeInfo)cmbNight.SelectedItem).EmployeeId;
                _emp.EmployeeName = ((VMEmployeeInfo)cmbNight.SelectedItem).EmployeeName;
                lbNight.Items.Add(_emp);
            }
        }

        private void DisplayRoster()
        {
            if(lbMorning.Items.Count ==0)
            {
                MessageBox.Show("Please Select Morning Employee");
                return;
            }

            if (lbEvening.Items.Count == 0)
            {
                MessageBox.Show("Please Select Evening Employee");
                return;
            }

            if (lbNight.Items.Count == 0)
            {
                MessageBox.Show("Please Select Night Employee");
                return;
            }



            List<VMEmployeeRoster> _ListEmployeeRoster = new List<VMEmployeeRoster>();

            List<VMEmployeeInfo> _ListVMEmployeeInfo = new List<VMEmployeeInfo>();

            EmpDepartment _dept = (EmpDepartment)cmbDept.SelectedItem;
            EmpDesignation _desig = (EmpDesignation)cmbDesignation.SelectedItem;


            DateTime dtRosterStartDate = dtpRosterStartDate.Value;
            DateTime dtRosterEndDate = dtpRosterEndDate.Value;
            DateTime dtRosterCalculationDate = dtpRosterStartDate.Value;
            int CalculationDateCount = 1;

            while (dtRosterCalculationDate < dtRosterEndDate.AddDays(1))
            {
                VMEmployeeRoster _VMEmployeeRoster = new VMEmployeeRoster();
                _VMEmployeeRoster.RosterDate = dtRosterCalculationDate;
                _VMEmployeeRoster.RosterDay = dtRosterCalculationDate.DayOfWeek.ToString();
                _VMEmployeeRoster.RosterOrder = CalculationDateCount;


                string MoringEmpID = "";
                string MoringEmpName = "";

                string EveningEmpID = "";
                string EveningEmpName = "";

                string NightEmpID = "";
                string NightEmpName = "";

                string OverTimeID = "";
                string OverTimeEmp = "";

                string DayOfEmpID = "";
                string DayofEmp = "";



                foreach (VMEmployeeInfo i in lbMorning.Items)
                    {
                        MoringEmpID = MoringEmpID + i.EmployeeId.ToString() + ",";
                        MoringEmpName = MoringEmpName + i.EmployeeName + ",";
                    }


                    foreach (VMEmployeeInfo i in lbEvening.Items)
                    {
                         EveningEmpID = EveningEmpID + i.EmployeeId.ToString() + ",";
                        EveningEmpName = EveningEmpName + i.EmployeeName + ",";
                    }

                    foreach (VMEmployeeInfo i in lbNight.Items)
                    {
                        NightEmpID = NightEmpID + i.EmployeeId.ToString() + ",";
                        NightEmpName = NightEmpName + i.EmployeeName + ",";

                    }


                    foreach (VMEmployeeInfo i in lbOverTime.Items)
                    {
                        OverTimeID = OverTimeID + i.EmployeeId.ToString() + ",";
                        OverTimeEmp = OverTimeEmp + i.EmployeeName + ",";

                    }

                    foreach (VMEmployeeInfo i in lbDayof.Items)
                    {
                        DayOfEmpID = DayOfEmpID + i.EmployeeId.ToString() + ",";
                        DayofEmp = DayofEmp + i.EmployeeName + ",";

                    }




                _VMEmployeeRoster.MorningEmpid = MoringEmpID.Substring(0, MoringEmpID.Length-1);
                _VMEmployeeRoster.MorningEmpName = MoringEmpName.Substring(0, MoringEmpName.Length - 1); 
                _VMEmployeeRoster.EveningEmpid = EveningEmpID.Substring(0, EveningEmpID.Length - 1); 
                _VMEmployeeRoster.EveningEmpName = EveningEmpName.Substring(0, EveningEmpName.Length - 1); 
                _VMEmployeeRoster.NightEmpid = NightEmpID.Substring(0, NightEmpID.Length - 1); 
                _VMEmployeeRoster.NightEmpName = NightEmpName.Substring(0, NightEmpName.Length - 1);


                if(OverTimeID.Length > 1)
                _VMEmployeeRoster.OverTimeEmpid = OverTimeID.Substring(0, OverTimeID.Length - 1);
                if (OverTimeEmp.Length > 2)
                    _VMEmployeeRoster.OverTimeEmpName = OverTimeEmp.Substring(0, OverTimeEmp.Length - 1);
                if (DayOfEmpID.Length > 1)
                    _VMEmployeeRoster.DayOffEmpid = DayOfEmpID.Substring(0, DayOfEmpID.Length - 1);
                if (DayofEmp.Length > 2)
                    _VMEmployeeRoster.DayOffEmpName = DayofEmp.Substring(0, DayofEmp.Length - 1);

                _VMEmployeeRoster.DeptId = _dept.DeptId;
                _VMEmployeeRoster.DesignationId = _desig.DesignationId;


                _ListEmployeeRoster.Add(_VMEmployeeRoster);


                CalculationDateCount = CalculationDateCount + 1;
                dtRosterCalculationDate = dtRosterCalculationDate.AddDays(1);
            }


            dgEmployeeRoster.SuspendLayout();
            dgEmployeeRoster.Rows.Clear();
            foreach (VMEmployeeRoster _VMEmployeeRoster in _ListEmployeeRoster)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = _VMEmployeeRoster;


                    row.CreateCells(dgEmployeeRoster, _VMEmployeeRoster.RosterDay, _VMEmployeeRoster.RosterDate.ToString("dd/MM/yyyy"), 
                   
                    _VMEmployeeRoster.MorningEmpName,
                   
                    _VMEmployeeRoster.EveningEmpName,
                   
                    _VMEmployeeRoster.NightEmpName,
                    //_VMEmployeeRoster.OverTimeEmpid,
                    _VMEmployeeRoster.OverTimeEmpName,
                   // _VMEmployeeRoster.DayOffEmpid,
                    _VMEmployeeRoster.DayOffEmpName

                    );
                dgEmployeeRoster.Rows.Add(row);


            }

        }

        private void btnCreateRoster_Click(object sender, EventArgs e)
        {

            try {

                EmpDepartment _dept = (EmpDepartment)cmbDept.SelectedItem;
                EmpDesignation _desig = (EmpDesignation)cmbDesignation.SelectedItem;
                //IList<EmployeeRosterMasterInfo> _EmpMasterList = 
                //new EmployeeService().GetEmployeeRosterMaster().Where(x=>x.RosterStartDate >= dtpRosterStartDate.Value && x.RosterEndDate<=dtpRosterEndDate.Value && x.DeptId == _dept.DeptId && x.DesignationId == _desig.DesignationId ).ToList();

                //if (_EmpMasterList.Count > 0)
                //    MessageBox.Show("Already Have A Roster.");

                EmployeeRosterMasterInfo _RosterMasterInfos = new EmployeeRosterMasterInfo();
                _RosterMasterInfos.RosterStartDate = dtpRosterStartDate.Value;
                _RosterMasterInfos.RosterEndDate = dtpRosterEndDate.Value;
                _RosterMasterInfos.Remarks = txtRemarks.Text;
                _RosterMasterInfos.DeptId = _dept.DeptId;
                _RosterMasterInfos.DesignationId = _desig.DesignationId;

                new EmployeeService().SaveStaffRosterMasterInfo(_RosterMasterInfos);
                _RosterMasterInfos =  new EmployeeService().GetEmployeeRosterMaster().OrderByDescending(x=>x.RosterMasterId).FirstOrDefault();

                foreach (DataGridViewRow row in dgEmployeeRoster.Rows)
                {
                    VMEmployeeRoster _empRoster = new VMEmployeeRoster();
                    EmployeeRoster _emp = new EmployeeRoster();

                    _empRoster = row.Tag as VMEmployeeRoster;

                    ////string str = row.Cells[1].Value.ToString();
                    _emp.RosterDate = _empRoster.RosterDate;
                    _emp.RosterDay = _empRoster.RosterDay;
                    _emp.RosterOrder = _empRoster.RosterOrder;
                    _emp.MorningEmpid = _empRoster.MorningEmpid;
                    _emp.MorningEmpName = _empRoster.MorningEmpName;

                    _emp.EveningEmpid = _empRoster.EveningEmpid;
                    _emp.EveningEmpName = _empRoster.EveningEmpName;
                    _emp.NightEmpid = _empRoster.NightEmpid;
                    _emp.NightEmpName = _empRoster.NightEmpName;

                    _emp.OverTimeEmpid = _empRoster.OverTimeEmpid;
                    _emp.OverTimeEmpName = _empRoster.OverTimeEmpName;
                    _emp.DayOffEmpid = _empRoster.DayOffEmpid;
                    _emp.DayOffEmpName = _empRoster.DayOffEmpName;
                    _emp.DeptId = _empRoster.DeptId;
                    _emp.DesignationId = _empRoster.DesignationId;
                    _emp.MasterRosterID = _RosterMasterInfos.RosterMasterId;
                    new EmployeeService().SaveStaffRosterInfo(_emp);

                }

                MessageBox.Show("Create New Roster. Roster ID : "+ _RosterMasterInfos.RosterMasterId);

                ViewRoster(_RosterMasterInfos.RosterMasterId);

                ClearForm();

               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Generate for "+ex.Message.ToString());

            }
        }

        private void ViewRoster(long rosterMasterId)
        {

            try
            {
                DataSet ds = new EmployeeService().GetRoster(rosterMasterId);

                rptRoster _rpt = new rptRoster();

                _rpt.SetDataSource(ds.Tables[0]);



                ReportViewer rv = new ReportViewer();



                _rpt.SetParameterValue("dept", cmbDept.Text);
                _rpt.SetParameterValue("desig", cmbDesignation.Text);

                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }catch(Exception ex)
            {

            }

        }

        private void ClearForm()
        {
            LoadData();
            lbMorning.Items.Clear();
            lbEvening.Items.Clear();
            lbNight.Items.Clear();
            lbOverTime.Items.Clear();
            lbDayof.Items.Clear();

            cmbMorning.SelectedIndex = 0;
            cmbEvening.SelectedIndex = 0;
            cmbNight.SelectedIndex = 0;
            cmbOverTime.SelectedIndex = 0;
            cmbDayof.SelectedIndex = 0;


            //cmbMorning.Items.Clear();
            //cmbEvening.Items.Clear();
            //cmbNight.Items.Clear();
            //cmbOverTime.Items.Clear();
            //cmbDayof.Items.Clear();

            dgEmployeeRoster.Rows.Clear();


        }

        private void btnOverTime_Click(object sender, EventArgs e)
        {
            if (cmbOverTime.SelectedIndex > 0)
            {

                bool containsItem = lbMorning.Items.Contains((VMEmployeeInfo)cmbOverTime.SelectedItem);

                VMEmployeeInfo _emp = new VMEmployeeInfo();
                _emp.EmployeeId = ((VMEmployeeInfo)cmbOverTime.SelectedItem).EmployeeId;
                _emp.EmployeeName = ((VMEmployeeInfo)cmbOverTime.SelectedItem).EmployeeName;
                lbOverTime.Items.Add(_emp);

            }
        }

        private void btnDayOf_Click(object sender, EventArgs e)
        {
            if (cmbDayof.SelectedIndex > 0)
            {

                bool containsItem = lbMorning.Items.Contains((VMEmployeeInfo)cmbDayof.SelectedItem);


                VMEmployeeInfo _emp = new VMEmployeeInfo();
                _emp.EmployeeId = ((VMEmployeeInfo)cmbDayof.SelectedItem).EmployeeId;
                _emp.EmployeeName = ((VMEmployeeInfo)cmbDayof.SelectedItem).EmployeeName;
                lbDayof.Items.Add(_emp);

                //lbMorning.DisplayMember = "EmployeeName";
                //lbMorning.ValueMember = "EmployeeId";

            }
        }

        private void btnClearM_Click(object sender, EventArgs e)
        {
            lbMorning.Items.Clear();
        }
    }
}
