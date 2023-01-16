using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using HDMS.Service.Pharmacy;
using Services.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Forms
{
    public partial class frmCabinInfo : Form
    {
        public frmCabinInfo()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgCabinInfo.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgCabinInfo.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void frmCabinInfo_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadAccomodationType();
            LoadCabinInfo();
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

        private void LoadAccomodationType()
        {
            List<HpPatientAccomodationType> _accomList = new HospitalCabinBedService().GetHpAccomodationTypes();
            _accomList.Insert(0, new HpPatientAccomodationType() { AccomodationTypeId = 0, AccomodationType = "Select Type" });
            cmbAccomType.Tag = _accomList;
            cmbAccomType.DataSource = _accomList;
            cmbAccomType.DisplayMember = "AccomodationType";
            cmbAccomType.ValueMember = "AccomodationTypeId";
        }

        private void LoadCabinInfo()
        {
            List<VMCabinInfo> CfList = new HospitalCabinBedService().GetVMAllCabinList().ToList();


            FillListGrid(CfList);
           
            
        }

        private void FillListGrid(List<VMCabinInfo> _cabinList)
        {
            dgCabinInfo.SuspendLayout();
            dgCabinInfo.Rows.Clear();
            foreach (VMCabinInfo item in _cabinList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgCabinInfo, item.CabinId, item.CabinNo, item.Description, item.Rent, item.Floor, item.Department, item.AccomType);
                dgCabinInfo.Rows.Add(row);
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {

            HpDepartment _dept = (HpDepartment)cmbDepartment.SelectedItem;

            HpPatientAccomodationType _accomType = (HpPatientAccomodationType)cmbAccomType.SelectedItem;

            FloorInfo _floorInfo= (FloorInfo)cmbFloor.SelectedItem;

            if (_dept.DeptId == 0)
            {
                MessageBox.Show("Department not selected."); return;
            }


            if (_accomType.AccomodationTypeId == 0)
            {
                MessageBox.Show("Accomodation type not selected."); return;
            }


            if (_floorInfo.FloorId == 0)
            {
                MessageBox.Show("Floor not selected."); return;
            }

            if (txtDescription.Tag !=null)
            {

                VMCabinInfo _vmCabinInfo = (VMCabinInfo)txtDescription.Tag;

                CabinInfo _cf = new HospitalCabinBedService().GetCabinInfoId(_vmCabinInfo.CabinId);


                if (!string.IsNullOrEmpty(txtCabinNo.Text) && _cf != null) 
                {
                    _cf.CabinNo = txtCabinNo.Text;
                    _cf.Description = txtDescription.Text;
                    _cf.Rent =Convert.ToInt32(txtRent.Text);
                    _cf.FloorId = Convert.ToInt32(cmbFloor.SelectedValue);
                    _cf.AccomodationTypeId = _accomType.AccomodationTypeId;
                    _cf.DeptId = _dept.DeptId;
                    if (new HospitalCabinBedService().UpdateCabinInfo(_cf))
                    {
                        MessageBox.Show("Cabin Information Update Successful");
                        LoadCabinInfo();
                    }
                    else
                    {
                        MessageBox.Show("Cabin Update Failed");
                    }
                }
            }
            else
            {
            if (!string.IsNullOrEmpty(txtCabinNo.Text))
            {
                CabinInfo cf = new CabinInfo();
                cf.CabinNo = txtCabinNo.Text;
                cf.Description = txtDescription.Text;
                cf.Rent = Convert.ToInt32(txtRent.Text);
                cf.FloorId = Convert.ToInt32(cmbFloor.SelectedValue);
                cf.AccomodationTypeId = _accomType.AccomodationTypeId;
                cf.DeptId = _dept.DeptId;
                if (new HospitalCabinBedService().SaveCabinInfo(cf))
                {
                    MessageBox.Show("Cabin Information Successful.");
                    txtDescription.Text = "";
                    txtRent.Text = "";
                    LoadCabinInfo();
                }
                else
                {
                    MessageBox.Show("Saved Failed.");
                }
            }
            else
            {
                MessageBox.Show("Cabin No Not fund.");
            }
            }
            

        }

        private void dgCabinInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMCabinInfo _cf = dgCabinInfo.SelectedRows[0].Tag as VMCabinInfo;
            cmbAccomType.SelectedItem = ((List<HpPatientAccomodationType>)cmbAccomType.Tag).Find(q=>q.AccomodationTypeId ==  _cf.AccomTypeId);

            cmbFloor.SelectedItem= ((List<FloorInfo>)cmbFloor.Tag).Find(q => q.FloorId == _cf.FloorId);

            txtCabinNo.Text = _cf.CabinNo;
            txtDescription.Tag = _cf;
            txtDescription.Text = _cf.Description;
            txtRent.Text = Convert.ToString(_cf.Rent);
            btnSave.Text = "Update";
            btnCancel.Visible = true;
            btnDelete.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCabinNo.Text = "";
            txtDescription.Text = "";
            txtRent.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
