using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Enums;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmSetPreference : Form
    {

        ChamberPractitioner _cp = new ChamberPractitioner();
        bool IsResetCb = false;
        public frmSetPreference(ChamberPractitioner _prac)
        {
            InitializeComponent();

            this._cp = _prac;
        }


      
        private void frmSetPreference_Load(object sender, EventArgs e)
        {
            txtRxBy.Text = _cp.Name;
            txtRxBy.Tag = _cp;

          
            foreach (Control control in this.tabPage4.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox cb = control as CheckBox;
                    cb.CheckStateChanged += Cb_CheckStateChanged; 
                }

            }


            foreach (Control control in this.tabPage4.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox cb = control as CheckBox;
                    
                    cb.Enabled = false;
                    
                }

            }

            chkInitialData.Enabled = true;
            chkPrescription.Enabled = true;
            chkTestReports.Enabled = true;


            LoadPersonalPreference(_cp);
            
            LoadPersonalInfo(_cp);

            LoadPrintPreference(_cp);

            LoadActiveSupportUsers(_cp);

            LoadCarryOnBlocks(_cp);

            
            
        }

        private void LoadPersonalPreference(ChamberPractitioner cp)
        {
            RxPersonalPreferenceSetting _ps = new RxService().GetRxPersonalPrefernce(cp.CPId);


            if (_ps.IsDefaultDoseInEnglish)
            {
                radDDInEnglishYes.Checked = true;
                radDDInEnglishNo.Checked = false;
            }
            else
            {
                radDDInEnglishYes.Checked = false;
                radDDInEnglishNo.Checked = true;
            }


            if (_ps.IsDefaultDoseInShortForm)
            {
                radDDFormShortYes.Checked = true;
                radDDFormShortNo.Checked = false;
            }
            else
            {
                radDDFormShortYes.Checked = false;
                radDDFormShortNo.Checked = true;
            }

            if (_ps.IsDefaultAdviceInEnglish)
            {
                radAdviceInEnglishYes.Checked = true;
                radAdviceInEnglishNo.Checked = false;
            }
            else
            {
                radAdviceInEnglishYes.Checked = false;
                radAdviceInEnglishNo.Checked = true;
            }

            if (_ps.IsDefaultDoseFromPersonalDb)
            {
                radPersonalDb.Checked = true;
                radCentralDb.Checked = false;
            }
            else
            {
                radPersonalDb.Checked = false;
                radCentralDb.Checked = true;
            }


            if (_ps.IsMedicineInterXEnable)
            {
                radMedInterXEnable.Checked = true;
                radMedInterXDisable.Checked = false;
            }
            else
            {
                radMedInterXEnable.Checked = false;
                radMedInterXDisable.Checked = true;
            }



        }

        private void LoadCarryOnBlocks(ChamberPractitioner cp)
        {
            RxCarryOnBlock cob = new RxService().GetRxCarryOnBlocks(cp.CPId);
            if (cob.ChiefComplains)
            {
                chkCOBCC.Checked = true;
            }
            else
            {
                chkCOBCC.Checked = false;
            }

            if (cob.History)
            {
                chkCOBHistory.Checked = true;
            }
            else
            {
                chkCOBHistory.Checked = false;
            }

            if (cob.Additional)
            {
                chkCOBAdditional.Checked = true;
            }
            else
            {
                chkCOBAdditional.Checked = false;
            }

            if (cob.PhysicalFindings)
            {
                chkCOBPhysicalFindings.Checked = true;
            }
            else
            {
                chkCOBPhysicalFindings.Checked = false;
            }

            if (cob.OtherFindings)
            {
                chkCOBOtherFindings.Checked = true;
            }
            else
            {
                chkCOBOtherFindings.Checked = false;
            }

            if (cob.DrugHistory)
            {
                chkCOBDrugHistory.Checked = true;
            }
            else
            {
                chkCOBDrugHistory.Checked = false;
            }

            if (cob.Treatment)
            {
                chkCOBTreatment.Checked = true;
            }
            else
            {
                chkCOBTreatment.Checked = false;
            }

            if (cob.Advices)
            {
                chkCOBAdvices.Checked = true;
            }
            else
            {
                chkCOBAdvices.Checked = false;
            }

            if (cob.Tests)
            {
                chkCOBInvestigations.Checked = true;
            }
            else
            {
                chkCOBInvestigations.Checked = false;
            }

            if (cob.Notes)
            {
                chkCOBNotes.Checked = true;
            }
            else
            {
                chkCOBNotes.Checked = false;
            }

            if (cob.Diagnosis)
            {
                chkCOBDiagnosis.Checked = true;
            }
            else
            {
                chkCOBDiagnosis.Checked = false;
            }

            if (cob.Dx)
            {
                chkDx.Checked = true;
            }
            else
            {
                chkDx.Checked = false;
            }
        }

        private void Cb_CheckStateChanged(object sender, EventArgs e)
        {
            int _userId = 0;
            if (txtUserName.Tag != null)
            {
                VMUserDetail _u = (VMUserDetail)txtUserName.Tag;
                _userId = _u.Id;
            }

            CheckBox cb = sender as CheckBox;
            if (cb.CheckState == CheckState.Unchecked && !IsResetCb)
            {
                this.DeleteAccessPermission(_userId, cb.Tag.ToString());
            }

            if ((cb.Tag.ToString().Equals("tab0") || cb.Tag.ToString().Equals("tab1") || cb.Tag.ToString().Equals("tab2")) && cb.CheckState == CheckState.Checked)
            {
                this.EnableOrDisableRxTabCheckBox(cb.Tag.ToString(),true);

            }
            else if ((cb.Tag.ToString().Equals("tab0") || cb.Tag.ToString().Equals("tab1") || cb.Tag.ToString().Equals("tab2")) && cb.CheckState == CheckState.Unchecked)
            {
                this.EnableOrDisableRxTabCheckBox(cb.Tag.ToString(),false);
            }
        }

        private void EnableOrDisableRxTabCheckBox(string tab,bool IsTrue)
        {
            if (tab.Equals("tab0"))
            {
                chkNewPatient.Enabled = IsTrue;
                chkNewPatient.Checked = IsTrue;
                chkSearchPatient.Enabled = IsTrue;
                chkSearchPatient.Checked = IsTrue;
                chkCC.Enabled = IsTrue;
                chkCC.Checked = IsTrue;
                chkHistory.Enabled = IsTrue;
                chkHistory.Checked = IsTrue;
                chkAdditional.Checked = IsTrue;
                chkAdditional.Enabled = IsTrue;
                chkTreatmentPlan.Enabled = IsTrue;
                chkTreatmentPlan.Checked = IsTrue;
                chkOtherFindings.Enabled = IsTrue;
                chkOtherFindings.Checked = IsTrue;
                chkDrugHistory.Enabled = IsTrue;
                chkDrugHistory.Checked = IsTrue;
                chkSketch.Enabled = IsTrue;
                chkSketch.Checked = IsTrue;
            }

            if (tab.Equals("tab1"))
            {
                chkSettings.Enabled = IsTrue;
                chkSettings.Checked = IsTrue;
                chkTreatment.Enabled = IsTrue;
                chkTreatment.Checked = IsTrue;
                chkAdvices.Checked = IsTrue;
                chkAdvices.Enabled = IsTrue;
                chkTestAdvices2.Enabled = IsTrue;
                chkTestAdvices2.Checked = IsTrue;
                chkDiagnosis2.Checked = IsTrue;
                chkDiagnosis2.Enabled = IsTrue;
            }
        }

        private void DeleteAccessPermission(int userId, string option)
        {
            new RxService().DeleteAccessPermissionItem(userId, option);
        }

        private async void LoadPrintPreference(ChamberPractitioner cp)
        {
            List<RxCPPrintPageSetup> _pageSetup = await new RxService().GetRxCPPageSetup(cp.CPId);
            RxCPPrintPageSetup setupObj = _pageSetup.Where(x => x.PageType == RxPageTypeEnum.FullPrescription.ToString()).FirstOrDefault();

            if (setupObj != null)
            {
                radFullPrint.Checked = true;
                radPortrait.Checked = true;
                txtTopMargin.Text = setupObj.TopMargin.ToString();
                txtRightMargin.Text = setupObj.RightMargin.ToString();
                txtBottomMargin.Text = setupObj.BottomMargin.ToString();
                txtLeftMargin.Text = setupObj.LeftMargin.ToString();
            }


            RxPrintPreference _printPref =  new RxService().GetRxPrintPreference(_cp.CPId);
            string pfInshort = string.Empty;

            if (_printPref != null)
            {
                if (_printPref.PrintFormat1)
                {
                    radPrintFormat1.Checked = true;
                    pfInshort = PrintFormatEnum.PF1.ToString();
                }
                else if (_printPref.PrintFormat2)
                {
                    radPrintFormat2.Checked = true;
                    pfInshort = PrintFormatEnum.PF2.ToString();
                }
                else if (_printPref.PrintFormat3)
                {
                    radPrintFormat3.Checked = true;
                    pfInshort = PrintFormatEnum.PF3.ToString();
                }
                else if (_printPref.PrintFormat4)
                {
                    radPrintFormat4.Checked = true;
                    pfInshort = PrintFormatEnum.PF4.ToString();
                }
                else if (_printPref.PrintFormat5)
                {
                    radPrintFormat5.Checked = true;
                    pfInshort = PrintFormatEnum.PF5.ToString();
                }
                else if (_printPref.PrintFormat6)
                {
                    radPrintFormat6.Checked = true;
                    pfInshort = PrintFormatEnum.PF6.ToString();
                }
                else if (_printPref.PrintFormat7)
                {
                    radPrintFormat7.Checked = true;
                    pfInshort = PrintFormatEnum.PF7.ToString();
                }
                else
                {
                    radPrintFormat8.Checked = true;
                    pfInshort = PrintFormatEnum.PF8.ToString();
                }
            }


            List<RxPrintFormatTemplate> _pfTemplates = new RxService().GetRxPrintFormatTemplates();
            templateImg.Tag = _pfTemplates;

            RxPrintFormatTemplate _pT = _pfTemplates.Where(x => x.PrintFormat == pfInshort).FirstOrDefault();
            if (_pT != null)
            {
                MemoryStream mem = new MemoryStream(_pT.Template);
                templateImg.Image = System.Drawing.Image.FromStream(mem);
               
            }

        }

        private void LoadPersonalInfo(ChamberPractitioner cp)
        {

            btnSave.Text = "Update";

            txtName.Text = cp.Name;

            Doctor _d = new DoctorService().GetDoctorById(cp.DoctorId);
            txtName.Tag = _d;

            txtIdentityLine1.Tag = cp;
            txtIdentityLine1.Text = cp.DIdentityLine1;
            txtIdentityLine2.Text = cp.DIdentityLine2;
            txtIdentityLine3.Text = cp.DIdentityLine3;
            txtIdentityLine4.Text = cp.DIdentityLine4;
            txtIdentityLine5.Text = cp.DIdentityLine5;
            txtIdentityLine6.Text = cp.DIdentityLine6;

            txtFontSizeforIdentity1.Text = cp.Fsize1.ToString();
            txtFontSizeforIdentity1.Text = cp.Fsize1.ToString();
            txtFontSizeforIdentity1.Text = cp.Fsize1.ToString();
            txtFontSizeforIdentity1.Text = cp.Fsize1.ToString();
            txtFontSizeforIdentity1.Text = cp.Fsize1.ToString();

            LoadSpeciality(cp.CPSId);

            dtpfrmTime.Text = cp.PrcticeTimeFrom;
            dtptoTime.Text = cp.PrcticeTimeTo;

            LoadOffDaysCaledarData(cp.CPId);

            if (cp.ESignature != null)
            {
                sgnbox.Image = byteArrayToImage(cp.ESignature);
            }
            else
            {
                sgnbox.Image = null;
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

        private void LoadOffDaysCaledarData(int cPId)
        {
            List<CPOffDayCalender> _offDays = new DoctorService().GetCPOffDays(cPId);
            FillCPOffDayCalendarGrid(_offDays);

        }

        private void FillCPOffDayCalendarGrid(List<CPOffDayCalender> offDays)
        {
            dgOffDay.SuspendLayout();
            dgOffDay.Rows.Clear();
            foreach (var item in offDays)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgOffDay, item.WeeklyOffDay, item.MonthlyOffDate);

                dgOffDay.Rows.Add(row);
            }
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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            RxPrintPreference _printPref = new RxPrintPreference();
            _printPref.CPId = _cp.CPId;
            _printPref.ChiefComplains = radCC.Checked;
            _printPref.ChiefComplainsWithHistory = radCCH.Checked;
            _printPref.BP = chkBP.Checked;
            _printPref.Pulse = chkPulse.Checked;
            _printPref.Weight = chkWght.Checked;
            _printPref.PhysicalExam = chkPhysicalExamination.Checked;
            _printPref.Investigations = chkInvestigations.Checked;
            _printPref.Treatment = chkTreatment.Checked;
          
            _printPref.Diagnosis = chkDiagnosis.Checked;
            _printPref.PrintFormat1 = radPrintFormat1.Checked;
            _printPref.PrintFormat2 = radPrintFormat2.Checked;
            _printPref.PrintFormat3 = radPrintFormat3.Checked;
            _printPref.PrintFormat4 = radPrintFormat4.Checked;
            _printPref.PrintFormat5 = radPrintFormat5.Checked;
            _printPref.PrintFormat6 = radPrintFormat6.Checked;
            _printPref.PrintFormat7 = radPrintFormat7.Checked;
            _printPref.PrintFormat8 = radPrintFormat8.Checked;

            new RxService().SavePrintPreference(_printPref);

            MessageBox.Show("Preference setup successful");
        }

        private void btnSaveRxPageSetup_Click(object sender, EventArgs e)
        {
            double _topMargin = 0;
            double _rightMargin = 0;
            double _bottomMargin = 0;
            double _leftMargin = 0;

            string _printType = string.Empty;
            string _pageOrientation = string.Empty;

            double.TryParse(txtTopMargin.Text, out _topMargin);
            double.TryParse(txtRightMargin.Text, out _rightMargin);
            double.TryParse(txtBottomMargin.Text, out _bottomMargin);
            double.TryParse(txtLeftMargin.Text, out _leftMargin);

            if (radFullPrint.Checked)
            {
                _printType = RxPageTypeEnum.FullPrescription.ToString();

            }
            else if (radTreatmentOnly.Checked)
            {
                _printType = RxPageTypeEnum.TreatmentOnly.ToString();
            }
            else if (radTestOnly.Checked)
            {
                _printType = RxPageTypeEnum.TestsAdvicedOnly.ToString();
            }

            if (radPortrait.Checked)
            {
                _pageOrientation = "Portait";

            }
            else if (radLandscape.Checked)
            {
                _pageOrientation = "Landscape";
            }

            RxCPPrintPageSetup _ps = new RxCPPrintPageSetup();
            _ps.CpId = _cp.CPId;
            _ps.PageType = _printType;
            _ps.PageOrientation = _pageOrientation;
            _ps.TopMargin = _topMargin;
            _ps.RightMargin = _rightMargin;
            _ps.BottomMargin = _bottomMargin;
            _ps.LeftMargin = _leftMargin;
            _ps.footerText = "";
            _ps.headretext = "";

            new RxService().InsertOrUpdateRxCpPrintPageSetup(_ps);

            MessageBox.Show("Setting successful.");

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
                _consultant.ESignature = imgbyte;

                if (new DoctorService().UpdateChamberPractitioner(_consultant))
                {

                    MessageBox.Show("Practitioner Info updated successfully.", "H-ERP");
                }
                else
                {
                    MessageBox.Show("Sorry! Fail to update consultant.", "H-ERP");
                }
            }
        }


        private byte[] GetPrintTemplateImagebyte()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(templateBox.Image);
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }

               
            }
            catch (Exception ex)
            {
                return null;
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

        private void btnCreateSupportUser_Click(object sender, EventArgs e)
        {
            
            
            ChamberPractitioner _cp = (ChamberPractitioner)txtRxBy.Tag;

            if (txtUserName.Tag != null)
            {
                VMUserDetail _uDetail = (VMUserDetail)txtUserName.Tag;

                User _user = new UserService().GetUserById(_uDetail.Id);
                _user.FullName = txtFullName.Text;
                _user.MobileNo = txtMobileNo.Text;
                _user.RoleId = 41;
                _user.ChamberPractitionerId = 0;
                _user.AssignedOutLet = 0;
                _user.MedicineRequisitionForwardToOutLet = 0;
                _user.FloorId = 0;
                _user.DeptId = 0;
                _user.IsIndoorSaleAllowed = false;

                new UserService().UpdateUser(_user);

                MessageBox.Show("User updated successfully.", "H-ERP");

                List<RxCpSupportUserAccessOption> optlist = new List<RxCpSupportUserAccessOption>();
                foreach (Control control in this.tabPage4.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        CheckBox cb = control as CheckBox;
                        if (cb.Checked)
                        {
                            RxCpSupportUserAccessOption Obj = new RxCpSupportUserAccessOption();
                            Obj.SupportUserId = _uDetail.Id;
                            Obj.AccessOption = cb.Tag.ToString();
                            optlist.Add(Obj);
                        }

                    }
                }

                if (optlist.Count > 0)
                {
                    new RxService().InsertOrUpdateCpAssistantAccessPermission(optlist);
                }

                btnCreateSupportUser.Text = "Create";
                txtUserName.Tag = null;
                // ClearPage();
                LoadActiveSupportUsers(_cp);

            }
            else if (String.Compare(txtPassword.Text, txtConfirmPassword.Text) == 0)
            {
                if (txtUserName.Text.Contains(" "))
                {
                    MessageBox.Show("Login name should not contain any space", "HERP");
                    return;
                }

                if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Login name, password and confim password are mandatory field. ", "HERP");
                    return;
                }

                if (new UserService().IsLoginNameExists(txtUserName.Text))
                {
                    MessageBox.Show("Login name already taken by another user. Please try using another name ", "HERP");
                    return;
                }




                string[] _arr = HashGenerator.GetPasswordHashAndSalt(txtPassword.Text);
                User _user = new User();
                _user.LoginName = txtUserName.Text;
                _user.FullName = txtFullName.Text;
                _user.MobileNo = txtMobileNo.Text;
                _user.Password = _arr[0];
                _user.RoleId = 41;
                _user.ChamberPractitionerId = 0;
                _user.AssignedOutLet = 0;
                _user.MedicineRequisitionForwardToOutLet = 0;
                _user.FloorId = 0;
                _user.DeptId = 0;
                _user.IsIndoorSaleAllowed = false;
                _user.Salt = _arr[1];
                _user.CpId = _cp.CPId;
                _user.Status = "Active";
                _user.Comments = "Chamber practitioner support user.";
                int _userId = new UserService().CreateUser(_user);

                if (_userId > 0)
                {

                    new MenuModuleService().GrantCpAssistantPermission(176, _userId);
                    new MenuModuleService().GrantCpAssistantPermission(177, _userId);

                    MessageBox.Show("User created successfully.", "H-ERP");

                    List<RxCpSupportUserAccessOption> optlist = new List<RxCpSupportUserAccessOption>();
                    foreach (Control control in this.tabPage4.Controls)
                    {
                        if (control.GetType() == typeof(CheckBox))
                        {
                            CheckBox cb = control as CheckBox;
                            if (cb.Checked)
                            {
                                RxCpSupportUserAccessOption Obj = new RxCpSupportUserAccessOption();
                                Obj.SupportUserId = _userId;
                                Obj.AccessOption = cb.Tag.ToString();
                                optlist.Add(Obj);
                            }

                        }
                    }

                    if (optlist.Count > 0)
                    {
                        new RxService().InsertOrUpdateCpAssistantAccessPermission(optlist);
                    }

                    // ClearPage();
                    LoadActiveSupportUsers(_cp);
                }
                else
                {
                    MessageBox.Show("Fail to create user.", "HERP");
                }

            }
        }

        private void LoadActiveSupportUsers(ChamberPractitioner cp)
        {
            List<VMUserDetail> _userDetail = new UserService().GetCpAssistantUserDetails(cp.CPId).ToList();

            dgUsers.SuspendLayout();
            dgUsers.Rows.Clear();
            foreach (VMUserDetail user in _userDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = user;
                row.CreateCells(dgUsers, user.Id, user.LoginName, user.FullName, user.MobileNo, user.RoleName, user.Status, false);
                dgUsers.Rows.Add(row);
            }
        }

       

       

        private void dgUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMUserDetail _udetail = dgUsers.SelectedRows[0].Tag as VMUserDetail;
            txtUserName.Tag = _udetail;
            btnCreateSupportUser.Text = "Update";

            txtUserName.Text = _udetail.LoginName;
            txtFullName.Text = _udetail.FullName;
            txtMobileNo.Text = _udetail.MobileNo;

            LoadAccessOptions(_udetail.Id);
        }

        private void LoadAccessOptions(int userId)
        {
            List<RxCpSupportUserAccessOption> optList = new RxService().GetCpAssistAccessOptions(userId);

            ResetAllCheckBoxCheckState();

            foreach (var item in optList)
            {
                if (item.AccessOption.Equals("tab0"))
                {
                    chkInitialData.Checked = true;
                }

                if (item.AccessOption.Equals("tab1"))
                {
                    chkPrescription.Checked = true;
                }

                if (item.AccessOption.Equals("tab2"))
                {
                    chkPrescription.Checked = true;
                }
            }
            
            foreach (var item in optList)
            {
                if (item.AccessOption.Equals("CC"))
                {
                    chkCC.Checked = true;
                }

                if (item.AccessOption.Equals("NewPatient"))
                {
                    chkNewPatient.Checked = true;
                }

                if (item.AccessOption.Equals("SearchPatient"))
                {
                    chkSearchPatient.Checked = true;
                }

                if (item.AccessOption.Equals("History"))
                {
                    chkHistory.Checked = true;
                }

                if (item.AccessOption.Equals("Additional"))
                {
                    chkAdditional.Checked = true;
                }

                if (item.AccessOption.Equals("TreatmentPlan"))
                {
                    chkTreatmentPlan.Checked = true;
                }

                if (item.AccessOption.Equals("OtherFindings"))
                {
                    chkOtherFindings.Checked = true;
                }

                if (item.AccessOption.Equals("DrugHistory"))
                {
                    chkDrugHistory.Checked = true;
                }

                if (item.AccessOption.Equals("Sketch"))
                {
                    chkSketch.Checked = true;
                }

                if (item.AccessOption.Equals("Treatment"))
                {
                    chkTreatment2.Checked = true;
                }

                if (item.AccessOption.Equals("Advices"))
                {
                    chkAdvices2.Checked = true;
                }

                if (item.AccessOption.Equals("TestAdvice"))
                {
                    chkTestAdvices2.Checked = true;
                }

                if (item.AccessOption.Equals("Comments"))
                {
                    chkComments2.Checked = true;
                }

                if (item.AccessOption.Equals("Notes"))
                {
                    chkNotes2.Checked = true;
                }

                if (item.AccessOption.Equals("Diagnosis"))
                {
                    chkDiagnosis2.Checked = true;
                }
            }
        }

        private void ResetAllCheckBoxCheckState()
        {
            IsResetCb = true;
            chkCC.Checked = false;
            chkNewPatient.Checked = false;
            chkSearchPatient.Checked = false;
            chkHistory.Checked = false;
            chkAdditional.Checked = false;
            chkOtherFindings.Checked = false;
            chkDrugHistory.Checked = false;
            chkSketch.Checked = false;
            chkTreatmentPlan.Checked = false;
            chkTreatment2.Checked = false;
            chkAdvices2.Checked = false;
            chkTestAdvices2.Checked = false;
            chkComments2.Checked = false;
            chkNotes2.Checked = false;
            chkDiagnosis2.Checked = false;

            IsResetCb = false;
        }

        private void btnSavePersonalPreference_Click(object sender, EventArgs e)
        {
            ChamberPractitioner _cp = (ChamberPractitioner)txtRxBy.Tag;
            if (_cp != null)
            {
                RxPersonalPreferenceSetting ps = new RxService().GetRxPersonalPrefernce(_cp.CPId);
                if (ps != null)
                {

                    ps.IsDefaultDoseInEnglish = radDDInEnglishYes.Checked;
                    ps.IsDefaultDoseInShortForm = radDDFormShortYes.Checked;
                    ps.IsDefaultAdviceInEnglish = radAdviceInEnglishYes.Checked;
                    ps.IsDefaultDoseFromPersonalDb = radPersonalDb.Checked;
                    ps.IsMedicineInterXEnable = radMedInterXEnable.Checked;
                    if (new RxService().UpdateRxPersonalPreference(ps))
                    {
                        MessageBox.Show("Personal preference updated successfully.");
                    }
                }
                else
                {
                    RxPersonalPreferenceSetting _ps = new RxPersonalPreferenceSetting();
                    _ps.CpId = _cp.CPId;
                    _ps.IsDefaultDoseInEnglish = radDDInEnglishYes.Checked;
                    _ps.IsDefaultDoseInShortForm = radDDFormShortYes.Checked;
                    _ps.IsDefaultAdviceInEnglish = radAdviceInEnglishYes.Checked;
                    _ps.IsDefaultDoseFromPersonalDb = radPersonalDb.Checked;

                    if (new RxService().SaveRxPersonalPreference(_ps))
                    {
                        MessageBox.Show("Personal preference saved successfully.");
                    }
                }
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

        private void btnSaveCarryOnSetting_Click(object sender, EventArgs e)
        {
            RxCarryOnBlock cob = new RxCarryOnBlock();
            cob.CPId = _cp.CPId;
            if (chkCOBCC.Checked)
            {
                cob.ChiefComplains = true;
            }
            else
            {
                cob.ChiefComplains = false;
            }

            if (chkCOBHistory.Checked)
            {
                cob.History = true;
            }
            else
            {
                cob.History = false;
            }

            if (chkCOBAdditional.Checked)
            {
                cob.Additional = true;
            }
            else
            {
                cob.Additional = false;
            }

            if (chkCOBPhysicalFindings.Checked)
            {
                cob.PhysicalFindings = true;
            }
            else
            {
                cob.PhysicalFindings = false;
            }

            if (chkCOBOtherFindings.Checked)
            {
                cob.OtherFindings = true;
            }
            else
            {
                cob.OtherFindings = false;
            }

            if (chkCOBDrugHistory.Checked)
            {
                cob.DrugHistory = true;
            }
            else
            {
                cob.DrugHistory = false;
            }

            if (chkCOBTreatment.Checked)
            {
                cob.Treatment = true;
            }
            else
            {
                cob.Treatment = false;
            }

            if (chkCOBAdvices.Checked)
            {
                cob.Advices = true;
            }
            else
            {
                cob.Advices = false;
            }

            if (chkCOBInvestigations.Checked )
            {
                cob.Tests = true;
            }
            else
            {
                cob.Tests = false;
            }

            if (chkCOBNotes.Checked)
            {
                cob.Notes = true;
            }
            else
            {
                cob.Notes = false;
            }

            if (chkCOBDiagnosis.Checked )
            {
                cob.Diagnosis = true;
            }
            else
            {
                cob.Diagnosis = false;
            }

            if (chkDx.Checked)
            {
                cob.Dx = true;
            }
            else
            {
                cob.Dx = false;
            }

            new RxService().SaveOrUpdateCarryOnBlocks(cob);
            LoadCarryOnBlocks(_cp);
            MessageBox.Show("Carry on setting successful");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog opnfd2 = new OpenFileDialog();
            opnfd2.Filter = "Image Files (*.jpg;*.jpeg;.*.png;.*.bmp;)|*.jpg;*.jpeg;.*.png;.*.bmp;";
            if (opnfd2.ShowDialog() == DialogResult.OK)
            {
                templateBox.Image = new Bitmap(opnfd2.FileName);
            }
        }

        private void btnSavePrintFormat_Click(object sender, EventArgs e)
        {
            byte[] imgbyte = null;
            if (templateBox.Image != null)
            {
                imgbyte = GetPrintTemplateImagebyte();
            }

            RxPrintFormatTemplate _pfTemplate = new RxPrintFormatTemplate();
            string _format = GetPrintFormat();
            _pfTemplate.Template = imgbyte;
            _pfTemplate.PrintFormat = _format;

            if(new RxService().SaveOrUpdateRxPrintFormatTemplate(_pfTemplate))
            {
                MessageBox.Show("Save successful.");
            }
           

        }

        private string GetPrintFormat()
        {
            if (radPrintFormat1.Checked)
            {
                return PrintFormatEnum.PF1.ToString();
            }
            else if (radPrintFormat2.Checked)
            {
                return PrintFormatEnum.PF2.ToString();
            }
            else if (radPrintFormat3.Checked)
            {
                return PrintFormatEnum.PF3.ToString();
            }
            else if (radPrintFormat4.Checked)
            {
                return PrintFormatEnum.PF4.ToString();
            }
            else if (radPrintFormat5.Checked)
            {
                return PrintFormatEnum.PF5.ToString();
            }
            else if (radPrintFormat6.Checked)
            {
                return PrintFormatEnum.PF6.ToString();
            }
            else if (radPrintFormat7.Checked)
            {
                return PrintFormatEnum.PF7.ToString();
            }
            else
            {
                return PrintFormatEnum.PF8.ToString();
            }
        }

        private void radPrintFormat1_Click(object sender, EventArgs e)
        {
            if (radPrintFormat1.Checked)
            {
                if (templateImg.Tag != null)
                {
                    List<RxPrintFormatTemplate> _templates = templateImg.Tag as List<RxPrintFormatTemplate>;
                    RxPrintFormatTemplate templateObj = _templates.Where(x => x.PrintFormat == PrintFormatEnum.PF1.ToString()).FirstOrDefault();

                    if (templateObj != null)
                    {
                        this.DisplayTemplate(templateObj);
                    }

                }
                
            }
        }

        private void DisplayTemplate(RxPrintFormatTemplate templateObj)
        {
            if (templateObj != null)
            {
                MemoryStream mem = new MemoryStream(templateObj.Template);
                templateImg.Image = System.Drawing.Image.FromStream(mem);

            }
        }

        private void radPrintFormat2_Click(object sender, EventArgs e)
        {
            if (radPrintFormat2.Checked)
            {
                if (templateImg.Tag != null)
                {
                    List<RxPrintFormatTemplate> _templates = templateImg.Tag as List<RxPrintFormatTemplate>;
                    RxPrintFormatTemplate templateObj = _templates.Where(x => x.PrintFormat == PrintFormatEnum.PF2.ToString()).FirstOrDefault();

                    if (templateObj != null)
                    {
                        this.DisplayTemplate(templateObj);
                    }

                }

            }
        }

        private void radPrintFormat3_Click(object sender, EventArgs e)
        {
            if (radPrintFormat3.Checked)
            {
                if (templateImg.Tag != null)
                {
                    List<RxPrintFormatTemplate> _templates = templateImg.Tag as List<RxPrintFormatTemplate>;
                    RxPrintFormatTemplate templateObj = _templates.Where(x => x.PrintFormat == PrintFormatEnum.PF3.ToString()).FirstOrDefault();

                    if (templateObj != null)
                    {
                        this.DisplayTemplate(templateObj);
                    }

                }

            }
        }

        private void radPrintFormat4_Click(object sender, EventArgs e)
        {
            if (radPrintFormat4.Checked)
            {
                if (templateImg.Tag != null)
                {
                    List<RxPrintFormatTemplate> _templates = templateImg.Tag as List<RxPrintFormatTemplate>;
                    RxPrintFormatTemplate templateObj = _templates.Where(x => x.PrintFormat == PrintFormatEnum.PF4.ToString()).FirstOrDefault();

                    if (templateObj != null)
                    {
                        this.DisplayTemplate(templateObj);
                    }

                }

            }
        }
    }
}