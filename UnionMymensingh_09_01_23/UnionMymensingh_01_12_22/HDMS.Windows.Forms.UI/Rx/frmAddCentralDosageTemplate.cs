using HDMS.Model;
using HDMS.Model.Rx;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Doctors;
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
    public partial class frmAddCentralDosageTemplate : Form
    {
        public frmAddCentralDosageTemplate()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
           
               
                if(String.IsNullOrEmpty(txtLongDoseEn.Text) && String.IsNullOrEmpty(txtLongDoseBn.Text) && String.IsNullOrEmpty(txtShortDoseEn.Text) && String.IsNullOrEmpty(txtShortDoseBn.Text))
                {
                    MessageBox.Show("At least one dose description required."); return;
                }

                RxDoseEMRInterpretation _emr = cmbEMR.SelectedItem as RxDoseEMRInterpretation;


                if (!String.IsNullOrEmpty(txtLongDoseBn.Text))
                {
                    if (txtLongDoseBn.Tag != null)
                    {
                        RxDosage _rxD = (RxDosage)txtLongDoseBn.Tag;
                       
                        _rxD.DoseBnLong = txtLongDoseBn.Text;
                        _rxD.DoseEnLong = txtLongDoseEn.Text;
                        _rxD.DoseBnShort = txtShortDoseBn.Text;
                        _rxD.DoseEnShort = txtShortDoseEn.Text;
                        _rxD.ShortKey = txtshortkey.Text;
                        _rxD.EMRInterPretId = _emr.EmrIId;
                        if (new RxService().UpdateCDbDosages(_rxD))
                        {
                            MessageBox.Show("Dosage update successful.");
                            ClearForm();
                            await LoadDosage();
                        }
                    }
                    else
                    {

                         RxDosage _rxD = new RxDosage();
                      
                        _rxD.DoseBnLong = txtLongDoseBn.Text;
                        _rxD.DoseEnLong = txtLongDoseEn.Text;
                        _rxD.DoseBnShort = txtShortDoseBn.Text;
                        _rxD.DoseEnShort = txtShortDoseEn.Text;
                        _rxD.ShortKey = txtshortkey.Text;
                        _rxD.EMRInterPretId = _emr.EmrIId;
                        if (new RxService().SaveCDbDosages(_rxD))
                        {
                            MessageBox.Show("Dosage save successful.");
                            ClearForm();
                            await LoadDosage();
                        }
                    }
               }
            
        }

        private async void ClearForm()
        {
            txtLongDoseBn.Text = "";
            txtLongDoseEn.Text = "";
            txtShortDoseEn.Text = "";
            txtShortDoseBn.Text = "";
            txtshortkey.Text = "";
            txtLongDoseBn.Tag = null;

            await LoadDosage();

        }

        private async void frmAddDosageTemplate_Load(object sender, EventArgs e)
        {

            LoadEMRCombo(0);
           await LoadDosage();
           
        }

        private void LoadEMRCombo(int emrId)
        {
            List<RxDoseEMRInterpretation> _emrList = new RxService().GetEMRInterpretList();
            _emrList.Insert(0, new RxDoseEMRInterpretation() { EmrIId=0,Description="Select Interpretation"});
            cmbEMR.DataSource = _emrList;
            cmbEMR.DisplayMember = "Description";
            cmbEMR.ValueMember = "EmrIId";

            if (emrId > 0)
            {
                cmbEMR.SelectedItem = _emrList.Find(q => q.EmrIId == emrId);
            }
        }

        private async Task<bool>  LoadDosage()
        {
            List<RxDosage> _dosageList = await new RxService().GetRxCDbDosageList();

            FillGrid(_dosageList);

            return await Task.FromResult(true);
        }

        private void FillGrid(List<RxDosage> _dosageList)
        {
            dgDosage.SuspendLayout();
            dgDosage.Rows.Clear();

            foreach (var item in _dosageList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgDosage, item.DoseId, item.DoseBnLong, item.DoseBnShort,item.DoseEnLong,item.DoseEnShort,item.ShortKey);
                dgDosage.Rows.Add(row);
            }
        }

        private void btnSetPreferrence_Click(object sender, EventArgs e)
        {
            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if (_user != null)
            {
               

                MessageBox.Show("Preferrence settings successful.");

            }else
            {

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgDosage_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RxCpDosage _SelectedItem = (RxCpDosage)e.Row.Tag;

            new RxService().DeleteDoseFromCpPersonalDb(_SelectedItem);

        }

        private void dgDosage_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDosage.Rows.Count > 0)
            {
                RxCpDosage dose = dgDosage.CurrentRow.Tag as RxCpDosage;
                if (dose != null)
                {

                    txtLongDoseBn.Tag = dose;

                    txtLongDoseBn.Text = dose.DoseBnLong;
                    txtLongDoseEn.Text = dose.DoseEnLong;
                    txtShortDoseBn.Text = dose.DoseBnShort;
                    txtShortDoseEn.Text = dose.DoseEnShort;
                }
            }
        }

        private void txtShortDoseEn_TextChanged(object sender, EventArgs e)
        {
            char[] chrs = new char[100];

            int count = 0;
            foreach (char c in txtShortDoseEn.Text)
            {
                char ch = c;
                if (Char.IsDigit(c))
                {
                    ch = (char)('\u09E6' + c - '0');
                }
                chrs[count] = ch;
                count++;
            }

            string bengali_text = new string(chrs);

            txtShortDoseBn.Text = bengali_text;
        }
    }
}
