using HDMS.Model.Enums;
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
    public partial class frmEditOrDeleteFloorService : Form
    {
        public frmEditOrDeleteFloorService()
        {
            InitializeComponent();
        }

        private void frmEditOrDeleteConsultancyService_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private async void LoadPatients()
        {
            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfo();

            FillListGrid(_lisPatientInfo);
        }

        private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMIPDInfo item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.BedCabinNo, item.Name, item.AddmissionDate.ToString("dd/MM/yyyy"));
                dgPatient.Rows.Add(row);
            }

        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);

              

                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;
                dtpDischarge.Tag = _pInfo;

                List<VMFloorServiceEdit> _cList = new HpFinancialService().GetFloorServiceList(_pInfo.AdmissionId);

                FillServiceListGrid(_cList);

            }
        }

        private void FillServiceListGrid(List<VMFloorServiceEdit> _cList)
        {
            dgServices.SuspendLayout();
            dgServices.Rows.Clear();
            foreach (VMFloorServiceEdit item in _cList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgServices, item.ServiceDate.ToString("dd/MM/yyyy"), item.ServiceName, item.Rate, item.Qty,item.Total);
                dgServices.Rows.Add(row);
            }
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByCabin.Text, "cabin");
            }
        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoBySearchParameter(_prefix, type).ToList();

            if (_lisPatientInfo.Count() == 0) return;

            // lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
        }

        private void dgServices_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgServices.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgServices.SelectedRows[0];
                VMFloorServiceEdit _consultancy = ((VMFloorServiceEdit)row.Tag);

                btnDelete.Tag = _consultancy;

                txtQty.Tag = _consultancy.Qty;
                txtQty.Text= _consultancy.Qty.ToString();

                txtRate.Tag = _consultancy.Rate;
                txtRate.Text = _consultancy.Rate.ToString();
            

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Tag != null)
            {
                VMIPDInfo _IpdInfo = (VMIPDInfo)dtpDischarge.Tag;

                VMFloorServiceEdit _floorService = ((VMFloorServiceEdit)btnDelete.Tag);

                if(_floorService != null)
                {
                    if (_floorService.Qty > 1)
                    {
                         DialogResult result = MessageBox.Show("It will delete " + _floorService.Qty.ToString() + " consultancy at a time. Will you proceed?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes) {

                        }
                        else
                        {
                            return;
                        }
                    }

                   ServiceBillDetail _billDetail = new HpFinancialService().GetFloorServiceById(_floorService.SBDId);

                    if(_billDetail != null)
                    {
                        FloorServiceDeleteLog _dLog = new FloorServiceDeleteLog();
                        _dLog.AdmissionId = _billDetail.AdmissionId;
                        _dLog.ServiceHeadId = _billDetail.ServiceHeadId;
                       
                        _dLog.Rate = _billDetail.Rate;
                        _dLog.Qty = _billDetail.Qty;
                        _dLog.Vat = 0;
                        _dLog.ServiceCharge = _billDetail.ServiceCharge;
                        _dLog.ServiceDate = _billDetail.ServiceDate;
                        _dLog.ServiceTime = _billDetail.ServiceTime;
                        _dLog.CreatedBy = _billDetail.CreatedBy;
                        _dLog.ModifiedDate = _billDetail.ModifiedDate;
                        _dLog.DeletedBy = MainForm.LoggedinUser.Name;

                        if(new HpFinancialService().SaveFloorServiceDeleteLog(_dLog))
                        {
                            new HpFinancialService().DeleteFloorService(_billDetail);
                            MessageBox.Show("Floor service deleted successfully.");

                            btnDelete.Tag = null;

                            List<VMFloorServiceEdit> _cList = new HpFinancialService().GetFloorServiceList(_billDetail.AdmissionId);

                            FillServiceListGrid(_cList);
                        }

                    }

                }

            }
            else
            {
                MessageBox.Show("No record found to delete");
            }
        }

        private void btnUpdateAmount_Click(object sender, EventArgs e)
        {
            if (btnDelete.Tag != null)
            {

               if(txtQty.Tag==null || txtRate.Tag == null)
                {
                    return;
                }
                // MessageBox.Show("Under construction"); return; // TODO: after complete delete this line

                string _msgtype = string.Empty;

                VMFloorServiceEdit _consultancy = ((VMFloorServiceEdit)btnDelete.Tag);

                VMIPDInfo _IpdInfo = (VMIPDInfo)dtpDischarge.Tag;

           

                if (_consultancy != null)
                {
                    ServiceBillDetail _billDetail = new HpFinancialService().GetFloorServiceById(_consultancy.SBDId);

                    double _rate = 0;
                    double.TryParse(txtRate.Text, out _rate);

                    int _qty = 0;
                    int.TryParse(txtQty.Text, out _qty);

                    double _prevQty = 0;
                    double.TryParse(txtQty.Tag.ToString(), out _prevQty);


                    if( _rate > 0 && _qty > 0)
                    {

                      
                        
                            _billDetail.Qty = _qty;
                            _billDetail.Rate = _rate;
                            _billDetail.ModifiedBy = MainForm.LoggedinUser.Name;
                            _billDetail.ModifiedDate = Utils.GetServerDateAndTime();

                           
                            if (new HpFinancialService().UpdateFloorServiceBill(_billDetail))
                            {
                                

                                MessageBox.Show("Update successful.");

                                btnDelete.Tag = null;

                              List<VMFloorServiceEdit> _cList = new HpFinancialService().GetFloorServiceList(_billDetail.AdmissionId);

                               FillServiceListGrid(_cList);
                         }
                        
                    }else
                    {
                        MessageBox.Show("Some constraints Fail. Plz. check and try again."); 
                    }
                }
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btnDelete.Tag != null)
                {
                    int _qty = 0;
                    int.TryParse(txtQty.Text, out _qty);

                    VMFloorServiceEdit _consultancy = ((VMFloorServiceEdit)btnDelete.Tag);


                    txtRate.Text = (_consultancy.Rate * _qty).ToString();
                }
            }
    
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            int _qty = 0;
            int.TryParse(txtQty.Text, out _qty);

            double _rate = 0;
            double.TryParse(txtRate.Text, out _rate);


        }
    }
}
