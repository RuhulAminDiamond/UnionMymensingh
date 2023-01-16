using HDMS.Common.Utils;
using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmReportDeliveryTimeSetting : Form
    {
        bool isComoLoaded = false;
        public frmReportDeliveryTimeSetting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _tds = 0;
            int.TryParse(txtTotalSlot.Text, out _tds);
            if (_tds > 0 && _tds<=8)
            {
                if (btnSave.Tag != null)
                {
                    ReportDeliveryTimingMaster _rdtm = btnSave.Tag as ReportDeliveryTimingMaster;
                    if (_rdtm != null)
                    {
                        _rdtm.TotalDeliverySlot = _tds;
                        _rdtm.IsActiveNow = radYes.Checked;
                        _rdtm.IsWeekendDeliverySchedule = radIsWeekEndYes.Checked;
                        if (radIsWeekEndYes.Checked)
                        {
                            _rdtm.WeekEndStartTime = dtpWST.Value.ToShortTimeString();
                        }
                        else
                        {
                            _rdtm.WeekEndStartTime = "";
                        }
                        if (new TestService().UpdateReportDeliveryTimingMaster(_rdtm))
                        {
                            LoadReportDeliveryTimingMaster();
                            txtTotalSlot.Text = "";
                            btnSave.Tag = null;
                            btnSave.Text = "Save";
                        }
                    }
                }
                else
                {

                    ReportDeliveryTimingMaster rdtm = new ReportDeliveryTimingMaster();
                    rdtm.TotalDeliverySlot = _tds;
                    rdtm.IsActiveNow = radYes.Checked;
                    rdtm.IsWeekendDeliverySchedule = radIsWeekEndYes.Checked;
                    if (radIsWeekEndYes.Checked)
                    {
                        rdtm.WeekEndStartTime = dtpWST.Value.ToShortTimeString();
                    }
                    else
                    {
                        rdtm.WeekEndStartTime = "";
                    }
                    if (new TestService().SaveReportDeliveryTimingMaster(rdtm))
                    {
                        LoadReportDeliveryTimingMaster();
                        txtTotalSlot.Text = "";
                        btnSave.Tag = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Value range between 1 to 8 expected.");
            }
        }

        private void LoadReportDeliveryTimingMaster()
        {
            List<ReportDeliveryTimingMaster> rdtmList = new TestService().GetReportDeliveryTimingMasterList();
            FillMasterGrid(rdtmList);
        }

        private void FillMasterGrid(List<ReportDeliveryTimingMaster> rdtmList)
        {
            dgDTM.Rows.Clear();
            dgDTM.SuspendLayout();
            foreach(var item in rdtmList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgDTM,item.RDTMId,item.TotalDeliverySlot,item.IsActiveNow,item.IsWeekendDeliverySchedule,item.WeekEndStartTime);
                dgDTM.Rows.Add(row);
            }
        }

        private void frmReportDeliveryTimeSetting_Load(object sender, EventArgs e)
        {
            LoadReportDeliveryTimingMaster();
            LoadDSCombo(0);
        }

        private void LoadDSCombo(int mId)
        {
            isComoLoaded = false;
            List<ReportDeliveryTimingMaster> rdtmList = new TestService().GetReportDeliveryTimingMasterList();
            rdtmList.Insert(0, new ReportDeliveryTimingMaster() { RDTMId = 0, TotalDeliverySlot = 0 });

            cmbDSlot.DataSource = rdtmList;
            cmbDSlot.DisplayMember = "TotalDeliverySlot";
            cmbDSlot.ValueMember = "RDTMId";

            if (mId > 0)
            {
                cmbDSlot.SelectedItem = rdtmList.Find(q => q.RDTMId == mId);
            }


            isComoLoaded = true;
        }

        private void btnSaveTiming_Click(object sender, EventArgs e)
        {
            
            ReportDeliveryTimingMaster _tm = cmbDSlot.SelectedItem as ReportDeliveryTimingMaster;

           

            if (btnSaveTiming.Tag != null)
            {
                ReportDeliveryTimingDetail _rdtd = btnSaveTiming.Tag as ReportDeliveryTimingDetail;
                if (_rdtd != null)
                {
                    _rdtd.EntryTime = dtpentrytime.Value.ToShortTimeString();
                    _rdtd.DeliveryTime = dtpdeliveryTime.Value.ToShortTimeString();
                   
                   
                    if (new TestService().UpdateReportDeliveryTimingDetail(_rdtd))
                    {
                        MessageBox.Show("Update successful.");
                        LoadReportDeliveryTimingDetail(_tm.RDTMId);
                        btnSaveTiming.Tag = null;
                        btnSaveTiming.Text = "Save";
                    }
                }
            } else if (btnSaveTiming.Tag == null && IsWithinTheSlotRange(_tm))
            {
                if (_tm.RDTMId > 0)
                {
                   
                        ReportDeliveryTimingDetail rdtd = new ReportDeliveryTimingDetail();
                        rdtd.RDTMId = _tm.RDTMId;
                        rdtd.EntryTime = dtpentrytime.Value.ToShortTimeString();
                        rdtd.DeliveryTime = dtpdeliveryTime.Value.ToShortTimeString();
                       
                       
                        if (new TestService().SaveReportDeliveryTimingDetail(rdtd))
                        {
                            LoadReportDeliveryTimingDetail(_tm.RDTMId);
                            btnSaveTiming.Tag = null;
                        }
                    
                }
                else
                {
                    MessageBox.Show("Plz. select a slot other than zero");
                }
            }
            else
            {
                MessageBox.Show("Sorry! Slot is filled up");
            }
        }

        private bool IsWithinTheSlotRange(ReportDeliveryTimingMaster tm)
        {
            List<ReportDeliveryTimingDetail> _tdList = new TestService().GetReportDeliveryTimingDetailList(tm.RDTMId);
            if(_tdList != null && _tdList.Count >= tm.TotalDeliverySlot)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void LoadReportDeliveryTimingDetail(int rDTMId)
        {
            List<ReportDeliveryTimingDetail> _tdList = new TestService().GetReportDeliveryTimingDetailList(rDTMId);
            FillTDGrid(_tdList);

        }

        private void FillTDGrid(List<ReportDeliveryTimingDetail> tdList)
        {
            dgRDTD.SuspendLayout();
            dgRDTD.Rows.Clear();
            foreach(var item in tdList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgRDTD, item.Id,item.EntryTime, item.DeliveryTime);
                dgRDTD.Rows.Add(row);
            }
        }

        private void dgRDTD_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReportDeliveryTimingDetail _td = dgRDTD.SelectedRows[0].Tag as ReportDeliveryTimingDetail;
            btnSaveTiming.Tag = _td;
            btnSaveTiming.Text = "Update";
            DateTime _entryTime = new CalculateCabinCharge().CombinedDateAndTimePart(DateTime.Now.Date, _td.EntryTime);
            dtpentrytime.Value = _entryTime;

            DateTime _deliveryTime = new CalculateCabinCharge().CombinedDateAndTimePart(DateTime.Now.Date, _td.DeliveryTime);
            dtpdeliveryTime.Value = _deliveryTime;

            LoadDSCombo(_td.RDTMId);
        }

        private void cmbDSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isComoLoaded)
            {
                ReportDeliveryTimingMaster tm = cmbDSlot.SelectedItem as ReportDeliveryTimingMaster;
                if (tm.RDTMId > 0)
                {
                    LoadReportDeliveryTimingDetail(tm.RDTMId);
                }
            }
        }

        private void dgDTM_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReportDeliveryTimingMaster _td = dgDTM.SelectedRows[0].Tag as ReportDeliveryTimingMaster;
            btnSave.Tag = _td;
            btnSave.Text = "Update";

            txtTotalSlot.Text = _td.TotalDeliverySlot.ToString();

            if (_td.IsActiveNow)
            {
                radYes.Checked = true;
            }
            else
            {
                radNo.Checked = true;
            }

            if (_td.IsWeekendDeliverySchedule)
            {
                radIsWeekEndYes.Checked = true;
            }
            else
            {
                radIsWeekEndNo.Checked = true;
            }
        }

        private void radIsWeekEndYes_CheckedChanged(object sender, EventArgs e)
        {
            if (radIsWeekEndYes.Checked)
            {
                lblWST.Visible = true;
                dtpWST.Visible = true;
            }
            else
            {
                lblWST.Visible = false;
                dtpWST.Visible = false;
            }
        }

        private void radIsWeekEndNo_Click(object sender, EventArgs e)
        {
            if (radIsWeekEndNo.Checked)
            {
                lblWST.Visible = false;
                dtpWST.Visible = false;
            }
            else
            {
                lblWST.Visible = true;
                dtpWST.Visible = true;
            }
        }
    }
}
