using HDMS.Model.Vehicle;
using HDMS.Service.Vehicle;
using HDMS.Windows.Forms.UI.Controls;
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
    public partial class frmCarAllotInfo : Form
    {
        public frmCarAllotInfo()
        {
            InitializeComponent();
        }

        private void frmCarAllotInfo_Load(object sender, EventArgs e)
        {
            HideDefaultHidden();
            ctrlCarSearch.Location = new Point(txtCar.Location.X,txtCar.Location.Y+txtCar.Height);
            ctrlDriverSearch2.Location = new Point(txtDriver.Location.X,txtDriver.Location.Y+txtDriver.Height);
            ctrlRouteSearch.Location = new Point(txtDestination.Location.X,txtDestination.Location.Y+txtDestination.Height);

            ctrlCarSearch.ItemSelected += ctrlCarSearch_ItemSelected;
            ctrlDriverSearch2.ItemSelected += ctrlDriverSearch2_ItemSelected;
            ctrlRouteSearch.ItemSelected += ctrlRouteSearch_ItemSelected;


        }

        private void ctrlRouteSearch_ItemSelected(SearchResultListControl<RoutingOrTripInfo> sender, RoutingOrTripInfo item)
        {
            txtDestination.Text = item.Destination;
            txtDestination.Tag = item;
            ShowCarRent(item);
           
            sender.Visible = false;
        }

        private void ShowCarRent(RoutingOrTripInfo item)
        {
            lblRent.Text = item.Rent.ToString();
        }

        private void ctrlDriverSearch2_ItemSelected(SearchResultListControl<DriverInfo> sender, DriverInfo item)
        {
            txtDriver.Text = item.DriverName;
            txtDriver.Tag = item;
           
            sender.Visible = false;
        }

        private void ctrlCarSearch_ItemSelected(SearchResultListControl<CarInfo> sender, CarInfo item)
        {
            txtCar.Text = item.CarNo;
            txtCar.Tag = item;
            
            sender.Visible = false;
        }

        private void HideDefaultHidden()
        {
            ctrlCarSearch.Visible = false;
            ctrlDriverSearch2.Visible = false;
            ctrlRouteSearch.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int res;
            Int32.TryParse(lblRent.Text,out res) ;
            if (txtCar.Tag != null && txtDriver.Tag != null && txtDestination.Tag != null)
            {
                CarInfo car = txtCar.Tag as CarInfo;
                DriverInfo driver = txtDriver.Tag as DriverInfo;
                RoutingOrTripInfo routing = txtDestination.Tag as RoutingOrTripInfo;
                CarAllotmentInfo carAllotmentInfo = new CarAllotmentInfo();
                carAllotmentInfo.CarId = car.CarId;
                carAllotmentInfo.DriverId = driver.DriverId;
                carAllotmentInfo.RouteId = routing.RouteId;
                carAllotmentInfo.Allotmentby = MainForm.LoggedinUser.Name;
                carAllotmentInfo.Rent = res;
                carAllotmentInfo.ADate = dtpDate.Value;
                if(new VehicleService().SaveAllotmentInfo(carAllotmentInfo))
                {
                    MessageBox.Show("Saved Successfully");
                    ClearField();
                }
                else
                    MessageBox.Show("Failed to Save");

            }
            else
                MessageBox.Show("Please Fill Up All The Required Field");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void ClearField()
        {
            txtCar.Tag = null;
            txtDriver.Tag = null;
            txtDestination.Tag = null;
            lblRent.Text = "";
            txtCar.Text = "";
            txtDriver.Text = "";
            txtDestination.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlCarSearch_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDriverSearch2_Load(object sender, EventArgs e)
        {

        }

        private void txtCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter|| e.KeyChar == (char)Keys.Space)
            {
                ctrlCarSearch.Visible = true;
                ctrlCarSearch.LoadData();
            }
        }

        private void txtDriver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter|| e.KeyChar == (char)Keys.Space)
            {
                ctrlDriverSearch2.Visible = true;
                ctrlDriverSearch2.LoadData();
            }
        }

        private void txtDestination_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Space)
            {
                ctrlRouteSearch.Visible = true;
                ctrlRouteSearch.LoadData();
            }
        }

        private void ctrlCarSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCar.Focus();
            }
        }

        private void ctrlDriverSearch2_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDriver.Focus();
            }
        }

        private void ctrlRouteSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDestination.Focus();
            }
        }
    }
}
