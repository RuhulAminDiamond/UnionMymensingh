using HDMS.Model.HR;
using HDMS.Service.HR;
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
using System.IO;
using HDMS.Model.HR.VM;
using System.Diagnostics;
using HDMS.Service.Diagonstics;
using HDMS.Model.Enums;
using HDMS.Windows.Forms.UI.Reports.HR;
using CrystalDecisions.Windows.Forms;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmJobCV : Form
    {
        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;


        public frmJobCV()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                JobCirculation _Jc = (JobCirculation)txtCirculationNo.Tag;
                string _fileName = string.Empty;
                byte[] PdfCvContents = null;
                byte[] WordCvContents = null;

                if (!String.IsNullOrEmpty(txtFile.Text))
                {
                    using (BinaryReader b = new BinaryReader(File.Open(txtFile.Text, FileMode.Open)))
                    {

                        int length = (int)b.BaseStream.Length;
                        byte[] File1Content = new byte[length];
                        b.Read(File1Content, 0, length);
                        PdfCvContents = File1Content;
                        string[] fileName = new string[2];
                        fileName = Path.GetFileName(txtFile.Text).Split('.');
                        _fileName = fileName[0];

                    }
                }

                if (!String.IsNullOrEmpty(txtWordCV.Text))
                {
                    using (BinaryReader b2 = new BinaryReader(File.Open(txtWordCV.Text, FileMode.Open)))
                    {

                        int length = (int)b2.BaseStream.Length;
                        byte[] File1Content = new byte[length];
                        b2.Read(File1Content, 0, length);
                        WordCvContents = File1Content;
                        string[] fileName = new string[2];
                        fileName = Path.GetFileName(txtWordCV.Text).Split('.');
                        _fileName = fileName[0];

                    }
                }

                if (txtCirculationNo.Tag != null)
                    {
                        JobCV _JCv = new JobCV();
                        _JCv.JCId = _Jc.JCId;
                        _JCv.Applyfor = cmbPosts.Text;
                        _JCv.ApplicatName = txtApplicantName.Text;
                        _JCv.FileName = _fileName;
                        _JCv.CVInPdf = PdfCvContents;
                        _JCv.CVInWord = WordCvContents;
                        _JCv.ApplicatMobileNo = txtMobileNo.Text;
                        if (new HrCommonService().AddJobCv(_JCv))
                        {
                            MessageBox.Show("Data Saved Successful.");
                            //texManufacturerTextBox = "";
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Data Saved Failed.");
                        }
                    }
                

            }catch(Exception ex)
            {


            }

          /*  if (txtCirculationNo.Tag != null)
            {
                JobCV _JCv = new HrCommonService().GetJobCVById(Convert.ToInt32(((JobCV)txtCirculationNo.Tag).JCVId));
                if (txtCirculationNo.Tag!=null)
                {
                    _JCv.JCId = _JCv.JCId;
                    _JCv.Applyfor = cmbPosts.Text;
                    _JCv.ApplicatName = txtApplicantName.Text;
                    _JCv.ApplicatMobileNo = txtMobileNo.Text;

                    if (new HrCommonService().UpdateJobCv(_JCv))
                    {
                        MessageBox.Show("Update Successful.");
                        txtCirculationNo.Text = "";
                        txtApplicantName.Text = "";
                        txtMobileNo.Text="";
                        txtCirculationNo.Tag = null;
                        btnSave.Text = "Save";
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        LoadData();

                    }
                }
            }
            else
            {
                if (txtCirculationNo.Tag!=null)
                {
                     JobCV _JCv = new JobCV();
                    _JCv.JCId = _JCv.JCId;
                    _JCv.Applyfor = cmbPosts.Text;
                    _JCv.ApplicatName = txtApplicantName.Text;
                    _JCv.ApplicatMobileNo = txtMobileNo.Text;
                    if (new HrCommonService().AddJobCv(_JCv))
                    {
                        MessageBox.Show("Data Saved Successful.");
                        //texManufacturerTextBox = "";
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Data Saved Failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Must be entry.");
                }
            } */
        }

        private void LoadData()
        {
            IList<JobCVDetail> cvList = new HrCommonService().GetJobCvs((JobCirculation)txtCirculationNo.Tag);
            FillCVGrid(cvList);

            UpdateStatusToGrid();
        }

        private void FillCVGrid(IList<JobCVDetail> cvList)
        {
            dgCVs.SuspendLayout();
            dgCVs.Rows.Clear();

         

            foreach (var item in cvList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 75;
                row.Tag = item;
          
                row.CreateCells(dgCVs,item.JobCircularNo, item.Applyfor,item.ApplicatName,item.ApplicatMobileNo);
              
                dgCVs.Rows.Add(row);
             
            }

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Name = "img";
            iconColumn.HeaderText = "CV File";
            if (dgCVs.Columns.Contains("img") && dgCVs.Columns["img"].Visible)
            {

            }else
            {
                dgCVs.Columns.Insert(4, iconColumn);
            }


            SetCVIcons();

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.FalseValue = true;
            dgvCmb.HeaderText = "In ShortList";

            if (dgCVs.Columns.Contains("Chk") && dgCVs.Columns["Chk"].Visible)
            {

            }else
            {
                dgCVs.Columns.Add(dgvCmb);
            }
          
            
        }

        private void SetCVIcons()
        {
            Bitmap pdfImage = new Bitmap(this.imgListLarge2.Images[2]);
            Bitmap wordImage = new Bitmap(this.imgListLarge.Images[1]);
            Bitmap noFileImage = new Bitmap(this.imgListLarge.Images[2]);




            foreach (DataGridViewRow row in dgCVs.Rows)
            {
                JobCVDetail _cv = row.Tag as JobCVDetail;

                if (_cv.CVInPdf != null)
                    row.Cells["img"].Value = pdfImage;

                if (_cv.CVInWord != null)
                    row.Cells["img"].Value = wordImage;

                if (_cv.CVInPdf == null && _cv.CVInWord == null) row.Cells["img"].Value = noFileImage;

            }
        }
        private void dgDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            JobCirculation _gr = new HrCommonService().GetCircularById(Convert.ToInt32(dgCVs.Rows[e.RowIndex].Cells["JCId"].Value));
        
            if (_gr != null)
            {
                txtCirculationNo.Text = _gr.CirculationNo;
                txtApplicantName.Text = _gr.CirculationTitle;
                txtApplicantName.Tag = _gr;
                btnSave.Text = "Update";
                btnCancel.Visible = true;
                btnDelete.Visible = true;

            }
        }

        public void ViewPdfCV(JobCVDetail _jcd)
        {
            try
            {
               

                ReportFilePath = new TemplateService().GetNewReportFilePath();

                byte[] _reportcontent = null; 

                if (_jcd.CVInPdf != null)
                {
                    ReportFileNameWithPath = ReportFilePath + @"\" + DateTime.Now.Ticks.ToString() + "-" + "test" + ".pdf";
                    _reportcontent= _jcd.CVInPdf;
                }
                else
                {
                    ReportFileNameWithPath = ReportFilePath + @"\" + DateTime.Now.Ticks.ToString() + "-" + "test" + ".docx";
                    _reportcontent = _jcd.CVInWord;
                }
   
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
                br.Write(_reportcontent);
                fsmaster.Dispose();
                br.Dispose();



                ProcessStartInfo psi = new ProcessStartInfo(ReportFileNameWithPath);
                Process process = Process.Start(psi);
                //  process.EnableRaisingEvents = true;


                //process.WaitForExit();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCirculationNo.Text = "";
            txtApplicantName.Text = "";
            txtApplicantName.Tag = null;
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtApplicantName.Tag != null)
            {
                EmpDepartment _gr = new HrCommonService().GetDeptById(Convert.ToInt32(((EmpDepartment)txtApplicantName.Tag).DeptId));
                if (_gr != null)
                {
                    if (new HrCommonService().DeleteDept(_gr))
                    {
                        MessageBox.Show("Successfully Deleted.");
                        LoadData();
                    }
                }

            }
        }

        private void frmDeptEntry_Load(object sender, EventArgs e)
        {

            ctrlJobCircularSearch.Location = new Point(txtCirculationNo.Location.X, txtCirculationNo.Location.Y);
            ctrlJobCircularSearch.ItemSelected += ctrlJobCircularSearch_ItemSelected;


            // LoadData();
        }

        private void ctrlJobCircularSearch_ItemSelected(SearchResultListControl<JobCirculation> sender, JobCirculation item)
        {
            txtCirculationNo.Text = item.CirculationNo;
            txtCirculationNo.Tag = item;
            cmbPosts.Focus();
            sender.Visible = false;

            LoadData();

            
        }

        private void txtCirculationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space)
            {
                ctrlJobCircularSearch.Visible = true;
                ctrlJobCircularSearch.LoadData();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            opfd.Title = "Select Files";
            opfd.Filter = "Pdf|*.pdf";
            opfd.FileName = null;
            string fileName;
            if (opfd.ShowDialog() != DialogResult.Cancel)
            {
                // querybuilder qu = new querybuilder();
                txtFile.Text = opfd.FileName;
                fileName = opfd.FileName;
                Object refmissing = System.Reflection.Missing.Value;
                txtWordCV.Text = "";

            }
        }

        private void btnBrowseWord_Click(object sender, EventArgs e)
        {
            opdWord.Title = "Select Files";
            opdWord.Filter = "MS-Word|*.docx";
            opdWord.FileName = null;
            string wordfileName;
            if (opdWord.ShowDialog() != DialogResult.Cancel)
            {
                // querybuilder qu = new querybuilder();
                txtWordCV.Text = opdWord.FileName;
                wordfileName = opdWord.FileName;
                Object refmissing = System.Reflection.Missing.Value;
                txtFile.Text = "";

            }
        }

        private void dgCVs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgCVs.CurrentRow;
            JobCVDetail _jcd = row.Tag as JobCVDetail;

            if(_jcd.CVInPdf==null && _jcd.CVInWord == null)
            {
                MessageBox.Show("No attachment found."); return;
            }
            else
            {
                ViewPdfCV(_jcd);
            }
            

        }

        private void btnPrintShortList_Click(object sender, EventArgs e)
        {
            try
            {

                List<JobCV> _cvList = new List<JobCV>();

                foreach (DataGridViewRow row in dgCVs.Rows)
                {
                    if (row.Cells["Chk"].Value!=null && (bool)row.Cells["Chk"].Value == true)
                    {
                        JobCVDetail _jcd = row.Tag as JobCVDetail;
                        JobCV _jc = new HrCommonService().GetJobCvById(_jcd.JCVId);
                        _jc.Status = JobCvStatusEnum.InShortList.ToString();
                        _cvList.Add(_jc);
                    }
                }


              
                if (_cvList.Count > 0)
                {
                    new HrCommonService().UpdateCVStatus(_cvList);
                    // MessageBox.Show("Sample received successful.");
                     ViewShortListedCV();
                    // ClearWindow();

                }
            }
            catch (Exception ex)
            {


            }

            UpdateStatusToGrid();

        }

        private void ViewShortListedCV()
        {
            if (txtCirculationNo.Tag != null)
            {
                JobCirculation _jc = (JobCirculation)txtCirculationNo.Tag;
                DataSet ds = new HrCommonService().GetShortlistedApplicants(_jc);

                rptApplicantShortList _rpt = new rptApplicantShortList();

                _rpt.SetDataSource(ds.Tables[0]);

                ReportViewer rv = new ReportViewer();
                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();


            }
        }

        private void UpdateStatusToGrid()
        {
            foreach (DataGridViewRow row in dgCVs.Rows)
            {
                JobCVDetail _jcd = row.Tag as JobCVDetail;

                if (_jcd.Status == JobCvStatusEnum.InShortList.ToString())
                {
                    //chkParent.Checked = true;
                    row.Cells["Chk"].Value = true;
                }
                else
                {
                    row.Cells["Chk"].Value = false;
                }

            }
        }

        private void ctrlJobCircularSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCirculationNo.Focus();
            }
        }
    }
}
