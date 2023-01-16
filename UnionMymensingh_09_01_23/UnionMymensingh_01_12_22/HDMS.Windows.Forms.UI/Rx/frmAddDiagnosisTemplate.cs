using HDMS.Model.Rx;
using HDMS.Service.Rx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmAddDiagnosisTemplate : Form
    {
        public frmAddDiagnosisTemplate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtDiagnosis.Tag != null)
            {
                RxDiagnosis _diagnosis = (RxDiagnosis)txtDiagnosis.Tag;
                _diagnosis.Name = txtDiagnosis.Text;

                if(new RxService().UpdateDiagnosis(_diagnosis))
                {
                    MessageBox.Show("Diagnosis update successful");
                    LoadDiagnosis();
                    ClearForm();
                }

            }
            else
            {
                if (!String.IsNullOrEmpty(txtDiagnosis.Text))
                {
                    RxDiagnosis _diagnosis = new RxDiagnosis();
                    _diagnosis.Name = txtDiagnosis.Text;

                    new RxService().SaveDiagnosis(_diagnosis);

                    MessageBox.Show("Diagnosis saved successfully");
                    LoadDiagnosis();
                    ClearForm();
                }
            }
        }

        private void ClearForm()
        {
            txtDiagnosis.Text = "";
            txtDiagnosis.Tag = null;
        }

        private void LoadDiagnosis()
        {
            List<RxDiagnosis> _diagnosisList = new RxService().GetRxDiagnosisList();

            FillGrid(_diagnosisList);
        }

        private void FillGrid(List<RxDiagnosis> _diagnosisList)
        {
            dgDiagnosis.SuspendLayout();
            dgDiagnosis.Rows.Clear();

            foreach(var item in _diagnosisList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;
                row.CreateCells(dgDiagnosis, item.DiagnosisId, item.Name);
                dgDiagnosis.Rows.Add(row);
            }
        }

        private void frmAddDiagnosisTemplate_Load(object sender, EventArgs e)
        {
            LoadDiagnosis();
        }

        private void dgDiagnosis_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDiagnosis.SelectedRows.Count > 0)
            {
                RxDiagnosis _dgns = dgDiagnosis.SelectedRows[0].Tag as RxDiagnosis;
                txtDiagnosis.Text = _dgns.Name;
                txtDiagnosis.Tag = _dgns;
            }
        }
    }
}
