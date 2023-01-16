using CrystalDecisions.Windows.Forms;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.MIS
{
    public partial class frmHpPatientList : Form
    {
        public frmHpPatientList()
        {
            InitializeComponent();
        }

        private void btnShowAllByAdmisison_Click(object sender, EventArgs e)
        {
            string _deptName = string.Empty;
            string _floorName = string.Empty;

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;

            FloorInfo _floor = cmbFloor.SelectedItem as FloorInfo;

            bool IsAllIPD = false;

            if (radYes.Checked) {
                IsAllIPD = true;
            }
            else
            {
                IsAllIPD = false;
            } 

            if (_dept.DeptId == 0)
            {
                _deptName = "All";
            }
            else
            {
                _deptName = _dept.Name;
            }

            if (_floor.FloorId == 0)
            {
                _floorName = "All";
            }
            else
            {
                _floorName = _floor.Name;
            }


            DataSet ds = new HospitalService().GetHpAllPatientListByAdmissionDate(dtpfrm.Value, dtpto.Value, _dept.DeptId, _floor.FloorId, IsAllIPD);

            ReportViewer rv = new ReportViewer();
            rptHpAdmittedPatientList _rpt = new rptHpAdmittedPatientList();

            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm",dtpfrm.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dateto", dtpto.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("department", _deptName); 
            _rpt.SetParameterValue("FloorName", _floorName);
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmHpPatientList_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

            LoadDepartments();
            LoadFloors();
        }

        private void LoadFloors()
        {
            List<FloorInfo> _floorList = new HospitalService().GetFloors();
            _floorList.Insert(0, new FloorInfo() { FloorId = 0, Name = "Select Floor" });
            cmbFloor.Tag = _floorList;
            cmbFloor.DataSource = _floorList;
            cmbFloor.DisplayMember = "Name";
            cmbFloor.ValueMember = "FloorId";
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });


            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
