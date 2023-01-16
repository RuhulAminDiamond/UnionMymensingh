using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model;
using HDMS.Model.Hospital;
using Novacode;
using HDMS.Service.Diagonstics;
using System.IO;
using System.Diagnostics;
using System.Threading;
using HDMS.Service.Rx;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Model.Diagnostic.VM;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlTemplateDischargePart2 : UserControl
    {
        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;

        public delegate void _UpdateRepotListOnWordFileClose(DateTime _date);

        static DocX g_document;
        bool isInMaxView = true;

        public ctrlTemplateDischargePart2()
        {
            InitializeComponent();
        }

        private async void ctrlTemplateBasedDischargeMainWindow_Load(object sender, EventArgs e)
        {

            HideDeafaultHidden();

            ctrlDischareTemplateSearchControl.Location = new Point(txtTemplate.Location.X, txtTemplate.Location.Y + txtTemplate.Height);
            ctrlDischareTemplateSearchControl.ItemSelected += ctrlDischareTemplateSearchControl_ItemSelected;

            ctrlMedicalOfficerSearchControl.Location = new Point(txtMedicalOfficer.Location.X, txtMedicalOfficer.Location.Y + txtMedicalOfficer.Height);
            ctrlMedicalOfficerSearchControl.ItemSelected += ctrlMedicalOfficerSearchControl_ItemSelected;

            dtpDischarge.Value = Utils.GetServerDateAndTime();

            List<VMIPDInfo> _Plist = await LoadPatients();

            LoadDischargedPatient(dtpStart.Value, dtpEnd.Value);
            
            FillListGrid(_Plist);

            txtSearchByCabin.Tag = _Plist;



        }

        private void LoadDischargedPatient(DateTime dtpfrm, DateTime dtpto)
        {
            List<VMDischargedCertifiedPatientList> _dischargedPList = new HospitalService().GetDischargeCertificateList(dtpStart.Value, dtpEnd.Value).ToList();

            FillDischargeCertificateListGrid(_dischargedPList);

            dgDischargePatientList.Tag = _dischargedPList;
        }

        private void FillDischargeCertificateListGrid(List<VMDischargedCertifiedPatientList> dischargedPList)
        {
            dgDischargePatientList.SuspendLayout();
            dgDischargePatientList.Rows.Clear();
            foreach(var item in dischargedPList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 60;
                row.Tag = item;
                row.CreateCells(dgDischargePatientList, item.BillNo, item.FullName, item.CPMobile, item.CPAddress, item.AddmissionDate.ToString("dd/MM/yyyy"), item.DischargeDate.ToString("dd/MM/yyyy"));

                dgDischargePatientList.Rows.Add(row);
            }

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Name = "img";
            iconColumn.HeaderText = "File";
            if (dgDischargePatientList.Columns.Contains("img") && dgDischargePatientList.Columns["img"].Visible)
            {

            }
            else
            {
                dgDischargePatientList.Columns.Insert(6, iconColumn);
            }


            SetCVIcons();

        }

        private void SetCVIcons()
        {
            
            Bitmap wordImage = new Bitmap(this.imgListLarge.Images[1]);
            
            foreach (DataGridViewRow row in dgDischargePatientList.Rows)
            {
               row.Cells["img"].Value = wordImage;
            }
        }

        private async Task<List<VMIPDInfo>> LoadPatients()
        {

            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfoForDischarge();

            return _lisPatientInfo;
        }

       

        private void ctrlMedicalOfficerSearchControl_ItemSelected(SearchResultListControl<ReportConsultant> sender, ReportConsultant item)
        {
            txtMedicalOfficer.Text = item.Name;
            txtMedicalOfficer.Tag = item;
            txtMedicalOfficer.Focus();
            sender.Visible = false;
        }

        private void ctrlDischareTemplateSearchControl_ItemSelected(SearchResultListControl<DischargeTemplate> sender, DischargeTemplate item)
        {
            txtTemplate.Text = item.TemplateName;
            txtTemplate.Tag = item;
            txtTemplate.Focus();
            sender.Visible = false;
        }

        

        private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMIPDInfo item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.BedCabinNo, item.Name, item.AddmissionDate.ToString("dd/MM/yyyy"));
                dgPatient.Rows.Add(row);
            }

        }

        private void HideDeafaultHidden()
        {
            ctrlDischareTemplateSearchControl.Visible = false;
            ctrlMedicalOfficerSearchControl.Visible = false;
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByCabin.Text, "cabin");
            }
        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = (List<VMIPDInfo>)txtSearchByCabin.Tag;


            if (_lisPatientInfo != null)
            {
                _lisPatientInfo = _lisPatientInfo.Where(x => x.BedCabinNo.Contains(_prefix)).ToList();

                FillListGrid(_lisPatientInfo);
            }
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {

                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);


                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;

                lblCabin.Tag = _pInfo;


                List<VMRequestOnDischargedResult> _InvestigationListOnDischarge = new PatientService().GetInvestigationsOnDischarge(_pInfo.BillNo);

                lblName.Tag = _InvestigationListOnDischarge;

            }
        }

        private void txtTemplate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideDeafaultHidden();
                ctrlDischareTemplateSearchControl.Visible = true;
                ctrlDischareTemplateSearchControl.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                ReportConsultant _mo = (ReportConsultant)txtMedicalOfficer.Tag;
                DischargeTemplate _dt = (DischargeTemplate)txtTemplate.Tag;

             

                if (_mo != null && _dt != null && lblCabin.Tag!=null)
                {
                    ShowTemplate(_dt.TId);

                }
                else
                {
                    MessageBox.Show("Medical Officer Or Template Or Patient not selected. Plz. Check it and try again "); return;
                }

            }
        }

        private void ShowTemplate(int _Id)
        {
            ReportFilePath = "C:\\Discharge";
            ReportFileNameWithPath = ReportFilePath + @"\" + _Id.ToString() + ".docx";

            TempMasterReoprtNameWithPath = ReportFilePath + @"\" + _Id.ToString() + "-" + ".docx";


            byte[] _masteremplatecontent = new TemplateService().GetDischargeMasterTemplateContent(_Id);

            if (!Directory.Exists(ReportFilePath))
            {
                Directory.CreateDirectory(@ReportFilePath);
            }

            if (File.Exists(ReportFileNameWithPath))
            {
                File.Delete(ReportFileNameWithPath);
            }




            FileStream fsmaster = new FileStream(ReportFileNameWithPath, FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fsmaster);
            br.Write(_masteremplatecontent);
            fsmaster.Dispose();
            br.Dispose();


            g_document = CreateReportFromTemplate(DocX.Load(@ReportFileNameWithPath));
            g_document.SaveAs(ReportFileNameWithPath);

            ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
            Process process = Process.Start(psi);
            process.EnableRaisingEvents = true;
            process.Exited += process_Exited;

            process.WaitForExit();
        }

        private void process_Exited(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(ReportFileNameWithPath);
                if (fileInfo.CreationTime.CompareTo(fileInfo.LastWriteTime) < 0)
                {
                    using (BinaryReader b = new BinaryReader(File.Open(ReportFileNameWithPath, FileMode.Open)))
                    {
                        int length = (int)b.BaseStream.Length;
                        byte[] ReportContent = new byte[length];
                        b.Read(ReportContent, 0, length);

                        VMIPDInfo _pInfo = (VMIPDInfo)lblCabin.Tag;

                        ReportConsultant _consultant = (ReportConsultant)txtMedicalOfficer.Tag;

                        DischargeCertificateTemplateBased _dc = new DischargeCertificateTemplateBased();
                        _dc.BillNo = _pInfo.BillNo;
                        _dc.RCId = _consultant.RCId;
                        _dc.DCPrintDate = Utils.GetServerDateAndTime();
                        _dc.DCPrintTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        _dc.DCContent = ReportContent;

                        if (new TemplateService().DeleteExistingDischargeCertificate(_pInfo))
                        {
                            string msg = string.Empty;
                            msg = new TemplateService().SaveDischargeReport(_dc);


                            if (String.Compare(msg, "Success") == 0)
                            {
                                MessageBox.Show("File Saved");
                            }
                            else
                            {
                                MessageBox.Show("DB. Update Fail.");
                            }

                            txtTemplate.Focus();

                            //Thread t = new Thread(new ThreadStart(this.UpdateReportList));
                            //t.IsBackground = true;
                            //t.Start();


                            this.ShowReportsOnListView(dtp.Value);
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HERP");
            }

        }


        private void ShowReportsOnListView(DateTime _datetime)
        {

            List<DischargeCertificateTemplateBased> dList = new HospitalService().GetDischargeCertificates(_datetime);

            lvReports.Items.Clear();
            lvReports.SmallImageList = imgListLarge;
            foreach (var item in dList)
            {
                HospitalPatientInfo _p = new HospitalService().GetHospitalPatientByBillNoAny(item.BillNo);
                if (_p != null)
                {
                    RegRecord rr = new RegRecordService().GetRegRecordByRegNo(_p.RegNo);
                    string displayText = item.BillNo.ToString();
                    ListViewItem listitem = new ListViewItem(displayText);
                    listitem.ToolTipText = rr.FullName.ToString();
                    listitem.ImageIndex = 1;
                    lvReports.Items.Add(listitem);

                }
            }


        }

        private DocX CreateReportFromTemplate(DocX template)
        {

            VMIPDInfo _pInfo = ((VMIPDInfo)lblCabin.Tag);

            template.ReplaceText("Bill_No", _pInfo.BillNo.ToString());
            template.ReplaceText("Reg_No", _pInfo.RegNo.ToString());
            template.ReplaceText("Admission_No", _pInfo.BillNo.ToString());
            template.ReplaceText("Patient_Name", _pInfo.Name);
            template.ReplaceText("P_Gender", _pInfo.Gender);
            template.ReplaceText("P_Age", _pInfo.Age);
            template.ReplaceText("P_Address", _pInfo.CPAddress);
            template.ReplaceText("P_Diagnosis", "");
            template.ReplaceText("D_Date", Utils.GetServerDateAndTime().ToString("dd/MM/yyyy"));
            //template.ReplaceText("daily_id", txtDID.Text);
            template.ReplaceText("D_Time", Utils.GetServerDateAndTime().ToString("hh:mm tt"));
            template.ReplaceText("A_Date", _pInfo.AddmissionDate.ToString("dd/MM/yyyy"));
            template.ReplaceText("A_Time", Convert.ToDateTime(_pInfo.AdmTime).ToString("hh:mm tt"));
            template.ReplaceText("P_Bed", lblCabin.Text);
            template.ReplaceText("P_Mobile", _pInfo.MobileNo);
            template.ReplaceText("Assign_Doctor", _pInfo.AssignedDoctor);



          List<VMRequestOnDischargedResult> _investigationList = (List<VMRequestOnDischargedResult>)lblName.Tag;

            string[] rrList = new string[4];
            rrList[0] = "Srl No";
            rrList[1] = "12345";
            rrList[2] = "12345";
            rrList[3] = "12345";

            Table placeholderTable1 = template.Tables[1];
            Table t1 = placeholderTable1.InsertTableAfterSelf(_investigationList.Count, 4);

            template.AddTable(rrList.Length, 3);

            int _row = 0;

            foreach (var testItem in _investigationList)
            {
                t1.Rows[_row].Cells[0].Paragraphs.First().Append((_row + 1).ToString());
                t1.Rows[_row].Cells[1].Paragraphs.First().Append(testItem.EntryDate.ToString("dd/MM/yyyy"));
                t1.Rows[_row].Cells[2].Paragraphs.First().Append(testItem.TestName);
                t1.Rows[_row].Cells[3].Paragraphs.First().Append(testItem.TestResult);
                _row++;
            }


            placeholderTable1.Remove();


            List<TreatmentOnDischarge> _treatmentList = new RxService().GetTreatmentOnDischarge(_pInfo.AdmissionId);

           
                Table placeholderTable2 = template.Tables[2];

                // Table t = placeholderTable.InsertTableAfterSelf(4, 4);


                Table t2 = placeholderTable2.InsertTableAfterSelf(_treatmentList.Count, 6);

              if (_treatmentList.Count > 0)
              {

                template.AddTable(_treatmentList.Count, 2);
                //for (int i = 0; i <= rrList.Length - 1; i++)
                //{
                //    t.Rows[i].Cells[0].Paragraphs.First().Append(rrList[i]);
                //    t.Rows[i].Cells[1].Paragraphs.First().Append(rrList[i]);
                //}

                int _startRow = 0;



                foreach (var item in _treatmentList)
                {

                    t2.Rows[_startRow].Cells[0].Paragraphs.First().Append((_startRow + 1).ToString());
                    t2.Rows[_startRow].Cells[1].Paragraphs.First().Append(item.MedicineName);
                    t2.Rows[_startRow].Cells[2].Paragraphs.First().Append(item.Dosage);
                    if (item.IsBeforAfterMealBanglaFont)
                    {
                        t2.Rows[_startRow].Cells[3].Paragraphs.First().Append(item.BeforAfterMeal).Font(new FontFamily("Nirmala UI"));
                    }
                    else
                    {
                        t2.Rows[_startRow].Cells[3].Paragraphs.First().Append(item.BeforAfterMeal);
                    }

                    t2.Rows[_startRow].Cells[4].Paragraphs.First().Append(item.Duration);

                    if (item.IsUnitBanglaFont)
                    {
                        t2.Rows[_startRow].Cells[5].Paragraphs.First().Append(item.Unit).Font(new FontFamily("Nirmala UI"));
                    }
                    else
                    {
                        t2.Rows[_startRow].Cells[5].Paragraphs.First().Append(item.Unit);
                    }

                    _startRow++;
                }

            }

            placeholderTable2.Remove();




            if (txtMedicalOfficer.Tag != null)
            {


                ReportConsultant _doctor = (ReportConsultant)txtMedicalOfficer.Tag;

                template.ReplaceText("Mo_Name", _doctor.Name);
                template.ReplaceText("Designation_Name", "Medical Officer");
               
            }

            template.ReplaceText("Print_date_time", Utils.GetServerDateAndTime().ToString("dd/MM/yyyy hh:mm tt"));

            return template;
        }

        private void txtMedicalOfficer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideDeafaultHidden();
                ctrlMedicalOfficerSearchControl.Visible = true;
                ctrlMedicalOfficerSearchControl.LoadData();
            }
        }

        private void ctrlDischareTemplateSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTemplate.Focus();
            }
        }

        private void ctrlMedicalOfficerSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtMedicalOfficer.Focus();
            }
        }

        private void lvReports_DoubleClick(object sender, EventArgs e)
        {
            if (lvReports.SelectedItems.Count == 1)
            {
                this.KillRunningProcess();

                ListView.SelectedListViewItemCollection items = lvReports.SelectedItems;

                ListViewItem lvItem = items[0];
                this.ViewPreviousReport(lvItem.Text);

            }
        }

        private void ViewPreviousReport(string fileName)
        {
            lblName.Tag = fileName;          // For later use during update database

            long _billNo=0;
            long.TryParse(fileName, out _billNo);
         
            DischargeCertificateTemplateBased dc = new HospitalService().GetDischargeCertificate(_billNo);

            if (dc != null)
            {

                ReportFilePath =  "C:\\DischargeOld"; ;
                ReportFileNameWithPath = ReportFilePath + @"\" + fileName + ".docx";

                if (!Directory.Exists(ReportFilePath))
                {
                    Directory.CreateDirectory(ReportFilePath);
                }

                if (File.Exists(ReportFileNameWithPath))
                {
                    File.Delete(ReportFileNameWithPath);
                }

                FileStream fs = new FileStream(ReportFileNameWithPath, FileMode.OpenOrCreate);
                BinaryWriter br = new BinaryWriter(fs);
                br.Write(dc.DCContent);
                fs.Dispose();
                br.Dispose();

                ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
                Process process = Process.Start(psi);
                process.EnableRaisingEvents = true;
                process.Exited += process_Exited_oldreport;

                process.WaitForExit();
            }
        }

        private void process_Exited_oldreport(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(ReportFileNameWithPath);
                if (fileInfo.CreationTime.CompareTo(fileInfo.LastWriteTime) < 0)
                {
                    using (BinaryReader b = new BinaryReader(File.Open(ReportFileNameWithPath, FileMode.Open)))
                    {
                        int length = (int)b.BaseStream.Length;
                        byte[] ReportContent = new byte[length];
                        b.Read(ReportContent, 0, length);


                        long _billNo;
                        long.TryParse(lblName.Tag.ToString(), out _billNo);

                  
                        DischargeCertificateTemplateBased reportTest = new HospitalService().GetDischargeCertificate(_billNo);

                        reportTest.DCContent = ReportContent;
                      
                        string msg = string.Empty;
                        msg = new HospitalService().UpdateDischargeCertificate(reportTest);


                        if (String.Compare(msg, "Success") == 0)
                        {
                            //MessageBox.Show("File Updated");
                        }
                        else
                        {
                            MessageBox.Show("DB. Update Fail.");
                        }

                     

                        Thread t = new Thread(new ThreadStart(this.UpdateReportList));
                        t.IsBackground = true;
                        t.Start();


                        //this.ShowReportsOnListView("", DateTimePicker.Value);


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HERP");
            }
        }

        private void UpdateReportList()
        {
            Invoke(new _UpdateRepotListOnWordFileClose(ShowReportsOnListView), new object[] { dtp.Value });
        }

        private void KillRunningProcess()
        {
            Process[] procs = Process.GetProcessesByName("winword");

            foreach (Process proc in procs)
                proc.Kill();
        }

        private void txtAdmId_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "By Adm. No")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                SearcgDischargeCertificate(txtAdmId.Text, "admid");
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                SearcgDischargeCertificate(txtName.Text, "PName");
            }
        }

        private void SearcgDischargeCertificate(string _prefix, string type)
        {
            List<VMDischargedCertifiedPatientList> _lisPatientInfo = dgDischargePatientList.Tag as List<VMDischargedCertifiedPatientList>;

            if (_lisPatientInfo.Count() == 0) return;

            if (type.Equals("PName"))
            {
                _lisPatientInfo = _lisPatientInfo.Where(x => x.FullName.ToLower().Contains(_prefix.ToLower())).ToList();
            }
            else if (type.Equals("admid"))
            {
                _lisPatientInfo = _lisPatientInfo.Where(x => x.BillNo.ToString().Contains(_prefix)).ToList();
            }
            else if (type.Equals("MobileNo"))
            {
                _lisPatientInfo = _lisPatientInfo.Where(x => x.CPMobile.Contains(_prefix)).ToList();
            }
            else if (type.Equals("Address"))
            {
                _lisPatientInfo = _lisPatientInfo.Where(x => x.CPAddress.ToLower().Contains(_prefix.ToLower())).ToList();
            }

            FillDischargeCertificateListGrid(_lisPatientInfo);
        }

       

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByMobile.Text.Trim() == "Search by Mobile No")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                SearcgDischargeCertificate(txtSearchByMobile.Text, "MobileNo");
            }
        }

        private void txtSearchByAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByAddress.Text.Trim() == "Search by Address")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                SearcgDischargeCertificate(txtSearchByAddress.Text, "Address");
            }
        }

        private void ctrlTemplateDischargePart2_Resize(object sender, EventArgs e)
        {
           // LoadPatients(dtpfrm.Value, dtpto.Value);

           // ShowReportsOnListView(dtp.Value);

        }

        private void btnMaxView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(18, 4);

            isInMaxView = true;

            btnMaxView.Visible = false;
        }

        private void btnMinView_Click(object sender, EventArgs e)
        {
            pnlPatient.Location = new Point(pnlPatient.Location.X + 1270, 4);

            isInMaxView = false;

            btnMaxView.Visible = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDischargedPatient(dtpStart.Value, dtpEnd.Value);
        }

        private void dgDischargePatientList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgDischargePatientList.CurrentRow;
            VMDischargedCertifiedPatientList _dc = row.Tag as VMDischargedCertifiedPatientList;

            if (_dc != null) 
            { 
                ViewPreviousDischareCertificate(_dc);
            }
        }

        private void ViewPreviousDischareCertificate(VMDischargedCertifiedPatientList dc)
        {
            DischargeCertificateTemplateBased prevdc = new HospitalService().GetDischargeCertificate(dc.BillNo);

            if (prevdc != null)
            {

                lblName.Tag = dc.BillNo;

                ReportFilePath = "C:\\DischargeOld"; ;
                ReportFileNameWithPath = ReportFilePath + @"\" + dc.BillNo.ToString() + ".docx";

                if (!Directory.Exists(ReportFilePath))
                {
                    Directory.CreateDirectory(ReportFilePath);
                }

                if (File.Exists(ReportFileNameWithPath))
                {
                    File.Delete(ReportFileNameWithPath);
                }

                FileStream fs = new FileStream(ReportFileNameWithPath, FileMode.OpenOrCreate);
                BinaryWriter br = new BinaryWriter(fs);
                br.Write(prevdc.DCContent);
                fs.Dispose();
                br.Dispose();

                ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
                Process process = Process.Start(psi);
                process.EnableRaisingEvents = true;
                process.Exited += process_Exited_oldreport;

                process.WaitForExit();
            }
        }
    }
}
