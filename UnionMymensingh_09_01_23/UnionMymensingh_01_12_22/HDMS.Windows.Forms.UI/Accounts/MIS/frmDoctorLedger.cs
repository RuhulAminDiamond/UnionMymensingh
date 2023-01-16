using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.MIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.MIS
{
    public partial class frmDoctorLedger : Form
    {
        public frmDoctorLedger()
        {
            InitializeComponent();
        }

        private void frmDoctorLedger_Load(object sender, EventArgs e)
        {
            LoadDoctors();

            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;
        }

        private void LoadDoctors()
        {
            List<Doctor> _dList = new DoctorService().GetAllDoctors().ToList();
            FillDoctorGrid(_dList);
        }

        private void FillDoctorGrid(List<Doctor> _dList)
        {
            dgDoc.SuspendLayout();
            dgDoc.Rows.Clear();

            foreach (Doctor _d in _dList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = _d;

                row.CreateCells(dgDoc, _d.DoctorId, _d.Name);
                dgDoc.Rows.Add(row);
            }
        }

        private void dgDoc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Doctor _d = dgDoc.SelectedRows[0].Tag as Doctor;

            btnPrint.Tag = _d;

            List<HpConsultantLedger> _cLedger = new HpFinancialService().GetConsultantLedger(dtpfrm.Value,dtpto.Value, _d.DoctorId);
            FillLedgerGrid(_cLedger);
        }

        private void FillLedgerGrid(List<HpConsultantLedger> _cLedger)
        {
            dgDLedger.SuspendLayout();
            dgDLedger.Rows.Clear();

            foreach (HpConsultantLedger _L in _cLedger)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 32;
                row.Tag = _L;

                row.CreateCells(dgDLedger, _L.TranDate.ToString("dd/MM/yyyy")+" "+_L.TransactionTime, _L.Particulars,_L.Debit,_L.Credit,_L.Balance);
                dgDLedger.Rows.Add(row);
            }
        }

        private void txtSearchDoctor_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchDoctor.Text.Trim() == "Search doctor")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                LoadDoctorDatabyName(txtSearchDoctor.Text, "DName");
            }
        }

        private void LoadDoctorDatabyName(string _searcgString, string v)
        {
            List<Doctor> _dList = new DoctorService().GetDoctorBySearchString(_searcgString);

            if (_dList == null) return;

            if (_dList.Count == 0) return;

            FillDoctorGrid(_dList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (btnPrint.Tag != null)
            {
                Doctor _d = (Doctor)btnPrint.Tag;

                DataSet ds = new HpFinancialService().GetConsultancyLedger(dtpfrm.Value, dtpto.Value, _d.DoctorId);

                rptConsultantLedger _rpt = new rptConsultantLedger();

                _rpt.SetDataSource(ds.Tables[0]);


                string _customFormat = "dd/MM/yyyy";

                _rpt.SetParameterValue("dtpfrm", dtpfrm.Value.ToString(_customFormat));
                _rpt.SetParameterValue("dtpto", dtpto.Value.ToString(_customFormat));

                _rpt.SetParameterValue("CName", _d.Name);

                ReportViewer rv = new ReportViewer();

                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

            }
        }

        private void btnCloseMe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
