using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Windows.Forms.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Rx;
using System.IO;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmChamberPractitionerEntry : Form
    {
        public frmChamberPractitionerEntry()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgCP.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgCP.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
            //dgTests.RowTemplate.Height = 30;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int _fSize1 = 0, _fSize2 = 0, _fSize3 = 0, _fSize4 = 0, _fSize5 = 0, _fSize6 = 0, _fSize7 = 0, _specialityId = 0;

            int.TryParse(txtNameFontSize.Text, out _fSize1);
            int.TryParse(txtFontSizeforIdentity1.Text, out _fSize2);
            int.TryParse(txtFontSizeforIdentity2.Text, out _fSize3);
            int.TryParse(txtFontSizeforIdentity3.Text, out _fSize4);
            int.TryParse(txtFontSizeforIdentity4.Text, out _fSize5);
            int.TryParse(txtFontSizeforIdentity5.Text, out _fSize6);
            int.TryParse(txtFontSizeforIdentity6.Text, out _fSize7);

            int _quota = 0;
            int.TryParse(txtPatientQuota.Text, out _quota);

            if (txtName.Tag == null)
            {
                MessageBox.Show("Plz. select a doctor and try again."); return;
            }


            _specialityId = ((ChamberPractitionerSpeciality)cmbSpeciality.SelectedItem).CPSId;

            if (_specialityId == 0)
            {
                MessageBox.Show("Practitioner speciality not selected."); return;
            }

            int _refdDoctorId = ((Doctor)txtName.Tag).DoctorId;

            byte[] imgbyte = null;
            if (sgnbox.Image != null)
            {
                 imgbyte = GetImagebyte();
            }


            if (txtIdentityLine1.Tag != null)
            {
                ChamberPractitioner _consultant = (ChamberPractitioner)txtIdentityLine1.Tag;
                _consultant.DoctorId = _refdDoctorId;
                _consultant.CPSId = _specialityId;
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
                _consultant.PatientQuota = _quota;
                _consultant.PrcticeTimeFrom = dtpfrmTime.Text;
                _consultant.PrcticeTimeTo = dtptoTime.Text;
                _consultant.Status = cmbstatus.Text;
                _consultant.ESignature = imgbyte;
                if (new DoctorService().UpdateChamberPractitioner(_consultant))
                {
                  

                    
                    MessageBox.Show("Practitioner Info updated successfully.", "H-ERP");

                    ClearFields();
                    LoadPractitioners();
                }
                else
                {
                    MessageBox.Show("Sorry! Fail to update consultant.", "H-ERP");
                }


            }
            else
            {
                ChamberPractitioner _consultant = new ChamberPractitioner();
                _consultant.DoctorId = _refdDoctorId;
                _consultant.CPSId = _specialityId;
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
                _consultant.PatientQuota = _quota;
                _consultant.PrcticeTimeFrom = dtpfrmTime.Text;
                _consultant.PrcticeTimeTo = dtptoTime.Text;
                _consultant.Status = cmbstatus.Text;
                _consultant.ESignature = imgbyte;
                int _CPId = new DoctorService().SaveChamberPractitioner(_consultant);
                if (_CPId > 0)
                {
                    List<CPOffDayCalender> _offdays = new List<CPOffDayCalender>();
                    foreach (var item in cPOffDayCalenders)
                    {
                        CPOffDayCalender Obj = new CPOffDayCalender();
                        Obj.CpId = _consultant.CPId;
                        Obj.WeeklyOffDay = item.WeeklyOffDay;
                        Obj.MonthlyOffDate = item.MonthlyOffDate;
                        _offdays.Add(Obj);
                    }


                    if (_offdays.Count > 0)
                    {
                        new DoctorService().SaveChamberPractitionerOffDays(_offdays);
                    }

                    MessageBox.Show("New Practioner Created Successfully.", "H-ERP");
                    ClearFields();
                    LoadPractitioners();
                }
                else
                {

                    MessageBox.Show("Sorry! Fail to create new practioner.", "H-ERP");
                }
            }

        }

        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        private byte[] GetImagebyte()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(sgnbox.Image);
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }

                //Byte[] imgBytes = null;
                //ImageConverter imgConverter = new ImageConverter();
                //imgBytes = (System.Byte[])imgConverter.ConvertTo(sgnbox.Image, Type.GetType("System.Byte[]"));
                //return imgBytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IList<CPOffDayCalender> cPOffDayCalenders;
        private void frmChamberPractitionerEntry_Load(object sender, EventArgs e)
        {

            cPOffDayCalenders = new List<CPOffDayCalender>();


            HideAllDefaultHidden();


            ctlDoctorSearch.Location = new Point(txtName.Location.X, txtName.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;



            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadSpeciality(0);
            LoadPractitioners();

            dtpOffDate.Enabled = false;
        }

        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtName.Text = item.Name;
            txtName.Tag = item;
            sender.Visible = false;
            txtName.Focus();

        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;

           
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;

            ctrl.BackColor = Color.NavajoWhite;
        }

        private void LoadSpeciality(int _CPSId)
        {
            List<ChamberPractitionerSpeciality> _cpsList = new List<ChamberPractitionerSpeciality>();
           
            _cpsList = new DoctorService().GetChamberPractitionerSpecialityList().ToList();

            _cpsList.Insert(0, new ChamberPractitionerSpeciality() { CPSId = 0, Name = "---Select----" });

            cmbSpeciality.DataSource = _cpsList;
            cmbSpeciality.ValueMember = "CPSId";
            cmbSpeciality.DisplayMember = "Name";

            if (_CPSId > 0)
            {
                cmbSpeciality.SelectedItem = _cpsList.Find(q => q.CPSId == _CPSId);
            }

        }

        private void btnAddSpeciality_Click(object sender, EventArgs e)
        {
            frmAddChamberPractitionerSpeciality _frm = new frmAddChamberPractitionerSpeciality();
            _frm.Show();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtName.Tag = null;
            txtIdentityLine1.Text = "";
            txtIdentityLine2.Text = "";
            txtIdentityLine3.Text = "";
            txtIdentityLine4.Text = "";
            txtIdentityLine5.Text = "";
            txtIdentityLine6.Text = "";
            LoadSpeciality(0);
        }

        private void LoadPractitioners()
        {
            List<ChamberPractitioner> _cpList = new DoctorService().GetChamberPractitionerList();
            FillCPGrid(_cpList);
        }

        private void FillCPGrid(List<ChamberPractitioner> _cpList)
        {
            dgCP.SuspendLayout();
            dgCP.Rows.Clear();
            foreach(var item in _cpList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 30;
                row.CreateCells(dgCP,item.CPId,item.Name,new DoctorService().GetChamberPractionerSpecialityById(item.CPSId).Name,item.DIdentityLine1,item.DIdentityLine2);

                dgCP.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgCP_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgCP.Rows.Count > 0)
            {
                ChamberPractitioner _consultant = dgCP.SelectedRows[0].Tag as ChamberPractitioner;
                btnSave.Text = "Update";

                    txtName.Text = _consultant.Name;

                    Doctor _d = new DoctorService().GetDoctorById(_consultant.DoctorId);
                    txtName.Tag = _d;

                    txtIdentityLine1.Tag = _consultant;
                    txtIdentityLine1.Text = _consultant.DIdentityLine1;
                    txtIdentityLine2.Text = _consultant.DIdentityLine2;
                    txtIdentityLine3.Text = _consultant.DIdentityLine3;
                    txtIdentityLine4.Text = _consultant.DIdentityLine4;
                    txtIdentityLine5.Text = _consultant.DIdentityLine5;
                    txtIdentityLine6.Text = _consultant.DIdentityLine6;

                    txtFontSizeforIdentity1.Text = _consultant.Fsize1.ToString();
                    txtFontSizeforIdentity1.Text = _consultant.Fsize1.ToString();
                    txtFontSizeforIdentity1.Text = _consultant.Fsize1.ToString();
                    txtFontSizeforIdentity1.Text = _consultant.Fsize1.ToString();
                    txtFontSizeforIdentity1.Text = _consultant.Fsize1.ToString();

                    LoadSpeciality(_consultant.CPSId);

                   dtpfrmTime.Text = _consultant.PrcticeTimeFrom;
                   dtptoTime.Text = _consultant.PrcticeTimeTo;

                if (_consultant.ESignature != null)
                {
                    sgnbox.Image = byteArrayToImage(_consultant.ESignature);
                }
                else
                {
                    sgnbox.Image = null;
                }

                  LoadOffDaysCaledarData(_consultant.CPId);

            }
        }

        private void LoadOffDaysCaledarData(int cPId)
        {
            List<CPOffDayCalender> _offDays = new DoctorService().GetCPOffDays(cPId);
            FillCPOffDayCalendarGrid(_offDays);

        }

        private void chkIsMonthlyOffDay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsMonthlyOffDay.Checked)
            {
                dtpOffDate.Enabled = true;
            }
            else
            {
                dtpOffDate.Enabled = false;
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (chkIsMonthlyOffDay.Checked)
            { 
                CPOffDayCalender Obj = new CPOffDayCalender();
              
                Obj.MonthlyOffDate = dtpOffDate.Value;

                cPOffDayCalenders.Add(Obj);
            }
            else
            {
                CPOffDayCalender Obj = new CPOffDayCalender();
                Obj.WeeklyOffDay = cmbWeekDay.Text;
                cPOffDayCalenders.Add(Obj);
            }

            FillCPOffDayCalendarGrid(cPOffDayCalenders);
        }

        private void FillCPOffDayCalendarGrid(IList<CPOffDayCalender> offdays)
        {
            dgOffDay.SuspendLayout();
            dgOffDay.Rows.Clear();
            foreach(var item in offdays)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgOffDay, item.WeeklyOffDay, item.MonthlyOffDate);

                dgOffDay.Rows.Add(row);
            }
        }

        private void lnkBtnUploadSignature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.png;)|*.jpg;*.jpeg;.*.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                sgnbox.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void btnClearSignature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sgnbox.Image = null;
        }
    }
}
