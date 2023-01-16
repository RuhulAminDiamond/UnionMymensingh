using CrystalDecisions.Windows.Forms;
using DSBarCode;
using HDMS.Common.Utils;
using HDMS.Model.Common;
using HDMS.Model.Location;
using HDMS.Service.Common;
using HDMS.Windows.Forms.UI.Reports.Common;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model;
using HDMS.Service.Rx;
using AForge.Video.DirectShow;
using AForge.Video;
using HDMS.Service.Doctors;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmRegistration : Form
    {
        BarCodeCtrl _control = new BarCodeCtrl();
        Boolean bloading;
        string _patientName = string.Empty;
        bool CalledFromOtherPlace = false;
        bool isLoaded = false;
        bool unlocked = true;
        bool isInMaxView = true;

        public frmRegistration()
        {
            InitializeComponent();
           

        }
        public frmRegistration(Image file)
        {
            InitializeComponent();

            if (file != null) {

                pbox.Image = file; }
                
        }

        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private async void frmRegistration_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0; // default


            FinalFrame = new VideoCaptureDevice();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            ctlDoctorSearch.Location = new Point(txtRefdby.Location.X, txtRefdby.Location.Y);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;


            ctlRegRecordControl.Location = new Point(txtRegisteredRegNo.Location.X, txtRegisteredRegNo.Location.Y);
            ctlRegRecordControl.ItemSelected += ctlRegRecordControl_ItemSelected;


            dtpDOB.Value = DateTime.Now;

            bloading = true;

            List<Country> _countryList = new LocationService().GetAllCountry();
                
            List<Division> _dList = new LocationService().GetAllDivision();

            //cmbDivision.DataSource = _dList;
            //cmbDivision.DisplayMember = "Name";
            //cmbDivision.ValueMember = "DivisionId";


            LoadRegStatus();
            LoadCorporateClients();
            LoadRegDesignations();

            
            bloading = false;

            txtRegNo.Text = "";

            LoadDistricts();

            LoadLocalGurdianDistricts();

            //LoadBarcode();

            LoadRegisterdPatients(dtpregfrm.Value, dtpregto.Value);

            Task t1 = Task.Run(() => LoadTitleCombo());

           

            Task t2 = Task.Run(() => LoadOccupations());

            await Task.WhenAll(t1, t2);

        }


        private void LoadRegisterdPatients(DateTime dtpfrm, DateTime dtpto)
        {
            List<RegRecord> _regList = new RegRecordService().GetRegisterdPatients(dtpfrm, dtpto);


            lblTotalPatient.Text = _regList.Count().ToString();

            string _refdby = string.Empty;

            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();

            dgPatient.Tag = _regList;

            foreach (var item in _regList)
            {


                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;

                Doctor _d = new DoctorService().GetDoctorById(item.RefdId);
                if (_d != null)
                {
                    _refdby = _d.Name;
                }
                else
                {
                    _refdby = "";
                }

                row.CreateCells(dgPatient, item.RegNo, item.RegDate, item.FullName, item.MobileNo, item.MotherName, _refdby);

                dgPatient.Rows.Add(row);
            }


        }


        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtRefdby.Text = item.Name;
            txtRefdby.Tag = item;
            unlocked = true;
            sender.Visible = false;
            
        }

        private async void LoadLocalGurdianDistricts()
        {
            List<District> _districtList = await new CommonService().GetAllDistricts();
            _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

            cmbLocalGurdianDistrict.DataSource = _districtList;
            cmbLocalGurdianDistrict.DisplayMember = "Name";
            cmbLocalGurdianDistrict.ValueMember = "DistrictId";

            isLoaded = true;
        }

        private async void LoadDistricts()
        {
            List<District> _districtList =  await new CommonService().GetAllDistricts();
            _districtList.Insert(0, new District() { DistrictId = 0, Name = "Select District" });

            cmbDistricts.DataSource = _districtList;
            cmbDistricts.DisplayMember = "Name";
            cmbDistricts.ValueMember = "DistrictId";

            isLoaded = true;
        }

        private void LoadRegDesignations()
        {
            List<RegDesignation> _regDesignation = new CommonService().GetRegDesignationList();
            cmbRegDesignation.DataSource = _regDesignation;
            cmbRegDesignation.DisplayMember = "Designation";
            cmbRegDesignation.ValueMember = "DesignationId";
        }

        private void LoadCorporateClients()
        {
            List<CorporateClient> _corporateClients = new CommonService().GetCorporateClientList();
            _corporateClients.Insert(0, new CorporateClient() { CompanyId = 0, Name = "Select Company" });
            cmbCompanyName.DataSource = _corporateClients;
            cmbCompanyName.DisplayMember = "Name";
            cmbCompanyName.ValueMember = "CompanyId";
        }

        private void LoadRegStatus()
        {
            List<RegStatus> _regStatus = new CommonService().GetRegStatusList();
            cmbRegStatus.DataSource = _regStatus;
            cmbRegStatus.DisplayMember = "Status";
            cmbRegStatus.ValueMember = "Id";
        }

        private void ctlRegRecordControl_ItemSelected(SearchResultListControl<RegRecord> sender, RegRecord item)
        {
            txtRegisteredRegNo.Text = item.RegNo.ToString();
            txtRegisteredRegNo.Tag = item;
            sender.Visible = false;
            txtRegisteredRegNo.Focus();


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
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtRegNo.Text = GetNewRegNo();
            pictureBox2.Image = null;
            txtRegisteredRegNo.Tag = null;
            ClearFields();
            btnNew.Visible = true;
            cmbTitle.Focus();
        }

        private void LoadBarcode()
        {
            txtRegNo.Text = GetNewRegNo();
            long _reg =Convert.ToInt64(txtRegNo.Text);
            txtHexValue.Text = _reg.ToString("X");
          

            _control.BarCode = txtRegNo.Text;//txtRegNo.Text.Aggregate(string.Empty, (c, i) => c + i + ' ');
            _control.BarCodeHeight = 15;
            _control.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            _control.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _control.HeaderText = "";
            _control.LeftMargin = 10;
            _control.Location = new System.Drawing.Point(700, 30);
            //_control.Name = "userControl11";
            _control.ShowFooter = true;
            _control.ShowHeader = true;
            _control.Size = new System.Drawing.Size(210, 40);
            _control.TabIndex = 0;
            _control.TopMargin = 1;
            _control.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            _control.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            this.Controls.Add(_control);


            ClearFields();
        }

        private string GetNewRegNo()
        {
            string _regPart1 = Utils.GetRegNo();
            long _regNo = new Random().Next(100000, 999999);
            string _regPart2 = _regNo.ToString()+"1";

            string _RegNo = _regPart1 + _regPart2;

            if (!new RegRecordService().IsRegAlloted(Convert.ToInt64(_RegNo)))
            {
                return _RegNo.ToString();
            }

            GetNewRegNo();

            return "";
        }

        

        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _file = "C:\\RegNoBarcodeImages\\" + txtRegNo.Text + ".png";
            if (!Directory.Exists("C:\\RegNoBarcodeImages")) Directory.CreateDirectory("C:\\RegNoBarcodeImages");
            _control.SaveImage(_file);
            MessageBox.Show("Save successful.");
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDistrictPermanent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (sender as ComboBox);
            if (cbo.SelectedIndex > -1 && !bloading)
            {
                List<UpazilaOrArea> _uList = new LocationService().GetUpazillaByDistrict(Convert.ToInt32(cbo.SelectedValue));
                
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (IsValidEntry())
            {
                int _slefAreaId = 0;
                int _localGurdianAreaId = 0;
               
                UpazilaOrArea _upAreaSelf = (UpazilaOrArea)cmbAreaOrThana.SelectedItem;
                if (_upAreaSelf != null)
                {
                    _slefAreaId = _upAreaSelf.UpazilaId;
                }

                UpazilaOrArea _upAreaLG = (UpazilaOrArea)cmbLocalGurdianThana.SelectedItem;
                if (_upAreaLG != null)
                {
                    _localGurdianAreaId = _upAreaLG.UpazilaId;
                }

                int _refdId = 0;
                if (txtRefdby.Tag != null)
                {
                    Doctor _doc = (Doctor)txtRefdby.Tag;
                    _refdId = _doc.DoctorId;
                }
               

                if (txtRegisteredRegNo.Tag != null)
                {
                    

                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(((RegRecord)txtRegisteredRegNo.Tag).RegNo);
                    _record.Title = cmbTitle.Text;
                    _record.FirstName = txt1stName.Text;
                    _record.MiddleName = txtMiddleName.Text;
                    _record.LastName = txtLastName.Text;
                    _record.FullName = txtPatientName.Text; //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _record.Sex = cmbGenderNE.Text;
                    _record.MaritalStatus = cmbRegStatus.Text;
                    _record.FatherName = txtFatherName.Text;
                    _record.MotherName = txtMotherName.Text;
                    _record.AgeYear = txtYears.Text;
                    _record.AgeMonth = txtMonths.Text;
                    _record.AgeDay = txtDays.Text;
                    _record.DOB = dtpDOB.Value;
                    _record.Profession = cmbOccupation.Text;
                    _record.Address = txtAddress.Text;
                    _record.CareOf = txtCareOfNE.Text;
                    _record.HouseNo = txtHouseNo.Text;
                    _record.RoadNo = txtRoadNo.Text;
                    _record.Village = txtVillage.Text;
                    _record.PO = txtPO.Text;
                    _record.EmailId = txtEmailAddress.Text;
                    _record.NationalId = txtNationalId.Text;
                    _record.CPHouseNo = txtLocalGurdianHouseNo.Text;
                    _record.CPRoadNo = txtLocalGurdianRoadNo.Text;
                    _record.CPVillage = txtLocalGurdianVillage.Text;
                    _record.CPPo = txtLocalGurdianPO.Text;
                    _record.CompanyId = ((CorporateClient)cmbCompanyName.SelectedItem).CompanyId;
                    _record.Status = cmbRegStatus.Text;
                    _record.NationalId = txtNationalId.Text;
                    _record.DesignationId = ((RegDesignation)cmbRegDesignation.SelectedItem).DesignationId;
                    _record.BloodGroup = cmbBloodGroup.Text;
                    _record.UpazilaOrAreaId = _slefAreaId;
                    _record.LocalGurdianUpazilaOrAreaId = _localGurdianAreaId;
                    _record.MobileNo = txtphoneNumbersNE.Text;
                    //_record.refd _refdId
                    if (new RegRecordService().UpdateRegRecord(_record))
                    {
                        if (!String.IsNullOrEmpty(txtRegisteredRegNo.Text) && (pbox.Image != null))
                        {
                            UpdateProfileImage();
                        }

                        MessageBox.Show("Update registration successful.");
                        txtRegisteredRegNo.Text = "";
                        ClearFields();
                    }
                }
                else
                {

                    //RegRecord _record = new RegRecordService().GetRegRecordByMobileNo(txtMobileNo.Text);
                    //if (_record != null)
                    //{
                    //    MessageBox.Show("This mobile no already assigned to reg no. " + _record.ToString());
                    //    return;
                    //}

                    long _regNo = 0;
                    long.TryParse(txtRegNo.Text, out _regNo);

                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);

                    if (_record != null)
                    {
                        txtRegNo.Text = GetNewRegNo();
                        //return;
                    }



                    if (!String.IsNullOrEmpty(txtEmailAddress.Text))
                    {
                        if (!txtEmailAddress.Text.ContainsInvariant("@"))
                        {
                            MessageBox.Show("Email Id required @. ");
                            return;
                        }
                    }

                    double _discount = 0;
                    RegRecord _regRecord = new RegRecord();
                    _regRecord.RegNo = 0;
                    _regRecord.RegHex = "";
                    _regRecord.Title = cmbTitle.Text;
                    _regRecord.FirstName = "";
                    _regRecord.MiddleName = "";
                    _regRecord.LastName = "";
                    _regRecord.FullName = txtPatientName.Text; //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _regRecord.AgeYear = txtYears.Text;
                    _regRecord.AgeMonth = txtMonths.Text;
                    _regRecord.AgeDay = txtDays.Text;
                    _regRecord.DOB = dtpDOB.Value;
                    _regRecord.Sex = cmbGenderNE.Text;
                    _regRecord.MobileNo = txtphoneNumbersNE.Text;
                    _regRecord.EmailId = txtEmailAddress.Text;
                    _regRecord.FatherName = txtFatherName.Text;
                    _regRecord.MotherName = txtMotherName.Text;
                    _regRecord.HouseNo = txtHouseNo.Text;
                    _regRecord.RoadNo = txtRoadNo.Text;
                    _regRecord.Village = txtVillage.Text;
                    _regRecord.PO = txtPO.Text;
                    _regRecord.Address = txtAddress.Text;
                    _regRecord.CareOf = txtCareOfNE.Text;
                    _regRecord.NationalId = "";
                    _regRecord.CPHouseNo = txtLocalGurdianHouseNo.Text;
                    _regRecord.CPRoadNo = txtLocalGurdianRoadNo.Text;
                    _regRecord.CPVillage = txtLocalGurdianVillage.Text;
                    _regRecord.CPPo = txtLocalGurdianPO.Text;
                    _regRecord.CompanyId = 0;
                    _regRecord.Status = "";
                    _regRecord.DesignationId = 0;
                    _regRecord.MaritalStatus = cmbMaritalStatus.Text;
                    _regRecord.Profession = cmbOccupation.Text;
                    _regRecord.UpazilaOrAreaId = _slefAreaId;
                    _regRecord.LocalGurdianUpazilaOrAreaId = _localGurdianAreaId;
                    _regRecord.UnionId = 0;
                    _regRecord.BloodGroup = cmbBloodGroup.Text;
                    _regRecord.CpId = 0;
                    _regRecord.Referredby = _refdId;
                    _regRecord.Discount = 0;
                    _regRecord.NoOfSons = txtNoOfSons.Text;
                    _regRecord.NoOfDaughters = txtNoOfDaughters.Text;
                    _regRecord.RegDate = Utils.GetServerDateAndTime();
                    _regRecord.IsRegisterd = true;
                    // _regRecord.Present_DistrictId = Convert.ToInt32(cmbDivision.SelectedValue);

                    RegRecord _recordSaved = new RegRecordService().SaveRegRecord(_regRecord);

                   
                    if (_recordSaved!=null)
                    {
                        RegRecord _rec = new RegRecordService().GetRegRecordById(_recordSaved.Id);
                        txtRegNo.Text = _rec.RegNo.ToString();

                        MessageBox.Show("Record saved successfully.");
                      
                        if (pictureBox2.Image != null)
                        {
                            ViewCard();
                        }
                        else
                        {
                            ViewCardWithoutPicture();
                        }
                        btnNew.Visible = true;
                        if (!String.IsNullOrEmpty(txtRegNo.Text) && (pictureBox2.Image != null))
                        {
                            SaveProfileImage();
                        }
                        // ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Record save Failed! Plz. check the field and try again");
                    }
                }
            }
            else
            {
                MessageBox.Show("Some required field missing. Plz. check the entry field and try again.");
            }

        }

        private void ViewCardWithoutPicture()
        {
            long _regNo = 0;
            long.TryParse(txtRegNo.Text, out _regNo);

            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);

            rptMembershipCard2 _card = new rptMembershipCard2();

            

            ReportViewer rv = new ReportViewer();

            _card.SetParameterValue("RegNo", txtRegNo.Text);

            if (_record != null)
            {
                _card.SetParameterValue("Name", _record.FullName);
            }
            else
            {
                _card.SetParameterValue("Name", "N/A");
            }
            _card.SetParameterValue("Gender", cmbGenderNE.Text);
            _card.SetParameterValue("MobileNo", txtphoneNumbersNE.Text);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void LoadTitleCombo()
        {
            List<TitleOrNamePrefix> _titleStrins = new RxService().GetTitleStrings();
            this.Invoke(new MethodInvoker(delegate ()
            {
                cmbTitle.DataSource = _titleStrins;
                cmbTitle.DisplayMember = "Title";
                cmbTitle.ValueMember = "Id";

            }));
        }

        private void LoadOccupations()
        {
            List<Occupation> _occulist = new CommonService().GetAllOccupations();
            this.Invoke(new MethodInvoker(delegate ()
            {
                cmbOccupation.DataSource = _occulist;
                cmbOccupation.DisplayMember = "Name";
                cmbOccupation.ValueMember = "Id";

            }));
        }

        private void ViewCard()
        {

            long _regNo = 0;
            long.TryParse(txtRegNo.Text, out _regNo);

            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);

            rptMembershipCard _card = new rptMembershipCard();

            DataTable dtImage = new DataTable();
            // object of data row 
            DataRow drow;
            // add the column in table to store the image of Byte array type 
            dtImage.Columns.Add("ProfileImage", System.Type.GetType("System.Byte[]"));
            dtImage.Columns.Add("pRegNo", System.Type.GetType("System.String"));
            drow = dtImage.NewRow();
            byte[] imgbyte = GetImagebyte();
            drow[0] = imgbyte;
            drow[1] = txtRegNo.Text;

            dtImage.Rows.Add(drow);

            ReportViewer rv = new ReportViewer();
            _card.SetDataSource(dtImage);
            
            
            if (_record != null)
            {
                _card.SetParameterValue("Name", _record.FullName);
            }else
            {
                _card.SetParameterValue("Name", "N/A");
            }
            _card.SetParameterValue("Gender", cmbGenderNE.Text);
            _card.SetParameterValue("MobileNo",txtphoneNumbersNE.Text);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

       

        private int GetUpazillaId()
        {
            if (cmbAreaOrThana.SelectedIndex != -1) return Convert.ToInt32(cmbAreaOrThana.SelectedValue);

            return 0;
        }

        //private string GetFullName(string _title, string _1stName, string _middleName, string _lastName)
        //{

        //   // return _title + " " + _1stName;
        //    return _title + " "+ _1stName+" "+ _middleName+" "+ _lastName;
        //}

        private void SaveProfileImage()
        {
            string _conString = Utility.GetImageDbConnectionString();
            SqlConnection con = new SqlConnection(_conString);
            try
            {
                
                
                byte[] imagedata = GetImagebyte();

                string qry = @"insert into MemberImages (RegNo,ProfileImage) values(@RegNo, @ProfileImage)";

                //Initialize SqlCommand object for insert.
                SqlCommand SqlCom = new SqlCommand(qry, con);

                //We are passing Original Image Path and 
                //Image byte data as SQL parameters.
                SqlCom.Parameters.Add(new SqlParameter("@RegNo",(object)txtRegNo.Text));
                SqlCom.Parameters.Add(new SqlParameter("@ProfileImage", (object)imagedata));

                //Open connection and execute insert query.
                con.Open();
                SqlCom.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }


        private void UpdateProfileImage()
        {
            string _conString = Utility.GetImageDbConnectionString();
            SqlConnection con = new SqlConnection(_conString);
            try
            {

                long _rRegNo = 0;
                long.TryParse(txtRegisteredRegNo.Text, out _rRegNo);

                string qry = string.Format("Delete from MemberImages Where RegNo={0}", _rRegNo);
                con.Open();
                SqlCommand SqlCom = new SqlCommand(qry, con);
                SqlCom.ExecuteNonQuery();
                con.Close();

                byte[] imagedata = GetImagebyte();

                qry = @"insert into MemberImages (RegNo,ProfileImage) values(@RegNo, @ProfileImage)";
                SqlCom = new SqlCommand(qry, con);
                //Initialize SqlCommand object for insert.


                //We are passing Original Image Path and 
                //Image byte data as SQL parameters.
                SqlCom.Parameters.Add(new SqlParameter("@RegNo", (object)txtRegisteredRegNo.Text));
                SqlCom.Parameters.Add(new SqlParameter("@ProfileImage", (object)imagedata));

                //Open connection and execute insert query.
                con.Open();
                SqlCom.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        private byte[] GetImagebyte()
        {
            Byte[] imgBytes = null;
            ImageConverter imgConverter = new ImageConverter();
            imgBytes = (System.Byte[])imgConverter.ConvertTo(pictureBox2.Image, Type.GetType("System.Byte[]"));
            return imgBytes;
        }

        private bool IsValidEntry()
        {
             string _message=string.Empty;
             //if (txtRegNo.Text == "")  _message = ConcatenateMessage(_message, "RegNo");
             if (txt1stName.Text == "") _message = ConcatenateMessage(_message, "Name");
             if (cmbGenderNE.Text == "") _message = ConcatenateMessage(_message, "Sex");
             if (txtphoneNumbersNE.Text == "") _message = ConcatenateMessage(_message, "Mobile No");

             if (String.IsNullOrEmpty(_message))
             {
                 return true;
             }
             else
             {
                 return false;
             }
        }

        private string ConcatenateMessage(string _msg, string _txt)
        {
            return _msg + "," + _txt;
        }

        private void ClearFields()
        {

            foreach (Control ctrl in this.Controls)
            {
               if(ctrl is TextBox || ctrl is ComboBox)
                ctrl.Text="";
                
            }

           
        }

        private void btnCopyto_Click(object sender, EventArgs e)
        {

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            _patientName = txt1stName.Text;
            txt1stName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt1stName.Text.ToLower());
        }

        public static void testm(Image img){

        }
        private void btnWebCam_Click(object sender, EventArgs e)
        {
          
        }

        private void cmbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGenderNE.Text == "")
            {
                MessageBox.Show("Select gender first."); return;
                cmbGenderNE.Focus();
            }

           
        }

       

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Down)
            {
                long _regNo = 0;
                long.TryParse(txtRegNo.Text, out _regNo);
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
                if (_record != null)
                {

                }
            }
        }

        

        private void GetDOB()
        {
            int yrs = 0, mnths = 0,dys=0;
            int.TryParse(txtYears.Text, out yrs);
            int.TryParse(txtMonths.Text, out mnths);
            int.TryParse(txtDays.Text, out dys);

            DateTime _dt = DateTime.Now;
            _dt = _dt.AddYears(0 - yrs);
            _dt = _dt.AddMonths(0 - mnths);
            _dt = _dt.AddDays(0 - dys);

            dtpDOB.Value = _dt;
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            int _dys = 0;
            int.TryParse(txtDays.Text, out _dys);
            if (_dys>0 && _dys <= 31)
            {
                this.GetDOB();
            }
            else
            {
                //MessageBox.Show("days exceed the limit");
                //txtDays.Focus();
            }

         
        }

        private void txtYears_TextChanged(object sender, EventArgs e)
        {
            int _yrs = 0;
            int.TryParse(txtYears.Text, out _yrs);
            if (_yrs <= 200)
            {
                this.GetDOB();
            }else
            {
                //MessageBox.Show("Years exceed the limit");
                //txtYears.Focus();
            }
        }

        

        private void dtpDOB_Leave(object sender, EventArgs e)
        {
            DateDiff dateDiff = new DateDiff(dtpDOB.Value, DateTime.Now);
            int yrs = dateDiff.ElapsedYears;
            int months = dateDiff.ElapsedMonths;
            int dys = dateDiff.ElapsedDays;

            txtYears.Text = yrs.ToString();
            txtMonths.Text = months.ToString();
            txtDays.Text = dys.ToString();

            if (txtPatientName.Text.Substring(0, 2).ToLower() == "mr")
            {
                txtFatherName.Focus();
            }

            if (txtPatientName.Text.Substring(0, 2).ToLower() == "ms")
            {
                txtFatherName.Focus();
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pbox.Image = new Bitmap(open.FileName);
                // image file path  
               // textBox1.Text = open.FileName;
            }  
        }

        

        private void cmbDistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbDistricts.SelectedIndex != -1 && !bloading)
            {
                List<UpazilaOrArea> _upztList = new LocationService().GetUpazillasByDistrict(Convert.ToInt32(cmbDistricts.SelectedValue));
                bloading = true;
                _upztList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
                cmbAreaOrThana.DataSource = _upztList;
                cmbAreaOrThana.DisplayMember = "Name";
                cmbAreaOrThana.ValueMember = "UpazilaId";

               
               

                bloading = false;
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblAge_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            RegRecord _rRecord = null;

            CalledFromOtherPlace = true;


            if (String.IsNullOrEmpty(txtRegisteredRegNo.Text))
            {
                _rRecord = new RegRecordService().GetLastRegNo();
                txtRegisteredRegNo.Tag = _rRecord;
            }
            else
            {
                if (txtRegisteredRegNo.Tag != null)
                {
                    RegRecord _record = (RegRecord)txtRegisteredRegNo.Tag;
                    _rRecord = new RegRecordService().GetSubSequentRegRecordDesc(_record.Id);
                    txtRegisteredRegNo.Tag = _rRecord;
                }

            }

            if (_rRecord != null)
            {
                txtRegisteredRegNo.Text = _rRecord.RegNo.ToString();
                txtRegisteredRegNo.Tag = _rRecord;
                ShowPatientInfo(_rRecord);
            }
            else
            {
                MessageBox.Show("Record not found.");
                txtRegisteredRegNo.Text = "";
                txtRegisteredRegNo.Tag = null;
                CalledFromOtherPlace = false;
                ClearFields();
            }
        }

        private void ShowPatientInfo(RegRecord _rRecord)
        {
            if (_rRecord != null)
            {

                txtRegisteredRegNo.Text = _rRecord.RegNo.ToString();
                cmbTitle.Text = _rRecord.Title;
                //txt1stName.PlaceHolderText = "";
                //txt1stName.Text = _rRecord.FirstName;
                //txtMiddleName.Text = _rRecord.MiddleName;
                //txtLastName.Text = _rRecord.LastName;
                txtPatientName.Text = _rRecord.FullName;
                txtYears.Text = _rRecord.AgeYear;
                txtMonths.Text = _rRecord.AgeMonth;
                txtDays.Text = _rRecord.AgeDay;
                cmbGenderNE.Text = _rRecord.Sex;
                txtFatherName.Text = _rRecord.FatherName;
                txtAddress.Text = _rRecord.MotherName;
                cmbRegStatus.Text = _rRecord.MaritalStatus;
                txtphoneNumbersNE.Text = _rRecord.MobileNo;

                txtEmailAddress.Text = _rRecord.EmailId;

                txtRegisteredRegNo.Tag = _rRecord;


                txtHouseNo.Text = _rRecord.HouseNo;

                if (_rRecord.UpazilaOrAreaId > 0)
                {

                    UpazilaOrArea _upazilla = new LocationService().GetUpazillaById(_rRecord.UpazilaOrAreaId);
                    List<UpazilaOrArea> _uzList = new LocationService().GetUpazillaByDistrict(_upazilla.DistrictId);
                    cmbAreaOrThana.DataSource = _uzList;
                    cmbAreaOrThana.DisplayMember = "Name";
                    cmbAreaOrThana.ValueMember = "UpazilaId";
                    cmbAreaOrThana.SelectedItem = _uzList.Find(q => q.UpazilaId == _rRecord.UpazilaOrAreaId);


                }

                pictureBox2.Image = Utils.GetProfileImage(_rRecord.RegNo);

            }
        }

        private void btnNextId_Click(object sender, EventArgs e)
        {
            RegRecord _rRecord = null;

            CalledFromOtherPlace = true;

            if (String.IsNullOrEmpty(txtRegisteredRegNo.Text))
            {
                _rRecord = new RegRecordService().GetFirstRegNo();
                txtRegisteredRegNo.Tag = _rRecord;
            }
            else
            {
                if (txtRegisteredRegNo.Tag != null)
                {
                    RegRecord _record = (RegRecord)txtRegisteredRegNo.Tag;
                    _rRecord = new RegRecordService().GetSubSequentRegRecordAsc(_record.Id);
                    txtRegisteredRegNo.Tag = _rRecord;
                }

            }

            if (_rRecord != null)
            {
                txtRegisteredRegNo.Text = _rRecord.RegNo.ToString();
                txtRegisteredRegNo.Tag = _rRecord;
                ShowPatientInfo(_rRecord);
            }
            else
            {
                MessageBox.Show("Record not found.");
                txtRegisteredRegNo.Text = "";
                txtRegisteredRegNo.Tag = null;
                CalledFromOtherPlace = false;
                ClearFields();
            }
        }

        private void txtRegisteredRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                long _regNo = 0;
                long.TryParse(txtRegisteredRegNo.Text, out _regNo);
                RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);
                if (_record != null)
                {

                    txtRegisteredRegNo.Tag = _record;
                    ShowPatientInfo(_record);
                }
            }
        }

        private void txt1stName_Leave(object sender, EventArgs e)
        {
            txt1stName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt1stName.Text.ToLower());
           // txtPatientName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtMiddleName_Leave(object sender, EventArgs e)
        {
            txtMiddleName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMiddleName.Text.ToLower());
           // txtPatientName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            txtLastName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text.ToLower());
           // txtPatientName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtFatherName_Leave(object sender, EventArgs e)
        {
            txtFatherName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFatherName.Text.ToLower());
        }

        private void txtMotherName_Leave(object sender, EventArgs e)
        {
            txtMotherName.Text =  CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMotherName.Text.ToLower());
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            long regNo = 0;
            long.TryParse(txtRegisteredRegNo.Text, out regNo);

            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(regNo);
            if (_record!=null)
            {
                if (pbox.Image != null)
                {
                    ViewPreviousCard(_record);
                }
                else
                {
                    ViewPreviousCardWithoutPicture(_record);
                }
            }
        }

        private void ViewPreviousCardWithoutPicture(RegRecord _rRecord)
        {
           

            rptMembershipCard2 _card = new rptMembershipCard2();



            ReportViewer rv = new ReportViewer();

            _card.SetParameterValue("RegNo", _rRecord.RegNo.ToString());
            _card.SetParameterValue("Name", _rRecord.FullName);
           
            _card.SetParameterValue("Gender", cmbGenderNE.Text);
            _card.SetParameterValue("MobileNo", txtphoneNumbersNE.Text);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ViewPreviousCard(RegRecord _rRecord)
       {
           
            rptMembershipCard _card = new rptMembershipCard();

            DataTable dtImage = new DataTable();
            // object of data row 
            DataRow drow;
            // add the column in table to store the image of Byte array type 
            dtImage.Columns.Add("ProfileImage", System.Type.GetType("System.Byte[]"));
            dtImage.Columns.Add("pRegNo", System.Type.GetType("System.String"));
            drow = dtImage.NewRow();
            byte[] imgbyte =  Utils.GetProfileImagebyte(_rRecord.RegNo);
            drow[0] = imgbyte;
            drow[1] = _rRecord.RegNo.ToString();

            dtImage.Rows.Add(drow);

            ReportViewer rv = new ReportViewer();
            _card.SetDataSource(dtImage);


           
            _card.SetParameterValue("Name", _rRecord.FullName);
            
            _card.SetParameterValue("Gender", _rRecord.Sex);
            _card.SetParameterValue("MobileNo", _rRecord.MobileNo);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtRegisteredRegNo_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtRegisteredRegNo.Text) && !CalledFromOtherPlace)
            {
                ctlRegRecordControl.Visible = true;
                ctlRegRecordControl.LoadDataByType(txtRegisteredRegNo.Text);
                ctlRegRecordControl.txtSearch.Text = txtRegisteredRegNo.Text;
                ctlRegRecordControl.txtSearch.SelectionStart = ctlRegRecordControl.txtSearch.Text.Length;
                ctlRegRecordControl.txtSearch.SelectionLength = 0;
            }
        }

        private void txtMobileNo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtphoneNumbersNE.Text))
            {
                string _firstChar = txtphoneNumbersNE.Text.Substring(0, 1);
                if (_firstChar.ToLower() == "0")
                {
                    txtphoneNumbersNE.Text = txtphoneNumbersNE.Text.Remove(0, 1);
                }

                if (txtphoneNumbersNE.Text.Length > 10)
                {
                    MessageBox.Show("Mobile no exceeds 10 digit. Please check and try again.");
                    txtphoneNumbersNE.Focus();
                }
            }
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
            if (txtPatientName.Text.Substring(0, 2).ToLower() == "mr")
            {
                cmbGenderNE.Text = "Male";
            }

            if (txtPatientName.Text.Substring(0, 2).ToLower() == "ms")
            {
                cmbGenderNE.Text = "Female";
            }

            txtYears.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTitle_Leave(object sender, EventArgs e)
        {
            TitleOrNamePrefix _prefix = cmbTitle.SelectedItem as TitleOrNamePrefix;
            if (_prefix != null)
            {
                cmbGenderNE.Text = _prefix.Gender;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt1stName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDistricts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                District _dist = (District)cmbDistricts.SelectedItem;

                List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(_dist.DistrictId);
                _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
                cmbAreaOrThana.DataSource = _uaList;
                cmbAreaOrThana.DisplayMember = "Name";
                cmbAreaOrThana.ValueMember = "UpazilaId";
            }
        }

        private void cmbLocalGurdianDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                District _dist = (District)cmbLocalGurdianDistrict.SelectedItem;

                List<UpazilaOrArea> _uaList = new CommonService().GetUpazilaOrAreaList(_dist.DistrictId);
                _uaList.Insert(0, new UpazilaOrArea() { UpazilaId = 0, Name = "Select Area/Thana" });
                cmbLocalGurdianThana.DataSource = _uaList;
                cmbLocalGurdianThana.DisplayMember = "Name";
                cmbLocalGurdianThana.ValueMember = "UpazilaId";
            }
        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            
            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbGenderNE.Focus();
            }
        }

        private void cmbGenderNE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtYears.Focus();
            }
        }

        private void txtMonths_TextChanged(object sender, EventArgs e)
        {
            int _months = 0;
            int.TryParse(txtMonths.Text, out _months);
            if (_months > 0 && _months <= 12)
            {
                this.GetDOB();
            }
            else
            {
                //MessageBox.Show("days exceed the limit");
                //txtDays.Focus();
            }
        }

        private void txtRefdby_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtRefdby.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtRefdby.Text;
                    if (!string.IsNullOrEmpty(_txt))
                    {
                        HideAllDefaultHidden();
                        ctlDoctorSearch.Visible = true;
                        ctlDoctorSearch.txtSearch.Text = _txt;
                        ctlDoctorSearch.txtSearch.SelectionStart = ctlDoctorSearch.txtSearch.Text.Length;

                        ctlDoctorSearch.LoadData();
                    }
                }
            }

        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
        }

        private void ctlDoctorSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtRefdby.Focus();
            }
        }

        private void cmbTitle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TitleOrNamePrefix _prefix = cmbTitle.SelectedItem as TitleOrNamePrefix;
            if (_prefix != null)
            {
                cmbGenderNE.Text = _prefix.Gender;
            }
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
            FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void frmRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalFrame.SignalToStop();
            FinalFrame.WaitForStop();
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (pbox.Image != null)
            {
                Image Image = (Bitmap)pbox.Image.Clone();

                //Bitmap varBmp = new Bitmap(pictureBox2.Image);
                Bitmap newBitmap = new Bitmap(Image, new Size(160, 130));

                pictureBox2.Image = newBitmap;
            }
        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(18, 12);

            isInMaxView = true;

            btnMaxView.Visible = false;
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(pnlPatient.Location.X + 1250, pnlPatient.Location.Y);

            isInMaxView = false;

            btnMaxView.Visible = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRegisterdPatients(dtpregfrm.Value, dtpregto.Value);
        }

        private void txtAdmId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Trim() == "Search by name")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabySearchParam(txtName.Text, "Name");
            }
        }

        private void LoadPatientsDatabySearchParam(string _searchParam, string _paramType)
        {
            if (dgPatient.Tag != null)
            {
                List<RegRecord> _regList = (List<RegRecord>)dgPatient.Tag;

                if (_paramType == "MobileNo")
                {
                    _regList = _regList.Where(x => x.MobileNo.Contains(_searchParam)).ToList();
                    FillPatientGrid(_regList);
                }
                else if (_paramType == "Name")
                {
                    _regList = _regList.Where(x => x.FullName.Contains(_searchParam)).ToList();
                    FillPatientGrid(_regList);
                }
            }
        }

        private void FillPatientGrid(List<RegRecord> regList)
        {
            string _refdby = string.Empty;

            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();

            foreach (var item in regList)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;

                Doctor _d = new DoctorService().GetDoctorById(item.RefdId);
                if (_d != null)
                {
                    _refdby = _d.Name;
                }
                else
                {
                    _refdby = "";
                }

                row.CreateCells(dgPatient, item.RegNo, item.RegDate, item.FullName, item.MobileNo, item.PresentAddress, _refdby);

                dgPatient.Rows.Add(row);
            }
        }

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchByMobile.Text) || txtSearchByMobile.Text.Trim() == "Search by Mobile No")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabySearchParam(txtSearchByMobile.Text, "MobileNo");
            }
        }
    }
}
