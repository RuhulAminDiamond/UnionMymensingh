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
    public partial class frmCarInfo : Form
    {
        public frmCarInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if(txtChasis.Tag!=null)
            {
                CarInfo  car= txtChasis.Tag as CarInfo;
                CarInfo carInfo = new VehicleService().GetCar(car.CarId);
                carInfo.ChasisNo = txtChasis.Text;
                carInfo.EngineNo = txtEngine.Text;
                carInfo.CarNo = txtCarNo.Text;
                carInfo.License = txtLicense.Text;
                carInfo.CommissionDate = dtpDate.Value;
                carInfo.Condiotion = txtCondition.Text;
                carInfo.Amenities = txtAmenities.Text;
                carInfo.CarType = txtCtype.Text;
                carInfo.CStatus = cmbStatus.Text;
                if(new VehicleService().UpCarInfo(carInfo))
                {
                    MessageBox.Show("Updated Successfully");
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
                    CarInfo carInfo = new CarInfo();
                    carInfo.ChasisNo = txtChasis.Text;
                    carInfo.EngineNo = txtEngine.Text;
                    carInfo.CarNo = txtCarNo.Text;
                    carInfo.License = txtLicense.Text;
                    carInfo.CommissionDate = dtpDate.Value;
                    carInfo.Condiotion = txtCondition.Text;
                    carInfo.Amenities = txtAmenities.Text;
                    carInfo.CarType = txtCtype.Text;
                    carInfo.CStatus = cmbStatus.Text;
                    if (new VehicleService().SaveCar(carInfo))
                    {
                        MessageBox.Show("Successfully Saved");
                        Loaddata();

                    }
                    else
                        MessageBox.Show("Failed to Save");
                }
                else
                    MessageBox.Show("please fill up All required Field");
            }
            
        }

        private void Loaddata()
        {
            IList<CarInfo> carList = new VehicleService().GetCarList();
            FillGrid(carList);
            clearField();
        }

        private void clearField()
        {
            txtChasis.Text="";
            txtEngine.Text="";
            txtCarNo.Text="";
            txtLicense.Text="";
            dtpDate.Value=DateTime.Now;
            txtCondition.Text="";
            txtAmenities.Text="";
            txtCtype.Text="";
            cmbStatus.Text = "";
            txtChasis.Tag = null;
        }

        private void FillGrid(IList<CarInfo> carList)
        {
            DgCar.SuspendLayout();
            DgCar.Rows.Clear();
            foreach(CarInfo car in carList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = car;
                row.CreateCells(DgCar,car.CarNo,car.Condiotion,car.CStatus);
                DgCar.Rows.Add(row);
            }
        }

        private bool isValid()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(txtChasis.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtCarNo.Text)) flag = false;
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

        private void frmCarInfo_Load(object sender, EventArgs e)
        {
          Loaddata();
            cmbStatus.DataSource = Enum.GetValues(typeof(CarStatus));
        }

        private void DgCar_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CarInfo car = DgCar.SelectedRows[0].Tag as CarInfo;
            if(car!=null)
            {
                txtChasis.Text = car.ChasisNo;
                txtEngine.Text = car.EngineNo;
                txtCarNo.Text = car.CarNo;
                txtLicense.Text=car.License;
                dtpDate.Value = car.CommissionDate;
                txtCondition.Text = car.Condiotion;
                txtAmenities.Text = car.Amenities;
                txtCtype.Text = car.CarType;
                cmbStatus.Text = car.CStatus.ToString();
                txtChasis.Tag = car;

            }
        }

        private void txtChasis_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtEngine_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void txtChasis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEngine.Focus();
            }
        }

        private void txtEngine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCarNo.Focus();
            }
        }

        private void txtLicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpDate.Focus();
            }
        }

        private void txtCarNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtLicense.Focus();
            }
        }

        private void dtpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCondition.Focus();
            }
        }
    }
}
