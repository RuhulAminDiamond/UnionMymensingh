using HDMS.Model.ShareHolder;
using HDMS.Model.ShareHolder.VM;
using HDMS.Service.ShareHolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.ShareHolder
{
    public partial class frmShareHolderInfo : Form
    {
        bool isInMaxView = true;

        public frmShareHolderInfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmShareHolderInfo_Load(object sender, EventArgs e)
        {
            IList<ShareHolderRelation> shrlist = new ShareHolderService().GetShareHolderRelation().ToList();
            shrlist.Insert(0,new ShareHolderRelation() { RelationId=0,Name=""});
            CmbRelation2.DataSource = shrlist;
            CmbRelation2.DisplayMember = "Name";
            CmbRelation2.ValueMember = "RelationId";
            LoadData();
            //LoadDataDependants();
            //LoadShInDescendant();

        }

        private void txtShName_TextChanged(object sender, EventArgs e)
        {

        }
        private bool isValid()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(txtShName.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtShFname.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtShMName.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtShprsntAddress.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtpermanentAddress.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtNationality.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtNationalId.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtMobileNo.Text)) flag = false;
           
            if (string.IsNullOrWhiteSpace(cmbfiscal.Text)) flag = false;

            if (string.IsNullOrWhiteSpace(txtNmName.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtNmFName.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtNmMName.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtNmAddress.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtNmMobile.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(cmbRelation.Text)) flag = false;

            int shareNo = 0;
            int.TryParse(txtShareNo.Text, out shareNo);
            if (shareNo == 0) flag = false;

            return flag;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            long shareno; int totalshare; double facevalue;
            Int64.TryParse(txtShareNo.Text, out shareno);
            Int32.TryParse(txtTotalShare.Text, out totalshare);
            double.TryParse(txtFaceValue.Text, out facevalue);

            byte[] Nomineeimagedata = null; 
            if(picnominee.Image!=null)  Nomineeimagedata= GetNomineeImageByte();

            byte[] Shareholderimagedata = null;
            if(picshareholder.Image!=null)  Shareholderimagedata = GetShareHolderImageByte();

            if (txtShName.Tag!=null)
            {   
                VMShareHolderInfo sh = txtShName.Tag as VMShareHolderInfo;
                ShareHolderBasicData sg = new ShareHolderService().GetShareHolderId(sh.ShId);
                sg.ShName = txtShName.Text;
                sg.ShFName = txtShFname.Text;
                sg.ShMName = txtShMName.Text;
                sg.ShSpouseName = txtShSpName.Text;
                sg.ShPresentAddress = txtShprsntAddress.Text;
                sg.ShPermanentAddress = txtpermanentAddress.Text;
                sg.ShMobile = txtMobileNo.Text;
                sg.ShPhone = txtPhoneNo.Text;
                sg.ShEmail = txtEmail.Text;
                sg.ShDOB = dtpDob.Value;
                sg.ShNationality = txtNationality.Text;
                sg.ShNationalId = txtNationalId.Text;
                sg.ShPassportNo = txtPassport.Text;
                sg.ShDrivingLicenseNo = txtDrivingLicense.Text;
                sg.ShStartingFiscalYear = cmbfiscal.Text;
                sg.ShNoofSons = txtNoOfSons.Text;
                sg.ShNoofDaughter = txtNoOfDaughter.Text;
                sg.NmName = txtNmName.Text;
                sg.NmFName = txtNmFName.Text;
                sg.NmContactNo = txtNmMobile.Text;
                sg.NmMName = txtNmMName.Text;
                sg.NmAddress = txtNmAddress.Text;
                sg.NmRelation = cmbRelation.Text;
                sg.ShareHolderImg = Shareholderimagedata;
                sg.NomineeImg = Nomineeimagedata;
                sg.NomineeNID = txtNomineeNID.Text;

                if (totalshare > 0)
                {
                    sg.isActive = true;
                }
                else
                {
                    sg.isActive = false;
                }

                if (new ShareHolderService().UpdateShareHolder(sg))
                {

                    ShareInfo share = new ShareHolderService().GetShareHolderById(sg.ShId);
                    share.ShareNo = shareno;
                    share.TotalShare = totalshare;
                    share.FaceValue = facevalue;
                    share.ShId = sg.ShId;
                    share.TotalInvestment = (facevalue * (double)totalshare);

                    new ShareHolderService().UpShareInfo(share);

                    MessageBox.Show("Updated Successfully");
                    LoadData();
                }
                else
                {
                    MessageBox.Show(" Not Updated ");
                }
            }
            else
            {
                if(isValid())
                {
                    ShareHolderBasicData sg = new ShareHolderBasicData();
                    sg.ShName = txtShName.Text;
                    sg.ShFName = txtShFname.Text;
                    sg.ShMName = txtShMName.Text;
                    sg.ShSpouseName = txtShSpName.Text;
                    sg.ShPresentAddress = txtShprsntAddress.Text;
                    sg.ShPermanentAddress = txtpermanentAddress.Text;
                    sg.ShMobile = txtMobileNo.Text;
                    sg.ShPhone = txtPhoneNo.Text;
                    sg.ShEmail = txtEmail.Text;
                    sg.ShDOB = dtpDob.Value;
                    sg.ShNationality = txtNationality.Text;
                    sg.ShNationalId = txtNationalId.Text;
                    sg.ShPassportNo = txtPassport.Text;
                    sg.ShDrivingLicenseNo = txtDrivingLicense.Text;
                    sg.ShStartingFiscalYear = cmbfiscal.Text;
                    sg.ShNoofSons = txtNoOfSons.Text;
                    sg.ShNoofDaughter = txtNoOfDaughter.Text;
                    sg.NmName = txtNmName.Text;
                    sg.NmFName = txtNmFName.Text;
                    sg.NmContactNo = txtNmMobile.Text;
                    sg.NmMName = txtNmMName.Text;
                    sg.NmAddress = txtNmAddress.Text;
                    sg.NmRelation = cmbRelation.Text;
                    sg.ShareHolderImg = Shareholderimagedata;
                    sg.NomineeImg = Nomineeimagedata;
                    sg.NomineeNID = txtNomineeNID.Text;

                    if (totalshare > 0)
                    {
                        sg.isActive = true;
                    }
                    else
                    {
                        sg.isActive = false;
                    }

                    if(new ShareHolderService().isShareNoUsed(shareno))
                    {
                        MessageBox.Show("Share no. is already used. Try with a different one.");
                        return;
                    }

                    if (new ShareHolderService().SaveShareHolder(sg))
                    {

                        ShareInfo shareInfo = new ShareInfo();
                        shareInfo.ShareNo = shareno;
                        shareInfo.TotalShare = totalshare;
                        shareInfo.FaceValue = facevalue;
                        shareInfo.ShId = sg.ShId;
                        shareInfo.TotalInvestment = (facevalue * (double)totalshare);

                        new ShareHolderService().SaveShareInfo(shareInfo);

                        int year = Utils.GetServerDateAndTime().Year;
                        if (!new ShareHolderService().IsShareExistsInYearOnYearShare(sg.ShId, year))
                        {
                            YearOnYearShareInfo shObj = new YearOnYearShareInfo();
                            shObj.ShId = sg.ShId;
                            shObj.TotalShare = totalshare;
                            shObj.Year = year;
                            new ShareHolderService().SaveYearOnYearShareInfo(shObj);
                        }


                        MessageBox.Show("Saved Successfully");
                        LoadData();
                        
                    }
                    else
                        MessageBox.Show("Not Saved");

                }
                else
                {
                    MessageBox.Show("Please Fill up all required field");
                }
             
            }
        }

        private byte[] GetNomineeImageByte()
        {
            Byte[] imgbyte = null;
            ImageConverter imgconverter = new ImageConverter();
            imgbyte = (System.Byte[])imgconverter.ConvertTo(picnominee.Image, Type.GetType("System.Byte[]"));
            return imgbyte;
        }

        private byte[] GetShareHolderImageByte()
        {
            Byte[] imgbyte = null;
            ImageConverter imgconverter = new ImageConverter();
            imgbyte = (System.Byte[])imgconverter.ConvertTo(picshareholder.Image, Type.GetType("System.Byte[]"));
            return imgbyte;
        }

        private void LoadData()
        {
            IList<VMShareHolderInfo> shlist = new ShareHolderService().GetAllShareHolderWithShareInfo();
            dgShareHolder.Tag = shlist;
            FillGrid(shlist);
            dgShareHolderInfo.Tag = shlist;
            FillGridShInDescendant(shlist);

            txtShName.Text="";
            txtShName.Text="";
            txtShFname.Text = "";
            txtShMName.Text="";
            txtShSpName.Text="";
            txtShprsntAddress.Text="";
            txtpermanentAddress.Text="";
            txtMobileNo.Text="";
            txtPhoneNo.Text="";
            txtEmail.Text="";
            txtNationality.Text="";
            txtNationalId.Text = "";
            txtPassport.Text="";
            txtDrivingLicense.Text="";
            cmbfiscal.Text="";
            txtNoOfDaughter.Text = "";
            txtNoOfSons.Text = "";
            txtNmName.Text="";
            txtNmFName.Text = "";
            txtNmMName.Text="";
            txtNmMobile.Text = "";
            txtNmAddress.Text="";
            txtNmMobile.Text = "";
            cmbRelation.Text="";
            txtShName.Tag = null;
            picshareholder.Image = null;
            picnominee.Image = null;
            txtNomineeNID.Text = "";
            txtShareNo.Text = "";
        }

        private void FillGrid(IList<VMShareHolderInfo> shlist)
        {
            dgShareHolder.SuspendLayout();
            dgShareHolder.Rows.Clear();
            foreach(VMShareHolderInfo sh in shlist)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = sh;
                row.CreateCells(dgShareHolder,sh.ShareNo, sh.ShName,sh.ShPermanentAddress,sh.ShMobile,sh.ShEmail,sh.TotalShare);
                dgShareHolder.Rows.Add(row);
            }

            lblTotalShareHolder.Text = shlist.Count().ToString();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtShName.Text = "";
            txtShName.Text = "";
            txtShFname.Text = "";
            txtShMName.Text = "";
            txtShSpName.Text = "";
            txtShprsntAddress.Text = "";
            txtpermanentAddress.Text = "";
            txtMobileNo.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            dtpDob.Value = DateTime.Now;
            txtNationality.Text = "";
            txtNationalId.Text = "";
            txtPassport.Text = "";
            txtDrivingLicense.Text = "";
            cmbfiscal.Text = "";
            txtNoOfDaughter.Text = "";
            txtNoOfSons.Text = "";
            txtNmName.Text = "";
            txtNmFName.Text = "";
            txtNmMName.Text = "";
            txtNmMobile.Text = "";
            txtNmAddress.Text = "";
            txtNmMobile.Text = "";
            cmbRelation.Text = "";
            txtShName.Tag = null;
            txtNomineeNID.Text = "";
            LoadData();
        }

        private void dgShareHolder_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMShareHolderInfo sg = dgShareHolder.SelectedRows[0].Tag as VMShareHolderInfo;
            if (sg != null)
            {
                txtShName.Text = sg.ShName;
                txtShFname.Text = sg.ShFName;
                txtShMName.Text = sg.ShMName;
                txtShSpName.Text = sg.ShSpouseName;
                txtShprsntAddress.Text = sg.ShPresentAddress;
                txtpermanentAddress.Text = sg.ShPermanentAddress;
                txtMobileNo.Text = sg.ShMobile;
                txtPhoneNo.Text = sg.ShPhone;
                txtEmail.Text = sg.ShEmail;
                dtpDob.Value = sg.ShDOB;
                txtNationality.Text = sg.ShNationality;
                txtNationalId.Text = sg.ShNationalId;
                txtPassport.Text = sg.ShPassportNo;
                txtDrivingLicense.Text = sg.ShDrivingLicenseNo;
                cmbfiscal.Text = sg.ShStartingFiscalYear;
                txtNoOfDaughter.Text = sg.ShNoofDaughter;
                txtNoOfSons.Text = sg.ShNoofSons;
                txtNmName.Text = sg.NmName;
                txtNmFName.Text = sg.NmFName;
                txtNmMName.Text = sg.NmMName;
                txtNmMobile.Text = sg.NmContactNo;
                txtNmAddress.Text = sg.NmAddress;
                txtNmMobile.Text = sg.NmContactNo;
                cmbRelation.Text = sg.NmRelation;
                dtpDob.Value = sg.ShDOB;
                txtShName.Tag = sg;
                txtNomineeNID.Text = sg.NomineeNID;

                if (sg.ShareHolderImg != null)
                {
                    MemoryStream memSh = new MemoryStream(sg.ShareHolderImg);
                    picshareholder.Image = System.Drawing.Image.FromStream(memSh);
                }
                else
                {
                    picshareholder.Image = null;
                }

                if (sg.NomineeImg != null)
                {
                    MemoryStream memNm = new MemoryStream(sg.NomineeImg);
                    picnominee.Image = System.Drawing.Image.FromStream(memNm);
                }
                else
                {
                    picnominee.Image = null;
                }

                txtShareNo.Text = sg.ShareNo.ToString();
                txtTotalShare.Text = sg.TotalShare.ToString();

                IList<ShareHolderDescendantsInfo> sp = new ShareHolderService().DataViewSh(sg.ShId);
                FillGridDependants(sp);


                MiniMizeTheViewPanel();

            }
        }

        private string MiniMizeTheViewPanel()
        {
           
                pnlPatient.Location = new Point(pnlPatient.Location.X + 1280, pnlPatient.Location.Y);

                isInMaxView = false;

                btnMaxView.Visible = true;

            return "";
        }

        private void cmbfiscal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtShName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtShFname.Focus();
            }
        }

        private void txtShFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtShMName.Focus();
            }
        }

        private void txtShMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtShSpName.Focus();
            }
        }

        private void txtShSpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpDob.Focus();
            }
        }

        private void txtShprsntAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtpermanentAddress.Focus();
            }
        }

        private void txtpermanentAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNationality.Focus();
            }
        }

        private void txtNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtNationalId.Focus();
        }

        private void dtpDob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtShprsntAddress.Focus();
        }

        private void txtNationalId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNoOfSons.Focus();
            }
        }

        private void txtNoOfSons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNoOfDaughter.Focus();
            }
        }

        private void txtNoOfDaughter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                txtMobileNo.Focus();
            }
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPhoneNo.Focus();
            }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassport.Focus();
            }
        }

        private void txtPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDrivingLicense.Focus();
            }
        }

        private void txtDrivingLicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbfiscal.Focus();
            }
        }

        private void cmbfiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNmName.Focus();
            }
        }

        private void txtNmName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNmFName.Focus();
            }
        }

        private void txtNmFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNmMName.Focus();
            }
        }

        private void txtNmMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNmAddress.Focus();
            }
        }

        private void txtNmAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtNmMobile.Focus();
        }

        private void txtNmMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cmbRelation.Focus();
        }

        private void cmbRelation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Save.Focus();
            }
        }

        private void btn_Save_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Cancel.Focus();
            }
        }

        private void btn_Cancel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btn_Close.Focus();
        }

        private void btn_Close_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtShName.Focus();
            }
        }

       
        //private void LoadSH(string text)
        //{
        //    IList<ShareHolderBasicData> sh = new ShareHolderService().GetShareHolderByName(text);
        //   // FillGrid(sh);
        //}

        //private void placeHolderTextBox1_TextChanged(object sender, EventArgs e)
        //{
        //    if(string.IsNullOrWhiteSpace(txtsearch2.Text)||txtsearch2.Text.Trim()== "Search By ShareHolder Name")
        //    {
        //        LoadShInDescendant();
        //    }
        //    else
        //    {
        //        LoadSh2(txtsearch2.Text);
                
        //    }
        //}

        private void LoadSh2(string text)
        {
            IList<ShareHolderBasicData> sh = new ShareHolderService().GetShareHolderByName(text);
           // FillGridShInDescendant(sh);
        }

        private void LoadShInDescendant()
        {
            IList<VMShareHolderInfo> shlist = new ShareHolderService().GetAllShareHolderWithShareInfo();
            dgShareHolderInfo.Tag = shlist;
            FillGridShInDescendant(shlist);
            
        }

        private void FillGridShInDescendant(IList<VMShareHolderInfo> shlist)
        {
            dgShareHolderInfo.SuspendLayout();
            dgShareHolderInfo.Rows.Clear();
            foreach (VMShareHolderInfo sh in shlist)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = sh;
                row.CreateCells(dgShareHolderInfo, sh.ShareNo, sh.ShName);
                dgShareHolderInfo.Rows.Add(row);
            }

        }

        private void PIC_PROFILE_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void MotherName_Click(object sender, EventArgs e)
        {

        }

        private void SpouseName_Click(object sender, EventArgs e)
        {

        }

        private void PresentAddress_Click(object sender, EventArgs e)
        {

        }

        private void CurrentAddress_Click(object sender, EventArgs e)
        {

        }

        private void Mobile_Click(object sender, EventArgs e)
        {

        }

        private void Phone_Click(object sender, EventArgs e)
        {

        }

        private void EMail_Click(object sender, EventArgs e)
        {

        }

        private void DOB_Click(object sender, EventArgs e)
        {

        }

        private void Nationality_Click(object sender, EventArgs e)
        {

        }

        private void NationalId_Click(object sender, EventArgs e)
        {

        }

        private void StFiscalYear_Click(object sender, EventArgs e)
        {

        }

        private void NomineeName_Click(object sender, EventArgs e)
        {

        }

        private void NmFName_Click(object sender, EventArgs e)
        {

        }

        private void NmMotherName_Click(object sender, EventArgs e)
        {

        }

        private void NmAddress_Click(object sender, EventArgs e)
        {

        }

        private void NmContactNo_Click(object sender, EventArgs e)
        {

        }

        private void NmRelation_Click(object sender, EventArgs e)
        {

        }

        private void NoofSons_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtShMName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShSpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpermanentAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShprsntAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNationality_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNationalId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoOfSons_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoOfDaughter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNmFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNmMName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNmAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNmMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void passportno_Click(object sender, EventArgs e)
        {

        }

        private void DrivingLicense_Click(object sender, EventArgs e)
        {

        }

        private void txtPassport_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDrivingLicense_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NmName_Click(object sender, EventArgs e)
        {

        }

        private void txtNmName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRelation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if(open.ShowDialog() == DialogResult.OK)
            {
                PIC_PROFILE.Image = new Bitmap(open.FileName);
            }
        }

        private void dtpDpDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            byte[] imagedata = GetImageByte();
            //int res=new ShareHolderService().GetShareholderIdByName(lblSh1.Text);
            VMShareHolderInfo shd = lblSh1.Tag as VMShareHolderInfo;

            ShareHolderRelation shr = (ShareHolderRelation)CmbRelation2.SelectedItem;
            if (txtName2.Tag!=null)
            {
                ShareHolderDescendantsInfo sh = txtName2.Tag as ShareHolderDescendantsInfo;
               // ShareHolderDescendantsInfo sh = new ShareHolderService().GetShareHolder(shd.ShId);
                sh.Name = txtName2.Text;
                sh.Gender = CmbGender.Text;
                sh.Dob = dtpDpDOB.Value;
                sh.Relation = CmbRelation2.Text;
                sh.RelationId = shr.RelationId;
                sh.ShId = shd.ShId;
                sh.Img = imagedata;
                sh.NID = txtDependantNID.Text;
                if (new ShareHolderService().DsUpdateShareHolder(sh))
                {
                    MessageBox.Show("Updated Successfully");
                    LoadDataDependants();
                    PIC_PROFILE.Image = null;
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }

            }
            else
            {   if(!string.IsNullOrWhiteSpace(lblSh1.Text))
                {
                   if(!string.IsNullOrWhiteSpace(txtName2.Text)&&!string.IsNullOrWhiteSpace(CmbRelation2.Text))
                   {
                        ShareHolderDescendantsInfo sh = new ShareHolderDescendantsInfo();
                        sh.Name = txtName2.Text;
                        sh.Gender = CmbGender.Text;
                        sh.Dob = dtpDpDOB.Value;
                        sh.NID = txtDependantNID.Text;
                        sh.Relation = CmbRelation2.Text;
                        sh.RelationId = shr.RelationId;
                        sh.ShId = shd.ShId;
                        sh.Img = imagedata;
                        if (new ShareHolderService().DsSaveShareHolder(sh))
                        {
                            MessageBox.Show("Saved Successfully");
                            LoadDataDependants();

                            PIC_PROFILE.Image = null;

                        }
                        else MessageBox.Show("Not Saved");
                   }
                }
                else MessageBox.Show("Please Select Shareholder Name");


            }
        }
        private void LoadDataDependants()
        {
            IList<ShareHolderDescendantsInfo> shlist = new ShareHolderService().GetAllShareHolderDescendentInfo();
            FillGridDependants(shlist);
            txtName2.Text = "";
            CmbGender.Text = "";
            CmbRelation2.Text = "";
            txtDependantNID.Text = "";
            dtpDpDOB.Value = DateTime.Now;
        }

        private void FillGridDependants(IList<ShareHolderDescendantsInfo> shlist)
        {
            dgSHDependants.SuspendLayout();
            dgSHDependants.Rows.Clear();
            
            foreach (ShareHolderDescendantsInfo sh in shlist)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = sh;
                row.CreateCells(dgSHDependants, sh.Name,sh.Relation,sh.Gender, sh.NID);
                dgSHDependants.Rows.Add(row);
                
            }
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Photo";
            imageColumn.HeaderText = "Photo";
            if(dgSHDependants.Columns.Contains("Photo") && dgSHDependants.Columns["Photo"].Visible)
            {

            }
            else
            {
                dgSHDependants.Columns.Insert(3,imageColumn);
            }
            //ImageList imgList;
            //Bitmap img = new Bitmap(this.imgList.Images[0]);

        }

        private byte[] GetImageByte()
        {
            Byte[] imgbyte = null;
            ImageConverter imgconverter = new ImageConverter();
            imgbyte = (System.Byte[])imgconverter.ConvertTo(PIC_PROFILE.Image, Type.GetType("System.Byte[]"));
            return imgbyte;
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            txtName2.Text = "";
            CmbRelation2.Text = "";
            CmbGender.Text = "";
            dtpDpDOB.Value = DateTime.Now;
            LoadDataDependants();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgShareHolderInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblSh1.Text = "";
            txtName2.Text = "";
            CmbRelation2.Text = "";
            CmbGender.Text = "";
            dtpDpDOB.Value = DateTime.Now;
            VMShareHolderInfo sg = dgShareHolderInfo.SelectedRows[0].Tag as VMShareHolderInfo;
            if (sg != null)
            {

                lblSh1.Text = sg.ShName;
                lblSh1.Tag = sg;
                IList<ShareHolderDescendantsInfo> sp = new ShareHolderService().DataViewSh(sg.ShId);
                FillGridDependants(sp);
                PIC_PROFILE.Image = null;
            }
        }

        private void dgSHDescendents_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShareHolderDescendantsInfo sg = dgSHDependants.SelectedRows[0].Tag as ShareHolderDescendantsInfo;
            
            if(sg!=null)
            {
                ShareHolderBasicData sh = new ShareHolderService().GetShareHolderId(sg.ShId);
                txtName2.Text = sg.Name;
                CmbGender.Text = sg.Gender;
                CmbRelation2.Text = sg.Relation;
                txtDependantNID.Text = sg.NID;
               
                dtpDpDOB.Value = sg.Dob;
               
                if (sg.Img != null)
                {
                    MemoryStream mem = new MemoryStream(sg.Img);
                    PIC_PROFILE.Image = System.Drawing.Image.FromStream(mem);
                }
                else
                {
                    PIC_PROFILE.Image = null;
                }

                txtName2.Tag = sg;
                
            }

        }

        private void txtName2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CmbGender.Focus();
            }
        }

        private void CmbRelation2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpDpDOB.Focus();
            }
        }

        private void CmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CmbRelation2.Focus();
            }
        }

        private void dtpDpDOB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               btnUpload.Focus();
            }
        }

        private void btnUpload_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave2.Focus();
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
            MiniMizeTheViewPanel();
        }

      

        private void txtShareNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTotalShare.Focus();
            }
        }

        private void txtTotalShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtFaceValue.Focus();
            }
        }

        private void txtFaceValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            long totalshare; double facevalue;

            Int64.TryParse(txtTotalShare.Text, out totalshare);
            double.TryParse(txtFaceValue.Text, out facevalue);
            if (e.KeyChar == (char)Keys.Enter)
            {
                lblAmount.Text = (facevalue * totalshare).ToString();
                btn_Save.Focus();
            }
        }

        private void btnShareHolderPicUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picshareholder.Image = new Bitmap(open.FileName);
            }
        }

        private void btnNomineePicUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picnominee.Image = new Bitmap(open.FileName);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            if(txtName.Text.ToLower().Equals("search by name"))
            {

            }
            else
            {
                FilterList(txtName.Text, "Name");
            }
        }

        private void FilterList(string filterStr, string prefix)
        {
            List<VMShareHolderInfo> shList = dgShareHolder.Tag as List<VMShareHolderInfo>;
            if (shList != null)
            {
                if (prefix.ToLower().Equals("name"))
                {
                    shList = shList.Where(x => x.ShName.ToLower().Contains(filterStr.ToLower().Trim())).ToList();

                }
                else if (prefix.ToLower().Equals("mobileno"))
                {
                    shList = shList.Where(x => x.ShMobile.Contains(filterStr.Trim())).ToList();
                }
                else if (prefix.ToLower().Equals("address"))
                {
                    shList = shList.Where(x => x.ShPresentAddress.Contains(filterStr.Trim())).ToList();
                }
                else if(prefix.Equals("ShareNo"))
                {
                    shList = shList.Where(x => x.ShareNo.ToString().Contains(filterStr.Trim())).ToList();
                }

                FillGrid(shList);
            }
        }

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByMobile.Text.ToLower().Equals("search by mobile no"))
            {

            }
            else
            {
                FilterList(txtSearchByMobile.Text, "MobileNo");
            }
        }

       

        private void txtSearchByAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByAddress.Text.ToLower().Equals("search by address"))
            {

            }
            else
            {
                FilterList(txtSearchByAddress.Text, "Address");
            }
            
        }

        private void txtSearchByShareNo_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.ToLower().Equals("search by share no."))
            {

            }
            else
            {
                FilterList(txtSearchByShareNo.Text, "ShareNo");
            }
        }

        private void txtSearchByShareNoInDependants_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchByShareNoInDependants.Text.Equals("Search by Share No."))
            {

            }
            else
            {
                FilterListInDependants(txtSearchByShareNoInDependants.Text, "ShareNo");
            }
        }

        private void FilterListInDependants(string searchString, string searchBy)
        {
            List<VMShareHolderInfo> shList = dgShareHolderInfo.Tag as List<VMShareHolderInfo>;

            if(shList != null)
            {
                if(searchBy.Equals("ShareNo"))
                {
                    shList = shList.Where(x => x.ShareNo.ToString().Contains(searchString.Trim())).ToList();
                }
                else if(searchBy.Equals("Name"))
                {
                    shList = shList.Where(x => x.ShName.ToLower().Contains(searchString.ToLower().Trim())).ToList();
                }
                FillGridShInDescendant(shList);
            }
        }

        private void txtSearchByShareHolderNameInDependants_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByShareHolderNameInDependants.Text.Equals("Search by Name"))
            {

            }
            else
            {
                FilterListInDependants(txtSearchByShareHolderNameInDependants.Text, "Name");
            }
        }
    }
}
