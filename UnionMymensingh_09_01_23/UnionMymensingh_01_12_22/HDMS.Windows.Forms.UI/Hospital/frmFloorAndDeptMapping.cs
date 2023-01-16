using HDMS.Model.Hospital;
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

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmFloorAndDeptMapping : Form
    {
        public frmFloorAndDeptMapping()
        {
            InitializeComponent();
        }

        private void frmFloorAndDeptMapping_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadFloors();
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });
            cmbDepartment.DataSource = _deptList;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "DeptId";

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
    }
}
