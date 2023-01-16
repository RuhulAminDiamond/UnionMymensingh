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
    public partial class frmRouteorTripInfo : Form
    {
        public frmRouteorTripInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int res;
            Int32.TryParse(txtRent.Text,out res);
            if(txtRent.Tag!=null)
            {
                RoutingOrTripInfo info = txtRent.Tag as RoutingOrTripInfo;
                RoutingOrTripInfo tripInfo = new VehicleService().GetRoute(info.RouteId);
                tripInfo.Destination = txtDestination.Text;
                tripInfo.Rent = res;
                if (new VehicleService().UpRouteInfo(tripInfo))
                {
                    MessageBox.Show("Updated Successfully");
                    LoadData();
                }
                else
                    MessageBox.Show("Update Failed");
            }
            else
            {
                if (isValid())
                {
                    RoutingOrTripInfo tripInfo = new RoutingOrTripInfo();
                    tripInfo.Destination = txtDestination.Text;
                    tripInfo.Rent = res;
                    if (new VehicleService().SaveRent(tripInfo))
                    {
                        MessageBox.Show("Saved Successfully");
                        LoadData();
                    }
                }
                else
                    MessageBox.Show("Please Fill Up All Required Filled");
            }
            
        }

        private void LoadData()
        {
            IList<RoutingOrTripInfo> TripList = new VehicleService().GetRouteInfo();
            FillGrid(TripList);
            clearField();
        }

        private void clearField()
        {
            txtDestination.Text = "";
            txtRent.Text = "";
            txtRent.Tag = null;
        }

        private void FillGrid(IList<RoutingOrTripInfo> tripList)
        {
            dgRoute.SuspendLayout();
            dgRoute.Rows.Clear();
            foreach(RoutingOrTripInfo info in tripList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = info;
                row.CreateCells(dgRoute,info.Destination,info.Rent);
                dgRoute.Rows.Add(row);
            }
        }

        private bool isValid()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(txtDestination.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtRent.Text)) flag = false;

            return flag;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearField();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgRoute_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RoutingOrTripInfo info = dgRoute.SelectedRows[0].Tag as RoutingOrTripInfo;
            if(info!=null)
            {
                txtDestination.Text = info.Destination;
                txtRent.Text = info.Rent.ToString();
                txtRent.Tag = info;
            }

        }

        private void frmRouteorTripInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
