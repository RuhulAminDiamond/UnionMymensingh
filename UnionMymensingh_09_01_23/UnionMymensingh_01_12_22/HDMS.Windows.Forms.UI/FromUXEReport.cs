using HDMS.Model;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Novacode;
using OpenXmlPowerTools;
using HDMS.Common.Utils;
using System.Threading;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Globalization;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.Token;
using CrystalDecisions.Windows.Forms;
using HDMS.Repository.ServiceObjects;
using HDMS.Windows.Forms.UI.Diagonstics;
using HDMS.Model.Diagnostic.VM;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Model.Enums;

namespace HDMS.Windows.Forms.UI
{
    public partial class FromUXEReport : Form
    {
        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;
        ReportConsultant _doctor = new ReportConsultant();
        public delegate void _UpdateRepotListOnWordFileClose(long regNo, DateTime _date);
       
        private IList<Template> _SelectedTemplates;
        static DocX g_document;
        bool unlocked = true;

        public static LoginUser LoggedinUser { get; set; }
        public string CalledFrom = string.Empty;

       
        //public FromUXEReport()
        //{
        //    InitializeComponent();
            
          
        //}

        public FromUXEReport(ReportConsultant reportConsultant)
        {
            InitializeComponent();
            _doctor = reportConsultant;
            LoggedinUser = MainForm.LoggedinUser;

        }


        private void txtTemplate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ReportConsultant _doc = (ReportConsultant)cmbConsultant.SelectedItem;
                HideAllDefaultHidden();
                ctrlTemplateSearch.Visible = true;
                ctrlTemplateSearch.LoadDataByType(_doc.RCId.ToString());
               

               
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                

                ctrlTemplateSearch.Visible = false;
                int id;

                if (txtCurrentTestName.Tag == null)
                {
                    MessageBox.Show("No test selected for report.","HERP");
                    return;
                }

                this.KillRunningProcess();
              
