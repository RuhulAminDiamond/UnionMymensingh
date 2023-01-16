using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
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
    public partial class frmCabinList : Form
    {
        public frmCabinList()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgCabin.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgCabin.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

        private void frmCabinList_Load(object sender, EventArgs e)
        {
            List<VMCabinInfo>  _cabinList = new HospitalCabinBedService().GetVMAllCabinList();

            FillCabinGrid(_cabinList);
            //dgCabin.AutoGenerateColumns = false;
            //dgCabin.DataSource = _cabinList;

            List<VMFreeCabinList> _freeCabinList = new HospitalCabinBedService().GetFreeCabinListByFloor();
            FillFreeCabinGrid(_freeCabinList);

        }

        private void FillFreeCabinGrid(List<VMFreeCabinList> _freeCabinList)
        {
            dgFreeCabins.SuspendLayout();
            dgFreeCabins.Rows.Clear();
            foreach (VMFreeCabinList item in _freeCabinList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;

                row.CreateCells(dgFreeCabins, item.FloorNo, item.FreeCabins, item.TotalFree);
                dgFreeCabins.Rows.Add(row);
            }
        }

        private void FillCabinGrid(List<VMCabinInfo> _cabinList)
        {
            dgCabin.SuspendLayout();
            dgCabin.Rows.Clear();
            foreach (VMCabinInfo item in _cabinList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;

                if (item.Booked.ToLower() == "booked")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;

                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }


                row.CreateCells(dgCabin, item.CabinId, item.CabinNo, item.Description, item.Rent, item.Floor, item.Booked);
                dgCabin.Rows.Add(row);
            }
        }

        private void dgCabin_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CabinInfo _CabinInfo = new HospitalCabinBedService().GetCabinInfoId(Convert.ToInt32(dgCabin.Rows[e.RowIndex].Cells[0].Value.ToString()));
          
            if (_CabinInfo != null)
            {
                txtCabin.Text = _CabinInfo.CabinNo;
                txtCabin.Tag = _CabinInfo;

                if (_CabinInfo.IsBooked)
                {
                    cmbStatus.Text = "Booked";
                }else
                {
                    cmbStatus.Text = "Free";
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCabin.Tag != null)
            {
                CabinInfo _Cabin = (CabinInfo)txtCabin.Tag;

                if (cmbStatus.Text.ToLower() == "booked")
                {
                    _Cabin.IsBooked = true;
                }
                else
                {
                    _Cabin.IsBooked = false;
                }

                new HospitalCabinBedService().UpdateCabinInfo(_Cabin);

                List<VMCabinInfo> _cabinList = new HospitalCabinBedService().GetVMCabinList();

                FillCabinGrid(_cabinList);

            }
            else
            {

            }
        }
    }
}
