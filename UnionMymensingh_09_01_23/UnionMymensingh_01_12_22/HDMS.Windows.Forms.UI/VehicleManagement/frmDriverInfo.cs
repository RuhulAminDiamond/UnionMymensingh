using HDMS.Model.Enums;
using HDMS.Model.Vehicle;
using HDMS.Service.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Vehicle
{
    public partial class frmDriverInfo : Form
    {
        public frmDriverInfo()
        {
            InitializeComponent();
        }

        private void dgDriver_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DriverInfo driver = dgDriver.SelectedRows[0].Tag as DriverInfo;
            if(driver!=null)
            {
                txtName.Text = driver.DriverName;
                txtAddress.Text = driver.Address;
                txtMobile.Text = driver.MobileNo;
                txtLicense.Text =driver.License;
                txtQualification.Text = driver.Qualification;
                txtRemarks.Text =driver.Remarks;
                cmbDstatus.Text =driver.DStatus;
                dtpJoin.Value = driver.Djoin;
                txtName.Tag = driver;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if(txtName.Tag!=null)
            {
                DriverInfo dv = txtName.Tag as DriverInfo;
                DriverInfo driver = new VehicleService().GetDriver(dv.DriverId);
                driver.DriverName = txtName.Text;
                driver.Address = txtAddress.Text;
                driver.MobileNo = txtMobile.Text;
                driver.License = txtLicense.Text;
                driver.Qualification = txtQualification.Text;
                driver.Remarks = txtRemarks.Text;
                driver.DStatus =cmbDstatus.Text;
                driver.Djoin = dtpJoin.Value;
                if(new VehicleService().UpDriverInfo(driver))
                {
                    MessageBox.Show("Updated Succesfully");
                    Loaddata();
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
            }
            else
            {
                if (isValid())
                {
                    DriverInfo driver = new DriverInfo();
                    driver.DriverName = txtName.Text;
                    driver.Address = txtAddress.Text;
                    driver.MobileNo = txtMobile.Text;
                    driver.License = txtLicense.Text;
                    driver.Qualification = txtQualification.Text;
                    driver.Remarks = txtRemarks.Text;
                    driver.DStatus = cmbDstatus.Text;
                    driver.Djoin = dtpJoin.Value;
                    if (new VehicleService().SaveDriverInfo(driver))
                    {
                        MessageBox.Show("Saved Successfully");
                        Loaddata();
                    }
                    else
                        MessageBox.Show("Failed in Saving");

                }
                else
                    MessageBox.Show("Please Fill up All Required Field");
            }
            
        }

        private void Loaddata()
        {
            IList<DriverInfo> dvList = new VehicleService().GetDriverList();
            FillGrid(dvList);
            clearField();
        }

        private void clearField()
        {
             txtName.Text="";
             txtAddress.Text="";
             txtMobile.Text="";
             txtLicense.Text="";
            txtQualification.Text="";
            txtRemarks.Text="";
            cmbDstatus.Text = "";
             dtpJoin.Value=DateTime.Now;
        }

        private void FillGrid(IList<DriverInfo> dvList)
        {
            dgDriver.SuspendLayout();
            dgDriver.Rows.Clear();
            foreach(DriverInfo info in dvList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = info;
                row.CreateCells(dgDriver,info.DriverName,info.Address,info.MobileNo,info.DStatus);
                dgDriver.Rows.Add(row);
            }
        }

        private bool isValid()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(txtName.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtLicense.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtMobile.Text)) flag = false;
            return flag;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearField();
            Loaddata();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverInfo_Load(object sender, EventArgs e)
        {
            Loaddata();
            cmbDstatus.DataSource = Enum.GetValues(typeof(DriverStatus));
        }
    }
}