                if (int.TryParse(txtTemplate.Tag.ToString(), out id))
                {

                     _doctor = (ReportConsultant)cmbConsultant.SelectedItem;
                    if (_doctor.RCId != 0)
                    {
                        this.ShowTemplate(id);
                    }
                    else
                    {
                        MessageBox.Show("Please select consultant.");
                    }
                }
            }
        }

        private void KillRunningProcess()
        {
            Process[] procs = Process.GetProcessesByName("winword");

            foreach (Process proc in procs)
                proc.Kill();
        }


        private void ShowTemplate(int templateId)
        {

          
            ReportFilePath = new TemplateService().GetNewReportFilePath(); 
            ReportFileNameWithPath = ReportFilePath +@"\"+txtBillNo.Text + "-" + ((ViewModelReportTests)txtCurrentTestName.Tag).Id.ToString() + ".docx";

            TempMasterReoprtNameWithPath = ReportFilePath + @"\" + txtBillNo.Text + "-" + ((ViewModelReportTests)txtCurrentTestName.Tag).Id.ToString() + ".docx";
            TempChildReoprtNameWithPath = ReportFilePath + @"\" + txtBillNo.Text + "-" + ((ViewModelReportTests)txtCurrentTestName.Tag).Id.ToString() + ".docx";

            byte[] _masteremplatecontent = new TemplateService().GetWordMasterTemplateContent(2);
            byte[] _childtemplatecontent = new TemplateService().GetWordTemplateContent(templateId);
            

            if (!Directory.Exists(ReportFilePath))
            {
                Directory.CreateDirectory(@ReportFilePath);
            }

            if (File.Exists(ReportFileNameWithPath))
            {
                File.Delete(ReportFileNameWithPath);
            }

           

            List<Source> documentBuilderSources = new List<Source>();
            List<byte[]> docs = new List<byte[]>();
            docs.Add(_masteremplatecontent);
            docs.Add(_childtemplatecontent);
            byte[] reportcontent = this.OpenAndCombine(docs);

            FileStream fsmaster = new FileStream(ReportFileNameWithPath, FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fsmaster);
            br.Write(reportcontent);
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

        private byte[] OpenAndCombine(IList<byte[]> documents)
        {
            MemoryStream mainStream = new MemoryStream();

            mainStream.Write(documents[0], 0, documents[0].Length);
            mainStream.Position = 0;

            int pointer = 1;
            byte[] ret;
            try
            {
                using (WordprocessingDocument mainDocument = WordprocessingDocument.Open(mainStream, true))
                {

                    XElement newBody = XElement.Parse(mainDocument.MainDocumentPart.Document.Body.OuterXml);

                    for (pointer = 1; pointer < documents.Count; pointer++)
                    {
                        WordprocessingDocument tempDocument = WordprocessingDocument.Open(new MemoryStream(documents[pointer]), true);
                        XElement tempBody = XElement.Parse(tempDocument.MainDocumentPart.Document.Body.OuterXml);

                        newBody.Add(tempBody);
                        mainDocument.MainDocumentPart.Document.Body = new Body(newBody.ToString());
                        mainDocument.MainDocumentPart.Document.Save();
                        mainDocument.Package.Flush();
                    }
                }
            }
            catch (OpenXmlPackageException oxmle)
            {
                throw new Exception(string.Format(CultureInfo.CurrentCulture, "Error while merging files. Document index {0}", pointer), oxmle);

            }
            catch (Exception e)
            {
                throw new Exception(string.Format(CultureInfo.CurrentCulture, "Error while merging files. Document index {0}", pointer), e);
            }
            finally
            {
                ret = mainStream.ToArray();
                mainStream.Close();
                mainStream.Dispose();
            }
            return (ret);
        }

        private DocX CreateReportFromTemplate(DocX template)
        {

            if (txtCurrentTestName.Tag != null)
            {
                ViewModelReportTests reportTest = (ViewModelReportTests)txtCurrentTestName.Tag;
                string reportGroupName = Utility.GetReportGroupName(reportTest.GroupId);
                template.ReplaceText("Report_Type", reportGroupName);
            }


            template.ReplaceText("bill_no", GetPrefixedIdString(txtBillNo.Text));
            template.ReplaceText("member_regno", txtMemberRegNo.Text);
            template.ReplaceText("Reg_No", txtBillNo.Text);
            template.ReplaceText("Admission_No", "");
            template.ReplaceText("Received_date", txtDate.Text);
            template.ReplaceText("Report_Date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
            //template.ReplaceText("daily_id", txtDID.Text);
            template.ReplaceText("Report_Date", DateTime.Now.ToString("dd/MM/yyyy"));
            template.ReplaceText("Patient_Name", txtPatientName.Text);
            template.ReplaceText("Patient_Age", txtAge.Text.Replace(" ",""));
            template.ReplaceText("Patient_Sex", txtSex.Text);
            template.ReplaceText("Refd_By", txtRefBy.Text);
            template.ReplaceText("Printed_By", lblPreparedBy.Text);
            if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            {
                template.ReplaceText("Cabin_No", "Cabin :" + txtCabin.Text);
            }
            else
            {
                template.ReplaceText("Cabin_No", "");
            }
            template.ReplaceText("Test_Name", txtCurrentTestName.Text);

            if (txtDID.Tag != null)
            {
                template.ReplaceText("Report_No", txtDID.Tag.ToString());

            }
            else
            {
                template.ReplaceText("Report_No", "");
            }

            ReportConsultant _doctor = (ReportConsultant)cmbConsultant.SelectedItem;

            template.ReplaceText("Doctor_Name", _doctor.Name);
            template.ReplaceText("Identity_Line1", _doctor.DIdentityLine1);
            template.ReplaceText("Identity_Line2", _doctor.DIdentityLine2);
            template.ReplaceText("Identity_Line3", _doctor.DIdentityLine3);
            template.ReplaceText("Identity_Line4", _doctor.DIdentityLine4);
            template.ReplaceText("Identity_Line5", " ");

            return template;
        }

        private string GetPrefixedIdString(string _originalId)
        {
            string _appendZero = string.Empty;
            if (_originalId.Length == 1) _appendZero = "00000";
            if (_originalId.Length == 2) _appendZero = "0000";
            if (_originalId.Length == 3) _appendZero = "000";
            if (_originalId.Length == 4) _appendZero = "00";
            if (_originalId.Length == 5) _appendZero = "0";


            return _appendZero + _originalId;
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
                        ViewModelReportTests _vmRT=(ViewModelReportTests)txtCurrentTestName.Tag;
                        
                        int length = (int)b.BaseStream.Length;
                        byte[] ReportContent = new byte[length];
                        b.Read(ReportContent, 0, length);

                        bool isReportExists = new TemplateService().IsReportExists(txtBillNo.Text, (ViewModelReportTests)txtCurrentTestName.Tag);
                        
                        MsWordReport newReport = new MsWordReport();
                        newReport.RegNo = txtBillNo.Text;
                        newReport.TestInfo = _vmRT;
                        newReport.ReportContent = ReportContent;
                        newReport._ReportDoctor = _doctor;
                        newReport.PreparedBy = lblPreparedBy.Text;
                        newReport.PreparedDate = DateTime.Now;
                        newReport.Preparedtime = DateTime.Now.ToString("hh:mm:ss");
                        newReport.ReportType = _vmRT.GroupName;
                        newReport.Printed_By = lblPreparedBy.Text;
                        string msg=string.Empty;

                        if (isReportExists)
                        {
                            msg = new TemplateService().UpdateReport(newReport);
                        }
                        else
                        {
                            msg = new TemplateService().SaveReport(newReport);
                        }

                        if (_vmRT.GroupId == 18)
                        {
                           // new PatientService().SetUSGDoctorOnDailyStatement(txtRegNo.Text, _doctor);
                        }

                        if (txtBillNo.Tag != null)
                        {
                            Patient _Patient = (Patient)txtBillNo.Tag;
                            TestsCost _tc = new TestsCostService().GetTestCostByPatientAndTestId(_Patient.PatientId, _vmRT.Id);
                            _tc.ReportStatus = ReportStatusEnum.RP.ToString();
                            new TestsCostService().UpdateReportStatusByTest(_tc);
                        }

                        unlocked = false;
                        txtTemplate.Text = "";
                        unlocked = true;


                        if (String.Compare(msg, "Success") == 0)
                        {
                           // MessageBox.Show("File Saved");
                        }
                        else
                        {
                            MessageBox.Show("Save to DB Fail.");
                        }

                        txtBillNo.Focus();

                        Thread t = new Thread(new ThreadStart(this.UpdateReportList));
                        t.IsBackground = true;
                        t.Start();

                        //this.Invoke(new MethodInvoker(this.ShowReportsOnListView("", DateTimePicker.Value))); 


                    }

                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "HERP");
            }
                
        }

        private void UpdateReportList()
        {
            Invoke(new _UpdateRepotListOnWordFileClose(ShowReportsOnListView), new object[] { 0, Convert.ToDateTime(DateTimePicker.Value) });
        }


        private void ShowReportsOnListView(long RegNo, DateTime _datetime)
        {

           

            DataTable dt = new TemplateService().GetReports((ReportConsultant)cmbConsultant.SelectedItem, RegNo, _datetime, "NonPath");
            
            lvReports.Items.Clear();
            lvReports.SmallImageList = imgListLarge;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string displayText = dr[1].ToString() + "-" + dr[2].ToString();
                ListViewItem listitem = new ListViewItem(displayText);
                listitem.ToolTipText = dr[3].ToString();
                listitem.ImageIndex = 1;
                lvReports.Items.Add(listitem);


            }

         

           // lvReports.LargeImageList = imgListLarge;
            
        }

        private void HideAllDefaultHidden()
        {
            ctrlTemplateSearch.Visible = false;
        }

        private void FromUXEReport_Load(object sender, EventArgs e)
        {
            _SelectedTemplates = new List<Template>();

            ctrlTemplateSearch.Location = new Point(txtTemplate.Location.X, txtTemplate.Location.Y);
            ctrlTemplateSearch.ItemSelected += ctrlTemplateSearch_ItemSelected;
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            lblPreparedBy.Text = LoggedinUser.Name;


            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            List<ReportConsultant> ReportDoctors = new DoctorService().GetAllConsultants().ToList(); //new DoctorService().GetlAlReportDoctorOtherThanPathologyLegay().ToList();
            if (ReportDoctors != null)
            {
                ReportDoctors.Insert(0, new ReportConsultant()
                {
                    RCId = 0,
                    Name = "Select Consulatnt"
                });
            }

            cmbConsultant.DataSource = ReportDoctors;
            cmbConsultant.DisplayMember = "Name";
            cmbConsultant.ValueMember = "RCId";

           // ReportConsultant _consultant = new DoctorService().GetConsultantByUserId(LoggedinUser.UserId);
            if (_doctor != null && ReportDoctors!=null)
            {
                cmbConsultant.SelectedItem = ReportDoctors.Find(q => q.RCId == _doctor.RCId);
                cmbConsultant.Enabled = false;
            }
            else
            {
                cmbConsultant.Enabled = true;
            }


           

            this.ShowReportsOnListView(0,DateTimePicker.Value);



            txtBillNo.Focus();

           

        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as System.Windows.Forms.Control; ;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = System.Drawing.Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as System.Windows.Forms.Control;
            //ctrl.Tag = ctrl.BackColor;
            if ((ctrl is TextBox) && ((TextBox)ctrl).Equals(txtTemplate))
            {
                HideAllDefaultHidden();
                ctrlTemplateSearch.Visible = true;
                ctrlTemplateSearch.LoadData();
            }
            ctrl.BackColor = System.Drawing.Color.NavajoWhite;
        }

        private void ctrlTemplateSearch_ItemSelected(UI.Controls.SearchResultListControl<Template> sender, Template item)
        {
            unlocked = false;

      
           
                txtTemplate.Text = item.TemplateName;

                txtTemplate.Tag = item.Id;
          
           
            txtTemplate.Focus();
            unlocked = true;
            sender.Visible = false;
        }

        private void txtRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _billNo = 0;
                long.TryParse(txtBillNo.Text, out _billNo);
                Patient _patient = new PatientService().GetPatientByIdNo(_billNo);
                if (_patient != null)
                {

                    txtBillNo.Tag = _patient;

                    txtDID.Text = _patient.DailyId.ToString();
                    txtDID.Tag = _patient.ReportIdPrefix + _patient.ReportId.ToString();
                    txtRefBy.Text = new DoctorService().GetDoctorByIdFromLegacy(_patient.DoctorId).Name;
                    txtCabin.Text = _patient.Cabin;
                    txtDate.Text = _patient.EntryDate.ToString("dd/MM/yyyy")+" "+ _patient.EntryTime;

                    RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_patient.RegNo);
                    if (_record != null)
                    {
                        txtMemberRegNo.Text = _record.RegNo.ToString();
                        txtPatientName.Text = _record.FullName;
                      
                        txtSex.Text = _record.Sex;
                    }

                    txtAge.Text = Utility.GetConcatenatedAge(_patient.AgeYear, _patient.AgeMonth, _patient.AgeDay);

                    ReportConsultant _consultant = (ReportConsultant)cmbConsultant.SelectedItem;
                    List<ViewModelReportTests> reportTests = new TestService().GetAllTestByRegNoLegacy(_patient.PatientId, _consultant.RCId).ToList();


                    Tv.Nodes.Clear();

                    TreeNode MainNode = new TreeNode();
                    MainNode.Text = "Select Test";
                    Tv.Nodes.Add(MainNode);

                    foreach (var item in reportTests)
                    {
                        TreeNode child = new TreeNode();
                        child.Text = item.Name;
                        child.Tag = item;
                        MainNode.Nodes.Add(child);
                    }

                    Tv.ExpandAll();

                    Tv.Focus();
                   
                    this.ShowReportsOnListView(Convert.ToInt64(txtBillNo.Text), DateTimePicker.Value);
                }
                else
                {
                    MessageBox.Show("Patient not found.","HERP");
                }
            }
        }

        private void Tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
          
            txtCurrentTestName.Tag = string.Empty;
            txtCurrentTestName.Text = string.Empty;
             ReportConsultant _consultant =   (ReportConsultant)cmbConsultant.SelectedItem;

            if (Tv.SelectedNode.Tag == null) return;

             if (_consultant != null && !new ReportService().IsReportDoneByOtherConsultant((ViewModelReportTests)Tv.SelectedNode.Tag, txtBillNo.Text, _consultant.RCId))
             {
                txtCurrentTestName.Text = Tv.SelectedNode.Text;
                txtCurrentTestName.Tag = Tv.SelectedNode.Tag;
            }
            else
            {
                MessageBox.Show("Report already done by other consultant Or You are not allowed for this kind of reporting.");
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

            txtAge.Tag = fileName;          // For later use during update database
            string[] Ids = fileName.Split('-');

            string _reportType = new ReportService().GetReportType(Ids);
            

            byte[] reportcontent = new TemplateService().GetPreviousReport(Ids);

            ReportFilePath = new TemplateService().GetOldReportFilePath();
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
            br.Write(reportcontent);
            fs.Dispose();
            br.Dispose();

            ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
            Process process = Process.Start(psi);
            process.EnableRaisingEvents = true;
            process.Exited += process_Exited_oldreport;

            process.WaitForExit();    
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


                        string[] Ids = txtAge.Tag.ToString().Split('-');

                        Patient _p = new PatientService().GetPatientByBillNo(Convert.ToInt64(Ids[0]));
                        ViewModelReportTests reportTest = new TestService().GetSelectedTestByRegNoLegacy(_p.PatientId, Ids[1]);

                        MsWordReport newReport = new MsWordReport();
                        newReport.PatientId = Convert.ToInt64(Ids[0]);
                        newReport.RegNo =_p.RegNo.ToString();
                        newReport.TestInfo = reportTest;
                        newReport.ReportContent = ReportContent;
                        newReport.PreparedBy = lblPreparedBy.Text;
                        newReport._ReportDoctor = (ReportConsultant)cmbConsultant.SelectedItem; 
                        newReport.ReportType = reportTest.GroupName;
                        newReport.PreparedDate = DateTime.Now;
                        newReport.Preparedtime = DateTime.Now.ToString("hh:mm:ss");

                        string msg = string.Empty;
                        msg = new TemplateService().UpdateReport(newReport);


                        if (String.Compare(msg, "Success") == 0)
                        {
                            //MessageBox.Show("File Updated");
                        }
                        else
                        {
                            MessageBox.Show("DB. Update Fail.");
                        }

                        txtBillNo.Focus();

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

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.ShowReportsOnListView(0, DateTimePicker.Value);
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblRefBy_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DateTime _dt = Utils.GetServerDateAndTime();
            List<UXEntryList> _uxEntryList = new TestService().GetUXEntryListByDate(_dt).ToList();
            dgvUxList.AutoGenerateColumns = false;
            dgvUxList.DataSource = _uxEntryList;

        }

        private void btnPrintToken_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            long.TryParse(txtSelectedPatientId.Text, out _billNo);
            Patient _patient = new PatientService().GetPatientByBillNo(_billNo);

            
            DataSet ds = new ReportService().GetTokenData(_patient.PatientId);

            rptToken rptTokenList = new rptToken();

            rptTokenList.SetDataSource(ds.Tables[0]);

            rptTokenList.SetParameterValue("BillNo", txtSelectedPatientId.Text);

            ReportViewer rv = new ReportViewer();
           // string customFmts = "dd/MM/yyyy";
           
            rv.crviewer.ReportSource = rptTokenList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();


        }

        private void dgvUxList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSelectedPatientId.Text = dgvUxList.Rows[e.RowIndex].Cells["BillNo"].Value.ToString();
        }

        private void Tv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTemplate.Focus();
            }
        }

        private void txtTemplate_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtTemplate.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtTemplate.Text;
                    HideAllDefaultHidden();
                    ctrlTemplateSearch.Visible = true;
                    ctrlTemplateSearch.txtSearch.Text = _txt;
                    ctrlTemplateSearch.txtSearch.SelectionStart = ctrlTemplateSearch.txtSearch.Text.Length;

                   // ctrlTemplateSearch.LoadData(); 
                    
                   ReportConsultant _doc = (ReportConsultant)cmbConsultant.SelectedItem;
                    ctrlTemplateSearch.LoadDataByType(_doc.RCId.ToString());
                }
            }
        }

        private void btnPrintLabel(object sender, EventArgs e)
        {
            long _pId = 0;
            long.TryParse(txtSelectedPatientId.Text, out _pId);

            Patient _Patient = new PatientService().GetPatientByBillNo(_pId);

            RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_Patient.RegNo);

            VMFolderLabelParameter _lblParam = new VMFolderLabelParameter();
            _lblParam.IdNo = txtSelectedPatientId.Text;
            _lblParam.Name = _record.FullName;
            _lblParam.Age = Utility.GetConcatenatedAge(_record.AgeYear, _record.AgeMonth, _record.AgeDay);
            _lblParam.Sex = _record.Sex;
            _lblParam.MobileNo = _record.MobileNo;
            _lblParam.RefdBy = new DoctorService().GetDoctorById(_Patient.DoctorId).Name;
            _lblParam.EntryDate = _Patient.EntryDate.ToString("dd/MM/yyyy");
            _lblParam.EntryTime = _Patient.EntryTime;
            List<ViewModelReportTests> reportTests = new TestService().GetAllTestByRegNoLegacy(_Patient.PatientId,((ReportConsultant)cmbConsultant.SelectedItem).RCId).ToList();

            _lblParam.Tests = GetTestsName(reportTests);

            BarCodePrintHelper _bPrintHelper = new BarCodePrintHelper(_lblParam);
            _bPrintHelper.print("Brother QL-800");
        }

        private string GetTestsName(List<ViewModelReportTests> reportTests)
        {
            string _Tests = string.Empty;
            foreach (ViewModelReportTests item in reportTests)
            {
                if (String.IsNullOrEmpty(_Tests))
                {
                    _Tests = item.Name;
                }
                else
                {
                    _Tests = _Tests + "," + item.Name;
                }
            }

            return _Tests;
        }

        private void ctrlTemplateSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTemplate.Focus();
            }
        }
    }
}
