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

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmRegistration : Form
    {
        BarCodeCtrl _control = new BarCodeCtrl();
        Boolean bloading;
        string _patientName = string.Empty;
        bool CalledFromOtherPlace = false;

        public frmRegistration()
        {
            InitializeComponent();
           

        }
        public frmRegistration(Image file)
        {
            
            if (file != null) { pbox.Image = file; }
                
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

           

            ctlRegRecordControl.Location = new Point(txtRegisteredRegNo.Location.X, txtRegisteredRegNo.Location.Y);
            ctlRegRecordControl.ItemSelected += ctlRegRecordControl_ItemSelected;


            dtpDOB.Value = DateTime.Now;

            bloading = true;

            List<Country> _countryList = new LocationService().GetAllCountry();
                
            List<Division> _dList = new LocationService().GetAllDivision();


            cmbCountry.DataSource = _countryList;
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "CountryId";


            _dList.Insert(0, new Division()
            {
                DivisionId = 0,
                Name = "Select Division",
                BN_Name="",
                CountryId=0
            });

            cmbDivision.DataSource = _dList;
            cmbDivision.DisplayMember = "Name";
            cmbDivision.ValueMember = "DivisionId";

            cmbBNDivision.DataSource = _dList;
            cmbBNDivision.DisplayMember = "BN_Name";
            cmbBNDivision.ValueMember = "DivisionId";
            
            bloading = false;

            txtRegNo.Text = GetNewRegNo();
            //long _reg = Convert.ToInt64(txtRegNo.Text);

            //LoadBarcode();
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
            pbox.Image = null;
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
            //_control.BarCode = txtRegNo.Text;
            //_control.BarCodeHeight = 40;
            //_control.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            //_control.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //_control.HeaderFont = new System.Drawing.Font("Comic Sans MS", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            //_control.HeaderText = "";
            //_control.LeftMargin = 10;
            //_control.Location = new System.Drawing.Point(580, 12);
            ////_control.Name = "userControl11";
            //_control.ShowFooter = true;
            //_control.ShowHeader = true;
            //_control.Size = new System.Drawing.Size(240, 40);
            //_control.TabIndex = 0;
            //_control.TopMargin = 1;
            //_control.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            //_control.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            //this.Controls.Add(_control);

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
                List<Upazila> _uList = new LocationService().GetUpazillaByDistrict(Convert.ToInt32(cbo.SelectedValue));
                
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (IsValidEntry())
            {

                if (txtRegisteredRegNo.Tag != null)
                {
                    

                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(((RegRecord)txtRegisteredRegNo.Tag).RegNo);
                    _record.Title = cmbTitle.Text;
                    _record.FirstName = txt1stName.Text;
                    _record.MiddleName = txtMiddleName.Text;
                    _record.LastName = txtLastName.Text;
                    _record.FullName = txtFullName.Text; //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _record.Sex = cmbGender.Text;
                    _record.MaritalStatus = cmbMaritalStatus.Text;
                    _record.FatherName = txtFatherName.Text;
                    _record.MotherName = txtMotherName.Text;
                    _record.AgeYear = txtYears.Text;
                    _record.AgeMonth = txtMonths.Text;
                    _record.AgeDay = txtDays.Text;
                    _record.DOB = dtpDOB.Value;
                    _record.Profession = cmbOccupation.Text;
                    _record.Address = txtAddress.Text;
                    _record.EmailId = txtEmail.Text;
                    _record.CountryCode = txtCountryCode.Text;
                    _record.MobileNo = txtMobileNo.Text;
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



                    if (!String.IsNullOrEmpty(txtEmail.Text))
                    {
                        if (!txtEmail.Text.ContainsInvariant("@"))
                        {
                            MessageBox.Show("Email Id required @. ");
                            return;
                        }
                    }

                    double _discount = 0;
                    RegRecord _regRecord = new RegRecord();
                    _regRecord.RegNo = Convert.ToInt64(txtRegNo.Text);
                    _regRecord.RegHex = txtHexValue.Text;
                    _regRecord.Title = cmbTitle.Text;
                    _regRecord.FirstName = txt1stName.Text;
                    _regRecord.MiddleName = txtMiddleName.Text;
                    _regRecord.LastName = txtLastName.Text;
                    _regRecord.FullName = txtFullName.Text; //GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
                    _regRecord.AgeYear = txtYears.Text;
                    _regRecord.AgeMonth = txtMonths.Text;
                    _regRecord.AgeDay = txtDays.Text;
                    _regRecord.DOB = dtpDOB.Value;
                    _regRecord.Sex = cmbGender.Text;
                    _regRecord.CountryCode = txtCountryCode.Text;
                    _regRecord.MobileNo = txtMobileNo.Text;
                    _regRecord.EmailId = txtEmail.Text;
                    _regRecord.FatherName = txtFatherName.Text;
                    _regRecord.MotherName = txtMotherName.Text;
                    _regRecord.Address = txtAddress.Text;
                 
                    _regRecord.MaritalStatus = cmbMaritalStatus.Text;
                    _regRecord.Profession = cmbOccupation.Text;
                    _regRecord.UpazilaId = GetUpazillaId();
                    _regRecord.UnionId = GetUnionId();
                  

                    _regRecord.Discount = _discount;

                    // _regRecord.Present_DistrictId = Convert.ToInt32(cmbDivision.SelectedValue);
                    RegRecord _returnrecord = new RegRecordService().SaveRegRecord(_regRecord);
                    if (_returnrecord != null)
                    {
                        MessageBox.Show("Record saved successfully.");
                        if (pbox.Image != null)
                        {
                            ViewCard();
                        }
                        else
                        {
                            ViewCardWithoutPicture();
                        }
                        btnNew.Visible = true;
                        if (!String.IsNullOrEmpty(txtRegNo.Text) && (pbox.Image != null))
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
            _card.SetParameterValue("Gender", cmbGender.Text);
            _card.SetParameterValue("MobileNo", txtCountryCode.Text + txtMobileNo.Text);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
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
            }else
            {
                _card.SetParameterValue("Name", "N/A");
            }
            _card.SetParameterValue("Gender", cmbGender.Text);
            _card.SetParameterValue("MobileNo", txtCountryCode.Text + txtMobileNo.Text);

            rv.crviewer.ReportSource = _card;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private int GetUnionId()
        {
            if (cmbUnion.SelectedIndex != -1) return Convert.ToInt32(cmbUnion.SelectedValue);

            return 0;
        }

        private int GetUpazillaId()
        {
            if (cmbUpazila.SelectedIndex != -1) return Convert.ToInt32(cmbUpazila.SelectedValue);

            return 0;
        }

        private string GetFullName(string _title, string _1stName, string _middleName, string _lastName)
        {

           // return _title + " " + _1stName;
            return _title + " "+ _1stName+" "+ _middleName+" "+ _lastName;
        }

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
            imgBytes = (System.Byte[])imgConverter.ConvertTo(pbox.Image, Type.GetType("System.Byte[]"));
            return imgBytes;
        }

        private bool IsValidEntry()
        {
             string _message=string.Empty;
             if (txtRegNo.Text == "")  _message = ConcatenateMessage(_message, "RegNo");
             if (txt1stName.Text == "") _message = ConcatenateMessage(_message, "Name");
             if (cmbGender.Text == "") _message = ConcatenateMessage(_message, "Sex");
             if (txtMobileNo.Text == "") _message = ConcatenateMessage(_message, "Mobile No");

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
            //txtRegNo.Text = "";
            txt1stName.Text = "";
            txt1stName.PlaceHolderText = "First Name";
            cmbTitle.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtFullName.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtDays.Text = "";
            txtYears.Text = "";
            txtMonths.Text = "";
            txtMobileNo.Text = "";
            txtMobileNo.PlaceHolderText = "Mobile No 10 digit.";
            cmbGender.Text = "";
            cmbOccupation.Text = "";
            cmbMaritalStatus.Text = "";
            pbox.Image = null;

            txtRegisteredRegNo.Tag = null;

            //pbox.Image = null;

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
            frmWebCam _frmWebcam = new frmWebCam();
            _frmWebcam.Show();
            //this.Close();
        }

        private void cmbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGender.Text == "")
            {
                MessageBox.Show("Select sex first."); return;
                cmbGender.Focus();
            }

           // if (String.IsNullOrEmpty(cmbTitle.Text))
           // {
                SetPrefixforName(cmbMaritalStatus.SelectedIndex);
           // }
            
        }

        private void SetPrefixforName(int _mstatus)
        {
            if (_mstatus == 0)
            {
                if (cmbGender.Text == "Male")
                {
                    cmbTitle.Text = "Mr. ";
                }
                else if (cmbGender.Text == "Female")
                {
                    cmbTitle.Text = "Mrs. ";
                }
                else
                {
                    cmbTitle.Text = "Master ";
                }
            }
            else if (_mstatus == 1)
            {
                if (cmbGender.Text == "Male")
                {
                    cmbTitle.Text = "Mr. ";
                }
                else if (cmbGender.Text == "Female")
                {
                    cmbTitle.Text = "Miss. ";
                }
                else
                {
                    cmbTitle.Text = "Master ";
                }
            }
            else
            {
                cmbTitle.Text = "Master ";
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

        private void txtMonths_TextChanged(object sender, EventArgs e)
        {

            int _mnths = 0;
            int.TryParse(txtMonths.Text, out _mnths);
            if (_mnths > 0 && _mnths <= 12)
            {
                this.GetDOB();
            }
            else
            {
               // MessageBox.Show("Months exceed the limit");
               // txtMonths.Focus();
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

            if (txtFullName.Text.Substring(0, 2).ToLower() == "mr")
            {
                txtFatherName.Focus();
            }

            if (txtFullName.Text.Substring(0, 2).ToLower() == "ms")
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

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDivision.SelectedIndex !=-1 && !bloading)
            {
                List<District> _distList = new LocationService().GetDistrictsByDivision(Convert.ToInt32(cmbDivision.SelectedValue));
                bloading = true;

                _distList.Insert(0,new District() { DistrictId=0, Name="Select District" });

                cmbDistrict.DataSource = _distList;
                cmbDistrict.DisplayMember = "Name";
                cmbDistrict.ValueMember = "DistrictId";

                cmbBNDistrict.DataSource = _distList;
                cmbBNDistrict.DisplayMember = "BN_Name";
                cmbBNDistrict.ValueMember = "DistrictId";

                bloading = false;
            }
        }

        private void cmbDistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbDistrict.SelectedIndex != -1 && !bloading)
            {
                List<Upazila> _upztList = new LocationService().GetUpazillasByDistrict(Convert.ToInt32(cmbDistrict.SelectedValue));
                bloading = true;
                _upztList.Insert(0, new Upazila() { UpazilaId = 0, Name = "Select Upazila" });
                cmbUpazila.DataSource = _upztList;
                cmbUpazila.DisplayMember = "Name";
                cmbUpazila.ValueMember = "UpazilaId";

                cmbBNUpazila.DataSource = _upztList;
                cmbBNUpazila.DisplayMember = "BN_Name";
                cmbUpazila.ValueMember = "UpazilaId";

                bloading = false;
            }
        }

        private void cmbUpazila_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrict.SelectedIndex != -1 && !bloading)
            {
                List<Union> _uniontList = new LocationService().GetUnionByUpazilla(Convert.ToInt32(cmbUpazila.SelectedValue));
                bloading = true;

                _uniontList.Insert(0, new Union() { UnionId = 0, Name = "Select Union" });
                cmbUnion.DataSource = _uniontList;
                cmbUnion.DisplayMember = "Name";
                cmbUnion.ValueMember = "UnionId";

                cmbBNUnion.DataSource = _uniontList;
                cmbBNUnion.DisplayMember = "BN_Name";
                cmbBNUnion.ValueMember = "UnionId";

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
                cmbTitle.Text = _rRecord.Title;
                txt1stName.PlaceHolderText = "";
                txt1stName.Text = _rRecord.FirstName;
                txtMiddleName.Text = _rRecord.MiddleName;
                txtLastName.Text = _rRecord.LastName;
                txtFullName.Text = _rRecord.FullName;
                txtYears.Text = _rRecord.AgeYear;
                txtMonths.Text = _rRecord.AgeMonth;
                txtDays.Text = _rRecord.AgeDay;
                cmbGender.Text = _rRecord.Sex;
                txtFatherName.Text = _rRecord.FatherName;
                txtMotherName.Text = _rRecord.MotherName;
                cmbMaritalStatus.Text = _rRecord.MaritalStatus;
                txtMobileNo.Text = _rRecord.MobileNo;
                cmbOccupation.Text = _rRecord.Profession;
                txtEmail.Text = _rRecord.EmailId;

                txtRegisteredRegNo.Tag = _rRecord;


                txtAddress.Text = _rRecord.Address;

                if (_rRecord.UpazilaId > 0)
                {
                    if (_rRecord.UnionId > 0)
                    {
                        List<Union> _unionList = new LocationService().GetUnionByUpazilla(_rRecord.UpazilaId);
                        cmbUnion.DataSource = _unionList;
                        cmbUnion.DisplayMember = "Name";
                        cmbUnion.ValueMember = "UnionId";

                        cmbUnion.SelectedItem= _unionList.Find(q => q.UnionId == _rRecord.UnionId);
                    }

                    Upazila _upazilla = new LocationService().GetUpazillaById(_rRecord.UpazilaId);
                    List<Upazila> _uzList = new LocationService().GetUpazillaByDistrict(_upazilla.DistrictId);
                    cmbUpazila.DataSource = _uzList;
                    cmbUpazila.DisplayMember = "Name";
                    cmbUpazila.ValueMember = "UpazilaId";
                    cmbUpazila.SelectedItem = _uzList.Find(q => q.UpazilaId == _rRecord.UpazilaId);

                    cmbBNUpazila.DataSource = _uzList;
                    cmbBNUpazila.DisplayMember = "BN_Name";
                    cmbBNUpazila.ValueMember = "UpazilaId";
                    cmbBNUpazila.SelectedItem = _uzList.Find(q => q.UpazilaId == _rRecord.UpazilaId);
                }

                pbox.Image = Utils.GetProfileImage(_rRecord.RegNo);

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
            txtFullName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtMiddleName_Leave(object sender, EventArgs e)
        {
            txtMiddleName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMiddleName.Text.ToLower());
            txtFullName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            txtLastName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text.ToLower());
            txtFullName.Text = GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
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
           
            _card.SetParameterValue("Gender", cmbGender.Text);
            _card.SetParameterValue("MobileNo", txtMobileNo.Text);

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
            if (!String.IsNullOrWhiteSpace(txtMobileNo.Text))
            {
                string _firstChar = txtMobileNo.Text.Substring(0, 1);
                if (_firstChar.ToLower() == "0")
                {
                    txtMobileNo.Text = txtMobileNo.Text.Remove(0, 1);
                }

                if (txtMobileNo.Text.Length > 10)
                {
                    MessageBox.Show("Mobile no exceeds 10 digit. Please check and try again.");
                    txtMobileNo.Focus();
                }
            }
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            txtFullName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFullName.Text.ToLower());
            if (txtFullName.Text.Substring(0, 2).ToLower() == "mr")
            {
                cmbGender.Text = "Male";
            }

            if (txtFullName.Text.Substring(0, 2).ToLower() == "ms")
            {
                cmbGender.Text = "Female";
            }

            txtYears.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTitle_Leave(object sender, EventArgs e)
        {
            txtFullName.Text= GetFullName(cmbTitle.Text, txt1stName.Text, txtMiddleName.Text, txtLastName.Text);
        }
    }
}
