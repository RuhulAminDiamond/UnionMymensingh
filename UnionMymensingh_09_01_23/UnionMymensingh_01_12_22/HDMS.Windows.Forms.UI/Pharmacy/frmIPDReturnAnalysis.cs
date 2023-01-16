using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using HDMS.Service.Common;
using HDMS.Service.Hospital;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmIPDReturnAnalysis : Form
    {
        public frmIPDReturnAnalysis()
        {
            InitializeComponent();
        }

        private void txtHBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _hbillNo = 0;
                long.TryParse(txtHBillNo.Text, out _hbillNo);

                HospitalPatientInfo _hp = new HospitalService().GetHospitalPatientByBillNoAny(_hbillNo);
                if (_hp != null)
                {

                    if (_hp.Status.Equals("Discharged"))
                    {
                        HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetReleasedAsPBCabinByPatient(_hp.AdmissionId);
                        CabinInfo _cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);

                        RegRecord rr = new RegRecordService().GetRegRecordByRegNo(_hp.RegNo);

                        lblName.Text = rr.FullName;
                        lblCabin.Text = _cabin.CabinNo;

                        LoadReturnInvoices(_hbillNo);

                    }
                    else
                    {

                        VMIPDInfo _pInfo = new HospitalService().GetIPDInfoById(_hp.AdmissionId);
                        if (_pInfo != null)
                        {
                            lblName.Text = _pInfo.Name;
                            lblCabin.Text = _pInfo.BedCabinNo;

                            LoadReturnInvoices(_pInfo.BillNo);

                        }
                    }
                }


                

            }
        }

        private void LoadReturnInvoices(long billNo)
        {
            List<PhInvoice> _retInvoiceList = new PhFinancialService().GetReturnInvoices(billNo);
            dgReturnInvoices.SuspendLayout();
            dgReturnInvoices.Rows.Clear();

            double sumOfAmount = 0;

            foreach(var item in _retInvoiceList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                sumOfAmount = sumOfAmount + item.GrandTK;
                row.CreateCells(dgReturnInvoices,item.BillNo,item.GrandTK,item.RequisitionNo);
                dgReturnInvoices.Rows.Add(row);
            }

            lblTotalIndentAmount.Text = sumOfAmount.ToString();
        }

        private void dgReturnInvoices_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PhInvoice invObj = dgReturnInvoices.SelectedRows[0].Tag as PhInvoice;
            if (invObj != null)
            {

                List<VMReturnRequestList> _mRetDetail = new PhProductService().GetHpMedicineReturnDetail(invObj.RequisitionNo);
              
                FillRetIndentProductGrid(_mRetDetail);

                List<VMPhSoldItem> _retAcceptedItemList = new PhProductService().GetPhSoldItems(invObj.InvoiceId);
                FillRetAcceptedProductGrid(_retAcceptedItemList);

               

            }

        }

      

        private void FillRetAcceptedProductGrid(List<VMPhSoldItem> retAcceptedItemList)
        {

            dgReturnAcceptedItems.SuspendLayout();
            dgReturnAcceptedItems.Rows.Clear();

            if (retAcceptedItemList == null) return;

            double sumOfAmount = 0;
            foreach (VMPhSoldItem item in retAcceptedItemList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                sumOfAmount = sumOfAmount + item.TotalPrice;
                row.CreateCells(dgReturnAcceptedItems, item.BrandName, item.Qty, item.SaleRate, item.TotalPrice);
                dgReturnAcceptedItems.Rows.Add(row);
            }


            lblAcceptedAmount.Text = sumOfAmount.ToString();
        }

        private void FillRetIndentProductGrid(List<VMReturnRequestList> mRetDetail)
        {
            dgReturnItems.SuspendLayout();
            dgReturnItems.Rows.Clear();

            if (mRetDetail == null) return;


            foreach (VMReturnRequestList item in mRetDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgReturnItems, item.BrandName, item.RetQty, item.SalePrice, item.TotalPrice);
                dgReturnItems.Rows.Add(row);
            }
        }
    }
}
