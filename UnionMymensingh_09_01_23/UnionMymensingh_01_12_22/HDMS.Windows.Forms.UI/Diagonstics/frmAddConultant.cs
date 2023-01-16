using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
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
    public partial class frmAddConultant : Form
    {
        private bool IsAnyOneSelected = false;
        public frmAddConultant()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgvConsultants.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgvConsultants.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
            //dgTests.RowTemplate.Height = 30;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
                int _fSize1 = 0, _fSize2 = 0, _fSize3 = 0, _fSize4 = 0, _fSize5 = 0, _fSize6 = 0, _fSize7=0;

                int.TryParse(txtNameFontSize.Text, out _fSize1);
                int.TryParse(txtFontSizeforIdentity1.Text, out _fSize2);
                int.TryParse(txtFontSizeforIdentity2.Text, out _fSize3);
                int.TryParse(txtFontSizeforIdentity3.Text, out _fSize4);
                int.TryParse(txtFontSizeforIdentity4.Text, out _fSize5);
                int.TryParse(txtFontSizeforIdentity5.Text, out _fSize6);
                int.TryParse(txtFontSizeforIdentity6.Text, out _fSize7);

                if (txtName.Tag != null)
                {
                    ReportConsultant _consultant = (ReportConsultant)txtName.Tag;
                    

                    _consultant.Name = txtName.Text;
                    _consultant.Fsize1 = _fSize1;
                    _consultant.DIdentityLine1 = txtIdentityLine1.Text;
                    _consultant.Fsize2 = _fSize2;
                    _consultant.DIdentityLine2 = txtIdentityLine2.Text;
                    _consultant.Fsize3 = _fSize3;
                    _consultant.DIdentityLine3 = txtIdentityLine3.Text;
                    _consultant.Fsize4 = _fSize4;
                    _consultant.DIdentityLine4 = txtIdentityLine4.Text;
                    _consultant.Fsize5 = _fSize5;
                    _consultant.DIdentityLine5 = txtIdentityLine5.Text;
                    _consultant.Fsize6 = _fSize6;
                    _consultant.DIdentityLine6 = txtIdentityLine6.Text;
                    _consultant.Fsize7 = _fSize7;

                    if (new DoctorService().UpdateReportConsultant(_consultant))
                    {
                        MessageBox.Show("Consultant Info updated successfully.", "H-ERP");
                        new DoctorService().DeleteExistingAllowedGroups(_consultant.RCId);
                        SaveAllowedGroups(_consultant.RCId);
                        LoadConsultants();
                    }
                    else
                    {
                       MessageBox.Show("Sorry! Fail to update consultant.", "H-ERP");
                    }


                }
                else
                {
                    ReportConsultant _consultant = new ReportConsultant();
                   
                    _consultant.Name = txtName.Text;
                    _consultant.Fsize1 = _fSize1;
                    _consultant.DIdentityLine1 = txtIdentityLine1.Text;
                    _consultant.Fsize2 = _fSize2;
                    _consultant.DIdentityLine2 = txtIdentityLine2.Text;
                    _consultant.Fsize3 = _fSize3;
                    _consultant.DIdentityLine3 = txtIdentityLine3.Text;
                    _consultant.Fsize4 = _fSize4;
                    _consultant.DIdentityLine4 = txtIdentityLine4.Text;
                    _consultant.Fsize5 = _fSize5;
                    _consultant.DIdentityLine5 = txtIdentityLine5.Text;
                    _consultant.Fsize6 = _fSize6;
                    _consultant.DIdentityLine6 = txtIdentityLine6.Text;
                    _consultant.Fsize7 = _fSize7;

                int _RCId = new DoctorService().SaveReportConsultant(_consultant);
                    if (_RCId>0)
                    {

                    SaveAllowedGroups(_RCId);

                    MessageBox.Show("New Consultant Saved Successfully.", "H-ERP");
                        LoadConsultants();
                    }
                    else
                    {

                        MessageBox.Show("Sorry! Fail to create new consultant.", "H-ERP");
                    }
                }

               

           
        }

        private void SaveAllowedGroups(int _RCId)
        {
            List<ReportConsultantWorkList> _rcWList = new List<ReportConsultantWorkList>();

            string[] _allowedGroups = null;
            if (chkRadiology.Checked)
            {
                _allowedGroups = chkRadiology.Tag.ToString().Split(',');
                foreach (string _grouId in _allowedGroups)
                {
                    ReportConsultantWorkList _rcw = new ReportConsultantWorkList();
                    _rcw.RCId = _RCId;
                    _rcw.TestGroupId = Convert.ToInt32(_grouId);
                    _rcWList.Add(_rcw);
                }
            }

            _allowedGroups = null;

            if (chkCardiology.Checked)
            {
                _allowedGroups = chkCardiology.Tag.ToString().Split(',');
                foreach (string _grouId in _allowedGroups)
                {
                    ReportConsultantWorkList _rcw = new ReportConsultantWorkList();
                    _rcw.RCId = _RCId;
                    _rcw.TestGroupId = Convert.ToInt32(_grouId);
                    _rcWList.Add(_rcw);
                }
            }

            _allowedGroups = null;
            if (chkGastro.Checked)
            {
                _allowedGroups = chkGastro.Tag.ToString().Split(',');
                foreach (string _grouId in _allowedGroups)
                {
                    ReportConsultantWorkList _rcw = new ReportConsultantWorkList();
                    _rcw.RCId = _RCId;
                    _rcw.TestGroupId = Convert.ToInt32(_grouId);
                    _rcWList.Add(_rcw);
                }
            }



            _allowedGroups = null;
            if (chkNeuro.Checked)
            {
                _allowedGroups = chkNeuro.Tag.ToString().Split(',');
                foreach (string _grouId in _allowedGroups)
                {
                    ReportConsultantWorkList _rcw = new ReportConsultantWorkList();
                    _rcw.RCId = _RCId;
                    _rcw.TestGroupId = Convert.ToInt32(_grouId);
                    _rcWList.Add(_rcw);
                }
            }

            _allowedGroups = null;
            if (chkUro.Checked)
            {

                ReportConsultantWorkList _rcw = new ReportConsultantWorkList();
                _rcw.RCWId = _RCId;
                _rcw.TestGroupId = Convert.ToInt32(chkUro.Tag);
                _rcWList.Add(_rcw);

            }

            if (_rcWList.Count() > 0)
            {
                new DoctorService().SaveAllowedGroups(_rcWList);
            }
        }

        private void frmAddConultant_Load(object sender, EventArgs e)
        {

            LoadConsultants();
        }

        private void LoadConsultants()
        {
            List<ReportConsultant> _rConsultant = new ReportService().GetReportConsultants();

            dgvConsultants.AutoGenerateColumns = false;
            dgvConsultants.DataSource = _rConsultant;

        }

        private void dgvConsultants_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtName.Tag = new DoctorService().GetReportConsultantById(Convert.ToInt32(dgvConsultants.Rows[e.RowIndex].Cells["Id"].Value.ToString()));
            btnSave.Text = "Update";
            if (txtName.Tag != null)
            {
           

                ReportConsultant _consultant = (ReportConsultant)txtName.Tag;
                //cmbGroup.SelectedIndex = _testItem.GroupId-3; //As Test Group Id starts from 3
                txtName.Text = _consultant.Name;
                txtIdentityLine1.Text = _consultant.DIdentityLine1;
                txtIdentityLine2.Text = _consultant.DIdentityLine2;
                txtIdentityLine3.Text = _consultant.DIdentityLine3;
                txtIdentityLine4.Text = _consultant.DIdentityLine4;
                txtIdentityLine5.Text = _consultant.DIdentityLine5;
                txtIdentityLine6.Text = _consultant.DIdentityLine6;

                txtFontSizeforIdentity1.Text = _consultant.Fsize1.ToString();
                txtFontSizeforIdentity1.Text= _consultant.Fsize1.ToString();
                txtFontSizeforIdentity1.Text= _consultant.Fsize1.ToString();
                txtFontSizeforIdentity1.Text= _consultant.Fsize1.ToString();
                txtFontSizeforIdentity1.Text= _consultant.Fsize1.ToString();

                LoadAllowedDepts(_consultant);

            }

        }

        private void LoadAllowedDepts(ReportConsultant _consultant)
        {
            List<ReportConsultantWorkList> cwList = new DoctorService().GetConsultantWorkList(_consultant.RCId);

            ReportConsultantWorkList _radiology = cwList.Where(q => q.TestGroupId == 5).FirstOrDefault();
            if (_radiology != null) { chkRadiology.Checked = true; } else { chkRadiology.Checked = false; }

            ReportConsultantWorkList _cardiology = cwList.Where(q => q.TestGroupId == 4).FirstOrDefault();
            if (_cardiology != null) { chkCardiology.Checked = true; } else { chkCardiology.Checked = false; }

            ReportConsultantWorkList _gastro = cwList.Where(q => q.TestGroupId == 3).FirstOrDefault();
            if (_gastro != null) { chkGastro.Checked = true; } else { chkGastro.Checked = false; }

            ReportConsultantWorkList _neuro = cwList.Where(q => q.TestGroupId == 10).FirstOrDefault();
            if (_neuro != null) { chkNeuro.Checked = true; } else { chkNeuro.Checked = false; }

            ReportConsultantWorkList _urology = cwList.Where(q => q.TestGroupId == 28).FirstOrDefault();
            if (_urology != null) { chkUro.Checked = true; } else { chkUro.Checked = false; };

            
        }

        private void chkPathology_CheckStateChanged(object sender, EventArgs e)
        {
            IsAnyOneSelected = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
