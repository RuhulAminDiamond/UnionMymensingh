using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSBarCode;
using HDMS.Service.Common;
using HDMS.Model.Location;
using HDMS.Model;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Common;
using System.IO;
using HDMS.Common.Utils;
using HDMS.Windows.Forms.UI.Reports.Common;
using CrystalDecisions.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using Itenso.TimePeriod;
using HDMS.Service.Doctors;
using AForge.Video.DirectShow;
using AForge.Video;
using HDMS.Service.Diagonstics;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing.Printing;
using HDMS.Windows.Forms.UI.Diagonstics;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class ctrlRegistration : UserControl
    {
        bool isInMaxView = true;
        bool flag = false;
        string _message = string.Empty;
        public ctrlRegistration()
        {
            InitializeComponent();
        }

        BarCodeCtrl _control = new BarCodeCtrl();
        Boolean bloading;
        string _patientName = string.Empty;
        bool CalledFromOtherPlace = false;
        bool isLoaded = false;
        bool unlocked = true;
        bool IsDobFlagSet = false;

        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;

        private void ctrlRegistration_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();

            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);

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

            dtpDOB.Value = DateTime.Now;

            bloading = true;

            List<Country> _countryList = new LocationService().GetAllCountry();

            List<Division> _dList = new LocationService().GetAllDivision();

            LoadRegStatus();
            LoadCorporateClients();
            LoadRegDesignations();
            bloading = false;

            txtRegNo.Text = "";

            

            LoadRegisterdPatients(dtpregfrm.Value, dtpregto.Value);
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalFrame.SignalToStop();
            FinalFrame.WaitForStop();
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

                row.CreateCells(dgPatient, item.RegNo, item.RegDate.ToString("dd-MM-yyyy"), item.FullName, item.MobileNo, item.MotherName, _refdby);

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

            GetNewRegNoAndClearctrl();


        }

        private void GetNewRegNoAndClearctrl()
        {
            txtRegNo.Text = GetNewRegNo();
            pictureBox2.Image = null;
            txtRegisteredRegNo.Tag = null;
            txtDateofBirth.Tag = null;
            ClearFields();
            btnNew.Visible = true;
            cmbTitle.Focus();
        }

        private void LoadBarcode()
        {
            txtRegNo.Text = GetNewRegNo();
            long _reg = Convert.ToInt64(txtRegNo.Text);
            //  txtHexValue.Text = _reg.ToString("X");


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
            string _regPart2 = _regNo.ToString() + "1";

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

              

                int _refdId = 0;
                if (txtRefdby.Tag != null)
                {
                    Doctor _doc = (Doctor)txtRefdby.Tag;
                    _refdId = _doc.DoctorId;
                }


                    DateTime _dateOfBirth;
               
                    _dateOfBirth = Convert.ToDateTime(txtDateofBirth.Tag);

            
                if (txtRegisteredRegNo.Tag != null)
                {


                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(((RegRecord)txtRegisteredRegNo.Tag).RegNo);
                    _record.Title = cmbTitle.Text;
                    _record.FirstName = ""; //txt1stName.Text;
                    _record.MiddleName = ""; //txtMiddleName.Text;
                    _record.LastName = ""; //txtLastName.Text;
                    _record.FullName = txtPatientName.Text; //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _record.Sex = cmbGender.Text;
                    _record.MaritalStatus = cmbRegStatus.Text;
                    _record.FatherName = txtFatherName.Text;
                    _record.MotherName = txtMotherName.Text;
                    _record.AgeYear = txtYears.Text;
                    _record.AgeMonth = txtMonths.Text;
                    _record.AgeDay = txtDays.Text;
                    _record.DOB = _dateOfBirth;
                    _record.Profession = "";
                    _record.RelationWithPatient =cmbRelationshipWithPatient.Text;
                    
                    _record.EmailId = txtEmailAddress.Text;
                    _record.Address =txtPatientAddress.Text;
                    _record.NationalId = txtNationalId.Text;
                    _record.CPName = txtLocalGurdianName.Text;
                    _record.CPMobile =txtContactPersonNumber.Text;
                    _record.CPAddress =txtGuardianAddress.Text;
                    _record.CompanyId = ((CorporateClient)cmbCompanyName.SelectedItem).CompanyId;
                    _record.Status = cmbRegStatus.Text;
                    _record.NationalId = txtNationalId.Text;
                    _record.DesignationId = ((RegDesignation)cmbRegDesignation.SelectedItem).DesignationId;
                    _record.BloodGroup = cmbBloodGroup.Text;
                    _record.UpazilaOrAreaId = _slefAreaId;
                    _record.LocalGurdianUpazilaOrAreaId = _localGurdianAreaId;
                    _record.MobileNo = txtphoneNumbersNE.Text;
                    _record.RefdId = _refdId;

                    if (new RegRecordService().UpdateRegRecord(_record))
                    {
                        if (!String.IsNullOrEmpty(txtRegisteredRegNo.Text) && (pictureBox2.Image != null))
                        {
                            UpdateProfileImage();
                        }

                        MessageBox.Show("Update registration successful.");

                        if (_record != null)
                        {
                            if (pictureBox2.Image != null)
                            {
                                PrintCardUsingPrintDocument(_record);
                            }
                            else
                            {
                                PrintCardWithoutPictureUsingPrintDocument(_record);
                            }
                        }

                        txtRegisteredRegNo.Text = "";
                        GetNewRegNoAndClearctrl();
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

                    // DateTime _DefaultDate;
                    // _DefaultDate = Convert.ToDateTime("00-00-0000");

                    double _discount = 0;
                    RegRecord _regRecord = new RegRecord();
                    _regRecord.RegNo = 0;
                    _regRecord.RegHex = ""; //txtHexValue.Text;
                    _regRecord.Title = cmbTitle.Text;
                    _regRecord.FirstName = ""; //txt1stName.Text;
                    _regRecord.MiddleName = ""; //txtMiddleName.Text;
                    _regRecord.LastName = ""; //txtLastName.Text;
                    _regRecord.FullName = txtPatientName.Text;  //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _regRecord.AgeYear = txtYears.Text;
                    _regRecord.AgeMonth = txtMonths.Text;
                    _regRecord.AgeDay = txtDays.Text;
                    _regRecord.DOB = _dateOfBirth;
                    _regRecord.Sex = cmbGender.Text;
                    _regRecord.MobileNo = txtphoneNumbersNE.Text;
                    _regRecord.EmailId = txtEmailAddress.Text;
                    _regRecord.FatherName = txtFatherName.Text;
                    _regRecord.MotherName =txtMotherName.Text;
                   _regRecord.Address = txtPatientAddress.Text;
                    
                    _regRecord.NationalId = txtNationalId.Text;
                    _regRecord.CPName =txtLocalGurdianName.Text;
                    _regRecord.RelationWithPatient = cmbRelationshipWithPatient.Text;
                    _regRecord.CPName = txtLocalGurdianName.Text;
                    _regRecord.CPMobile = txtContactPersonNumber.Text;
                    _regRecord.CPAddress = txtGuardianAddress.Text;
                    _regRecord.CompanyId = ((CorporateClient)cmbCompanyName.SelectedItem).CompanyId;
                    _regRecord.Status = cmbRegStatus.Text;
                    _regRecord.DesignationId = ((RegDesignation)cmbRegDesignation.SelectedItem).DesignationId;
                    _regRecord.MaritalStatus = cmbRegStatus.Text;
                    _regRecord.Profession = "";
                    _regRecord.UpazilaOrAreaId = _slefAreaId;
                    _regRecord.LocalGurdianUpazilaOrAreaId = _localGurdianAreaId;
                    _regRecord.UnionId = 0;
                    _regRecord.BloodGroup = cmbBloodGroup.Text;
                    _regRecord.RegDate = Utils.GetServerDateAndTime();
                    _regRecord.Discount = _discount;
                    _regRecord.RefdId = _refdId;
                    _regRecord.IsRegisterd = true;

                    // _regRecord.Present_DistrictId = Convert.ToInt32(cmbDivision.SelectedValue);

                    RegRecord _recordSaved = new RegRecordService().SaveRegRecord(_regRecord);

                    if (_recordSaved != null)
                    {
                        RegRecord _rec = new RegRecordService().GetRegRecordById(_recordSaved.Id);
                        txtRegNo.Text = _rec.RegNo.ToString();

                        MessageBox.Show("Record saved successfully.");
                        if (pictureBox2.Image != null)
                        {
                            //ViewCard();
                            PrintCardUsingPrintDocument(_rec);
                        }
                        else
                        {
                            //ViewCardWithoutPicture();
                            PrintCardWithoutPictureUsingPrintDocument(_rec);
                        }
                        btnNew.Visible = true;
                        if (!String.IsNullOrEmpty(txtRegNo.Text) && (pictureBox2.Image != null))
                        {
                            SaveProfileImage();
                        }

                        GetNewRegNoAndClearctrl();
                    }
                    else
                    {
                        MessageBox.Show("Record save Failed! Plz. check the field and try again");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill up " + _message);
            }



        }
        private string _PName { get; set; }
        private string _NID { get; set; }
        private string _MobileNo { get; set; }
        private string _RegNo { get; set; }
        private string _EDate { get; set; }
        private string _Gender { get; set; }
        private string Age { get; set; }
        private string labAge { get; set; }
        private string _bloodGroup { get; set; }
     

        private void PrintCardWithoutPictureUsingPrintDocument(RegRecord rec)
        {
            PrinterSettings ps = new PrinterSettings();
            PrintDialog pd = new PrintDialog();

            picBarcode.Image = Image.FromStream(Code128bBarcode.CreateBarcode128b(rec.RegNo.ToString()));
            Byte[] arrImage = Code128bBarcode.CreateBarcode128b(rec.RegNo.ToString()).GetBuffer();

            //if (rec.DOB != null &&!flag)
            //{
            //    _Dob = rec.DOB.ToString("dd/MM/yyyy");
            //    labAge = "DOB";
            //}
            //else
            //{
            //    Age = rec.AgeYear;
            //    labAge = "Age";
            //}
            _PName = rec.Title + " " + rec.FullName;
            _NID = rec.NationalId;
            _bloodGroup = rec.BloodGroup;
            _MobileNo = rec.MobileNo;
            _RegNo = rec.RegNo.ToString();
            _EDate = rec.RegDate.ToString("MMMM dd, yyyy");
            _Gender = rec.Sex;

            pd.Document = printDocument2;

            ps.PrinterName = "Zebra ZXP Series 3 USB Card Printer";   //Code to set default printer name
            pd.PrinterSettings.PrinterName = "Zebra ZXP Series 3 USB Card Printer";  //Code to set default printer name 

            //if (pd.ShowDialog() == DialogResult.OK)
            //{
            pd.Document.Print();

        }

        


        private void PrintCardUsingPrintDocument(RegRecord rec)
        {
            PrinterSettings ps = new PrinterSettings();
            PrintDialog pd = new PrintDialog();

            picBarcode.Image = Image.FromStream(Code128bBarcode.CreateBarcode128b(rec.RegNo.ToString()));
            Byte[] arrImage = Code128bBarcode.CreateBarcode128b(rec.RegNo.ToString()).GetBuffer();

            //if (rec.DOB != null && !flag)
            //{
            //    _Dob = rec.DOB.ToString("dd/MM/yyyy");
            //    labAge = "DOB";
            //}
            //else
            //{
            //    Age = rec.AgeYear;
            //    labAge = "Age";
            //}

            _PName = rec.Title + " " + rec.FullName;
            _bloodGroup = rec.BloodGroup;
            _NID =rec.NationalId;
            _MobileNo = rec.MobileNo;
            _RegNo = rec.RegNo.ToString();
            _EDate = rec.RegDate.ToString("MMMM dd, yyyy");
            _Gender = rec.Sex;

            pd.Document = printDocument1;

            ps.PrinterName = "Zebra ZXP Series 3 USB Card Printer";   //Code to set default printer name
            pd.PrinterSettings.PrinterName = "Zebra ZXP Series 3 USB Card Printer";  //Code to set default printer name 

            //if (pd.ShowDialog() == DialogResult.OK)
            //{
            pd.Document.Print();
        }

        private void ViewCardWithoutPicture()
        {
            long _regNo = 0;
            long.TryParse(txtRegNo.Text, out _regNo);

            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_regNo);

            //DataSet ds = new PhFinancialService().GetRegRecordInfo(_regNo);

            rptMembershipCard2 _card = new rptMembershipCard2();



            ReportViewer rv = new ReportViewer();

            string _customFormat = "dd-MM-yyyy";
            _card.SetParameterValue("RegNo", txtRegNo.Text);
            _card.SetParameterValue("DOB", txtDateofBirth.Text);
            _card.SetParameterValue("EDate", dtpfrm.Value.ToString(_customFormat));

            if (_record != null)
            {
                _card.SetParameterValue("Name", _record.FullName);
            }
            else
            {
                _card.SetParameterValue("Name", "N/A");
            }



            _card.SetParameterValue("Gender", cmbGender.Text);
            _card.SetParameterValue("MobileNo", txtphoneNumbersNE.Text);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // rv.crviewer.PrintReport();
            rv.Show();

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
            }
            else
            {
                _card.SetParameterValue("Name", "N/A");
            }

            string _customFormat = "dd-MM-yyyy";
            _card.SetParameterValue("RegNo", txtRegNo.Text);
            _card.SetParameterValue("Gender", cmbGender.Text);
            _card.SetParameterValue("MobileNo", txtphoneNumbersNE.Text);
            _card.SetParameterValue("DOB", txtDateofBirth.Text);
            _card.SetParameterValue("EDate", dtpfrm.Value.ToString(_customFormat));

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            //rv.crviewer.PrintReport();
            rv.Show();
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
                SqlCom.Parameters.Add(new SqlParameter("@RegNo", (object)txtRegNo.Text));
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
        int cnt = 0;
        private bool IsValidEntry()
        {
            cnt = 0;
             _message = string.Empty;
            //if (txtRegNo.Text == "")  _message = ConcatenateMessage(_message, "RegNo");
            if (string.IsNullOrWhiteSpace(txtPatientName.Text)) _message = ConcatenateMessage(_message, "Name");
            if (string.IsNullOrWhiteSpace(cmbGender.Text)) _message = ConcatenateMessage(_message, "Sex");
            if (string.IsNullOrWhiteSpace(txtphoneNumbersNE.Text)) _message = ConcatenateMessage(_message, "Mobile No");
            if (string.IsNullOrWhiteSpace(txtYears.Text)) _message =ConcatenateMessage(_message,"Age");
            if (String.IsNullOrWhiteSpace(_message))
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
            if (cnt == 0)
            {
                cnt = 1;
                return _msg + " " + _txt;
            }
            return _msg + "," + _txt;
            cnt=1;
        }

        private void ClearFields()
        {

            //txtPatientName.Text = "";
            //txtEmailAddress.Text = "";
            //cmbGenderNE.Text = "";
            //txtDateofBirth.Text = "";
            //txtYears.Text = "";
            //txtMonths.Text = "";
            //txtDays.Text = "";
            //cmbBloodGroup.Text = "";
            //txtAddress.Text = "";
            //txtphoneNumbersNE.Text = "";

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                    ctrl.Text = "";

            }

            txtDateofBirth.Text = "";

        }

        private void btnCopyto_Click(object sender, EventArgs e)
        {

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            _patientName = txtPatientName.Text;
            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());
        }

        public static void testm(Image img)
        {

        }
        private void btnWebCam_Click(object sender, EventArgs e)
        {
            //frmWebCam _frmWebcam = new frmWebCam();
            //_frmWebcam.Show();
            //this.Close();
        }

        private void cmbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGender.Text == "")
            {
                MessageBox.Show("Select gender first."); return;
                cmbGender.Focus();
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
            int yrs = 0, mnths = 0, dys = 0;
            int.TryParse(txtYears.Text, out yrs);
            int.TryParse(txtMonths.Text, out mnths);
            int.TryParse(txtDays.Text, out dys);

            DateTime _dt = DateTime.Now;
            _dt = _dt.AddYears(0 - yrs);
            _dt = _dt.AddMonths(0 - mnths);
            _dt = _dt.AddDays(0 - dys);

            txtDateofBirth.Tag = _dt;
            txtDateofBirth.Text = _dt.ToString("dd-MM-yyyy");
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            //int _dys = 0;
            //int.TryParse(txtDays.Text, out _dys);
            //if (_dys > 0 && _dys <= 31 && !IsDobFlagSet)
            //{
            //    this.GetDOB();
            //}
            //else
            //{
            //    //MessageBox.Show("days exceed the limit");
            //    //txtDays.Focus();
            //}


        }

        private void txtYears_TextChanged(object sender, EventArgs e)
        {
            //int _yrs = 0;
            //int.TryParse(txtYears.Text, out _yrs);
            //if (_yrs <= 200 && !IsDobFlagSet)
            //{
            //    this.GetDOB();
            //}
            //else
            //{
            //    //MessageBox.Show("Years exceed the limit");
            //    //txtYears.Focus();
            //}
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

            if (!string.IsNullOrEmpty(txtPatientName.Text))
            {

                //if (txtPatientName.Text.Substring(0, 2).ToLower() == "mr")
                //{
                //    txtFatherName.Focus();
                //}

                //if (txtPatientName.Text.Substring(0, 2).ToLower() == "ms")
                //{
                //    txtFatherName.Focus();
                //}
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
                pictureBox2.Image = new Bitmap(open.FileName);
                // image file path  
                // textBox1.Text = open.FileName;
            }
        }



        private void cmbDistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {

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
            flag = false;

            if (_rRecord != null)
            {

                txtRegisteredRegNo.Text = _rRecord.RegNo.ToString();
                cmbTitle.Text = _rRecord.Title;
                txtPatientName.Text = _rRecord.FullName;
                txtYears.Text = _rRecord.AgeYear;
                txtMonths.Text = _rRecord.AgeMonth;
                txtDays.Text = _rRecord.AgeDay;
                cmbGender.Text = _rRecord.Sex;
                txtFatherName.Text = _rRecord.FatherName;
                txtPatientAddress.Text = _rRecord.MotherName;
                cmbRegStatus.Text = _rRecord.MaritalStatus;
                txtphoneNumbersNE.Text = _rRecord.MobileNo;
                cmbBloodGroup.Text = _rRecord.BloodGroup;
                txtEmailAddress.Text = _rRecord.EmailId;
                txtRegisteredRegNo.Tag = _rRecord;
                txtNationalId.Text = _rRecord.NationalId;


                // txtDateofBirth.Text = (_rRecord.DOB.HasValue?_rRecord.DOB.Value.ToString("dd-MM-yyyy"):null);


                if (_rRecord.DOB != null)
                {
                    txtDateofBirth.Tag = _rRecord.DOB;
                    txtDateofBirth.Text = _rRecord.DOB.ToString("dd-MM-yyyy");
                }
                else
                {

                    int ageyr = 0;
                    int agemnth = 0;
                    int ageday = 0;
                    int.TryParse(_rRecord.AgeYear, out ageyr);
                    int.TryParse(_rRecord.AgeMonth, out agemnth);
                    int.TryParse(_rRecord.AgeDay, out ageday);
                    DateTime _date = Utils.GetServerDateAndTime();
                    DateTime _dt = new DateTime(_date.AddYears(-ageyr).Year, _date.AddMonths(agemnth).Month, _date.AddDays(ageday).Day);
                    txtDateofBirth.Tag = _dt;
                    //txtDateofBirth.Text = _dt.ToString("dd-MM-yyyy"); 
                   //txtYears.Text =ageyr.ToString();
                    flag = true;
                    
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
            //txt1stName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt1stName.Text.ToLower());
            // txtPatientName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtMiddleName_Leave(object sender, EventArgs e)
        {
            // txtMiddleName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMiddleName.Text.ToLower());
            // txtPatientName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            // txtLastName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text.ToLower());
            // txtPatientName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtFatherName_Leave(object sender, EventArgs e)
        {
            txtFatherName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFatherName.Text.ToLower());
        }

        private void txtMotherName_Leave(object sender, EventArgs e)
        {
            txtPatientAddress.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientAddress.Text.ToLower());
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            long regNo = 0;
            long.TryParse(txtRegisteredRegNo.Text, out regNo);

            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(regNo);
            if (_record != null)
            {
                if (pictureBox2.Image != null)
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

            string _customFormat = "dd-MM-yyyy";
            if (!string.IsNullOrEmpty(txtDateofBirth.Text))
            {
                _card.SetParameterValue("Age",txtDateofBirth.Text);
            }
            else
            {
                _card.SetParameterValue("Age", txtYears.Text);
            }
            _card.SetParameterValue("RegNo", txtRegisteredRegNo.Text);
            _card.SetParameterValue("DOB", txtDateofBirth.Text.ToString());
            _card.SetParameterValue("EDate", dtpfrm.Value.ToString(_customFormat));

            _card.SetParameterValue("Name", cmbTitle.Text + " " + _rRecord.FullName);
            //_card.SetParameterValue("Age", txtYears.Text);

            _card.SetParameterValue("Gender", cmbGender.Text);
            _card.SetParameterValue("MobileNo", txtphoneNumbersNE.Text);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // rv.crviewer.PrintReport();
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
            byte[] imgbyte = Utils.GetProfileImagebyte(_rRecord.RegNo);
            drow[0] = imgbyte;
            drow[1] = _rRecord.RegNo.ToString();

            dtImage.Rows.Add(drow);

            ReportViewer rv = new ReportViewer();
            _card.SetDataSource(dtImage);



            _card.SetParameterValue("Name", _rRecord.FullName);

            string _customFormat = "dd-MM-yyyy";
            if(!string.IsNullOrEmpty(txtDateofBirth.Text))
            {
                _card.SetParameterValue("DOB", txtDateofBirth.Text);
            }
            else
            {
                _card.SetParameterValue("DOB", txtYears.Text);
            }
            _card.SetParameterValue("RegNo", txtRegisteredRegNo.Text);
            _card.SetParameterValue("Gender", cmbGender.Text);
            _card.SetParameterValue("MobileNo", txtphoneNumbersNE.Text);
           
            _card.SetParameterValue("EDate", dtpfrm.Value.ToString(_customFormat));
            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtRegisteredRegNo_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtRegisteredRegNo.Text) && !CalledFromOtherPlace)
            {
                //ctlRegRecordControl.Visible = true;
                //ctlRegRecordControl.LoadDataByType(txtRegisteredRegNo.Text);
                //ctlRegRecordControl.txtSearch.Text = txtRegisteredRegNo.Text;
                //ctlRegRecordControl.txtSearch.SelectionStart = ctlRegRecordControl.txtSearch.Text.Length;
                //ctlRegRecordControl.txtSearch.SelectionLength = 0;
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
                cmbGender.Text = "Male";
            }

            if (txtPatientName.Text.Substring(0, 2).ToLower() == "ms")
            {
                cmbGender.Text = "Female";
            }

            txtYears.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

       

      

        private void txtPatientName_Leave(object sender, EventArgs e)
        {

            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());

            cmbGender.Focus();
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbGender.Focus();
            }
        }

        private void cmbGenderNE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDateofBirth.Focus();
            }
        }

        private void txtMonths_TextChanged(object sender, EventArgs e)
        {
            //int _months = 0;
            //int.TryParse(txtMonths.Text, out _months);
            //if (_months > 0 && _months <= 12 && !IsDobFlagSet)
            //{
            //    this.GetDOB();
            //}
            //else
            //{
            //    //MessageBox.Show("days exceed the limit");
            //    //txtDays.Focus();
            //}
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

        private void cmbTitle_Leave(object sender, LayoutEventArgs e)
        {

        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTitle.Text.ToLower() == "mr." || cmbTitle.Text.ToLower() == "md.")
            {
                cmbGender.Text = "Male";
            }
            else if (cmbTitle.Text.ToLower() == "ms." || cmbTitle.Text.ToLower() == "mst." || cmbTitle.Text.ToLower() == "ms")
            {
                cmbGender.Text = "Female";
            }
            else if (cmbTitle.Text.ToLower() == "others.")
            {
                cmbGender.Text = "None";

            }
        }

        private void txtOthers_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDateofBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                IsDobFlagSet = true;
                string _newdateString = "";
                string _dob = txtDateofBirth.Text;
                int Length = 0;
                Length = _dob.Length - 1;

                if (Length == 7)
                {
                    _newdateString = _dob.Substring(4, 4) + _dob.Substring(2, 2) + _dob.Substring(0, 2);

                }
               
                DateTime _dto;
                if (!string.IsNullOrEmpty(_newdateString) && DateTime.TryParseExact(_newdateString, "yyyyMMdd", CultureInfo.InvariantCulture
                                                           , DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out _dto))
                {

                    txtDateofBirth.Tag = _dto;
                    txtDateofBirth.Text = _dto.ToString("dd-MM-yyyy");

                    DateDiff dateDiff = new DateDiff(_dto, DateTime.Now);
                    int yrs = dateDiff.ElapsedYears;
                    int months = dateDiff.ElapsedMonths;
                    int dys = dateDiff.ElapsedDays;

                    txtYears.Text = yrs.ToString();
                    txtMonths.Text = months.ToString();
                    txtDays.Text = dys.ToString();
                }
                else
                {
                    // MessageBox.Show("Invalid date time format.");
                    txtDateofBirth.Text = "";
                }


                txtYears.Focus();


            }
        }

        private void txtPatientName_Leave_1(object sender, EventArgs e)
        {
            txtPatientName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientName.Text.ToLower());

            txtDateofBirth.Focus();
        }

        private void cmbTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPatientName.Focus();
            }
        }

        private void txtPatientName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDateofBirth.Focus();
            }
        }

        private void txtphoneNumbersNE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbBloodGroup.Focus();
            }
        }

        private void cmbBloodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEmailAddress.Focus();
            }
        }

        private void txtEmailAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPatientAddress.Focus();
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)

            //{ 
            //    cmdSave.Focus();
            //}
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

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.Rows.Count > 0)
            {

                pnlPatient.Location = new Point(pnlPatient.Location.X + 1250, pnlPatient.Location.Y);

                isInMaxView = false;

                btnMaxView.Visible = true;

                RegRecord _rRecord = dgPatient.SelectedRows[0].Tag as RegRecord;
                ShowPatientInfo(_rRecord);

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRegisterdPatients(dtpregfrm.Value, dtpregto.Value);
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
                else if (_paramType == "name")
                {
                    _regList = _regList.Where(x => x.FullName.ToLower().Contains(_searchParam.ToLower())).ToList();

                    FillPatientGrid(_regList);
                }
                else if (_paramType == "Regno")
                {
                    _regList = _regList.Where(x => x.RegNo.ToString().Contains(_searchParam.ToLower())).ToList();

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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.ToLower()) || txtName.Text.Trim() == "Search by name")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabySearchParam(txtName.Text, "name");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                List<RegRecord> _regList = new RegRecordService().GetRegisterdPatientByName(txtName.Text);

                FillPatientGrid_3(_regList);
            }
        }

        private void txtSearchByMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                List<RegRecord> _regList = new RegRecordService().GetRegisterdPatientByMobileNo(txtSearchByMobile.Text);

                FillPatientGrid_3(_regList);
            }
        }

        private void FillPatientGrid_3(List<RegRecord> regList)
        {
            string _refdby = string.Empty;

            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            dgPatient.Tag = regList;
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

                row.CreateCells(dgPatient, item.RegNo, item.RegDate.ToString("dd-MM-yyyy"), item.FullName, item.MobileNo, item.MotherName, _refdby);

                dgPatient.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox12.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
            FinalFrame.Start();

        }

        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs) // must be void so that it can be accessed everywhere.
        {                                                                    // New Frame Event Args is an constructor of a class{
            pbox.Image = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
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

        private void pnlPatient_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // this.btnClose();
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            DataSet ds = new ReportService().GetIDPatientList(dtpregfrm.Value, dtpregto.Value);

            ReportViewer rv = new ReportViewer();
            RegList _rpt = new RegList();

            _rpt.SetDataSource(ds.Tables[0]);
            _rpt.SetParameterValue("frm", dtpregfrm.Value.ToString("dd/MM/yyy"));
            _rpt.SetParameterValue("to", dtpregto.Value.ToString("dd/MM/yyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtAdmId_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmId.Text.ToLower()) || txtAdmId.Text.Trim() == "By PID No")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabySearchParam(txtAdmId.Text, "Regno");
            }
        }

        private void txtSearchByAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctlDoctorSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtRefdby.Focus();
            }
        }

        private void txtDateofBirth_Leave(object sender, EventArgs e)
        {
            if (!IsDobFlagSet)
            {
                string _newdateString = "";
                string _dob = txtDateofBirth.Text;
                int Length = 0;
                Length = _dob.Length - 1;

                if (Length == 7)
                {
                    _newdateString = _dob.Substring(4, 4) + _dob.Substring(2, 2) + _dob.Substring(0, 2);

                }
                else
                {
                    MessageBox.Show("Date Length did not match."); return;
                }


                DateTime _dto;
                if (!string.IsNullOrEmpty(_newdateString) && DateTime.TryParseExact(_newdateString, "yyyyMMdd", CultureInfo.InvariantCulture
                                                           , DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out _dto))
                {

                    txtDateofBirth.Tag = _dto;
                    txtDateofBirth.Text = _dto.ToString("dd-MM-yyyy");

                    DateDiff dateDiff = new DateDiff(_dto, DateTime.Now);
                    int yrs = dateDiff.ElapsedYears;
                    int months = dateDiff.ElapsedMonths;
                    int dys = dateDiff.ElapsedDays;

                    txtYears.Text = yrs.ToString();
                    txtMonths.Text = months.ToString();
                    txtDays.Text = dys.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid date time format.");
                    txtDateofBirth.Text = "";
                }
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
         txtPatientAddress.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPatientAddress.Text.ToLower());
        }

        private void btnCameraPostion_Click(object sender, EventArgs e)
        {
            SetCameraFramepositionInCenter();
        }

        private void SetCameraFramepositionInCenter()
        {
            pnlPhotoFramePosition.Location = new Point(490, 100);
        }

        private void btnHideCameraFramePosition_Click(object sender, EventArgs e)
        {
            pnlPhotoFramePosition.Location = new Point(-690, 100);
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
            FinalFrame.Start();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (pbox.Image != null)
            {
                Image Image = (Bitmap)pbox.Image.Clone();

                //Bitmap varBmp = new Bitmap(pictureBox2.Image);
                Bitmap newBitmap = new Bitmap(Image, new Size(160, 130));

                pictureBox2.Image = newBitmap;
                //if (!IsImageCaptured)
                //{
                //    SaveProfileImage();
                //    IsImageCaptured = true;
                //}
                //else
                //{
                //    UpdateProfileImage();
                //}

                pnlPhotoFramePosition.Location = new Point(-490, 150);

            }
        }

        private void txtDateofBirth_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDateofBirth.Text))
            {
                IsDobFlagSet = false;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Far;
                sf.Alignment = StringAlignment.Far;


                Font namefnt = new Font("Arial Narrow", 10, FontStyle.Bold);
                Font namefnt1 = new Font("Arial Narrow", 9, FontStyle.Bold);
                Font othersfnt = new Font("Arial", 9, FontStyle.Bold);
               
                Font namefnt2 = new Font("Arial Black", 10, FontStyle.Bold);
                Font namefnt3 = new Font("Arial", 10, FontStyle.Regular);

                g.DrawImage(pictureBox2.Image, 40, 70, 75, 85);


                g.DrawImage(picBarcode.Image, 180, 55, 120, 30);


                g.DrawString("Issue Date", namefnt1, System.Drawing.Brushes.Black, 210, 15);
                g.DrawString(_EDate, namefnt1, System.Drawing.Brushes.Black, 210, 30);

                g.DrawString("H E A L T H", namefnt2, System.Drawing.Brushes.Black, 33, 30);

                g.DrawString("C", namefnt3, System.Drawing.Brushes.Black, 33, 45);

                g.DrawString("A", namefnt3, System.Drawing.Brushes.Black, 58, 45);

                g.DrawString("R", namefnt3, System.Drawing.Brushes.Black, 83, 45);

                g.DrawString("D", namefnt3, System.Drawing.Brushes.Black, 108, 45);

                g.DrawString(_PName, namefnt, System.Drawing.Brushes.Black, 180, 100);

                g.DrawString("NID", namefnt1, System.Drawing.Brushes.Black, 180, 115);
                g.DrawString(_NID, namefnt1, System.Drawing.Brushes.Black, 210, 115);

                g.DrawString("Blood Group", namefnt1, System.Drawing.Brushes.Black, 180, 130);
                g.DrawString(_bloodGroup, namefnt1, System.Drawing.Brushes.Black, 248, 130);

                g.DrawString("Cell", namefnt1, System.Drawing.Brushes.Black, 180, 145);
                g.DrawString(_MobileNo, namefnt1, System.Drawing.Brushes.Black, 210, 145);


                g.DrawString("Mount Adora Hospital", namefnt2, System.Drawing.Brushes.Black, 150, 180);

            }
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Font namefnt = new Font("Arial Narrow", 10, FontStyle.Bold);
                Font namefnt1 = new Font("Arial Narrow", 9, FontStyle.Bold);
                Font othersfnt = new Font("Arial", 9, FontStyle.Bold);

                Font namefnt2 = new Font("Arial Black", 10, FontStyle.Bold);
                Font namefnt3 = new Font("Arial", 10, FontStyle.Regular);

              //  g.DrawImage(pictureBox2.Image, 40, 70, 75, 85);


                g.DrawImage(picBarcode.Image, 180, 55, 120, 30);


                g.DrawString("Issue Date", namefnt1, System.Drawing.Brushes.Black, 210, 15);
                g.DrawString(_EDate, namefnt1, System.Drawing.Brushes.Black, 210, 30);

                g.DrawString("H E A L T H", namefnt2, System.Drawing.Brushes.Black, 33, 30);

                g.DrawString("C", namefnt3, System.Drawing.Brushes.Black, 33, 45);

                g.DrawString("A", namefnt3, System.Drawing.Brushes.Black, 58, 45);

                g.DrawString("R", namefnt3, System.Drawing.Brushes.Black, 83, 45);

                g.DrawString("D", namefnt3, System.Drawing.Brushes.Black, 108, 45);

                g.DrawString(_PName, namefnt, System.Drawing.Brushes.Black, 180, 100);

                g.DrawString("NID", namefnt1, System.Drawing.Brushes.Black, 180, 115);
                g.DrawString(_NID, namefnt1, System.Drawing.Brushes.Black, 210, 115);

                g.DrawString("Blood Group", namefnt1, System.Drawing.Brushes.Black, 180, 130);
                g.DrawString(_bloodGroup, namefnt1, System.Drawing.Brushes.Black, 248, 130);

                g.DrawString("Cell", namefnt1, System.Drawing.Brushes.Black, 180, 145);
                g.DrawString(_MobileNo, namefnt1, System.Drawing.Brushes.Black, 210, 145);


                g.DrawString("Mount Adora Hospital", namefnt2, System.Drawing.Brushes.Black, 150, 180);
            }
        }

        private void txtMonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDays.Focus();
            }
        }

        private void txtYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMonths.Focus();
            }
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtphoneNumbersNE.Focus();
            }
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCareOfNE_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtRefdby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
        }

        private void txtAdmId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               
                List<RegRecord> _regList = new RegRecordService().GetRegisterdPatientByAdmId(txtAdmId.Text);

                FillPatientGrid_3(_regList);
            }
        }

        private void chkAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddress.Checked)
            {
                txtPatientAddress.Text = txtGuardianAddress.Text;
            }
            else
            {
                txtPatientAddress.Text = "";

            }
        }

        private void txtDateofBirth_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                IsDobFlagSet = true;
                string _newdateString = "";
                string _dob = txtDateofBirth.Text;
                int Length = 0;
                Length = _dob.Length - 1;

                if (Length == 7)
                {
                    _newdateString = _dob.Substring(4, 4) + _dob.Substring(2, 2) + _dob.Substring(0, 2);

                }

                DateTime _dto;
                if (!string.IsNullOrEmpty(_newdateString) && DateTime.TryParseExact(_newdateString, "yyyyMMdd", CultureInfo.InvariantCulture
                                                           , DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out _dto))
                {

                    txtDateofBirth.Tag = _dto;
                    txtDateofBirth.Text = _dto.ToString("dd-MM-yyyy");

                    DateDiff dateDiff = new DateDiff(_dto, DateTime.Now);
                    int yrs = dateDiff.ElapsedYears;
                    int months = dateDiff.ElapsedMonths;
                    int dys = dateDiff.ElapsedDays;

                    txtYears.Text = yrs.ToString();
                    txtMonths.Text = months.ToString();
                    txtDays.Text = dys.ToString();
                }
                else
                {
                    // MessageBox.Show("Invalid date time format.");
                    txtDateofBirth.Text = "";
                }


                txtYears.Focus();


            }
        }

        private void txtDateofBirth_Leave_1(object sender, EventArgs e)
        {
            if (!IsDobFlagSet)
            {
                string _newdateString = "";
                string _dob = txtDateofBirth.Text;
                int Length = 0;
                Length = _dob.Length - 1;

                if (Length == 7)
                {
                    _newdateString = _dob.Substring(4, 4) + _dob.Substring(2, 2) + _dob.Substring(0, 2);

                }
                else
                {
                    MessageBox.Show("Date Length did not match."); return;
                }


                DateTime _dto;
                if (!string.IsNullOrEmpty(_newdateString) && DateTime.TryParseExact(_newdateString, "yyyyMMdd", CultureInfo.InvariantCulture
                                                           , DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out _dto))
                {

                    txtDateofBirth.Tag = _dto;
                    txtDateofBirth.Text = _dto.ToString("dd-MM-yyyy");

                    DateDiff dateDiff = new DateDiff(_dto, DateTime.Now);
                    int yrs = dateDiff.ElapsedYears;
                    int months = dateDiff.ElapsedMonths;
                    int dys = dateDiff.ElapsedDays;

                    txtYears.Text = yrs.ToString();
                    txtMonths.Text = months.ToString();
                    txtDays.Text = dys.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid date time format.");
                    txtDateofBirth.Text = "";
                }
            }
        }

        private void txtDateofBirth_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDateofBirth.Text))
            {
                IsDobFlagSet = false;
            }
        }

        private void lblYears_Click(object sender, EventArgs e)
        {

        }
    }
}
