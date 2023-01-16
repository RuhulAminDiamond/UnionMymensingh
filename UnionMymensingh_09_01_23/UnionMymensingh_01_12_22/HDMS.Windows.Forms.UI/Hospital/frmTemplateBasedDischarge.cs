using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Service.Diagonstics;
using System.IO;
using Novacode;
using System.Diagnostics;
using System.Threading;
using HDMS.Model;
using HDMS.Model.Common;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmTemplateBasedDischarge : Form
    {
        string TempChildReoprtNameWithPath = string.Empty;
        string TempMasterReoprtNameWithPath = string.Empty;
        string ReportFilePath = string.Empty;
        string ReportFileNameWithPath = string.Empty;

        public delegate void _UpdateRepotListOnWordFileClose(string regNo, DateTime _date);

        static DocX g_document;


        public frmTemplateBasedDischarge()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgPatient.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgPatient.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          txtTime.Text = Utils.GetServerDateAndTime().ToString("HH:mm:ss tt");
        }

        private void frmTemplateBasedDischarge_Load(object sender, EventArgs e)
        {
            HideDeafaultHidden();

            ctrlDischareTemplateSearchControl.Location = new Point(txtTemplate.Location.X, txtTemplate.Location.Y + txtTemplate.Height);
            ctrlDischareTemplateSearchControl.ItemSelected += ctrlDischareTemplateSearchControl_ItemSelected;

            ctrlMedicalOfficerSearchControl.Location = new Point(txtMedicalOfficer.Location.X, txtMedicalOfficer.Location.Y + txtMedicalOfficer.Height);
            ctrlMedicalOfficerSearchControl.ItemSelected += ctrlMedicalOfficerSearchControl_ItemSelected;

            dtpDischarge.Value = Utils.GetServerDateAndTime();
            LoadPatients();
        }

        private void ctrlMedicalOfficerSearchControl_ItemSelected(SearchResultListControl<ReportConsultant> sender, ReportConsultant item)
        {
            txtMedicalOfficer.Text = item.Name;
            txtMedicalOfficer.Tag = item;
            txtMedicalOfficer.Focus();
            sender.Visible = false;
        }

        private void HideDeafaultHidden()
        {
            ctrlDischareTemplateSearchControl.Visible = false;
            ctrlMedicalOfficerSearchControl.Visible = false;
        }

        private void ctrlDischareTemplateSearchControl_ItemSelected(SearchResultListControl<DischargeTemplate> sender, DischargeTemplate item)
        {
            txtTemplate.Text = item.TemplateName;
            txtTemplate.Tag = item;
            txtTemplate.Focus();
            sender.Visible = false;
        }

        private async void LoadPatients()
        {
            List<VMIPDInfo> _lisPatientInfo = await new HospitalService().GetCurrentIPDInfo();

            FillListGrid(_lisPatientInfo);
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
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoBySearchParameter(_prefix, type).ToList();

            if (_lisPatientInfo.Count() == 0) return;

            // lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
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

                if (_mo != null && _dt != null)
                {
                    ShowTemplate(_dt.TId);

                }else
                {
                    MessageBox.Show("Medical Officer Or Template not selected. Plz. Check it and try again "); return;
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

        private DocX CreateReportFromTemplate(DocX template)
        {

            VMIPDInfo _pInfo = ((VMIPDInfo)lblCabin.Tag);

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
            template.ReplaceText("A_Time", _pInfo.AdmTime);
            template.ReplaceText("P_Bed", lblCabin.Text);
            template.ReplaceText("P_Mobile", _pInfo.MobileNo);
            template.ReplaceText("Assign_Doctor", _pInfo.AssignedDoctor);

            string[] rrList = new string[4];
              rrList[0]="12345";
            rrList[1] = "12345";
            rrList[2] = "12345";
            rrList[3] = "12345";

            Table placeholderTable = template.Tables[1];

           // Table t = placeholderTable.InsertTableAfterSelf(4, 4);


            Table t = placeholderTable.InsertTableAfterSelf(4, 4);

            template.AddTable(rrList.Length, 2);
            for (int i = 0; i <= rrList.Length-1; i++)
            {
                t.Rows[i].Cells[0].Paragraphs.First().Append(rrList[i]);
                t.Rows[i].Cells[1].Paragraphs.First().Append(rrList[i]);
            }

           

            placeholderTable.Remove();




            //if (txtDID.Tag != null)
            //{
            //    template.ReplaceText("Report_No", txtDID.Tag.ToString());

            //}
            //else
            //{
            //    template.ReplaceText("Report_No", "");
            //}

            //ReportConsultant _doctor = (ReportConsultant)cmbConsultant.SelectedItem;

            //template.ReplaceText("Doctor_Name", _doctor.Name);
            //template.ReplaceText("Identity_Line1", _doctor.DIdentityLine1);
            //template.ReplaceText("Identity_Line2", _doctor.DIdentityLine2);
            //template.ReplaceText("Identity_Line3", _doctor.DIdentityLine3);
            //template.ReplaceText("Identity_Line4", _doctor.DIdentityLine4);
            //template.ReplaceText("Identity_Line5", " ");

            return template;
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

                       

                       DischargeCertificateTemplateBased _dc = new DischargeCertificateTemplateBased();
                        _dc.RCId = 1;
                        _dc.DCPrintDate = Utils.GetServerDateAndTime();
                        _dc.DCPrintTime = Utils.GetServerDateAndTime().ToString("hh:mm tt"); 
                        _dc.DCContent = ReportContent;
                      

                        string msg = string.Empty;
                        msg = new TemplateService().UpdateDischargeReport(_dc);


                        if (String.Compare(msg, "Success") == 0)
                        {
                            //MessageBox.Show("File Updated");
                        }
                        else
                        {
                            MessageBox.Show("DB. Update Fail.");
                        }

                        txtTemplate.Focus();

                        //Thread t = new Thread(new ThreadStart(this.UpdateReportList));
                        //t.IsBackground = true;
                        //t.Start();


                        //this.ShowReportsOnListView("", DateTimePicker.Value);


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HERP");
            }

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
    }
}
