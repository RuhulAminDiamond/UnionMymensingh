using HDMS.Model.Hospital;
using HDMS.Service.Diagonstics;
using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmAddDischargeTemplate : Form
    {
        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;
      
        public delegate void _UpdateRepotListOnWordFileClose(string regNo, DateTime _date);

      
        static DocX g_document;
    
        public frmAddDischargeTemplate()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Docx Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Word Files|*.doc;*.docx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;

            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader b = new BinaryReader(File.Open(txtFileName.Text, FileMode.Open)))
                {

                    int templateId = 0;
                    int length = (int)b.BaseStream.Length;
                    byte[] File1Content = new byte[length];
                    b.Read(File1Content, 0, length);

                    string[] fileName = new string[2];
                    fileName = Path.GetFileName(txtFileName.Text).Split('.');



                    DischargeTemplate _template = new DischargeTemplate();

                    _template.TGroup = cmbType.Text;
                    _template.FileName = fileName[0];
                    _template.TemplateName = txtTemplateName.Text;
                    _template.TemplateContent = File1Content;

                    if ((txtTemplateName.Tag != null) && (Int32.TryParse(txtTemplateName.Tag.ToString(), out templateId)))
                    {
                        if (new TemplateService().UpdateDischareTemplate(_template, templateId))
                        {
                            MessageBox.Show("Template Updated.", "HERP");
                        }
                    }
                    else
                    {
                        if (new TemplateService().SaveDischargeTemplate(_template))
                        {
                            MessageBox.Show("Template Saved.", "HERP");
                        }
                    }


                    this.LoadTemplates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HERP");
            }

        }



        private void LoadTemplates()
        {
            List<DischargeTemplate> _dtList = new TemplateService().GetAllDischargeTemplates();
            lvTemplates.Items.Clear();

            foreach (DischargeTemplate _dt in _dtList)
            {
                
                ListViewItem listitem = new ListViewItem(_dt.TId.ToString());
                listitem.SubItems.Add(_dt.TGroup.PadLeft(3));
                listitem.SubItems.Add(_dt.TemplateName);
                listitem.SubItems.Add(_dt.FileName);
               
                lvTemplates.Items.Add(listitem);
            }
        }

        private void frmAddDischargeTemplate_Load(object sender, EventArgs e)
        {
            LoadTemplates();
        }

        private void lvTemplates_DoubleClick(object sender, EventArgs e)
        {
            if (lvTemplates.SelectedItems.Count == 1)
            {



                int _Id = 0 ;

                ListView.SelectedListViewItemCollection items = lvTemplates.SelectedItems;

                ListViewItem lvItem = items[0];
                string[] Ids = lvItem.Text.Split('-');

               

                this.KillRunningProcess();

                if (!String.IsNullOrEmpty(Ids[0]))
                {
                    int.TryParse(Ids[0], out _Id);

                    this.ShowTemplate(_Id);
                }


            }
        }

        private void ShowTemplate(int _Id)
        {
            ReportFilePath = "C:\\NR";
            ReportFileNameWithPath = ReportFilePath + @"\" + _Id.ToString()  + ".docx";

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


            g_document = DocX.Load(@ReportFileNameWithPath);
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
                        //ViewModelReportTests _vmRT = (ViewModelReportTests)txtCurrentTestName.Tag;

                        //int length = (int)b.BaseStream.Length;
                        //byte[] ReportContent = new byte[length];
                        //b.Read(ReportContent, 0, length);

                        //bool isReportExists = new TemplateService().IsReportExists(txtBillNo.Text, (ViewModelReportTests)txtCurrentTestName.Tag);

                        //MsWordReport newReport = new MsWordReport();
                        //newReport.RegNo = txtBillNo.Text;
                        //newReport.TestInfo = _vmRT;
                        //newReport.ReportContent = ReportContent;
                        //newReport._ReportDoctor = _doctor;
                        //newReport.PreparedBy = lblPreparedBy.Text;
                        //newReport.PreparedDate = DateTime.Now;
                        //newReport.Preparedtime = DateTime.Now.ToString("hh:mm:ss");
                        //newReport.ReportType = _vmRT.GroupName;
                        //string msg = string.Empty;

                        //if (isReportExists)
                        //{
                        //    msg = new TemplateService().UpdateReport(newReport);
                        //}
                        //else
                        //{
                        //    msg = new TemplateService().SaveReport(newReport);
                        //}

                        //if (_vmRT.GroupId == 18)
                        //{
                        //    // new PatientService().SetUSGDoctorOnDailyStatement(txtRegNo.Text, _doctor);
                        //}

                        //unlocked = false;
                        //txtTemplate.Text = "";
                        //unlocked = true;


                        //if (String.Compare(msg, "Success") == 0)
                        //{
                        //    // MessageBox.Show("File Saved");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Save to DB Fail.");
                        //}

                        //txtBillNo.Focus();

                        //Thread t = new Thread(new ThreadStart(this.UpdateReportList));
                        //t.IsBackground = true;
                        //t.Start();

                        //this.Invoke(new MethodInvoker(this.ShowReportsOnListView("", DateTimePicker.Value))); 


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HERP");
            }

        }
    
        private DocX CreateReportFromTemplate(DocX template)
        {
          

            //if (txtCurrentTestName.Tag != null)
            //{
            //    ViewModelReportTests reportTest = (ViewModelReportTests)txtCurrentTestName.Tag;
            //    string reportGroupName = Utility.GetReportGroupName(reportTest.GroupId);
            //    template.ReplaceText("Report_Type", reportGroupName);
            //}


            //template.ReplaceText("bill_no", GetPrefixedIdString(txtBillNo.Text));
            //template.ReplaceText("member_regno", txtMemberRegNo.Text);
            //template.ReplaceText("Reg_No", txtBillNo.Text);
            //template.ReplaceText("Admission_No", "");
            //template.ReplaceText("Received_date", txtDate.Text);
            //template.ReplaceText("Report_Date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
            ////template.ReplaceText("daily_id", txtDID.Text);
            //template.ReplaceText("Report_Date", DateTime.Now.ToString("dd/MM/yyyy"));
            //template.ReplaceText("Patient_Name", txtPatientName.Text);
            //template.ReplaceText("Patient_Age", txtAge.Text.Replace(" ", ""));
            //template.ReplaceText("Patient_Sex", txtSex.Text);
            //template.ReplaceText("Refd_By", txtRefBy.Text);
            //if (!String.IsNullOrWhiteSpace(txtCabin.Text))
            //{
            //    template.ReplaceText("Cabin_No", "Cabin :" + txtCabin.Text);
            //}
            //else
            //{
            //    template.ReplaceText("Cabin_No", "");
            //}
            //template.ReplaceText("Test_Name", txtCurrentTestName.Text);

            //if (txtDID.Tag != null)
            //{
            //    template.ReplaceText("Report_No", txtDID.Tag.ToString());

            //}
            //else
            //{
            //    template.ReplaceText("Report_No", "");
            //}

           

            return template;
        }
    

        private void KillRunningProcess()
        {
            Process[] procs = Process.GetProcessesByName("winword");

            foreach (Process proc in procs)
                proc.Kill();
        }
    }
}
